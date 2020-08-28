using PensumProgresoAcademico.BLL;
using PensumProgresoAcademico.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
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

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {//todo: Crear una validacion que no permita ingresar la misma materia dos veces
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
            PrerequisitosTextBox.Clear();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }

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

        public void LimpiarEnBusqueda()
        {
            DescripcionDetalleTextBox.Clear();
            HorasPracticasDetalleTextBox.Clear();
            HorasTeoricasDetalleTextBox.Clear();
            CreditosDetalleTextBox.Clear();
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Pensum;
        }

        public void Sumatoria(byte horasPracticas, byte horasTeoricas, byte creditos)
        {
            Pensum.PensumHorasPracticas += horasPracticas;
            Pensum.PensumHorasTeoricas += horasTeoricas;
            Pensum.PensumCreditos += creditos;

        }
    }
    
}
