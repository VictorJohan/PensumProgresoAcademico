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

namespace PensumProgresoAcademico.UI.Consultas.cEstudiantes
{
    /// <summary>
    /// Interaction logic for cEstudiantes.xaml
    /// </summary>
    public partial class cEstudiantes : Window
    {
        string[] filtro = { "Matricula", "Nombres", "Materias Pendientes", "Créditos Pendientes",  "Horas Practicas Pendientes", "Horas Teoricas Pendientes", "Pensum Id" };
        public cEstudiantes()
        {
            InitializeComponent();
            FiltroComboBox.ItemsSource = filtro;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Estudiantes> lista = new List<Estudiantes>();
            if (FiltroComboBox.SelectedIndex != -1)
            {
                switch (FiltroComboBox.SelectedItem.ToString())
                {
                    case "Matricula":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese una matricula valida.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = EstudiantesBLL.GetEstudiantes(e => e.Matricula == int.Parse(CriterioTextBox.Text));
                        break;
                    case "Nombres":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[a-zA-Z'.\\s]{1,40}$"))
                        {
                            MessageBox.Show("Solo se admiten carácteres alfabeticos.", "Nombre no válido.",
                               MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                        lista = EstudiantesBLL.GetEstudiantes(e => e.Nombres == CriterioTextBox.Text);
                        break;
                    case "Materias Pendientes":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese una digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = EstudiantesBLL.GetEstudiantes(e => e.MateriasPendientes == int.Parse(CriterioTextBox.Text));
                        break;

                    case "Créditos Pendientes":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese una digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = EstudiantesBLL.GetEstudiantes(e => e.CreditosPendientes == int.Parse(CriterioTextBox.Text));
                        break;

                    case "Horas Practicas Pendientes":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese una digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = EstudiantesBLL.GetEstudiantes(e => e.HorasPracticasPendientes == int.Parse(CriterioTextBox.Text));
                        break;

                    case "Horas Teoricas Pendientes":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese una digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = EstudiantesBLL.GetEstudiantes(e => e.HorasTeoricasPendientes == int.Parse(CriterioTextBox.Text));
                        break;

                    case "Pensum Id":
                        if (!Regex.IsMatch(CriterioTextBox.Text, "^[0-9]+$"))
                        {
                            MessageBox.Show("Ingrese una digito válido.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        lista = EstudiantesBLL.GetEstudiantes(e => e.PensumId == int.Parse(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                lista = EstudiantesBLL.GetEstudiantes();
            }

            DetalleDataGrid.ItemsSource = lista;
            FiltroComboBox.SelectedIndex = -1;
        }
    }
}
