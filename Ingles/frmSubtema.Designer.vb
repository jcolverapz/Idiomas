<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubtema
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSubtema))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CmdVocabulario = New System.Windows.Forms.Button()
        Me.txtSubtema = New System.Windows.Forms.TextBox()
        Me.lblmod = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        ' Me.RichTextBoxEx1 = New RichTextBoxEx.RichTextBoxEx()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 800)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1435, 22)
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.CmdVocabulario)
        Me.Panel2.Controls.Add(Me.txtSubtema)
        Me.Panel2.Controls.Add(Me.lblmod)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.CmdGuardar)
        Me.Panel2.Controls.Add(Me.cmdExit)
        Me.Panel2.Controls.Add(Me.lblTipo)
        Me.Panel2.Controls.Add(Me.txtId)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1435, 49)
        Me.Panel2.TabIndex = 380
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1169, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 32)
        Me.Button1.TabIndex = 385
        Me.Button1.Text = "Oraciones"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CmdVocabulario
        '
        Me.CmdVocabulario.Location = New System.Drawing.Point(1087, 10)
        Me.CmdVocabulario.Name = "CmdVocabulario"
        Me.CmdVocabulario.Size = New System.Drawing.Size(76, 32)
        Me.CmdVocabulario.TabIndex = 384
        Me.CmdVocabulario.Text = "Vocabulario"
        Me.CmdVocabulario.UseVisualStyleBackColor = True
        '
        'txtSubtema
        '
        Me.txtSubtema.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtSubtema.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtema.Location = New System.Drawing.Point(136, 25)
        Me.txtSubtema.Name = "txtSubtema"
        Me.txtSubtema.ReadOnly = True
        Me.txtSubtema.Size = New System.Drawing.Size(656, 23)
        Me.txtSubtema.TabIndex = 383
        '
        'lblmod
        '
        Me.lblmod.AutoSize = True
        Me.lblmod.ForeColor = System.Drawing.Color.Black
        Me.lblmod.Location = New System.Drawing.Point(1036, 18)
        Me.lblmod.Name = "lblmod"
        Me.lblmod.Size = New System.Drawing.Size(16, 13)
        Me.lblmod.TabIndex = 94
        Me.lblmod.Text = "[ ]"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(810, 6)
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
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(97, 5)
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
        Me.txtId.Location = New System.Drawing.Point(136, 3)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(44, 22)
        Me.txtId.TabIndex = 381
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        'RichTextBoxEx1
        '
        'Me.RichTextBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill
        'Me.RichTextBoxEx1.Location = New System.Drawing.Point(0, 49)
        'Me.RichTextBoxEx1.Name = "RichTextBoxEx1"
        'Me.RichTextBoxEx1.Size = New System.Drawing.Size(1435, 773)
        'Me.RichTextBoxEx1.TabIndex = 390
        '
        'frmSubtema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1435, 822)
        Me.Controls.Add(Me.StatusStrip1)
        '  Me.Controls.Add(Me.RichTextBoxEx1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmSubtema"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmSubtema"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    'Friend WithEvents RichTextBoxEx1 As RichTextBoxEx.RichTextBoxEx
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblmod As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList4 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents txtSubtema As System.Windows.Forms.TextBox
    Friend WithEvents CmdVocabulario As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
