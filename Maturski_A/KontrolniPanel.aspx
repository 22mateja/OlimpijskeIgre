<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="KontrolniPanel.aspx.cs" Inherits="Maturski_A.KontrolniPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    KONTROLNI PANEL:
    <%
        Response.Write(Session["korisnik"]);
        %>
</asp:Content>
