Public Class L_Peminjaman_Anggota

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        cryRpt.Load("Report\CR_Anggota_Satu_List_Pinjam.rpt")
        CrystalReportViewer1.SelectionFormula = "{h_pinjam." & a & " }='" & TextBoxX1.Text & "'"
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.RefreshReport()
    End Sub
    Dim a As String = "no_ang"

    Private Sub ComboBoxEx1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled() = True
        End If
        If ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled() = True
        End If
    End Sub

    Private Sub TextBoxX1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxX1.KeyDown
        If e.KeyCode = Keys.Return Then
            BtnSimpan_Click(sender, e)
        End If
    End Sub

    Private Sub TextBoxX1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxX1.KeyPress
        If Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxX1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX1.TextChanged
        Dim i As Integer = TextBoxX1.SelectionStart
        TextBoxX1.Text = StrConv(TextBoxX1.Text, VbStrConv.ProperCase)
        TextBoxX1.SelectionStart = i
    End Sub

    Private Sub L_Peminjaman_Anggota_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cryRpt.Load("Report\CR_Anggota_Semua.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class