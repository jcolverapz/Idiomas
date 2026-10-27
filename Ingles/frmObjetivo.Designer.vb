<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmObjetivo
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
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtObjetivo = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Location = New System.Drawing.Point(12, 12)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(105, 41)
        Me.CmdCerrar.TabIndex = 40
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.txtObjetivo)
        Me.Panel1.Location = New System.Drawing.Point(22, 94)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(676, 262)
        Me.Panel1.TabIndex = 41
        '
        'txtObjetivo
        '
        Me.txtObjetivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtObjetivo.Location = New System.Drawing.Point(0, 0)
        Me.txtObjetivo.Multiline = True
        Me.txtObjetivo.Name = "txtObjetivo"
        Me.txtObjetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObjetivo.Size = New System.Drawing.Size(676, 262)
        Me.txtObjetivo.TabIndex = 1
        '
        'frmObjetivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 381)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Name = "frmObjetivo"
        Me.Text = "frmObjetivo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtObjetivo As System.Windows.Forms.TextBox
End Class
