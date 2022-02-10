Public Class L_Denda_

    Private Sub L_Grafik_Buku_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cryRpt.Load("Report\CR_Denda.rpt")
        CrystalReportViewer1.SelectionFormula = "{h_pinjam.telat} > 0"
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class