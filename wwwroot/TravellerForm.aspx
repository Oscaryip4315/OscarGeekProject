<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TravellerForm.aspx.vb" Inherits="TravellerForm" %>
<%--<OutputCache(CacheProfile:="Cache1Hour")>--%>
<%--<%@ OutputCache Duration=5 VaryByParam="SaveBtn" VaryByCustom="browser" %>--%>
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
            $("#<%=DOB.ClientID %>").dynDateTime({
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

//        function openwd() {
//            var myWindow = window.open("NationalityForm.aspx", "", "toolbar=yes, scrollbars=yes, resizable=yes, top=100, left=100, width=600,height=500");
//            return false;
//        }

        $('form').on('click', '#btn', function (evt) {
            evt.preventDefault();
            some_js_function();
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
        <asp:Label ID="Label1" runat="server" Text="Traveller Details" 
            Font-Bold="True" Font-Size="35px"></asp:Label>

    <br />
    <br />
    <br />

        <fieldset class="fieldset" style="height: 53px; width: 489px">
        <legend align="left" style="font-weight: bold">Search Panel</legend>
        <asp:Label ID="Label2" runat="server" Text="Traveller Name"></asp:Label>
        &nbsp;&nbsp;
        <asp:DropDownList ID="TravellerNameSearch" runat="server" Height="20px" 
                Width="140px">
        </asp:DropDownList>
        &nbsp;&nbsp;
            <asp:Button ID="SearchBtn" runat="server" Text="Search" style="height: 26px" />
        </fieldset>
    </div>

        <br />
        <br />

    <div class="content">
        
        <asp:LinkButton ID="NewBtn" runat = "server">New</asp:LinkButton>
        
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
    <div class="table">
        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label3" runat="server" Text="Title"></asp:Label></td>
                <td style="text-align: left">
                <asp:DropDownList ID="TravellerTitle" runat="server" Width="121px" Height="22px" 
                        Enabled="False">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="MR"></asp:ListItem>
                    <asp:ListItem Value="MRS"></asp:ListItem>
                    <asp:ListItem Value="MS"></asp:ListItem>
                    <asp:ListItem Value="DR"></asp:ListItem>
                </asp:DropDownList>

                </td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label4" runat="server" Text="Traveller Name"></asp:Label></td>
                <td style="text-align: left">
                <asp:TextBox ID="TravellerNamee" runat="server" Width="190px" 
                        style="margin-left: 0px" CssClass="Uppercase" Enabled="False"></asp:TextBox>
                        
                
                </td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label5" runat="server" Text="Gender"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="TravellerGender" runat="server" Width="120px" 
                        Enabled="False">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="MALE"></asp:ListItem>
                        <asp:ListItem Value="FEMALE"></asp:ListItem>
                </asp:DropDownList>

                </td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label7" runat="server" Text="DOB"></asp:Label></td>
                <td style="text-align: left">
                <asp:TextBox ID="DOB" runat="server" Enabled="False"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" ImageUrl="Image/calender.png" />
                
                &nbsp;</td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label9" runat="server" Text="Nationality"></asp:Label></td>
                <td style="text-align: left">
                <asp:DropDownList ID="TravellerNationality" runat="server" Width="120px" 
                        style="margin-left: 2px" Enabled="False">
                </asp:DropDownList>

                &nbsp;
    
    <asp:Button ID="NationalityBtn" runat="server" Text="Add a nationality" />
    
                </td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                
                <asp:Label ID="Label11" runat="server" Font-Bold="False" Text="Passport No"></asp:Label>
                
                </td>
                <td style="text-align: left">
                
                <asp:TextBox ID="TravellerPassport" runat="server" style="margin-left: 0px" 
                        Enabled="False"></asp:TextBox>

                </td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                
                <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="Contact No"></asp:Label>
                
                </td>
                <td style="text-align: left">
                
                    <asp:TextBox ID="TravellerContact" runat="server" Enabled="False"></asp:TextBox>

                </td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                
                <asp:Label ID="Label8" runat="server" Font-Bold="False" Text="IC No"></asp:Label>
                
                </td>
                <td style="text-align: left">
                
                    <asp:TextBox ID="TravellerICNo" runat="server" Enabled="False"></asp:TextBox>


                </td>
            </tr>
        </table>

        <table class="style1">
            <tr>
                <td class="style3">
                
                <asp:Label ID="Label10" runat="server" Font-Bold="False" Text="Project/Dept"></asp:Label>
                
                </td>
                <td style="text-align: left">
                
                    <asp:DropDownList ID="TravellerProjectDept" runat="server" Width="120px" 
                        Enabled="False">
                </asp:DropDownList>


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
