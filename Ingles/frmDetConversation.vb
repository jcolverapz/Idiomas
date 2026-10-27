
Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports RichTextBoxEx
Imports System.IO
Public Class frmDetConversation

#Region "variables"
    Public Id As Integer
    Public descripcion As String = ""
    Public Inicio As String = ""
    Dim tipo As String = ""

#End Region
    Public orden As Integer = -1
    Public IdOracion As Integer
    Public GrupoOracion As String
    Public contenedor As String
    Public sqlstring As String
    Public MaxColumna As Integer
    Public ColorActivo As Object = System.Drawing.Color.FromArgb(198, 255, 196)
     
    Dim avance As Integer
    Public consulta As String
    Dim rowcount As Integer
   
    Public Nombre As String = ""
    'Public Tipo As String = ""
    Public Status As String = ""
    Public Area As String = ""

    
    Public Departamento As String = ""
    Public Ubicacion As String = ""
    Public NombreEmpleado As String = ""
    Public ApellidoEmpleado As String = ""
    Public Anydesk As String = ""
    Public estadoCerrado As String = ""
    Public UsuarioCorreo As String = ""
    Public descripcionCorta As String = ""
    Public estado As String = ""
    Public UsuarioAbrioId As String = ""
    Public UsuarioAbrio As String = ""
    Public UsuarioAsignado As String = ""
    Public Usuario As String = ""
    Public UsuarioId As String = ""
    Public Categoria1 As String = ""

    Public ArchivoAdjunto As String = ""
    Public fechaAbrio As Date
    Public HoraAbrio As String = ""
    Public fechaTermino As String = ""
    Public HoraTermino As String = ""
    Public Approval As String = ""
    Public Prioridad As String = ""
    Public fechaEntrega As String = Format(Today, "dd-MM-yyyy")
    Public bandAsignado As Boolean
    Public TipoTicket As String = ""
    Dim Observaciones As String = ""
    Dim OrdenInicio As Integer
    'Traduccion
    Public TextoPlano As String = ""
    Public Oracion As String = ""
    Public GrupoOracionId As Integer

    Public traduccion As String = ""

    Public bandTimeValue As Boolean
    Public bandEstado As Boolean
    Public lstModificaciones As New ListView
    Public Aprendi As Boolean
    Dim _comando As SqlCommand = MetodosDatos.CrearComando()
    'Dim sqlstring As String
    'Dim IdOracion As Integer
    'Dim dt As New DataTable
    Dim da As New SqlDataAdapter
    Dim i As Integer
    Dim indice As Integer
    Dim nm As String
    Dim str() As String
    Dim tp As String
    Dim param As String = ""
    Dim q As Integer

    ' Dim resp As Nullable(Of Integer)
    'nm = sender.name
    'str = nm.Split("_")

    'tp = str(0)
    'IdOracion = str(1)

    'sqlstring = "Upda From Det_Conversation "
    'sqlstring = sqlstring & "  WHERE Con_Id = '" & Id & "' And Det_Con='" & IdOracion & "'"


    '_comando.CommandText = sqlstring
    '_comando.Connection.Open()


    'Try

    '    i = _comando.ExecuteNonQuery

    '    If i > 0 Then
    '        'MsgBox("se guardo")
    '    Else
    '        'MsgBox("No se guardo")
    '    End If

    '    CrearControles()

    'Catch ex As Exception
    '    MsgBox(ex.Message)
    '    _comando.Connection.Close()

    'Finally

    'End Try
    'End Sub

    'Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)


    '    'If Me.cboTipo.Text <> Tipo Then

    '    '    DetectChanges("Tipo", Tipo, sender)

    '    'End If

    'End Sub

    'Private Sub cboStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    '    'If Me.cboStatus.Text <> Status Then

    '    '    DetectChanges("Status", Status, sender)

    '  
    ' 
    ' '' End Sub


    ''Private Sub cboUbicacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboUbicacion.SelectedIndexChanged
    ''    If Me.cboUbicacion.Text <> Ubicacion Then

    ''        DetectChanges("AreaId", Ubicacion, cboUbicacion.Items(cboUbicacion.SelectedIndex).ItemData(), "Location: " & cboUbicacion.Text)

    ''    End If
    ''End Sub

    ''Private Sub cboCategory1_LostFocus(sender As Object, e As System.EventArgs) Handles cboCategory1.LostFocus

    ''    Dim param As String = ""
    ''    Dim i, n As Integer



    ''    If Me.cboCategory1.Text = "" Then
    ''        Me.cboCategory2.Items.Clear()
    ''        Me.cboCategory2.Text = ""

    ''        Exit Sub
    ''    End If

    ''    Me.cboCategory2.Items.Clear()

    ''    'Categoria 2
    ''    Dim Categoria2 As DataTable
    ''    param = " Where Tbl_RT_Tipo.Tip_Id=" & cboCategory1.Items(cboCategory1.SelectedIndex).ItemData()
    ''    Categoria2 = CapaLogica.CatalogoCategoria2(param)
    ''    i = 0
    ''    n = Categoria2.Rows.Count

    ''    Do While i <= n - 1
    ''        Me.cboCategory2.Items.Add(New clsItem(Categoria2.Rows(i).Item(1), Categoria2.Rows(i).Item(0)))
    ''        i = i + 1
    ''    Loop
    ''    Me.cboCategory2.SelectedIndex = -1
    ''    Me.cboCategory2.Text = ""







    ''End Sub

    ''Private Sub cboCategory1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCategory1.SelectedIndexChanged
    ''    Dim param As String = ""
    ''    Dim i, n As Integer


    ''    If Me.cboCategory1.Text <> Categoria1 Then
    ''        'param =
    ''        DetectChanges("Tip_Id", Tipo, cboCategory1.Items(cboCategory1.SelectedIndex).ItemData(), "Category 1: " & cboCategory1.Text)
    ''        Categoria1 = cboCategory1.Text


    ''        Me.cboCategory2.Items.Clear()

    ''        'Categoria 2
    ''        Dim Categoria2 As DataTable
    ''        param = " Where Tbl_RT_Tipo.Tip_Id=" & cboCategory1.Items(cboCategory1.SelectedIndex).ItemData()
    ''        Categoria2 = CapaLogica.CatalogoCategoria2(param)
    ''        i = 0
    ''        n = Categoria2.Rows.Count

    ''        Do While i <= n - 1
    ''            Me.cboCategory2.Items.Add(New clsItem(Categoria2.Rows(i).Item(1), Categoria2.Rows(i).Item(0)))
    ''            i = i + 1
    ''        Loop
    ''    End If

    ''    Me.cboCategory2.SelectedIndex = -1
    ''    Me.cboCategory2.Text = ""

    ''End Sub

    ''Private Sub cboCategory2_LostFocus(sender As Object, e As System.EventArgs) Handles cboCategory2.LostFocus
    ''    'If Trim(cboCategory2.Text) <> "" Then
    ''    '    CmdGuardar.Enabled = True
    ''    'Else
    ''    '    CmdGuardar.Enabled = False
    ''    'End If
    ''End Sub

    ''Private Sub cboCategory2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCategory2.SelectedIndexChanged

    ''    If Me.cboCategory2.Text <> Categoria2 Then
    ''        DetectChanges("Cat_Id", Categoria2, cboCategory2.Items(cboCategory2.SelectedIndex).ItemData(), "Category 2: " & cboCategory2.Text)
    ''        Categoria2 = cboCategory2.Text
    ''    End If

    ''    If Trim(cboCategory2.Text) <> "" Then
    ''        CmdGuardar.Enabled = True
    ''    Else
    ''        CmdGuardar.Enabled = False
    ''    End If

    
    ''  
     
    Private Sub frmDetConversation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        cboTipo.Items.Add("ALL")
        cboTipo.Items.Add("Saludo")
        cboTipo.Items.Add("Presentacion")
        cboTipo.Items.Add("Iniciando")
        cboTipo.Items.Add("Frases")
        cboTipo.Items.Add("Conversacion")
        cboTipo.Items.Add("Conversacion basica")
        cboTipo.Items.Add("Leccion")
        cboTipo.Items.Add("Leccion Nivel 1")
        cboTipo.Items.Add("Leccion Nivel 2")
        cboTipo.Items.Add("Serie")
        cboTipo.Items.Add("Audios")

    End Sub

    Public Sub CargarConversation(Id)
        Dim param As String = " WHERE Oraciones.Id=" & Id
        Dim resp As Integer

        Dim i, n As Integer
        Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Det_Conversation.Det_Person, Det_Conversation.Det_Par, Oraciones.Oracion, "
        sqlstring = sqlstring & " Enc_Conversation.Con_Titulo, Enc_Conversation.Con_Id"
        sqlstring = sqlstring & " FROM            Det_Conversation d INNER JOIN"
        sqlstring = sqlstring & "              Enc_Conversation e ON d.Con_Id = e.Con_Id INNER JOIN"
        sqlstring = sqlstring & "              Oraciones o ON d.Det_OracionId = Oraciones.Id"

        sqlstring = sqlstring & param

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

        Do While i <= n - 1
            Me.cboTipo.Items.Add(New clsItem(dt.Rows(i).Item(7), dt.Rows(i).Item(8)))
            i = i + 1
        Loop



    End Sub

    Public Sub CargarDatos(Id)
        Dim resp As Integer
        Dim i, n As Integer
        Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Dim carpeta As String = ""
        Dim filename As String = ""

        Dim param As String = " WHERE Enc_Conversation.Con_Id=" & Id

        sqlstring = "select * from  Enc_Conversation "

        sqlstring = sqlstring & param

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


        resp = dt.Rows.Count

        If resp = 0 Then Exit Sub

        Id = dt.Rows(0).Item(0)

        txtId.Text = Id

        If Not IsDBNull(dt.Rows(0).Item(1)) Then
            descripcion = dt.Rows(0).Item(1)
        End If
        txtDescripcion.Text = descripcion

        If Not IsDBNull(dt.Rows(0).Item(2)) Then
            orden = dt.Rows(0).Item(2)
        End If
        txtOrden.Text = orden

        If Not IsDBNull(dt.Rows(0).Item(7)) Then
            avance = dt.Rows(0).Item(7)
        End If
        txtavance.Text = avance

        If Not IsDBNull(dt.Rows(0).Item(8)) Then
            tipo = dt.Rows(0).Item(8)
        End If
        cboTipo.Text = tipo

        If Not IsDBNull(dt.Rows(0).Item(11)) Then
            Inicio = dt.Rows(0).Item(11)
        End If
        txtInicio.Text = Inicio

        If Not IsDBNull(dt.Rows(0).Item(12)) Then
            Observaciones = dt.Rows(0).Item(12)
        End If
        txtObserv.Text = Observaciones

        If Not IsDBNull(dt.Rows(0).Item(13)) Then
            OrdenInicio = dt.Rows(0).Item(13)
        End If
        txtOrdenInicio.Text = OrdenInicio

    End Sub

    'Public Sub CargarHistorial(Id)
    '    Dim param As String = " WHERE Tbl_RT_Historial.Enc_Id=" & Id
    '    Dim DatosHistorial As DataTable
    '    Dim resp As Integer
    '    ' Dim Empleados As DataTable
    '    Dim i, n As Integer
    '    Dim actividad As String
    '    Dim fechaHistorial As String = ""
    '    'DatosMantenimiento = CapaLogica.DatosEquiposMantenimiento(param)
    '    DatosHistorial = CapaLogica.Historial(param)

    '    resp = DatosHistorial.Rows.Count

    '    If resp = 0 Then Exit Sub
    '    n = DatosHistorial.Rows.Count

    '    i = 0
    '    ' lstActivities.Items.Clear()


    '    Dim User1 As String
    '    Do While i <= n - 1


    '        User1 = DatosHistorial.Rows(i).Item(5) & " " & DatosHistorial.Rows(i).Item(6) '& "                  " & actividad & " " & fechaHistorial


    '        Dim item As ListViewItem 'Creo el ListViewItem (item) 
    '        item = New ListViewItem(User1) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

    '        If DatosHistorial.Rows(i).Item(9) = "M" Then
    '            item.ImageIndex = 0
    '        Else
    '            DatosHistorial.Rows(i).Item(9) = "F"
    '            item.ImageIndex = 1

    '        End If

    '        item.UseItemStyleForSubItems = False

    '        Try

    '            actividad = DatosHistorial.Rows(i).Item(2) & "  " ' & DatosHistorial.Rows(i).Item(3)
    '            fechaHistorial = Format(DatosHistorial.Rows(i).Item(7), "dd-MMM-yyyy") '& "   " & Format(DatosHistorial.Rows(i).Item(8), "hh:mm tt")


    '            item.SubItems.Add(fechaHistorial)
    '            item.SubItems.Add(actividad)
    '            ' item.SubItems.Add(DatosHistorial.Rows(i).Item(3))

    '            item.SubItems(1).ForeColor = Color.SteelBlue
    '            item.SubItems(2).ForeColor = Color.Blue

    '            'lstActivities.Columns(0).TextAlign = HorizontalAlignment.Right
    '            'lstActivities.Columns(1).TextAlign = HorizontalAlignment.Right
    '            'lstActivities.Columns(2).TextAlign = HorizontalAlignment.Right
    '            'lstActivities.Columns(3).TextAlign = HorizontalAlignment.Right


    '            'item.SubItems(1).ForeColor = Color.Brown
    '            ' item.SubItems.Add(Format(DatosHistorial.Rows(i).Item(7), "dd-MMM-yyyy hh:mm tt")).
    '            ' 'item.SubItems.Add(DatosHistorial.Rows(i).Item(2))

    '            'item.SubItems.Add(DatosHistorial.Rows(i).Item(3))
    '            ' item.SubItems.Add(DatosHistorial.Rows(i).Item(4))



    '        Catch ex As Exception
    '        End Try

    '        ' lstActivities.Items.Add(item)


    '        i = i + 1
    '    Loop



    'End Sub

    'Private Sub Solution(param)
    '    Dim frm As New frmReport

    '    AddOwnedForm(frm)

    '    frm.His_Id = param
    '    frm.CargarDatos(param)
    '    frm.Show()
    '    ' frmSolution.CargarDatos(param)
    '    ' frmSolution.Show()

    'End Sub
    'Private Sub Adjunto(param)

    '    Try
    '        If var.Planta = "Planta SLP" Then
    '            Process.Start("explorer.exe", "\\10.18.164.207\Adjuntos$\Reportes_tickets\" & Id & "\" & ArchivoAdjunto)

    '        Else
    '            Process.Start("explorer.exe", "\\10.18.172.30\Adjuntos\Reportes_tickets\" & Id & "\" & ArchivoAdjunto)
    '        End If




    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    ' frmSolution.CargarDatos(param)
    '    ' frmSolution.Show()
    'End Sub

    'Private Sub NewReport(HisId)
    '    'frmNewReport.Text = HisId

    '    Dim frm As New frmNewReport

    '    frm.lblNumber.Text = HisId
    '    frm.ShowDialog()

    '    CrearControles()


    '    'MessageBox.Show("Dynamic event happened!" & sender)
    'End Sub
    'Private Sub MarkAsSolution(sender, e)
    '    'Dim resp As Boolean
    '    Dim resp As Integer
    '    Dim q As Integer
    '    Dim ln As Integer
    '    Dim str() As String
    '    Dim nm As String
    '    ' Dim resp As Nullable(Of Integer)
    '    nm = sender.name
    '    str = nm.Split("_")
    '    Dim tp As String
    '    Dim param As String = ""

    '    tp = str(0)
    '    q = str(1)

    '    resp = MsgBox("Mark as solution?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

    '    If resp = 6 Then
    '        sender.BackColor = Color.LightGreen
    '        param = "S"
    '    Else
    '        sender.BackColor = Color.WhiteSmoke
    '        param = "N"

    '    End If

    '    resp = CapaLogica.EditarSolucion(q, param)

    '    If resp = True Then
    '        'MessageBox.Show("Successfully Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        CrearControles()

    '    End If
    '    If resp = True Then

    '    End If
    'End Sub
    'Private Sub AnswerYes(_btn As Object, e As EventArgs)



    'End Sub

    ''With pEtapa.Controls.Item("pAux" & q).Controls.Item("btnNo_" & q)
    ''    If .BackColor = Color.Red Then
    ''        .BackColor = Gris

    ''    End If
    ''End With

    ''Private Sub menu_year(ByVal intYear As Integer)
    ''    MsgBox(intYear)
    ''    'do something
    ''End Sub
    ''Private Sub txtFecha_Clicked(sender As Object, e As System.Windows.Forms.LinkClickedEventArgs)
    ''    System.Diagnostics.Process.Start(e.LinkText)
    ''End Sub

    ''Private Sub cboUsuario_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
    ''    'Me.txtUsuarioId.Text = cboUsuario.Items(cboUsuario.SelectedIndex).ItemData()
    ''    'Me.txtUsuario.Text = cboUsuario.Text

    ''End Sub

    ''Private findListView As New ListView()
    'Private Sub roundCorners(obj As Object)
    '    Dim DGP As New Drawing2D.GraphicsPath
    '    FormBorderStyle = FormBorderStyle.FixedSingle

    '    DGP.StartFigure()

    '    'TOP LEft 
    '    DGP.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
    '    DGP.AddLine(20, 0, obj.Width - 20, 0)

    '    'top right
    '    DGP.AddArc(New Rectangle(obj.Width - 40, 0, 40, 40), -90, 90)
    '    DGP.AddLine(obj.Width, 40, obj.Width, obj.Height - 40)

    '    'bottom right

    '    DGP.AddArc(New Rectangle(obj.Width - 40, obj.Height - 40, 40, 40), 0, 90)
    '    DGP.AddLine(obj.Width - 40, obj.Height, 40, obj.Height)

    '    'bottom left

    '    DGP.AddArc(New Rectangle(0, obj.Height - 40, 40, 40), 90, 90)
    '    'DGP.AddLine(obj.Width - 40, obj.Height, 40, obj.Height)
    '    DGP.CloseFigure()
    '    obj.Region = New Region(DGP)

    'End Sub
    Private Sub DetectChanges(Nombre, valor, NuevoValor, param)
        Dim item As ListViewItem 'Creo el ListViewItem (item) 
        Dim i As Integer

        i = lstModificaciones.Items.Count + 1

        If lstModificaciones.Items.Count = 0 Then

            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.SubItems.Add(Nombre)
            item.SubItems.Add(valor)
            item.SubItems.Add(NuevoValor)
            item.SubItems.Add(param)

            lstModificaciones.Items.Add(item)

        Else

            Dim foundItem As ListViewItem = lstModificaciones.FindItemWithText(Nombre, True, 0, True)

            If (foundItem IsNot Nothing) Then

                lstModificaciones.Items(foundItem.Index).SubItems(1).Text = Nombre
                lstModificaciones.Items(foundItem.Index).SubItems(2).Text = valor
                lstModificaciones.Items(foundItem.Index).SubItems(3).Text = NuevoValor
                lstModificaciones.Items(foundItem.Index).SubItems(4).Text = param

            Else
                item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

                item.SubItems.Add(Nombre)
                item.SubItems.Add(valor)
                item.SubItems.Add(NuevoValor)
                item.SubItems.Add(param)

                lstModificaciones.Items.Add(item)

            End If
        End If

        'lblmod.Text = "( " & lstModificaciones.Items.Count & " )"




    End Sub
    Private Sub Solution(Id)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer

        ' IdOracion = lstOraciones.SelectedItems(0).Text


        sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id)"
        sqlstring = sqlstring & " Values ('" & IdOracion & "', '0', '" & Id & "')"

        '  _comando.Connection = conexion
        _comando.CommandText = sqlstring
        _comando.Connection.Open()



        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                MsgBox("se guardo")

            Else
                MsgBox("No se guardo")
            End If

            ' CrearControles()


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub
    'Private Sub MoveDown(sender, e)
    '    Dim _comando As SqlCommand = MetodosDatos.CrearComando()
    '    Dim sqlstring As String
    '    Dim IdOracion As Integer
    '    Dim dt As New DataTable
    '    Dim da As New SqlDataAdapter
    '    Dim i As Integer
    '    Dim pos As Integer
    '    Dim n As Integer

    '    Dim itemOver As ListViewItem
    '    Dim itemCurr As ListViewItem
    '    Dim itemSel As Integer
    '    Dim indice As Integer
    '    Dim nm As String
    '    Dim str() As String

    '    Dim q As Integer

    '    ' Dim resp As Nullable(Of Integer)
    '    nm = sender.name
    '    Str = nm.Split("_")
    '    Dim tp As String
    '    Dim param As String = ""

    '    tp = Str(0)
    '    indice = str(1)


    '    n = ListView1.Items.Count

    '    If indice = -1 Then Exit Sub


    '    itemCurr = ListView1.Items(indice)


    '    If indice = ListView1.Items.Count - 1 Then

    '        'ListView1.Items.Remove(itemCurr)

    '    Else

    '        If indice >= ListView1.Items.Count - 1 Then

    '            ListView1.Items.Remove(itemCurr)

    '        Else

    '            ListView1.Items.Remove(itemCurr)
    '            ListView1.Items.Insert(indice + 1, itemCurr)

    '        End If


    '    End If
    '    ListView1.Refresh()

    '    _comando.Connection.Open()

    '    For Each r In ListView1.Items

    '        Console.WriteLine(r.SubItems(0).Text)
    '        Console.WriteLine(r.SubItems(1).Text)
    '        Console.WriteLine(r.SubItems(2).Text)
    '        Console.WriteLine(r.index)

    '        _comando.Parameters.Clear()

    '        '   item = New ListViewItem(lstAgregar.SelectedItems(0).Text()) 'Creo una nueva instancia de item pasandole el nombre como dato principal 




    '        If r.SubItems(2).text = "Null" Then
    '            sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
    '            sqlstring = sqlstring & " WHERE Id = @Id"
    '            '_comando.Parameters.AddWithValue("@Det_Orden", pos + 1)

    '        Else
    '            sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
    '            sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"

    '            '  _comando.Parameters.AddWithValue("@" & r.SubItems(1).Text, r.SubItems(3).Text)
    '            _comando.Parameters.AddWithValue("@Det_Orden", r.index)

    '        End If
    '        _comando.Parameters.AddWithValue("@Det_Con", r.SubItems(2).Text)


    '        _comando.CommandText = sqlstring


    '        i = _comando.ExecuteNonQuery


    '    Next
    '    _comando.Connection.Close()

    '    If i > 0 Then
    '    Else
    '        MsgBox("No se actualizo")
    '    End If
    '    'Bitacora
    '    'IdOracion = lstOraciones.SelectedItems(0).Text


    '    CrearControles()

    '    '_comando.CommandText = sqlstring

    '    'Try

    '    '    i = _comando.ExecuteNonQuery

    '    '    If i > 0 Then
    '    '        MsgBox("se guardo")
    '    '    Else
    '    '        MsgBox("No se guardo")
    '    '    End If

    '    '    CrearControles()

    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    'Finally

    '    'End Try
    'End Sub
    'Private Sub MoveUp(sender, e)
    '    Dim _comando As SqlCommand = MetodosDatos.CrearComando()
    '    Dim sqlstring As String
    '    Dim IdOracion As Integer
    '    Dim dt As New DataTable
    '    Dim da As New SqlDataAdapter
    '    Dim i As Integer
    '    Dim indice As Integer
    '    Dim itemCurr As ListViewItem
    '    Dim itemOver As ListViewItem
    '    Dim itemSel As Integer
    '    Dim nm As String
    '    Dim str() As String
    '    Dim tp As String
    '    Dim param As String = ""
    '    Dim q As Integer

    '    ' Dim resp As Nullable(Of Integer)
    '    nm = sender.name
    '    Str = nm.Split("_")

    '    tp = Str(0)
    '    indice = Str(1)

    '    itemCurr = ListView1.Items(indice)


    '    'If indice = ListView1.Items.Count - 1 Then

    '    'ListView1.Items.Remove(itemCurr)
    '    '   If ListView1.SelectedItems(0).Index = -1 Then Exit Sub

    '    '  indice = ListView1.SelectedItems(0).Index
    '    'itemCurr = ListView1.SelectedItems(0)
    '    itemCurr = ListView1.Items(indice)

    '    If indice = ListView1.Items.Count - 1 Then
    '        ListView1.Items.Remove(itemCurr)
    '        ListView1.Items.Insert(indice - 1, itemCurr)
    '    Else

    '        If indice = 0 Then
    '            ' ListView1.Items.Remove(itemCurr)
    '        Else
    '            ListView1.Items.Remove(itemCurr)
    '            ListView1.Items.Insert(indice - 1, itemCurr)
    '        End If
    '    End If

    '    ListView1.Refresh()


    '    _comando.Connection.Open()


    '    For Each r In ListView1.Items


    '        _comando.Parameters.Clear()

    '        If r.SubItems(2).text = "Null" Then
    '            sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
    '            sqlstring = sqlstring & " WHERE Id = @Id"

    '        Else
    '            sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
    '            sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"

    '            _comando.Parameters.AddWithValue("@Det_Orden", r.index)

    '        End If
    '        _comando.Parameters.AddWithValue("@Det_Con", r.SubItems(2).Text)



    '        Try
    '            _comando.CommandText = sqlstring

    '            i = _comando.ExecuteNonQuery


    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        Finally

    '        End Try


    '    Next


    '    'If i > 0 Then
    '    '    MsgBox("se guardo")
    '    'Else
    '    '    MsgBox("No se guardo")
    '    'End If

    '    CrearControles()







    'End Sub
    'Private Sub Delete(sender, e)
    '    Dim _comando As SqlCommand = MetodosDatos.CrearComando()
    '    Dim sqlstring As String
    '    Dim IdOracion As Integer
    '    Dim dt As New DataTable
    '    Dim da As New SqlDataAdapter
    '    Dim i As Integer
    '    Dim indice As Integer
    '    Dim nm As String
    '    Dim str() As String
    '    Dim tp As String
    '    Dim param As String = ""
    '    Dim q As Integer

    '    ' Dim resp As Nullable(Of Integer)
    '    nm = sender.name
    '    str = nm.Split("_")

    '    tp = str(0)
    '    IdOracion = str(1)

    '    sqlstring = "Delete From Det_Conversation "
    '    sqlstring = sqlstring & "  WHERE Con_Id = '" & Id & "' And Det_Con='" & IdOracion & "'"


    '    _comando.CommandText = sqlstring
    '    _comando.Connection.Open()


    '    Try

    '        i = _comando.ExecuteNonQuery

    '        If i > 0 Then
    '            'MsgBox("se guardo")
    '        Else
    '            'MsgBox("No se guardo")
    '        End If

    '        CrearControles()

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        _comando.Connection.Close()

    '    Finally

    '    End Try
    'End Sub
    'Private Sub Editar(sender, e)


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer

        ' sqlstring = "select * from  SubTemas "
        '    conexion.Open()

        'If cmbPersona.Text = "" Then Exit Sub
        'Try
        '    If lstOraciones.SelectedItems(0).Text = "" Then Exit Sub

        'Catch ex As Exception
        '    Exit Sub
        'End Try

        'IdOracion = lstOraciones.SelectedItems(0).Text
        ''Desc = lstOraciones.SelectedItems(0).Text

        sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
        ' sqlstring = sqlstring & " Values ('" & IdOracion & "', '0', '" & Id & "', '" & cmbPersona.Text & "')"

        '  _comando.Connection = conexion
        _comando.CommandText = sqlstring
        _comando.Connection.Open()




        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                MsgBox("se guardo")

            Else
                MsgBox("No se guardo")
            End If

            'CrearControles()


            '_comando.CommandText = sqlstring
            '_comando.Connection.Open()

            'da.SelectCommand = _comando

            'da.Fill(dt)

            '_comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        ' txtBuscar.Text = ""


        'If cmbPersona.Text = 1 Then
        '    cmbPersona.Text = 2
        'Else
        '    cmbPersona.Text = 1
        'End If
        ' RichTextBox1.LoadFile("C:\Legacy\Test.rtf")

    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        'Me.Close()
        Dim param As String

        Try

            lstModificaciones.Items.Clear()

            Dim frm As frmItemsConversation = CType(Owner, frmItemsConversation)

            frm.CargarDatos()

            Me.Close()
            Me.Dispose()
        Catch ex As Exception

            Me.Close()
            Me.Dispose()
            Exit Sub

        End Try

    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim buscar As String
        Dim sqlstring As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        ' Dim da As New OleDbDataAdapter
        Dim i, n As Integer
        'Try
        ' conexion.Open()
        ' lstOraciones.Items.Clear()

        ' buscar = Trim(Me.txtBuscar.Text)
        If buscar = "" Then Exit Sub

        sqlstring = " SELECT Id, TextoPlano, Traduccion  FROM Oraciones"

        sqlstring = sqlstring & " Where TextoPlano LIKE " & "'%" & buscar & "%'"
        sqlstring = sqlstring & " ORDER BY Oraciones.TextoPlano ASC"

        ' param = " WHERE Enc_Id  LIKE " & "'%" & param & "%'"


        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            _comando.Connection.Close()

        Finally

        End Try
        '    Console.Write(sql)
        '    cmd.Connection = conexion
        '    cmd.CommandText = sql
        '    da.SelectCommand = cmd
        n = dt.Rows.Count
        '    da.Fill(dt)
        i = 0

        Do While i <= n - 1

            ' lstAgregar.Items.Add(i)

            Dim item As ListViewItem 'Creo el ListViewItem (item) 


            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.UseItemStyleForSubItems = False
            item.Text = dt.Rows(i).Item(0)
            Try

                'item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(1))
                item.SubItems.Add(dt.Rows(i).Item(2))

                item.SubItems(0).ForeColor = Color.Blue

                '   lstOraciones.Items.Add(item)


            Catch ex As Exception

            End Try


            'Agrego el item a la colección de listViewItem's de ListView1

            i = i + 1

        Loop



    End Sub

    Private Sub lstOraciones_DoubleClick(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub lstOraciones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        'Id = lstOraciones.SelectedItems(0).Text

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        Dim n As Integer
        Dim pos As Integer

        '  n = ListView1.Items.Count

        pos = 1

        'IdOracion = lstOraciones.SelectedItems(0).Text

        'sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
        'sqlstring = sqlstring & " WHERE Id = @Id"

        '_comando.Parameters.AddWithValue("@Det_Orden", pos + 1)


        '_comando.CommandText = sqlstring
        '_comando.Connection.Open()

        Dim itemCurr As ListViewItem
        Dim itemOver As ListViewItem
        Dim itemSel As Integer
        Dim indice As Integer


        ' indice = ListView1.SelectedIndices.Item(0)
        'If ListView1.SelectedItems(0).Index = -1 Then Exit Sub

        'indice = ListView1.SelectedItems(0).Index


        'itemCurr = ListView1.SelectedItems(0)


        'If indice = ListView1.Items.Count - 1 Then

        '    'ListView1.Items.Remove(itemCurr)

        'Else

        '    If indice >= ListView1.Items.Count - 1 Then

        '        ListView1.Items.Remove(itemCurr)

        '    Else
        '        ListView1.Items.Remove(itemCurr)

        '        ListView1.Items.Insert(indice + 1, itemCurr)

        '    End If


        ' End If





    End Sub


    'Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
    '    Dim IdOracion As Integer


    '    ' sqlstring = "select * from  SubTemas "
    '    '    conexion.Open()
    '    '  If cmbPersona.Text = "" Then Exit Sub
    '    IdOracion = txtId.Text


    '    Dim frm As New frmNewConversation
    '    frm.IdOracion = IdOracion
    '    '  frm.IdPersona = cmbPersona.Text

    '    frm.ShowDialog()

    '    ' CrearControles()





    'End Sub

    

    'Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
    '    frmNewOracion.Show()

    'End Sub

    Private Sub CmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim resp As Boolean
        Dim respcorreo As Boolean
        Dim item As ListViewItem

        Dim i As Integer
        Dim _insertado As Boolean = False
        Dim mostrarMensaje As Boolean = False
        Dim stringvalues As String = ""
        Dim sql As String = ""
        Dim IdMax As Integer

        Dim fecha As Date
        Dim fechaEntrega As Date

        _comando.Connection.Open()


        For Each r In lstModificaciones.Items

            _comando.Parameters.Clear()

            ' Console.WriteLine(r.SubItems(1).Text)
            ' Console.WriteLine(r.SubItems(3).Text)

            If r.SubItems(3).text = "Null" Then
                sqlstring = "UPDATE Enc_Conversation SET " & r.SubItems(1).Text & " = Null"
                sqlstring = sqlstring & " WHERE Con_Id = @Con_Id"

            Else
                sqlstring = "UPDATE Enc_Conversation SET " & r.SubItems(1).Text & " = @" & r.SubItems(1).Text
                sqlstring = sqlstring & " WHERE Con_Id = @Con_Id"

               
                _comando.Parameters.AddWithValue("@" & r.SubItems(1).Text, r.SubItems(3).Text)
                 

            End If



            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Con_Id", Id)
            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Next
        _comando.Connection.Close()


        If i > 0 Then
            'Return True
            ' MsgBox("Guardado")

        Else
            'Return False

        End If

        cmdExit_Click(sender, e)




    End Sub

    'Private Sub txtTraduccion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTraduccion.TextChanged
    '    If Me.txtTraduccion.Text <> traduccion Then
    '        Try
    '            DetectChanges("Traduccion", traduccion, txtTraduccion.Text, "")
    '            traduccion = txtTraduccion.Text
    '        Catch ex As Exception

    '        End Try
    '    End If
    'End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged
        If Me.txtDescripcion.Text <> descripcion Then
            Try
                DetectChanges("Con_Titulo", descripcion, txtDescripcion.Text, "")
                descripcion = txtDescripcion.Text
            Catch ex As Exception

            End Try
        End If
    End Sub


    Private Sub txtOrden_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOrden.TextChanged
        If Me.txtOrden.Text = "" Then Exit Sub
        If Not IsNumeric(Me.txtOrden.Text) Then Exit Sub

        If Me.txtOrden.Text <> orden Then
            Try
                DetectChanges("Con_orden", orden, txtOrden.Text, "")
                orden = txtOrden.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtavance_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtavance.TextChanged
        If Me.txtavance.Text = "" Then Exit Sub

        If Me.txtavance.Text <> avance Then
            Try
                DetectChanges("Con_avance", avance, txtavance.Text, "")
                orden = txtOrden.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    
    Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If Me.cboTipo.Text = "" Then Exit Sub

        If Me.cboTipo.Text <> tipo Then
            Try
                DetectChanges("Con_tipo", tipo, cboTipo.Text, "")
                tipo = cboTipo.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
         
        Dim resp As Integer
        Dim obj As PictureBox

        Dim filename As String = ""

        Dim Nombre As String
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()


        Clipboard.SetText(descripcion)


        ' Seleccionar Imagen
        Using ofd As New OpenFileDialog
            ofd.InitialDirectory = "C:\Legacy\Ingles\Imagenes_Ingles\"
            '  = IdPerson

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim _insertado As Boolean = False
                Dim mostrarMensaje As Boolean = False
                Dim stringvalues As String = ""
                Dim sql As String = ""

                filename = ofd.SafeFileName

                'Actualiza en Tbl Dialogos
                _comando.Connection.Open()

                sqlstring = "Update Enc_Conversation SET IMG='" & filename & "'"
                sqlstring = sqlstring & "  WHERE Con_Id = '" & Id & "'"
                _comando.CommandText = sqlstring

                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    _comando.Connection.Close()
                    Exit Sub
                End Try

                _comando.Connection.Close()
                Try
                    PictureBox1.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\" & filename)

                Catch ex As Exception

                End Try


            End If

            _comando.Connection.Close()


        End Using

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim frm As New frmMoverDetalleConversacion

        frm.Enc_Id = Id

        frm.ShowDialog()

    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Dim frm As New frmTextoToDgv

        frm.Det_Id = Id

        frm.ShowDialog()

    End Sub

    Private Sub txtInicio_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtInicio.TextChanged
        If Me.txtInicio.Text <> Inicio Then
            Try
                DetectChanges("Inicio", Inicio, txtInicio.Text, "")
                Inicio = txtInicio.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmdOrdenarDialogos_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenarDialogos.Click
        Dim frm As New frmMoverDetalleConversacion
        frm.Enc_Id = Id

        frm.Show()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim frm As New frmTextoOrdenarDialogos
        frm.Id = Id

        frm.Show()
    End Sub

    Private Sub txtObserv_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtObserv.TextChanged
        If Me.txtObserv.Text <> Observaciones Then
            Try
                DetectChanges("Observaciones", Observaciones, txtObserv.Text, "")
                Observaciones = txtObserv.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtOrdenInicio_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOrdenInicio.TextChanged
        If Me.txtOrdenInicio.Text = "" Then Exit Sub
        If Not IsNumeric(Me.txtOrdenInicio.Text) Then Exit Sub

            Try
            If Me.txtOrdenInicio.Text <> OrdenInicio Then
                DetectChanges("ordenInicio", OrdenInicio, txtOrdenInicio.Text, "")
                OrdenInicio = txtOrdenInicio.Text
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class


    