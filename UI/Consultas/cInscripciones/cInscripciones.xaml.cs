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

namespace PensumProgresoAcademico.UI.Consultas.cInscripciones
{
    /// <summary>
    /// Interaction logic for cInscripciones.xaml
    /// </summary>
    public partial class cInscripciones : Window
    {
        string[] filtro = { "Inscripcion Id", "Estudiante Matricula", "Créditos Selccionados", "Cantidad Materia", "Fecha", "Todo" };
        public cInscripciones()
        {
            InitializeComponent();
            FiltroComboBox.ItemsSource = filtro;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Inscripciones> lista = new List<Inscripciones>();
            if (FiltroComboBox.SelectedIndex == -1) { return; }
            if (FiltroComboBox.SelectedItem.ToString() != "Todo")
            {
                switch (FiltroComboBox.SelectedItem.ToString())
                {
                    case "Inscripcion Id":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = InscripcionesBLL.GetInscripciones(i => i.InscripcionId == int.Parse(CriterioTextBox.Text));
                        break;
                    case "Estudiante Matricula":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese una matricula válida.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = InscripcionesBLL.GetInscripciones(i => i.Matricula == int.Parse(CriterioTextBox.Text));
                        break;
                    case "Créditos Selccionados":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        lista = InscripcionesBLL.GetInscripciones(i => i.CreditosSelccionados == int.Parse(CriterioTextBox.Text));
                        break;

                    case "Cantidad Materia":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese una digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        lista = InscripcionesBLL.GetInscripciones(i => i.CantidadMateria == int.Parse(CriterioTextBox.Text));
                        break;

                    case "Fecha":

                        lista = InscripcionesBLL.GetInscripciones(i => i.Fecha.Year == FechaDatePicker.SelectedDate.Value.Year);
                        break;
                }
            }
            else
            {
                lista = InscripcionesBLL.GetInscripciones();
            }

            DetalleDataGrid.ItemsSource = lista;
            FechaDatePicker.SelectedDate = null;
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
