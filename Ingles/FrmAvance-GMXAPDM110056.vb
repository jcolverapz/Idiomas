Imports System.Data
Imports System.Data.OleDb
Imports ADODB
Public Class FrmAvance
    Public conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\legacy\Ingles\Ingles.accdb")
    Public instruccion As New OleDbCommand
    Public contenedor As String
    Public sqlstring As String
    Public IdEnc As Integer
    Public mifecha As String
    Dim rowcount As Integer

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'llamamos al procedimiento
        
        '  listarTipo()

        Dim cmd As New OleDbCommand

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter
        Dim i As Integer
        Try
            conexion.Open()

            sqlstring = "select * from Grupos_Temas"
            cmd.Connection = conexion
            cmd.CommandText = sqlstring
            da.SelectCommand = cmd

            da.Fill(dt)


            'Do While i < dt.Rows.Count

            'Me.cboTema.Items.IndexOf(1).ToString()

            ' Me.cboTema.Items.Add(dt.Rows(i).Item(1))


            'Console.Write(dt.Rows(i).Item(0))

            Me.cboTema.DataSource = dt
            Me.cboTema.DisplayMember = "Grupos_Temas"
            Me.cboTema.ValueMember = "Id"

            '  i = i + 1
            ' Loop
            '
        Catch

        End Try


        'Dim str As String = "select * from Grupos_temas" ' where TemaId=" & IdTema
        ''Dim str As String = "select * from Subtemas where TemaId=" & CInt(FrmTemas.IdEnc)
        'Using cmd As New OleDb.OleDbCommand(str, conexion)
        '    Using da As New OleDbDataAdapter(cmd)
        '        Using newtable As New DataTable
        '            da.Fill(newtable)
        '            'dgvListaDatos.DataSource = newtable
        '            sqlstring = "select * from Grupos_Temas"
        '            cmd.Connection = conexion
        '            cmd.CommandText = sqlstring
        '            da.SelectCommand = cmd

        '            da.Fill(dt)

        '            ' dgvEncDatos.DataSource = dt



        '            Me.cboTema.DataSource = dt
        '        End Using
        '    End Using
        'End Using

    End Sub

    Public Sub cargardatos()
        'Dim oda As New OleDbDataAdapter
        'Dim ods As New DataSet
        'Dim consulta As String
        'consulta = "select * from Det_Gastos where IdGastos=" & CInt(Form2.IdEnc)

        'oda = New OleDbDataAdapter(consulta, conexion)
        'ods.Tables.Add("Enc_Gastos")
        'oda.Fill(ods.Tables("Enc_Gastos"))
        'dgvListaDatos.DataSource = ods.Tables("Enc_Gastos").DefaultView

        'dgvListaDatos.DataSource = Nothing
        'dgvListaDatos.Refresh()

        Dim str As String = "select * from Grupos_temas" ' where TemaId=" & IdTema
        'Dim str As String = "select * from Subtemas where TemaId=" & CInt(FrmTemas.IdEnc)
        Using cmd As New OleDb.OleDbCommand(str, conexion)
            Using da As New OleDbDataAdapter(cmd)
                Using newtable As New DataTable
                    da.Fill(newtable)
                    'dgvListaDatos.DataSource = newtable
                End Using
            End Using
        End Using


        FrmSubtemas.Show()

        '  IdTema = Me.dgve
        ' miId = Forms!Formulario18.Form("Subformulario Grupos_Temas")!id

        'Forms!Formulario10.LbID.Caption = miId
        'Forms!Formulario10.LbTema.Caption = Tema
        'Forms!Formulario10.id = miId


        'strNewRecord = "SELECT Subtemas.Id,Subtemas.estatus, Subtemas.Subtema,Subtemas.orden, Subtemas.TemaID" _
        '& " FROM Subtemas" _
        '& " WHERE (Subtemas.TemaID)=" & miId _
        '& " ORDER BY  Subtemas.orden ASC"
        'Forms!Formulario7.[Subformulario Subtemas].Form.RecordSource = strNewRecord


       



    End Sub

    
   
     

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim obj As New Pago

        obj.nombre = txtDescripcion.Text.Trim
        obj.horas = CInt(txtIdTema.Text.Trim)
        obj.categoria = cboTema.SelectedItem.ToString

        'mostramos datos del pago

        '  With lvdatos.Items
        '.Add("El trabajador es: " + obj.nombre)
        '.Add("horas trabajadas: " + obj.horas)

        ' .Add("El pago es: " + obj.calcularPago.ToString)


        ' End With



    End Sub

    Private Sub dgvListaDatos_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListaDatos.CellClick

        txtIdTema.Text = dgvListaDatos.CurrentRow.Cells(0).Value.ToString()
        cboTipo.Text = dgvListaDatos.CurrentRow.Cells(1).Value.ToString()
        txtDescripcion.Text = dgvListaDatos.CurrentRow.Cells(2).Value.ToString()
        Try
            ' dtpFecha.Value = dgvListaDatos.CurrentRow.Cells(3).Value.ToString()
        Catch ex As Exception
            'MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try




        ' txtCantidad.Text = FormatCurrency(dgvListaDatos.CurrentRow.Cells(1).Value.ToString())
        'string.Format("{0:C2}", b);
        cboStatus.Text = dgvListaDatos.CurrentRow.Cells(6).Value.ToString()
        ' On Error Resume Next
        ' dtpFecha.Value = dgvListaDatos.CurrentRow.Cells(3).Value.ToString()
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        Dim sqlstring As String
        Dim cmd As New OleDbCommand
        Dim i As Integer

        Try
            conexion.Open()

            cmd.Connection = conexion
            sqlstring = "Update Det_gastos SET tipo = @tipo, periodo=@periodo, fecha=@fecha, cant=@cant, status=@status   Where ID=@id"

            cmd.CommandText = sqlstring
            cmd.Parameters.AddWithValue("tipo", cboTipo.Text)
            cmd.Parameters.AddWithValue("periodo", txtDescripcion.Text)
            cmd.Parameters.AddWithValue("fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("cant", txtCantidad.Text)
            cmd.Parameters.AddWithValue("status", cboStatus.Text)

            cmd.Parameters.AddWithValue("id", txtIdTema.Text)

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
        cargardatos()


    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        'Dim conn As ADODB.Connection
        'Dim rs As ADODB.Recordset

        'dgvListaDatos.EndEdit()
        'Me.dgvListaDatos.Update()

        Dim sqlstring As String
        Dim cmd As New OleDbCommand
        Dim i As Integer
        Dim mifecha As String
        Try
            conexion.Open()
            cmd.Connection = conexion

            mifecha = FormatDateTime(dtpFecha.Value, DateFormat.ShortDate)
            ' mifecha= dtpFecha.CustomFormat "dd/MM/yyyy")

            ' sqlstring = "insert into Det_gastos (tipo,periodo,cant, IdGastos,fecha) values ('" & cboTipo.Text & "','" & txtDescripcion.Text & "','" & txtCantidad.Text & "', '" & Form2.IdEnc & "','" & dtpFecha.Value & "' )"
            sqlstring = "Insert into Det_gastos (tipo, periodo, cant,  fecha, IdGastos) values (@tipo,@periodo,@cant,@fecha,@IdGastos)"
            ' sqlstring = "Insert into Det_gastos ( fecha) values (@fecha)"
            'dtpFecha.CustomFormat = "dd/MM/yyyy"
            ' sqlstring = "Insert into Det_gastos (fecha) values (@fecha)"

            cmd.CommandText = sqlstring
            cmd.Parameters.AddWithValue("tipo", cboTipo.Text)
            cmd.Parameters.AddWithValue("periodo", txtDescripcion.Text)
            cmd.Parameters.AddWithValue("cant", txtCantidad.Text)

            cmd.Parameters.AddWithValue("fecha", mifecha)
            cmd.Parameters.AddWithValue("IdGastos", FrmTemas.IdEnc)


            i = cmd.ExecuteNonQuery

            i = 123

            If i > 0 Then
            Else
                MsgBox("No se guardo")
            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()


        End Try


        cargardatos()

        'conn = New ADODB.Connection
        'conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jolvera.SSWTECHNOLOGIES\OneDrive - SSW Holding Company, LLC\Documents\Personal\VS2010-Proyectos\Gastos\Database.accdb"

        'conn.CursorLocation = CursorLocationEnum.adUseClient
        '' Dim rs As New Recordset


        'Try
        '    conn.Open()
        '    'MsgBox("Conectado a la base de datos")

        'Catch ex As Exception
        '    MsgBox("no hay conexion")
        '    conn.Close()

        'End Try

        'rs = New ADODB.Recordset
        '' rs.CursorLocation = CursorLocationEnum.adUseClient
        '' rs.CursorType = CursorTypeEnum.adOpenDynamic
        ''rs.ActiveConnection = conn
        'rs.Open("select Id from Det_Gastos", conn, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic, 1)
        ''rs.Open("select * from Det_Gastos")

        'rs.MoveFirst()
        'txtDescripcion.Text = rs!Id
        'txtDescripcion.Text = rs.RecordCount
        ''txtDescripcion.Text = rs!fecha

        'rs.AddNew()

        '' With rs
        '' txtDescripcion.Text = rs!fecha

        '' End With

        'With rs
        '    'txtDescripcion.Text = Id
        'End With
        'If txtDescripcion.Text = "" Then
        '    MsgBox("Dato vacio")
        'Else
        'End If


        ''sqlstring = "insert into Det_gastos (descripcion,cant,fecha) values ('" & txtDescripcion.Text & "','" & txtCantidad.Text & "','" & dtpFecha.Value & "')"
        ''instruccion = New OleDbCommand(sqlstring, conn)
        ' ''instruccion = New OleDbCommand("insert into Det_gastos (descripcion) values (txtDescripcion)")
        ' ''instruccion.Parameters.AddWithValue("@descripcion", txtDescripcion.Text)
        ''instruccion.Parameters.Add(New OleDbParameter("descripcion", CType(txtDescripcion.Text, String)))
        ''instruccion.Parameters.Add(New OleDbParameter("cant", CType(txtCantidad.Text, String)))
        ''instruccion.Parameters.Add(New OleDbParameter("fecha", dtpFecha.Value))
        'instruccion.ExecuteNonQuery()

        'Try
        '    'instruccion.ExecuteNonQuery()
        '    'instruccion.Dispose()
        '    'conexion.Close()
        '    ' MsgBox("Registro insertado")

        'Catch ex As Exception
        '    MsgBox(ex.Message)

        'End Try
        'If rowcount > 0 Then
        '    MsgBox("Registro insertado")
        '    txtDescripcion.Text = ""
        'Else



        'End If
        'creamos el objeto

    End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        cargarDatos()

    End Sub

     

   

    Private Sub dgvListaDatos_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvListaDatos.CellFormatting
        If e.ColumnIndex = 5 Then
            'If  = "Pagado" Then
            '    e.CellStyle.BackColor = Color.Aqua
            'End If
        End If
    End Sub

    Private Sub cboTema_LostFocus(sender As Object, e As System.EventArgs) Handles cboTema.LostFocus

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter
        Dim i As Integer


        Me.txtIdTema.Text = Me.cboTema.SelectedValue




        Dim sqlstring As String
        Dim cmd As New OleDbCommand
        ' Dim i As Integer

        Try
           
            sqlstring = "select * from Temas Where" & Me.txtIdTema.Text
            cmd.Connection = conexion
            cmd.CommandText = sqlstring
            da.SelectCommand = cmd

            da.Fill(dt)

            Me.dgvListaDatos.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conexion.Close()
        End Try

        ' cargardatos()




        dgvListaDatos.Columns(0).Visible = False

        ' dgvListaDatos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvListaDatos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvListaDatos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvListaDatos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvListaDatos.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvListaDatos.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvListaDatos.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '  dgvListaDatos.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' dgvListaDatos.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvListaDatos.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvListaDatos.Columns(0).Visible = False
        dgvListaDatos.Columns(2).Visible = False
        dgvListaDatos.Columns(3).Visible = False
        ' dgvListaDatos.Columns(4).Visible = False
        ' dgvListaDatos.Columns(5).Visible = False
        ' dgvListaDatos.Columns(6).Visible = False
        '  dgvListaDatos.Columns(7).Visible = False

        'dgvListaDatos.Columns(3).DefaultCellStyle.Format = "dd-MM-yyyy"
        ' dgvListaDatos.Columns(5).DefaultCellStyle.Format = "C2"
        dgvListaDatos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvListaDatos.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter



        'Dim chk As New DataGridViewCheckBoxColumn()
        '  dgvListaDatos.Columns.Add(chk)
        ' chk.HeaderText = ""
        'chk.Name = "chk"
        'dgvListaDatos.Rows(2).Cells(3).Value = True



    End Sub


    Private Sub cboTema_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTema.SelectedIndexChanged

    End Sub
End Class