<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistrarAvance
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
        Me.txtNivel = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTema = New System.Windows.Forms.Label()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtNivel
        '
        Me.txtNivel.Location = New System.Drawing.Point(91, 98)
        Me.txtNivel.Name = "txtNivel"
        Me.txtNivel.Size = New System.Drawing.Size(52, 20)
        Me.txtNivel.TabIndex = 57
        Me.txtNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Porcentaje"
        '
        'lblTema
        '
        Me.lblTema.AutoSize = True
        Me.lblTema.Location = New System.Drawing.Point(27, 50)
        Me.lblTema.Name = "lblTema"
        Me.lblTema.Size = New System.Drawing.Size(34, 13)
        Me.lblTema.TabIndex = 54
        Me.lblTema.Text = "Tema"
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Location = New System.Drawing.Point(188, 150)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(76, 43)
        Me.CmdGuardar.TabIndex = 58
        Me.CmdGuardar.Text = "Guardar"
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'frmRegistrarAvance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 214)
        Me.Controls.Add(Me.CmdGuardar)
        Me.Controls.Add(Me.txtNivel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblTema)
        Me.Name = "frmRegistrarAvance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRegistrarAvance"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNivel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTema As System.Windows.Forms.Label
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
End Class
