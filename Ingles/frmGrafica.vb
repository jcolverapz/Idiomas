Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports SpeechLib
Imports System
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
 
Public Class frmGrafica

    Public Linea As String
    Public codlinea As Integer
    Public IdJC As Integer
    Public turno As Integer

    Dim IdHorarioMin As DateTime
    Dim IdHorarioMax As DateTime
    Dim fechaInicio As DateTime
    Dim fechatest As DateTime
    Dim lstHorarios As List(Of DateTime)
    Dim confoco As Boolean

    Private Sub frmGrafica_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        CargarGrafica()

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

        Dim total As Integer
        Dim totalFalta As Integer
        Dim totalAprendidos As Integer
        Dim totalGlobalAprendidos As Integer
        Dim totalGlobalFalta As Integer
        Dim GrupoId As Integer

        sqlstring = "select * from  Grupos_oracion "
        ' sqlstring = sqlstring & " WHERE Grupos_oracion.Tipo = 'Mas Usado'"
        sqlstring = sqlstring & " ORDER By orden ASC"

        _comando.CommandText = sqlstring

        _comando.Connection.Open()

        da.SelectCommand = _comando

        da.Fill(dt)

        _comando.Connection.Close()

        n = dt.Rows.Count

        Dim objDataReader As SqlDataReader

      
        For i = 0 To n - 1

            Dim m As String

            m = dt.Rows(i).Item(1)

            sqlstring = " SELECT        COUNT(Oraciones.Id) AS Cuenta, Oraciones.STL, Grupos_oracion.Grupo"
            sqlstring = sqlstring & " FROM            Oraciones INNER JOIN"
            sqlstring = sqlstring & "                       Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"

            If confoco = True Then
                sqlstring = sqlstring & " WHERE GrupoO ='" & dt.Rows(i).Item(0) & "' And Oraciones.foco='1'"
            Else
                sqlstring = sqlstring & " WHERE GrupoO ='" & dt.Rows(i).Item(0) & "' And Oraciones.foco='0'"
            End If
            sqlstring = sqlstring & " GROUP BY Oraciones.STL, Grupos_oracion.Grupo"

            Console.WriteLine(sqlstring)
            Console.WriteLine(dt.Rows(i).Item(0))
            Console.WriteLine(m)

            _comando.CommandText = sqlstring
            _comando.Connection.Open()


            objDataReader = _comando.ExecuteReader

            Do While objDataReader.Read()
                If objDataReader(1) = "True" Then
                    totalAprendidos = objDataReader(0)
                    totalGlobalAprendidos += totalAprendidos
                    total += totalAprendidos
                Else
                    totalFalta = objDataReader(0)
                    totalGlobalFalta += totalFalta
                    total += totalFalta

                End If
            Loop

            _comando.Connection.Close()

         

        Next i

        _comando.Connection.Close()

        Dim IntervalY As Integer

        IntervalY = 10

        'Chart2.ChartAreas(0).AxisX.Interval = 1

        'Chart2.ChartAreas(0).AxisY.Minimum = 0
        'Chart2.ChartAreas(0).AxisY.Maximum = total + 10
        'Chart2.ChartAreas(0).AxisY.Interval = IntervalY

        'Chart2.ChartAreas(0).AxisX.Minimum = 0
        'Chart2.ChartAreas(0).AxisX.Maximum = n + 1
        'Chart2.ChartAreas(0).AxisX.Interval = 1

        Chart1.Series.Clear()
        Chart1.Titles.Clear()
        ' Create a new series for the pie chart
        Dim series1 As New Series("MySeries")
        series1.ChartType = SeriesChartType.Column

        ' Add data points to the series
        series1.Points.AddXY("Aprendidos", totalGlobalAprendidos) ' Label, Value
        series1.Points.AddXY("Faltan", totalGlobalFalta)

        ' Add the series to the chart
        Chart1.Series.Add(series1)
        ' If you want to show Chart Legends
        Chart1.Legends(0).Enabled = True

        ' Optional: Customize the pie chart appearance
        ' series1("PieLabelStyle") = "Outside" ' Show labels outside the pie
        series1("PieLabelStyle") = "Inside" ' Show labels outside the pie
        series1.IsValueShownAsLabel = True
        '  series1.Label = "#PERCENT{P0}"
        ' series1.Label = "#VALX: #VALY"
        ' Or for percentage:
        series1.Label = "#VALX:  #VALY  (#PERCENT)"
        '   Chart3.Size = 500
        'Chart1.Dock = DockStyle.Fill
        Chart1.Titles.Add("Title") ' Add a title
        ' Chart1.ChartAreas(0).Area3DStyle.Enable3D = True ' 
        'Chart3.Series(0).IsValueShownAsLabel = True
        ' Chart3.Series(0).Label = "#PERCENT"
        'Chart3.Series(0).Label = "#PERCENT{P0}"
        ' Chart.HasLegend = True


        txtTotal.Text = total

    End Sub
    Private Sub CargarGrafica()

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim sqlstring As String = ""

        sqlstring &= " SELECT e.Con_Titulo, "
        sqlstring &= " SUM(CASE WHEN d.Status = 'R' THEN 1 ELSE 0 END) AS TotalR, "
        sqlstring &= " SUM(CASE WHEN o.STL = 1 THEN 1 ELSE 0 END) AS Aprendidos, "
        sqlstring &= " COUNT(t.IdConversacion) AS Total "

       


        'sqlstring = ""
        'sqlstring &= " SELECT e.Con_Titulo, "
        '' sqlstring &= " SUM(CASE WHEN d.Status = 'N' THEN 1 ELSE 0 END) AS TotalN, "
        'sqlstring &= " SUM(CASE WHEN d.Status = 'R' THEN 1 ELSE 0 END) AS TotalR, "
        ''  sqlstring &= " SUM(CASE WHEN d.Status = 'X' THEN 1 ELSE 0 END) AS TotalX, "
        'sqlstring &= " COUNT(t.IdConversacion) AS Total  "


        sqlstring &= " FROM Tbl_Dialogos AS t "
        sqlstring &= " INNER JOIN Det_Conversation AS d ON t.IdConversacion = d.Det_Con "
        sqlstring &= " INNER JOIN Enc_Conversation AS e ON d.Con_Id = e.Con_Id "
        sqlstring &= " INNER JOIN Oraciones AS o ON o.Id = t.IdOracion "  ' <-- AJUSTA ESTE JOIN
        sqlstring &= " WHERE d.Status = 'R' and e.Inicio='S' "
        sqlstring &= " GROUP BY e.Con_Titulo "
        ' sqlstring &= " HAVING COUNT(t.IdConversacion) > 20  "
        sqlstring &= " ORDER BY e.Con_Titulo DESC "

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        da.SelectCommand = _comando
        da.Fill(dt)

        _comando.Connection.Close()

  Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(New ChartArea("Area1"))

        '  Dim serieN As New Series("Sin Revisar")
        Dim serieR As New Series("Revisado")
        'Dim serieX As New Series("Mal")
        Dim serieA As New Series("Aprendidos")

        ' CAMBIO A COLUMNAS SIMPLES
        '  serieN.ChartType = SeriesChartType.Column
        serieR.ChartType = SeriesChartType.Column
        ' serieX.ChartType = SeriesChartType.Column

        ' serieN.Color = Color.FromArgb(250, 200, 150)
        serieR.Color = Color.FromArgb(180, 220, 180)
        ' serieX.Color = Color.FromArgb(170, 200, 240)
        serieA.Color = Color.FromArgb(170, 200, 240)

        ' serieN.IsValueShownAsLabel = True
        serieR.IsValueShownAsLabel = True
        '  serieX.IsValueShownAsLabel = True
        serieA.IsValueShownAsLabel = True

        Dim totalGeneral As Integer = 0

        For Each row As DataRow In dt.Rows

            Dim titulo As String = row("Con_Titulo").ToString()

            ' serieN.Points.AddXY(titulo, Convert.ToInt32(row("TotalN")))
            serieR.Points.AddXY(titulo, Convert.ToInt32(row("TotalR")))
            serieA.Points.AddXY(titulo, Convert.ToInt32(row("Aprendidos")))
            ' serieX.Points.AddXY(titulo, Convert.ToInt32(row("TotalX")))
            totalGeneral += Convert.ToInt32(row("Total"))

        Next

        'Chart1.Series.Add(serieN)
        Chart1.Series.Add(serieR)
        'Chart1.Series.Add(serieX)
        Chart1.Series.Add(serieA)

        Chart1.ChartAreas(0).AxisX.Interval = 1
        Chart1.ChartAreas(0).AxisX.LabelStyle.Angle = -45

        Chart1.Legends(0).Docking = DataVisualization.Charting.Docking.Top

        Dim totalAprendidos As Integer = 0

        If dt.Rows.Count > 0 Then
            totalAprendidos = Convert.ToInt32(dt.Compute("SUM(Aprendidos)", ""))
        End If

        txtAprendidos.Text = totalAprendidos.ToString()


        txtTotal.Text = totalGeneral.ToString("N0")

    End Sub
    
    Private Sub GraficarStandard()
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
        Dim total As Integer
        Dim totalFalta As Integer
        Dim totalAprendidos As Integer
        Dim GrupoId As Integer

     

        sqlstring = "select * from  Grupos_oracion "

        'If cboGrupo.Text <> "ALL" And cboGrupo.Text <> "" Then
        '    sqlstring = sqlstring & " WHERE Grupos_oracion.Id = '" & GrupoId & "'"
        'Else
        '    sqlstring = sqlstring & " WHERE Grupos_oracion.Tipo = 'Mas Usado'"

        'End If

        ' sqlstring = sqlstring & " WHERE Grupos_oracion.Tipo = 'Mas Usado'"

        sqlstring = sqlstring & " ORDER By orden ASC"

        _comando.CommandText = sqlstring

        _comando.Connection.Open()

        da.SelectCommand = _comando

        da.Fill(dt)

        _comando.Connection.Close()

        n = dt.Rows.Count

        Dim objDataReader As SqlDataReader

        Chart1.Series.Clear()
        Chart1.Legends(0).Font = New Font("Arial", 10, System.Drawing.FontStyle.Regular)
        Chart1.Legends(0).Docking = Docking.Top
        Chart1.Legends(0).BackColor = SystemColors.Control

        Chart1.BorderlineWidth = 1
        Chart1.BorderlineDashStyle = ChartDashStyle.Solid

        Chart1.ChartAreas(0).BackColor = SystemColors.Control 'Color.Black

        Chart1.ChartAreas(0).AxisX2.LineColor = Color.Blue

        Chart1.ChartAreas(0).AxisY2.LineColor = Color.Blue
        Chart1.ChartAreas(0).AxisY2.LabelStyle.ForeColor = Color.Blue

        Chart1.ChartAreas(0).AxisY.LineColor = Color.Blue
        Chart1.ChartAreas(0).AxisY.LineDashStyle = ChartDashStyle.Solid

        Chart1.ChartAreas(0).AxisY.MajorTickMark.Enabled = False
        Chart1.ChartAreas(0).AxisY.MinorTickMark.Enabled = False

        Chart1.ChartAreas(0).AxisX.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisY.LineColor = Color.LightGray

        Chart1.ChartAreas(0).AxisX.InterlacedColor = Color.LightGray
        Chart1.ChartAreas(0).AxisY.InterlacedColor = Color.LightGray
        Chart1.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.LightGray
        Chart1.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.LightGray

        Dim chartArea As ChartArea = Chart1.ChartAreas(0) ' Assuming you have one ChartArea
        Dim axisX As Axis = chartArea.AxisY
        ' You can also loop through an array of labels and add them
        ' Dim categories() As String = {0, 1, 2, 3, 4, 5, 6, 7, 8}
        ' For k As Integer = 0 To categories.Length - 1
        'axisX.CustomLabels.Add(i, DateTimeIntervalType.Number, categories(i))
        ' Next
        axisX.LabelStyle.Format = "D" ' For date formatting (e.g., "MM/dd/yyyy")
        axisX.LabelStyle.Angle = -90 ' Rotate labels to prevent overlap
        axisX.LabelStyle.Font = New Font("Verdana", 8)

        For i = 0 To n - 1
            sqlstring = " SELECT        COUNT(Oraciones.Id) AS Cuenta, Oraciones.STL, Grupos_oracion.Grupo"
            sqlstring = sqlstring & " FROM            Oraciones INNER JOIN"
            sqlstring = sqlstring & "                       Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"
            ' sqlstring = sqlstring & " WHERE GrupoO ='" & dt.Rows(i).Item(0) & "'"
            'sqlstring = sqlstring & " GROUP BY Oraciones.STL, Grupos_oracion.Grupo"

            If confoco = True Then
                sqlstring = sqlstring & " WHERE GrupoO ='" & dt.Rows(i).Item(0) & "' And Oraciones.foco='1'"
            Else
                sqlstring = sqlstring & " WHERE GrupoO ='" & dt.Rows(i).Item(0) & "' And Oraciones.foco='0'"
            End If
            sqlstring = sqlstring & " GROUP BY Oraciones.STL, Grupos_oracion.Grupo"

            ' Console.WriteLine(sqlstring)

            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            objDataReader = _comando.ExecuteReader

            totalFalta = 0
            totalAprendidos = 0

            Do While objDataReader.Read()
                If objDataReader(1) = "True" Then
                    totalAprendidos = objDataReader(0)
                Else
                    totalFalta = objDataReader(0)
                End If
            Loop

            _comando.Connection.Close()

            Dim m As String
            m = dt.Rows(i).Item(1)
            Chart1.Series.Add("[Falta]" & m)
            Chart1.Series("[Falta]" & m).Points.Clear()
            ' Chart1.Series("[Falta]" & m).ChartType = SeriesChartType.Bar    'Tipo de Grafico
            Chart1.Series("[Falta]" & m).ChartType = SeriesChartType.Column    'Tipo de Grafico
            Chart1.Series("[Falta]" & m).MarkerStep = 1

            Chart1.Series("[Falta]" & m).MarkerColor = Color.Green 'Color.DarkBlue
            Chart1.Series("[Falta]" & m).XValueType = ChartValueType.Int32
            Chart1.Series("[Falta]" & m).YValueType = ChartValueType.Int32
            Chart1.Series("[Falta]" & m).Font = New Font("Arial", 10, System.Drawing.FontStyle.Bold)
            Chart1.Series("[Falta]" & m).IsValueShownAsLabel = True
            Chart1.Series("[Falta]" & m).Points.AddXY(i, totalFalta)

            Chart1.Series.Add("[Ok]" & m)
            Chart1.Series("[Ok]" & m).Points.Clear()
            Chart1.Series("[Ok]" & m).ChartType = SeriesChartType.Column    'Tipo de Grafico
            Chart1.Series("[Ok]" & m).MarkerStep = 1

            Chart1.Series("[Ok]" & m).MarkerColor = Color.Green 'Color.DarkBlue
            Chart1.Series("[Ok]" & m).XValueType = ChartValueType.Int32
            Chart1.Series("[Ok]" & m).YValueType = ChartValueType.Int32
            Chart1.Series("[Ok]" & m).Font = New Font("Arial", 10, System.Drawing.FontStyle.Bold)
            Chart1.Series("[Ok]" & m).IsValueShownAsLabel = True
            Chart1.Series("[Ok]" & m).Points.AddXY(totalAprendidos, i)

            axisX.CustomLabels.Add(i, DateTimeIntervalType.Number, m)

            total += (totalAprendidos + totalFalta)

            i += 1

        Next



        _comando.Connection.Close()



        Dim IntervalY As Integer

        If total > 0 And total < 500 Then
            IntervalY = 10
        ElseIf total > 500 And total < 1000 Then
            IntervalY = 100

        End If

        Chart1.ChartAreas(0).AxisX.Interval = 1

        Chart1.ChartAreas(0).AxisY.Minimum = 0
        Chart1.ChartAreas(0).AxisY.Maximum = total + 10
        Chart1.ChartAreas(0).AxisY.Interval = IntervalY

        Chart1.ChartAreas(0).AxisX.Minimum = 0
        Chart1.ChartAreas(0).AxisX.Maximum = n + 1
        Chart1.ChartAreas(0).AxisX.Interval = 1




        txtAvance.Text = Math.Round(totalAprendidos / total, 1) * 100 & " %"



    End Sub
    
    'Private Sub Chart1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs)
    '    Dim result As HitTestResult = Chart1.HitTest(e.X, e.Y)
    '    Dim Ndx As Integer
    '    Dim thisPt As New PointF
    '    Dim ta As New CalloutAnnotation
    '    Dim TheText As String = ""

    '    Chart1.Annotations.Clear()
    '    If result.ChartElementType = ChartElementType.DataPoint Then

    '        Dim SName As String = result.Series.Name
    '        If SName = "Pz_Ok" Then
    '            Ndx = 1
    '        Else
    '            Ndx = 0
    '        End If

    '        thisPt = New PointF(CSng(Chart1.Series(Ndx).Points(result.PointIndex).XValue),
    '             CSng(Chart1.Series(Ndx).Points(result.PointIndex).YValues(0)))

    '        ta.CalloutStyle = CalloutStyle.Rectangle
    '        ta.AnchorDataPoint = Chart1.Series(Ndx).Points(result.PointIndex)
    '        ta.Alignment = ContentAlignment.MiddleLeft
    '        ta.TextStyle = TextStyle.Default
    '        ta.Font = New Font("Arial", 10, FontStyle.Bold)

    '        TheText &= "Value: " & thisPt.Y.ToString("F0") '& vbLf &
    '        'TheText &= SName & ": " & vbLf &
    '        '    "Value: " & thisPt.Y.ToString("F0") '& vbLf &
    '        ' "Date: " & DateFromOtherData(SName, CInt(thisPt.Y))
    '        ta.Text = TheText
    '        Chart1.Annotations.Add(ta)
    '        Chart1.Invalidate()
    '        Me.Text = "ThisPt.X = " & thisPt.X.ToString
    '    End If
    'End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

        Dim _grupo As String
        Dim sqlstring As String = ""
        Dim GrupoId As Integer

        ' If Me.cboGrupo.Text = "" Then Exit Sub

        ' If cboGrupo.Text = "ALL" Then
        '  GraficarTotales()
        ' Else
        GraficarStandard()

        ' End If

    End Sub

    Private Sub cmdFoco_Click(sender As System.Object, e As System.EventArgs)

        'If cmdFoco.Text = "Foco" Then
        '    cmdFoco.Text = "Sin foco"
        '    confoco = False
        '    cmdFoco.BackColor = Color.LightGray
        'Else
        '    cmdFoco.Text = "Foco"

        '    confoco = True
        '    cmdFoco.BackColor = Color.LightGreen
        'End If

        GraficarStandard()

        GraficarTotales()


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
    End Sub

    
End Class