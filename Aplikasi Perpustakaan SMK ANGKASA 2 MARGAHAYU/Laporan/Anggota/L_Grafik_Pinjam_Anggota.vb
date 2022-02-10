Public Class L_Grafik_Pinjam_Anggota

    Private Sub L_Semua_Anggota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cryRpt.Load("Report\CR_Anggota_Grafik_Pinjam.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class