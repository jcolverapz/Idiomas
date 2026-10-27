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
Imports AxWMPLib
Imports WMPLib
Public Class frmtest
    '  Dim pEtapa As Panel
    Private Sub frmtest_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'WebBrowser1.Document.BackColor = Color.White

        ' RichTextBoxEx1.Controls.Item("rtb").LoadFile = "C:\Legacy\Test.rtf"
        Dim test As Boolean

        '() 'Load("C:Legacy\Rtf\.rtf")
        '  Dim obj As New RichTextBoxEx.RichTextBoxEx

     
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
         
        ' RichTextBoxEx1.rtb.LoadFile("C:\Legacy\Rtf\" & Id & ".rtf")
        'CargarConversation(Id)
        ' CrearControles()

        ''Voces
        'For Each Token As ISpeechObjectToken In speech.GetVoices("", "")

        '    'Console.WriteLine(Token.GetDescription(49))
        '    cmbVoices.Items.Add(Token.GetDescription(49))

        '    cmbVoices.SelectedIndex = 0
        '    TrackBarVelocidad.Value = speechRate
        '    TrackBarVolumen.Value = volume
        'Next
        ''.Items.Add(toke
        wmp = New AxWindowsMediaPlayer
        ' 🔥 agregar primero
        Panel1.Controls.Add(wmp)
        wmp.CreateControl()

        wmp.windowlessVideo = False

        ' Evita repintados
        wmp.enableContextMenu = False

        'AxWindowsMediaPlayer1.SendToBack()

        wmp.uiMode = "none"
        wmp.settings.autoStart = False
        wmp.stretchToFit = True
        wmp.Size = New Size(300, 200)


        ' TextBox1.Text = " This is a example This"
        ' ToolStatus.Text = "Oracion"

    End Sub

     
        Public Id As Integer
        Public IdOracion As Integer

        Public instruccion As New OleDbCommand
        Public contenedor As String
        Public sqlstring As String
        Public MaxColumna As Integer
        Public Titulo As String
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

        
        Public paused As Boolean = False
        Public speech As SpVoice = New SpVoice()
    Public speechRate As Integer = 2 ' Rango desde -10 hasta 10 
    Public volume As Integer = 100 ' Rango desde 0 hasta 100.


        Public lstModificaciones As New ListView
     

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
                ' DatosTicket = CapaLogica.CatalogoTickets(param)

                _comando.Connection.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try

            ' n = dt.Rows.Count

            'Do While i <= n - 1
            '    Me.cmbConversation.Items.Add(New clsItem(dt.Rows(i).Item(7), dt.Rows(i).Item(8)))
            '    i = i + 1
            'Loop



        End Sub

        Public Sub CargarDatos(Id)
            Dim param As String = " WHERE Oraciones.Id=" & Id
            ' Dim param As String = " WHERE Tbl_RT_Enc.Enc_Id=" & 86
            ' Dim DatosTicket As DataTable
            Dim resp As Integer
            ' Dim Empleados As DataTable
            Dim i, n As Integer
            Dim IdOracion As Integer
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sql As String

            Dim dt As New DataTable
            Dim da As New SqlDataAdapter

            sqlstring = "select  * from  Oraciones "
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

            'DatosMantenimiento = CapaLogica.DatosEquiposMantenimiento(param)
            Dim carpeta As String = ""
            Dim filename As String = ""

            resp = dt.Rows.Count

            If resp = 0 Then Exit Sub

            IdOracion = dt.Rows(0).Item(0)

            txtId.Text = IdOracion

            '  descripcionCorta = dt.Rows(0).Item(1)

            ' WebBrowser1.DocumentText = descripcionCorta
            ' RichTextBox1.Text = descripcionCorta
            'RichTextBoxEx1.Controls.Item("rtb").Text = descripcionCorta
            ' RichTextBoxEx.RichTextBoxEx.rt(Id)


            If Not IsDBNull(dt.Rows(0).Item(1)) Then
                descripcionCorta = dt.Rows(0).Item(1)
            End If
            'txtDescripcion.Text = descripcionCorta
            ' WebBrowser1.DocumentText = descripcionCorta

        'RichTextBoxEx.RichTextBoxEx.filename = IdOracion

            ' RichTextBoxEx1.rtb.LoadFile("C:\Legacy\Rtf\" & Id & ".rtf")

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

                If Not IsDBNull(dt.Rows(0).Item(21)) Then
                    descripcion = dt.Rows(0).Item(21)
                End If
                '    RichTextBoxEx1.rtb.Text = descripcion
                ' Try to create the directory.
                'Dim di As DirectoryInfo = Directory.CreateDirectory(carpeta)
                'archivo = Dir(Adjunto)
                'IO.File.Copy(Adjunto, carpeta & archivo)

            End If

            If Not IsDBNull(dt.Rows(0).Item(4)) Then
            ' traduccion = dt.Rows(0).Item(4)
            End If
            '   txtTraduccion.Text = traduccion


            If Not IsDBNull(dt.Rows(0).Item(3)) Then
                estado = dt.Rows(0).Item(3)
            End If

            ' cboState.Text = estado

            '    'Hora de Termino
            'If Not IsDBNull(dt.Rows(0).Item(24)) Then
            '    HoraTermino = Format(dt.Rows(0).Item(24), "hh:mm")
            'End If

            '    'Fecha de Entrega
            'If Not IsDBNull(dt.Rows(0).Item(25)) Then
            '    fechaEntrega = dt.Rows(0).Item(25)
            '    dtpDuedate.Value = fechaEntrega
            'Else
            '    dtpDuedate.Value = Today
            'End If

            '    If dtpDuedate.Value < Today Then
            '        picAlerta.Visible = True
            '    Else
            '    End If

            '    'Usuario Asignado
            'If Not IsDBNull(dt.Rows(0).Item(11)) Then
            '    UsuarioAsignado = dt.Rows(0).Item(11)
            '    cboState.Enabled = True
            'End If
            '    cboEmpleados.Text = UsuarioAsignado


            'If Not IsDBNull(dt.Rows(0).Item(27)) Then
            '    Approval = dt.Rows(0).Item(27)
            'End If
            '    txtApproval.Text = Approval

            'If Not IsDBNull(dt.Rows(0).Item(29)) Then
            '    Tipo = dt.Rows(0).Item(29)
            'End If
            '    'Prioridad

            '    If Not IsDBNull(DatosTicket.Rows(0).Item(8)) Then
            '        Prioridad = DatosTicket.Rows(0).Item(8)
            '    End If
            '    cboPriority.Text = Prioridad

            '    If Not IsDBNull(DatosTicket.Rows(0).Item(15)) Then
            '        ' DatosTicket.Rows(0).Item(15)
            '    End If

            'If Not IsDBNull(DatosTicket.Rows(0).Item(16)) Then
            '    'UsuarioAsignado = DatosTicket.Rows(0).Item(16)
            'End If
            'If Not IsDBNull(DatosTicket.Rows(0).Item(17)) Then
            '    'descripcion = DatosTicket.Rows(0).Item(13)
            'End If
            ''txtDescripcion.Text = descripcion

            'If Not IsDBNull(DatosTicket.Rows(0).Item(18)) Then
            '    ' estadoCerrado = DatosTicket.Rows(0).Item(18)
            'End If

            'If Not IsDBNull(DatosTicket.Rows(0).Item(30)) Then
            '    UsuarioCorreo = DatosTicket.Rows(0).Item(30)
            'End If
            'txtCorreo.Text = UsuarioCorreo

            'If Not IsDBNull(DatosTicket.Rows(0).Item(20)) Then
            '    Categoria1 = DatosTicket.Rows(0).Item(20)
            'End If
            'cboCategory1.Text = Categoria1

            'If Not IsDBNull(DatosTicket.Rows(0).Item(22)) Then
            '    Categoria2 = DatosTicket.Rows(0).Item(22)
            '    CmdGuardar.Enabled = True
            'End If
            'cboCategory2.Text = Categoria2

            'If Not IsDBNull(DatosTicket.Rows(0).Item(10)) Then
            '    Area = DatosTicket.Rows(0).Item(10)
            'End If
            'cboUbicacion.Text = Area

            'If Not IsDBNull(DatosTicket.Rows(0).Item(2)) Then
            '    Departamento = DatosTicket.Rows(0).Item(2)
            'End If
            'txtDepartamento.Text = Departamento

            'If Not IsDBNull(DatosTicket.Rows(0).Item(29)) Then

            '    If DatosTicket.Rows(0).Item(29) = "INC" Then
            '        TipoTicket = "INCIDENTE"
            '    Else
            '        TipoTicket = "REQUERIMIENTO"

            '    End If
            'End If

            'If Not IsDBNull(DatosTicket.Rows(0).Item(31)) Then

            '    TotalTime = DatosTicket.Rows(0).Item(31)
            'Else
            '    TotalTime = New TimeSpan(0, 0, 0)
            'End If

            'If TotalTime.Hours = 0 Then
            '    txtTime.Text = TotalTime.Minutes & " minutes"
            'Else
            '    txtTime.Text = TotalTime.Hours & " hours and " & TotalTime.Minutes & " minutes"
            'End If

            'If Not IsDBNull(DatosTicket.Rows(0).Item(32)) Then
            '    ArchivoAdjunto = DatosTicket.Rows(0).Item(32)
            'End If

        End Sub
        Public Sub CrearControles()
            Dim pAux As Panel
        Dim txtNombre As TextBox
            Dim txtFecha As Label
            Dim txtMinutos As Label
            Dim btnSolution As Button
            Dim btnUp As Button
            Dim btnDown As Button
            Dim btnDelete As Button

            Dim btnTask As Button
            Dim btnLeer As Button
            Dim txtParam As Label
            Dim btnAuxNo As Label

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


            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String = ""

        sqlstring = " SELECT    Top 5     Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Oraciones.TextoPlano, Det_Person, Det_Par, Oraciones.traduccion"
            sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
            sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
            sqlstring = sqlstring & " WHERE  Det_Conversation.Con_Id='" & Id & "'"
            sqlstring = sqlstring & " ORDER BY  Det_Conversation.Det_Orden ASC"

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



            n = dt.Rows.Count
            yPos = 10

            i = 0

        pEtapa.Controls.Clear()

            ListView1.Items.Clear()


            Dim List As New List(Of String)

        ' pEtapa.AutoScroll = True

            Dim person1 As Integer
            Dim person2 As Integer

            Dim p As PictureBox
            Dim bmp As Bitmap
            Dim g As Graphics

        For i = 0 To 2 - 1


            pAux = New Panel
            pAux.Name = "pAux" & i

            pAux.Height = 50
            pAux.Width = 900
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


            '  var.Usuarioiniciales = Mid(dt.Rows(i).Item(5), 1, 1) & Mid(dt.Rows(i).Item(6), 1, 1)

            'Nombre

            txtNombre = New TextBox
            txtNombre.Name = "text_1"
            txtNombre.Text = "This is an example" '& " " & dt.Rows(i).Item(1) '& vbCrLf & vbCrLf & dt.Rows(i).Item(3)
            txtNombre.BorderStyle = BorderStyle.None
            txtNombre.Font = New System.Drawing.Font("Arial", 11, FontStyle.Regular)
            'txtNombre.ForeColor = Color.DimGray
            txtNombre.AutoSize = True
            txtNombre.Width = 200
            txtNombre.Location = New Point(45, 5)
            '   txtNombre.BackColor = Color.LightGray
            txtNombre.Height = txtNombre.PreferredHeight
            AddHandler txtNombre.Click, AddressOf RefreshTexto

            pEtapa.Controls.Item("pAux" & i).Controls.Add(txtNombre)


            ' txtNombre.MaximumSize = New Size(txtNombre.Width, 0)
            ' txtNombre.TextAlign = ContentAlignment.MiddleLeft

            ' pEtapa.Controls.Item("pAux" & i).Controls.Add(txtNombre)

            


            'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
            'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
            'AddHandler btnTask.Click, AddressOf Editar

            'pEtapa.Controls.Item("pAux" & i).Controls.Add(btnTask)

            btnUp = New Button
            ' btnUp.Name = "btnUp_" & dt.Rows(i).Item(6)
            btnUp.Name = "btnUp_" & i
            btnUp.Width = 52 : btnUp.Height = 19 ': btnTask.Text = "Report"
            btnUp.Location = New Point(txtNombre.Left - 55, 1)
            btnUp.Text = "UP"
            ' btnUp.TextImageRelation = TextImageRelation.ImageAboveText
            ' AddHandler btnUp.Click, Sub() MoveUp(i)
            AddHandler btnUp.Click, AddressOf MoveUp
            pEtapa.Controls.Item("pAux" & i).Controls.Add(btnUp)

            'btnDown = New Button
            '' btnDown.Name = "btnDown_" & dt.Rows(i).Item(1)
            'btnDown.Name = "btnDown_" & i
            'btnDown.Width = 52 : btnDown.Height = 19 ': btnTask.Text = "Report"
            'btnDown.Location = New Point(btnDelete.Left - 55, btnDown.Bottom + 1)
            '' btnDown.Image = ImageList3.Images.Item(1)
            'btnDown.Text = "DOWN"

            ''btnDown.TextImageRelation = TextImageRelation.ImageAboveText
            ''AddHandler btnDown.Click, Sub() MoveDown(i)
            'AddHandler btnDown.Click, AddressOf MoveDown

            'pEtapa.Controls.Item("pAux" & i).Controls.Add(btnDown)


            'Leer
            'btnLeer = New Button
            'btnLeer.Name = dt.Rows(i).Item(0)
            'btnLeer.Width = 25 : btnLeer.Height = 25 ': btnTask.Text = "Report"
            'btnLeer.Location = New Point(btnUp.Left - 30, 1)
            ''btnLeer.Text = "L"
            'btnLeer.Image = ImageList1.Images.Item(0)

            ''btnDown.TextImageRelation = TextImageRelation.ImageAboveText
            ''AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
            'AddHandler btnLeer.Click, AddressOf LeerTexto
            'Try
            '    pEtapa.Controls.Item("pAux" & i).Controls.Add(btnLeer)

            'Catch ex As Exception

            'End Try

            'p = New PictureBox
            'p.Name = "p_" & dt.Rows(i).Item(0)
            '' bmp = New Bitmap(p.Size.Width, p.Size.Height)

            ''If dt.Rows(i).Item(5) = 1 Then
            ''txtNombre.Image = 

            ''p.Image = ImageList4.Images.Item(dt.Rows(i).Item(5))
            'Try
            '    p.Image = ImageList5.Images.Item(dt.Rows(i).Item(5))
            '    'bmp = New Bitmap(p.Size.Width, p.Size.Height)
            '    'p.Image = bmp
            '    p.Location = New Point(2, 1)
            '    AddHandler p.Click, AddressOf SeleccionarPersona

            '    pEtapa.Controls.Item("pAux" & i).Controls.Add(p)

            'Catch ex As Exception

            'End Try
            'person1 = person1 + 1
            ' Else
            ' p.Image = ImageList4.Images.Item(2)

            ' End If



            'Dim item As ListViewItem 'Creo el ListViewItem (item) 


            'item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            'item.UseItemStyleForSubItems = False
            ''item.Text = i
            'Try
            '    'item.SubItems.Add(dt.Rows(i).Item(0))
            '    'item.SubItems.Add(dt.Rows(i).Item(1))
            '    item.SubItems.Add(dt.Rows(i).Item(4))
            '    item.SubItems.Add(dt.Rows(i).Item(0))

            '    'item.SubItems(0).ForeColor = Color.Blue

            '    ListView1.Items.Add(item)
            '    ' ListBox1.Items.Add(item)


            'Catch ex As Exception

            'End Try








            'Parametro

            'txtParam = New Label
            ''   txtParam.Text = dt.Rows(i).Item(3) '& " " & dt.Rows(i).Item(6) & vbCrLf & vbCrLf & dt.Rows(i).Item(3)
            'txtParam.Text = dt.Rows(i).Item(3) '& " " & dt.Rows(i).Item(6) & vbCrLf & vbCrLf & dt.Rows(i).Item(3)
            '' txtParam.Text = lorem
            'txtParam.BorderStyle = BorderStyle.None
            'txtParam.Font = New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            ''txtParam.Width = 750

            'txtParam.ForeColor = Color.Black
            ''  txtParam.BackColor = Color.LightCoral
            ''  txtParam.Width = 150
            'txtParam.Location = New Point(45, txtNombre.Bottom + 10)
            'txtParam.MaximumSize = New Size(750, 100)
            'txtParam.AutoSize = True

            '' txtParam.Height = txtNombre.PreferredHeight

            'pEtapa.Controls.Item("pAux" & i).Controls.Add(txtParam)

            'x.MaximumSize = New Size(0, 0)
            ' pAux.Size = New System.Drawing.Size(100 + lblAux.Width, lblAux.Height + 100)
            '   pEtapa.Controls.Item("pAux" & i).Controls.Add(lblAux)




            ''End If


            ''New Report


            'If dt.Rows(i).Item(2) = "Report" Then







            'If Not IsDBNull(dt.Rows(i).Item(12)) Then
            '    If dt.Rows(i).Item(12) = "S" Then
            '        'New Report

            '        btnAdjunto = New Button
            '        btnAdjunto.Name = "btnAdjunto" & dt.Rows(i).Item(1)

            '        btnAdjunto.Width = 35 : btnAdjunto.Height = 35 ': btnTask.Text = "Report"
            '        ' btnTask.Font = New System.Drawing.Font("arial", 7)
            '        ' btnTask.TextAlign = ContentAlignment.BottomCenter
            '        ''btnSolution.Location = New Point(300, 0)
            '        btnAdjunto.Location = New Point(pAux.Right - txtFecha.Width - 100, 1)
            '        btnAdjunto.Image = ImageList2.Images.Item(14)
            '        ' btnAdjunto.Image = ImageList3.Images.Item(6)

            '        btnAdjunto.TextImageRelation = TextImageRelation.ImageAboveText
            '        ' AddHandler btnAdjunto.Click, Sub() Adjunto(HisId)

            '        pEtapa.Controls.Item("pAux" & i).Controls.Add(btnAdjunto)

            '    End If
            'End If

            'Iniciales
            'p = New PictureBox
            'bmp = New Bitmap(p.Size.Width, p.Size.Height)
            'p.Image = bmp

            ''circulos
            'Dim arrayColor() As Brush = {Brushes.LightCoral, avatar1, avatar2, avatar3, Brushes.LightCoral, Brushes.LightBlue, Brushes.Gainsboro}
            'Dim arrayColorPen() As Brush = {Brushes.Black, LblAvatar1, LblAvatar2, LblAvatar3, Brushes.Black, Brushes.Black, Brushes.Black}

            'g = Graphics.FromImage(p.Image)
            'g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            'Dim stringFormat As New StringFormat()
            'stringFormat.Alignment = StringAlignment.Center
            'stringFormat.LineAlignment = StringAlignment.Center

            'Dim rect1 As New Rectangle(5, 15, 35, 35)

            '' g.FillEllipse(arrayColor(c), rect1)

            'Dim myrect As New RectangleF(5, 15, 20, 20)
            ''  g.DrawString("AB", New Font("Segoe UI", 10, FontStyle.Bold), arrayColorPen(c), rect1, stringFormat)


            'pEtapa.Controls.Item("pAux" & i).Controls.Add(p)

            yPos = yPos + 80

        Next i

            ' pEtapa.Controls.Add(pAux)
            ' pEtapa.Controls.Add(Controls.Item("pAux" & i))
            ' pEtapa.Controls.Add(Me.Panel2, 2, 0)
            'var.Usuarioiniciales = Mid(dt.Rows(i).Item(12), 1, 1) & Mid(dt.Rows(i).Item(14), 1, 1)



            'imagen
            'Dim p As PictureBox
            'p = New PictureBox
            'p.Size = New Point(20, 20)
            'p.Location = New Point(10, 10)
            'p.SizeMode = PictureBoxSizeMode.StretchImage
            ' ''  p.Image = Image.FromFile("C:\legacy\iconos\Q-" & Trim(dt.Rows(i).Item(0)) & ".jpg")
            ''If dt.Rows(i).Item(11) = "M" Then
            'p.Image = ImageList1.Images.Item(0)
            'Else
            '    p.Image = ImageList1.Images.Item(1)
            'End If



            '  pEtapa.Controls.Item("pAux" & i).Controls.Add(p)

            'circulo
            'Dim c As Graphics
            'Dim papel As Graphics
            'papel = Me.CreateGraphics
            'papel.DrawEllipse(Lapiz, 30, 50, 50, 50)
            'papel = p
            'Me.Controls.Item("pAux" & i).Controls.Add(p)
            'Controls.Item("pAux" & i).Controls.Add(p)



            'roundCorners(p)
            '  pEtapa.Controls.Item("pAux" & i).Controls.Add(p)
            'pEtapa.AutoScroll = True

            ' pEtapa.Controls.Item("pAux" & i).Controls.Add(p)
            ' pEtapa.Controls.Item("pAux" & i).Controls.Add(p)

            ' txtFecha.Name = "btnYes_" & i
            ' txtFecha.BackColor = Color.White
            'txtFecha.BackColor = Color.LightBlue
            ' txtFecha.TextAlign = ContentAlignment.MiddleRight
            ' txtFecha.Location = New Point(lblAux.Right, lblAux.Top)


            ' pEtapa.Controls.Item("pAux0" & i).Controls.Add(lblAux)
            'pEtapa.Controls.Item("pAux0" & i).Controls.Add(lblAux)

            'param
            '  Dim lorem As String
            ' lorem = "Ni tampoco hay nadie que ame, persiga y quiera alcanzar el dolor mismo porque sea dolor, sino porque a veces se dan las circunstancias de tal manera, que con esfuerzo y dolor puede obtenerse algún "



            'pEtapa.Controls.Add(txtFecha, 1, i)
            ' txtFecha.Width = 300 : txtAuxYes.Height = 200
            'txtAuxYes.Font = New System.Drawing.Font("Arial", 9)
            'txtAuxYes.ForeColor = Color.DarkSlateGray
            'txtAuxYes.Location = New Point(pAux.Bounds.Right, lblAux.Height)
            'txtAuxYes.Dock = DockStyle.Right
            ' txtFecha.Location = New Point(pAux.Right - 320, 15)
            '   txtAuxYes.Location = New Point(txtAuxYes.Location., txtAuxYes.Location.Y + 10)
            ' lblAuxYes.Text = dt.Rows(i).Item(8) '& " " & dt.Rows(i).Item(8)
            '  txtAuxYes.WordWrap = True
            '   txtAuxYes.TextAlign = HorizontalAlignment.Right
            ' pEtapa.Controls.Item("pAux" & i).Controls.Add(txtFecha)
            'pEtapa.Controls.Item("pAux" & i).Controls.Add(p)
            '   pEtapa.Controls.Item("pAux" & i).Controls.Add(txtAuxYes)

            '  pEtapa.Controls.Item("pAux" & i).Controls.Add(btnAuxNo)

            'pAux.AutoSize = True
            '  roundCorners(pEtapa.Controls.Item("pAux" & i))
            'circulos


            ' font1.Dispose()
            ' Catch ex As Exception

            ' End Try

            ' yPos = yPos + pAux.Height + 10

            ' panel1.Invalidate();
            'pEtapa.Invalidate()

            'pEtapa.Height = pEtapa.Height + 10
            'pAux.Size = New System.Drawing.Size(500, 20)
            'pAux.AutoScroll = True
            'pAux.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly
            ' If i = 0 Then
            'pAux.Height = 120
            ' pAux.Width = 800
            ' Else
            'c = index


            '  Console.WriteLine(c)


            'paux1 = New Rectangle
            '  paux1.Height = 80
            ' paux1.Width = 800
            '
            '   paux1.Size = New System.Drawing.Size(500, 20)

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
            ' Dim resp As Nullable(Of Integer)
            ' obj = sender

            nm = sender.Name

            str = nm.Split("_")

            tp = str(0)

            IdOracion = str(1)

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
            frm.IdOracion = IdOracion
            frm.CargarDatos(IdOracion)
            frm.ShowDialog()

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
            'AddOwnedForm(frm)
            obj = sender

            ' Console.WriteLine(obj.Image)

            IdPerson = cmbPersona.SelectedIndex

            ' resp = MsgBox("Confirmar?", MsgBoxStyle.YesNo)

            'If resp = 6 Then

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
        Private Sub LeerTexto(sender, e)

           
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
            '  If lstOraciones.SelectedItems(0).Text = "" Then Exit Sub

            Catch ex As Exception
                Exit Sub
            End Try

        '  IdOracion = lstOraciones.SelectedItems(0).Text
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
        ' lstOraciones.Items.Clear()

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

                '  lstOraciones.Items.Add(item)


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
            OracionES = txtOracionES.Text

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
            txtOracionES.Text = ""


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

    Private Sub pEtapa_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs)

    End Sub

        Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

        End Sub


    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
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
            objtext = pEtapa.Controls.Item("pAux0").Controls.Item("text_1")
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
            'vectoraux = TextBox1.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
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
    Private Shared Sub Synth_PhonemeReached(sender As Object, e As PhonemeReachedEventArgs)
        Dim sym As Integer = AscW(e.Phoneme(0))
    End Sub



    Private Sub TextBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        ' TextBox1.SelectionStart = 0
        ' TextBox1.SelectionLength = Len(TextBox1.Text)}



    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As System.EventArgs)


        'when control receives the focus, set the back color to color of choice
        'TextBox1.BackColor = Color.Yellow '[vb(color of your choice) OR hex value for color]
        'set the value of the text box to 1
        'TextBox1.Text = "1"

        'TextBox1.SelStart = 0

        '.SelLength = 1000


        'Sub Text1_GotFocus ()
        ' TextBox1.SelectionStart = 0          ' Start selection at beginning.
        '  TextBox1.SelectionLength = Len(TextBox1.Text)  ' Length of text in Text1.
        '  TextBox1.SelectionLength = TextBox1.Text.Length
        ' Length of text in Text1.
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        'TextBox1.SelectionLength = 0
    End Sub

    Private Sub Button6_GotFocus(sender As Object, e As System.EventArgs) Handles Button6.GotFocus

       

        'Dim rbt As New RichTextBox
        'rbt.selection()
        'TextBox1.SelectionBackColor = Color.White
        'CodeCS.Find(ToolStripTextBox1.Text, RichTextBoxFinds.MatchCase)
        'CodeCS.SelectionBackColor = Color.Yellow
    End Sub
    
    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs)
        ' TextBox1.SelectionStart = 0          ' Start selection at beginning.
        ' TextBox1.SelectionLength = Len(TextBox1.Text)  ' L

    End Sub

   
End Class