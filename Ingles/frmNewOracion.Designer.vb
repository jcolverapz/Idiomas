<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewOracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewOracion))
        Me.ToolStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.txtTraduccion = New System.Windows.Forms.TextBox()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.cboState = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSubtemaId = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        '  Me.RichTextBoxEx1 = New RichTextBoxEx.RichTextBoxEx()
        Me.cmdFoco = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStatus
        '
        Me.ToolStatus.Name = "ToolStatus"
        Me.ToolStatus.Size = New System.Drawing.Size(39, 17)
        Me.ToolStatus.Text = "Status"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 430)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(795, 22)
        Me.StatusStrip1.TabIndex = 379
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'txtTraduccion
        '
        Me.txtTraduccion.BackColor = System.Drawing.Color.White
        Me.txtTraduccion.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTraduccion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTraduccion.Location = New System.Drawing.Point(166, 195)
        Me.txtTraduccion.MaxLength = 500
        Me.txtTraduccion.Multiline = True
        Me.txtTraduccion.Name = "txtTraduccion"
        Me.txtTraduccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTraduccion.Size = New System.Drawing.Size(420, 43)
        Me.txtTraduccion.TabIndex = 1
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
        'ImageList4
        '
        Me.ImageList4.ImageStream = CType(resources.GetObject("ImageList4.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList4.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList4.Images.SetKeyName(0, "documento_-_Copy-transformed.png")
        Me.ImageList4.Images.SetKeyName(1, "avatar_people_person_profile_user_woman_icon_123359.png")
        Me.ImageList4.Images.SetKeyName(2, "user_icon-icons.com_74450 (1).ico")
        '
        'cboState
        '
        Me.cboState.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboState.FormattingEnabled = True
        Me.cboState.Location = New System.Drawing.Point(166, 288)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(255, 24)
        Me.cboState.TabIndex = 362
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(117, 291)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 16)
        Me.Label9.TabIndex = 361
        Me.Label9.Text = "State"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(162, 96)
        Me.txtDescripcion.MaxLength = 500
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(495, 61)
        Me.txtDescripcion.TabIndex = 0
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(88, 97)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 16)
        Me.Label13.TabIndex = 359
        Me.Label13.Text = "frase (EN)"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.CmdGuardar)
        Me.Panel2.Controls.Add(Me.cmdExit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(795, 49)
        Me.Panel2.TabIndex = 356
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(290, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 25)
        Me.Label3.TabIndex = 383
        Me.Label3.Text = "Nueva Oracion"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdGuardar.Location = New System.Drawing.Point(608, 10)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(53, 32)
        Me.CmdGuardar.TabIndex = 2
        Me.CmdGuardar.Text = "Save"
        Me.CmdGuardar.UseVisualStyleBackColor = True
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
        'cboGrupo
        '
        Me.cboGrupo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(166, 318)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(254, 24)
        Me.cboGrupo.TabIndex = 369
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(111, 321)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 368
        Me.Label1.Text = "Grupo"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(51, 198)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(105, 16)
        Me.Label20.TabIndex = 365
        Me.Label20.Text = "Traduccion (ES)"
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
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(123, 60)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(33, 16)
        Me.lblTipo.TabIndex = 358
        Me.lblTipo.Text = "Item"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(166, 57)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(75, 22)
        Me.txtId.TabIndex = 357
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(460, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 381
        Me.Label2.Text = "Subtema"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSubtemaId
        '
        Me.txtSubtemaId.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtSubtemaId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtemaId.Location = New System.Drawing.Point(528, 62)
        Me.txtSubtemaId.Name = "txtSubtemaId"
        Me.txtSubtemaId.ReadOnly = True
        Me.txtSubtemaId.Size = New System.Drawing.Size(75, 22)
        Me.txtSubtemaId.TabIndex = 380
        Me.txtSubtemaId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(609, 53)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(73, 37)
        Me.Button3.TabIndex = 382
        Me.Button3.Text = "Subtema x Oracion"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'RichTextBoxEx1
        '
        'Me.RichTextBoxEx1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        'Me.RichTextBoxEx1.Location = New System.Drawing.Point(166, 369)
        'Me.RichTextBoxEx1.Name = "RichTextBoxEx1"
        'Me.RichTextBoxEx1.Size = New System.Drawing.Size(412, 47)
        'Me.RichTextBoxEx1.TabIndex = 370
        ''
        'cmdFoco
        '
        Me.cmdFoco.AutoSize = True
        Me.cmdFoco.Checked = True
        Me.cmdFoco.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cmdFoco.Location = New System.Drawing.Point(564, 269)
        Me.cmdFoco.Name = "cmdFoco"
        Me.cmdFoco.Size = New System.Drawing.Size(47, 17)
        Me.cmdFoco.TabIndex = 383
        Me.cmdFoco.Text = "foco"
        Me.cmdFoco.UseVisualStyleBackColor = True
        '
        'frmNewOracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(795, 452)
        Me.Controls.Add(Me.cmdFoco)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSubtemaId)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtTraduccion)
        '  Me.Controls.Add(Me.RichTextBoxEx1)
        Me.Controls.Add(Me.cboState)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.txtId)
        Me.Name = "frmNewOracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmNewOracion"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents txtTraduccion As System.Windows.Forms.TextBox
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList4 As System.Windows.Forms.ImageList
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSubtemaId As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Public WithEvents Label3 As System.Windows.Forms.Label
    ' Friend WithEvents RichTextBoxEx1 As RichTextBoxEx.RichTextBoxEx
    Friend WithEvents cmdFoco As System.Windows.Forms.CheckBox
End Class
