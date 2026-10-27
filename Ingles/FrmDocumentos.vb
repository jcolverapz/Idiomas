Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
Imports System.Windows.Forms

Public Class FrmDocumentos

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim documentPath As String
        'Documents.Open(FileName:="C:\MyFiles\MyDoc.docx", ReadOnly:=True)
        ' documentPath = "C:\Legacy\MyDoc.docx"
        'Process.Start(documentPath)

        Dim objWord As Word.Application
        objWord = New Word.Application

        objWord.Documents.Open("C:\Legacy\MyDoc.docx")
        objWord.Visible = True
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        CreateWordDocument()
    End Sub
    Private Sub CreateWordDocument()
        Dim objWord As Word.Application
        Dim objDoc As Word.Document

        objWord = CreateObject("Word.Application")
        objWord.Visible = True
        objDoc = objWord.Documents.Add
        'Insert some text in document
        Dim objPara As Word.Paragraph
        objPara = objDoc.Content.Paragraphs.Add
        objPara.Range.Text = "Welcome to Author Code"
        objPara.Range.Font.Bold = True
        objPara.Format.SpaceAfter = 30
        objPara.Range.InsertParagraphAfter()



    End Sub

    Private Sub FrmDocumentos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'InglesDataSet.Subtemas' Puede moverla o quitarla según sea necesario.
        ' Me.SubtemasTableAdapter.Fill(Me.InglesDataSet.Subtemas)
        'TODO: esta línea de código carga datos en la tabla 'InglesDataSet.Subtemas' Puede moverla o quitarla según sea necesario.
        'Me.SubtemasTableAdapter.Fill(Me.InglesDataSet.Subtemas)
        Me.CheckBox1.Appearance = System.Windows.Forms.Appearance.Button
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Declara la variable.
        Dim objWD As Word.Application
        'Crea una nueva instancia de Word
        objWD = CreateObject("Word.Application")
        'Agrega un nuevo documento en blanco
        objWD.Documents.Add()
        'Agrega Texto.
        objWD.Selection.TypeText("Hola mundo")
        'Guarda el documento
        objWD.ActiveDocument.SaveAs(FileName:="cotizacion.doc")
        'Declaramos la variable para abrir el documento y se le asigna el valor al objeto y especificamos el nombre del documento a abrir
        Dim archivoWord = objWD.Documents.Open(FileName:="cotizacion.doc")
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim MyDialog As New ColorDialog()
        ' Keeps the user from selecting a custom color.
        MyDialog.AllowFullOpen = False
        ' Allows the user to get help. (The default is false.)
        MyDialog.ShowHelp = True
        ' Sets the initial color select to the current text color,
        MyDialog.Color = txtDocumento.ForeColor

        ' Update the text box color if the user clicks OK 
        If (MyDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            txtDocumento.ForeColor = MyDialog.Color
        End If

        If Me.CheckBox1.Checked Then

            'Me.txtDocumento.SelectedText = Me.txtDocumento.SelectedText.Format
            '  txtDocumento.SelectionFont = New Font("Tahoma", 12, FontStyle.Bold)
            txtDocumento.SelectionColor = System.Drawing.Color.Red
        Else
            'txtDocumento.SelectionColor = System.Drawing.Color.Black

        End If

    End Sub
End Class