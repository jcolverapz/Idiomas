<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetVocabulario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDetVocabulario))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtTraduccion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbConversation = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        'Me.RichTextBoxEx1 = New RichTextBoxEx.RichTextBoxEx()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboState = New System.Windows.Forms.ComboBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblmod = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.chkContentWord = New System.Windows.Forms.CheckBox()
        Me.chkUsadas = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(681, 208)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(277, 104)
        Me.WebBrowser1.TabIndex = 397
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 793)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1223, 22)
        Me.StatusStrip1.TabIndex = 392
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStatus
        '
        Me.ToolStatus.Name = "ToolStatus"
        Me.ToolStatus.Size = New System.Drawing.Size(39, 17)
        Me.ToolStatus.Text = "Status"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(728, 104)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(230, 24)
        Me.cmbGrupo.TabIndex = 389
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
        Me.txtTraduccion.Location = New System.Drawing.Point(135, 269)
        Me.txtTraduccion.MaxLength = 500
        Me.txtTraduccion.Multiline = True
        Me.txtTraduccion.Name = "txtTraduccion"
        Me.txtTraduccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTraduccion.Size = New System.Drawing.Size(420, 43)
        Me.txtTraduccion.TabIndex = 391
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(610, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 388
        Me.Label1.Text = "Grupo"
        '
        'cmbConversation
        '
        Me.cmbConversation.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbConversation.FormattingEnabled = True
        Me.cmbConversation.Location = New System.Drawing.Point(728, 134)
        Me.cmbConversation.Name = "cmbConversation"
        Me.cmbConversation.Size = New System.Drawing.Size(231, 24)
        Me.cmbConversation.TabIndex = 396
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(611, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 16)
        Me.Label4.TabIndex = 395
        Me.Label4.Text = "Conversation"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(221, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 14)
        Me.Label3.TabIndex = 394
        Me.Label3.Text = "Agregar"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(224, 52)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 41)
        Me.Button3.TabIndex = 393
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'RichTextBoxEx1
        '
        ' Me.RichTextBoxEx1.Location = New System.Drawing.Point(134, 162)
        ' Me.RichTextBoxEx1.Name = "RichTextBoxEx1"
        ' Me.RichTextBoxEx1.Size = New System.Drawing.Size(412, 92)
        ' Me.RichTextBoxEx1.TabIndex = 390
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(24, 272)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(105, 16)
        Me.Label20.TabIndex = 387
        Me.Label20.Text = "Traduccion (ES)"
        '
        'cboState
        '
        Me.cboState.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboState.FormattingEnabled = True
        Me.cboState.Items.AddRange(New Object() {"APRENDI", "Falta APRENDER"})
        Me.cboState.Location = New System.Drawing.Point(728, 74)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(231, 24)
        Me.cboState.TabIndex = 386
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(134, 115)
        Me.txtDescripcion.MaxLength = 500
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(412, 43)
        Me.txtDescripcion.TabIndex = 384
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(59, 115)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 16)
        Me.Label13.TabIndex = 383
        Me.Label13.Text = "frase (EN)"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblmod)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.CmdGuardar)
        Me.Panel2.Controls.Add(Me.cmdExit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1223, 49)
        Me.Panel2.TabIndex = 380
        '
        'lblmod
        '
        Me.lblmod.AutoSize = True
        Me.lblmod.ForeColor = System.Drawing.Color.Black
        Me.lblmod.Location = New System.Drawing.Point(748, 18)
        Me.lblmod.Name = "lblmod"
        Me.lblmod.Size = New System.Drawing.Size(16, 13)
        Me.lblmod.TabIndex = 94
        Me.lblmod.Text = "[ ]"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(467, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(59, 41)
        Me.Button4.TabIndex = 355
        Me.Button4.Text = "Nueva Oracion"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = True
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdGuardar.Location = New System.Drawing.Point(875, 10)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(53, 32)
        Me.CmdGuardar.TabIndex = 91
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(611, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 16)
        Me.Label9.TabIndex = 385
        Me.Label9.Text = "State"
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
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(88, 63)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(33, 16)
        Me.lblTipo.TabIndex = 382
        Me.lblTipo.Text = "Item"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(131, 60)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(75, 22)
        Me.txtId.TabIndex = 381
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkContentWord
        '
        Me.chkContentWord.AutoSize = True
        Me.chkContentWord.Location = New System.Drawing.Point(728, 173)
        Me.chkContentWord.Name = "chkContentWord"
        Me.chkContentWord.Size = New System.Drawing.Size(109, 17)
        Me.chkContentWord.TabIndex = 398
        Me.chkContentWord.Text = "No Content Word"
        Me.chkContentWord.UseVisualStyleBackColor = True
        '
        'chkUsadas
        '
        Me.chkUsadas.AutoSize = True
        Me.chkUsadas.Location = New System.Drawing.Point(875, 173)
        Me.chkUsadas.Name = "chkUsadas"
        Me.chkUsadas.Size = New System.Drawing.Size(85, 17)
        Me.chkUsadas.TabIndex = 399
        Me.chkUsadas.Text = "Mas Usadas"
        Me.chkUsadas.UseVisualStyleBackColor = True
        '
        'FrmDetVocabulario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1223, 815)
        Me.Controls.Add(Me.chkUsadas)
        Me.Controls.Add(Me.chkContentWord)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.txtTraduccion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbConversation)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        '  Me.Controls.Add(Me.RichTextBoxEx1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cboState)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.txtId)
        Me.Name = "FrmDetVocabulario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FrmDetVocabulario"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txtTraduccion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbConversation As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    ' Friend WithEvents RichTextBoxEx1 As RichTextBoxEx.RichTextBoxEx
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblmod As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList4 As System.Windows.Forms.ImageList
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Public WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents chkContentWord As System.Windows.Forms.CheckBox
    Friend WithEvents chkUsadas As System.Windows.Forms.CheckBox
End Class
