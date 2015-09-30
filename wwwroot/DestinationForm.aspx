<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DestinationForm.aspx.vb" Inherits="DestinationForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
    <link href="Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        $(document).ready(function () {
            $("#<%=DepartureTxt.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d",
                daFormat: "%l;%M %p, %e %m, %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });

        $(document).ready(function () {
            $("#<%=ArrivalTxt.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d",
                daFormat: "%l;%M %p, %e %m, %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });

    </script>

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
        <asp:Label ID="Label1" runat="server" Text="Destination Details" 
            Font-Bold="True" Font-Size="35px"></asp:Label>

        <br />
        <br />
        <br />

        <fieldset class="fieldset" style="height: 53px; width: 410px">
        <legend align="left" style="font-weight: bold">Search Record</legend>
        <asp:Label ID="Label2" runat="server" Text="Destination"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="DestinationSearch" runat="server" Height="20px" Width="120px" >
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
                    <asp:Label ID="Label3" runat="server" Text="Destination"></asp:Label></td>
                <td style="text-align: left">
                    <asp:TextBox ID="DestinationTxt" runat="server" CssClass="Uppercase" 
                        Enabled="False" Width="170px"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label4" runat="server" Text="Departure Date"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="DepartureTxt" runat="server" Enabled="False"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" ImageUrl="Image/calender.png" />
                </td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label5" runat="server" Text="Arrival Date"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:TextBox ID="ArrivalTxt" runat="server" Enabled="False"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" ImageUrl="Image/calender.png" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
