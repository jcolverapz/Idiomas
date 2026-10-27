Public Class frmObjetivo
    Public valor As String

    Private Sub frmObjetivo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim mensaje As String = ""
        If valor = "Oraciones" Then
            mensaje = " Todas las oraciones"
        End If

        txtObjetivo.Text = mensaje

    End Sub

    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()

    End Sub
End Class