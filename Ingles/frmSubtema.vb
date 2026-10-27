Public Class frmSubtema
    Public filename As String = ""
    Public SubtemaId As Integer
    Public carpeta As String = ""
    Public ruta As String = ""
    Public archivo As String = ""

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub

   

    Private Sub frmSubtema_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        txtId.Text = SubtemaId
        CargarDatos(filename)

    End Sub
    Public Sub CargarDatos(filename)
        'Dim filename As String




        filename = ruta & carpeta & "\" & archivo & ".rtf"
        Try
            ' RichTextBoxEx1.rtb.LoadFile("C:\legacy\Rtf\3748.rtf")
            'RichTextBoxEx1.rtb.LoadFile("C:\legacy\Rtf\Preposiciones.rtf")

            ' RichTextBoxEx1.filename = filename
            ' RichTextBoxEx1.rtb.LoadFile(filename)

        Catch ex As Exception

        End Try

        ' Determine whether the directory exists.
        ' If Directory.Exists(carpeta) Then
        'If System.IO.File.Exists(filename) Then

        'End If

        ''End If
        '' Console.WriteLine("That path exists already.")
        '' Return
        ''  RichTextBoxEx.RichTextBoxEx.CargarDatos(Id)

        'Else

        'If Not IsDBNull(dt.Rows(0).Item(21)) Then
        '    descripcion = dt.Rows(0).Item(21)
        'End If
        'RichTextBoxEx1.rtb.Text = descripcion
        '' Try to create the directory.
    End Sub

    Private Sub CmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click

        filename = ruta & carpeta & "\" & archivo & ".rtf"

        Try
            'RichTextBoxEx1.rtb.SaveFile(filename)
            Me.Close()
            ' MsgBox("Saved")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim frm As New frmNewOracion

        frm.subtemaId = SubtemaId
        frm.Show()
         

    End Sub

    Private Sub CmdVocabulario_Click(sender As System.Object, e As System.EventArgs) Handles CmdVocabulario.Click
        FrmVocabulario.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FrmOraciones.Show()

    End Sub
End Class