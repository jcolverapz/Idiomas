Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports SpeechLib
Imports System.Speech.Synthesis
Imports System
Imports System.Media
Imports System.Windows.Forms
Imports WMPLib
Imports System.Drawing.Imaging
Imports AxWMPLib

Public Class frmEscenas

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
    Public ColorWatsap As Color = System.Drawing.Color.FromArgb(220, 248, 198)
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
    Dim total As Integer
    Dim Cantidad As Integer
    Dim ListDialogos As New ListView
    Dim IdDetAnterior As Integer

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
    Dim LastId As Integer
    Dim LastPanel As New Panel
   
        Dim pnlCurrent As String
        Dim pnlOver As String
        Dim n As Integer
    Public Imagen As String
        Public bandComplete As Boolean

        Public lstModificaciones As New ListView
        'Dim speech As New SpVoice '= New SpVoice()

        Dim speaker As New SpeechSynthesizer()
        ' Public Event SpeakCompleted As EventHandler(Of SpeakCompletedEventArgs)
        Public handler As EventHandler(Of SpeakCompletedEventArgs)
        ' Public handler2 As EventHandler(Of spee)
        'Private WithEvents speech As New SpVoice
        ' Dim voice As SpVoice = New SpVoice()
    Dim picDet As PictureBox
    Dim LastIdItem As Integer
    Dim LastIdOracion As Integer
    Dim frameCount As Integer = 0
    Dim currentFrame As Integer = 0

    Public texto As String
    Dim startIndex As Integer
    Dim length As Integer

    Public filename As String
    Dim rate As Double
    Dim volumen As Double
    ' Private WithEvents synth As New SpeechSynthesizer()

    Public Event SpeakWord As EventHandler(Of SpeakProgressEventArgs)
    Public band As Boolean
    Private hilo1 As Threading.Timer 'a
    Dim MinFaltante As String
    Dim filtro As String
    Dim inicio As Integer = 50
    Dim fin As Integer = 100
    Dim WithEvents Player As New WindowsMediaPlayer
    ' Dim WithEvents player As AxWindowsMediaPlayer

    Private cacheImagenes As New Dictionary(Of String, Image)
    'Private imgSonido As Image = New Bitmap(My.Resources.sonido1)
    Private imgMute As Image = New Bitmap(My.Resources.mute)
    Private imgDefault As Image = New Bitmap(My.Resources._default)
    Private imgSonido As Image = New Bitmap(My.Resources.sonidogris)

    Dim dt As New DataTable
    Dim da As New SqlDataAdapter

    Private poolPanels As New List(Of Panel)

    Private Const PANEL_HEIGHT As Integer = 260
    Private Const MAX_VISIBLE As Integer = 12

    Private listaGrupos As List(Of IGrouping(Of Object, DataRow))
    Dim RutaAudios As String
    Dim RutaImagenesFemenino As String = "C:\Ingles\Imagenes_Ingles\Femenino\"
    Dim RutaImagenes As String = "C:\Ingles\Imagenes_Ingles\"
    Dim RutaImagenesEstandar As String = "C:\Legacy\Ingles\Imagenes_Ingles\Sustantivos\"

    Dim RutaImagenesMasculino As String = "C:\Legacy\Ingles\Imagenes_Ingles\Masculino\"
    Dim RutaAudiosFemenino2 As String = "C:\Legacy\Ingles\Audios2\Femenino\"
    Dim RutaAudiosFemenino3 As String = "C:\Legacy\Ingles\Audios3\Femenino\"
    Dim RutaAudiosMasculino As String = "C:\Legacy\Ingles\Audios3\Masculino\"

    Dim btnSolution As Button

    Dim btnUp As Button
    Dim btnDown As Button
    Dim btnDelete As Button
    Dim btnHide As Button
    Dim btnEditar As Button
    Dim btnAprendido As Button
    Dim btnFalta As Button
    Dim btnExam As Button
    Dim btnMover As Button
    Dim btnMoverDetalle As Button
    Dim btnEliminar As Button
    Dim btnLeer As Button
    Dim btnVoz As Button
    Dim btnTransferir As Button
    Dim btnMoverNuevo As Button
    Dim btnRecibir As Button
    Dim PicFavorito As PictureBox
    Dim btnAgregar As Button
    Dim PicFavoritoDet As PictureBox

    Dim txtTexto As RichTextBox

    Dim txtCuenta As Label
    Dim txtCuentaDialogos As Label
    Dim txtIdDialogo As Label
    Dim txtFecha As Label
    Dim txtTraduccion As Label
    Dim txtIPA As Label
    Dim txtReproduccion As Label
    Dim txtScore As Label


    Dim txtParam As Label
    Dim btnAuxNo As Label
    Dim txtTest As TextBox
    Dim txtTestES As TextBox

    Dim yPos As Integer
    Dim lblY As Integer

    Dim ds As New DataSet

    Dim criterio As String
    Dim DatosTickets As DataTable

    Dim i As Integer
    Dim ticketId, ticketTipo As String

    Dim usuarios As List(Of String)
    Dim fechas As List(Of String)
    Dim Comentarios As List(Of String)
    Dim parametros As List(Of String)
    Dim faltan As String = ""


    Dim lastScroll As Integer = -1

    Dim vScroll As New VScrollBar
    Dim picDetImagen As String

    Dim Seleccionado As Integer = 0
    Dim pic As PictureBox
    Dim pivote As Integer = -500
    ' Dim video As String = "C:\Legacy\Ingles\audios3\Femenino\14845_final.mp4"
    Dim video1 As String = "C:\Legacy\Ingles\videos\14845_final.mp4"
    Dim avatar As Integer
    Private Imagenes As New Dictionary(Of String, Image)

    Dim NombreImagen As String
    Private UltimoArchivo As String = ""

    Private FadeLevel As Integer = 255
    Private FadeMode As String = ""

    Private ArchivoPendiente As String = ""
    Private FadeIniciado As Boolean = False

    Dim wmp As AxWindowsMediaPlayer

#End Region
    Dim pan As New Panel

#Region "Inicio"
    'Private Sub voice_EndStream(StreamNumber As Integer, StreamPosition As Object) Handles speech.EndStream
    '    ' This event fires when an asynchronous speech stream has completed.
    '    'MessageBox.Show("Asynchronous speech completed.")

    '    ' objtextCurrent.BackColor = Color.Beige
    '    Try
    '        objtextCurrent.SelectAll()
    '        objtextCurrent.SelectionBackColor = Color.Beige

    '        objtextOver = objtextCurrent
    '        IdOver = IdCurrent
    '        pnlOver = pnlCurrent

    '        If Not IsNothing(objtextOver) Then
    '            'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
    '            objtextOver.BackColor = Color.Beige

    '        End If
    '    Catch ex As Exception

    '    End Try


    '    bandComplete = False

    'End Sub
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

    Private Sub frmEscenas_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load

        txtEncId.Text = Id
        lblTitulo.Text = Titulo

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = "Select * from  Grupos_oracion "
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

        ' Me.DoubleBuffered = True

        Dim prop = GetType(Panel).GetProperty("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        prop.SetValue(pEtapa, True, Nothing)

        '===================================
        ' Imagenes
        '===================================
        CargarImagenes()

        '===================================
        ' Crear Controles
        '===================================

        CrearControles()

        ' PLAYER

        wmp = New AxWMPLib.AxWindowsMediaPlayer()

        pEtapa.Controls.Add(wmp)

        wmp.CreateControl()
        'wmp.Dock = DockStyle.Fill

        wmp.windowlessVideo = False

        ' Evita repintados
        wmp.enableContextMenu = False

        'AxWindowsMediaPlayer1.SendToBack()

        wmp.uiMode = "none"
        wmp.settings.autoStart = False

        wmp.Size = New Size(320, 180)
        wmp.stretchToFit = True

        ' wmp.Size = New Size(314, 175)
        ' ' wmp.BringToFront()

       

        AddHandler wmp.PlayStateChange, AddressOf wmp_PlayStateChange

        wmp.Ctlcontrols.play()


    End Sub

    Private Sub test_Click(sender As System.Object, e As System.EventArgs)
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



    Private Sub CargarImagenes()

        Dim archivos() As String = {
     "C:\Ingles\Imagenes_Ingles\Matilda_Normal.jpg",
     "C:\Ingles\Imagenes_Ingles\Matilda_Pregunta.jpg",
     "C:\Ingles\Imagenes_Ingles\Matilda_Seria.jpg",
     "C:\Ingles\Imagenes_Ingles\Jessica_Normal.jpg",
     "C:\Ingles\Imagenes_Ingles\Adam_Normal.jpg",
      "C:\Ingles\Imagenes_Ingles\Adam_Pregunta.jpg",
      "C:\Ingles\Imagenes_Ingles\Manon_Normal.jpg",
      "C:\Ingles\Imagenes_Ingles\Alexandre_Normal.jpg",
      "C:\Ingles\Imagenes_Ingles\Koraly_Normal.jpg"
 }

        For Each archivo As String In archivos

            Dim nombre As String = Path.GetFileName(archivo)

            Using fs As New FileStream(archivo, FileMode.Open, FileAccess.Read)

                Using imgTemp As Image = Image.FromStream(fs)

                    Imagenes(nombre) = New Bitmap(imgTemp)

                End Using

            End Using

        Next

    End Sub

    'Protected Overrides ReadOnly Property CreateParams As CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ExStyle = cp.ExStyle Or &H2000000
    '        Return cp
    '    End Get
    'End Property
    'Public Class DoubleBufferedPanel
    '    Inherits Panel
    '    Public Sub New()
    '        Me.DoubleBuffered = True
    '        Me.ResizeRedraw = True
    '    End Sub
    'End Class


#End Region

#Region "Crear Controles "
    ' 'Evaluacion
    ' txtTest = New TextBox
    ' txtTest.Name = "tst_" & dt.Rows(j).Item(0)
    ' txtTest.Font = New Font("Consolas", 11, FontStyle.Bold)

    ' If Not IsDBNull(dt.Rows(j).Item(9)) Then
    '     txtTest.Text = dt.Rows(j).Item(9)

    '     If dt.Rows(j).Item(8) = True Then
    '         txtTest.BackColor = Color.LightGreen
    '     Else
    '         txtTest.BackColor = Color.LightSalmon
    '     End If

    ' Else
    '     txtTest.BackColor = Color.BlanchedAlmond
    ' End If

    ' txtTest.BorderStyle = BorderStyle.None
    ' txtTest.Width = 1000
    ' txtTest.Location = New Point(btnAprendido.Right + 1, txtTraduccion.Bottom + 2)
    ' txtTest.Visible = False
    ' AddHandler txtTest.TextChanged, AddressOf Exam
    ' AddHandler txtTest.LostFocus, AddressOf SaveExam
    ' pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTest)

    ' 'Evaluacion Español - Ingles
    ' txtTestES = New TextBox
    ' txtTestES.Name = "tstES_" & nm
    ' txtTestES.Font = New Font("Consolas", 11, FontStyle.Bold)
    ' txtTestES.BackColor = Color.Wheat
    ' txtTestES.BorderStyle = BorderStyle.None
    ' txtTestES.Width = 500
    ' txtTestES.Location = New Point(btnAprendido.Right + 1, txtTest.Bottom + 2)
    ' txtTestES.Visible = False
    ' AddHandler txtTestES.TextChanged, AddressOf ExamES
    ' AddHandler txtTestES.LostFocus, AddressOf SaveExamES
    ' pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTestES)

    ' 'Bajar
    ' btnDown = New Button
    ' btnDown.Name = "btnDown_" & i
    ' btnDown.Width = 52 : btnDown.Height = 19 ': btnTask.Text = "Report"
    ' btnDown.Location = New Point(btnDelete.Left - 55, btnDown.Bottom + 1)
    ' btnDown.Text = "DOWN"
    ' AddHandler btnDown.Click, AddressOf MoveDown

    ' pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnDown)

    ' 'Guardar Evaluacion
    ' btnExam = New Button
    ' btnExam.Name = "btnStatus_" & dt.Rows(j).Item(0)
    ' btnExam.Width = 52 : btnExam.Height = 19
    ' btnExam.Location = New Point(btnDelete.Left - 55, btnDown.Bottom + 1)
    ' btnExam.Text = "SAVE"

    ' If dt.Rows(j).Item(8) = False Then
    '     If dt.Rows(j).Item(11) = True Then
    '         btnExam.BackColor = Color.Yellow
    '     End If
    ' End If

    ' AddHandler btnExam.Click, AddressOf SaveExam
    ' pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnExam)


    ' 'Flecha
    ' pbf = New PictureBox
    ' pbf.Name = "pbf_" & dt.Rows(j).Item(0)
    ' pbf.Width = 80
    ' pbf.Height = 80
    ' pbf.Tag = dt.Rows(j).Item(10)
    ' AddHandler pbf.Click, AddressOf CambiarTipoCon

    ' bmp = New Bitmap(80, 80)
    ' pbf.Image = bmp

    ' g = Graphics.FromImage(pbf.Image)
    ' g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

    ' If dt.Rows(j).Item(10) <> "R" Then
    '     startPoint = New Point(10, 55)
    '     endPoint = New Point(30, 55) ' La línea es horizontal si la coordenada Y es la misma

    '     Dim tipPoints As Point() = {
    'endPoint, New Point(endPoint.X - 10, endPoint.Y - 5), New Point(endPoint.X - 10, endPoint.Y + 5)}

    '     g.DrawLine(Pens.Blue, startPoint, endPoint)
    '     g.FillPolygon(Brushes.Blue, tipPoints)

    ' Else
    '     startPoint = New Point(30, 55)
    '     endPoint = New Point(10, 55) ' La línea es horizontal si la coordenada Y es la misma

    '     Dim tipPoints As Point() = {
    'endPoint, New Point(endPoint.X + 10, endPoint.Y - 5), New Point(endPoint.X + 10, endPoint.Y + 5)}

    '     g.DrawLine(Pens.Orange, startPoint, endPoint)
    '     g.FillPolygon(Brushes.Orange, tipPoints)
    ' End If

    ' pEtapa.Controls.Item("pAux_" & nm).Controls.Add(pbf)
    'Sub ActualizarVista()

    '    ' ===============================
    '    ' VALIDACIONES 🔥
    '    ' ===============================
    '    If listaGrupos Is Nothing OrElse listaGrupos.Count = 0 Then Exit Sub
    '    If poolPanels Is Nothing OrElse poolPanels.Count = 0 Then Exit Sub

    '    Dim total As Integer = listaGrupos.Count

    '    ' ===============================
    '    ' SCROLL SIZE
    '    ' ===============================
    '    pEtapa.AutoScrollMinSize = New Size(0, total * PANEL_HEIGHT)

    '    Dim scrollY As Integer = -pEtapa.AutoScrollPosition.Y
    '    Dim inicio As Integer = Math.Max(0, (scrollY \ PANEL_HEIGHT) - 3)

    '    pEtapa.SuspendLayout()

    '    For i = 0 To poolPanels.Count - 1

    '        Dim panel = poolPanels(i)
    '        Dim index = inicio + i

    '        ' ===============================
    '        ' FUERA DE RANGO 🔥 (OBLIGATORIO)
    '        ' ===============================
    '        If index < 0 OrElse index >= total Then
    '            If panel.Visible Then panel.Visible = False
    '            Continue For
    '        End If

    '        ' ===============================
    '        ' MISMO INDEX → NO REPROCESAR
    '        ' ===============================
    '        'If panel.Tag IsNot Nothing AndAlso CInt(panel.Tag) = index Then
    '        '    panel.Location = New Point(0, index * PANEL_HEIGHT)
    '        '    If Not panel.Visible Then panel.Visible = True
    '        '    Continue For
    '        'End If
    '        If panel.Tag IsNot Nothing AndAlso CInt(panel.Tag) = index Then
    '            panel.Location = New Point(0, i * PANEL_HEIGHT)
    '            If Not panel.Visible Then panel.Visible = True
    '        Else
    '            panel.Tag = index

    '            Dim grpo = listaGrupos(index)

    '            panel.Location = New Point(0, index * PANEL_HEIGHT)
    '            If Not panel.Visible Then panel.Visible = True

    '            ActualizarPanel(panel, grpo, index)
    '        End If
    '        ' ===============================
    '        ' NUEVO CONTENIDO
    '        ' ===============================
    '        panel.Tag = index

    '        Dim grupo = listaGrupos(index)

    '        panel.Location = New Point(0, index * PANEL_HEIGHT)
    '        If Not panel.Visible Then panel.Visible = True

    '        ActualizarPanel(panel, grupo, index)

    '    Next

    '    pEtapa.ResumeLayout()

    'End Sub
    Private Sub ScrollManual(sender As Object, e As ScrollEventArgs)
        ActualizarVista()
    End Sub

    Public Sub CrearControles()

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String = ""

        sqlstring = "    SELECT     dc.Det_Con,    dc.Con_Id,    dc.Det_Par,    dc.IMG AS IMG_Det,    dc.orden AS orden_det,   "
        sqlstring = sqlstring & "    d.Id,    d.IdConversacion,    d.item,    d.orden AS orden_dialogo,    d.IMG AS IMG_Dialogo,"
        sqlstring = sqlstring & "   o.TextoPlano,    o.Traduccion,    o.STL,    o.Exam,    o.foco,    o.CuentaSTL,    o.Oracion,    o.IMG AS IMG_Oracion,"
        sqlstring = sqlstring & "   o.Favorito,    o.IPA,    o.reproduccion,    o.scoreNaturalidad,    o.personaje,"
        sqlstring = sqlstring & " o.PalabrasClave, o.Id AS IdOracion, o.rate, o.masUsada, o.Tipo, dc.status, dc.Observaciones, o.voice, o.expresion"

        sqlstring = sqlstring & " FROM Det_Conversation dc"
        sqlstring = sqlstring & " INNER JOIN Tbl_Dialogos_FR d ON dc.Det_Con = d.IdConversacion"
        sqlstring = sqlstring & " INNER JOIN Oraciones_FR o ON d.IdOracion = o.Id"
        sqlstring = sqlstring & " WHERE dc.Con_Id='" & Id & "'"

        sqlstring = sqlstring & filtro
        sqlstring = sqlstring & " AND dc.Status='R'"


        sqlstring = sqlstring & " ORDER BY orden_det ,  d.item "


        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        da.SelectCommand = _comando
        dt.Clear()

        dt.PrimaryKey = New DataColumn() {dt.Columns("Id")}
        dt.AcceptChanges()


        da.Fill(dt)

        n = dt.Rows.Count

        _comando.Connection.Close()


        ' ===============================
        ' 2. AGRUPAR (AQUÍ VA 👇)
        ' ===============================
        listaGrupos = dt.AsEnumerable().GroupBy(Function(r) r("Det_Con")).ToList()
        ' 🔥 guardar para virtualización

        pEtapa.SuspendLayout()
        pEtapa.Controls.Clear()
        poolPanels.Clear()

        If dt.Rows.Count = 0 Then
            'If filtro = " AND o.STL= 0" Then
            txtFaltan.Text = "Completado"
            txtFaltan.ForeColor = Color.Green
            'End If
            Exit Sub
        End If


        ' 🔥 Calcular pool real
        Dim altoVisible As Integer = pEtapa.ClientSize.Height
        Dim visibles As Integer = Math.Ceiling(altoVisible / PANEL_HEIGHT)
        Dim poolSize As Integer = visibles + 6

        If poolSize <= 0 Then poolSize = 10

        ' 🔥 Crear pool
        For i = 0 To poolSize - 1
            Dim pAux As New PanelOptimizado()
            pAux.Width = 1850
            pAux.Height = PANEL_HEIGHT
            pAux.BackColor = Color.LightGray
            pAux.Name = i
            'pAux.Tag = i

            InicializarPanel(pAux)

            poolPanels.Add(pAux)

            pEtapa.Controls.Add(pAux)

        Next

        ' 🔥 SCROLL CORRECTO
        ' Dim totalHeight As Integer = listaGrupos.Count * PANEL_HEIGHT
        Dim totalHeight As Integer = listaGrupos.Count * (PANEL_HEIGHT + ESPACIO)
        'pEtapa.AutoScroll = True
        'pEtapa.AutoScrollMinSize = New Size(0, totalHeight)

        '' 🔥 FORZAR REFRESH REAL
        'pEtapa.AutoScroll = False
        'pEtapa.AutoScroll = True

        pEtapa.ResumeLayout()

        vScroll.Dock = DockStyle.Right
        vScroll.Width = 40
        If vScroll.Maximum < 0 Then vScroll.Maximum = 0

        vScroll.Minimum = 0
        vScroll.LargeChange = pEtapa.ClientSize.Height
        vScroll.SmallChange = PANEL_HEIGHT

        ' 🔥 ESTE ES EL FIX REAL
        'vScroll.Maximum = totalHeight - vScroll.LargeChange
        'vScroll.Maximum = Math.Max(0, totalHeight - vScroll.LargeChange + PANEL_HEIGHT)
        vScroll.Maximum = Math.Max(0, totalHeight - vScroll.LargeChange + (PANEL_HEIGHT + ESPACIO))

        If Not Me.Controls.Contains(vScroll) Then
            Me.Controls.Add(vScroll)
        End If

        vScroll.BringToFront()

        RemoveHandler vScroll.Scroll, AddressOf ScrollManual
        AddHandler vScroll.Scroll, AddressOf ScrollManual

        ActualizarVista()

    End Sub

    Sub ActualizarVista()

        If listaGrupos Is Nothing OrElse listaGrupos.Count = 0 Then Exit Sub
        If poolPanels Is Nothing OrElse poolPanels.Count = 0 Then Exit Sub

        Dim total As Integer = listaGrupos.Count

        Dim vs = pEtapa.VerticalScroll

        Dim ESPACIO As Integer = 5 ' ← separación

        Dim scrollY As Integer = vScroll.Value

        Dim alturaReal As Integer = PANEL_HEIGHT + ESPACIO
        Dim inicio As Integer = Math.Max(0, scrollY \ alturaReal)
        'Dim inicio As Integer = Math.Max(0, scrollY \ PANEL_HEIGHT)

        pEtapa.SuspendLayout()

        For i = 0 To poolPanels.Count - 1

            Dim panel = poolPanels(i)
            Dim index = inicio + i

            ' 🔥 VALIDACIÓN CRÍTICA
            If index < 0 OrElse index >= total Then
                panel.Visible = False
                Continue For
            End If

            ' panel.Location = New Point(0, i * PANEL_HEIGHT)
            ' 🔥 SOLO MOVER SI CAMBIA

            Dim nuevaY As Integer = i * (PANEL_HEIGHT + ESPACIO)

            If panel.Top <> nuevaY Then
                panel.Top = nuevaY
            End If

            If Not panel.Visible Then panel.Visible = True

            Dim data = CType(panel.Tag, PanelData)

            If data.Index <> index Then
                data.Index = index
                ' panel.BackColor = Color.LightYellow
                ActualizarPanel(panel, listaGrupos(index), index)
            End If

            'If panel Is Nothing OrElse CInt(panel.Tag) <> index Then
            '    panel.Tag = index
            '    ActualizarPanel(panel, listaGrupos(index), index)
            'End If

        Next

        pEtapa.ResumeLayout(False)

    End Sub

    Sub InicializarPanel(pAux As Panel)

        ' Dim lblIndex As New Label
        ' pAux.Controls.Add(lblIndex)

        Dim PosX As Integer = 0

        Dim items(3) As ItemPanel

        For j = 0 To 3   ' máximo 4 items
            PosX = (j * 450) + 87

            '' ===============================
            '' Imagen
            '' ===============================

            Dim pd As New PictureBox
            pd.Name = "pd_" & j
            pd.BorderStyle = BorderStyle.None
            '   pd.BackColor = Color.Black
            pd.Cursor = Cursors.Hand
            pd.Size = New Size(320, 180)
            pd.SizeMode = PictureBoxSizeMode.Zoom

            '  pd.Visible = False

            pd.BringToFront()

            AddHandler pd.Click, AddressOf CambiarImagenDialogo
            pAux.Controls.Add(pd)

            pd.Location = New Point(PosX, 26)

            '' ===============================
            '' Reproductor
            '' ===============================
            ' Dim vid As New AxWindowsMediaPlayer
            ' vid.Name = "vid_" & j

            ' vid.Size = New Size(300, 200)
            ' vid.windowlessVideo = False
            '  vid.enableContextMenu = False
            ' vid.uiMode = "none"
            ' vid.settings.autoStart = False
            ' vid.stretchToFit = True

            ' pAux.Controls.Add(vid)

            ' vid.Location = New Point(PosX, 26)



            '' ===============================
            '' BOTÓN AUDIO (reutilizable)
            '' ===============================
            Dim pAudio As New CircularPictureBox
            pAudio.Name = "pAudio_" & j
            pAudio.Size = New Size(60, 60)
            pAudio.SizeMode = PictureBoxSizeMode.Zoom
            pAudio.Cursor = Cursors.Hand
            pAudio.BackColor = Color.LightGray
            ' AddHandler pAudio.Click, AddressOf CambiarImagen
            AddHandler pAudio.MouseHover, AddressOf ReproducirAudio
            AddHandler pAudio.Click, AddressOf ReproducirAudio
            AddHandler pAudio.LostFocus, AddressOf QuitarMouse

            pAux.Controls.Add(pAudio)

            ' pAudio.Visible = True
            'pAudio.Image = imgSonido
            pAudio.Location = New Point(pd.Left - 75, pAux.Bottom - 120)
            '===========
            'Test
            '===========

            'Dim test As New TextBox
            'test.Name = "test_" & j 
            'test.BorderStyle = BorderStyle.FixedSingle
            'test.Font = New Font("Consolas", 15, FontStyle.Bold)
            'test.BackColor = Color.LightGreen
            'test.Text = "TEST"
            'test.Height = 40
            'test.Width = 50
            'test.BringToFront()

            'test.Visible = True

            'test.Location = New Point(1, 1)

            'pAux.Controls.Add(test)


            '' ===============================
            '' Texto en ingles
            '' ===============================
            Dim txt As New RichTextBox
            txt.Name = "txt_" & j
            txt.AutoSize = False
            txt.MaximumSize = New Size(350, 0)
            txt.BorderStyle = BorderStyle.None
            txt.Font = New Font("Consolas", 15, FontStyle.Bold)
            txt.BackColor = Color.LightGray
            txt.WordWrap = True
            txt.SelectionAlignment = HorizontalAlignment.Left

            txt.Height = txt.PreferredHeight
            txt.Width = 350

            txt.Multiline = True
            txt.Visible = False

            txt.Location = New Point(pAudio.Right + 10, pd.Bottom + 5)

            pAux.Controls.Add(txt)

            ' ===============================
            ' TRADUCCIÓN
            ' ===============================

            Dim traduccion As New RichTextBox
            traduccion.Name = "trad_" & j

            traduccion.AutoSize = True
            traduccion.ForeColor = Color.Gray
            traduccion.BackColor = Color.LightGray

            traduccion.MaximumSize = New Size(400, 0)
            traduccion.Font = New Font("Arial", 10)
            traduccion.Font = New System.Drawing.Font("Arial", 10, FontStyle.Regular)

            traduccion.BorderStyle = BorderStyle.None

            traduccion.Width = 300
            traduccion.Height = traduccion.PreferredHeight
            traduccion.Visible = False

            ' traduccion.Location = New Point(txt.Left + 5, txt.Bottom + 1)

            pAux.Controls.Add(traduccion)

            '' ===============================
            '' btnLeer
            '' ===============================

            Dim btnLeer As New Button
            btnLeer.Name = "btnLeer_" & j
            btnLeer.Width = 25 : btnLeer.Height = 25
            btnLeer.Cursor = Cursors.Hand
            btnLeer.Location = New Point(pd.Left - 15, 1)
            btnLeer.Visible = True
            AddHandler btnLeer.Click, AddressOf AbrirDetalle
            pAux.Controls.Add(btnLeer)
            '  btnLeer.BackColor = Color.Green

            ' ===============================
            '' Show / Hide
            '' ===============================
            Dim btnHide As New Button
            btnHide.Name = "btnHide_" & j
            btnHide.Width = 25 : btnHide.Height = 25 ': btnTask.Text = "Report"
            btnHide.Image = ImageList1.Images.Item(1)
            btnHide.Text = "-"
            btnHide.Cursor = Cursors.Hand
            AddHandler btnHide.Click, AddressOf Show
            btnHide.Location = New Point(btnLeer.Right + 1, 1)

            pAux.Controls.Add(btnHide)


            ' ===============================
            'Aprendido
            ' ===============================
            Dim btnAprendido As Button
            btnAprendido = New Button
            btnAprendido.Name = "btnAprendido_" & j
            btnAprendido.Width = 25 : btnAprendido.Height = 25
            btnAprendido.Cursor = Cursors.Hand
            btnAprendido.Text = "SI"

            AddHandler btnAprendido.Click, AddressOf StatusControl
            btnAprendido.Location = New Point(btnHide.Right + 1, 1)
            btnAprendido.Visible = True

            'If Not IsDBNull(row("Reproduccion")) Then
            '    If row("Reproduccion") <= 0 Then
            '        myPen = New Pen(Color.LightSalmon, 2)
            '        pAudio.BackColor = Color.LightSalmon
            '    Else
            '        myPen = New Pen(Color.LimeGreen, 2)
            '        ' txtTexto.BackColor = ColorWatsap
            '        pAudio.BackColor = ColorWatsap
            '    End If
            'End If
            ' btnAprendido.BackColor = Color.LightGray
            pAux.Controls.Add(btnAprendido)


            '===============================
            'Falta
            ' ===============================

            Dim btnFalta As New Button
            btnFalta.Name = "btnFalta_" & j
            btnFalta.Width = 30 : btnFalta.Height = 25
            btnFalta.Cursor = Cursors.Hand
            btnFalta.Text = "No"

            AddHandler btnFalta.Click, AddressOf StatusControl

            btnFalta.Location = New Point(btnAprendido.Right + 1, 1)
            btnFalta.Visible = True
            btnFalta.BackColor = Color.LightGray

            pAux.Controls.Add(btnFalta)

            ' ===============================
            'Mover
            ' =============================== 
            Dim btnMover As New Button
            btnMover.Name = "btnMover_" & j
            btnMover.Width = 25 : btnMover.Height = 25
            btnMover.Cursor = Cursors.Hand
            btnMover.Text = "S"
            '  btnMover.BackColor = Color.LightGray
            ' btnMover.Tag = rw.Item(0)

            AddHandler btnMover.Click, AddressOf MoverDialogo

            btnMover.Location = New Point(btnFalta.Right + 1, 1)
            btnMover.Visible = True

            pAux.Controls.Add(btnMover)

            ' ===============================
            'Delete de Tbl_dialogos
            ' ===============================  
            Dim btnDelete As New Button

            btnDelete.Name = "btnDelete_" & j
            btnDelete.Width = 25 : btnDelete.Height = 25
            btnDelete.Text = "X"
            'btnDelete.Tag = rw.Item(0)
            btnDelete.Cursor = Cursors.Hand
            AddHandler btnDelete.Click, AddressOf Delete
            ' btnDelete.BackColor = Color.Red

            btnDelete.Visible = True
            btnDelete.Location = New Point(btnMover.Right + 1, 1)

            pAux.Controls.Add(btnDelete)

            ' ===============================
            'Editar
            ' ===============================  

            Dim btnEditar As New Button
            btnEditar.Name = "btnTask_" & j
            btnEditar.Width = 25 : btnEditar.Height = 25 ': btnTask.Text = "Report"
            btnEditar.Text = "Edit"
            'btnEditar.Tag = rw.Item(0)
            AddHandler btnEditar.Click, AddressOf Editar
            btnEditar.Visible = True
            btnEditar.Location = New Point(btnDelete.Right + 0.5, 1)
            ' btnEditar.BackColor = Color.Red

            pAux.Controls.Add(btnEditar)


            ' ===============================
            ' Voz
            ' =============================== 
            'Dim btnVoz As New Button
            'btnVoz.Name = "btnVoz_" & j
            'btnVoz.Width = 25 : btnVoz.Height = 25 ': btnTask.Text = "Report"
            'btnVoz.Text = "0"

            ''btnVoz.Tag = rw.Item(0)
            'AddHandler btnVoz.Click, AddressOf SeleccionarPersona
            'pAux.Controls.Add(btnVoz)

            'btnVoz.Location = New Point(btnEditar.Right + 0.5, 1)
            'btnVoz.Visible = True
            ' ===============================
            'Cambiar Status de Conversacion
            ' ===============================  
            Dim btnStatus As New Button

            btnStatus.Name = "btnStatus_" & j
            btnStatus.Width = 25 : btnStatus.Height = 25
            btnStatus.Text = "N"
            btnStatus.BackColor = Color.LightGreen
            btnStatus.Cursor = Cursors.Hand
            AddHandler btnStatus.Click, AddressOf CambiarStatusConversacion

            btnStatus.Visible = True
            btnStatus.Location = New Point(btnEditar.Right + 1, 1)


            pAux.Controls.Add(btnStatus)

            ' ===============================
            ' Personaje > cambio a Avatar
            ' =============================== 
            Dim personaje As New Button
            personaje.Name = "txtPersonaje_" & j
            personaje.Font = New System.Drawing.Font("Consolas", 10, FontStyle.Regular)
            'personaje.TextAlign = ContentAlignment.MiddleLeft
            ' AddHandler txtScore.Click, AddressOf SeleccionarPersona
            personaje.Width = 25 : personaje.Height = 25
            personaje.Text = "-"
            personaje.Location = New Point(btnStatus.Right + 1, 1)
            ' personaje.BackColor = Color.LightGray
            'personaje.BackColor = Color.Red
            personaje.Cursor = Cursors.Hand
            AddHandler personaje.Click, AddressOf CambiarPersonaje

            pAux.Controls.Add(personaje)

            ' ===============================
            ' Imagen Default
            ' =============================== 
            Dim imagen As New Button
            imagen.Name = "txtimagen_" & j
            imagen.Font = New System.Drawing.Font("Consolas", 10, FontStyle.Regular)
            imagen.Width = 25 : imagen.Height = 25
            'imagen.TextAlign = ContentAlignment.MiddleLeft
            ' AddHandler txtScore.Click, AddressOf SeleccionarPersona
            'imagen.Width = 60
            imagen.Text = "Like"
            imagen.Location = New Point(personaje.Right + 2, 1)
            ' personaje.BackColor = Color.Red
            imagen.Cursor = Cursors.Hand
            AddHandler imagen.Click, AddressOf CambiarImagenDefault

            pAux.Controls.Add(imagen)
            ' ===============================
            ' Imagen Default
            ' =============================== 
            Dim pregunta As New Button
            pregunta.Name = "txtPregunta_" & j
            pregunta.Font = New System.Drawing.Font("Consolas", 10, FontStyle.Regular)
            pregunta.Width = 25 : pregunta.Height = 25

            ' pregunta.Width = 60
            pregunta.Text = "Question"
            pregunta.Location = New Point(imagen.Right + 2, 1)
            ' personaje.BackColor = Color.Red
            pregunta.Cursor = Cursors.Hand
            AddHandler pregunta.Click, AddressOf CambiarImagenDefault

            pAux.Controls.Add(pregunta)
            ' ===============================
            ' subir
            ' =============================== 
            Dim subir As New Button
            subir.Name = "txtsubir_" & j
            subir.Font = New System.Drawing.Font("Consolas", 10, FontStyle.Regular)
            subir.Width = 25 : personaje.Height = 25

            ' pregunta.Width = 60
            subir.Text = "^"
            subir.Location = New Point(pregunta.Right + 2, 1)
            ' personaje.BackColor = Color.Red
            subir.Cursor = Cursors.Hand
            AddHandler subir.Click, AddressOf subirDialogo

            pAux.Controls.Add(subir)
            ' ===============================
            ' Favorito
            ' =============================== 
            Dim Favorito As New PictureBox
            Favorito.Name = "btnFavorito_" & j
            Favorito.Width = 20 : Favorito.Height = 20 ': btnTask.Text = "Report"
            'Favorito.BackColor = Color.LightYellow
            Favorito.Cursor = Cursors.Hand
            'Favorito.Image = ImageList1.Images(5)
            'Favorito.SizeMode = PictureBoxSizeMode.Zoom

            Favorito.Location = New Point(subir.Right + 0.5, 1)
            Favorito.Visible = True
            ' Favorito.BackColor = Color.Red

            AddHandler Favorito.Click, AddressOf CambiarFavorito
            pAux.Controls.Add(Favorito)

            ' ===============================
            ' Score
            ' =============================== 
            Dim Score As New Label
            Score.Name = "txtScore_" & j
            Score.Font = New System.Drawing.Font("Consolas", 10, FontStyle.Regular)
            Score.TextAlign = ContentAlignment.MiddleCenter
            ' AddHandler txtScore.Click, AddressOf SeleccionarPersona
            Score.AutoSize = True
            ' Score.BackColor = Color.Red
            AddHandler Score.Click, AddressOf CambiarScore
            Score.Cursor = Cursors.Hand
            Score.Location = New Point(Favorito.Right + 2, Favorito.Top + 5)
            Score.Visible = True

            pAux.Controls.Add(Score)


            ' ===============================
            ' Reproducciones
            ' ===============================' 
            Dim txtReproduccion As New Label
            txtReproduccion.Name = "txtReproduccion_" & j
            'txtReproduccion.Width = 30 : btnVoz.Height = 25 ': btnTask.Text = "Report"
            ' txtReproduccion.BorderStyle = BorderStyle.Fixed3D
            txtReproduccion.Font = New System.Drawing.Font("Consolas", 18, FontStyle.Bold)
            txtReproduccion.TextAlign = ContentAlignment.MiddleCenter
            txtReproduccion.AutoSize = True


            pAux.Controls.Add(txtReproduccion)

            txtReproduccion.Location = New Point(pAudio.Left + 8, pAudio.Bottom + 8)
            txtReproduccion.Visible = True



            'pAux.Controls.Add(pd)
            'pAux.Controls.Add(txt)
            'pAux.Controls.Add(pAudio)

            '=========================
            ' 🔥 guardar referencias
            '=========================
            items(j) = New ItemPanel With {
                .pd = pd,
                .txt = txt,
                .trad = traduccion,
                .audio = pAudio,
                .btnHide = btnHide,
                .favorito = Favorito,
                .reproduccion = txtReproduccion,
                .score = Score,
                .aprendido = btnAprendido,
                .falta = btnFalta,
                .editar = btnEditar,
                .status = btnStatus,
                .personaje = personaje,
                .imagen = imagen,
                .pregunta = pregunta,
                .subir = subir,
                .delete = btnDelete,
                .leer = btnLeer
                }


        Next

        ' 🔥 guardar TODO en Tag
        pAux.Tag = New PanelData With {
            .Index = -1,
            .Items = items,
            .Contexto = contexto
            }

    End Sub

    Sub ActualizarPanel(pAux As Panel, grupo As IGrouping(Of Object, DataRow), index As Integer)

        ' pAux.Controls.Clear()
        pAux.SuspendLayout()

        Dim total As Integer = listaGrupos.Count
        Dim numero As Integer = index + 1

        Dim lblIndex As Label

        If pAux.Controls.ContainsKey("lblIndex") Then
            lblIndex = CType(pAux.Controls("lblIndex"), Label)
        Else
            lblIndex = New Label
            lblIndex.Name = "lblIndex" & index
            lblIndex.Location = New Point(5, 5)
            lblIndex.Size = New Size(59, 20)
            ' lblIndex.BackColor = Color.Yellow

            pAux.Controls.Add(lblIndex)
        End If

        pAux.Name = index

        lblIndex.BringToFront()
        lblIndex.Visible = True
        lblIndex.Text = (index + 1) & " / " & listaGrupos.Count


        '=======================
        ' Contexto
        '=======================
        Dim contexto As String = grupo.First()("Observaciones").ToString()

        Dim pContexto As PictureBox = TryCast(pAux.Controls("pContexto"), PictureBox)
        Dim lblTexto As Label = TryCast(pAux.Controls("lblTexto"), Label)

        If contexto <> "" Then

            If pContexto Is Nothing Then
                pContexto = New PictureBox
                pContexto.Name = "pContexto"
                pContexto.Location = New Point(pAux.Right - 250, 45)
                'pContexto.Size = New Size(300, 200)
                pContexto.SizeMode = PictureBoxSizeMode.Zoom
                pAux.Controls.Add(pContexto)
            End If

            Dim ruta As String = "C:\Ingles\Imagenes_Ingles\contexto\" & contexto & ".png"
            pContexto.Image = GetImagen(ruta)
            pContexto.Visible = True
            pContexto.BringToFront()

            If lblTexto Is Nothing Then
                lblTexto = New Label With {
                    .Name = "lblTexto",
                    .AutoSize = True,
                    .Font = New Font("Arial", 9, FontStyle.Regular),
                    .TextAlign = ContentAlignment.MiddleCenter
                }
                pAux.Controls.Add(lblTexto)
            End If

            lblTexto.Text = contexto
            lblTexto.Location = New Point(
                pContexto.Left + (pContexto.Width - lblTexto.Width) \ 2,
                pContexto.Bottom + 5
            )
            lblTexto.Visible = True

        Else
            ' 🔥 AQUÍ ESTÁ LA CLAVE
            If pContexto IsNot Nothing Then pContexto.Visible = False
            If lblTexto IsNot Nothing Then lblTexto.Visible = False
        End If

        Dim i As Integer = 0

        Dim data = CType(pAux.Tag, PanelData)
        Dim items = data.Items

        For Each row In grupo

            If i > 3 Then Exit For ' 🔥 CRÍTICO

            Dim item = items(i)

            Dim pd = item.pd
            Dim txt = item.txt
            Dim trad = item.trad
            Dim pAudio = item.audio
            Dim fav = item.favorito
            Dim score = item.score
            Dim reproduccion = item.reproduccion
            Dim aprendido = item.aprendido
            Dim falta = item.falta
            Dim editar = item.editar
            Dim hide = item.btnHide
            Dim status = item.status
            Dim txtpersonaje = item.personaje
            Dim txtImagen = item.imagen
            Dim pregunta = item.pregunta
            Dim subir = item.subir
            Dim delete = item.delete
            Dim leer = item.leer

            ' ===============================
            'PERSONAJE
            ' ===============================

            If Not IsDBNull(row("personaje")) Then
                personaje = row("personaje")
            End If

            'Try
            If personaje = "1" Then  'Femenino
                ' RutaImagenes = RutaImagenesFemenino
                RutaAudios = RutaAudiosFemenino
            ElseIf personaje = "2" Then
                'Masculino
                ' RutaImagenes = RutaImagenesMasculino
                RutaAudios = RutaAudiosMasculino
            Else
                'RutaImagenes = RutaImagenesEstandar
                RutaAudios = RutaAudiosFemenino
            End If

            Console.WriteLine(personaje)


            ' ===============================
            ' Imagen 
            '' ===============================
            'If Not IsDBNull(row("IMG_Oracion")) Then
            If Not IsDBNull(row("voice")) Then
                Dim ruta As String = RutaImagenes & row("voice") & "_" & row("expresion") & ".jpg"
                Dim nuevaImagen = GetImagen(ruta)

                If pd.Image IsNot nuevaImagen Then
                    pd.Image = nuevaImagen
                End If
            End If

            ' pd.Size = New Size(120, 110)
            pd.Text = personaje

            pd.Tag = row("Id")

            ' ===============================
            ' BOTÓN AUDIO 
            '' ===============================
            leer.Tag = row("Id")

            pAudio.Tag = row("Id")

            previousHeight = 0

            'Index
            'If row("Id") = Seleccionado Then
            '    lblIndex.ForeColor = Color.Red
            'End If

            Dim nuevaImg As Image

            If File.Exists(RutaAudiosFemenino3 & row("IdOracion") & ".mp3") Then
                nuevaImg = imgSonido
            Else

                If File.Exists(RutaAudiosFemenino2 & row("IdOracion") & ".mp3") Then ' El archivo existe
                    nuevaImg = imgSonido
                Else
                    nuevaImg = imgMute
                End If
            End If

            If pAudio.Image IsNot nuevaImg Then
                pAudio.Image = nuevaImg
            End If


            '' ===============================
            ' Texto en ingles
            ' ===============================

            txt.Tag = "txt_" & row("Id")

            If Not IsDBNull(row("TextoPlano")) Then
                txt.Text = row("TextoPlano")
                If row("TextoPlano") = "I like red" Then
                    ' MsgBox("")
                End If
            Else
                txt.Text = "NULL"
            End If

            If txt.Text.Length > 0 Then
                ' Calcular la altura necesaria para todo el contenido
                Dim numLines As Integer = txt.GetLineFromCharIndex(txt.Text.Length - 1) + 1
                Dim newHeight As Integer = numLines * txt.Font.Height + txt.Margin.Vertical

                If newHeight <> previousHeight Then
                    txt.Height = newHeight
                    previousHeight = newHeight
                End If
            Else
                ' Si está vacío, restablecer a la altura de una línea
                txt.Height = txt.Font.Height + txt.Margin.Vertical
                previousHeight = txt.Height
            End If

            If row("Tipo") = "Q" Then
                txt.ForeColor = Color.DarkBlue
            ElseIf row("Tipo") = "R" Then
                txt.ForeColor = Color.DarkViolet
            ElseIf row("Tipo") = "O" Then
                txt.ForeColor = Color.SaddleBrown
            Else
                txt.ForeColor = Color.Black
            End If
            '' ===============================
            ' Traduccion
            ' ===============================
            If Not IsDBNull(row("Traduccion")) Then
                trad.Text = row("Traduccion")
                'Else
                '    txt.Text = "NULL"
            End If
            trad.Location = New Point(txt.Left + 5, txt.Bottom + 1)

            ' ===============================
            ''  Favorito
            ' ===============================
            fav.Tag = row("Id")
            If Not IsDBNull(row("Favorito")) Then
                fav.Text = row("Favorito")
                If row("Favorito") = "R" Then
                    fav.Image = ImageList1.Images(6)
                ElseIf row("Favorito") = "S" Then
                    fav.Image = ImageList1.Images(4)
                Else
                    fav.Image = ImageList1.Images(5)
                End If
            End If

            ' ===============================
            ' Reproducciones
            ' ===============================' 
            reproduccion.Text = row("Reproduccion")
            If row("Reproduccion") > 29 Then
                reproduccion.ForeColor = Color.Green
            Else
                reproduccion.ForeColor = Color.Salmon
            End If
            reproduccion.Tag = row("Id")


            ' ===============================
            ' Show / Hide
            '' ===============================
            hide.Tag = row("Id")
            hide.Text = "-"

            '' ===============================
            '' Status  Aprendido / Falta
            ' ===============================
            aprendido.Tag = row("Id")

            falta.Tag = row("Id")

            If row("STL") = True Then
                STL = row("STL")
                aprendido.BackColor = Color.LightGreen
                falta.BackColor = Color.LightGray
                pAudio.BackColor = ColorWatsap

                Aprendidos += 1
            Else
                falta.BackColor = Color.LightSalmon
                aprendido.BackColor = Color.LightGray
                pAudio.BackColor = Color.LightSalmon
            End If

            ' ===============================
            ' Editar
            '' ===============================
            editar.Tag = row("Id")

            ' ===============================
            ' btn Leer
            '' ===============================
            If Not IsDBNull(row("MasUsada")) Then
                ' leer.Text = Mid(row("Tipo"), 1, 1)
                If row("MasUsada") = "S" Then
                    leer.BackColor = Color.Green
                End If
            End If

            ' ===============================
            ' Status Conversaicon
            ' ===============================
            status.Tag = row("Id")
            status.Text = row("status")



            '================
            ' Personaje
            '================
            txtpersonaje.Tag = row("Id")
            txtpersonaje.Text = personaje
            ' txtpersonaje.BackColor = Color.LightGray
            If row("Id") = LastIdItem Then
                'txtpersonaje.BackColor = Color.Yellow
                '  pAudio.Image = imgSonido
                ' pAudio.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\animacion.gif")
                pAudio.Image = Image.FromFile("C:\Ingles\Imagenes_Ingles\sonido.gif")
            End If
            '================
            ' Imagen
            '================
            txtImagen.Tag = row("Id")

            '================
            ' Pregunta
            '================
            pregunta.Tag = row("Id")

            ' ===============================
            ' Subir
            ' =============================== 
            subir.Tag = row("Id")

            ' ===============================
            ' Delete
            '' ===============================
            delete.Tag = row("Id")

            ' ===============================
            ' Score
            ' =============================== 
            score.Tag = row("Id")
            If Not IsDBNull(row("rate")) Then
                score.Text = row("rate")
                score.ForeColor = Color.Green

            Else
                score.Text = "NULL"
                score.ForeColor = Color.Gray
            End If


            ' ===============================
            ' CONTROLES EXISTENTES
            ' ===============================
            If cmdMostrarTexto.Text = "Mostrar Texto" Then
                txt.Visible = False
            Else
                txt.Visible = True
            End If

            If cmdMostrarTrad.Text = "Mostrar Trad" Then
                trad.Visible = False
            Else
                trad.Visible = True
            End If

            pd.Visible = True
            pAudio.Visible = True

            fav.Visible = True
            reproduccion.Visible = True
            txtpersonaje.Visible = True

            i = i + 1

        Next

        'Limpiar basura

        For j = i To 3

            Dim pd = CType(pAux.Controls("pd_" & j), PictureBox)
            Dim pAudio = CType(pAux.Controls("pAudio_" & j), CircularPictureBox)
            Dim txt = CType(pAux.Controls("txt_" & j), RichTextBox)
            Dim trad = CType(pAux.Controls("trad_" & j), RichTextBox)
            Dim reproduccion = CType(pAux.Controls("txtreproduccion_" & j), Label)
            Dim aprendido = CType(pAux.Controls("btnaprendido_" & j), Button)
            Dim falta = CType(pAux.Controls("btnfalta_" & j), Button)
            Dim fav = CType(pAux.Controls("btnfavorito_" & j), PictureBox)
            Dim txtpersonaje = CType(pAux.Controls("txtpersonaje_" & j), Button)

            pd.Visible = False
            pAudio.Visible = False
            txt.Visible = False
            trad.Visible = False
            reproduccion.Visible = False
            aprendido.BackColor = Color.LightGray
            falta.BackColor = Color.LightGray
            fav.Visible = False
            txtpersonaje.Visible = False
            'pic.Visible = False

        Next



        ' ===============================
        ' IPA
        '===============================
        '    Dim txtIPA As New Label
        '    txtIPA.Name = "ipa"
        '    txtIPA.AutoSize = True
        '    txtIPA.Font = New Font("Consolas", 10)
        '    txtIPA.ForeColor = Color.Purple
        '    txtIPA.Location = New Point(220, 180)

        '    If Not IsDBNull(dtDialogos.Rows(j).Item(13)) Then
        '        txtIPA.Text = dtDialogos.Rows(j).Item(13)
        '    End If
        '    txtIPA.BorderStyle = BorderStyle.None
        '    txtIPA.Font = New System.Drawing.Font("Consolas", 10, FontStyle.Regular)
        '    txtIPA.ForeColor = Color.Purple
        '    
        '    txtIPA.Width = 300
        '    txtIPA.Height = txtTexto.PreferredHeight
        '    txtIPA.Location = New Point(txtTexto.Left + 5, txtTexto.Bottom + 1)
        '    pAux.Controls.Add(txtIPA)
        ''''aGREGAR
        ' pAux.SuspendLayout()
        pAux.ResumeLayout(True)

    End Sub

    Sub ActualizarPanelNew(pAux As Panel, grupo As IGrouping(Of Object, DataRow), index As Integer)

        pAux.SuspendLayout()

        Dim total As Integer = listaGrupos.Count
        Dim numero As Integer = index + 1

        ' ===============================
        ' HEADER (SIN ContainsKey 🔥)
        ' ===============================
        Dim lblIndex = CType(pAux.Controls("lblIndex"), Label)
        'lblIndex.Text = numero & " / " & total

        ' ===============================
        ' ITEMS
        ' ===============================
        Dim i As Integer = 0

        For Each row In grupo

            If i > 1 Then Exit For ' ajustado a tu InicializarPanel (0–1)

            Dim pd = CType(pAux.Controls("pd_" & i), PictureBox)
            Dim pAudio = CType(pAux.Controls("pAudio_" & i), CircularPictureBox)
            Dim txt = CType(pAux.Controls("txt_" & i), RichTextBox)
            Dim txtScore = CType(pAux.Controls("txtScore_" & i), Label)
            Dim txtRep = CType(pAux.Controls("txtRep_" & i), Label)
            Dim btn = CType(pAux.Controls("btn_" & i), Button)

            ' ===============================
            ' SOLO CAMBIAR SI ES NECESARIO 🔥
            ' ===============================
            If Not pd.Visible Then pd.Visible = True
            ' If Not pAudio.Visible Then pAudio.Visible = True
            'If Not txt.Visible Then txt.Visible = True
            'If Not txtScore.Visible Then txtScore.Visible = True
            'If Not txtRep.Visible Then txtRep.Visible = True
            ' If Not btn.Visible Then btn.Visible = True

            ' ===============================
            ' POSICIONES
            ' ===============================
            Dim baseX As Integer = 80 + (i * 450)
            Dim baseY As Integer = 30

            pd.Location = New Point(baseX, baseY)
            ' pAudio.Location = New Point(baseX - 75, baseY + 100)
            ' txt.Location = New Point(baseX + 130, baseY + 110)

            ' ===============================
            ' DATOS
            ' ===============================
            ' txt.Text = row("TextoPlano")
            ' txtScore.Text = row("Id")

            'If Not IsDBNull(row("Reproduccion")) Then
            '    txtRep.Text = row("Reproduccion")
            'Else
            '    txtRep.Text = ""
            'End If

            ' btn.Tag = row("Id")

            i += 1

        Next

        ' ===============================
        ' OCULTAR SOBRANTES 🔥
        ' ===============================
        For j = i To 1

            CType(pAux.Controls("pd_" & j), PictureBox).Visible = False
            ' CType(pAux.Controls("pAudio_" & j), CircularPictureBox).Visible = False
            'CType(pAux.Controls("txt_" & j), RichTextBox).Visible = False
            ' CType(pAux.Controls("txtScore_" & j), Label).Visible = False
            'CType(pAux.Controls("txtRep_" & j), Label).Visible = False
            'CType(pAux.Controls("btn_" & j), Button).Visible = False

        Next

        pAux.ResumeLayout()

    End Sub

    Sub InicializarPanelNuevo(pAux As Panel)

        pAux.SuspendLayout()

        For i = 0 To 1   ' máximo 2 items

            Dim baseX As Integer = 80 + (i * 450)
            Dim baseY As Integer = 30

            ' ===============================
            ' IMAGEN
            ' ===============================
            Dim pd As New PictureBox
            pd.Name = "pd_" & i
            pd.Size = New Size(120, 110)
            pd.Location = New Point(baseX, baseY)
            pd.SizeMode = PictureBoxSizeMode.Zoom
            pd.BorderStyle = BorderStyle.Fixed3D
            pd.Visible = False
            pAux.Controls.Add(pd)

            '' ===============================
            '' AUDIO
            '' ===============================
            'Dim pAudio As New CircularPictureBox
            'pAudio.Name = "pAudio_" & i
            'pAudio.Size = New Size(60, 60)
            'pAudio.Location = New Point(baseX - 75, baseY + 100)
            'pAudio.Visible = False

            'pAux.Controls.Add(pAudio)

            '' ===============================
            '' TEXTO
            '' ===============================
            'Dim txt As New RichTextBox
            'txt.Name = "txt_" & i
            'txt.Width = 300
            'txt.Height = 60
            'txt.Location = New Point(baseX + 130, baseY + 110)
            'txt.BorderStyle = BorderStyle.None
            'txt.BackColor = Color.LightGray
            'txt.ReadOnly = True
            'txt.Visible = False
            'pAux.Controls.Add(txt)

            '' ===============================
            '' SCORE
            '' ===============================
            'Dim txtScore As New Label
            'txtScore.Name = "txtScore_" & i
            'txtScore.Size = New Size(40, 20)
            'txtScore.Location = New Point(baseX - 60, baseY + 140)
            'txtScore.Visible = False
            'pAux.Controls.Add(txtScore)

            '' ===============================
            '' REPRODUCCION
            '' ===============================
            'Dim txtRep As New Label
            'txtRep.Name = "txtRep_" & i
            'txtRep.Location = New Point(baseX - 60, baseY + 165)
            'txtRep.Visible = False

            'AddHandler txtRep.Click, AddressOf CambiarPersonaje

            'pAux.Controls.Add(txtRep)

            '' ===============================
            '' BOTÓN
            '' ===============================
            'Dim btn As New Button
            'btn.Name = "btn_" & i
            'btn.Size = New Size(30, 25)
            'btn.Location = New Point(baseX, 5)
            'btn.Text = "SI"
            'btn.Visible = False

            'AddHandler btn.Click, AddressOf StatusControl

            'pAux.Controls.Add(btn)

        Next

        pAux.ResumeLayout()

    End Sub

    Sub CrearMasPanels(visibles As Integer)

        Dim actuales As Integer = poolPanels.Count

        For i = actuales To visibles - 1

            Dim pAux As New PanelOptimizado()
            pAux.Width = 1850
            pAux.Height = PANEL_HEIGHT
            pAux.BackColor = Color.LightGray

            poolPanels.Add(pAux)
            pEtapa.Controls.Add(pAux)

        Next

    End Sub

    Function GetImagen(ruta As String) As Image
        If Not cacheImagenes.ContainsKey(ruta) Then
            If IO.File.Exists(ruta) Then
                Using temp As Image = Image.FromFile(ruta)
                    cacheImagenes(ruta) = New Bitmap(temp) ' 🔥 importante
                End Using
            Else
                cacheImagenes(ruta) = New Bitmap(My.Resources._default)
            End If
        End If
        Return cacheImagenes(ruta)
    End Function

    Function CargarImagenSeguro(ruta As String) As Image

        Dim bytes = IO.File.ReadAllBytes(ruta)

        Using ms As New IO.MemoryStream(bytes)
            Using temp As Image = Image.FromStream(ms)
                Return New Bitmap(temp) ' 🔥 CLAVE
            End Using
        End Using

    End Function

    Sub CrearEstructuraPanel(pAux As Panel)

    End Sub
    'Public Sub CrearControlesFaltantes()
    '    Dim pAux As Panel
    '    Dim txtTexto As RichTextBox

    '    Dim txtCuenta As Label
    '    Dim txtCuentaDialogos As Label
    '    Dim txtIdDialogo As Label
    '    Dim txtFecha As Label
    '    Dim txtTraduccion As Label
    '    Dim txtIPA As Label
    '    Dim txtReproduccion As Label
    '    Dim btnSolution As Button
    '    Dim btnUp As Button
    '    Dim btnDown As Button
    '    Dim btnDelete As Button
    '    Dim btnHide As Button
    '    Dim btnEditar As Button
    '    Dim btnAprendido As Button
    '    Dim btnFalta As Button
    '    Dim btnExam As Button
    '    Dim btnMover As Button
    '    Dim btnMoverDetalle As Button
    '    Dim btnEliminar As Button
    '    Dim btnLeer As Button
    '    Dim btnVoz As Button
    '    Dim btnTransferir As Button
    '    Dim btnMoverNuevo As Button
    '    Dim btnRecibir As Button
    '    Dim PicFavorito As PictureBox
    '    Dim btnAgregar As Button

    '    Dim txtParam As Label
    '    Dim btnAuxNo As Label
    '    Dim txtTest As TextBox
    '    Dim txtTestES As TextBox

    '    Dim yPos As Integer
    '    Dim xPos As Integer
    '    Dim lblY As Integer

    '    Dim ds As New DataSet
    '    Dim dt As New DataTable
    '    Dim da As New SqlDataAdapter
    '    Dim criterio As String
    '    Dim DatosTickets As DataTable
    '    Dim param As String = ""
    '    Dim i As Integer
    '    Dim ticketId, ticketTipo As String

    '    Dim usuarios As List(Of String)
    '    Dim fechas As List(Of String)
    '    Dim Comentarios As List(Of String)
    '    Dim parametros As List(Of String)
    '    Dim x As Integer

    '    Dim _comando As SqlCommand = MetodosDatos.CrearComando()
    '    Dim sqlstring As String = ""

    '    pEtapa.Visible = False

    '    sqlstring = "SELECT        Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Det_Conversation.Det_Person, Det_Conversation.Det_Par, Det_Conversation.IMG, Oraciones_fr.STL"
    '    sqlstring = sqlstring & " FROM            Oraciones_fr INNER JOIN"
    '    sqlstring = sqlstring & "                       Dialogos ON Oraciones.Id = Dialogos.OracionId INNER JOIN"
    '    sqlstring = sqlstring & "                      Det_Conversation ON Dialogos.DetConversacion = Det_Conversation.Det_Con"
    '    sqlstring = sqlstring & " GROUP BY Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Det_Conversation.Det_Person, Det_Conversation.Det_Par, Det_Conversation.IMG, Oraciones.STL"
    '    sqlstring = sqlstring & " HAVING        (Det_Conversation.Con_Id = '" & Id & "')  AND (Oraciones.STL = 0)"

    '    sqlstring = sqlstring & " ORDER BY Det_Conversation.Det_Orden"

    '    'sqlstring = " SELECT        Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Det_Conversation.Det_Person, Det_Conversation.Det_Par, Det_Conversation.IMG, Oraciones.STL"
    '    'sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
    '    'sqlstring = sqlstring & "                       Dialogos ON Det_Conversation.Det_Con = Dialogos.DetConversacion INNER JOIN"
    '    'sqlstring = sqlstring & "                      Oraciones ON Dialogos.OracionId = Oraciones.Id"

    '    ' sqlstring = " SELECT        Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Det_Conversation.Det_Person, Det_Conversation.Det_Par, Det_Conversation.IMG "
    '    ' sqlstring = sqlstring & " FROM            Det_Conversation "


    '    'Try
    '    _comando.CommandText = sqlstring
    '    _comando.Connection.Open()

    '    da.SelectCommand = _comando

    '    da.Fill(dt)

    '    _comando.Connection.Close()

    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    '    _comando.Connection.Close()

    '    'End Try

    '    n = dt.Rows.Count

    '    pgrBar.Maximum = n

    '    If n = 0 Then
    '        ' GuardarAvance(0, 0)
    '        MsgBox("No hay datos", MsgBoxStyle.Information)
    '        Exit Sub
    '    End If

    '    yPos = 10

    '    i = 0

    '    pEtapa.Controls.Clear()

    '    Dim item As ListViewItem 'Creo el ListViewItem (item) 

    '    Dim List As New List(Of String)

    '    pEtapa.AutoScroll = True

    '    Dim person1 As Integer
    '    Dim person2 As Integer

    '    Dim p As CircularPictureBox
    '    Dim pd As PictureBox
    '    Dim bmp As Bitmap
    '    Dim g As Graphics
    '    Dim nm As String
    '    Dim myPen As Pen
    '    Dim j As Integer

    '    Dim pb As PictureBox
    '    Dim pbf As PictureBox
    '    Dim pId As PictureBox

    '    Dim startPoint As Point
    '    Dim endPoint As Point ' La línea es horizontal si la coordenada Y es la misma
    '    ' Puntos para la punta de la flecha (triángulo)
    '    Dim dtDialogos As New DataTable
    '    Dim m As Integer
    '    Dim previousHeight As Integer = 0
    '    Dim h As Integer
    '    Dim k As Integer
    '    Dim txtNo As Label
    '    Dim PosX As Integer
    '    Dim STL As Boolean

    '    x = 0

    '    For Each rw In dt.Rows

    '        x += 1

    '        dtDialogos.Clear()

    '        '''  Panel

    '        nm = rw.Item(0)

    '        pAux = New Panel
    '        pAux.Name = "pAux_" & nm
    '        pAux.Height = 250 '350 
    '        pAux.Width = 1850
    '        pAux.Location = New Point(0, yPos)
    '        pAux.BackColor = Color.LightGray
    '        pAux.BorderStyle = BorderStyle.FixedSingle
    '        'pAux.VerticalScroll.Enabled = False
    '        pAux.AutoScroll = True
    '        ' pAux.AutoScrollMinSize = New Size(1000, 0)
    '        'pAux.HorizontalScroll = True
    '        pAux.VerticalScroll.Maximum = 0

    '        Try
    '            pEtapa.Controls.Add(pAux)
    '        Catch ex As Exception
    '        End Try

    '        'Id
    '        txtIdDialogo = New Label
    '        txtIdDialogo.Name = "Id_" & rw.Item(0)
    '        txtIdDialogo.Width = 70 : txtIdDialogo.Height = 15
    '        'txtIdDialogo.Font = New Font("Consolas", 10)
    '        txtIdDialogo.Text = x & " / " & n
    '        ' txtIdDialogo.BorderStyle = BorderStyle.Fixed3D
    '        txtIdDialogo.TextAlign = ContentAlignment.MiddleLeft
    '        'txtIdDialogo.Tag = rw.Item(0)
    '        'AddHandler txtCuentaDialogos.Click, AddressOf Mover
    '        txtIdDialogo.Location = New Point(pAux.Left + 5, 5)
    '        pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtIdDialogo)

    '        'Leer
    '        btnEliminar = New Button
    '        btnEliminar.Name = rw.Item(0)
    '        btnEliminar.Width = 25 : btnEliminar.Height = 25 ': btnTask.Text = "Report"
    '        btnEliminar.Location = New Point(pAux.Right - 50, 5)
    '        btnEliminar.Cursor = Cursors.Hand
    '        btnEliminar.Text = "X"

    '        AddHandler btnEliminar.Click, AddressOf EliminarPanel
    '        Try
    '            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnEliminar)
    '        Catch ex As Exception
    '        End Try

    '        'Agregar
    '        btnAgregar = New Button
    '        btnAgregar.Name = "btnAgregar_" & rw.Item(0)
    '        btnAgregar.Width = 25 : btnAgregar.Height = 25 ': btnTask.Text = "Report"
    '        btnAgregar.Location = New Point(btnEliminar.Left, btnEliminar.Bottom + 1)
    '        btnAgregar.Text = "+"
    '        btnAgregar.Tag = rw.Item(0)
    '        AddHandler btnAgregar.Click, AddressOf Agregar

    '        pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnAgregar)

    '        'Cuenta
    '        txtCuentaDialogos = New Label
    '        txtCuentaDialogos.Name = "txtCuenta_" & rw.Item(0)
    '        txtCuentaDialogos.Width = 25 : txtCuentaDialogos.Height = 25
    '        txtCuentaDialogos.Location = New Point(btnAgregar.Left, btnAgregar.Bottom + 1)
    '        txtCuentaDialogos.Text = m
    '        txtCuentaDialogos.Tag = rw.Item(0)
    '        'AddHandler txtCuentaDialogos.Click, AddressOf Mover

    '        pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtCuentaDialogos)

    '        'Mover Detalle
    '        btnMoverDetalle = New Button
    '        btnMoverDetalle.Name = rw.Item(0)
    '        btnMoverDetalle.Width = 25 : btnMoverDetalle.Height = 25 ': btnTask.Text = "Report"
    '        btnMoverDetalle.Location = New Point(txtCuentaDialogos.Left, txtCuentaDialogos.Bottom + 1)
    '        btnMoverDetalle.Text = "M"
    '        btnMoverDetalle.Tag = rw.Item(0)
    '        btnMoverDetalle.Cursor = Cursors.Hand
    '        AddHandler btnMoverDetalle.Click, AddressOf Mover

    '        pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnMoverDetalle)

    '        'Recibir Frase
    '        btnRecibir = New Button
    '        btnRecibir.Name = rw.Item(0)
    '        btnRecibir.Width = 25 : btnRecibir.Height = 25 ': btnTask.Text = "Report"
    '        btnRecibir.Location = New Point(btnEliminar.Left, btnMoverDetalle.Bottom + 1)
    '        btnRecibir.Text = "R"
    '        btnRecibir.Tag = rw.Item(0)
    '        btnRecibir.Cursor = Cursors.Hand
    '        AddHandler btnRecibir.Click, AddressOf Recibir

    '        pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnRecibir)

    '        'Dialogos
    '        sqlstring = "  SELECT     Dialogos.Id, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.STL, Oraciones.Exam, Oraciones.foco, Oraciones.CuentaSTL, Dialogos.Item, Oraciones.Oracion, Oraciones.IMG,  Dialogos.IMG AS IMG2"
    '        sqlstring = sqlstring & " , Dialogos.OracionId, Dialogos.voice, Oraciones.Reproduccion,  Oraciones.Favorito, Oraciones.IPA"
    '        sqlstring = sqlstring & " FROM            Dialogos INNER JOIN"
    '        sqlstring = sqlstring & "                  Oraciones ON Dialogos.OracionId = Oraciones.Id"
    '        sqlstring = sqlstring & " WHERE  Dialogos.DetConversacion='" & rw.item(0) & "'"

    '        Try
    '            _comando.CommandText = sqlstring
    '            _comando.Connection.Open()

    '            da.SelectCommand = _comando
    '            da.Fill(dtDialogos)

    '            _comando.Connection.Close()

    '        Catch ex As Exception
    '            _comando.Connection.Close()
    '        End Try

    '        m = dtDialogos.Rows.Count

    '        If m = 0 Then
    '            pAux.Height = 60
    '            pAux.AutoScroll = False

    '        End If


    '        For j = 0 To m - 1

    '            'Foto  de Contexto
    '            pd = New PictureBox
    '            pd.Name = "pd_" & dtDialogos.Rows(j).Item(0)
    '            pd.Tag = dtDialogos.Rows(j).Item(11)
    '            pd.Height = 110 '250
    '            pd.Width = 120 '250
    '            pd.Cursor = Cursors.Hand
    '            pd.BorderStyle = BorderStyle.Fixed3D

    '            pd.SizeMode = PictureBoxSizeMode.Zoom
    '            PosX = (dtDialogos.Rows(j).Item(7) * 500) + 80

    '            pd.Location = New Point(PosX, 26)
    '            AddHandler pd.Click, AddressOf CambiarImagenDialogo
    '            pAux.Controls.Add(pd)

    '            Try

    '                'Foto Pregunta / comentario
    '                ' p = New PictureBox
    '                p = New CircularPictureBox
    '                p.BackColor = Color.Red

    '                p.Name = "p_" & dtDialogos.Rows(j).Item(0)
    '                p.Height = 60 '250
    '                p.Width = 60 '250
    '                p.Cursor = Cursors.Hand
    '                p.BorderStyle = BorderStyle.Fixed3D

    '                ' p.Tag = dtDialogos.Rows(j).Item(11)

    '                'If Not IsDBNull(dtDialogos.Rows(j).Item(12)) Then
    '                '    p.Tag = dtDialogos.Rows(j).Item(12)
    '                'End If
    '                '  p.BorderStyle = BorderStyle.FixedSingle
    '                'Try
    '                '    If Not IsDBNull(dtDialogos.Rows(j).Item(9)) Then 'Oraciones.IMG
    '                '        p.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\" & dtDialogos.Rows(j).Item(9))
    '                '        ' p.SizeMode = PictureBoxSizeMode.Zoom
    '                '    Else

    '                '        If Not IsDBNull(dtDialogos.Rows(j).Item(9)) Then

    '                '            'Actualiza en Dialogos
    '                '            _comando.Connection.Open()

    '                '            sqlstring = "Update Dialogos SET IMG='" & dtDialogos.Rows(j).Item(9) & "'"
    '                '            sqlstring = sqlstring & "  WHERE Id = '" & dtDialogos.Rows(j).Item(0) & "'"
    '                '            _comando.CommandText = sqlstring
    '                '            Try
    '                '                k = _comando.ExecuteNonQuery
    '                '            Catch ex As Exception
    '                '            End Try
    '                '            p.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\" & dtDialogos.Rows(j).Item(9))
    '                '            ' p.SizeMode = PictureBoxSizeMode.Zoom
    '                '        Else
    '                '            p.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\vacio.jpg")
    '                '            ' p.Image = ImageList3.Images.Item(7)
    '                '            ' p.SizeMode = PictureBoxSizeMode.CenterImage
    '                '        End If

    '                '    End If

    '                'Catch ex As Exception
    '                '    p.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\vacio.jpg")

    '                'End Try

    '                p.SizeMode = PictureBoxSizeMode.Zoom
    '                p.BringToFront()

    '                'p.Location = New Point(pd.Left - 75, pd.Bottom - 8)
    '                'AddHandler p.Click, AddressOf CambiarImagen
    '                'AddHandler p.MouseHover, AddressOf ReproducirAudio


    '                pAux.Controls.Add(p)

    '                ' ''Recuadro de color
    '                'pb = New PictureBox
    '                'pb.Name = "pb_" & dtDialogos.Rows(j).Item(0)
    '                'pb.Width = 61
    '                'pb.Height = 61
    '                'bmp = New Bitmap(61, 61)
    '                'pb.Image = bmp
    '                'g = Graphics.FromImage(pb.Image)
    '                'g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
    '                'g.DrawRectangle(myPen, 0, 0, p.Width + 1, p.Height + 1)
    '                'pb.Location = New Point(p.Left - 1, p.Top - 1)
    '                'pEtapa.Controls.Item("pAux_" & nm).Controls.Add(pb)
    '                'g.Dispose()

    '                'Texto en ingles

    '                txtTexto = New RichTextBox
    '                txtTexto.Name = "txt_" & dtDialogos.Rows(j).Item(0)

    '                txtTexto.Text = dtDialogos.Rows(j).Item(1) '& " " & dt.Rows(j).Item(1) '& vbCrLf & vbCrLf & dt.Rows(j).Item(3)
    '                txtTexto.BorderStyle = BorderStyle.None
    '                txtTexto.Font = New System.Drawing.Font("Consolas", 15, FontStyle.Bold)
    '                txtTexto.BackColor = Color.LightGray
    '                ' txtTexto.TextAlign = HorizontalAlignment.Left
    '                'txtTexto.Multiline = True
    '                ' txtTexto.AutoSize = True
    '                txtTexto.Width = 400
    '                'txtTexto.Width.MaxValue = 500
    '                txtTexto.WordWrap = True
    '                txtTexto.SelectionAlignment = HorizontalAlignment.Left

    '                txtTexto.Height = txtTexto.PreferredHeight

    '                txtTexto.Multiline = True

    '                previousHeight = 0
    '                ' Private previousHeight As Integer = 0
    '                If txtTexto.Text.Length > 0 Then
    '                    ' Calcular la altura necesaria para todo el contenido
    '                    Dim numLines As Integer = txtTexto.GetLineFromCharIndex(txtTexto.Text.Length - 1) + 1
    '                    Dim newHeight As Integer = numLines * txtTexto.Font.Height + txtTexto.Margin.Vertical

    '                    If newHeight <> previousHeight Then
    '                        txtTexto.Height = newHeight
    '                        previousHeight = newHeight
    '                    End If
    '                Else
    '                    ' Si está vacío, restablecer a la altura de una línea
    '                    txtTexto.Height = txtTexto.Font.Height + txtTexto.Margin.Vertical
    '                    previousHeight = txtTexto.Height
    '                End If

    '                AddHandler txtTexto.Click, AddressOf RefreshTexto
    '                ' txtTexto.Visible = False
    '                txtTexto.Location = New Point(p.Right + 10, pd.Bottom + 5)
    '                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTexto)

    '                ''Texto en español Traduccion
    '                txtIPA = New Label
    '                txtIPA.Name = "IPA_" & dtDialogos.Rows(j).Item(0)
    '                ' txtTraduccion.BackColor = Color.Beige

    '                If Not IsDBNull(dtDialogos.Rows(j).Item(15)) Then
    '                    txtIPA.Text = dtDialogos.Rows(j).Item(15)
    '                End If
    '                txtIPA.BorderStyle = BorderStyle.None
    '                txtIPA.Font = New System.Drawing.Font("Consolas", 10, FontStyle.Regular)
    '                txtIPA.ForeColor = Color.DimGray
    '                txtIPA.AutoSize = True
    '                txtIPA.Width = 300
    '                txtIPA.Height = txtTexto.PreferredHeight

    '                txtIPA.Location = New Point(txtTexto.Left + 5, txtTexto.Bottom + 1)
    '                pAux.Controls.Add(txtIPA)

    '                ''Texto en español Traduccion
    '                txtTraduccion = New Label
    '                txtTraduccion.Name = "tra_" & dtDialogos.Rows(j).Item(0)
    '                ' txtTraduccion.BackColor = Color.Beige

    '                If Not IsDBNull(dtDialogos.Rows(j).Item(2)) Then
    '                    txtTraduccion.Text = dtDialogos.Rows(j).Item(2)
    '                End If
    '                txtTraduccion.BorderStyle = BorderStyle.None
    '                txtTraduccion.Font = New System.Drawing.Font("Arial", 10, FontStyle.Regular)
    '                txtTraduccion.ForeColor = Color.DimGray
    '                txtTraduccion.AutoSize = True
    '                txtTraduccion.Width = 300
    '                txtTraduccion.Height = txtTexto.PreferredHeight
    '                ' txtTexto.Visible = False

    '                ' txtTraduccion.Visible = False
    '                txtTraduccion.Location = New Point(txtIPA.Left + 5, txtIPA.Bottom + 1)
    '                pAux.Controls.Add(txtTraduccion)

    '                'Leer
    '                btnLeer = New Button
    '                btnLeer.Name = "btnLeer_" & dtDialogos.Rows(j).Item(0)
    '                btnLeer.Width = 25 : btnLeer.Height = 25 ': btnTask.Text = "Report"
    '                btnLeer.Cursor = Cursors.Hand
    '                btnLeer.Image = ImageList1.Images.Item(0)
    '                btnLeer.Tag = dtDialogos.Rows(j).Item(12)

    '                AddHandler btnLeer.Click, AddressOf ReproducirAudio
    '                btnLeer.Location = New Point(txtTexto.Left, 1)
    '                pAux.Controls.Add(btnLeer)


    '                'Show / Hide
    '                btnHide = New Button
    '                btnHide.Name = "btnHide_" & dtDialogos.Rows(j).Item(0)
    '                btnHide.Width = 25 : btnHide.Height = 25 ': btnTask.Text = "Report"
    '                btnHide.Image = ImageList1.Images.Item(1)
    '                btnHide.Location = New Point(btnLeer.Right + 1, 1)
    '                btnHide.Text = "."
    '                btnHide.Cursor = Cursors.Hand
    '                btnHide.Tag = rw.Item(0)
    '                AddHandler btnHide.Click, AddressOf Show

    '                pAux.Controls.Add(btnHide)

    '                'Aprendido
    '                btnAprendido = New Button
    '                btnAprendido.Name = "btnAprendido_" & dtDialogos.Rows(j).Item(0)
    '                btnAprendido.Width = 25 : btnAprendido.Height = 25
    '                btnAprendido.Location = New Point(btnHide.Right + 1, 1)
    '                btnAprendido.Cursor = Cursors.Hand
    '                btnAprendido.Text = "SI"
    '                btnAprendido.Tag = rw.Item(0)

    '                If dtDialogos.Rows(j).Item(6) <= 0 Then
    '                    myPen = New Pen(Color.LightSalmon, 2)
    '                    '  txtTexto.BackColor = Color.Beige
    '                    p.BackColor = Color.LightSalmon
    '                Else
    '                    myPen = New Pen(Color.LimeGreen, 2)
    '                    ' txtTexto.BackColor = ColorWatsap
    '                    p.BackColor = ColorWatsap
    '                End If

    '                AddHandler btnAprendido.Click, AddressOf StatusControl

    '                pAux.Controls.Add(btnAprendido)

    '                'Falta
    '                btnFalta = New Button
    '                btnFalta.Name = "btnFalta_" & dtDialogos.Rows(j).Item(0)
    '                btnFalta.Width = 30 : btnFalta.Height = 25
    '                btnFalta.Location = New Point(btnAprendido.Right + 1, 1)
    '                btnFalta.Cursor = Cursors.Hand
    '                btnFalta.Text = "No"
    '                btnFalta.Tag = rw.Item(0)

    '                AddHandler btnFalta.Click, AddressOf StatusControl
    '                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnFalta)

    '                'Mover
    '                btnMover = New Button
    '                btnMover.Name = "btnMover_" & dtDialogos.Rows(j).Item(0)
    '                btnMover.Width = 25 : btnMover.Height = 25
    '                btnMover.Location = New Point(btnFalta.Right + 1, 1)
    '                btnMover.Cursor = Cursors.Hand
    '                btnMover.Text = "S"
    '                btnMover.BackColor = Color.LightGray
    '                btnMover.Tag = rw.Item(0)

    '                AddHandler btnMover.Click, AddressOf MoverDialogo

    '                pAux.Controls.Add(btnMover)

    '                'Delete
    '                btnDelete = New Button
    '                btnDelete.Name = "btnDelete_" & dtDialogos.Rows(j).Item(0)
    '                btnDelete.Width = 25 : btnDelete.Height = 25
    '                btnDelete.Location = New Point(btnMover.Right + 1, 1)
    '                btnDelete.Text = "X"
    '                btnDelete.Tag = rw.Item(0)
    '                btnDelete.Cursor = Cursors.Hand
    '                AddHandler btnDelete.Click, AddressOf Delete

    '                pAux.Controls.Add(btnDelete)

    '                'Editar
    '                btnEditar = New Button
    '                btnEditar.Name = "btnTask_" & dtDialogos.Rows(j).Item(0)
    '                btnEditar.Width = 25 : btnEditar.Height = 25 ': btnTask.Text = "Report"
    '                btnEditar.Text = "Edit"
    '                btnEditar.Tag = rw.Item(0)
    '                AddHandler btnEditar.Click, AddressOf Editar

    '                btnEditar.Location = New Point(btnDelete.Right + 0.5, 1)

    '                pAux.Controls.Add(btnEditar)


    '                ' Mover a Nuevo
    '                btnMoverNuevo = New Button
    '                btnMoverNuevo.Name = dtDialogos.Rows(j).Item(0)
    '                btnMoverNuevo.Width = 25 : btnMoverNuevo.Height = 25 ': btnTask.Text = "Report"
    '                btnMoverNuevo.Text = ">>"
    '                btnMoverNuevo.Tag = dtDialogos.Rows(j).Item(11)
    '                btnMoverNuevo.Cursor = Cursors.Hand
    '                AddHandler btnMoverNuevo.Click, AddressOf MoverNuevoDialogo
    '                btnMoverNuevo.Location = New Point(btnEditar.Right + 0.5, 1)

    '                pAux.Controls.Add(btnMoverNuevo)

    '                ' Voz
    '                btnVoz = New Button
    '                btnVoz.Name = "btnVoz_" & dtDialogos.Rows(j).Item(0)
    '                btnVoz.Width = 25 : btnVoz.Height = 25 ': btnTask.Text = "Report"
    '                btnVoz.Location = New Point(btnMoverNuevo.Right + 0.5, 1)
    '                If Not IsDBNull(dtDialogos.Rows(j).Item(12)) Then
    '                    btnVoz.Text = dtDialogos.Rows(j).Item(12)
    '                Else
    '                    btnVoz.Text = "0"
    '                End If
    '                btnVoz.Tag = rw.Item(0)
    '                AddHandler btnVoz.Click, AddressOf SeleccionarPersona
    '                pAux.Controls.Add(btnVoz)



    '                ' Favorito
    '                PicFavorito = New PictureBox
    '                PicFavorito.Name = "btnFavorito_" & dtDialogos.Rows(j).Item(0)
    '                PicFavorito.Width = 25 : PicFavorito.Height = 25 ': btnTask.Text = "Report"
    '                PicFavorito.Tag = dtDialogos.Rows(j).Item(14)
    '                PicFavorito.Cursor = Cursors.Hand

    '                If dtDialogos.Rows(j).Item(14) = "S" Then
    '                    PicFavorito.Image = ImageList1.Images.Item(3)
    '                    ' p.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\vacio.jpg")
    '                Else
    '                    PicFavorito.Image = ImageList1.Images.Item(2)
    '                End If
    '                AddHandler PicFavorito.Click, AddressOf CambiarFavorito
    '                PicFavorito.Location = New Point(btnVoz.Right + 0.5, 1)

    '                pAux.Controls.Add(PicFavorito)

    '                ' Reproducciones
    '                txtReproduccion = New Label
    '                txtReproduccion.Name = "txtReproduccion_" & dtDialogos.Rows(j).Item(0)
    '                'txtReproduccion.Width = 30 : btnVoz.Height = 25 ': btnTask.Text = "Report"
    '                ' txtReproduccion.BorderStyle = BorderStyle.Fixed3D
    '                txtReproduccion.Font = New System.Drawing.Font("Consolas", 18, FontStyle.Bold)
    '                txtReproduccion.TextAlign = ContentAlignment.MiddleCenter
    '                txtReproduccion.AutoSize = True

    '                If Not IsDBNull(dtDialogos.Rows(j).Item(13)) Then

    '                    txtReproduccion.Text = dtDialogos.Rows(j).Item(13)

    '                    If dtDialogos.Rows(j).Item(13) > 10 Then
    '                        txtReproduccion.ForeColor = Color.Green
    '                    Else
    '                        txtReproduccion.ForeColor = Color.Red
    '                    End If

    '                Else
    '                    txtReproduccion.Text = "0"
    '                    txtReproduccion.ForeColor = Color.Red
    '                End If

    '                'If File.Exists("C:\Legacy\Ingles\Audios\" & dtDialogos.Rows(j).Item(11) & ".mp3") Then ' El archivo existe
    '                'Else
    '                '    txtReproduccion.Visible = False
    '                '    ' p.Visible = False
    '                '    txtReproduccion.Text = "x"
    '                '    'txtReproduccion.ForeColor = Color.Gray
    '                'End If
    '                ' txtReproduccion.Tag = rw.Item(0)
    '                ' AddHandler txtReproduccion.Click, AddressOf SeleccionarPersona
    '                txtReproduccion.Location = New Point(p.Left + 15, p.Bottom + 10)

    '                pAux.Controls.Add(txtReproduccion)


    '                If cmdMostrarTexto.Text = "Mostrar Texto" Then
    '                    txtTexto.Visible = False
    '                    txtIPA.Visible = False
    '                Else
    '                    txtTexto.Visible = True
    '                    txtIPA.Visible = True
    '                End If

    '                If cmdMostrarTrad.Text = "Mostrar Trad" Then
    '                    txtTraduccion.Visible = False
    '                Else
    '                    txtTraduccion.Visible = True
    '                End If

    '                'Status
    '                If Not IsDBNull(dtDialogos.Rows(j).Item(3)) Then
    '                    STL = dtDialogos.Rows(j).Item(3)
    '                Else
    '                    STL = False
    '                End If

    '                If STL = True Then
    '                    btnAprendido.BackColor = Color.LightGreen
    '                    Aprendidos += 1
    '                Else
    '                    STL = False
    '                    btnFalta.BackColor = Color.LightSalmon
    '                End If

    '            Catch ex As Exception
    '                ' MsgBox("Error al generar Dialogo No " & h & " " & ex.Message)
    '                StatusStrip1.Text = ex.Message
    '                _comando.Connection.Close()

    '            End Try

    '            Cantidad += 1

    '        Next j

    '        yPos = yPos + 80
    '        xPos = xPos + 50
    '        i = i + 1

    '        pgrBar.Value = x

    '    Next

    '    '  total = n * m

    '    ' txtAvance.Text = Math.Round(Aprendidos / Cantidad, 1) & " %"

    '    pgrBar.Value = 0
    '    pEtapa.Visible = True

    'End Sub

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

    Private Sub LiberarImagenes(ctrl As Control)
        If TypeOf ctrl Is PictureBox Then
            Dim pb As PictureBox = CType(ctrl, PictureBox)
            If pb.Image IsNot Nothing Then
                pb.Image.Dispose()
                pb.Image = Nothing
            End If
        End If

        For Each child As Control In ctrl.Controls
            LiberarImagenes(child)
        Next
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        'Private Sub Timer1_Tick(...) Handles Timer1.Tick
        'If pEtapa.VerticalScroll.Value <> lastScroll Then
        '    lastScroll = pEtapa.VerticalScroll.Value
        '    ActualizarVista()
        'End If
        ' End Sub

        ' Timer1.Enabled = False


        'Dim resp As Integer

        ''resp = MsgBox("¿Solo Faltantes?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

        ''If resp = 6 Then
        ''    filtro = " AND o.STL= 0"
        ''Else
        ''    filtro = ""
        ''End If

        '' pEtapa.Visible = False

        'CrearControles(filtro, inicio, fin)

        'For Each ctrl As Control In pEtapa.Controls
        '    If TypeOf ctrl Is Panel Then
        '        For Each subCtrl As Control In ctrl.Controls
        '            If TypeOf subCtrl Is PictureBox Then
        '                Dim pic = CType(subCtrl, PictureBox)

        '                If pic.Image IsNot Nothing Then
        '                    Try
        '                        ImageAnimator.StopAnimate(pic.Image, Nothing)
        '                    Catch
        '                    End Try
        '                End If
        '            End If
        '        Next
        '    End If
        'Next

        ' pEtapa.Visible = True

        'pgrBar.Value = 0

    End Sub

#End Region

#Region "Botones de Controles"

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

        If avance < 0 Then
            avance = 0
        End If

        _comando.Parameters.AddWithValue("@Con_avance", avance)

        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@Con_Id", Id)
        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        _comando.Connection.Close()

    End Sub

    Private Sub Solution(Id)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        ' Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
        Dim i As Integer

        ' IdOracion = lstOraciones.SelectedItems(0).Text

        sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id)"
        sqlstring = sqlstring & " Values ('" & IdOracion & "', '0', '" & Id & "')"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                MsgBox("se guardo")

            Else
                MsgBox("No se guardo")
            End If

            'CrearControles(filtro, inicio, fin)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub

    Private Sub MoveDown(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        ' Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
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


        ' n = ListView1.Items.Count

        If indice = -1 Then Exit Sub


        ' itemCurr = ListView1.Items(indice)


        ' If indice = ListView1.Items.Count - 1 Then

        'ListView1.Items.Remove(itemCurr)

        'Else

        'If indice >= ListView1.Items.Count - 1 Then

        '    ListView1.Items.Remove(itemCurr)

        'Else

        '    ListView1.Items.Remove(itemCurr)
        '    ListView1.Items.Insert(indice + 1, itemCurr)

        'End If


        'End If
        'ListView1.Refresh()

        _comando.Connection.Open()

        'For Each r In ListView1.Items

        '    Console.WriteLine(r.SubItems(0).Text)
        '    Console.WriteLine(r.SubItems(1).Text)
        '    Console.WriteLine(r.SubItems(2).Text)
        '    Console.WriteLine(r.index)

        '    _comando.Parameters.Clear()

        '    '   item = New ListViewItem(lstAgregar.SelectedItems(0).Text()) 'Creo una nueva instancia de item pasandole el nombre como dato principal 




        '    If r.SubItems(2).text = "Null" Then
        '        sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
        '        sqlstring = sqlstring & " WHERE Id = @Id"
        '        '_comando.Parameters.AddWithValue("@Det_Orden", pos + 1)

        '    Else
        '        sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
        '        sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"

        '        '  _comando.Parameters.AddWithValue("@" & r.SubItems(1).Text, r.SubItems(3).Text)
        '        _comando.Parameters.AddWithValue("@Det_Orden", r.index)

        '    End If
        '_comando.Parameters.AddWithValue("@Det_Con", r.SubItems(2).Text)


        _comando.CommandText = sqlstring


        i = _comando.ExecuteNonQuery


        'Next
        _comando.Connection.Close()

        If i > 0 Then
        Else
            MsgBox("No se actualizo")
        End If
        'Bitacora
        'IdOracion = lstOraciones.SelectedItems(0).Text


        ' CrearControles(filtro)
        ' CrearControles(filtro, inicio, fin)

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
        'Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
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

        'itemCurr = ListView1.Items(indice)


        'If indice = ListView1.Items.Count - 1 Then

        'ListView1.Items.Remove(itemCurr)
        '   If ListView1.SelectedItems(0).Index = -1 Then Exit Sub

        '  indice = ListView1.SelectedItems(0).Index
        'itemCurr = ListView1.SelectedItems(0)
        'itemCurr = ListView1.Items(indice)

        'If indice = ListView1.Items.Count - 1 Then
        '    ListView1.Items.Remove(itemCurr)
        '    ListView1.Items.Insert(indice - 1, itemCurr)
        'Else

        '    If indice = 0 Then
        '        ' ListView1.Items.Remove(itemCurr)
        '    Else
        '        ListView1.Items.Remove(itemCurr)
        '        ListView1.Items.Insert(indice - 1, itemCurr)
        '    End If
        'End If

        'ListView1.Refresh()


        _comando.Connection.Open()


        'For Each r In ListView1.Items


        '    _comando.Parameters.Clear()

        '    If r.SubItems(2).text = "Null" Then
        '        sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
        '        sqlstring = sqlstring & " WHERE Id = @Id"

        '    Else
        '        sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
        '        sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"

        '        _comando.Parameters.AddWithValue("@Det_Orden", r.index)

        '    End If
        '    _comando.Parameters.AddWithValue("@Det_Con", r.SubItems(2).Text)



        'Try
        '    _comando.CommandText = sqlstring

        '    i = _comando.ExecuteNonQuery


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally

        'End Try


        'Next


        'If i > 0 Then
        '    MsgBox("se guardo")
        'Else
        '    MsgBox("No se guardo")
        'End If

        'CrearControles(filtro)

        ' CrearControles(filtro, inicio, fin)






    End Sub

    Private Sub Delete(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer

        Dim delete = CType(sender, Button)
        Dim IdDialogo As Integer = CInt(delete.Tag)

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)
        Dim _Item As Integer
        _Item = str(1)


        Dim panel = CType(delete.Parent, Panel)

        picDet = CType(panel.Controls("pd_" & _Item), PictureBox)

        ' Dim txt = CType(panel.Controls("txtReproduccion_" & _Item), Label)

        ' If Not IsNothing(objtextOver) Then
        'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
        ' End If

        '  Dim myPen As New Pen(Color.Red, 2)
        ' Dim myPenClear As New Pen(Color.Beige, 2)

        ' Dim g As Graphics

        IdCurrent = IdDialogo

        _comando.Connection.Open()

        sqlstring = "DELETE FROM Tbl_Dialogos"
        sqlstring = sqlstring & " WHERE Id = @Id"
        _comando.CommandText = sqlstring

        _comando.Parameters.Clear()
        _comando.Parameters.AddWithValue("@Id", IdDialogo)


        Try
            i = _comando.ExecuteNonQuery
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        _comando.Connection.Close()
        picDet.Visible = False

        ' CrearControles()

        'objp = pEtapa.Controls(sender.parent.name).Controls("p_" & IdDialogo)
        'objp.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\X.jpg")

    End Sub

    'Editar

    Private Sub Editar(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        ' Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
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


        Dim editar = CType(sender, Button)
        Dim panel = CType(editar.Parent, Panel)
        Dim IdDialogo As Integer = CInt(editar.Tag)

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)
        Dim _Item As Integer
        _Item = str(1)

        IdCurrent = IdDialogo

        sqlstring = " SELECT         d.Id, d.IdOracion"
        sqlstring = sqlstring & " FROM            Tbl_Dialogos_FR d INNER JOIN"
        sqlstring = sqlstring & "              Oraciones_FR o ON d.IdOracion = o.Id"
        sqlstring = sqlstring & " WHERE  d.Id='" & IdDialogo & "'"
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
        '  Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
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
      
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim Reproducciones As Integer
        Dim IdOracionItem As Integer

        Dim btnHide = CType(sender, Button)
        Dim IdDialogo As Integer = CInt(btnHide.Tag)
        Dim panel = CType(btnHide.Parent, Panel)
        Dim _Item As Integer

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)
        _Item = str(1)

        picDet = CType(panel.Controls("pd_" & _Item), PictureBox)
        Dim texto = CType(panel.Controls("txt_" & _Item), RichTextBox)
        Dim pAudio = CType(panel.Controls("pAudio_" & _Item), CircularPictureBox)


        Dim txt = CType(panel.Controls("txtReproduccion_" & _Item), Label)

        If sender.text = "-" Then
            panel.Controls.Item("txt_" & _Item).Visible = True
            panel.Controls.Item("trad_" & _Item).Visible = True

            sender.text = "."
            picDet.Size = New Size(320, 180)
            texto.Location = New Point(pAudio.Right + 10, picDet.Bottom + 5)

        Else
            panel.Controls.Item("txt_" & _Item).Visible = False
            panel.Controls.Item("trad_" & _Item).Visible = False
            sender.text = "-"


        End If



    End Sub

    Private Sub Exam(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        '  Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
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
        ' Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
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
        ' Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim indice As Integer
        Dim IdDialogo As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim IdPanel As Integer

        IdPanel = sender.tag
        nm = sender.name
        str = nm.Split("_")

        tp = str(0)
        IdDialogo = str(1)

        Dim Id As Integer
        Dim IdPerson As Integer
        Dim TipoTicket As String

        Dim resp As Integer
        Dim obj As PictureBox

        'obj = sender

        ' If cmbPersona.Text = "" Then Exit Sub

        '  IdPerson = cmbPersona.SelectedIndex

        ' resp = MsgBox("Confirmar?", MsgBoxStyle.YesNo)
        'If resp = 6 Then

        sqlstring = "Update Dialogos SET voice='" & IdPerson & "'"
        sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"

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

        pEtapa.Controls.Item(sender.parent.name).Controls("p_" & IdDialogo).Tag = IdPerson
        pEtapa.Controls.Item(sender.parent.name).Controls("btnVoz_" & IdDialogo).text = IdPerson


    End Sub

    Private Sub SeleccionarPersonaRandom(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdDet As Integer
        ' Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
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

        ' If cmbPersona.Text = "" Then Exit Sub

        '   IdPerson = cmbPersona.SelectedIndex

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
        ' Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
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
        ' Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
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

    Private Sub ControlAprendidosES(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        ' Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
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
        If ModVar.Idioma = "EN" Then
            sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        Else
            sqlstring = sqlstring & "              Oraciones_FR ON Det_Conversation.Det_OracionId = Oraciones.Id"

        End If
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
            If ModVar.Idioma = "EN" Then
                sqlstring = "UPDATE Oraciones SET AprendidoES = @AprendidoES"
            Else
                sqlstring = "UPDATE Oraciones_FR SET AprendidoES = @AprendidoES"

            End If
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
        Dim IdDialogo As Integer
        ' Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim speech As New SpVoice
        Dim SpeakCompleted As EventHandler(Of SpeakCompletedEventArgs)

        nm = sender.Name
        Dim IdPanel As Integer

        str = nm.Split("_")
        tp = str(0)
        IdDialogo = str(1)

        If cmdStop.Text = "Stop" Then
            Exit Sub
        End If

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
        '_voice = pEtapa.Controls.Item("pAux_" & nm).Controls("p_" & nm).Tag
        _voice = sender.Tag

        'If _voice = 0 Then
        '_voice = 3
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
            'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
        End If

        Dim myPen As New Pen(Color.Red, 2)
        Dim myPenClear As New Pen(Color.Beige, 2)

        Dim g As Graphics

        'If Not objtextOver Is Nothing Then
        '    g = objtextOver.CreateGraphics
        '    g.DrawRectangle(myPenClear, 0, 0, 40, 40)
        'End If
        IdCurrent = IdDialogo

        If IdOver > 0 Then
            'g = pEtapa.Controls("pAux_" & IdPanel).Controls.Item("p_" & IdOver).CreateGraphics
            ' g.DrawRectangle(myPenClear, 0, 0, 40, 40)
        End If

        'g = pEtapa.Controls("pAux_" & nm).Controls.Item("p_" & nm).CreateGraphics
        'g.DrawRectangle(myPen, 0, 0, 40, 40)

        Try
            objtextCurrent = pEtapa.Controls.Item(sender.parent.name).Controls.Item("txt_" & IdDialogo)
            ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
            ' objtextCurrent.Font = New Font("Consolas", 11, FontStyle.Bold)

            objtextOver = objtextCurrent
            IdOver = IdPanel

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
            Dim pVoice As ISpVoice = CType(speech, ISpVoice)

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

        'Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim speech As New SpVoice
        Dim SpeakCompleted As EventHandler(Of SpeakCompletedEventArgs)


        Dim pVoice As ISpVoice = CType(speech, ISpVoice)

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

    Private Sub cmdLeer_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub LeerItem(item, person)
        Dim _voice As String = ""
        Dim speech As New SpVoice
        Dim SpeakCompleted As EventHandler(Of SpeakCompletedEventArgs)

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

    'Private Sub Voice_Word(StreamNumber As Integer, StreamPosition As Object, CharacterPosition As Integer, Length As Integer) Handles speech.Word
    '    Try
    '        objtextCurrent.SelectAll()
    '        objtextCurrent.SelectionBackColor = Color.Beige ' Or your default background color
    '        'Highlight word in textbox as it is spoken  
    '        objtextCurrent.Select(CharacterPosition, Length)
    '        ' Highlight the current word
    '        ' RichTextBox1.Select(e.CharacterPosition, e.CharacterCount)
    '        objtextCurrent.SelectionBackColor = Color.Yellow ' Or your desired highlight color
    '        ' RichTextBox1.Focus()
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub Cuentas(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        '  Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
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
        ' Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
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
        'Try
        '    PictureBox1.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\" & filename)
        '    PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        '    PictureBox1.BringToFront()

        '    Panel3.Visible = True
        '    Panel3.Location = New Point(500, MousePosition.Y - 100)
        'Catch ex As Exception
        '    Panel3.Visible = False

        'End Try


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



        '  Panel3.Visible = False
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
        'Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
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

    Private Sub VerMenu(sender As Object, e As ToolStripItemClickedEventArgs)
        Dim nombre = e.ClickedItem.Name.ToString
        Dim fecha As Date
        Dim mifecha As String
        Dim Id As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim IdDetActual As Integer
        Dim IdDetNuevo As Integer
        Dim i As Integer
        Dim mypen As Pen
        Dim MaxOrden As Integer
        Dim rowcount As Integer
        Dim k As Integer
        Dim p As Integer


        If nombre.Contains("Mover") Then
            Dim posicion = nombre.Replace("Mover", "")
            k = ListDialogos.Items.Count
            Dim item1 As New ListViewItem(k) ' Crea un nuevo ítem para la primera columna
            Dim orden As Integer

            ' ListDialogos.Items.Add(item1) ' Agrega un subítem para la segunda columna en el ítem ya creado

            _comando.Connection.Open()

            sqlstring = " SELECT         Id, OracionId, Orden, DetConversacion, IMG"
            sqlstring = sqlstring & " FROM            Dialogos "
            sqlstring = sqlstring & "          "
            sqlstring = sqlstring & " WHERE  Id='" & posicion & "'"
            _comando.CommandText = sqlstring

            Dim objDataReader As SqlDataReader

            Try

                objDataReader = _comando.ExecuteReader

                If objDataReader.HasRows Then
                    objDataReader.Read()
                    'rowcount += 1
                    IdDetActual = objDataReader(3)
                    orden = objDataReader(2)

                    item1.SubItems.Add(posicion)   ' Agrega el ítem a la lista
                    item1.SubItems.Add(IdDetActual)   ' Agrega el ítem a la lista
                    item1.SubItems.Add(orden)   ' Agrega el ítem a la lista

                End If

                ListDialogos.Items.Add(item1)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            _comando.Connection.Close()


            Dim pic As PictureBox
            pic = pEtapa.Controls.Item("pAux_" & IdDetActual).Controls.Item("p_" & posicion)
            pic.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\X.jpg")

            'pEtapa.Controls.Item("pAux_" & IdDetActual).Controls.Item("txt_" & posicion).Visible = False

            Exit Sub

        ElseIf nombre.Contains("Recibir") Then
            Dim IdDetRecibe As Integer

            If ListDialogos.Items.Count = 0 Then
                MsgBox("No hay items para mover")
                Exit Sub
            End If

            Dim posicion = nombre.Replace("Recibir", "")

            '_comando.Connection.Open()

            'sqlstring = " SELECT         Id, OracionId, Orden, DetConversacion, IMG"
            'sqlstring = sqlstring & " FROM            Dialogos "
            'sqlstring = sqlstring & "          "
            'sqlstring = sqlstring & " WHERE  Id='" & posicion & "'"
            '_comando.CommandText = sqlstring

            'Dim objDataReader As SqlDataReader

            'Try

            '    objDataReader = _comando.ExecuteReader

            '    If objDataReader.HasRows Then
            '        objDataReader.Read()
            '        'rowcount += 1
            '        IdDetRecibe = objDataReader(3)
            IdDetRecibe = posicion

            'End If

            '    Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try
            '_comando.Connection.Close()


            _comando.Connection.Open()

            Dim j As Integer = 1


            For Each d In ListDialogos.Items

                sqlstring = "UPDATE Dialogos SET DetConversacion = @DetConversacion, Orden = @Orden"
                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.CommandText = sqlstring

                Dim orden As Integer
                orden = ListDialogos.Items(0).SubItems(3).Text
                _comando.Parameters.Clear()
                _comando.Parameters.AddWithValue("@DetConversacion", IdDetRecibe)
                _comando.Parameters.AddWithValue("@Orden", orden + 1)
                _comando.Parameters.AddWithValue("@Id", ListDialogos.Items(0).SubItems(1).Text)

                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                'Dim txt As RichTextBox
                'txt = pEtapa.Controls.Item("pAux_" & ListDialogos.Items(0).SubItems(2).Text).Controls.Item("txt_" & ListDialogos.Items(0).SubItems(1).Text)
                'pEtapa.Controls.Item("pAux_" & IdDetRecibe).Controls.Add(txt)
                'txt.Location = New Point(500, 0)
                '' pEtapa.Controls.Item("pAux_" & IdDetActual).Controls.Item("txt_" & posicion).Visible = False
                'Dim trad As Label
                'trad = pEtapa.Controls.Item("pAux_" & ListDialogos.Items(0).SubItems(2).Text).Controls.Item("tra_" & ListDialogos.Items(0).SubItems(1).Text)
                'trad.Location = New Point(500, txt.Bottom + 1)

                j += 1

            Next


            'Actualiza el Orden 'Dialogos'
            sqlstring = " SELECT         Id, OracionId, Orden, DetConversacion, IMG"
            sqlstring = sqlstring & " FROM            Dialogos "
            sqlstring = sqlstring & "          "
            sqlstring = sqlstring & " WHERE  DetConversacion='" & IdDetRecibe & "'"
            _comando.CommandText = sqlstring

            Dim dt As New DataTable
            Dim da As New SqlDataAdapter

            da.SelectCommand = _comando

            da.Fill(dt)

            n = dt.Rows.Count

            For Each r In dt.Rows

                sqlstring = "UPDATE Dialogos SET Orden = @Orden"
                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Orden", k)
                ' _comando.Parameters.AddWithValue("@Id", r.SubItems(1).Text)
                _comando.Parameters.AddWithValue("@Id", r.item(0))

                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                k += 1
            Next

            ' _comando.Connection.Close()

            '''' Actualizar Orden de Det Id Anterior
            sqlstring = " SELECT         Id, OracionId, Orden, DetConversacion, IMG"
            sqlstring = sqlstring & " FROM            Dialogos "
            sqlstring = sqlstring & "          "
            sqlstring = sqlstring & " WHERE  DetConversacion='" & ListDialogos.Items(0).SubItems(1).Text & "'"
            _comando.CommandText = sqlstring

            da.SelectCommand = _comando

            da.Fill(dt)

            n = dt.Rows.Count


            For Each r In dt.Rows

                sqlstring = "UPDATE Dialogos SET Orden = @Orden"
                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Orden", p)
                _comando.Parameters.AddWithValue("@Id", r.item(0))


                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                p += 1



            Next

            _comando.Connection.Close()

            ''
            ListDialogos.Items.Clear()

            'CrearControles()

        ElseIf nombre.Contains("Ordenar") Then

            Dim posicion = nombre.Replace("Ordenar", "")

            Dim frm As New frmOrdenarDialogos

            AddOwnedForm(frm)
            frm.Id = posicion

            frm.ShowDialog()

            If band = True Then
                ' CrearControles(filtro, inicio, fin)
                'CrearControles(filtro)
            End If

            Exit Sub


        End If

        'CrearControles()


        'Dim CuentaSTL As Integer
        'Dim Exam As String
        'Exam = 

        'Try
        '    Dim Cuenta As Integer

        '    If sender.text = "X" Then
        '        '  sender.backcolor = Color.LightGreen
        '        ' sender.text = "SI"
        '        Aprendidos += 1
        '        'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tst_" & IdDet).BackColor = Color.LightGreen
        '        CuentaSTL -= 1

        '    Else
        '        'sender.backcolor = Color.LightSalmon
        '        'sender.text = "NO"
        '        Aprendidos = 1
        '        'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tst_" & IdDet).BackColor = Color.LightSalmon
        '        CuentaSTL += 1

        '    End If

        '    Cuenta = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Text
        '    CuentaSTL += Cuenta

        '    If CuentaSTL <= 0 Then
        '        ' mypen = New Pen(Color.LightSalmon, 1)
        '        Status = False
        '        pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("btnStatus_" & IdDet).BackColor = Color.Yellow
        '        pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Visible = False

        '    Else
        '        Status = True
        '        ' mypen = New Pen(Color.LightGreen, 1)
        '        pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("btnStatus_" & IdDet).BackColor = Color.Transparent
        '        pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Visible = True

        '    End If



        'Catch ex As Exception

        'End Try

        'Dim pb As PictureBox
        'Dim bmp As Bitmap
        'Dim g As Graphics

        'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("pb_" & IdDet).CreateGraphics.DrawRectangle(mypen, 0, 0, 1195, 85)
        'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Text = CuentaSTL

        'Try
        '    ' IO.File.Open("10.18.172.30\Materials\Readwrite\Checklist\auditoria\" & mifecha & "F-" & id & ".pdf", mode:=IO.FileMode.Append)
        '    'Process.Start("Q:\Materials\Readwrite\Checklist\auditoria-F-" & id & ".pdf") ' Approach 1
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try



        '' Id = dgvDevices.Rows(posicion).Cells(0).Value.ToString

        'Dim version As Integer
        'Dim Proyecto As String

        'Try
        '    ' Id = dgvDevices.Rows(posicion).Cells(0).Value.ToString
        '    ' Proyecto = dgvDevices.Rows(posicion).Cells(1).Value.ToString
        '    ' version = dgvDevices.Rows(posicion).Cells(0).Value.ToString
        '    version = 1

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    'Exit Sub
        'End Try

        'Dim param As String = " WHERE Tbl_files.fil_Id='" & Id & "'"


    End Sub

    Private Sub EliminarPanel(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        'Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
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

        Dim resp As Integer

        resp = MsgBox("¿ Eliminar este panel ?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)

        If resp = 6 Then
        Else
            Exit Sub
        End If

        IdDet = sender.Name

        sqlstring = "Delete From Det_Conversation "
        sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
        End Try

        sqlstring = "Delete From Tbl_Dialogos "
        sqlstring = sqlstring & "  WHERE IdConversacion = '" & IdDet & "'"

        _comando.CommandText = sqlstring

        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
        End Try

        _comando.Connection.Close()

        If i > 0 Then
            'MsgBox("se guardo")
        Else
            'MsgBox("No se guardo")
        End If

        'CrearControles()


        pEtapa.Controls.Remove(pEtapa.Controls.Item("pAux_" & IdDet))



    End Sub

    Private Sub Agregar(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        ' Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
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

        IdDet = sender.tag

        Dim frm As New frmTransferir

        AddOwnedForm(frm)

        frm.Id = Id
        frm.IdDet = IdDet
        'frm.IdConversation = Id
        frm.ShowDialog()



        'sqlstring = " SELECT         Dialogos.Id, Dialogos.OracionId"
        'sqlstring = sqlstring & " FROM            Dialogos INNER JOIN"
        'sqlstring = sqlstring & "              Oraciones ON Dialogos.OracionId = Oraciones.Id"
        'sqlstring = sqlstring & " WHERE  Dialogos.Id='" & str(1) & "'"
        ''sqlstring = sqlstring & " ORDER BY  Det_Conversation.Det_Orden ASC"

        'Dim objDataReader As SqlDataReader

        'Try
        '    _comando.CommandText = sqlstring

        '    _comando.Connection.Open()

        'Catch ex As Exception

        'End Try

        'Try
        '    objDataReader = _comando.ExecuteReader

        '    If objDataReader.HasRows Then

        '        objDataReader.Read()

        '        IdOracionItem = objDataReader(1)
        '    Else
        '        IdOracionItem = IdDet

        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        '_comando.Connection.Close()


        'Dim Id As Integer
        'Dim TipoTicket As String
        'Dim frm As New FrmDetOracion

        'AddOwnedForm(frm)

        'frm.IdOracion = IdOracionItem
        ''frm.CargarDatos(IdOracionItem)
        'frm.CargarDatos(IdOracionItem)
        'frm.ShowDialog()

    End Sub

    Private Sub MoverNuevoDialogo(sender, e)

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        '  Dim dt As New DataTable
        ' Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer
        Dim resp As Boolean
        Dim sql As String
        Dim IdDetNuevo As Integer
        Dim j As Integer = 1

        IdPerson = 3

        _comando.Connection.Open()

        _comando.Parameters.Clear()

        sqlstring = "Insert into Det_Conversation (Det_Orden, Con_Id)"
        sqlstring = sqlstring & " Values (@Det_Orden, '" & Id & "')"

        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@Det_Orden", 0)

        Try
            i = _comando.ExecuteNonQuery
        Catch ex As Exception

        End Try

        Try
            If i > 0 Then
                sql = "SELECT @@IDENTITY FROM Det_conversation"

                _comando = New SqlCommand(sql, _comando.Connection)

                Dim value As Object = _comando.ExecuteScalar

                IdDetNuevo = value.ToString
            End If
            _comando.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        _comando.Connection.Close()

        Dim IdOracionItem As Integer

        Dim nm As String
        IdOracionItem = sender.tag
        nm = sender.Name
        ' Dim str() As String

        ' Str = nm.Split("_")
        _comando.Connection.Open()


        sqlstring = "Update Dialogos SET DetConversacion='" & IdDetNuevo & "'"
        sqlstring = sqlstring & "  WHERE Id = '" & nm & "'"
        _comando.CommandText = sqlstring

        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Console.WriteLine(sender.name)
        Console.WriteLine(sender.parent.name)


        Dim objp As PictureBox

        objp = pEtapa.Controls(sender.parent.name).Controls("p_" & sender.name)
        objp.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\X.jpg")

        '''''

        sqlstring = "SELECT * FROM Dialogos"
        sqlstring = sqlstring & " WHERE DetConversacion = @DetConversacion"
        _comando.CommandText = sqlstring

        _comando.Parameters.Clear()
        _comando.Parameters.AddWithValue("@DetConversacion", IdDetNuevo)
        Try
            da.SelectCommand = _comando
            da.Fill(dt)

        Catch ex As Exception
        End Try

        n = dt.Rows.Count

        Dim q As Integer = 0
        For Each r In dt.Rows

            sqlstring = "UPDATE Dialogos SET Orden = @Orden"
            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()

            _comando.Parameters.AddWithValue("@Orden", q)
            _comando.Parameters.AddWithValue("@Id", r.item(0))


            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            j += 1
        Next

        _comando.Connection.Close()


        'Actualiza OracionId 'Det_conversation
        For Each r In dt.Rows


            Try
                Console.WriteLine(r.item(1))
            Catch ex As Exception

            End Try
            sqlstring = "UPDATE Det_Conversation SET Det_OracionId = @Det_OracionId"
            sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"
            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()

            _comando.Parameters.AddWithValue("@Det_OracionId", r.item(1))
            _comando.Parameters.AddWithValue("@Det_Con", IdDetNuevo)

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
            End Try
        Next



    End Sub

  
    Private Sub AnimateGif(sender As Object, e As EventArgs)

        If picDet.Image Is Nothing Then Exit Sub

        Dim img As Image = picDet.Image
        Dim dimension As New FrameDimension(img.FrameDimensionsList(0))

        If currentFrame >= frameCount Then
            ' 🔴 detener completamente
            RemoveHandler Application.Idle, AddressOf AnimateGif
            Exit Sub
        End If

        img.SelectActiveFrame(dimension, currentFrame)
        picDet.Invalidate()

        currentFrame += 1

    End Sub

    Private Sub StatusControl(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        'Dim IdOracion As Integer

        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer

        ' Dim IdDet As Integer
        Dim IdDet As Integer

        Dim IdOracionItem As Integer
        Dim mypen As Pen
        Dim CuentaOracion As Integer

        '''''''''
        Dim btnStatus = CType(sender, Button)
        Dim IdDialogo As Integer = CInt(btnStatus.Tag)
        Dim panel = CType(btnStatus.Parent, Panel)

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)
        Dim _Item As Integer
        _Item = str(1)



        picDet = CType(panel.Controls("pd_" & _Item), PictureBox)

        IdDet = sender.tag

        If ModVar.Idioma = "EN" Then
            sqlstring = " SELECT          d.Id, d.IdOracion, d.Orden, d.IdConversacion, d.IMG, o.CuentaSTL"
            sqlstring = sqlstring & " FROM            Tbl_Dialogos d INNER JOIN"
            sqlstring = sqlstring & "                    Oraciones o ON d.IdOracion = o.Id"
            sqlstring = sqlstring & " WHERE  d.Id='" & IdDialogo & "'"

        Else
            sqlstring = " SELECT          d.Id, d.IdOracion, d.Orden, d.IdConversacion, d.IMG, o.CuentaSTL"
            sqlstring = sqlstring & " FROM            Tbl_Dialogos_FR d INNER JOIN"
            sqlstring = sqlstring & "                    Oraciones_FR o ON d.IdOracion = o.Id"
            sqlstring = sqlstring & " WHERE  d.Id='" & IdDialogo & "'"
        End If
       
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
                CuentaOracion = objDataReader(5)

            Else
                IdOracionItem = IdDet

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()

        Dim CuentaSTL As Integer



        Dim Exam As String
        ' Exam = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txt_" & IdDialogo).Text

        Try
            Dim Cuenta As Integer

            If sender.text = "SI" Then
                sender.backcolor = Color.LightGreen
                ' sender.text = "SI"
                ' Aprendidos -= 1
                ' pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("btnFalta_" & IdDialogo)
                btnFalta = CType(panel.Controls("btnFalta_" & _Item), Button)
                btnFalta.BackColor = Color.LightGray
                CuentaSTL += 1

            Else
                sender.backcolor = Color.LightSalmon
                'sender.text = "NO"
                'Aprendidos = 1
                CuentaSTL -= 1
                '  pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("btnAprendido_" & IdDialogo)
                btnAprendido_ = CType(panel.Controls("btnAprendido_" & _Item), Button)
                btnAprendido_.BackColor = Color.LightGray

            End If

            'Cuenta = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Text
            CuentaSTL += Cuenta

            If CuentaSTL <= 0 Then
                mypen = New Pen(Color.LightSalmon, 2)
                Status = False
                ' pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("btnStatus_" & IdDet).BackColor = Color.Yellow
                ' pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Visible = False

            Else
                Status = True
                mypen = New Pen(Color.LimeGreen, 2)
                ' pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("btnStatus_" & IdDialogo).BackColor = Color.Transparent
                ' pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDialogo).Visible = True

            End If

            If ModVar.Idioma = "EN" Then
                sqlstring = "UPDATE Oraciones SET STL = @STL, CuentaSTL=@CuentaSTL"
            Else
                sqlstring = "UPDATE Oraciones_FR SET STL = @STL, CuentaSTL=@CuentaSTL"

            End If
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

        '================================
        ' Actualizar registro
        '================================

        ' Dim fila As DataRow = dt.Rows(0)
        dt.PrimaryKey = New DataColumn() {dt.Columns("Id")}
        Dim fila As DataRow = dt.Rows.Find(IdDialogo) ' Id = 1
        'dt.AcceptChanges()
        'dt.Clear()
        'da.Fill(dt)
        fila("STL") = Status
        ' fila("Edad") = 30

        Dim p As CircularPictureBox
        Dim bmp As Bitmap
        Dim g As Graphics

        If Status = True Then
            'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txt_" & IdDialogo).BackColor = ColorWatsap
            'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("p_" & IdDialogo).BackColor = ColorWatsap
            ' panel.Controls.Item("p_" & IdDialogo)
            p = CType(panel.Controls("pAudio_" & _Item), CircularPictureBox)
            p.BackColor = ColorWatsap
        Else
            'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("p_" & IdDialogo).BackColor = Color.LightSalmon
            p = CType(panel.Controls("pAudio_" & _Item), CircularPictureBox)
            p.BackColor = Color.LightSalmon
            'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("p_" & IdDialogo).BackColor = Color.LightSalmon
        End If




    End Sub

    Private Sub Recibir(sender, e)

        Dim Id As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim IdDetActual As Integer
        Dim IdDetNuevo As Integer
        Dim i As Integer
        Dim mypen As Pen
        Dim MaxOrden As Integer
        Dim rowcount As Integer
        Dim k As Integer
        Dim p As Integer

        Dim orden As Integer

        ' Dim posicion = nombre.Replace("Mover", "")
        Dim posicion = Nombre.Replace("Recibir", "")
        ' k = ListDialogos.Items.Count
        'Dim item1 As New ListViewItem(k) ' Crea un nuevo ítem para la primera columna

        ' ListDialogos.Items.Add(item1) ' Agrega un subítem para la segunda columna en el ítem ya creado
        Dim IdDetalle As Integer
        Dim IdDetRecibe As Integer

        IdDetRecibe = sender.name
        '_comando.Connection.Open()

        'sqlstring = " SELECT         Id, OracionId, Orden, DetConversacion, IMG"
        'sqlstring = sqlstring & " FROM            Dialogos "
        'sqlstring = sqlstring & "          "
        'sqlstring = sqlstring & " WHERE  Id='" & posicion & "'"


        If ListDialogos.Items.Count = 0 Then
            MsgBox("No hay items para mover")
            Exit Sub
        End If


        '_comando.Connection.Open()

        'sqlstring = " SELECT         Id, OracionId, Orden, DetConversacion, IMG"
        'sqlstring = sqlstring & " FROM            Dialogos "
        'sqlstring = sqlstring & "          "
        'sqlstring = sqlstring & " WHERE  Id='" & posicion & "'"
        '_comando.CommandText = sqlstring

        'Dim objDataReader As SqlDataReader

        'Try

        '    objDataReader = _comando.ExecuteReader

        '    If objDataReader.HasRows Then
        '        objDataReader.Read()
        '        'rowcount += 1
        '        IdDetRecibe = objDataReader(3)
        'IdDetRecibe = posicion


        _comando.Connection.Open()

        Dim j As Integer = 1


        For Each d In ListDialogos.Items

            sqlstring = "UPDATE Dialogos SET DetConversacion = @DetConversacion, Orden = @Orden"
            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring

            orden = ListDialogos.Items(0).SubItems(3).Text
            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@DetConversacion", IdDetRecibe)
            _comando.Parameters.AddWithValue("@Orden", orden + 1)
            _comando.Parameters.AddWithValue("@Id", ListDialogos.Items(0).SubItems(1).Text)

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'Dim txt As RichTextBox
            'txt = pEtapa.Controls.Item("pAux_" & ListDialogos.Items(0).SubItems(2).Text).Controls.Item("txt_" & ListDialogos.Items(0).SubItems(1).Text)
            'pEtapa.Controls.Item("pAux_" & IdDetRecibe).Controls.Add(txt)
            'txt.Location = New Point(500, 0)
            '' pEtapa.Controls.Item("pAux_" & IdDetActual).Controls.Item("txt_" & posicion).Visible = False
            'Dim trad As Label
            'trad = pEtapa.Controls.Item("pAux_" & ListDialogos.Items(0).SubItems(2).Text).Controls.Item("tra_" & ListDialogos.Items(0).SubItems(1).Text)
            'trad.Location = New Point(500, txt.Bottom + 1)

            j += 1

        Next


        'Actualiza el Orden 'Dialogos'
        sqlstring = " SELECT         Id, OracionId, Orden, DetConversacion, IMG"
        sqlstring = sqlstring & " FROM            Dialogos "
        sqlstring = sqlstring & "          "
        sqlstring = sqlstring & " WHERE  DetConversacion='" & IdDetRecibe & "'"
        _comando.CommandText = sqlstring

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        da.SelectCommand = _comando

        da.Fill(dt)

        n = dt.Rows.Count
        pgrBar.Value = 0

        pgrBar.Maximum = n
        For Each r In dt.Rows

            sqlstring = "UPDATE Dialogos SET Orden = @Orden"
            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()

            _comando.Parameters.AddWithValue("@Orden", k)
            ' _comando.Parameters.AddWithValue("@Id", r.SubItems(1).Text)
            _comando.Parameters.AddWithValue("@Id", r.item(0))

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            k += 1
            pgrBar.Value += 1

        Next

        ' _comando.Connection.Close()

        '''' Actualizar Orden de Det Id Anterior
        sqlstring = " SELECT         Id, OracionId, Orden, DetConversacion, IMG"
        sqlstring = sqlstring & " FROM            Dialogos "
        sqlstring = sqlstring & "          "
        sqlstring = sqlstring & " WHERE  DetConversacion='" & ListDialogos.Items(0).SubItems(1).Text & "'"
        _comando.CommandText = sqlstring

        da.SelectCommand = _comando

        da.Fill(dt)

        n = dt.Rows.Count


        For Each r In dt.Rows

            sqlstring = "UPDATE Dialogos SET Orden = @Orden"
            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()

            _comando.Parameters.AddWithValue("@Orden", p)
            _comando.Parameters.AddWithValue("@Id", r.item(0))


            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            p += 1



        Next

        _comando.Connection.Close()

        ''
        ListDialogos.Items.Clear()

        StatusTrip.Text = "Guardado " & TimeOfDay.ToString("h:mm tt")

        'pgrBar.Value = 0



    End Sub

    Private Sub MoverDialogo(sender, e)
        Dim sqlstring As String
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim btnStatus As Button
        Dim IdDialogo As Integer
        Dim IdDetNuevo As Integer
        Dim IdOracionItem As Integer

        ' If e.Button = MouseButtons.Right Then
        Dim menu = New System.Windows.Forms.ContextMenuStrip()
        Dim posicion As Integer 'dgvDevices.HitTest(e.X, e.Y).RowIndex

        nm = sender.Name
        str = nm.Split("_")
        tp = str(0)

        IdDialogo = str(1)


        'If posicion > -1 Then
        '    menu.Items.Add("Mover").Name = "Mover" & IdDialogo
        '    menu.Items.Add("Recibir").Name = "Recibir" & IdDialogo
        '    menu.Items.Add("Ordenar").Name = "Ordenar" & sender.tag
        'End If

        'menu.Show(pEtapa.Controls.Item("pAux_" & sender.tag), sender.location.X - 120, sender.location.Y - 50)

        'AddHandler menu.ItemClicked, AddressOf VerMenu

        'sender.backcolor = Color.Yellow



    End Sub

    Private Sub Mover(sender, e)
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

        Dim IdOracionItem As Integer
        nm = sender.Name

        str = nm.Split("_")

        tp = str(0)

        IdDet = sender.tag

        'Dim frm As New frmMoverDialogo

        'AddOwnedForm(frm)

        ' frm.IdEnc = Id
        frmMoverDialogo.IdDet = IdDet

        frmMoverDialogo.ShowDialog()

        'CrearControles()

        pEtapa.Controls.Remove(sender.parent)

    End Sub

    Private Sub CambiarFavorito(sender, e)
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label

        
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim _rate As Double
        nm = sender.Name
        Dim IdPanel As String
        Dim Reproducciones As Integer
        Dim IdOracionItem As Integer
        Dim Status As String

        Dim favorito = CType(sender, PictureBox)
        Dim panel = CType(favorito.Parent, Panel)
        Dim IdDialogo As Integer = CInt(favorito.Tag)

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)
        Dim _Item As Integer
        _Item = str(1)

        IdCurrent = IdDialogo

        Dim n As UInteger = 0
        Dim archivo As String


        If favorito.Text = "S" Then
            favorito.Text = "R"
            favorito.Image = ImageList1.Images.Item(6)
            Status = "R"
        ElseIf favorito.Text = "R" Then
            favorito.Text = "N"
            favorito.Image = ImageList1.Images.Item(5)
            Status = "N"
        Else

            favorito.Text = "S"
            favorito.Image = ImageList1.Images.Item(4)
            Status = "S"
        End If


        'Dim PicFavorito As PictureBox

        ' PicFavorito = panel.Controls.Item("btnFavorito_" & IdDialogo)
        sqlstring = " SELECT          d.Id, d.IdOracion, o.favorito"
        sqlstring = sqlstring & " FROM            Tbl_Dialogos d INNER JOIN"

        If ModVar.Idioma = "EN" Then
            sqlstring = sqlstring & "  Oraciones o ON d.IdOracion = o.Id"
        Else
            sqlstring = sqlstring & "   Oraciones_FR o ON d.IdOracion = o.Id"

        End If
        sqlstring = sqlstring & " WHERE  d.Id='" & IdDialogo & "'"

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

                objDataReader.Close()

                If ModVar.Idioma = "EN" Then
                    sqlstring = "UPDATE Oraciones SET Favorito = @Favorito, MasUsada= @masUsada"
                Else
                    sqlstring = "UPDATE Oraciones SET Favorito = @Favorito, MasUsada= @masUsada"
                End If

                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Favorito", Status)
                _comando.Parameters.AddWithValue("@MasUsada", Status)
                _comando.Parameters.AddWithValue("@Id", IdOracionItem)


                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                ' _comando.Connection.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()


        '  Dim audio As String
        ' Dim _gif As String = ""
        ' Dim _IMG As String = ""
        ' Dim _Texto As String = ""
        ' Dim previousHeight As moInteger = 0


        ' Dim fila As DataRow = dt.Rows(0)
        dt.PrimaryKey = New DataColumn() {dt.Columns("Id")}
        Dim fila As DataRow = dt.Rows.Find(IdDialogo) ' Id = 1
        'dt.AcceptChanges()
        'dt.Clear()
        'da.Fill(dt)
        fila("favorito") = Status

        favorito.Refresh()

    End Sub

    Private Sub CambiarScore(sender As Object, e As MouseEventArgs)
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        nm = sender.Name
        Dim IdPanel As String
        Dim Reproducciones As Integer
        Dim IdOracionItem As Integer
        Dim Status As String

        Dim score = CType(sender, Label)
        Dim panel = CType(score.Parent, Panel)
        Dim IdDialogo As Integer = CInt(score.Tag)
        Dim rate As Double
        Dim _rate As Double
        rate = score.Text

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)
        Dim _Item As Integer
        _Item = str(1)

        IdCurrent = IdDialogo

        Dim n As UInteger = 0
        Dim archivo As String

        If ModVar.Idioma = "EN" Then
            sqlstring = " SELECT          d.Id, d.IdOracion, o.favorito"
            sqlstring = sqlstring & " FROM            Tbl_Dialogos d INNER JOIN"
            sqlstring = sqlstring & "                    Oraciones_FR o ON d.IdOracion = o.Id"
            sqlstring = sqlstring & " WHERE  d.Id='" & IdDialogo & "'"
        Else
            sqlstring = " SELECT          d.Id, d.IdOracion, o.favorito"
            sqlstring = sqlstring & " FROM            Tbl_Dialogos_FR d INNER JOIN"
            sqlstring = sqlstring & "                    Oraciones_FR o ON d.IdOracion = o.Id"
            sqlstring = sqlstring & " WHERE  d.Id='" & IdDialogo & "'"
        End If
       
        Dim objDataReader As SqlDataReader

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()
        Catch ex As Exception
        End Try

        If e.Button = Windows.Forms.MouseButtons.Right Then
            _rate = rate - 0.1
        Else
            _rate = rate + 0.1

        End If


        Try
            objDataReader = _comando.ExecuteReader
            If objDataReader.HasRows Then
                objDataReader.Read()

                IdOracionItem = objDataReader(1)

                objDataReader.Close()

                sqlstring = "UPDATE Oraciones_FR SET rate = @rate"
                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@rate", _rate)
                _comando.Parameters.AddWithValue("@Id", IdOracionItem)


                Try
                    i = _comando.ExecuteNonQuery
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()

        dt.PrimaryKey = New DataColumn() {dt.Columns("Id")}
        Dim fila As DataRow = dt.Rows.Find(IdDialogo)

        fila("rate") = _rate

        score.Text = _rate
        score.Refresh()

    End Sub

    Private Sub CambiarImagen(sender, e)
        Dim sqlstring As String
        Dim IdDialogo As Integer
       
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

        IdDialogo = str(1)

        Dim Id As Integer
        Dim IdPerson As Integer
        Dim TipoTicket As String

        Dim resp As Integer
        Dim obj As PictureBox

        IdOracion = sender.tag

        Dim _comando As SqlCommand
        Dim filename As String = ""

        Dim Nombre As String
        Dim objDataReader As SqlDataReader


        Dim Personaje As String

        Personaje = InputBox("Ingrese el numero de personaje", "Personaje")



        If Trim(Personaje) <> "" Then

            sqlstring = "UPDATE Tbl_Dialogos SET Personaje = @Personaje"
            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()

            _comando.Parameters.AddWithValue("@Personaje", Personaje)
            _comando.Parameters.AddWithValue("@Id", IdDialogo)
            _comando.Connection.Open()

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
            End Try
            _comando.Connection.Close()

            pEtapa.Controls(sender.parent.name).Controls.Item("txtReproduccion_" & IdDialogo).Text = 0


        Else




        End If


        ' Dim fila As DataRow = dt.Rows(0)
        dt.PrimaryKey = New DataColumn() {dt.Columns("Id")}
        Dim fila As DataRow = dt.Rows.Find(IdDialogo) ' Id = 1
        'dt.AcceptChanges()
        'dt.Clear()
        'da.Fill(dt)
        fila("Personaje") = Personaje




    End Sub

    Private Sub CambiarPersonaje(sender, e)
        Dim sqlstring As String
       
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim _Item As Integer

        nm = sender.name
        str = nm.Split("_")

        tp = str(0)
        _Item = str(1)

        Dim txtpersonaje = CType(sender, Button)
        Dim IdDialogo As Integer = CInt(txtpersonaje.Tag)
        Dim panel = CType(txtpersonaje.Parent, Panel)

        picDet = CType(panel.Controls("pd_" & _Item), PictureBox)

        Dim txt = CType(panel.Controls("txtReproduccion_" & _Item), Label)

        If Not IsNothing(objtextOver) Then
            'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
        End If

        Dim myPen As New Pen(Color.Red, 2)
        Dim myPenClear As New Pen(Color.Beige, 2)


        Dim Id As Integer
        Dim IdPerson As Integer
        Dim TipoTicket As String

        Dim resp As Integer
        Dim obj As PictureBox

        IdOracion = sender.tag

        Dim _comando As SqlCommand
        Dim filename As String = ""

        Dim Nombre As String
        Dim objDataReader As SqlDataReader

        Dim _personaje As String

        ' _personaje = InputBox("Ingrese Personaje A:Mujer B:Hombre C:Contexto")
        If txtpersonaje.Text = "1" Then
            _personaje = "2"
        ElseIf txtpersonaje.Text = "2" Then
            _personaje = "3"
        ElseIf txtpersonaje.Text = "3" Then
            _personaje = "4"
        ElseIf txtpersonaje.Text = "4" Then
            _personaje = "1"
        End If
        If Trim(_personaje) = "" Then Exit Sub


        'If e.button = MouseButtons.Right Then
        '    'Oculta texto 
        '    Exit Sub  'Falta revisar para que sirve
        '    Dim IdPanel As String
        '    ' IdPanel = sender.parent
        '    IdPanel = pEtapa.Controls(sender.parent.name).name
        '    If Not IsNothing(objtextOver) Then
        '        'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
        '    End If

        _comando = MetodosDatos.CrearComando()

        sqlstring = " SELECT          Id, IdOracion, Orden, personaje"
        sqlstring = sqlstring & " FROM            Tbl_Dialogos "
        sqlstring = sqlstring & " WHERE  Id='" & IdDialogo & "'"
        _comando.CommandText = sqlstring

        Try
            _comando.Connection.Open()

        Catch ex As Exception
        End Try

        Dim audio As String
        Dim _gif As String = ""
        Dim _IMG As String = ""
        Dim _Texto As String = ""
        Dim previousHeight As Integer = 0
        Dim _rate As Double
        Dim Reproducciones As Integer
        Dim Personaje As String
        Dim carpeta As String
        Dim FileToMove As String

        Try
            objDataReader = _comando.ExecuteReader
            If objDataReader.HasRows Then
                objDataReader.Read()
                If Not IsDBNull(objDataReader(3)) Then
                    Personaje = objDataReader(3)
                End If
                If Not IsDBNull(objDataReader(1)) Then
                    IdOracion = objDataReader(1)
                End If
                If Personaje = "1" Then
                    carpeta = "C:\Legacy\Ingles\Audios\Femenino\"
                Else
                    carpeta = "C:\Legacy\Ingles\Audios\Masculino\"
                End If

                FileToMove = carpeta & IdOracion & ".mp3"

            Else
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()

        Dim n As UInteger = 0
        Dim archivo As String


        sqlstring = "UPDATE Oraciones SET avatar = @avatar"
        sqlstring = sqlstring & " WHERE Id = @Id"
        _comando.CommandText = sqlstring
        _comando.Parameters.Clear()

        _comando.Parameters.AddWithValue("@avatar", _personaje)
        _comando.Parameters.AddWithValue("@Id", IdOracion)
        _comando.Connection.Open()

        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
        End Try
        _comando.Connection.Close()

        'Mover el audio a la carpeta
        Dim carpetaNueva As String


        If _personaje = "1" Then
            carpetaNueva = "C:\Legacy\Ingles\Audios\Femenino\"
        Else
            carpetaNueva = "C:\Legacy\Ingles\Audios\Masculino\"
        End If

        Dim MoveLocation As String

        'ofd.InitialDirectory = "C:\Legacy\Ingles\Audios\"
        ''My.Computer.FileSystem.RenameFile("C:\Ruta\A\documento.txt", "informe.txt")
        'If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then

        Dim ruta As String = ""

        Try

            If File.Exists(FileToMove) Then
                ' El archivo existe
                My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", IdOracion & "_2.mp3")
            Else 'No existe
                'FileToMove = filename
                MoveLocation = carpetaNueva & IdOracion & ".mp3"

                System.IO.File.Move(FileToMove, MoveLocation)

            End If

            'My.Computer.FileSystem.RenameFile(filename, IdOracion & ".mp3")

        Catch ex As Exception

        End Try

        txtpersonaje.Text = _personaje


        ' Dim fila As DataRow = dt.Rows(0)
        dt.PrimaryKey = New DataColumn() {dt.Columns("Id")}
        Dim fila As DataRow = dt.Rows.Find(IdDialogo) ' Id = 1
        'dt.AcceptChanges()
        'dt.Clear()
        'da.Fill(dt)
        fila("avatar") = _personaje

     
       



    End Sub

    Private Sub CambiarImagenDefault(sender, e)
        Dim sqlstring As String
       
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim _Item As Integer

        Dim myPen As New Pen(Color.Red, 2)
        Dim myPenClear As New Pen(Color.Beige, 2)

        nm = sender.name
        str = nm.Split("_")

        tp = str(0)
        _Item = str(1)

        Dim txtImagen = CType(sender, Button)
        Dim IdDialogo As Integer = CInt(txtImagen.Tag)
        Dim panel = CType(txtImagen.Parent, Panel)

        picDet = CType(panel.Controls("pd_" & _Item), PictureBox)


        Dim Id As Integer
        Dim IdPerson As Integer
        Dim TipoTicket As String

        Dim resp As Integer
        Dim obj As PictureBox
          
        Dim _comando As SqlCommand
        Dim filename As String = ""

        Dim Nombre As String
        Dim objDataReader As SqlDataReader

        Dim _personaje As String
        Dim _tipo As String

        _tipo = txtImagen.Text

        _comando = MetodosDatos.CrearComando()

        sqlstring = " SELECT          Id, IdOracion, Orden, Personaje"
        sqlstring = sqlstring & " FROM            Tbl_Dialogos "
        sqlstring = sqlstring & " WHERE  Id='" & IdDialogo & "'"
        _comando.CommandText = sqlstring

        Try
            _comando.Connection.Open()
        Catch ex As Exception
        End Try


        Try
            objDataReader = _comando.ExecuteReader

            If objDataReader.HasRows Then
                objDataReader.Read()
                IdOracionItem = objDataReader(1)
            End If
        Catch ex As Exception
        End Try
        objDataReader.Close()

        Dim audio As String
        Dim _gif As String = ""
        Dim _IMG As String = ""
        Dim _Texto As String = ""
        Dim previousHeight As Integer = 0
        Dim _rate As Double
        Dim Reproducciones As Integer
        Dim Personaje As String
        Dim carpeta As String
        Dim FileToMove As String
        Dim valor As String

        sqlstring = "UPDATE Oraciones SET IMG = @IMG, personaje ='A'"
        sqlstring = sqlstring & " WHERE Id = @Id"
        _comando.CommandText = sqlstring
        _comando.Parameters.Clear()

        If _tipo = "Question" Then
            valor = "pensando"
            _comando.Parameters.AddWithValue("@IMG", valor)
        Else
            valor = "like"
            _comando.Parameters.AddWithValue("@IMG", valor)
        End If

        _comando.Parameters.AddWithValue("@Id", IdOracionItem)

        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
        End Try
        _comando.Connection.Close()

        'CrearControles()

        picDet.Image = My.Resources._like

        ' Dim fila As DataRow = dt.Rows(0)
        dt.PrimaryKey = New DataColumn() {dt.Columns("Id")}
        Dim fila As DataRow = dt.Rows.Find(IdDialogo) ' Id = 1
        'dt.AcceptChanges()
        'dt.Clear()
        'da.Fill(dt)
        fila("IMG_Oracion") = valor
        fila("personaje") = "A"

    End Sub

    Private Sub subirDialogo(sender, e)
        Dim _comando As SqlCommand
        Dim sqlstring As String
        Dim resp As Integer
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim _Item As Integer
        Dim _IdDet As Integer
        nm = sender.name
        str = nm.Split("_")

        tp = str(0)
        _Item = str(1)

        Dim btnsubir = CType(sender, Button)
        Dim IdDialogo As Integer = CInt(btnsubir.Tag)
        Dim panel = CType(btnsubir.Parent, Panel)


        _comando = MetodosDatos.CrearComando()
                  
        picDet = CType(panel.Controls("pd_" & _Item), PictureBox)

        Dim txt = CType(panel.Controls("txtReproduccion_" & _Item), Label)
      
        sqlstring = " SELECT          d.Id, d.IdOracion, d.Orden, d.IdConversacion"
        sqlstring = sqlstring & " FROM            Tbl_Dialogos d INNER JOIN"
        sqlstring = sqlstring & "                    Oraciones o ON d.IdOracion = o.Id"
        sqlstring = sqlstring & " WHERE  d.Id='" & IdDialogo & "'"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()
        Catch ex As Exception
        End Try

        Dim objDataReader As SqlDataReader
        objDataReader = _comando.ExecuteReader
        If objDataReader.HasRows Then
            objDataReader.Read()
            IdDet = objDataReader(3)
        End If
        objDataReader.Close()
        _comando.Connection.Close()

        sqlstring = "UPDATE Det_conversation SET orden = @orden"
        sqlstring = sqlstring & " WHERE Det_con = @Det_con"
        _comando.CommandText = sqlstring

        _comando.Connection.Open()
        _comando.Parameters.Clear()

        _comando.Parameters.AddWithValue("@orden", pivote)
        _comando.Parameters.AddWithValue("@Det_con", IdDet)


        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
        End Try
        _comando.Connection.Close()


        'panel.Visible = False

        'dt.PrimaryKey = New DataColumn() {dt.Columns("Id")}
        'Dim fila As DataRow = dt.Rows.Find(IdDialogo)

        'fila("orden_det") = pivote


        '' --- ORDENAR SIN PERDER ESTRUCTURA ---
        'Dim dv As New DataView(dt)
        'dv.Sort = "orden_det ASC, orden_dialogo ASC, item ASC"

        'dt = dv.ToTable()

        'listaGrupos.Clear()
        'listaGrupos = dt.AsEnumerable().GroupBy(Function(r) r("Det_Con")).ToList()

        pivote = pivote + 1

        pEtapa.SuspendLayout()

        For Each ctrl As Control In pEtapa.Controls
            ctrl.Dispose()
        Next

        pEtapa.Controls.Clear()
        poolPanels.Clear()

        pEtapa.ResumeLayout()

        CrearControles()

    End Sub

    Private Sub CambiarStatusConversacion(sender, e)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
      
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim IdDet As Integer

        Dim btnstatus = CType(sender, Button)
        Dim IdDialogo As Integer = CInt(btnstatus.Tag)
        Dim panel = CType(btnstatus.Parent, Panel)

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)
        Dim _Item As Integer
        _Item = str(1)

        picDet = CType(panel.Controls("pd_" & _Item), PictureBox)

        Dim txt = CType(panel.Controls("txtReproduccion_" & _Item), Label)
        Dim status As String

        If btnstatus.Text = "R" Then
            status = "N"
        Else
            status = "R"
        End If

        sqlstring = " SELECT          d.Id, d.IdOracion, d.Orden, d.IdConversacion"
        sqlstring = sqlstring & " FROM            Tbl_Dialogos d INNER JOIN"
        sqlstring = sqlstring & "                    Oraciones o ON d.IdOracion = o.Id"
        sqlstring = sqlstring & " WHERE  d.Id='" & IdDialogo & "'"

        Dim objDataReader As SqlDataReader

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

        Catch ex As Exception
        End Try


        objDataReader = _comando.ExecuteReader

        If objDataReader.HasRows Then
            objDataReader.Read()
            IdDet = objDataReader(3)
        End If
        objDataReader.Close()
        _comando.Connection.Close()

        sqlstring = "Update Det_conversation Set status = @status"
        sqlstring = sqlstring & "  WHERE Det_Con = @Det_Con"
        _comando.CommandText = sqlstring
        _comando.Parameters.Clear()

        _comando.Parameters.AddWithValue("@status", status)
        _comando.Parameters.AddWithValue("@Det_Con", IdDet)
         
        _comando.Connection.Open()

        Try
            i = _comando.ExecuteNonQuery
        Catch ex As Exception
        End Try

        _comando.Connection.Close()


        If i > 0 Then
            btnstatus.Text = status
        Else
            MsgBox("No se guardo")
        End If

        dt.PrimaryKey = New DataColumn() {dt.Columns("Id")}
        Dim fila As DataRow = dt.Rows.Find(IdDialogo) ' Id = 1

        fila("status") = status



    End Sub

    Private Sub AbrirDetalle(sender, e)
        Dim frm As New frmMoverDetalleConversacion
        Dim leer = CType(sender, Button)
        Dim IdDialogo As Integer = CInt(leer.Tag)
        frm.Enc_Id = Id

        frm.SeleccionadoEscenas = IdDialogo
        frm.Show()
    End Sub

    Private Sub QuitarMouse(sender, e)

        Timer1.Enabled = False

        If picDetImagen = "like" Then
            picDet.Image = Image.FromFile("C:\legacy\Ingles\Imagenes_Ingles\femenino\like.png")
            '  pic.Image = Image.FromFile("C:\legacy\Ingles\Imagenes_Ingles\mute.png")
            pic.Image = Image.FromFile("C:\legacy\Ingles\Imagenes_Ingles\Sonido.png")
        Else
            ' picDet.Height = 110
            ' picDet.Width = 120
        End If

    End Sub

    Private Sub Reproducir(sender, e)
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim _rate As Double
        Dim IdPanel As String
        Dim Reproducciones As Integer
        Dim IdOracionItem As Integer

        pgrBar.Value = 0

        Dim pAudio = CType(sender, CircularPictureBox)
        Dim IdDialogo As Integer = CInt(pAudio.Tag)

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)
        Dim _Item As Integer
        _Item = str(1)


        Dim panel = CType(pAudio.Parent, Panel)
        Dim orden As Integer
        'Dim indice As Label
        picDet = CType(panel.Controls("pd_" & _Item), PictureBox)


        Dim txt = CType(panel.Controls("txtReproduccion_" & _Item), Label)

        If Not IsNothing(objtextOver) Then
            'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
        End If

        Dim myPen As New Pen(Color.Red, 2)
        Dim myPenClear As New Pen(Color.Beige, 2)

        Dim g As Graphics

        IdCurrent = IdDialogo

        If IdOver > 0 Then
            'g = pEtapa.Controls("pAux_" & IdPanel).Controls.Item("p_" & IdOver).CreateGraphics
            ' g.DrawRectangle(myPenClear, 0, 0, 40, 40)
        End If


        sqlstring = " SELECT          d.Id, d.IdOracion, d.Orden, d.IdConversacion, o.IMG, o.audio, o.rate, o.Gif, o.TextoPlano, o.Reproduccion, d.Personaje, o.personaje"
        sqlstring = sqlstring & " FROM            Tbl_Dialogos d INNER JOIN"

        If ModVar.Idioma = "EN" Then
            sqlstring = sqlstring & "  Oraciones o ON d.IdOracion = o.Id"
        Else
            sqlstring = sqlstring & "  Oraciones_FR o ON d.IdOracion = o.Id"
        End If

        sqlstring = sqlstring & " WHERE  d.Id='" & IdDialogo & "'"

        Dim objDataReader As SqlDataReader

        Try
            _comando.CommandText = sqlstring

            _comando.Connection.Open()

        Catch ex As Exception
        End Try

        Dim audio As String
        Dim _gif As String = ""
        Dim _IMG As String = ""
        Dim _Texto As String = ""
        Dim previousHeight As Integer = 0
        Dim personaje As String

        Try
            objDataReader = _comando.ExecuteReader

            If objDataReader.HasRows Then

                objDataReader.Read()

                IdOracionItem = objDataReader(1)
                _rate = objDataReader(6)

                If Not IsDBNull(objDataReader(4)) Then
                    IMG = objDataReader(4)
                End If

                If Not IsDBNull(objDataReader(9)) Then
                    Reproducciones = objDataReader(9)
                End If

                If Not IsDBNull(objDataReader(11)) Then
                    personaje = objDataReader(11)
                Else
                    If Not IsDBNull(objDataReader(10)) Then
                        personaje = objDataReader(10)
                    End If
                End If

                If Not IsDBNull(objDataReader(2)) Then
                    orden = objDataReader(2)
                End If
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()

        Dim Cuen

        Dim n As UInteger = 0
        Dim archivo As String

        If personaje = "A" Then
            archivo = "C:\legacy\Ingles\Audios3\Femenino\" & IdOracionItem & ".mp3"
            picDetImagen = IMG
        ElseIf personaje = "B" Then
            archivo = "C:\legacy\Ingles\Audios3\Masculino\" & IdOracionItem & ".mp3"
            picDetImagen = ""
        ElseIf personaje = "C" Then
            archivo = "C:\legacy\Ingles\Audios3\Femenino\" & IdOracionItem & ".mp3"
            picDetImagen = ""
        End If

         If Not File.Exists(archivo) Then ' El archivo existe
            archivo = "C:\legacy\Ingles\Audios2\Femenino\" & IdOracionItem & ".mp3"
        End If


        Try
            If Not IsNothing(LastPanel) Then
                Dim picDetAnterior As PictureBox = CType(LastPanel.Controls("pd_" & LastId), PictureBox)
                Dim picAnterior = CType(LastPanel.Controls("pAudio_" & LastId), CircularPictureBox)

                picAnterior.Image = Image.FromFile("C:\legacy\Ingles\Imagenes_Ingles\Sonido.png")
                If LastIdItem <> IdDialogo Then
                    picDetAnterior.Height = 110
                    picDetAnterior.Width = 120
                End If
            End If

        Catch ex As Exception
        End Try


        pic = sender


        If IMG <> "" Then
            If IMG = "like" And personaje = "A" Then
                picDet.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\femenino\animacion.gif")
                ' picDet.Tag = "animacion.gif"
            End If
        End If

        Dim resp As Integer

        If File.Exists(archivo) Then ' El archivo existe
            ' Player.controls.stop()
            Player.settings.rate = _rate
            Player.URL = archivo

            'player.Controls.play()
            'Timer1.Enabled = True

            sqlstring = "UPDATE Oraciones SET Reproduccion = @Reproduccion"
            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()

            _comando.Parameters.AddWithValue("@Reproduccion", Reproducciones + 1)
            _comando.Parameters.AddWithValue("@Id", IdOracionItem)
            _comando.Connection.Open()

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
            End Try
            _comando.Connection.Close()

            txt.Text = Reproducciones + 1

            If Reproducciones + 1 >= 10 Then
                txt.ForeColor = Color.Green
            Else
                txt.ForeColor = Color.Gainsboro
            End If

            pic.Image = Image.FromFile("C:\legacy\Ingles\Imagenes_Ingles\sonido.gif")

            ' If IsNothing(picDet.Image) Then
            If personaje = "C" Then
                picDet.Height = 220
                picDet.Width = 300
            End If
            'End If

            ' picDet.Height = 110
            ' picDet.Width = 120



        Else '' El archivo no existe

            If personaje = "A" Or personaje = "C" Then
                resp = MsgBox(" ¿ Crear audio femenino ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

                If resp = 6 Then

                    My.Computer.Audio.Stop()

                    Dim psi As New ProcessStartInfo()
                    psi.FileName = "python"
                    psi.Arguments = """C:\legacy\Programas\Voz_Natural\GenerarAudioF3.py"" " & IdOracionItem
                    psi.UseShellExecute = False
                    psi.RedirectStandardOutput = True
                    psi.CreateNoWindow = True

                    Dim p As Process = Process.Start(psi)
                    Dim resultado As String = p.StandardOutput.ReadToEnd()
                    p.WaitForExit()

                    'MessageBox.Show(resultado)
                End If

            ElseIf personaje = "B" Then 'Audio Masculino
                resp = MsgBox(" ¿ Crear audio voz Masculino ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

                If resp = 6 Then
                    My.Computer.Audio.Stop()
                    Dim psi As New ProcessStartInfo()
                    psi.FileName = "python"
                    psi.Arguments = """C:\legacy\Programas\Voz_Natural\generaraudioMasculino.py"" " & IdOracionItem
                    psi.UseShellExecute = False
                    psi.RedirectStandardOutput = True
                    psi.CreateNoWindow = True
                    Dim p As Process = Process.Start(psi)
                    Dim resultado As String = p.StandardOutput.ReadToEnd()
                    p.WaitForExit()
                    MessageBox.Show(resultado)
                End If

            End If

            'Reiniciar contador
            If Reproducciones > 0 Then
                resp = MsgBox("¿ Reiniciar contador ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

                If resp = 6 Then
                    sqlstring = "UPDATE Oraciones SET Reproduccion = @Reproduccion"
                    sqlstring = sqlstring & " WHERE Id = @Id"
                    _comando.CommandText = sqlstring
                    _comando.Parameters.Clear()

                    _comando.Parameters.AddWithValue("@Reproduccion", 0)
                    _comando.Parameters.AddWithValue("@Id", IdOracionItem)
                    _comando.Connection.Open()

                    Try
                        i = _comando.ExecuteNonQuery

                    Catch ex As Exception
                    End Try
                    _comando.Connection.Close()

                    ' pic = pEtapa.Controls(IdPanel).Controls.Item("p_" & IdDialogo)
                    pic.Image = Image.FromFile("C:\legacy\Ingles\Imagenes_Ingles\mute.png")
                    'pEtapa.Controls(sender.parent.name).Controls.Item("txtReproduccion_" & IdDialogo).Text = 0

                End If
            End If

        End If

        dt.PrimaryKey = New DataColumn() {dt.Columns("Id")}
        Dim fila As DataRow = dt.Rows.Find(IdDialogo) ' Id = 1

        fila("reproduccion") = Reproducciones + 1


        LastId = _Item
        LastPanel = panel


        LastIdItem = IdDialogo
        LastIdOracion = IdOracionItem


        Seleccionado = IdDialogo

    End Sub

#End Region

#Region "Controles Dialogo"
    Private Sub CambiarFavoritoDetalle(sender, e)
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim IdDialogo As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim _rate As Double
        nm = sender.Name
        Dim IdPanel As String
        Dim Reproducciones As Integer
        Dim IdOracionItem As Integer

        IdPanel = pEtapa.Controls(sender.parent.name).name

        str = nm.Split("_")
        tp = str(0)
        IdDialogo = str(1)

        Dim n As UInteger = 0
        Dim archivo As String

        Dim PicFavoritoDet As PictureBox

        'PicFavoritoDet = pEtapa.Controls(IdPanel).Controls.Item("btnFavoritoDet_" & IdDialogo)

        If sender.Tag = "S" Then
            sender.Tag = "N"
            sender.Image = ImageList1.Images.Item(5)
        Else
            sender.Tag = "S"
            sender.Image = ImageList1.Images.Item(4)
        End If


        Try

            sqlstring = "UPDATE Det_Conversation SET Favorito = @Favorito"
            sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"
            _comando.CommandText = sqlstring

            _comando.Parameters.Clear()

            _comando.Parameters.AddWithValue("@Favorito", sender.Tag)
            _comando.Parameters.AddWithValue("@Det_Con", IdDialogo)

            _comando.Connection.Open()

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            ' _comando.Connection.Close()
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()



    End Sub

    Private Sub CambiarImagenDialogo(sender, e)
        Dim sqlstring As String
        Dim IdDet As Integer

        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer


        Dim Id As Integer
        Dim IdPerson As Integer
        Dim TipoTicket As String

        Dim resp As Integer
        Dim obj As PictureBox

        Dim _comando As SqlCommand
        Dim filename As String = ""

        Dim Nombre As String
        Dim Personaje As String



        Dim pic = CType(sender, PictureBox)
        Dim IdDialogo As Integer
        Try
            IdDialogo = CInt(pic.Tag)
        Catch ex As Exception
            Exit Sub
        End Try
        Dim panel = CType(pic.Parent, Panel)

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)
        Dim _Item As Integer
        _Item = str(1)

        Personaje = sender.text


        'Busca y actualiza si no existe en Oraciones
        _comando = MetodosDatos.CrearComando()

        ' Nombre = pEtapa.Controls(sender.parent.name).controls("pd_" & IdDet).text

        Dim CarpetaInicio As String
        If Personaje = "A" Then
            CarpetaInicio = "C:\Legacy\Ingles\Imagenes_Ingles\Femenino\"
        Else
            CarpetaInicio = "C:\Legacy\Ingles\Imagenes_Ingles\Masculino\"
        End If

        sqlstring = " SELECT    Id, IdOracion"
        sqlstring = sqlstring & " FROM            Tbl_Dialogos "
        sqlstring = sqlstring & " WHERE  Id='" & IdDialogo & "'"
        _comando.CommandText = sqlstring

        Try
            _comando.Connection.Open()

        Catch ex As Exception
        End Try

        Dim audio As String
        Dim _gif As String = ""
        Dim _IMG As String = ""
        Dim _Texto As String = ""
        Dim previousHeight As Integer = 0

        Dim objDataReader As SqlDataReader


        Try
            objDataReader = _comando.ExecuteReader

            If objDataReader.HasRows Then
                objDataReader.Read()
                IdOracionItem = objDataReader(1)
                IdOracionItem = objDataReader(1)
            End If
        Catch ex As Exception
        End Try
        objDataReader.Close()

        ' Clipboard.SetText(nm)


        ' Seleccionar Imagen
        Using ofd As New OpenFileDialog
            ofd.InitialDirectory = CarpetaInicio

            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim _insertado As Boolean = False
                Dim mostrarMensaje As Boolean = False
                Dim stringvalues As String = ""
                Dim sql As String = ""


                filename = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName)
                'Actualiza en Tbl Dialogos
                ' _comando.Connection.Open()

                sqlstring = "UPDATE Oraciones SET IMG= @IMG"
                sqlstring = sqlstring & " WHERE Id = @Id"

                _comando.CommandText = sqlstring

                _comando.Parameters.Clear()
                _comando.Parameters.AddWithValue("@IMG", filename)
                _comando.Parameters.AddWithValue("@Id", IdOracionItem)


                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    _comando.Connection.Close()
                    Exit Sub
                End Try

                Try
                    pic.Image = Image.FromFile(CarpetaInicio & ofd.SafeFileName)

                Catch ex As Exception

                End Try


            End If


            _comando.Connection.Close()

            ' Dim fila As DataRow = dt.Rows(0)
            dt.PrimaryKey = New DataColumn() {dt.Columns("Id")}
            Dim fila As DataRow = dt.Rows.Find(IdDialogo) ' Id = 1
            'dt.AcceptChanges()
            'dt.Clear()
            'da.Fill(dt)
            fila("IMG_Oracion") = filename


        End Using


    End Sub

#End Region

#Region "Player"
    Private Sub Player_PlayStateChange(ByVal NewState As Integer) Handles Player.PlayStateChange
        If NewState = WMPPlayState.wmppsMediaEnded Then

            If picDetImagen = "like" Then
                picDet.Image = Image.FromFile("C:\legacy\Ingles\Imagenes_Ingles\femenino\like.png")
            Else

            End If


        End If

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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click

        'If Aprendidos <> n Then
        '  GuardarAvance(Cantidad, Aprendidos)
        ' End If
        'pEtapa.Visible = False

        For i As Integer = pEtapa.Controls.Count - 1 To 0 Step -1
            Dim ctrl = pEtapa.Controls(i)

            ' liberar imagen si es PictureBox
            If TypeOf ctrl Is PictureBox Then
                Dim pic = CType(ctrl, PictureBox)
                If pic.Image IsNot Nothing Then
                    pic.Image.Dispose()
                    pic.Image = Nothing
                End If
            End If

            ctrl.Dispose()
        Next

        pEtapa.Controls.Clear()


        Me.Close()
        Me.Dispose()


    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lstOraciones_DoubleClick(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub lstOraciones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub CmdUp_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub RichTextBoxEx1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        MsgBox("test")

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        Dim IdOracion As Integer


        ' sqlstring = "select * from  SubTemas "
        '    conexion.Open()
        '' If cmbPersona.Text = "" Then Exit Sub
        ' IdOracion = txtId.Text


        Dim frm As New frmNewConversation
        frm.IdOracion = IdOracion
        '  frm.IdPersona = cmbPersona.Text

        frm.ShowDialog()

        ' CrearControles(filtro)

        ' CrearControles(filtro, inicio, fin)




    End Sub

    Private Sub cmbConversation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Dim frm As New FrmDetOracion


        ' Id = cmbConversation.Items(cmbConversation.SelectedIndex).ItemData()

        ' CrearControles(filtro)
        'CrearControles(filtro, inicio, fin)

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub CmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click

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

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click

    End Sub

    Private Sub wait(ByVal seconds As Integer)
        For i As Integer = 0 To seconds * 100
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next


    End Sub

    Private Sub cmdStop_Click(sender As System.Object, e As System.EventArgs) Handles cmdStop.Click

        If cmdStop.Text = "Stop" Then
            cmdStop.Text = "Speaking"
        Else
            cmdStop.Text = "Stop"

        End If

    End Sub

    Private Sub SpeakCompletedEventArgs()
        MsgBox("Speach Done")

    End Sub

    Private Sub cboVoice_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TrackBarVelocidad_Scroll(sender As System.Object, e As System.EventArgs)

        txtVelocidad.Text = TrackBarVelocidad.Value / 10

    End Sub

    Private Sub cmdAudio_Click(sender As System.Object, e As System.EventArgs) Handles cmdAudio.Click

    End Sub

    Private Sub checkMostrarTexto_CheckedChanged(sender As System.Object, e As System.EventArgs)


    End Sub

    Private Sub cmdOraciones_Click(sender As System.Object, e As System.EventArgs)
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





    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs)
        Dim frm As New frmTexto
        frm.Con_Id = Id
        frm.Show()

    End Sub

    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)

        ' detectar si el mouse está sobre pEtapa
        If pEtapa.Bounds.Contains(Me.PointToClient(Cursor.Position)) Then

            Dim velocidad As Integer = 150
            Dim delta As Integer = -e.Delta

            Dim nuevoValor As Integer = vScroll.Value + (delta \ 120) * velocidad

            If nuevoValor < vScroll.Minimum Then nuevoValor = vScroll.Minimum
            If nuevoValor > vScroll.Maximum Then nuevoValor = vScroll.Maximum

            vScroll.Value = nuevoValor

            ActualizarVista()

        Else
            MyBase.OnMouseWheel(e)
        End If

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

    End Sub

    Private Sub TrackBarVolumen_Scroll(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cmdtext_Click(sender As System.Object, e As System.EventArgs) Handles cmdtext.Click
        Dim frm As New frmTexto

        AddOwnedForm(frm)

        frm.Con_Id = Id
        frm.Show()


    End Sub

    Private Sub cmdRandom_Click(sender As System.Object, e As System.EventArgs) Handles cmdRandom.Click

    End Sub

    Private Sub checkMostrarTestES_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkMostrarTestES.CheckedChanged

    End Sub

    Private Sub checkMostrarTextoES_CheckedChanged(sender As System.Object, e As System.EventArgs)

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

    Private Sub cmdRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefresh.Click
        'checkMostrarTexto.Checked = True
        'checkMostrarTextoES.Checked = True
        'For Each ctrl As Control In pEtapa.Controls
        '    ctrl.Dispose()
        ''Next
        'For Each ctrl As Control In pEtapa.Controls
        '    ctrl.Dispose()
        'Next

        'pEtapa.Controls.Clear()
        'GC.Collect()
        'GC.WaitForPendingFinalizers()

        'For Each ctrl As Control In pEtapa.Controls
        '    LiberarImagenes(ctrl)
        'Next
        pEtapa.SuspendLayout()

        For Each ctrl As Control In pEtapa.Controls
            ctrl.Dispose()
        Next

        pEtapa.Controls.Clear()
        poolPanels.Clear()

        pEtapa.ResumeLayout()

        CrearControles()

        ' Timer1.Enabled = True

    End Sub

    Private Sub OracionesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OracionesToolStripMenuItem.Click
        Dim frm As New FrmOraciones

        frm.ShowDialog()

    End Sub

    Private Sub OrdenarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OrdenarToolStripMenuItem.Click
        Dim frm As New frmMoverDetalleConversacion
        frm.Enc_Id = Id

        frm.SeleccionadoEscenas = Seleccionado
        frm.Show()
    End Sub

    Private Sub AgregarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AgregarToolStripMenuItem.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer
        Dim resp As Boolean

        IdPerson = 3

        _comando.Connection.Open()

        _comando.Parameters.Clear()

        sqlstring = "Insert into Det_Conversation (Det_Orden, Con_Id)"
        sqlstring = sqlstring & " Values (@Det_Orden, '" & Id & "')"

        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@Det_Orden", 100)

        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                resp = True
            Else
                resp = False
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        ' _comando.Connection.Close()

        'If resp Then
        '    MsgBox("se guardo")

        '    CrearControles()

        'Else
        '    MsgBox("No se guardo")
        'End If

        Dim sql As String
        Dim IdDetNuevo As Integer

        Try
            If i > 0 Then
                sql = "SELECT @@IDENTITY FROM Det_conversation"

                _comando = New SqlCommand(sql, _comando.Connection)

                Dim value As Object = _comando.ExecuteScalar

                IdDetNuevo = value.ToString
            End If
            _comando.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        _comando.Connection.Close()

        Dim frm As New frmTransferir

        AddOwnedForm(frm)

        frm.Id = Id
        frm.IdDet = IdDetNuevo
        'frm.IdConversation = Id
        frm.ShowDialog()


    End Sub

    Private Sub cmdMostrarTexto_Click(sender As System.Object, e As System.EventArgs) Handles cmdMostrarTexto.Click
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        'If cmdMostrarTexto.Text = "" Then Exit Sub

        If cmdMostrarTexto.Text = "Mostrar Texto" Then

            ' RichTextBox1.Visible = True
            For Each c In pEtapa.Controls

                nm = c.name

                For Each ctrl As Control In c.controls
                    If TypeOf ctrl Is RichTextBox Then
                        ' Dim txtBox As TextBox = DirectCast(ctrl, TextBox)
                        ctrl.Visible = True
                    End If
                Next

            Next

            cmdMostrarTexto.Text = "Ocultar Texto"
        Else
            'RichTextBox1.Visible = False

            For Each c In pEtapa.Controls

                For Each ctrl As Control In c.controls
                    If TypeOf ctrl Is RichTextBox Then
                        ' Dim txtBox As TextBox = DirectCast(ctrl, TextBox)
                        ctrl.Visible = False
                    End If
                Next
                'pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Visible = False
                'pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Refresh()
                'pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Visible = False
                'pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Refresh()

            Next

            cmdMostrarTexto.Text = "Mostrar Texto"
        End If
    End Sub

    Private Sub cmdMostrarTrad_Click(sender As System.Object, e As System.EventArgs) Handles cmdMostrarTrad.Click
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        ' If checkMostrarTextoES.Text = "" Then Exit Sub

        If cmdMostrarTrad.Text = "Mostrar Trad" Then

            For Each c In pEtapa.Controls

                nm = c.name

                For Each ctrl As Control In c.controls
                    If TypeOf ctrl Is RichTextBox Then
                        ' Dim txtBox As TextBox = DirectCast(ctrl, TextBox)
                        If Split(ctrl.Name, "_")(0) = "trad" Then
                            ctrl.Visible = True

                        End If
                    End If
                Next

            Next

            cmdMostrarTrad.Text = "Ocultar Trad"
        Else

            For Each c In pEtapa.Controls


                For Each ctrl As Control In c.controls
                    If TypeOf ctrl Is RichTextBox Then
                        If Split(ctrl.Name, "_")(0) = "trad" Then
                            ctrl.Visible = False
                        End If
                        ' Dim txtBox As TextBox = DirectCast(ctrl, TextBox)
                    End If
                Next

            Next

            cmdMostrarTrad.Text = "Mostrar Trad"
        End If
    End Sub

    Private Sub cmdFaltan_Click(sender As System.Object, e As System.EventArgs) Handles cmdFaltan.Click

        Dim resp As Integer

        pEtapa.SuspendLayout()

        For Each ctrl As Control In pEtapa.Controls
            ctrl.Dispose()
        Next

        pEtapa.Controls.Clear()
        poolPanels.Clear()


        resp = MsgBox("¿Solo Faltantes?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

        If resp = 6 Then
            'filtro = " AND dc.status = 'R'"
            ' -- 🔥 CLAVE: validar si existe al menos un STL = 0 en ese grupo
            filtro = filtro & " AND EXISTS ("
            filtro = filtro & "      Select 1"
            filtro = filtro & "      FROM Tbl_Dialogos d2"
            filtro = filtro & "     INNER JOIN Oraciones o2 "
            filtro = filtro & "         ON d2.IdOracion = o2.Id"
            filtro = filtro & "     WHERE(d2.IdConversacion = dc.Det_Con)"
            filtro = filtro & "       AND o2.STL = 0)"

            CrearControles()
        Else
            filtro = ""
            CrearControles()

        End If

        pEtapa.ResumeLayout()


    End Sub

    Private Sub txtFaltan_Click(sender As System.Object, e As System.EventArgs) Handles txtFaltan.Click
        Dim mitad As String
        mitad = (250 * MinFaltante) - 250
        pEtapa.AutoScrollPosition = New Point(0, mitad)
    End Sub

    Private Sub TrackBarVolumen_Scroll_1(sender As System.Object, e As System.EventArgs) Handles TrackBarVolumen.Scroll

    End Sub

    Private Sub Label9_Click(sender As System.Object, e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub cmdSiguiente_Click(sender As System.Object, e As System.EventArgs)
        'pEtapa.Visible = False

        For i As Integer = pEtapa.Controls.Count - 1 To 0 Step -1
            Dim ctrl = pEtapa.Controls(i)

            ' liberar imagen si es PictureBox
            If TypeOf ctrl Is PictureBox Then
                Dim pic = CType(ctrl, PictureBox)
                If pic.Image IsNot Nothing Then
                    pic.Image.Dispose()
                    pic.Image = Nothing
                End If
            End If

            ctrl.Dispose()
        Next

        pEtapa.Controls.Clear()


        inicio += 50
        fin += 50

        Timer1.Enabled = True

    End Sub

    Private Sub cmdAnterior_Click(sender As System.Object, e As System.EventArgs)
        'pEtapa.Visible = False

        For i As Integer = pEtapa.Controls.Count - 1 To 0 Step -1
            Dim ctrl = pEtapa.Controls(i)

            ' liberar imagen si es PictureBox
            If TypeOf ctrl Is PictureBox Then
                Dim pic = CType(ctrl, PictureBox)
                If pic.Image IsNot Nothing Then
                    pic.Image.Dispose()
                    pic.Image = Nothing
                End If
            End If

            ctrl.Dispose()
        Next

        pEtapa.Controls.Clear()


        inicio -= 50
        fin -= 50

        If inicio < 0 Then
            inicio = 0
            fin = 50
        End If

        Timer1.Enabled = True

    End Sub

    Private Sub pEtapa_Click(sender As Object, e As System.EventArgs) Handles pEtapa.Click

        QuitarMouse(sender, e)

    End Sub

    Private Sub pEtapa_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pEtapa.MouseMove

        QuitarMouse(sender, e)

    End Sub

    Private Sub pEtapa_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pEtapa.Paint

    End Sub

    Private Sub cmdFavoritos_Click(sender As System.Object, e As System.EventArgs) Handles cmdFavoritos.Click


        pEtapa.SuspendLayout()

        For Each ctrl As Control In pEtapa.Controls
            ctrl.Dispose()
        Next

        pEtapa.Controls.Clear()
        poolPanels.Clear()

        filtro = ""

        If cmdFavoritos.Text = "Favoritos" Then

            filtro = filtro & " AND EXISTS ("
            filtro = filtro & "      Select 1"
            filtro = filtro & "      FROM Tbl_Dialogos d2"
            filtro = filtro & "     INNER JOIN Oraciones o2 "
            filtro = filtro & "         ON d2.IdOracion = o2.Id"
            filtro = filtro & "     WHERE(d2.IdConversacion = dc.Det_Con)"
            filtro = filtro & "       AND o2.favorito = 'N')"

            CrearControles()

            cmdFavoritos.Text = "No_Favoritos"

        Else

            filtro = filtro & " AND EXISTS ("
            filtro = filtro & "      Select 1"
            filtro = filtro & "      FROM Tbl_Dialogos d2"
            filtro = filtro & "     INNER JOIN Oraciones o2 "
            filtro = filtro & "         ON d2.IdOracion = o2.Id"
            filtro = filtro & "     WHERE(d2.IdConversacion = dc.Det_Con)"
            filtro = filtro & "       AND o2.favorito = 'S')"

            CrearControles()

            cmdFavoritos.Text = "Favoritos"

        End If


        pEtapa.ResumeLayout()


    End Sub

    Private Sub AbrirCarpetaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AbrirCarpetaToolStripMenuItem.Click
        Dim ruta As String = "C:\Legacy\Ingles\Imagenes_Ingles\Sustantivos"

        If IO.Directory.Exists(ruta) Then
            Process.Start(New ProcessStartInfo With {
                .FileName = ruta,
                .UseShellExecute = True
            })
        Else
            MessageBox.Show("La carpeta no existe")
        End If
    End Sub

    Private Sub wmp_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent)

        Select Case e.newState

            Case WMPLib.WMPPlayState.wmppsBuffering
                ' picDet.Visible = True
                picDet.BringToFront()
                ' picDet.Refresh()

                ' picDet.BringToFront()

            Case WMPLib.WMPPlayState.wmppsPlaying

                TimerVideo.Start()
                TimerEnd.Start()
            Case WMPLib.WMPPlayState.wmppsMediaEnded

                ' TimerEnd.Start()

        End Select

    End Sub

    '    Private Sub AxWindowsMediaPlayer1_PlayStateChange(
    '    sender As Object,
    '    e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent
    ') Handles AxWindowsMediaPlayer1.PlayStateChange

    '        Select Case e.newState

    '            Case WMPLib.WMPPlayState.wmppsPlaying

    '                If FadeIniciado = False Then

    '                    FadeIniciado = True

    '                    IniciarFadeIn()

    '                End If

    '            Case WMPLib.WMPPlayState.wmppsMediaEnded

    '                PictureBox1.BringToFront()

    '        End Select

    '    End Sub
    'Private Sub TimerFade_Tick(sender As Object, e As EventArgs) Handles TimerFade.Tick

    '    If FadeMode = "OUT" Then
    '        FadeLevel += 10
    '        If FadeLevel >= 255 Then
    '            FadeLevel = 255
    '            TimerFade.Stop()
    '            PanelFade.BackColor = Color.FromArgb(FadeLevel, 0, 0, 0)
    '            PanelFade.Refresh()
    '            PictureBox1.SendToBack()
    '            AxWindowsMediaPlayer1.URL = ArchivoPendiente
    '            AxWindowsMediaPlayer1.Ctlcontrols.play()
    '            Exit Sub

    '        End If

    '    ElseIf FadeMode = "IN" Then
    '        FadeLevel -= 10

    '        If FadeLevel <= 0 Then

    '            FadeLevel = 0

    '            TimerFade.Stop()

    '            PanelFade.Visible = False

    '            Exit Sub

    '        End If

    '    End If

    '    PanelFade.BackColor = Color.FromArgb(FadeLevel, 0, 0, 0)

    'End Sub
    'Private Sub IniciarFadeIn()
    '    If TimerFade.Enabled Then Exit Sub

    '    FadeMode = "IN"

    '    FadeLevel = 255

    '    PanelFade.Visible = True
    '    PanelFade.BringToFront()

    '    TimerFade.Start()
    'End Sub

    'Private Sub IniciarFadeOut()
    '    If TimerFade.Enabled Then Exit Sub

    '    FadeIniciado = False

    '    FadeMode = "OUT"

    '    FadeLevel = 0

    '    PanelFade.Visible = True
    '    PanelFade.BringToFront()

    '    TimerFade.Start()


    'End Sub

    Private Sub TimerEnd_Tick(sender As System.Object, e As System.EventArgs) Handles TimerEnd.Tick
        Try

            If yaMostro Then Exit Sub

            Dim duracion As Double =
                wmp.currentMedia.duration

            Dim posicion As Double =
                wmp.Ctlcontrols.currentPosition

            If duracion - posicion <= 0.1 Then
                yaMostro = True
                TimerEnd.Stop()
                picDet.Visible = True
                'picDet.BringToFront()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TimerVideo_Tick(sender As System.Object, e As System.EventArgs) Handles TimerVideo.Tick

        TimerVideo.Stop()
        TimerVideo.Enabled = False

        ' picDet.SendToBack()
        picDet.Visible = False
    End Sub

    Private Sub ReproducirAudio(sender, e)
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim _rate As Double
        Dim IdPanel As String
        Dim Reproducciones As Integer
        Dim IdOracionItem As Integer

        Dim Idioma As String

        pgrBar.Value = 0

        Dim pAudio = CType(sender, CircularPictureBox)
        Dim IdDialogo As Integer = CInt(pAudio.Tag)

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)

        Dim _Item As Integer
        _Item = str(1)


        Dim panel = CType(pAudio.Parent, Panel)
        Dim orden As Integer
        picDet = CType(panel.Controls("pd_" & _Item), PictureBox)

        wmp.Location = picDet.Location

 

        panel.Controls.Add(wmp)


        Dim btn As Button
        btn = CType(panel.Controls("txtpersonaje_" & _Item), Button)


        Dim txt = CType(panel.Controls("txtReproduccion_" & _Item), Label)
        Dim texto = CType(panel.Controls("txt_" & _Item), RichTextBox)


        If Not IsNothing(objtextOver) Then
            'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
        End If

        Dim myPen As New Pen(Color.Red, 2)
        Dim myPenClear As New Pen(Color.Beige, 2)

        Dim g As Graphics

        IdCurrent = IdDialogo

        If IdOver > 0 Then
            'g = pEtapa.Controls("pAux_" & IdPanel).Controls.Item("p_" & IdOver).CreateGraphics
            ' g.DrawRectangle(myPenClear, 0, 0, 40, 40)
        End If

        If ModVar.Idioma = "EN" Then
            sqlstring = " SELECT          d.Id, d.IdOracion, d.Orden, d.IdConversacion, o.IMG, o.audio, o.rate, o.Gif, o.TextoPlano, o.Reproduccion, d.Personaje, o.personaje, o.voice, o.expresion"
            sqlstring = sqlstring & " FROM            Tbl_Dialogos_FR d INNER JOIN"
            sqlstring = sqlstring & "                    Oraciones_FR o ON d.IdOracion = o.Id"
            sqlstring = sqlstring & " WHERE  d.Id='" & IdDialogo & "'"
        Else
            sqlstring = " SELECT          d.Id, d.IdOracion, d.Orden, d.IdConversacion, o.IMG, o.audio, o.rate, o.Gif, o.TextoPlano, o.Reproduccion, d.Personaje, o.personaje, o.voice, o.expresion"
            sqlstring = sqlstring & " FROM            Tbl_Dialogos_FR d INNER JOIN"
            sqlstring = sqlstring & "                    Oraciones_FR o ON d.IdOracion = o.Id"
            sqlstring = sqlstring & " WHERE  d.Id='" & IdDialogo & "'"
        End If




        Dim objDataReader As SqlDataReader

        Try
            _comando.CommandText = sqlstring

            _comando.Connection.Open()

        Catch ex As Exception
        End Try

        Dim audio As String
        Dim _gif As String = ""
        Dim _IMG As String = ""
        Dim _Texto As String = ""
        Dim previousHeight As Integer = 0
        Dim personaje As String
        Dim voice As String

        Try
            objDataReader = _comando.ExecuteReader

            If objDataReader.HasRows Then

                objDataReader.Read()

                IdOracionItem = objDataReader(1)

                _rate = objDataReader(6)

                If Not IsDBNull(objDataReader(4)) Then
                    IMG = objDataReader(4)
                End If

                If Not IsDBNull(objDataReader(9)) Then
                    Reproducciones = objDataReader(9)
                End If

                If Not IsDBNull(objDataReader(11)) Then
                    personaje = objDataReader(11)
                Else
                    If Not IsDBNull(objDataReader(10)) Then
                        personaje = objDataReader(10)
                    End If
                End If

                If Not IsDBNull(objDataReader(2)) Then
                    orden = objDataReader(2)
                End If

                If Not IsDBNull(objDataReader(12)) Then
                    voice = objDataReader(12)
                End If

                If Not IsDBNull(objDataReader(13)) Then
                    expresion = objDataReader(13)
                End If
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()

        ' Reproducir al x % de velocidad
        wmp.settings.rate = _rate

        Dim n As UInteger = 0
        Dim archivo As String

        If voice = "Matilda" Then

        ElseIf voice = "Jessica" Then

        ElseIf voice = "x" Then
            picDetImagen = ""
            NombreImagen = "x.jpg"
        Else
            NombreImagen = "Matilda.jpg"
        End If

        ' Nombre de la Imagen
        NombreImagen = voice & "_" & expresion & ".jpg"

        '==================
        ' Audio
        '===================
        If ModVar.Idioma = "EN" Then
            archivo = "C:\Ingles\Audios3\Femenino\" & IdOracionItem & ".mp3"
        Else
            archivo = "C:\frances\Audios\Femenino\" & IdOracionItem & ".mp3"
        End If


        If Not File.Exists(archivo) Then ' El archivo existe
            archivo = "C:\Ingles\Audios2\Femenino\" & IdOracionItem & ".mp3"
        End If

        ' PictureBox1.Image = Imagenes("matilda.jpg")
        ' PictureBox1.Image = Image.FromFile(Imagen)

        'If personaje <> "C" Then
        '    ' If Not IsNothing(picDet) Then
        '    picDet.Height = 110
        '    picDet.Width = 120
        '    'End If
        'End If

        ' texto.Location = New Point(pAudio.Right + 10, pd.Bottom + 5)
        ' texto.Visible = True
        ' btn.BackColor = Color.Yellow

        texto.Location = New Point(sender.Right + 10, picDet.Bottom + 5)


        '==================================
        'Anterior
        '=================================
        ' panel.BackColor = Color.LightGray

        Try
            If Not IsNothing(LastPanel) Then
                ' Dim picDetAnterior As PictureBox = CType(LastPanel.Controls("pd_" & LastId), PictureBox)
                ' Dim picAnterior = CType(LastPanel.Controls("pAudio_" & LastId), CircularPictureBox)
                Dim btnAnterior = CType(pEtapa.Controls(LastPanel.Name).Controls("pAudio_" & LastId), CircularPictureBox)

                ' picAnterior.Image = Image.FromFile("C:\legacy\Ingles\Imagenes_Ingles\Sonido.png")
                If LastIdItem <> IdDialogo Then
                    ' picDetAnterior.Height = 110
                    ' picDetAnterior.Width = 120
                    ' texto.Location = New Point(picAnterior.Right + 10, picAnterior.Bottom + 5)
                    'btnAnterior.BackColor = Color.LightGray
                    ' btnAnterior.Visible = False
                    ' LastPanel.BackColor = Color.LightGreen
                    btnAnterior.Image = imgSonido
                End If
                ' btnAnterior.Refresh()
                ' LastPanel.Tag = IdDialogo
                ' LastPanel.Name = IdDialogo

            End If

        Catch ex As Exception
        End Try

        pic = sender

        Dim imgGif As Image
        If IMG <> "" Then
            If IMG = "like" And personaje = "A" Then
                ' AxWindowsMediaPlayer1.URL = "C:\Legacy\video.mp4"
                ' AxWindowsMediaPlayer1.settings.autoStart = True
                'imgGif = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\femenino\animacion.gif")
                'ImageAnimator.StopAnimate(imgGif, Nothing)

                'picDet.Image = imgGif
                '' picDet.Tag = "animacion.gif"
                '' Obtener frames
                'Dim dimension As New FrameDimension(imgGif.FrameDimensionsList(0))
                'frameCount = imgGif.GetFrameCount(dimension)
                'currentFrame = 0

                '' Evitar duplicar handler
                'RemoveHandler Application.Idle, AddressOf AnimateGif
                'AddHandler Application.Idle, AddressOf AnimateGif

            End If
        End If

        Dim resp As Integer

        archivo = "C:\Ingles\Videos\" & IdOracionItem & ".mp4"

        If picDet.Image IsNot Imagenes(NombreImagen) Then
            picDet.Image = Imagenes(NombreImagen)
        End If

        '  picDet.Visible = False  'Quitar esta linea

        If File.Exists(archivo) Then ' El archivo existe

            'picDet.BringToFront()
            'picDet.Visible = True
            wmp.URL = archivo

            wmp.Ctlcontrols.play()

           
            pic.Image = Image.FromFile("C:\Ingles\Imagenes_Ingles\sonido.gif")

            If btn.Text = "-" Then
                If personaje = "C" Then
                    ' picDet.Height = 210
                    ' picDet.Width = 300
                    texto.Location = New Point(picDet.Left, picDet.Bottom + 1)
                    '  panel.Controls.Add(textoCopy)
                End If
            Else
            End If

            ' texto.Visible = False

        Else '' El archivo no existe
            picDet.SendToBack()

            If Idioma = "EN" Then
                archivo = "C:\Ingles\Audios3\femenino\" & IdOracionItem & ".mp3"
            Else
                archivo = "C:\frances\Audios\femenino\" & IdOracionItem & ".mp3"

            End If

            If File.Exists(archivo) Then
                wmp.URL = archivo

                wmp.Ctlcontrols.play()

                If ModVar.Idioma = "EN" Then
                    sqlstring = "UPDATE Oraciones SET Reproduccion = @Reproduccion"
                Else
                    sqlstring = "UPDATE Oraciones_FR SET Reproduccion = @Reproduccion"

                End If
                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Reproduccion", Reproducciones + 1)
                _comando.Parameters.AddWithValue("@Id", IdOracionItem)
                _comando.Connection.Open()

                Try
                    i = _comando.ExecuteNonQuery
                Catch ex As Exception
                End Try
                _comando.Connection.Close()

                'pEtapa.Controls(IdPanel).Controls.Item("txtReproduccion_" & IdDialogo).Text = Reproducciones + 1
                txt.Text = Reproducciones + 1

                If Reproducciones + 1 >= 10 Then
                    txt.ForeColor = Color.Green
                Else
                    txt.ForeColor = Color.Salmon
                End If

            Else
                If personaje = "A" Or personaje = "C" Then
                    resp = MsgBox(" ¿ Crear audio femenino ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

                    If resp = 6 Then

                        My.Computer.Audio.Stop()

                        Dim psi As New ProcessStartInfo()
                        psi.FileName = "python"
                        psi.Arguments = """C:\legacy\Programas\Voz_Natural\GeneraAudioF3.py"" " & IdOracionItem
                        psi.UseShellExecute = False
                        psi.RedirectStandardOutput = True
                        psi.CreateNoWindow = True

                        Dim p As Process = Process.Start(psi)
                        Dim resultado As String = p.StandardOutput.ReadToEnd()
                        p.WaitForExit()

                        'MessageBox.Show(resultado)
                    End If

                ElseIf personaje = "B" Then 'Audio Masculino
                    resp = MsgBox(" ¿ Crear audio voz Masculino ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

                    If resp = 6 Then
                        My.Computer.Audio.Stop()
                        Dim psi As New ProcessStartInfo()
                        psi.FileName = "python"
                        psi.Arguments = """C:\legacy\Programas\Voz_Natural\GeneraAudioM.py"" " & IdOracionItem
                        psi.UseShellExecute = False
                        psi.RedirectStandardOutput = True
                        psi.CreateNoWindow = True
                        Dim p As Process = Process.Start(psi)
                        Dim resultado As String = p.StandardOutput.ReadToEnd()
                        p.WaitForExit()
                        MessageBox.Show(resultado)
                    End If

                End If

                'Reiniciar contador
                If Reproducciones > 0 Then
                    resp = MsgBox("¿ Reiniciar contador ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

                    If resp = 6 Then
                        If ModVar.Idioma = "EN" Then
                            sqlstring = "UPDATE Oraciones SET Reproduccion = @Reproduccion"
                        Else
                            sqlstring = "UPDATE Oraciones_FR SET Reproduccion = @Reproduccion"

                        End If
                        sqlstring = sqlstring & " WHERE Id = @Id"
                        _comando.CommandText = sqlstring
                        _comando.Parameters.Clear()

                        _comando.Parameters.AddWithValue("@Reproduccion", 0)
                        _comando.Parameters.AddWithValue("@Id", IdOracionItem)
                        _comando.Connection.Open()

                        Try
                            i = _comando.ExecuteNonQuery

                        Catch ex As Exception
                        End Try
                        _comando.Connection.Close()

                        ' pic = pEtapa.Controls(IdPanel).Controls.Item("p_" & IdDialogo)
                        pic.Image = Image.FromFile("C:\legacy\Ingles\Imagenes_Ingles\mute.png")
                        ' pEtapa.Controls(sender.parent.name).Controls.Item("txtReproduccion_" & IdDialogo).Text = 0

                    End If
                End If
            End If


        End If

        dt.PrimaryKey = New DataColumn() {dt.Columns("Id")}
        Dim fila As DataRow = dt.Rows.Find(IdDialogo) ' Id = 1

        fila("reproduccion") = Reproducciones + 1

        LastId = _Item

        LastIdItem = IdDialogo
        LastIdOracion = IdOracionItem

        LastPanel.Name = panel.Name

        Seleccionado = IdDialogo

    End Sub


    Private Sub cmdReproducidos_Click(sender As System.Object, e As System.EventArgs) Handles cmdReproducidos.Click

        pEtapa.SuspendLayout()

        For Each ctrl As Control In pEtapa.Controls
            ctrl.Dispose()
        Next

        pEtapa.Controls.Clear()
        poolPanels.Clear()

        filtro = ""

        If cmdReproducidos.Text = "Reprod" Then

            filtro = filtro & " AND EXISTS ("
            filtro = filtro & "      Select 1"
            filtro = filtro & "      FROM Tbl_Dialogos d2"
            filtro = filtro & "     INNER JOIN Oraciones o2 "
            filtro = filtro & "         ON d2.IdOracion = o2.Id"
            filtro = filtro & "     WHERE(d2.IdConversacion = dc.Det_Con)"
            filtro = filtro & "       AND o2.reproduccion <= '30')"

            CrearControles()

            cmdReproducidos.Text = "No_Reprod"

        Else

            filtro = filtro & " AND EXISTS ("
            filtro = filtro & "      Select 1"
            filtro = filtro & "      FROM Tbl_Dialogos d2"
            filtro = filtro & "     INNER JOIN Oraciones o2 "
            filtro = filtro & "         ON d2.IdOracion = o2.Id"
            filtro = filtro & "     WHERE(d2.IdConversacion = dc.Det_Con)"
            filtro = filtro & "       AND o2.reproduccion > '30')"

            CrearControles()

            cmdReproducidos.Text = "Reprod"

        End If


        pEtapa.ResumeLayout()

    End Sub

#End Region

  
End Class
