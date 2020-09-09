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

        //Constructoe
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

        //Busca un registro en la base de datos
        /*private void BuscarButton_Click(object sender, RoutedEventArgs e)
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
        }*/

        //Agrega una materia al detalle de la inscripcion
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

        //Remueve una materia del detalle
        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if(DetalleDataGrid.SelectedIndex == -1) { return; }
            var detalle = (InscripcionesDetalle)DetalleDataGrid.SelectedItem;
            Inscripcion.CantidadMateria--;
            Inscripcion.CreditosSelccionados -= detalle.Materia.Creditos;

            Inscripcion.InscripcionesDetalles.RemoveAt(DetalleDataGrid.SelectedIndex);

            Cargar();

        }

        //Limpia el WPF para dar lugar a un nuevo detalle.
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        //Guarda un nuevo registro a la base de datos
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

        //Elimina un registro de la base de datos
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

        //Actualiza el WPF
        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Inscripcion;
        }

        //Permite agignar un estudiante a la inscripcion
        private void MatriculaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MatriculaComboBox.SelectedIndex == -1)
                return;

            var estudiante = (Estudiantes)MatriculaComboBox.SelectedItem;
            Inscripcion.Estudiante = estudiante;
            MateriaComboBox.ItemsSource = PensumBLL.GetPensumMaterias(estudiante.PensumId);
        }

        //Permite selecionar una materia para luego agregarla al detalle de la inscripcion.
        private void MateriaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(MateriaComboBox.SelectedIndex == -1) { return; };
            Materia = (Materias)MateriaComboBox.SelectedItem;
            HorasPracticasDetalleTextBox.Text = Materia.HorasPracticas.ToString();
            HorasTeoricasDetalleTextBox.Text = Materia.HorasTeoricas.ToString();
            CreditosDetalleTextBox.Text = Materia.Creditos.ToString();
        }

        //Limpia el WPF
        public void Limpiar()
        {
            Inscripcion = new Inscripciones();
            this.DataContext = Inscripcion;
        }

        //Valida todos los campos del WPF.
        public bool Validar()
        {
            //Valida que el se haya ingresado un Id valido
            if(!Regex.IsMatch(InscripcionIdTextBox.Text, "^[1-9]+${1,5}"))
            {
                MessageBox.Show("Asegúrese de haber introducido un Id de caracter numérico y diferente de cero.", 
                    "Id no valido", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        //Valida el agregar.
        public bool ValidarAgregar()
        {
            //Valida que se haya selcionado un estudiante
            if (MateriaComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una materia para poder agregarla a la inscripcion.",
                    "Id no valido", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            //Valida que no se ingrese una materia 2 veces en la misma inscripcion
            if(Inscripcion.InscripcionesDetalles.Any(i => i.Clave == MateriaComboBox.SelectedValue.ToString()))
            {
                MessageBox.Show("Esta materia ya se encuntra agregada en la inscripción.", "Aviso.",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            //Valida que no se agregue una materia que ya haya sido inscrita.
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

        //todo: OJO CON ESTO... Al agregar el WPF aparentemente se limpia.
        private void InscripcionIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!Regex.IsMatch(InscripcionIdTextBox.Text, "^[0-9]+${1,8}")) {
                LimpiarEnBusuqeda();
                return;
            }
            var encontrado = InscripcionesBLL.Buscar(int.Parse(InscripcionIdTextBox.Text));

            if (encontrado != null)
            {
                Inscripcion = encontrado;
                this.DataContext = Inscripcion;
                DetalleDataGrid.ItemsSource = Inscripcion.InscripcionesDetalles;
            }
            else
            {
                LimpiarEnBusuqeda();
                return;
            }
        }

        public void LimpiarEnBusuqeda()
        {
            DetalleDataGrid.ItemsSource = null;
            MateriaComboBox.SelectedIndex = -1;
            FechaDatePicker.SelectedDate = DateTime.Now;
            CreditosSelccionadosTextBox.Clear();
            CantidadMateriaTextBox.Clear();
            Inscripcion = new Inscripciones();
        }
    }
}
