using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class carrito : System.Web.UI.Page
    {
        public List<Producto> listaCarrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                decimal total = 0;
                listaCarrito = (List<Producto>)Session[Session.SessionID + "listaCarrito"];

                var QuitarProducto = Request.QueryString["idQuitar"];
                if (QuitarProducto != null)
                {
                    Producto ProductoQuitar = listaCarrito.Find(J => J.ID == int.Parse(QuitarProducto));
                    listaCarrito.Remove(ProductoQuitar);
                    Session[Session.SessionID + "listaCarrito"] = listaCarrito;
                }
                else if (Request.QueryString["idpdt"] != null)
                {

                    List<Producto> listaOriginal = (List<Producto>)Session[Session.SessionID + "listaProducto"];
                    var ProductoSeleccionado = Convert.ToInt32(Request.QueryString["idpdt"]);
                  
                    Producto product = listaOriginal.Find(J => J.ID == ProductoSeleccionado);
                    
                 

                    if (listaCarrito == null)
                        listaCarrito = new List<Producto>();

                    listaCarrito.Add(product);
                    Session[Session.SessionID + "listaCarrito"] = listaCarrito;

                  
                }

                foreach (var item in listaCarrito)
                {
                    total += item.Precio;
                }
                lblTotal.Text = total.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }


}



