Imports System.Data.SqlClient
Imports System.Data

Partial Class NationalityForm
    Inherits System.Web.UI.Page

    Dim strCON As String
    Dim connection As SqlConnection
    Dim strSQL As String
    Dim command As SqlCommand
    Dim dataReader As SqlDataReader

    Private Sub ResetState()

        NationalityTxt.Text = ""

    End Sub

    Protected Sub NewBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewBtn.Click

        Me.NationalityTxt.Enabled = True

    End Sub

    Protected Sub CancelBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelBtn.Click

        Call ResetState()

    End Sub

    Protected Sub SaveBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveBtn.Click

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        connection.Open()
        strSQL = "SELECT Nationality FROM dbo.NationalityDetails WHERE Nationality = @Nationality"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@Nationality", Me.NationalityTxt.Text.ToUpper)
        dataReader = command.ExecuteReader
        If dataReader.HasRows Then
            
            MsgBox("Nationality Already Exist!", MsgBoxStyle.Exclamation, "Add New Nationality!")
            dataReader.Close()
            Call ResetState()

        Else

            dataReader.Close()
            strSQL = "INSERT INTO dbo.NationalityDetails (Nationality) VALUES (@Nationality)"
            command = New SqlCommand(strSQL, connection)
            command.Parameters.AddWithValue("@Nationality", Me.NationalityTxt.Text.ToUpper)
            dataReader = command.ExecuteReader
            dataReader.Close()
            command.Parameters.Clear()
            MsgBox("Saved Successfully")
            connection.Close()
            Call ResetState()

        End If

    End Sub
End Class
