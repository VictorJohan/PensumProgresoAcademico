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

namespace PensumProgresoAcademico.UI.Registros
{
    /// <summary>
    /// Interaction logic for rEstudiantes.xaml
    /// </summary>
    public partial class rEstudiantes : Window
    {

        private Estudiantes Estudiante = new Estudiantes();
        public rEstudiantes()
        {
            InitializeComponent();
            PensumComboBox.ItemsSource = PensumBLL.GetPensum();
            PensumComboBox.SelectedValuePath = "PensumId";
            PensumComboBox.DisplayMemberPath = "Carrera";
            this.DataContext = Estudiante;
        }

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

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            if (!Confirmacion())
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

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
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

        public void Limpiar()
        {
            Estudiante = new Estudiantes();
            this.DataContext = Estudiante;
        }

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

        private void Window_Initialized(object sender, EventArgs e)
        {
            this.Topmost = true;
            this.Focus();
        }

    }
}
