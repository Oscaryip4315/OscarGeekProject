<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MainPage.aspx.vb" Inherits="MainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
    
    #MainFormButton
    {
        padding: 6px;
        -webkit-box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -moz-box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -webkit-border-radius: 15px; 
        -moz-border-radius: 15px; 
        -border-radius: 15px;
    }
    
    #PassportFormButton
    {
        padding: 6px;
        -webkit-box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -moz-box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -webkit-border-radius: 15px; 
        -moz-border-radius: 15px; 
        -border-radius: 15px;
    }
    
    #PaymentFormButton
    {
        padding: 6px;
        -webkit-box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -moz-box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -webkit-border-radius: 15px; 
        -moz-border-radius: 15px; 
        -border-radius: 15px;
    }
    
    #ProjectFormButton
    {
        padding: 6px;
        -webkit-box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -moz-box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -webkit-border-radius: 15px; 
        -moz-border-radius: 15px; 
        -border-radius: 15px;
    }
    
    #TravellerFormButton
    {
        padding: 6px;
        -webkit-box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -moz-box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -box-shadow: 0 0 6px rgba(132, 132, 132, .75);
        -webkit-border-radius: 15px; 
        -moz-border-radius: 15px; 
        -border-radius: 15px;
    }

    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="header">

        <asp:Label ID="Label1" runat="server" Text="Select a Form to Open" 
            Font-Bold="True" Font-Size="35px"></asp:Label>

        <br />
        <br />
        <br />

    <div>
    
        <asp:ImageButton ID="MainFormButton" runat="server" Height="100px" 
            Width="650px" BackColor="#666666" ImageUrl="Image/MainForm.png" 
            PostBackUrl="MainForm.aspx" />

        <br />
        <br />
        <br />
        <br />

        <asp:ImageButton ID="PassportFormButton" runat="server" Height="100px" 
            Width="650px" BackColor="#666666" ImageUrl="Image/PassportForm.png" 
            PostBackUrl="PassportForm.aspx" />

        <br />
        <br />
        <br />
        <br />

        <asp:ImageButton ID="PaymentFormButton" runat="server" Height="100px" 
            Width="650px" BackColor="#666666" ImageUrl="Image/PaymentForm.png" 
            PostBackUrl="PaymentForm.aspx" />

        <br />
        <br />
        <br />
        <br />

        <asp:ImageButton ID="ProjectFormButton" runat="server" Height="100px" 
            Width="650px" BackColor="#666666" ImageUrl="Image/ProjectsForm.png" 
            PostBackUrl="ProjectForm.aspx" />

        <br />
        <br />
        <br />
        <br />

        <asp:ImageButton ID="TravellerFormButton" runat="server" Height="100px" 
            Width="650px" BackColor="#666666" ImageUrl="Image/TravellerForm.png" 
            PostBackUrl="TravellerForm.aspx" />

    </div>
    </div>
    </form>
</body>
</html>
