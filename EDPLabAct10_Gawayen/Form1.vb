Imports System.IO
Imports System.Linq
Public Class Form1

    Private numbers As New List(Of Integer)
    Private Sub btnWrite_Click(sender As Object, e As EventArgs) Handles btnWrite.Click
        Try
            Dim number As Integer = Convert.ToInt32(NumericUpDown1.Value)
            numbers.Add(number)
            ListBox1.Items.Add(number)
            MessageBox.Show("Number added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error, Please enter a valid integer", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        Try
            Using writer As New StreamWriter("numbers.txt")
                For Each n In numbers
                    writer.WriteLine(n)
                Next
            End Using
            MessageBox.Show("Numbers saved to numbers.txt")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error saving file: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click
        Dim numbers As New List(Of Integer)
        Try
            If File.Exists("numbers.txt") Then
                Using reader As New StreamReader("numbers.txt")
                    While Not reader.EndOfStream
                        Dim line = reader.ReadLine()
                        Dim num As Integer
                        If Integer.TryParse(line, num) Then
                            numbers.Add(num)
                        End If
                    End While
                End Using

                Dim sortedNumbers = numbers.OrderBy(Function(x) x)
                ListBox1.Items.Clear()
                For Each n In sortedNumbers
                    ListBox1.Items.Add(n)
                Next
            Else
                MessageBox.Show("numbers.txt not found. Save numbers first.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error reading or sorting numbers: " & ex.Message)
        End Try
    End Sub
End Class
