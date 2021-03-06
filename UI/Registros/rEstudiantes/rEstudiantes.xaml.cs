﻿using PensumProgresoAcademico.BLL;
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

namespace PensumProgresoAcademico.UI.Registros
{
    /// <summary>
    /// Interaction logic for rEstudiantes.xaml
    /// </summary>
    public partial class rEstudiantes : Window
    {
        private Estudiantes Estudiante = new Estudiantes();

        //Constructor
        public rEstudiantes()
        {
            InitializeComponent();
            //Se le agregan los pensum al comboBox
            PensumComboBox.ItemsSource = PensumBLL.GetPensum();
            PensumComboBox.SelectedValuePath = "PensumId";
            PensumComboBox.DisplayMemberPath = "Carrera";
            //Se inicializan los campos del WPF.
            this.DataContext = Estudiante;
        }

        //Busca un registro en la base de datos.
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = EstudiantesBLL.Buscar(int.Parse(MatriculaTextBox.Text));

            if (encontrado != null)
            {
                Estudiante = encontrado;
                this.DataContext = Estudiante;
            }
            else
            {
                MessageBox.Show("No hay un registros con esta esta matrícula.", "No se encontro al estudiante.",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //Limpia el formulario para crear un nuevo registro.
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        //Guarda un registro en la base de datos.
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            if (!Confirmacion())//Pregunta al usuario si realmente desea cambiar de pensum
                return;

            if (EstudiantesBLL.Guardar(Estudiante))
            {
                MessageBox.Show("Guardado.", "Aviso.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Algo salió mal, no se logró registrar el estudiante.", "Error.",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Elimina un registro de la base de datos
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ConfirmarEliminar()) { return; }

            if (EstudiantesBLL.Eliminar(int.Parse(MatriculaTextBox.Text)))
            {
                MessageBox.Show("Estudiante eliminado.", "Aviso.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Algo salió mal, no se logró eliminar el estudiante.", "Error.",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Limpia el WPF
        public void Limpiar()
        {
            Estudiante = new Estudiantes();
            this.DataContext = Estudiante;
        }

        //Valida todos los campos del WPF.
        public bool Validar()
        {
            //Valida que sea una matricula valida
            int año;
            if (MatriculaTextBox.Text.Length > 7)
            {
                año = int.Parse(MatriculaTextBox.Text.Substring(0, 4));
                if (año < 1978 || !Regex.IsMatch(MatriculaTextBox.Text, @"\d{8}"))
                {
                    MessageBox.Show("Ejemplo de matrícula: 20170122.\nLos primeros 4 digitos de una matrícula" +
                        " componen el año de ingreso del alumno y los ultimos 4 digitos son para diferenciar a los alumnos que " +
                        "ingresaron en el mismo año y son proporcionados por la Universidad.\nCabe destacar que la cifra " +
                        "que componen los primeros 4 digitos no debe ser menor al año de fundación de la Universidad el cual es 1978.", "Matrícula no válida.",
                      MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Ejemplo de matrícula: 20170122.\nLos primeros 4 digitos de una matrícula" +
                        " componen el año de ingreso del alumno y los ultimos 4 digitos son para diferenciar a los alumnos que " +
                        "ingresaron en el mismo año y son proporcionados por la Universidad.\nCabe destacar que la cifra " +
                        "que componen los primeros 4 digitos no debe ser menor al año de fundación de la Universidad el cual es 1978.", "Matrícula no válida.",
                      MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            //válida que se haya introducido un nombre válido
            if (!Regex.IsMatch(NombresTextBox.Text, "^[a-zA-Z'.\\s]{1,40}$"))
            {
                MessageBox.Show("Solo se admiten carácteres alfabeticos.", "Nombre no válido.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            //Valida que se selecione un pensum
            if (PensumComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un Pensum.", "Aviso.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            //Valida la relacion entre la matricula y la fecha de ingreso.
            int ingreso = FechaIngresoDatePicker.SelectedDate.Value.Year;
            if (año != ingreso)
            {
                MessageBox.Show("Ejemplo de matrícula: 20170122.\nLos primeros 4 digitos de una matrícula" +
                       " componen el año de ingreso del alumno y los ultimos 4 digitos son para diferenciar a los alumnos que " +
                       "ingresaron en el mismo año y son proporcionados por la Universidad.\nCabe destacar que la cifra " +
                       "que componen los primeros 4 digitos no debe ser menor al año de fundación de la Universidad el cual es 1978.", "No hay una relación entre la matricula y la fecha de ingreso.",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }

        //Asigna un pensum a un estudiante
        private void PensumComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PensumComboBox.SelectedIndex == -1)
                return;
            var aux = EstudiantesBLL.Buscar(int.Parse(MatriculaTextBox.Text));
            if (!EstudiantesBLL.Existe(int.Parse(MatriculaTextBox.Text)) || int.Parse(PensumComboBox.SelectedValue.ToString()) != aux.PensumId)
            {
                Pensum pensum = (Pensum)PensumComboBox.SelectedItem;

                Estudiante.CreditosPendientes = pensum.PensumCreditos;
                Estudiante.HorasPracticasPendientes = pensum.PensumHorasPracticas;
                Estudiante.HorasTeoricasPendientes = pensum.PensumHorasTeoricas;
                Estudiante.MateriasPendientes = pensum.TotalMaterias;
            }


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

        //Pregunta al usuario si realmente desea cambiar de pensum
        public bool Confirmacion()
        {
            if (EstudiantesBLL.Existe(int.Parse(MatriculaTextBox.Text)))
            {
                var estudiante = EstudiantesBLL.Buscar(int.Parse(MatriculaTextBox.Text));

                if (estudiante.PensumId != int.Parse(PensumComboBox.SelectedValue.ToString()))
                {
                    if (MessageBox.Show($"Si cambias de pensum se perderá de forma permanente el registro de progreso del pensum " +
                       "anterior y deberas realizar las inscripciones correspondientes de las materias del" +
                       " pensum que seleccionaste ahora.\n¿Cambiar pensum?", "Advertencia.", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        return true;
                    }

                    return false;
                }
                else
                {
                    return true;
                }
            }

            return true;

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            this.Topmost = false;
            this.Focus();
        }

        //Hace Focus al WPF para que aparezca en primera plana cuando se invoque.
        private void Window_Initialized(object sender, EventArgs e)
        {
            this.Topmost = true;
            this.Focus();
        }

    }
}
