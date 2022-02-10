Public Class L_Semua_Anggota

    Private Sub L_Semua_Anggota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cryRpt.Load("Report\CR_Anggota_Semua.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class