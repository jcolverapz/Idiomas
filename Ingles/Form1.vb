Public Class Form1

    Private Sub ConceptosBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        'Me.Validate()
        'Me.ConceptosBindingSource.EndEdit()
        'Me.TableAdapterManager.UpdateAll(Me.InglesDataSet)

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'Grupos.Grupos_Temas' Puede moverla o quitarla según sea necesario.
        'Me.Grupos_TemasTableAdapter.Fill(Me.Grupos.Grupos_Temas)
        'TODO: esta línea de código carga datos en la tabla 'InglesDataSet.Conceptos' Puede moverla o quitarla según sea necesario.
        '  Me.ConceptosTableAdapter.Fill(Me.InglesDataSet.Conceptos)
        CrearDataSet()
    End Sub

    Private dataSetArbol As System.Data.DataSet
    Private Sub CrearDataSet()
        Dim tablaArbol As DataTable

        dataSetArbol = New DataSet("DataSetArbol")

        tablaArbol = dataSetArbol.Tables.Add("TablaArbol")
        tablaArbol.Columns.Add("NombreNodo", GetType(String))
        tablaArbol.Columns.Add("IdentificadorNodo", GetType(Integer))
        tablaArbol.Columns.Add("IdentificadorPadre", GetType(Integer))

        InsertarDataRow("Nodo 1", 1, 0)
        InsertarDataRow("Nodo 1.1", 2, 1)
        InsertarDataRow("Nodo 1.1.1", 3, 2)
        InsertarDataRow("Nodo 1.1.2", 4, 2)
        InsertarDataRow("Nodo 1.2", 5, 1)

        InsertarDataRow("Nodo 2", 6, 0)
        InsertarDataRow("Nodo 2.1", 7, 6)
        InsertarDataRow("Nodo 2.2", 8, 6)

        InsertarDataRow("Nodo 3", 9, 0)
        InsertarDataRow("Nodo 3.1", 10, 9)
        InsertarDataRow("Nodo 3.2", 11, 9)
    End Sub

    Private Sub InsertarDataRow(ByVal column1 As String, ByVal column2 As Integer, ByVal column3 As Integer)
        Dim nuevaFila As DataRow

        nuevaFila = dataSetArbol.Tables("TablaArbol").NewRow()

        nuevaFila("NombreNodo") = column1
        nuevaFila("IdentificadorNodo") = column2
        nuevaFila("IdentificadorPadre") = column3
        dataSetArbol.Tables("TablaArbol").Rows.Add(nuevaFila)
    End Sub
    'Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
    'CrearNodosDelPadre(indicePadre, nodePadre)
    ' End Sub
    Private Sub CrearNodosDelPadre(ByVal indicePadre As Integer, ByVal nodePadre As TreeNode)

        Dim dataViewHijos As DataView

        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(dataSetArbol.Tables("TablaArbol"))

        dataViewHijos.RowFilter = dataSetArbol.Tables("TablaArbol").Columns("IdentificadorPadre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = dataRowCurrent("NombreNodo").ToString().Trim()

            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                'TreeView1.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If

            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            CrearNodosDelPadre(Int32.Parse(dataRowCurrent("IdentificadorNodo").ToString()), nuevoNodo)
        Next dataRowCurrent

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        CrearNodosDelPadre(0, Nothing)
    End Sub

    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
       
        ' Definir el color y el grosor de la flecha
        'Dim pen As New Pen(Color.Blue, 3)

        '' Dibujar la línea de la flecha
        'g.DrawLine(pen, startPoint, endPoint)

        '' Calcular los puntos de la punta de la flecha
        'Dim arrowHeadLength As Integer = 15
        'Dim arrowHeadAngle As Double = 45

        '' Calcular los puntos de la cabeza de la flecha
        'Dim angle = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X)
        'Dim angle1 = angle + Math.PI / 180.0 * arrowHeadAngle
        'Dim angle2 = angle - Math.PI / 180.0 * arrowHeadAngle

        'Dim headPoint1 As Point = New Point(CInt(endPoint.X - arrowHeadLength * Math.Cos(angle1)), CInt(endPoint.Y - arrowHeadLength * Math.Sin(angle1)))
        'Dim headPoint2 As Point = New Point(CInt(endPoint.X - arrowHeadLength * Math.Cos(angle2)), CInt(endPoint.Y - arrowHeadLength * Math.Sin(angle2)))

        '' Dibujar los lados de la punta de la flecha
        'g.DrawLine(pen, endPoint, headPoint1)
        'g.DrawLine(pen, endPoint, headPoint2)
    End Sub
End Class