Imports System.Data
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports WMPLib

Imports System.Data.Sql

Imports System.IO
Imports System.Windows.Forms
'Imports Microsoft.Office.Interop.Word
'Imports Microsoft.Office.Interop
Imports System.Diagnostics
Imports System.Text
Imports System.Web.Script.Serialization
Imports System.Text.Json
 
Public Class frmOracionesDialogos
    'Public conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\legacy\Ingles\Ingles.accdb")
    'Public instruccion As New OleDbCommand
    Public contenedor As String
    Public sqlstring As String

    Public Shared IdEnc As Integer
    Public SubtemaId As Integer

    Public consulta As String
    Dim rowcount As Integer
    Public filtro As String
    Public MaxColumna As Integer
    Public Color1 As Color = System.Drawing.Color.FromArgb(253, 239, 202)
    Public Color2 As Color = System.Drawing.Color.FromArgb(128, 94, 14)

    Public Color3 As Color = System.Drawing.Color.FromArgb(209, 235, 222)
    Public Color4 As Color = System.Drawing.Color.FromArgb(31, 92, 60)

    Public Color5 As Color = System.Drawing.Color.FromArgb(207, 218, 223)
    Public Color6 As Color = System.Drawing.Color.FromArgb(19, 49, 57)
    Dim SelectedId As Integer
    Dim dt As New DataTable
    Dim da As New SqlDataAdapter
    Dim _comando As SqlCommand
    Public IdEst As Integer
    Public Estructura As String

    'Public Const MOUSEEVENTF_LEFTDOWN As Integer = &H2
    'Public Const MOUSEEVENTF_LEFTUP As Integer = &H4

    ' Constantes para mouse_event
    Private Const MOUSEEVENTF_MOVE = &H1
    Private Const MOUSEEVENTF_LEFTDOWN = &H2
    Private Const MOUSEEVENTF_LEFTUP = &H4
    'Public Declare Sub mouse_event(ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
    'end sub
    ' Para mover el cursor
    Private Declare Function SetCursorPos Lib "user32" (ByVal x As Integer, ByVal y As Integer) As Boolean
    ' Public Declare Auto Function SetCursorPos Lib "user32.dll" (ByVal x As Integer, ByVal y As Integer) As Boolean
    Private Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
    ' Private Shared Sub mouse_event(ByVal dwFlags As UInteger, ByVal dx As UInteger, ByVal dy As UInteger, ByVal cButtons As UInteger, ByVal dwExtraInfo As UInteger)
    'End Sub
    Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer
    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Public Sub CargarDatos(filtro)
        _comando = MetodosDatos.CrearComando()
        Dim sqlstring As String

        'filtro = " Where Oraciones.Status='S'"
        'If filtro = Nothing Then Exit Sub
        Dim param As String

        param = " Order By ScoreNaturalidad DESC"

        sqlstring = "  SELECT        Id, FrecuenciaUso, Reproduccion, TextoPlano, Traduccion, NivelCEFR, ScoreNaturalidad, ScoreComplejidad,ScoreCEFR, Id_Dialogo"
        sqlstring = sqlstring & " FROM            Oraciones"
        sqlstring = sqlstring & " WHERE  FrecuenciaUso = 0"
        sqlstring = sqlstring & param
 
        dgvOraciones.DataSource = Nothing
        dt.Rows.Clear()

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando
            da.Fill(dt)
            dt.AcceptChanges()

            dgvOraciones.DataSource = dt

            MaxColumna = dgvOraciones.ColumnCount

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        Try
            dgvOraciones.Columns(0).Visible = False ' Id
            dgvOraciones.Columns(1).Width = 50 'FrecuenciaUso
            dgvOraciones.Columns(2).Width = 50 'Reproduccion
            dgvOraciones.Columns(3).Width = 450 ' TextoPlano
            dgvOraciones.Columns(4).Width = 450 ' Traduccion

            dgvOraciones.Columns(5).Width = 70 ' NivelCEFR, , 

            dgvOraciones.Columns(6).Width = 120 'ScoreNaturalidad
            dgvOraciones.Columns(7).Width = 120 'ScoreComplejidad
            dgvOraciones.Columns(8).Width = 120 'ScoreCEFR
            dgvOraciones.Columns(9).Width = 120 'Id_Dialogo

            ',, "

            ' dgvOraciones.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' 
            '  dgvOraciones.Columns(8).Visible = False
            '  dgvOraciones.Columns(9).Visible = False
            '  dgvOraciones.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        Catch ex As Exception

        End Try


        Dim n As Integer
        n = dt.Rows.Count

        txtCuenta.Text = n

        If n = 0 Then Exit Sub


        ' lblCuenta.Text = n

        Try
            dgvOraciones.Rows(SelectedId).Selected = True
            'dgvOraciones.Scroll()
            'dgvOraciones.ScrollIntoView(dgvOraciones.SelectedItem)
            'Me.DGVMateriales.FirstDisplayedScrollingRowIndex = I
            dgvOraciones.FirstDisplayedScrollingRowIndex = SelectedId
        Catch ex As Exception

        End Try

        Dim colCheck As New DataGridViewCheckBoxColumn()
        colCheck.HeaderText = "Seleccionar"
        colCheck.Name = "chkSeleccion"
        colCheck.Width = 60

        dgvOraciones.Columns.Insert(0, colCheck)

        'lsvSugerencia.View = System.Windows.Forms.View.Details
        'lsvSugerencia.LabelEdit = False ' Allow the user to edit item text.
        'lsvSugerencia.AllowColumnReorder = True ' Allow the user to rearrange columns.
        'lsvSugerencia.FullRowSelect = True ' Select the item and subitems when selection is made.
        'lsvSugerencia.GridLines = True ' Display grid lines.

    End Sub
    Public Sub CargarDatosOrdenados(filtro)
        _comando = MetodosDatos.CrearComando()
        Dim sqlstring As String
 
        sqlstring = "  SELECT        Id, TextoPlano, Traduccion, Favorito, ScoreNaturalidad, PalabrasClaveImagen, TemaDetectado, NivelCEFR, OrdenSugerido, Id_Dialogo, similitud "
        sqlstring = sqlstring & " FROM            Oraciones"
        sqlstring = sqlstring & " ORDER BY ScoreNaturalidad ASC"
        

        'sqlstring = "SELECT  Oraciones.Id, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.estatus, Oraciones.GrupoId, "
        ' Oraciones.forma, Oraciones.STL"
        'sqlstring = sqlstring & " FROM            Oraciones RIGHT JOIN"
        'sqlstring = sqlstring & "                Tbl_Dialogos ON Oraciones.Id = Tbl_Dialogos.IdOracion"

        'sqlstring = "Select  Oraciones.Id, Oraciones.orden,  Oraciones.Audio, Oraciones.STL,  Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.Estatus, Oraciones.Oracion, Oraciones.GrupoO, Grupos_oracion.Grupo, "
        '"Oraciones.foco, Oraciones.Palabras, Oraciones.Reproduccion"
        'sqlstring = sqlstring & filtro
        'sqlstring = sqlstring & " Order By orden ASC"

        dgvOraciones.DataSource = Nothing
        dt.Rows.Clear()

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando
            da.Fill(dt)
            dt.AcceptChanges()

            dgvOraciones.DataSource = dt

            MaxColumna = dgvOraciones.ColumnCount

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        Try
            dgvOraciones.Columns(0).Visible = False
            dgvOraciones.Columns(1).Width = 250
            dgvOraciones.Columns(2).Width = 250
            dgvOraciones.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            dgvOraciones.Columns(3).Width = 50

            dgvOraciones.Columns(4).Width = 100
            dgvOraciones.Columns(5).Width = 100
            ' 
            dgvOraciones.Columns(6).Visible = False
            dgvOraciones.Columns(7).Visible = False
            dgvOraciones.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        Catch ex As Exception

        End Try


        Dim n As Integer
        n = dt.Rows.Count

        txtCuenta.Text = n

        If n = 0 Then Exit Sub


        ' lblCuenta.Text = n

        Try
            dgvOraciones.Rows(SelectedId).Selected = True
            'dgvOraciones.Scroll()
            'dgvOraciones.ScrollIntoView(dgvOraciones.SelectedItem)
            'Me.DGVMateriales.FirstDisplayedScrollingRowIndex = I
            dgvOraciones.FirstDisplayedScrollingRowIndex = SelectedId
        Catch ex As Exception

        End Try


        'lsvSugerencia.View = System.Windows.Forms.View.Details
        'lsvSugerencia.LabelEdit = False ' Allow the user to edit item text.
        'lsvSugerencia.AllowColumnReorder = True ' Allow the user to rearrange columns.
        'lsvSugerencia.FullRowSelect = True ' Select the item and subitems when selection is made.
        'lsvSugerencia.GridLines = True ' Display grid lines.

    End Sub
    Private Sub frmOracionesDialogos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        dgvOraciones.RowTemplate.Height = 40

        CargarDatos(" ")

        lblinfo.Text = "0.7 – 1.0  Muy natural " & vbCrLf + _
                        " 0.4 – 0.7  Natural " + vbCrLf + _
                        "0.1 – 0.4   Algo forzada" + vbCrLf + _
                         "0.01 – 0.1  Poco natural" + vbCrLf + _
                        "< 0.01   Muy rara" + vbCrLf + _
                        "0.00013   Extremadamente rara"

    End Sub


    Private Sub cmdOrdenarAZ_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenarAZ.Click
        Dim IdGrupo As Integer
        Dim sqlstring As String = ""

        'If Me.cboGrupo.Text = "" Then Exit Sub
        'If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub

        ' IdGrupo = Me.cboGrupo.SelectedValue

        ' filtro = "select  orden, STL, TextoPlano, Traduccion, Estatus, Oracion, Id, GrupoO from Oraciones "

        'filtro = " Order By ScoreNaturalidad ASC"

        CargarDatosOrdenados(filtro)
    End Sub

    Private Sub cmdStatus_Click(sender As System.Object, e As System.EventArgs) Handles cmdStatus.Click

        Dim Id As Integer
        Dim j As Integer
        Dim resp As Integer

        resp = MsgBox("Eliminar?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

        If resp = 6 Then
        Else
            Exit Sub
        End If

        Id = dgvOraciones.CurrentRow.Cells(0).Value.ToString()
        sqlstring = " UPDATE Oraciones Set Eliminar = @Eliminar "
        sqlstring = sqlstring & " WHERE (Id = '" & Id & "')"

        _comando.CommandText = sqlstring

        _comando.Parameters.Clear()
        _comando.Parameters.AddWithValue("@Eliminar", "S")
        _comando.Connection.Open()

        Try
            j = _comando.ExecuteNonQuery
            ' reemplazos += 1
            ToolStatus.Text = "Se actualizo:" & dgvOraciones.CurrentRow.Cells(1).Value.ToString()
            CargarDatosOrdenados("")

        Catch ex As Exception
            ToolStatus.Text = "no Se actualizo " & Now
            MsgBox(ex.Message)
        End Try

        _comando.Connection.Close()

    End Sub

 
    Private Sub cmdInsertarNuevos_Click(sender As System.Object, e As System.EventArgs) Handles cmdInsertarNuevos.Click
        Dim Id As Integer
        Dim j As Integer
        Dim resp As Integer
        Dim reemplazos As Integer

        _comando.Connection.Open()

        For Each fila As DataGridViewRow In dgvOraciones.SelectedRows
            Id = fila.Cells(1).Value.ToString()

            sqlstring = " UPDATE Oraciones Set CrearDialogo = 'S' "
            sqlstring = sqlstring & " WHERE (Id = '" & Id & "')"

            _comando.CommandText = sqlstring

            '_comando.Parameters.Clear()
            '_comando.Parameters.AddWithValue("@Eliminar", "S")

            Try
                j = _comando.ExecuteNonQuery
                reemplazos += 1

            Catch ex As Exception
                ToolStatus.Text = "no Se actualizo " & reemplazos
                ' MsgBox(ex.Message)
            End Try
        Next


        ToolStatus.Text = "Se actualizo:" & " " & reemplazos

        _comando.Connection.Close()

        

    End Sub

    

    Private Sub dgvOraciones_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvOraciones.DoubleClick
        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New FrmDetOracion

        AddOwnedForm(frm)

        ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        Id = dgvOraciones.CurrentRow.Cells(1).Value.ToString()
        ' TipoTicket = dgvOraciones.CurrentRow.Cells(11).Value.ToString()
        Dim IdGrupo As Integer
        Dim sqlstring As String = ""

        'If Me.cboGrupo.Text = "" Then Exit Sub
        'If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub
        'Try
        '    If cboGrupo.SelectedIndex > -1 Then
        '        IdGrupo = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

        '    End If
        'Catch ex As Exception

        'End Try


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
        frm.GrupoOracionId = IdGrupo
        frm.IdOracion = Id
        frm.CargarDatos(Id)
        frm.Show()
    End Sub

    Private Sub cmdHuerfanas_Click(sender As System.Object, e As System.EventArgs) Handles cmdHuerfanas.Click
        Dim titulo As String

        titulo = InputBox("Titulo")

        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\huerfanas.py"" " & titulo
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        Dim p As Process = Process.Start(psi)
        Dim resultado As String = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

        MessageBox.Show(resultado)


        psi = New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\ActualizarUso.py"" "
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        p = Process.Start(psi)
        resultado = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

        MessageBox.Show(resultado)

        CargarDatos("")

    End Sub

    Private Sub cmdFrecuencia_Click(sender As System.Object, e As System.EventArgs) Handles cmdFrecuencia.Click
        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\ActualizarUso.py"" "
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        Dim p As Process = Process.Start(psi)
        Dim resultado As String = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

        MessageBox.Show(resultado)



    End Sub

    Private Sub dgvOraciones_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOraciones.CellContentClick

    End Sub

    Private Sub dgvOraciones_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvOraciones.KeyUp
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim Id As Integer

        If e.KeyCode = Keys.Delete Then

            Dim resp As Integer
            resp = MsgBox("Desea eliminar Oracion?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

            If resp <> 6 Then
                Exit Sub

            End If

            Id = dgvOraciones.CurrentRow.Cells(1).Value.ToString()

        End If
        
          

        Dim i As Integer

        Dim sqlstring As String

        sqlstring = "Delete FROM Oraciones"
        sqlstring = sqlstring & " WHERE Id = @Id"

        _comando.CommandText = sqlstring

        _comando.Parameters.Clear()
        _comando.Parameters.AddWithValue("@Id", Id)
        _comando.Connection.Open()

        Try
            i = _comando.ExecuteNonQuery
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        '_comando.Connection.Close()

          
        sqlstring = "Delete FROM Tbl_dialogos"
        sqlstring = sqlstring & " WHERE IdOracion = @IdOracion"

        _comando.CommandText = sqlstring

        _comando.Parameters.Clear()
        _comando.Parameters.AddWithValue("@IdOracion", Id)
        ' _comando.Connection.Open()

        Try
            i = _comando.ExecuteNonQuery
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        _comando.Connection.Close()

        If dgvOraciones.CurrentRow IsNot Nothing Then
            Dim index As Integer = dgvOraciones.CurrentRow.Index
            dt.Rows(index).Delete()
        End If

        'dt.Rows.RemoveAt(dgvOraciones.CurrentRow.Index)

        If dgvOraciones.CurrentRow IsNot Nothing Then

            Dim index As Integer = dgvOraciones.CurrentRow.Index

            dgvOraciones.Rows.RemoveAt(index)

        End If
    End Sub


End Class