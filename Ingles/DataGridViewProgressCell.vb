Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Namespace Sample
    Class DataGridViewProgressCell
        Inherits DataGridViewImageCell

        ' Used to make custom cell consistent with a DataGridViewImageCell
        Shared emptyImage As Image

        ' Used to remember color of the progress bar
        Shared _ProgressBarColor As Color

        Public Property ProgressBarColor As Color
            Get
                Return _ProgressBarColor
            End Get
            Set(value As Color)
                _ProgressBarColor = value
            End Set
        End Property

        Shared Sub New()
            emptyImage = New Bitmap(5, 5, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        End Sub

        Public Sub New()
            Me.ValueType = GetType(Integer)
        End Sub

        ' Method required to make the Progress Cell consistent with the default Image Cell.
        ' The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an int.
        Protected Overrides Function GetFormattedValue(value As Object, rowIndex As Integer, ByRef cellStyle As DataGridViewCellStyle, valueTypeConverter As TypeConverter, formattedValueTypeConverter As TypeConverter, context As DataGridViewDataErrorContexts) As Object
            Return emptyImage
        End Function

        Protected Overrides Sub Paint(g As Graphics, clipBounds As Rectangle, cellBounds As Rectangle, rowIndex As Integer, cellState As DataGridViewElementStates, value As Object, formattedValue As Object, errorText As String, cellStyle As DataGridViewCellStyle, advancedBorderStyle As DataGridViewAdvancedBorderStyle, paintParts As DataGridViewPaintParts)
            If Convert.ToInt16(value) = 0 OrElse value Is Nothing Then
                value = 0
            End If

            Dim progressVal As Integer = Convert.ToInt32(value)

            Dim percentage As Single = CSng(progressVal) / 100.0F ' Need to convert to float before division; otherwise VB.NET returns int which is 0 for anything but 100%.
            Dim backColorBrush As Brush = New SolidBrush(cellStyle.BackColor)
            Dim foreColorBrush As Brush = New SolidBrush(cellStyle.ForeColor)

            ' Draws the cell grid
            MyBase.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, (paintParts And Not DataGridViewPaintParts.ContentForeground))

            Dim posX As Single = cellBounds.X
            Dim posY As Single = cellBounds.Y

            Dim textWidth As Single = TextRenderer.MeasureText(progressVal.ToString() & "%", cellStyle.Font).Width
            Dim textHeight As Single = TextRenderer.MeasureText(progressVal.ToString() & "%", cellStyle.Font).Height

            'evaluating text position according to alignment
            Select Case cellStyle.Alignment
                Case DataGridViewContentAlignment.BottomCenter
                    posX = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2
                    posY = cellBounds.Y + cellBounds.Height - textHeight
                Case DataGridViewContentAlignment.BottomLeft
                    posX = cellBounds.X
                    posY = cellBounds.Y + cellBounds.Height - textHeight
                Case DataGridViewContentAlignment.BottomRight
                    posX = cellBounds.X + cellBounds.Width - textWidth
                    posY = cellBounds.Y + cellBounds.Height - textHeight
                Case DataGridViewContentAlignment.MiddleCenter
                    posX = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2
                    posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2
                Case DataGridViewContentAlignment.MiddleLeft
                    posX = cellBounds.X
                    posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2
                Case DataGridViewContentAlignment.MiddleRight
                    posX = cellBounds.X + cellBounds.Width - textWidth
                    posY = cellBounds.Y + (cellBounds.Height / 2) - textHeight / 2
                Case DataGridViewContentAlignment.TopCenter
                    posX = cellBounds.X + (cellBounds.Width / 2) - textWidth / 2
                    posY = cellBounds.Y
                Case DataGridViewContentAlignment.TopLeft
                    posX = cellBounds.X
                    posY = cellBounds.Y
                Case DataGridViewContentAlignment.TopRight
                    posX = cellBounds.X + cellBounds.Width - textWidth
                    posY = cellBounds.Y
            End Select

            Dim a As Integer
            Dim b As Integer
            Dim c As Integer
            Dim x As Integer
            Dim y As Integer
            Dim r As New Rectangle

            If percentage >= 0.0 Then
                ' Draw the progress 

                ' g.fillrectangle(New SolidBrush(_ProgressBarColor),cell
                'g.FillRectangle(New SolidBrush(_ProgressBarColor), 

                'y = cellBounds.X + 2
                'x = cellBounds.Y + 2
                'b = Convert.ToInt32((percentage * cellBounds.Width * 0.8))
                c = cellBounds.Height

                'r= cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width * 0.8)), cellBounds.Height)
                g.FillRectangle(New SolidBrush(_ProgressBarColor), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width * 0.95)), c - 5)

                ' g.FillRectangle(Brushes.Black, r)


                'Draw text
                g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreColorBrush, posX, posY)
            Else
                'if percentage is negative, we don't want to draw progress bar
                'wa want only text
                If Me.DataGridView.CurrentRow.Index = rowIndex Then
                    g.DrawString(progressVal.ToString() & "%", cellStyle.Font, New SolidBrush(cellStyle.SelectionForeColor), posX, posX)
                Else
                    g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreColorBrush, posX, posY)
                End If
            End If
        End Sub

        Public Overrides Function Clone() As Object
            Dim dataGridViewCell As DataGridViewProgressCell = TryCast(MyBase.Clone(), DataGridViewProgressCell)
            If dataGridViewCell IsNot Nothing Then
                dataGridViewCell.ProgressBarColor = Me.ProgressBarColor
            End If
            Return dataGridViewCell
        End Function

        Friend Sub SetProgressBarColor(rowIndex As Integer, value As Color)
            Me.ProgressBarColor = value
        End Sub
    End Class
End Namespace

