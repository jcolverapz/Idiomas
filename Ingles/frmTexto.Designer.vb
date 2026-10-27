<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTexto
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdSplit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lstOraciones = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtTexto = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboGrupo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.txtId)
        Me.Panel1.Controls.Add(Me.txtDescripcion)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmdSplit)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lbltitulo)
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1466, 58)
        Me.Panel1.TabIndex = 396
        '
        'cboGrupo
        '
        Me.cboGrupo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(215, 30)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(262, 28)
        Me.cboGrupo.TabIndex = 399
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(135, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 24)
        Me.Label3.TabIndex = 398
        Me.Label3.Text = "Grupo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1140, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 17)
        Me.Label2.TabIndex = 401
        Me.Label2.Text = "Descripcion"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(483, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(234, 20)
        Me.TextBox1.TabIndex = 400
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(723, 32)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(47, 20)
        Me.txtId.TabIndex = 399
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(1143, 28)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(190, 20)
        Me.txtDescripcion.TabIndex = 398
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1024, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 35)
        Me.Button1.TabIndex = 397
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSplit
        '
        Me.cmdSplit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdSplit.Location = New System.Drawing.Point(912, 11)
        Me.cmdSplit.Name = "cmdSplit"
        Me.cmdSplit.Size = New System.Drawing.Size(66, 36)
        Me.cmdSplit.TabIndex = 396
        Me.cmdSplit.Text = "Split"
        Me.cmdSplit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(489, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 22)
        Me.Label1.TabIndex = 396
        Me.Label1.Text = "Conversacion"
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = True
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.Location = New System.Drawing.Point(183, 7)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(195, 22)
        Me.lbltitulo.TabIndex = 396
        Me.lbltitulo.Text = "Copy and Pase Text"
        '
        'Button9
        '
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Location = New System.Drawing.Point(12, 12)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(66, 36)
        Me.Button9.TabIndex = 395
        Me.Button9.Text = "Exit"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lstOraciones)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1466, 783)
        Me.Panel2.TabIndex = 397
        '
        'lstOraciones
        '
        Me.lstOraciones.BackColor = System.Drawing.SystemColors.Info
        Me.lstOraciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader1})
        Me.lstOraciones.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lstOraciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstOraciones.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.lstOraciones.Location = New System.Drawing.Point(1004, 0)
        Me.lstOraciones.Name = "lstOraciones"
        Me.lstOraciones.Size = New System.Drawing.Size(462, 783)
        Me.lstOraciones.TabIndex = 403
        Me.lstOraciones.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Width = 50
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Width = 200
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.txtTexto)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1004, 783)
        Me.Panel3.TabIndex = 1
        '
        'txtTexto
        '
        Me.txtTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTexto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTexto.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTexto.Location = New System.Drawing.Point(0, 0)
        Me.txtTexto.Multiline = True
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTexto.Size = New System.Drawing.Size(1004, 783)
        Me.txtTexto.TabIndex = 1
        '
        'frmTexto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1466, 841)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmTexto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmTexto"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdSplit As System.Windows.Forms.Button
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtTexto As System.Windows.Forms.TextBox
    Friend WithEvents lstOraciones As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
