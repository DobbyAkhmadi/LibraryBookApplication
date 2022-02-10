Public Class L_Satu_Buku

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        If ComboBoxEx1.Text = "Pilih" Then
            MsgBox("Pilih Berdasarkan Kategori", vbInformation, "Pesan")
        ElseIf TextBoxX1.Text = "" Then
            MsgBox("Isikan Data Yang Di Cari", vbInformation, "Pesan")
        Else
            cryRpt.Load("Report\CR_Buku_Satu.rpt")
            CrystalReportViewer1.SelectionFormula = "{buku." & a & " }='" & TextBoxX1.Text & "'"
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
            a = "no_induk"
        ElseIf ComboBoxEx1.SelectedIndex = 1 Then
            a = "judul"
   
        End If
    End Sub

    Private Sub TextBoxX1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxX1.KeyDown
        If e.KeyCode = Keys.Return Then
            If ComboBoxEx1.Text = "Pilih" Then
                MsgBox("Pilih Berdasarkan Kategori", vbInformation, "Pesan")
            ElseIf TextBoxX1.Text = "" Then
                MsgBox("Isikan Data Yang Di Cari", vbInformation, "Pesan")
            Else
                cryRpt.Load("Report\CR_Buku_Satu.rpt")
                CrystalReportViewer1.SelectionFormula = "{buku." & a & " }='" & TextBoxX1.Text & "'"
                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.RefreshReport()
            End If
        End If
    End Sub

 
    Private Sub TextBoxX1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxX1.TextChanged
        Dim i As Integer = TextBoxX1.SelectionStart
        TextBoxX1.Text = StrConv(TextBoxX1.Text, VbStrConv.ProperCase)
        TextBoxX1.SelectionStart = i
    End Sub
End Class