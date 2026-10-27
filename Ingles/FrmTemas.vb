Imports System.Data
Imports System.Data.SqlClient
'Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Drawing


'Imports System.Data.Sql
'Imports System.Data.SqlClient
Public Class FrmTemas
    'Public conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\legacy\Ingles\Ingles.accdb")
    'Public conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Program Files (x86)\Rosslare\GS-01 Digitool Reports\main.mdb")

    'Public instruccion As New 
    Public contenedor As String
    Public carpeta As String
    Public sqlstring As String
    Public maxColumna As Integer
    Public filtro As String
    Public Shared IdEnc As Integer
    Public consulta As String
    Public rowcount As Integer
    Public buscar As String
    Public CurrentNode As Integer = 0
    Public ItemSelected As Integer = 5
    Public ColorBeige As Color = System.Drawing.Color.FromArgb(253, 239, 202) 'beige
    Public oColorAmarillo As Color = System.Drawing.Color.FromArgb(254, 254, 180) 'amarillo

    Public oColorVerde As Color = System.Drawing.Color.FromArgb(209, 235, 222) 'verde
    Public Color4 As Color = System.Drawing.Color.FromArgb(31, 92, 60) 'verde fuerte

    Public oColorSalmon As Color = System.Drawing.Color.FromArgb(254, 180, 180) 'salmon
    Public Color6 As Color = System.Drawing.Color.FromArgb(19, 49, 57)
    Public CurrRowDgvTemas As Integer

    Private dataSetArbol As System.Data.DataSet
    Private dtTabla As New DataTable 'Creo una nueva tabla
    Public IdTema As Integer
    Dim objWord As Word.Application
       

#Region "Inicio"
    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim dt As New DataTable
        '  Dim da As New OleDbDataAdapter
        Dim da As New SqlDataAdapter

        sqlstring = "select * from  Grupos_Temas "
        sqlstring = sqlstring & " ORDER By Grupos_Temas ASC"


        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            Me.cboTipos.DataSource = dt
            Me.cboTipos.ValueMember = "Id"
            Me.cboTipos.DisplayMember = "Grupos_Temas"
            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        ' objWord = CreateObject("Word.Application")
        objWord = New Word.Application

    End Sub

    Public Sub CargarSubtemas(param)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter


            Try
                _comando.CommandText = param
                _comando.Connection.Open()

                da.SelectCommand = _comando

                da.Fill(dt)
 
                _comando.Connection.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try

            maxColumna = dt.Columns.Count

        DataGridView1.DataSource = dt

        DataGridView1.Columns(0).Visible = True

        DataGridView1.Columns(0).Width = 60
        'DataGridView1.Columns(1).Visible = True
        DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Columns(1).Width = 50

        DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False
        ' DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).Visible = False

        DataGridView1.Columns(9).DefaultCellStyle.Format = "0 %"
        DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DataGridView1.Columns(10).Width = 100
        ' DataGridView1.Columns(10).Visible = True
        ' DataGridView1.Columns(11).Visible = False
        ' DataGridView1.Columns(12).Visible = False

        Dim n As Integer
            n = dt.Rows.Count

            ProgressBar1.Maximum = 100
            ProgressBar1.Value = 0

            Dim i As Integer
            Dim avance As Integer = 0

        Try
            avance = avance / n

            ProgressBar1.Value = avance

            ' Porcentaje.Text = Math.Round((ProgressBar1.Value / n), 1) * 100 & "%"
            Porcentaje.Text = (avance) & "%"

        Catch ex As Exception
        End Try

            Try
            DataGridView1.Focus()
                DataGridView1.CurrentCell = DataGridView1(2, ItemSelected)
            Catch ex As Exception
        End Try


            'Nodos
            Dim IdGrupo As Integer
            IdGrupo = Me.cboTipos.SelectedValue
            dtTabla = New DataTable 'Creo una nueva tabla

            Try

            sqlstring = " SELECT s.Id, s.orden, s.Subtema, s.estatus,t.Grupo, g.Grupos_Temas, s.TemaID, s.Estado, s.secuencia, s.avance, s.Cuenta, s.duracion, s.nodo,"
            sqlstring = sqlstring & " Grupos_Temas.Id, s.Complemento" ', Subtemas.orden, Subtemas.Subtema, Subtemas.Cuenta,  Subtemas.TemaID"
            sqlstring = sqlstring & " FROM Subtemas s INNER JOIN Temas t ON s.TemaID = t.Id INNER JOIN Grupos_Temas g ON t.Grupo = g.Id "
                sqlstring = sqlstring & " Where Grupos_Temas.Id= " & IdGrupo

                If optIdNodo.Checked = True Then
                sqlstring = sqlstring & " Order by s.nodo ASC"
                Else
                sqlstring = sqlstring & " Order by s.Subtema ASC"

                End If

                _comando.CommandText = sqlstring
                _comando.Connection.Open()

                da.SelectCommand = _comando

                da.Fill(dtTabla)

                _comando.Connection.Close()

            TreeView1.ImageList = ImageList1

            Me.TreeView1.Nodes.Clear()

            Dim nodo1 As Integer

            Dim test As String

                CrearNodosDelPadre(0, Nothing) 'Llamo al proceso que llena el treeview Catch ex As Exception
            Catch
        End Try

            TreeView1.CollapseAll()

            Try
                TreeView1.Nodes(CurrentNode).Expand()
                TreeView1.Nodes(CurrentNode).EnsureVisible()

            Catch ex As Exception
            End Try




    End Sub

    Private Sub CrearNodosDelPadre(ByVal indicePadre As Integer, ByVal nodePadre As TreeNode)

        Dim dataViewHijos As DataView

        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(dtTabla)

        'Filtra por cada padre

        'Identificador_Padre
        dataViewHijos.RowFilter = dtTabla.Columns("Secuencia").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New TreeNode
            'nuevoNodo.Text = dataRowCurrent("Subtema").ToString().Trim()

            '   Console.WriteLine(dataRowCurrent("Complemento").ToString().Trim())

            'Descripción o texto del nodo
            nuevoNodo.Text = dataRowCurrent("Subtema").ToString().Trim()

            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nuevoNodo.Name = dataRowCurrent("Id").ToString().Trim()

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nuevoNodo.Tag = dataRowCurrent("Secuencia").ToString().Trim()



            If dataRowCurrent("Complemento").ToString() = "S" Then
                nuevoNodo.ForeColor = Color.DarkBlue

            Else
                'nuevoNodo.ForeColor = Color.AliceBlue

            End If
            'nuevoNodo. = dataRowCurrent("Secuencia").ToString().Trim()
            'node.Nodes.Add(SubDirs(x)).Tag = e.Node.Tag & SubDirs(x) & "\"
            'If e.Node.Parent Is Nothing Then
            '    nuevoNodo.ImageIndex = 1
            '    node.SelectedImageIndex = 0
            'End If

            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TreeView1.Nodes.Add(nuevoNodo)
                nuevoNodo.ImageIndex = 1

            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
                nuevoNodo.ImageIndex = 2

            End If

            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            'Identificador_Nodo
            CrearNodosDelPadre(Int32.Parse(dataRowCurrent("Id").ToString()), nuevoNodo)

        Next dataRowCurrent

        If optExpand.Checked = True Then
            TreeView1.ExpandAll()
        Else
            TreeView1.CollapseAll()

        End If


        TreeView1.Nodes(0).EnsureVisible()


        ' TreeView1.Nodes(1).TreeView.
        'TreeView1.BeginUpdate()
        '  TreeView1.SelectedNode = TreeView1.Nodes(1)
        ' TreeView1.Focus()
        ' TreeView1.Scrollable.
        ' TreeView1.Nodes(1).EnsureVisible()

    End Sub

#End Region

#Region "Todo lo demas"
  

    Public Function AbrirConexion()
        'Try
        '    conexion.Open()
        '    If conexion.State = 1 Then
        '        Return True
        '    Else
        '        Return False

        '    End If

        'Catch ex As Exception
        '    Return False

        'End Try


    End Function

    Private Sub dgvEncDatos_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        'IdTema = dgvEncDatos.CurrentRow.Cells(0).Value.ToString()

        'txtID.Text = dgvEncDatos.CurrentRow.Cells(0).Value.ToString()
        '  txtDescripcion.Text = dgvEncDatos.CurrentRow.Cells(1).Value.ToString()
    End Sub

    Private Sub dgvEncDatos_DoubleClick(sender As Object, e As System.EventArgs)
        FrmAvance.Show()
        ' FrmAvance.lblDescripcion.Text = dgvEncDatos.CurrentRow.Cells(0).Value.ToString()

    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim sqlstring As String
        Dim i As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim grupoId As Integer


        grupoId = Me.cboTipos.SelectedValue

        ' sqlstring = "Insert into Grupos_oracion (Grupo, Orden, estatus, Nivel)"
        'sqlstring = sqlstring & " Values ('" & txtDescripcion.Text & "',  '" & txtOrden.Text & "', '1', '" & txtNivel.Text & "')"
        sqlstring = "Insert into Temas (Tema, Grupo, estatus)"
        sqlstring = sqlstring & " Values ('" & txtDescripcion.Text & "',  '" & grupoId & "', '1')"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        Try
            i = _comando.ExecuteNonQuery

            If i > 0 Then
                MsgBox("se guardo")

            Else
                MsgBox("No se guardo")
            End If

        Catch ex As Exception

        End Try






    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim sqlstring As String
        ' Dim cmd As New OleDbCommand
        Dim i As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = "Update Temas SET Tema = @Tema, Orden=@Orden Where ID=@id"


        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()


            _comando.Parameters.AddWithValue("@Tema", txtDescripcion.Text)
            _comando.Parameters.AddWithValue("@Orden", txtOrden.Text)
            _comando.Parameters.AddWithValue("@id", txtId.Text)


            i = _comando.ExecuteNonQuery
            If i > 0 Then
            Else
                MsgBox("No se actualizo")
            End If

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub

    



    'Private Sub dgvEncDatos_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvEncDatos.SelectionChanged
    'Dim ruta, img As String

    ' img = dgvEncDatos.CurrentRow.Cells(3).Value.ToString().ToString()
    'ruta = "C:\Users\jolvera.SSWTECHNOLOGIES\OneDrive - SSW Holding Company, LLC\Pictures\iconos\"
    '   Try
    '   PictureBox1.Image = Image.FromFile(ruta & img)

    ' Catch ex As Exception

    ' End Try
    ' End Sub


    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cboGrupoTema_LostFocus(sender As Object, e As System.EventArgs) Handles cboTipos.LostFocus
        Dim IdTipo As Integer

        If Me.cboTipos.SelectedIndex < 1 Then Exit Sub


        IdTipo = Me.cboTipos.SelectedValue

        CargarGrupos(IdTipo)

    End Sub


    Private Sub cboTipos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipos.SelectedIndexChanged

        If Me.cboTipos.Text = "" Then Exit Sub
        carpeta = Me.cboTipos.Text
        'IdTema = Me.cboGrupos.SelectedValue

        ' CargarSubtemas(IdTipo)

       

    End Sub

    Public Sub CargarGrupos(IdTipo)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter


        Try

            sqlstring = "select * from  Temas "
            sqlstring = sqlstring & " Where Grupo=" & IdTipo
            sqlstring = sqlstring & " ORDER By orden ASC"


            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            Me.cboGrupos.DataSource = dt
            Me.cboGrupos.ValueMember = "Id"
            Me.cboGrupos.DisplayMember = "Tema"

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try



        If cboTipos.Text = "" Then Exit Sub
        If cboTipos.SelectedIndex < 1 Then Exit Sub




    End Sub

    Private Sub CargarSubtemasxCanal(GrupoId)
        Dim sqlstring As String

        Dim IdGrupo As Integer
        
        Try

        Catch ex As Exception
            
        End Try

        'sqlstring = " SELECT Subtemas.Id, Subtemas.orden, Subtemas.Subtema,   Subtemas.estatus,Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado, Subtemas.secuencia,Subtemas.Cuenta, Subtemas.Cuenta as Avance,Subtemas.duracion, Subtemas.archivo,"
        'sqlstring = sqlstring & " Grupos_Temas.Id" ', Subtemas.orden, Subtemas.Subtema, Subtemas.Cuenta,  Subtemas.TemaID"
        'sqlstring = sqlstring & " FROM (Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id) INNER JOIN Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id "

        sqlstring = "  SELECT        Subtemas.Id, Subtemas.Orden, Subtemas.Subtema, Subtemas.estatus, Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado, Subtemas.Secuencia, Enc_conversation.Con_avance as Avance, Subtemas.Duracion, "
        sqlstring = sqlstring & "               Subtemas.archivo, Grupos_Temas.Id AS Expr1, Enc_Conversation.Con_Id"
        sqlstring = sqlstring & " FROM            Subtemas INNER JOIN"
        sqlstring = sqlstring & "         Temas ON Subtemas.TemaID = Temas.Id INNER JOIN"
        sqlstring = sqlstring & "         Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id LEFT JOIN"
        sqlstring = sqlstring & "         Enc_Conversation ON Subtemas.Id = Enc_Conversation.SubtemaId"
        ' sqlstring = sqlstring & " Where TemaID= " & IdTema
        sqlstring = sqlstring & " Where   Grupos_Temas.Id= " & GrupoId

        If optId.Checked = True Then
            sqlstring = sqlstring & " ORDER BY Subtemas.orden ASC"
        Else
            sqlstring = sqlstring & " ORDER BY Subtemas.Subtema ASC"
        End If

        txtId.Text = IdTema
        txtDescripcion.Text = cboGrupos.Text
        txtOrden.Text = cboGrupos.SelectedIndex.ToString()

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Try


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

            maxColumna = dt.Rows.Count

            DataGridView1.DataSource = dt

            ' DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = True

            ' DataGridView1.Columns(4).Visible = False
            ' DataGridView1.Columns(5).Visible = False
            ' DataGridView1.Columns(6).Visible = False
            ' DataGridView1.Columns(7).Visible = False
            ' DataGridView1.Columns(8).Visible = False
            ' DataGridView1.Columns(10).Visible = False
            ' DataGridView1.Columns(10).Width = 0

            DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataGridView1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'DataGridView1.Columns(13).Visible = False


            Dim n As Integer
            n = dt.Rows.Count

            ProgressBar1.Maximum = 100
            ProgressBar1.Value = 0

            Dim i As Integer
            Dim avance As Integer = 0

            Do While i < n
                If dt.Rows(i).Item(10) < 100 Then
                    'DataGridView1.Columns(9).DefaultCellStyle.BackColor = Color.Yellow
                End If
                i = i + 1

            Loop

            Try
                avance = avance / n

                ProgressBar1.Value = avance

                ' Porcentaje.Text = Math.Round((ProgressBar1.Value / n), 1) * 100 & "%"
                Porcentaje.Text = (avance) & "%"


            Catch ex As Exception

            End Try

            Try

                DataGridView1.Focus()
                DataGridView1.CurrentCell = DataGridView1(2, ItemSelected)
            Catch ex As Exception

            End Try


        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub cboGrupos_LostFocus(sender As Object, e As System.EventArgs) Handles cboGrupos.LostFocus

        ''If Me.cboTipos.Text = "" Then Exit Sub
        'If Me.cboGrupos.Text = "" Then Exit Sub
        'IdTema = Me.cboGrupos.SelectedValue

        'CargarSubtemas(IdTema)
    End Sub


    Private Sub MenuStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub


    Private Sub cboGrupos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupos.SelectedIndexChanged

        Dim IdGrupo As Integer
         
        If Me.cboGrupos.Text = "" Then Exit Sub
         
        Try
            IdTema = Me.cboGrupos.SelectedValue

            filtro = "  SELECT        s.Id, s.Orden, s.Subtema, s.estatus, t.Grupo, g.Grupos_Temas, s.TemaID, s.Estado, s.Secuencia, s.Avance, s.Duracion, "
            filtro = filtro & "               s.archivo, g.Id AS GrupoId, s.Con_Id"
            filtro = filtro & " FROM            Subtemas s INNER JOIN"
            filtro = filtro & "         Temas  t ON s.TemaID = t.Id INNER JOIN"
            filtro = filtro & "         Grupos_Temas g ON t.Grupo = g.Id "
            ' filtro = filtro & "         Enc_Conversation e ON s.Id = e.SubtemaId"
            filtro = filtro & " Where TemaID= " & IdTema

            If optId.Checked = True Then
                filtro = filtro & " ORDER BY s.orden ASC"
            Else
                filtro = filtro & " ORDER BY s.Subtema ASC"
            End If

            CargarSubtemas(filtro)

            txtId.Text = IdTema

            txtDescripcion.Text = cboGrupos.Text

            txtOrden.Text = cboGrupos.SelectedIndex.ToString()

        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim SQL As String
        'Dim cmd As New OleDbCommand

        Dim dt As New DataTable
        'Dim da As New OleDbDataAdapter
        Try
            ' conexion.Open()

            'SQL = " SELECT Subtemas.Id, Subtemas.Subtema, Subtemas.estatus, Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.estado"
            SQL = " SELECT Subtemas.orden, Subtemas.Subtema, Subtemas.estatus,Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado ,Subtemas.Id"

            SQL = SQL & " FROM (Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id) INNER JOIN Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id "
            SQL = SQL & " ORDER BY Subtemas.Subtema ASC"

            'cmd.Connection = conexion
            'cmd.CommandText = SQL
            'da.SelectCommand = cmd

            ' da.Fill(dt)

            'dgvListaDatos.DataSource = dt


            'dgvListaDatos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvListaDatos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvListaDatos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvListaDatos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvListaDatos.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells



        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            'conexion.Close()

        End Try
    End Sub



    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs)
        'CargarSubtemas(1)
    End Sub


    Private Sub dgvSubtemas_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)

    End Sub

    Private Sub dgvListaDatos_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvListaDatos_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvListaDatos_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)

    End Sub


    Private Sub CmdAbrir_Click(sender As System.Object, e As System.EventArgs) Handles CmdAbrir.Click
        Dim documentPath As String
        Dim archivo As String
        Dim Resp, IdSubTema As Integer


        archivo = Trim(DataGridView1.CurrentRow.Cells(2).Value.ToString())
       
        If archivo = "" Then Exit Sub

      
        Dim RutaArchivo As String

        RutaArchivo = "C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".docx"
        Try
            If System.IO.File.Exists(RutaArchivo) Then

                objWord.Documents.Open(RutaArchivo)
                objWord.Visible = True

                Resp = MsgBox("Registrar curso?", vbOKCancel + vbQuestion)
                If Resp = 1 Then
                    'bitacora(IdSubTema)
                End If

            Else

                Resp = MsgBox("¿ Crear Nuevo ?", MsgBoxStyle.OkCancel)

                If Resp = 1 Then

                    objWord = New Microsoft.Office.Interop.Word.Application

                    Dim objDoc As Word.Document

                    objDoc = objWord.Documents.Add
                    'Insert some text in document
                    Dim objPara As Word.Paragraph
                    objPara = objDoc.Content.Paragraphs.Add
                    objPara.Range.Text = archivo
                    objPara.Range.Font.Bold = True
                    objPara.Format.SpaceAfter = 30
                    objPara.Range.InsertParagraphAfter()
                    'objWord.Documents.Save("Test")
                    objWord.ActiveDocument.SaveAs(FileName:="" & "C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".docx")
                    ' objWord.SaveToFile("WordDocument.docx",)
                Else
                    MsgBox("No Creado")
                End If

            End If



           

        Catch ex As Exception
           



        End Try
    End Sub

    Public Sub bitacora(Id)

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim fechaActual As String

        'sqlstring = "select * from  SubTemas "
        '  mifecha = Format(Now, "dd/mm/yyyy hh:mm:ss")
        fechaActual = Format(Now, "dd-MM-yyyy hh:mm")
        sqlstring = "insert into Bitacora (SubtemaId, fecha) values ('" & Id & "',  '" & fechaActual & "')"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()
        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                MsgBox("se registro en Bitacora")

            Else
                MsgBox("No se guardo")
            End If

            ' CrearControles()


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try





    End Sub

    Private Sub txtBuscar_LocationChanged(sender As Object, e As System.EventArgs) Handles txtBuscar.LocationChanged

    End Sub

    Private Sub txtBuscar_LostFocus(sender As Object, e As System.EventArgs) Handles txtBuscar.LostFocus
        ' Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String = ""
        ' Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
        ' Dim da As New OleDbDataAdapter
        Dim i, n As Integer
        Dim IdGrupo As Integer
        'Try
        ' conexion.Open()
        'lstOraciones.Items.Clear()

        buscar = Me.txtBuscar.Text
        If Trim(buscar) = "" Then Exit Sub
        IdTema = Me.cboGrupos.SelectedValue
        IdGrupo = Me.cboTipos.SelectedValue



        filtro = " SELECT Subtemas.Id, Subtemas.orden, Subtemas.Subtema, Subtemas.estatus,Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado, Subtemas.secuencia,Subtemas.Cuenta, Subtemas.Cuenta as Avance,"
        filtro = filtro & " Subtemas.duracion, Subtemas.archivo,Grupos_Temas.Id" ', Subtemas.orden, Subtemas.Subtema, Subtemas.Cuenta,  Subtemas.TemaID"
        filtro = filtro & " FROM (Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id) INNER JOIN Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id "
        filtro = filtro & " Where Subtema LIKE " & "'%" & buscar & "%'"
        filtro = filtro & " And Grupos_Temas.Id= " & IdGrupo
        'filtro = filtro & " ORDER BY Subtemas.Subtema ASC"

        If optId.Checked = True Then
            filtro = filtro & " ORDER BY Subtemas.orden ASC"

        Else
            filtro = filtro & " ORDER BY Subtemas.Subtema ASC"

        End If


        'filtro = " SELECT Id, Orden, Subtema,  TemaID, estatus, Descripcion,   Comentario, Campo1, Marcado, Avance, Nodo, Secuencia, Tipo, imp, Estado, Cuenta, duracion, archivo"
        '' filtro = " SELECT Subtemas.Id, Subtemas.orden, Subtemas.Subtema,   Subtemas.estatus, Subtemas.Estado, Subtemas.secuencia,Subtemas.Cuenta, Subtemas.Cuenta as Avance,Subtemas.duracion"

        'filtro = filtro & " FROM Subtemas"
        'filtro = filtro & " Where Subtema LIKE " & "'%" & buscar & "%'"
        'filtro = filtro & " And TemaID = " & IdTema
        'filtro = filtro & " ORDER BY Subtema ASC"


        CargarSubtemas(filtro)



    End Sub



    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs)
        Form1.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'CargarArbol()
    End Sub


    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged

        'txtBuscar.Text = ""
        'Dim sql As String
        '' Dim cmd As New OleDbCommand
        'Dim buscar As String

        'Dim dt As New DataTable
        '' Dim da As New OleDbDataAdapter

        ''Try
        '' conexion.Open()

        'buscar = Me.txtBuscar.Text

        'sql = " SELECT Subtemas.orden, Subtemas.Subtema, Subtemas.estatus,Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado ,Subtemas.Id"
        'sql = sql & " FROM (Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id) INNER JOIN Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id "
        'sql = sql & " Where Subtema like " & "'" & buscar & "'"
        'sql = sql & " ORDER BY Subtemas.orden ASC"


        '    Console.Write(sql)
        '    cmd.Connection = conexion
        '    cmd.CommandText = sql
        '    da.SelectCommand = cmd

        '    da.Fill(dt)

        '    ' dgvListaDatos.DataSource = dt

        'Catch ex As Exception

        '    MsgBox(ex.Message)
        'Finally
        '    conexion.Close()
        '  End Try

        'dgvListaDatos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvListaDatos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvListaDatos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvListaDatos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvListaDatos.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells



    End Sub



    Private Sub dgvTemas_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)



        ' TipoTicket = dgvOraciones.CurrentRow.Cells(11).Value.ToString()

        ' Dim filename As String = ""

        ' filename = 

        'rtb.SaveFile("C:\Legacy\Rtf\" & filename & ".rtf")
        ' Process.Start("explorer.exe", "C:\Legacy\Rtf\" & filename & ".rtf")

        '  MsgBox("Saved")
        'Status = "Saved"
        ' rtb.SaveFile("C:\Legacy\Rtf\" & filename & ".rtf")
        'MsgBox("Saved")



    End Sub

    Private Sub dgvTemas_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)

    End Sub

    Private Sub dgvTemas_DoubleClick(sender As Object, e As System.EventArgs)
        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New frmDetSubtema
        Dim filename As String = ""
        Dim Cuenta As Integer

        AddOwnedForm(frm)

        ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        'Id = DataGridView1.CurrentRow.Cells(0).Value.ToString()

        'If IsDBNull(dgvTemas.CurrentRow.Cells(9).Value) Then
        '    Cuenta = 0
        'Else
        '    Cuenta = dgvTemas.CurrentRow.Cells(9).Value.ToString()

        'End If

        '' frm.IdOracion = Id
        'frm.Id = Id
        'frm.carpeta = cboTipos.Text
        'frm.archivo = Trim(dgvTemas.CurrentRow.Cells(2).Value.ToString())
        'frm.CargarDatos(Id)
        'frm.ShowDialog()

        'actualizaCuenta(Id, Cuenta)

        '' IdSubTema =
        'Cuenta = Trim(TreeView1.SelectedNode.Name)
        ''Id = dgvTemas.CurrentRow.Cells(0).Value.ToString()
        Try

            '  Process.Start("explorer.exe", "C:\Legacy\Rtf\" & filename)


        Catch ex As Exception

        End Try
        'filename = dgvDocuments.CurrentRow.Cells(1).Value.ToString()
    End Sub

    Private Sub dgvTemas_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Public Sub actualizaCuenta(Id, Cuenta)

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim fechaActual As String


        'Actualizar Cuenta
        ' Cuenta = Cuenta + 1

        sqlstring = "Update Subtemas SET Cuenta=@Cuenta Where ID=@id"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()


            _comando.Parameters.AddWithValue("@Cuenta", Cuenta)
            _comando.Parameters.AddWithValue("@id", Id)


            i = _comando.ExecuteNonQuery
            If i > 0 Then
            Else
                MsgBox("No se actualizo")
            End If

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try




    End Sub

    Private Sub CmdNuevoTema_Click(sender As System.Object, e As System.EventArgs) Handles CmdNuevoTema.Click
        Dim sqlstring As String
        Dim i As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim TemaId As Integer


        TemaId = Me.cboGrupos.SelectedValue

        If Trim(txtSubtema.Text) = "" Then
            MsgBox("VAcio")
            Exit Sub
        End If

        sqlstring = "Insert into SubTemas (SubTema, TemaId, estatus, estado, nodo, cuenta, duracion, Complemento)"
        sqlstring = sqlstring & " Values ('" & txtSubtema.Text & "',  '" & TemaId & "', '1', 'A', '0', '0', @duracion, 'S' )"
        ' _comando.Parameters.Add("@duracion",)
        _comando.Parameters.AddWithValue("@duracion", Me.txtDuracion.Text)

        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        Try
            i = _comando.ExecuteNonQuery

            If i > 0 Then
                MsgBox("se guardo")
                CargarSubtemas(filtro)

                txtSubtema.Text = ""
                txtDuracion.Text = ""
            Else
                MsgBox("No se guardo")
            End If

        Catch ex As Exception

        End Try





    End Sub

    Private Sub Button2_Click_2(sender As System.Object, e As System.EventArgs)
        IdTema = Me.cboGrupos.SelectedValue

        filtro = " SELECT Subtemas.Id, Subtemas.orden, Subtemas.Subtema, Subtemas.estatus,Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado, Subtemas.secuencia,Subtemas.Cuenta, Subtemas.Cuenta as Avance,"
        filtro = filtro & " Subtemas.duracion, Subtemas.archivo " ', Subtemas.orden, Subtemas.Subtema, Subtemas.Cuenta,  Subtemas.TemaID"
        filtro = filtro & " FROM (Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id) INNER JOIN Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id "
        filtro = filtro & " Where TemaID= " & IdTema
        filtro = filtro & " ORDER BY Subtemas.Subtema ASC"


        CargarSubtemas(filtro)


    End Sub

    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button5_Click_1(sender As System.Object, e As System.EventArgs)
        Dim row As Integer = 5
        'dgv.Focus() = true;
        'dgv.CurrentCell = dgv[0,2];
        DataGridView1.Focus()
        DataGridView1.CurrentCell = DataGridView1(2, 20)

        'DataGridView1.Rows.Item(5).Selected = True
        ' DataGridView1.CurrentCell = DataGridViewCell(5, 5)
        ' DataGridView1.CurrentCell = 5
    End Sub

    Private Sub optId_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If IdTema = 0 Then Exit Sub

        If optId.Checked = True Then
            IdTema = Me.cboGrupos.SelectedValue

            filtro = " SELECT Subtemas.Id, Subtemas.orden, Subtemas.Subtema, Subtemas.estatus,Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado, Subtemas.secuencia,Subtemas.Cuenta, Subtemas.Cuenta as Avance,"
            filtro = filtro & " Subtemas.duracion, Subtemas.archivo" ', Subtemas.orden, Subtemas.Subtema, Subtemas.Cuenta,  Subtemas.TemaID"
            filtro = filtro & " FROM (Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id) INNER JOIN Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id "
            filtro = filtro & " Where TemaID= " & IdTema
            filtro = filtro & " ORDER BY Subtemas.orden ASC"


            CargarSubtemas(filtro)
        End If
    End Sub

    Private Sub optSubtema_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If IdTema = 0 Then Exit Sub


        If optSubtema.Checked = True Then
            IdTema = Me.cboGrupos.SelectedValue

            filtro = " SELECT Subtemas.Id, Subtemas.orden, Subtemas.Subtema, Subtemas.estatus,Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado, Subtemas.secuencia,Subtemas.Cuenta, Subtemas.Cuenta as Avance,"
            filtro = filtro & " Subtemas.duracion, Subtemas.archivo" ', Subtemas.orden, Subtemas.Subtema, Subtemas.Cuenta,  Subtemas.TemaID"
            filtro = filtro & " FROM (Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id) INNER JOIN Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id "
            filtro = filtro & " Where TemaID= " & IdTema
            filtro = filtro & " ORDER BY Subtemas.Subtema ASC"


            CargarSubtemas(filtro)
        End If
    End Sub

    Private Sub Button2_Click_3(sender As System.Object, e As System.EventArgs)
        'TreeView1.ExpandAll()
        ' 'TreeView1.CollapseAll()
        ' Dim node As TreeNode
        ' Dim TreeView As TreeView
        '  node = TreeView1.Nodes(1)
        ' TreeView = New treeviewdata(TreeView1)
        '    TreeView1.Nodes.Clear()
        'in a loop I regenerate the nodes and sub nodes again and attach it to the Treeview
        '   Dim nd As TreeNode
        '  nd.Text = "N1"
        ' TreeView1.TopNode.EnsureVisible()
        ' TreeView1.Nodes(0).EnsureVisible()
        'end loop
        ' TreeView.PopulateTree(TreeView1)
        ' node.EnsureVisible()
    End Sub

    Private Sub Button4_Click_2(sender As System.Object, e As System.EventArgs)
        'TreeView1.CollapseAll()

    End Sub

    Private Sub optContract_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optContract.CheckedChanged
        TreeView1.CollapseAll()
        '  TreeView1.Nodes(0).EnsureVisible()
    End Sub


#End Region

#Region "Datagrid"
    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim filename As String

        ItemSelected = DataGridView1.CurrentRow.Index


    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'Set the background to red for negative values in the Balance column.

        'Console.WriteLine(DataGridView1.Columns(e.ColumnIndex).Name)
        'Try
        '    If DataGridView1.Columns(e.ColumnIndex).Name = "Avance" Then

        '        ' Validar valor
        '        If e.Value Is Nothing OrElse IsDBNull(e.Value) Then Exit Sub

        '        Dim avance As Double
        '        If Not Double.TryParse(e.Value.ToString(), avance) Then Exit Sub

        '        Dim colorFila As Color

        '        Select Case avance
        '            Case 0
        '                colorFila = oColorSalmon
        '            Case 1
        '                colorFila = oColorVerde
        '            Case Else
        '                If avance > 0 AndAlso avance < 1 Then
        '                    colorFila = ColorBeige
        '                Else
        '                    Exit Sub
        '                End If
        '        End Select

        '        ' Aplicar color a toda la fila
        '        For Each celda As DataGridViewCell In DataGridView1.Rows(e.RowIndex).Cells
        '            celda.Style.BackColor = colorFila
        ''        Next

        ''    End If

        ''Catch ex As Exception
        ''    ' Opcional: loggear error
        'Debug.WriteLine(ex.Message)
        'End Try

        'Try
        '    If DataGridView1.Columns(e.ColumnIndex).Name.Equals("Avance") Then
        '        If e.Value = 0 Then
        '            For ColNo As Integer = 0 To maxColumna + 2
        '                DataGridView1.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = oColorSalmon
        '            Next
        '        ElseIf e.Value > 0 And e.Value < 1 Then
        '            For ColNo As Integer = 0 To maxColumna + 2
        '                DataGridView1.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = ColorBeige
        '            Next
        '        ElseIf e.Value = 1 Then
        '            For ColNo As Integer = 0 To maxColumna + 2
        '                DataGridView1.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = oColorVerde
        '            Next
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try



    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim Id As Integer
        Dim filename As String
        Dim resp As Integer

        Try
            Id = DataGridView1.CurrentRow.Cells(0).Value.ToString()

        Catch ex As Exception
            Exit Sub
        End Try

        CurrRowDgvTemas = DataGridView1.CurrentRow.Index

        'If IsNothing(objWord) Then
        '    objWord = New Word.Application
        'End If
      
        

        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            'Dim resp As String
            'Dim avance As Integer
            ' If e.Button = System.Windows.Forms.MouseButtons.Right Then
            Dim RutaArchivo As String
            Dim RutaArchivoWord As String

            'ruta = "C:\Users\jolvera.SSWTECHNOLOGIES\OneDrive - SSW Holding Company, LLC\Documents\_ingles\Temas\"
            ruta = "C:\Legacy\Ingles\Temas\"
            ' resp = MsgBox("No existe el archivo?" & vbCrLf & "¿ Crear Nuevo ?", vbOKCancel + vbQuestion)


            Try
                filename = Trim(DataGridView1.CurrentRow.Cells(2).Value.ToString())
                'filename = "test"
                RutaArchivo = ruta & carpeta & "\" & filename & ".rtf"
                RutaArchivoWord = ruta & carpeta & "\" & filename & ".docx"

                'Dim objWord As Object
                'objWord = CreateObject("Word.Application")

                Dim objDoc As Document = Nothing
                Dim wordPara As Word.Paragraph
                Dim wordPara2 As Word.Paragraph

                Try
                    'objWord = New Microsoft.Office.Interop.Word.Application

                    If System.IO.File.Exists(RutaArchivoWord) Then
                        objWord.Documents.Open(RutaArchivoWord)
                    Else
                        MsgBox("No existe el archivo")
                        Exit Sub
                    End If
                Catch ex As Exception
                    objWord = New Microsoft.Office.Interop.Word.Application
                    If System.IO.File.Exists(RutaArchivoWord) Then
                        objWord.Documents.Open(RutaArchivoWord)
                    Else
                        'objWord.Documents.Add()
                        Exit Sub
                    End If
                End Try


                ' Process.Start("explorer.exe", RutaArchivoWord)
                ' Agregar un nuevo documento
                objDoc = objWord.Documents(1)

                ' Obtener un objeto Range al principio del documento
                ' El Range representa el texto en la posición 0 a 0 (principio)
                objWord.Visible = True
                objWord.Activate()
                'objDoc.Content.Text = "Este es el texto agregado desde VB.NET."
                ' Insertar el texto en el Range
                ' rng.Text = ""

                ' wordPara = objDoc.Content.Paragraphs. ' Add a paragraph to the document
                'wordPara.Range.Text = cboGrupos.Text & vbCrLf & vbCrLf ' Set the text for the paragraph
                'wordPara.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter  ' Set the paragraph alignment to center

                'objDoc.Range(0, 0).Text = "Este es el texto agregado desde VB.NET." ' Define un rango en el documento. Al poner start = 0 y end = 0
                'objDoc.Content.InsertAfter(Environment.NewLine & "Este es el texto agregado desde VB.NET.")
                resp = MsgBox("¿ Agregar Titulo ?", MsgBoxStyle.YesNo)
                If resp = 6 Then
                    Dim rng As Word.Range
                    rng = objDoc.Range(0, 0) '.Text = "Lección " & DataGridView1.CurrentRow.Cells(1).Value & "  & vbCrLf
                    'rng.Paragraphs.Add()
                    'rng.Text = "Lección " & DataGridView1.CurrentRow.Cells(1).Value & " : " & filename & vbCr
                    'rng.Font.Bold = True

                    '   rng = Nothing
                    'wordPara.Range.Text =
                    'rng.InsertBefore("Lección " & DataGridView1.CurrentRow.Cells(1).Value & ": " & filename & vbCr & vbCr)
                    rng.Text = ("Lección " & DataGridView1.CurrentRow.Cells(1).Value & ": " & filename & vbCr & vbCr)

                    wordPara = objDoc.Content.Paragraphs(1)
                    wordPara.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft   ' Set the paragraph alignment to center
                    wordPara.Range.Font.Bold = True
                    'wordPara.Range.Select()

                    ' rng.InsertParagraphAfter()
                    rng.InsertBefore(cboGrupos.Text & vbCr & vbCr)
                    wordPara2 = objDoc.Content.Paragraphs(1)
                    ' wordPara2.Range.Text = "Lección " & DataGridView1.CurrentRow.Cells(1).Value '& vbCr '" : " & filename
                    wordPara2.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter ' Set the paragraph alignment to center
                    wordPara2.Range.Font.Bold = False

                End If


                ' objWord.ActiveDocument.ShowGrammaticalErrors = False
                '  objWord.ActiveDocument.ShowSpellingErrors = False

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If

        DataGridView1.Rows(CurrRowDgvTemas).Selected = True

    End Sub



    Private Sub DataGridView1_DoubleClick(sender As Object, e As System.EventArgs) Handles DataGridView1.DoubleClick
        Dim Id As Integer
        Dim TipoTicket As String
        Dim filename As String = ""
        Dim Cuenta As Integer
        'Dim frm As New frmDetSubtema

        'AddOwnedForm(frm)
        If Not IsDBNull(DataGridView1.CurrentRow.Cells(13).Value) Then
        Else
            MsgBox("No existe el Id")
            Exit Sub
        End If

        Using frm As New frmEscenas
            AddOwnedForm(frm)

            ' tipo = Str(0)
            ' indice = Str(1)

            '  Id = pEtapa.Controls.Item("pAux_" & Id).Controls.Item("txt_" & Id)
            Id = Trim(DataGridView1.CurrentRow.Cells(13).Value.ToString())
            titulo = Trim(DataGridView1.CurrentRow.Cells(2).Value.ToString())


            frm.Id = Id
            frm.Titulo = titulo
            frm.Imagen = sender.Tag

            frm.ShowDialog()

            ' Catch ex As Exception
            'MsgBox(ex.Message)
            'End Try
            'If cboTipo.Text <> "" Then
            '    param = " Where Con_Tipo='" & cboTipo.Text & "'"

            'End If
        End Using
         

        'frm.Id = Id
        'frm.lbltitulo.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString()
        'frm.CargarConversation(Id)

        'Try
        '    frm.ShowDialog()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'Dim param As String

        'CargarSubtemas(filtro)


    End Sub

#End Region

#Region "TreeView"
    Private Sub TreeView1_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragDrop
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", _
              True) = False Then Exit Sub

        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)

        'Get the TreeNode being dragged
        Dim dropNode As TreeNode = _
              CType(e.Data.GetData("System.Windows.Forms.TreeNode"),  _
              TreeNode)

        'The target node should be selected from the DragOver event
        Dim targetNode As TreeNode = selectedTreeview.SelectedNode

        'Remove the drop node from its current location
        dropNode.Remove()

        'If there is no targetNode add dropNode to the bottom of
        'the TreeView root nodes, otherwise add it to the end of
        'the dropNode child nodes
        If targetNode Is Nothing Then
            selectedTreeview.Nodes.Add(dropNode)
        Else
            'targetNode.Nodes.Add(dropNode)
            ' targetNode.Parent.Nodes.Add(dropNode)
            Try

                If targetNode.Name = dropNode.Name Then
                    selectedTreeview.Nodes.Add(dropNode)
                Else

                    targetNode.Parent.Nodes.Insert(targetNode.Index, dropNode)

                End If

            Catch ex As Exception

                'selectedTreeview.Nodes.Add(dropNode)
                'e.Effect = DragDropEffects.None
                Try
                    targetNode.Nodes.Add(dropNode)

                Catch ex1 As Exception
                    e.Effect = DragDropEffects.None
                    Exit Sub
                    ' selectedTreeview.Nodes.Add(dropNode)

                End Try
                'targetNode.Nodes.Add(dropNode)
                Exit Sub
            End Try

        End If

        'Ensure the newley created node is visible to
        'the user and select it
        dropNode.EnsureVisible()
        selectedTreeview.SelectedNode = dropNode

        'dropNode.Parent = dropNode.Parent

        ''Actualizar

        'Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        'Dim sqlstring As String

        'Dim i As Integer


        '_comando.Connection.Open()

        '_comando.Parameters.Clear()


        'sqlstring = "UPDATE Subtemas SET Nodo = @Nodo, Secuencia = @Secuencia"
        'sqlstring = sqlstring & " WHERE Id = @Id"

        '_comando.CommandText = sqlstring

        '_comando.Parameters.AddWithValue("@Id", dropNode.Name)
        '_comando.Parameters.AddWithValue("@Nodo", targetNode.Index)
        '_comando.Parameters.AddWithValue("@Secuencia", targetNode.Name)

        'Try
        '    i = _comando.ExecuteNonQuery

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        '_comando.Connection.Close()



        'CargarSubtemas(filtro)

        'TreeView1.ExpandAll()
        'Try
        '    TreeView1.Nodes(CurrentNode).EnsureVisible()

        'Catch ex As Exception

        'End Try


    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Dim filename As String

        Try


            If TreeView1.SelectedNode.Level > 0 Then
                If e.Button = System.Windows.Forms.MouseButtons.Right Then
                    Dim resp As Integer
                    Dim RutaArchivo As String
                    Dim RutaArchivoWord As String

                    'ruta = "C:\Users\jolvera.SSWTECHNOLOGIES\OneDrive - SSW Holding Company, LLC\Documents\_ingles\Temas\"
                    ruta = "C:\Legacy\Ingles\Temas\"
                    ' resp = MsgBox("No existe el archivo?" & vbCrLf & "¿ Crear Nuevo ?", vbOKCancel + vbQuestion)
                    If resp = 6 Then
                    End If


                    Try
                        filename = Trim(TreeView1.SelectedNode.Text)
                        'filename = "test"
                        RutaArchivo = ruta & carpeta & "\" & filename & ".rtf"
                        RutaArchivoWord = ruta & carpeta & "\" & filename & ".doc"

                        'Console.WriteLine(RutaArchivo)

                        'Dim objWord As New Word.Application ' Dim objDoc As Words.a
                        Dim objWord As Object

                        If System.IO.File.Exists(RutaArchivo) Then
                            objWord = CreateObject("Word.Application")
                            objWord.Documents.Open(RutaArchivo)

                        Else
                            MsgBox("No existe")

                            resp = MsgBox("¿Crear archivo?", MsgBoxStyle.OkCancel)

                            If resp = 1 Then
                                resp = MsgBox("¿Es Complementaria?", MsgBoxStyle.YesNo)


                                objWord = CreateObject("Word.Application")

                                objWord.Documents.Add()
                                'objWord.Documents.Save(filename & ".rtf")
                                If resp = 6 Then
                                    objWord.ActiveDocument.Characters.Last.Select()  '// Line 1
                                    objWord.Selection.Collapse()                     '// Line 2
                                    objWord.Selection.TypeText("Complementaria")


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

                                End If

                                objWord.ActiveDocument.SaveAs(filename:="" & RutaArchivo)
                                objWord.quit()
                                'objWord = Nothing
                                Exit Sub

                            Else
                                Exit Sub

                            End If
                        End If
                        objWord.ActiveDocument.ActiveWindow.View.Zoom.Percentage = 150
                        objWord.ActiveDocument.ShowGrammaticalErrors = False
                        objWord.ActiveDocument.ShowSpellingErrors = False
                        objWord.Visible = True


                        ' Process.Start("explorer.exe", RutaArchivoWord)

                        ' Else
                        ' objWord.Documents.Add(RutaArchivo)
                        'objWord.Documents.Open(RutaArchivo & ".doc")
                        '   objWord.ActiveDocument.pro()
                        'objWord.SaveFile(filename)

                        ' Dim objDoc As Word.Document


                        '    objWord.ActiveDocument.SaveAs(filename:="" & ruta & carpeta & "\" & filename & ".doc")


                        ' End If
                        'objWord.Documents.Open(filename)
                        'objWord.Visible = True
                        ' Console.Write("")
                        ' Dim objNewWord As New Word.Application ' Dim objDoc As Words.a

                        '     objNewWord.ActiveDocument.SaveAs(filename:="" & ruta & carpeta & "\" & filename & ".docx")
                        'objWord.ActiveDocument.SaveAs(filename:="" & ruta & carpeta & "\" & filename & ".docx")


                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try





                End If
            Else




                'If Mid(TreeView1.SelectedNode.Text, 1, 1) = "_" Then Exit Sub
                If IsNothing(TreeView1.SelectedNode) = True Then Exit Sub
                If TreeView1.SelectedNode.Level = 0 Then
                    CurrentNode = TreeView1.SelectedNode.Index
                    lblNode.Text = TreeView1.SelectedNode.Text
                Else
                    ' IsNothing(TreeView1.SelectedNode.Parent) = True Then Exit Sub
                    CurrentNode = TreeView1.SelectedNode.Parent.Index
                    lblNode.Text = TreeView1.SelectedNode.Parent.Text
                End If
            End If

        Catch ex As Exception

        End Try

        'Exit Sub
        ' If IsNothing(TreeView1.SelectedNode.Parent) = True Then Exit Sub




    End Sub

    Private Sub TreeView1_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles TreeView1.ItemDrag


        'Set the drag node and initiate the DragDrop
        DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub TreeView1_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragEnter
        'See if there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            'TreeNode found allow move effect
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None

            'No TreeNode found, prevent move
        End If
    End Sub

    Private Sub TreeView1_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles TreeView1.DragOver
        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)

        'As the mouse moves over nodes, provide feedback to
        'the user by highlighting the node that is the
        'current drop target
        Dim pt As Point = _
            CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        Dim targetNode As TreeNode = selectedTreeview.GetNodeAt(pt)

        'See if the targetNode is currently selected,
        'if so no need to validate again
        If Not (selectedTreeview.SelectedNode Is targetNode) Then
            'Select the    node currently under the cursor
            selectedTreeview.SelectedNode = targetNode

            'Check that the selected node is not the dropNode and
            'also that it is not a child of the dropNode and
            'therefore an invalid target
            Dim dropNode As TreeNode = _
                CType(e.Data.GetData("System.Windows.Forms.TreeNode"),  _
                TreeNode)

            Do Until targetNode Is Nothing
                If targetNode Is dropNode Then
                    e.Effect = DragDropEffects.None
                    Exit Sub
                End If
                targetNode = targetNode.Parent
            Loop
        End If

        'Currently selected node is a suitable target
        e.Effect = DragDropEffects.Move


    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        Dim documentPath As String
        Dim archivo, carpeta As String
        Dim Resp, IdSubTema As Integer
        Dim filename As String
        'Documents.Open(FileName:="C:\MyFiles\MyDoc.docx", ReadOnly:=True)
        ' documentPath = "C:\Legacy\MyDoc.docx"
        'Process.Start(documentPath)
        ' archivo = Trim(Me.TreeView1.Nodes.Item(TreeView1.SelectedNode.Index).Text)

        'If Trim(TreeView1.SelectedNode.Text) Then Exit Sub
        If IsNothing(TreeView1.SelectedNode) = True Then Exit Sub

        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            'MsgBox(TreeView1.SelectedNode.Text)
        Else
            If Mid(TreeView1.SelectedNode.Text, 1, 1) = "_" Then Exit Sub

        End If


        archivo = Trim(TreeView1.SelectedNode.Text)
        IdSubTema = Trim(TreeView1.SelectedNode.Name)




        ' IdSubTema = Me.TreeView1.Nodes.Item(TreeView1.SelectedNode.Index).Name
        'TreeView.SelectedNode = TreeView1.Nodes.Item(TreeView1.SelectedNode.Index + 1) ' <-- I thought this would work, but it doesn't
        If archivo = "" Then Exit Sub
        ' On Error Resume Next
        ' Dim objWord As Word.Application
        'objWord = New Word.Application

        'carpeta = Me.dgvListaDatos.CurrentRow.Cells(4).Value.ToString()
        carpeta = Trim(Me.cboTipos.Text)

        filename = "C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".rtf"

        Try



            Dim Id As Integer
            Dim TipoTicket As String
            Dim frm As New frmDetSubtema
            '  Dim filename As String = ""
            Dim Cuenta As Integer

            AddOwnedForm(frm)

            ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

            ' Id = DataGridView1.CurrentRow.Cells(0).Value.ToString()

            '  CurrRowDgvTemas = DataGridView1.CurrentRow.Index

            ' If IsDBNull(DataGridView1.CurrentRow.Cells(9).Value) Then
            'Cuenta = 0
            ' Else
            ' Cuenta = DataGridView1.CurrentRow.Cells(9).Value.ToString()
            ' End If


            frm.Id = IdSubTema
            frm.subtemaId = IdSubTema
            frm.carpeta = cboTipos.Text
            frm.archivo = Trim(archivo)
            frm.CargarDatos(IdSubTema)
            frm.ShowDialog()

            Try
                DataGridView1.Rows(CurrRowDgvTemas).Selected = True

            Catch ex As Exception

            End Try
            ' Determine whether the directory exists.
            ' If Directory.Exists(carpeta) Then
            ' "C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".rtf")
            ' If System.IO.File.Exists(filename) Then
            'objWord.Documents.Open(filename)
            ' objWord.Visible = True

            'Resp = MsgBox("Registrar curso?", vbOKCancel + vbQuestion)

            'If Resp = 1 Then
            'bitacora(IdSubTema)

            'End If

            ' Else
            'No existe archivo
            ' Resp = MsgBox("¿ Crear Nuevo ?", MsgBoxStyle.OkCancel)

            ' If Resp = 1 Then

            'Dim obj As New RichTextBox
            'obj.Text = archivo
            ' obj.AppendText(archivo)
            ' obj.Font = New Font("arial", 12, FontStyle.Bold)
            ''  g.DrawString("AB", New Font("Segoe UI", 10, FontStyle.Bold), arrayColorPen(c), rect1, stringFormat)

            ' obj.SaveFile(filename)

            'objWord = CreateObject("Word.Application")
            'objWord.Visible = True
            'Dim objDoc As Word.Document

            'objDoc = objWord.Documents.Add
            'Insert some text in document
            'Dim objPara As Word.Paragraph
            'objPara = objDoc.Content.Paragraphs.Add
            'objPara.Range.Text = archivo
            'objPara.Range.Font.Bold = True
            'objPara.Format.SpaceAfter = 30
            'objPara.Range.InsertParagraphAfter()
            'objWord.Documents.Save("Test")
            'objWord.ActiveDocument.SaveAs(FileName:="" & filename, FileFormat:="rtf")
            'objWord.SaveToFile("rtf.rtf",)
            ' Else
            '  MsgBox("No Creado")
            '  End If
            ' End If

            '  End If

            'If System.IO.File.Exists(filename) Then

            'End If

            'End If
            ' Console.WriteLine("That path exists already.")
            ' Return
            '  RichTextBoxEx.RichTextBoxEx.CargarDatos(Id)

            'Else





        Catch ex As Exception




        End Try
    End Sub

    Private Sub CmdNode_Click(sender As System.Object, e As System.EventArgs) Handles CmdNode.Click

        TreeView1.CollapseAll()

        Try
            TreeView1.Nodes(CurrentNode).Expand()
            TreeView1.Nodes(CurrentNode).EnsureVisible()

        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button2_Click_4(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = TreeView1

        Dim miNode As TreeNode
        'Actualizar
        'miNode = TreeView1.Nodes(1)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, j As Integer

        Dim n As TreeNode
        _comando.Connection.Open()


        Do While i <= TreeView1.Nodes.Count - 1

            miNode = TreeView1.Nodes(i)

            For Each n In miNode.Nodes
                _comando.Parameters.Clear()

                sqlstring = "UPDATE Subtemas SET Nodo = @Nodo, Secuencia = @Secuencia"
                sqlstring = sqlstring & " WHERE Id = @Id"

                _comando.CommandText = sqlstring
                Console.Write(n.Text)
                _comando.Parameters.AddWithValue("@Id", n.Name)
                _comando.Parameters.AddWithValue("@Nodo", n.Index)
                _comando.Parameters.AddWithValue("@Secuencia", n.Parent.Name)
                '  _comando.Parameters.AddWithValue("@Secuencia", miNode.Name)

                Try
                    j = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


                'Nodos en nodo

                For Each n2 In n.Nodes
                    _comando.Parameters.Clear()

                    sqlstring = "UPDATE Subtemas SET Nodo = @Nodo, Secuencia = @Secuencia"
                    sqlstring = sqlstring & " WHERE Id = @Id"

                    _comando.CommandText = sqlstring
                    Console.WriteLine(n2.Text)
                    _comando.Parameters.AddWithValue("@Id", n2.Name)
                    _comando.Parameters.AddWithValue("@Nodo", n2.Index)
                    _comando.Parameters.AddWithValue("@Secuencia", n2.Parent.Name)

                    Try
                        j = _comando.ExecuteNonQuery

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try


                Next

            Next



            'Try
            '    i = _comando.ExecuteNonQuery

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try

            i = i + 1
        Loop

        _comando.Connection.Close()


        CargarSubtemas(filtro)

        TreeView1.ExpandAll()
        Try
            TreeView1.Nodes(CurrentNode).EnsureVisible()

        Catch ex As Exception

        End Try


        optExpand.Checked = True


        TreeView1.CollapseAll()

        Try
            TreeView1.Nodes(CurrentNode).Expand()
            TreeView1.Nodes(CurrentNode).EnsureVisible()

        Catch ex As Exception
        End Try

        '_comando.Connection.Close()
        'Actualizar

        'Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        'Dim sqlstring As String

        'Dim i As Integer


        '_comando.Connection.Open()

        '_comando.Parameters.Clear()


        'sqlstring = sqlstring & " WHERE Id = @Id"

        '_comando.CommandText = sqlstring

        '_comando.Parameters.AddWithValue("@Id", dropNode.Name)
        '_comando.Parameters.AddWithValue("@Nodo", targetNode.Index)

        'Try
        '    i = _comando.ExecuteNonQuery

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try





    End Sub
    Private Sub optExpand_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optExpand.CheckedChanged
        TreeView1.ExpandAll()
        Try
            TreeView1.Nodes(CurrentNode).EnsureVisible()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub TreeView1_MouseHover(sender As Object, e As System.EventArgs) Handles TreeView1.MouseHover

        TreeView1.ShowNodeToolTips = True

    End Sub

    Private mNode As TreeNode
    Private Property Node() As TreeNode
        Get
            Return mNode
        End Get
        Set(ByVal Value As TreeNode)

            mNode = Value
            If Not mNode Is Nothing Then

                Dim selectedTreeview As TreeView = TreeView1

                Dim miNode As TreeNode

                Dim _comando As SqlCommand = MetodosDatos.CrearComando()
                Dim sqlstring As String
                Dim objDataReader As SqlDataReader
                Dim Tema As String
                _comando.Connection.Open()

                sqlstring = " SELECT        Subtemas.Id,  Temas.Tema"
                sqlstring = sqlstring & " FROM            Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id"
                sqlstring = sqlstring & " Where Subtemas.Id=" & mNode.Name


                _comando.CommandText = sqlstring

                '_comando.Parameters.AddWithValue("@Id", mNode.Name)

                Try
                    'i = _comando.ExecuteNonQuery
                    objDataReader = _comando.ExecuteReader


                    If objDataReader.HasRows Then

                        objDataReader.Read()

                        Tema = objDataReader.GetString(1)
                        mNode.ToolTipText = Tema

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                _comando.Connection.Close()



            End If
        End Set
    End Property

    Private Sub TreeView1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView1.MouseMove

        Me.Node = TreeView1.GetNodeAt(e.X, e.Y)
    End Sub


#End Region

#Region "Buscar"
    Private Sub FindByText()
        Dim nodes As TreeNodeCollection = TreeView1.Nodes
        Dim n As TreeNode
        For Each n In nodes
            FindRecursive(n)
        Next
    End Sub
    Private Sub FindRecursive(ByVal tNode As TreeNode)
        If txtBuscarTree.Text = "" Then
            TreeView1.CollapseAll()
            TreeView1.BackColor = Color.White
            'TreeView1.ExpandAll(TreeView1.Nodes, 1)
        Else
            Dim tn As TreeNode
            For Each tn In tNode.Nodes
                ' if the text properties match, color the item
                If tn.Text.Contains(txtBuscarTree.Text) Then
                    tn.BackColor = Color.Yellow
                    tn.EnsureVisible()        'Scroll the control to the item
                End If

                FindRecursive(tn)
            Next
        End If
    End Sub

    Private Sub ClearBackColor()
        Dim nodes As TreeNodeCollection
        nodes = TreeView1.Nodes
        Dim n As TreeNode
        For Each n In nodes
            ClearRecursive(n)
        Next
    End Sub

    Private Sub ClearRecursive(ByVal treeNode As TreeNode)
        Dim tn As TreeNode
        For Each tn In treeNode.Nodes
            tn.BackColor = Color.White
            ClearRecursive(tn)
        Next
    End Sub
    Private Sub txtBuscarTree_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscarTree.TextChanged
        ClearBackColor()
        FindByText()
    End Sub

#End Region


    Private Sub Button4_Click_3(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub CmdNivel_Click(sender As System.Object, e As System.EventArgs) Handles CmdNivel.Click
        Dim parentObj As Object = TreeView1.SelectedNode.Parent
        Dim parentObjNew As Object = TreeView1.SelectedNode.PrevNode

        If parentObj Is Nothing Then
            parentObj = TreeView1
        End If

        Dim selectedNode As TreeNode = TreeView1.SelectedNode
        Dim idxSelected As Integer = selectedNode.Index
        Dim idxNext As Integer

        If selectedNode IsNot Nothing Then
            Dim prevNode As TreeNode = TreeView1.SelectedNode.PrevNode

            If prevNode IsNot Nothing Then
                idxNext = prevNode.Index
                If TypeOf parentObj Is TreeNode Then
                    CType(parentObj, TreeNode).Nodes.Remove(CType(parentObj, TreeNode).Nodes(idxSelected))
                    CType(parentObjNew, TreeNode).Nodes.Insert(idxNext, selectedNode)
                Else
                    CType(parentObj, TreeView).Nodes.Remove(CType(parentObj, TreeView).Nodes(idxSelected))
                    CType(parentObj, TreeView).Nodes.Insert(idxNext, selectedNode)
                End If

                If TypeOf parentObj Is TreeNode Then
                    TreeView1.SelectedNode = CType(parentObj, TreeNode).Nodes(idxNext)
                Else
                    TreeView1.SelectedNode = CType(parentObj, TreeView).Nodes(idxNext)
                End If
            End If
        End If


    End Sub

    Private Sub cboAvance_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAvance.SelectedIndexChanged
        Dim sqlstring As String = ""
    
        Dim i, n As Integer
        Dim IdGrupo As Integer
        Dim valor1, valor2 As Integer

        'buscar = Me.txtBuscar.Text
        'If Trim(buscar) = "" Then Exit Sub

        IdTema = Me.cboGrupos.SelectedValue
        IdGrupo = Me.cboTipos.SelectedValue

        Select Case cboAvance.SelectedIndex
            Case 0
                valor1 = 0
                valor2 = 50

            Case 1
                valor1 = 50
                valor2 = 99
            Case 3

        End Select

        filtro = " SELECT Subtemas.Id, Subtemas.orden, Subtemas.Subtema, Subtemas.estatus,Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado, Subtemas.secuencia,Subtemas.Cuenta, Subtemas.Cuenta as Avance,"
        filtro = filtro & " Subtemas.duracion, Subtemas.archivo,Grupos_Temas.Id" ', Subtemas.orden, Subtemas.Subtema, Subtemas.Cuenta,  Subtemas.TemaID"
        filtro = filtro & " FROM (Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id) INNER JOIN Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id "
        filtro = filtro & " Where Subtemas.Cuenta Between " & valor1 & " And " & valor2
        filtro = filtro & " And Grupos_Temas.Id= " & IdGrupo

        If optId.Checked = True Then
            filtro = filtro & " ORDER BY Subtemas.orden ASC"

        Else
            filtro = filtro & " ORDER BY Subtemas.Subtema ASC"

        End If

 


        CargarSubtemas(filtro)

    End Sub

    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        Dim oColorOk As Drawing.Color = Color.Chartreuse
        Dim oColorNot As Drawing.Color = Color.Yellow


        If DataGridView1.SelectedRows.Count > 0 Then
            Try
                If e.RowIndex <> DataGridView1.CurrentCell.RowIndex Then

                    If e.ColumnIndex = 9 Then
                        Dim cellValue As Double
                        If e.RowIndex >= 0 Then
                            If Not IsDBNull(e.Value) Then
                                cellValue = e.Value
                                If cellValue = 1 Then
                                    Bar.PintaDegradado(oColorOk, e, cellValue)
                                Else
                                    Bar.PintaDegradado(oColorNot, e, cellValue)

                                End If
                            End If

                        End If


                    End If
                End If
            Catch ex As Exception

            End Try

        Else
            'MessageBox.Show("No hay ninguna fila seleccionada")
        End If

    End Sub

    Private Sub Button4_Click_4(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim CanalId As Integer
        Try
            CanalId = cboTipos.SelectedValue
            CargarSubtemasxCanal(CanalId)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdDetalle_Click(sender As System.Object, e As System.EventArgs) Handles cmdDetalle.Click
        Dim Id As Integer
        Dim TipoTicket As String
        Dim filename As String = ""
        Dim Cuenta As Integer
        Dim frm As New frmDetSubtema
        ' Dim frm As New FrmConversation

        Id = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        CurrRowDgvTemas = DataGridView1.CurrentRow.Index

        If IsDBNull(DataGridView1.CurrentRow.Cells(9).Value) Then
            Cuenta = 0
        Else
            Cuenta = DataGridView1.CurrentRow.Cells(9).Value.ToString()
        End If


        frm.Id = Id
        frm.subtemaId = Id
        frm.carpeta = cboTipos.Text
        frm.archivo = Trim(DataGridView1.CurrentRow.Cells(2).Value.ToString())
        frm.CargarDatos(Id)
        frm.ShowDialog()

        Try
            CargarSubtemas(filtro)
            DataGridView1.Rows(CurrRowDgvTemas).Selected = True

        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmdConversacion_Click(sender As System.Object, e As System.EventArgs) Handles cmdConversacion.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim sqlstring As String = ""
        Dim i As Integer
        Dim IdEnc As Integer
        Dim Id As Integer
        Dim titulo As String

        Dim j As Integer
        Dim TextoPlano As String

        Dim n As Integer

        Dim objDataReader As SqlDataReader
        Dim celda As DataGridViewCell
        Dim valorActual As String
        Dim valorModificado As String

        _comando.Connection.Open()

        For Each RW As DataGridViewRow In DataGridView1.Rows

            Try

                If IsDBNull(RW.Cells(13).Value) Then
                    Id = RW.Cells(0).Value.ToString()

                    titulo = Trim(RW.Cells(2).Value.ToString())
                    _comando.Parameters.Clear()

                    sqlstring = "Insert into Enc_Conversation (Con_Titulo, Con_tipo, SubtemaId)"
                    sqlstring = sqlstring & " Values ('@Con_Titulo', 'Leccion', '" & Id & "')"

                    _comando.CommandText = sqlstring

                    _comando.Parameters.AddWithValue("@Con_Titulo", titulo)

                    Try
                        i = _comando.ExecuteNonQuery

                        If i > 0 Then

                        Else
                            MsgBox("No se guardo")
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)

                    End Try
                End If


            Catch ex As Exception
            End Try
        Next


        _comando.Connection.Close()

    End Sub

    Private Sub TreeView1_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub Button5_Click_2(sender As System.Object, e As System.EventArgs) Handles Button5.Click

        Dim appWord As Word.Application
        Dim doc As Word.Document

        appWord = New Word.Application
        appWord.Visible = False

        archivo = DataGridView1.CurrentRow.Cells(2).Value.ToString()

        If archivo = "" Then Exit Sub

        Dim objWord As Word.Application

        Dim RutaArchivo As String

        RutaArchivo = "C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".doc"
        Try
            doc = appWord.Documents.Open(RutaArchivo)

            ' Mostrar dentro del panel
            doc.ActiveWindow.Visible = True
        Catch ex As Exception

        End Try




    End Sub

    

    Private Sub cmdConversaciones_Click(sender As System.Object, e As System.EventArgs) Handles cmdConversaciones.Click
        frmConversaciones.Show()
    End Sub
End Class