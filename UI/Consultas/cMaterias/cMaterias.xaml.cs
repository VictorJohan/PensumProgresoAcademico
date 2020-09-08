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

namespace PensumProgresoAcademico.UI.Consultas.cMaterias
{
    /// <summary>
    /// Interaction logic for cMaterias.xaml
    /// </summary>
    public partial class cMaterias : Window
    {
        //Se crean un array de srtrings con las opciones.
        string[] filtro = { "Clave", "Descripción", "Horas Practicas", "Horas Teoricas", "Créditos", "Todo" };
        public cMaterias()
        {
            InitializeComponent();
            FiltroComboBox.ItemsSource = filtro;//Se le pasa el array al ComboBox.
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Materias> lista = new List<Materias>();
            if (FiltroComboBox.SelectedIndex == -1) { return; }//Si no hay nada selecionado sale del evento
            if (FiltroComboBox.SelectedItem.ToString() != "Todo")
            {
                switch (FiltroComboBox.SelectedItem.ToString())
                {
                    case "Clave":
                       
                        lista = MateriasBLL.GetMaterias(m => m.Clave == CriterioTextBox.Text);
                        break;
                    case "Descripción":

                        lista = MateriasBLL.GetMaterias(m => m.Descripcion == CriterioTextBox.Text);
                        break;
                    case "Horas Practicas":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        lista = MateriasBLL.GetMaterias(m => m.HorasPracticas == byte.Parse(CriterioTextBox.Text));
                        break;

                    case "Horas Teoricas":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        lista = MateriasBLL.GetMaterias(m => m.HorasTeoricas == byte.Parse(CriterioTextBox.Text));
                        break;

                    case "Créditos":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese un digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        lista = MateriasBLL.GetMaterias(m => m.Creditos == byte.Parse(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                lista = MateriasBLL.GetMaterias();
            }

            DetalleDataGrid.ItemsSource = lista;
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
