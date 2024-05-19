<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="parametri.aspx.cs" Inherits="Maturski_A.parametri" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div_100">
       <H1>Olimpijske igre</H1>
        <H2>Unos sporta :</H2>
         Naziv:<asp:TextBox ID="txtnazivsporta" runat="server"></asp:TextBox>
        <br />vrsta:<asp:TextBox ID="txtvrstasporta" runat="server"></asp:TextBox>
        <br />broj faza:<asp:TextBox ID="txtbrojfazasporta" runat="server"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" style="width: 56px" Text="UPIS" />
        <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Ispravka" />
        <br />
        <asp:ListBox ID="ListBox4" runat="server" DataSourceID="SqlDataSource3" DataTextField="naziv" DataValueField="id" Width="259px">
            <asp:ListItem></asp:ListItem>
        </asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Olimpijada %>" SelectCommand="SELECT [id], [naziv] FROM [Sport]"></asp:SqlDataSource>
        <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Brisanje" />
        <br />
        <br />
        <H2>Unos drzave :</H2>
         Naziv:<asp:TextBox ID="txtnazivdrzave" runat="server"></asp:TextBox>
        <br />Broj medalja:<asp:TextBox ID="txtbrojmedaljadrzave" runat="server"></asp:TextBox>
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="unos" />
        <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="Ispravka" />
        <br />
        <asp:ListBox ID="ListBox3" runat="server" DataSourceID="SqlDataSource2" DataTextField="naziv" DataValueField="id" Width="291px"></asp:ListBox>
        <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Brisanje" />
        <br />
        <br />
        <H2>Unos ekipe:</H2>
         Drzava:<asp:ListBox ID="ListBox5" runat="server" DataSourceID="SqlDataSource2" DataTextField="naziv" DataValueField="id" Width="225px"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Olimpijada %>" SelectCommand="SELECT [id], [naziv] FROM [Drzava]"></asp:SqlDataSource>
        <asp:ListBox ID="ListBox7" runat="server" DataSourceID="SqlDataSource4" DataTextField="nazivEkipe" DataValueField="id" style="margin-left: 140px; margin-right: 0px" Width="288px"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Olimpijada %>" SelectCommand="SELECT [id], [nazivEkipe] FROM [Ekipa]"></asp:SqlDataSource>
        <br />Sport:<asp:ListBox ID="ListBox6" runat="server" DataSourceID="SqlDataSource3" DataTextField="naziv" DataValueField="id" Width="227px" style="margin-left: 8px"></asp:ListBox>
        <br />
        <asp:Button ID="Button6" runat="server" Text="OK" OnClick="Button6_Click" />
        <asp:Button ID="Button13" runat="server" OnClick="Button13_Click" Text="Brisanje" />
        <br />
        <H2>Unos Igraca</H2>
        <p>
            Ime:<asp:TextBox ID="txtimeigraca" runat="server"></asp:TextBox>
        </p>
        <p>
            Prezime:<asp:TextBox ID="txtprezimeigraca" runat="server"></asp:TextBox>
        </p>
        <p>
            Drzava:<asp:TextBox ID="txtdrzavaigraca" runat="server"></asp:TextBox>
        </p>
        <p>
            Sport:<asp:TextBox ID="txtsportigraca" runat="server" style="margin-left: 75px" Width="188px"></asp:TextBox>
        </p>
        <p>
            BrojMedalja:<asp:TextBox ID="txtbrojmedaljaigraca" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Unesi" />
        </p>
        <p>
            <asp:ListBox ID="ListBox2" runat="server" DataSourceID="OlimpijskeIgre" Width="335px" DataTextField="ime" DataValueField="id">
                <asp:ListItem></asp:ListItem>
            </asp:ListBox>
            <asp:SqlDataSource ID="OlimpijskeIgre" runat="server" ConnectionString="<%$ ConnectionStrings:Olimpijada %>" SelectCommand="SELECT [id], [ime], [prezime] FROM [Igraci]"></asp:SqlDataSource>
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Brisanje" />
            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="Ispravka" />
        </p>
        <p>
             &nbsp;</p>
        <H2>Unos Trenera</H2>
        <p>
            Ime:<asp:TextBox ID="txtimetrenera" runat="server"></asp:TextBox>
        </p>
        <p>
            Prezime:<asp:TextBox ID="txtprezimetrenera" runat="server"></asp:TextBox>
        </p>
        <p>
            Drzava:<asp:TextBox ID="txtdrzavatrenera" runat="server"></asp:TextBox>
        </p>
        <p>
            Sport:<asp:TextBox ID="txtsporttrenera" runat="server"></asp:TextBox>
        </p>
        <p>
            Vrsta:<asp:TextBox ID="txtvrstatrenera" runat="server"></asp:TextBox>
            <asp:Button ID="Button14" runat="server" OnClick="Button14_Click" Text="Unesi" />
            <asp:Button ID="Button15" runat="server" Text="Brisanje" OnClick="Button15_Click" />
        </p>
        <p>
            <asp:ListBox ID="ListBox8" runat="server" DataSourceID="SqlDataSource5" DataTextField="ime" DataValueField="id" Width="387px"></asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Olimpijada %>" SelectCommand="SELECT [id], [ime], [prezime] FROM [Trener]"></asp:SqlDataSource>
            <asp:Button ID="Button16" runat="server" Text="Ispravka" OnClick="Button16_Click" />
        </p 
         <p>
        <H2>Unos Utakmice</H2>
        <p>
            Ekipa1</p>
        <p>
            <asp:ListBox ID="ListBox9" runat="server" DataSourceID="SqlDataSource6" DataTextField="nazivEkipe" DataValueField="id"></asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:Olimpijada %>" SelectCommand="SELECT [nazivEkipe], [id] FROM [Ekipa]"></asp:SqlDataSource>
        </p>
        <p>
             Ekipa2</p>
        <p>
            <asp:ListBox ID="ListBox10" runat="server" DataSourceID="SqlDataSource7" DataTextField="nazivEkipe" DataValueField="id" Width="109px"></asp:ListBox>
            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:Olimpijada %>" SelectCommand="SELECT [id], [nazivEkipe] FROM [Ekipa]"></asp:SqlDataSource>
        </p>
        <p>
            faza:<asp:TextBox ID="txtfazautakmice" runat="server"></asp:TextBox>
            <asp:Button ID="Button17" runat="server" OnClick="Button17_Click" Text="unos" />
        </p>
        <p>
            Utakmica;</p>
   </div>
    <asp:ListBox ID="ListBox11" runat="server" DataSourceID="SqlDataSource9" DataTextField="id" DataValueField="id" Width="121px"></asp:ListBox>
    <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:Olimpijada %>" SelectCommand="SELECT [id] FROM [Utakmica]"></asp:SqlDataSource>
    GOTOVA UTAKMICA:<br />
    REZULTAT1:<asp:TextBox ID="txtrezultat1utakmica" runat="server" OnTextChanged="TextBox1_TextChanged" style="margin-left: 18px"></asp:TextBox>
    <br />
    REZULTAT2:<asp:TextBox ID="txtrezultat2utakmica" runat="server"></asp:TextBox>
    <asp:Button ID="Button18" runat="server" OnClick="Button18_Click" Text="Dodaj" />
</asp:Content>
