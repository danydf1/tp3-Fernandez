using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TP2_Fernandez
{
    public partial class frmAgregar : Form
    {
        private Producto producto = null;
        public frmAgregar()
        {
            InitializeComponent();
        }
        public frmAgregar(Producto produc)
        {
            InitializeComponent();
            producto = produc;
        }

        private void frmAgregar_Load_1(object sender, EventArgs e)
        {
            MarcaNegocio marca = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();

            try
            {
                cmbMarca.DataSource = marca.listar();
                cmbCategoria.DataSource = categoria.listar();
                cmbMarca.DisplayMember = "Descripcion";
                cmbMarca.ValueMember = "ID";
                cmbCategoria.DisplayMember = "Descripcion";
                cmbCategoria.ValueMember = "ID";
                

                if (producto!=null)
                     {
                    txtCodigo.Text = producto.Codigo;
                    txtNombre.Text = producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;
                    cmbMarca.SelectedValue = producto.Marca.ID;
                    cmbCategoria.SelectedValue = producto.Categoria.ID;
                    txtPrecio.Text =  producto.Precio.ToString();
                    txtUrl.Text = producto.ImagenURL;
                     }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
           
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                    if (producto == null)
                   producto = new Producto();
               
                producto.Codigo = txtCodigo.Text.Trim();
                producto.Nombre = txtNombre.Text.Trim();
                producto.Descripcion = txtDescripcion.Text.Trim();
                producto.Marca = (Marca)cmbMarca.SelectedItem;
                producto.Categoria = (Categoria)cmbCategoria.SelectedItem;
                producto.Precio = decimal.Parse(txtPrecio.Text);
                producto.ImagenURL = txtUrl.Text.Trim();

                if (producto.ID == 0)
                    negocio.agregar(producto);
                else
                    negocio.Modificar(producto);
                
                Dispose();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            
            Dispose();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        
    }
}
