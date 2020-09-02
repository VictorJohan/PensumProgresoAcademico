using MaterialDesignThemes.Wpf;
using PensumProgresoAcademico.UI.Consultas.cEstudiantes;
using PensumProgresoAcademico.UI.Consultas.cInscripciones;
using PensumProgresoAcademico.UI.Consultas.cMaterias;
using PensumProgresoAcademico.UI.Consultas.cPensum;
using PensumProgresoAcademico.UI.Registros;
using PensumProgresoAcademico.UI.Registros.rInscripciones;
using PensumProgresoAcademico.UI.Registros.rMaterias;
using PensumProgresoAcademico.UI.Registros.rPensum;
using PensumProgresoAcademico.ViewModel;
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
        //todo: Documentar todo el proyecto.
        public MainWindow()
        {
            InitializeComponent();

            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Materia"));
            menuRegister.Add(new SubItem("Pensum"));
            menuRegister.Add(new SubItem("Estudiante"));
            menuRegister.Add(new SubItem("Inscripción"));
            var item = new ItemMenu("Registros", menuRegister, PackIconKind.Register);

            var menuConsulta = new List<SubItem>();
            menuConsulta.Add(new SubItem("Materia"));
            menuConsulta.Add(new SubItem("Pensum"));
            menuConsulta.Add(new SubItem("Estudiante"));
            menuConsulta.Add(new SubItem("Inscripción"));
            var item2 = new ItemMenu("Consultas", menuConsulta, PackIconKind.Search);

           
            MenuStackPanel.Children.Add(new UserControlMenuItem(item));
            MenuStackPanel.Children.Add(new UserControlMenuItem(item2));
            
            


        }


    }
}
