<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="CatalogoWeb.ListaProductos" %>


<asp:Content ID="ListadoProducto" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">

        <%foreach (var item in ListaProducto)
            {%>
        <div class="card" style="width: 18rem;">
            <img src="<% = item.ImagenURL %>" class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title"><% = item.Nombre %></h5>
                <p class="card-text"><% = item.Descripcion %></p>
            </div>
            <ul class="list-group list-group-flush">
                <li class="list-group-item"><%= item.Precio %></li>
            </ul>
            <div class="card-body">
                <a href="carrito.aspx?idpdt=<% = item.ID.ToString() %>" class="btn btn-outline-success my-2 my-sm-0">anadir al carrito</a>

            </div>
        </div>
        <% } %>
    </div>

</asp:Content>
