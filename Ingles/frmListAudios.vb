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

'Imports Microsoft.Office.Interop.Word
'Imports Microsoft.Office.Interop

Public Class frmListAudios
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
    Private objOpenDialogo As New OpenFileDialog
    Private hilo1 As Threading.Timer 'a
    Private objLista As WMPLib.IWMPPlaylist
    Public dt As DataTable
    Dim maxColumna As Integer

    'Private lvwColumnSorter As ListViewColumnSorter
    Private LastColumnIndex As Integer = -1
    Private LastSortOrder As SortOrder = SortOrder.Ascending
    Dim sortColumn As Integer = -1

    Dim _comando As SqlCommand = MetodosDatos.CrearComando()

    Private Sub frmListAudios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        rate = tbVelocidad.Value / 10

        AddHandler ListView1.ColumnClick, AddressOf Me.ListView1_ColumnClick
        'Dim nuevaLista As WMPLib.IWMPPlaylist ' Declarar la lista de reproducción.
        'nuevaLista = AxWindowsMediaPlayer1.playlistCollection.newPlaylist("MiNuevaPlaylist")  ' Crear una nueva lista de reproducción con un nombre.

        ' '' Check that the AxWindowsMediaPlayer control is on the form.
        ''If AxWindowsMediaPlayer1 IsNot Nothing Then
        '    Dim mediaCollection As WMPLib.IWMPMediaCollection = AxWindowsMediaPlayer1.mediaCollection

        '    Try
        '        '
        '        Dim allMedia As WMPLib.IWMPPlaylist = mediaCollection.getAll() 'Get a playlist containing all items in the library.

        '        If allMedia IsNot Nothing Then
        '            Debug.WriteLine("Listing all media items:")
        '            For i As Integer = 0 To allMedia.count - 1
        '                Dim mediaItem As WMPLib.IWMPMedia = allMedia.Item(i)
        '                ListBox1.Items.Add(mediaItem.name)


        '            Next
        '        End If

        '    Catch ex As Exception
        '        MessageBox.Show("Error accessing media collection: " & ex.Message)
        '    End Try
        'End If

        ' Limpia cualquier elemento previo si se está actualizando una lista
        ' ListBox1.Items.Clear()

        ' Obtiene todos los archivos con extensión .mp3 y .wav de la carpeta
        'Dim audioFiles As String() = Directory.GetFiles("C:\Legacy\Ingles\audios\, "*.*") _
        '.Where(Function(f) f.ToLower().EndsWith(".mp3") OrElse f.ToLower().EndsWith(".wav")).ToArray()

        '' Itera sobre cada archivo de audio encontrado
        'For Each audioFile As String In audioFiles
        '    ' Aquí puedes agregar el archivo a un ListBox, o hacer cualquier otra operación
        '    ' Por ejemplo: ListBox1.Items.Add(Path.GetFileName(audioFile))
        '    Console.WriteLine(audioFile) ' O imprimir en la consola para depurar
        'Next


        ' ... dentro de tu código, por ejemplo, en el evento Click de un botón ...


        'cargarDatos()

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

            'Me.cboGrupo.DataSource = dt
            'Me.cboGrupo.ValueMember = "Id"
            'Me.cboGrupo.DisplayMember = "Grupo"

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
            Me.cboGrupo.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
            i = i + 1
        Loop

        CargarArchivos()

        ListView1.View = View.Details ' Set the view to show details.
        ListView1.LabelEdit = False ' Allow the user to edit item text.
        ListView1.AllowColumnReorder = True ' Allow the user to rearrange columns.
        ListView1.FullRowSelect = True ' Select the item and subitems when selection is made.
        ListView1.GridLines = True ' Display grid lines.
        ' Crear los objetos de medios y añadirlos a la lista.
        ' Debes reemplazar las rutas con las de tus archivos.
        ' nuevaLista.appendItem(AxWindowsMediaPlayer1.newMedia("C:\Ruta\a\tu\cancion3.mp3"))


        'objOpenDialogo.RestoreDirectory = True
        'objOpenDialogo.Multiselect = True
        'objOpenDialogo.Filter = "Archivos MP3 |*.mp3"
        'objOpenDialogo.ShowDialog()

        ''  Inserto en la colección del Media Player los archivos seleccionados
        'Dim archivo As String
        'For Each archivo In objOpenDialogo.FileNames
        '    nuevaLista.appendItem(AxWindowsMediaPlayer1.newMedia(archivo))
        '    ' objMP.mediaCollection.add(archivo)
        'Next


        'Me.BringToFront()
        'Dim ruta As String

        'Dim mensaje As String

        'Dim WMP As New WMPLib.WindowsMediaPlayer()
        'Dim mediaCollection As WMPLib.IWMPMediaCollection
        'Dim audioPlaylist As WMPLib.IWMPPlaylist

        '' Get the media collection from the WMP object
        'mediaCollection = WMP.mediaCollection

        '' Get a playlist containing all audio files in the library
        'audioPlaylist = mediaCollection.getByAttribute("MediaType", "audio")

        '' Clear any existing items in the ListBox
        'ListBox1.Items.Clear()

        '' Loop through the playlist and add each audio file's name to the ListBox
        'If audioPlaylist IsNot Nothing Then
        '    For i As Integer = 0 To audioPlaylist.count - 1
        '        Dim mediaItem As WMPLib.IWMPMedia = audioPlaylist.Item(i)
        '        If mediaItem IsNot Nothing Then
        '            ListBox1.Items.Add(mediaItem.name)
        '        End If
        '    Next
        'End If

        '' Important: Close the WMP object to release resources
        'WMP.close()


        'Creo una lista para manejar mejor la colección del Media Player
        '  Dim objLista As WMPLib.IWMPMediaCollection
        '  objLista = objMP.mediaCollection

        'Debería ahora, indicar al Media Player que reproduzca la colección . . .



    End Sub

   
    Private Sub ListView1_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick

        '
        ' Crear una instancia de la clase que realizará la comparación
        Dim oCompare As New ListViewColumnSort()
        '
        ' Asignar el orden de clasificación
        If ListView1.Sorting = SortOrder.Ascending Then
            oCompare.Sorting = SortOrder.Descending
        Else
            oCompare.Sorting = SortOrder.Ascending
        End If
        ListView1.Sorting = oCompare.Sorting
        '
        ' La columna en la que se ha pulsado
        oCompare.ColumnIndex = e.Column
        ' El tipo de datos de la columna en la que se ha pulsado
        Select Case e.Column
            Case 0
                oCompare.CompararPor = ListViewColumnSort.TipoCompare.Cadena
            Case 1
                oCompare.CompararPor = ListViewColumnSort.TipoCompare.Numero
            Case 2
                oCompare.CompararPor = ListViewColumnSort.TipoCompare.Fecha
        End Select
        ' Asignar la clase que implementa IComparer
        ' y que se usará para realizar la comparación de cada elemento
        ListView1.ListViewItemSorter = oCompare
        '
        ' Cuando se asigna ListViewItemSorter no es necesario llamar al método Sort
        'ListView1.Sort()
        '
        ' ========================================
        ' Usando la clase ListViewColumnSortSimple
        ' ========================================
        ''
        '' Crear una instancia de la clase que realizará la comparación
        'Dim oCompare As New ListViewItemComparer()
        ''
        '' Asignar el orden de clasificación
        'If ListView1.Sorting = SortOrder.Ascending Then
        '    oCompare.Sorting = SortOrder.Descending
        'Else
        '    oCompare.Sorting = SortOrder.Ascending
        'End If
        'ListView1.Sorting = oCompare.Sorting
        ''
        '' La columna en la que se ha pulsado
        'oCompare.ColumnIndex = e.Column
        '' Asignar la clase que implementa IComparer
        '' y que se usará para realizar la comparación de cada elemento
        'ListView1.ListViewItemSorter = oCompare
        ''
        '' Cuando se asigna ListViewItemSorter no es necesario llamar al método Sort
        ''ListView1.Sort()

        ' '' Determine whether the column is the same as the last column clicked.
        'If e.Column <> sortColumn Then
        '    ' Set the sort column to the new column.
        '    sortColumn = e.Column
        '    ' Set the sort order to ascending by default.
        '    ListView1.Sorting = SortOrder.Ascending
        'Else
        '    ' Determine what the last sort order was and change it.
        '    If ListView1.Sorting = SortOrder.Ascending Then
        '        ListView1.Sorting = SortOrder.Descending
        '    Else
        '        ListView1.Sorting = SortOrder.Ascending
        '    End If
        'End If
        '' Call the sort method to manually sort.
        'ListView1.Sort()
        '' Set the ListViewItemSorter property to a new ListViewItemComparer
        '' object.
        'ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column, ListView1.Sorting)

        ' En el evento de carga de datos o de clic:
     
        ' Obtener el índice de la columna en la que se hizo clic
        'Dim columnIndex As Integer = e.Column

        '' Si la columna es la misma que la anterior, invierte el orden
        'If columnIndex = LastColumnIndex Then
        '    If LastSortOrder = SortOrder.Ascending Then
        '        LastSortOrder = SortOrder.Descending
        '    Else
        '        LastSortOrder = SortOrder.Ascending
        '    End If
        'Else
        '    ' Si es una columna nueva, establece el orden ascendente por defecto
        '    LastSortOrder = SortOrder.Ascending
        'End If

        '' Asigna la columna y el orden de clasificación
        'ListView1.Sorting = LastSortOrder
        '' Usa la propiedad 'Column' del objeto ListViewItemSorter
        'ListView1.Sort(columnIndex, LastSortOrder)

        '' Guarda el índice de la columna actual
        'LastColumnIndex = columnIndex

    End Sub
    Private Sub CargarArchivos()
        Dim rutaCarpeta As String = "C:\Legacy\Ingles\audios\SinDefinir\" ' Define la ruta de la carpeta
        Dim params() As String
        Dim texto As Integer
        Dim textoModificado As Integer

        Dim archivos() As String = Directory.GetFiles(rutaCarpeta) '' Obtiene todos los archivos como una matriz de cadenas



        Dim item As ListViewItem 'Creo el ListViewItem (item) 
        Dim i As Integer

        'i = ListView1.Items.Count + 1

        ' Create an instance of a ListView column sorter and assign it 
        ' to the ListView control.
        'lvwColumnSorter = New ListViewColumnSorter()
        ' Me.ListView1.ListViewItemSorter = lvwColumnSorter

        ListView1.Items.Clear()

        ' ListBox1.Items.Clear()
        For Each archivo As String In archivos '' Agrega cada nombre de archivo al ListBox


            params = Split(Path.GetFileNameWithoutExtension(archivo), "-")

            Try
                texto = params(1)

                'If Len(texto) = 1 Then
                '    textoModificado = CInt("00" & texto) ' & ".mp3"
                'ElseIf Len(texto) = 2 Then
                '    textoModificado = CInt("0" & texto) ' ".mp3"
                'Else
                '    textoModificado = CInt(texto)
                'End If

                item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

                item.SubItems.Add(texto)
                item.SubItems.Add(Path.GetFileName(archivo))

                ListView1.Items.Add(item)
            Catch ex As Exception

            End Try



            'ListBox1.Items.Add(textoModificado) ' Usa Path.GetFileName para obtener solo el nombre del archivo
            '' nuevaLista.appendItem()
            '' nuevaLista.appendItem(AxWindowsMediaPlayer1.newMedia(archivo))

            'ListBox1.Sorted = True
            i += 1
        Next

        ' Por defecto se clasifica por la primera columna
        ListView1.Sorting = SortOrder.Ascending
        ListView1.Sort()


        lblCuenta.Text = ListView1.Items.Count
        'Para ordenar ascendentemente por texto
        ' ListView1.Sorting = SortOrder.Ascending

        
        ' Llama al método Sort para ordenar
        'ListView1.Sort()



    End Sub
#Region "Player"

    Private Sub cmdPlay_Click(sender As System.Object, e As System.EventArgs) Handles cmdPlay.Click



    End Sub
    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub CargarDatos(param)
        Dim _grupo As String
        Dim sqlstring As String = ""

        If Me.cboGrupo.Text = "" Then Exit Sub
        ' If Me.cboGrupo.SelectedIndex = -1 Then Exit Sub
        ' If IdGrupo = 0 Then Exit Sub

        _grupo = Trim(cboGrupo.Text)

        Dim IdGrupo As Integer

        Try
            IdGrupo = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

        Catch ex As Exception
        End Try


        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim buscar As String


        Dim i, n As Integer

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        buscar = Trim(Me.txtBuscar.Text)

        'If Len(buscar) < 1 Then Exit Sub

        _comando = MetodosDatos.CrearComando()

        sqlstring = "select Oraciones.Id, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.GrupoO, Oraciones.Audio"
        sqlstring = sqlstring & " FROM            Oraciones INNER JOIN  Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"

        ' sqlstring = "select  Oraciones.Id, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.GrupoO, Oraciones.Audio "
        'sqlstring = sqlstring & " FROM            Oraciones INNER JOIN  Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"

        If buscar = "" Then
            sqlstring = sqlstring & " Where  GrupoO= '" & IdGrupo & "'"
            sqlstring = sqlstring & param
        Else
            sqlstring = sqlstring & " Where TextoPlano LIKE '%' + @TextoPlano + '%' And GrupoO= '" & IdGrupo & "'"
            sqlstring = sqlstring & " AND Audio ='N'"
            _comando.Parameters.AddWithValue("@TextoPlano", buscar)

        End If
        ' sqlstring = sqlstring & " ORDER BY Oraciones.Id ASC"
        sqlstring = sqlstring & " ORDER BY Oraciones.Id ASC"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        Try


            dt.Clear()

            da.SelectCommand = _comando

            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        _comando.Connection.Close()

        n = dt.Rows.Count
        dt.AcceptChanges()

        dgvOraciones.DataSource = dt

        'MaxColumna = dt.Columns.Count

        Try
            dgvOraciones.Columns(0).Visible = False

            dgvOraciones.Columns(1).Width = 300
            dgvOraciones.Columns(2).Width = 300
            dgvOraciones.Columns(3).Width = 60

        Catch ex As Exception

        End Try

    End Sub
    Public Sub CargarDatosOraciones()
        Dim param As String
        Dim resp As Integer
        Dim i, n As Integer
        Dim folderName As String = ""

        Dim ruta As String = "C:\Legacy\Ingles\Lectura\"

        ' Dim oWord As Word.Application
        ' Dim oDoc As Word.Document
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
            ' oWord = New Word.Application()
            'oDoc = oWord.Documents.Add()


            'oDoc.Content.Text = "Reporte No:" '& 'Id ' Añadir texto al documento
            'With oDoc.PageSetup
            '    .TopMargin = 20   ' 1 inch top margin
            '    .BottomMargin = 20 ' 1 inch bottom margin
            '    .LeftMargin = 20 ' 1.25 inch left margin
            '    .RightMargin = 20 ' 1.25 inch right margin
            'End With
            '' Guardar el documento en una ruta específica

            '' oDoc.SaveAs(ruta & "\" & carpeta & "\" & filename & ".rtf")
            '' oDoc.SaveAs2(ruta & "\" & filename, Word.WdSaveFormat.wdFormatRTF)
            '' Cerrar el documento y salir de Word
            'oDoc.Close()
            'oWord.Quit()

            '' Liberar los objetos
            'System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc)
            'System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord)
            'oDoc = Nothing
            'oWord = Nothing

            MessageBox.Show("Archivo Word creado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

            '  RichTextBox2.LoadFile(archivo)

        End If


    End Sub

    Public Sub CargarDatosListening(Id)
        'Dim param As String
        'Dim resp As Integer
        'Dim i, n As Integer
        'Dim folderName As String = ""

        'lbltitulo.Text = filename
        'Dim ruta As String = "C:\Legacy\Ingles\Lectura\"

        'Dim oWord As Word.Application
        'Dim oDoc As Word.Document
        'Dim archivo As String
        'Dim carpeta As String

        'archivo = ruta & filename & "_test.rtf"

        'If System.IO.File.Exists(archivo) Then
        '    ' RichTextBoxEx1.rtb.LoadFile(archivo) '.rtf"
        '    'RichTextBox1.LoadFile(archivo)
        '    'RichTextBoxEx1.filename = archivo
        '    ' RichTextBox2.LoadFile(archivo)
        'Else
        '    'Dim di As DirectoryInfo = Directory.CreateDirectory(archivo)

        '    ' Iniciar Word y crear un nuevo documento
        '    oWord = New Word.Application()
        '    oDoc = oWord.Documents.Add()


        '    oDoc.Content.Text = "Test_" ' Añadir texto al documento
        '    With oDoc.PageSetup
        '        .TopMargin = 20   ' 1 inch top margin
        '        .BottomMargin = 20 ' 1 inch bottom margin
        '        .LeftMargin = 20 ' 1.25 inch left margin
        '        .RightMargin = 20 ' 1.25 inch right margin
        '    End With
        '    ' Guardar el documento en una ruta específica

        '    ' oDoc.SaveAs(ruta & "\" & carpeta & "\" & filename & ".rtf")
        '    oDoc.SaveAs2(ruta & filename & "_test", Word.WdSaveFormat.wdFormatRTF)
        '    ' Cerrar el documento y salir de Word
        '    oDoc.Close()
        '    oWord.Quit()


        '    ' Liberar los objetos
        '    System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc)
        '    System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord)
        '    oDoc = Nothing
        '    oWord = Nothing

        '    MessageBox.Show("Archivo Word creado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    ' RichTextBox2.LoadFile(archivo)

        'End If


    End Sub
    Public Sub CargarTraduccion()
        'Dim param As String
        'Dim resp As Integer
        'Dim i, n As Integer
        'Dim folderName As String = ""

        'Dim ruta As String = "C:\Legacy\Ingles\Lectura\"

        'Dim oWord As Word.Application
        'Dim oDoc As Word.Document
        'Dim archivo As String
        'Dim carpeta As String

        'archivo = ruta & filename & "_trad.rtf"

        'If System.IO.File.Exists(archivo) Then
        '    ' RichTextBox3.LoadFile(archivo)
        'Else
        '    'Dim di As DirectoryInfo = Directory.CreateDirectory(archivo)

        '    ' Iniciar Word y crear un nuevo documento
        '    oWord = New Word.Application()
        '    oDoc = oWord.Documents.Add()


        '    oDoc.Content.Text = "Traduccion" ' Añadir texto al documento
        '    With oDoc.PageSetup
        '        .TopMargin = 20   ' 1 inch top margin
        '        .BottomMargin = 20 ' 1 inch bottom margin
        '        .LeftMargin = 20 ' 1.25 inch left margin
        '        .RightMargin = 20 ' 1.25 inch right margin
        '    End With
        '    ' Guardar el documento en una ruta específica

        '    ' oDoc.SaveAs(ruta & "\" & carpeta & "\" & filename & ".rtf")
        '    oDoc.SaveAs2(ruta & filename & "_trad", Word.WdSaveFormat.wdFormatRTF)
        '    ' Cerrar el documento y salir de Word
        '    oDoc.Close()
        '    oWord.Quit()


        '    ' Liberar los objetos
        '    System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc)
        '    System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord)
        '    oDoc = Nothing
        '    oWord = Nothing

        '    MessageBox.Show("Archivo Word creado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    '   RichTextBox3.LoadFile(archivo)
        '    '
        'End If


    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
       


        'AxWindowsMediaPlayer1.URL = ruta 

        ''AxWindowsMediaPlayer1.currentPlaylist = nuevaLista  ' Asignar la lista de reproducción al reproductor.

        '' AxWindowsMediaPlayer1.Ctlcontrols.play() ' Iniciar la reproducción de la lista.
        'AxWindowsMediaPlayer1.Ctlcontrols.play()

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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
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


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)

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
            'RichTextBox2.SaveFile("C:\Legacy\Ingles\Lectura" & "\" & filename & "_test" & ".rtf")
        Else
            'RichTextBox1.SaveFile("C:\Legacy\Ingles\Lectura" & "\" & filename & ".rtf")

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

            ' Panel1.Visible = False
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

        ' RichTextBox2.SelectionFont = nuevaFuente
        'RichTextBox2.SelectionColor = Color.Red
    End Sub

    Private Sub RichTextBox3_Click(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub RichTextBox3_DockChanged(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub RichTextBox3_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
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
            ' RichTextBox3.SaveFile("C:\Legacy\Ingles\Lectura" & "\" & filename & "_trad" & ".rtf")


        ElseIf nombre.Contains("Bloques") Then

        End If

        MsgBox("Saved", vbInformation)

    End Sub


    Private Sub cmdMover_Click(sender As System.Object, e As System.EventArgs) Handles cmdMover.Click
        ' Dim ofd As New OpenFileDialog
        Dim IdOracion As Integer
        Dim i As Integer

        IdOracion = dgvOraciones.CurrentRow.Cells(0).Value.ToString()

        Dim filename As String = ""
        Dim rutaNueva As String = ""
        Dim rutaActual As String = ""
        rutaActual = "C:\Legacy\Ingles\Audios\SinDefinir\" & ListView1.SelectedItems.Item(0).Text
        rutaNueva = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"


        Try

            If File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3") Then
                ' El archivo existe
                My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", "Libre.mp3")
                System.IO.File.Move(rutaActual, rutaNueva)

            End If

            ' My.Computer.FileSystem.RenameFile(rutaActual, rutaNueva)
            ' My.Computer.FileSystem.MoveFile(, )
            System.IO.File.Move(rutaActual, rutaNueva)

            'Actualiza en Dialogos
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()

            _comando.Connection.Open()
            Dim sqlstring As String
            sqlstring = "Update Oraciones SET Audio='S'"
            sqlstring = sqlstring & "  WHERE Id = '" & IdOracion & "'"
            _comando.CommandText = sqlstring
            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
            End Try
           
            ' CargarArchivos()
            '  ListBox1.Items.Remove(ListBox1.SelectedItem)
            'ListBox1.Items.Remove(ListBox1.SelectedIndices)
            'ListBox1.Items.Remove(ListBox1.SelectedItem)
            ' ListView1.SelectedItems(0).Index()

            ListView1.Items.Remove(ListView1.SelectedItems.Item(0))

        Catch ex As Exception

        End Try

        CargarDatos("")

        If i > 0 Then
            'MsgBox("Se guardo correctamente")
        End If

        txtBuscar.Text = ""


    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim buscar As String
        Dim sqlstring As String = ""

        Dim i, n As Integer

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim IdGrupo As Integer

        buscar = Trim(Me.txtBuscar.Text)

        _comando = MetodosDatos.CrearComando()

        sqlstring = "select  Oraciones.Id, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.GrupoO, Oraciones.Audio "
        sqlstring = sqlstring & " FROM            Oraciones INNER JOIN  Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"

        If cboGrupo.Text = "" Then

            If txtBuscar.Text = "" Then
                Exit Sub
            Else
                sqlstring = sqlstring & " Where TextoPlano LIKE '%' + @TextoPlano + '%'"
                _comando.Parameters.AddWithValue("@TextoPlano", buscar)
            End If


        Else
            IdGrupo = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

            If Len(buscar) < 1 Then
                sqlstring = sqlstring & " Where  GrupoO= '" & IdGrupo & "'"
                ' sqlstring = sqlstring & " AND Audio ='N'"
            Else

                sqlstring = sqlstring & " Where TextoPlano LIKE '%' + @TextoPlano + '%'"
                sqlstring = sqlstring & " AND  GrupoO= '" & IdGrupo & "'"
                '  sqlstring = sqlstring & " AND Audio ='N'"

                _comando.Parameters.AddWithValue("@TextoPlano", buscar)

            End If

        End If

      
        
        sqlstring = sqlstring & " ORDER BY Oraciones.TextoPlano ASC"
        _comando.CommandText = sqlstring

        _comando.Connection.Open()


        Try


            dt.Clear()

            da.SelectCommand = _comando

            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        _comando.Connection.Close()

        n = dt.Rows.Count
        dt.AcceptChanges()

        dgvOraciones.DataSource = dt

        'MaxColumna = dt.Columns.Count

        Try
            dgvOraciones.Columns(0).Visible = False

            dgvOraciones.Columns(1).Width = 300
            dgvOraciones.Columns(2).Width = 300
            dgvOraciones.Columns(3).Width = 60

            ' dgvOraciones.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            ' dgvOraciones.Columns(5).Visible = False
            'dgvOraciones.Columns(6).Visible = False
            ' dgvOraciones.Columns(7).Visible = False


        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupo.SelectedIndexChanged

        CargarDatos("")

    End Sub
    Public Sub CargarDatosFiltro(filtro)
        '_comando = MetodosDatos.CrearComando()
        'Dim sqlstring As String

        'If filtro = Nothing Then Exit Sub



        'dgvOraciones.DataSource = Nothing
        'dt.Rows.Clear()

        'Try
        '    _comando.CommandText = sqlstring
        '    _comando.Connection.Open()

        '    da.SelectCommand = _comando
        '    da.Fill(dt)
        '    dt.AcceptChanges()

        '    dgvOraciones.DataSource = dt

        '    MaxColumna = dgvOraciones.ColumnCount

        '    _comando.Connection.Close()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally

        'End Try

        'sqlstring = "select  Oraciones.Id, Oraciones.orden, Oraciones.STL,  Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.Estatus, Oraciones.Oracion, Oraciones.GrupoO, Grupos_oracion.Grupo, "
        'sqlstring = sqlstring & "Oraciones.foco, Oraciones.Palabras"
        'sqlstring = sqlstring & " FROM            Oraciones INNER JOIN  Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"
        'sqlstring = sqlstring & filtro
        'sqlstring = sqlstring & " Order By orden ASC"
        'Try
        '    dgvOraciones.Columns(0).Visible = False
        '    'dgvOraciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    ' dgvOraciones.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    dgvOraciones.Columns(1).Width = 50
        '    dgvOraciones.Columns(2).Width = 50
        '    'dgvOraciones.Columns(2).Width = 100
        '    dgvOraciones.Columns(3).Width = 300
        '    dgvOraciones.Columns(4).Width = 300
        '    ' 
        'dgvOraciones.Columns(5).Visible = False
        'dgvOraciones.Columns(6).Visible = False
        'dgvOraciones.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Catch ex As Exception

        'End Try


        'Dim n As Integer
        'n = dt.Rows.Count
        'If n = 0 Then Exit Sub


        'Try
        '    dgvOraciones.Rows(SelectedId).Selected = True
        '    'dgvOraciones.Scroll()
        '    'dgvOraciones.ScrollIntoView(dgvOraciones.SelectedItem)
        '    'Me.DGVMateriales.FirstDisplayedScrollingRowIndex = I
        '    dgvOraciones.FirstDisplayedScrollingRowIndex = SelectedId
        'Catch ex As Exception

        'End Try




    End Sub

    Private Sub dgvOraciones_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOraciones.CellContentClick
 
        Try
            Player.URL = "C:\Legacy\Ingles\Audios\" & dgvOraciones.CurrentRow.Cells(0).Value.ToString() & ".mp3"
            Player.controls.play()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvOraciones_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvOraciones.CellFormatting
        'Set the background to red for negative values in the Balance column.

        If dgvOraciones.Columns(e.ColumnIndex).Name.Equals("Audio") Then
            If e.Value = "S" Then
                For ColNo As Integer = 0 To maxColumna - 1
                    dgvOraciones.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = Color.LightGreen
                Next

            End If
        End If

    End Sub

    Private Sub dgvOraciones_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvOraciones.DoubleClick
        Dim Id As Integer
        Dim frm As New FrmDetOracion

        AddOwnedForm(frm)

        Id = dgvOraciones.CurrentRow.Cells(0).Value.ToString()

        Dim IdGrupo As Integer
        Dim sqlstring As String = ""

        Try
            If cboGrupo.SelectedIndex > -1 Then
                IdGrupo = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

            End If
        Catch ex As Exception

        End Try

 
        frm.GrupoOracionId = IdGrupo
        frm.IdOracion = Id
        frm.CargarDatos(Id)
        frm.Show()
    End Sub

    Private Sub dgvOraciones_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvOraciones.MouseClick

        Dim resp As Integer
        Dim IdOracion As Integer
        Dim j As Integer

        If e.Button = System.Windows.Forms.MouseButtons.Right Then

            If ListView1.SelectedItems.Count = 0 Then Exit Sub
           
            ' Dim ofd As New OpenFileDialog
            Dim i As Integer

            IdOracion = dgvOraciones.CurrentRow.Cells(0).Value.ToString()

            ' If IdOracion = 0 Then
            ''Entonces no existe en 'Oraciones'
            'If cboGrupo.Text = "" Then
            '    MsgBox("Seleccione un Grupo")
            '    Exit Sub
            'End If

            ''Agrega nueva
            'Dim sqlstring As String

            'Dim OracionEN As String
            'Dim OracionES As String
            'Dim SQL As String
            'Dim IdCon As Integer

            'Dim textoOriginal As String = ""
            'Dim textoModificado As String = ""
            'Dim objDataReader As SqlDataReader
            'Dim IdGrupo As Integer

            'sqlstring = "Insert into Oraciones (Oracion, TextoPlano, Traduccion, GrupoO)"
            'sqlstring = sqlstring & " Values (@Oracion, @TextoPlano, @Traduccion, @GrupoO)"

            '_comando.CommandText = sqlstring


            'IdGrupo = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

            '_comando.Parameters.AddWithValue("@Oracion", dgvOraciones.CurrentRow.Cells(1).Value.ToString())
            '_comando.Parameters.AddWithValue("@TextoPlano", dgvOraciones.CurrentRow.Cells(1).Value.ToString())
            '_comando.Parameters.AddWithValue("@Traduccion", dgvOraciones.CurrentRow.Cells(2).Value.ToString())
            '_comando.Parameters.AddWithValue("@GrupoO", IdGrupo)


            'i = _comando.ExecuteNonQuery

            'If i > 0 Then
            '    SQL = "SELECT @@IDENTITY FROM Oraciones"

            '    _comando = New SqlCommand(SQL, _comando.Connection)

            '    Dim value As Object = _comando.ExecuteScalar

            '    IdOracion = value.ToString
            'End If

            'End If

            Dim filename As String = ""
            Dim FileToMove As String = ""
            Dim MoveLocation As String = ""
            Dim AlternativeLocation As String = ""

            FileToMove = "C:\Legacy\Ingles\Audios\SinDefinir\" & ListView1.SelectedItems.Item(0).SubItems(2).Text
            MoveLocation = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"


            Try

                If File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3") Then
                    ' El archivo existe 
                    'MsgBox("El archivo ya existe")

                    resp = MsgBox("Reemplazar audio?", MsgBoxStyle.YesNo)

                    If resp = 6 Then
                        'Si lo reemplaza
                        AlternativeLocation = "C:\Legacy\Ingles\Audios\Alternativo\" & IdOracion & ".mp3"
                        If File.Exists(AlternativeLocation) Then
                            'busca Alternativo 2
                            AlternativeLocation = "C:\Legacy\Ingles\Audios\Alternativo_2\" & IdOracion & ".mp3"

                            If File.Exists("C:\Legacy\Ingles\Audios\Alternativo_2\" & IdOracion & ".mp3") Then
                                'busca Alternativo 3
                                If File.Exists("C:\Legacy\Ingles\Audios\Alternativo_3\" & IdOracion & ".mp3") Then

                                Else
                                    AlternativeLocation = "C:\Legacy\Ingles\Audios\Alternativo_3\" & IdOracion & ".mp3"
                                    System.IO.File.Move(MoveLocation, AlternativeLocation)

                                    ' My.Computer.FileSystem.RenameFile(FileToMove, "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3")
                                    System.IO.File.Move(FileToMove, MoveLocation)

                                End If
                            Else

                                System.IO.File.Move(MoveLocation, AlternativeLocation)
                                System.IO.File.Move(FileToMove, MoveLocation) 'Mueve el archivo Sin definir
                               
                            End If
                        Else

                            System.IO.File.Move(MoveLocation, AlternativeLocation)

                            System.IO.File.Move(FileToMove, MoveLocation) 'Mueve el archivo Sin definir

                            'My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", IdOracion & "_2" & ".mp3")
                            'Mueve el archivo existente
                            'My.Computer.FileSystem.RenameFile(FileToMove, IdOracion & ".mp3")
                            ' AlternativeLocation = "C:\Legacy\Ingles\Audios\Alternativo\" & IdOracion & ".mp3"
                        End If

                        'System.IO.File.Move(FileToMove, MoveLocation)
                    Else
                        'Lo mueve a Alternativo
                        AlternativeLocation = "C:\Legacy\Ingles\Audios\Alternativo\" & IdOracion & ".mp3"

                        If File.Exists("C:\Legacy\Ingles\Audios\Alternativo\" & IdOracion & ".mp3") Then
                            'My.Computer.FileSystem.RenameFile(, IdOracion & "_2" & ".mp3")
                            AlternativeLocation = "C:\Legacy\Ingles\Audios\Alternativo_2\" & IdOracion & ".mp3"

                            If File.Exists("C:\Legacy\Ingles\Audios\Alternativo_2\" & IdOracion & ".mp3") Then

                                AlternativeLocation = "C:\Legacy\Ingles\Audios\Alternativo_3\" & IdOracion & ".mp3"

                                If File.Exists("C:\Legacy\Ingles\Audios\Alternativo_3\" & IdOracion & ".mp3") Then

                                Else
                                    System.IO.File.Move(FileToMove, AlternativeLocation)
                                End If
                            Else
                                System.IO.File.Move(FileToMove, AlternativeLocation)

                            End If

                            'MoveLocation = "C:\Legacy\Ingles\Audios\Alternativo\" & IdOracion & ".mp3"
                            ' System.IO.File.Move(FileToMove, MoveLocation)
                            'My.Computer.FileSystem.RenameFile(MoveLocation, IdOracion & ".mp3")
                        Else
                            If Not File.Exists("C:\Legacy\Ingles\Audios\Alternativo_2\" & IdOracion & ".mp3") Then
                                AlternativeLocation = "C:\Legacy\Ingles\Audios\Alternativo_2\" & IdOracion & ".mp3"
                                ' My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\Alternativo_2\" & IdOracion & ".mp3", IdOracion & ".mp3")
                                System.IO.File.Move(FileToMove, AlternativeLocation)
                            End If
                        End If
                        'System.IO.File.Move(FileToMove, MoveLocation)

                    End If
                Else 'No existe el archivo en \Audios\

                    System.IO.File.Move(FileToMove, MoveLocation)

                    '  My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Alternativo\" & IdOracion & ".mp3", IdOracion & "_3" & ".mp3")


                    'Actualiza en Dialogos

                    Dim sqlstring As String
                    sqlstring = "Update Oraciones SET Audio='S'"
                    sqlstring = sqlstring & "  WHERE Id = '" & IdOracion & "'"
                    _comando.CommandText = sqlstring
                    Try
                        j = _comando.ExecuteNonQuery
                    Catch ex As Exception
                    End Try


                    dgvOraciones.CurrentRow.Cells(0).Value = IdOracion
                End If



                '            // Assuming 'myListView' is your ListView control
                'foreach (ListViewItem item in myListView.SelectedItems)
                '{
                '    myListView.Items.Remove(item);
                '}
                'ListBox1.Items.Remove(ListBox1.SelectedItem)
                ListView1.Items.Remove(ListView1.SelectedItems.Item(0))
            Catch ex As Exception

            End Try

            ' CargarDatos(" AND Audio ='N'")

            txtBuscar.Text = ""

        End If

        lblCuenta.Text = ListView1.Items.Count

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
       
        CargarArchivos()

    End Sub

    Private Sub cmdTexto_Click(sender As System.Object, e As System.EventArgs) Handles cmdTexto.Click
        Dim frm As New frmTextoToDgv
        ' Dim datos As DataTable
        AddOwnedForm(frm)

        frm.ShowDialog()

        ' datos = frmTextoToDgv.Mitabla()

        dgvOraciones.DataSource = dt
        

        Try
            ' dgvOraciones.Columns(0).Visible = False
            maxColumna = dt.Columns.Count

            dgvOraciones.Columns(1).Width = 300
            dgvOraciones.Columns(2).Width = 150
            dgvOraciones.Columns(3).Width = 150
            dgvOraciones.Columns(4).Width = 60

        Catch ex As Exception

        End Try
        _comando.Connection.Close()
        _comando.Connection.Open()

    End Sub

    Private Sub cmdEliminar_Click(sender As System.Object, e As System.EventArgs) Handles cmdEliminar.Click
        Dim resp As Integer

        'resp = MsgBox("Eliminar archivo?", MsgBoxStyle.YesNo)

        'If resp = 6 Then
        'Dim rutaCarpeta As String = "C:\Legacy\Ingles\audios\SinDefinir\" ' Define la ruta de la carpeta

        ' Reemplaza "c:\ruta\al\tu\archivo.txt" con la ruta real
        'System.IO.File.Delete(rutaCarpeta & ListView1.SelectedItems.Item(0).SubItems(2).Text)
        ListView1.Items.Remove(ListView1.SelectedItems.Item(0))

        'End If

        ' CargarArchivos()
        'lblCuenta.Text = ListView1.Items.Count

    End Sub


    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged

        'AxWindowsMediaPlayer1.URL = ListBox1.GetItemText(ListBox1.SelectedItem)
        Dim ruta As String = ""
        ruta = "C:\Legacy\Ingles\audios\SinDefinir\"

        'If cmdPlay.Text = "Play" Then
        '    'Play
        '    cmdPlay.Text = "Stop"
        '    cmdPlay.Refresh()

        '    Player.controls.currentPosition = 10
        '    Player.controls.play()

        'Else
        '    'Stop
        '    cmdPlay.Text = "Play"
        '    Player.controls.stop()

        'End If


        'Player.settings.rate = rate
        ''  Player.URL = ruta & "AndiesJob.mp3"

        'If Not ListView1.SelectedItems.Item(0).Text = "" Then
        '    Player.URL = ruta & ListView1.SelectedItems.Item(0).Text
        'End If

        If ListView1.SelectedItems.Count > 0 Then
            Player.URL = ruta & ListView1.SelectedItems.Item(0).SubItems(2).Text
            Player.controls.play()
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim frm As New frmTextoToDgv
        ' Dim datos As DataTable
        AddOwnedForm(frm)
        frm.tipo = "Faltantes"
        frm.ShowDialog()

        ' datos = frmTextoToDgv.Mitabla()

        dgvOraciones.DataSource = dt
        maxColumna = dt.Columns.Count

        Try
            ' dgvOraciones.Columns(0).Visible = False

            dgvOraciones.Columns(1).Width = 300
            dgvOraciones.Columns(2).Width = 150
            dgvOraciones.Columns(3).Width = 150
            dgvOraciones.Columns(4).Width = 60
            dgvOraciones.Columns(5).Width = 60

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
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
        Dim IdDet As Integer
        Dim descripcion As String

        Dim r As Integer, c As Integer

        Dim Enc_Id As Integer
        Dim OracionId As Integer

        sqlstring = ""
        descripcion = InputBox("Ingrese Descripcion")
        If descripcion = "" Then Exit Sub

        _comando.Connection.Open()

        If Enc_Id = 0 Then
            Enc_Id = frmNewConversation.GuardarConversation(descripcion, "N")
        End If

        Dim t As Integer

        For r = 0 To dgvOraciones.RowCount - 1 ' Exclude the potential new row in DataGridView


            If t = 0 Then
                OracionId = dgvOraciones(0, r).Value.ToString()

                'Detalle conversation
                sqlstring = "INSERT INTO det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
                sqlstring = sqlstring & " Values ('" & OracionId & "', '" & j & "', '" & Enc_Id & "', '0')"
                _comando.CommandText = sqlstring

                Try
                    i = _comando.ExecuteNonQuery
                Catch ex As Exception
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

            End If


            'Inserta Dialogo
            For t = 0 To 1

                OracionId = dgvOraciones(0, r).Value.ToString()

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

                r += 1

            Next

            t = 0


            j = j + 1

        Next
        _comando.Connection.Close()

        MessageBox.Show("Completed !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New frmEscenas

        AddOwnedForm(frm)

        frm.Id = Enc_Id
        frm.lblTitulo.Text = descripcion
        frm.CargarConversation(Id)
        frm.Show()


        txtBuscar.Text = ""

         
    End Sub
End Class