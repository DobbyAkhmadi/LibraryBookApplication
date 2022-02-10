Public Class L_Satu_Anggota

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        If ComboBoxEx1.Text = "Pilih" Then
            MsgBox("Pilih Berdasarkan Kategori", vbInformation, "Pesan")
        ElseIf TextBoxX1.Text = "" Then
            MsgBox("Isikan Data Yang Di Cari", vbInformation, "Pesan")
        Else
            cryRpt.Load("Report\CR_Anggota_Satu.rpt")
            CrystalReportViewer1.SelectionFormula = "{anggota." & a & " }='" & TextBoxX1.Text & "'"
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.RefreshReport()
        End If

    End Sub
    Dim a As String

    Private Sub ComboBoxEx1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBoxEx1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled() = True
        End If
        If ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled() = True
        End If
    End Sub

    Private Sub ComboBoxEx1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxEx1.SelectedIndexChanged
        If ComboBoxEx1.SelectedIndex = 0 Then
            a = "no_ang"
        ElseIf ComboBoxEx1.SelectedIndex = 1 Then
            a = "nama"
        ElseIf ComboBoxEx1.SelectedIndex = 2 Then
            a = "nis"
        End If
    End Sub

    Private Sub TextBoxX1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxX1.KeyDown
        If e.KeyCode = Keys.Return Then
            If ComboBoxEx1.Text = "Pilih" Then
                MsgBox("Pilih Berdasarkan Kategori", vbInformation, "Pesan")
            ElseIf TextBoxX1.Text = "" Then
                MsgBox("Isikan Data Yang Di Cari", vbInformation, "Pesan")
            Else
                cryRpt.Load("Report\CR_Anggota_Satu.rpt")
                CrystalReportViewer1.SelectionFormula = "{anggota." & a & " }='" & TextBoxX1.Text & "'"
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
            End If
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
End Class