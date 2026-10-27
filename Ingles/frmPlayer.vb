Imports System.Data
Imports Entidades
Imports Negocios

Imports System.Data.Sql
Imports System.Data.SqlClient

Imports System.IO
Imports SpeechLib
Imports System.Speech.Synthesis

Imports System.Speech.AudioFormat
 
Imports WMPLib
 
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop

Public Class frmPlayer
    Public texto As String
    Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer
    Dim startIndex As Integer
    Dim length As Integer
    Dim titulo As String
    Public filename As String
    Dim rate As Double
    Dim volumen As Double
    Private WithEvents synth As New SpeechSynthesizer()

    Dim speaker As New SpeechSynthesizer()

    Public handler As EventHandler(Of SpeakCompletedEventArgs)
    
    Private WithEvents speech As New SpVoice

    Public Event SpeakCompleted As EventHandler(Of SpeakCompletedEventArgs)
    Public Event SpeakWord As EventHandler(Of SpeakProgressEventArgs)

    Private hilo1 As Threading.Timer 'a


#Region "Player"
    Private Sub frmPlayer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.BringToFront()
        Dim ruta As String

        Dim mensaje As String

        '  mensaje = "In a small village nestled between mountains lived an altruistic woman named Clara, known for her generosity and empathy toward others. One day, while strolling through the market, she encountered an eloquent man speaking with such passion that he drew a crowd. He was witty, and his words were so persuasive that even the most skeptical stopped to listen."
        ruta = "C:\legacy\Ingles\Audios\"

        ' Dim SongLocation = Path.Combine(Application.StartupPath, ruta & ".mp3")
        CargarDatos("")
        CargarDatosListening("")
        CargarTraduccion()

        ' RichTextBox1.Text = mensaje
        AddHandler synth.SpeakProgress, AddressOf Synthesizer_SpeakProgress
        rate = tbVelocidad.Value / 10
        ' Player.URL = SongLocation
        Player.settings.rate = rate
        'Player.URL = ruta & filename & ".mp3"
        Player.URL = ruta & "AndiesJob.mp3"
        Player.controls.stop()

    End Sub
    Private Sub cmdPlay_Click(sender As System.Object, e As System.EventArgs) Handles cmdPlay.Click
        If cmdPlay.Text = "Play" Then
            'Play
            cmdPlay.Text = "Stop"
            cmdPlay.Refresh()

            'C:\legacy\audios
            'Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer

            Player.controls.currentPosition = 10
            Player.controls.play()

        Else
            'Stop
            cmdPlay.Text = "Play"

            Player.controls.stop()

        End If
    End Sub
    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Public Sub CargarDatos(Id)
        Dim param As String
        Dim resp As Integer
        Dim i, n As Integer
        Dim folderName As String = ""

        Dim ruta As String = "C:\Legacy\Ingles\Lectura\"
       
        Dim oWord As Word.Application
        Dim oDoc As Word.Document
        Dim archivo As String
        Dim carpeta As String

        archivo = ruta & filename & ".rtf" '& tipo

        If System.IO.File.Exists(archivo) Then
            ' RichTextBoxEx1.rtb.LoadFile(archivo) '.rtf"
            '  RichTextBox1.LoadFile(archivo)
            'RichTextBoxEx1.filename = archivo

        Else
            'Dim di As DirectoryInfo = Directory.CreateDirectory(archivo)

            ' Iniciar Word y crear un nuevo documento
            oWord = New Word.Application()
            oDoc = oWord.Documents.Add()


            oDoc.Content.Text = "Reporte No:" & Id ' Añadir texto al documento
            With oDoc.PageSetup
                .TopMargin = 20   ' 1 inch top margin
                .BottomMargin = 20 ' 1 inch bottom margin
                .LeftMargin = 20 ' 1.25 inch left margin
                .RightMargin = 20 ' 1.25 inch right margin
            End With
            ' Guardar el documento en una ruta específica

            ' oDoc.SaveAs(ruta & "\" & carpeta & "\" & filename & ".rtf")
            oDoc.SaveAs2(ruta & "\" & filename, Word.WdSaveFormat.wdFormatRTF)
            ' Cerrar el documento y salir de Word
            oDoc.Close()
            oWord.Quit()

            ' Liberar los objetos
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord)
            oDoc = Nothing
            oWord = Nothing

            MessageBox.Show("Archivo Word creado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            '  RichTextBox2.LoadFile(archivo)

        End If

      
    End Sub

    Public Sub CargarDatosListening(Id)
        Dim param As String
        Dim resp As Integer
        Dim i, n As Integer
        Dim folderName As String = ""

        lbltitulo.Text = filename
        Dim ruta As String = "C:\Legacy\Ingles\Lectura\"

        Dim oWord As Word.Application
        Dim oDoc As Word.Document
        Dim archivo As String
        Dim carpeta As String

        archivo = ruta & filename & "_test.rtf"

        If System.IO.File.Exists(archivo) Then
            ' RichTextBoxEx1.rtb.LoadFile(archivo) '.rtf"
            'RichTextBox1.LoadFile(archivo)
            'RichTextBoxEx1.filename = archivo
            ' RichTextBox2.LoadFile(archivo)
        Else
            'Dim di As DirectoryInfo = Directory.CreateDirectory(archivo)

            ' Iniciar Word y crear un nuevo documento
            oWord = New Word.Application()
            oDoc = oWord.Documents.Add()


            oDoc.Content.Text = "Test_" ' Añadir texto al documento
            With oDoc.PageSetup
                .TopMargin = 20   ' 1 inch top margin
                .BottomMargin = 20 ' 1 inch bottom margin
                .LeftMargin = 20 ' 1.25 inch left margin
                .RightMargin = 20 ' 1.25 inch right margin
            End With
            ' Guardar el documento en una ruta específica

            ' oDoc.SaveAs(ruta & "\" & carpeta & "\" & filename & ".rtf")
            oDoc.SaveAs2(ruta & filename & "_test", Word.WdSaveFormat.wdFormatRTF)
            ' Cerrar el documento y salir de Word
            oDoc.Close()
            oWord.Quit()


            ' Liberar los objetos
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord)
            oDoc = Nothing
            oWord = Nothing

            MessageBox.Show("Archivo Word creado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '   RichTextBox2.LoadFile(archivo)

        End If


    End Sub
    Public Sub CargarTraduccion()
        Dim param As String
        Dim resp As Integer
        Dim i, n As Integer
        Dim folderName As String = ""

        Dim ruta As String = "C:\Legacy\Ingles\Lectura\"

        Dim oWord As Word.Application
        Dim oDoc As Word.Document
        Dim archivo As String
        Dim carpeta As String

        archivo = ruta & filename & "_trad.rtf"

        If System.IO.File.Exists(archivo) Then
            ' RichTextBox3.LoadFile(archivo)
        Else
            'Dim di As DirectoryInfo = Directory.CreateDirectory(archivo)

            ' Iniciar Word y crear un nuevo documento
            oWord = New Word.Application()
            oDoc = oWord.Documents.Add()


            oDoc.Content.Text = "Traduccion" ' Añadir texto al documento
            With oDoc.PageSetup
                .TopMargin = 20   ' 1 inch top margin
                .BottomMargin = 20 ' 1 inch bottom margin
                .LeftMargin = 20 ' 1.25 inch left margin
                .RightMargin = 20 ' 1.25 inch right margin
            End With
            ' Guardar el documento en una ruta específica

            ' oDoc.SaveAs(ruta & "\" & carpeta & "\" & filename & ".rtf")
            oDoc.SaveAs2(ruta & filename & "_trad", Word.WdSaveFormat.wdFormatRTF)
            ' Cerrar el documento y salir de Word
            oDoc.Close()
            oWord.Quit()


            ' Liberar los objetos
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord)
            oDoc = Nothing
            oWord = Nothing

            MessageBox.Show("Archivo Word creado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '  RichTextBox3.LoadFile(archivo)

        End If


    End Sub
#End Region

#Region "Speech"
    Private Sub Synthesizer_SpeakProgress(sender As Object, e As SpeakProgressEventArgs)
        ' Clear any previous highlighting (optional, depending on desired effect)
        'RichTextBox1.SelectAll()
        'RichTextBox1.SelectionBackColor = Color.White ' Or your default background color

        '' Highlight the current word
        'RichTextBox1.Select(e.CharacterPosition, e.CharacterCount)
        'RichTextBox1.SelectionBackColor = Color.Yellow ' Or your desired highlight color
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ' synth.SpeakAsync(RichTextBox1.Text)
    End Sub
    Private Sub voice_EndStream(StreamNumber As Integer, StreamPosition As Object) Handles speech.EndStream
        
        'If Not IsNothing(objtextOver) Then
        '    'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
        '    objtextOver.BackColor = Color.Beige

        'End If

    End Sub
    Private Sub Voice_Word(StreamNumber As Integer, StreamPosition As Object, CharacterPosition As Integer, Length As Integer) Handles speech.Word
        'RichTextBox1.SelectAll()
        'RichTextBox1.SelectionBackColor = Color.White ' Or your default background color
        ''Highlight word in textbox as it is spoken  
        'RichTextBox1.Select(CharacterPosition, Length)
        '' Highlight the current word
        '' RichTextBox1.Select(e.CharacterPosition, e.CharacterCount)
        'RichTextBox1.SelectionBackColor = Color.Yellow ' Or your desired highlight color
        ' RichTextBox1.Focus()
    End Sub

    Private Sub voice_word(StreamNumber As Integer, StreamPosition As Object) Handles speech.StartStream

        'If Not IsNothing(objtextOver) Then
        '    'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
        '    objtextOver.BackColor = Color.Beige

        'End If

    End Sub
    
    Private Sub LeerTexto(sender, e)
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label

        'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(cmbVoices.SelectedIndex)

        '    speech.Resume()
        '    paused = False

        'End If

        'speech.Rate = speechRate
        'speech.Volume = volume
        '' speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFlagsAsync)
        '' speech.Speak("Text", SpeechVoiceSpeakFlags.SVSFlagsAsync)
        'speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFVoiceMask)


        Dim _voice As Integer
        
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


        Try
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
            pVoice.SetRate(-4)

            Try
                ' pVoice.Speak(RichTextBox1.Text, 0, n)
                ' Voice.Speak(TextToSay, SpeechVoiceSpeakFlags.SVSFlagsAsync) 
                'speech.Speak(RichTextBox1.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

            Catch ex As Exception

            End Try
 
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub
#End Region


    Private Sub cmdPause_Click(sender As System.Object, e As System.EventArgs) Handles cmdPause.Click

        If cmdPause.Text = "Continue" Then
            'Play
            cmdPause.Text = "Pause"
            cmdPause.Refresh()
            Player.controls.play()

        Else
            'pause
            cmdPause.Text = "Continue"

            Player.controls.pause()

        End If


    End Sub

    Private Sub cmdStop_Click(sender As System.Object, e As System.EventArgs)

        Player.controls.stop()

    End Sub
    
    Private WithEvents Timer1 As New Timer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Timer1.Interval = 100 ' Check every 100 milliseconds
        'Timer1.Start()

        Control.CheckForIllegalCrossThreadCalls = False  'Acceso a traves otro hilo 

        hilo1 = New Threading.Timer(AddressOf Tick, Nothing, 1000, 1000)

    End Sub
    Public Sub Tick(ByVal Parametro As Object)
         
        Dim _delay As TimeSpan
        
        ' txtCurrentPosition.Text = Player.controls.currentPosition
         

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
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
    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        LeerTexto("", 0)
    End Sub

    Private Sub tbVelocidad_Scroll(sender As System.Object, e As System.EventArgs) Handles tbVelocidad.Scroll
        'Player.controls.pause()
        Try
            rate = tbVelocidad.Value / 10

            Player.settings.rate = rate

        Catch ex As Exception

        End Try
        
        'Player.controls.play()
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        ' Dim filename As String = ""

        ' filename = 
        'RichTextBoxEx1.rtb.LoadFile()
        If chkMostrarOcultar.Text = "Mostrar Texto" Then
            '  RichTextBox2.SaveFile("C:\Legacy\Ingles\Lectura" & "\" & filename & "_test" & ".rtf")
        Else
            '  RichTextBox1.SaveFile("C:\Legacy\Ingles\Lectura" & "\" & filename & ".rtf")

        End If
        ' rtb.
        ' Process.Start("explorer.exe", "Rtf\" & filename & ".rtf")
        MsgBox("Saved", vbInformation)
        'Status = "Saved"
    End Sub

    Private Sub numFontSize_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numFontSize.ValueChanged
        'Dim nuevaFuente As New System.Drawing.Font("Tahoma", 18, System.Drawing.FontStyle.Bold)
        Dim nuevaFuente As New System.Drawing.Font("Tahoma", numFontSize.Value)

        ' Aplica la nueva fuente al texto seleccionado en el RichTextBox
        ' RichTextBox1.SelectAll()
        ' RichTextBox1.SelectionFont = nuevaFuente
        ' RichTextBox1.Font = New Font("Tahoma", 12, FontStyle.Bold)
        ' = New Font("Arial", numFontSize.Value)
        ' RichTextBoxEx1.Font = New Font("arial")
        'RichTextBoxEx1.Font = New Font("Arial", 12)
        '  RichTextBoxEx1.rtb.Font = New Font("Arial", 12)

        'RichTextBoxEx1.rtb.Font = New Font("Tahoma", 12, FontStyle.Bold)

    End Sub

    Private Sub chkMostrarOcultar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMostrarOcultar.CheckedChanged

        If chkMostrarOcultar.Text = "" Then Exit Sub

        If chkMostrarOcultar.Text = "Ocultar Texto" Then

            '  Panel1.Visible = False
            'Panel2.Visible = True
            chkMostrarOcultar.Text = "Mostrar Texto"

        Else

            ' Panel1.Visible = True
            'Panel2.Visible = False

            chkMostrarOcultar.Text = "Ocultar Texto"

        End If
         
    End Sub

    Private Sub cmdAtras_Click(sender As System.Object, e As System.EventArgs) Handles cmdAtras.Click

        'Play
        ' cmdPause.Text = "Pause"
        ' cmdPause.Refresh()
        ' Player.controls.fastReverse()
        ' Player.controls.previous()
        Try
            Player.controls.currentPosition = Player.controls.currentPosition - 5
        Catch ex As Exception

        End Try
        

    End Sub

    Private Sub tbVolume_Scroll(sender As System.Object, e As System.EventArgs) Handles tbVolume.Scroll
        'Player.controls.pause()
        Try
            volumen = tbVolume.Value

            Player.settings.volume = volumen

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdSeleccionar_Click(sender As System.Object, e As System.EventArgs) Handles cmdSeleccionar.Click

        ' RichTextBox2.SelectionBackColor = Color.Green

    End Sub

    Private Sub cmdErrores_Click(sender As System.Object, e As System.EventArgs) Handles cmdErrores.Click

        Dim nuevaFuente As New System.Drawing.Font("Tahoma", 11, FontStyle.Bold)
        'nuevaFuente.SelectionColor = Color.Red
        '' Aplica la nueva fuente al texto seleccionado en el RichTextBox

        '  RichTextBox2.SelectionFont = nuevaFuente
        '  RichTextBox2.SelectionColor = Color.Red
    End Sub

    Private Sub RichTextBox3_Click(sender As Object, e As System.EventArgs) Handles RichTextBox3.Click

    End Sub

    Private Sub RichTextBox3_DockChanged(sender As Object, e As System.EventArgs) Handles RichTextBox3.DockChanged

    End Sub

    Private Sub RichTextBox3_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles RichTextBox3.MouseClick
        Dim _Parametros() As String
        Dim nombre As String
        Dim param As String
        Dim Archivo As String
        Dim resp As String
        Dim richtextId As String

        '_Parametros = Split(sender.name, "_")
        richtextId = Mid(sender.name, Len(sender.name), 1)


        Dim menu = New System.Windows.Forms.ContextMenuStrip()

        menu.Items.Add("Guardar Texto").Name = "Texto" & richtextId
        menu.Items.Add("Guardar Traduccion").Name = "Traduccion" & richtextId


        menu.Show(sender, e.X, e.Y)

        AddHandler menu.ItemClicked, AddressOf VerMenu

    End Sub
    Private Sub VerMenu(sender As Object, e As ToolStripItemClickedEventArgs)

        Dim nombre = e.ClickedItem.Name.ToString
        Dim fecha As Date
        Dim mifecha As String
        Dim Id As Integer
        Dim param As String = ""

        Dim posicion = nombre.Replace("Texto", "")
         
        If nombre.Contains("Texto") Then
            '  RichTextBox1.SaveFile("C:\Legacy\Ingles\Lectura" & "\" & filename & "" & ".rtf")


        ElseIf nombre.Contains("Traduccion") Then
            '  RichTextBox3.SaveFile("C:\Legacy\Ingles\Lectura" & "\" & filename & "_trad" & ".rtf")


        ElseIf nombre.Contains("Bloques") Then

        End If

        MsgBox("Saved", vbInformation)

    End Sub
   
End Class