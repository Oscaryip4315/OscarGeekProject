Imports System.Data.SqlClient
Imports System.Data

Partial Class PassportForm
    Inherits System.Web.UI.Page

    Dim strCON As String
    Dim connection As SqlConnection
    Dim strSQL As String
    Dim command As SqlCommand
    Dim dataReader As SqlDataReader
    Dim cmdbtnClicked As Integer
    Dim cmdsearchClicked As Integer

    Private Sub ResetState()

        Me.Nationality.Text = ""
        Me.Name.Text = ""
        Me.PassportNo.Text = ""
        Me.ICNo.Text = ""
        Me.IssuingCountry.Text = ""
        Me.DOB.Text = ""
        'Me.NationalitySearch.Items.Clear()
        'Me.NameSearch.Items.Clear()

    End Sub

    Private Sub ResetState1()

        Me.Nationality.Enabled = False
        Me.PassportNo.Enabled = False
        Me.Name.Enabled = False
        Me.ICNo.Enabled = False
        Me.IssuingCountry.Enabled = False
        Me.DOB.Enabled = False
        Me.NationalitySearch.Enabled = True
        Me.NameSearch.Enabled = True

    End Sub

    Private Sub NationalitySearchh()


        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        strSQL = "SELECT Nationality FROM dbo.Passenger GROUP BY Nationality"
        connection.Open()
        Dim command = New SqlCommand(strSQL, connection)
        Dim dataReader As SqlDataReader
        dataReader = command.ExecuteReader()
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (NationalitySearch.SelectedIndex = -1) Then
            NationalitySearch.Items.Clear()
            'For Each item As ListItem In NationalitySearch.Items
            '    If item.Selected Then
            Me.NationalitySearch.Items.Add("")
            While (dataReader.Read())

                Me.NationalitySearch.Items.Add(dataReader("Nationality"))
                autocompletetext.Add(dataReader("Nationality"))

            End While
            'NationalitySearch.DataBind()
            'TravellerNameSearch.Items.Clear()
        End If
        dataReader.Close()
        connection.Close()

    End Sub

    Private Sub NationalityTxtBox()

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        strSQL = "SELECT Nationality FROM dbo.NationalityDetails GROUP BY Nationality"
        connection.Open()
        Dim command = New SqlCommand(strSQL, connection)
        Dim dataReader As SqlDataReader
        dataReader = command.ExecuteReader()
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (Nationality.SelectedIndex = -1) Then
            Nationality.Items.Clear()
            'For Each item As ListItem In NationalitySearch.Items
            '    If item.Selected Then
            Me.Nationality.Items.Add("")
            While (dataReader.Read())

                Me.Nationality.Items.Add(dataReader("Nationality"))
                autocompletetext.Add(dataReader("Nationality"))

            End While
            'NationalitySearch.DataBind()
            'TravellerNameSearch.Items.Clear()
        End If
        dataReader.Close()
        connection.Close()

    End Sub

    Private Sub PassportUserList()


        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        strSQL = "SELECT Name FROM dbo.Passenger GROUP BY Name"
        connection.Open()
        Dim command = New SqlCommand(strSQL, connection)
        Dim dataReader As SqlDataReader
        dataReader = command.ExecuteReader()
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (Name.SelectedIndex = -1) Then
            Name.Items.Clear()
            'For Each item As ListItem In NationalitySearch.Items
            '    If item.Selected Then
            Me.Name.Items.Add("")
            While (dataReader.Read())

                Me.Name.Items.Add(dataReader("Name"))
                autocompletetext.Add(dataReader("Name"))

            End While
            'NationalitySearch.DataBind()
            'TravellerNameSearch.Items.Clear()
        End If
        dataReader.Close()
        connection.Close()

    End Sub

    Private Sub IssuingCountryList()


        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        strSQL = "SELECT IssuingCountry FROM dbo.PassengerPassport GROUP BY IssuingCountry"
        connection.Open()
        Dim command = New SqlCommand(strSQL, connection)
        Dim dataReader As SqlDataReader
        dataReader = command.ExecuteReader()
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (IssuingCountry.SelectedIndex = -1) Then
            IssuingCountry.Items.Clear()
            'For Each item As ListItem In NationalitySearch.Items
            '    If item.Selected Then
            Me.IssuingCountry.Items.Add("")
            While (dataReader.Read())

                Me.IssuingCountry.Items.Add(dataReader("IssuingCountry"))
                autocompletetext.Add(dataReader("IssuingCountry"))

            End While
            'NationalitySearch.DataBind()
            'TravellerNameSearch.Items.Clear()
        End If
        dataReader.Close()
        connection.Close()

    End Sub

    'Public ReadOnly Property CurrentNationality() As String
    '    Get

    '        Return DropDownList3.Text

    '    End Get
    'End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call NationalitySearchh()
        Call NationalityTxtBox()
        Call PassportUserList()
        Call IssuingCountryList()

    End Sub

    Protected Sub NationalitySearch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NationalitySearch.SelectedIndexChanged

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        Dim rowNo As Integer = 1
        connection.Open()
        strSQL = "SELECT Name FROM dbo.Passenger WHERE Nationality = @Nationality"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@Nationality", NationalitySearch.SelectedItem.Text)
        dataReader = command.ExecuteReader
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (dataReader.HasRows) Then
            NameSearch.Items.Clear()
            Me.NameSearch.Items.Add("")
            While dataReader.Read()
                Me.NameSearch.Items.Add(dataReader("Name"))
                autocompletetext.Add(dataReader("Name"))
                rowNo += 1
            End While
        End If
        dataReader.Close()
        command.Parameters.Clear()
        connection.Close()

        If (NationalitySearch.SelectedItem.Text = "MALAYSIAN") Then

            Label7.Visible = True
            ICNo.Visible = True

        Else

            Label7.Visible = False
            ICNo.Visible = False

        End If

    End Sub

    Protected Sub NationalityBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NationalityBtn.Click

        Dim queryString As String = "NationalityForm.aspx"
        Dim newWin As String = "window.open('" & queryString & "');"
        ClientScript.RegisterStartupScript(Me.GetType(), "pop", newWin, True)

    End Sub

    Protected Sub newbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newbtn.Click

        Me.Nationality.Enabled = True
        Me.PassportNo.Enabled = True
        Me.ICNo.Enabled = True
        Me.IssuingCountry.Enabled = True
        Me.DOB.Enabled = True
        Me.Name.Enabled = True
        Me.NationalitySearch.Enabled = False
        Me.NameSearch.Enabled = False

        Me.Nationality.Text = ""
        Me.PassportNo.Text = ""
        Me.ICNo.Text = ""
        Me.IssuingCountry.Text = ""
        Me.DOB.Text = ""
        Me.Name.Text = ""
        Me.NationalitySearch.Text = ""
        Me.NameSearch.Text = ""

        cmdbtnClicked = 1

    End Sub

    Protected Sub cancelbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelbtn.Click

        Call ResetState()

    End Sub


    Protected Sub Nationality_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Nationality.SelectedIndexChanged

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        Dim rowNo As Integer = 1
        connection.Open()
        strSQL = "SELECT Name FROM dbo.Passenger WHERE Nationality = @Nationality"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@Nationality", Nationality.SelectedItem.Text)
        dataReader = command.ExecuteReader
        Dim autocompletetext As New CommaDelimitedStringCollection
        If (dataReader.HasRows) Then
            Name.Items.Clear()
            Me.Name.Items.Add("")
            While dataReader.Read()
                Me.Name.Items.Add(dataReader("Name"))
                autocompletetext.Add(dataReader("Name"))
                rowNo += 1
            End While
        End If
        dataReader.Close()
        command.Parameters.Clear()
        connection.Close()

        If (Nationality.SelectedItem.Text = "MALAYSIAN") Then

            Label7.Visible = True
            ICNo.Visible = True

        Else

            Label7.Visible = False
            ICNo.Visible = False

        End If

    End Sub

    Protected Sub searchbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchbtn.Click

        connection = New SqlConnection(strCON)
        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection.Open()
        strSQL = "SELECT A.Nationality, A.Name, A.ICNo, B.PassportOwner, B.PassportNo, B.IssuingCountry, B.ExpiredDate FROM dbo.Passenger AS A LEFT JOIN dbo.PassengerPassport AS B ON A.Name = B.PassportOwner WHERE Name = @Name"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@Name", Me.NameSearch.Text)
        dataReader = command.ExecuteReader
        If (dataReader.HasRows) Then
            dataReader.Read()

            Me.Nationality.Text = dataReader("Nationality")
            Me.Name.Text = dataReader("Name")
            'Me.TravellerNationality.Style.Add(HtmlTextWriterStyle.Visibility, "Hidden")
            'Me.TravellerNationality.Text = dataReader("Nationality")
            If IsDBNull(dataReader("PassportNo")) Then

                Me.PassportNo.Text = ""

            Else

                Me.PassportNo.Text = dataReader("PassportNo")

            End If

            If IsDBNull(dataReader("ICNo")) Then

                Me.ICNo.Text = ""

            Else

                Me.ICNo.Text = dataReader("ICNo")

            End If

            If IsDBNull(dataReader("IssuingCountry")) Then

                Me.IssuingCountry.Text = ""

            Else

                Me.IssuingCountry.Text = dataReader("IssuingCountry")

            End If

            If IsDBNull(dataReader("ExpiredDate")) Then

                Me.DOB.Text = ""

            Else

                Me.DOB.Text = dataReader("ExpiredDate")

            End If

        End If

        dataReader.Close()
        command.Parameters.Clear()
        connection.Close()

    End Sub

    Protected Sub editbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editbtn.Click

        'If (cmdsearchClicked = 1) Then

        Me.Nationality.Enabled = True
        Me.PassportNo.Enabled = True
        Me.ICNo.Enabled = True
        Me.IssuingCountry.Enabled = True
        Me.DOB.Enabled = True
        Me.Name.Enabled = True
        Me.NationalitySearch.Enabled = False
        Me.NameSearch.Enabled = False

        cmdsearchClicked = 2

        'End If

    End Sub

    Protected Sub savebtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles savebtn.Click

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        connection.Open()

        'If (cmdbtnClicked = 1) Then

        strSQL = "INSERT INTO dbo.PassengerPassport (PassportOwner, PassportNo, IssuingCountry, ExpiredDate) VALUES (@PassportOwner, @PassportNo, @IssuingCountry, @ExpiredDate)" &
                    "UPDATE dbo.Passenger SET PassportNo = @PassportNo WHERE Name = @Name"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@Name", Me.Name.Text)
        command.Parameters.AddWithValue("@PassportOwner", Me.Name.Text.ToUpper)
        command.Parameters.AddWithValue("@PassportNo", Me.PassportNo.Text)
        command.Parameters.AddWithValue("@IssuingCountry", Me.IssuingCountry.Text)
        command.Parameters.AddWithValue("@ExpiredDate", Me.DOB.Text)
        dataReader = command.ExecuteReader
        dataReader.Close()
        command.Parameters.Clear()
        MsgBox("Saved Successfully")
        connection.Close()
        Call ResetState()
        Call ResetState1()

        'ElseIf (cmdbtnClicked = 2) Then

        'strSQL = "UPDATE dbo.PassengerPassport SET PassportOwner = @PassportOwner, PassportNo = @PassportNo, IssuingCountry = @IssuingCountry, ExpiredDate = @ExpiredDate, WHERE Name = @PassengerName" &
        '        "UPDATE dbo.Passenger SET PassportNo = @PassportNo WHERE Name = @PassengerName"
        'command = New SqlCommand(strSQL, connection)
        'command.Parameters.AddWithValue("@PassengerName", Me.NameSearch.Text)
        'command.Parameters.AddWithValue("@PassportOwner", Me.Name.Text)
        'command.Parameters.AddWithValue("@PassportNo", Me.PassportNo.Text)
        'command.Parameters.AddWithValue("@IssuingCountry", Me.IssuingCountry.Text)
        'command.Parameters.AddWithValue("@ExpiredDate", Me.DOB.Text)
        'dataReader = command.ExecuteReader
        'dataReader.Close()
        'command.Parameters.Clear()
        'Me.NationalitySearch.Items.Clear()
        'Me.NameSearch.Items.Clear()
        'MsgBox("Edited Successfully")
        'connection.Close()
        'Call ResetState()
        'Call ResetState1()


        'End If

    End Sub

    Protected Sub deletebtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deletebtn.Click

        strCON = "Data Source=192.9.200.114;Initial Catalog=FlightScheduling;User ID=sa;Password=fRANKY1969"
        connection = New SqlConnection(strCON)
        connection.Open()

        strSQL = "DELETE FROM dbo.PassengerPassport WHERE PassportOwner = @SearchName"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@SearchName", Me.NameSearch.Text)
        dataReader = command.ExecuteReader()
        dataReader.Close()
        command.Parameters.Clear()

        strSQL = "UPDATE dbo.Passenger SET PassportNo = @PassportNo WHERE Nationality = @Nationality AND Name = @SearchName"
        command = New SqlCommand(strSQL, connection)
        command.Parameters.AddWithValue("@PasspotNo", "")
        command.Parameters.AddWithValue("@Nationality", Me.Nationality.Text)
        command.Parameters.AddWithValue("@SearchName", Me.NameSearch.Text)
        dataReader = command.ExecuteReader()
        dataReader.Close()
        command.Parameters.Clear()


        Me.NationalitySearch.Items.Clear()
        Me.NameSearch.Items.Clear()
        MsgBox("Deleted successfully")
        connection.Close()
        Call ResetState()
        Call ResetState1()

    End Sub

End Class
