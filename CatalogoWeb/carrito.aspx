<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="CatalogoWeb.carrito" %>

<asp:Content ID="Carrito" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <tr>
                        <td>Nombre</td>
                        <td>Marca</td>
                        <td>Precio </td>
                        <td>Accion</td>
                    </tr>
                    
                    <%foreach (var producto in listaCarrito )
                        {
                    %>

                    <tr>
                        <td><% = producto.Nombre %></td>
                        <td><% = producto.Marca %></td>
                        <td><% = producto.Precio %></td>
                        <td><a href="Carrito.aspx?idQuitar=<% = producto.ID.ToString() %> class="btn btn-primary">Quitar</a></td>
                    </tr>
                    
                    <% } %>
                    <tr>
                        <td> Total <asp:Label ID ="lblTotal" runat="server" /></td>
                    </tr>
                </table>

            </div>

        </div>
    </div>


</asp:Content>
