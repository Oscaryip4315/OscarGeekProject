<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ProjectForm.aspx.vb" Inherits="ProjectForm" %>

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
    
    .content
    {
        text-align: center;
    }
    
    .fieldset
    {
        margin: 0px auto 0px auto;
    }
    
    .table
    {
        margin: 0px auto 0px 400px;
    }
    
    .style1
    {
        width: 79%;
        height: 30px;
    }
    
    .style3
    {
        width: 117px;
        height: 30px;
    }
    
    .footer
    {
        text-align:center;
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
        <asp:Label ID="Label1" runat="server" Text="Project Details" 
            Font-Bold="True" Font-Size="35px"></asp:Label>

        <br />
        <br />
        <br />

        <fieldset class="fieldset" style="height: 53px; width: 410px">
        <legend align="left" style="font-weight: bold">Search Record</legend>
        <asp:Label ID="Label2" runat="server" Text="Project/Dept"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="ProjectDeptSearch" runat="server" Height="20px" Width="120px">
        </asp:DropDownList>

            &nbsp;&nbsp;

            <asp:Button ID="searchbtn" runat="server" Text="Search" />

        </fieldset>
    </div>
        <br />
        <br />

    <div class="content">

        <asp:LinkButton ID="newbtn" runat="server">New</asp:LinkButton>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="savebtn" runat="server">Save</asp:LinkButton>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="editbtn" runat="server">Edit</asp:LinkButton>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="deletebtn" runat="server">Delete</asp:LinkButton>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="cancelbtn" runat="server">Cancel</asp:LinkButton>

    </div>

    <br />

    <div class="table">
        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label3" runat="server" Text="Project/Dept"></asp:Label></td>
                <td style="text-align: left">
                    <asp:TextBox ID="ProjectDeptTxt" runat="server" CssClass="Uppercase" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label4" runat="server" Text="Project Code"></asp:Label></td>
                <td style="text-align: left">
                    <asp:TextBox ID="ProjectCodeTxt" runat="server" CssClass="Uppercase" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label5" runat="server" Text="Project Desc"></asp:Label></td>
                <td style="text-align: left">
                    <asp:TextBox ID="ProjectDescTxt" runat="server" Width="180px" CssClass="Uppercase" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label6" runat="server" Text="Project Location"></asp:Label></td>
                <td style="text-align: left">
                    <asp:TextBox ID="ProjectLocationTxt" runat="server" Width="180px" 
                        CssClass="Uppercase" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>

    <br />
    <br />

    <div class="footer">

    <asp:Button ID="Button1" runat="server" Text="BACK" PostBackUrl="MainPage.aspx" />

    </div>
    </form>
</body>
</html>
