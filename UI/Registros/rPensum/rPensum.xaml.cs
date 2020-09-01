using Microsoft.EntityFrameworkCore.Internal;
using PensumProgresoAcademico.BLL;
using PensumProgresoAcademico.Entidades;
using PensumProgresoAcademico.UI.Registros.rMaterias;
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

namespace PensumProgresoAcademico.UI.Registros.rPensum
{
    /// <summary>
    /// Interaction logic for rPensum.xaml
    /// </summary>
    public partial class rPensum : Window
    {
        private Pensum Pensum = new Pensum();
        private Materias Materias;
        public rPensum()
        {
            InitializeComponent();
            this.DataContext = Pensum;
        }

        //Busca un el registro de un Pensum en la base de datos
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(PensumIdTextBox.Text, "^[1-9]+${1,5}"))
            {
                MessageBox.Show("El Id que ha ingresado no es válido.\nVerifique que haya ingresado un caracter numerico y que este " +
                    "sea diferente de cero.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var encontrado = PensumBLL.Buscar(int.Parse(PensumIdTextBox.Text));

            if (encontrado != null)
            {
                Pensum = encontrado;
                this.DataContext = Pensum;
            }
            else
            {
                MessageBox.Show("No hay un Pensum con este Id.", "No se encontro al Pensum.",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //Agrega una materia al Pensum
        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarAgregar())
                return;

            var detalle = new PensumDetalle
            {
                Id = 0,
                PensumId = int.Parse(PensumIdTextBox.Text),
                Clave = ClaveMateriaTextBox.Text,
                Prerequisitos = PrerequisitosTextBox.Text
            };

            detalle.Materia = Materias;

            Pensum.PensumDetalles.Add(detalle);
            Sumatoria(Materias.HorasPracticas, Materias.HorasTeoricas, Materias.Creditos);

            Cargar();
            LimpiarDetalle();
        }

        //Elimina un materia del Pensum
        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DetalleDataGrid.SelectedIndex == -1)
                    return;

                var detalle = (PensumDetalle)DetalleDataGrid.SelectedItem;
                Reduccion(detalle.Materia.HorasPracticas, detalle.Materia.HorasTeoricas, detalle.Materia.Creditos);

                Pensum.PensumDetalles.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
            catch (Exception)
            {

                MessageBox.Show("Selecciona un elemento valido.", "Acción no valida.",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Limpia el registro para un nuevo Pensum.
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        //Guarda un nuevo Pensum en la base de datos.
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            if (PensumBLL.Guardar(Pensum))
            {
                MessageBox.Show("Pensum guardado.", "Aviso.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Algo salió mal, no se logró guardar el pensum.", "Error.",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Elimina un Pensum de la base de datos.
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(PensumIdTextBox.Text, "^[1-9]+${1,5}"))
            {
                MessageBox.Show("El Id que ha ingresado no es válido.\nVerifique que haya ingresado un caracter numerico y que este " +
                    "sea diferente de cero.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (PensumBLL.Eliminar(int.Parse(PensumIdTextBox.Text)))
            {
                MessageBox.Show("Pensum eliminado.", "Aviso.",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Algo salió mal, no se logró eliminar el pensum.", "Error.",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Busca la materia segun se vayan ingresando caracteres.
        private void ClaveMateriaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var encontrado = MateriasBLL.Buscar(ClaveMateriaTextBox.Text);
            if (encontrado != null)
            {
                Materias = encontrado;
                DescripcionDetalleTextBox.Text = Materias.Descripcion;
                HorasPracticasDetalleTextBox.Text = Materias.HorasPracticas.ToString();
                HorasTeoricasDetalleTextBox.Text = Materias.HorasTeoricas.ToString();
                CreditosDetalleTextBox.Text = Materias.Creditos.ToString();
            }
            else
            {
                LimpiarEnBusqueda();
                return;
            }
        }

        //Limpia el detalle segun la busqueda que se este haciendo.
        public void LimpiarEnBusqueda()
        {
            DescripcionDetalleTextBox.Clear();
            HorasPracticasDetalleTextBox.Clear();
            HorasTeoricasDetalleTextBox.Clear();
            CreditosDetalleTextBox.Clear();
        }

        //Actualiza el detalle.
        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Pensum;
        }

        //Suma las horas de practicas, horas de teoria y los creditos en caso de que se agregue una materia del pensum.
        public void Sumatoria(byte horasPracticas, byte horasTeoricas, byte creditos)
        {
            Pensum.PensumHorasPracticas += horasPracticas;
            Pensum.PensumHorasTeoricas += horasTeoricas;
            Pensum.PensumCreditos += creditos;
            Pensum.TotalMaterias++;

        }

        //Resta las horas de practicas, horas de teoria y los creditos en caso de que se quite una materia del pensum.
        public void Reduccion(byte horasPracticas, byte horasTeoricas, byte creditos)
        {
            Pensum.PensumHorasPracticas -= horasPracticas;
            Pensum.PensumHorasTeoricas -= horasTeoricas;
            Pensum.PensumCreditos -= creditos;
            Pensum.TotalMaterias--;

        }

        //Limpia el registro completo.
        public void Limpiar()
        {
            Pensum = new Pensum();
            this.DataContext = Pensum;
            LimpiarDetalle();
        }

        //Limpia los campos del detalle al agregar una materia.
        public void LimpiarDetalle()
        {
            ClaveMateriaTextBox.Clear();
            DescripcionDetalleTextBox.Clear();
            HorasPracticasDetalleTextBox.Clear();
            HorasTeoricasDetalleTextBox.Clear();
            CreditosDetalleTextBox.Clear();
            PrerequisitosTextBox.Clear();
        }

        //Valida los campos del registro.
        public bool Validar()
        {
            //Valida que se haya ingresado un Id valido
            if (!Regex.IsMatch(PensumIdTextBox.Text, "^[1-9]+${1,5}"))
            {
                MessageBox.Show("El Id que ha ingresado no es válido.\nVerifique que haya ingresado un caracter numerico y que este " +
                    "sea diferente de cero.", "Aviso.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            //Valida que todos los campos esten llenos
            if (CarreraTextBox.Text.Length == 0 || DuracionTextBox.Text.Length == 0 || TituloOtorgarTextBox.Text.Length == 0)
            {
                MessageBox.Show("Verifique que todos los campos esten debidamente llenados.", "Aviso.",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        //Valida el agregar
        public bool ValidarAgregar()
        {
            //Valida que no haya campos vacios en el detalle
            if (ClaveMateriaTextBox.Text.Length == 0 || PrerequisitosTextBox.Text.Length == 0)
            {
                MessageBox.Show("Verifique que todos los campos esten debidamente llenados en el área del detalle.", "Aviso.",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            //Valida que la materia exista
            if (!MateriasBLL.Existe(ClaveMateriaTextBox.Text))
            {
                if(MessageBox.Show("Esa materia no existe en la base de datos, ¿Quieres crearla?", "Aviso.",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    rMaterias.rMaterias rMaterias = new rMaterias.rMaterias();
                    rMaterias.Show();

                }
                else
                {
                    LimpiarDetalle();
                }
                return false;
            }

            //Valida que no se agregue mas de una 1 vez la misma materia
            if(Pensum.PensumDetalles.Any(p => p.Clave == ClaveMateriaTextBox.Text))
            {
                MessageBox.Show("Esta materia ya se encuntra en el pensum.", "Aviso.",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }
    }

}
