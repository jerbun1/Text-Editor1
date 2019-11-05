Option Strict On
Imports System.IO
Public Class frmTextEditor


    Private Sub OpenToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim OpenFileDialog1 = New OpenFileDialog()

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Me.Text = "Title"
                Dim Reader As New StreamReader(OpenFileDialog1.FileName)
                txtText.Text = Reader.ReadToEnd
                Reader.Close()
            Catch ex As Exception
                Throw New ApplicationException(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub mnuSaveAs_Click(sender As Object, e As EventArgs) Handles mnuSaveAs.Click
        Dim SaveFileDialog1 = New SaveFileDialog
        SaveFileDialog1.Filter = "TXT Files (*.txt)|.txt"

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(txtText.Text, SaveFileDialog1.FileName, False)
        End If


    End Sub

    Private Sub mnuClose_Click(sender As Object, e As EventArgs) Handles mnuClose.Click
        Application.Exit()
    End Sub

    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        Dim OpenFileDialog1 = New OpenFileDialog()
        Dim Save As New SaveFileDialog
        Dim myWriter As System.IO.StreamWriter
        Save.Filter = "Text (*.txt)|*.txt|HTML (*.html*)|*.html|PHP (*.php*)|*.php*|All Files (*.*)|*>*"
        Save.CheckPathExists = True
        Save.Title = "Save File"
        Save.ShowDialog(Me)
        Try
            myWriter = System.IO.File.AppendText(Save.FileName)
            myWriter.Write(txtText.Text)
            myWriter.Flush()
            myWriter.Close()
        Catch ex As Exception
            Throw ex
        End Try

        '* The line of code below wasnt working im my code dont really know why
        ''My.Computer.FileSystem.WriteAllText(OpenFileDialog1.FileName, txtText.Text, False)



    End Sub

    Private Sub mnuCopy_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        txtText.Copy()

    End Sub

    Private Sub mnuCut_Click(sender As Object, e As EventArgs) Handles mnuCut.Click
        txtText.Cut()
    End Sub

    Private Sub mnuPaste_Click(sender As Object, e As EventArgs) Handles mnuPaste.Click
        txtText.Paste()
    End Sub

    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        txtText.Clear()
    End Sub
End Class
