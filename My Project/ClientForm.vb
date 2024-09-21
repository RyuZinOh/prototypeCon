Imports System.Data.SqlClient

Public Class ClientForm
    Private Const ConnectionString As String = "Data Source=192.168.1.80;Initial Catalog=hostvclient;User ID=SA;Password=MyStrongPass123;"

    Private Sub ClientForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDropboxItems()
    End Sub

    Private Sub LoadDropboxItems()
        Using connection As New SqlConnection(ConnectionString)
            Dim query As String = "SELECT ItemID, ItemName, Amount, Status FROM Dropbox WHERE Status = 'Available'"
            Using adapter As New SqlDataAdapter(query, connection)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgv.DataSource = table
            End Using
        End Using
    End Sub

    Private Sub buystuff_Click(sender As Object, e As EventArgs) Handles buystuff.Click
        Dim selectedItemId As Integer

        If Integer.TryParse(dropid.Text, selectedItemId) Then
            If BuyItem(selectedItemId) Then
                MessageBox.Show("Purchase successful.")
                LoadDropboxItems()
            Else
                MessageBox.Show("Error processing purchase.")
            End If
        Else
            MessageBox.Show("Please enter a valid item ID.")
        End If
    End Sub

    Private Function BuyItem(itemId As Integer) As Boolean
        Dim success As Boolean = False
        Dim username As String = userlogin.CurrentUsername

        Using connection As New SqlConnection(ConnectionString)
            connection.Open()
            Dim transaction As SqlTransaction = connection.BeginTransaction()

            Try
                Dim updateQuery As String = "UPDATE Dropbox SET Status = 'Bought', BoughtBy = @BoughtBy WHERE ItemID = @ItemID AND Status = 'Available'"
                Using updateCommand As New SqlCommand(updateQuery, connection, transaction)
                    updateCommand.Parameters.AddWithValue("@BoughtBy", username)
                    updateCommand.Parameters.AddWithValue("@ItemID", itemId)
                    Dim rowsAffected As Integer = updateCommand.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        Dim insertQuery As String = "INSERT INTO UserProfile (UserID, ItemID, Amount) VALUES (@UserID, @ItemID, 1)"
                        Using insertCommand As New SqlCommand(insertQuery, connection, transaction)
                            insertCommand.Parameters.AddWithValue("@UserID", GetCurrentUserId(username))
                            insertCommand.Parameters.AddWithValue("@ItemID", itemId)
                            insertCommand.ExecuteNonQuery()
                        End Using

                        transaction.Commit()
                        success = True
                    Else
                        MessageBox.Show("Item not found, already bought, or status is not available.")
                    End If
                End Using
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using

        Return success
    End Function

    Private Function GetCurrentUserId(username As String) As Integer
        Dim userId As Integer = 0
        Using connection As New SqlConnection(ConnectionString)
            Dim query As String = "SELECT id FROM Users WHERE username = @username"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@username", username)
                connection.Open()
                Dim result = command.ExecuteScalar()
                If result IsNot Nothing Then
                    userId = Convert.ToInt32(result)
                End If
            End Using
        End Using
        Return userId
    End Function
End Class
