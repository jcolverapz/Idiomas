Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports RichTextBoxEx
Imports System.IO
Imports SpeechLib

Public Class frmTextoToDgv

    Public Con_Id As Integer
    Public Det_Id As Integer
    Public descripcion As String
    Public Tipo As String

    Dim dt As New DataTable

    Private Sub frmTextoToDgv_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'lstOraciones.View = View.Details ' Set the view to show details.
        'lstOraciones.LabelEdit = False ' Allow the user to edit item text.
        'lstOraciones.AllowColumnReorder = True ' Allow the user to rearrange columns.
        'lstOraciones.FullRowSelect = True
        'lstOraciones.GridLines = True
        '' lstOraciones.TileSize = New Size(500, 40)
        '' lstOraciones.Dock = DockStyle.Fill
        'lstOraciones.ShowItemToolTips = True

        'lstOraciones.HeaderStyle = ColumnHeaderStyle.None

        txtId.Text = Con_Id
        txtDetId.Text = Det_Id

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

        ListView1.View = View.Details ' Set the view to show details.
        ListView1.LabelEdit = False ' Allow the user to edit item text.
        ListView1.AllowColumnReorder = True ' Allow the user to rearrange columns.
        ListView1.FullRowSelect = True ' Select the item and subitems when selection is made.
        ListView1.GridLines = True ' Display grid lines.

        Dim param As String

        param = " Where Det_Conversation.Con_Id='" & Det_Id & "'"
        CargarDatos(param)

    End Sub

    Private Sub CargarDatos(param)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        sqlstring = " SELECT        Dialogos.Id,  Dialogos.OracionId, Oraciones.TextoPlano, Dialogos.Orden, Det_Conversation.Det_Con"
        '  sqlstring = sqlstring & "  , "
        sqlstring = sqlstring & " FROM            Dialogos INNER JOIN"
        sqlstring = sqlstring & "                 Oraciones ON Dialogos.OracionId = Oraciones.Id INNER JOIN"
        sqlstring = sqlstring & "                Det_Conversation ON Dialogos.DetConversacion = Det_Conversation.Det_Con"
        sqlstring = sqlstring & param
        sqlstring = sqlstring & " ORDER BY Det_Conversation.Det_Orden ASC, Dialogos.Orden ASC"



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

        dgvGeneral.DataSource = dt

        n = dt.Rows.Count
        ' dgvOraciones.Columns(0).Visible = False
        Dim maxColumna As Integer
        maxColumna = dt.Columns.Count

        dgvGeneral.Columns(1).Width = 60
        dgvGeneral.Columns(2).Width = 60
        dgvGeneral.Columns(3).Width = 300
        dgvGeneral.Columns(4).Width = 60
         

    End Sub
    Public Shared Function Mitabla() As DataTable
        Dim dt As New DataTable

        Return dt
    End Function

    Private Sub cmdSplit_Click(sender As System.Object, e As System.EventArgs) Handles cmdSplit.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim parametros() As String
        Dim Traducciones() As String
 
        Dim i As Integer
        Dim sqlstring As String
        Dim IdOracion As Integer

        Dim SQL As String
        Dim IdCon As Integer
        Dim j As Integer
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
        Dim objDataReader As SqlDataReader
        Dim IdDet As Integer
        Dim IdGrupo As Integer

        dt.Rows.Clear()
        dt.Columns.Clear()

        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Texto", GetType(String))
        dt.Columns.Add("Traduccion", GetType(String))
        dt.Columns.Add("Audio", GetType(String))
        dt.Columns.Add("Index", GetType(Integer))

        parametros = Split(txtTexto.Text, vbCrLf)
        Traducciones = Split(txtTraduccion.Text, vbCrLf)

        _comando.Connection.Open()

        For Each p In parametros

            If Trim(p) <> "" Then

                Dim newRow As DataRow = dt.NewRow()

                newRow("Index") = i
                newRow("Texto") = Trim(p)
               
                _comando.Parameters.Clear()

                'buscar en Oraciones
                sqlstring = " SELECT Id, TextoPlano, Traduccion, Audio  FROM Oraciones"
                sqlstring = sqlstring & " Where TextoPlano = @TextoPlano"

                If Tipo = "Faltantes" Then
                    sqlstring = sqlstring & " And Audio = 'N'"
                End If

                _comando.CommandText = sqlstring

                _comando.Parameters.AddWithValue("@TextoPlano", Trim(p))

                Try
                    objDataReader = _comando.ExecuteReader

                    If objDataReader.HasRows Then
                        objDataReader.Read()
                        newRow("ID") = objDataReader(0)
                        newRow("Traduccion") = objDataReader(2)
                        newRow("Audio") = objDataReader(3)
                    Else 'No existe
                       
                        newRow("ID") = 0
                        newRow("Traduccion") = ""
                        newRow("Audio") = ""

                    End If

                    dt.Rows.Add(newRow)

                    i = i + 1

                Catch ex As Exception

                End Try
                objDataReader.Close()

            End If

        Next

        i = 0
        For Each p In Traducciones
            If Trim(p) <> "" Then
                Try
                    dt.Rows(i).Item(2) = Trim(p)
                Catch ex As Exception
                End Try
            End If
            i = i + 1
        Next

        IdGrupo = 6 'Frases basicas

         
        For Each rw In dt.Rows


            If rw.item(0) = 0 Then

                sqlstring = "Insert into Oraciones (TextoPlano, Traduccion, GrupoO)"
                sqlstring = sqlstring & " Values (@TextoPlano, @Traduccion, @GrupoO)"
                _comando.CommandText = sqlstring

                _comando.Parameters.Clear()
                _comando.Parameters.AddWithValue("@TextoPlano", rw.item(1))
                _comando.Parameters.AddWithValue("@Traduccion", "")
                _comando.Parameters.AddWithValue("@GrupoO", IdGrupo)

                j = _comando.ExecuteNonQuery


                If j > 0 Then
                    SQL = "SELECT @@IDENTITY FROM Oraciones"
                    _comando = New SqlCommand(SQL, _comando.Connection)
                    Dim value As Object = _comando.ExecuteScalar
                    IdOracion = value.ToString
                    rw.item(0) = IdOracion

                End If


            End If


        Next



        _comando.Connection.Close()

        dgvGeneral.DataSource = dt

        dgvGeneral.Columns(0).Width = 50
        dgvGeneral.Columns(1).Width = 300
        dgvGeneral.Columns(2).Width = 300

    End Sub


    Private Sub CrearTabla()
        Dim dt As New DataTable
        Dim i As Integer

        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Texto", GetType(String))
        dt.Columns.Add("Traduccion", GetType(String))
        dt.Columns.Add("Audio", GetType(String))
        dt.Columns.Add("Index", GetType(Integer))

        Dim newRow As DataRow = dt.NewRow()
        newRow("Index") = i
        '' newRow("Texto") = Trim(parameters3(0))
        'newRow("ID") = objDataReader(0)
        'newRow("Traduccion") = objDataReader(2)
        'newRow("Audio") = objDataReader(3)

        'newRow("ID") = 0
        'newRow("Traduccion") = Trim(parameters3(1))
        'newRow("Audio") = "N"

        ' objDataReader.Close()



    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
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
        GrupoId = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

        If Con_Id = 0 Then
            Con_Id = frmNewConversation.GuardarConversation(descripcion, "N")
        End If

        _comando.Connection.Open()

        '  For Each r In lstOraciones.Items

        '   OracionEN = r.subitems(1).text
        ' OracionES = r.subitems(2).text

        'textoOriginal = dt.Rows(i).Item(1)
        _comando.Parameters.Clear()

        textoModificado = Trim(OracionEN.Replace("?", "")) ' Reemplaza el símbolo de ? por ""

        'buscar en Conversaciones
        sqlstring = " SELECT Id, TextoPlano, Traduccion  FROM Oraciones"

        sqlstring = sqlstring & " Where TextoPlano = '@TextoPlano' "
        sqlstring = sqlstring & " ORDER BY Oraciones.TextoPlano ASC"

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


                sqlstring = "Insert into Oraciones (Oracion, TextoPlano, Traduccion, GrupoO)"
                sqlstring = sqlstring & " Values (@Oracion, @TextoPlano, @Traduccion, @GrupoO)"
                _comando.CommandText = sqlstring

                _comando.Parameters.AddWithValue("@Oracion", OracionEN)
                _comando.Parameters.AddWithValue("@TextoPlano", OracionEN)
                _comando.Parameters.AddWithValue("@Traduccion", OracionES)
                _comando.Parameters.AddWithValue("@GrupoO", GrupoId)

                Try
                    i = _comando.ExecuteNonQuery

                    If i > 0 Then
                        SQL = "SELECT @@IDENTITY FROM Oraciones"

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

        '  Next
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

    Private Sub cmdOrdenar_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenar.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim parameters() As String

        parameters = Split(txtTexto.Text, vbCrLf)

        Dim parameters2() As String
        Dim parameters3() As String

        '  lstOraciones.Items.Clear()

        Dim i As Integer
        Dim dt As New DataTable

        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Texto", GetType(String))
        dt.Columns.Add("Traduccion", GetType(String))
        dt.Columns.Add("Audio", GetType(String))
        dt.Columns.Add("Index", GetType(Integer))

        i = 0

        'Crear dt
        Dim sqlstring As String
        Dim IdOracion As Integer

        Dim SQL As String
        Dim IdCon As Integer
        Dim j As Integer
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
        Dim objDataReader As SqlDataReader
        Dim IdDet As Integer

        parameters = Split(txtTexto.Text, vbCrLf)

        _comando.Connection.Open()

        For Each p In parameters

            If Trim(p) <> "" Then

                Dim newRow As DataRow = dt.NewRow()
                newRow("Texto") = Trim(p)

                _comando.Parameters.Clear()

                'buscar en Oraciones
                sqlstring = " SELECT Id, TextoPlano, Traduccion, Audio  FROM Oraciones"
                sqlstring = sqlstring & " Where TextoPlano = @TextoPlano"

                If Tipo = "Faltantes" Then
                    sqlstring = sqlstring & " And Audio = 'N'"
                End If

                _comando.CommandText = sqlstring

                _comando.Parameters.AddWithValue("@TextoPlano", Trim(p))
                 
                    objDataReader = _comando.ExecuteReader

                    If objDataReader.HasRows Then
                        objDataReader.Read()
                        newRow("ID") = objDataReader(0)
                        newRow("Traduccion") = objDataReader(2)
                        newRow("Audio") = objDataReader(3)
                    Else
                        newRow("ID") = 0
                    newRow("Traduccion") = Trim(p)
                        newRow("Audio") = "N"
                    End If

                    newRow("Index") = i

                dt.Rows.Add(newRow)
                   
                    objDataReader.Close()
            End If
        Next

        Dim n As Integer
        n = dt.Rows.Count
        '''
        Dim item As ListViewItem 'Creo el ListViewItem (item) 

        Do While i < n
            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.UseItemStyleForSubItems = False

            Try
                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(1))
                item.SubItems.Add(dt.Rows(i).Item(2))
                item.SubItems.Add("0")

                ListView1.Items.Add(item)      'Agrego el item a la colección de listViewItem's de ListView1

                i = i + 1
            Catch ex As Exception
            End Try
        Loop




       

    End Sub

    Private Function DetectChanges(Nombre) As Integer
        Dim item As ListViewItem 'Creo el ListViewItem (item) 
        Dim i As Integer
        Dim Orden As Integer
         
        Dim Indice As Integer
        i = ListView1.Items.Count + 1

        Dim foundItem As ListViewItem

        Try

            foundItem = ListView1.FindItemWithText(Nombre, True, 0, True)

            If (foundItem IsNot Nothing) Then
                Orden = foundItem.Index
            End If


        Catch ex As Exception

        End Try

        Return Orden



    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Ordenar

        Dim Orden As Integer
        Dim r As Integer, c As Integer
        Dim sqlstring As String
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim i As Integer
        _comando.Connection.Open()
        ' Populate table with DataGridView data
        For r = 0 To dgvGeneral.RowCount - 2 ' Exclude the potential new row in DataGridView
             
            Orden = DetectChanges(dgvGeneral(2, r).Value.ToString())
             
                sqlstring = "UPDATE Dialogos SET Orden = @Orden"
                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.CommandText = sqlstring

                _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@Orden", Orden)
            _comando.Parameters.AddWithValue("@Id", dgvGeneral(0, r).Value.ToString())

            dgvGeneral(3, r).Value = Orden
                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                'MsgBox(ex.Message)
                End Try


            Next
        _comando.Connection.Close()

         
    End Sub

    Private Sub cmdExportar_Click(sender As System.Object, e As System.EventArgs) Handles cmdExportar.Click

        frmListAudios.dt = dt
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
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
        Dim IdDet As Integer

        Dim i As Integer

        Dim Id As Integer
        Dim texto As String

        _comando.Connection.Open()

        '---------------        Insertar en Dialogos
      
        Dim IdOracion As Integer

        Dim IdCon As Integer

        Dim objDataReader As SqlDataReader


        pbar.Maximum = dt.Rows.Count

        descripcion = InputBox("Ingrese Descripcion")
        If descripcion = "" Then Exit Sub

        'Inserta Encabezado
        If Enc_Id = 0 Then
            Enc_Id = frmNewConversation.GuardarConversation(descripcion, "Audios")
        End If

        Dim OracionId As Integer
        'Dim titulo As String

        j = 0
        For r = 0 To dt.Rows.Count - 1

            ' Exclude the potential new row in DataGridView


            'OracionId = dgvGeneral(0, r).Value.ToString()

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


            OracionId = dt.Rows(x).Item(0)

            sqlstring = "Insert into Dialogos (OracionId, Orden, DetConversacion)"
            sqlstring = sqlstring & " Values ('" & OracionId & "', @Orden, '" & IdDet & "')"
            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()

            _comando.Parameters.AddWithValue("@Orden", x)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
            End Try

            x += 1

            j = j + 1

            pbar.Value += 1

        Next

        _comando.Connection.Close()

        MessageBox.Show("Completed !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class