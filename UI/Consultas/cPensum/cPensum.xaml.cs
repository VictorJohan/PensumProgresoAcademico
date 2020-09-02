using PensumProgresoAcademico.BLL;
using PensumProgresoAcademico.Entidades;
using System;
using System.Collections.Generic;
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

namespace PensumProgresoAcademico.UI.Consultas.cPensum
{
    /// <summary>
    /// Interaction logic for cPensum.xaml
    /// </summary>
    public partial class cPensum : Window
    {
        string[] filtro = { "Pensum Id", "Carrera", "Duración", "Titulo", "Total Materias", "Horas Teoricas", "Horas Practicas", "Créditos" };
        public cPensum()
        {
            InitializeComponent();
            FiltroComboBox.ItemsSource = filtro;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Pensum> lista = new List<Pensum>();
            if (FiltroComboBox.SelectedIndex != -1)
            {
                switch (FiltroComboBox.SelectedItem.ToString())
                {
                    case "Pensum Id":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un Id válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = PensumBLL.GetPensum(p => p.PensumId == int.Parse(CriterioTextBox.Text));
                        break;
                    case "Carrera":

                        lista = PensumBLL.GetPensum(p => p.Carrera == CriterioTextBox.Text);
                        break;
                    case "Duración":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = PensumBLL.GetPensum(p => p.Duracion == int.Parse(CriterioTextBox.Text));
                        break;

                    case "Titulo":

                        lista = PensumBLL.GetPensum(p => p.TituloOtorgar == CriterioTextBox.Text);
                        break;

                    case "Total Materias":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = PensumBLL.GetPensum(p => p.TotalMaterias == int.Parse(CriterioTextBox.Text));
                        break;

                    case "Horas Teoricas":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = PensumBLL.GetPensum(p => p.PensumHorasTeoricas == int.Parse(CriterioTextBox.Text));
                        break;

                    case "Horas Practicas":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = PensumBLL.GetPensum(p => p.PensumHorasPracticas == int.Parse(CriterioTextBox.Text));
                        break;

                    case "Créditos":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = PensumBLL.GetPensum(p => p.PensumCreditos == int.Parse(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                lista = PensumBLL.GetPensum();
            }

            DetalleDataGrid.ItemsSource = lista;
            FiltroComboBox.SelectedIndex = -1;
        }
    }
}
