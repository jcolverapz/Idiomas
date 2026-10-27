Public Class PanelOptimizado
    Inherits Panel

    Public Sub New()
        Me.DoubleBuffered = True
        Me.ResizeRedraw = True
    End Sub
    'Public Sub New()
    '    Me.DoubleBuffered = True
    '    Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    '    Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    '    Me.SetStyle(ControlStyles.UserPaint, True)
    'End Sub
    'Public Sub New()
    '    'Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
    '    '            ControlStyles.UserPaint Or
    '    '            ControlStyles.OptimizedDoubleBuffer, True)

    '    'Me.DoubleBuffered = True
    '    'Me.ResizeRedraw = True
    'End Sub
End Class