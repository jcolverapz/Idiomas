<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenarDialogos
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
        Me.cmdTransferir = New System.Windows.Forms.Button()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.cmdNuevo = New System.Windows.Forms.Button()
        Me.cboConversation = New System.Windows.Forms.ComboBox()
        Me.cmdSaveTransferir = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdConversationNew = New System.Windows.Forms.TextBox()
        Me.txtConversacion = New System.Windows.Forms.TextBox()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.LvwNew = New Ingles.ListViewCustomReorder.ListViewEx()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LvwAssigned = New Ingles.ListViewCustomReorder.ListViewEx()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'cmdTransferir
        '
        Me.cmdTransferir.Location = New System.Drawing.Point(518, 8)
        Me.cmdTransferir.Name = "cmdTransferir"
        Me.cmdTransferir.Size = New System.Drawing.Size(125, 25)
        Me.cmdTransferir.TabIndex = 364
        Me.cmdTransferir.Text = "Transferir Todo"
        Me.cmdTransferir.UseVisualStyleBackColor = True
        '
        'cboTipo
        '
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(799, 39)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(248, 26)
        Me.cboTipo.TabIndex = 362
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Location = New System.Drawing.Point(799, 13)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(125, 25)
        Me.cmdNuevo.TabIndex = 359
        Me.cmdNuevo.Text = "Nuevo"
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'cboConversation
        '
        Me.cboConversation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConversation.FormattingEnabled = True
        Me.cboConversation.Location = New System.Drawing.Point(1100, 41)
        Me.cboConversation.Name = "cboConversation"
        Me.cboConversation.Size = New System.Drawing.Size(248, 26)
        Me.cboConversation.TabIndex = 363
        '
        'cmdSaveTransferir
        '
        Me.cmdSaveTransferir.Location = New System.Drawing.Point(956, 14)
        Me.cmdSaveTransferir.Name = "cmdSaveTransferir"
        Me.cmdSaveTransferir.Size = New System.Drawing.Size(138, 25)
        Me.cmdSaveTransferir.TabIndex = 361
        Me.cmdSaveTransferir.Text = "Save"
        Me.cmdSaveTransferir.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(479, 42)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(125, 25)
        Me.cmdSave.TabIndex = 358
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1340, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 356
        Me.Label1.Text = "Conversacion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(649, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 357
        Me.Label2.Text = "Conversacion"
        '
        'txtIdConversationNew
        '
        Me.txtIdConversationNew.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdConversationNew.Location = New System.Drawing.Point(1364, 41)
        Me.txtIdConversationNew.Name = "txtIdConversationNew"
        Me.txtIdConversationNew.Size = New System.Drawing.Size(67, 22)
        Me.txtIdConversationNew.TabIndex = 354
        '
        'txtConversacion
        '
        Me.txtConversacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConversacion.Location = New System.Drawing.Point(652, 41)
        Me.txtConversacion.Name = "txtConversacion"
        Me.txtConversacion.Size = New System.Drawing.Size(67, 22)
        Me.txtConversacion.TabIndex = 355
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Location = New System.Drawing.Point(12, 13)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(105, 31)
        Me.CmdCerrar.TabIndex = 353
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'LvwNew
        '
        Me.LvwNew.AllowDrop = True
        Me.LvwNew.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.LvwNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvwNew.Location = New System.Drawing.Point(799, 69)
        Me.LvwNew.MultiSelect = False
        Me.LvwNew.Name = "LvwNew"
        Me.LvwNew.Size = New System.Drawing.Size(632, 710)
        Me.LvwNew.TabIndex = 360
        Me.LvwNew.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Ingles"
        Me.ColumnHeader3.Width = 300
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Traduccion"
        Me.ColumnHeader4.Width = 300
        '
        'LvwAssigned
        '
        Me.LvwAssigned.AllowDrop = True
        Me.LvwAssigned.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.LvwAssigned.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvwAssigned.Location = New System.Drawing.Point(12, 69)
        Me.LvwAssigned.MultiSelect = False
        Me.LvwAssigned.Name = "LvwAssigned"
        Me.LvwAssigned.Size = New System.Drawing.Size(592, 710)
        Me.LvwAssigned.TabIndex = 352
        Me.LvwAssigned.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Ingles"
        Me.ColumnHeader8.Width = 380
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Traduccion"
        Me.ColumnHeader9.Width = 380
        '
        'frmOrdenarDialogos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1462, 790)
        Me.Controls.Add(Me.cmdTransferir)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.LvwNew)
        Me.Controls.Add(Me.cmdNuevo)
        Me.Controls.Add(Me.cboConversation)
        Me.Controls.Add(Me.cmdSaveTransferir)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIdConversationNew)
        Me.Controls.Add(Me.txtConversacion)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.LvwAssigned)
        Me.Name = "frmOrdenarDialogos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmOrdenarDialogos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdTransferir As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents LvwNew As Ingles.ListViewCustomReorder.ListViewEx
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboConversation As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSaveTransferir As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdConversationNew As System.Windows.Forms.TextBox
    Friend WithEvents txtConversacion As System.Windows.Forms.TextBox
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents LvwAssigned As Ingles.ListViewCustomReorder.ListViewEx
End Class
