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


namespace PensumProgresoAcademico.UI.Consultas.cAmbitoPensum
{
    /// <summary>
    /// Interaction logic for cAmbitoPensum.xaml
    /// </summary>
    public partial class cAmbitoPensum : Window
    {
        //Se crean un array de srtrings con las opciones.
        string[] filtro = { "Clave", "Descripción", "Horas Practicas", "Horas Teoricas", "Créditos","Pre-Requisitos", "Todo" };
        public cAmbitoPensum()
        {
            InitializeComponent();
            FiltroComboBox.ItemsSource = filtro;//Se le pasa el array al ComboBox.
            PensumComboBox.ItemsSource = PensumBLL.GetPensum();
            PensumComboBox.SelectedValuePath = "PensumId";
            PensumComboBox.DisplayMemberPath = "Carrera";
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            List<PensumDetalle> lista = new List<PensumDetalle>();
            lista = PensumBLL.GetMaterias(int.Parse(PensumComboBox.SelectedValue.ToString()));
            if (FiltroComboBox.SelectedIndex == -1) { return; }//Si no hay nada selecionado sale del evento
            if (FiltroComboBox.SelectedItem.ToString() != "Todo")
            {
                switch (FiltroComboBox.SelectedItem.ToString())
                {
                    case "Clave":

                        DetalleDataGrid.ItemsSource = lista.FindAll(m => m.Clave == CriterioTextBox.Text);
                        break;
                    case "Descripción":

                        DetalleDataGrid.ItemsSource = lista.FindAll(m => m.Materia.Descripcion == CriterioTextBox.Text);
                        break;
                    case "Horas Practicas":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        DetalleDataGrid.ItemsSource = lista.FindAll(m => m.Materia.HorasPracticas == int.Parse(CriterioTextBox.Text));
                        break;

                    case "Horas Teoricas":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        DetalleDataGrid.ItemsSource = lista.FindAll(m => m.Materia.HorasTeoricas == int.Parse(CriterioTextBox.Text));
                        break;

                    case "Créditos":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        DetalleDataGrid.ItemsSource = lista.FindAll(m => m.Materia.Creditos == int.Parse(CriterioTextBox.Text));
                        break;
                    case "Pre-Requisitos":

                        DetalleDataGrid.ItemsSource = PensumBLL.GetMaterias(int.Parse(PensumComboBox.SelectedValue.ToString()), CriterioTextBox.Text);
                        break;
                }
            }
            else
            {
                DetalleDataGrid.ItemsSource = lista;
            }

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
