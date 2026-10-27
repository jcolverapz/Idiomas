<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenar
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
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdMostrar = New System.Windows.Forms.Button()
        Me.cmdSaveDialogo = New System.Windows.Forms.Button()
        Me.txtDetId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LvwAssigned = New Ingles.ListViewCustomReorder.ListViewEx()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Location = New System.Drawing.Point(9, 4)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(105, 31)
        Me.CmdCerrar.TabIndex = 41
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.UseVisualStyleBackColor = true
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Location = New System.Drawing.Point(139, 5)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(116, 33)
        Me.cmdGuardar.TabIndex = 43
        Me.cmdGuardar.Text = "Save"
        Me.cmdGuardar.UseVisualStyleBackColor = true
        '
        'cmdEditar
        '
        Me.cmdEditar.Location = New System.Drawing.Point(271, 5)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(116, 33)
        Me.cmdEditar.TabIndex = 44
        Me.cmdEditar.Text = "Editar"
        Me.cmdEditar.UseVisualStyleBackColor = true
        '
        'cmdMostrar
        '
        Me.cmdMostrar.Location = New System.Drawing.Point(412, 5)
        Me.cmdMostrar.Name = "cmdMostrar"
        Me.cmdMostrar.Size = New System.Drawing.Size(120, 33)
        Me.cmdMostrar.TabIndex = 47
        Me.cmdMostrar.Text = "En Conversacion"
        Me.cmdMostrar.UseVisualStyleBackColor = true
        '
        'cmdSaveDialogo
        '
        Me.cmdSaveDialogo.Location = New System.Drawing.Point(12, 1433)
        Me.cmdSaveDialogo.Name = "cmdSaveDialogo"
        Me.cmdSaveDialogo.Size = New System.Drawing.Size(116, 48)
        Me.cmdSaveDialogo.TabIndex = 346
        Me.cmdSaveDialogo.Text = "Save Dialogo"
        Me.cmdSaveDialogo.UseVisualStyleBackColor = true
        '
        'txtDetId
        '
        Me.txtDetId.Location = New System.Drawing.Point(167, 1461)
        Me.txtDetId.Name = "txtDetId"
        Me.txtDetId.Size = New System.Drawing.Size(204, 20)
        Me.txtDetId.TabIndex = 347
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(164, 1433)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 348
        Me.Label1.Text = "ID"
        '
        'LvwAssigned
        '
        Me.LvwAssigned.AllowDrop = true
        Me.LvwAssigned.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader5})
        Me.LvwAssigned.Font = New System.Drawing.Font("Consolas", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvwAssigned.Location = New System.Drawing.Point(9, 41)
        Me.LvwAssigned.MultiSelect = False
        Me.LvwAssigned.Name = "LvwAssigned"
        Me.LvwAssigned.Size = New System.Drawing.Size(1008, 1354)
        Me.LvwAssigned.TabIndex = 353
        Me.LvwAssigned.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Ingles"
        Me.ColumnHeader8.Width = 450
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Traduccion"
        Me.ColumnHeader9.Width = 450
        '
        'frmOrdenar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 1061)
        Me.Controls.Add(Me.LvwAssigned)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDetId)
        Me.Controls.Add(Me.cmdSaveDialogo)
        Me.Controls.Add(Me.cmdMostrar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Name = "frmOrdenar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmOrdenar"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ListView1 As Ingles.ListViewCustomReorder.ListViewEx
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents cmdEditar As System.Windows.Forms.Button
    Friend WithEvents cmdMostrar As System.Windows.Forms.Button
    Friend WithEvents cmdSaveDialogo As System.Windows.Forms.Button
    Friend WithEvents txtDetId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LvwAssigned As Ingles.ListViewCustomReorder.ListViewEx
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader


End Class
