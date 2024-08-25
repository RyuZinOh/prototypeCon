Imports System.Data.SqlClient

Public Class userlogin
    Public Shared CurrentUsername As String

    Private Const ConnectionString As String = "Server=_SABER_X\SQLEXPRESS;Database=hostvclient;Integrated Security=True;"

    Private Sub loginas_Click(sender As Object, e As EventArgs) Handles loginas.Click
        Dim username As String = usernames.Text
        Dim password As String = passwords.Text
        Dim role As String = AuthenticateUser(username, password)

        If role IsNot Nothing Then
            CurrentUsername = username
            MessageBox.Show("Login successful as " & role)
            If role = "admin" Then
                Dim adminForm As New AdminForm()
                adminForm.Show()
                Me.Hide()
            ElseIf role = "user" Then
                Dim clientForm As New ClientForm()
                clientForm.Show()
                Me.Hide()
            End If
        Else
            MessageBox.Show("Invalid username or password")
        End If
    End Sub

    Private Function AuthenticateUser(username As String, password As String) As String
        Dim role As String = Nothing

        Using connection As New SqlConnection(ConnectionString)
            Dim query As String = "SELECT role FROM Users WHERE username = @username AND password = @password"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@username", username)
                command.Parameters.AddWithValue("@password", password)

                connection.Open()
                Dim result = command.ExecuteScalar()
                If result IsNot Nothing Then
                    role = result.ToString()
                End If
            End Using
        End Using

        Return role
    End Function
End Class
