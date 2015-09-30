<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MainForm.aspx.vb" Inherits="MainForm" %>

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
            $("#<%=BookingRefTxt.ClientID %>").dynDateTime({
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

        function openwd() {
            var myWindow = window.open("TravellerForm.aspx","", "toolbar=yes, scrollbars=yes, resizable=yes, top=100, left=100, width=1300,height=900");
            return false;
        }

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
    
    #GridView2
    {
        margin: 20px auto 0px auto;
    }
    
    #GridView1
    {
        margin: 20px auto 0px auto;
    }
    
    .content
    {
        text-align: center;
    }
    
    .content1
    {
        margin: 0px auto 0px auto;
    }
    
    .footer
    {
        text-align: center;
    }
    
    .fieldset
    {
        margin: 0px auto 0px auto;
    }

    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="header">

        <asp:Image ID="Image1" runat="server" Height="140px" Width="290px" 
            ImageUrl="Image/AirAsia-MAS-FireFly-will-face-stiffer-competition.jpg" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="AIR TICKETING BOOKING SYSTEM" 
            Font-Bold="True" Font-Size="35px"></asp:Label>

        <br />
        <br />
        <br />

        <fieldset class="fieldset" style="height: 53px; width: 489px">
        <legend align="left" style="font-weight: bold">Search Panel</legend>
        <asp:Label ID="Label2" runat="server" Text="Airlines"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="FlightSearch" runat="server" Height="20px" Width="120px">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="BookingRef"></asp:Label>
        &nbsp;
        <asp:DropDownList ID="BookingRefSearch" runat="server" Height="20px" Width="120px">
        </asp:DropDownList>
        </fieldset>
    </div>
        <br />
        <br />

    <div class="content">

        <asp:LinkButton ID="LinkButton1" runat="server">New</asp:LinkButton>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="LinkButton2" runat="server">Save</asp:LinkButton>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="LinkButton3" runat="server">Edit</asp:LinkButton>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="LinkButton4" runat="server">Delete</asp:LinkButton>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:LinkButton ID="LinkButton5" runat="server">Cancel</asp:LinkButton>

    </div>
    <div class="content1">
        <fieldset class="fieldset" style="height: 150px; width: 770px">
        <legend align="left" style="font-weight: bold">Booking Details</legend>
                <br />
                &nbsp;
                <asp:Label ID="Label5" runat="server" Font-Bold="False" Text="Booking Date"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:TextBox ID="BookingDateTxt" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:Image runat="server" ImageUrl="Image/calender.png" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:Label ID="Label7" runat="server" Text="Total Fee (RM)"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TotalFeeTxt" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Payment Details" 
                onclientclick="openwd()" />
                <br />
                <br />
                &nbsp;
                <asp:Label ID="Label6" runat="server" Text="Booking Ref"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="BookingRefTxt" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                <asp:Label ID="Label8" runat="server" Text="Payment Card No"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="PaymentCardNoTxt" runat="server"></asp:TextBox>

        </fieldset>
    </div>

     <div>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                Width="892px" Height="133px">
                <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="Traveller Name" />
                        <asp:BoundField HeaderText="IC No" />
                        <asp:BoundField HeaderText="Passport No" />
                        <asp:BoundField HeaderText="Project/Dept" />
                    </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
     </div>
     <br />
     <br />
     <div class="content1">
        <fieldset class="fieldset" style="height: 229px; width: 770px">
        <legend align="left" style="font-weight: bold">Flight Details</legend>

            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" 
                style="text-align: left" Width="838px" Height="169px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Departure Time" />
                    <asp:BoundField HeaderText="Arrival Time" />
                    <asp:BoundField HeaderText="Flight Date" />
                    <asp:BoundField HeaderText="Flight Destination" />
                    <asp:BoundField HeaderText="Flight Type" />
                    <asp:BoundField HeaderText="Class" />
                    <asp:BoundField HeaderText="Flight No" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
<%--            <asp:SqlDataSource ID="BookingDetails" runat="server" ConnectionString="<%$ ConnectionStrings: TestConnectionString  %>"
                SelectCommand="[dbo].[BookingDetails]">
            </asp:SqlDataSource>--%>

       </fieldset>
    </div>
    <br />
    <br />
    <div class="footer">
    
        <asp:Button ID="Button2" runat="server" Text="New Traveller" 
            PostBackUrl="TravellerForm.aspx" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="Button3" runat="server" Text="New Passport" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="Button4" runat="server" Text="New Project" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="Button5" runat="server" Text="New Destination" />
    
    </div>
    <br />
    <br />
    <div class="footer">
    
        <asp:Button ID="Button6" runat="server" Text="BACK" 
            PostBackUrl="MainPage.aspx" />
    
    </div>
    </form>
</body>
</html>
