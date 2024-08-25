Imports System.Data.SqlClient

Public Class ClientForm
    Private Const ConnectionString As String = "Server=_SABER_X\SQLEXPRESS;Database=hostvclient;Integrated Security=True;"

    Private Sub ClientForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDropboxItems()
    End Sub

    Private Sub LoadDropboxItems()
        Using connection As New SqlConnection(ConnectionString)
            Dim query As String = "SELECT ItemID, ItemName, Amount, Status, BoughtBy FROM Dropbox WHERE Status IS NULL"
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
                Dim updateQuery As String = "UPDATE Dropbox SET Status = 'Bought', BoughtBy = @BoughtBy WHERE ItemID = @ItemID AND Status IS NULL"
                Using updateCommand As New SqlCommand(updateQuery, connection, transaction)
                    updateCommand.Parameters.AddWithValue("@BoughtBy", username)
                    updateCommand.Parameters.AddWithValue("@ItemID", itemId)
                    Dim rowsAffected As Integer = updateCommand.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        Dim insertQuery As String = "INSERT INTO UserProfile (UserID, ItemID, Amount) VALUES (@UserID, @ItemID, 1)"
                        Using insertCommand As New SqlCommand(insertQuery, connection, transaction)
                            insertCommand.Parameters.AddWithValue("@UserID", GetCurrentUserId())
                            insertCommand.Parameters.AddWithValue("@ItemID", itemId)
                            insertCommand.ExecuteNonQuery()
                        End Using

                        transaction.Commit()
                        success = True
                    Else
                        transaction.Rollback()
                        MessageBox.Show("Item not found, already bought, or status is not null.")
                    End If
                End Using
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using

        Return success
    End Function

    Private Function GetCurrentUserId() As Integer
        Return 1
    End Function
End Class
