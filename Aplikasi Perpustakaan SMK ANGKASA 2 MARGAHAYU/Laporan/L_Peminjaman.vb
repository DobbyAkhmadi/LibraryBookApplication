Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Public Class L_GraPeminjaman_Buku
    Private Sub L_Peminjaman_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cryRpt.Load("Report\CR_Peminjaman.rpt")
        CrystalReportViewer1.SelectionFormula = "{h_pinjam.status} = 'Pinjam'"
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class