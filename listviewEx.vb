Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices

Namespace ListViewCustomReorder
    ''' <summary> 
    ''' A slightly extended version of the standard ListView. 
    ''' </summary> 
    Public Class ListViewEx
        Inherits ListView

        Private Const WM_PAINT As Integer = &HF

        ' The LVItem being dragged 
        Private _itemDnD As ListViewItem = Nothing
        'The mouseover LVItem
        Dim itemOver As ListViewItem = Nothing

        Public Sub New()
            ' Reduce flicker 
            Me.DoubleBuffered = True
        End Sub

        Protected Overloads Overrides Sub WndProc(ByRef m As Message)
            MyBase.WndProc(m)

            ' We have to take this way (instead of overriding OnPaint()) because the ListView is just a wrapper 
            ' around the common control ListView and unfortunately does not call the OnPaint overrides. 
            If m.Msg = WM_PAINT Then
                If itemOver Is Nothing Then Return
                If itemOver.Index >= 0 AndAlso itemOver.Index < Items.Count AndAlso _itemDnD IsNot Nothing Then
                    Dim rc As Rectangle = Items(itemOver.Index).GetBounds(ItemBoundsPortion.Entire)
                    rc.Width = MyBase.ClientRectangle.Width
                    If _itemDnD.Index > itemOver.Index Then
                        DrawInsertionLine(rc.Left, rc.Right, rc.Top)
                    ElseIf _itemDnD.Index < itemOver.Index Then
                        DrawInsertionLine(rc.Left, rc.Right, rc.Bottom)
                    End If
                End If
                End If
        End Sub

        ''' <summary> 
        ''' Draw a line with insertion marks at each end 
        ''' </summary> 
        ''' <param name="X1">Starting position (X) of the line</param> 
        ''' <param name="X2">Ending position (X) of the line</param> 
        ''' <param name="Y">Position (Y) of the line</param> 
        Private Sub DrawInsertionLine(ByVal X1 As Integer, ByVal X2 As Integer, ByVal Y As Integer)
            Using g As Graphics = Me.CreateGraphics()
                g.DrawLine(Pens.Red, X1, Y, X2 - 1, Y)

                Dim leftTriangle As Point() = New Point(2) {New Point(X1, Y - 4), New Point(X1 + 7, Y), New Point(X1, Y + 4)}
                Dim rightTriangle As Point() = New Point(2) {New Point(X2, Y - 4), New Point(X2 - 8, Y), New Point(X2, Y + 4)}
                g.FillPolygon(Brushes.Red, leftTriangle)
                g.FillPolygon(Brushes.Red, rightTriangle)
            End Using
        End Sub

        Dim effectCursor As Cursor

        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)
            _itemDnD = MyBase.GetItemAt(e.X, e.Y)
            effectCursor = Cursors.Hand
            Dim rc As Rectangle = Items(_itemDnD.Index).GetBounds(ItemBoundsPortion.Entire)
            Dim img As New Bitmap(rc.Width + 17, rc.Height + 22)
            Dim gr As Graphics = Graphics.FromImage(img)
            gr.Clear(Color.FromArgb(250, 250, 250))
            ' effectCursor.Draw(gr, Rectangle.Round(img.GetBounds(Drawing.GraphicsUnit.Pixel)))
            '   effectCursor.Draw(gr, Rectangle.Round(img.GetBounds(Drawing.)))
            For x As Integer = 0 To _itemDnD.SubItems.Count - 1
                gr.DrawString(_itemDnD.SubItems(x).Text, MyBase.Font, New SolidBrush(SystemColors.Highlight), _itemDnD.SubItems(x).Bounds.Left + 17, 22)
            Next
            img.MakeTransparent(Color.FromArgb(250, 250, 250))
            effectCursor = CreateCursor(img)
            itemOver = Nothing
            ' Show the user that a drag operation is happening 
            Cursor = effectCursor
            ' invalidate the LV so that the insertion line is shown 
            MyBase.Invalidate()
            
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)

            If _itemDnD IsNot Nothing Then
                ' Show the user that a drag operation is happening 
                Cursor = effectCursor
            End If

            ' use 0 instead of e.X so that you don't have to keep inside the columns while dragging 
            itemOver = MyBase.GetItemAt(0, e.Y)

            If itemOver Is Nothing Then
                ' invalidate the LV so that the insertion line is shown 
                MyBase.Invalidate()
                Cursor = Cursors.Default
                Return
            End If

            If _itemDnD IsNot Nothing Then
                MyBase.Items(itemOver.Index).Selected = True
                MyBase.FocusedItem = itemOver
            End If

            ' invalidate the LV so that the insertion line is shown 
            MyBase.Invalidate()
        End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
            itemOver = Nothing
            ' invalidate the LV so that the insertion line is removed 
            MyBase.Invalidate()
            MyBase.OnMouseLeave(e)
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(e)

            If _itemDnD Is Nothing Then
                Return
            End If

            Try

                If itemOver Is Nothing Then
                    ' finish drag&drop operation 
                    _itemDnD = Nothing
                    Cursor = Cursors.Default
                    Return
                End If

                If _itemDnD IsNot itemOver Then
                    ' if we dropped the item on itself, nothing is to be done 
                    If itemOver.Index > _itemDnD.Index Then
                        MyBase.Items.Remove(_itemDnD)
                        MyBase.Items.Insert(itemOver.Index + 1, _itemDnD)
                    Else
                        MyBase.Items.Remove(_itemDnD)
                        MyBase.Items.Insert(itemOver.Index, _itemDnD)
                    End If
                End If

                MyBase.Items(_itemDnD.Index).Selected = True
                MyBase.FocusedItem = _itemDnD
                itemOver = _itemDnD

                MyBase.Invalidate()
            Finally
                ' finish drag&drop operation 
                _itemDnD = Nothing
                Cursor = Cursors.Default
            End Try
        End Sub

#Region "   CreateIconIndirect"

        Private Structure IconInfo
            Public fIcon As Boolean
            Public xHotspot As Int32
            Public yHotspot As Int32
            Public hbmMask As IntPtr
            Public hbmColor As IntPtr
        End Structure

        <DllImport("user32.dll", EntryPoint:="CreateIconIndirect")> _
        Private Shared Function CreateIconIndirect(ByVal iconInfo As IntPtr) As IntPtr
        End Function

        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function DestroyIcon(ByVal handle As IntPtr) As Boolean
        End Function

        <DllImport("gdi32.dll")> _
        Public Shared Function DeleteObject(ByVal hObject As IntPtr) As Boolean
        End Function

        ''' <summary>
        ''' CreateCursor
        ''' </summary>
        ''' <param name="bmp"></param>
        ''' <returns>custom Cursor</returns>
        ''' <remarks>creates a custom cursor from a bitmap</remarks>
        Public Function CreateCursor(ByVal bmp As Bitmap) As Cursor
            'Setup the Cursors IconInfo
            Dim tmp As New IconInfo
            tmp.xHotspot = 0
            tmp.yHotspot = 0
            tmp.fIcon = False
            tmp.hbmMask = bmp.GetHbitmap()
            tmp.hbmColor = bmp.GetHbitmap()

            'Create the Pointer for the Cursor Icon
            Dim pnt As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(tmp))
            Marshal.StructureToPtr(tmp, pnt, True)
            Dim curPtr As IntPtr = CreateIconIndirect(pnt)

            'Clean Up
            DestroyIcon(pnt)
            DeleteObject(tmp.hbmMask)
            DeleteObject(tmp.hbmColor)

            Return New Cursor(curPtr)
        End Function

#End Region

    End Class
End Namespace

