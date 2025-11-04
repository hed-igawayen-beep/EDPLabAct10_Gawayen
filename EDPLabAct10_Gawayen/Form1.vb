Imports System.IO
Public Class Form1

    Dim filePath As String = "numbers.txt"
    Private Sub btnWrite_Click(sender As Object, e As EventArgs) Handles btnWrite.Click
        Try
            Using writer As New StreamWriter(filePath, True) 'True to append
                writer.WriteLine("You added a number")
            End Using

            MessageBox.Show("Number added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        'Using reader As New StreamReader(filePath)
        '    Dim content As String = reader.ReadToEnd()
        '    MessageBox.Show("Number content" + content)
        'End Using
        ListBox1.Items.Clear()
        Using reader As New StreamReader(filePath)
            Dim line As Integer
            line = reader.ReadLine()
            While (line IsNot Nothing)
                ListBox1.Items.Add(line)
                line = reader.ReadLine()
            End While
        End Using
    End Sub
End Class
