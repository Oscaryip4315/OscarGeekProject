Imports System.Data.SqlClient
Imports System.Data

Partial Class ProjectForm
    Inherits System.Web.UI.Page

    Dim strCON As String
    Dim connection As SqlConnection
    Dim strSQL As String
    Dim command As SqlCommand
    Dim dataReader As SqlDataReader
    Dim cmdbtnClicked As Integer
    Dim cmdsearchClicked As Integer

    Private Sub ResetState()

        Me.ProjectDeptTxt.Text = ""
        Me.ProjectCodeTxt.Text = ""
        Me.ProjectDescTxt.Text = ""
        Me.ProjectLocationTxt.Text = ""

    End Sub

    Private Sub ResetState1()

        Me.ProjectDeptTxt.Enabled = False
        Me.ProjectCodeTxt.Enabled = False
        Me.ProjectDescTxt.Enabled = False
        Me.ProjectLocationTxt.Enabled = False
        Me.ProjectDeptSearch.Enabled = True

    End Sub

    Private Sub ProjectDeptSearchh()


        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        strSQL = "SELECT ProjectDesc FROM dbo.Project GROUP BY ProjectDesc"
        connection.Open()
        Dim command = New SqlCommand(strSQL, connection)
        Dim dataReader As SqlDataReader
        dataReader = command.ExecuteReader()
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (ProjectDeptSearch.SelectedIndex = -1) Then
            ProjectDeptSearch.Items.Clear()
            Me.ProjectDeptSearch.Items.Add("")
            While (dataReader.Read())

                Me.ProjectDeptSearch.Items.Add(dataReader("ProjectDesc"))
                autocompletetext.Add(dataReader("ProjectDesc"))

            End While
        End If
        dataReader.Close()
        connection.Close()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call ProjectDeptSearchh()

    End Sub

    Protected Sub searchbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchbtn.Click

        connection = New SqlConnection(strCON)
        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection.Open()
        strSQL = "SELECT ProjectDept, ProjectCode, ProjectDesc, ProjectLocation FROM dbo.Project WHERE ProjectDesc = @ProjectDesc"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@ProjectDesc", Me.ProjectDeptSearch.Text)
        dataReader = command.ExecuteReader
        If (dataReader.HasRows) Then
            dataReader.Read()

            Me.ProjectDeptTxt.Text = dataReader("ProjectDept")
            Me.ProjectCodeTxt.Text = dataReader("ProjectCode")
            Me.ProjectDescTxt.Text = dataReader("ProjectDesc")
            Me.ProjectLocationTxt.Text = dataReader("ProjectLocation")

        End If

        dataReader.Close()
        command.Parameters.Clear()
        connection.Close()

    End Sub

    Protected Sub newbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newbtn.Click

        Me.ProjectDeptTxt.Enabled = True
        Me.ProjectCodeTxt.Enabled = True
        Me.ProjectDescTxt.Enabled = True
        Me.ProjectLocationTxt.Enabled = True
        Me.ProjectDeptSearch.Enabled = False

        Me.ProjectDeptTxt.Text = ""
        Me.ProjectCodeTxt.Text = ""
        Me.ProjectDescTxt.Text = ""
        Me.ProjectDescTxt.Text = ""
        Me.ProjectLocationTxt.Text = ""
        Me.ProjectDeptSearch.Text = ""

        cmdbtnClicked = 1

    End Sub

    Protected Sub cancelbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelbtn.Click

        Call ResetState()

    End Sub

    Protected Sub editbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editbtn.Click

        'If (cmdsearchClicked = 1) Then

        Me.ProjectDeptTxt.Enabled = True
        Me.ProjectCodeTxt.Enabled = True
        Me.ProjectDescTxt.Enabled = True
        Me.ProjectLocationTxt.Enabled = True

        cmdsearchClicked = 2

        'End If

    End Sub

    Protected Sub savebtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles savebtn.Click

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        connection.Open()

        If (cmdbtnClicked = 1) Then

            strSQL = "INSERT INTO dbo.Project (ProjectDept, ProjectCode, ProjectDesc, ProjectLocation) VALUES (@ProjectDept, @ProjectCode, @ProjectDesc, @ProjectLocation)"
            command = New SqlCommand(strSQL, connection)
            command.Parameters.AddWithValue("@ProjectDept", Me.ProjectDeptTxt.Text.ToUpper)
            command.Parameters.AddWithValue("@ProjectCode", Me.ProjectCodeTxt.Text.ToUpper)
            command.Parameters.AddWithValue("@ProjectDesc", Me.ProjectDescTxt.Text.ToUpper)
            command.Parameters.AddWithValue("@ProjectLocation", Me.ProjectLocationTxt.Text)
            dataReader = command.ExecuteReader
            dataReader.Close()
            command.Parameters.Clear()
            'Me.ProjectDeptSearch.Items.Clear()
            MsgBox("Saved Successfully")
            connection.Close()
            Call ResetState()
            Call ResetState1()

        ElseIf (cmdbtnClicked = 2) Then

            strSQL = "UPDATE dbo.Project SET ProjectDept = @ProjectDept, ProjectCode = @ProjectCode, ProjectDesc = @ProjectDesc, ProjectLocation = @ProjectLocation WHERE ProjectDept = @ProjectDeptSearch"
            command = New SqlCommand(strSQL, connection)
            command.Parameters.AddWithValue("@ProjectDept", Me.ProjectDeptTxt.Text)
            command.Parameters.AddWithValue("@ProjectCode", Me.ProjectCodeTxt.Text)
            command.Parameters.AddWithValue("@ProjectDesc", Me.ProjectDescTxt.Text)
            command.Parameters.AddWithValue("@ProjectLocation", Me.ProjectLocationTxt.Text)
            command.Parameters.AddWithValue("@ProjectDeptSearch", Me.ProjectDeptSearch.Text)
            dataReader = command.ExecuteReader
            dataReader.Close()
            command.Parameters.Clear()
            'Me.ProjectDeptSearch.Items.Clear()
            MsgBox("Edited Successfully")
            connection.Close()
            Call ResetState()
            Call ResetState1()


        End If

    End Sub

    Protected Sub deletebtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deletebtn.Click

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        connection.Open()

        strSQL = "DELETE FROM dbo.Project WHERE ProjectDept = @ProjectDeptSearch"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@ProjectDeptSearch", Me.ProjectDeptSearch.Text)
        dataReader = command.ExecuteReader()
        dataReader.Close()
        command.Parameters.Clear()

        Me.ProjectDeptSearch.Items.Clear()
        MsgBox("Deleted successfully")
        connection.Close()
        Call ResetState()
        Call ResetState1()

    End Sub
End Class
