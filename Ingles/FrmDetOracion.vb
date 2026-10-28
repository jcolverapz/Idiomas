Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports RichTextBoxEx
Imports System.IO
Imports WMPLib 
Imports SpeechLib
Imports System.Speech.Synthesis

Imports System.Speech.AudioFormat
 
Public Class FrmDetOracion

#Region "Variables"
    Public Id As Integer
    Public orden As Integer
    Dim cuenta As Integer
    Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer

    Public IdOracion As Integer
    Public GrupoOracion As String
    Public contenedor As String
    Public sqlstring As String
    Public MaxColumna As Integer
    Public CurrentRow As Integer
    Public ColorActivo As Object = System.Drawing.Color.FromArgb(198, 255, 196)
    ' Public ColorInicio As SystemBrushes = Brushes.Gainsboro
    Dim Audio As String

    'Public Shared Id As Integer
    Public consulta As String
    Dim rowcount As Integer
    ' Public Device As clsDevice
    'Public Id As Integer
    Public TextHTML As String = ""
    Public Nombre As String = ""
    Public Tipo As String = ""
    Public tipoId As Integer
    Public Status As String = ""
    Public Area As String = ""
    Dim foco As Boolean
    Dim EsRespuesta As String = ""
    Dim startIndex As Integer
    Dim length As Integer
    Dim Favorito As String = ""
    Public filename As String
    Dim rate As Double
    Dim volumen As Double
    Dim IPA As String = ""
    Dim personaje As String = ""
    Dim Imagen As String = ""
    Dim Contexto As String = ""
    Dim Pregunta As String = ""

    Dim Tema As String = ""
    Dim voice As String = ""
    Dim intencion As String = ""

#Region "Colores"
    Public Color1 As Color = System.Drawing.Color.FromArgb(253, 239, 202)
    Public Color2 As Color = System.Drawing.Color.FromArgb(128, 94, 14)

    Public Color3 As Color = System.Drawing.Color.FromArgb(209, 235, 222)
    Public Color4 As Color = System.Drawing.Color.FromArgb(31, 92, 60)

    Public Color5 As Color = System.Drawing.Color.FromArgb(207, 218, 223)
    Public Color6 As Color = System.Drawing.Color.FromArgb(19, 49, 57)


    Public avatar1 As Brush = New SolidBrush(Color1)
    Public LblAvatar1 As Brush = New SolidBrush(Color2)

    Public avatar2 As Brush = New SolidBrush(Color3)
    Public LblAvatar2 As Brush = New SolidBrush(Color4)


    Public avatar3 As Brush = New SolidBrush(Color5)
    Public LblAvatar3 As Brush = New SolidBrush(Color6)
#End Region
    

    Public Departamento As String = ""
    Public Ubicacion As String = ""
    Public NombreEmpleado As String = ""
    Public ApellidoEmpleado As String = ""
    Public Anydesk As String = ""
    Public estadoCerrado As String = ""
    Public UsuarioCorreo As String = ""
    Public descripcion As String = ""
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
    Dim dtOraciones As New DataTable


    'Traduccion
    Public TextoPlano As String = ""
    '  Public Oracion As New RichTextBox
    Public Oracion As String = ""
    Public GrupoOracionId As Integer

    Public traduccion As String = ""
    Public observaciones As String = ""

    Public bandTimeValue As Boolean
    Public bandEstado As Boolean
    Public lstModificaciones As New ListView
    Public Aprendi As Boolean

#End Region

#Region "Inicio"
    Private Sub FrmDetOracion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
       
        'CargarConversation(IdOracion)

        txtStatus.Text = "Oracion"


        'Grupos
        Dim Grupos As New DataTable

        Dim param As String = " WHERE Oraciones_FR.Id=" & Id
        Dim resp As Integer

        Dim i, n, nv As Integer
        ' Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        ' Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = "SELECT       Id, Grupo, Orden, estatus, Nivel"
        sqlstring = sqlstring & " FROM Grupos_oracion"
        sqlstring = sqlstring & " ORDER BY Grupo asc"

        'sqlstring = sqlstring & param

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(Grupos)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        n = Grupos.Rows.Count
        cmbGrupo.Items.Clear()

        Do While i <= n - 1
            Me.cmbGrupo.Items.Add(New clsItem(Grupos.Rows(i).Item(1), Grupos.Rows(i).Item(0)))
            i = i + 1
        Loop
         
        sql = ""
        '=================================================
        'Voces
        '=================================================
        Dim voces As New DataTable

        sqlstring = "SELECT       Id, voice"
        sqlstring = sqlstring & " FROM Tbl_voces"

        If ModVar.Idioma = "EN" Then
            sqlstring = sqlstring & " Where Idioma='EN'"
        Else
            sqlstring = sqlstring & " Where Idioma='FR'"
        End If

        sqlstring = sqlstring & " ORDER BY voice asc"
         

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(voces)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        nv = voces.Rows.Count
        cboVoice.Items.Clear()
        i = 0
        Do While i <= nv - 1
            Me.cboVoice.Items.Add(New clsItem(voces.Rows(i).Item(1), voces.Rows(i).Item(0)))
            i = i + 1
        Loop

        'cargarConversaciones(IdOracion)
        '=================================================
        ' Expresion
        '=================================================
        cboExpresion.Items.Clear()
        ' i = 0
        'Do While i <= nv - 1
        Me.cboExpresion.Items.Add("Saludo")
        Me.cboExpresion.Items.Add("Normal")
        'i = i + 1
        'Loop

        Dim dt As New DataTable

        sqlstring = ""

        sqlstring = " SELECT    Con_Id, Con_Titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation "
        sqlstring = sqlstring & " ORDER BY Con_Titulo"

        dt = New DataTable
        da = New SqlDataAdapter
        i = 0
        n = 0

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
            _comando.Connection.Close()
        Catch ex As Exception

        End Try

        'Conversaciones

        i = 0
        n = dt.Rows.Count

        'Do While i <= n - 1
        '    cboConversation.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
        '    i = i + 1
        'Loop


        If File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3") Then

            '   cmdPlay.Enabled = True
        Else
            '  cmdPlay.Enabled = False

        End If


        lstAudios.View = View.Details ' Set the view to show details.
        lstAudios.LabelEdit = False ' Allow the user to edit item text.
        lstAudios.AllowColumnReorder = True ' Allow the user to rearrange columns.
        lstAudios.FullRowSelect = True ' Select the item and subitems when selection is made.
        lstAudios.GridLines = True ' Display grid lines.

        cargarAudios()


        'Cargar Temas
        ' Do While i <= n - 1
        ' Me.cmbTema.Items.Add(New clsItem(dt.Rows(i).Item(7), dt.Rows(i).Item(8)))
        Me.cmbTema.Items.Add("greetings")
        Me.cmbTema.Items.Add("farewell")
        Me.cmbTema.Items.Add("identity")
        Me.cmbTema.Items.Add("politeness")
        Me.cmbTema.Items.Add("Languages")
        Me.cmbTema.Items.Add("food")
        Me.cmbTema.Items.Add("transportation")
        Me.cmbTema.Items.Add("aviso")
        Me.cmbTema.Items.Add("plans")
        Me.cmbTema.Items.Add("time")
        Me.cmbTema.Items.Add("ubicacion")

        Me.cmbTema.Items.Add("family")
        Me.cmbTema.Items.Add("work")
        Me.cmbTema.Items.Add("education")

        Me.cmbTema.Items.Add("shopping")
        Me.cmbTema.Items.Add("social")
        Me.cmbTema.Items.Add("weather")
        Me.cmbTema.Items.Add("Profession")

        Me.cmbTema.Items.Add("Sin_Tema")



    End Sub

    Public Sub CargarDatos(Id)
        Dim param As String
        Dim resp As Integer
        Dim i, n As Integer
        Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        param = " WHERE O.Id=" & Id

        sqlstring = " SELECT       O.Id, O.Oracion, O.ConceptoID, O.GrupoO, O.Traduccion, O.Campo1, O.Palabra, O.[Delete], O.SEL, "
        sqlstring = sqlstring & "                  O.estatus, O.GrupoId, O.forma, O.STL, O.IMG, O.Orden, O.IPA, O.TextoPlano, O.CursoId, "
        sqlstring = sqlstring & "                  O.Ora_Aprendido, g.Grupo, O.cuentaSTL, O.foco, O.Observaciones, O.tipo, O.Audio, O.rate, O.favorito, O.IPA, o.personaje, o.IMG, o.contexto, o.tema,"
        sqlstring = sqlstring & " o.Estructura, o.Pregunta, o.voice, o.Expresion"
        sqlstring = sqlstring & "  FROM            Oraciones_FR O LEFT JOIN"
        sqlstring = sqlstring & "                    Grupos_oracion g ON O.GrupoO = g.Id"

        sqlstring = sqlstring & param

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()
            ' _comando.Parameters.AddWithValue("@"
            da.SelectCommand = _comando

            da.Fill(dt)
            ' DatosTicket = CapaLogica.CatalogoTickets(param)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        'DatosMantenimiento = CapaLogica.DatosEquiposMantenimiento(param)
        Dim carpeta As String = ""
        Dim filename As String = ""

        resp = dt.Rows.Count

        If resp = 0 Then Exit Sub

        IdOracion = dt.Rows(0).Item(0)

        txtId.Text = IdOracion

        If Not IsDBNull(dt.Rows(0).Item(1)) Then
            Oracion = dt.Rows(0).Item(1)
            'Oracion = "Test"
            'TextoPlano = dt.Rows(0).Item(21)
            txtHTML.Text = dt.Rows(0).Item(1)

        End If


        If Not IsDBNull(dt.Rows(0).Item(16)) Then
            TextoPlano = dt.Rows(0).Item(16)
        End If
        txtDescripcion.Text = Trim(TextoPlano)

        filename = "C:\Legacy\Rtf\" & Id & ".rtf"

        ' Determine whether the directory exists.
        ' If Directory.Exists(carpeta) Then
        If System.IO.File.Exists(filename) Then

            'End If
            ' Console.WriteLine("That path exists already.")
            ' Return
            '  RichTextBoxEx.RichTextBoxEx.CargarDatos(Id)
            ' RichTextBoxEx1.rtb.LoadFile(filename)
        Else

            If Not IsDBNull(dt.Rows(0).Item(16)) Then
                descripcion = dt.Rows(0).Item(16)
            End If
            ' RichTextBoxEx1.rtb.Text = descripcion
            ' RichTextBoxEx1.rtb.Text = Oracion

            ' Try to create the directory.
            'Dim di As DirectoryInfo = Directory.CreateDirectory(carpeta)
            'archivo = Dir(Adjunto)
            'IO.File.Copy(Adjunto, carpeta & archivo)

        End If

        If Not IsDBNull(dt.Rows(0).Item(4)) Then
            traduccion = dt.Rows(0).Item(4)
        End If
        txtTraduccion.Text = traduccion


        If Not IsDBNull(dt.Rows(0).Item(12)) Then
            If dt.Rows(0).Item(12) = True Then
                estado = "APRENDI"
            Else
                estado = "Falta APRENDER"
            End If
        End If
        cboState.Text = estado


        If Not IsDBNull(dt.Rows(0).Item(19)) Then
            GrupoOracionId = dt.Rows(0).Item(3)
            GrupoOracion = dt.Rows(0).Item(19)
        End If
        cmbGrupo.Text = GrupoOracion


        If Not IsDBNull(dt.Rows(0).Item(14)) Then
            orden = dt.Rows(0).Item(14)
        End If
        txtOrden.Text = orden

        If Not IsDBNull(dt.Rows(0).Item(20)) Then
            cuenta = dt.Rows(0).Item(20)
        End If
        txtCuenta.Text = cuenta

        If Not IsDBNull(dt.Rows(0).Item(21)) Then
            foco = dt.Rows(0).Item(21)
        End If
        chkFile.Checked = foco

        If Not IsDBNull(dt.Rows(0).Item(22)) Then
            observaciones = dt.Rows(0).Item(22)
        End If
        txtObserv.Text = observaciones

        If Not IsDBNull(dt.Rows(0).Item(23)) Then
            EsRespuesta = dt.Rows(0).Item(23)
        End If
        txtTipo.Text = EsRespuesta

        If Not IsDBNull(dt.Rows(0).Item(24)) Then
            Audio = dt.Rows(0).Item(24)
        End If
        txtAudio.Text = Audio

        If Not IsDBNull(dt.Rows(0).Item(25)) Then
            rate = dt.Rows(0).Item(25)
        End If
        NumRate.Value = rate

        If Not IsDBNull(dt.Rows(0).Item(26)) Then
            Favorito = dt.Rows(0).Item(26)
        End If
        txtFavorito.Text = Favorito

        If Not IsDBNull(dt.Rows(0).Item(27)) Then
            IPA = dt.Rows(0).Item(27)
        End If
        txtIPA.Text = IPA

        If Not IsDBNull(dt.Rows(0).Item(28)) Then
            personaje = dt.Rows(0).Item(28)
        End If

        If personaje = "C" Then
            checkObjeto.Checked = True
        Else
            checkObjeto.Checked = False

        End If

        If Not IsDBNull(dt.Rows(0).Item(29)) Then
            Imagen = dt.Rows(0).Item(29)
        End If
        txtIMG.Text = Imagen

        If Not IsDBNull(dt.Rows(0).Item(30)) Then
            Contexto = dt.Rows(0).Item(30)
        End If
        txtContexto.Text = Contexto

        If Not IsDBNull(dt.Rows(0).Item(31)) Then
            Tema = dt.Rows(0).Item(31)
        End If
        cmbTema.Text = Tema


        If Not IsDBNull(dt.Rows(0).Item(32)) Then
            txtEstructura.Text = dt.Rows(0).Item(32)
        End If

        If Not IsDBNull(dt.Rows(0).Item(33)) Then
            Pregunta = dt.Rows(0).Item(33)
        End If
        txtPregunta.Text = Pregunta

        If Not IsDBNull(dt.Rows(0).Item(34)) Then
            voice = dt.Rows(0).Item(34)
        End If
        cboVoice.Text = voice


        If Not IsDBNull(dt.Rows(0).Item(35)) Then
            intencion = dt.Rows(0).Item(35)
        End If
        cboExpresion.Text = intencion

    End Sub

    Private Sub cargarConversaciones(Id)

        Dim dt As New DataTable
        Dim n As Integer

        sqlstring = "  SELECT       Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Enc_Conversation.Con_Titulo,Enc_Conversation.Con_Id"
        sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
        sqlstring = sqlstring & "                 Enc_Conversation ON Det_Conversation.Con_Id = Enc_Conversation.Con_Id"
        sqlstring = sqlstring & " Where Det_Conversation.Det_OracionId='" & IdOracion & "'"

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
        i = 0


        'Detalles

        For Each rw In dt.Rows
        Next


        Dim item As ListViewItem 'Creo el ListViewItem (item) 


        Do While i <= n - 1
            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.SubItems.Add(dt.Rows(i).Item(2))
            item.SubItems.Add(dt.Rows(i).Item(0))

            lstConversaciones.Items.Add(item)

            i = i + 1
        Loop

        'item.SubItems(1).ForeColor = Color.SteelBlue
        '  item.SubItems(2).ForeColor = Color.Blue

        lstConversaciones.View = View.Details ' Set the view to show details.
        lstConversaciones.LabelEdit = False ' Allow the user to edit item text.
        lstConversaciones.AllowColumnReorder = True ' Allow the user to rearrange columns.
        lstConversaciones.FullRowSelect = True
        lstConversaciones.GridLines = True

        lstConversaciones.ShowItemToolTips = True

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

        sqlstring = " SELECT         d.Det_Con,  d.Orden, d.Con_Id, d.Det_Person, d.Det_Par, Oraciones.Oracion, "
        sqlstring = sqlstring & " e.Con_Titulo, e.Con_Id"
        sqlstring = sqlstring & " FROM            Det_Conversation d INNER JOIN"
        sqlstring = sqlstring & "              Enc_Conversation e ON d.Con_Id = e.Con_Id INNER JOIN"
        sqlstring = sqlstring & "              Oraciones o ON d.Det_OracionId = o.Id"

        'sqlstring = "select * from  Oraciones "
        sqlstring = sqlstring & param

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
            ' DatosTicket = CapaLogica.CatalogoTickets(param)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        n = dt.Rows.Count

        cboConversation.Items.Clear()




    End Sub

#End Region

#Region "Lo demas"
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

        lblmod.Text = "( " & lstModificaciones.Items.Count & " )"




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

    '    'End If
    'End Sub

    'Private Sub txtComputerName_TextChanged(sender As System.Object, e As System.EventArgs)
    '    'If Me.txtComputerName.Text <> Nombre Then

    '    '    DetectChanges("Nombre", Nombre, sender)

    '    'End If
    'End Sub




    'Private Sub txtUsuarioId_TextChanged(sender As System.Object, e As System.EventArgs)

    '    'If Me.txtUsuarioId.Text <> UsuarioId Then

    '    '    DetectChanges("EmpleadoId", UsuarioId, sender)

    '    'End If
    'End Sub

    'Private Sub txtAnydesk_TextChanged(sender As System.Object, e As System.EventArgs)
    '    'If Me.txtAnydesk.Text <> Anydesk Then

    '    '    DetectChanges("Anydesk", Anydesk, sender)

    '    'End If
    'End Sub

    'Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
    '    Dim param As String

    '    Try

    '        lstModificaciones.Items.Clear()

    '        Dim frm As frmItems = CType(Owner, frmItems)


    '        frm.CargarDatos(frm.filtro)

    '        Me.Close()
    '        Me.Dispose()
    '    Catch ex As Exception

    '        Me.Close()
    '        Me.Dispose()
    '        Exit Sub

    '    End Try

    'End Sub

    'Private Sub txtmin_TextChanged(sender As System.Object, e As System.EventArgs)

    'End Sub

    'Private Sub nHora_ValueChanged(sender As System.Object, e As System.EventArgs)

    'End Sub

    'Private Sub nmin_ValueChanged(sender As System.Object, e As System.EventArgs)
    '    'txtTime.Text = Format(CType(nHora.Value, Decimal), "0#") & ":" & Format(CType(nmin.Value, Decimal), "0#")
    'End Sub
    'Private Sub dgvTasks_DoubleClick(sender As Object, e As System.EventArgs)
    '    Dim frm As New frmTask
    '    Dim TaskId As Integer

    '    ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."
    '    ' If dgvTasks.Rows.Count = 0 Then Exit Sub

    '    'TaskId = dgvTasks.CurrentRow.Cells(0).Value.ToString()

    '    AddOwnedForm(frm)
    '    frm.CargarDatos(TaskId)

    '    frm.ShowDialog()

    '    'Dim frm As New frmIncidentItem
    '    'Dim TicketId As Integer

    '    '' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

    '    'TicketId = dgvRequest.CurrentRow.Cells(0).Value.ToString()

    '    'AddOwnedForm(frm)
    '    'frm.CargarDatos(TicketId)

    '    'frm.ShowDialog()

    'End Sub



    'Private Sub txtUbicacion_TextChanged(sender As System.Object, e As System.EventArgs)
    '    Try
    '        DetectChanges("Ubicacion", Ubicacion, cboUbicacion.Text, "")
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Private Sub dgvTasks_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    'End Sub


    'Private Sub cboClose_LostFocus(sender As Object, e As System.EventArgs)
    '    'Try
    '    '    If estadoCerrado <> cboClose.Text Then
    '    '        DetectChanges("EstadoCerrado", estadoCerrado, cboClose.Text)
    '    '    End If
    '    'Catch ex As Exception

    '    'End Try
    'End Sub
    'Private Sub cboApproval_LostFocus(sender As Object, e As System.EventArgs)
    '    Try
    '        'If Approval <> cboApproval.Text Then
    '        '    DetectChanges("Approval", Approval, cboApproval.Text)

    '        'End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Private Sub dtpDuedate_LostFocus(sender As Object, e As System.EventArgs)
    '    Try

    '        If fechaEntrega <> dtpDuedate.Value Then
    '            DetectChanges("fechaEntrega", fechaEntrega, Format(dtpDuedate.Value, "dd-MMM-yyyy"), "")

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    ''Private Sub cboUpdateActivity_Click(sender As System.Object, e As System.EventArgs)
    ''    Dim resp As Boolean
    ''    Dim NuevoEstado As New clsHistorial

    ''    resp = CapaLogica.UpdateTicket(lstModificaciones, Id)

    ''    If estado <> cboState.Text Then

    ''        NuevoEstado.EmpleadoId = var.UsuarioID
    ''        NuevoEstado.fecha = Now
    ''        NuevoEstado.IdReq = Id
    ''        NuevoEstado.Status = cboState.Text

    ''        resp = CapaLogica.NewState(NuevoEstado)

    ''        estado = cboState.Text






    ''    End If

    ''    If resp = True Then
    ''        MsgBox("se actualizo")
    ''    End If

    ''    CargarDatos(Id)

    ''End Sub

    ''Private Sub CmdNewTask_Click(sender As System.Object, e As System.EventArgs)



    ''End Sub

    ' ''Private Sub frmItemIncident_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    ' ''Dim p As PictureBox
    ' ''p = New PictureBox


    ' ''Dim Gp As Graphics
    ' ''Gp = p.CreateGraphics
    ' ''Gp.Clear(Color.FromKnownColor(KnownColor.Control))
    ' ''Gp.DrawEllipse(Pens.Blue, 10, 60, 60, 10)


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

    ''End Sub

    ''Private Sub CmdUpdate_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click
    ''    Dim resp As Boolean
    ''    Dim respcorreo As Boolean

    ''    'If cboState.Text <> "Canceled" Then
    ''    If UsuarioAsignado = "" Then
    ''        MsgBox("Unassigned Ticket", MsgBoxStyle.Exclamation, "Alert")
    ''        Exit Sub
    ''    End If
    ''    'End If

    ''    resp = CapaLogica.UpdateTicket(lstModificaciones, Id)



    ''    'Estado
    ''    If bandEstado = True Then

    ''        Dim itemState As New clsHistorial
    ''        itemState.IdReq = Id
    ''        itemState.fecha = Now
    ''        itemState.hora = Now
    ''        itemState.EmpleadoId = var.UsuarioID
    ''        itemState.parametro = "State"
    ''        itemState.descripcion = "State: " & cboState.Text
    ''        itemState.adjunto = "N"
    ''        itemState.minutos = 0


    ''        itemState.Status = cboState.Text

    ''        respcorreo = CapaLogica.NewState(itemState)

    ''        estado = cboState.Text

    ''        'generaCorreo(itemState)
    ''        generaCorreoSeguimiento(txtCorreo.Text, "")
    ''        bandEstado = False
    ''    End If


    ''    If resp = True Then

    ''        MsgBox("Saved Successfully ", MsgBoxStyle.Information, "Information")

    ''        CrearControles()
    ''        lblmod.Text = "( )"
    ''        lstModificaciones.Items.Clear()

    ''        'cerrar
    ''        Try
    ''            Dim frm As frmItems = CType(Owner, frmItems)


    ''            frm.CargarDatos(frm.filtro)

    ''            Me.Close()
    ''            Me.Dispose()
    ''        Catch ex As Exception

    ''            Me.Close()
    ''            Me.Dispose()
    ''            Exit Sub

    ''        End Try
    ''    End If



    ''End Sub

    ''Private Sub frmItemTicket_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

    ''    ' pEtapa.AutoScroll = True
    ''    '  pEtapa.VerticalScroll.Visible = True
    ''    ' pEtapa.Invalidate()

    ''    CrearControles()

    ''    '    pEtapa.VerticalScroll.Enabled = True

    ''End Sub

    ''Private Sub cboState_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboState.SelectedIndexChanged

    ''    If cboState.Text <> "Assigned" Then
    ''        CambioEstado(cboState.Text)

    ''    End If

    ''End Sub
    ''Private Sub CambioEstado(vEstado)
    ''    Try
    ''        If estado <> vEstado Then

    ''            DetectChanges("Enc_Estado", estado, vEstado, "")
    ''            estado = vEstado
    ''            bandEstado = True

    ''        End If

    ''    Catch ex As Exception

    ''    End Try
    ''End Sub
    ''Public Sub TimeWorked(fechaInicio, fechaFin)
    ''    ' Function sTiempo(dInicio As Date, dFin As Date) As String
    ''    Dim Tiempo As String
    ''    Dim vdias As Integer
    ''    Dim vHora As Integer
    ''    Dim vMin As Integer

    ''    If fechaInicio >= fechaFin Then
    ''        'MsgBox("fecha Invalida")
    ''        txtTimeWorked.ForeColor = Color.Red
    ''        bandTimeValue = False

    ''        ' Exit Sub
    ''    Else

    ''        bandTimeValue = True

    ''        ' txtTimeWorked.ForeColor = Color.Black
    ''        txtTimeWorked.ForeColor = Color.Black

    ''    End If


    ''    vHora = ((DateDiff("s", fechaInicio, fechaFin) \ 3600))
    ''    vMin = ((DateDiff("s", fechaInicio, fechaFin) \ 60) Mod 60)
    ''    txtTimeWorked.Text = Format(vHora, "00") & ":" & Format(vMin, "00")

    ''    'Tiempo = Str((DateDiff("s", fechaInicio, fechaFin) \ 86400) Mod 365) & " días, "
    ''    ' Tiempo = ((DateDiff("s", fechaInicio, fechaFin) \ 3600) Mod 24)
    ''    'Tiempo = ((DateDiff("s", fechaInicio, fechaFin) \ 60) Mod 60)

    ''    ' vdias = ((DateDiff("s", fechaInicio, fechaFin) \ 86400) Mod 365)
    ''    ' vHora = ((DateDiff("s", fechaInicio, fechaFin) \ 3600) Mod 24)
    ''    'Tiempo = Tiempo & Str(DateDiff("s", fechaInicio, fechaFin) Mod 60) & " segundos."
    ''    ' Lbl_Sec.Text = 0
    ''    ' sTiempo = Tiempo

    ''    'End Sub
    ''    ' Dim vHora As Integer = DateDiff(DateInterval.Hour, fechaInicio, fechaFin)
    ''    'Dim vMin As Integer = DateDiff(DateInterval.Minute, fechaInicio, fechaFin)
    ''    'Dim vHora As Integer = vMin / 60

    ''    ' txtTimeWorked.Text = Format(vHora, "00") & ":" & Format(vMin, "00")

    ''    ' If vMin >= 0 And vHora >= 0 Then
    ''    '  Else
    ''    'txtTimeWorked.Text = "00:00"
    ''    ' bandTimeValue = False

    ''    ' End If


    ''    'Dim vHora As Double = vMin / 60
    ''    ' Dim wY As Long = DateDiff(DateInterval.WeekOfYear, datTim1, datTim2)
    ''    'txtTime.Text = span.ToString

    ''    ' Dim span As TimeSpan = New TimeSpan(vHora, vMin, 0)
    ''    'txtTimeWorked.Text = span.ToString
    ''    'txtTimeWorked.Text = span.ToString


    ''End Sub



    ''Private Sub dtphoraFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtphoraFin.ValueChanged
    ''    Dim fechaFin As DateTime
    ''    Dim fechaInicio As DateTime

    ''    fechaInicio = CDate(Format(dtpfechaInicio.Value, "dd-MM-yyyy") & " " & Format(dtpHoraInicio.Value, "hh:mm tt"))
    ''    fechaFin = CDate(Format(dtpfechaFin.Value, "dd-MM-yyyy") & " " & Format(dtphoraFin.Value, "hh:mm tt"))

    ''    TimeWorked(fechaInicio, fechaFin)

    ''End Sub

    ''Private Sub dtpHoraInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpHoraInicio.ValueChanged
    ''    Dim fechaFin As DateTime
    ''    Dim fechaInicio As DateTime

    ''    Try
    ''        fechaInicio = CDate(Format(dtpfechaInicio.Value, "dd-MM-yyyy") & " " & Format(dtpHoraInicio.Value, "hh:mm tt"))
    ''        fechaFin = CDate(Format(dtpfechaFin.Value, "dd-MM-yyyy") & " " & Format(dtphoraFin.Value, "hh:mm tt"))

    ''        TimeWorked(fechaInicio, fechaFin)
    ''    Catch ex As Exception

    ''    End Try

    ''End Sub

    ''Private Sub dtpfechaInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpfechaInicio.ValueChanged
    ''    Dim fechaFin As DateTime
    ''    Dim fechaInicio As DateTime

    ''    dtpfechaFin.Value = dtpfechaInicio.Value

    ''    fechaInicio = CDate(Format(dtpfechaInicio.Value, "dd-MM-yyyy") & " " & Format(dtpHoraInicio.Value, "hh:mm tt"))
    ''    fechaFin = CDate(Format(dtpfechaFin.Value, "dd-MM-yyyy") & " " & Format(dtphoraFin.Value, "hh:mm tt"))

    ''    TimeWorked(fechaInicio, fechaFin)
    ''End Sub

    ''Private Sub dtpfechaFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpfechaFin.ValueChanged
    ''    Dim fechaFin As DateTime
    ''    Dim fechaInicio As DateTime

    ''    fechaInicio = CDate(Format(dtpfechaInicio.Value, "dd-MM-yyyy") & " " & Format(dtpHoraInicio.Value, "hh:mm tt"))
    ''    fechaFin = CDate(Format(dtpfechaFin.Value, "dd-MM-yyyy") & " " & Format(dtphoraFin.Value, "hh:mm tt"))

    ''    TimeWorked(fechaInicio, fechaFin)
    ''End Sub

    ''Private Sub txtTimeWorked_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTimeWorked.TextChanged

    ''End Sub

    ''Private Sub cmdAsignar_Click(sender As System.Object, e As System.EventArgs) Handles cmdAsignar.Click
    ''    Dim resp As Boolean

    ''    If cboEmpleados.Text = "" Then Exit Sub



    ''    If cboEmpleados.Text <> "" Then

    ''        Try
    ''            If UsuarioAsignado <> cboEmpleados.Text Then

    ''                DetectChanges("Enc_Emp_asignado", UsuarioAsignado, cboEmpleados.Items(cboEmpleados.SelectedIndex).ItemData(), "")
    ''                UsuarioAsignado = cboEmpleados.Text
    ''                CambioEstado("Assigned")
    ''            Else
    ''                Exit Sub
    ''            End If

    ''        Catch ex As Exception
    ''        End Try
    ''    End If

    ''    resp = CapaLogica.UpdateTicket(lstModificaciones, Id)

    ''    Dim itemState As New clsHistorial
    ''    itemState.IdReq = Id
    ''    itemState.fecha = Now
    ''    itemState.hora = Now
    ''    itemState.EmpleadoId = var.UsuarioID
    ''    itemState.parametro = "Assigned to"
    ''    itemState.descripcion = "Assigned to: " & UsuarioAsignado
    ''    itemState.Status = cboState.Text
    ''    itemState.adjunto = "N"
    ''    itemState.minutos = 0

    ''    resp = CapaLogica.NewState(itemState)

    ''    If resp = True Then
    ''        cboState.Text = "Assigned"

    ''        cboState.Enabled = True

    ''        MsgBox("Saved Successfully ", MsgBoxStyle.Information, "Information")

    ''        bandEstado = False

    ''        Dim EmpleadoIT As clsUsuario
    ''        Dim param As String = ""

    ''        '    If var.Planta = "Planta SLP" Then
    ''        param = " Where Empleado.Emp_Nombre='" & Me.cboEmpleados.Text & "'" 'And Empleado.Estado='A'"
    ''        'Else

    ''        'End If

    ''        EmpleadoIT = CapaLogica.BuscarEmpleado(param)

    ''        If Not IsDBNull(EmpleadoIT.CorreoUsuario) Then
    ''            'Me.cboEmpleados.Items.Add(New clsItem(EmpleadosIT.Rows(i).Item(1), EmpleadosIT.Rows(i).Item(0)))
    ''            '  NombreEmpleado = EmpleadosIT.Item(i).NombreDelEmpleado & " " & EmpleadosIT.Item(i).apellidoPatEmpleado & " " & EmpleadosIT.Item(i).apellidoMatEmpleado
    ''            '  Me.cboEmpleados.Items.Add(New clsItem(NombreEmpleado, EmpleadosIT.Item(i).EmpleadoID))

    ''            generaCorreo(EmpleadoIT.CorreoUsuario, EmpleadoIT.Usuario)

    ''        End If

    ''        CrearControles()
    ''        lblmod.Text = "( )"

    ''        lstModificaciones.Items.Clear()

    ''    End If



    ''End Sub
    ''Public Sub generaCorreo(para, usuario)
    ''    Dim txtCorreo As String = ""
    ''    Dim today As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
    ''    Dim CorreoUsuario As String = ""
    ''    Try
    ''        txtCorreo = txtCorreo + "<table width=80% border=0 cellspacing=4 cellpadding=1 align=center height=131 <font face='Tahoma'>"
    ''        txtCorreo = txtCorreo + "<tr><td><h4 align=center><strong><size=3>TICKET ASIGNADO</strong></h3></td></tr>"
    ''        txtCorreo = txtCorreo + "<tr><td><h5 align=center>" & var.Planta & "</font></table><br>"

    ''        txtCorreo = txtCorreo + " <font face='Tahoma'><b>Hola  @" & usuario & "</b> se te ha asignado el siguiente Ticket: <br><br>"
    ''        txtCorreo = txtCorreo + " <b>Tipo: </b>" & TipoTicket & "<br><br>"
    ''        txtCorreo = txtCorreo + " <b>ID: </b>" & txtId.Text & "<br><br>"
    ''        txtCorreo = txtCorreo + "<b>Descripcion corta: </b>" & txtdescripcionCorta.Text & "<br><br>"
    ''        txtCorreo = txtCorreo + "<b>Descripcion: </b>" & txtDescripcion.Text & "<br><br>"

    ''        'Mail con texto
    ''        txtCorreo = txtCorreo + "<p><b>ELABORO: </b>" & txtSubmittedBy.Text & "</p>"
    ''        txtCorreo = txtCorreo + "<p><b>UBICACION: </b>" & cboUbicacion.Text & "</font></p>"

    ''        CorreoUsuario = para

    ''        EnviarCorreo(txtCorreo, CorreoUsuario, "")
    ''    Catch ex As Exception
    ''        MsgBox("error on email " & ex.Message, MsgBoxStyle.Exclamation, "Alert")

    ''    End Try
    ''End Sub
    ''Public Sub generaCorreoSeguimiento(para, usuario)
    ''    Dim txtCorreo As String = ""
    ''    Dim today As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
    ''    Dim CorreoUsuario As String = ""
    ''    Try
    ''        txtCorreo = txtCorreo + "<table width=80% border=0 cellspacing=4 cellpadding=1 align=center height=131 <font face='Tahoma'>"
    ''        txtCorreo = txtCorreo + "<tr><td><h4 align=center><strong><size=3>TICKET</strong></h3></td></tr>"
    ''        txtCorreo = txtCorreo + "<tr><td><h5 align=center>" & var.Planta & "</font></table>"

    ''        txtCorreo = txtCorreo + "<font face='Tahoma'>"
    ''        txtCorreo = txtCorreo + " <b>Number: </b>" & txtId.Text & "<br><br>"

    ''        txtCorreo = txtCorreo + "<b>State: </b>" & cboState.Text & "<br><br>"
    ''        'Mail con texto
    ''        txtCorreo = txtCorreo + "<b>Short description: </b>" & txtdescripcionCorta.Text & "<br><br>"
    ''        txtCorreo = txtCorreo + "<p><b>Modified by: </b>" & var.UsuarioNombre & "</p>"
    ''        'txtCorreo = txtCorreo + "<b>Descripcion: </b>" & txtDescripcion.Text & "<br><br>"


    ''        txtCorreo = txtCorreo + "<p></font></p>"

    ''        CorreoUsuario = para

    ''        EnviarCorreo(txtCorreo, CorreoUsuario, "")
    ''    Catch ex As Exception
    ''        MsgBox("error on email " & ex.Message, MsgBoxStyle.Exclamation, "Alert")

    ''    End Try
    ''End Sub

    ''Public Sub EnviarCorreo(ByRef cuerpo As String, para As String, adjunto As String)

    ''    If adjunto <> "" Then
    ''        'IO.File.Copy("Q:\Materials\Readwrite\Checklist\" & "" & ".pdf", "\\10.18.172.30\adjuntos\" & "" & ".pdf")
    ''    End If

    ''    Dim elementosMail As New clsCorreo()
    ''    elementosMail.De = "notification.mx@us.sswtechnologies.com"
    ''    elementosMail.Para = para
    ''    elementosMail.Cc = "hireta@sswtechnologies.com, jlara@sswtechnologies.com, practicante-it-mxslp@sswtechnologies.com, jolvera@sswtechnologies.com"
    ''    elementosMail.Cco = ""
    ''    elementosMail.adjunto = adjunto
    ''    elementosMail.titulo = "Ticket IT  " & var.Planta & " " & txtdescripcionCorta.Text & "  ID: " & txtId.Text
    ''    elementosMail.mensaje = cuerpo
    ''    elementosMail.aplicacion = "Tickets"

    ''    Dim enviado As Boolean = CapaLogica.enviarCorreo(elementosMail)

    ''    If enviado = True Then
    ''        MessageBox.Show("Email send successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    ''    End If

    ''End Sub


    ''Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
    ''    frmNewReport.ShowDialog()
    ''End Sub


    ''Private Sub cboPriority_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPriority.SelectedIndexChanged

    ''    If Me.cboPriority.Text <> Prioridad Then
    ''        Try
    ''            DetectChanges("Enc_Prioridad", Prioridad, cboPriority.Text, "Priority: " & cboPriority.Text)
    ''            Prioridad = cboPriority.Text
    ''        Catch ex As Exception

    ''        End Try
    ''    End If


    ''End Sub

    ''Private Sub dtpDuedate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpDuedate.ValueChanged
    ''    If Me.dtpDuedate.Value = fechaEntrega Then
    ''        Exit Sub
    ''    End If
    ''    Try
    ''        DetectChanges("Enc_Fecha_Entrega", fechaEntrega, Format(dtpDuedate.Value, "dd-MM-yyyy"), "Due Date: " & Format(dtpDuedate.Value, "dd-MMM-yyyy"))
    ''        Prioridad = cboPriority.Text
    ''    Catch ex As Exception

    ''    End Try

    ''    If dtpDuedate.Value < Today Then
    ''        picAlerta.Visible = True
    ''    Else
    ''        picAlerta.Visible = False

    ''    End If

    ''End Sub




    ''Private Sub cmdRegistros_Click(sender As System.Object, e As System.EventArgs) Handles cmdRegistros.Click
    ''    Dim frm As New frmDetalles


    ''    frm.cargarDatos(Id)
    ''    frm.ShowDialog()

    ''End Sub


    ''Private Sub cmdReport_Click(sender As System.Object, e As System.EventArgs) Handles cmdReport.Click
    ''    'frmNewReport.Text = HisId
    ''    Dim resp As Integer
    ''    Dim param As String = ""

    ''    resp = MsgBox("Add Report?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)

    ''    If resp = 6 Then
    ''        'Nuevo Registro
    ''        Dim itemState As New clsHistorial
    ''        itemState.IdReq = Id
    ''        itemState.fecha = Now
    ''        itemState.hora = Now
    ''        itemState.EmpleadoId = var.UsuarioID
    ''        itemState.parametro = "Report"
    ''        itemState.adjunto = "N"
    ''        itemState.descripcion = "New report added"
    ''        itemState.minutos = 0
    ''        itemState.Status = ""

    ''        Dim newReport As Boolean
    ''        newReport = CapaLogica.NewState(itemState)

    ''        If newReport = True Then
    ''            MsgBox("Report added succesfully", MsgBoxStyle.Information)
    ''            CrearControles()

    ''        End If

    ''        ' param = " WHERE Tbl_RT_Historial.His_Id=" & Id
    ''    Else
    ''        Exit Sub
    ''    End If


    ''End Sub


    ''Private Sub cmdPost_Click(sender As System.Object, e As System.EventArgs) Handles cmdPost.Click
    ''    'Dim minutos As Integer
    ''    Dim resp As Boolean
    ''    Dim fechaInicio As DateTime
    ''    Dim fechaFin As DateTime
    ''    Dim diferencia As TimeSpan
    ''    Dim band As Boolean


    ''    If UsuarioAsignado = "" Then
    ''        MsgBox("Unassigned Ticket", MsgBoxStyle.Exclamation, "Alert")
    ''        Exit Sub
    ''    End If


    ''    band = Funciones.ValText("Work Notes", txtWorkNotes.Text)
    ''    If band = False Then
    ''        MsgBox("Required value " & "Work Notes", vbExclamation, "Warning")

    ''        'pnAdvertencia.Visible = True
    ''        ' lblRequired.Text = obj
    ''        Exit Sub
    ''    End If


    ''    ' band = Funciones.ValTime("Time Worked", txtTimeWorked.Text)
    ''    If bandTimeValue = False Then
    ''        MsgBox("Invalid Date Value ", vbExclamation, "Warning")
    ''        Exit Sub
    ''    End If


    ''    fechaFin = Format(dtpfechaFin.Value, "dd-MM-yyyy") & " " & Format(dtphoraFin.Value, "hh:mm:ss tt")
    ''    fechaInicio = Format(dtpfechaInicio.Value, "dd-MM-yyyy") & " " & Format(dtpHoraInicio.Value, "hh:mm:ss tt")
    ''    'fechaInicio = dtpfechaInicio.Value & " " & dtpHoraInicio.Value

    ''    diferencia = fechaFin - fechaInicio
    ''    'Console.WriteLine(minutos.TotalMinutes)

    ''    Dim Task As New clsTask
    ''    Task.Enc_Id = Me.txtId.Text
    ''    Task.descripcion = Me.txtWorkNotes.Text
    ''    Task.FechaInicio = dtpfechaInicio.Value
    ''    Task.HoraInicio = dtpHoraInicio.Value
    ''    Task.FechaTermino = dtpfechaFin.Value
    ''    Task.HoraTermino = dtphoraFin.Value
    ''    Task.EmpleadoId = var.UsuarioID
    ''    Task.PC = var.PC
    ''    Task.Minutos = diferencia.TotalMinutes
    ''    Task.parametro = "Work Notes"

    ''    resp = CapaLogica.NewWorkNotes(Task, "")

    ''    'Actualiza Time Worked de Ticket
    ''    Dim TimeTotalWorked As New TimeSpan
    ''    Dim lstTiempo As New ListView
    ''    TimeTotalWorked = TotalTime + diferencia


    ''    Dim item As ListViewItem 'Creo el ListViewItem (item) 
    ''    item = New ListViewItem() 'Creo una nueva instancia de item pasandole el nombre como dato principal 

    ''    item.SubItems.Add("Enc_Tiempo")
    ''    item.SubItems.Add("")
    ''    item.SubItems.Add(TimeTotalWorked.ToString)

    ''    lstTiempo.Items.Add(item)

    ''    resp = CapaLogica.UpdateTicket(lstTiempo, Id)

    ''    If TimeTotalWorked.Hours = 0 Then
    ''        txtTime.Text = TimeTotalWorked.Minutes & " minutes"
    ''    Else
    ''        txtTime.Text = TimeTotalWorked.Hours & " hours and " & TimeTotalWorked.Minutes & " minutes"
    ''    End If

    ''    TotalTime = TimeTotalWorked


    ''    lstTiempo.Items.Clear()

    ''    Dim itemState As New clsHistorial
    ''    itemState.IdReq = Id
    ''    itemState.fecha = Now
    ''    itemState.hora = Now
    ''    itemState.EmpleadoId = var.UsuarioID
    ''    itemState.parametro = "Work Notes"
    ''    itemState.adjunto = "N"
    ''    itemState.descripcion = Me.txtWorkNotes.Text
    ''    itemState.minutos = diferencia.TotalMinutes
    ''    itemState.Status = cboState.Text

    ''    resp = CapaLogica.NewState(itemState)

    ''    estado = cboState.Text

    ''    'generaCorreo(itemState)

    ''    If resp = True Then
    ''        MsgBox("Successfully Registered", MsgBoxStyle.Information, "Information")

    ''        CrearControles()
    ''        txtWorkNotes.Text = ""
    ''        txtTimeWorked.Text = ""
    ''    End If

    ''End Sub

    ''Private Sub cboCategory2_TextChanged(sender As Object, e As System.EventArgs) Handles cboCategory2.TextChanged
    '        If Trim(cboCategory2.Text) <> "" Then
    '            CmdGuardar.Enabled = True
    '        Else
    '            CmdGuardar.Enabled = False
    '        End If
    '    End Sub

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

            Dim frm As FrmOraciones = CType(Owner, FrmOraciones)

            'frm.CrearFiltro()
            ' frm.CargarDatos(frm.filtro)

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



    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim IdOracion As Integer

        IdOracion = txtId.Text


        Me.Close()
        Me.Dispose()


        Dim frm As New frmNewConversation
        frm.IdOracion = IdOracion
        frm.Frase = descripcion

        frm.ShowDialog()


    End Sub



    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        frmNewOracion.Show()

    End Sub

    Private Sub CmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click
        Dim resp As Boolean
        Dim respcorreo As Boolean


        'resp = CapaLogica.UpdateTicket(lstModificaciones, Id)

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim item As ListViewItem

        Dim i As Integer
        Dim _insertado As Boolean = False
        Dim mostrarMensaje As Boolean = False
        Dim stringvalues As String = ""
        Dim sql As String = ""
        Dim IdMax As Integer

        Dim fecha As Date
        Dim fechaEntrega As Date
        ' fecha = Today

        _comando.Connection.Open()


        For Each r In lstModificaciones.Items
            _comando.Parameters.Clear()

            If r.SubItems(3).text = "Null" Then
                sqlstring = "UPDATE Oraciones_FR SET " & r.SubItems(1).Text & " = Null"

            Else
                sqlstring = "UPDATE Oraciones_FR SET " & r.SubItems(1).Text & " = @" & r.SubItems(1).Text
                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.Parameters.AddWithValue("@" & r.SubItems(1).Text, r.SubItems(3).Text)

            End If

            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Id", IdOracion)
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
            txtStatus.Text = "Recorded"
            lstModificaciones.Items.Clear()
            lblmod.Text = "( " & lstModificaciones.Items.Count & " )"
            'GrupoOracionId = 0


            ' cmdExit_Click(sender, e)

        Else
            'Return False
            txtStatus.Text = "Error"

        End If

        GrupoOracionId = 0




    End Sub

    Private Sub txtTraduccion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTraduccion.TextChanged
        If Me.txtTraduccion.Text <> traduccion Then
            Try
                DetectChanges("Traduccion", traduccion, txtTraduccion.Text, "")
                traduccion = txtTraduccion.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtDescripcion_LostFocus(sender As Object, e As System.EventArgs) Handles txtDescripcion.LostFocus
        Dim _Id As Integer
        Dim sqlstring As String
        Dim _texto As String
        Dim _trad As String
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        _comando.Parameters.Clear()

        sqlstring = "SELECT Id, TextoPlano, Traduccion"
        sqlstring = sqlstring & " FROM Oraciones"
        sqlstring = sqlstring & " WHERE TextoPlano = @TextoPlano"
        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@TextoPlano", Trim(txtDescripcion.Text))

        _comando.Connection.Open()

        Dim objDataReader As SqlDataReader
        objDataReader = _comando.ExecuteReader

        If objDataReader.HasRows Then
            objDataReader.Read()
            _Id = objDataReader(0)
            _texto = objDataReader(1)

            If Not IsDBNull(objDataReader(2)) Then
                _trad = objDataReader(2)
            Else
                _trad = "Sin_trad"
            End If


            If IdOracion <> _Id Then 'Es una oracion diferente
                txtDescripcion.BackColor = Color.LightSalmon
                CmdGuardar.Enabled = False
                MsgBox("Id:" & _Id & vbCrLf & _texto & vbCrLf & "Traduccion:" & _trad)

                objDataReader.Close()

                Dim resp As Integer

                resp = MsgBox("Reemplazar ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

                If resp = 6 Then

                    _comando.Parameters.Clear()

                    sqlstring = "Update tbl_dialogos SET IdOracion = @IdNuevo"
                    sqlstring = sqlstring & "  WHERE IdOracion = @IdActual"
                    _comando.CommandText = sqlstring

                    _comando.Parameters.AddWithValue("@IdNuevo", _Id)
                    _comando.Parameters.AddWithValue("@IdActual", IdOracion)

                    Try
                        i = _comando.ExecuteNonQuery
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    sqlstring = "Delete FROM Oraciones"
                    sqlstring = sqlstring & " WHERE Id = @IdActual"
                    _comando.CommandText = sqlstring

                    _comando.Parameters.Clear()
                    _comando.Parameters.AddWithValue("@IdActual", IdOracion)

                    Try
                        i = _comando.ExecuteNonQuery
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try


                End If

            Else
                txtDescripcion.BackColor = Color.LightGreen
                CmdGuardar.Enabled = True
            End If

        End If

        objDataReader.Close()
        _comando.Connection.Close()

        txtStatus.Text = "Ya existe oracion Id =" & _Id

    End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged
        If Me.txtDescripcion.Text <> TextoPlano Then
            Try
                DetectChanges("TextoPlano", TextoPlano, txtDescripcion.Text, "")
                TextoPlano = txtDescripcion.Text
            Catch ex As Exception

            End Try
        End If
    End Sub



    Private Sub WebBrowser1_DocumentCompleted(sender As System.Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub cboState_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboState.SelectedIndexChanged
        Dim STL As Boolean
        If Me.cboState.Text <> estado Then
            Try

                If cboState.Text = "APRENDIDO" Then
                    STL = True
                Else
                    STL = False
                End If
                DetectChanges("STL", STL, STL, "")
                estado = cboState.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmbGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbGrupo.SelectedIndexChanged
        'Dim STL As Boolean
        Dim GrupoOracionIdNuevo As Integer
        GrupoOracionIdNuevo = cmbGrupo.Items(cmbGrupo.SelectedIndex).ItemData()

        If GrupoOracionId <> GrupoOracionIdNuevo Then
            Try


                DetectChanges("GrupoO", "", GrupoOracionIdNuevo, "")
                ' GrupoOracionIdNuevo = GrupoOracionId
                GrupoOracionId = GrupoOracionIdNuevo
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cboLearn_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtOrden_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOrden.TextChanged
        If Me.txtOrden.Text <> orden Then
            Try
                DetectChanges("orden", orden, txtOrden.Text, "")
                orden = txtOrden.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmdNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim IdNext As Integer
        'IdNext = Id + 1
        'CargarDatos(Id)

        lstModificaciones.Items.Clear()
        lblmod.Text = "( " & lstModificaciones.Items.Count & " )"

        If CurrentRow >= dtOraciones.Rows.Count - 1 Then
            MessageBox.Show("Last Record is Reached")
        Else

            'GrupoOracionId = 0
            CurrentRow += 1
            ShowData()
            txtStatus.Text = "Next Record"

        End If
    End Sub

    Private Sub ShowData()


        If Not IsDBNull(dtOraciones.Rows(CurrentRow).Item(0)) Then
            IdOracion = dtOraciones.Rows(CurrentRow).Item(0)
        End If
        txtId.Text = IdOracion


        If Not IsDBNull(dtOraciones.Rows(CurrentRow).Item(1)) Then
            Oracion = dtOraciones.Rows(CurrentRow).Item(1)
        End If

        WebBrowser1.DocumentText = Oracion
        Try
            '  RichTextBoxEx1.rtb.Rtf = Oracion

        Catch ex As Exception
            '  RichTextBoxEx1.rtb.Rtf = ""

        End Try



        If Not IsDBNull(dtOraciones.Rows(CurrentRow).Item(20)) Then
            TextoPlano = dtOraciones.Rows(CurrentRow).Item(20)

        End If
        txtDescripcion.Text = Trim(TextoPlano)

        ' filename = "C:\Legacy\Rtf\" & Id & ".rtf"

        ' Determine whether the directory exists.
        ' If Directory.Exists(carpeta) Then
        'If System.IO.File.Exists(filename) Then

        '    'End If
        '    ' Console.WriteLine("That path exists already.")
        '    ' Return
        '    '  RichTextBoxEx.RichTextBoxEx.CargarDatos(Id)
        '    RichTextBoxEx1.rtb.LoadFile(filename)

        'Else

        '    If Not IsDBNull(dt.Rows(0).Item(21)) Then
        '        descripcion = dt.Rows(0).Item(21)
        '    End If
        '    RichTextBoxEx1.rtb.Text = descripcion
        '    ' Try to create the directory.
        '    'Dim di As DirectoryInfo = Directory.CreateDirectory(carpeta)
        '    'archivo = Dir(Adjunto)
        '    'IO.File.Copy(Adjunto, carpeta & archivo)

        'End If

        If Not IsDBNull(dtOraciones.Rows(CurrentRow).Item(4)) Then
            traduccion = dtOraciones.Rows(CurrentRow).Item(4)
        End If
        txtTraduccion.Text = traduccion


        If Not IsDBNull(dtOraciones.Rows(CurrentRow).Item(14)) Then
            If dtOraciones.Rows(CurrentRow).Item(14) = True Then
                estado = "APRENDI"

            Else
                estado = "Falta APRENDER"
            End If
        End If
        cboState.Text = estado


        If Not IsDBNull(dtOraciones.Rows(CurrentRow).Item(24)) Then
            GrupoOracion = dtOraciones.Rows(CurrentRow).Item(24)
        End If
        cmbGrupo.Text = GrupoOracion
        GrupoOracionId = cmbGrupo.Items(cmbGrupo.SelectedIndex).ItemData()


        If Not IsDBNull(dtOraciones.Rows(CurrentRow).Item(16)) Then
            orden = dtOraciones.Rows(CurrentRow).Item(16)
        End If
        txtOrden.Text = orden


        ' GuardarRTF()



    End Sub

    Private Sub cmdCargar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCargar.Click
        Dim param As String = ""
        Dim resp As Integer
        Dim i, n As Integer
        Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        'Private conString As String = "Your connection string"
        'Private CurrentRow As Integer
        'Private dt As DataTable
        Dim da As New SqlDataAdapter

        param = " WHERE Oraciones.GrupoO =" & GrupoOracionId

        sqlstring = " SELECT       Oraciones.Id, Oraciones.Oracion, Oraciones.ConceptoID, Oraciones.GrupoO, Oraciones.Traduccion, Oraciones.Campo1, Oraciones.F5, Oraciones.F6, Oraciones.Palabra, Oraciones.[Delete], Oraciones.SEL, "
        sqlstring = sqlstring & "                  Oraciones.estatus, Oraciones.GrupoId, Oraciones.forma, Oraciones.STL, Oraciones.IMG, Oraciones.Orden, Oraciones.Campo2, Oraciones.IPA, Oraciones.Campo3, Oraciones.TextoPlano, Oraciones.CursoId, "
        sqlstring = sqlstring & "                  Oraciones.SSMA_TimeStamp, Oraciones.Ora_Aprendido, Grupos_oracion.Grupo"
        sqlstring = sqlstring & "  FROM            Oraciones LEFT JOIN"
        sqlstring = sqlstring & "                    Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"

        sqlstring = sqlstring & param
        sqlstring = sqlstring & "  Order by Oraciones.TextoPlano ASC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dtOraciones)

            _comando.Connection.Close()

            MessageBox.Show(" Record is Ready")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        GuardarRTF()
    End Sub

    Private Sub GuardarRTF()

        Dim resp As Boolean
        Dim respcorreo As Boolean
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

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
        _comando.Parameters.Clear()

        sqlstring = "UPDATE Oraciones SET Oracion=@Oracion"
        sqlstring = sqlstring & " WHERE Id = @Id"

        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("Id", IdOracion)
        ' _comando.Parameters.AddWithValue("Oracion", RichTextBoxEx1.rtb.Rtf)


        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        _comando.Connection.Close()
        Status = "Saved RTF"

    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ' Dim objrtf As RichTextBox
        'RichTextBoxEx1.rtb.Clear()

        'RichTextBoxEx1.rtb.AppendText("")
        'WebBrowser1.Document.ExecCommand("SelectAll", False, vbNull)
        'WebBrowser1.Document.ExecCommand("Copy", False, vbNull)
        'RichTextBoxEx1.rtb.Paste()


        GuardarRTF()
        '  RichTextBoxEx1.rtb.Text =
    End Sub

    Private Sub cmdUpdate_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtHTML_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHTML.TextChanged
        If Me.txtHTML.Text <> TextHTML Then
            Try
                DetectChanges("Oracion", TextHTML, txtHTML.Text, "")
                TextHTML = txtHTML.Text
                '  RichTextBoxEx1.rtb.Rtf = TextHTML

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

    End Sub

    Private Sub chkFile_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFile.CheckedChanged


        If foco <> chkFile.Checked Then
            Try
                DetectChanges("foco", "", chkFile.Checked, "")
                foco = chkFile.Checked
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmdImagen_Click(sender As System.Object, e As System.EventArgs) Handles cmdImagen.Click
        ' Dim ofd As New OpenFileDialog

        Dim i As Integer

        Using ofd As New OpenFileDialog
            ofd.InitialDirectory = "C:\Legacy\Ingles\Imagenes_Ingles\"

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim _comando As SqlCommand = MetodosDatos.CrearComando()
                Dim sqlstring As String

                Dim _insertado As Boolean = False
                Dim mostrarMensaje As Boolean = False
                Dim stringvalues As String = ""
                Dim sql As String = ""
                Dim filename As String = ""

                filename = ofd.SafeFileName

                _comando.Connection.Open()

                sqlstring = "UPDATE Oraciones SET IMG= @IMG"
                sqlstring = sqlstring & " WHERE Id = @Id"

                _comando.CommandText = sqlstring

                _comando.Parameters.AddWithValue("@IMG", filename)
                _comando.Parameters.AddWithValue("@Id", IdOracion)

                Try
                    i = _comando.ExecuteNonQuery
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


            End If


            If i > 0 Then
                MsgBox("Se guardo correctamente")
            End If



        End Using

    End Sub

    Private Sub lstConversaciones_DoubleClick(sender As Object, e As System.EventArgs) Handles lstConversaciones.DoubleClick
        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New FrmConversation

        AddOwnedForm(frm)

        Id = lstConversaciones.SelectedItems.Item(0).SubItems(1).Text
        'SelectedItems(0).Text()

        frm.Id = Id
        frm.lblTitulo.Text = lstConversaciones.SelectedItems(0).SubItems(2).Text
        frm.CargarConversation(Id)

        Try
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim param As String

        'If cboTipo.Text <> "" Then
        '    param = " Where Con_Tipo='" & cboTipo.Text & "'"

        'End If

        'CargarDatos()
    End Sub

    Private Sub lstConversaciones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstConversaciones.SelectedIndexChanged

    End Sub

    Private Sub cmdCopiar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopiar.Click

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer
        Dim IdConversation As Integer

        IdConversation = cboConversation.Items(cboConversation.SelectedIndex).ItemData()

        _comando.Connection.Open()

        _comando.Parameters.Clear()

        '  sqlstring = "UPDATE Det_Conversation SET Con_Id = @Con_Id, Det_Orden = @Det_Orden"
        '  sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"

        sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id)"
        sqlstring = sqlstring & " Values ('" & txtId.Text & "', '0', '" & IdConversation & "')"

        '    _comando.Parameters.AddWithValue("@Con_Id", IdConversation)
        '_comando.Parameters.AddWithValue("@Det_Con", txtId.Text)
        '_comando.Parameters.AddWithValue("@Det_Orden", 0)

        _comando.CommandText = sqlstring

        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then

                MsgBox("se guardo")
                ' CargarConversation(txtId.Text)
                cargarConversaciones(IdOracion)

            Else
                MsgBox("No se guardo")
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        _comando.Connection.Close()

    End Sub

    Private Sub cboConversation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboConversation.SelectedIndexChanged

    End Sub

    Private Sub cmdPapelera_Click(sender As System.Object, e As System.EventArgs) Handles cmdPapelera.Click

        txtDescripcion.Text = "-"
        txtTraduccion.Text = "-"

        ' Buscar el texto en la colección Items
        Dim indice As Integer = cmbGrupo.FindStringExact("_PAPELERA")

        ' Si el texto se encuentra, establecer el índice
        If indice <> -1 Then
            cmbGrupo.SelectedIndex = indice
        Else
        End If

        CmdGuardar_Click(sender, e)
        Me.Close()
        Me.Dispose()


    End Sub

    Private Sub txtObserv_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtObserv.TextChanged
        If Me.txtObserv.Text <> observaciones Then
            Try
                DetectChanges("Observaciones", observaciones, txtObserv.Text, "")
                observaciones = txtObserv.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtTipo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTipo.TextChanged

        Try
            txtTipo.Text = UCase(txtTipo.Text)
        Catch ex As Exception
        End Try


        If Me.txtTipo.Text <> EsRespuesta Then
            Try
                DetectChanges("Tipo", EsRespuesta, txtTipo.Text, "")
                EsRespuesta = txtTipo.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmdAudio_Click(sender As System.Object, e As System.EventArgs) Handles cmdAudio.Click
        ' Dim ofd As New OpenFileDialog

        Dim i As Integer
        Dim carpeta As String
        Dim FileToMove As String
        Dim MoveLocation As String

        Using ofd As New OpenFileDialog
            ofd.InitialDirectory = "C:\Legacy\Ingles\Audios\"
            'My.Computer.FileSystem.RenameFile("C:\Ruta\A\documento.txt", "informe.txt")
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim filename As String = ""
                Dim ruta As String = ""
                ' ruta = ofd.FileNames.
                filename = ofd.FileName
                carpeta = Dir(filename)
                Try

                    If File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3") Then
                        ' El archivo existe
                        My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", IdOracion & "_2.mp3")
                    Else 'No existe
                        FileToMove = filename
                        MoveLocation = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"

                        System.IO.File.Move(FileToMove, MoveLocation)

                    End If

                    'My.Computer.FileSystem.RenameFile(filename, IdOracion & ".mp3")

                Catch ex As Exception

                End Try

            End If

            'Mover de Sin Definir a Audios


            If carpeta = "C:\Legacy\Ingles\Audios\SinDefinir\" Then
                FileToMove = "C:\Legacy\Ingles\Audios\SinDefinir\" & IdOracion & ".mp3"
                MoveLocation = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"


                Try
                    ' System.IO.File.Move(FileToMove, MoveLocation)
                Catch ex As Exception

                End Try
            End If



            'If File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & "_" & i & ".mp3") Then
            '    If Not File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & "_" & "_2" & ".mp3") Then
            '        My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", IdOracion & "_2" & ".mp3")
            '    Else
            '        If Not File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & "_" & "_3" & ".mp3") Then
            '            My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", IdOracion & "_3" & ".mp3")
            '        End If
            '    End If
            'Else
            '    My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", IdOracion & "_2" & ".mp3")

            'End If





            If i > 0 Then
                MsgBox("Se guardo correctamente")
            End If



        End Using

    End Sub

    Private Sub cmdPlay_Click(sender As System.Object, e As System.EventArgs) Handles cmdPlay.Click

        Try
            Player.settings.rate = rate
            If ModVar.Idioma = "EN" Then
                Player.URL = "C:\Ingles\Audios3\femenino\" & IdOracion & ".mp3"
            Else
                Player.URL = "C:\frances\Audios\femenino\" & IdOracion & ".mp3"

            End If
            ' Player.URL = ruta & "AndiesJob.mp3"
            Player.controls.play()
        Catch ex As Exception

        End Try




    End Sub

    Private Sub txtAudio_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAudio.TextChanged

        If Me.txtAudio.Text <> Audio Then
            Try
                DetectChanges("Audio", Audio, txtAudio.Text, "")
                Audio = txtAudio.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click

        Dim filename As String = ""
        Dim FileToMove As String = ""
        Dim MoveLocation As String = ""

        FileToMove = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"
        Try
            If File.Exists(FileToMove) Then
                ' El archivo existe
                MoveLocation = "C:\Legacy\Ingles\Audios\SinDefinir\Liberado.mp3"
                System.IO.File.Move(FileToMove, MoveLocation)
                MsgBox("Se libero el  archivo ")
                ' My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", "Libre.mp3")

            End If

        Catch ex As Exception

        End Try



    End Sub

    Private Sub NumRate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumRate.ValueChanged

        If NumRate.Value <> rate Then
            Try
                DetectChanges("rate", rate, NumRate.Value, "")
                rate = NumRate.Value
            Catch ex As Exception

            End Try
        End If

    End Sub
#End Region

   
    Private Sub cmdAbrirAudio_Click(sender As System.Object, e As System.EventArgs) Handles cmdAbrirAudio.Click
 
        Dim searchLocation As String = "C:\Legacy\Ingles\Audios\"

        ' Format the search command with the protocol
        ' The search term must be URL encoded if it contains special characters
        ' Dim searchCommand As String = "search-ms:query={" & Uri.EscapeDataString(searchTerm) & "}crumb=location:{" & Uri.EscapeDataString(searchLocation) & "}"

        ' Start the Windows Search process
        'Process.Start(searchCommand)
        Dim searchString As String
        'searchString = ControlChars.Quote & "     " & Me.DateTimePicker1.Value.Year.ToString & "-" & Me.DateTimePicker1.Value.Month.ToString().PadLeft(2, "0") & "-" & Me.DateTimePicker1.Value.Day.ToString().PadLeft(2, "0") & ControlChars.Quote
        searchString = IdOracion & "*"
        Dim Search As String
        Search = "search-ms:query=" & searchString.ToString & "&crumb=location:" & searchLocation & ",recursive" & "&"
        ' MessageBox.Show(Search) 'Messagebox shows: search-ms:query=System.FileName:~="     2016-01-25"&crumb=location:C:\EPS\Enforcement Photos Archive_DEMO,recursive&
        Process.Start(Search)

    End Sub

    Private Sub cmdAgregarGif_Click(sender As System.Object, e As System.EventArgs) Handles cmdAgregarGif.Click
        
        Dim i As Integer

        Using ofd As New OpenFileDialog
            ofd.InitialDirectory = "C:\Legacy\Ingles\Imagenes_Ingles\"

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim _comando As SqlCommand = MetodosDatos.CrearComando()
                Dim sqlstring As String

                Dim _insertado As Boolean = False
                Dim mostrarMensaje As Boolean = False
                Dim stringvalues As String = ""
                Dim sql As String = ""
                Dim filename As String = ""

                filename = ofd.SafeFileName

                _comando.Connection.Open()

                sqlstring = "UPDATE Oraciones SET Gif= @Gif"
                sqlstring = sqlstring & " WHERE Id = @Id"

                _comando.CommandText = sqlstring

                _comando.Parameters.AddWithValue("@Gif", filename)
                _comando.Parameters.AddWithValue("@Id", IdOracion)

                Try
                    i = _comando.ExecuteNonQuery
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


            End If


            If i > 0 Then
                MsgBox("Se guardo correctamente")
            End If



        End Using

    End Sub

    Private Sub cmdAgregarAudio_Click(sender As System.Object, e As System.EventArgs) Handles cmdAgregarAudio.Click

        Dim frm As New frmAgregarAudio
        AddOwnedForm(frm)

        frm.Id = IdOracion
        frm.Oracion = descripcion

        frm.ShowDialog()

        cargarAudios()

    End Sub

    Private Sub cargarAudios()

        Dim filename As String = ""
        Dim FileToMove As String = ""
        Dim Location As String = ""
        Dim AlternativeLocation_1 As String = ""
        Dim AlternativeLocation_2 As String = ""
        Dim AlternativeLocation_3 As String = ""
        Dim item As ListViewItem 'Creo el ListViewItem (item) 
        Dim i As Integer

        Location = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"
        AlternativeLocation_1 = "C:\Legacy\Ingles\Alternativo\" & IdOracion & ".mp3"

        Try
            If File.Exists(Location) Then
                item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

                item.SubItems.Add("Voz 1")
                ' item.SubItems.Add( )
                lstAudios.Items.Add(item)
            End If


            If File.Exists(AlternativeLocation_1) Then
                item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

                item.SubItems.Add("Voz 2")
                ' item.SubItems.Add( )
                lstAudios.Items.Add(item)
            End If

            If File.Exists(AlternativeLocation_2) Then
                item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

                item.SubItems.Add("Voz 3")
                ' item.SubItems.Add( )
                lstAudios.Items.Add(item)
            End If
        Catch ex As Exception

        End Try

        ' My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", IdOracion & "_2" & ".mp3")
        ' System.IO.File.Move(Location, AlternativeLocation_1)
        ' My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", IdOracion & "_3" & ".mp3")


    End Sub

    Private Sub lstAudios_Click(sender As Object, e As System.EventArgs) Handles lstAudios.Click
        Dim Location As String
        Dim Voz As String

        If lstAudios.SelectedItems.Count > 0 Then

            Voz = lstAudios.SelectedItems.Item(0).SubItems(1).Text
              
            Select Case Voz

                Case Is = "Voz 1"
                    Player.URL = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"
                Case Is = "Voz 2"
                    Player.URL = "C:\Legacy\Ingles\Audios\Alternativo\" & IdOracion & ".mp3"
                Case Is = "Voz 3"
                    Player.URL = "C:\Legacy\Ingles\Audios\Alternativo2\" & IdOracion & ".mp3"
            End Select

            Player.controls.play()

            'Try
            '    If File.Exists(Location) Then
            '        item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            '        item.SubItems.Add("Voz 1")
            '        ' item.SubItems.Add( )
            '        lstAudios.Items.Add(item)
            '    End If


            '    If File.Exists(AlternativeLocation_1) Then
            '        item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            '        item.SubItems.Add("Voz 2")
            '        ' item.SubItems.Add( )
            '        lstAudios.Items.Add(item)
            '    End If

            '    If File.Exists(AlternativeLocation_2) Then
            '        item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            '        item.SubItems.Add("Voz 3")
            '        ' item.SubItems.Add( )
            '        lstAudios.Items.Add(item)
            '    End If



        End If
    End Sub

     
    
    Private Sub cmdQuitarAudio_Click(sender As System.Object, e As System.EventArgs) Handles cmdQuitarAudio.Click
        Dim i As Integer
        Dim carpeta As String

        'Mover de Sin Definir a Audios
        Dim FileToMove As String
        Dim MoveLocation As String

        FileToMove = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"
        MoveLocation = "C:\Legacy\Ingles\Papelera\" & IdOracion & ".mp3"

        Try
            If File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3") Then
                System.IO.File.Move(FileToMove, MoveLocation)


                MsgBox("Se quito correctamente")

            End If



        Catch ex As Exception
        End Try


        'Using ofd As New OpenFileDialog
        '    ofd.InitialDirectory = "C:\Legacy\Ingles\Audios\"
        '    'My.Computer.FileSystem.RenameFile("C:\Ruta\A\documento.txt", "informe.txt")
        '    If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then

        '        Dim filename As String = ""
        '        Dim ruta As String = ""
        '        ' ruta = ofd.FileNames.
        '        filename = ofd.FileName
        '        carpeta = Dir(filename)
        '        Try

        '                ' El archivo existe
        '                My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", IdOracion & "_2.mp3")

        '            End If

        '            My.Computer.FileSystem.RenameFile(filename, IdOracion & ".mp3")

        '        Catch ex As Exception

        '        End Try

        '    End If

       


        ' End Using
    End Sub

    Private Sub txtFavorito_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFavorito.TextChanged

        Try
            txtFavorito.Text = UCase(txtFavorito.Text)
        Catch ex As Exception
        End Try


        If Me.txtFavorito.Text <> Favorito Then
            Try
                DetectChanges("Favorito", Favorito, txtFavorito.Text, "")
                Favorito = txtFavorito.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmdIPA_Click(sender As System.Object, e As System.EventArgs) Handles cmdIPA.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim Id, j As Integer
        Dim sqlstring As String
        Dim i As Integer
        
        Dim valorActual As String
        Dim valorModificado As String
         
        Dim frase As String = ""
        Dim numeroDePalabras As Integer
        
          
        frase = descripcion
        _comando.Connection.Open()

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
            sqlstring = sqlstring & " WHERE (Id = '" & IdOracion & "')"
                _comando.CommandText = sqlstring

                _comando.Parameters.Clear()
                _comando.Parameters.AddWithValue("@IPA", IPA)

                Try
                    j = _comando.ExecuteNonQuery
                Catch ex As Exception
                End Try
            End If
             
        _comando.Connection.Close()

        txtIPA.Text = IPA

    End Sub

    Private Sub txtIPA_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIPA.TextChanged
         
        If Me.txtIPA.Text <> IPA Then
            Try
                DetectChanges("IPA", IPA, txtIPA.Text, "")
                IPA = txtIPA.Text
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub cmdRemplazarAudio_Click(sender As System.Object, e As System.EventArgs) Handles cmdRemplazarAudio.Click

        My.Computer.Audio.Stop()

        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\generar_audio_id.py"" " & IdOracion
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        Dim p As Process = Process.Start(psi)
        Dim resultado As String = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

        MessageBox.Show(resultado)

    End Sub

    Private Sub cmdAudioMasc_Click(sender As System.Object, e As System.EventArgs) Handles cmdAudioMasc.Click

        My.Computer.Audio.Stop()

        txtStatus.Text = "Iniciando..."

        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        'psi.Arguments = "-u ""C:\legacy\Programas\Voz_Natural\ordenporId.py"" " & Enc_Id
        psi.Arguments = "-u ""C:\legacy\Programas\Voz_Natural\GeneraAudioM.py"" " & IdOracion
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True
        psi.CreateNoWindow = True

        Dim p As New Process()
        p.StartInfo = psi
        p.EnableRaisingEvents = True

        AddHandler p.OutputDataReceived,
            Sub(senderObj, args)
                If args.Data IsNot Nothing Then
                    Me.BeginInvoke(Sub()
                                       txtStatus.Text &= vbCrLf & args.Data
                                   End Sub)
                End If
            End Sub

        AddHandler p.ErrorDataReceived,
            Sub(senderObj, args)
                If args.Data IsNot Nothing Then
                    Me.BeginInvoke(Sub()
                                       txtStatus.Text &= vbCrLf & args.Data
                                   End Sub)
                End If
            End Sub

        AddHandler p.Exited,
            Sub()
                Me.BeginInvoke(Sub()
                                   'txtStatus.Text = "Proceso finalizado"
                               End Sub)
            End Sub

        p.Start()
        p.BeginOutputReadLine()
        p.BeginErrorReadLine()

    End Sub

    Private Sub GenerarAudioFemenino_Click(sender As System.Object, e As System.EventArgs) Handles GenerarAudioFemenino.Click

        My.Computer.Audio.Stop()


        '==============
        ' Eliminar Audio
        '================
        Dim i As Integer
        Dim carpeta As String

        Dim FileToDelete As String
        Dim MoveLocation As String
         
        If Idioma = "IN" Then
            FileToDelete = "C:\Ingles\Audios3\Femenino\" & IdOracion & ".mp3"
        Else
            FileToDelete = "C:\Frances\Audios\Femenino\" & IdOracion & ".mp3"

        End If
        

        Try

            If File.Exists(FileToDelete) Then
                File.Delete(FileToDelete)
                ' MsgBox("Se quito correctamente")

            End If

            'MoveLocation = "C:\Legacy\Ingles\Papelera\" & IdOracion & ".mp3"

            '    If File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3") Then
            '        System.IO.File.Move(FileToMove, MoveLocation)
            '    End If
        Catch ex As Exception
        End Try
        'Dim psi As New ProcessStartInfo()
        'psi.FileName = "python"
        'psi.UseShellExecute = False
        'psi.RedirectStandardOutput = True
        'psi.CreateNoWindow = True
        'Dim p As Process = Process.Start(psi)
        'Dim resultado As String = p.StandardOutput.ReadToEnd()
        'p.WaitForExit()
        'MessageBox.Show(resultado)

        ''''''
        txtStatus.Text = "Iniciando..."

        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        'psi.Arguments = "-u ""C:\legacy\Programas\Voz_Natural\ordenporId.py"" " & Enc_Id
        psi.Arguments = "-u ""C:\legacy\Programas\Voz_Natural\GeneraAudioF3.py"" " & IdOracion
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True
        psi.CreateNoWindow = True

        Dim p As New Process()
        p.StartInfo = psi
        p.EnableRaisingEvents = True

        AddHandler p.OutputDataReceived,
            Sub(senderObj, args)
                If args.Data IsNot Nothing Then
                    Me.BeginInvoke(Sub()
                                       txtStatus.Text &= vbCrLf & args.Data
                                       txtStatus.SelectionStart = txtStatus.TextLength
                                       txtStatus.ScrollToCaret()
                                   End Sub)
                End If
            End Sub

        AddHandler p.ErrorDataReceived,
            Sub(senderObj, args)
                If args.Data IsNot Nothing Then
                    Me.BeginInvoke(Sub()
                                       txtStatus.Text &= vbCrLf & args.Data
                                       txtStatus.SelectionStart = txtStatus.TextLength
                                       txtStatus.ScrollToCaret()
                                   End Sub)
                End If
            End Sub

        AddHandler p.Exited,
            Sub()
                Me.BeginInvoke(Sub()
                                   'txtStatus.Text = "Proceso finalizado"
                               End Sub)
            End Sub

        p.Start()
        p.BeginOutputReadLine()
        p.BeginErrorReadLine()

    End Sub

    Private Sub cmdtraducir_Click(sender As System.Object, e As System.EventArgs) Handles cmdtraducir.Click
        My.Computer.Audio.Stop()

        'Dim psi As New ProcessStartInfo()
        'psi.FileName = "python"
        'psi.UseShellExecute = False
        'psi.RedirectStandardOutput = True
        'psi.CreateNoWindow = True

        'Dim p As Process = Process.Start(psi)
        'Dim resultado As String = p.StandardOutput.ReadToEnd()
        'p.WaitForExit()

        'MessageBox.Show(resultado)
        'CargarDatos(IdOracion)

        Dim psi As New ProcessStartInfo()

        psi.FileName = "python.exe"  ' Mejor especificar .exe

        psi.Arguments = """C:\legacy\Programas\Voz_Natural\traducirporId.py"" " & IdOracion

        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True   ' 🔥 IMPORTANTE
        psi.CreateNoWindow = True

        Dim p As Process = Process.Start(psi)

        Dim resultado As String = p.StandardOutput.ReadToEnd()
        Dim errorOutput As String = p.StandardError.ReadToEnd()

        p.WaitForExit()

        If errorOutput <> "" Then
            txtStatus.Text = "ERROR: " & errorOutput
        Else
            txtStatus.Text = resultado
        End If

        CargarDatos(IdOracion)

    End Sub

     
    Private Sub txtIMG_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIMG.TextChanged
        If Me.txtIMG.Text <> Imagen Then
            Try
                DetectChanges("IMG", Imagen, txtIMG.Text, "")
                Imagen = txtIMG.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmdAbrirFolder_Click(sender As System.Object, e As System.EventArgs) Handles cmdAbrirFolder.Click
        Process.Start("explorer.exe", "C:\Legacy\Ingles\Imagenes_Ingles")
    End Sub

    Private Sub txtContexto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContexto.TextChanged
        If Me.txtContexto.Text <> Contexto Then
            Try
                DetectChanges("Contexto", Contexto, txtContexto.Text, "")
                Contexto = txtContexto.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmdMoverAudioMasculino_Click(sender As System.Object, e As System.EventArgs) Handles cmdMoverAudioMasculino.Click
        ' Dim ofd As New OpenFileDialog

        Dim i As Integer
        Dim carpeta As String
        Dim FileToMove As String
        Dim MoveLocation As String

        ' Using ofd As New OpenFileDialog

        ' ofd.InitialDirectory = "C:\Legacy\Ingles\Audios\"
        'My.Computer.FileSystem.RenameFile("C:\Ruta\A\documento.txt", "informe.txt")
        ' If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then

        Dim filename As String = ""
        Dim ruta As String = ""
        ' ruta = ofd.FileNames.
        ' filename = ofd.FileName
        carpeta = Dir(filename)
        Try

            If File.Exists("C:\Legacy\Ingles\Audios\Femenino\" & IdOracion & ".mp3") Then
                ' El archivo existe
                'My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\Femenino" & IdOracion & ".mp3", IdOracion & "_2.mp3")
                FileToMove = "C:\Legacy\Ingles\Audios\Femenino\" & IdOracion & ".mp3"
                MoveLocation = "C:\Legacy\Ingles\Audios\Masculino\" & IdOracion & ".mp3"

                System.IO.File.Move(FileToMove, MoveLocation)

            Else 'No existe
            End If
            'My.Computer.FileSystem.RenameFile(filename, IdOracion & ".mp3")
        Catch ex As Exception
        End Try

        '  End If

        'Mover de Sin Definir a Audios


        'If carpeta = "C:\Legacy\Ingles\Audios\SinDefinir\" Then
        '    FileToMove = "C:\Legacy\Ingles\Audios\SinDefinir\" & IdOracion & ".mp3"
        '    MoveLocation = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"


        '    Try
        '        ' System.IO.File.Move(FileToMove, MoveLocation)
        '    Catch ex As Exception

        '    End Try
        'End If

        ' End Using






    End Sub

    Private Sub cmdGuardarNuevo_Click(sender As System.Object, e As System.EventArgs) Handles cmdGuardarNuevo.Click
        Dim OracionEN As String
        Dim OracionES As String

        OracionEN = Trim(txtOracionNueva.Text)
        OracionES = Trim(txtTraduccionNueva.Text)

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim GrupoO As Integer
         
        'GrupoO = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

        sqlstring = "Insert into Oraciones (Oracion, TextoPlano, Traduccion, GrupoO)"
        sqlstring = sqlstring & " Values (@Oracion, @TextoPlano, @Traduccion, @GrupoO)"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        'GrupoO: 1050 _sin definir
        _comando.Parameters.AddWithValue("@Oracion", OracionEN)
        _comando.Parameters.AddWithValue("@TextoPlano", OracionEN)
        _comando.Parameters.AddWithValue("@Traduccion", OracionES)
        _comando.Parameters.AddWithValue("@GrupoO", 1050)
         
        '   _comando.Parameters.AddWithValue("@foco", 1)
        'Else
        '    _comando.Parameters.AddWithValue("@foco", 0)
        'End If


        Try
            i = _comando.ExecuteNonQuery

            If i > 0 Then
            Else
                '  MsgBox("No se guardo")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        _comando.Connection.Close()

        ' RichTextBoxEx1.rtb.Text = ""
        txtOracionNueva.Text = ""
        txtTraduccionNueva.Text = ""

         
    End Sub

    Private Sub cmbTema_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbTema.SelectedIndexChanged
        If Me.cmbTema.Text <> Tema Then
            Try
                DetectChanges("Tema", Tema, cmbTema.Text, "")
                Tema = cmbTema.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub EsPregunta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles EsPregunta.CheckedChanged

        If EsPregunta.Checked = True Then
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String

            Dim i As Integer
           
            _comando.Connection.Open()

            _comando.Parameters.Clear()

            sqlstring = "UPDATE Oraciones_FR SET IMG='pensando'"
            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Id", IdOracion)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            _comando.Connection.Close()

        End If

        cmdExit_Click(sender, e)

    End Sub

    Private Sub EsPersonajeA_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles EsPersonajeA.CheckedChanged
        If EsPersonajeA.Checked = True Then
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String

            Dim i As Integer

            _comando.Connection.Open()

            _comando.Parameters.Clear()

            sqlstring = "UPDATE Oraciones SET IMG='Like'"
            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Id", IdOracion)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            _comando.Connection.Close()

        End If

        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdEliminarAudio_Click(sender As System.Object, e As System.EventArgs) Handles cmdEliminarAudio.Click
        Dim i As Integer
        Dim carpeta As String

        ' 
        Dim FileToDelete As String
        Dim MoveLocation As String

        ' If personaje = "A" Or personaje = "C" Then
        If idioma = "IN" Then
            FileToDelete = "C:\Ingles\Audios3\Femenino\" & IdOracion & ".mp3"
        Else
            FileToDelete = "C:\Frances\Audios\Femenino\" & IdOracion & ".mp3"

        End If
        'ElseIf personaje = "B" Then
        ' FileToDelete = "C:\Legacy\Ingles\Audios3\Masculino\" & IdOracion & ".mp3"

        ' End If


        Try

            If File.Exists(FileToDelete) Then
                File.Delete(FileToDelete)
                MsgBox("Se quito correctamente")

            End If

            'MoveLocation = "C:\Legacy\Ingles\Papelera\" & IdOracion & ".mp3"

            '    If File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3") Then
            '        System.IO.File.Move(FileToMove, MoveLocation)



            '    End If



        Catch ex As Exception
        End Try


    End Sub

    Private Sub Label29_Click(sender As System.Object, e As System.EventArgs) Handles Label29.Click, Label33.Click

    End Sub

    Private Sub cmdGenerar_Click(sender As System.Object, e As System.EventArgs) Handles cmdGenerar.Click

        My.Computer.Audio.Stop()

        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\respuesta1.py"" " & IdOracion
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        Dim p As Process = Process.Start(psi)
        Dim resultado As String = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

        MessageBox.Show(resultado)
    End Sub

  

    Private Sub txtPregunta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPregunta.TextChanged
        If Me.txtPregunta.Text <> Pregunta Then
            Try
                DetectChanges("Pregunta", Pregunta, txtPregunta.Text, "")
                Pregunta = txtPregunta.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmdGuardarPred_Click(sender As System.Object, e As System.EventArgs) Handles cmdGuardarPred.Click
        Dim resp As Boolean
        Dim respcorreo As Boolean


        'resp = CapaLogica.UpdateTicket(lstModificaciones, Id)

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim item As ListViewItem

        Dim i As Integer
        Dim _insertado As Boolean = False
        Dim mostrarMensaje As Boolean = False
        Dim stringvalues As String = ""
        Dim sql As String = ""
        Dim IdMax As Integer

        Dim fecha As Date
        Dim fechaEntrega As Date
        ' fecha = Today

        _comando.Connection.Open()


        For Each r In lstModificaciones.Items
            _comando.Parameters.Clear()

            If r.SubItems(3).text = "Null" Then
                sqlstring = "UPDATE Oraciones SET " & r.SubItems(1).Text & " = Null"

            Else
                sqlstring = "UPDATE Oraciones SET " & r.SubItems(1).Text & " = @" & r.SubItems(1).Text
                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.Parameters.AddWithValue("@" & r.SubItems(1).Text, r.SubItems(3).Text)

            End If

            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Id", IdOracion)
            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If i = 1 Then
                txtStatus.Text = "Guardado: " & Now
            End If

        Next
        _comando.Connection.Close()
    End Sub

     

    Private Sub cmdEliminarVideo_Click(sender As System.Object, e As System.EventArgs) Handles cmdEliminarVideo.Click
        Dim i As Integer
        Dim carpeta As String
         
        Dim FileToDelete As String
        Dim MoveLocation As String

        If personaje = "A" Or personaje = "C" Then
            FileToDelete = "C:\Legacy\Ingles\videos\" & IdOracion & ".mp4"
        ElseIf personaje = "B" Then
            FileToDelete = "C:\Legacy\Ingles\videos\" & IdOracion & ".mp4"

        End If


        Try

            If File.Exists(FileToDelete) Then
                File.Delete(FileToDelete)
                MsgBox("Se quito correctamente")

            End If

            Dim resp As Boolean

            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String

            Dim item As ListViewItem

            Dim _insertado As Boolean = False
            Dim mostrarMensaje As Boolean = False
            Dim stringvalues As String = ""
            Dim sql As String = ""
            Dim IdMax As Integer


            _comando.Connection.Open()

            _comando.Parameters.Clear()

            sqlstring = "UPDATE Oraciones SET videogenerado=@videogenerado"
            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@videogenerado", 0)
            _comando.Parameters.AddWithValue("@Id", IdOracion)

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            _comando.Connection.Close()



        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdGenerarVideoFemenino_Click(sender As System.Object, e As System.EventArgs) Handles cmdGenerarVideoFemenino.Click
        My.Computer.Audio.Stop()

        'Dim psi As New ProcessStartInfo()
        'psi.FileName = "python"
        'psi.UseShellExecute = False
        'psi.RedirectStandardOutput = True
        'psi.CreateNoWindow = True

        'Dim p As Process = Process.Start(psi)
        'Dim resultado As String = p.StandardOutput.ReadToEnd()
        'p.WaitForExit()

        'MessageBox.Show(resultado)

        ''''''
        txtStatus.Text = "Iniciando..."

        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        'psi.Arguments = "-u ""C:\legacy\Programas\Voz_Natural\ordenporId.py"" " & Enc_Id
        psi.Arguments = "-u ""C:\legacy\Programas\Voz_Natural\avatar_id.py"" " & IdOracion
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True
        psi.CreateNoWindow = True

        Dim p As New Process()
        p.StartInfo = psi
        p.EnableRaisingEvents = True

        AddHandler p.OutputDataReceived,
            Sub(senderObj, args)
                If args.Data IsNot Nothing Then
                    Me.BeginInvoke(Sub()
                                       ' txtStatus.Text = args.Data
                                       txtStatus.Text &= vbCrLf & args.Data
                                       txtStatus.SelectionStart = txtStatus.TextLength
                                       txtStatus.ScrollToCaret()
                                   End Sub)
                End If
            End Sub

        AddHandler p.ErrorDataReceived,
            Sub(senderObj, args)
                If args.Data IsNot Nothing Then
                    Me.BeginInvoke(Sub()
                                       txtStatus.Text &= vbCrLf & args.Data
                                       txtStatus.SelectionStart = txtStatus.TextLength
                                       txtStatus.ScrollToCaret()
                                   End Sub)
                End If
            End Sub

        AddHandler p.Exited,
            Sub()
                Me.BeginInvoke(Sub()
                                   'ToolStatus.Text = "Proceso finalizado"
                               End Sub)
            End Sub

        p.Start()
        p.BeginOutputReadLine()
        p.BeginErrorReadLine()

    End Sub

    

    Private Sub cboVoice_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboVoice.SelectedIndexChanged
        If Me.cboVoice.Text <> voice Then
            Try
                DetectChanges("Voice", voice, cboVoice.Text, "")
                voice = cboVoice.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cboExpresion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboExpresion.SelectedIndexChanged
        If Me.cboExpresion.Text <> intencion Then
            Try
                DetectChanges("Expresion", intencion, cboExpresion.Text, "")
                intencion = cboExpresion.Text
            Catch ex As Exception

            End Try
        End If
    End Sub
 
    Private Sub checkObjeto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkObjeto.CheckedChanged
        Dim _personajeNuevo As String

        If checkObjeto.Checked = True Then
            _personajeNuevo = "C"
        Else
            _personajeNuevo = "A"
        End If

        If _personajeNuevo <> personaje Then
            Try
                DetectChanges("personaje", personaje, _personajeNuevo, "")
                personaje = _personajeNuevo
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class