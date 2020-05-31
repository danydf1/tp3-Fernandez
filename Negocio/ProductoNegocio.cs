using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Security.Cryptography.X509Certificates;

namespace Negocio
{
    public class ProductoNegocio
    {
      
        public List<Producto> listar()
        {
            List<Producto> listado = new List<Producto>();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                Conexion.ConnectionString = "data source=DESKTOP-09K26PO\\SQLEXPRESS;initial Catalog=CATALOGO_DB;integrated security=sspi ";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "select P.Id as IdProducto,p.Codigo, P.Nombre, P.Descripcion, P.ImagenUrl,P.Precio ,M.Id ,M.Descripcion as MarDesc,C.Id ,C.Descripcion as CatDesc from ARTICULOS P, MARCAS M , CATEGORIAS C Where P.IdMarca=M.Id and P.IdCategoria=C.Id";
                Comando.Connection = Conexion;
                Conexion.Open();
                lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    Producto aux = new Producto();
                    aux.ID = (int)lector["IdProducto"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.ImagenURL = (string)lector["ImagenUrl"];
                    aux.Precio = (decimal)lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Marca.ID = (int)lector["Id"];
                    aux.Marca.Descripcion = (string)lector["MarDesc"];
                    aux.Categoria.ID = (int)lector["Id"];
                    aux.Categoria.Descripcion = (string)lector["CatDesc"];




                    listado.Add(aux);
                }

                return listado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Conexion.Close();
            }
        }

        public void agregar(Producto nuevo)
        {
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            try
            {
                Conexion.ConnectionString = "data source=DESKTOP-09K26PO\\SQLEXPRESS;initial Catalog=CATALOGO_DB;integrated security=sspi ";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "insert into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) " +
                                        "Values (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@ImagenUrl,@Precio)";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo);
                Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                Comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                Comando.Parameters.AddWithValue("@IdMarca", nuevo.Marca.ID);
                Comando.Parameters.AddWithValue("@IdCategoria", nuevo.Categoria.ID);
                Comando.Parameters.AddWithValue("@ImagenUrl", nuevo.ImagenURL);
                Comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                Comando.Connection = Conexion;

                Conexion.Open();
                Comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Conexion.Close();
            }
        }

        public void Modificar(Producto producto)
        {
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            try
            {
                Conexion.ConnectionString = "data source=DESKTOP-09K26PO\\SQLEXPRESS;initial Catalog=CATALOGO_DB;integrated security=sspi ";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "update ARTICULOS set Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, IdMarca=@IdMarca, IdCategoria=@IdCategoria, ImagenUrl=@ImagenUrl, Precio=@Precio Where Id=@Id";

                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@Codigo", producto.Codigo);
                Comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                Comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                Comando.Parameters.AddWithValue("@IdMarca", producto.Marca.ID);
                Comando.Parameters.AddWithValue("@IdCategoria", producto.Categoria.ID);
                Comando.Parameters.AddWithValue("@ImagenUrl", producto.ImagenURL);
                Comando.Parameters.AddWithValue("@Precio", producto.Precio);
                Comando.Parameters.AddWithValue("@Id", producto.ID);
                Comando.Connection = Conexion;

                Conexion.Open();
                Comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Conexion.Close();
            }
        }
        public void Eliminar(int id)
        {
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            try
            {
                Conexion.ConnectionString = "data source=DESKTOP-09K26PO\\SQLEXPRESS;initial Catalog=CATALOGO_DB;integrated security=sspi ";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "delete from ARTICULOS Where Id=" + id ;
                Comando.Connection = Conexion;

                Conexion.Open();
                Comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Conexion.Close();
            }
        }
    }
}
