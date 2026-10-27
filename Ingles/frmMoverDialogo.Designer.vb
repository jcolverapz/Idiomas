<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMoverDialogo
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
        Me.cboConversation = New System.Windows.Forms.ComboBox()
        Me.txtaprendidos = New System.Windows.Forms.Label()
        Me.txtIdConversationNew = New System.Windows.Forms.TextBox()
        Me.cmdSaveTransferir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
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
        'cboConversation
        '
        Me.cboConversation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConversation.FormattingEnabled = True
        Me.cboConversation.Location = New System.Drawing.Point(21, 150)
        Me.cboConversation.Name = "cboConversation"
        Me.cboConversation.Size = New System.Drawing.Size(410, 26)
        Me.cboConversation.TabIndex = 351
        '
        'txtaprendidos
        '
        Me.txtaprendidos.AutoSize = True
        Me.txtaprendidos.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaprendidos.Location = New System.Drawing.Point(17, 124)
        Me.txtaprendidos.Name = "txtaprendidos"
        Me.txtaprendidos.Size = New System.Drawing.Size(115, 23)
        Me.txtaprendidos.TabIndex = 396
        Me.txtaprendidos.Text = "Descripcion"
        '
        'txtIdConversationNew
        '
        Me.txtIdConversationNew.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdConversationNew.Location = New System.Drawing.Point(303, 71)
        Me.txtIdConversationNew.Name = "txtIdConversationNew"
        Me.txtIdConversationNew.Size = New System.Drawing.Size(67, 22)
        Me.txtIdConversationNew.TabIndex = 397
        '
        'cmdSaveTransferir
        '
        Me.cmdSaveTransferir.Location = New System.Drawing.Point(175, 201)
        Me.cmdSaveTransferir.Name = "cmdSaveTransferir"
        Me.cmdSaveTransferir.Size = New System.Drawing.Size(138, 25)
        Me.cmdSaveTransferir.TabIndex = 398
        Me.cmdSaveTransferir.Text = "Save"
        Me.cmdSaveTransferir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 23)
        Me.Label1.TabIndex = 399
        Me.Label1.Text = "Tipo"
        '
        'cboTipo
        '
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(21, 95)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(258, 26)
        Me.cboTipo.TabIndex = 459
        '
        'frmMoverDialogo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 248)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdSaveTransferir)
        Me.Controls.Add(Me.txtIdConversationNew)
        Me.Controls.Add(Me.txtaprendidos)
        Me.Controls.Add(Me.cboConversation)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Name = "frmMoverDialogo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Mover"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents cboConversation As System.Windows.Forms.ComboBox
    Friend WithEvents txtaprendidos As System.Windows.Forms.Label
    Friend WithEvents txtIdConversationNew As System.Windows.Forms.TextBox
    Friend WithEvents cmdSaveTransferir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
End Class
