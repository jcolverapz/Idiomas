Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports RichTextBoxEx
Imports System.IO
Imports SpeechLib
Public Class frmTexto

    Public Con_Id As Integer
    Public descripcion As String

    Private Sub frmTexto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lstOraciones.View = View.Details ' Set the view to show details.
        lstOraciones.LabelEdit = False ' Allow the user to edit item text.
        lstOraciones.AllowColumnReorder = True ' Allow the user to rearrange columns.
        lstOraciones.FullRowSelect = True
        lstOraciones.GridLines = True
        ' lstOraciones.TileSize = New Size(500, 40)
        ' lstOraciones.Dock = DockStyle.Fill
        lstOraciones.ShowItemToolTips = True

        lstOraciones.HeaderStyle = ColumnHeaderStyle.None

        txtId.Text = Con_Id

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
         
        Do While i <= n - 1
            Me.cboGrupo.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
            i = i + 1
        Loop
    End Sub

    Private Sub cmdSplit_Click(sender As System.Object, e As System.EventArgs) Handles cmdSplit.Click
        Dim parameters() As String

        parameters = Split(txtTexto.Text, vbCrLf)

        Dim parameters2() As String
        Dim parameters3() As String

        lstOraciones.Items.Clear()

        Dim i As Integer

        i = 0

        For Each p In parameters

            Dim item As ListViewItem 'Creo el ListViewItem (item) 

            'parameters2 = Split(p, ".")
            ' For Each p2 In parameters2
            If Trim(p) <> "" Then

                parameters3 = Split(p, "-")

                item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

                item.UseItemStyleForSubItems = False

                Try
                    'item.SubItems.Add(dt.Rows(i).Item(0))
                    item.SubItems.Add(Trim(parameters3(0)))
                    item.SubItems.Add(Trim(parameters3(1)))
                    'item.SubItems(0).ForeColor = Color.Blue
                    lstOraciones.Items.Add(item)

                    i = i + 1
                Catch ex As Exception

                End Try
            End If

            'Next


        Next
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
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

        sqlstring = ""

        descripcion = txtDescripcion.Text

        If descripcion = "" Then Exit Sub

        Dim GrupoId As Integer

        If cboGrupo.SelectedIndex = -1 Then Exit Sub
        GrupoId = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

        If Con_Id = 0 Then
            Con_Id = frmNewConversation.GuardarConversation(descripcion, "N")
        End If
       
        _comando.Connection.Open()
       
        For Each r In lstOraciones.Items

            OracionEN = r.subitems(1).text
            OracionES = r.subitems(2).text

            'textoOriginal = dt.Rows(i).Item(1)
            _comando.Parameters.Clear()

            textoModificado = Trim(OracionEN.Replace("?", "")) ' Reemplaza el símbolo de ? por ""

            'buscar en Conversaciones
            If ModVar.Idioma = "EN" Then
                sqlstring = " SELECT Id, TextoPlano, Traduccion  FROM Oraciones"
            Else
                sqlstring = " SELECT Id, TextoPlano, Traduccion  FROM Oraciones_FR"
            End If

            'sqlstring = " SELECT Id, TextoPlano, Traduccion  FROM Oraciones"

            sqlstring = sqlstring & " Where TextoPlano = '@TextoPlano' "

            sqlstring = sqlstring & " ORDER BY TextoPlano ASC"

            _comando.CommandText = sqlstring
            _comando.Parameters.AddWithValue("@TextoPlano", textoModificado)

            Try
                objDataReader = _comando.ExecuteReader

                If objDataReader.HasRows Then
                    objDataReader.Read()
                    IdOracion = objDataReader(0)

                Else
                    'Si no existe
                    'Grupo Sin definiir Id 1050

                    objDataReader.Close()

                    _comando.Parameters.Clear()
                    
                    If ModVar.Idioma = "EN" Then
                        sqlstring = "Insert into Oraciones (Oracion, TextoPlano, Traduccion, GrupoO)"
                    Else
                        sqlstring = "Insert into Oraciones_FR (Oracion, TextoPlano, Traduccion, GrupoO)"

                    End If
                    sqlstring = sqlstring & " Values (@Oracion, @TextoPlano, @Traduccion, @GrupoO)"
                    _comando.CommandText = sqlstring

                    _comando.Parameters.AddWithValue("@Oracion", OracionEN)
                    _comando.Parameters.AddWithValue("@TextoPlano", OracionEN)
                    _comando.Parameters.AddWithValue("@Traduccion", OracionES)
                    _comando.Parameters.AddWithValue("@GrupoO", GrupoId)

                    Try
                        i = _comando.ExecuteNonQuery

                        If i > 0 Then
                            If ModVar.Idioma = "EN" Then
                                SQL = "SELECT @@IDENTITY FROM Oraciones"
                            Else
                                SQL = "SELECT @@IDENTITY FROM Oraciones_FR"

                            End If

                            _comando = New SqlCommand(SQL, _comando.Connection)

                            Dim value As Object = _comando.ExecuteScalar

                            IdOracion = value.ToString
                        End If
                       
                    Catch ex As Exception
                    End Try

                End If

            Catch ex As Exception
            End Try

            objDataReader.Close()

            'Detalle conversation
            sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
            sqlstring = sqlstring & " Values ('" & IdOracion & "', '" & j & "', '" & Con_Id & "', '0')"
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

            'Inserta Dialogo
             
            sqlstring = "Insert into Dialogos (OracionId, Orden, DetConversacion)"
            sqlstring = sqlstring & " Values ('" & IdOracion & "', @Orden, '" & IdDet & "')"
            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Orden", 0)

                Try

                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
            Finally

            End Try
             

            j = j + 1

        Next
        _comando.Connection.Close()

        MessageBox.Show("Completed !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New FrmConversation

        AddOwnedForm(frm)

        frm.Id = Con_Id
        frm.lblTitulo.Text = descripcion
        frm.CargarConversation(Id)
        frm.Show()


        'Agrega a Conversacion

        'Dim IdOracion As Integer
        'Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
        'Dim i As Integer




    End Sub

    Private Sub cmdGuardarOraciones_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupo.SelectedIndexChanged

    End Sub
End Class