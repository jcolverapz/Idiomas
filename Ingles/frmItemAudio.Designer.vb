<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemAudio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemAudio))
        Me.cmdPlay = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.pEtapa = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdLeer = New System.Windows.Forms.Button()
        Me.ImageList5 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'cmdPlay
        '
        Me.cmdPlay.Location = New System.Drawing.Point(309, 12)
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(140, 38)
        Me.cmdPlay.TabIndex = 0
        Me.cmdPlay.Text = "Play"
        Me.cmdPlay.UseVisualStyleBackColor = True
        '
        'cmdStop
        '
        Me.cmdStop.Location = New System.Drawing.Point(509, 12)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(116, 38)
        Me.cmdStop.TabIndex = 1
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(12, 12)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(116, 38)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "Cerrar"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'pEtapa
        '
        Me.pEtapa.Location = New System.Drawing.Point(12, 79)
        Me.pEtapa.Name = "pEtapa"
        Me.pEtapa.Size = New System.Drawing.Size(1310, 714)
        Me.pEtapa.TabIndex = 365
        '
        'cmdLeer
        '
        Me.cmdLeer.Location = New System.Drawing.Point(662, 12)
        Me.cmdLeer.Name = "cmdLeer"
        Me.cmdLeer.Size = New System.Drawing.Size(140, 38)
        Me.cmdLeer.TabIndex = 0
        Me.cmdLeer.Text = "leer"
        Me.cmdLeer.UseVisualStyleBackColor = True
        '
        'ImageList5
        '
        Me.ImageList5.ImageStream = CType(resources.GetObject("ImageList5.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList5.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList5.Images.SetKeyName(0, "icons8-usuario-50.ico")
        Me.ImageList5.Images.SetKeyName(1, "download__1_-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(2, "Aaron-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(3, "download-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(4, "melendez_1-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(5, "download__2_-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(6, "Andrews-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(7, "pixelcut-export (2).png")
        Me.ImageList5.Images.SetKeyName(8, "dra.-lea-jpg-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(9, "Morgan-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(10, "park-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(11, "asher-removebg-preview.png")
        '
        'frmItemAudio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1360, 813)
        Me.Controls.Add(Me.pEtapa)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.cmdLeer)
        Me.Controls.Add(Me.cmdPlay)
        Me.Name = "frmItemAudio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmItemAudio"
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents cmdPlay As System.Windows.Forms.Button
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents pEtapa As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmdLeer As System.Windows.Forms.Button
    Friend WithEvents ImageList5 As System.Windows.Forms.ImageList
End Class
