Imports System.Data
Imports Entidades
Imports Negocios
 
Imports System.Data.Sql
Imports System.Data.SqlClient

Imports System.IO
Imports SpeechLib
Imports System.Speech.Synthesis

Imports System.Speech.AudioFormat
'Imports System.Data.OleDb
'Imports Microsoft.Office.Interop.Word
'Imports Microsoft.Office.Interop

Imports WMPLib

Public Class frmDocuments
    Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer

    Private Sub frmDocuments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        cargarDatos()

        dgvDocuments.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvDocuments.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '  dgvOraciones.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' dgvOraciones.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvOraciones.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ''dgvOraciones.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        '' dgvOraciones.Columns(0).Visible = False
        ''dgvOraciones.Columns(1).Visible = False

        '' dgvOraciones.Columns(3).Visible = False
        ''  dgvOraciones.Columns(4).Visible = False
        'dgvOraciones.Columns(5).Visible = False
        'dgvOraciones.Columns(6).Visible = False



    End Sub
     
    Public Sub cargarDatos()
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        'sqlstring = "select * from  SubTemas "
        sqlstring = "select * from  Tbl_Documents "
        'sqlstring = sqlstring & " ORDER By Grupo ASC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            'Me.cboGrupo.DataSource = dt
            'Me.cboGrupo.ValueMember = "Id"
            'Me.cboGrupo.DisplayMember = "Grupo"
            dgvDocuments.DataSource = dt

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        _comando.Connection.Close()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frm As New FrmNewDocument

        AddOwnedForm(frm)

        'frm.Id = Id
        'frm.lbltitulo.Text = dgvOraciones.CurrentRow.Cells(1).Value.ToString()
        ' frm.CargarConversation(Id)
        frm.ShowDialog()

        'FrmNewDocument.ShowDialog()
        ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        'Id = dgvOraciones.CurrentRow.Cells(0).Value.ToString()
        ' TipoTicket = dgvOraciones.CurrentRow.Cells(11).Value.ToString()


        'If TipoTicket = "INC" Then
        '    ' Dim frm As New frmItemTicket
        '    frm.lblTipo.Text = "Incident Item"
        '    ' frm.CargarDatos(TicketId)
        '    'frm.ShowDialog()
        'Else
        '    ' Dim frm As New frmItemRequest
        '    ' AddOwnedForm(frm)
        '    frm.lblTipo.Text = "Request Item"
        '    '  frm.CargarDatos(TicketId)
        'End If



    End Sub

    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub dgvDocuments_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvDocuments.DoubleClick
        Dim Id As Integer
        Dim TipoTicket As String
        'Dim frm As New FrmConversation
        Dim filename As String = ""
        Dim RutaArchivo As String
        '  Dim RutaArchivo As String
        ' Dim RutaArchivoWord As String
        ' AddOwnedForm(frm)
        ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        Id = dgvDocuments.CurrentRow.Cells(0).Value.ToString()
        filename = dgvDocuments.CurrentRow.Cells(1).Value.ToString()

        ' filename = Trim(txtArchivo.Text)
        'filename = "test"
        'RutaArchivo = ruta & "\" & filename & ".rtf"

        RutaArchivo = "C:\Legacy\Ingles\Lectura\" & filename & ".doc"

        ' TipoTicket = dgvOraciones.CurrentRow.Cells(11).Value.ToString()
        ' Dim filename As String = ""
        ' filename = 
        'rtb.SaveFile("C:\Legacy\Rtf\" & filename & ".rtf")
        ' Process.Start("explorer.exe", "C:\Legacy\Rtf\" & filename & ".rtf")
        '  MsgBox("Saved")
        'Status = "Saved"
        ' rtb.SaveFile("C:\Legacy\Rtf\" & filename & ".rtf")
        'MsgBox("Saved")

        Try

            'Process.Start("explorer.exe", RutaArchivo)

            Dim frm As New frmPlayer
            'frm.texto = filename
            frm.filename = filename
            frm.Show()


        Catch ex As Exception

        End Try
        Dim resp As Integer
        
        'ruta = "C:\Users\jolvera.SSWTECHNOLOGIES\OneDrive - SSW Holding Company, LLC\Documents\_ingles\Temas\"
        'ruta = "C:\Legacy\Ingles\Lectura\"
        ' resp = MsgBox("No existe el archivo?" & vbCrLf & "¿ Crear Nuevo ?", vbOKCancel + vbQuestion)
        ' If resp = 6 Then
        ' End If


        'Dim objWord As Object

        'resp = MsgBox("¿Crear archivo?", MsgBoxStyle.OkCancel)

        'If resp = 1 Then

        '    objWord = CreateObject("Word.Application")

        '    objWord.Documents.Add()
        '    'objWord.Documents.Save(filename & ".rtf")
        '    If resp = 6 Then
        '        objWord.ActiveDocument.Characters.Last.Select()  '// Line 1
        '        objWord.Selection.Collapse()                     '// Line 2
        '        objWord.Selection.TypeText(filename)


        '    End If

        '    objWord.ActiveDocument.SaveAs(filename:="" & RutaArchivo)
        '    'objWord.quit()
        '    'objWord = Nothing
        '    Exit Sub

        'Else
        '    Exit Sub

        'End If

        'objWord.ActiveDocument.ActiveWindow.View.Zoom.Percentage = 150
        'objWord.ActiveDocument.ShowGrammaticalErrors = False
        'objWord.ActiveDocument.ShowSpellingErrors = False
        'objWord.Visible = True




    End Sub

    Private Sub cmdEditar_Click(sender As System.Object, e As System.EventArgs) Handles cmdEditar.Click
        Dim frm As New FrmNewDocument
        Dim id As Integer
        Dim archivo As String

        AddOwnedForm(frm)
        id = dgvDocuments.CurrentRow.Cells(0).Value.ToString()
        archivo = dgvDocuments.CurrentRow.Cells(1).Value.ToString()

        frm.Id = id
        frm.archivo = archivo
        frm.Show()

    End Sub

    Private Sub cmdPlay_Click(sender As System.Object, e As System.EventArgs) Handles cmdPlay.Click
        If cmdPlay.Text = "Play" Then
            'Play
            cmdPlay.Text = "Stop"
            cmdPlay.Refresh()

            'C:\legacy\audios
            'Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer
            Dim ruta As String
            'ruta = "C:\legacy\Audios\spirit.mp3"
            ruta = "C:\legacy\Audios\" & dgvDocuments.CurrentRow.Cells(1).Value.ToString()

            Dim SongLocation = Path.Combine(Application.StartupPath, ruta & ".mp3")
            Player.URL = SongLocation
            Player.controls.play()
        Else
            'Stop
            cmdPlay.Text = "Play"

            Player.controls.stop()

        End If


    End Sub

    Private Sub cmdStop_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub dgvDocuments_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocuments.CellContentClick

    End Sub
End Class