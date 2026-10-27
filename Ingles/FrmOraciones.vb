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

Public Class FrmOraciones
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

    Private Sub FrmOraciones_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        txtEstructura.Text = IdEst

        If Estructura <> "" Then
            txtBuscar.Text = Estructura
        End If
        'cargarDatos()
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        'sqlstring = "select * from  SubTemas "
        sqlstring = "select * from  Grupos_oracion "
        sqlstring = sqlstring & " ORDER By orden ASC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            'Me.cboGrupo.DataSource = dt
            'Me.cboGrupo.ValueMember = "Id"
            'Me.cboGrupo.DisplayMember = "Grupo"

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        cboGrupo.Items.Clear()

        Dim i As Integer
        Dim n As Integer
        n = dt.Rows.Count

        cboGrupo.Items.Add("ALL")

        Do While i <= n - 1
            Me.cboGrupo.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
            i = i + 1
        Loop

        'Cargar Temas
        If Estructura <> "" Then
            txtBuscar.Text = Estructura
        End If
       

        Dim Temas As New DataTable
        da = New SqlDataAdapter
         
        sqlstring = "select Id, Tema from  Tbl_temas "
        sqlstring = sqlstring & " ORDER By Tema ASC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(Temas)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        cboTema.Items.Clear()
          
        n = Temas.Rows.Count

        Do While i <= n - 1
            Me.cboTema.Items.Add(New clsItem(Temas.Rows(i).Item(1), Temas.Rows(i).Item(0)))
            i = i + 1
        Loop


        CrearFiltro()

        CargarDatos(filtro)

    End Sub
    Private Sub FrmOraciones_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        'Me.BringToFront()
        'Me.Focus() 'Me.Focus()
        'mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)  '' Simular un clic izquierdo
        'mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

        ' MsgBox("Se activo")


       
        ' SendKeys.Send("Hola, esto es texto")

    End Sub

    Private Sub FrmOraciones_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        Me.ForeColor = Color.Gray

    End Sub

    Public Sub CargarDatos(filtro)
        _comando = MetodosDatos.CrearComando()
        Dim sqlstring As String

        If filtro = Nothing Then Exit Sub

        sqlstring = "Select  Oraciones.Id, Oraciones.orden,  Oraciones.Audio, Oraciones.STL,  Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.Estatus, Oraciones.Tema, Oraciones.GrupoO, Grupos_oracion.Grupo, "
        sqlstring = sqlstring & "Oraciones.foco, Oraciones.Palabras, Oraciones.Reproduccion"
        sqlstring = sqlstring & " FROM            Oraciones INNER JOIN  Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"
        sqlstring = sqlstring & filtro
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
            'dgvOraciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' dgvOraciones.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvOraciones.Columns(1).Width = 50
            dgvOraciones.Columns(2).Width = 50
            dgvOraciones.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            dgvOraciones.Columns(3).Width = 50
            'dgvOraciones.Columns(2).Width = 100
            dgvOraciones.Columns(4).Width = 300
            dgvOraciones.Columns(5).Width = 300
            ' 
            ' dgvOraciones.Columns(6).Visible = False
            ' dgvOraciones.Columns(7).Visible = False
            dgvOraciones.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Catch ex As Exception

        End Try


        Dim n As Integer
        n = dt.Rows.Count
        If n = 0 Then Exit Sub

        lblCuenta.Text = n

        Try
            dgvOraciones.Rows(SelectedId).Selected = True
            'dgvOraciones.Scroll()
            'dgvOraciones.ScrollIntoView(dgvOraciones.SelectedItem)
            'Me.DGVMateriales.FirstDisplayedScrollingRowIndex = I
            dgvOraciones.FirstDisplayedScrollingRowIndex = SelectedId
        Catch ex As Exception

        End Try


        lsvSugerencia.View = System.Windows.Forms.View.Details
        lsvSugerencia.LabelEdit = False ' Allow the user to edit item text.
        lsvSugerencia.AllowColumnReorder = True ' Allow the user to rearrange columns.
        lsvSugerencia.FullRowSelect = True ' Select the item and subitems when selection is made.
        lsvSugerencia.GridLines = True ' Display grid lines.

    End Sub
    'customize the TextBoxCellRenderer
    Public Sub CargarDatosFaltantes(sql)
        _comando = MetodosDatos.CrearComando()
         
        dgvOraciones.DataSource = Nothing
        dt.Rows.Clear()

        Try
            _comando.CommandText = sql
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
            'dgvOraciones.Columns(0).Visible = False
            'dgvOraciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' dgvOraciones.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvOraciones.Columns(1).Width = 50
            dgvOraciones.Columns(2).Width = 50
            dgvOraciones.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            dgvOraciones.Columns(3).Width = 50
            'dgvOraciones.Columns(2).Width = 100
            dgvOraciones.Columns(4).Width = 300
            dgvOraciones.Columns(5).Width = 300
            ' 
            dgvOraciones.Columns(6).Visible = False
            dgvOraciones.Columns(7).Visible = False
            dgvOraciones.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Catch ex As Exception

        End Try


        Dim n As Integer
        n = dt.Rows.Count
        If n = 0 Then Exit Sub

        lblCuenta.Text = n

        Try
            dgvOraciones.Rows(SelectedId).Selected = True
            'dgvOraciones.Scroll()
            'dgvOraciones.ScrollIntoView(dgvOraciones.SelectedItem)
            'Me.DGVMateriales.FirstDisplayedScrollingRowIndex = I
            dgvOraciones.FirstDisplayedScrollingRowIndex = SelectedId
        Catch ex As Exception

        End Try




    End Sub

    Private Sub cboGrupo_LostFocus(sender As Object, e As System.EventArgs) Handles cboGrupo.LostFocus
        'Dim IdGrupo As Integer
        'If Me.cboGrupo.Text = "" Then Exit Sub
        'If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub
        'IdGrupo = Me.cboGrupo.SelectedValue

        'CargarDatos(IdGrupo)
    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupo.SelectedIndexChanged
        Dim _grupo As String
        Dim sqlstring As String = ""

        If Me.cboGrupo.Text = "" Then Exit Sub
        ' If Me.cboGrupo.SelectedIndex = -1 Then Exit Sub

        ' If IdGrupo = 0 Then Exit Sub

        _grupo = Trim(cboGrupo.Text)

        CrearFiltro()

        CargarDatos(filtro)

        CargarSugerencia("")

    End Sub

    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()

    End Sub

    Private Sub dgvOraciones_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOraciones.CellEndEdit
        ' Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        '  Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter

        'Dim sqlstring As String

        'Dim builder As SqlCommandBuilder = New SqlCommandBuilder(da)
        '' _comando.CommandText = sqlstring
        ''  _comando.Connection.Open()
        'Dim ds As New DataSet()

        '' da.SelectCommand = _comando
        'da.Fill(ds, "Table")


        'Dim table As DataTable = ds.Tables("Table")

        'table.Rows(0)("foco") = True
        sqlstring = "select  Id, orden, STL, TextoPlano, Traduccion, Estatus, Oracion, GrupoO, "
        sqlstring = sqlstring & "foco"
        sqlstring = sqlstring & " from Oraciones "

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        _comando.Connection.Open()


        'da.Update(table)
        Dim builder As New SqlCommandBuilder(da)
        'Using cn As New SqlConnection("Your connection string")
        '**EDIT** Add line to re-establish connection for adapter
        da.SelectCommand = New SqlCommand(sqlstring, _comando.Connection)
        Try
            da.Update(dt)

        Catch ex As Exception

        End Try

        txtBuscar.Focus()
    End Sub

    
    Private Sub dgvOraciones_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvOraciones.CellFormatting

        'Set the background to red for negative values in the Balance column.


        Try
            If dgvOraciones.Columns(e.ColumnIndex).Name.Equals("STL") Then
                If e.Value = True Then
                    For ColNo As Integer = 0 To MaxColumna - 1
                        dgvOraciones.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = Color3
                    Next
                Else

                    For ColNo As Integer = 0 To MaxColumna - 1
                        dgvOraciones.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = Color1
                    Next
                End If
            End If

            If dgvOraciones.Columns(e.ColumnIndex).Name.Equals("foco") Then
                If e.Value = True Then
                    For ColNo As Integer = 0 To MaxColumna - 1
                        dgvOraciones.Rows(e.RowIndex).Cells(ColNo).Style.ForeColor = Color.Blue
                        ' dgvOraciones.Rows(e.RowIndex).Cells(ColNo).Style.Font = New Font("Arial", 15, FontStyle.Bold)
                        'dgvOraciones.Rows(e.RowIndex).Cells(ColNo).Style.Font = New Font("Arial", 12, FontStyle.Bold)
                        '  e.CellStyle.Font = New Font(e.CellStyle.Font, FontStyle.Bold)
                        'e.CellStyle
                        'e.CellStyle.Font = New Font(e.CellStyle.Font, FontStyle.Bold)
                        ' e.FormattingApplied = True
                    Next
                    '            'Else
                    '            '    For ColNo As Integer = 0 To MaxColumna - 1
                    '            '        dgvOraciones.Rows(e.RowIndex).Cells(ColNo).Style.ForeColor = Color.Black
                    '            '    Next
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvOraciones_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvOraciones.DoubleClick
        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New FrmDetOracion

        AddOwnedForm(frm)

        ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        Id = dgvOraciones.CurrentRow.Cells(0).Value.ToString()
        ' TipoTicket = dgvOraciones.CurrentRow.Cells(11).Value.ToString()
        Dim IdGrupo As Integer
        Dim sqlstring As String = ""

        'If Me.cboGrupo.Text = "" Then Exit Sub
        'If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub
        Try
            If cboGrupo.SelectedIndex > -1 Then
                IdGrupo = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

            End If
        Catch ex As Exception

        End Try


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

    Private Sub txtBuscar_LostFocus(sender As Object, e As System.EventArgs) Handles txtBuscar.LostFocus, txtTraduccion.LostFocus

        If txtBuscar.Text = "" Then Exit Sub
        Clipboard.SetText(txtBuscar.Text)
        txtBuscar.Text = ""
        txtBuscar.BackColor = Color.Beige
        txtBuscar.Focus()

    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged

        Dim buscar As String
        Dim sqlstring As String = ""
        
        Dim i, n As Integer
        'Try
        ' conexion.Open()
        'lstOraciones.Items.Clear()

        buscar = Trim(Me.txtBuscar.Text)

        If Len(buscar) < 1 Then Exit Sub

        _comando = MetodosDatos.CrearComando()

        filtro = "select Oraciones.Id, Oraciones.orden, Oraciones.STL, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.Estatus, Oraciones.Oracion, Oraciones.GrupoO, Grupos_oracion.Grupo, "
        filtro = filtro & "Oraciones.foco, Oraciones.Palabras, Oraciones.Audio"
        filtro = filtro & " FROM            Oraciones INNER JOIN  Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"

        filtro = filtro & " Where TextoPlano LIKE '%' + @TextoPlano + '%'"
        filtro = filtro & " ORDER BY Oraciones.TextoPlano ASC"
       
        Try
            _comando.CommandText = filtro

            _comando.Connection.Open()
            _comando.Parameters.AddWithValue("@TextoPlano", buscar)

            dt.Clear()

            da.SelectCommand = _comando

            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        _comando.Connection.Close()

        n = dt.Rows.Count
        dt.AcceptChanges()

        dgvOraciones.DataSource = dt

        MaxColumna = dt.Columns.Count

        Try
            dgvOraciones.Columns(0).Visible = False
           
            dgvOraciones.Columns(1).Width = 50
            dgvOraciones.Columns(2).Width = 50
            dgvOraciones.Columns(3).Width = 50
            dgvOraciones.Columns(4).Width = 300
            dgvOraciones.Columns(5).Width = 300
         
            dgvOraciones.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            dgvOraciones.Columns(6).Visible = False
            dgvOraciones.Columns(7).Visible = False
            dgvOraciones.Columns(8).Visible = False

            ' dgvOraciones.Columns(3).Visible = False
            '  dgvOraciones.Columns(4).Visible = False
            'dgvOraciones.Columns(5).Visible = False
            'dgvOraciones.Columns(6).Visible = False
        Catch ex As Exception

        End Try



        'For Each rw As DataGridViewRow In dgvOraciones.Rows

        '  If rw.Cells(8).Value = True Then
        'rw.DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
        'dgvOraciones.Rows(e.RowIndex).Cells(ColNo).Style.Font = New Font("Arial", 12, FontStyle.Bold)

        ' End If
        ' Next




    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmNewOracion

        frm.Show()
        'CargarDatos(filtro)

        'frmNewOracion.Show()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim OracionEN As String
        Dim OracionES As String
        Dim SQL As String
        Dim Id As Integer
        Dim IdOracion As Integer

        ' OracionEN = txtOracionEN.Text
        '  OracionES = txtOracionES.Text
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        _comando.Connection.Open()
        Dim IdPerson As Integer

        IdPerson = 0
        Id = 6004

        For Each r In dgvOraciones.Rows

            ' IdOracion = dgvOraciones.CurrentRow.Cells(5).Value.ToString()
            IdOracion = r.Cells(5).Value.ToString()

            sqlstring = ""
            'Dim IdOracion As Integer
            'Dim dt As New DataTable
            'Dim da As New SqlDataAdapter
            'Dim i As Integer

            ' sqlstring = "select * from  SubTemas "
            '    conexion.Open()
            'Select Case cmbPersona.Text
            '    Case "Lisa"
            '        IdPerson = 1

            '    Case "Steve"
            '        IdPerson = 2

            '    Case "Maggie"
            '        IdPerson = 3

            '    Case "Marge"
            '        IdPerson = 4

            '    Case "Mark"
            '        IdPerson = 5

            '    Case "Homer"
            '        IdPerson = 6
            '    Case "Doctor"
            '        IdPerson = 9

            'End Select


            'Try
            '    'If lstOraciones.SelectedItems(0).Text = "" Then Exit Sub

            'Catch ex As Exception
            '    'Exit Sub
            'End Try

            'IdOracion = lstOraciones.SelectedItems(0).Text
            'Desc = lstOraciones.SelectedItems(0).Text
           

            sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
            sqlstring = sqlstring & " Values ('" & IdOracion & "', '0', '" & Id & "', '" & IdPerson & "')"

            '  _comando.Connection = conexion
            _comando.CommandText = sqlstring




            Try

                i = _comando.ExecuteNonQuery

                If i > 0 Then
                    'MsgBox("se guardo")

                Else
                    'MsgBox("No se guardo")
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try

            'txtBuscar.Text = ""

        Next
        _comando.Connection.Close()

        'If cmbPersona.Text = "" Then Exit Sub


        'Agrega a Conversacion
        ' Dim _comando As SqlCommand = MetodosDatos.CrearComando()
       
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim OracionId As Integer
        Dim OracionES As String

        ' OracionEN = RichTextBoxEx1.rtb.Text
        ' OracionES = txtTraduccion.Text
       
        Try
            OracionId = dgvOraciones.CurrentRow.Cells(6).Value.ToString()

        Catch ex As Exception

        End Try
        If OracionId = 0 Then
            MsgBox("No se ha seleccionado")
            Exit Sub
        End If


        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i As Integer


        sqlstring = "Insert into SubtemaxOracion (OracionId, SubtemaId)"
        sqlstring = sqlstring & " Values ('" & OracionId & "', '" & SubtemaId & "' )"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()
        Try
            i = _comando.ExecuteNonQuery

            If i > 0 Then
                ' MsgBox("se guardo")

            Else
                '  MsgBox("No se guardo")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        _comando.Connection.Close()
        'txtDescripcion.Text = ""
        ' txtTraduccion.Text = ""

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub cmdOrden_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrden.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, j As Integer

        i = 1

        ' OracionId = dgvOraciones.CurrentRow.Cells(5).Value.ToString()
        _comando.Connection.Open()


        For Each r In dgvOraciones.Rows

            _comando.Parameters.Clear()
            'Console.WriteLine(r.cells(6).value.ToString())


            'If r.Item(0).text = "" Then
            '    sqlstring = "UPDATE Oraciones SET Orden = @Orden"
            '    sqlstring = sqlstring & " WHERE Id = @Id"
            '    _comando.Parameters.AddWithValue("@Orden", i)

            'Else

            sqlstring = "UPDATE Oraciones SET Orden = @Orden"
            sqlstring = sqlstring & " WHERE  Id = @Id"

            _comando.Parameters.AddWithValue("@Orden", i)
            _comando.Parameters.AddWithValue("@Id", r.cells(6).value.ToString())

            _comando.CommandText = sqlstring

            Try
                j = _comando.ExecuteNonQuery

            Catch ex As Exception

            End Try

            i = i + 1
        Next
        _comando.Connection.Close()

        If i > 0 Then
            CargarDatos(filtro)
        Else
            MsgBox("No se actualizo")
        End If
        

    End Sub

    Private Sub cmdOrdenar_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenar.Click
        Dim frm As New frmOrdenar
        Dim IdGrupo As Integer

        If Me.cboGrupo.Text = "" Then Exit Sub
        If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub

        ' IdGrupo = Me.cboGrupo.SelectedValue
        IdGrupo = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

        ' AddOwnedForm(frm)
        frm.IdGrupo = IdGrupo
        Try
            frm.Location = New Point(Screen.AllScreens(1).Bounds.X, Screen.AllScreens(1).Bounds.Y)

        Catch ex As Exception

        End Try
        frm.Show()
      
        CargarDatos(filtro)

    End Sub



    Private Sub cmdGrupos_Click(sender As System.Object, e As System.EventArgs) Handles cmdGrupos.Click

        frmGrupos.Show()



        'Dim frm As New frmOrdenar
        'Dim IdGrupo As Integer
        'If Me.cboGrupo.Text = "" Then Exit Sub
        'If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub

        'IdGrupo = Me.cboGrupo.SelectedValue

        'AddOwnedForm(frm)
        'frm.IdGrupo = IdGrupo
        'frm.Show()

        'CargarDatos(filtro)

    End Sub

   

    Private Sub cmdOrdenarAZ_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenarAZ.Click
        Dim IdGrupo As Integer
        Dim sqlstring As String = ""

        If Me.cboGrupo.Text = "" Then Exit Sub
        If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub

        IdGrupo = Me.cboGrupo.SelectedValue

        filtro = "select  orden, STL, TextoPlano, Traduccion, Estatus, Oracion, Id, GrupoO from Oraciones "
        filtro = filtro & " Where GrupoO= '" & IdGrupo & "'"
        filtro = filtro & " Order By TextoPlano ASC"

        CargarDatos(filtro)
    End Sub

    Private Sub cmdUpdate_Click(sender As System.Object, e As System.EventArgs) Handles cmdUpdate.Click
        Dim param As String = ""
        Dim resp As Integer
        Dim i, n As Integer
        Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String
        Dim sqlstring As String
        Dim IdGrupo As Integer
        'Private conString As String = "Your connection string"
        'Private CurrentRow As Integer
        'Private dt As DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable

        If Me.cboGrupo.Text = "" Then Exit Sub
        If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub

        IdGrupo = Me.cboGrupo.SelectedValue

        sqlstring = " SELECT       Oraciones.Id, Oraciones.Oracion, Oraciones.ConceptoID, Oraciones.GrupoO, Oraciones.Traduccion, Oraciones.Campo1, Oraciones.F5, Oraciones.F6, Oraciones.Palabra, Oraciones.[Delete], Oraciones.SEL, "
        sqlstring = sqlstring & "                  Oraciones.estatus, Oraciones.GrupoId, Oraciones.forma, Oraciones.STL, Oraciones.IMG, Oraciones.Orden, Oraciones.Campo2, Oraciones.IPA, Oraciones.Campo3, Oraciones.TextoPlano, Oraciones.CursoId, "
        sqlstring = sqlstring & "                  Oraciones.SSMA_TimeStamp, Oraciones.Ora_Aprendido, Grupos_oracion.Grupo"
        sqlstring = sqlstring & "  FROM            Oraciones LEFT JOIN"
        sqlstring = sqlstring & "                    Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"
        sqlstring = sqlstring & " Where GrupoO= '" & IdGrupo & "'"

        ' sqlstring = sqlstring & param
        '  sqlstring = sqlstring & " Where  Oraciones.Id='3758'"
        '  sqlstring = sqlstring & "  Order by Oraciones.TextoPlano ASC"

       
        ' filtro = "select  orden, STL, TextoPlano, Traduccion, Estatus, Oracion, Id, GrupoO from Oraciones "


        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            _comando.Connection.Close()

            ' MessageBox.Show(" Record is Ready")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try


        n = dt.Rows.Count

        Dim respcorreo As Boolean
        '  Dim sqlstring As String

        Dim item As ListViewItem

        '  Dim i As Integer
        Dim _insertado As Boolean = False
        Dim mostrarMensaje As Boolean = False
        Dim stringvalues As String = ""
        '  Dim sql As String = ""
        Dim IdMax As Integer

        Dim fecha As Date
        Dim fechaEntrega As Date
        '  Dim rtb As New RichTextBox

        Dim Oracion As String = ""
        Dim TextoPlano As String = ""

        _comando.Connection.Open()

        sqlstring = "UPDATE Oraciones SET Oracion=@Oracion"
        sqlstring = sqlstring & " WHERE Id = @Id"
        _comando.CommandText = sqlstring

        ' Dim wb As New WebBrowser
        '' Dim objrtf As RichTextBox
        Dim Clip As Clipboard
        'Clip.SetDataObject(Oracion)
       
        'rtbTemp.SelectionFont = New System.Drawing.Font("Arial", 30, FontStyle.Bold)

        For Each r In dt.Rows

            ' TextoPlano = ""
            Dim wb As New WebBrowser

            If Mid(r.Item(1), 1, 1) <> "{" Then
                _comando.Parameters.Clear()
                ' rtbTemp.Text = r.Item(20)
                _comando.Parameters.AddWithValue("Id", r.Item(0))
                '_comando.Parameters.AddWithValue("Oracion", rtbTemp.Rtf)
                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    'MsgBox(ex.Message)
                End Try
            Else
                'Console.WriteLine(r.item(0))
                Console.WriteLine(r.item(20))

                If Not IsDBNull(r.Item(1)) Then

                    ' If r.Item(1) <> "" Then
                    ' MsgBox("vacio")
                    Dim html As String = "" '// html content
                    html = r.Item(1)

                    'RichTextBox rtbTemp = new RichTextBox();
                    'WebBrowser wb = new WebBrowser();

                    'wb.Document.Write(html);
                    'wb.Document.ExecCommand("SelectAll", false, null);
                    'wb.Document.ExecCommand("Copy", false, null);

                    'rtbTemp.SelectAll();
                    'rtbTemp.Paste();
                    Try
                        Clip.Clear()
                    Catch ex As Exception

                    End Try


                    wb.Navigate("about:blank")

                    wb.DocumentText = ""

                    wb.Document.Write(html)
                    wb.Document.ExecCommand("SelectAll", False, vbNull)
                    wb.Document.ExecCommand("Copy", False, vbNull)
                    '  rtbTemp.SelectAll()
                    ' rtbTemp.Paste()

                  

                    ' rtbTemp.SelectAll()
                    ' rtbTemp.Font = New Font("Consolas", 12, FontStyle.Regular)
                    ' rtbTemp.SelectionFont = masterFont
                    ' rtbTemp.Font.Name = "Consolas"
                    'rtb.SelectionFont = New Font("Consolas", 30, FontStyle.Regular)


                    _comando.Parameters.Clear()
                    _comando.Parameters.AddWithValue("Id", r.Item(0))
                    ' _comando.Parameters.AddWithValue("Oracion", rtbTemp.Rtf)
                    ' _comando.Parameters.AddWithValue("TextoPlano", TextoPlano)


                    Try
                        i = _comando.ExecuteNonQuery

                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try
                    ' Status = "Saved RTF"



                    'Oracion = r.Item(1)

                    '' wb.DocumentText = Oracion
                    '' WebBrowser1.Refresh()
                    '' wb.Refresh()
                    ''Console.WriteLine(Oracion)

                    'rtb.Clear()
                    '' rtb.Text = Clip.GetDataObject.GetData(System.Windows.Forms.DataFormats.StringFormat, True)
                    ''or Clip.GetDataObject.GetData(System.Windows.Forms.DataFormats.Html, True)

                    ''  rtb.AppendText("")
                    ''wb.Document.ExecCommand("SelectAll", False, vbNull)
                    ''wb.Document.ExecCommand("Copy", False, vbNull)
                    '' rtb.Rtf = wb.DocumentText
                    'rtb.Paste()
                    'rtb.Refresh()
                    'RichTextBoxEx1.rtb.AppendText("")
                    'WebBrowser1.Document.ExecCommand("SelectAll", False, vbNull)
                    'WebBrowser1.Document.ExecCommand("Copy", False, vbNull)
                    'RichTextBoxEx1.rtb.Paste()


                    'If Not IsDBNull(r.Item(20)) Then
                    'TextoPlano = Trim(r.Item(20))
                    ' End If




                    'End If

                End If


                ' MsgBox("NULL")


                ' _comando.Parameters.AddWithValue("TextoPlano", TextoPlano)


            End If




        Next
        _comando.Connection.Close()






    End Sub


    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim param As String = ""
        Dim resp As Integer
        Dim i, n As Integer
        Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String
        Dim sqlstring As String
        Dim IdGrupo As Integer
        'Private conString As String = "Your connection string"
        'Private CurrentRow As Integer
        'Private dt As DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable

        If Me.cboGrupo.Text = "" Then Exit Sub
        If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub

        IdGrupo = Me.cboGrupo.SelectedValue

        sqlstring = " SELECT       Oraciones.Id, Oraciones.Oracion, Oraciones.ConceptoID, Oraciones.GrupoO, Oraciones.Traduccion, Oraciones.Campo1, Oraciones.F5, Oraciones.F6, Oraciones.Palabra, Oraciones.[Delete], Oraciones.SEL, "
        sqlstring = sqlstring & "                  Oraciones.estatus, Oraciones.GrupoId, Oraciones.forma, Oraciones.STL, Oraciones.IMG, Oraciones.Orden, Oraciones.Campo2, Oraciones.IPA, Oraciones.Campo3, Oraciones.TextoPlano, Oraciones.CursoId, "
        sqlstring = sqlstring & "                  Oraciones.SSMA_TimeStamp, Oraciones.Ora_Aprendido, Grupos_oracion.Grupo"
        sqlstring = sqlstring & "  FROM            Oraciones LEFT JOIN"
        sqlstring = sqlstring & "                    Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"
        sqlstring = sqlstring & " Where GrupoO= '" & IdGrupo & "'"

        ' sqlstring = sqlstring & param
        '  sqlstring = sqlstring & " Where  Oraciones.Id='3758'"
        '  sqlstring = sqlstring & "  Order by Oraciones.TextoPlano ASC"
        ' filtro = "select  orden, STL, TextoPlano, Traduccion, Estatus, Oracion, Id, GrupoO from Oraciones "
        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando
            da.Fill(dt)

            _comando.Connection.Close()
            ' MessageBox.Show(" Record is Ready")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try


        n = dt.Rows.Count

        Dim respcorreo As Boolean
        '  Dim sqlstring As String

        Dim item As ListViewItem
        '  Dim i As Integer
        Dim _insertado As Boolean = False
        Dim mostrarMensaje As Boolean = False
        Dim stringvalues As String = ""
        '  Dim sql As String = ""
        Dim IdMax As Integer
        Dim fecha As Date
        Dim fechaEntrega As Date

        Dim Oracion As String = ""
        Dim TextoPlano As String = ""

        _comando.Connection.Open()

        sqlstring = "UPDATE Oraciones SET Oracion=@Oracion"
        sqlstring = sqlstring & " WHERE Id = @Id"
        _comando.CommandText = sqlstring

        Dim wb As New WebBrowser

       
        'rtbTemp.SelectionFont = New System.Drawing.Font("Arial", 30, FontStyle.Bold)
        Dim rtb As New RichTextBox

        For Each r In dt.Rows


            If Mid(r.Item(1), 1, 1) <> "{" Then
                _comando.Parameters.Clear()
                ' rtbTemp.Text = r.Item(20)
                Dim rtbTemp As New RichTextBox
                Dim masterFont = New System.Drawing.Font("Consolas", 12, FontStyle.Regular)
                'rtbTemp.Rtf = r.item(1)
                rtbTemp.Text = r.item(20)
                'rtbTemp.SelectionFont = masterFont
                rtbTemp.Font = masterFont
                Dim rtb1start As Integer = rtbTemp.SelectionStart
                Dim len As Integer = rtbTemp.SelectionLength
                Dim rtbTempStart As Integer = 0
                ' If len <= 1 and there is a selection font, amend and return
                If len <= 1 AndAlso rtbTemp.SelectionFont IsNot Nothing Then
                    rtbTemp.SelectionFont = masterFont
                    'Return
                End If

                _comando.Parameters.Clear()
                _comando.Parameters.AddWithValue("Id", r.Item(0))
                _comando.Parameters.AddWithValue("Oracion", rtbTemp.Rtf)
                 
                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    'MsgBox(ex.Message)
                End Try
            Else



                ' Dim wb As New WebBrowser
                If Not IsDBNull(r.Item(1)) Then
                     
                    Dim rtbTemp As New RichTextBox
                    Dim masterFont = New System.Drawing.Font("Consolas", 12, FontStyle.Regular)
                    ' Dim masterFont = New Font("arial", 29, FontStyle.Bold)
                    rtbTemp.Rtf = r.item(1)
                    rtbTemp.Text = r.item(20)
                    'rtbTemp.SelectionFont = masterFont
                    rtbTemp.Font = masterFont
                    Dim rtb1start As Integer = rtbTemp.SelectionStart
                    Dim len As Integer = rtbTemp.SelectionLength
                    Dim rtbTempStart As Integer = 0
                    ' If len <= 1 and there is a selection font, amend and return
                    If len <= 1 AndAlso rtbTemp.SelectionFont IsNot Nothing Then
                        rtbTemp.SelectionFont = masterFont
                        'Return
                    End If

                    _comando.Parameters.Clear()
                    _comando.Parameters.AddWithValue("Id", r.Item(0))
                    _comando.Parameters.AddWithValue("Oracion", rtbTemp.Rtf)

                    Try
                        i = _comando.ExecuteNonQuery

                    Catch ex As Exception
                        'MsgBox(ex.Message)
                    End Try
                End If





            End If





        Next
        _comando.Connection.Close()



    End Sub

    Private Sub cmdObjetivo_Click(sender As System.Object, e As System.EventArgs) Handles cmdObjetivo.Click
        Dim frm As New frmObjetivo

        frm.valor = "Oraciones"
        frm.Show()

    End Sub

    Private Sub txtTraduccion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTraduccion.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim trad As String
        Dim sqlstring As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer
        
        trad = Me.txtTraduccion.Text

        filtro = "select  Id, orden, STL, TextoPlano, Traduccion, Estatus, Oracion, GrupoO, "
        filtro = filtro & "foco"
        filtro = filtro & " from Oraciones "

        filtro = filtro & " Where Traduccion LIKE " & "'%" & trad & "%'"
        filtro = filtro & " ORDER BY Oraciones.TextoPlano ASC"

        Try
            _comando.CommandText = filtro
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally

        End Try
        _comando.Connection.Close()

        n = dt.Rows.Count

        dgvOraciones.DataSource = dt


        Try
            dgvOraciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvOraciones.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvOraciones.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvOraciones.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvOraciones.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
           
            dgvOraciones.Columns(5).Visible = False
            dgvOraciones.Columns(6).Visible = False
        Catch ex As Exception

        End Try
         
    End Sub

    Private Sub dgvOraciones_Click(sender As Object, e As System.EventArgs) Handles dgvOraciones.Click
        Try
            SelectedId = dgvOraciones.CurrentRow.Index

        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmdBorrarPuntos_Click(sender As System.Object, e As System.EventArgs) Handles cmdBorrarPuntos.Click
        Dim Id, j As Integer
        Dim TextoPlano As String
        Dim sqlstring As String
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim i As Integer
        Dim n As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim reemplazos As Integer

        _comando.Connection.Open()
        Dim celda As DataGridViewCell

        ' Obtén el valor actual del texto y reemplaza el caracter
        Dim valorActual As String
        Dim valorModificado As String

        pbavance.Maximum = dgvOraciones.Rows.Count
        pbavance.Value = 0
        reemplazos = 0
        Dim reemplazar As String

        ' reemplazar = InputBox("Caracter a reemplazar")

        ' If reemplazar = "" Then Exit Sub

        For Each RW As DataGridViewRow In dgvOraciones.Rows


            Id = RW.Cells(0).Value.ToString()
            'Obtén la celda
            celda = RW.Cells(3)

            ' Obtén el valor actual del texto y reemplaza el caracter
            valorActual = celda.Value.ToString()

            '.Replace(oldValue, NewValue)
            valorModificado = valorActual.Replace("’", "'") ' Reemplaza 'a' por 'X'
            'valorModificado = Trim(valorActual)

            ' Asigna el valor modificado a la celda
            ' celda.Value = valorModificado
            If valorActual <> valorModificado Then
                Try
                    '    sqlstring = "UPDATE Oraciones SET Orden = @Orden"
                    sqlstring = " UPDATE Oraciones Set TextoPlano = @TextoPlano "
                    ' sqlstring = " UPDATE Oraciones Set Traduccion = @Traduccion "
                    sqlstring = sqlstring & " WHERE (Id = '" & Id & "')"
                    _comando.CommandText = sqlstring

                    _comando.Parameters.Clear()
                    _comando.Parameters.AddWithValue("@TextoPlano", valorModificado)
                    '_comando.Parameters.AddWithValue("@Traduccion", valorModificado)

                    Try
                        j = _comando.ExecuteNonQuery
                        reemplazos += 1

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Catch ex As Exception
                End Try
            End If
            ' pbavance.Value = 0
            pbavance.Value = pbavance.Value + 1

        Next
        _comando.Connection.Close()

        MsgBox("Se realizaron " & reemplazos & " reemplazos")

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim sqlstring As String
        Dim aprendidos As Integer

        sqlstring = "select  Id, orden, STL, TextoPlano, Traduccion, Estatus, Oracion, GrupoO from Oraciones "
        sqlstring = sqlstring & " Where STL= 'True'"

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
 
            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        aprendidos = dt.Rows.Count

        txtaprendidos.Text = aprendidos
  
        sqlstring = "select  Id, orden, STL, TextoPlano, Traduccion, Estatus, Oracion, GrupoO from Oraciones "
        sqlstring = sqlstring & " Where STL= 'False'"
         

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        Dim Noaprendidos As Integer
        Noaprendidos = dt.Rows.Count

        lblCuenta.Text = aprendidos + Noaprendidos

        Try
            txtAvance.Text = Math.Round((aprendidos / Noaprendidos), 1) * 100 & "%"
        Catch ex As Exception

        End Try

    End Sub

   


    Private Sub cmdFoco_Click(sender As System.Object, e As System.EventArgs) Handles cmdFoco.Click

        If cmdFoco.Text = "foco" Then
            cmdFoco.Text = "Sin foco"
            cmdFoco.BackColor = Color.LightGray
        Else
            cmdFoco.Text = "foco"
            cmdFoco.BackColor = Color.LightGreen
        End If

        CrearFiltro()

        CargarDatos(filtro)

    End Sub

    Public Sub CrearFiltro()
        filtro = ""

        If cmdFoco.Text = "foco" Then
            filtro = filtro & " Where foco = 'True'"
            ' cmdFoco.Text = "Sin foco"
        Else
            filtro = filtro & " Where foco = 'false'"
            'cmdFoco.Text = "foco"

        End If

        If cmdAprendidos.Text = "Aprendidos" Then
            filtro = filtro & " And STL = 'True'"
        Else
            filtro = filtro & " And STL = 'false'"
        End If


        Dim IdGrupo As Integer

        Try
            IdGrupo = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()
            If cboGrupo.Text <> "ALL" Then
                filtro = filtro & " And GrupoO= '" & IdGrupo & "'"
            Else
            End If

        Catch ex As Exception
        End Try


        If cmdFiltroEscuchados.Text = "Mas escuchados" Then
            filtro = filtro & " And Reproduccion > 9"
            filtro = filtro & " Order by Reproduccion ASC"
        Else
            filtro = filtro & "  And Reproduccion < 10"
            filtro = filtro & " Order by Reproduccion DESC"
        End If


    End Sub

    Private Sub cmdFalta_Click(sender As System.Object, e As System.EventArgs) Handles cmdFalta.Click
        Dim sql As String

        sql = "SELECT        Oraciones.Id, Oraciones.Orden, Oraciones.STL, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.estatus, Oraciones.Oracion, Oraciones.GrupoO, Grupos_oracion.Grupo, Oraciones.foco, "
        sql = sql & "         Dialogos.Id, Dialogos.OracionId, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.GrupoO, Grupos_oracion.Grupo"
        sql = sql & " FROM            Oraciones LEFT OUTER JOIN"
        sql = sql & "                        Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id LEFT OUTER JOIN"
        sql = sql & "                       Dialogos ON Oraciones.Id = Dialogos.OracionId"
        sql = sql & "       WHERE (Dialogos.OracionId Is NULL)"
        sql = sql & " ORDER BY Dialogos.Id DESC"
         

        CargarDatosFaltantes(sql)

    End Sub

    Private Sub cmdAprendidos_Click(sender As System.Object, e As System.EventArgs) Handles cmdAprendidos.Click

        If cmdAprendidos.Text = "Aprendidos" Then
            cmdAprendidos.Text = "Falta"
            cmdAprendidos.BackColor = Color.LightGray
        Else
            cmdAprendidos.Text = "Aprendidos"
            cmdAprendidos.BackColor = Color.LightGreen
        End If

        CrearFiltro()

        CargarDatos(filtro)

       

    End Sub

    Private Sub dgvOraciones_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOraciones.CellContentClick

        Clipboard.SetText(dgvOraciones.CurrentRow.Cells(0).Value.ToString())

    End Sub

    Private Sub FrmOraciones_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick

        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Clipboard.SetText(txtBuscar.Text)
            txtBuscar.Text = ""
            txtBuscar.BackColor = Color.Beige

        End If

    End Sub

    Private Sub FrmOraciones_MouseHover(sender As Object, e As System.EventArgs) Handles Me.MouseHover
        'SetCursorPos(100, 200) ' Mueve el cursor a las coordenadas (100, 200)


        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0) ' Simula un clic del mouse
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
        Me.ForeColor = Color.Black
        txtBuscar.BackColor = Color.LightGreen

    End Sub

    Private Sub FrmOraciones_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        ' Mover el cursor a una posición específica antes de hacer clic
        'SetCursorPos(1414, 117)

        'Me.Focus()
        ' CmdCerrar.InvokeOnClick(CmdCerrar, EventArgs.Empty)
        'Sub MoveMouseTo(x As Integer, y As Integer)
        ' SetCursorPos(0, 0)
        ' End Sub

        txtBuscar.Focus()
        ' txtBuscar.Text = "-"

    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click


    End Sub

    Private Sub Label2_MouseHover(sender As Object, e As System.EventArgs) Handles Label2.MouseHover

        If txtBuscar.Text = "" Then Exit Sub
        Clipboard.SetText(txtBuscar.Text)
        txtBuscar.Text = ""

    End Sub

    Private Sub cmdPalabras_Click(sender As System.Object, e As System.EventArgs) Handles cmdPalabras.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim Id, j As Integer
        Dim sqlstring As String
        Dim i As Integer

        ' Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter

        Dim reemplazos As Integer

        _comando.Connection.Open()
        Dim celda As DataGridViewCell

        ' Obtén el valor actual del texto y reemplaza el caracter
        Dim valorActual As String
        Dim valorModificado As String

        pbavance.Maximum = dgvOraciones.Rows.Count
        pbavance.Value = 0
        reemplazos = 0

        Dim frase As String = "Esta es una frase de ejemplo."
        Dim numeroDePalabras As Integer

        For Each RW As DataGridViewRow In dgvOraciones.Rows

            Id = RW.Cells(0).Value.ToString()
            'Obtén la celda
            celda = RW.Cells(3)

            frase = celda.Value.ToString() ' Obtén el valor actual del texto 

            Dim palabras() As String = frase.Split({" "}, StringSplitOptions.RemoveEmptyEntries) ' Divide la frase en un array de palabras usando el espacio como separador

            sqlstring = "INSERT INTO Oraciones_Det (IdOracion, IdPalabra, Palabra) values (@IdOracion, '0', @Palabra)"

            _comando.CommandText = sqlstring

            For Each p In palabras

                _comando.Parameters.Clear()
                _comando.Parameters.AddWithValue("IdOracion", Id)
                _comando.Parameters.AddWithValue("Palabra", p)

                i = _comando.ExecuteNonQuery

            Next

            'numeroDePalabras = palabras.Length ' Obtiene la cantidad de palabras
            
            'sqlstring = " UPDATE Oraciones Set Palabras = @Palabras "
            'sqlstring = sqlstring & " WHERE (Id = '" & Id & "')"

            ' _comando.CommandText = sqlstring

            ' _comando.Parameters.Clear()
            ' _comando.Parameters.AddWithValue("@Palabras", numeroDePalabras)

            'Try
            '    j = _comando.ExecuteNonQuery
            '    reemplazos += 1

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try

            pbavance.Value = pbavance.Value + 1

        Next
        _comando.Connection.Close()

        MsgBox("Se realizaron " & reemplazos & " reemplazos")

       




    End Sub

    Private Sub cmdPDF_Click(sender As System.Object, e As System.EventArgs) Handles cmdPDF.Click
        Dim oWord As Word.Application
        Dim oDoc As Word.Document

        Try
            oWord = New Word.Application()
            oWord.Visible = True ' Set to True to see Word open, False to run in background
            oDoc = oWord.Documents.Add()
            ' ... (rest of the code)
        Catch ex As Exception
            MessageBox.Show("Error exporting to Word: " & ex.Message)
        Finally
            ' Clean up Word objects (release COM objects)
            'If Not oDoc Is Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc)
            'If Not oWord Is Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord)
            'oDoc = Nothing
            'oWord = Nothing
        End Try


        ' ... (inside the Try block)
        Dim r As Integer, c As Integer
        Dim oTable As Word.Table

        ' Add a new table to the document
        oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, dgvOraciones.RowCount, dgvOraciones.ColumnCount)
        oTable.Range.ParagraphFormat.SpaceAfter = 6 ' Optional: Add spacing

        ' Add column headers
        For c = 0 To 4 'dgvOraciones.ColumnCount - 1
            oTable.Cell(1, c + 1).Range.Text = dgvOraciones.Columns(c).HeaderText
            oTable.Cell(1, c + 1).Range.Font.Bold = True ' Optional: Make headers bold
        Next
        pbavance.Maximum = dgvOraciones.RowCount + 1
        ' Populate table with DataGridView data
        For r = 0 To dgvOraciones.RowCount - 2 ' Exclude the potential new row in DataGridView
            For c = 0 To 4
                oTable.Cell(r + 2, c + 1).Range.Text = dgvOraciones(c, r).Value.ToString()
            Next
            pbavance.Value += 1

        Next
        ' ... (rest of the code)


    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub cmdAgregarADialogo_Click(sender As System.Object, e As System.EventArgs) Handles cmdAgregarADialogo.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer

        Dim OracionEN As String
        Dim OracionES As String
        Dim SQL As String
        Dim IdCon As Integer
        Dim j As Integer
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
        Dim objDataReader As SqlDataReader
        Dim IdDet As Integer
        Dim descripcion As String
         
        Dim r As Integer, c As Integer
        Dim oTable As Word.Table
        Dim Enc_Id As Integer
        Dim OracionId As Integer

        sqlstring = ""
        descripcion = InputBox("Ingrese Descripcion")
        If descripcion = "" Then Exit Sub

        'Inserta Encabezado
        If Enc_Id = 0 Then
            Enc_Id = frmNewConversation.GuardarConversation(descripcion, "Presentacion")
        End If

        _comando.Connection.Open()

        For r = 0 To dgvOraciones.RowCount - 2 ' Exclude the potential new row in DataGridView

            'Detalle conversation
            sqlstring = "Insert into det_Conversation (Det_Orden, Con_Id, Det_Person)"
            sqlstring = sqlstring & " Values ('" & j & "', '" & Enc_Id & "', '0')"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
            End Try

            Try
                If i > 0 Then
                    SQL = "SELECT @@IDENTITY FROM det_Conversation"
                    _comando = New SqlCommand(SQL, _comando.Connection)
                    Dim value As Object = _comando.ExecuteScalar
                    IdDet = value.ToString
                End If
            Catch ex As Exception
            End Try

            'Inserta Dialogo
            For t = 0 To 1

                OracionId = dgvOraciones(0, r + t).Value.ToString()

                sqlstring = "Insert into Dialogos (OracionId, Orden, DetConversacion)"
                sqlstring = sqlstring & " Values ('" & OracionId & "', @Orden, '" & IdDet & "')"
                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Orden", t)

                Try
                    i = _comando.ExecuteNonQuery
                Catch ex As Exception
                Finally

                End Try


            Next t
            r += 1
            j = j + 1

        Next r
        _comando.Connection.Close()

        MessageBox.Show("Completed !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New frmEscenas

        AddOwnedForm(frm)

        frm.Id = Enc_Id
        frm.lblTitulo.Text = descripcion
        frm.CargarConversation(Id)
        frm.Show()


        txtBuscar.Text = ""


    End Sub

    Private Sub cmdActualizarEstructura_Click(sender As System.Object, e As System.EventArgs) Handles cmdActualizarEstructura.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim _IdOracion As Integer
        Dim i As Integer

        _comando.Connection.Open()

        For r = 0 To dgvOraciones.RowCount - 2 ' Exclude the potential new row in DataGridView

            _IdOracion = dgvOraciones(0, r).Value.ToString()

            sqlstring = "INSERT INTO Estructuras_Det (IdEst, OracionId) values (@IdEst, @OracionId)"
            _comando.CommandText = sqlstring

            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("IdEst", IdEst)
            _comando.Parameters.AddWithValue("OracionId", _IdOracion)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
            End Try
             
        Next
        _comando.Connection.Close()
        MsgBox("Completado")


    End Sub

    Private Sub dgvOraciones_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvOraciones.MouseClick
        
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Dim IdOracion As Integer
            IdOracion = dgvOraciones.CurrentRow.Cells(0).Value.ToString()

            Try
                'Player.settings.rate = 1
                Player.URL = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"
                ' Player.URL = ruta & "AndiesJob.mp3"
                Player.controls.play()
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub cmdUpdateTipo_Click(sender As System.Object, e As System.EventArgs) Handles cmdUpdateTipo.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim j As Integer

        Dim r As Integer

        Dim OracionId As Integer


        _comando.Connection.Open()

        For r = 0 To dgvOraciones.RowCount - 1 ' Exclude the potential new row in DataGridView


            OracionId = dgvOraciones(0, r).Value.ToString()

            sqlstring = " UPDATE Oraciones Set EsRespuesta = @EsRespuesta, IMG =  @IMG "
            sqlstring = sqlstring & " WHERE (Id = '" & OracionId & "')"
            _comando.CommandText = sqlstring

            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@EsRespuesta", "Q")
            _comando.Parameters.AddWithValue("@IMG", "Pregunta1.png")

            Try
                j = _comando.ExecuteNonQuery
            Catch ex As Exception
            End Try

        Next r
        _comando.Connection.Close()

        MessageBox.Show("Completed !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub

    Private Sub cmdFiltroEscuchados_Click(sender As System.Object, e As System.EventArgs) Handles cmdFiltroEscuchados.Click

        If cmdFiltroEscuchados.Text = "Mas escuchados" Then
            cmdFiltroEscuchados.Text = "Menos escuchados"
            cmdFiltroEscuchados.BackColor = Color.LightGray
        Else
            cmdFiltroEscuchados.Text = "Mas escuchados"
            cmdFiltroEscuchados.BackColor = Color.LightGreen
        End If

        CrearFiltro()

        CargarDatos(filtro)

    End Sub

    Private Sub cmdIPA_Click(sender As System.Object, e As System.EventArgs) Handles cmdIPA.Click

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim Id, j As Integer
        Dim sqlstring As String
        Dim i As Integer
        Dim reemplazos As Integer

        Dim celda As DataGridViewCell

        Dim valorActual As String
        Dim valorModificado As String

        pbavance.Maximum = dgvOraciones.Rows.Count
        pbavance.Value = 0

        Dim frase As String = ""
        Dim numeroDePalabras As Integer
        Dim dt As New DataTable

        sqlstring = "Select  Id, TextoPlano from Oraciones "

        _comando.CommandText = sqlstring

        Try
            _comando.Connection.Open()

            da.SelectCommand = _comando
            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        pbavance.Maximum = dt.Rows.Count + 1

        For Each RW In dt.Rows

            Id = RW.item(0)

            'celda = RW.Cells(3) 'Obtén la celda

            frase = RW.item(1) ' Obtén el valor actual del texto 

            Dim palabras() As String = frase.Split({" "}, StringSplitOptions.RemoveEmptyEntries) ' Divide la frase en un array de palabras usando el espacio como separador
            Dim IPA As String = ""

            For Each p In palabras

                sqlstring = " SELECT         Concepto, IPA"
                sqlstring = sqlstring & " FROM            Conceptos"
                sqlstring = sqlstring & " WHERE  Concepto = @Concepto"
                _comando.CommandText = sqlstring

                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Concepto", p)

                Dim objDataReader As SqlDataReader
                objDataReader = _comando.ExecuteReader

                If objDataReader.HasRows Then

                    objDataReader.Read()

                    IPA = IPA & " " & objDataReader(1)
                Else
                    IPA = IPA & " " & p

                End If

                objDataReader.Close()

            Next

            If IPA <> "" Then
                sqlstring = " UPDATE Oraciones Set IPA = @IPA"
                sqlstring = sqlstring & " WHERE (Id = '" & Id & "')"
                _comando.CommandText = sqlstring

                _comando.Parameters.Clear()
                _comando.Parameters.AddWithValue("@IPA", IPA)

                Try
                    j = _comando.ExecuteNonQuery
                Catch ex As Exception
                End Try
            End If
            'pbavance.Value = pbavance.Value + 1

        Next
        _comando.Connection.Close()

        MsgBox("Se realizaron " & reemplazos & " reemplazos")

    End Sub

    Private Sub CargarSugerencia(param)

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer
        ' Dim param As String
        Dim firstIndex As Integer

        ' CrearFiltro()

        If filtro = Nothing Then Exit Sub
        Dim IdGrupo As Integer

        If cboGrupo.Text = "ALL" Then
        Else
            IdGrupo = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

        End If

        sqlstring = "Select  Id, orden,  Audio, STL,  TextoPlano, Traduccion, Estatus, GrupoO, TemaDetectado"
        '¿ sqlstring = sqlstring & "Oraciones.foco, Oraciones.Palabras, Oraciones.Reproduccion"
        sqlstring = sqlstring & " FROM            Oraciones "
        sqlstring = sqlstring & " Where GrupoO='" & IdGrupo & "'"


        ' sqlstring = sqlstring & param

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
        n = dt.Rows.Count
        If n = 0 Then Exit Sub
        '''''''''
        'CONVERTIR DATATABLE A JSON
        Dim lista As New List(Of Dictionary(Of String, Object))

        For Each row As DataRow In dt.Rows

            Dim dict As New Dictionary(Of String, Object)

            For Each col As DataColumn In dt.Columns
                dict(col.ColumnName) = row(col)
            Next

            lista.Add(dict)
        Next
        n = dt.Rows.Count

        Dim serializer As New JavaScriptSerializer()

        Dim json As String = serializer.Serialize(lista)
        'MessageBox.Show(json)

        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\Legacy\Programas\Voz_Natural\backend4.py"""
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.RedirectStandardInput = True
        psi.RedirectStandardError = True
        psi.CreateNoWindow = True

        Dim proc As New Process()
        proc.StartInfo = psi
        proc.EnableRaisingEvents = True

        AddHandler proc.ErrorDataReceived, AddressOf PythonOutputHandler

        proc.Start()

        proc.BeginErrorReadLine()   ' 🔥 empieza a escuchar stderr

        proc.StandardInput.Write(json)
        proc.StandardInput.Close()

        Dim resultadoJson As String = proc.StandardOutput.ReadToEnd()

        proc.WaitForExit()

        'If errorPython <> "" Then
        '    MessageBox.Show("ERROR PYTHON: " & errorPython)
        'End If

        '' MessageBox.Show("RESULTADO: " & resultadoJson)
        'MessageBox.Show("Temrinado: ")


        Dim listaOrdenada =
      serializer.Deserialize(Of List(Of Dictionary(Of String, Object)))(resultadoJson)

        'Dim dtOrdenado As New DataTable()


        'If listaOrdenada.Count > 0 Then
        '    For Each key In listaOrdenada(0).Keys
        '        dtOrdenado.Columns.Add(key)
        '    Next
        'End If

        'For Each item In listaOrdenada
        '    Dim newRow = dtOrdenado.NewRow()
        '    For Each key In item.Keys
        '        newRow(key) = item(key)
        '    Next
        '    dtOrdenado.Rows.Add(newRow)
        'Next


        ' 4. Cargar en ListView
        ' -----------------------------------------

        lsvSugerencia.Items.Clear()

        'Dim itm As New ListViewItem
        'Dim j As Integer
        'n = dtOrdenado.Rows.Count

        'Do While i <= n - 1

        '    itm = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

        '    itm.UseItemStyleForSubItems = False

        '    Try
        '        itm.SubItems.Add(dtOrdenado.Rows(i).Item(0))
        '        ' itm.SubItems.Add(dtOrdenado.Rows(i).Item(7))
        '        '  itm.SubItems.Add(dtOrdenado.Rows(i).Item(4))
        '        If Not IsDBNull(dtOrdenado.Rows(i).Item(7)) Then
        '            itm.SubItems.Add(dtOrdenado.Rows(i).Item(7))
        '        End If

        '        If Not IsDBNull(dtOrdenado.Rows(i).Item(8)) Then
        '            itm.SubItems.Add(dtOrdenado.Rows(i).Item(8))
        '        End If


        '        lsvSugerencia.Items.Add(itm)      'Agrego el item a la colección de listViewItem's de ListView1

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try


        '    i = i + 1
        '    j = j + 1

        'Loop

    End Sub

    Private Sub PythonOutputHandler(sender As Object, e As DataReceivedEventArgs)
        If e.Data IsNot Nothing Then
            Me.Invoke(Sub()
                          Debug.Print(e.Data)
                          ' O puedes actualizar un label:
                          ' lblStatus.Text = e.Data
                      End Sub)
        End If
    End Sub

    Private Sub cboTema_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTema.SelectedIndexChanged
        Dim _tema As String
        Dim sqlstring As String = ""

        If Me.cboTema.Text = "" Then Exit Sub
        ' If Me.cboGrupo.SelectedIndex = -1 Then Exit Sub
        ' If IdGrupo = 0 Then Exit Sub

        _tema = Trim(cboTema.Text)

        ' CrearFiltro()

        Dim _filtro As String
        _filtro = " Where Oraciones.Tema='" & cboTema.Text & "'"
        CargarDatos(_filtro)

        ' CargarSugerencia("")
    End Sub
End Class