Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports RichTextBoxEx
Imports System.IO
Imports SpeechLib
Imports System.Speech.Synthesis

Public Class frmOracionesRead


#Region "variables"
    Public ok As Integer

    Public contenedor As String
    Public sqlstring As String
    Public MaxColumna As Integer
    Public Titulo As String
    Public filtro As String
    Public ColorActivo As Object = System.Drawing.Color.FromArgb(198, 255, 196)
    ' Public ColorInicio As SystemBrushes = Brushes.Gainsboro


    'Public Shared Id As Integer
    Public consulta As String
    Dim rowcount As Integer
    ' Public Device As clsDevice
    'Public Id As Integer
    Public Nombre As String = ""
    Public Tipo As String = ""
    Public tipoId As Integer
    Public Status As String = ""
    Public Area As String = ""
    Public bandActivado As Boolean
    Public bandstop As Boolean
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

    Public Categoria2 As String = ""
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
    Public traduccion As String = ""

    Public bandTimeValue As Boolean
    Public bandEstado As Boolean

    'Variables
    Public Id As Integer
    Public IdOracion As Integer
    Public paused As Boolean = False

    Public speech As SpVoice = New SpVoice()
    Public speechRate As Integer = -1 ' Rango desde -10 hasta 10 
    Public volume As Integer = 80 ' Rango desde 0 hasta 100.

    Dim objtextCurr As Label
    Dim objtextOver As Label

    Public bandComplete As Boolean

    Public lstModificaciones As New ListView

    Public speaker As New SpeechSynthesizer()
    Public Event SpeakCompleted As EventHandler(Of SpeakCompletedEventArgs)
    Public handler As EventHandler(Of SpeakCompletedEventArgs)
#End Region

#Region "Inicio"
    Private Sub test_Click(sender As System.Object, e As System.EventArgs) Handles test.Click
        'Dim i As Integer
        'Dim nm As String
        'Dim str() As String
        'Dim tp As String
        'Dim param As String = ""
        'Dim q As Integer
        'Dim obj As New Label
        'Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
        ''Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        'If (paused) = True Then
        'Else
        '    speech.Resume()
        '    paused = False

        'End If

        'AddHandler speaker.SpeakCompleted, handler


        'obj.Text = 
        ' paused = True
        ' spe()
        'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(1)



        ' Synth_PhonemeReached(sender, e)
        '   Dim sentences As New List(Of String)()
        ' Dim start As Integer = 0
        ' Dim position As Integer
        ' Console.WriteLine(speech.Status)

        'SpeakCompletedEventArgs()


        AddHandler speaker.SpeakCompleted, AddressOf SpeachComplete

        ' speaker.Voice=
        ' ' speaker.Speak(Texto.Text)
        'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(person)
        'speaker.Voice = speaker.GetVoices(String.Empty, String.Empty).Item(person)
        speaker.SelectVoice("Microsoft David Desktop")
        speaker.Rate = speechRate
        speaker.Volume = volume

        speaker.SpeakAsync("This is a test speach to see if the speach complete event raises")


        'speech.Rate = speechRate
        'speech.Volume = volume
        'speech.Speak(Texto.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)


    End Sub
    Private Sub frmOracionesRead_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'WebBrowser1.Document.BackColor = Color.White
        ' RichTextBoxEx1.Controls.Item("rtb").LoadFile = "C:\Legacy\Test.rtf"

        Dim test As Boolean

        'Dim obj As New RichTextBoxEx.RichTextBoxEx

        ' obj.Controls.Item("rtb").Focus()

        lstOraciones.View = View.Tile ' Set the view to show details.
        lstOraciones.LabelEdit = False ' Allow the user to edit item text.
        lstOraciones.AllowColumnReorder = True ' Allow the user to rearrange columns.
        lstOraciones.FullRowSelect = True
        lstOraciones.GridLines = True
        lstOraciones.TileSize = New Size(500, 40)
        ' lstOraciones.Dock = DockStyle.Fill
        lstOraciones.ShowItemToolTips = True

        ListView1.View = View.Details ' Set the view to show details.
        ListView1.LabelEdit = False ' Allow the user to edit item text.
        ListView1.AllowColumnReorder = True ' Allow the user to rearrange columns.
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ' ListView1.TileSize = New Size(500, 40)
        ListView1.ShowItemToolTips = True
        'RichTextBoxEx.RichTextBoxEx.
        ' 'test = RichTextBoxEx.RichTextBoxEx.
        '   RichTextBox1.LoadFile("C:\Legacy\Rtf\" & Id & ".rtf

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

            Me.cboGrupo.DataSource = dt
            Me.cboGrupo.ValueMember = "Id"
            Me.cboGrupo.DisplayMember = "Grupo"

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        cboGrupo.Text = ""

        CrearControles()

        ToolStatus.Text = "Oracion"


        lblVelocidad.Text = TrackBarVelocidad.Value


    End Sub
    Public Sub CargarConversation(Id)
        Dim param As String = " WHERE Enc_Conversation.Con_Id=" & Id
        Dim resp As Integer

        Dim i, n As Integer
        Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Det_Conversation.Det_Person, Det_Conversation.Det_Par, Oraciones.Oracion, "
        sqlstring = sqlstring & " Enc_Conversation.Con_Titulo, Enc_Conversation.Con_Id"
        sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
        sqlstring = sqlstring & "              Enc_Conversation ON Det_Conversation.Con_Id = Enc_Conversation.Con_Id INNER JOIN"
        sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"

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

    End Sub
    Public Sub CargarDatos(Id)





    End Sub
#End Region
#Region "Controles"
    Public Sub CrearControles()
        Dim pAux As Panel
        Dim txtNombre As Label
        Dim txtFecha As Label
        Dim txtMinutos As Label
        Dim btnSolution As Button
        Dim btnUp As Button
        Dim btnDown As Button
        Dim btnDelete As Button
        Dim btnHide As Button
        Dim btnTask As Button
        Dim btnStatus As Button
        Dim btnExam As Button

        Dim btnLeer As Button
        Dim txtParam As Label
        Dim btnAuxNo As Label
        Dim txtTest As TextBox

        Dim yPos As Integer
        Dim lblY As Integer

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim criterio As String
        Dim DatosTickets As DataTable
        Dim param As String = ""
        Dim i, n As Integer
        Dim ticketId, ticketTipo As String

        Dim usuarios As List(Of String)
        Dim fechas As List(Of String)
        Dim Comentarios As List(Of String)
        Dim parametros As List(Of String)
        Dim IdGrupo As Integer

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String = ""

        If cboGrupo.Text = "" Then Exit Sub

        IdGrupo = Me.cboGrupo.SelectedValue
        If IdGrupo = 0 Then Exit Sub

        sqlstring = "   SELECT         Oraciones.Id, Oraciones.Oracion, Oraciones.ConceptoID, Oraciones.GrupoO, Oraciones.Traduccion, Oraciones.Campo1, Oraciones.F5, Oraciones.F6, Oraciones.Palabra, Oraciones.[Delete], Oraciones.SEL, "
        sqlstring = sqlstring & "                    Oraciones.estatus, Oraciones.GrupoId, Oraciones.forma, Oraciones.STL, Oraciones.GRUPO, Oraciones.IMG, Oraciones.Orden, Oraciones.Campo2, Oraciones.IPA, Oraciones.Campo3, Oraciones.TextoPlano, Oraciones.CursoId, "
        sqlstring = sqlstring & "                    Oraciones.Ora_Aprendido, Oraciones.Exam, Grupos_oracion.Grupo AS Expr1"
        sqlstring = sqlstring & " FROM            Oraciones INNER JOIN"
        sqlstring = sqlstring & "                    Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"
        sqlstring = sqlstring & " WHERE  Oraciones.GrupoO='" & IdGrupo & "'"
        sqlstring = sqlstring & " ORDER BY  orden ASC"

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


        ok = 0
        n = dt.Rows.Count
        txtCuenta.Text = n
        yPos = 10

        i = 0

        pEtapa.Controls.Clear()

        ListView1.Items.Clear()


        Dim List As New List(Of String)

        pEtapa.AutoScroll = True

        Dim person1 As Integer
        Dim person2 As Integer

        Dim p As PictureBox
        Dim bmp As Bitmap
        Dim g As Graphics

        Dim nm As String
        ' n = 1
        For i = 0 To n - 1

            nm = dt.Rows(i).Item(0)

            pAux = New Panel
            pAux.Name = "pAux_" & nm
            'pAux.Name = "pAux" & i

            pAux.Height = 70
            pAux.Width = 1200
            'pAux.AutoSize = True
            'pAux.Size = New System.Drawing.Size(pAux.Width, 0)
            pAux.Location = New Point(0, yPos)
            pAux.BackColor = Color.Beige
            ' pAux.BorderStyle = BorderStyle.FixedSingle
            pAux.BorderStyle = BorderStyle.Fixed3D
            '  pAux.BorderStyle = BorderStyle.FixedSingle
            ' pAux.Width = 500
            ' pEtapa.Controls.Add(pAux, 0, i)
            Try
                pEtapa.Controls.Add(pAux)

            Catch ex As Exception

            End Try
             
            'Texto en Ingles

            txtNombre = New Label
            txtNombre.Name = "txt_" & dt.Rows(i).Item(0)
            ' txtNombre.Name = "txt0"
            'txtNombre.HideSelection = False
            txtNombre.Text = dt.Rows(i).Item(21) '& " " & dt.Rows(i).Item(1) '& vbCrLf & vbCrLf & dt.Rows(i).Item(3)
            txtNombre.BorderStyle = BorderStyle.None
            txtNombre.Font = New System.Drawing.Font("Consolas", 11, FontStyle.Regular)
            txtNombre.Visible = True

            txtNombre.AutoSize = True
            ' txtNombre.Width = 500
            txtNombre.Location = New Point(75, 5)
            '   txtNombre.BackColor = Color.LightGray
            txtNombre.Height = txtNombre.PreferredHeight
            AddHandler txtNombre.Click, AddressOf RefreshTexto

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtNombre)
             
            ''Traduccion
            If Not IsDBNull(dt.Rows(i).Item(4)) Then
                txtMinutos = New Label
                txtMinutos.Name = "tra_" & dt.Rows(i).Item(0)
                txtMinutos.Text = dt.Rows(i).Item(4)
                txtMinutos.BorderStyle = BorderStyle.None
                txtMinutos.Font = New System.Drawing.Font("Arial", 9, FontStyle.Regular)
                txtMinutos.ForeColor = Color.DimGray
                txtMinutos.AutoSize = True
                
                txtMinutos.Location = New Point(75, txtNombre.Bottom + 5)
                
                txtMinutos.Height = txtNombre.PreferredHeight
                txtMinutos.Visible = True
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtMinutos)
            End If

            'Delete
            btnDelete = New Button
            btnDelete.Name = "btnDelete_" & dt.Rows(i).Item(0)
            btnDelete.Width = 25 : btnDelete.Height = 25 ': btnTask.Text = "Report"
            btnDelete.Location = New Point(pAux.Right - 40, 1)
            ' btnDown.Image = ImageList3.Images.Item(1)
            btnDelete.Text = "X"

            'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
            'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
            AddHandler btnDelete.Click, AddressOf Delete

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnDelete)


            'Editar
            btnTask = New Button
            btnTask.Name = "btnTask_" & dt.Rows(i).Item(0)
            btnTask.Width = 25 : btnDelete.Height = 25 ': btnTask.Text = "Report"
            btnTask.Location = New Point(pAux.Right - 40, btnDelete.Bottom + 1)
            ' btnDown.Image = ImageList3.Images.Item(1)
            btnTask.Text = "Edit"

            'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
            'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
            AddHandler btnTask.Click, AddressOf Editar

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnTask)

            btnUp = New Button
            ' btnUp.Name = "btnUp_" & dt.Rows(i).Item(6)
            btnUp.Name = "btnUp_" & i
            btnUp.Width = 52 : btnUp.Height = 19 ': btnTask.Text = "Report"
            btnUp.Location = New Point(btnDelete.Left - 55, 1)
            btnUp.Text = "UP"
            ' btnUp.TextImageRelation = TextImageRelation.ImageAboveText
            ' AddHandler btnUp.Click, Sub() MoveUp(i)
            AddHandler btnUp.Click, AddressOf MoveUp
            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnUp)

            btnDown = New Button
            ' btnDown.Name = "btnDown_" & dt.Rows(i).Item(1)
            btnDown.Name = "btnDown_" & i
            btnDown.Width = 52 : btnDown.Height = 19 ': btnTask.Text = "Report"
            btnDown.Location = New Point(btnDelete.Left - 55, btnDown.Bottom + 1)
            ' btnDown.Image = ImageList3.Images.Item(1)
            btnDown.Text = "DOWN"

            'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
            'AddHandler btnDown.Click, Sub() MoveDown(i)
            AddHandler btnDown.Click, AddressOf MoveDown

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnDown)


            'Leer
            btnLeer = New Button
            btnLeer.Name = dt.Rows(i).Item(0)
            btnLeer.Width = 25 : btnLeer.Height = 25 ': btnTask.Text = "Report"
            btnLeer.Location = New Point(40, 1)
            'btnLeer.Text = "L"
            btnLeer.Image = ImageList1.Images.Item(0)

            'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
            'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
            AddHandler btnLeer.Click, AddressOf LeerTexto
            ' AddHandler btnLeer.Click, AddressOf CambiarColor
            Try
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnLeer)
            Catch ex As Exception
            End Try
            'Status
            btnStatus = New Button
            btnStatus.Name = "btnStatus_" & dt.Rows(i).Item(0)
            btnStatus.Width = 35 : btnDelete.Height = 25
            btnStatus.Location = New Point(btnUp.Left - 50, 1)

            If dt.Rows(i).Item(14) = False Then
                btnStatus.Text = "NO"
                btnStatus.BackColor = Color.LightSalmon
            Else
                btnStatus.Text = "SI"
                btnStatus.BackColor = Color.LightGreen
                ok = ok + 1
            End If

            AddHandler btnStatus.Click, AddressOf StatusControl
            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnStatus)

           

            'Examen
            txtTest = New TextBox
            txtTest.Name = "tst_" & dt.Rows(i).Item(0)
            If Not IsDBNull(dt.Rows(i).Item(25)) Then
                txtTest.Text = dt.Rows(i).Item(25)
            End If

            txtTest.BorderStyle = BorderStyle.None
            txtTest.Font = New System.Drawing.Font("Consolas", 11, FontStyle.Regular)

            '  txtTest.AutoSize = True
            txtTest.Width = 1000
            txtTest.Location = New Point(75, txtMinutos.Bottom + 5)
            txtTest.BackColor = Color.White
            'txtTest.Height = txtTest.PreferredHeight
            If dt.Rows(i).Item(14) = True Then
                txtTest.ForeColor = Color.DarkGreen
                ' txtNombre.Visible = True
                ' txtMinutos.Visible = True
            Else
                txtTest.ForeColor = Color.DarkRed
                ' txtNombre.Visible = False
                ' txtMinutos.Visible = False
            End If
            txtTest.Font = New Font("Consolas", 11, FontStyle.Bold)

            If dt.Rows(i).Item(14) = True Then
                txtNombre.BackColor = Color.LightGreen
            Else
                txtNombre.BackColor = Color.LightSalmon
            End If

            AddHandler txtTest.LostFocus, AddressOf Exam

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTest)

            'Guardar Test
            btnExam = New Button
            btnExam.Name = "btnExam_" & dt.Rows(i).Item(0)
            btnExam.Width = 50 : btnExam.Height = 20
            btnExam.Location = New Point(txtTest.Right + 5, txtMinutos.Bottom)
            btnExam.Text = "SAVE"

            AddHandler btnExam.Click, AddressOf SaveExam
            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnExam)


            'Show / Hide
            btnHide = New Button
            btnHide.Name = "btnHide_" & dt.Rows(i).Item(0)
            btnHide.Width = 25 : btnHide.Height = 25 ': btnTask.Text = "Report"
            btnHide.Location = New Point(40, btnLeer.Bottom + 0.5)
            ' btnDown.Image = ImageList3.Images.Item(1)
            btnHide.Text = " ? "

            'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
            'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
            AddHandler btnHide.Click, AddressOf Show

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnHide)


            'Imagen
            p = New PictureBox
            p.Name = "p_" & dt.Rows(i).Item(0)
            p.Tag = dt.Rows(i).Item(5)
            ' bmp = New Bitmap(p.Size.Width, p.Size.Height)

            'If dt.Rows(i).Item(5) = 1 Then
            'txtNombre.Image = 

            'p.Image = ImageList4.Images.Item(dt.Rows(i).Item(5))
            Try
                p.Image = ImageList5.Images.Item(dt.Rows(i).Item(5))
                'bmp = New Bitmap(p.Size.Width, p.Size.Height)
                'p.Image = bmp
                p.Location = New Point(2, 1)
                AddHandler p.Click, AddressOf SeleccionarPersona

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(p)

            Catch ex As Exception
            End Try



            Dim item As ListViewItem 'Creo el ListViewItem (item) 


            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.UseItemStyleForSubItems = False
            'item.Text = i
            Try
                'item.SubItems.Add(dt.Rows(i).Item(0))
                'item.SubItems.Add(dt.Rows(i).Item(1))
                item.SubItems.Add(dt.Rows(i).Item(4))
                item.SubItems.Add(dt.Rows(i).Item(0))

                'item.SubItems(0).ForeColor = Color.Blue

                ListView1.Items.Add(item)
                ' ListBox1.Items.Add(item)


            Catch ex As Exception

            End Try


            Dim avance As Integer
            avance = (ok / txtCuenta.Text) * 100
            txtAvance.Text = avance


            yPos = yPos + 80

        Next i
        txtOk.Text = ok

    End Sub

    Private Sub Solution(Id)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer

        IdOracion = lstOraciones.SelectedItems(0).Text


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

            CrearControles()


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub
    Private Sub MoveDown(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim pos As Integer
        Dim n As Integer

        Dim itemOver As ListViewItem
        Dim itemCurr As ListViewItem
        Dim itemSel As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String

        Dim q As Integer

        ' Dim resp As Nullable(Of Integer)
        nm = sender.name
        str = nm.Split("_")
        Dim tp As String
        Dim param As String = ""

        tp = str(0)
        indice = str(1)


        n = ListView1.Items.Count

        If indice = -1 Then Exit Sub


        itemCurr = ListView1.Items(indice)


        If indice = ListView1.Items.Count - 1 Then

            'ListView1.Items.Remove(itemCurr)

        Else

            If indice >= ListView1.Items.Count - 1 Then

                ListView1.Items.Remove(itemCurr)

            Else

                ListView1.Items.Remove(itemCurr)
                ListView1.Items.Insert(indice + 1, itemCurr)

            End If


        End If
        ListView1.Refresh()

        _comando.Connection.Open()

        For Each r In ListView1.Items

            Console.WriteLine(r.SubItems(0).Text)
            Console.WriteLine(r.SubItems(1).Text)
            Console.WriteLine(r.SubItems(2).Text)
            Console.WriteLine(r.index)

            _comando.Parameters.Clear()

            '   item = New ListViewItem(lstAgregar.SelectedItems(0).Text()) 'Creo una nueva instancia de item pasandole el nombre como dato principal 




            If r.SubItems(2).text = "Null" Then
                sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
                sqlstring = sqlstring & " WHERE Id = @Id"
                '_comando.Parameters.AddWithValue("@Det_Orden", pos + 1)

            Else
                sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
                sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"

                '  _comando.Parameters.AddWithValue("@" & r.SubItems(1).Text, r.SubItems(3).Text)
                _comando.Parameters.AddWithValue("@Det_Orden", r.index)

            End If
            _comando.Parameters.AddWithValue("@Det_Con", r.SubItems(2).Text)


            _comando.CommandText = sqlstring


            i = _comando.ExecuteNonQuery


        Next
        _comando.Connection.Close()

        If i > 0 Then
        Else
            MsgBox("No se actualizo")
        End If
        'Bitacora
        'IdOracion = lstOraciones.SelectedItems(0).Text


        CrearControles()

        '_comando.CommandText = sqlstring

        'Try

        '    i = _comando.ExecuteNonQuery

        '    If i > 0 Then
        '        MsgBox("se guardo")
        '    Else
        '        MsgBox("No se guardo")
        '    End If

        '    CrearControles()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally

        'End Try
    End Sub
    Private Sub MoveUp(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim indice As Integer
        Dim itemCurr As ListViewItem
        Dim itemOver As ListViewItem
        Dim itemSel As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer

        ' Dim resp As Nullable(Of Integer)
        nm = sender.name
        str = nm.Split("_")

        tp = str(0)
        indice = str(1)

        itemCurr = ListView1.Items(indice)


        'If indice = ListView1.Items.Count - 1 Then

        'ListView1.Items.Remove(itemCurr)
        '   If ListView1.SelectedItems(0).Index = -1 Then Exit Sub

        '  indice = ListView1.SelectedItems(0).Index
        'itemCurr = ListView1.SelectedItems(0)
        itemCurr = ListView1.Items(indice)

        If indice = ListView1.Items.Count - 1 Then
            ListView1.Items.Remove(itemCurr)
            ListView1.Items.Insert(indice - 1, itemCurr)
        Else

            If indice = 0 Then
                ' ListView1.Items.Remove(itemCurr)
            Else
                ListView1.Items.Remove(itemCurr)
                ListView1.Items.Insert(indice - 1, itemCurr)
            End If
        End If

        ListView1.Refresh()


        _comando.Connection.Open()


        For Each r In ListView1.Items


            _comando.Parameters.Clear()

            If r.SubItems(2).text = "Null" Then
                sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
                sqlstring = sqlstring & " WHERE Id = @Id"

            Else
                sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
                sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"

                _comando.Parameters.AddWithValue("@Det_Orden", r.index)

            End If
            _comando.Parameters.AddWithValue("@Det_Con", r.SubItems(2).Text)



            Try
                _comando.CommandText = sqlstring

                i = _comando.ExecuteNonQuery


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try


        Next


        'If i > 0 Then
        '    MsgBox("se guardo")
        'Else
        '    MsgBox("No se guardo")
        'End If

        CrearControles()







    End Sub
    Private Sub Delete(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer

        ' Dim resp As Nullable(Of Integer)
        nm = sender.name
        str = nm.Split("_")

        tp = str(0)
        IdOracion = str(1)

        sqlstring = "Delete From Det_Conversation "
        sqlstring = sqlstring & "  WHERE Con_Id = '" & Id & "' And Det_Con='" & IdOracion & "'"


        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                'MsgBox("se guardo")
            Else
                'MsgBox("No se guardo")
            End If

            CrearControles()

        Catch ex As Exception
            MsgBox(ex.Message)
            _comando.Connection.Close()

        Finally

        End Try
    End Sub
    Private Sub Editar(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim IdDet As Integer
        ' Dim resp As Nullable(Of Integer)
        ' obj = sender
        Dim IdOracionItem As Integer
        nm = sender.Name

        str = nm.Split("_")

        tp = str(0)

        IdOracionItem = str(1)

        'sqlstring = "select  orden, STL, TextoPlano, Traduccion, Estatus, Oracion, Id, GrupoO from Oraciones "
        'sqlstring = sqlstring & " Where Id= '" & IdDet & "'"
        ''sqlstring = sqlstring & " Order By orden ASC"

        'sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId"
        'sqlstring = sqlstring & " FROM            Det_Conversation"
        ''sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        'sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & IdDet & "'"
        ''sqlstring = sqlstring & " ORDER BY  Det_Conversation.Det_Orden ASC"

        Dim objDataReader As SqlDataReader

        Try
            _comando.CommandText = sqlstring

            _comando.Connection.Open()

            ''i = _comando.ExecuteNonQuery
            'da.SelectCommand = _comando

            'da.Fill(dt)


        Catch ex As Exception

        End Try

        Try
            'i = _comando.ExecuteNonQuery
            'objDataReader = _comando.ExecuteReader


            'If objDataReader.HasRows Then

            '    objDataReader.Read()
            '    '  Console.WriteLine(objDataReader(0))
            '    '  Console.WriteLine(objDataReader(1))

            '    IdOracionItem = objDataReader(1)

            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()






        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New FrmDetOracion

        AddOwnedForm(frm)

        ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        ' Id = dgvOraciones.CurrentRow.Cells(5).Value.ToString()
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
        frm.IdOracion = IdOracionItem
        frm.CargarDatos(IdOracionItem)
        frm.ShowDialog()

        '  StatusControl(IdDet, IdOracionItem)


        ''''''
        ' Editar
        ' Console.WriteLine(obj.Image)

        'IdPerson = cmbPersona.SelectedIndex

        ' resp = MsgBox("Confirmar?", MsgBoxStyle.YesNo)

        'If resp = 6 Then

        ' sqlstring = "Update Det_Conversation SET Det_Person='" & IdPerson & "'"
        '  sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"

        '_comando.CommandText = sqlstring
        '_comando.Connection.Open()


        Try
            'i = _comando.ExecuteNonQuery

            If i > 0 Then
                'MsgBox("se guardo")
                'obj.Image = ImageList5.Images(IdPerson)
                'obj.Text = "test"

            Else
                'MsgBox("No se guardo")
            End If
        Catch ex As Exception

        End Try


        ' Else





        '''''
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
    End Sub
    Private Sub RefreshTexto(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        ' Dim resp As Nullable(Of Integer)
        obj = sender

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)

        'IdOracion = str(1)

        sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Oraciones.TextoPlano, Det_Person, Det_Par, Oraciones.traduccion"
        sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
        sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & nm & "'"
        sqlstring = sqlstring & " ORDER BY  Det_Conversation.Det_Orden ASC"

        Try
            _comando.CommandText = sqlstring

            _comando.Connection.Open()

            'i = _comando.ExecuteNonQuery
            da.SelectCommand = _comando

            da.Fill(dt)
        Catch ex As Exception

        End Try
        _comando.Connection.Close()


        Try
            obj.Text = dt.Rows(0).Item(4)
            'txtNombre.Text = dt.Rows(i).Item(4) '& " " & dt.Rows(i).Item(1) '& vbCrLf & vbCrLf & dt.Rows(i).Item(3)

            If i > 0 Then
                'MsgBox("se guardo")
                'obj.Image = ImageList5.Images(IdPerson)
                'obj.Text = "test"

            Else
                'MsgBox("No se guardo")
            End If
        Catch ex As Exception

        End Try


        'Dim Id As Integer
        'Dim TipoTicket As String
        'Dim frm As New FrmDetOracion

        ' AddOwnedForm(frm)

        ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        ' Id = dgvOraciones.CurrentRow.Cells(5).Value.ToString()
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
        ''End If
        'frm.IdOracion = IdOracion
        'frm.CargarDatos(IdOracion)
        'frm.ShowDialog()

        ' CrearControles()

        ''''''
        ' Editar
        ' Console.WriteLine(obj.Image)

        'IdPerson = cmbPersona.SelectedIndex

        ' resp = MsgBox("Confirmar?", MsgBoxStyle.YesNo)

        'If resp = 6 Then

        ' sqlstring = "Update Det_Conversation SET Det_Person='" & IdPerson & "'"
        '  sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"

        '_comando.CommandText = sqlstring


        ' Else





        '''''
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
    End Sub
    Private Sub Show(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer

        ' Dim resp As Nullable(Of Integer)
        nm = sender.name
        str = nm.Split("_")

        tp = str(0)
        IdOracion = str(1)


        'Console.WriteLine(c.name)
        '  Console.WriteLine()

        If bandActivado = True Then
            pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("txt_" & IdOracion).Visible = True
            pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("tra_" & IdOracion).Visible = True
            bandActivado = False
            sender.text = "-"

        Else
            pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("txt_" & IdOracion).Visible = False
            pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("tra_" & IdOracion).Visible = False
            sender.text = "?"
            bandActivado = True
        End If

        ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")

        '   objtextCurr = pEtapa.Controls(c.name).Controls.Item("txt" & str(1))
        '  objtextCurr.Font = New Font("Consolas", 11, FontStyle.Bold)


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
    End Sub
    Private Sub Exam(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)

        IdOracion = str(1)

        If UCase(sender.text) = UCase(pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("txt_" & IdOracion).Text) Then
            sender.forecolor = Color.DarkGreen
            sender.font = New Font("Consolas", 11, FontStyle.Bold)
            ' objtext.Font = New Font("arial", 12, FontStyle.Bold)

        Else
            sender.forecolor = Color.DarkRed
            sender.font = New Font("Consolas", 11, FontStyle.Bold)

        End If

         
      

 

        ' 
    End Sub

    Private Sub SeleccionarPersona(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdDet As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer

        ' Dim resp As Nullable(Of Integer)
        nm = sender.name
        str = nm.Split("_")

        tp = str(0)
        IdDet = str(1)

        Dim Id As Integer
        Dim IdPerson As Integer
        Dim TipoTicket As String
        ' Dim frm As New FrmDetOracion
        Dim resp As Integer
        Dim obj As PictureBox

        obj = sender

        IdPerson = cmbPersona.SelectedIndex

        sqlstring = "Update Det_Conversation SET Det_Person='" & IdPerson & "'"
        sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        Try
            i = _comando.ExecuteNonQuery

            If i > 0 Then
                'MsgBox("se guardo")
                obj.Image = ImageList5.Images(IdPerson)

            Else
                'MsgBox("No se guardo")
            End If
        Catch ex As Exception

        End Try


        ' Else

        'End If



        'CrearControles()





        '    CrearControles()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    _comando.Connection.Close()

        'Finally

        'End Try
    End Sub
    Private Sub CambiarColor(sender, e)
        Dim objtext As New Label
        Dim n As String
        n = sender.name

        'objtext = pEtapa.Controls.Item("pAux" & n).Controls.Item("txt" & n)
        objtext = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
        ' objtext.ForeColor= color.
        objtext.Font = New Font("arial", 12, FontStyle.Bold)
        ' obj.Font = New Font("arial", 12, FontStyle.Bold)
    End Sub
    Private Sub SaveExam(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim btnStatus As Button
        Dim IdDet As Integer
        Dim IdOracionItem As Integer

        nm = sender.Name
        str = nm.Split("_")
        tp = str(0)
        '  IdDet = str(1)
        IdOracionItem = str(1)
 

        Dim Exam As String
        Exam = pEtapa.Controls.Item("pAux_" & IdOracionItem).Controls.Item("tst_" & IdOracionItem).Text


        Try


            sqlstring = "UPDATE Oraciones SET  Exam = @Exam"
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.Parameters.AddWithValue("@Id", IdOracionItem)
            _comando.Parameters.AddWithValue("@Exam", Exam)

            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            _comando.Connection.Close()


        Catch ex As Exception

        End Try



        If i > 0 Then
            sender.backcolor = Color.LightGreen

            '        'MsgBox("No se guardo")
        End If

        '    CrearControles()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    _comando.Connection.Close()

        'Finally

        'End Try
    End Sub
    Private Sub StatusControl(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        'Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim btnStatus As Button
        ' Dim IdDet As Integer
        Dim IdDet As Integer
        Dim IdOracion As Integer
        Dim estatus As Boolean
        nm = sender.Name
        str = nm.Split("_")
        tp = str(0)
        '  IdDet = str(1)
        IdOracion = str(1)

        Try

            If sender.text = "NO" Then
                estatus = True
                sender.backcolor = Color.LightGreen
                sender.text = "SI"
                ok = ok + 1

            Else
                estatus = False
                sender.backcolor = Color.LightSalmon
                sender.text = "NO"
                ok = ok - 1

            End If


           

            sqlstring = "UPDATE Oraciones SET STL = @STL"
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.Parameters.AddWithValue("@Id", IdOracion)
            _comando.Parameters.AddWithValue("@STL", estatus)


            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            _comando.Connection.Close()



            If i > 0 Then

            Else
                'MsgBox("No se guardo")
            End If
        Catch ex As Exception

        End Try

        Dim avance As Integer

        txtOk.Text = ok
        avance = (ok / txtCuenta.Text) * 100
        txtAvance.Text = avance

         

    End Sub

    Private Sub LeerTexto(sender, e)
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)

        'Voice : Microsoft David - English (United States)
        'Voice:  Microsoft(James - English(Australia))
        'Voice:  Microsoft(Linda - English(Canada))
        'Voice:  Microsoft(Richard - English(Canada))
        'Voice : Microsoft George - English (United Kingdom)
        'Voice : Microsoft Hazel - English (United Kingdom)
        'Voice : Microsoft Susan - English (United Kingdom)
        'Voice:  Microsoft(Catherine - English(Australia))
        'Voice : Microsoft Mark - English (United States)
        'Voice : Microsoft Zira - English (United States)

        'IdOracion = str(1)

        'sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Oraciones.TextoPlano, Det_Person, Det_Par, Oraciones.traduccion"
        'sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
        'sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        'sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & nm & "'"
        'sqlstring = sqlstring & " ORDER BY  Det_Conversation.Det_Orden ASC"

        'Try
        '    _comando.CommandText = sqlstring

        '    _comando.Connection.Open()

        '    da.SelectCommand = _comando

        '    da.Fill(dt)
        'Catch ex As Exception

        'End Try
        '_comando.Connection.Close()

        'nm = sender.Name
        'str = nm.Split("_")
        'tp = str(0)
        'IdOracion = str(1)

        'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(cmbVoices.SelectedIndex)

        'If (paused) = True Then
        'Else

        '    speech.Resume()
        '    paused = False

        'End If



        'speech.Rate = speechRate
        'speech.Volume = volume
        '' speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFlagsAsync)
        '' speech.Speak("Text", SpeechVoiceSpeakFlags.SVSFlagsAsync)
        'speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFVoiceMask)


        ''''leer lento
        'Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        'Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
        ' Dim i As Integer
        'Dim indice As Integer
        'Dim nm As String
        'Dim str() As String
        ' Dim tp As String
        ' Dim param As String = ""
        ' Dim q As Integer
        ' Dim obj As New Label
        'Dim obj As New Label
        ' Dim resp As Nullable(Of Integer)
        'obj = sender
        '  Dim dt As New DataTable
        '  Dim da As New SqlDataAdapter
        '   Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        'obj = sender
        Dim _voice As Integer
        _voice = pEtapa.Controls.Item("pAux_" & nm).Controls("p_" & nm).Tag
        ' pEtapa.Controls.Item("pAux" & q).Controls.Item("txtNombre_1" & q)
        'pEtapa.Controls.Item("pAux" & nm).Controls.Item("txt_" & nm)
        ' paused = True
        Select Case _voice

            Case 0, 1, 4
                _voice = 9
            Case 3, 7, 8  'Woman
                _voice = 2
            Case 2, 4, 5, 6 'Melendez 'Andrews
                _voice = 1
            Case 9
                _voice = 2
            Case 10, 11
                _voice = 1
        End Select

        If Not IsNothing(objtextOver) Then
            objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)

        End If

        Try
            objtextCurr = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("txt_" & nm)
            ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
            objtextCurr.Font = New Font("Consolas", 11, FontStyle.Bold)

            objtextOver = objtextCurr

            ' Dim pVoice As ISpVoice = CType(voice, ISpVoice)
            Dim otc As SpObjectTokenCategory = New SpObjectTokenCategory()
            otc.SetId("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices")

            Dim tokenEnum As ISpeechObjectTokens = otc.EnumerateTokens()
            Dim nTokenCount As Integer = tokenEnum.Count

            '  Console.WriteLine("Number of voices: {0}", nTokenCount)
            Dim n As UInteger = 0
            ' Dim pVoice As ISpVoice = CType(voice, ISpVoice)

            Dim pVoice As ISpVoice = CType(speech, ISpVoice)

            For Each sot As ISpeechObjectToken In tokenEnum
                Console.WriteLine("Voice : {0}", sot.GetDescription())
            Next

            ' pVoice.SetVoice(CType(sot, ISpObjectToken))
            pVoice.SetVoice(CType(tokenEnum(_voice), ISpObjectToken))
            ' pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))
            ' pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))
            ' speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(voice)
            ' speech.SetVoice(CType(tokenEnum(0), ISpObjectToken))

            ' AddHandler voice.EndStream, AddressOf speakComplete

            Try
                pVoice.Speak(objtextCurr.Text, 0, n)

            Catch ex As Exception

            End Try

            'For Each sot As ISpeechObjectToken In tokenEnum
            'Console.WriteLine("Voice : {0}", sot.GetDescription())

            'pVoice.SetVoice(CType(sot, ISpObjectToken))
            ' pVoice.SetVoice(CType(tokenEnum(0), ISpObjectToken))
            ' speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(voice)
            ' speech.SetVoice(CType(tokenEnum(0), ISpObjectToken))

            'Try
            '    ' pVoice.Speak(objtextCurr.Text, 0, n)

            '    ' speech.Speak(objtextCurr.Text, 0, 0)
            'Catch ex As System.Exception
            '    'Console.WriteLine("Cannot speak with the voice : {0}", sot.GetDescription())
            'End Try

            ' Next

            'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(voice)

            'If (paused) = True Then
            '    speech.Resume()
            '    paused = False

            'Else
            '    speech.Rate = speechRate
            '    speech.Volume = volume
            '    speech.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'str = nm.Split("_")
        'tp = str(0)

        'IdOracion = str(1)

        'sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Oraciones.TextoPlano, Det_Person, Det_Par, Oraciones.traduccion"
        'sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
        'sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        'sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & nm & "'"
        'sqlstring = sqlstring & " ORDER BY  Det_Conversation.Det_Orden ASC"

        'Try
        '    _comando.CommandText = sqlstring

        '    _comando.Connection.Open()

        '    da.SelectCommand = _comando

        '    da.Fill(dt)
        'Catch ex As Exception

        'End Try
        '_comando.Connection.Close()

        'nm = sender.Name
        'str = nm.Split("_")
        'tp = str(0)
        'IdOracion = str(1)

        'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(cmbVoices.SelectedIndex)

        'If (paused) = True Then
        'Else

        '    speech.Resume()
        '    paused = False

        'End If



        'speech.Rate = speechRate
        'speech.Volume = volume
        '' speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFlagsAsync)
        '' speech.Speak("Text", SpeechVoiceSpeakFlags.SVSFlagsAsync)
        'speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFVoiceMask)
 
        ' Dim voice As Integer
        'voice = pEtapa.Controls.Item("pAux_" & nm).Controls("p_" & nm).Tag
        ' pEtapa.Controls.Item("pAux" & q).Controls.Item("txtNombre_1" & q)
        'pEtapa.Controls.Item("pAux" & nm).Controls.Item("txt_" & nm)
        ' paused = True
        ' voice = cmbVoices.SelectedIndex


        'Select Case voice

        '    Case 0, 1, 4
        '        voice = 1


        '    Case 3, 7, 8  'Woman
        '        voice = 2

        '    Case 2, 4, 5, 6 'Melendez 'Andrews
        '        voice = 1

        '    Case 9
        '        voice = 2

        '    Case 10, 11
        '        voice = 1
        'End Select

        'If Not IsNothing(objtextOver) Then
        '    objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)

        'End If

        'Try
        '    objtextCurr = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("txt_" & nm)
        '    ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
        '    objtextCurr.Font = New Font("Consolas", 11, FontStyle.Bold)

        '    objtextOver = objtextCurr

        '    Dim speak As New SpeechSynthesizer
        '    speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(voice)

        '    If (paused) = True Then
        '        speech.Resume()
        '        paused = False

        '    Else
        '        'obj.Text = 


        '        speech.Rate = speechRate
        '        speech.Volume = volume
        '        '   speech.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

        '        'speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFVoiceMask)


        '        ' Synth_PhonemeReached(sender, e)
        '        'Dim sentences As New List(Of String)()
        '        'Dim start As Integer = 0
        '        'Dim position As Integer



        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        ' obj.Font = New Font("arial", 12, FontStyle.Bold)
        '  Call FontColor(nm)


        ' lblString.Text = "This is an example"
        ' If .BackColor = Color.Red Then
        '.BackColor = Color.Gray
        '' lblScore.Text = CInt(lblScore.Text) - 1
        '  End If
        ' .BackColor = Color.Green
        'If .BackColor = Color.Red Then
        ' lblScore.Text = CInt(lblScore.Text) - 1
        ' End If


        '' End With

        'Palabra por palabra
        'Dim objtext As TextBox
        '' objtext = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
        'objtext = pEtapa.Controls.Item("pAux" & nm).Controls.Item("txt" & nm)
        'objtext.HideSelection = False


        'For Each word As String In objtext.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        '    position = objtext.Text.IndexOf(word, start)

        '    objtext.SelectionStart = position
        '    objtext.SelectionLength = Len(word)
        '    start = Len(word)
        '    speech.Speak(word, SpeechVoiceSpeakFlags.SVSFDefault)

        'Next



        ' For Each word As String In TextBox1.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        'For Each word As String In pEtapa.Controls.Item("pAux0").Controls.Item("text_1").Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        'For Each word As String In objtext.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        'For Each word As String In lblString.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)


        '
        'Dim s As String = "This is the first sentence in a string. " &
        '          "More sentences will follow. For example, " &
        '          "this is the third sentence. This is the " &
        '          "fourth. And this is the fifth and final " &
        '          "sentence."



        ' Extract sentences from the string.
        'Do
        'If position >= 0 Then
        'sentences.Add(objtext.Text.Substring(start, position - start + 1).Trim())




        ' position = objtext.Text.IndexOf(word, start)

        'objtext.SelectionStart = position
        'objtext.SelectionLength = Len(word)
        'start = Len(word)

        'Dim vectoraux() As String
        ''vectoraux = TextBox1.Text.Split("<=,>=,>,<,+,-,/,*")
        'vectoraux = objtext.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        ''Dim numBox As TextBox = CType(word, TextBox)
        '  numBox.SelectAll()
        ' numBox.Focus()
        ' For Each r In vectoraux

        '  Next

        ''''''''
        'sobra:
        'position = position + Len(word)
        '  i = i + 1
        'End If
        'Loop While position > 0
        'objtext.ForeColor = Color.Red
        'word.Select(0, Len(word))



        ' Console.WriteLine(word)
        'TextBox1.
        'speak.SpeakAsync(word)

        'Select Case word
        '    Case "run"
        '        'Code
        '    Case "ok"
        '        'Code
        'End Select
        'Next





        'objtext.ForeColor = Color.Blue



    End Sub
    Private Sub cmdLeer_Click(sender As System.Object, e As System.EventArgs) Handles cmdLeer.Click
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        'If (paused) = True Then
        'Else
        '    speech.Resume()
        '    paused = False

        'End If

        AddHandler speaker.SpeakCompleted, AddressOf SpeachComplete

        ' speaker.Voice=
        ' ' speaker.Speak(Texto.Text)
        'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(person)
        'speaker.Voice = speaker.GetVoices(String.Empty, String.Empty).Item(person)

        speaker.Rate = speechRate
        speaker.Volume = volume


        For Each c In pEtapa.Controls

            If bandstop = True Then
                Exit Sub
            End If

Pregunta:
            If bandComplete = False Then

                bandComplete = True

                'nm = sender.Name
                nm = c.name

                str = nm.Split("_")
                ' str = nm.Split("_")
                tp = str(0)

                'Console.WriteLine(c.name)
                '  Console.WriteLine()
                '    'objtextCurr = pEtapa.Controls.Item("pAux" & nm).Controls.Item("txt" & nm)
                ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")

                objtextCurr = pEtapa.Controls(c.name).Controls.Item("txt" & str(1))
                objtextCurr.Font = New Font("Consolas", 11, FontStyle.Bold)

                'Dim speak As New SpeechSynthesizer
                'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(cmbVoices.SelectedIndex)
                Dim pic As PictureBox
                Dim person As Integer
                ' p.Name = "p_" & dt.Rows(i).Item(0)
                ' bmp = New Bitmap(p.Size.Width, p.Size.Height)

                'If dt.Rows(i).Item(5) = 1 Then
                'txtNombre.Image = 

                'p.Image = ImageList4.Images.Item(dt.Rows(i).Item(5))

                'person = p.Image = ImageList5.Images.Item(dt.Rows(i).Item(5))
                pic = pEtapa.Controls(c.name).Controls.Item("p_" & str(1))

                ' person = pic.Image
                'speech.WaitUntilDone(-1)


                ' If (paused) = True Then
                ' speech.Resume()
                'aused = False


                'Else

                ' paused = True
                'Console.WriteLine("antes " & speech.Status.InputWordPosition)



                LeerItem(objtextCurr, pic.Tag)


                ' Console.WriteLine("despues " & speech.Status.InputWordPosition)
                'Console.WriteLine("despues " & speech.Status.InputSentencePosition)

                'Bucle
                'Do While bandComplete = False
                '    Console.WriteLine("entro al bucle")
                'Loop

                ' End If




            Else

                'Exit Sub
                'Regresa a preguntar
                wait(1)
                GoTo Pregunta


            End If






        Next





    End Sub

    Private Sub LeerItem(item, person)
        Dim Voice As String = ""
        Dim _voice As String = ""
        Try

            Select Case person

                Case Is = 0, 1, 2, 4 'Man
                    _voice = 3
                Case Is = 3, 7, 8  'Woman
                    _voice = 2
                Case Is = 4, 5 'Melendez 'Andrews
                    _voice = 3
                Case Is = 9
                    _voice = 3

            End Select
            If (paused) = True Then
                ' speech.Resume()
                ' paused = False

            Else

                ' Dim pVoice As ISpVoice = CType(voice, ISpVoice)
                Dim otc As SpObjectTokenCategory = New SpObjectTokenCategory()
                otc.SetId("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices")

                Dim tokenEnum As ISpeechObjectTokens = otc.EnumerateTokens()
                Dim nTokenCount As Integer = tokenEnum.Count

                '  Console.WriteLine("Number of voices: {0}", nTokenCount)
                Dim n As UInteger = 0
                Dim pVoice As ISpVoice = CType(speech, ISpVoice)

                'For Each sot As ISpeechObjectToken In tokenEnum
                '    Console.WriteLine("Voice : {0}", sot.GetDescription())
                'Next

                ' pVoice.SetVoice(CType(sot, ISpObjectToken))
                pVoice.SetVoice(CType(tokenEnum(_voice), ISpObjectToken))
                ' pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))
                ' pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))
                ' speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(voice)
                ' speech.SetVoice(CType(tokenEnum(0), ISpObjectToken))

                ' AddHandler voice.EndStream, AddressOf speakComplete

                Try
                    pVoice.Speak(objtextCurr.Text, 0, n)

                Catch ex As Exception

                End Try


                'For Each v In speaker.GetInstalledVoices
                '    Console.WriteLine(v.VoiceInfo.Name)

                'Next

                '' paused = True
                'Select Case person

                '    Case 0, 1, 4
                '        Voice = "Microsoft Mark"


                '    Case 3, 7, 8  'Woman
                '        Voice = "Microsoft Zira"

                '    Case 2, 4, 5 'Melendez 'Andrews
                '        Voice = "Microsoft David Desktop"

                '    Case 9
                '        Voice = "Microsoft Hazel Desktop"
                'End Select

                'If Voice = "" Then
                '    Voice = "Microsoft Mark"
                'End If
                ''speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(person)

                ''speech.Rate = speechRate
                ''speech.Volume = volume
                ''speech.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

                'speaker.SelectVoice(Voice)
                '' speaker.Speak(item.text)
                'speaker.SpeakAsync(item.text)

                ' Synth_PhonemeReached(sender, e)
                '   Dim sentences As New List(Of String)()
                ' Dim start As Integer = 0
                ' Dim position As Integer
                'Console.WriteLine(speech.Status)


            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub
#End Region
#Region "todo lo demas"

    Private Sub SpeachComplete(sender As Object, e As SpeakCompletedEventArgs)

        objtextOver = objtextCurr


        If Not IsNothing(objtextOver) Then
            objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)

        End If

        bandComplete = False

    End Sub


    'Console.WriteLine(Len(Texto.Text))

    'Do While speech.Status.InputSentencePosition <= Len(Texto.Text)
    '    Dim sp1 As System.Speech.Synthesis.PromptEventArgs

    '    '  Console.WriteLine(speech.Status.InputSentencePosition)
    '    Console.WriteLine(sp1.Prompt.IsCompleted)
    'Loop


    ' SpeakCompletedEventArgs()






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

        lblmod.Text = "( " & lstModificaciones.Items.Count & " )"




    End Sub

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
 

    ''Private Sub cboCategory1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCategory1.SelectedIndexChanged
    ''    Dim param As String = ""
    ''    Dim i, n As Integer



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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer

        ' sqlstring = "select * from  SubTemas "
        '    conexion.Open()
        Console.WriteLine(cmbPersona.Text)
        Console.WriteLine(cmbPersona.SelectedIndex)

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


        If cmbPersona.Text = "" Then Exit Sub
        IdPerson = cmbPersona.SelectedIndex

        Try
            If lstOraciones.SelectedItems(0).Text = "" Then Exit Sub

        Catch ex As Exception
            Exit Sub
        End Try

        IdOracion = lstOraciones.SelectedItems(0).Text
        'Desc = lstOraciones.SelectedItems(0).Text

        sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
        sqlstring = sqlstring & " Values ('" & IdOracion & "', '0', '" & Id & "', '" & IdPerson & "')"

        '  _comando.Connection = conexion
        _comando.CommandText = sqlstring
        _comando.Connection.Open()




        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                'MsgBox("se guardo")

            Else
                MsgBox("No se guardo")
            End If

            CrearControles()



            '_comando.CommandText = sqlstring
            '_comando.Connection.Open()

            'da.SelectCommand = _comando

            'da.Fill(dt)

            '_comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        txtBuscar.Text = ""


        'If IdPerson = 1 Then
        '    cmbPersona.SelectedIndex = 2
        'Else
        '    cmbPersona.SelectedIndex = 1
        'End If
        ' RichTextBox1.LoadFile("C:\Legacy\Test.rtf")

    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim buscar As String
        Dim sqlstring As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        ' Dim da As New OleDbDataAdapter
        Dim i, n As Integer
        'Try
        ' conexion.Open()
        lstOraciones.Items.Clear()

        buscar = Trim(Me.txtBuscar.Text)
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

                lstOraciones.Items.Add(item)


            Catch ex As Exception

            End Try


            'Agrego el item a la colección de listViewItem's de ListView1

            i = i + 1

        Loop



    End Sub

    Private Sub lstOraciones_DoubleClick(sender As Object, e As System.EventArgs) Handles lstOraciones.DoubleClick

    End Sub

    Private Sub lstOraciones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstOraciones.SelectedIndexChanged
        'Id = lstOraciones.SelectedItems(0).Text

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim n As Integer
        Dim pos As Integer

        n = ListView1.Items.Count

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
        If ListView1.SelectedItems(0).Index = -1 Then Exit Sub

        indice = ListView1.SelectedItems(0).Index


        itemCurr = ListView1.SelectedItems(0)


        If indice = ListView1.Items.Count - 1 Then

            'ListView1.Items.Remove(itemCurr)

        Else

            If indice >= ListView1.Items.Count - 1 Then

                ListView1.Items.Remove(itemCurr)

            Else
                ListView1.Items.Remove(itemCurr)

                ListView1.Items.Insert(indice + 1, itemCurr)

            End If


        End If





    End Sub

    Private Sub CmdUp_Click(sender As System.Object, e As System.EventArgs) Handles CmdUp.Click
        Dim n As Integer
        Dim pos As Integer

        n = ListView1.Items.Count

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
        If ListView1.SelectedItems(0).Index = -1 Then Exit Sub

        indice = ListView1.SelectedItems(0).Index


        itemCurr = ListView1.SelectedItems(0)


        If indice = ListView1.Items.Count - 1 Then

            ListView1.Items.Remove(itemCurr)
            ListView1.Items.Insert(indice - 1, itemCurr)

        Else

            If indice = 0 Then

                ' ListView1.Items.Remove(itemCurr)

            Else
                ListView1.Items.Remove(itemCurr)

                ListView1.Items.Insert(indice - 1, itemCurr)

            End If


        End If

    End Sub

    Private Sub RichTextBoxEx1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        MsgBox("test")

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        Dim IdOracion As Integer


        ' sqlstring = "select * from  SubTemas "
        '    conexion.Open()
        If cmbPersona.Text = "" Then Exit Sub
        IdOracion = txtId.Text


        Dim frm As New frmNewConversation
        frm.IdOracion = IdOracion
        frm.IdPersona = cmbPersona.Text

        frm.ShowDialog()

        CrearControles()





    End Sub

    Private Sub cmbConversation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Dim frm As New FrmDetOracion


        ' Id = cmbConversation.Items(cmbConversation.SelectedIndex).ItemData()

        CrearControles()

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

            'Console.WriteLine(r.SubItems(1).Text)
            'Console.WriteLine(r.SubItems(3).Text)

            If r.SubItems(3).text = "Null" Then
                sqlstring = "UPDATE Oraciones SET " & r.SubItems(1).Text & " = Null"
                sqlstring = sqlstring & " WHERE Id = @Id"

            Else
                sqlstring = "UPDATE Oraciones SET " & r.SubItems(1).Text & " = @" & r.SubItems(1).Text
                sqlstring = sqlstring & " WHERE Id = @Id"

                'If r.subitems(1).text = "Enc_Fecha_Entrega" Then
                '    fechaEntrega = r.subitems(3).text
                '    _comando.Parameters.AddWithValue("@" & r.SubItems(1).Text, fechaEntrega)

                'Else
                '    _comando.Parameters.AddWithValue("@" & r.SubItems(1).Text, r.SubItems(3).Text)

                'End If

            End If



            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Id", IdOracion)
            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception

            End Try


        Next
        _comando.Connection.Close()


        'If i > 0 Then
        '    Return True
        'Else
        '    Return False

        'End If






    End Sub

    Private Sub txtTraduccion_TextChanged(sender As System.Object, e As System.EventArgs)
        'If Me.txtTraduccion.Text <> traduccion Then
        '    Try
        '        DetectChanges("Traduccion", traduccion, txtTraduccion.Text, "")
        '        traduccion = txtTraduccion.Text
        '    Catch ex As Exception

        '    End Try
        'End If
    End Sub

    Private Sub cmbPersona_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPersona.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim OracionEN As String
        Dim OracionES As String
        Dim SQL As String
        Dim IdOracion As Integer

        OracionEN = txtOracionEN.Text
        'OracionES = Texto.Text

        If cmbPersona.Text = "" Then Exit Sub


        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer


        sqlstring = "Insert into Oraciones (Oracion, TextoPlano, Traduccion)"
        sqlstring = sqlstring & " Values ('""', '" & OracionEN & "', '" & OracionES & "')"

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
        '_comando.Connection.Close()


        If i > 0 Then
            SQL = "SELECT @@IDENTITY FROM Oraciones"

            _comando = New SqlCommand(SQL, _comando.Connection)

            Dim value As Object = _comando.ExecuteScalar

            IdOracion = value.ToString
        End If
        _comando.Connection.Close()


        txtOracionEN.Text = ""
        ' Texto.Text = ""


        ' Me.Close()
        ' Me.Dispose()

        'Agrega a Conversacion
        ' Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        sqlstring = ""
        'Dim IdOracion As Integer
        'Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
        'Dim i As Integer
        Dim IdPerson As Integer

        ' sqlstring = "select * from  SubTemas "
        '    conexion.Open()
        Select Case cmbPersona.Text
            Case "Lisa"
                IdPerson = 1

            Case "Steve"
                IdPerson = 2

            Case "Maggie"
                IdPerson = 3

            Case "Marge"
                IdPerson = 4

            Case "Mark"
                IdPerson = 5

            Case "Homer"
                IdPerson = 6
            Case "Doctor"
                IdPerson = 9

        End Select


        Try
            'If lstOraciones.SelectedItems(0).Text = "" Then Exit Sub

        Catch ex As Exception
            'Exit Sub
        End Try

        'IdOracion = lstOraciones.SelectedItems(0).Text
        'Desc = lstOraciones.SelectedItems(0).Text

        sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
        sqlstring = sqlstring & " Values ('" & IdOracion & "', '0', '" & Id & "', '" & IdPerson & "')"

        '  _comando.Connection = conexion
        _comando.CommandText = sqlstring
        _comando.Connection.Open()




        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                'MsgBox("se guardo")

            Else
                MsgBox("No se guardo")
            End If

            CrearControles()



            '_comando.CommandText = sqlstring
            '_comando.Connection.Open()

            'da.SelectCommand = _comando

            'da.Fill(dt)

            '_comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        txtBuscar.Text = ""


    End Sub


    

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        'Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
        Dim i As Integer
        'Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        'Dim obj As New Label
        ' Dim resp As Nullable(Of Integer)
        'obj = sender
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        'obj = sender

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)

        'IdOracion = str(1)

        Dim speak As New SpeechSynthesizer
        speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(cmbVoices.SelectedIndex)

        If (paused) = True Then
            speech.Resume()
            paused = False

        Else
            'obj.Text = 


            speech.Rate = speechRate
            speech.Volume = volume


            ' Synth_PhonemeReached(sender, e)
            Dim sentences As New List(Of String)()
            Dim start As Integer = 0
            Dim position As Integer

            ' lblString.Text = "This is an example"
            'pEtapa.Controls.Item("pAux" & i).Controls("txtNombre_1")
            '    With pEtapa.Controls.Item("pAux" & q).Controls.Item("txtNombre_1" & q)
            With pEtapa.Controls.Item("pAux0").Controls.Item("text_1")
                ' If .BackColor = Color.Red Then
                '.BackColor = Color.Gray
                '' lblScore.Text = CInt(lblScore.Text) - 1
                '  End If
                ' .BackColor = Color.Green
                'If .BackColor = Color.Red Then
                ' lblScore.Text = CInt(lblScore.Text) - 1
                ' End If


            End With
            Dim objtext As TextBox
            objtext = pEtapa.Controls.Item("pAux0").Controls.Item("txt_")
            objtext.HideSelection = False

            ' For Each word As String In TextBox1.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
            'For Each word As String In pEtapa.Controls.Item("pAux0").Controls.Item("text_1").Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
            'For Each word As String In objtext.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
            'For Each word As String In lblString.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)


            '
            'Dim s As String = "This is the first sentence in a string. " &
            '          "More sentences will follow. For example, " &
            '          "this is the third sentence. This is the " &
            '          "fourth. And this is the fifth and final " &
            '          "sentence."



            ' Extract sentences from the string.
            'Do
            'If position >= 0 Then
            'sentences.Add(objtext.Text.Substring(start, position - start + 1).Trim())




            ' position = objtext.Text.IndexOf(word, start)

            'objtext.SelectionStart = position
            'objtext.SelectionLength = Len(word)
            'start = Len(word)

            Dim vectoraux() As String
            'vectoraux = TextBox1.Text.Split("<=,>=,>,<,+,-,/,*")
            vectoraux = objtext.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
            'Dim numBox As TextBox = CType(word, TextBox)
            '  numBox.SelectAll()
            ' numBox.Focus()
            For Each r In vectoraux
                'speech.Speak(r, SpeechVoiceSpeakFlags.SVSFDefault)

            Next

            ''''''''
            'sobra:
            'position = position + Len(word)
            '  i = i + 1
            'End If
            'Loop While position > 0
            'objtext.ForeColor = Color.Red
            'word.Select(0, Len(word))



            ' Console.WriteLine(word)
            'TextBox1.
            'speak.SpeakAsync(word)

            'Select Case word
            '    Case "run"
            '        'Code
            '    Case "ok"
            '        'Code
            'End Select
            'Next

            'speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFVoiceMask)
        End If
    End Sub

    Private Sub cmdAgregar_Click(sender As System.Object, e As System.EventArgs) Handles cmdAgregar.Click
        Dim frm As New frmTransferir

        AddOwnedForm(frm)

        frm.IdConversation = Id
        frm.Show()

    End Sub

    Private Sub pEtapa_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pEtapa.Paint

    End Sub



    Private Sub wait(ByVal seconds As Integer)
        For i As Integer = 0 To seconds * 100
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next


    End Sub

    Private Sub cmdStop_Click(sender As System.Object, e As System.EventArgs) Handles cmdStop.Click
        bandstop = True
    End Sub

    Private Sub SpeakCompletedEventArgs()
        MsgBox("Speach Done")

    End Sub



    Private Sub cboVoice_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub
#End Region


    Private Sub TrackBarVelocidad_Scroll(sender As System.Object, e As System.EventArgs) Handles TrackBarVelocidad.Scroll
        speechRate = TrackBarVelocidad.Value
        lblVelocidad.Text = TrackBarVelocidad.Value
        ' TrackBarVolumen.Value = volume
    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupo.SelectedIndexChanged
        Dim IdGrupo As Integer
        Dim sqlstring As String = ""

        If Me.cboGrupo.Text = "" Then Exit Sub
        ' If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub
        Try


            'If cboGrupo.SelectedItem = True Then
            IdGrupo = Me.cboGrupo.SelectedValue
            CrearControles()

            ' End If
        Catch ex As Exception

        End Try
      

        'filtro = "select  orden, STL, TextoPlano, Traduccion, Estatus, Oracion, Id, GrupoO from Oraciones "
        'filtro = filtro & " Where GrupoO= '" & IdGrupo & "'"
        'filtro = filtro & " Order By orden ASC"

        'CargarDatos(filtro)

    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Me.Close()

    End Sub

    Private Sub cmdOrdenar_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenar.Click
        Dim frm As New frmOrdenar
        Dim IdGrupo As Integer

        'If Me.cboGrupo.Text = "" Then Exit Sub
        'If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub

        IdGrupo = Me.cboGrupo.SelectedValue

        AddOwnedForm(frm)
        frm.IdGrupo = IdGrupo
        frm.Show()

        CargarDatos(filtro)

    End Sub

    Private Sub checkMostrarTexto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkMostrarTexto.CheckedChanged
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        If checkMostrarTexto.Text = "" Then Exit Sub

        If checkMostrarTexto.Text = "Mostrar" Then

            For Each c In pEtapa.Controls

                nm = c.name

                str = nm.Split("_")

                tp = str(0)

                pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Visible = True
                pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Refresh()
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Visible = True
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Refresh()

                pEtapa.Controls(c.name).Controls.Item("tst_" & str(1)).Visible = False
                pEtapa.Controls(c.name).Controls.Item("tst_" & str(1)).Refresh()





            Next

            checkMostrarTexto.Text = "Ocultar"
        Else

            For Each c In pEtapa.Controls

                nm = c.name

                str = nm.Split("_")

                tp = str(0)

                pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Visible = False
                pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Refresh()
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Visible = False
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Refresh()


                If pEtapa.Controls(c.name).Controls.Item("tst_" & str(1)).BackColor = Color.LightSalmon Then

                    pEtapa.Controls(c.name).Controls.Item("tst_" & str(1)).Visible = False
                    pEtapa.Controls(c.name).Controls.Item("tst_" & str(1)).Refresh()

                End If
            Next

            checkMostrarTexto.Text = "Mostrar"
        End If

    End Sub
End Class


 