<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NationalityForm.aspx.vb" Inherits="NationalityForm" %>
<%--<%@ PreviousPageType PageType VirtualPath ="~/PassportForm.aspx" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <%--<script type="text/javascript">

        function askConfirm()
        {
            alert("Saved Successfully")
        }

    </script>--%>

    <style type="text/css">

     body
    {
        width: 90%;
        margin: 20px auto 30px auto;
    }
    
    .header
    {
        text-align: center;
    }
    
    .content
    {
        text-align: center;
    }
    
    .content1
    {
        text-align: center;
    }
    
    .Uppercase
    {
        text-transform: uppercase;
    }

    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="header">

        <asp:Image ID="Image1" runat="server" Height="140px" Width="290px" 
            ImageUrl="Image/AirAsia-MAS-FireFly-will-face-stiffer-competition.jpg" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Traveller Details" 
            Font-Bold="True" Font-Size="35px"></asp:Label>

    </div>

    <br />
    <br />

    <div class="content">

        <asp:LinkButton ID="NewBtn" runat="server">New</asp:LinkButton>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="SaveBtn" runat="server">Save</asp:LinkButton>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="EditBtn" runat="server">Edit</asp:LinkButton>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="DeleteBtn" runat="server">Delete</asp:LinkButton>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="CancelBtn" runat="server">Cancel</asp:LinkButton>

    </div>
    <br />
    <div class="content1">
    
        <asp:Label ID="Label2" runat="server" Text="Nationality"></asp:Label>
    &nbsp;
        <asp:TextBox ID="NationalityTxt" runat="server" Enabled="False" CssClass="Uppercase"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
