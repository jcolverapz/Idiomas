Public Class BufferedPanel
    Inherits Panel

    Public Sub New()

        Me.DoubleBuffered = True

        Me.SetStyle(
            ControlStyles.UserPaint Or
            ControlStyles.AllPaintingInWmPaint Or
            ControlStyles.OptimizedDoubleBuffer,
            True)

        Me.UpdateStyles()

    End Sub

End Class
