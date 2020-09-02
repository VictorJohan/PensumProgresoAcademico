using PensumProgresoAcademico.BLL;
using PensumProgresoAcademico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PensumProgresoAcademico.UI.Registros.rInscripciones
{
    /// <summary>
    /// Interaction logic for rInscripciones.xaml
    /// </summary>
    public partial class rInscripciones : Window
    {
        private Inscripciones Inscripcion = new Inscripciones();
        private Materias Materia;

        public rInscripciones()
        {
            InitializeComponent();
            this.DataContext = Inscripcion;
            //Llenando comboBox con estudiantes
            MatriculaComboBox.ItemsSource = EstudiantesBLL.GetEstudiantes();
            MatriculaComboBox.SelectedValuePath = "Matricula";
            MatriculaComboBox.DisplayMemberPath = "Nombres";

            //Dando dirreccion y despliegue
            MateriaComboBox.SelectedValuePath = "Clave";
            MateriaComboBox.DisplayMemberPath = "Descripcion";
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }

            var encontrado = InscripcionesBLL.Buscar(int.Parse(InscripcionIdTextBox.Text));

            if (encontrado != null)
            {
                Inscripcion = encontrado;
                this.DataContext = Inscripcion;
            }
            else
            {
                MessageBox.Show("No hay una inscripción con este Id.", "No se encontro la Inscripción.",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarAgregar()) { return; }

            var detalle = new InscripcionesDetalle
            {
                Id = 0,
                InscripcionId = int.Parse(InscripcionIdTextBox.Text),
                Clave = MateriaComboBox.SelectedValue.ToString()
                
            };

            detalle.Materia = (Materias)MateriaComboBox.SelectedItem;
           
            Inscripcion.InscripcionesDetalles.Add(detalle);
            Inscripcion.CantidadMateria++;
            Inscripcion.CreditosSelccionados += detalle.Materia.Creditos;

            Cargar();

            HorasPracticasDetalleTextBox.Clear();
            HorasTeoricasDetalleTextBox.Clear();
            CreditosDetalleTextBox.Clear();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if(DetalleDataGrid.SelectedIndex == -1) { return; }
            var detalle = (InscripcionesDetalle)DetalleDataGrid.SelectedItem;
            Inscripcion.CantidadMateria--;
            Inscripcion.CreditosSelccionados -= detalle.Materia.Creditos;

            Inscripcion.InscripcionesDetalles.RemoveAt(DetalleDataGrid.SelectedIndex);

            Cargar();

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }

            if (InscripcionesBLL.Guardar(Inscripcion))
            {
                MessageBox.Show("Guardado.", "Aviso.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Algo salió mal, no se logró guardar la inscripción.", "Error.",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }

            if (!Regex.IsMatch(InscripcionIdTextBox.Text, "^[1-9]+${1,5}"))
            {
                MessageBox.Show("El Id que ha ingresado no es válido.\nVerifique que haya ingresado un caracter numerico y que este " +
                    "sea diferente de cero.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (InscripcionesBLL.Eliminar(int.Parse(InscripcionIdTextBox.Text)))
            {
                MessageBox.Show("Inscripción eliminada.", "Aviso.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Algo salió mal, no se logró eliminar la inscripción.", "Error.",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Inscripcion;
        }

        private void MatriculaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MatriculaComboBox.SelectedIndex == -1)
                return;

            var estudiante = (Estudiantes)MatriculaComboBox.SelectedItem;
            Inscripcion.Estudiante = estudiante;
            MateriaComboBox.ItemsSource = PensumBLL.GetPensumMaterias(estudiante.PensumId);
        }

        private void MateriaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(MateriaComboBox.SelectedIndex == -1) { return; };
            Materia = (Materias)MateriaComboBox.SelectedItem;
            HorasPracticasDetalleTextBox.Text = Materia.HorasPracticas.ToString();
            HorasTeoricasDetalleTextBox.Text = Materia.HorasTeoricas.ToString();
            CreditosDetalleTextBox.Text = Materia.Creditos.ToString();
        }

        public void Limpiar()
        {
            Inscripcion = new Inscripciones();
            this.DataContext = Inscripcion;
        }

        public bool Validar()
        {
            if(!Regex.IsMatch(InscripcionIdTextBox.Text, "^[1-9]+${1,5}"))
            {
                MessageBox.Show("Asegúrese de haber introducido un Id de caracter numérico y diferente de cero.", 
                    "Id no valido", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        public bool ValidarAgregar()
        {
            if (MateriaComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una materia para poder agregarla a la inscripcion.",
                    "Id no valido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if(Inscripcion.InscripcionesDetalles.Any(i => i.Clave == MateriaComboBox.SelectedValue.ToString()))
            {
                MessageBox.Show("Esta materia ya se encuntra agregada en la inscripción.", "Aviso.",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if(InscripcionesBLL.MateriaInscrita(MateriaComboBox.SelectedValue.ToString(), int.Parse(MatriculaComboBox.SelectedValue.ToString())))
            {
                MessageBox.Show("Esta materia ya fue inscrita.",
                   "Aviso.", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            this.Topmost = false;
            this.Focus();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            this.Topmost = true;
            this.Focus();
        }
    }
}
