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

namespace PensumProgresoAcademico.UI.Registros.rMaterias
{
    /// <summary>
    /// Interaction logic for rMaterias.xaml
    /// </summary>
    public partial class rMaterias : Window
    {
        private Materias Materia = new Materias();
        public rMaterias()
        {
            InitializeComponent();
            this.DataContext = Materia;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            if (MateriasBLL.Guardar(Materia))
            {
                MessageBox.Show("Materia guardada.", "Aviso.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Algo salió mal, no se logró guardar la materia.", "Error.",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (MateriasBLL.Eliminar(ClaveTextBox.Text))
            {
                MessageBox.Show("Materia eliminada.", "Aviso.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Algo salió mal, no se logró eliminar la materia.", "Error.",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Limpiar()
        {
            Materia = new Materias();
            this.DataContext = Materia;
        }

        private void ClaveTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var encontrado = MateriasBLL.Buscar(ClaveTextBox.Text);
            if (encontrado != null)
            {
                Materia = encontrado;
                this.DataContext = Materia;
            }
            else
            {
                LimpiarEnBusqueda();
                return;
            }
        }

        public void LimpiarEnBusqueda()
        {
            DescripcionTextBox.Clear();
            CreditosTextBox.Clear();
            HorasPracticasTextBox.Clear();
            HorasTeoricasTextBox.Clear();
        }

        public bool Validar()
        {
            //Valida que no haya campos vacios
            if (ClaveTextBox.Text.Length == 0 || DescripcionTextBox.Text.Length == 0 || CreditosTextBox.Text.Length == 0 ||
                HorasPracticasTextBox.Text.Length == 0 || HorasTeoricasTextBox.Text.Length == 0)
            {
                MessageBox.Show("Asegurate de haber llenado todos los campos.", "Campos vacios.",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            //Valida el campo creditos
            if (!Regex.IsMatch(CreditosTextBox.Text, "^[1-9]{1,2}"))
            {
                MessageBox.Show("La cantidad de Créditos que ingresaste no es valida.", "Campos Créditos.",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            //Valida el campo Horas Practicas
            if (!Regex.IsMatch(HorasPracticasTextBox.Text, "^[1-9]{1,2}"))
            {
                MessageBox.Show("La cantidad de horas practicas que ingresaste no es valida.", "Campos Horas Practicas.",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            //Valida el campo Horas Teoricas
            if (!Regex.IsMatch(HorasTeoricasTextBox.Text, "^[1-9]{1,2}"))
            {
                MessageBox.Show("La cantidad de horas teoricas que ingresaste no es valida.", "Campos Horas Teoricas.",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
