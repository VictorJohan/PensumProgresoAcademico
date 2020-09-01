using PensumProgresoAcademico.UI.Registros;
using PensumProgresoAcademico.UI.Registros.rInscripciones;
using PensumProgresoAcademico.UI.Registros.rMaterias;
using PensumProgresoAcademico.UI.Registros.rPensum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PensumProgresoAcademico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //todo: Crear con sultas.
        //todo: Documentar todo el proyecto.
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            rEstudiantes rEstudiantes = new rEstudiantes();
            rEstudiantes.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            rInscripciones rInscripciones = new rInscripciones();
            rInscripciones.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            rMaterias rMaterias = new rMaterias();
            rMaterias.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            rPensum rPensum = new rPensum();
            rPensum.Show();
        }
    }
}
