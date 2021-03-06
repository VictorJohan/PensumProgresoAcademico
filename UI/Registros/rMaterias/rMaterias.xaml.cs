﻿using PensumProgresoAcademico.BLL;
using PensumProgresoAcademico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //Constructor
        public rMaterias()
        {
            InitializeComponent();
            this.DataContext = Materia;
        }

        //Limpia el WPF para dar lugar a un nuevo registro.
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        //Guarda un registro en la base de datos.
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar()) { return; }
            if (!ConfirmarGuardar()) { return; }

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

        //Elimina un registro de la base de datos.
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ConfirmarEliminar()) { return; }

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

        //Limpia el WPF.
        public void Limpiar()
        {
            Materia = new Materias();
            this.DataContext = Materia;
        }

        //Busca un registro a medida que se va ingresando un caracter. 
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

        //Limpia el WPF si la clave no coincide con la de algun registro.
        public void LimpiarEnBusqueda()
        {
            DescripcionTextBox.Clear();
            CreditosTextBox.Clear();
            HorasPracticasTextBox.Clear();
            HorasTeoricasTextBox.Clear();
        }

        //Valida todos los campos del WPF.
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
            if (!Regex.IsMatch(HorasPracticasTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("La cantidad de horas practicas que ingresaste no es valida.", "Campos Horas Practicas.",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            //Valida el campo Horas Teoricas
            if (!Regex.IsMatch(HorasTeoricasTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("La cantidad de horas teoricas que ingresaste no es valida.", "Ya hay una materia con este nombre.",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            //Valida que no se creen dos materias con el mismo nombre
            var materia = MateriasBLL.ExisteMateria(DescripcionTextBox.Text);
            if (materia != null)
            {
                if ((DescripcionTextBox.Text == materia.Descripcion) && ClaveTextBox.Text != materia.Clave)
                {
                    MessageBox.Show($"Esta materia ya existe con la clave: {materia.Clave}.", "Aviso.",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
            }

            return true;
        }

        //Confirma si se vana a guardar los datos
        public bool ConfirmarGuardar()
        {
            bool respuesta = (MessageBox.Show("¿Seguro que desea guardar estos datos?", "Guardar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No);

            if (respuesta) { return false; }

            return true;
        }

        //Confirma si se vana a eliminar los datos
        public bool ConfirmarEliminar()
        {
            bool respuesta = (MessageBox.Show("¿Seguro que desea eliminar estos datos?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No);

            if (respuesta) { return false; }

            return true;
        }

        //todo: recuerda
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //this.Topmost = false;
            this.Focus();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            this.Topmost = true;
            this.Focus();
        }
    }
}
