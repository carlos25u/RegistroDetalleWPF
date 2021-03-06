using RegistroDetalleWPF.BLL;
using RegistroDetalleWPF.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroDetalleWPF.UI.Registros
{
    /// <summary>
    /// Interaction logic for rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {
        private Roles role = new Roles();
        public rRoles()
        {
            InitializeComponent();
            this.DataContext = role;
            RolIDTextBox.Text = "0";

            PermisoIDCombobox.ItemsSource = PermisoBLL.GetPermisos();
            nombreComboBox.ItemsSource = PermisoBLL.GetPermisos();
            DescripcionComBox.ItemsSource = PermisoBLL.GetPermisos();

            PermisoIDCombobox.SelectedValuePath = "PermisoID";
            PermisoIDCombobox.DisplayMemberPath = "PermisoID";
            nombreComboBox.DisplayMemberPath = "Nombre";
            DescripcionComBox.DisplayMemberPath = "Descripcion";
        }

        private void Limpiar()
        {
            RolIDTextBox.Text = "0";
            DetalleDataGrid.ItemsSource = new List<RolesDetalle>();
            Actuallizar();
        }

        private void Actuallizar()
        {
            this.DataContext = null;
            this.DataContext = role;
        }
        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Rol = RolesBLL.Buscar(Ulilidades.ToInt(RolIDTextBox.Text));

            if(Rol != null)
            {
                DescripcionTextBox.Text = role.Descripcion;
                this.role = Rol;
            }
            else
            {
                this.role = new Roles();
            }
            this.DataContext = this.role;
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            role.RolesDetalle.Add(new RolesDetalle(Ulilidades.ToInt(RolIDTextBox.Text), Ulilidades.ToInt(PermisoIDCombobox.Text)));
            
            Actuallizar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Actuallizar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var paso = RolesBLL.Guardar(role);
            if (paso)
            {
                role.Descripcion = DescripcionTextBox.Text;

                Limpiar();
                MessageBox.Show("Guardado con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(int.Parse(RolIDTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No fue posible Eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            role.RolesDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
            Actuallizar();
        }
    }
}
