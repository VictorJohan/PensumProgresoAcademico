using PensumProgresoAcademico.BLL;
using PensumProgresoAcademico.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
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

        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {

            var detalle = new InscripcionesDetalle
            {
                Id = 0,
                InscripcionId = int.Parse(InscripcionIdTextBox.Text),
                Clave = MateriaComboBox.SelectedValue.ToString()
                
            };

            detalle.Materia = (Materias)MateriaComboBox.SelectedItem;
            Inscripcion.InscripcionesDetalles.Add(detalle);
            Cargar();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
