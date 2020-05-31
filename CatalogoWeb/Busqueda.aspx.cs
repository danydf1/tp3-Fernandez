using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CatalogoWeb
{
    public partial class Busqueda : System.Web.UI.Page
    {
        public List<Producto> ListaFiltrada { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                ListaFiltrada = negocio.listar();

                Session[Session.SessionID + "ListaFiltrada"] = ListaFiltrada;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}