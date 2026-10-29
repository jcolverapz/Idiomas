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
Imports System
Imports System.Media
Imports System.Windows.Forms

Public Class FrmConversation
#Region "variables"
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
     

    Dim Aprendidos As Integer

     
    Public traduccion As String = ""

    Public bandTimeValue As Boolean
    Public bandEstado As Boolean

    'Variables
    Public Id As Integer
    Public IdOracion As Integer
    Public paused As Boolean = False

    Public speechRate As Integer = -1 ' Rango desde -10 hasta 10 
    Public volume As Integer = 80 ' Rango desde 0 hasta 100.

    Dim objtextCurrent As RichTextBox
    Dim objtextOver As RichTextBox
    Dim objtextCurrentES As Label
    Dim objtextOverES As Label

    Dim IdCurrent As Integer
    Dim IdOver As Integer
    Dim pnlCurrent As String
    Dim pnlOver As String
    Dim n As Integer

    Public bandComplete As Boolean

    Public lstModificaciones As New ListView
    'Dim speech As New SpVoice '= New SpVoice()

    Dim speaker As New SpeechSynthesizer()
    ' Public Event SpeakCompleted As EventHandler(Of SpeakCompletedEventArgs)
    Public handler As EventHandler(Of SpeakCompletedEventArgs)
    ' Public handler2 As EventHandler(Of spee)
    'Private WithEvents speech As New SpVoice
    ' Dim voice As SpVoice = New SpVoice()
    Private WithEvents speech As New SpVoice
    Public Event SpeakCompleted As EventHandler(Of SpeakCompletedEventArgs)

#End Region
    Private Player As New SoundPlayer
    Private Player2 As New SoundPlayer
    Dim pVoice As ISpVoice = CType(speech, ISpVoice)

    Private Sub voice_EndStream(StreamNumber As Integer, StreamPosition As Object) Handles speech.EndStream
        ' This event fires when an asynchronous speech stream has completed.
        'MessageBox.Show("Asynchronous speech completed.")

        ' objtextCurrent.BackColor = Color.Beige
        Try
            objtextCurrent.SelectAll()
            objtextCurrent.SelectionBackColor = Color.Beige

            objtextOver = objtextCurrent
            IdOver = IdCurrent
            pnlOver = pnlCurrent

            If Not IsNothing(objtextOver) Then
                'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
                objtextOver.BackColor = Color.Beige

            End If
        Catch ex As Exception

        End Try
       

        bandComplete = False

    End Sub
    'Private Sub SpeakButton_Click(sender As Object, e As EventArgs) Handles SpeakButton.Click
    '    synth.SpeakAsync(RichTextBox1.Text)
    'End Sub
    'Private Sub voice_Stream(StreamNumber As Integer, StreamPosition As Object) Handles speech.
    '    ' This event fires when an asynchronous speech stream has completed.
    '    'MessageBox.Show("Asynchronous speech completed.")
    '    objtextOver = objtextCurrent


    '    If Not IsNothing(objtextOver) Then
    '        'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
    '        objtextOver.BackColor = Color.Beige

    '    End If

    '    bandComplete = False

    'End Sub
    'If Player.playState = WMPLib.WMPPlayState.wmppsPlaying Then
    '    'Dim currentPosition As Double = Player.Ctlcontrols.currentPosition
    '    Dim currentPosition As Double = Player.controls.currentPosition

    '    ' Update text based on currentPosition as in the CurrentPositionChange example
    '    ' Assuming you have a RichTextBox named RichTextBox1
    '    ' Select the text you want to highlight
    '    Console.WriteLine("Current Position " & currentPosition)
    '    'RichTextBox1.Select(startIndex, length)
    '    RichTextBox1.Select(currentPosition, 10)

    '    ' Set the background color for the selected text
    '    RichTextBox1.SelectionBackColor = Color.Yellow
    'End If

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

    Private Sub FrmConversation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'WebBrowser1.Document.BackColor = Color.White

        ' RichTextBoxEx1.Controls.Item("rtb").LoadFile = "C:\Legacy\Test.rtf"
        Dim test As Boolean

        '() 'Load("C:Legacy\Rtf\.rtf")
        ' Dim obj As New RichTextBoxEx.RichTextBoxEx

        ' obj.Controls.Item("rtb").Focus()

        ToolStatus.Text = "Oracion"

        checkMostrarTextoES.Text = "Mostrar Texto ES"

        lblVelocidad.Text = TrackBarVelocidad.Value

        LblId.Text = Id

        cmbPersona.SelectedIndex = 2

        'cargarDatos()
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = "select * from  Grupos_oracion "
        sqlstring = sqlstring & " ORDER By orden ASC"

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

        cboGrupo.Items.Clear()

        Dim i As Integer
        Dim n As Integer
        n = dt.Rows.Count

        cboGrupo.Items.Add("ALL")

        Do While i <= n - 1
            Me.cboGrupo.Items.Add(New clsItem(Trim(dt.Rows(i).Item(1)), dt.Rows(i).Item(0)))
            i = i + 1
        Loop


        If Id = 0 Then Exit Sub

        CrearControles()

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



        ' RichTextBoxEx1.rtb.LoadFile("C:\Legacy\Rtf\" & Id & ".rtf")
        CargarConversation(Id)


        Dim synth As New SpeechSynthesizer()
        ' Dim installedVoices As ReadOnlyCollection(Of InstalledVoice)
        ' Dim installedVoices As ReadOnlyCollection(Of InstalledVoice)

        ' Iterate through the collection and display voice information
        ' 'For Each voice As InstalledVoice In installedVoices
        ' If voice.Enabled Then ' Only show enabled voices
        'Console.WriteLine($"Voice Name: {voice.VoiceInfo.Name}")
        'Console.WriteLine($"Culture: {voice.VoiceInfo.Culture.DisplayName}")
        'Console.WriteLine($"Gender: {voice.VoiceInfo.Gender}")
        'Console.WriteLine($"Age: {voice.VoiceInfo.Age}")
        '   Console.WriteLine("--------------------")
        'End If
        ' Next
        For Each voice As InstalledVoice In synth.GetInstalledVoices()
            Dim info As VoiceInfo = voice.VoiceInfo
            Console.WriteLine(voice.VoiceInfo)

        Next
        ''Voces
        'For Each Token As ISpeechObjectToken In speech.GetVoices("", "")

        '    Console.WriteLine(Token.GetDescription(49))
        '    cmbVoices.Items.Add(Token.GetDescription(49))

        '    cmbVoices.SelectedIndex = 0
        '    TrackBarVelocidad.Value = speechRate
        '    TrackBarVolumen.Value = volume
        'Next


        

       



    End Sub

    Public Sub CargarConversation(Id)
        Dim param As String
        Dim resp As Integer

        Dim i, n As Integer
        Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        If Id > 0 Then
            param = " WHERE Enc_Conversation.Con_Id='" & Id & "'"
        Else
            Exit Sub
        End If

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

#End Region
#Region "Controles"
    Public Sub CrearControles()
        Dim pAux As Panel
        Dim txtNombre As RichTextBox
        Dim txtCuenta As Label
        Dim txtFecha As Label
        Dim txtTraduccion As Label
        Dim btnSolution As Button
        Dim btnUp As Button
        Dim btnDown As Button
        Dim btnDelete As Button
        Dim btnHide As Button
        Dim btnTask As Button
        Dim btnAprendido As Button
        Dim btnFalta As Button
        Dim btnExam As Button

        Dim btnLeer As Button
        Dim txtParam As Label
        Dim btnAuxNo As Label
        Dim txtTest As TextBox
        Dim txtTestES As TextBox

        Dim yPos As Integer
        Dim lblY As Integer

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim criterio As String
        Dim DatosTickets As DataTable
        Dim param As String = ""
        Dim i As Integer
        Dim ticketId, ticketTipo As String

        Dim usuarios As List(Of String)
        Dim fechas As List(Of String)
        Dim Comentarios As List(Of String)
        Dim parametros As List(Of String)


        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String = ""

        sqlstring = " SELECT   Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, o.TextoPlano, Det_Person, Det_Par, o.traduccion, o.STL, o.Exam, Det_Conversation.Det_Tipo"
        sqlstring = sqlstring & "  ,o.foco, o.CuentaSTL"
        sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"

        If ModVar.Idioma = "EN" Then
            sqlstring = sqlstring & "              Oraciones o ON Det_Conversation.Det_OracionId = o.Id"
        Else
            sqlstring = sqlstring & "              Oraciones_FR o ON Det_Conversation.Det_OracionId = o.Id"
        End If
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

        End Try

        n = dt.Rows.Count
        If n = 0 Then
            MsgBox("No hay datos", MsgBoxStyle.Information)
            Exit Sub
        End If
        yPos = 10

        If n = 0 Then
            GuardarAvance(0, 0)
            Exit Sub
        End If

        i = 0

        pEtapa.Controls.Clear()

        ListView1.Items.Clear()
        Dim item As ListViewItem 'Creo el ListViewItem (item) 


        Dim List As New List(Of String)

        pEtapa.AutoScroll = True

        Dim person1 As Integer
        Dim person2 As Integer

        Dim p As PictureBox
        Dim bmp As Bitmap
        Dim g As Graphics
        Dim nm As String
        Dim myPen As Pen

        Dim pb As PictureBox
        Dim pbf As PictureBox

        Dim startPoint As Point
        Dim endPoint As Point ' La línea es horizontal si la coordenada Y es la misma
        ' Puntos para la punta de la flecha (triángulo)
       
        For i = 0 To n - 1

            Try

                nm = dt.Rows(i).Item(0)

                pAux = New Panel
                pAux.Name = "pAux_" & nm
              
                pAux.Height = 90
                pAux.Width = 1200
                'pAux.AutoSize = True
                'pAux.Size = New System.Drawing.Size(pAux.Width, 0)
                pAux.Location = New Point(0, yPos)
                pAux.BackColor = Color.Beige
                ' pAux.BorderStyle = BorderStyle.FixedSingle
                pAux.BorderStyle = BorderStyle.Fixed3D
                 
                Try
                    pEtapa.Controls.Add(pAux)

                Catch ex As Exception
                End Try

                ' AddHandler pAux.Paint, AddressOf MyPanel_Paint
                'If IdOver > 0 Then
                '    g = pEtapa.Controls(pAux).CreateGraphics
                '    g.DrawRectangle(myPenClear, 0, 0, 40, 40)
                'End If

               

                'Leer
                btnLeer = New Button
                btnLeer.Name = dt.Rows(i).Item(0)
                btnLeer.Width = 25 : btnLeer.Height = 25 ': btnTask.Text = "Report"
                btnLeer.Location = New Point(45, 2)
                btnLeer.Image = ImageList1.Images.Item(0)
                btnLeer.Cursor = Cursors.Hand
                'btnLeer.Visible = False
                'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
                'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
                AddHandler btnLeer.Click, AddressOf LeerTexto
                ' AddHandler btnLeer.Click, AddressOf CambiarColor
                Try
                    pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnLeer)
                Catch ex As Exception
                End Try

               
                'Show / Hide
                btnHide = New Button
                btnHide.Name = "btnHide_" & dt.Rows(i).Item(0)
                btnHide.Width = 25 : btnHide.Height = 25 ': btnTask.Text = "Report"
                btnHide.Location = New Point(45, btnLeer.Bottom + 0.5)
                ' btnDown.Image = ImageList3.Images.Item(1)
                btnHide.Text = " ? "
                btnHide.Cursor = Cursors.Hand

                'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
                'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
                AddHandler btnHide.Click, AddressOf Show

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnHide)

                'Aprendido
                btnAprendido = New Button
                btnAprendido.Name = "btnAprendido_" & dt.Rows(i).Item(0)
                btnAprendido.Width = 35 : btnAprendido.Height = 25
                btnAprendido.Location = New Point(btnLeer.Right + 1, 1)
                btnAprendido.Cursor = Cursors.Hand
                btnAprendido.Text = "SI"
                btnAprendido.BackColor = Color.LightGreen
                Dim STL As Boolean
                If dt.Rows(i).Item(12) <= 0 Then
                    myPen = New Pen(Color.LightSalmon, 1)
                    STL = False
                Else
                    ' btnAprendido.Text = "SI"
                    ' btnAprendido.BackColor = Color.LightGreen
                    myPen = New Pen(Color.LightGreen, 1)
                    STL = True
                    Aprendidos += 1
                End If

                AddHandler btnAprendido.Click, AddressOf StatusControl

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnAprendido)
                'Falta
                btnFalta = New Button
                btnFalta.Name = "btnFalta_" & dt.Rows(i).Item(0)
                btnFalta.Width = 35 : btnFalta.Height = 25
                btnFalta.Location = New Point(btnLeer.Right + 1, btnAprendido.Bottom + 1)
                btnFalta.Cursor = Cursors.Hand
                btnFalta.Text = "X"
                btnFalta.BackColor = Color.LightSalmon

                AddHandler btnFalta.Click, AddressOf StatusControl
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnFalta)

                'Cuenta
                txtCuenta = New Label
                txtCuenta.Name = "txtc_" & dt.Rows(i).Item(0)
                txtCuenta.BackColor = Color.Beige
                txtCuenta.Text = dt.Rows(i).Item(12)
                txtCuenta.BorderStyle = BorderStyle.Fixed3D

                If dt.Rows(i).Item(12) > 0 Then
                    txtCuenta.Visible = True
                End If
                txtCuenta.Font = New System.Drawing.Font("Consolas", 9, FontStyle.Regular)
                txtCuenta.ForeColor = Color.Gray
               
                txtCuenta.AutoSize = True
                '  txtNombre.Width = 500
                ' txtCuenta.Width = 950
                txtCuenta.Location = New Point(btnAprendido.Left + 5, btnFalta.Bottom + 1)
                '   txtNombre.BackColor = Color.LightGray
                ' txtNombre.Height = txtNombre.PreferredHeight
                'AddHandler txtNombre.Click, AddressOf RefreshTexto

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtCuenta)


                'Texto en ingles
                ' txtNombre = New Label
                txtNombre = New RichTextBox
                txtNombre.Name = "txt_" & dt.Rows(i).Item(0)
                txtNombre.BackColor = Color.Beige
                'txtNombre.HideSelection = False
                txtNombre.Text = dt.Rows(i).Item(4) '& " " & dt.Rows(i).Item(1) '& vbCrLf & vbCrLf & dt.Rows(i).Item(3)
                txtNombre.BorderStyle = BorderStyle.None
                txtNombre.Font = New System.Drawing.Font("Consolas", 11, FontStyle.Regular)
                txtNombre.Visible = False

                If dt.Rows(i).Item(1) = IdOracion Then
                    txtNombre.Font = New System.Drawing.Font("Arial", 11, FontStyle.Bold)
                    txtNombre.ForeColor = Color.Blue
                End If

                txtNombre.AutoSize = True
                '  txtNombre.Width = 500
                txtNombre.Width = 950
                txtNombre.Location = New Point(btnAprendido.Right + 1, 6)
                '   txtNombre.BackColor = Color.LightGray
                txtNombre.Height = txtNombre.PreferredHeight
                AddHandler txtNombre.Click, AddressOf RefreshTexto

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtNombre)

                
                ''Texto en español Traduccion
                txtTraduccion = New Label
                txtTraduccion.Name = "tra_" & dt.Rows(i).Item(0)

                If Not IsDBNull(dt.Rows(i).Item(7)) Then
                    txtTraduccion.Text = dt.Rows(i).Item(7)
                End If
                txtTraduccion.BorderStyle = BorderStyle.None
                txtTraduccion.Font = New System.Drawing.Font("Arial", 9, FontStyle.Regular)
                txtTraduccion.ForeColor = Color.DimGray
                txtTraduccion.AutoSize = True
                txtTraduccion.Location = New Point(btnAprendido.Right + 1, txtNombre.Bottom + 5)
                txtTraduccion.Height = txtNombre.PreferredHeight

                txtTraduccion.Visible = False
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTraduccion)

              
                'Evaluacion
                txtTest = New TextBox
                txtTest.Name = "tst_" & dt.Rows(i).Item(0)
                txtTest.Font = New Font("Consolas", 11, FontStyle.Bold)
                'txtTest.ForeColor = Color.DarkRed

                If Not IsDBNull(dt.Rows(i).Item(9)) Then
                    txtTest.Text = dt.Rows(i).Item(9)

                    If dt.Rows(i).Item(8) = True Then
                        txtTest.BackColor = Color.LightGreen
                    Else
                        txtTest.BackColor = Color.LightSalmon
                    End If

                Else
                    txtTest.BackColor = Color.BlanchedAlmond
                End If

                txtTest.BorderStyle = BorderStyle.None
                'txtTest.Font = New System.Drawing.Font("arial", 10, FontStyle.Bold)

                txtTest.Width = 1000
                txtTest.Location = New Point(btnAprendido.Right + 1, txtTraduccion.Bottom + 2)
                txtTest.Visible = False

                'txtTest.Height = txtTest.PreferredHeight
                AddHandler txtTest.TextChanged, AddressOf Exam
                AddHandler txtTest.LostFocus, AddressOf SaveExam

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTest)


                'Evaluacion Español - Ingles
                txtTestES = New TextBox
                txtTestES.Name = "tstES_" & nm
                txtTestES.Font = New Font("Consolas", 11, FontStyle.Bold)

                txtTestES.BackColor = Color.Wheat
                ' End If
                txtTestES.BorderStyle = BorderStyle.None
                'txtTest.Font = New System.Drawing.Font("arial", 10, FontStyle.Bold)
                txtTestES.Width = 500
                txtTestES.Location = New Point(btnAprendido.Right + 1, txtTest.Bottom + 2)
                txtTestES.Visible = False
                'txtTest.Height = txtTest.PreferredHeight
                AddHandler txtTestES.TextChanged, AddressOf ExamES
                AddHandler txtTestES.LostFocus, AddressOf SaveExamES

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTestES)


                ''' ''''''''''' Lado Derecho
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

                'Subir
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

                'Bajar
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

                'Guardar Evaluacion
                btnExam = New Button
                btnExam.Name = "btnStatus_" & dt.Rows(i).Item(0)
                btnExam.Width = 52 : btnExam.Height = 19
                btnExam.Location = New Point(btnDelete.Left - 55, btnDown.Bottom + 1)
                btnExam.Text = "SAVE"

                If dt.Rows(i).Item(8) = False Then
                    If dt.Rows(i).Item(11) = True Then
                        btnExam.BackColor = Color.Yellow
                    End If
                End If

                AddHandler btnExam.Click, AddressOf SaveExam
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnExam)

                '=======================================
                'Personaje
                '=======================================
                p = New PictureBox
                p.Name = "p_" & dt.Rows(i).Item(0)
                p.Width = 80

                If Not IsDBNull(dt.Rows(i).Item(5)) Then
                    If dt.Rows(i).Item(5) >= 0 Then
                        p.Tag = dt.Rows(i).Item(5)
                        p.Image = ImageList5.Images.Item(dt.Rows(i).Item(5))
                    Else
                        p.Tag = 0
                        p.Image = ImageList5.Images.Item(0)
                    End If
                ElseIf dt.Rows(i).Item(5) = -1 Then
                    p.Tag = 0
                    p.Image = ImageList5.Images.Item(0)
                Else
                    p.Tag = 0
                    p.Image = ImageList5.Images.Item(0)
                End If

                Try
                    p.Location = New Point(2, 1)
                    AddHandler p.Click, AddressOf SeleccionarPersona
                    pEtapa.Controls.Item("pAux_" & nm).Controls.Add(p)

                Catch ex As Exception
                End Try

               
                '=======================================
                ' Flecha
                '=======================================
                pbf = New PictureBox
                pbf.Name = "pbf_" & dt.Rows(i).Item(0)
                pbf.Width = 80
                pbf.Height = 80
                pbf.Tag = dt.Rows(i).Item(10)
                AddHandler pbf.Click, AddressOf CambiarTipoCon

                bmp = New Bitmap(80, 80)
                pbf.Image = bmp

                g = Graphics.FromImage(pbf.Image)
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

                If dt.Rows(i).Item(10) <> "R" Then
                    startPoint = New Point(10, 55)
                    endPoint = New Point(30, 55) ' La línea es horizontal si la coordenada Y es la misma

                    Dim tipPoints As Point() = {endPoint, New Point(endPoint.X - 10, endPoint.Y - 5), New Point(endPoint.X - 10, endPoint.Y + 5)}

                    g.DrawLine(Pens.Blue, startPoint, endPoint)
                    g.FillPolygon(Brushes.Blue, tipPoints)

                Else
                    startPoint = New Point(30, 55)
                    endPoint = New Point(10, 55) ' La línea es horizontal si la coordenada Y es la misma

                    Dim tipPoints As Point() = {endPoint, New Point(endPoint.X + 10, endPoint.Y - 5), New Point(endPoint.X + 10, endPoint.Y + 5)}

                    g.DrawLine(Pens.Orange, startPoint, endPoint)
                    g.FillPolygon(Brushes.Orange, tipPoints)
                End If

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(pbf)


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            '=======================================
            ' Recuadro de color
            '=======================================
            pb = New PictureBox
            pb.Name = "pb_" & dt.Rows(i).Item(0)
            pb.Width = 1200
            pb.Height = 91
            bmp = New Bitmap(1200, 95)
            pb.Image = bmp

            g = Graphics.FromImage(pb.Image)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.DrawRectangle(myPen, 0, 0, 1195, 85)
            ' pb.SendToBack()
            'pb.BringToFront()
            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(pb)
            'item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            'item.UseItemStyleForSubItems = False

            'Try

            '    item.SubItems.Add(dt.Rows(i).Item(4))
            '    item.SubItems.Add(dt.Rows(i).Item(0))

            '    ListView1.Items.Add(item)


            'Catch ex As Exception

            'End Try

            yPos = yPos + 80

        Next i

        txtAvance.Text = Math.Round(Aprendidos / n, 1) & " %"

        '  GuardarAvance(n, Aprendidos)


    End Sub
    Public Sub CrearControlesRandom(grupo)
        Dim pAux As Panel
        Dim txtNombre As RichTextBox
        Dim txtCuenta As TextBox
        Dim txtFecha As Label
        Dim txtTraduccion As Label
        Dim btnSolution As Button
        Dim btnCuenta As Button
        Dim btnDown As Button
        Dim btnDelete As Button
        Dim btnHide As Button
        Dim btnTask As Button
        Dim btnAprendido As Button
        Dim btnAprendidoES As Button
        Dim btnExam As Button
        Dim Cuenta As Integer
        Dim btnLeer As Button
        Dim btnLeerES As Button
        Dim txtParam As Label
        Dim btnAuxNo As Label
        Dim txtTest As TextBox
        Dim txtTestES As TextBox

        Dim yPos As Integer
        Dim lblY As Integer

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim criterio As String
        Dim DatosTickets As DataTable
        Dim param As String = ""
        Dim i As Integer
        Dim ticketId, ticketTipo As String

        Dim usuarios As List(Of String)
        Dim fechas As List(Of String)
        Dim Comentarios As List(Of String)
        Dim parametros As List(Of String)

        Dim random As New Random()

        Dim maximo As Integer = 0

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String = ""

        sqlstring = "  SELECT         Oraciones.Id, Oraciones.Oracion, Oraciones.ConceptoID, Oraciones.GrupoO, Oraciones.Traduccion, Oraciones.forma, Oraciones.STL, Oraciones.GRUPO, Oraciones.IMG, Oraciones.Orden, "
        sqlstring = sqlstring & "  Oraciones.IPA, Oraciones.TextoPlano, Oraciones.CursoId, Oraciones.Ora_Aprendido, Oraciones.Exam,  Oraciones.Cuenta, Grupos_oracion.Grupo, Grupos_oracion.Tipo,"
        sqlstring = sqlstring & " Oraciones.Persona, Oraciones.ExamES, Oraciones.aprendidoES, Oraciones.IMG"
        sqlstring = sqlstring & " FROM            Oraciones INNER JOIN"
        sqlstring = sqlstring & "                Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"
        sqlstring = sqlstring & " WHERE  Oraciones.STL='False'  "

        If cmdfoco.Text = "Foco" Then
            sqlstring = sqlstring & "  And   Oraciones.foco='1' "
            cmdfoco.Text = "Sin foco"
        Else
            sqlstring = sqlstring & "  And   Oraciones.foco='0' "
            cmdfoco.Text = "foco"

        End If

        
        If grupo <> "" Then
            If cboGrupo.Text <> "ALL" Then
                sqlstring = sqlstring & " AND Grupos_oracion.grupo ='" & grupo & "'"

            End If
        Else
            
        End If


        Console.WriteLine(sqlstring)
        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            _comando.Connection.Close()

        End Try

        n = dt.Rows.Count

        pEtapa.Controls.Clear()

        Panel3.Visible = False


        ListView1.Items.Clear()

        If n = 0 Then
            MsgBox("No hay datos", MsgBoxStyle.Information)
            Exit Sub
        End If

        yPos = 10

        i = 0

       
        Dim item As ListViewItem 'Creo el ListViewItem (item) 


        Dim List As New List(Of String)

        pEtapa.AutoScroll = True

        Dim person1 As Integer
        Dim person2 As Integer

        Dim p As PictureBox
        Dim bmp As Bitmap
        Dim g As Graphics
        Dim nm As String
        Dim myPen As Pen
        'Dim myPenNo 
        ' Dim myPenOk = New Pen(Color.LightGreen, 1)
        Dim pb As PictureBox
        Dim pbi As PictureBox
        Dim indiceAleatorio As Integer

        Try
            maximo = InputBox("Ingrese valor, maximo:" & n, , n)

        Catch ex As Exception
            Exit Sub
        End Try

        If maximo > n Then
            maximo = n
        End If
        yPos = 0

        Dim numerosGenerados As New List(Of Integer)()
        Dim yaEstaEnLaLista As Boolean

        For i = 1 To maximo
            yaEstaEnLaLista = True
            Do While yaEstaEnLaLista
                indiceAleatorio = random.Next(n)
                'numeroAleatorio = CInt(Math.Floor((max - min + 1) * Rnd())) + min
                ' Comprobar si el número ya está en la lista
                If numerosGenerados.Contains(indiceAleatorio) Then
                    yaEstaEnLaLista = True ' El número está repetido, genera otro
                Else
                    yaEstaEnLaLista = False ' El número es único, salir del bucle
                End If
            Loop

            ' Agregar el número único a la lista
            numerosGenerados.Add(indiceAleatorio)

            nm = dt.Rows(indiceAleatorio).Item(0)
            'If nm > 0 Then
            'Else
            '    MsgBox("no existe")
            'End If
            'If IsDBNull(nm) Then
            '    MsgBox("no existe")
            'End If
            If Not IsDBNull(dt.Rows(indiceAleatorio).Item(11)) Then

                pAux = New Panel
                pAux.Name = "pAux_" & nm

                pAux.Height = 90
                pAux.Width = 1400

                pAux.Location = New Point(0, yPos)
                pAux.BackColor = Color.Beige

                pAux.BorderStyle = BorderStyle.Fixed3D


                pEtapa.Controls.Add(pAux)

                'Leer
                btnLeer = New Button
                btnLeer.Name = nm
                btnLeer.Width = 25 : btnLeer.Height = 25 ': btnTask.Text = "Report"
                btnLeer.Location = New Point(45, 1)
                btnLeer.Image = ImageList1.Images.Item(0)
                btnLeer.Cursor = Cursors.Hand
                AddHandler btnLeer.Click, AddressOf LeerTexto
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnLeer)

                'Show / Hide
                btnHide = New Button
                btnHide.Name = "btnHide_" & nm
                btnHide.Width = 25 : btnHide.Height = 25 ': btnTask.Text = "Report"
                btnHide.Location = New Point(45, btnLeer.Bottom + 0.5)
                ' btnDown.Image = ImageList3.Images.Item(1)
                btnHide.Text = " ? "

                'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
                'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
                AddHandler btnHide.Click, AddressOf Show

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnHide)

                'Leer
                btnLeerES = New Button
                btnLeerES.Name = nm
                btnLeerES.Width = 25 : btnLeerES.Height = 25 ': btnTask.Text = "Report"
                btnLeerES.Location = New Point(45, btnHide.Bottom + 1)
                btnLeerES.Image = ImageList1.Images.Item(0)
                btnLeerES.Cursor = Cursors.Hand

                If Not IsDBNull(dt.Rows(indiceAleatorio).Item(8)) Then
                    btnLeerES.Tag = dt.Rows(indiceAleatorio).Item(8)
                    AddHandler btnLeerES.MouseMove, AddressOf MostrarImagen
                    'btnLeerES.ForeColor = Color.Green
                    btnLeerES.BackColor = Color.LightPink
                End If


                AddHandler btnLeerES.Click, AddressOf LeerTextoES
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnLeerES)


                'Status
                btnAprendido = New Button
                btnAprendido.Name = "btnStatus_" & nm
                btnAprendido.Width = 35 : btnAprendido.Height = 25
                btnAprendido.Location = New Point(btnLeer.Right + 1, 1)

                If dt.Rows(indiceAleatorio).Item(6) = False Then
                    btnAprendido.Text = "NO"
                    btnAprendido.BackColor = Color.LightSalmon
                    myPen = New Pen(Color.LightSalmon, 1)
                Else
                    btnAprendido.Text = "SI"
                    btnAprendido.BackColor = Color.LightGreen
                    myPen = New Pen(Color.LightGreen, 1)
                    Aprendidos += 1

                End If

                AddHandler btnAprendido.Click, AddressOf StatusControl
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnAprendido)

                'Texto en ingles
                ' txtNombre = New Label
                txtNombre = New RichTextBox
                txtNombre.Name = "txt_" & nm
                txtNombre.BackColor = Color.Beige
                'txtNombre.HideSelection = False
                txtNombre.Text = dt.Rows(indiceAleatorio).Item(11) '& " " & dt.Rows(i).Item(1) '& vbCrLf & vbCrLf & dt.Rows(i).Item(3)
                txtNombre.BorderStyle = BorderStyle.None
                txtNombre.Font = New System.Drawing.Font("Consolas", 11, FontStyle.Regular)
                txtNombre.Visible = False

                'If dt.Rows(i).Item(1) = IdOracion Then
                '    txtNombre.Font = New System.Drawing.Font("Arial", 11, FontStyle.Bold)
                '    txtNombre.ForeColor = Color.Blue
                'End If
                '  Console.WriteLine(dt.Rows(indiceAleatorio).Item(11))

                txtNombre.AutoSize = True
                '  txtNombre.Width = 500
                txtNombre.Width = 950
                txtNombre.Location = New Point(btnAprendido.Right + 1, 5)
                '   txtNombre.BackColor = Color.LightGray
                txtNombre.Height = txtNombre.PreferredHeight
                AddHandler txtNombre.Click, AddressOf RefreshTexto

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtNombre)

                pEtapa.Controls.Item("pAux_" & nm).Refresh()

                ''Texto en español Traduccion
                txtTraduccion = New Label
                txtTraduccion.Name = "tra_" & nm

                If Not IsDBNull(dt.Rows(indiceAleatorio).Item(4)) Then
                    txtTraduccion.Text = dt.Rows(indiceAleatorio).Item(4)
                End If
                txtTraduccion.BorderStyle = BorderStyle.None
                txtTraduccion.Font = New System.Drawing.Font("Arial", 9, FontStyle.Regular)
                txtTraduccion.ForeColor = Color.DimGray
                txtTraduccion.AutoSize = True
                txtTraduccion.Location = New Point(btnAprendido.Right + 1, txtNombre.Bottom + 5)
                txtTraduccion.Height = txtNombre.PreferredHeight

                txtTraduccion.Visible = False
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTraduccion)

                'Evaluacion Ingles - Español
                txtTest = New TextBox
                txtTest.Name = "tst_" & nm
                txtTest.Font = New Font("Consolas", 11, FontStyle.Bold)

                If Not IsDBNull(dt.Rows(indiceAleatorio).Item(14)) Then
                    If dt.Rows(indiceAleatorio).Item(6) = True Then
                        txtTest.BackColor = Color.LightGreen
                    Else
                        txtTest.BackColor = Color.LightSalmon
                    End If
                Else
                    txtTest.BackColor = Color.BlanchedAlmond
                End If

                txtTest.BorderStyle = BorderStyle.None
                txtTest.Width = 500
                txtTest.Location = New Point(btnAprendido.Right + 1, txtTraduccion.Bottom + 2)

                'txtTest.Height = txtTest.PreferredHeight
                AddHandler txtTest.TextChanged, AddressOf Exam
                AddHandler txtTest.LostFocus, AddressOf SaveExam

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTest)

                'Evaluacion Español - Ingles
                txtTestES = New TextBox
                txtTestES.Name = "tstES_" & nm
                txtTestES.Font = New Font("Consolas", 11, FontStyle.Bold)
                'If Not IsDBNull(dt.Rows(indiceAleatorio).Item(19)) Then
                '    txtTestES.Text = dt.Rows(indiceAleatorio).Item(19)
                '    'If dt.Rows(i).Item(6) = True Then
                '    txtTestES.BackColor = Color.LightSkyBlue
                '    ' txtTestES.BackColor = Color.LightSalmon
                '    'End If
                'Else
                txtTestES.BackColor = Color.Wheat
                ' End If
                txtTestES.BorderStyle = BorderStyle.None
                'txtTest.Font = New System.Drawing.Font("arial", 10, FontStyle.Bold)
                txtTestES.Width = 500
                txtTestES.Location = New Point(btnAprendido.Right + 1, txtTest.Bottom + 2)

                'txtTest.Height = txtTest.PreferredHeight
                AddHandler txtTestES.TextChanged, AddressOf ExamES
                AddHandler txtTestES.LostFocus, AddressOf SaveExamES

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTestES)

                'Delete
                btnDelete = New Button
                btnDelete.Name = "btnDelete_" & nm
                btnDelete.Width = 25 : btnDelete.Height = 25 ': btnTask.Text = "Report"
                btnDelete.Location = New Point(pAux.Right - 120, 1)
                ' btnDown.Image = ImageList3.Images.Item(1)
                btnDelete.Text = "X"

                'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
                'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
                AddHandler btnDelete.Click, AddressOf Delete

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnDelete)


                'Editar
                btnTask = New Button
                btnTask.Name = "btnTask_" & nm
                btnTask.Width = 25 : btnDelete.Height = 25 ': btnTask.Text = "Report"
                btnTask.Location = New Point(pAux.Right - 120, btnDelete.Bottom + 1)
                ' btnDown.Image = ImageList3.Images.Item(1)
                btnTask.Text = "Edit"

                'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
                'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
                AddHandler btnTask.Click, AddressOf Editar

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnTask)

                'boton Cuenta
                btnCuenta = New Button
                ' btnUp.Name = "btnUp_" & dt.Rows(i).Item(6)
                btnCuenta.Name = "btnCuenta_" & nm
                btnCuenta.Width = 52 : btnCuenta.Height = 19 ': btnTask.Text = "Report"
                btnCuenta.Location = New Point(btnDelete.Left - 55, 1)
                btnCuenta.Text = "UP"
                AddHandler btnCuenta.Click, AddressOf Cuentas

                'AddHandler btnCuenta.Click, AddressOf MoveUp
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnCuenta)

                'Cuenta
                txtCuenta = New TextBox
                txtCuenta.Name = "txtCuenta_" & nm
                txtCuenta.BackColor = Color.Beige
                'txtNombre.HideSelection = False
                txtCuenta.Text = dt.Rows(indiceAleatorio).Item(15) '& " " & dt.Rows(i).Item(1) '& vbCrLf & vbCrLf & dt.Rows(i).Item(3)
                txtCuenta.BorderStyle = BorderStyle.None
                txtCuenta.Font = New System.Drawing.Font("Consolas", 11, FontStyle.Regular)
                'txtCuenta.Visible = False

                txtCuenta.AutoSize = True
                '  txtNombre.Width = 500
                txtCuenta.Width = 950
                txtCuenta.Location = New Point(btnCuenta.Left - 55, btnCuenta.Bottom + 1)
                txtCuenta.Height = txtCuenta.PreferredHeight
                ' AddHandler txtCuenta.TextChanged, AddressOf Cuentas

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtCuenta)


                'Guardar Evaluacion
                btnExam = New Button
                btnExam.Name = "btnStatus_" & nm
                btnExam.Width = 52 : btnExam.Height = 19
                btnExam.Location = New Point(btnDelete.Left - 55, txtCuenta.Bottom + 1)
                btnExam.Text = "SAVE"

                AddHandler btnExam.Click, AddressOf SaveExam
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnExam)

              

                'Aprendido
                btnAprendidoES = New Button
                btnAprendidoES.Name = "btnAprendidoES_" & nm
                btnAprendidoES.Width = 60 : btnAprendidoES.Height = 19
                'btnAprendidoES.Location = New Point(btnStatus.Left - 50, 1)
                btnAprendidoES.Location = New Point(btnExam.Left, btnExam.Bottom + 1)

                If dt.Rows(indiceAleatorio).Item(20) = False Then
                    btnAprendidoES.Text = "NO"
                    btnAprendidoES.BackColor = Color.LightSalmon
                    myPen = New Pen(Color.LightSalmon, 1)
                Else
                    btnAprendidoES.Text = "SI"
                    btnAprendidoES.BackColor = Color.LightGreen
                    myPen = New Pen(Color.LightGreen, 1)
                    Aprendidos += 1

                End If

                AddHandler btnAprendidoES.Click, AddressOf ControlAprendidosES
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnAprendidoES)

                'Personaje
                p = New PictureBox
                p.Name = "p_" & nm
                p.Height = 40
                p.Width = 40
                ' p.BackColor = Color.Aqua

                If Not IsDBNull(dt.Rows(indiceAleatorio).Item(18)) Then

                    p.Tag = dt.Rows(indiceAleatorio).Item(18)
                    p.Image = ImageList5.Images.Item(dt.Rows(indiceAleatorio).Item(18))
                Else
                    p.Tag = 0
                    p.Image = ImageList5.Images.Item(0)
                End If


                p.Location = New Point(2, 1)
                AddHandler p.Click, AddressOf SeleccionarPersonaRandom

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(p)

                'Recuadro de color
                ' g = pEtapa.Controls("pAux_" & 16260).CreateGraphics
                pb = New PictureBox
                pb.Name = "pb_" & nm
                pb.Width = 1500
                pb.Height = 100
                bmp = New Bitmap(1200, 100)
                pb.Image = bmp
                AddHandler pb.Click, AddressOf OcultarImagen

                g = Graphics.FromImage(pb.Image)
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                g.DrawRectangle(myPen, 0, 0, 1500, 110)

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(pb)
                ' pb.SendToBack()
                'item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

                'item.UseItemStyleForSubItems = False

                'Try

                '    item.SubItems.Add(dt.Rows(i).Item(4))
                '    item.SubItems.Add(dt.Rows(i).Item(0))

                '    ListView1.Items.Add(item)

                'Catch ex As Exception
                'End Try

                yPos = yPos + 80
            Else
                Console.WriteLine(dt.Rows(indiceAleatorio).Item(11))

            End If
        Next i

        txtAvance.Text = Math.Round(Aprendidos / n, 1) & " %"

        '  GuardarAvance(n, Aprendidos)
        ' PictureBox1.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\vacio.jpg")
        '' PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub
    Private Sub GuardarAvance(n, a)
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
        Dim avance As Double

        _comando.Connection.Open()

        _comando.Parameters.Clear()

        sqlstring = "UPDATE Enc_Conversation SET Con_Cant = @Con_Cant, Con_aprendidos = @Con_aprendidos, Con_avance = @Con_avance"
        sqlstring = sqlstring & " WHERE Con_Id = @Con_Id"

        _comando.Parameters.AddWithValue("@Con_Cant", n)
        _comando.Parameters.AddWithValue("@Con_aprendidos", a)
        Try
            avance = (a / n) ' * 100
        Catch ex As Exception
            avance = 0
        End Try
        If avance >= 0 Then
        Else
            avance = 0
        End If
        _comando.Parameters.AddWithValue("@Con_avance", avance)

        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@Con_Id", Id)
        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

        _comando.Connection.Close()

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
        'itemCurr = ListView1.Items(indice)

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

            'CrearControles()
            pEtapa.Controls.Remove(pEtapa.Controls.Item("pAux_" & IdOracion))


        Catch ex As Exception
            MsgBox(ex.Message)
            _comando.Connection.Close()

        Finally

        End Try

        checkMostrarTexto.Text = "Mostrar Texto"
        checkMostrarTexto.Checked = False

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

        IdDet = str(1)

        sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId"
        sqlstring = sqlstring & " FROM            Det_Conversation"
        'sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & IdDet & "'"
        'sqlstring = sqlstring & " ORDER BY  Det_Conversation.Det_Orden ASC"

        Dim objDataReader As SqlDataReader

        Try
            _comando.CommandText = sqlstring

            _comando.Connection.Open()

        Catch ex As Exception

        End Try

        Try
            objDataReader = _comando.ExecuteReader

            If objDataReader.HasRows Then

                objDataReader.Read()

                IdOracionItem = objDataReader(1)
            Else
                IdOracionItem = IdDet

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()


        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New FrmDetOracion

        AddOwnedForm(frm)

        frm.IdOracion = IdOracionItem
        'frm.CargarDatos(IdOracionItem)
        frm.CargarDatos(IdOracionItem)
        frm.ShowDialog()

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
        Dim obj As New RichTextBox

        obj = sender

        nm = sender.Name

        str = nm.Split("_")

        tp = str(0)

        indice = str(1)

        If Id <> 0 Then
            sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Oraciones.TextoPlano, Det_Person, Det_Par, Oraciones.traduccion"
            sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
            sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
            sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & str(1) & "'"
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
            'SELECT        TOP (200) [Delete], SEL, estatus, GrupoId, forma, STL, GRUPO, IMG, Orden, IPA, Campo3, , CursoId, Ora_Aprendido, Exam, Cuenta, Persona
            'FROM(Oraciones)
            'WHERE(Id = 3000)
        Else
            sqlstring = "select  Id, TextoPlano FROM Oraciones"
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.Parameters.AddWithValue("@Id", indice)

            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            Try
                da.SelectCommand = _comando

                da.Fill(dt)
                obj.Text = dt.Rows(0).Item(1)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            _comando.Connection.Close()


        End If

       


        Try
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


        If sender.text = "-" Then
            pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("txt_" & IdOracion).Visible = False
            pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("tra_" & IdOracion).Visible = False
            'bandActivado = False
            sender.text = "?"

        Else
            pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("txt_" & IdOracion).Visible = True
            pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("tra_" & IdOracion).Visible = True
            sender.text = "-"
            'bandActivado = True
        End If

   
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
        Dim mypen As Pen
      
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

       

    End Sub
    Private Sub ExamES(sender, e)
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
        Dim mypen As Pen

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)

        IdOracion = str(1)

        If UCase(sender.text) = UCase(pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("tra_" & IdOracion).Text) Then
            sender.forecolor = Color.DarkGreen
            sender.font = New Font("Consolas", 11, FontStyle.Bold)
            ' objtext.Font = New Font("arial", 12, FontStyle.Bold)
        Else
            sender.forecolor = Color.DarkRed
            sender.font = New Font("Consolas", 11, FontStyle.Bold)


        End If



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

        nm = sender.name
        str = nm.Split("_")

        tp = str(0)
        IdDet = str(1)

        Dim Id As Integer
        Dim IdPerson As Integer
        Dim TipoTicket As String

        Dim resp As Integer
        Dim obj As PictureBox

        obj = sender

        If cmbPersona.Text = "" Then Exit Sub

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

        pEtapa.Controls.Item("pAux_" & IdDet).Controls("p_" & IdDet).Tag = IdPerson


    End Sub
    Private Sub SeleccionarPersonaRandom(sender, e)
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

        nm = sender.name
        str = nm.Split("_")

        tp = str(0)
        IdDet = str(1)

        Dim Id As Integer
        Dim IdPerson As Integer
        Dim TipoTicket As String

        Dim resp As Integer
        Dim obj As PictureBox

        obj = sender

        If cmbPersona.Text = "" Then Exit Sub

        IdPerson = cmbPersona.SelectedIndex

        sqlstring = "Update Oraciones SET Persona='" & IdPerson & "'"
        sqlstring = sqlstring & "  WHERE Id = '" & IdDet & "'"

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

        pEtapa.Controls.Item("pAux_" & IdDet).Controls("p_" & IdDet).Tag = IdPerson


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

        IdDet = str(1)

        sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Oraciones.STL"
        sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN Oraciones"
        sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & IdDet & "'"

        Dim objDataReader As SqlDataReader

        Try
            _comando.CommandText = sqlstring

            _comando.Connection.Open()

        Catch ex As Exception

        End Try

        Try
            objDataReader = _comando.ExecuteReader

            If objDataReader.HasRows Then

                objDataReader.Read()

                IdOracionItem = objDataReader(1)
            Else
                IdOracionItem = IdDet
            End If

        Catch ex As Exception

        End Try
        _comando.Connection.Close()



        Dim Exam As String
        Exam = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tst_" & IdDet).Text


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



            If i > 0 Then
            Else
                MsgBox("no se guardo")

            End If
        Catch ex As Exception

        End Try



        '    If i > 0 Then
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
    Private Sub SaveExamES(sender, e)
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

        IdDet = str(1)

        sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Oraciones.STL"
        sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN Oraciones"
        sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & IdDet & "'"

        Dim objDataReader As SqlDataReader

        Try
            _comando.CommandText = sqlstring

            _comando.Connection.Open()

        Catch ex As Exception

        End Try

        Try
            objDataReader = _comando.ExecuteReader

            If objDataReader.HasRows Then

                objDataReader.Read()

                IdOracionItem = objDataReader(1)
            Else
                IdOracionItem = IdDet
            End If

        Catch ex As Exception

        End Try
        _comando.Connection.Close()



        Dim ExamES As String
        ExamES = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tstES_" & IdDet).Text


        Try


            sqlstring = "UPDATE Oraciones SET  ExamES = @ExamES"
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.Parameters.AddWithValue("@Id", IdOracionItem)
            _comando.Parameters.AddWithValue("@ExamES", ExamES)

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
                MsgBox("no se guardo")

            End If
        Catch ex As Exception

        End Try

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
        Dim IdOracionItem As Integer
        Dim mypen As Pen

        nm = sender.Name
        str = nm.Split("_")
        tp = str(0)

        IdDet = str(1)

        sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Oraciones.STL"
        sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN Oraciones"
        sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & IdDet & "'"

        Dim objDataReader As SqlDataReader

        Try
            _comando.CommandText = sqlstring

            _comando.Connection.Open()

        Catch ex As Exception

        End Try

        Try
            objDataReader = _comando.ExecuteReader

            If objDataReader.HasRows Then

                objDataReader.Read()

                IdOracionItem = objDataReader(1)
            Else
                IdOracionItem = IdDet

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()

        Dim CuentaSTL As Integer


        Dim Exam As String
        Exam = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txt_" & IdDet).Text

        Try
            Dim Cuenta As Integer

            If sender.text = "X" Then
                '  sender.backcolor = Color.LightGreen
                ' sender.text = "SI"
                Aprendidos += 1
                'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tst_" & IdDet).BackColor = Color.LightGreen
                CuentaSTL -= 1

            Else
                'sender.backcolor = Color.LightSalmon
                'sender.text = "NO"
                Aprendidos = 1
                'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tst_" & IdDet).BackColor = Color.LightSalmon
                CuentaSTL += 1

            End If

            Cuenta = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Text
            CuentaSTL += Cuenta

            If CuentaSTL <= 0 Then
                mypen = New Pen(Color.LightSalmon, 1)
                Status = False
                pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("btnStatus_" & IdDet).BackColor = Color.Yellow
                pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Visible = False

            Else
                Status = True
                mypen = New Pen(Color.LightGreen, 1)
                pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("btnStatus_" & IdDet).BackColor = Color.Transparent
                pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Visible = True

            End If

            sqlstring = "UPDATE Oraciones SET STL = @STL, CuentaSTL=@CuentaSTL"
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.Parameters.AddWithValue("@Id", IdOracionItem)
            _comando.Parameters.AddWithValue("@STL", Status)
            _comando.Parameters.AddWithValue("@CuentaSTL", CuentaSTL)


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

        Dim pb As PictureBox
        Dim bmp As Bitmap
        Dim g As Graphics

     

        pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("pb_" & IdDet).CreateGraphics.DrawRectangle(mypen, 0, 0, 1195, 85)
        pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Text = CuentaSTL
       
    End Sub
    Private Sub ControlAprendidosES(sender, e)
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
        Dim mypen As Pen

        nm = sender.Name
        str = nm.Split("_")
        tp = str(0)

        IdDet = str(1)

        sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Oraciones.STL"
        sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN Oraciones"
        sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & IdDet & "'"

        Dim objDataReader As SqlDataReader

        Try
            _comando.CommandText = sqlstring

            _comando.Connection.Open()

        Catch ex As Exception

        End Try

        Try
            objDataReader = _comando.ExecuteReader

            If objDataReader.HasRows Then

                objDataReader.Read()

                IdOracionItem = objDataReader(1)
            Else
                IdOracionItem = IdDet

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()



        Dim Exam As String
        Exam = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tra_" & IdDet).Text

        Try

            If sender.text = "NO" Then
                Status = True
                sender.backcolor = Color.LightGreen
                sender.text = "SI"
                ' Aprendidos += 1
                pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tstES_" & IdDet).BackColor = Color.LightGreen
                mypen = New Pen(Color.LightGreen, 1)
            Else
                Status = False
                sender.backcolor = Color.LightSalmon
                sender.text = "NO"
                ' Aprendidos -= 1
                pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tstES_" & IdDet).BackColor = Color.LightSalmon
                mypen = New Pen(Color.LightSalmon, 1)

            End If

            sqlstring = "UPDATE Oraciones SET AprendidoES = @AprendidoES"
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.Parameters.AddWithValue("@Id", IdOracionItem)
            _comando.Parameters.AddWithValue("@AprendidoES", Status)


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

            End If
        Catch ex As Exception

        End Try

        Dim pb As PictureBox
        Dim bmp As Bitmap
        Dim g As Graphics

        'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("pb_" & IdDet).CreateGraphics.DrawRectangle(mypen, 0, 0, 1195, 65)

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

        '1 : Microsoft David - English (United States)
        '2:  Microsoft(James - English(Australia))
        '3:  Microsoft(Linda - English(Canada))
        '4:  Microsoft(Richard - English(Canada))
        '5 : Microsoft George - English (United Kingdom)
        '6 : Microsoft Hazel - English (United Kingdom)
        '7 : Microsoft Susan - English (United Kingdom)
        '8:  Microsoft(Catherine - English(Australia))
        '9 : Microsoft Mark - English (United States)
        '10 : Microsoft Zira - English (United States)

        'speech.Rate = speechRate
        'speech.Volume = volume
        '' speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFlagsAsync)
        '' speech.Speak("Text", SpeechVoiceSpeakFlags.SVSFlagsAsync)
        'speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFVoiceMask)

        Dim _voice As Integer
        _voice = pEtapa.Controls.Item("pAux_" & nm).Controls("p_" & nm).Tag
         
        'If _voice = 0 Then
        '    _voice = 3
        'End If

        Select Case _voice
            Case Is = 0, 1
                _voice = 3
            Case Is = 2   'Woman
                _voice = 2
                'Case Is = 2, 4, 5, 6 'Melendez 'Andrews
                '    _voice = 10
                'Case Is = 9
                '    _voice = 9
                'Case 10, 11
                '    _voice = 10
        End Select

        If Not IsNothing(objtextOver) Then
            objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
        End If

        Dim myPen As New Pen(Color.Red, 2)
        Dim myPenClear As New Pen(Color.Beige, 2)

        Dim g As Graphics
        
        'If Not objtextOver Is Nothing Then
        '    g = objtextOver.CreateGraphics
        '    g.DrawRectangle(myPenClear, 0, 0, 40, 40)
        'End If
        IdCurrent = nm

        If IdOver > 0 Then
            g = pEtapa.Controls("pAux_" & IdOver).Controls.Item("p_" & IdOver).CreateGraphics
            g.DrawRectangle(myPenClear, 0, 0, 40, 40)
        End If

        g = pEtapa.Controls("pAux_" & nm).Controls.Item("p_" & nm).CreateGraphics
        g.DrawRectangle(myPen, 0, 0, 40, 40)

            Try
                objtextCurrent = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("txt_" & nm)
                ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
                objtextCurrent.Font = New Font("Consolas", 11, FontStyle.Bold)

                objtextOver = objtextCurrent
            IdOver = nm

                ' Dim pVoice As ISpVoice = CType(voice, ISpVoice)
                Dim otc As SpObjectTokenCategory = New SpObjectTokenCategory()
                otc.SetId("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices")

                Dim tokenEnum As ISpeechObjectTokens = otc.EnumerateTokens()
                Dim nTokenCount As Integer = tokenEnum.Count

                '  Console.WriteLine("Number of voices: {0}", nTokenCount)
                Dim n As UInteger = 0
                ' Dim pVoice As ISpVoice = CType(voice, ISpVoice)


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
                pVoice.SetRate(TrackBarVelocidad.Value)
                pVoice.SetVolume(TrackBarVolumen.Value)

                Try
                    '  pVoice.Speak(objtextCurrent.Text, 0, n)
                    speech.Speak(objtextCurrent.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

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




    End Sub
    Private Sub LeerTextoES(sender, e)
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

        '1 : Microsoft David - English (United States)
        '2:  Microsoft(James - English(Australia))
        '3:  Microsoft(Linda - English(Canada))
        '4:  Microsoft(Richard - English(Canada))
        '5 : Microsoft George - English (United Kingdom)
        '6 : Microsoft Hazel - English (United Kingdom)
        '7 : Microsoft Susan - English (United Kingdom)
        '8:  Microsoft(Catherine - English(Australia))
        '9 : Microsoft Mark - English (United States)
        '10 : Microsoft Zira - English (United States)

        Dim _voice As Integer
        _voice = pEtapa.Controls.Item("pAux_" & nm).Controls("p_" & nm).Tag


        Select Case _voice
            Case Is = 0, 1
                _voice = 3
            Case Is = 2   'Woman
                _voice = 2

        End Select

        If Not IsNothing(objtextOverES) Then
            objtextOverES.Font = New Font("Consolas", 11, FontStyle.Regular)
        End If

        Dim myPen As New Pen(Color.Red, 2)
        Dim myPenClear As New Pen(Color.Beige, 2)

        Dim g As Graphics

        IdCurrent = nm

        If IdOver > 0 Then
            g = pEtapa.Controls("pAux_" & IdOver).Controls.Item("p_" & IdOver).CreateGraphics
            g.DrawRectangle(myPenClear, 0, 0, 40, 40)
        End If
        Dim synth As New SpeechSynthesizer()


        'synth.SetOutputToDefaultAudioDevice()
        'synth.SelectVoice("Microsoft Zira Desktop")
        'objtextCurrentES = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("tra_" & nm)
        'objtextCurrentES.Font = New Font("Consolas", 11, FontStyle.Bold)

        'objtextOverES = objtextCurrentES
        'IdOver = nm

        'synth.SpeakAsync(objtextCurrentES.Text)
        ' synth.Speak("Hello, this is a test of the speech synthesizer.")



        'Dim AudioFormats As String = ""
        'Dim info As VoiceInfo = voice.VoiceInfo

        ' _voice = 10 'Raul
        _voice = 11 '
        'For Each voice As InstalledVoice In spcsynth.GetInstalledVoices()
        'Console.WriteLine(voice.VoiceInfo.Name)
        'Next
        'Each fmt As SpeechAudioFormatInfo In info.SupportedAudioFormats
        ' AudioFormats += String.Format("{0}" & vbLf, fmt.E

        g = pEtapa.Controls("pAux_" & nm).Controls.Item("p_" & nm).CreateGraphics
        g.DrawRectangle(myPen, 0, 0, 40, 40)

        Try
            objtextCurrentES = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("tra_" & nm)
            objtextCurrentES.Font = New Font("Consolas", 11, FontStyle.Bold)

            objtextOverES = objtextCurrentES
            IdOver = nm

            Dim otc As SpObjectTokenCategory = New SpObjectTokenCategory()
            otc.SetId("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices")

            Dim tokenEnum As ISpeechObjectTokens = otc.EnumerateTokens()
            Dim nTokenCount As Integer = tokenEnum.Count

            Dim n As UInteger = 0

            pVoice.SetVoice(CType(tokenEnum(_voice), ISpObjectToken))

            pVoice.SetRate(TrackBarVelocidad.Value)
            pVoice.SetVolume(TrackBarVolumen.Value)

            Try
                speech.Speak(objtextCurrentES.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

            Catch ex As Exception

            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try




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

        If cmdStop.Text = "Stop" Then
            cmdStop.Text = "Running"
            bandstop = False
        Else
            cmdStop.Text = "Stop"
            bandstop = True
        End If

        'If (paused) = True Then
        'Else
        '    speech.Resume()
        '    paused = False

        'End If

        'AddHandler speaker.SpeakCompleted, AddressOf SpeachComplete
        ' AddHandler speech.Speak, AddressOf SpeachComplete
        'pVoice.SpeakCompleteEvent()

        ' speaker.Voice=
        ' ' speaker.Speak(Texto.Text)
        'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(person)
        'speaker.Voice = speaker.GetVoices(String.Empty, String.Empty).Item(person)

        speaker.Rate = speechRate
        speaker.Volume = volume


        For Each c In pEtapa.Controls

            If cmdStop.Text = "Stop" Then
                Exit Sub
            End If

Pregunta:
            If bandComplete = False Then

                bandComplete = True

                nm = c.name

                str = nm.Split("_")

                tp = str(0)

                IdCurrent = str(1)
                pnlCurrent = nm
                ' Console.WriteLine(c.name)
                ' Console.WriteLine()
                '    'objtextCurr = pEtapa.Controls.Item("pAux" & nm).Controls.Item("txt" & nm)
                ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")

                ' "btnLeer_"
                objtextCurrent = pEtapa.Controls(c.name).Controls.Item("txt_" & IdCurrent)
                ' objtextCurrent.Font = New Font("Consolas", 11, FontStyle.Bold)
                'objtextCurrent.BackColor = Color.Yellow
                'objtextCurrent.Visible = True
                'objtextCurrent.Refresh()

                ' pEtapa.Controls(c.name).Controls.Item(str(1)).BackColor = Color.LightGreen
                ' pEtapa.Controls(c.name).Controls.Item(str(1)).bordercolor = Color.Red
                'pEtapa.Controls(c.name).Controls.Item(str(1)).Refresh()

                'Dim speak As New SpeechSynthesizer
                'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(cmbVoices.SelectedIndex)

                Dim pic As PictureBox
                Dim person As Integer

                ' p.Name = "p_" & dt.Rows(i).Item(0)
                ' bmp = New Bitmap(p.Size.Width, p.Size.Height)
                ' If dt.Rows(i).Item(5) = 1 Then
                ' txtNombre.Image = 
                ' p.Image = ImageList4.Images.Item(dt.Rows(i).Item(5))

                'person = p.Image = ImageList5.Images.Item(dt.Rows(i).Item(5))
                pic = pEtapa.Controls(c.name).Controls.Item("p_" & IdCurrent)
                ' Dim p As New PictureBox
                'Dim bmp As New Bitmap(15, 15)
                'p.Image = bmp

                Dim myPen As New Pen(Color.Red, 2)
                Dim myPenClear As New Pen(Color.Beige, 2)

                Dim g As Graphics
                ' g = Graphics.FromImage(p.Image)
                'g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                'Dim rect1 As New Rectangle(5, 15, 35, 35)
                'g.FillEllipse(Brushes.Red, rect1)

                'g.DrawRectangle(myPen, 500, 20, 10, 10)
                ' pEtapa.Controls(c.name).Controls.Add(p)
                ' p.BringToFront()
                'g = pEtapa.Controls(c.name).CreateGraphics
                If IdOver > 0 Then
                    g = pEtapa.Controls(pnlOver).Controls.Item("p_" & IdOver).CreateGraphics
                    g.DrawRectangle(myPenClear, 0, 0, 40, 40)
                End If

                g = pEtapa.Controls(c.name).Controls.Item("p_" & IdCurrent).CreateGraphics
                g.DrawRectangle(myPen, 0, 0, 40, 40)

                ' Dim myPen As New Pen(Color.Blue, 2)
                ' g.Clear(Color.White)
                ' person = pic.Image
                'speech.WaitUntilDone(-1)


                ' If (paused) = True Then
                ' speech.Resume()
                ' paused = True
                'dimension variables of local scope
                'Dim x, y As Integer
                'x = pEtapa.Controls(c.name).Controls.Item(str(1)).Location.X
                'y = pEtapa.Controls(c.name).Controls.Item(str(1)).Location.y




                'bmp = New Bitmap(pbwidth, pbheight)
                'g = Graphics.FromImage(bmp)
                ''g.Clear(SystemColors.Control)

                'g.FillRectangle(Brushes.Red, New Rectangle(0, 0, 10, pbheight))

                'Dim pb1 As New PictureBox

                'pb1.Image = bmp
                'pb1.BackColor = Color.Red
                'pb1.BringToFront()
                'pEtapa.Controls(c.name).Controls.add(pb1)

                'Dim blackPen As New Pen(Color.Black, 3)

                '' Create rectangle.
                'Dim rect As New Rectangle(0, 0, 200, 200)

                '' Draw rectangle to screen.
                'g.DrawRectangle(blackPen, rect)

                'return the current form as a drawing surface

                ' g = Graphics.FromHwnd(ActiveForm().Handle)

                'create a rectangle based on x,y coordinates, width, & height


                'draw rectangle from pen and rectangle objects



                LeerItem(objtextCurrent, pic.Tag)

            Else


                wait(2) 'Regresa a preguntar
                GoTo Pregunta


            End If



        Next





    End Sub

    Private Sub LeerItem(item, person)
        Dim _voice As String = ""
        Try
            'Voice : Microsoft David - English (United States)
            'Voice:  Microsoft(James - English(Australia))
            'Voice:  Microsoft(Linda - English(Canada))
            'Voice:  Microsoft(Richard - English(Canada))
            'Voice:  Microsoft(Catherine - English(Australia))
            'Voice : Microsoft Mark - English (United States)
            'Voice : Microsoft Zira - English (United States)

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

            ' _voice = "Microsoft Catherine - English (Australia)"
            '_voice = "Microsoft Zira Desktop"

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

                For Each sot As ISpeechObjectToken In tokenEnum
                    Console.WriteLine("Voice : {0}", sot.GetDescription())
                Next

                ' pVoice.SetVoice(CType(sot, ISpObjectToken))
                pVoice.SetVoice(CType(tokenEnum(_voice), ISpObjectToken))
                ' pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))
                ' pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))
                ' speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(voice)
                ' speech.SetVoice(CType(tokenEnum(0), ISpObjectToken))
                pVoice.SetRate(TrackBarVelocidad.Value)
                ' AddHandler voice.EndStream, AddressOf speakComplete

                Try
                    '  pVoice.Speak(objtextCurrent.Text, 0, n)
                    speech.Speak(objtextCurrent.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

                Catch ex As Exception

                End Try



                'pVoice.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync, 0)

                'voice.GetVoices(CType(tokenEnum(person), ISpObjectToken)).Item(5)
                'speech.SetVoice(CType(tokenEnum(4), ISpObjectToken))

                ' voice.Speak(objtextCurr.Text, 0, 0)
                ' voice.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)


                'speech.Speak(objtextCurr.Text, 0, 0)
                For Each v In speaker.GetInstalledVoices
                    Console.WriteLine(v.VoiceInfo.Name)
                Next
                ' paused = True

                'If Voice = "" Then
                '    Voice = "Microsoft Mark"
                'End If

                ' speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(1)
                ' speech.Voice = speech.GetVoices(CType(tokenEnum(4), ISpObjectToken))
                ' speech.Voice = speech.GetVoices(CType(tokenEnum(4), ISpObjectToken))
                'speech.SetVoice(CType(tokenEnum(4), ISpObjectToken))

                ' speech.Rate = speechRate
                ' speech.Volume = volume

                ' speech.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)
                ' speaker.SelectVoice(voice)
                ' speaker.Speak(item.text)
                ' speaker.SelectVoice(_voice)
                'speaker.SelectVoice(tokenEnum(0).GetDescription())
                'pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))

                'speaker.SpeakAsync(item.text)

                ' speech.Speak("This is an asynchronous speech example.", SpeechVoiceSpeakFlags.SVSFlagsAsync)
                ' This line executes immediately, before the speech is completed.

                ' Synth_PhonemeReached(sender, e)
                ' Dim sentences As New List(Of String)()
                ' Dim start As Integer = 0
                ' Dim position As Integer

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub Voice_Word(StreamNumber As Integer, StreamPosition As Object, CharacterPosition As Integer, Length As Integer) Handles speech.Word
        Try
            objtextCurrent.SelectAll()
            objtextCurrent.SelectionBackColor = Color.Beige ' Or your default background color
            'Highlight word in textbox as it is spoken  
            objtextCurrent.Select(CharacterPosition, Length)
            ' Highlight the current word
            ' RichTextBox1.Select(e.CharacterPosition, e.CharacterCount)
            objtextCurrent.SelectionBackColor = Color.Yellow ' Or your desired highlight color
            ' RichTextBox1.Focus()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Cuentas(sender, e)
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
        Dim cuenta As Integer

        nm = sender.name

        str = nm.Split("_")

        tp = str(0)

        indice = str(1)

        If pEtapa.Controls("Paux_" & indice).Controls.Item("txtCuenta_" & indice).Text <> "" Then
            cuenta = pEtapa.Controls("Paux_" & indice).Controls.Item("txtCuenta_" & indice).Text
        Else
            Exit Sub
        End If

        cuenta += 1
            _comando.Connection.Open()

            sqlstring = "UPDATE Oraciones SET Cuenta = @Cuenta"
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.Parameters.AddWithValue("@Cuenta", cuenta)

            _comando.Parameters.AddWithValue("@Id", indice)

            Try
                _comando.CommandText = sqlstring

                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try
            _comando.Connection.Close()
        pEtapa.Controls.Item("pAux_" & indice).Controls("txtCuenta_" & indice).Text = cuenta


    End Sub

    Private Sub MostrarImagen(sender, e)
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
        Dim cuenta As Integer

        nm = sender.name

        str = nm.Split("_")

        tp = str(0)

        ' indice = str(1)


      
        Dim filename As String
        filename = sender.tag


        ' Dim btn As Button
        ' btn = pEtapa.Controls.Item("pAux_" & nm).Controls(nm)

        
        'PictureBox1.Location = New Point(0, 0)

        ' pbi.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\" & filename)
        Try
            PictureBox1.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\" & filename)
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            PictureBox1.BringToFront()

            Panel3.Visible = True
            Panel3.Location = New Point(500, MousePosition.Y - 100)
        Catch ex As Exception
            Panel3.Visible = False

        End Try
       
        
        'Me.Controls.Add(newpanel)

        'newpanel.Location = New Point(100, 100)

        'newpanel.BringToFront()

        'newpanel.Controls.Add(PictureBox1)

        '_comando.Connection.Open()
        '_comando.Parameters.AddWithValue("@Cuenta", cuenta)

        '_comando.Parameters.AddWithValue("@Id", indice)

        'Try
        '    _comando.CommandText = sqlstring

        '    i = _comando.ExecuteNonQuery

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally

        'End Try
        ' _comando.Connection.Close()
        'pEtapa.Controls.Item("pAux_" & indice).Controls("txtCuenta_" & indice).Text = cuenta


    End Sub
    Private Sub OcultarImagen(sender, e)



        Panel3.Visible = False
        'Panel3.Location = New Point(MousePosition.X + 200, MousePosition.Y)




        'Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        'Dim sqlstring As String
        'Dim IdOracion As Integer
        'Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
        'Dim i As Integer
        'Dim indice As Integer
        'Dim itemCurr As ListViewItem
        'Dim itemOver As ListViewItem
        'Dim itemSel As Integer
        'Dim nm As String
        'Dim str() As String
        'Dim tp As String
        'Dim param As String = ""
        'Dim q As Integer
        'Dim cuenta As Integer

        'nm = sender.name

        'str = nm.Split("_")

        'tp = str(0)

        'indice = str(1)

        'If pEtapa.Controls("Paux_" & indice).Controls.Item("txtCuenta_" & indice).Text <> "" Then
        '    cuenta = pEtapa.Controls("Paux_" & indice).Controls.Item("txtCuenta_" & indice).Text
        'Else
        '    Exit Sub
        'End If

        'cuenta += 1
        '_comando.Connection.Open()

        'sqlstring = "UPDATE Oraciones SET Cuenta = @Cuenta"
        'sqlstring = sqlstring & " WHERE Id = @Id"

        '_comando.Parameters.AddWithValue("@Cuenta", cuenta)

        '_comando.Parameters.AddWithValue("@Id", indice)

        'Try
        '    _comando.CommandText = sqlstring

        '    i = _comando.ExecuteNonQuery

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally

        'End Try
        '_comando.Connection.Close()
        'pEtapa.Controls.Item("pAux_" & indice).Controls("txtCuenta_" & indice).Text = cuenta


    End Sub
    Private Sub CambiarTipoCon(sender, e)
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

        nm = sender.name
        str = nm.Split("_")

        tp = str(0)
        IdDet = str(1)

        Dim Id As Integer
        Dim IdPerson As Integer
        Dim TipoTicket As String

        Dim resp As Integer
        Dim obj As PictureBox
        Dim valorNuevo As String

        obj = sender

        If sender.tag = "R" Then
            valorNuevo = "Q"
            sqlstring = "Update Det_Conversation SET Det_Tipo='Q'"
            sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"
        Else
            valorNuevo = "R"
            sqlstring = "Update Det_Conversation SET Det_Tipo='R'"
            sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"
        End If


        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        Try
            i = _comando.ExecuteNonQuery

            If i > 0 Then
                'MsgBox("se guardo")
                'obj.Image = ImageList5.Images(IdPerson)

            Else
                'MsgBox("No se guardo")
            End If
        Catch ex As Exception

        End Try

        Dim bmp As Bitmap
        Dim g As Graphics
        Dim startPoint As Point
        Dim endPoint As Point

        bmp = New Bitmap(80, 80)
        sender.Image = bmp
        sender.tag = valorNuevo

        g = Graphics.FromImage(sender.Image)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        If valorNuevo <> "R" Then
            startPoint = New Point(10, 55)
            endPoint = New Point(30, 55) ' La línea es horizontal si la coordenada Y es la misma

            Dim tipPoints As Point() = {
       endPoint, New Point(endPoint.X - 10, endPoint.Y - 5), New Point(endPoint.X - 10, endPoint.Y + 5)}

            g.DrawLine(Pens.Blue, startPoint, endPoint)
            g.FillPolygon(Brushes.Blue, tipPoints)

        Else
            startPoint = New Point(30, 55)
            endPoint = New Point(10, 55) ' La línea es horizontal si la coordenada Y es la misma

            Dim tipPoints As Point() = {
       endPoint, New Point(endPoint.X + 10, endPoint.Y - 5), New Point(endPoint.X + 10, endPoint.Y + 5)}

            g.DrawLine(Pens.Orange, startPoint, endPoint)
            g.FillPolygon(Brushes.Orange, tipPoints)
        End If


        ' pEtapa.Controls.Item("pAux_" & nm).Controls.Add(pbf)


    End Sub

#End Region
#Region "todo lo demas"

    Private Sub SpeachComplete(sender As Object, e As SpeakCompletedEventArgs)

        'objtextOver = objtextCurrent


        'If Not IsNothing(objtextOver) Then
        '    objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)

        'End If

        'bandComplete = False

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

        'If Aprendidos <> n Then
        'GuardarAvance(n, Aprendidos)
        ' End If


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

    Private Sub cmbPersona_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

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
        'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(cmbVoices.SelectedIndex)

        If (paused) = True Then
            'speech.Resume()
            paused = False

        Else
            'obj.Text = 


            ' speech.Rate = speechRate
            ' speech.Volume = volume


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

        frm.Id = Id
        'frm.IdConversation = Id
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

        If cmdStop.Text = "Stop" Then
            cmdStop.Text = "Running"
            bandstop = False
        Else
            cmdStop.Text = "Stop"
            bandstop = True
        End If
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

    Private Sub cmdAudio_Click(sender As System.Object, e As System.EventArgs) Handles cmdAudio.Click
        ' Me.Player.SoundLocation = Application.StartupPath & "C:\Legacy\audios\spirit.mp3"
        '   Me.Player.SoundLocation = "C:\Legacy\audios\spirit.mp3"
        '   Me.Player.PlayLooping()

        My.Computer.Audio.Play("C:\Legacy\audios\spirit.mp3",
       AudioPlayMode.WaitToComplete)

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

        If checkMostrarTexto.Text = "Mostrar Texto" Then

            For Each c In pEtapa.Controls

                nm = c.name

                str = nm.Split("_")

                tp = str(0)

                pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Visible = True
                pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Refresh()
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Visible = True
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Refresh()

            Next

            checkMostrarTexto.Text = "Ocultar Texto"
        Else

            For Each c In pEtapa.Controls

                nm = c.name

                str = nm.Split("_")

                tp = str(0)

                pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Visible = False
                pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Refresh()
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Visible = False
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Refresh()

            Next

            checkMostrarTexto.Text = "Mostrar Texto"
        End If




    End Sub

    Private Sub cmdOraciones_Click(sender As System.Object, e As System.EventArgs) Handles cmdOraciones.Click
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
        Dim objDataReader As SqlDataReader
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        _comando.Connection.Open()

        For Each c In pEtapa.Controls

            nm = c.name

            str = nm.Split("_")

            tp = str(0)

            textoOriginal = pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).text

            textoModificado = Trim(textoOriginal.Replace("?", "")) ' Reemplaza el símbolo de ? por ""


            Dim sqlstring As String = ""

            '  If textoModificado = "" Then Exit Sub

            sqlstring = " SELECT Id, TextoPlano, Traduccion  FROM Oraciones"

            sqlstring = sqlstring & " Where TextoPlano LIKE " & "'%" & textoModificado & "%'"
            sqlstring = sqlstring & " ORDER BY Oraciones.TextoPlano ASC"

            _comando.CommandText = sqlstring

            Try
                objDataReader = _comando.ExecuteReader

                If objDataReader.HasRows Then

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            objDataReader.Close()

        Next

        _comando.Connection.Close()

        ' Dim texto As String = ""

        ''Split con array de delimitadores
        ' Dim delimitadores() As String = {"?", "-", ">", "<", "+", "-", "/", "*"}



    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim frm As New frmTexto
        frm.Con_Id = Id
        frm.Show()

    End Sub

    Private Sub txtOrdenar_Click(sender As System.Object, e As System.EventArgs) Handles txtOrdenar.Click
        Dim frm As New frmOrdenarConversacion

        AddOwnedForm(frm)

        frm.Id = Id

        frm.ShowDialog()

    End Sub

    Private Sub FrmConversation_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
       

    End Sub
    Public Sub DrawRectangleRectangle(ByVal e As PaintEventArgs)

        '' Create pen.
        'Dim blackPen As New Pen(Color.Black, 3)

        '' Create rectangle.
        'Dim rect As New Rectangle(0, 0, 200, 200)

        '' Draw rectangle to screen.
        'e.Graphics.DrawRectangle(blackPen, rect)
    End Sub


    Private Sub MyPanel_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        ''  e.Graphics.DrawRectangle(Pens.Red, 5, 5, 20, 20)
        '' Create pen.
        'Dim blackPen As New Pen(Color.Red, 2)

        '' Create rectangle.
        'Dim rect As New Rectangle(0, 0, 20, 20)

        '' Draw rectangle to screen.

        'e.Graphics.DrawRectangle(blackPen, rect)
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs)
        Dim mypen As New Pen(Color.Red, 3)

        pEtapa.Controls.Item("pAux_" & 16260).CreateGraphics.DrawRectangle(mypen, 0, 0, 500, 50)

    End Sub

    Private Sub checkMostrarTest_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkMostrarTest.CheckedChanged
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        If checkMostrarTest.Text = "" Then Exit Sub

        If checkMostrarTest.Text = "Mostrar Test" Then

            For Each c In pEtapa.Controls

                nm = c.name

                str = nm.Split("_")

                tp = str(0)

                pEtapa.Controls(c.name).Controls.Item("tst_" & str(1)).Visible = True
                pEtapa.Controls(c.name).Controls.Item("tst_" & str(1)).Refresh()


            Next

            checkMostrarTest.Text = "Ocultar Test"
        Else

            For Each c In pEtapa.Controls

                nm = c.name

                str = nm.Split("_")

                tp = str(0)

                pEtapa.Controls(c.name).Controls.Item("tst_" & str(1)).Visible = False
                pEtapa.Controls(c.name).Controls.Item("tst_" & str(1)).Refresh()
            Next

            checkMostrarTest.Text = "Mostrar Test"
        End If
         
    End Sub

    Private Sub TrackBarVolumen_Scroll(sender As System.Object, e As System.EventArgs) Handles TrackBarVolumen.Scroll
        'speechRate = TrackBarVelocidad.Value
        'lblVelocidad.Text = TrackBarVelocidad.Value
        ' TrackBarVolumen.Value = volume
        pVoice.SetVolume(TrackBarVolumen.Value)
        txtVolumen.Text = TrackBarVolumen.Value

    End Sub

    Private Sub cmdtext_Click(sender As System.Object, e As System.EventArgs) Handles cmdtext.Click
        Dim frm As New frmTexto

        AddOwnedForm(frm)

        frm.Con_Id = Id
        frm.Show()


    End Sub

    Private Sub cmdRandom_Click(sender As System.Object, e As System.EventArgs) Handles cmdRandom.Click
        'WebBrowser1.Document.BackColor = Color.White

        ' RichTextBoxEx1.Controls.Item("rtb").LoadFile = "C:\Legacy\Test.rtf"
        Dim test As Boolean

        '() 'Load("C:Legacy\Rtf\.rtf")
        ' Dim obj As New RichTextBoxEx.RichTextBoxEx

        ' obj.Controls.Item("rtb").Focus()

        IdOver = 0
        Dim _grupo As String
        _grupo = cboGrupo.Text

        CrearControlesRandom(_grupo)

        ' CargarConversation(Id)


        Dim synth As New SpeechSynthesizer()
       
        'For Each voice As InstalledVoice In synth.GetInstalledVoices()
        '    Dim info As VoiceInfo = voice.VoiceInfo
        '    Console.WriteLine(voice.VoiceInfo)
        'Next
        

        ToolStatus.Text = "Oracion"

        lblVelocidad.Text = TrackBarVelocidad.Value

        LblId.Text = Id

        cmbPersona.SelectedIndex = 2

    End Sub

    Private Sub checkMostrarTestES_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkMostrarTestES.CheckedChanged
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        If checkMostrarTestES.Text = "" Then Exit Sub

        If checkMostrarTestES.Text = "Mostrar Test ESP" Then

            For Each c In pEtapa.Controls

                nm = c.name

                str = nm.Split("_")

                tp = str(0)

                pEtapa.Controls(c.name).Controls.Item("tstES_" & str(1)).Visible = True
                pEtapa.Controls(c.name).Controls.Item("tstES_" & str(1)).Refresh()


            Next

            checkMostrarTestES.Text = "Ocultar Test"
        Else

            For Each c In pEtapa.Controls

                nm = c.name

                str = nm.Split("_")

                tp = str(0)

                pEtapa.Controls(c.name).Controls.Item("tstES_" & str(1)).Visible = False
                pEtapa.Controls(c.name).Controls.Item("tstES_" & str(1)).Refresh()
            Next

            checkMostrarTestES.Text = "Mostrar Test ESP"
        End If
    End Sub

    Private Sub checkMostrarTextoES_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkMostrarTextoES.CheckedChanged
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        If checkMostrarTextoES.Text = "" Then Exit Sub

        If checkMostrarTextoES.Text = "Mostrar Texto ES" Then

            For Each c In pEtapa.Controls

                nm = c.name

                str = nm.Split("_")

                tp = str(0)

                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Visible = True
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Font = New System.Drawing.Font("Arial", 11, FontStyle.Bold)
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).ForeColor = Color.Brown
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Refresh()

                'pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Visible = True
                'pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Refresh()


            Next

            checkMostrarTextoES.Text = "Ocultar Texto ES"
        Else

            For Each c In pEtapa.Controls

                nm = c.name

                str = nm.Split("_")

                tp = str(0)

                'pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Visible = False
                'pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Refresh()
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Visible = False
                pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Refresh()

            Next

            checkMostrarTextoES.Text = "Mostrar Texto ES"
        End If
    End Sub

    Private Sub cmdImgTest_Click(sender As System.Object, e As System.EventArgs) Handles cmdImgTest.Click
        Dim pbi As New PictureBox

        pbi.Height = 100
        pbi.Width = 100
        pbi.Location = New Point(0, 0)

        pbi.BringToFront()

        Dim newpanel As New Panel

        Me.Controls.Add(newpanel)

        newpanel.Location = New Point(100, 100)


        newpanel.BringToFront()

        newpanel.Controls.Add(pbi)
    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupo.SelectedIndexChanged
        'WebBrowser1.Document.BackColor = Color.White

        ' RichTextBoxEx1.Controls.Item("rtb").LoadFile = "C:\Legacy\Test.rtf"
        Dim test As Boolean

        '() 'Load("C:Legacy\Rtf\.rtf")
        '  Dim obj As New RichTextBoxEx.RichTextBoxEx
        'obj.Controls.Item("rtb").Focus()

        IdOver = 0
        Dim _grupo As String
        _grupo = cboGrupo.Text

        CrearControlesRandom(_grupo)

        ' CargarConversation(Id)


        Dim synth As New SpeechSynthesizer()

        'For Each voice As InstalledVoice In synth.GetInstalledVoices()
        '    Dim info As VoiceInfo = voice.VoiceInfo
        '    Console.WriteLine(voice.VoiceInfo)
        'Next


        ToolStatus.Text = "Oracion"

        lblVelocidad.Text = TrackBarVelocidad.Value

        LblId.Text = Id

        cmbPersona.SelectedIndex = 2

    End Sub

    Private Sub cmdfoco_Click(sender As System.Object, e As System.EventArgs) Handles cmdfoco.Click

        If cmdfoco.Text = "Foco" Then
            cmdfoco.Text = "Sin foco"
        Else
            cmdfoco.Text = "Foco"
        End If

    End Sub

    Private Sub Button11_Click_1(sender As System.Object, e As System.EventArgs) Handles Button11.Click

        Dim resp As String
        Dim _voice As Integer

        resp = InputBox("Introduce texto")

        If resp = "" Then
            Exit Sub
        End If

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

        '1 : Microsoft David - English (United States)
        '2:  Microsoft(James - English(Australia))
        '3:  Microsoft(Linda - English(Canada))
        '4:  Microsoft(Richard - English(Canada))
        '5 : Microsoft George - English (United Kingdom)
        '6 : Microsoft Hazel - English (United Kingdom)
        '7 : Microsoft Susan - English (United Kingdom)
        '8:  Microsoft(Catherine - English(Australia))
        '9 : Microsoft Mark - English (United States)
        '10 : Microsoft Zira - English (United States)

        'speech.Rate = speechRate
        'speech.Volume = volume
        '' speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFlagsAsync)
        '' speech.Speak("Text", SpeechVoiceSpeakFlags.SVSFlagsAsync)
        'speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFVoiceMask)
        _voice = InputBox("Selecciona Voz")

        '_voice = 2

        'Select Case _voice
        '    Case Is = 0
        '        _voice = 
        '    Case Is = 2   'Woman
        '        _voice = 2
        'End Select
         

        
        ' Dim pVoice As ISpVoice = CType(voice, ISpVoice)
        Dim otc As SpObjectTokenCategory = New SpObjectTokenCategory()
        otc.SetId("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices")

        Dim tokenEnum As ISpeechObjectTokens = otc.EnumerateTokens()
        Dim nTokenCount As Integer = tokenEnum.Count

        '  Console.WriteLine("Number of voices: {0}", nTokenCount)
        Dim n As UInteger = 0

        pVoice.SetVoice(CType(tokenEnum(_voice), ISpObjectToken))

        pVoice.SetRate(TrackBarVelocidad.Value)
        pVoice.SetVolume(TrackBarVolumen.Value)

        Try

            speech.Speak(resp, SpeechVoiceSpeakFlags.SVSFlagsAsync)

        Catch ex As Exception

        End Try



    End Sub
End Class
