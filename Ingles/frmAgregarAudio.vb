Imports System.Data
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports WMPLib
Imports System.IO

    Public Class frmAgregarAudio

    Public sqlstring As String

    Public Shared IdEnc As Integer
    Public SubtemaId As Integer

    Public consulta As String
    Dim rowcount As Integer
    Public filtro As String
    Public MaxColumna As Integer
   
    Dim SelectedId As Integer
    Dim dt As New DataTable
    Dim da As New SqlDataAdapter
    Public IdEst As Integer
    Public Estructura As String
    Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer
    Public Id As Integer
    Public Oracion As String
    Private Sub frmAgregarAudio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        txtOracion.Text = Oracion
        txtId.Text = Id

    End Sub
        Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click

            Try

                Dim frm As FrmDetOracion = CType(Owner, FrmDetOracion)

                frm.CargarDatos(frm.Id)

                Me.Close()
                Me.Dispose()
            Catch ex As Exception

                Me.Close()
                Me.Dispose()
                Exit Sub

            End Try

        End Sub

        Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim buscar As String
        Dim sqlstring As String = ""
        Dim i, n As Integer
            
            buscar = Trim(Me.txtBuscar.Text)

            If Len(buscar) < 1 Then Exit Sub
         

        filtro = "select Oraciones.Id, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.GrupoO, Grupos_oracion.Grupo, "
        filtro = filtro & "Oraciones.Audio"
            filtro = filtro & " FROM            Oraciones INNER JOIN  Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"

            filtro = filtro & " Where TextoPlano LIKE '%' + @TextoPlano + '%'"
            filtro = filtro & " ORDER BY Oraciones.TextoPlano ASC"

            Try
                _comando.CommandText = filtro

                _comando.Connection.Open()
                _comando.Parameters.AddWithValue("@TextoPlano", buscar)

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

            MaxColumna = dt.Columns.Count

            Try
                dgvOraciones.Columns(0).Visible = False

            dgvOraciones.Columns(1).Width = 300
            dgvOraciones.Columns(2).Width = 300
            dgvOraciones.Columns(3).Width = 300
            dgvOraciones.Columns(4).Width = 50

            'dgvOraciones.Columns(5).Visible = False
            'dgvOraciones.Columns(6).Visible = False
            'dgvOraciones.Columns(7).Visible = False

                ' dgvOraciones.Columns(3).Visible = False
                '  dgvOraciones.Columns(4).Visible = False
                'dgvOraciones.Columns(5).Visible = False
                'dgvOraciones.Columns(6).Visible = False
            Catch ex As Exception

            End Try



            'For Each rw As DataGridViewRow I
        End Sub

    Private Sub dgvOraciones_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOraciones.CellContentClick

    End Sub

    Private Sub dgvOraciones_Click(sender As Object, e As System.EventArgs) Handles dgvOraciones.Click

       
    End Sub

    Private Sub dgvOraciones_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvOraciones.MouseClick
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim resp As Integer
        Dim IdOracion As Integer
        Dim j As Integer

        If e.Button = System.Windows.Forms.MouseButtons.Right Then

            Dim i As Integer
            Dim filename As String = ""
            Dim FileToMove As String = ""
            Dim Location As String = ""
            Dim archivoOrigen As String = ""
            Dim archivoDestino As String = ""
            Dim AlternativeLocation As String = ""

            If cmdPlay.Text = "Stop" Then
                MsgBox("Archivo en uso")
                Exit Sub
            End If
            'Audio en Lista
            IdOracion = dgvOraciones.CurrentRow.Cells(0).Value.ToString()

            archivoOrigen = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"
            archivoDestino = "C:\Legacy\Ingles\Audios\" & Id & ".mp3"

            FileToMove = "C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3"
            Location = "C:\Legacy\Ingles\Audios\" & Id & ".mp3"
            AlternativeLocation = "C:\Legacy\Ingles\Audios\Alternativo\" & Id & ".mp3"
            Try
                ' El archivo existe 
                If File.Exists(archivoDestino) Then

                    resp = MsgBox("¿Reemplazar audio?", MsgBoxStyle.YesNo)

                    If resp = 6 Then
                        'Si lo reemplaza
                        

                        If File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3") Then

                            If File.Exists(archivoDestino) Then
                                'Mueve a Carpeta Alternativo
                                System.IO.File.Move(Location, AlternativeLocation)
                                'My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", IdOracion & "_3" & ".mp3")
                                My.Computer.FileSystem.CopyFile(archivoOrigen, "C:\Legacy\Ingles\Audios\" & Id & ".mp3", True)
                            End If

                            ' File.Copy(archivoOrigen, "C:\Legacy\Ingles\Audios\" & Id & ".mp3", True)

                            'If Not File.Exists("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3") Then
                            '    My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", IdOracion & "_2" & ".mp3")
                            'Else

                            'End If
                        Else
                            'My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Audios\" & IdOracion & ".mp3", IdOracion & "_2" & ".mp3")
                            'Mueve el archivo existente
                            'My.Computer.FileSystem.RenameFile(FileToMove, IdOracion & ".mp3")
                            AlternativeLocation = "C:\Legacy\Ingles\Audios\Alternativo\" & IdOracion & ".mp3"
                            System.IO.File.Move(Location, AlternativeLocation)

                            'Mueve el archivo Sin definir
                            System.IO.File.Move(FileToMove, Location)

                        End If

                        'System.IO.File.Move(FileToMove, MoveLocation)
                    Else
                        '                    My.Computer.FileSystem.CopyFile(
                        '"C:\UserFiles\TestFiles\testFile.txt",
                        '"C:\UserFiles\TestFiles2\testFile.txt")


                        'Lo mueve a Alternativo
                        If Not File.Exists("C:\Legacy\Ingles\Audios\Alternativo\" & IdOracion & ".mp3") Then
                            'My.Computer.FileSystem.RenameFile(, IdOracion & "_2" & ".mp3")
                            Location = "C:\Legacy\Ingles\Audios\Alternativo\" & IdOracion & ".mp3"
                            System.IO.File.Move(FileToMove, Location)
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
                Else 'No existe el archivo en la carpeta \Audios

                    ' System.IO.File.Move(FileToMove, Location)
                    File.Copy(archivoOrigen, archivoDestino, True)

                    '  My.Computer.FileSystem.RenameFile("C:\Legacy\Ingles\Alternativo\" & IdOracion & ".mp3", IdOracion & "_3" & ".mp3")


                    'Actualiza en Dialogos
                    _comando.Connection.Open()
                    Dim sqlstring As String
                    sqlstring = "Update Oraciones SET Audio='S'"
                    sqlstring = sqlstring & "  WHERE Id = '" & Id & "'"
                    _comando.CommandText = sqlstring
                    Try
                        j = _comando.ExecuteNonQuery
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    _comando.Connection.Close()


                    'dgvOraciones.CurrentRow.Cells(0).Value = IdOracion
                End If


            Catch ex As Exception

            End Try

            txtBuscar.Text = ""

        End If

    End Sub


    Private Sub cmdAgregar_Click(sender As System.Object, e As System.EventArgs) Handles cmdAgregar.Click

    End Sub

    Private Sub cmdPlay_Click(sender As System.Object, e As System.EventArgs) Handles cmdPlay.Click
        Try

            If cmdPlay.Text = "Play" Then
                cmdPlay.Text = "Stop"
                Player.URL = "C:\Legacy\Ingles\Audios\" & dgvOraciones.CurrentRow.Cells(0).Value.ToString() & ".mp3"
                ' Player.controls.play()
            Else
                cmdPlay.Text = "Play"
                Player.controls.stop()
                Player.close()
                Player = Nothing
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class