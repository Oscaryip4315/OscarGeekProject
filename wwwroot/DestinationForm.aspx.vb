Imports System.Data.SqlClient
Imports System.Data

Partial Class DestinationForm
    Inherits System.Web.UI.Page

    Dim strCON As String
    Dim connection As SqlConnection
    Dim strSQL As String
    Dim command As SqlCommand
    Dim dataReader As SqlDataReader
    Dim cmdbtnClicked As Integer
    Dim cmdsearchClicked As Integer

    Private Sub ResetState()

        Me.DestinationTxt.Text = ""
        Me.DepartureTxt.Text = ""
        Me.ArrivalTxt.Text = ""

    End Sub

    Private Sub ResetState1()

        Me.DestinationTxt.Enabled = False
        Me.DepartureTxt.Enabled = False
        Me.ArrivalTxt.Enabled = False
        Me.DestinationSearch.Enabled = True

    End Sub

    Private Sub DestinationSearchh()


        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        strSQL = "SELECT Destination FROM dbo.Trip GROUP BY Destination"
        connection.Open()
        Dim command = New SqlCommand(strSQL, connection)
        Dim dataReader As SqlDataReader
        dataReader = command.ExecuteReader()
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (DestinationSearch.SelectedIndex = -1) Then
            DestinationSearch.Items.Clear()
            Me.DestinationSearch.Items.Add("")
            While (dataReader.Read())

                Me.DestinationSearch.Items.Add(dataReader("Destination"))
                autocompletetext.Add(dataReader("Destination"))

            End While
        End If
        dataReader.Close()
        connection.Close()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call DestinationSearchh()

    End Sub

    Protected Sub searchbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchbtn.Click

        connection = New SqlConnection(strCON)
        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection.Open()
        strSQL = "SELECT Destination, DepartDate, ArriveDate FROM dbo.Trip WHERE Destination = @Destination"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@Destination", Me.DestinationSearch.Text)
        dataReader = command.ExecuteReader
        If (dataReader.HasRows) Then
            dataReader.Read()

            Me.DestinationTxt.Text = dataReader("Destination")
            Me.DepartureTxt.Text = dataReader("DepartDate")
            Me.ArrivalTxt.Text = dataReader("ArriveDate")

        End If

        dataReader.Close()
        command.Parameters.Clear()
        connection.Close()

    End Sub

    Protected Sub newbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newbtn.Click


        Me.DestinationTxt.Enabled = True
        Me.DepartureTxt.Enabled = True
        Me.ArrivalTxt.Enabled = True
        Me.DestinationSearch.Enabled = False

        Me.DestinationTxt.Text = ""
        Me.DepartureTxt.Text = ""
        Me.ArrivalTxt.Text = ""
        Me.DestinationSearch.Text = ""

        cmdbtnClicked = 1

    End Sub

    Protected Sub cancelbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelbtn.Click

        Call ResetState()

    End Sub

    Protected Sub savebtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles savebtn.Click

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        connection.Open()

        If (cmdbtnClicked = 1) Then

            strSQL = "INSERT INTO dbo.Trip (Destination, DepartDate, ArriveDate) VALUES (@Destination, @DepartDate, @ArriveDate)"
            command = New SqlCommand(strSQL, connection)
            command.Parameters.AddWithValue("@Destination", Me.DestinationTxt.Text.ToUpper)
            command.Parameters.AddWithValue("@DepartDate", Me.DepartureTxt.Text)
            command.Parameters.AddWithValue("@ArriveDate", Me.ArrivalTxt.Text)
            dataReader = command.ExecuteReader
            dataReader.Close()
            command.Parameters.Clear()
            'Me.DestinationSearch.Items.Clear()
            MsgBox("Saved Successfully")
            connection.Close()
            Call ResetState()
            Call ResetState1()

        ElseIf (cmdbtnClicked = 2) Then

            strSQL = "UPDATE dbo.Trip SET Destination = @Destination, DepartDate = @DepartDate, ArriveDate = @ArriveDate WHERE Destination = @DestinationSearch"
            command = New SqlCommand(strSQL, connection)
            command.Parameters.AddWithValue("@Destination", Me.DestinationTxt.Text)
            command.Parameters.AddWithValue("@DepartDate", Me.DepartureTxt.Text)
            command.Parameters.AddWithValue("@ArriveDate", Me.ArrivalTxt.Text)
            command.Parameters.AddWithValue("@DestinationSearch", Me.DestinationSearch.Text)
            dataReader = command.ExecuteReader
            dataReader.Close()
            command.Parameters.Clear()
            'Me.DestinationSearch.Items.Clear()
            MsgBox("Edited Successfully")
            connection.Close()
            Call ResetState()
            Call ResetState1()


        End If

    End Sub

    Protected Sub editbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editbtn.Click

        'If (cmdsearchClicked = 1) Then

        Me.DestinationTxt.Enabled = True
        Me.DepartureTxt.Enabled = True
        Me.ArrivalTxt.Enabled = True

        cmdsearchClicked = 2

        'End If

    End Sub

    Protected Sub deletebtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deletebtn.Click

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        connection.Open()

        strSQL = "DELETE FROM dbo.Trip WHERE Destination = @DestinationSearch"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@DestinationSearch", Me.DestinationSearch.Text)
        dataReader = command.ExecuteReader()
        dataReader.Close()
        command.Parameters.Clear()

        Me.DestinationSearch.Items.Clear()
        MsgBox("Deleted successfully")
        connection.Close()
        Call ResetState()
        Call ResetState1()

    End Sub
End Class
