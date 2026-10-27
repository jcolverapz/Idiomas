<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetConversation
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
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtavance = New System.Windows.Forms.TextBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtInicio = New System.Windows.Forms.TextBox()
        Me.cmdOrdenarDialogos = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObserv = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtOrdenInicio = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdExit.Location = New System.Drawing.Point(22, 12)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(66, 36)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(22, 70)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(19, 16)
        Me.lblTipo.TabIndex = 298
        Me.lblTipo.Text = "Id"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(120, 67)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(75, 22)
        Me.txtId.TabIndex = 297
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(120, 110)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(530, 22)
        Me.txtDescripcion.TabIndex = 299
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 300
        Me.Label1.Text = "Titulo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdGuardar.Location = New System.Drawing.Point(283, 240)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(53, 32)
        Me.CmdGuardar.TabIndex = 361
        Me.CmdGuardar.Text = "Save"
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(545, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 363
        Me.Label3.Text = "Orden"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOrden
        '
        Me.txtOrden.BackColor = System.Drawing.Color.White
        Me.txtOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrden.Location = New System.Drawing.Point(596, 54)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(75, 22)
        Me.txtOrden.TabIndex = 362
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(536, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 365
        Me.Label5.Text = "Avance"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtavance
        '
        Me.txtavance.BackColor = System.Drawing.Color.White
        Me.txtavance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtavance.Location = New System.Drawing.Point(596, 26)
        Me.txtavance.Name = "txtavance"
        Me.txtavance.Size = New System.Drawing.Size(75, 22)
        Me.txtavance.TabIndex = 364
        Me.txtavance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboTipo
        '
        Me.cboTipo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(120, 169)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(231, 24)
        Me.cboTipo.TabIndex = 360
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 16)
        Me.Label4.TabIndex = 359
        Me.Label4.Text = "Tipo"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(574, 186)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 148)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 366
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(107, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(66, 36)
        Me.Button1.TabIndex = 367
        Me.Button1.Text = "Ordenar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(190, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(66, 36)
        Me.Button2.TabIndex = 368
        Me.Button2.Text = "Ordenar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(69, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 370
        Me.Label2.Text = "Inicio"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtInicio
        '
        Me.txtInicio.BackColor = System.Drawing.Color.White
        Me.txtInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInicio.Location = New System.Drawing.Point(120, 219)
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.Size = New System.Drawing.Size(75, 22)
        Me.txtInicio.TabIndex = 369
        Me.txtInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdOrdenarDialogos
        '
        Me.cmdOrdenarDialogos.Location = New System.Drawing.Point(283, 11)
        Me.cmdOrdenarDialogos.Name = "cmdOrdenarDialogos"
        Me.cmdOrdenarDialogos.Size = New System.Drawing.Size(82, 39)
        Me.cmdOrdenarDialogos.TabIndex = 371
        Me.cmdOrdenarDialogos.Text = "Ordenar Con Dialogos"
        Me.cmdOrdenarDialogos.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(371, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(82, 39)
        Me.Button3.TabIndex = 372
        Me.Button3.Text = "Ordenar Con Texto"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 373
        Me.Label6.Text = "Descripcion"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtObserv
        '
        Me.txtObserv.BackColor = System.Drawing.Color.White
        Me.txtObserv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObserv.Location = New System.Drawing.Point(120, 141)
        Me.txtObserv.Name = "txtObserv"
        Me.txtObserv.Size = New System.Drawing.Size(530, 22)
        Me.txtObserv.TabIndex = 374
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(512, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 16)
        Me.Label7.TabIndex = 376
        Me.Label7.Text = "Orden Inicio"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOrdenInicio
        '
        Me.txtOrdenInicio.BackColor = System.Drawing.Color.White
        Me.txtOrdenInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrdenInicio.Location = New System.Drawing.Point(596, 82)
        Me.txtOrdenInicio.Name = "txtOrdenInicio"
        Me.txtOrdenInicio.Size = New System.Drawing.Size(75, 22)
        Me.txtOrdenInicio.TabIndex = 375
        Me.txtOrdenInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmDetConversation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 346)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtOrdenInicio)
        Me.Controls.Add(Me.txtObserv)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cmdOrdenarDialogos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtInicio)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtavance)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.CmdGuardar)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "frmDetConversation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmDetConversation"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtavance As System.Windows.Forms.TextBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtInicio As System.Windows.Forms.TextBox
    Friend WithEvents cmdOrdenarDialogos As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Public WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtObserv As System.Windows.Forms.TextBox
    Public WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOrdenInicio As System.Windows.Forms.TextBox
End Class
