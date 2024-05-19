<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Pregledkorisnika.aspx.cs" Inherits="Maturski_A.Pregledkorisnika" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div_100" >
        UPIS NOVOG SUDIJE :<br />
             Ime:<asp:TextBox ID="txtime" runat="server" style="margin-bottom: 0px"></asp:TextBox><br />

             Prezime: <asp:TextBox ID="txtprezime" runat="server"></asp:TextBox><br />

             Drzava:<asp:TextBox ID="txtdrzava" runat="server"></asp:TextBox><br />
       
            Korisnicko ime :<asp:TextBox ID="txtimekorisnika" runat="server"></asp:TextBox><br />
         
           Lozinka korisnika :<asp:TextBox ID="txtlozinka" TextMode="Password" runat="server"></asp:TextBox><br />
    
            <asp:Button ID="btnupiskorisnika" runat="server" Text="UPIS" OnClick="btnupiskorisnika_Click" />


    </div>
     <div class="divpk_100">
    <%
        Maturski_A.maturski_a svi_korisnici = new Maturski_A.maturski_a();
        DataSet ds = new DataSet();
        ds = svi_korisnici.Admin_Svi();
        Response.Write("<Table>");
        for(int i=0; i<ds.Tables[0].Rows.Count;i++)
        {
            Response.Write("<tr>");
            Response.Write("<td>");
            Response.Write(ds.Tables[0].Rows[i]["email"]);
            
            Response.Write("</td>");
            Response.Write("</tr>");
        }
        Response.Write("</Table>");
        %>
         </div>
</asp:Content>
