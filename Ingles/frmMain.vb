Public Class frmMain

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Rows.Add("Process 1", 10)
        DataGridView1.Rows.Add("Process 2", 99)
        DataGridView1.Rows.Add("Process 3", 81)
        DataGridView1.Rows.Add("Process 4", -41)
    End Sub
End Class