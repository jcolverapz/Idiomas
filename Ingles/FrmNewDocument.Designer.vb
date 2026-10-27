<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewDocument
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNewDocument))
        Me.cboState = New System.Windows.Forms.ComboBox()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtTraduccion = New System.Windows.Forms.TextBox()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CmdAdjuntar = New System.Windows.Forms.Button()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboState
        '
        Me.cboState.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboState.FormattingEnabled = True
        Me.cboState.Location = New System.Drawing.Point(77, 265)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(255, 24)
        Me.cboState.TabIndex = 386
        '
        'cmdExit
        '
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdExit.Location = New System.Drawing.Point(7, 6)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(66, 36)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(28, 268)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 16)
        Me.Label9.TabIndex = 385
        Me.Label9.Text = "State"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 556)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(788, 22)
        Me.StatusStrip1.TabIndex = 392
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStatus
        '
        Me.ToolStatus.Name = "ToolStatus"
        Me.ToolStatus.Size = New System.Drawing.Size(39, 17)
        Me.ToolStatus.Text = "Status"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "user_icon-icons.com_74450.ico")
        Me.ImageList1.Images.SetKeyName(1, "woman256_24802.png")
        Me.ImageList1.Images.SetKeyName(2, "adduser_4961 (2).png")
        Me.ImageList1.Images.SetKeyName(3, "check_accept_done_tick_icon_143633.png")
        Me.ImageList1.Images.SetKeyName(4, "iconfinder-document03-1622833_121957.png")
        Me.ImageList1.Images.SetKeyName(5, "burger_line_list_menu_nav_navigation_option_icon_123231.png")
        Me.ImageList1.Images.SetKeyName(6, "checkbox_icon_216007 (1).png")
        Me.ImageList1.Images.SetKeyName(7, "emblemdefault_103452.png")
        Me.ImageList1.Images.SetKeyName(8, "PaperClip_4895 (2).png")
        Me.ImageList1.Images.SetKeyName(9, "burger_line_list_menu_nav_navigation_option_icon_123231.png")
        Me.ImageList1.Images.SetKeyName(10, "savetheapplication_guardar_2958.ico")
        '
        'txtTraduccion
        '
        Me.txtTraduccion.BackColor = System.Drawing.Color.White
        Me.txtTraduccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTraduccion.Location = New System.Drawing.Point(18, 148)
        Me.txtTraduccion.MaxLength = 500
        Me.txtTraduccion.Multiline = True
        Me.txtTraduccion.Name = "txtTraduccion"
        Me.txtTraduccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTraduccion.Size = New System.Drawing.Size(420, 43)
        Me.txtTraduccion.TabIndex = 391
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdGuardar.Location = New System.Drawing.Point(217, 8)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(53, 32)
        Me.CmdGuardar.TabIndex = 91
        Me.CmdGuardar.Text = "Save"
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'ImageList4
        '
        Me.ImageList4.ImageStream = CType(resources.GetObject("ImageList4.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList4.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList4.Images.SetKeyName(0, "documento_-_Copy-transformed.png")
        Me.ImageList4.Images.SetKeyName(1, "avatar_people_person_profile_user_woman_icon_123359.png")
        Me.ImageList4.Images.SetKeyName(2, "user_icon-icons.com_74450 (1).ico")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 129)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 16)
        Me.Label13.TabIndex = 383
        Me.Label13.Text = "Descripcion"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.CmdAdjuntar)
        Me.Panel2.Controls.Add(Me.CmdGuardar)
        Me.Panel2.Controls.Add(Me.cmdExit)
        Me.Panel2.Controls.Add(Me.txtId)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(788, 49)
        Me.Panel2.TabIndex = 380
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(89, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 28)
        Me.Button1.TabIndex = 93
        Me.Button1.Text = "Nuevo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CmdAdjuntar
        '
        Me.CmdAdjuntar.Location = New System.Drawing.Point(373, 11)
        Me.CmdAdjuntar.Name = "CmdAdjuntar"
        Me.CmdAdjuntar.Size = New System.Drawing.Size(65, 27)
        Me.CmdAdjuntar.TabIndex = 92
        Me.CmdAdjuntar.Text = "Adjuntar"
        Me.CmdAdjuntar.UseVisualStyleBackColor = True
        '
        'cmbGrupo
        '
        Me.cmbGrupo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(77, 295)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(254, 24)
        Me.cmbGrupo.TabIndex = 389
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "iconfinder-document03-1622833_121957.png")
        Me.ImageList2.Images.SetKeyName(1, "document_add_256_icon-icons.com_75994.png")
        Me.ImageList2.Images.SetKeyName(2, "folder_add_icon-icons.com_74436.png")
        Me.ImageList2.Images.SetKeyName(3, "add_icon_129463.png")
        Me.ImageList2.Images.SetKeyName(4, "report-transformed.jpeg")
        Me.ImageList2.Images.SetKeyName(5, "lapiz.png")
        Me.ImageList2.Images.SetKeyName(6, "document_add_256_icon-icons.com_75994-transformed.png")
        Me.ImageList2.Images.SetKeyName(7, "documento.png")
        Me.ImageList2.Images.SetKeyName(8, "756exclamationmark_100528.png")
        Me.ImageList2.Images.SetKeyName(9, "Gallery_icon-icons.com_76885.png")
        Me.ImageList2.Images.SetKeyName(10, "checkbox_icon_216007.png")
        Me.ImageList2.Images.SetKeyName(11, "emblemdefault_103452.png")
        Me.ImageList2.Images.SetKeyName(12, "picture_photo_image_icon_131252.png")
        Me.ImageList2.Images.SetKeyName(13, "icon_Options.ico")
        Me.ImageList2.Images.SetKeyName(14, "PaperClip_4895 (3).png")
        Me.ImageList2.Images.SetKeyName(15, "burger_line_list_menu_nav_navigation_option_icon_123231.png")
        Me.ImageList2.Images.SetKeyName(16, "document_add_256_icon-icons.com_75994-transformed.png")
        Me.ImageList2.Images.SetKeyName(17, "666295.png")
        Me.ImageList2.Images.SetKeyName(18, "documento.png")
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(15, 66)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(53, 16)
        Me.Label20.TabIndex = 387
        Me.Label20.Text = "Archivo"
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "icon_Options.ico")
        Me.ImageList3.Images.SetKeyName(1, "burger_line_list_menu_nav_navigation_option_icon_123231.png")
        Me.ImageList3.Images.SetKeyName(2, "details_more_icon_214604.png")
        Me.ImageList3.Images.SetKeyName(3, "savetheapplication_guardar_2958 (1).png")
        Me.ImageList3.Images.SetKeyName(4, "documento.png")
        Me.ImageList3.Images.SetKeyName(5, "lapiz - Copy.png")
        Me.ImageList3.Images.SetKeyName(6, "attachment.png")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 298)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 388
        Me.Label1.Text = "Grupo"
        '
        'txtArchivo
        '
        Me.txtArchivo.BackColor = System.Drawing.Color.White
        Me.txtArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.Location = New System.Drawing.Point(18, 85)
        Me.txtArchivo.MaxLength = 500
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtArchivo.Size = New System.Drawing.Size(420, 22)
        Me.txtArchivo.TabIndex = 393
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(166, 195)
        Me.TextBox1.MaxLength = 500
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(420, 43)
        Me.TextBox1.TabIndex = 393
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(640, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 16)
        Me.Label2.TabIndex = 387
        Me.Label2.Text = "ID"
        '
        'txtId
        '
        Me.txtId.AutoSize = True
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(686, 17)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(15, 16)
        Me.txtId.TabIndex = 387
        Me.txtId.Text = "0"
        '
        'FrmNewDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 578)
        Me.Controls.Add(Me.txtArchivo)
        Me.Controls.Add(Me.cboState)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtTraduccion)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmNewDocument"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FrmNewDocument"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txtTraduccion As System.Windows.Forms.TextBox
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents ImageList4 As System.Windows.Forms.ImageList
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CmdAdjuntar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
