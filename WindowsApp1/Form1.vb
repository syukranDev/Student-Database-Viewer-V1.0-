Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ContactsTableDataSet.studentData' table. You can move, or remove it, as needed.
        Me.StudentDataTableAdapter.Fill(Me.ContactsTableDataSet.studentData)
        If ComboBox1.Text = Nothing Then
            Try
                StudentDataBindingSource.AddNew()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FirstNameTextBox.Text = Nothing Then
            FirstNameTextBox.Text = "Unknown"
        End If

        If LastNameTextBox.Text = Nothing Then
            LastNameTextBox.Text = "Unknown"
        End If

        If AddressTextBox.Text = Nothing Then
            AddressTextBox.Text = "Unknown"
        End If

        If Phone_NumberTextBox.Text = Nothing Then
            Phone_NumberTextBox.Text = "Unknown"
        End If

        If Email_AdressTextBox.Text = Nothing Then
            Email_AdressTextBox.Text = "Unknown"
        End If

        Try
            Me.Validate()
            Me.StudentDataBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.ContactsTableDataSet)
            MessageBox.Show("The data has been saved!", "Information", MessageBoxButtons.OK)
            StudentDataBindingSource.AddNew()
            FirstNameTextBox.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            StudentDataBindingSource.AddNew()
            FirstNameTextBox.Select()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Select Case MsgBox("Are you sure you want to delete the current contact?", MsgBoxStyle.YesNo, "Are you sure?")
            Case MsgBoxResult.Yes
                Try
                    StudentDataBindingSource.RemoveCurrent()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Case MsgBoxResult.No
                ''nothing
        End Select
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            StudentDataBindingSource.MovePrevious()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            StudentDataBindingSource.MoveNext()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class
