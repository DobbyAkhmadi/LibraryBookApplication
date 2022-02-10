Public Class L_Buku_Rusak

   
    Private Sub L_Buku_Rusak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cryRpt.Load("Report\CR_Buku_Rusak.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class