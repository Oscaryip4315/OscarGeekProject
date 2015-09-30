Imports System.Data.SqlClient
Imports System.Data

Partial Class TravellerForm
    Inherits System.Web.UI.Page

    Dim strCON As String
    Dim connection As SqlConnection
    Dim strSQL As String
    Dim command As SqlCommand
    Dim dataReader As SqlDataReader
    Dim cmdbtnClicked As Integer
    Dim cmdsearchClicked As Integer

    Private Sub ResetState()

        Me.TravellerTitle.Text = ""
        Me.TravellerNamee.Text = ""
        Me.TravellerGender.Text = ""
        Me.DOB.Text = ""
        Me.TravellerNationality.Text = ""
        Me.TravellerPassport.Text = ""
        Me.TravellerContact.Text = ""
        Me.TravellerICNo.Text = ""
        Me.TravellerProjectDept.Text = ""

    End Sub

    Private Sub ResetState1()

        Me.TravellerTitle.Enabled = False
        Me.TravellerNamee.Enabled = False
        Me.TravellerGender.Enabled = False
        Me.DOB.Enabled = False
        Me.TravellerNationality.Enabled = False
        Me.TravellerPassport.Enabled = False
        Me.TravellerContact.Enabled = False
        Me.TravellerICNo.Enabled = False
        Me.TravellerProjectDept.Enabled = False
        Me.TravellerNameSearch.Enabled = True

    End Sub

    Private Sub TravellerName()

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        strSQL = "SELECT Name FROM dbo.Passenger"
        connection.Open()
        Dim command = New SqlCommand(strSQL, connection)
        Dim dataReader As SqlDataReader
        dataReader = command.ExecuteReader()
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (TravellerNameSearch.SelectedIndex = -1) Then
            TravellerNameSearch.Items.Clear()
            Me.TravellerNameSearch.Items.Add("")
            While (dataReader.Read())

                Me.TravellerNameSearch.Items.Add(dataReader("Name"))
                autocompletetext.Add(dataReader("Name"))

            End While
            'TravellerNameSearch.Items.Clear()
        End If
        dataReader.Close()
        connection.Close()

    End Sub

    'Private Sub TitleName()

    '    strCON = "Data Source=192.9.200.223;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
    '    connection = New SqlConnection(strCON)
    '    Dim queryString = "SELECT Title FROM dbo.Passenger GROUP BY Title"
    '    connection.Open()
    '    Dim command = New SqlCommand(queryString, connection)
    '    Dim dataReader As SqlDataReader
    '    dataReader = command.ExecuteReader()
    '    Dim autocompletetext As New CommaDelimitedStringCollection
    '    If (dataReader.HasRows) Then
    '        While (dataReader.Read())

    '            Me.TravellerTitle.Items.Add(dataReader("Title"))
    '            autocompletetext.Add(dataReader("Title"))

    '        End While
    '    End If
    '    dataReader.Close()
    '    connection.Close()

    'End Sub

    'Private Sub Genderr()

    '    strCON = "Data Source=192.9.200.223;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
    '    connection = New SqlConnection(strCON)
    '    Dim queryString = "SELECT Gender FROM dbo.Passenger GROUP BY Gender"
    '    connection.Open()
    '    Dim command = New SqlCommand(queryString, connection)
    '    Dim dataReader As SqlDataReader
    '    dataReader = command.ExecuteReader()
    '    Dim autocompletetext As New CommaDelimitedStringCollection
    '    If (dataReader.HasRows) Then
    '        While (dataReader.Read())

    '            Me.TravellerGender.Items.Add(dataReader("Gender"))
    '            autocompletetext.Add(dataReader("Gender"))

    '        End While
    '    End If
    '    dataReader.Close()
    '    connection.Close()

    'End Sub

    Private Sub Nationalityy()

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        strSQL = "SELECT Nationality FROM dbo.NationalityDetails GROUP BY Nationality"
        connection.Open()
        Dim command = New SqlCommand(strSQL, connection)
        Dim dataReader As SqlDataReader
        dataReader = command.ExecuteReader()
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (TravellerNationality.SelectedIndex = -1) Then
            Me.TravellerNationality.Items.Clear()
            Me.TravellerNationality.Items.Add("")
            While (dataReader.Read())

                Me.TravellerNationality.Items.Add(dataReader("Nationality"))
                autocompletetext.Add(dataReader("Nationality"))

            End While
        End If
        dataReader.Close()
        connection.Close()

    End Sub

    Private Sub ProjectDeptt()

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        strSQL = "SELECT ProjectDept FROM dbo.Passenger GROUP BY ProjectDept"
        connection.Open()
        Dim command = New SqlCommand(strSQL, connection)
        Dim dataReader As SqlDataReader
        dataReader = command.ExecuteReader()
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (TravellerProjectDept.SelectedIndex = -1) Then
            Me.TravellerProjectDept.Items.Clear()
            Me.TravellerProjectDept.Items.Add("")
            While (dataReader.Read())

                Me.TravellerProjectDept.Items.Add(dataReader("ProjectDept"))
                autocompletetext.Add(dataReader("ProjectDept"))

            End While
        End If
        dataReader.Close()
        connection.Close()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call TravellerName()
        'Call TitleName()
        'Call Genderr()
        Call Nationalityy()
        Call ProjectDeptt()
        'HttpResponse.RemoveOutputCacheItem("/wwwroot/TravellerForm.aspx")

    End Sub

    Protected Sub NationalityBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NationalityBtn.Click

        Dim queryString As String = "NationalityForm.aspx"
        Dim newWin As String = "window.open('" & queryString & "');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)
        'Dim script As String = String.Empty
        'script = "window.open('NationalityForm.aspx?id=""');"
        'Display pop up
        'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Me, Me.[GetType](), "ScriptKey", script, True)
        'Button2.Attributes.Add("onclientclick", "window.open('NationalityForm'); return false;")

    End Sub

    Protected Sub CancelBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelBtn.Click

        Call ResetState()

    End Sub

    'Protected Sub TravellerNameSearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TravellerNameSearch.SelectedIndexChanged

    '    strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
    '    connection = New SqlConnection(strCON)
    '    connection.Open()
    '    strSQL = "SELECT Title, Name, Gender, DOB, Nationality, PassportNo, ContactNo, ICNo, ProjectDept FROM dbo.Passenger WHERE Name = @Name"
    '    command = New SqlCommand(strSQL, connection)
    '    command.Parameters.AddWithValue("@Name", Me.TravellerNameSearch.Text)
    '    dataReader = command.ExecuteReader
    '    If (dataReader.HasRows) Then
    '        dataReader.Read()

    '        Me.TravellerTitle.Text = dataReader("Title")
    '        Me.TravellerNamee.Text = dataReader("Name")

    '    End If

    'End Sub

    Protected Sub SearchBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchBtn.Click

        connection = New SqlConnection(strCON)
        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection.Open()
        strSQL = "SELECT Title, Name, Gender, DOB, Nationality, PassportNo, ContactNo, ICNo, ProjectDept FROM dbo.Passenger WHERE Name = @Name"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@Name", Me.TravellerNameSearch.Text)
        dataReader = command.ExecuteReader
        If (dataReader.HasRows) Then
            dataReader.Read()

            Me.TravellerTitle.Text = dataReader("Title")
            Me.TravellerNamee.Text = dataReader("Name")
            Me.TravellerGender.Text = dataReader("Gender")
            Me.DOB.Text = dataReader("DOB")
            'Me.TravellerNationality.Style.Add(HtmlTextWriterStyle.Visibility, "Hidden")
            Me.TravellerNationality.Text = dataReader("Nationality")
            If IsDBNull(dataReader("PassportNo")) Then

                Me.TravellerPassport.Text = ""

            Else

                Me.TravellerPassport.Text = dataReader("PassportNo")

            End If

            Me.TravellerContact.Text = dataReader("ContactNo")

            If IsDBNull(dataReader("ICNo")) Then

                Me.TravellerICNo.Text = ""

            Else

                Me.TravellerICNo.Text = dataReader("ICNo")

            End If

            Me.TravellerProjectDept.Text = dataReader("ProjectDept")

        End If

        dataReader.Close()
        command.Parameters.Clear()
        connection.Close()

    End Sub

    Protected Sub EditBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditBtn.Click

        'If (cmdsearchClicked = 1) Then

        Me.TravellerTitle.Enabled = True
        Me.TravellerNamee.Enabled = True
        Me.TravellerGender.Enabled = True
        Me.DOB.Enabled = True
        Me.TravellerNationality.Enabled = True
        Me.TravellerPassport.Enabled = True
        Me.TravellerContact.Enabled = True
        Me.TravellerICNo.Enabled = True
        Me.TravellerProjectDept.Enabled = True

        cmdbtnClicked = 2

        'End If

    End Sub

    Protected Sub SaveBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveBtn.Click

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        connection.Open()

        If (cmdbtnClicked = 1) Then

            strSQL = "INSERT INTO dbo.Passenger (Title, Name, Gender, DOB, Nationality, PassportNo, ContactNo, ICNo, ProjectDept) VALUES (@Title, @Name, @Gender, @DOB, @Nationality, @PassportNo, @ContactNo, @ICNo, @ProjectDept)"
            command = New SqlCommand(strSQL, connection)
            command.Parameters.AddWithValue("@Title", Me.TravellerTitle.Text)
            command.Parameters.AddWithValue("@Name", Me.TravellerNamee.Text.ToUpper)
            command.Parameters.AddWithValue("@Gender", Me.TravellerGender.Text)
            command.Parameters.AddWithValue("@DOB", Me.DOB.Text)
            command.Parameters.AddWithValue("@Nationality", Me.TravellerNationality.Text)
            command.Parameters.AddWithValue("@PassportNo", Me.TravellerPassport.Text)
            command.Parameters.AddWithValue("@ContactNo", Me.TravellerContact.Text)
            command.Parameters.AddWithValue("@ICNo", Me.TravellerICNo.Text)
            command.Parameters.AddWithValue("@ProjectDept", Me.TravellerProjectDept.Text)
            dataReader = command.ExecuteReader
            dataReader.Close()
            command.Parameters.Clear()
            MsgBox("Saved Successfully")
            connection.Close()
            Call ResetState()
            Call ResetState1()

        ElseIf (cmdbtnClicked = 2) Then

            strSQL = "UPDATE dbo.Passenger SET Title = @Title, Name = @Name, Gender = @Gender, DOB = @DOB, Nationality = @Nationality, PassportNo = @PassportNo, Contacto = @ContactNo, ICNo = @ICNo, ProjectDept = @ProjectDept WHERE Name = @SearchName"
            command = New SqlCommand(strSQL, connection)
            command.Parameters.AddWithValue("@Title", Me.TravellerTitle.Text)
            command.Parameters.AddWithValue("@Name", Me.TravellerNamee.Text)
            command.Parameters.AddWithValue("@Gender", Me.TravellerGender.Text)
            command.Parameters.AddWithValue("@DOB", Me.DOB.Text)
            command.Parameters.AddWithValue("@Nationality", Me.TravellerNationality.Text)
            command.Parameters.AddWithValue("@PassportNo", Me.TravellerPassport.Text)
            command.Parameters.AddWithValue("@ContactNo", Me.TravellerContact.Text)
            command.Parameters.AddWithValue("@ICNo", Me.TravellerICNo.Text)
            command.Parameters.AddWithValue("@ProjectDept", Me.TravellerProjectDept.Text)
            command.Parameters.AddWithValue("@SearchName", Me.TravellerNameSearch.Text)
            dataReader = command.ExecuteReader
            dataReader.Close()
            command.Parameters.Clear()
            'Me.TravellerNameSearch.Items.Clear()
            MsgBox("Edited Successfully")
            connection.Close()
            Call ResetState()
            Call ResetState1()


        End If

    End Sub

    Protected Sub NewBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewBtn.Click

        'MsgBox(cmdbtnClicked)

        Me.TravellerTitle.Enabled = True
        Me.TravellerNamee.Enabled = True
        Me.TravellerGender.Enabled = True
        Me.DOB.Enabled = True
        Me.TravellerNationality.Enabled = True
        Me.TravellerPassport.Enabled = True
        Me.TravellerContact.Enabled = True
        Me.TravellerICNo.Enabled = True
        Me.TravellerProjectDept.Enabled = True
        Me.TravellerNameSearch.Enabled = False

        Me.TravellerTitle.Text = ""
        Me.TravellerNamee.Text = ""
        Me.TravellerGender.Text = ""
        Me.DOB.Text = ""
        Me.TravellerNationality.Text = ""
        Me.TravellerPassport.Text = ""
        Me.TravellerContact.Text = ""
        Me.TravellerICNo.Text = ""
        Me.TravellerProjectDept.Text = ""
        Me.TravellerNameSearch.Text = ""

        cmdbtnClicked = 1

    End Sub

    Protected Sub DeleteBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteBtn.Click

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        connection.Open()
        strSQL = "DELETE FROM dbo.Passenger WHERE Name = @NameSearch"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@NameSearch", Me.TravellerNameSearch.Text)
        dataReader = command.ExecuteReader()
        dataReader.Close()

        MsgBox("deleted successfully")
        connection.Close()
        Call ResetState()
        Call ResetState1()

    End Sub
End Class
