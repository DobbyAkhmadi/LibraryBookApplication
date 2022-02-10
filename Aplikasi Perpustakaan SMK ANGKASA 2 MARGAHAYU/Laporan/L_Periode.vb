Public Class L_Periode


    Private Sub L_Periode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimeInput1.Value = Now.ToString("dd/MMM/yyyy")
        DateTimeInput2.Value = Now.ToString("dd/MMM/yyyy")
       
    End Sub


    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        
            If DateTimeInput1.Value > DateTimeInput2.Value Then
                MsgBox("Tanggal Periode Tidak Bisa Kurang  ", vbInformation, "Pesan")
                DateTimeInput1.Value = Now.ToString("dd/MMM/yyyy")
                DateTimeInput2.Value = Now.ToString("dd/MMM/yyyy")
            Else
                MsgBox("Dari Tanggal    " & DateTimeInput1.Value.ToString("dd/MMM/yyyy") & "   Sampai Dengan   " & DateTimeInput2.Value.ToString("dd/MMM/yyyy") & MsgBoxStyle.OkOnly)
                cryRpt.Load("Report\CR_Peminjaman_Periode.rpt")
                L_Peminjaman_Periode.CrystalReportViewer1.SelectionFormula = "date({H_PINJAM.TGL_PINJAM}) >= #" & DateTimeInput1.Value & "# and date({H_PINJAM.TGL_PINJAM})<=#" & DateTimeInput2.Value & "#"
                L_Peminjaman_Periode.CrystalReportViewer1.ReportSource = cryRpt
                L_Peminjaman_Periode.CrystalReportViewer1.RefreshReport()
                L_Peminjaman_Periode.ShowDialog()
        End If


    End Sub
End Class