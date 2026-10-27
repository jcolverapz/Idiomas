Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
'Imports System.Data.Sql
'Imports System.Data.SqlClient
Public Class FrmTemas
    Public conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\legacy\Ingles\Ingles.accdb")
    'Public conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Program Files (x86)\Rosslare\GS-01 Digitool Reports\main.mdb")



    Public instruccion As New OleDbCommand
    Public contenedor As String
    Public sqlstring As String

    Public Shared IdEnc As Integer
    Public consulta As String
    Dim rowcount As Integer

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Consulta2._Consulta2' Puede moverla o quitarla según sea necesario.
        Me.Consulta2TableAdapter.Fill(Me.Consulta2._Consulta2)
        'Dim oda As New OleDbDataAdapter
        'Dim ods As New DataSet
        'Dim consulta As String
        'consulta = "select * from Enc_Gastos"

        'oda = New OleDbDataAdapter(consulta, conexion)
        'ods.Tables.Add("Enc_Gastos")
        'oda.Fill(ods.Tables("Enc_Gastos"))
        'dgvEncDatos.DataSource = ods.Tables("Enc_Gastos").DefaultView

        'cargarDatos()

        Dim sqlstring As String
        Dim cmd As New OleDbCommand

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter
        Try
            conexion.Open()

            sqlstring = "select * from  Grupos_Temas "
            sqlstring = sqlstring & " ORDER By Grupos_Temas ASC"

            cmd.Connection = conexion
            cmd.CommandText = sqlstring
            da.SelectCommand = cmd

            da.Fill(dt)
             
            Me.cboTipos.DataSource = dt
            Me.cboTipos.ValueMember = "Id"
            Me.cboTipos.DisplayMember = "Grupos_Temas"


        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()

        End Try


        ' CargarSubtemas()
        ' dgvEncDatos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '  dgvEncDatos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvEncDatos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '  dgvEncDatos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        'dgvEncDatos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datagrid.Columns[0].AutoSizeMode =DataGridViewAutoSizeColumnMode.Fill
        '  dgvEncDatos.Columns(0).AutoSizeMode = True
        'dgvEncDatos.Columns(0).MinimumWidth = True
        ' dgvEncDatos.Columns(0).Visible = False



    End Sub
    Private dataSetArbol As System.Data.DataSet
    Private dtTabla As New DataTable 'Creo una nueva tabla

    Public Sub CargarSubtemas(IdGrupo)
        Dim sql As String
        Dim cmd As New OleDbCommand

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter

        Try
            conexion.Open()

            ' sqlstring = "select * from  SubTemas "
            'sqlstring = sqlstring & " Where TemaID= " & IdGrupo
            'sqlstring = sqlstring & " Order By orden ASC"

            sql = " SELECT Subtemas.orden, Subtemas.Subtema, Subtemas.estatus,Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado ,Subtemas.Id, Subtemas.secuencia"
            Sql = Sql & " FROM (Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id) INNER JOIN Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id "
            Sql = Sql & " Where TemaID= " & IdGrupo
            Sql = Sql & " ORDER BY Subtemas.orden ASC"

            

            cmd.Connection = conexion
            cmd.CommandText = sql
            da.SelectCommand = cmd

            ' da.Fill(dt)
            dtTabla = New DataTable 'Creo una nueva tabla
            da.Fill(dtTabla)
            TreeView1.ImageList = ImageList1
            Me.TreeView1.Nodes.Clear()

            Dim nodo1 As Integer
            Dim test As String
            'nodo1 = Trim(dtTabla.Rows(0).Item(7))
            'test = Trim(dtTabla.Rows(0).Item(1))

            CrearNodosDelPadre(0, Nothing) 'Llamo al proceso que llena el treeview

            ''''''

            'Dim NodoBloque As New TreeNode
            'Dim NodoEdificio As TreeNode
            'Dim NodoPiso As TreeNode
            'Dim NodoHabitacion As TreeNode


            '' Dim DRS As DataRow() = dt.Select("", "Grupos_Temas, TemaID, Subtema")
            'Dim DRS As DataRow() = dt.Select("Grupos_Temas, TemaID, Subtema")

            'For Each DR As DataRow In DRS

            '    If NodoBloque.Text <> DR("BLOQUE") Then
            '        NodoBloque = New TreeNode(DR("BLOQUE"))
            '        Me.TreeView1.Nodes.Add(NodoBloque)
            '        NodoEdificio = New TreeNode
            '    End If

            '    If NodoEdificio.Text <> DR("EDIFICIO") Then
            '        NodoEdificio = New TreeNode(DR("EDIFICIO"))
            '        NodoBloque.Nodes.Add(NodoEdificio)
            '        NodoPiso = New TreeNode
            '    End If

            '    If NodoPiso.Text <> DR("PISO") Then
            '        NodoPiso = New TreeNode(DR("PISO"))
            '        NodoBloque.Nodes.Add(NodoPiso)
            '    End If

            '    NodoHabitacion = New TreeNode(DR("HABITACION"))

            '    NodoPiso.Nodes.Add(NodoHabitacion)
            'Next
            ' '''''
            'Dim tablaArbol As DataTable

            'dataSetArbol = New DataSet("DataSetArbol")

            'tablaArbol = dataSetArbol.Tables.Add("dt")
            'tablaArbol.Columns.Add("NombreNodo", GetType(String))
            'tablaArbol.Columns.Add("IdentificadorNodo", GetType(Integer))
            'tablaArbol.Columns.Add("IdentificadorPadre", GetType(Integer))

            'InsertarDataRow("Nodo 1", 1, 0)
            'InsertarDataRow("Nodo 1.1", 2, 1)
            'InsertarDataRow("Nodo 1.1.1", 3, 2)
            'InsertarDataRow("Nodo 1.1.2", 4, 2)
            'InsertarDataRow("Nodo 1.2", 5, 1)

            'InsertarDataRow("Nodo 2", 6, 0)
            'InsertarDataRow("Nodo 2.1", 7, 6)
            'InsertarDataRow("Nodo 2.2", 8, 6)

            'InsertarDataRow("Nodo 3", 9, 0)
            'InsertarDataRow("Nodo 3.1", 10, 9)
            'InsertarDataRow("Nodo 3.2", 11, 9)
            'End Sub
            ''''
            '' dgvListaDatos.DataSource = dt
            'ByVal indicePadre As Integer, ByVal nodePadre As TreeNode

            '' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
            ''  For Each dataRowCurrent As DataRowView In dt
            'Dim n As Integer

            '' dt = CapaLogica.GetDatosChecklist(criterio)
            'n = dt.Rows.Count
            'For i = 0 To n - 1


            '    CrearNodosDelPadre(0, Nothing)


            'Dim nuevoNodo As New TreeNode
            ''nuevoNodo.Text = dataRowCurrent("NombreNodo").ToString().Trim()
            'nuevoNodo.Text = Trim(dt.Rows(i).Item(0))

            '' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            '' del primer nivel que no dependen de otro nodo.
            'If nodePadre Is Nothing Then
            '    TreeView1.Nodes.Add(nuevoNodo)
            'Else
            '    ' se añade el nuevo nodo al nodo padre.
            '    nodePadre.Nodes.Add(nuevoNodo)
            'End If

            '' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            'CrearNodosDelPadre(Int32.Parse(dataRowCurrent("IdentificadorNodo").ToString()), nuevoNodo)
            ''Next dataRowCurrent



            ' Next i



        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()


            ' dgvListaDatos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvListaDatos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvListaDatos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' dgvListaDatos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' dgvListaDatos.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells






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

            'Descripción o texto del nodo
            nuevoNodo.Text = dataRowCurrent("Subtema").ToString().Trim()

            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nuevoNodo.Name = dataRowCurrent("Id").ToString().Trim()

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nuevoNodo.Tag = dataRowCurrent("Secuencia").ToString().Trim()
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

    End Sub
    Public Sub cargarDatos()
        Dim sqlstring As String
        Dim cmd As New OleDbCommand

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter
        Dim ObjReader As OleDbDataReader

        Try
            conexion.Open()

            sqlstring = "select * from Temas "
            sqlstring = sqlstring & " ORDER By Tema ASC"
            cmd.Connection = conexion
            cmd.CommandText = sqlstring
            da.SelectCommand = cmd

            da.Fill(dt)



            ObjReader = cmd.ExecuteReader

            'cboCategoria.DataSource = dt
            'cboCategoria.DisplayMember = "Id"
            While ObjReader.Read()

                Me.cboTipos.Items.Add(New DictionaryEntry(ObjReader("Tema"), ObjReader(1)))
                Me.cboTipos.DisplayMember = "Key"
                Me.cboTipos.ValueMember = "Value"

            End While
        Catch ae As OleDbException
            MsgBox(ae.Message())

        Finally
            conexion.Close()

        End Try



        ' dgvEncDatos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '  dgvEncDatos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvEncDatos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '  dgvEncDatos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        'dgvEncDatos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datagrid.Columns[0].AutoSizeMode =DataGridViewAutoSizeColumnMode.Fill
        '  dgvEncDatos.Columns(0).AutoSizeMode = True
        'dgvEncDatos.Columns(0).MinimumWidth = True
        ' dgvEncDatos.Columns(0).Visible = False

    End Sub



    Public Function AbrirConexion()
        Try
            conexion.Open()
            If conexion.State = 1 Then
                Return True
            Else
                Return False

            End If

        Catch ex As Exception
            Return False

        End Try


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
        Dim cmd As New OleDbCommand
        Dim i As Integer

        Try
            conexion.Open()
            sqlstring = "insert into Enc_gastos (descripcion) values ('" & txtDescripcion.Text & "')"

            cmd.Connection = conexion
            cmd.CommandText = sqlstring

            i = cmd.ExecuteNonQuery
            If i > 0 Then
            Else
                MsgBox("No se guardo")
            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try

        'Try
        '    'instruccion.ExecuteNonQuery()
        '    'instruccion.Dispose()
        '    'conexion.Close()
        '    MsgBox("Registro insertado")

        'Catch ex As Exception
        '    MsgBox(ex.Message)

        'End Try
        ''If rowcount > 0 Then
        '    MsgBox("Registro insertado")
        '    txtDescripcion.Text = ""
        'Else



        'End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim sqlstring As String
        Dim cmd As New OleDbCommand
        Dim i As Integer

        Try

            conexion.Open()
            sqlstring = "Update Enc_gastos SET descripcion = @descripcion, frec=@frec Where ID=@id"

            cmd.Connection = conexion
            cmd.CommandText = sqlstring
            cmd.Parameters.AddWithValue("descripcion", txtDescripcion.Text)
            cmd.Parameters.AddWithValue("frec", txtfrec.Text)
            'cmd.Parameters.AddWithValue("id", txtID.Text)

            'instruccion = New OleDbCommand("insert into Det_gastos (descripcion) values (txtDescripcion)")
            'instruccion.Parameters.AddWithValue("@descripcion", txtDescripcion.Text)
            'instruccion.Parameters.Add(New OleDbParameter("descripcion", CType(txtDescripcion.Text, String)))
            'instruccion.Parameters.Add(New OleDbParameter("cant", CType(txtCantidad.Text, String)))
            'instruccion.Parameters.Add(New OleDbParameter("fecha", dtpFecha.Value))
            'instruccion.ExecuteNonQuery()


            '  result = cmd.ExecuteNonQuery()

            i = cmd.ExecuteNonQuery
            If i > 0 Then
            Else
                MsgBox("No se actualizo")
            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()


        End Try

        cargarDatos()

        'Dim cmd As New SqlCommand("Update EmployeeDetail Set Salary = '" & dgvEmpDetail.Rows(i).Cells(1).Value & "', 
        'Experience ='" & dgvEmpDetail.Rows(i).Cells(2).Value & "', 
        'Skills='" & dgvEmpDetail.Rows(i).Cells(3).Value() & "' 
        'where Emp_ID = '" & dgvEmpDetail.Rows(i).Cells(0).Value & "'", con)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        cargarDatos()

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

    End Sub





    Private Sub dgvSubtemas_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub



    Private Sub cboTipos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipos.SelectedIndexChanged
        Dim IdTipo As Integer

        If Me.cboTipos.SelectedIndex < 1 Then Exit Sub


        IdTipo = Me.cboTipos.SelectedValue

        CargarGrupos(IdTipo)


        ' If Me.cboTipos.Text = "" Then Exit Sub
        'IdTema = Me.cboGrupos.SelectedValue

        ' CargarSubtemas(IdTipo)
    End Sub
    Public Sub CargarGrupos(IdTipo)
        Dim sqlstring As String
        Dim cmd As New OleDbCommand

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter

        If cboTipos.Text = "" Then Exit Sub
        If cboTipos.SelectedIndex < 1 Then Exit Sub


        Try
            conexion.Open()

            sqlstring = "select * from  Temas "
            sqlstring = sqlstring & " Where Grupo=" & IdTipo
            sqlstring = sqlstring & " ORDER By orden ASC"

            cmd.Connection = conexion
            cmd.CommandText = sqlstring
            da.SelectCommand = cmd

            da.Fill(dt)

            Me.cboGrupos.DataSource = dt
            Me.cboGrupos.ValueMember = "Id"
            Me.cboGrupos.DisplayMember = "Tema"


        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()

        End Try
    End Sub

    Private Sub cboGrupos_Layout(sender As Object, e As System.Windows.Forms.LayoutEventArgs) Handles cboGrupos.Layout

    End Sub

    Private Sub cboGrupos_LostFocus(sender As Object, e As System.EventArgs) Handles cboGrupos.LostFocus

        'If Me.cboTipos.Text = "" Then Exit Sub
        If Me.cboGrupos.Text = "" Then Exit Sub
        IdTema = Me.cboGrupos.SelectedValue

        CargarSubtemas(IdTema)
    End Sub




    Private Sub MenuStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub



    Private Sub cboGrupos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupos.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim SQL As String
        Dim cmd As New OleDbCommand

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter
        Try
            conexion.Open()

            'SQL = " SELECT Subtemas.Id, Subtemas.Subtema, Subtemas.estatus, Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.estado"
            SQL = " SELECT Subtemas.orden, Subtemas.Subtema, Subtemas.estatus,Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado ,Subtemas.Id"

            SQL = SQL & " FROM (Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id) INNER JOIN Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id "
            SQL = SQL & " ORDER BY Subtemas.Subtema ASC"

            cmd.Connection = conexion
            cmd.CommandText = SQL
            da.SelectCommand = cmd

            da.Fill(dt)

            'dgvListaDatos.DataSource = dt


            'dgvListaDatos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvListaDatos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvListaDatos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvListaDatos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvListaDatos.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells



        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()

        End Try
    End Sub



    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'CargarSubtemas(1)
    End Sub


    Private Sub dgvSubtemas_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)

    End Sub

    Private Sub dgvListaDatos_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvListaDatos_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvListaDatos_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Dim test As String

        'If dgvSubtemas.Rows.Count = 0 Then Exit Sub

        'Console.Write(Me.dgvListaDatos.Rows(e.RowIndex).Cells(2).Value.ToString())
        ' If Me.dgvSubtemas.Rows(e.RowIndex).Cells(6).Value.ToString() = "" Then
        Try
            'If Me.dgvListaDatos.Rows(e.RowIndex).Cells(6).Value.ToString() = "A" Then

            '    e.CellStyle.BackColor = Color.FromArgb(198, 239, 206)
            'ElseIf dgvListaDatos.Rows(e.RowIndex).Cells(6).Value.ToString() = "O" Then
            '    e.CellStyle.BackColor = Color.FromArgb(253, 190, 31)
            'Else
            '    e.CellStyle.ForeColor = Color.Black
            'End If
        Catch ex As Exception

        End Try



        'End If
    End Sub


    Private Sub CmdAbrir_Click(sender As System.Object, e As System.EventArgs) Handles CmdAbrir.Click
        Dim documentPath As String
        Dim archivo, carpeta As String
        Dim Resp, IdSubTema As Integer
        'Documents.Open(FileName:="C:\MyFiles\MyDoc.docx", ReadOnly:=True)
        ' documentPath = "C:\Legacy\MyDoc.docx"
        'Process.Start(documentPath)
        'archivo = dgvListaDatos.CurrentRow.Cells(1).Value.ToString()
        'IdSubTema = dgvListaDatos.CurrentRow.Cells(7).Value.ToString()

        If archivo = "" Then Exit Sub
        ' On Error Resume Next
        Dim objWord As Word.Application
        objWord = New Word.Application

        'carpeta = Me.dgvListaDatos.CurrentRow.Cells(4).Value.ToString()

        Try



            objWord.Documents.Open("C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".doc")

            objWord.Visible = True

            Resp = MsgBox("Registrar curso?", vbOKCancel + vbQuestion)
            If Resp = 1 Then
                bitacora(IdSubTema)

            End If

        Catch ex As Exception
            Resp = MsgBox("¿ Crear Nuevo ?", MsgBoxStyle.OkCancel)

            If Resp = 1 Then
                objWord = CreateObject("Word.Application")
                objWord.Visible = True
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
                objWord.ActiveDocument.SaveAs(FileName:="" & "C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".doc")
                ' objWord.SaveToFile("WordDocument.docx",)
            Else
                MsgBox("No Creado")
            End If



        End Try
    End Sub

    Public Sub bitacora(Id)
        Dim sqlstring As String
        Dim cmd As New OleDbCommand
        Dim i As Integer

        Try
            conexion.Open()
            sqlstring = "insert into Bitacora (SubtemaId, fecha) values ('" & Id & "', '" & Now & "')"

            cmd.Connection = conexion
            cmd.CommandText = sqlstring

            i = cmd.ExecuteNonQuery
            If i > 0 Then
            Else
                MsgBox("No se guardo")
            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try

        'Try
    End Sub

    Private Sub txtBuscar_LostFocus(sender As Object, e As System.EventArgs) Handles txtBuscar.LostFocus

        Dim sql As String
        Dim cmd As New OleDbCommand
        Dim buscar As String

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter

        Try
            conexion.Open()

            buscar = Me.txtBuscar.Text

            sql = " SELECT Subtemas.orden, Subtemas.Subtema, Subtemas.estatus,Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado ,Subtemas.Id"
            sql = sql & " FROM (Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id) INNER JOIN Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id "
            sql = sql & " Where Subtema like " & "'" & buscar & "'"
            sql = sql & " ORDER BY Subtemas.orden ASC"


            Console.Write(sql)
            cmd.Connection = conexion
            cmd.CommandText = sql
            da.SelectCommand = cmd

            da.Fill(dt)

            ' dgvListaDatos.DataSource = dt

        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try

        'dgvListaDatos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvListaDatos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvListaDatos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvListaDatos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvListaDatos.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells


    End Sub



    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Form1.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        CargarArbol()
    End Sub
    Private Sub CargarArbol()
        
    End Sub

    Private Sub TreeView1_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        Dim documentPath As String
        Dim archivo, carpeta As String
        Dim Resp, IdSubTema As Integer
        'Documents.Open(FileName:="C:\MyFiles\MyDoc.docx", ReadOnly:=True)
        ' documentPath = "C:\Legacy\MyDoc.docx"
        'Process.Start(documentPath)
        archivo = Me.TreeView1.Nodes.Item(TreeView1.SelectedNode.Index).Text
        IdSubTema = Me.TreeView1.Nodes.Item(TreeView1.SelectedNode.Index).Name
        'TreeView.SelectedNode = TreeView1.Nodes.Item(TreeView1.SelectedNode.Index + 1) ' <-- I thought this would work, but it doesn't
        If archivo = "" Then Exit Sub
        ' On Error Resume Next
        Dim objWord As Word.Application
        objWord = New Word.Application

        'carpeta = Me.dgvListaDatos.CurrentRow.Cells(4).Value.ToString()
        carpeta = Me.cboTipos.Text

        Try



            objWord.Documents.Open("C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".doc")

            objWord.Visible = True

            Resp = MsgBox("Registrar curso?", vbOKCancel + vbQuestion)
            If Resp = 1 Then
                bitacora(IdSubTema)

            End If

        Catch ex As Exception
            Resp = MsgBox("¿ Crear Nuevo ?", MsgBoxStyle.OkCancel)

            If Resp = 1 Then
                objWord = CreateObject("Word.Application")
                objWord.Visible = True
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
                objWord.ActiveDocument.SaveAs(FileName:="" & "C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".doc")
                ' objWord.SaveToFile("WordDocument.docx",)
            Else
                MsgBox("No Creado")
            End If



        End Try
    End Sub
End Class