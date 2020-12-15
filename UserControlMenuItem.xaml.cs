using PensumProgresoAcademico.UI.Registros;
using PensumProgresoAcademico.UI.Consultas.cMaterias;
using PensumProgresoAcademico.UI.Consultas.cPensum;
using PensumProgresoAcademico.UI.Consultas.cInscripciones;
using PensumProgresoAcademico.UI.Consultas.cEstudiantes;
using PensumProgresoAcademico.UI.Registros.rInscripciones;
using PensumProgresoAcademico.UI.Registros.rMaterias;
using PensumProgresoAcademico.UI.Registros.rPensum;
using PensumProgresoAcademico.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PensumProgresoAcademico.UI.Consultas.cAmbitoPensum;

namespace PensumProgresoAcademico
{
    /// <summary>
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        ItemMenu aux;

        public UserControlMenuItem(ItemMenu itemMenu)
        {
            InitializeComponent();
            ExpandeMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
            aux = itemMenu;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ListViewMenu.SelectedIndex == -1) { return; }
            var a = (SubItem)ListViewMenu.SelectedItem;
            if(aux.Header == "Registros")
            {
                switch (a.Name)
                {
                    case "Materia":
                        rMaterias m = new rMaterias();
                        m.Show();

                        ListViewMenu.SelectedIndex = -1;
                        break;
                    case "Pensum":
                        rPensum rPensum = new rPensum();
                        rPensum.Show();
                        ListViewMenu.SelectedIndex = -1;
                        break;
                    case "Estudiante":
                        rEstudiantes rEstudiantes = new rEstudiantes();
                        rEstudiantes.Show();
                        ListViewMenu.SelectedIndex = -1;
                        break;
                    case "Inscripción":
                        rInscripciones rInscripciones = new rInscripciones();
                        rInscripciones.Show();
                        ListViewMenu.SelectedIndex = -1;
                        break;
                }
            }else if(aux.Header == "Consultas"){
                switch (a.Name)
                {
                    case "Materia":
                        cMaterias cMaterias = new cMaterias();
                        cMaterias.Show();
                        ListViewMenu.SelectedIndex = -1;
                        break;
                    case "Pensum":
                        cPensum cPensum = new cPensum();
                        cPensum.Show();
                        ListViewMenu.SelectedIndex = -1;
                        break;
                    case "Estudiante":
                        cEstudiantes cEstudiantes = new cEstudiantes();
                        cEstudiantes.Show();
                        ListViewMenu.SelectedIndex = -1;
                        break;
                    case "Inscripción":
                        cInscripciones cInscripciones = new cInscripciones();
                        cInscripciones.Show();
                        ListViewMenu.SelectedIndex = -1;
                        break;
                    case "Ámbito de Pensum":
                        cAmbitoPensum cAmbitoPensum = new cAmbitoPensum();
                        cAmbitoPensum.Show();
                        ListViewMenu.SelectedIndex = -1;
                        break;
                }
            }
            
        }
    }
}
