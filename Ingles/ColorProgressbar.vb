Public Class ColorProgressbar
    Inherits ProgressBar
    Private _BarColor As Color = Color.Green
    Public Sub New()
        Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub
    Public Property BarColor As Color
        Get
            Return _BarColor
        End Get
        Set(value As Color)
            _BarColor = value
            Me.Invalidate()
        End Set
    End Property
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim rect As Rectangle = e.ClipRectangle

        e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), rect)

        rect.Width = CInt(rect.Width * (Me.Value - Me.Minimum) / (Me.Maximum - Me.Minimum))

        If Me.Value > 0 Then
            e.Graphics.FillRectangle(New SolidBrush(_BarColor), 0, 0, rect.Width, rect.Height)
        End If
    End Sub

End Class