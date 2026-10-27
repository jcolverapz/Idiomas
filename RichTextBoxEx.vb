Imports Entidades
Imports Negocios
Imports System.Data
Imports System.IO

Public Class RichTextBoxEx

    Public Shared carpeta As String = ""
    Public Shared filename As String = ""
    Public Shared Status As String = ""

    Private Sub RichTextBoxEx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Load control        
        rtb.Focus()
        'rtb.LoadFile("C:\Legacy\Rtf\" & filename & ".rtf")

    End Sub

    Public Shared Sub CargarDatos(file)
        ' Dim rtb1 As New RichTextBox

        'RichTextBoxEx.filename = file
        'rtb1.LoadFile("C:\Legacy\Rtf\" & file & ".rtf")
        'rtb.LoadFile("C:\Legacy\Rtf\" & file & ".rtf")

        ' MsgBox("tes")
        ' rtb.load()


    End Sub

    'Public Shared Function CargarDatos(file)
    '    Try
    '        '  rtb.LoadFile("C:\Legacy\Rtf\" & file & ".rtf")

    '    Catch ex As Exception

    '    End Try
    '    Return True

    'End Function
    'Public Shared Function CatalogoEmpleadosIT(deptoIT) As DataTable
    '    ' Return AccesoDatos.CatalogoEmpleadosIT(deptoIT)
    '    Try
    '        ' rtb.LoadFile("C:\Legacy\Rtf\" & file & ".rtf")

    '    Catch ex As Exception

    '    End Try
    'End Function

    ' Spell checking thanks to: http://www.codeproject.com/KB/string/netspell.aspx

    ' Handles when user chooses to delete in spell cehck
    Private Sub SpellChecker_DeletedWord(ByVal sender As Object, ByVal e As NetSpell.SpellChecker.SpellingEventArgs) Handles SpellChecker.DeletedWord
        'save existing selecting
        Dim start As Integer = rtb.SelectionStart
        Dim length As Integer = rtb.SelectionLength

        'select word for this event
        rtb.Select(e.TextIndex, e.Word.Length)

        'delete word
        rtb.SelectedText = ""

        If ((start + length) > rtb.Text.Length) Then
            length = 0
        End If

        'restore selection
        rtb.Select(start, length)

    End Sub

    ' Handles replacing a word from spell checking
    Private Sub SpellChecker_ReplacedWord(ByVal sender As Object, ByVal e As NetSpell.SpellChecker.ReplaceWordEventArgs) Handles SpellChecker.ReplacedWord
        'save existing selecting
        Dim start As Integer = rtb.SelectionStart
        Dim length As Integer = rtb.SelectionLength

        'select word for this event
        rtb.Select(e.TextIndex, e.Word.Length)

        'replace word
        rtb.SelectedText = e.ReplacementWord

        If ((start + length) > rtb.Text.Length) Then
            length = 0
        End If

        'restore selection
        rtb.Select(start, length)
    End Sub

    ' Update buttons when text is selected
    Private Sub rtb_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtb.SelectionChanged
        ' see which buttons should be checked or unchecked

        Try
            'BoldToolStripButton.Checked = rtb.SelectionFont.Bold
            'UnderlineToolStripButton.Checked = rtb.SelectionFont.Underline
            'LeftToolStripButton.Checked = IIf(rtb.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Left, True, False)
            'CenterToolStripButton.Checked = IIf(rtb.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Center, True, False)
            'RightToolStripButton.Checked = IIf(rtb.SelectionAlignment = System.Windows.Forms.HorizontalAlignment.Right, True, False)
            'BulletsToolStripButton.Checked = rtb.SelectionBullet

        Catch ex As Exception

        End Try

        'cmbFontName.Text = rtb.SelectionFont.Name
        'cmbFontSize.Text = rtb.SelectionFont.SizeInPoints

    End Sub

    Private Sub checkBullets()
        If rtb.SelectionBullet = True Then
            '   BulletsToolStripButton.Checked = True
        Else
            'BulletsToolStripButton.Checked = False
        End If
    End Sub

    Private Sub FontToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If FontDlg.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            rtb.SelectionFont = FontDlg.Font
        End If
    End Sub

    Private Sub FontColorToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ColorDlg.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            rtb.SelectionColor = ColorDlg.Color
        End If
    End Sub

    Private Sub BoldToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Switch Bold
        Dim currentFont As System.Drawing.Font = rtb.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle
        If rtb.SelectionFont.Bold = True Then
            newFontStyle = currentFont.Style - Drawing.FontStyle.Bold
        Else
            newFontStyle = currentFont.Style + Drawing.FontStyle.Bold
        End If
        rtb.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

        ' Check/Uncheck Bold button
        ' BoldToolStripButton.Checked = IIf(rtb.SelectionFont.Bold, True, False)
    End Sub

    Private Sub SpellcheckToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SpellChecker.Text = rtb.Text
        SpellChecker.SpellCheck()
    End Sub

    Private Sub UnderlineToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Switch Underline
        Dim currentFont As System.Drawing.Font = rtb.SelectionFont
        Dim newFontStyle As System.Drawing.FontStyle
        If rtb.SelectionFont.Underline = True Then
            newFontStyle = currentFont.Style - Drawing.FontStyle.Underline
        Else
            newFontStyle = currentFont.Style + Drawing.FontStyle.Underline
        End If
        rtb.SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)

        ' Check/Uncheck Underline button
        'UnderlineToolStripButton.Checked = IIf(rtb.SelectionFont.Underline, True, False)
    End Sub

    Private Sub LeftToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rtb.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub CenterToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rtb.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub RightToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rtb.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub BulletsToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rtb.SelectionBullet = Not rtb.SelectionBullet
        ' BulletsToolStripButton.Checked = rtb.SelectionBullet
    End Sub

    Private Sub SaveToolStripButton_Click(sender As System.Object, e As System.EventArgs)
    End Sub

    Private Sub rtb_TextChanged(sender As System.Object, e As System.EventArgs) Handles rtb.TextChanged

    End Sub


    Private Sub OpenToolStripButton_Click(sender As System.Object, e As System.EventArgs)
        ' rtb.SaveFile("C:\Legacy\Rtf\" & filename & ".rtf")
        'MsgBox("Saved")

        ' carpeta & filename & ".doc"
        'If var.Planta = "Planta SLP" Then
        '    carpeta = "\\10.18.164.207\Adjuntos$\Reportes_tickets\" & TicketId & "\"
        'Else
        '    carpeta = "\\10.18.172.30\Adjuntos\Reportes_tickets\" & TicketId & "\"
        'End If

        Try

            ' Determine whether the directory exists.
            If Directory.Exists(carpeta) Then
                ' Console.WriteLine("That path exists already.")
                ' Return
            Else

                ' Try to create the directory.
                Dim di As DirectoryInfo = Directory.CreateDirectory(carpeta)
                '  archivo = Dir(Adjunto)
                ' IO.File.Copy(Adjunto, carpeta & archivo)

            End If

            Process.Start("explorer.exe", carpeta & filename & ".doc")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try




    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs)




    End Sub
End Class
