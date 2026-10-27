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

Imports WMPLib

Public Class frmItemAudio
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

    Public speechRate As Integer = -1 ' Rango desde -10 hasta 10 
    Public volume As Integer = 80 ' Rango desde 0 hasta 100.

    Dim objtextCurrent As Label
    Dim objtextOver As Label

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
    'Private Player As New SoundPlayer
    'Private Player2 As New SoundPlayer
    Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer

    Private Sub cmdPlay_Click(sender As System.Object, e As System.EventArgs)

        If cmdPlay.Text = "Play" Then
            'Play
            cmdPlay.Text = "Stop"
            'C:\legacy\audios
            'Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer
            Dim ruta As String
            'ruta = "C:\legacy\Audios\spirit.mp3"

            Dim SongLocation = Path.Combine(Application.StartupPath, ruta)
            SongLocation = "C:\legacy\Ingles\audios\AndiesJob.mp3"
            Player.URL = SongLocation
            Player.controls.play()
            Player.controls.currentPosition = 0.1
        Else
            'Stop
            cmdPlay.Text = "Play"
            Player.controls.stop()

        End If



    End Sub

   
    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
        Me.Dispose()

    End Sub

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
       
        Dim param As String = ""
        Dim i, n As Integer

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String = ""
 
        sqlstring = " SELECT   Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Oraciones.TextoPlano, Det_Person, Det_Par, Oraciones.traduccion, Oraciones.STL, Oraciones.Exam"
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

        If n = 0 Then Exit Sub

        i = 0

        pEtapa.Controls.Clear()
         
        Dim item As ListViewItem 'Creo el ListViewItem (item) 
         
        Dim List As New List(Of String)

        pEtapa.AutoScroll = True

        Dim person1 As Integer
        Dim person2 As Integer

        Dim p As PictureBox
        Dim bmp As Bitmap
        Dim g As Graphics
        Dim Aprendidos As Integer
        Dim nm As String
        ' n = 1
        For i = 0 To n - 1

            Try

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

                'Texto en ingles

                txtNombre = New Label
                txtNombre.Name = "txt_" & dt.Rows(i).Item(0)
                ' txtNombre.Name = "txt0"
                'txtNombre.HideSelection = False
                txtNombre.Text = dt.Rows(i).Item(4) '& " " & dt.Rows(i).Item(1) '& vbCrLf & vbCrLf & dt.Rows(i).Item(3)
                txtNombre.BorderStyle = BorderStyle.None
                txtNombre.Font = New System.Drawing.Font("Consolas", 11, FontStyle.Regular)
                '  txtNombre.Visible = False

                If dt.Rows(i).Item(1) = IdOracion Then
                    txtNombre.Font = New System.Drawing.Font("Arial", 11, FontStyle.Bold)
                    txtNombre.ForeColor = Color.Blue
                End If

                txtNombre.AutoSize = True
                ' txtNombre.Width = 500
                txtNombre.Location = New Point(75, 5)
                '   txtNombre.BackColor = Color.LightGray
                txtNombre.Height = txtNombre.PreferredHeight
                AddHandler txtNombre.Click, AddressOf RefreshTexto

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtNombre)

                ' txtNombre.MaximumSize = New Size(txtNombre.Width, 0)
                ' txtNombre.TextAlign = ContentAlignment.MiddleLeft

                ''Texto en español Traduccion
                If Not IsDBNull(dt.Rows(i).Item(7)) Then
                    txtMinutos = New Label
                    txtMinutos.Name = "tra_" & dt.Rows(i).Item(0)
                    ' txtMinutos.Text = Format(dt.Rows(i).Item(7), "dd/MMM hh:mm tt") & " Time Worked: " & dt.Rows(i).Item(13) & " min " '& vbCrLf & vbCrLf & dt.Rows(i).Item(3)
                    txtMinutos.Text = dt.Rows(i).Item(7)
                    txtMinutos.BorderStyle = BorderStyle.None
                    txtMinutos.Font = New System.Drawing.Font("Arial", 9, FontStyle.Regular)
                    txtMinutos.ForeColor = Color.DimGray
                    txtMinutos.AutoSize = True
                    ' txtNombre.Width = 150
                    '   txtNombre.BackColor = Color.LightGray
                    ' txtMinutos.Location = New Point(45, 10)
                    txtMinutos.Location = New Point(75, txtNombre.Bottom + 5)
                    ' txtMinutos.Location = New Point(45, txtNombre.Bottom + 10)
                    ' txtNombre.MaximumSize = New Size(txtNombre.Width, 0)
                    txtMinutos.Height = txtNombre.PreferredHeight
                    ' txtNombre.TextAlign = ContentAlignment.MiddleLeft
                    'txtMinutos.Visible = False
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
                '  btnLeer.Image = ImageList1.Images.Item(0)

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

                If dt.Rows(i).Item(8) = False Then
                    btnStatus.Text = "NO"
                    btnStatus.BackColor = Color.LightSalmon
                Else
                    btnStatus.Text = "SI"
                    btnStatus.BackColor = Color.LightGreen
                End If

                AddHandler btnStatus.Click, AddressOf StatusControl
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnStatus)


                'Evaluacion
                txtTest = New TextBox
                txtTest.Name = "tst_" & dt.Rows(i).Item(0)
                If Not IsDBNull(dt.Rows(i).Item(9)) Then
                    txtTest.Text = dt.Rows(i).Item(9)
                End If

                txtTest.BorderStyle = BorderStyle.None
                txtTest.Font = New System.Drawing.Font("arial", 10, FontStyle.Bold)

                '  txtTest.AutoSize = True
                txtTest.Width = 1000
                txtTest.Location = New Point(75, txtMinutos.Bottom + 5)

                If dt.Rows(i).Item(8) = True Then
                    txtNombre.BackColor = Color.LightGreen
                    Aprendidos += 1
                Else
                    txtNombre.BackColor = Color.LightSalmon

                End If
                txtTest.BackColor = Color.Beige

                'txtTest.Height = txtTest.PreferredHeight
                AddHandler txtTest.LostFocus, AddressOf Exam

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTest)

                'Guardar Test
                btnExam = New Button
                btnExam.Name = "btnStatus_" & dt.Rows(i).Item(0)
                btnExam.Width = 50 : btnExam.Height = 25
                btnExam.Location = New Point(txtTest.Right + 5, txtMinutos.Bottom + 5)
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


            Catch ex As Exception

            End Try


            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.UseItemStyleForSubItems = False

            Try

                item.SubItems.Add(dt.Rows(i).Item(4))
                item.SubItems.Add(dt.Rows(i).Item(0))

                ' ListView1.Items.Add(item)


            Catch ex As Exception

            End Try

            yPos = yPos + 80

        Next i

        ' txtAvance.Text = Math.Round(Aprendidos / n, 1) * 100 & " %"

        GuardarAvance(n, Aprendidos)

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
        Dim avance As Integer

        _comando.Connection.Open()

        _comando.Parameters.Clear()

        sqlstring = "UPDATE Enc_Conversation SET Con_Cant = @Con_Cant, Con_aprendidos = @Con_aprendidos, Con_avance = @Con_avance"
        sqlstring = sqlstring & " WHERE Con_Id = @Con_Id"

        _comando.Parameters.AddWithValue("@Con_Cant", n)
        _comando.Parameters.AddWithValue("@Con_aprendidos", a)
        Try
            avance = (a / n) * 100
        Catch ex As Exception

        End Try
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


        ' n = ListView1.Items.Count

        If indice = -1 Then Exit Sub


        'itemCurr = ListView1.Items(indice)


        '  If indice = ListView1.Items.Count - 1 Then

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
        '    _comando.Parameters.AddWithValue("@Det_Con", r.SubItems(2).Text)


        '    _comando.CommandText = sqlstring


        '    i = _comando.ExecuteNonQuery


        'Next
        '_comando.Connection.Close()

        'If i > 0 Then
        'Else
        '    MsgBox("No se actualizo")
        'End If
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


        '_comando.Connection.Open()


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



        '    Try
        '        _comando.CommandText = sqlstring

        '        i = _comando.ExecuteNonQuery


        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    Finally

        '    End Try


        '  Next


        'If i > 0 Then
        '    MsgBox("se guardo")
        'Else
        '    MsgBox("No se guardo")
        'End If

        '  CrearControles()







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

            ''i = _comando.ExecuteNonQuery
            'da.SelectCommand = _comando

            'da.Fill(dt)


        Catch ex As Exception

        End Try

        Try
            'i = _comando.ExecuteNonQuery
            objDataReader = _comando.ExecuteReader


            If objDataReader.HasRows Then

                objDataReader.Read()
                '  Console.WriteLine(objDataReader(0))
                '  Console.WriteLine(objDataReader(1))

                IdOracionItem = objDataReader(1)

            End If

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
        'If cmbPersona.Text = "" Then Exit Sub

        'IdPerson = cmbPersona.SelectedIndex

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

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
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
                MsgBox("se guardo")


            Else

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

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()



        Dim Exam As String
        Exam = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txt_" & IdDet).Text

        Try

            If sender.text = "NO" Then
                Status = True
                sender.backcolor = Color.LightGreen
                sender.text = "SI"
                pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txt_" & IdDet).BackColor = Color.LightGreen

            Else
                Status = False
                sender.backcolor = Color.LightSalmon
                sender.text = "NO"
                pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txt_" & IdDet).BackColor = Color.LightSalmon

            End If



            sqlstring = "UPDATE Oraciones SET STL = @STL"
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.Parameters.AddWithValue("@Id", IdOracionItem)
            _comando.Parameters.AddWithValue("@STL", Status)


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
            objtextCurrent = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("txt_" & nm)
            ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
            objtextCurrent.Font = New Font("Consolas", 11, FontStyle.Bold)

            objtextOver = objtextCurrent

            ' Dim pVoice As ISpVoice = CType(voice, ISpVoice)
            Dim otc As SpObjectTokenCategory = New SpObjectTokenCategory()
            otc.SetId("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices")

            Dim tokenEnum As ISpeechObjectTokens = otc.EnumerateTokens()
            Dim nTokenCount As Integer = tokenEnum.Count

            '  Console.WriteLine("Number of voices: {0}", nTokenCount)
            Dim n As UInteger = 0
            ' Dim pVoice As ISpVoice = CType(voice, ISpVoice)

            '  Dim pVoice As ISpVoice = CType(speech, ISpVoice)

            For Each sot As ISpeechObjectToken In tokenEnum
                Console.WriteLine("Voice : {0}", sot.GetDescription())
            Next

            ' pVoice.SetVoice(CType(sot, ISpObjectToken))
            ' pVoice.SetVoice(CType(tokenEnum(_voice), ISpObjectToken))
            ' pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))
            ' pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))
            ' speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(voice)
            ' speech.SetVoice(CType(tokenEnum(0), ISpObjectToken))

            ' AddHandler voice.EndStream, AddressOf speakComplete

            Try
                'pVoice.Speak(objtextCurrent.Text, 0, n)

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
            ' bandstop = False
        Else
            cmdStop.Text = "Stop"
            ' bandstop = True
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

        'speaker.Rate = speechRate
        ' speaker.Volume = volume


        For Each c In pEtapa.Controls

            If cmdStop.Text = "Stop" Then
                Exit Sub
            End If

Pregunta:
            ' If bandComplete = False Then

            '  bandComplete = True

            nm = c.name

            str = nm.Split("_")

            tp = str(0)

            ' Console.WriteLine(c.name)
            ' Console.WriteLine()
            '    'objtextCurr = pEtapa.Controls.Item("pAux" & nm).Controls.Item("txt" & nm)
            ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")

            ' "btnLeer_"
            ' objtextCurrent = pEtapa.Controls(c.name).Controls.Item("txt_" & str(1))
            ' objtextCurrent.Font = New Font("Consolas", 11, FontStyle.Bold)
            ' objtextCurrent.BackColor = Color.Yellow
            'objtextCurrent.Visible = True
            'objtextCurrent.Refresh()

            pEtapa.Controls(c.name).Controls.Item(str(1)).BackColor = Color.Yellow
            pEtapa.Controls(c.name).Controls.Item(str(1)).Refresh()

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
            pic = pEtapa.Controls(c.name).Controls.Item("p_" & str(1))

            ' person = pic.Image
            'speech.WaitUntilDone(-1)


            ' If (paused) = True Then
            ' speech.Resume()
            ' paused = True

            'LeerItem(objtextCurrent, pic.Tag)

            ' Else


            ' wait(2) 'Regresa a preguntar
            ' GoTo Pregunta


            ' End If

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
                    pVoice.Speak(objtextCurrent.Text, 0, n)

                Catch ex As Exception

                End Try



                'pVoice.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync, 0)

                'voice.GetVoices(CType(tokenEnum(person), ISpObjectToken)).Item(5)
                'speech.SetVoice(CType(tokenEnum(4), ISpObjectToken))

                ' voice.Speak(objtextCurr.Text, 0, 0)
                ' voice.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)


                ' speech.Speak(objtextCurr.Text, 0, 0)
                'For Each v In speaker.GetInstalledVoices
                '    Console.WriteLine(v.VoiceInfo.Name)
                'Next
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

#End Region

    Private Sub frmItemAudio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        CrearControles()

    End Sub

    Private Sub cmdPlay_Click_1(sender As System.Object, e As System.EventArgs) Handles cmdPlay.Click

    End Sub
End Class