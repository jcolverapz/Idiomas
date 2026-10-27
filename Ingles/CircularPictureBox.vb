Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class CircularPictureBox
    Inherits PictureBox

    Protected Overrides Sub OnPaint(pe As System.Windows.Forms.PaintEventArgs)
        Dim grpath As GraphicsPath = New GraphicsPath()
        grpath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height)
        Me.Region = New Region(grpath)
        Try
            MyBase.OnPaint(pe)

        Catch ex As Exception

        End Try
    End Sub
End Class
