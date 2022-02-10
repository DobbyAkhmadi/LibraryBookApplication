Public Class L_Konfirmasi_Kartu
    Dim a As String
    Private Sub L_Konfirmasi_Kartu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
    End Sub

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
            a = "nis"
        End If
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        If ComboBoxEx1.Text = "Pilih" Then
            MsgBox("Pilih Berdasarkan Kategori", vbInformation, "Pesan")
        ElseIf TextBoxX1.Text = "" Then
            MsgBox("Isikan Data Yang Di Cari", vbInformation, "Pesan")
        Else
            Me.Hide()

            cryRpt.Load("Report\CR_Anggota_Kartu.rpt")
            L_Kartu_Anggota.CrystalReportViewer1.SelectionFormula = "{anggota." & a & " }='" & TextBoxX1.Text & "'"
            L_Kartu_Anggota.CrystalReportViewer1.ReportSource = cryRpt
            L_Kartu_Anggota.CrystalReportViewer1.RefreshReport()
            L_Kartu_Anggota.ShowDialog()
        End If
    End Sub

    Private Sub TextBoxX1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxX1.KeyDown
        If e.KeyCode = Keys.Return Then
            If ComboBoxEx1.Text = "Pilih" Then
                MsgBox("Pilih Berdasarkan Kategori", vbInformation, "Pesan")
            ElseIf TextBoxX1.Text = "" Then
                MsgBox("Isikan Data Yang Di Cari", vbInformation, "Pesan")
            Else
                Me.Hide()
                L_Kartu_Anggota.Show()
                cryRpt.Load("Report\CR_Anggota_Kartu.rpt")
                L_Kartu_Anggota.CrystalReportViewer1.SelectionFormula = "{anggota." & a & " }='" & TextBoxX1.Text & "'"
                L_Kartu_Anggota.CrystalReportViewer1.ReportSource = cryRpt
                L_Kartu_Anggota.CrystalReportViewer1.RefreshReport()

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
End Class