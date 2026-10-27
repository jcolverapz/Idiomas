<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTextoOrdenarDialogos
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
        Me.txtTexto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdOrdenar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lvwActual = New System.Windows.Forms.ListView()
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.txtIndice = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtTexto
        '
        Me.txtTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTexto.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTexto.Location = New System.Drawing.Point(12, 90)
        Me.txtTexto.Multiline = True
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTexto.Size = New System.Drawing.Size(330, 556)
        Me.txtTexto.TabIndex = 103
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(121, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 24)
        Me.Label4.TabIndex = 406
        Me.Label4.Text = "Original"
        '
        'cmdOrdenar
        '
        Me.cmdOrdenar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdOrdenar.Location = New System.Drawing.Point(692, 8)
        Me.cmdOrdenar.Name = "cmdOrdenar"
        Me.cmdOrdenar.Size = New System.Drawing.Size(66, 36)
        Me.cmdOrdenar.TabIndex = 407
        Me.cmdOrdenar.Text = "Split"
        Me.cmdOrdenar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(895, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 24)
        Me.Label1.TabIndex = 408
        Me.Label1.Text = "Desordenado"
        '
        'Button9
        '
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Location = New System.Drawing.Point(12, 11)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(66, 36)
        Me.Button9.TabIndex = 409
        Me.Button9.Text = "Exit"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1146, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 42)
        Me.Button1.TabIndex = 410
        Me.Button1.Text = "Update Orden"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lvwActual
        '
        Me.lvwActual.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvwActual.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwActual.Location = New System.Drawing.Point(776, 60)
        Me.lvwActual.Name = "lvwActual"
        Me.lvwActual.Size = New System.Drawing.Size(653, 579)
        Me.lvwActual.TabIndex = 411
        Me.lvwActual.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Width = 100
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Width = 300
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(499, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 24)
        Me.Label2.TabIndex = 413
        Me.Label2.Text = "Original"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.Location = New System.Drawing.Point(361, 90)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(397, 556)
        Me.ListView1.TabIndex = 414
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 200
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(779, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 44)
        Me.Button2.TabIndex = 415
        Me.Button2.Text = "Agregar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(620, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(66, 36)
        Me.Button3.TabIndex = 416
        Me.Button3.Text = "clear"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(361, 62)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(166, 22)
        Me.txtBuscar.TabIndex = 417
        '
        'txtIndice
        '
        Me.txtIndice.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndice.Location = New System.Drawing.Point(1339, 19)
        Me.txtIndice.Name = "txtIndice"
        Me.txtIndice.Size = New System.Drawing.Size(90, 22)
        Me.txtIndice.TabIndex = 418
        '
        'frmTextoOrdenarDialogos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1503, 849)
        Me.Controls.Add(Me.txtIndice)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lvwActual)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdOrdenar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTexto)
        Me.Name = "frmTextoOrdenarDialogos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmTextoOrdenarDialogos"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents txtTexto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdOrdenar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lvwActual As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents txtIndice As System.Windows.Forms.TextBox
End Class
