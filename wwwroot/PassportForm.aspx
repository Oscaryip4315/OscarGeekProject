<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PassportForm.aspx.vb" Inherits="PassportForm" %>

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
        margin: 0px auto 0px 250px;
    }
    
    .lefttable
    {
        width: 80%;
        height: 30px;
    }
    
    .righttable
    {
        width: 110px;
        height: 30px;
    }
    
    .tablepanel2
    {
        width: 90px;
    }
    
    .tablepanel3
    {
        width: 239px;
    }
    
    .tablepanel4
    {
        width: 109px;
    }
    
    .footer
    {
        text-align:center;
    }
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">

        <asp:Image ID="Image1" runat="server" Height="140px" Width="290px" 
            ImageUrl="Image/AirAsia-MAS-FireFly-will-face-stiffer-competition.jpg" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Passport Details" 
            Font-Bold="True" Font-Size="35px"></asp:Label>

        <br />
        <br />
        <br />

        <fieldset class="fieldset" style="height: 53px; width: 660px">
        <legend align="left" style="font-weight: bold">Search Record</legend>
        <asp:Label ID="Label2" runat="server" Text="Nationality Search"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="NationalitySearch" runat="server" Height="20px" Width="120px" OnSelectedIndexChanged="NationalitySearch_SelectedIndexChanged" AutoPostBack = "true">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="NameSearch" runat="server" Height="20px" Width="200px">
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

                <%--<iframe id="frame1" src="NationalityForm.aspx" frameborder="0" scrolling="no"></iframe>
                <br />
                <br />--%>
                <%--<asp:Label ID="Label4" runat="server" Text="Nationality"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="Nationality" runat="server" Width="121px" Height="20px" 
                    OnSelectedIndexChanged="Nationality_SelectedIndexChanged" AutoPostBack = "true" 
                    Enabled="False">
                </asp:DropDownList>

                &nbsp;&nbsp;

                <asp:Button ID="NationalityBtn" runat="server" Text="Add a nationality" />

                <br />
                <br />

                <asp:Label ID="Label5" runat="server" Text="Passport User"></asp:Label>
                &nbsp;
                <asp:DropDownList ID="PassportUser" runat="server" Width="200px" Height="20px" 
                    Enabled="False">
                </asp:DropDownList>

                <br />
                <br />

                <asp:Label ID="Label10" runat="server" Text="Name"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="Name" runat="server" Width="121px" Height="20px">
                </asp:DropDownList>

                <br />
                <br />

                <asp:Label ID="Label6" runat="server" Text="Passport No"></asp:Label>

                &nbsp;&nbsp;&nbsp;

                <asp:TextBox ID="PassportNo" runat="server" Width="180px" Enabled="False"></asp:TextBox>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Text="Issuing Country"></asp:Label>
                
                &nbsp;
                
                <asp:DropDownList ID="IssuingCountry" runat="server" Height="20px" 
                    Width="170px" Enabled="False">
                </asp:DropDownList>

                <br />
                <br />

                <asp:Label ID="Label7" runat="server" Text="IC No" Visible="False"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="ICNo" runat="server" Width="180px" Visible="False" 
                    Enabled="False"></asp:TextBox>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label9" runat="server" Text="Expired Date"></asp:Label>

                &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="DOB" runat="server" Enabled="False"></asp:TextBox>
                <asp:Image ID="Image2" runat="server" ImageUrl="Image/calender.png" />
                <br />
                <br />--%>
    
            <table class="lefttable">
            <tr>
                <td class="righttable">
                    <asp:Label ID="Label4" runat="server" Text="Nationality"></asp:Label>
                </td>
                <td style="text-align: left">
                <asp:DropDownList ID="Nationality" runat="server" Width="121px" Height="20px" 
                    OnSelectedIndexChanged="Nationality_SelectedIndexChanged" AutoPostBack = "true" 
                    Enabled="False">
                </asp:DropDownList>

                &nbsp;

                <asp:Button ID="NationalityBtn" runat="server" Text="Add a nationality" />
                </td>
            </tr>
        </table>

        <table class="lefttable">
            <tr>
                <td class="righttable">
                    <asp:Label ID="Label10" runat="server" Text="Name"></asp:Label>
                </td>
                <td style="text-align: left" class="tablepanel3">
                <asp:DropDownList ID="Name" runat="server" Width="160px" Height="20px" 
                        Enabled="False">
                </asp:DropDownList>
                </td>

                <td style="text-align: left" class="tablepanel4">
                
                    <asp:Label ID="Label8" runat="server" Text="Issuing Country"></asp:Label>
                
                </td>

                <td>

                <asp:DropDownList ID="IssuingCountry" runat="server" Height="20px" 
                    Width="170px" Enabled="False" style="margin-left: 0px">
                </asp:DropDownList>
                
                </td>
            </tr>
        </table>

        <table class="lefttable">
            <tr>
                <td class="righttable">
                    <asp:Label ID="Label6" runat="server" Text="Passport No"></asp:Label>
                
                </td>
                <td style="text-align: left">

                <asp:TextBox ID="PassportNo" runat="server" Width="180px" Enabled="False"></asp:TextBox>

                </td>

                <td style="text-align: left" class="tablepanel2">

                <asp:Label ID="Label9" runat="server" Text="Expired Date"></asp:Label>

                </td>

                <td>
                
                <asp:TextBox ID="DOB" runat="server" Enabled="False"></asp:TextBox>
                <asp:Image ID="Image2" runat="server" ImageUrl="Image/calender.png" />

                </td>
            </tr>
        </table>

        <table class="lefttable">
            <tr>
                <td class="righttable">
                    <asp:Label ID="Label7" runat="server" Text="IC No" Visible="False"></asp:Label>
                
                </td>
                <td style="text-align: left">

                <asp:TextBox ID="ICNo" runat="server" Width="180px" Visible="False" 
                    Enabled="False"></asp:TextBox>

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
