<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="Busqueda.aspx.cs" Inherits="CatalogoWeb.Busqueda" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnBusqueda" Text="Buscar" runat="server" />
    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">

        <%foreach (var item in ListaFiltrada)
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
            
        </div>
        <% } %>
    </div>

</asp:Content>
