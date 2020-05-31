using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TP2_Fernandez
{
    public partial class Form1 : Form
    {
       private List<Producto> lista;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                Cargar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Cargar()
        {
            ProductoNegocio productos = new ProductoNegocio();
            
            try
            {              
                lista = productos.listar();
                dgvCatalogo.DataSource = lista;
                dgvCatalogo.Columns[0].Visible = false;
                dgvCatalogo.Columns[4].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnAgregar_Click(object sender, MouseEventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.ShowDialog();
            Cargar();
        }

       

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Producto Modificar = (Producto)dgvCatalogo.CurrentRow.DataBoundItem;
            frmAgregar Agregar = new frmAgregar(Modificar);
            Agregar.ShowDialog();
            Cargar();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
             try
            {
                int id = ((Producto)dgvCatalogo.CurrentRow.DataBoundItem).ID;
                negocio.Eliminar(id);
            }
            catch (Exception ex)
            {

                throw ex ;
            }
            Cargar();
        }

       

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Producto> listaFiltrada;
            try
            {
                if (txtBusqueda.Text == "")
                {
                    listaFiltrada = lista;

                }
                else
                {
                    listaFiltrada = lista.FindAll(k => k.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()) || k.Codigo.ToLower().Contains(txtBusqueda.Text.ToLower())
                                                    || k.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower())|| k.Marca.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower())
                                                    || k.Categoria.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower()));
                }
                dgvCatalogo.DataSource = listaFiltrada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
            
        }

      

        

        private void ImgArt_Click(object sender, EventArgs e)
        {
            try
            {
                Producto Art;
                Art = (Producto)dgvCatalogo.CurrentRow.DataBoundItem;
                ImgArt.Load(Art.ImagenURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
    }
}
