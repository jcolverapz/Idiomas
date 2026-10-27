Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports RichTextBoxEx
Imports System.IO
'Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop

Public Class FrmNewDocument
    Public Adjunto As String = ""
    Public Id As Integer
    Public archivo As String
    Private Sub FrmNewDocument_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        txtId.Text = Id
        txtArchivo.Text = archivo

    End Sub
      
    Private Sub cmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click
        Dim Tipo As Integer
        Dim resp As Boolean
        Dim param As String
        Dim Id As Integer
        ' Dim frm As New frmItems
        Dim UsuarioAbrio As String = ""
        Dim UsuarioAbrioId As String = ""
        Dim fecha As Date
        Dim hora As DateTime
        Dim TicketId As Integer
      
        Dim carpeta As String = ""
 
        fecha = Format(Now, "dd/MM/yyyy")
        hora = Now

        Dim archivo As String = ""
       

        carpeta = "C:\Legacy\Ingles\Lectura\"

        archivo = Trim(txtArchivo.Text)

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer


        sqlstring = "Insert into Tbl_Documents (Doc_Name, Doc_Location)"
        sqlstring = sqlstring & " Values ('" & archivo & "',  '" & carpeta & "')"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()



        Try
            i = _comando.ExecuteNonQuery

            If i > 0 Then
                MsgBox("se guardo")
                MessageBox.Show("Saved successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MsgBox("No se guardo")
            End If

        Catch ex As Exception

        End Try


        If resp = True Then



            '    lstModificaciones.Items.Clear()
            '    maxIdModificaciones = 1
        End If

        _comando.Connection.Close()

        Me.Close()

        ' Dim band As Boolean
        '  Dim ItemTicket As New clsTicket
        '  UsuarioId = Me.cboSubmittedby.SelectedItem
        ' Determine whether the directory exists.
        ' If Directory.Exists(carpeta) Then
        ' Console.WriteLine("That path exists already.")
        ' Return
        ' Else

        ' Try to create the directory.
        'Dim di As DirectoryInfo = Directory.CreateDirectory(carpeta)


        ' End If

        ' pnAdvertencia.Visible = False

        'Band = Funciones.ValText("Short Description", .Text)
        'If band = False Then
        '    pnAdvertencia.Visible = True
        '    lblRequired.Text = "Short Description"
        '    Exit Sub
        'End If

        'band = Funciones.ValText("Location", cboUbicaciones.Text)
        'If band = False Then
        '    pnAdvertencia.Visible = True
        '    lblRequired.Text = "Location"
        '    Exit Sub

        'End If

        ' Try
        ' Funciones.ValText("Submitted by", cboSubmittedby.Text)
        'If band = False Then
        '    pnAdvertencia.Visible = True
        '    lblRequired.Text = "Submitted by"
        '    Exit Sub
        'End If

        'UsuarioAbrioId = cboSubmittedby.Items(cboSubmittedby.SelectedIndex).ItemData()
        'UsuarioAbrio = cboSubmittedby.Text
        'Catch ex As Exception
        '    pnAdvertencia.Visible = True
        '    lblRequired.Text = "Submitted by"
        '    Exit Sub
    End Sub
      
    Private Sub CmdAdjuntar_Click(sender As System.Object, e As System.EventArgs) Handles CmdAdjuntar.Click
        'MsgBox("hola")
        Dim OpenFile As New OpenFileDialog()
        Dim carpeta As String = ""
        Dim NombreArchivo As String = ""
        Dim archivo As String = ""

        If OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            Adjunto = OpenFile.FileName
            archivo = Dir(OpenFile.FileName)

            Dim fi As IO.FileInfo = New IO.FileInfo(OpenFile.FileName)
            Dim size As Integer = fi.Length
            ' Dim dormat As String = fi.Extension
            ' Console.WriteLine("File Size in Bytes:{0}", size)
            ' Console.ReadLine()
            ' Label9.Text = (size / 1024) & " KB" ' lbl_size.text = fi.Length
            Try
                ' pbAttach.Image = Image.FromFile(OpenFile.FileName)

            Catch ex As Exception
                'pbAttach.Image = ImageList1.Images(2)

            End Try
            'pnMain.Visible = True

            Try
                'lblFile.Text = Mid(archivo, 1, 20) & System.IO.Path.GetExtension(OpenFile.FileName)
                'lblFile.Text = Mid(archivo, 1, 20) '& System.IO.Path.GetExtension(OpenFile.FileName)
                'lblSize.Text = Int(size / 1024) & " KB"
                txtArchivo.Text = archivo


            Catch ex As Exception

            End Try

            ' pnFileAttachment.Visible = True

            'Me.txtArchivo.Text = Dir(OpenFile.FileName)
        End If


        Dim adjuntopath As String = ""

        Dim ruta As String = ""
        ruta = "C:\Legacy\Ingles\Lectura\"
        If Trim(Adjunto) <> "" Then

            Try


                archivo = Dir(Adjunto)
                IO.File.Copy(Adjunto, ruta & archivo)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Dim frm As frmDocuments = CType(Owner, frmDocuments)

        frm.cargarDatos()
        frm.Show()

        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

        End Try
       


        
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim filename As String

        Try
             
            Dim resp As Integer
            Dim RutaArchivo As String
            Dim RutaArchivoWord As String

            'ruta = "C:\Users\jolvera.SSWTECHNOLOGIES\OneDrive - SSW Holding Company, LLC\Documents\_ingles\Temas\"
            ruta = "C:\Legacy\Ingles\Lectura"
            ' resp = MsgBox("No existe el archivo?" & vbCrLf & "¿ Crear Nuevo ?", vbOKCancel + vbQuestion)
            If resp = 6 Then
            End If

            Dim carpeta As String = ""
            Dim archivo As String

            Dim titulo As String
            titulo = ""
            Try

                archivo = Trim(txtArchivo.Text)
              
                RutaArchivo = ruta & "\" & archivo & ".doc"

                Dim oWord As Word.Application
                Dim oDoc As Word.Document

                'archivo = carpeta & "\" & titulo & ".doc"

                ' Iniciar Word y crear un nuevo documento
                oWord = New Word.Application()
                oDoc = oWord.Documents.Add()

                oDoc.Content.Text = "texto:  " & vbCrLf & "Titulo:  "  ' Añadir texto al documento
                With oDoc.PageSetup
                    .TopMargin = 20   ' 1 inch top margin
                    .BottomMargin = 20 ' 1 inch bottom margin
                    .LeftMargin = 20 ' 1.25 inch left margin
                    .RightMargin = 20 ' 1.25 inch right margin
                End With

                 
                oDoc.SaveAs(RutaArchivo) ' Guardar el documento en una ruta específica
                 
                ' Cerrar el documento y salir de Word
                oDoc.Close()
                oWord.Quit()
                'Dim objWord As Object

                'resp = MsgBox("¿Crear archivo?", MsgBoxStyle.OkCancel)

                '    If resp = 1 Then

                '        objWord = CreateObject("Word.Application")

                '        objWord.Documents.Add()


                '    objWord.ActiveDocument.Characters.Last.Select()  '// Line 1
                '    objWord.Selection.Collapse()                     '// Line 2
                '    objWord.Selection.TypeText(filename)


                'objWord.Text = "Complementaria"
                'objWord.AppendText()
                '    'objWord.Font = New Font("arial", 12, FontStyle.Bold)
                '  g.DrawString("AB", New Font("Segoe UI", 10, FontStyle.Bold), arrayColorPen(c), rect1, stringFormat)
                ' Dim objWriter As New System.IO.StreamWriter("Complementaria", False)
                'objWriter.WriteLine(TxtFile.ToString)
                'objWriter.Close()

                ' objDoc = objWord.Documents.Add
                'Insert some text in document
                ' Dim objPara As Word.Paragraph
                'objPara = objWord.Content.Paragraphs.Add
                'objPara.Range.Text = "Complementaria"
                '   objPara.Range.Font.Bold = True
                '  objPara.Format.SpaceAfter = 30
                'objPara.Range.InsertParagraphAfter()
                 

                ' objWord.ActiveDocument.SaveAs(filename:="" & RutaArchivo)
                ' 'objWord.quit()
                'objWord = Nothing
                'Exit Sub


                'objWord.ActiveDocument.ActiveWindow.View.Zoom.Percentage = 150
                'objWord.ActiveDocument.ShowGrammaticalErrors = False
                'objWord.ActiveDocument.ShowSpellingErrors = False
                'objWord.Visible = True




            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

  
        Catch ex As Exception

        End Try

        
    End Sub

    Private Sub CrearArchivo()
        Dim resp As Integer
        Dim param As String
        Dim Id As Integer

        Dim UsuarioAbrio As String = ""
        Dim UsuarioAbrioId As String = ""
        Dim fecha As Date
        Dim hora As DateTime
        Dim TicketId As Integer
        ' Dim band As Boolean

        '  UsuarioId = Me.cboSubmittedby.SelectedItem
        Dim carpeta As String = ""
        Dim archivo As String

        Dim Tipo As String

        'Band = Funciones.ValText("Titulo", txtTitulo.Text)
        'If band = False Then

        '    Exit Sub
        'End If

        resp = MsgBox("Add Report?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)

        If resp <> 6 Then
            Exit Sub
        End If

        Dim titulo As String
        ' titulo = Trim(txtTitulo.Text)
        'Save
        Dim Apl As String
        ' Apl = cboSistema.Items(cboSistema.SelectedIndex).ItemData()
        ' Apl = Trim(cboSistema.Text)



        Dim Rep_Id As Integer

        ' Dim rep As New clsReporte
        Dim DatosTask As New DataTable

        Dim i, n, max As Integer

        'Tipo = cboTipo.Text

        'rep.No = 1
        'rep.descripcion = txtTitulo.Text
        'rep.Status = "S"
        'rep.Apl = Apl
        'rep.tipo = Tipo
        'Dim folderName As String = ""


        'Rep_Id = CapaLogica.NuevoReporte(rep)

        If Rep_Id > 0 Then
        End If

        Dim di As DirectoryInfo
        'If var.Planta = "Planta SLP" Then
        '    ' carpeta = "\\10.18.164.207\Adjuntos$\Reportes_Tickets\" & Rep_Id & "\"
        'Else
        '    ' carpeta = "\\10.18.172.30\Adjuntos\Reportes_Tickets\" & Rep_Id & "\"
        '    carpeta = "C:\Legacy\Configuraciones\" & Rep_Id
        '    di = Directory.CreateDirectory(carpeta)

        'End If


        Dim oWord As Word.Application
        Dim oDoc As Word.Document
        archivo = carpeta & "\" & titulo & "." & Tipo

        ' Iniciar Word y crear un nuevo documento
        oWord = New Word.Application()
        oDoc = oWord.Documents.Add()


        oDoc.Content.Text = "Reporte No:  " & Rep_Id & vbCrLf & "Titulo:  " & titulo ' Añadir texto al documento
        With oDoc.PageSetup
            .TopMargin = 20   ' 1 inch top margin
            .BottomMargin = 20 ' 1 inch bottom margin
            .LeftMargin = 20 ' 1.25 inch left margin
            .RightMargin = 20 ' 1.25 inch right margin
        End With
        ' Guardar el documento en una ruta específica


        If Tipo = "rtf" Then
            oDoc.SaveAs2(carpeta & "\" & titulo, Word.WdSaveFormat.wdFormatRTF)
        Else
            oDoc.SaveAs(carpeta & "\" & titulo & "." & Tipo)

        End If
        ' Cerrar el documento y salir de Word
        oDoc.Close()
        oWord.Quit()


        ' Liberar los objetos
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord)
        oDoc = Nothing
        oWord = Nothing

        MessageBox.Show("Archivo Word creado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Try

            archivo = carpeta & "\" & titulo & "." & Tipo

            If System.IO.File.Exists(carpeta & "\" & titulo & "." & Tipo) Then
                Process.Start("explorer.exe", archivo)
            Else
                MsgBox("no file", vbInformation)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Close()
        Me.Dispose()


    End Sub
End Class