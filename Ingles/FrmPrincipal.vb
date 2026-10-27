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

Imports System.Speech.AudioFormat
Imports System.Drawing

Imports System.Diagnostics
Imports System.Uri
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FrmPrincipal
    Dim voice As SpVoice = New SpVoice()
    Private synthesizer As New SpeechSynthesizer()


    Public Event SpeakCompleted As EventHandler(Of SpeakCompletedEventArgs)

    Private WithEvents spcsynth As New Speech.Synthesis.SpeechSynthesizer
    ' Private voices As System.Collections.ObjectModel.ReadOnlyCollection(Of System.Speech.Synthesis.)
    Dim handler As EventHandler(Of SpeakCompletedEventArgs)
    Dim speaker As New SpeechSynthesizer()
#Region "Menu"
    Private Sub FrmPrincipal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      

        'lstVoices.View = View.Details ' Set the view to show details.
        'lstVoices.LabelEdit = False ' Allow the user to edit item text.
        'lstVoices.AllowColumnReorder = True ' Allow the user to rearrange columns.
        'lstVoices.FullRowSelect = True
        'lstVoices.GridLines = True
        'lstVoices.TileSize = New Size(500, 40)
        '' lstOraciones.Dock = DockStyle.Fill
        'lstVoices.ShowItemToolTips = True

        ' ModVar.Idioma = "EN"
        ModVar.Idioma = "FR"

        Dim bmp As Bitmap
        Dim g As Graphics
        Dim miPen As New Pen(Color.Blue, 2) ' Borde azul de 2 píxeles de grosor

        Dim pbwidth, pbheight As Integer
        Dim pb1 As New PictureBox
        ' dimensiones del picturebox
        pbwidth = 100
        pbheight = 100
        ' Crear un objeto Rectangle (izquierda, arriba, ancho, alto)
        Dim miRectangulo As New Rectangle(50, 50, 100, 75) ' 100px de ancho, 75px de alto
        bmp = New Bitmap(pbwidth, pbheight)
        g = Graphics.FromImage(bmp)

        ' Dibujar el rectángulo en el panel (ejemplo)
        g.DrawRectangle(miPen, miRectangulo)

        'Foto  de Contexto
        Dim p As CircularPictureBox
        p = New CircularPictureBox
        p.Name = "p_1"

        p.Height = 100 '
        p.Width = 100 '

        p.SizeMode = PictureBoxSizeMode.Zoom
        p.Image = Image.FromFile("C:\Legacy\Imagenes\vacio.jpg")
        p.BackColor = Color.Beige
        p.Location = New Point(0, 0)

        CrearGrafica()

        ' Dim pic As New PictureBox
        'PictureBox1.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\femenino\animacion.gif")
        '  Me.Controls.Add(pic)

        ' Me.Controls.Add(p)
        ' Panel1.Controls.Add(p)
        ' pEtapa.Controls.Item("pAux_" & nm).Controls.Add(p)
    End Sub

#End Region

    Private Sub CrearGrafica()

        Chart3.Series.Clear()

        GraficarTotales()

        GraficarTotalesAprendidos()

        GraficarOraciones()

    End Sub

    Private Sub GraficarTotales()
        Dim i As Integer
        Dim j As Integer

        Dim valorY As Integer
        Dim valorX As DateTime

        Dim n As Integer

        Dim yPos As Integer
        Dim lblY As Integer

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim param As String = ""

        Dim sqlstring As String = ""
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim huerfanos As Integer
        Dim totalAprendidos As Integer
     

        Dim objDataReader As SqlDataReader
         

        sqlstring = " SELECT "
        sqlstring = sqlstring & " SUM(CASE WHEN FrecuenciaUso > 0 THEN 1 ELSE 0 END) AS MayoresACero,"
        sqlstring = sqlstring & " SUM(CASE WHEN FrecuenciaUso = 0 THEN 1 ELSE 0 END) AS Huerfanos"
        sqlstring = sqlstring & " FROM Oraciones_FR"
         
        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        objDataReader = _comando.ExecuteReader

        Do While objDataReader.Read()
            'If objDataReader(1) = "True" Then
            totalAprendidos = objDataReader(0)
            Huerfanos = objDataReader(1)

            '  totalGlobalAprendidos += totalAprendidos
            'total += totalAprendidos
            'Else
            'totalFalta = objDataReader(0)
            'totalGlobalFalta += totalFalta
            'total += totalFalta

            'End If
        Loop

        _comando.Connection.Close()

        'Next i

        '_comando.Connection.Close()

        Dim IntervalY As Integer

        IntervalY = 10


        Chart3.Series.Clear()
        Chart3.Titles.Clear()

        Dim maxValor As Integer = Math.Max(totalAprendidos, huerfanos)
        Chart3.ChartAreas(0).AxisY.Maximum = maxValor * 1.2

        ' Create a new series for the pie chart
        Dim series1 As New Series("Oraciones")
        series1.ChartType = SeriesChartType.Column

        ' Add data points to the series
        series1.Points.AddXY("En uso", totalAprendidos) ' Label, Value
        series1.Points(0).Color = Color.Green

        series1.Points.AddXY("huerfanos", huerfanos)
        series1.Points(1).Color = Color.Red


        ' Add the series to the chart
        Chart3.Series.Add(series1)
        ' If you want to show Chart Legends
        Chart3.Legends(0).Enabled = True
        Chart3.Legends(0).Docking = DataVisualization.Charting.Docking.Top

        ' Optional: Customize the pie chart appearance
        ' series1("PieLabelStyle") = "Outside" ' Show labels outside the pie
        ' series1("PieLabelStyle") = "Inside" ' Show labels outside the pie
        series1.IsValueShownAsLabel = True
        '  series1.Label = "#PERCENT{P0}"
        ' series1.Label = "#VALX: #VALY"
        ' Or for percentage:
        series1.Label = "#VALX:  #VALY  (#PERCENT)"

        Chart3.Titles.Add("Title") ' Add a title


        '   Chart3.Size = 500
        ' Chart3.Dock = DockStyle.Fill

        ' Chart3.ChartAreas(0).Area3DStyle.Enable3D = True ' 
        'Chart3.Series(0).IsValueShownAsLabel = True
        ' Chart3.Series(0).Label = "#PERCENT"
        'Chart3.Series(0).Label = "#PERCENT{P0}"
        ' Chart.HasLegend = True


        ' txtTotal.Text = total

    End Sub
    Private Sub GraficarTotalesAprendidos()
        Dim i As Integer
        Dim j As Integer

        Dim valorY As Integer
        Dim valorX As DateTime

        Dim n As Integer

        Dim yPos As Integer
        Dim lblY As Integer

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim param As String = ""

        Dim sqlstring As String = ""
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim faltantes As Integer
        Dim favoritos As Integer
        Dim totalAprendidos As Integer

        Dim objDataReader As SqlDataReader

        sqlstring = " SELECT "
        sqlstring = sqlstring & " SUM(CASE WHEN o.STL = 1 THEN 1 ELSE 0 END) AS Aprendidos,"
        sqlstring = sqlstring & " SUM(CASE WHEN o.STL = 0 THEN 1 ELSE 0 END) AS Falta,"
        sqlstring = sqlstring & " SUM(CASE WHEN o.favorito = 'S' THEN 1 ELSE 0 END) AS Favoritos,"
        sqlstring = sqlstring & " SUM(CASE WHEN o.favorito = 'R' THEN 1 ELSE 0 END) AS Verdes,"
        sqlstring = sqlstring & " SUM(CASE WHEN o.reproduccion > 1 THEN 1 ELSE 0 END) AS Reproducidos"
        sqlstring = sqlstring & " FROM Tbl_Dialogos g"
        sqlstring = sqlstring & " INNER JOIN Oraciones_Fr o     ON g.IdOracion = o.Id"
        sqlstring = sqlstring & " INNER JOIN Det_Conversation d    ON g.IdConversacion = d.Det_Con"
        sqlstring = sqlstring & " INNER JOIN Enc_Conversation AS e ON d.Con_Id = e.Con_Id "
        sqlstring = sqlstring & " WHERE d.Status = 'R'"


        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        objDataReader = _comando.ExecuteReader
        Try

      

        Do While objDataReader.Read()
            totalAprendidos = objDataReader(0)
            faltantes = objDataReader(1)
            favoritos = objDataReader(2)
            verdes = objDataReader(3)
            reproducidos = objDataReader(4)
        Loop

        _comando.Connection.Close()


        Dim IntervalY As Integer
        IntervalY = 10

        Chart1.Series.Clear()
        Chart1.Titles.Clear()

            ' Create a new series for the pie chart
        Dim series1 As New Series("Dialogos")
        series1.ChartType = SeriesChartType.Column

            ' Add data points to the series
        series1.Points.AddXY("Aprendidos", totalAprendidos) ' Label, Value
        series1.Points(0).Color = Color.Green

        series1.Points.AddXY("Falta", faltantes)
        series1.Points(1).Color = Color.Red

        series1.Points.AddXY("Favoritos", favoritos)
        series1.Points(2).Color = Color.DarkGoldenrod


        series1.Points.AddXY("Reproducidos", reproducidos)
        series1.Points(3).Color = Color.Blue

        series1.Points.AddXY("Verdes", verdes)
        series1.Points(4).Color = Color.Green

            ' Add the series to the chart
        Chart1.Series.Add(series1)
            ' If you want to show Chart Legends
        Chart1.Legends(0).Enabled = True
        Chart1.Legends(0).Docking = DataVisualization.Charting.Docking.Top

            ' Optional: Customize the pie chart appearance
            ' series1("PieLabelStyle") = "Outside" ' Show labels outside the pie
            ' series1("PieLabelStyle") = "Inside" ' Show labels outside the pie
        series1.IsValueShownAsLabel = True
            '  series1.Label = "#PERCENT{P0}"
            ' series1.Label = "#VALX: #VALY"
            ' Or for percentage:
        ' series1.Label = "#VALX:  #VALY  (#PERCENT)"
        series1.Label = "#VALY  (#PERCENT)"

            Chart1.Titles.Add("Title") ' Add a title

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Sub
    Private Sub GraficarOraciones()
        Dim i As Integer
        Dim j As Integer

        Dim valorY As Integer
        Dim valorX As DateTime

        Dim n As Integer

        Dim yPos As Integer
        Dim lblY As Integer

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim param As String = ""

        Dim sqlstring As String = ""
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim Revisados As Integer
        Dim Sin_Revisar As Integer
        Dim Descartados As Integer
        Dim Usadas As Integer

        Dim objDataReader As SqlDataReader

        sqlstring = " SELECT "
        sqlstring = sqlstring & " SUM(CASE WHEN Status = 'R' THEN 1 ELSE 0 END) AS Revisados,"
        sqlstring = sqlstring & " SUM(CASE WHEN Status = 'N' THEN 1 ELSE 0 END) AS Sin_Revisar,"
        sqlstring = sqlstring & " SUM(CASE WHEN Status = 'X' THEN 1 ELSE 0 END) AS Descartados,"
        sqlstring = sqlstring & " SUM(CASE WHEN masUsada = 'S' THEN 1 ELSE 0 END) AS Usadas"
        sqlstring = sqlstring & " FROM Oraciones_FR"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        objDataReader = _comando.ExecuteReader

        Do While objDataReader.Read()

            Revisados = objDataReader(0)
            Sin_Revisar = objDataReader(1)
            Descartados = objDataReader(2)
            Usadas = objDataReader(3)
        Loop

        _comando.Connection.Close()

        Dim IntervalY As Integer

        IntervalY = 10


        Chart2.Series.Clear()
        Chart2.Titles.Clear()

        ' Create a new series for the pie chart
        Dim series1 As New Series("Oraciones")
        series1.ChartType = SeriesChartType.Column
        ' series1.Color = Color.Green

        ' Add data points to the series
        series1.Points.AddXY("Revisados", Revisados) ' Label, Value
        series1.Points(0).Color = Color.Green

        series1.Points.AddXY("Sin_Revisar", Sin_Revisar)
        series1.Points(1).Color = Color.Gray

        series1.Points.AddXY("Descartados", Descartados)
        series1.Points(2).Color = Color.Red

        series1.Points.AddXY("Usadas", Usadas)
        series1.Points(3).Color = Color.Blue

        ' Add the series to the chart
        Chart2.Series.Add(series1)
        ' If you want to show Chart Legends
        ' Chart2.Legends(0).Enabled = True
        Chart2.Legends(0).Docking = DataVisualization.Charting.Docking.Top

        ' Optional: Customize the pie chart appearance
        ' series1("PieLabelStyle") = "Outside" ' Show labels outside the pie
        ' series1("PieLabelStyle") = "Inside" ' Show labels outside the pie
        series1.IsValueShownAsLabel = True
        '  series1.Label = "#PERCENT{P0}"
        ' series1.Label = "#VALX: #VALY"
        ' Or for percentage:
        series1.Label = "#VALX:  #VALY  (#PERCENT)"

        Chart2.Titles.Add("Title") ' Add a title



    End Sub
    Private Sub CmdTemas_Click(sender As System.Object, e As System.EventArgs) Handles CmdTemas.Click
        FrmTemas.Show()
        'FrmTemas.lblDescripcion.Text = txtDescripcion.Text
    End Sub

    'Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    '    FrmAvance.Show()
    'End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        FrmVocabulario.Show()
    End Sub

    Private Sub ConceptosBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)


    End Sub



    Private Sub ConceptosBindingNavigatorSaveItem_Click_1(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        ' Me.ConceptosBindingSource.EndEdit()
        '  Me.TableAdapterManager.UpdateAll(Me.InglesDataSet)

    End Sub

    Private Sub CmdOraciones_Click(sender As System.Object, e As System.EventArgs) Handles CmdOraciones.Click
        FrmOraciones.Show()
    End Sub

    Private Sub btnTexto_Click(sender As System.Object, e As System.EventArgs) Handles btnTexto.Click
        FrmDocumentos.Show()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        frmConversaciones.Show()

    End Sub
 

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        frmDocuments.Show()
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
         
            Dim pVoice As ISpVoice = CType(voice, ISpVoice)
            Dim otc As SpObjectTokenCategory = New SpObjectTokenCategory()
            otc.SetId("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices")

        Dim tokenEnum As ISpeechObjectTokens = otc.EnumerateTokens()
        Dim nTokenCount As Integer = tokenEnum.Count

        '  Console.WriteLine("Number of voices: {0}", nTokenCount)
        Dim n As UInteger = 0

            For Each sot As ISpeechObjectToken In tokenEnum
                Console.WriteLine("Voice : {0}", sot.GetDescription())


            ' pVoice.SetVoice(CType(sot, ISpObjectToken))
            pVoice.SetVoice(CType(tokenEnum(0), ISpObjectToken))

            Try
                pVoice.Speak("Hello! This is a test", 0, n)
            Catch ex As System.Exception
                Console.WriteLine("Cannot speak with the voice : {0}", sot.GetDescription())
            End Try

        Next
         
        'Using category As ObjectTokenCategory = ObjectTokenCategory.Create(SAPICategories.Voices)
        '    If category IsNot Nothing Then
        '        ' Build a list with all the voicesInfo
        '        For Each voiceToken As ObjectToken In category.FindMatchingTokens(Nothing, Nothing)
        '            If voiceToken IsNot Nothing AndAlso voiceToken.Attributes IsNot Nothing Then
        '                voices.Add(New InstalledVoice(voiceSynthesizer, New VoiceInfo(voiceToken)))
        '            End If
        '        Next
        '    End If
        'End Using

        'Dim synthesizer As New SpeechSynthesizer()
        'For Each voice As InstalledVoice In synthesizer.GetInstalledVoices()
        '    Console.WriteLine(voice.VoiceInfo.Name)
        'Next

        ' Create a new SpeechSynthesizer object
        'Dim synthesizer As New SpeechSynthesizer()

        ' Select the Microsoft David Desktop voice
        ' The exact name might vary slightly, e.g., "Microsoft David Desktop - English (United States)"
        ' It is recommended to iterate through installed voices to find the exact name if unsure.
        'Try
        '    synthesizer.SelectVoice("Microsoft David Desktop") ' Or the full name as found in settings
        'Catch ex As ArgumentException
        '    MessageBox.Show("Microsoft David Desktop voice not found. Please ensure it is installed.", "Voice Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    ' Optionally, select a default voice or handle the error differently
        '    synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult)
        'End Try

        '' Speak the text
        'synthesizer.SpeakAsync("Hello, this is a demonstration using Microsoft David Desktop voice.")

        '' Clean up the synthesizer object when done (e.g., on form close)
        '' synthesizer.Dispose()




        'For Each voice As InstalledVoice In spcsynth.GetInstalledVoices()
        '    Dim info As VoiceInfo = voice.VoiceInfo
        '    Dim AudioFormats As String = ""
        '    ' Each fmt As SpeechAudioFormatInfo In info.SupportedAudioFormats
        '    ' AudioFormats += String.Format("{0}" & vbLf, fmt.EncodingFormat.ToString())



        '    Console.WriteLine(" Name:          " + info.Name)
        '    'Console.WriteLine(" Culture:       " + info.Culture)
        '    'Console.WriteLine(" Age:           " & info.Age)
        '    'Console.WriteLine(" Gender:        " & info.Gender)
        '    'Console.WriteLine(" Description:   " & info.Description)
        '    'Console.WriteLine(" ID:            " & info.Id)
        '    'Console.WriteLine(" Enabled:       " & voice.Enabled)
        'Next

        'For Each voice In spcsynth.GetInstalledVoices

        '    Console.WriteLine(" Name:          " + info.Name)
        '    ' Console.WriteLine(" Culture:       " + info.Culture)
        '    Console.WriteLine(" Age:           " + info.Age)
        '    Console.WriteLine(" Gender:        " + info.Gender)
        '    Console.WriteLine(" Description:   " + info.Description)
        '    Console.WriteLine(" ID:            " + info.Id)
        '    Console.WriteLine(" Enabled:       " + voice.Enabled)
        'Next



        'Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'voices = spcsynth.GetInstalledVoices()
        'For Each v As System.Speech.Synthesis.InstalledVoice In voices
        '    lstVoices.Items.Add(String.Format("Name: {0}, Gender: {1}, Age: {2}, Description: {3}", v.VoiceInfo.Name, v.VoiceInfo.Gender, v.VoiceInfo.Age, v.VoiceInfo.Description))
        'Next
        '' End Sub


        'Dim synth As New SpeechSynthesizer
        'synth.SetOutputToDefaultAudioDevice()
        'synth.Speak("Some text...")

    End Sub

    Private Sub cmdVerbs_Click(sender As System.Object, e As System.EventArgs) Handles cmdVerbs.Click
        frmVerbs.Show()
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        frmGrupos.Show()
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click

        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New frmOracionesRead

        AddOwnedForm(frm)

        frm.Id = Id

        frm.CargarConversation(Id)

        frm.Show()


    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs)


    End Sub

  
    
    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
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
        Dim n As Integer
        Dim sqlstring As String

        sqlstring = "SELECT        Id, TextoPlano, Oracion, ConceptoID, GrupoO, Traduccion, Campo1, F5, F6, Palabra, [Delete], SEL, estatus, GrupoId, forma, STL, GRUPO, IMG, Orden, Campo2, IPA, Campo3,  CursoId, SSMA_TimeStamp"
        sqlstring = sqlstring & "    FROM Oraciones"

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
       

        Do While i <= n - 1


            textoOriginal = dt.Rows(i).Item(1)

            textoModificado = Trim(textoOriginal.Replace("?", "")) ' Reemplaza el símbolo de ? por ""

            'buscar en Conversaciones
            sqlstring = " SELECT Id, TextoPlano, Traduccion  FROM Oraciones"

            sqlstring = sqlstring & " Where TextoPlano LIKE " & "'%" & textoModificado & "%'"
            sqlstring = sqlstring & " ORDER BY Oraciones.TextoPlano ASC"

            _comando.CommandText = sqlstring

            Try
                objDataReader = _comando.ExecuteReader

                If objDataReader.HasRows Then
                Else
                    'Si no existe
                    'Grupo Sin definiir Id 1050
                    sqlstring = "Insert into Oraciones (TextoPlano, Traduccion, GrupoO)"
                    sqlstring = sqlstring & " Values ('" & textoModificado & "', '', '1050')"
                     
                    _comando.CommandText = sqlstring
                    _comando.Connection.Open()

                    Try
                        i = _comando.ExecuteNonQuery

                    Catch ex As Exception

                    End Try

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            objDataReader.Close()

            i = i + 1
        Loop
         
        _comando.Connection.Close()

       

    End Sub

    Private Sub Button9_Click_1(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        frmTexto.Show()
    End Sub

    
    Private Sub cmdDuplicados_Click(sender As System.Object, e As System.EventArgs) Handles cmdDuplicados.Click
        frmDuplicados.Show()

    End Sub

    Private Sub cmdAudios_Click(sender As System.Object, e As System.EventArgs) Handles cmdAudios.Click
        frmAudios.show()
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
       


    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        SpeakAndHighlight("Note: The SpeakAndHighlight method in the example uses synchronous synthesizer.Speak to ensure the highlighting keeps pace with the speech If SpeakAsync is used, the highlighting might not be perfectly synchronized without additional logic to track speech progress.                           You might also need to handle punctuation and other non-word characters when splitting the text into words for more precise highlighting")

    End Sub



    Private Sub SpeakAndHighlight(textToSpeak As String)
        Dim words() As String = textToSpeak.Split(New Char() {" "c, vbCrLf, vbTab}, StringSplitOptions.RemoveEmptyEntries)
        Dim currentPosition As Integer = 0

        For Each word As String In words
            ' Highlight the current word
            'RichTextBox1.Select(currentPosition, word.Length)
            'RichTextBox1.SelectionBackColor = Color.Yellow ' Set highlight color
            'RichTextBox1.SelectionFont = New Font(RichTextBox1.SelectionFont, FontStyle.Bold) ' Optional: make it bold

            '' Speak the word
            synthesizer.Speak(word) ' Use synchronous speak for highlighting to keep in sync

            '' Reset highlighting for the previous word (optional, depends on desired effect)
            'RichTextBox1.Select(currentPosition, word.Length)
            'RichTextBox1.SelectionBackColor = Color.White ' Reset to default background
            'RichTextBox1.SelectionFont = New Font(RichTextBox1.SelectionFont, FontStyle.Regular) ' Reset font style

            ' Move to the next word's starting position
            currentPosition += word.Length + 1 ' +1 for the space/separator
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'SpeakAndHighlight(RichTextBox1.Text)
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click

        'dimension variables of local scope

        Dim g As Graphics

        Dim rec As Rectangle

        Dim myPen As New Pen(Color.Blue)

        'return the current form as a drawing surface

        g = Graphics.FromHwnd(ActiveForm().Handle)

        'create a rectangle based on x,y coordinates, width, & height

        rec = New Rectangle(x:=200, y:=50, Width:=500, Height:=500)

        'draw rectangle from pen and rectangle objects

        g.DrawRectangle(pen:=myPen, rect:=rec)

    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        Dim bmp As Bitmap
        Dim g As Graphics
        'Dim miPen As New Pen(Color.Blue, 2) ' Borde azul de 2 píxeles de grosor
        Dim myPen As New Pen(Color.Red, 2)

        Dim pbwidth, pbheight As Integer
        Dim pb1 As New PictureBox
        ' dimensiones del picturebox
        pbwidth = 100
        pbheight = 100
        ' Crear un objeto Rectangle (izquierda, arriba, ancho, alto)
        ' Dim rec As New Rectangle(50, 50, 100, 75) ' 100px de ancho, 75px de alto
        bmp = New Bitmap(pbwidth, pbheight)

        ' pEtapa.Controls.Item(c.name).Controls.Add(pb1)

        'g = Graphics.FromHwnd(pEtapa.Controls(c.name).Controls.Item(str(1)))
        'g = Graphics.FromHwnd(pEtapa.Controls(c.name).Controls.Item(str(1)))

        g = Graphics.FromImage(bmp)
        Dim rec As New Rectangle(x:=200, y:=100, Width:=100, Height:=200)

        ' Dibujar el rectángulo en el panel (ejemplo)
        ' g.DrawRectangle(miPen, miRectangulo)
        g.DrawRectangle(pen:=myPen, rect:=rec)


        ''


        ' Create a Pen object to define the color and width of the rectangle's border
        Using blackPen As New Pen(Color.Black, 2) ' Black color, 2 pixels wide

            ' Define the rectangle's position and size
            Dim x As Integer = 10
            Dim y As Integer = 10
            Dim width As Integer = 100
            Dim height As Integer = 50

            ' Draw the rectangle
            g.DrawRectangle(blackPen, x, y, width, height)
        End Using

    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs)
        '' Create a Pen object to define the color and width of the rectangle's border
        'Using blackPen As New Pen(Color.Black, 2) ' Black color, 2 pixels wide

        '    ' Define the rectangle's position and size
        '    Dim x As Integer = 10
        '    Dim y As Integer = 10
        '    Dim width As Integer = 100
        '    Dim height As Integer = 50

        '    ' Draw the rectangle
        '    e.Graphics.DrawRectangle(blackPen, x, y, width, height)
        'End Using
    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        Dim myPen As New Pen(Color.Blue, 2)
        CreateGraphics.DrawRectangle(myPen, 100, 50, 200, 100)

    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
        Dim p As New PictureBox
        Dim bmp As New Bitmap(p.Size.Width, p.Size.Height)
        p.Image = bmp

        Dim myPen As New Pen(Color.Red, 2)
       
        Dim g As Graphics
        g = Graphics.FromImage(p.Image)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        g.DrawRectangle(myPen, 0, 0, 20, 20)
        '  Panel1.Controls.Add(p)

    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()

    End Sub

    
    Private Sub cmdRandom_Click(sender As System.Object, e As System.EventArgs) Handles cmdRandom.Click
        Dim frm As New FrmConversation

        ' frm.CrearControlesRandom("_mis frases")

        frm.Show()


    End Sub

    Private Sub cmdGrafica_Click(sender As System.Object, e As System.EventArgs)

        frmGrafica.ShowDialog()

    End Sub

    Private Sub cmdSpeak_Click(sender As System.Object, e As System.EventArgs) Handles cmdSpeak.Click
        'Dim synth As New SpeechSynthesizer()


        'synth.SetOutputToDefaultAudioDevice()
        'synth.SpeakAsync("Hello, this is a test of the speech synthesizer.")
        '' synth.Speak("Hello, this is a test of the speech synthesizer.")
        'synth.SelectVoice("Microsoft Zira Desktop")



        Dim AudioFormats As String = ""
        'Dim info As VoiceInfo = voice.VoiceInfo


        For Each voice As InstalledVoice In spcsynth.GetInstalledVoices()
            Console.WriteLine(voice.VoiceInfo.Name)
        Next
        ' Each fmt As SpeechAudioFormatInfo In info.SupportedAudioFormats
        ' AudioFormats += String.Format("{0}" & vbLf, fmt.EncodingFormat.ToString())




    End Sub

    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Dim i, j As Integer

        i = 1

        _comando.Connection.Open()

        sqlstring = "SELECT Id, STL, CuentaSTL FROM Oraciones"
        _comando.CommandText = sqlstring

        da.SelectCommand = _comando

        da.Fill(dt)

        _comando.Connection.Close()

        _comando.Connection.Open()

        For Each rw In dt.Rows

            _comando.Parameters.Clear()

            ' Console.WriteLine(rw.item(0))
            If rw.item(1) = True Then

                sqlstring = "UPDATE Oraciones SET CuentaSTL = @CuentaSTL"
                sqlstring = sqlstring & " WHERE  Id = @Id"

                _comando.Parameters.AddWithValue("@Id", rw.item(0))
                Dim cuenta As Integer
                cuenta = rw.item(2)
                _comando.Parameters.AddWithValue("@CuentaSTL", cuenta + 1)

            End If

            _comando.CommandText = sqlstring

            Try
                j = _comando.ExecuteNonQuery

            Catch ex As Exception


            End Try

            i = i + 1
        Next
        _comando.Connection.Close()

        
    End Sub

    Private Sub cmdPalabras_Click(sender As System.Object, e As System.EventArgs) Handles cmdPalabras.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer

        Dim OracionEN As String
        Dim OracionES As String
        Dim SQL As String
        Dim IdCon As Integer
        Dim j As Integer
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
        Dim objDataReader As SqlDataReader
        Dim valorActual As String
        Dim valorModificado As String
        Dim n As Integer
        Dim IdPalabra As Integer

        Dim CharRem As String
        CharRem = InputBox("Caracter a remplazar")
        If CharRem = "" Then Exit Sub

        'Buscar en Tbl Oraciones_Det
        Try
            sqlstring = ""
            sqlstring = " Select * FROM Oraciones_Det"
            sqlstring = sqlstring & " WHERE Palabra LIKE '%' + @Palabra + '%'"

            _comando.CommandText = sqlstring
            _comando.Connection.Open()
            _comando.Parameters.AddWithValue("@Palabra", CharRem)

            da.SelectCommand = _comando

            da.Fill(dt)
            n = dt.Rows.Count
            _comando.Connection.Close()

        Catch ex As Exception
        End Try

        Dim Id As Integer
        Dim texto As String

        _comando.Connection.Open()


        'Reemplazar caracteres
        For Each r In dt.Rows


            If r.item(2) = 0 Then

                Id = r.item(0)
                valorActual = r.item(3) ' Obtén el valor actual del texto y reemplaza el caracter

                valorModificado = valorActual.Replace(CharRem, "") ' Reemplaza 'a' por 'X'

                If valorActual <> valorModificado Then

                    sqlstring = " UPDATE Oraciones_Det Set Palabra = @Palabra "
                    sqlstring = sqlstring & " WHERE (Id = '" & Id & "')"
                    _comando.CommandText = sqlstring

                    _comando.Parameters.Clear()
                    _comando.Parameters.AddWithValue("@Palabra", valorModificado)

                    j = _comando.ExecuteNonQuery

                End If

                '''''''
                'buscar en Oraciones
                SQL = " SELECT Id, Concepto  FROM Conceptos"
                SQL = SQL & " Where Concepto = N'" & valorModificado & "'"
                _comando.Parameters.Clear()

                _comando.CommandText = SQL
                '  _comando.Parameters.AddWithValue("@Concepto", "do")
                Try
                    objDataReader = _comando.ExecuteReader



                    If objDataReader.HasRows Then
                        objDataReader.Read()
                        IdPalabra = objDataReader(0)
                        objDataReader.Close()

                        'Actualiza Id en Det

                        sqlstring = " UPDATE Oraciones_Det Set IdPalabra = @IdPalabra "
                        sqlstring = sqlstring & " WHERE (Id = '" & Id & "')"
                        '_comando.Connection.Open()
                        _comando.CommandText = sqlstring

                        _comando.Parameters.Clear()
                        _comando.Parameters.AddWithValue("@IdPalabra", IdPalabra)

                        j = _comando.ExecuteNonQuery
                        ' reemplazos += 1

                    Else
                        'Si no existe

                        objDataReader.Close()

                        '_comando.Parameters.Clear()
                    End If

                Catch ex As Exception

                End Try

            End If
        Next






        'sqlstring = "Insert into Oraciones (Oracion, TextoPlano, Traduccion, GrupoO)"
        'sqlstring = sqlstring & " Values (@Oracion, @TextoPlano, @Traduccion,'1050')"
        '_comando.CommandText = sqlstring

        '_comando.Parameters.AddWithValue("@Oracion", OracionEN)
        '_comando.Parameters.AddWithValue("@TextoPlano", OracionEN)
        '_comando.Parameters.AddWithValue("@Traduccion", OracionES)

        'Try
        '    i = _comando.ExecuteNonQuery

        '    If i > 0 Then
        '        SQL = "SELECT @@IDENTITY FROM Oraciones"

        '        _comando = New SqlCommand(SQL, _comando.Connection)

        '                Dim value As Object = _comando.ExecuteScalar

        '                IdOracion = value.ToString
        '            End If
        '            '_comando.Connection.Close()

        '        Catch ex As Exception

        '        End Try

        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'objDataReader.Close()


        '_comando.CommandText = sqlstring


        'Detalle conversation

        'sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
        'sqlstring = sqlstring & " Values ('" & IdOracion & "', '" & j & "', '" & Con_Id & "', '0')"

        '_comando.CommandText = sqlstring

        'Try
        '    i = _comando.ExecuteNonQuery

        '    If i > 0 Then
        '        'MsgBox("se guardo")
        '    Else
        '        MsgBox("No se guardo")
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        'End Try

        'j = j + 1

        _comando.Connection.Close()

        MessageBox.Show("Completed !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)




    End Sub

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs)
        frmEscenas.ShowDialog()

    End Sub

    Private Sub cmdInsert_Click(sender As System.Object, e As System.EventArgs) Handles cmdInsert.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim da As New SqlDataAdapter
      
        Dim SQL As String

        Dim j As Integer
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
        Dim objDataReader As SqlDataReader
        Dim valorActual As String
        Dim valorModificado As String
        Dim n As Integer
        Dim IdPalabra As Integer

        Dim dtConversaciones As New DataTable
        Dim dtDetalles As New DataTable

        'Tbl Enc_Conversation
        Try
            _comando.Connection.Open()

            sqlstring = ""
            sqlstring = " Select * FROM Enc_Conversation"
            _comando.CommandText = sqlstring

            da.SelectCommand = _comando

            da.Fill(dtConversaciones)
            n = dtConversaciones.Rows.Count
            _comando.Connection.Close()

        Catch ex As Exception
        End Try

        Dim Id As Integer
        Dim texto As String
        Dim i As Integer
        _comando.Connection.Open()

        'Insertar en Dialogos
        For Each r In dtConversaciones.Rows

            Id = r.item(0)

            sqlstring = ""
            sqlstring = " Select * FROM Det_Conversation"
            sqlstring = sqlstring & " WHERE Con_Id='" & Id & "'"
            _comando.CommandText = sqlstring

            da.SelectCommand = _comando

            da.Fill(dtDetalles)
            i = 0
            For Each rw In dtDetalles.Rows

                sqlstring = "Insert into Dialogos (OracionId, Orden, DetConversacion)"
                sqlstring = sqlstring & " Values (@OracionId, @Orden, @DetConversacion)"
                _comando.CommandText = sqlstring

                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@OracionId", rw.item(1))
                _comando.Parameters.AddWithValue("@Orden", i)
                _comando.Parameters.AddWithValue("@DetConversacion", rw.item(0))

                'If Not IsDBNull(r.item(3)) Then
                '    _comando.Parameters.AddWithValue("@IMG", r.item(3))
                'Else
                '    _comando.Parameters.AddWithValue("@IMG", "")
                'End If

                Try
                    j = _comando.ExecuteNonQuery
                Catch ex As Exception
                End Try

                i += 1
            Next

            dtDetalles.Clear()

            Console.WriteLine(Id)
        Next



        'Try
        '    objDataReader = _comando.ExecuteReader



        '    If objDataReader.HasRows Then
        '        objDataReader.Read()
        '        IdPalabra = objDataReader(0)
        '        objDataReader.Close()

        '        'Actualiza Id en Det

        '        sqlstring = " UPDATE Oraciones_Det Set IdPalabra = @IdPalabra "
        '        sqlstring = sqlstring & " WHERE (Id = '" & Id & "')"
        '        '_comando.Connection.Open()
        '        _comando.CommandText = sqlstring

        '        _comando.Parameters.Clear()
        '        _comando.Parameters.AddWithValue("@IdPalabra", IdPalabra)

        '        j = _comando.ExecuteNonQuery
        '        ' reemplazos += 1

        '    Else
        '        'Si no existe
        '        objDataReader.Close()

        '    End If

        'Catch ex As Exception
        'End Try






        'Try
        '    i = _comando.ExecuteNonQuery

        '    If i > 0 Then
        '        SQL = "SELECT @@IDENTITY FROM Oraciones"

        '        _comando = New SqlCommand(SQL, _comando.Connection)

        '                Dim value As Object = _comando.ExecuteScalar

        '                IdOracion = value.ToString
        '            End If
        '            '_comando.Connection.Close()

        '        Catch ex As Exception

        '        End Try

        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'objDataReader.Close()


        '_comando.CommandText = sqlstring


        'Detalle conversation

        'sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
        'sqlstring = sqlstring & " Values ('" & IdOracion & "', '" & j & "', '" & Con_Id & "', '0')"

        '_comando.CommandText = sqlstring

        'Try
        '    i = _comando.ExecuteNonQuery

        '    If i > 0 Then
        '        'MsgBox("se guardo")
        '    Else
        '        MsgBox("No se guardo")
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        'End Try

        'j = j + 1

        _comando.Connection.Close()

        MessageBox.Show("Completed !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub cmdPapelera_Click(sender As System.Object, e As System.EventArgs) Handles cmdPapelera.Click
        Dim Id, j As Integer
        Dim TextoPlano As String
        Dim sqlstring As String
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim i As Integer
        Dim n As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
     

        _comando.Connection.Open()

       
            Try
                sqlstring = " DELETE FROM Oraciones"
            sqlstring = sqlstring & " WHERE (GrupoO = '12')"

                _comando.CommandText = sqlstring

                Try
                    j = _comando.ExecuteNonQuery

            Catch ex As Exception

            End Try

            Catch ex As Exception
        End Try

        If j > 1 Then
            MsgBox("Se vacio papelera " & j & " Registros borrados")
        End If

        _comando.Connection.Close()


    End Sub

    Private Sub cmdAudiosDefinir_Click(sender As System.Object, e As System.EventArgs) Handles cmdAudiosDefinir.Click
        frmListAudios.Show()
    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click

        '' La ruta de la carpeta donde quieres buscar.
        'Dim initialFolder As String = "C:\Users\TuUsuario\Documents"

        '' El término de búsqueda que quieres usar.
        'Dim searchTerm As String = "informe mensual"

        '' Codifica la ruta y el término de búsqueda para la URI.
        'Dim encodedPath As String = Uri.EscapeDataString(initialFolder)
        'Dim encodedSearchTerm As String = Uri.EscapeDataString(searchTerm)

        '' Construye la URI completa del protocolo search-ms.
        '' El parámetro "crumb" define la ubicación inicial de la búsqueda.
        'Dim searchUri As String = $"search-ms:query={encodedSearchTerm}&crumb=location:{encodedPath}"

        'Try
        '    ' Inicia el proceso de búsqueda en el Explorador de Windows.
        '    Process.Start(searchUri)
        'Catch ex As Exception
        '    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try



        'Dim rutaCarpeta As String = "C:\Legacy\Ingles\Audios\"


        ''Declara una nueva instancia de ProcessStartInfo
        'Dim psi As New ProcessStartInfo()

        '' Establece la ruta de la carpeta que deseas abrir
        'psi.FileName = "C:\Legacy\Ingles\Audios\"

        '' Opcional: también puedes establecer la carpeta de trabajo si necesitas que el proceso se ejecute desde ahí
        '' psi.WorkingDirectory = "C:\Ruta\A\Tu\Carpeta"

        '' Inicia el proceso
        'Process.Start(psi)

        ' Obtiene solo los archivos .txt de la carpeta
        'Dim archivosTxt = Directory.GetFiles(rutaCarpeta).Where(Function(archivo) archivo.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))

        ' Recorre los archivos filtrados
        'For Each archivo In archivosTxt
        '    Console.WriteLine(archivo)
        'Next

        'If Directory.Exists(ruta) Then

        '    Dim archivosFiltrados = Directory.GetFiles(ruta).Where(Function(archivo) archivo.GetFileName(IdOracion).Contains("test")
        '    'If archivosFiltrados.Any() Then
        '    'Else

        '    'End If
        'Else

        'End If
      

        '' Dim rutaCarpeta As String = "C:\Tu\Carpeta"
        'Dim extensiones = {".mp3"}

        '' Obtiene los archivos que terminan con cualquiera de las extensiones de la matriz
        ''  Dim archivosFiltrados = Directory.GetFiles(ruta).Where(Function(archivo) extensiones.Contains(IdOracion, StringComparer.OrdinalIgnoreCase))
        'Dim archivosFiltrados = Directory.GetFiles(rutaCarpeta, "*2361*")
        'For Each archivo In archivosFiltrados
        '    Console.WriteLine(archivo)
        'Next


        '''''''
        '' 1. Define la ruta de la carpeta base y el filtro
        'Dim folderPath As String = "C:\Legacy\Ingles\Audios\"
        'Dim filter As String = "*2361*" ' Por ejemplo, archivos de texto

        '' 2. Obtener la lista de archivos filtrados
        'Dim files() As String = Directory.GetFiles(folderPath, filter)

        ' Get the search term from the text box
        ' Dim searchTerm As String = "*2361*"
        'Dim searchTerm As String = "3711"
      
        ''''''''''

       

        '    ' The location must be properly formatted for the `search-ms` protocol
        '    ' A crumb is a string that specifies search scope and other parameters
        'Dim searchCommand As String = $"search-ms:query={Uri.EscapeDataString(searchTerm)}&crumb=location:{Uri.EscapeDataString(searchLocation)}"

        '    Process.Start(searchCommand)

        ' 3. Si se encontraron archivos, abrir el Explorador y seleccionarlos
        'If files.Length > 0 Then
        '    ' El primer archivo se usa como referencia para abrir la carpeta
        '    Dim fileToSelect As String = files(0)

        '    ' Construir los argumentos para explorer.exe
        '    ' La sintaxis es "/select," seguida de la ruta completa del archivo
        '    ' Dim arguments As String = "/select,""" & fileToSelect & """"



        '    '' Dim arguments As String = "search-ms:query=2361"
        '    'Dim arguments As String = "search-ms:query=)"
        '    '' Lanzar el proceso
        '    'Process.Start("explorer.exe", arguments)

        'Else
        '    MessageBox.Show("No se encontraron archivos que coincidan con el filtro.")
        'End If

        ''''''

        ' Definir la ruta de la carpeta y el string a buscar
        'Dim rutaCarpeta As String = "C:\ruta\a\tu\carpeta"
        'Dim stringABuscar As String = "informe"

        '' 1. Obtener todos los archivos en la carpeta
        'Dim archivos As String() = Directory.GetFiles(rutaCarpeta, "*")

        '' 2. Filtrar los archivos por el string
        'Dim archivosFiltrados As New List(Of String)

        'For Each archivo As String In archivos
        '    If Path.GetFileName(archivo).Contains(IdOracion) Then
        '        archivosFiltrados.Add(archivo)
        '    End If
        'Next

        '' 3. Abrir la carpeta con los archivos filtrados seleccionados
        'If archivosFiltrados.Count > 0 Then
        '    ' Construir el argumento para el explorador
        '    Dim argumentoBusqueda As String = String.Join(" ", archivosFiltrados.Select(Function(x) $" ""{x}"""))
        '    Process.Start("explorer.exe", $"/select,{argumentoBusqueda}")
        'Else
        '    'MessageBox.Show("No se encontraron archivos que contengan el string '" & stringABuscar & "'.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If

        '' Declarar un nuevo objeto OpenFileDialog
        'Dim opd As New OpenFileDialog()

        '' Configurar el filtro para mostrar solo archivos de texto (.txt)
        '' y archivos de imagen (.jpg, .png)
        'opd.InitialDirectory = "C:\Legacy\Ingles\Audios\"
        ''opd.Filter = "Archivos de texto (*.txt)|*.txt|Archivos de imagen (*.jpg;*.png)|*.jpg;*.png|Todos los archivos (*.*)|*.*"
        'opd.Filter = IdOracion & "|"

        '' Establecer el índice del filtro predeterminado (en este caso, el segundo filtro)
        'opd.FilterIndex = 2

        '' Configurar la propiedad Multiselect a True para permitir la selección de varios archivos
        ''opd.Multiselect = True

        '' Mostrar el cuadro de diálogo
        'If opd.ShowDialog() = DialogResult.OK Then
        '    ' Si el usuario selecciona uno o más archivos y hace clic en Aceptar
        '    For Each fileName As String In opd.FileNames
        '        ' Aquí puedes procesar cada archivo seleccionado
        '        MessageBox.Show("Archivo seleccionado: " & fileName)
        '    Next
        'End If
    End Sub

    Private Sub cmdEstructuras_Click(sender As System.Object, e As System.EventArgs) Handles cmdEstructuras.Click
        frmEstructuras.Show()

    End Sub

    Private Sub Button21_Click(sender As System.Object, e As System.EventArgs) Handles Button21.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim da As New SqlDataAdapter

        Dim SQL As String

        Dim j As Integer
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
        Dim objDataReader As SqlDataReader
        Dim valorActual As String
        Dim valorModificado As String
        Dim n As Integer
        Dim IdPalabra As Integer

        Dim dtConversaciones As New DataTable
        Dim dtDetalles As New DataTable

        'Tbl Enc_Conversation
        Try
            _comando.Connection.Open()

            sqlstring = " Select * FROM Det_Conversation"
            sqlstring = sqlstring & " WHERE Det_OracionId <> 0"
            _comando.CommandText = sqlstring

            da.SelectCommand = _comando

            da.Fill(dtConversaciones)

            n = dtConversaciones.Rows.Count

            _comando.Connection.Close()

        Catch ex As Exception
        End Try

        Dim Id As Integer
        Dim texto As String
        Dim i As Integer
        _comando.Connection.Open()

        'Insertar en Dialogos
        For Each r In dtConversaciones.Rows

            Id = r.item(0)

                sqlstring = "Insert into Dialogos (OracionId, Orden, DetConversacion)"
                sqlstring = sqlstring & " Values (@OracionId, @Orden, @DetConversacion)"
                _comando.CommandText = sqlstring

                _comando.Parameters.Clear()

            _comando.Parameters.AddWithValue("@OracionId", r.item(1))
                _comando.Parameters.AddWithValue("@Orden", i)
            _comando.Parameters.AddWithValue("@DetConversacion", Id)

              
                Try
                    j = _comando.ExecuteNonQuery
                Catch ex As Exception
                End Try

                i += 1
            Next

           



        'Try
        '    objDataReader = _comando.ExecuteReader



        '    If objDataReader.HasRows Then
        '        objDataReader.Read()
        '        IdPalabra = objDataReader(0)
        '        objDataReader.Close()

        '        'Actualiza Id en Det

        '    End If

        'Catch ex As Exception
        'End Try






        'Try
        '    i = _comando.ExecuteNonQuery

        '    If i > 0 Then
        '        SQL = "SELECT @@IDENTITY FROM Oraciones"

        '        _comando = New SqlCommand(SQL, _comando.Connection)

        '                Dim value As Object = _comando.ExecuteScalar

        '                IdOracion = value.ToString
        '            End If
        '            '_comando.Connection.Close()

        '        Catch ex As Exception

        '        End Try

        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'objDataReader.Close()


        '_comando.CommandText = sqlstring


        'Detalle conversation

        'sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
        'sqlstring = sqlstring & " Values ('" & IdOracion & "', '" & j & "', '" & Con_Id & "', '0')"

        '_comando.CommandText = sqlstring

        'Try
        '    i = _comando.ExecuteNonQuery

        '    If i > 0 Then
        '        'MsgBox("se guardo")
        '    Else
        '        MsgBox("No se guardo")
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        'End Try

        'j = j + 1

        _comando.Connection.Close()

        MessageBox.Show("Completed !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub cmdEliminarPaneles_Click(sender As System.Object, e As System.EventArgs) Handles cmdEliminarPaneles.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim da As New SqlDataAdapter
         
        Dim j As Integer
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
        
        Dim n As Integer
        Dim m As Integer

        Dim dtConversaciones As New DataTable
        Dim dtDetalles As New DataTable

        'Tbl Detalles
        Try
            _comando.Connection.Open()

            sqlstring = "  SELECT        Det_Conversation.Con_Id, COUNT(Dialogos.Id) AS Cuenta, Dialogos.OracionId, Det_Conversation.Det_Con"
            sqlstring = sqlstring & " FROM            Det_Conversation LEFT OUTER JOIN"
            sqlstring = sqlstring & "                    Dialogos ON Det_Conversation.Det_Con = Dialogos.DetConversacion"
            sqlstring = sqlstring & " GROUP BY Det_Conversation.Con_Id, Dialogos.OracionId, Det_Conversation.Det_Con"
            ' sqlstring = sqlstring & "         HAVING(Det_Conversation.Con_Id = 8383)"
            sqlstring = sqlstring & " ORDER BY Cuenta DESC"

            _comando.CommandText = sqlstring

            da.SelectCommand = _comando

            da.Fill(dtConversaciones)

            n = dtConversaciones.Rows.Count

            _comando.Connection.Close()

        Catch ex As Exception
        End Try

        Dim Id As Integer
        Dim texto As String
        Dim i As Integer
        _comando.Connection.Open()

        Dim Cuenta As Integer
        'Insertar en Dialogos
        For Each r In dtConversaciones.Rows

            Cuenta = r.item(1)

            If Cuenta = 0 Then
                Id = r.item(3)

                sqlstring = " DELETE FROM Det_Conversation"
                sqlstring = sqlstring & " WHERE (Det_Con = '" & Id & "')"

                _comando.CommandText = sqlstring

                Try
                    j = _comando.ExecuteNonQuery
                    m += 1

                Catch ex As Exception

                End Try
            End If
        Next

        MsgBox("Eliminados: " & m)


    End Sub

    Private Sub cmdInsertarDialogo_Click(sender As System.Object, e As System.EventArgs) Handles cmdInsertarDialogo.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim da As New SqlDataAdapter

        Dim SQL As String

        Dim j As Integer
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
        
        Dim n As Integer

        Dim dtGrupos As New DataTable
        Dim dtOraciones As New DataTable
        Dim Enc_Id As Integer
        Dim Grupo As String
        Dim Categoria As String
        Dim x As Integer
        Dim g As Integer

        '----------      Grupos        ------------------
        Try
            _comando.Connection.Open()

            sqlstring = "   SELECT         Id, Grupo, Categoria, estatus, Nivel, Tipo, Agregado"
            sqlstring = sqlstring & "  FROM Grupos_oracion"
            sqlstring = sqlstring & "  Where Agregado='N'"
            _comando.CommandText = sqlstring

            da.SelectCommand = _comando

            da.Fill(dtGrupos)

            n = dtGrupos.Rows.Count

            _comando.Connection.Close()

            pbar.Maximum = n
        Catch ex As Exception
        End Try

        Dim Id As Integer
        Dim texto As String
        Dim i As Integer
        Dim IdDet As Integer

        _comando.Connection.Open()

        'Insertar en Dialogos
        For Each r In dtGrupos.Rows

            Id = r.item(0)
            Grupo = r.item(1)
            Categoria = r.item(2)
            da = New SqlDataAdapter

            sqlstring = "   SELECT        Id, Orden, STL, TextoPlano, Traduccion, estatus, Oracion, GrupoO, foco"
            sqlstring = sqlstring & "  FROM Oraciones"
            sqlstring = sqlstring & "       WHERE  GrupoO='" & Id & "'"
            sqlstring = sqlstring & " ORDER BY  Orden ASC"
            _comando.CommandText = sqlstring

            da.SelectCommand = _comando

            dtOraciones.Rows.Clear()

            da.Fill(dtOraciones)

            n = dtOraciones.Rows.Count

            _comando.Connection.Close()

            _comando.Connection.Open()

            Dim OracionId As Integer
            Dim titulo As String

            j = 0

            g = 0

            For x = 0 To dtOraciones.Rows.Count - 1

                'Nuevo Encabezado-

                titulo = Grupo & " # " & g

                Enc_Id = frmNewConversation.GuardarConversation(titulo, Categoria)

                j = 0

                Do While j < 100

                    'Nuevo Detalle
                    'Detalle conversation
                    sqlstring = "Insert into det_Conversation (Det_Orden, Con_Id, Det_Person)"
                    sqlstring = sqlstring & " Values ('" & j & "', '" & Enc_Id & "', '0')"
                    _comando.CommandText = sqlstring

                    Try
                        i = _comando.ExecuteNonQuery
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    Try
                        If i > 0 Then
                            SQL = "SELECT @@IDENTITY FROM det_Conversation"
                            _comando = New SqlCommand(SQL, _comando.Connection)
                            Dim value As Object = _comando.ExecuteScalar
                            IdDet = value.ToString
                        End If
                    Catch ex As Exception
                    End Try


                    For t = 0 To 1

                        If x < n Then
                            OracionId = dtOraciones.Rows(x).Item(0)

                            sqlstring = "Insert into Dialogos (OracionId, Orden, DetConversacion)"
                            sqlstring = sqlstring & " Values ('" & OracionId & "', @Orden, '" & IdDet & "')"
                            _comando.CommandText = sqlstring
                            _comando.Parameters.Clear()

                            _comando.Parameters.AddWithValue("@Orden", t)

                            Try
                                i = _comando.ExecuteNonQuery
                            Catch ex As Exception
                            Finally

                            End Try
                        End If


                        x += 1

                    Next t

                    j = j + 1

                Loop

                g = g + 1
            Next


            sqlstring = " UPDATE Grupos_Oracion Set Agregado = 'S'"
            sqlstring = sqlstring & " WHERE (Id = '" & Id & "')"

            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
            Finally

            End Try

            pbar.Value += 1
        Next r

        _comando.Connection.Close()

        MessageBox.Show("Completed !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click
        frmTextoOrdenarDialogos.Show()
    End Sub

    Private Sub cmdImagen_Click(sender As System.Object, e As System.EventArgs) Handles cmdImagen.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim j As Integer

        Dim r As Integer

        Dim OracionId As Integer
        Dim da As New SqlDataAdapter

        Dim dt As New DataTable

        _comando.Connection.Open()

        sqlstring = "   SELECT        Id,   TextoPlano, Traduccion, estatus, Oracion, GrupoO, foco"
        sqlstring = sqlstring & "  FROM Oraciones"

        sqlstring = sqlstring & " Where TextoPlano LIKE '%' + @TextoPlano + '%'"
        sqlstring = sqlstring & " ORDER BY Oraciones.TextoPlano ASC"
        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@TextoPlano", "?")
         
        da.SelectCommand = _comando
        da.Fill(dt)
        r = dt.Rows.Count
        For Each rw In dt.Rows ' Exclude the potential new row in DataGridView

            OracionId = rw.item(0)

            sqlstring = " UPDATE Oraciones Set IMG = 'Pregunta1.png'"
            sqlstring = sqlstring & " WHERE (Id = '" & OracionId & "')"

            Try
                j = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Next
        _comando.Connection.Close()

        MessageBox.Show("Completed !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub

    Private Sub cmdCambiarSignos_Click(sender As System.Object, e As System.EventArgs) Handles cmdCambiarSignos.Click
        Dim i As Integer
        Dim carpeta As String
        Dim FileToMove As String
        Dim MoveLocation As String
        Dim IdOracion As Integer

        Dim rutaCarpeta As String = "C:\Legacy\Ingles\audios\SinDefinir\" ' Define la ruta de la carpeta
        Dim params() As String
        Dim texto As String
        Dim valorModificado As String

        Dim archivos() As String = Directory.GetFiles(rutaCarpeta) '' Obtiene todos los archivos como una matriz de cadenas
        Dim valorActual As String

        Dim item As ListViewItem 'Creo el ListViewItem (item) 

        For Each archivo As String In archivos '' Agrega cada nombre de archivo al ListBox

            ' params = Split(Path.GetFileNameWithoutExtension(archivo), "-")
            texto = Path.GetFileName(archivo)

            Try
                'texto = params(1)

                Dim filename As String = ""
                Dim ruta As String = ""

                carpeta = Dir(filename)

                valorActual = texto
                 
                'valorModificado = valorActual.Replace("--", "") ' Reemplaza 'a' por 'X'
                My.Computer.FileSystem.RenameFile(rutaCarpeta & valorActual, "English phrases -" & i & ".mp3")

            Catch ex As Exception
            End Try

            i += 1
        Next


          
        '    'valorModificado = Trim(valorActual)
        '    Try

        '        If File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3") Then
        '            ' El archivo existe
        '        Else 'No existe
        '            FileToMove = " & IdOracion & ".mp3"
        '            MoveLocation = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"

        '            System.IO.File.Move(FileToMove, MoveLocation)

        '        End If

        '        'My.Computer.FileSystem.RenameFile(filename, IdOracion & ".mp3")

        '    Catch ex As Exception

        '    End Try

        'End If

        'Mover de Sin Definir a Audios


        'If carpeta = "C:\Legacy\Ingles\Audios\SinDefinir\" Then
        '    FileToMove = "C:\Legacy\Ingles\Audios\SinDefinir\" & IdOracion & ".mp3"
        '    MoveLocation = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"


        '    Try
        '        ' System.IO.File.Move(FileToMove, MoveLocation)
        '    Catch ex As Exception

        '    End Try
        'End If

        'End Using

    End Sub

    Private Sub cmdEstrategia_Click(sender As System.Object, e As System.EventArgs) Handles cmdEstrategia.Click
        frmEstrategia.Show()

    End Sub

    Private Sub cmdOracionesDialogos_Click(sender As System.Object, e As System.EventArgs) Handles cmdOracionesDialogos.Click
        frmOracionesDialogos.Show()
    End Sub

    Private Sub cmdGrafica_Click_1(sender As System.Object, e As System.EventArgs) Handles cmdGrafica.Click

        frmGrafica.Show()


    End Sub

    Private Sub cmdRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefresh.Click
        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\Actualiza\ActualizarUso.py"" "
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        Dim p As Process = Process.Start(psi)
        Dim resultado As String = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

        MessageBox.Show(resultado)

        CrearGrafica()


    End Sub

    Private Sub cmdActualizaStatus_Click(sender As System.Object, e As System.EventArgs) Handles cmdActualizaStatus.Click
        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\Actualiza\ActualizaStatus.py"" "
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        Dim p As Process = Process.Start(psi)
        Dim resultado As String = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

        MessageBox.Show(resultado)

    End Sub

    
End Class