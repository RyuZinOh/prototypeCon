Imports System.Data.SqlClient

Public Class AdminForm
    Private Const ConnectionString As String = "Server=_SABER_X\SQLEXPRESS;Database=hostvclient;Integrated Security=True;"

    Private Sub placestuff_Click(sender As Object, e As EventArgs) Handles placestuff.Click
        Dim itemName As String = stuff.Text
        Dim amount As Integer

        If Integer.TryParse(nrs.Text, amount) Then
            If AddItemToDropbox(itemName, amount) Then
                MessageBox.Show("Item added successfully.")
                stuff.Clear()
                nrs.Clear()
            Else
                MessageBox.Show("Error adding item.")
            End If
        Else
            MessageBox.Show("Please enter a valid amount.")
        End If
    End Sub

    Private Function AddItemToDropbox(itemName As String, amount As Integer) As Boolean
        Dim success As Boolean = False

        Using connection As New SqlConnection(ConnectionString)
            Dim query As String = "INSERT INTO Dropbox (ItemName, Amount, Status, BoughtBy) VALUES (@ItemName, @Amount, NULL, NULL)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ItemName", itemName)
                command.Parameters.AddWithValue("@Amount", amount)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    success = True
                Catch ex As Exception
                    MessageBox.Show("An error occurred: " & ex.Message)
                End Try
            End Using
        End Using

        Return success
    End Function
End Class
