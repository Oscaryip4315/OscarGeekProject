Imports System.Data.SqlClient
Imports System.Data
'Imports System.Data.Odbc

Partial Class MainForm
    Inherits System.Web.UI.Page

    Dim strCON As String
    Dim connection As SqlConnection
    Dim strSQL As String
    Dim command As SqlCommand
    Dim dataReader As SqlDataReader

    Private Sub AirlineType()

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        Dim queryString = "SELECT Flight_Name FROM dbo.Flights"
        connection.Open()
        '(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        Dim command = New SqlCommand(queryString, connection)
        Dim dataReader As SqlDataReader
        dataReader = command.ExecuteReader()
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (dataReader.HasRows) Then
            While (dataReader.Read())

                Me.FlightSearch.Items.Add(dataReader("Flight_Name"))
                autocompletetext.Add(dataReader("Flight_Name"))

            End While
        End If
        dataReader.Close()
        connection.Close()

        'While dataReader.Read()
        '    FlightSearch.Items.Add(dataReader("Flight_Name").ToString())
        'End While
        'Dim autocompletetext As New AutoCompleteStringCollection
        'If (dataReader.HasRows) Then
        '    While (dataReader.Read())

        '        Me.SearchDocDate.Items.Add(dataReader("stockO_DocDate"))
        '        autocompletetext.Add(dataReader("stockO_DocDate"))
        '    End While
        '    SearchDocDate.AutoCompleteMode = AutoCompleteMode.Suggest
        '    SearchDocDate.AutoCompleteSource = AutoCompleteSource.CustomSource
        '    SearchDocDate.AutoCompleteCustomSource = autocompletetext
        'End If
        'dataReader.Close()
        'connection.Close()
    End Sub

    Protected Sub FlightSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlightSearch.SelectedIndexChanged

        'If (Me.FlightSearch.Text = "AIRASIA") Then
        '    Me.BookingRefSearch.Text = "SELECT BookingRef FROM dbo.BookingHeader ORDERBY BookingRef"
        '    command = New SqlCommand(strSQL, connection)
        '    Me.BookingRefSearch.Text = dataReader("BookingRef")
        '    dataReader = command.ExecuteReader


        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        Dim rowNo As Integer = 1
        connection.Open()
        strSQL = "SELECT BookingRef FROM dbo.BookingHeader WHERE AirlinesType = @AirlinesType"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@AirlinesType", Me.FlightSearch.Text)
        dataReader = command.ExecuteReader
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (dataReader.HasRows) Then
            While dataReader.Read()
                Me.BookingRefSearch.Items.Add(dataReader("BookingRef"))
                autocompletetext.Add(dataReader("BookingRef"))
                rowNo += 1
            End While
        End If
        dataReader.Close()
        command.Parameters.Clear()
        connection.Close()

        'If (dataReader.HasRows) Then
        '    dataReader.Read()
        '    Me.BookingRefSearch.Text = dataReader("BookingRef")

        'End If
        'dataReader.Close()
        'connection.Close()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call AirlineType()

    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click

        'String str = "data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\aspnetdb.mdf;User Instance=true"
        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        connection.Open()
        strSQL = "INSERT INTO dbo.BookingHeader (BookingDate, BookingRef, TotalFare, PaymentCardNo) VALUES (@BookingDate, @BookingRef, @TotalFee, @PaymentCardNo)"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@BookingDate", Me.BookingDateTxt.Text)
        command.Parameters.AddWithValue("@BookingRef", Me.BookingRefTxt.Text)
        command.Parameters.AddWithValue("@TotalFee", Me.TotalFeeTxt.Text)
        command.Parameters.AddWithValue("@PaymentCardNo", Me.PaymentCardNoTxt.Text)
        dataReader = command.ExecuteReader
        dataReader.Close()
        command.Parameters.Clear()


        connection.Close()


    End Sub

    Protected Sub BookingRefSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BookingRefSearch.SelectedIndexChanged

        'strCON = "Data Source=192.9.200.223;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        'connection = New SqlConnection(strCON)
        'connection.Open()
        'strSQL = "SELECT BookingDate, BookingRef, TotalFare, PaymentCardNo FROM dbo.BookingHeader WHERE BookingRef = @BookingRef"
        'command = New SqlCommand(strSQL, connection)
        'DataTable tb = new DataTable();
        'command.Parameters.AddWithValue("@BookingRef", Me.BookingRefSearch.Text)
        'dataReader = command.ExecuteReader
        'If (dataReader.HasRows) Then
        '    While dataReader.Read()

        '        ds = New DataSet
        'GridView1.DataSource = ds.Tables[0]
        '        GridView1.DataBind()
        '        Me.GridView1.Rows.Add(dataReader("stockO_DocNo"), dataReader("stockOL_itemMCode"), "", dataReader("stockUL_CostCentreType"), dataReader("stockUL_CostCentre"), dataReader("stockOL_Qty"), dataReader("stockOL_UOM"), dataReader("stockO_AutoID"), dataReader("stockOL_AutoID"), dataReader("stockUL_AutoID"), dataReader("stockO_DocDate"))

        '    End While
        'End If
        'Dim cmd = New SqlCommand("Select * from dbo.Users;", connection)
        'Dim tb = New DataTable()

        'Dim da = New SqlDataAdapter(cmd)

        'da.Fill(tb)
        'tb.AcceptChanges()
        'GridView1.DataSource = tb
        'GridView1.DataBind()
    End Sub
End Class
