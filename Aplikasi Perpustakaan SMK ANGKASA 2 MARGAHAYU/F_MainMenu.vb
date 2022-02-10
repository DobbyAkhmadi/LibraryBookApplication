Public Class F_MainMenu

    Private Sub F_MainMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim x As Integer
        x = MsgBox("Keluar Aplikasi?", vbQuestion + vbYesNo, "Pesan")
        If x = vbYes Then
            MsgBox("Terima Kasih", vbInformation, "Pesan")
            Me.Hide()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub ButtonItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem7.Click
        Dim x As Integer
        x = MsgBox("Keluar Aplikasi?", vbQuestion + vbYesNo, "Pesan")
        If x = vbYes Then
            MsgBox("Terima Kasih", vbInformation, "Pesan")
            Me.Hide()
            F_Login.Show()
        End If

    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        F_Backup_Database.ShowDialog()
    End Sub

    Private Sub ButtonItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem6.Click
        F_Konfigurasi.ShowDialog()
    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        F_Buku.ShowDialog()
    End Sub

    Private Sub ButtonItem8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItem8.Click
        F_Anggota.ShowDialog()
    End Sub

    Private Sub ButtonItem9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItem9.Click
        F_Peminjaman.ShowDialog()
        F_Peminjaman.CBNO.Text = "Cari Anggota"
        F_Peminjaman.CBBUku.Text = "Cari Buku"

    End Sub

    Private Sub ButtonItem15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItem15.Click
        L_Satu_Anggota.ShowDialog()
    End Sub

    Private Sub ButtonItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem16.Click
        L_Semua_Anggota.ShowDialog()
    End Sub


    Private Sub ButtonItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem17.Click
        L_Konfirmasi_Kartu.ShowDialog()
    End Sub

    Private Sub ButtonItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem12.Click
        L_Satu_Buku.ShowDialog()
    End Sub

    Private Sub ButtonItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem13.Click
        L_Semua_Buku.ShowDialog()
    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Tentang.ShowDialog()
    End Sub

    Private Sub ButtonItem11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItem11.Click
        L_GraPeminjaman_Buku.ShowDialog()
    End Sub

    Private Sub ButtonItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem10.Click
        F_Pengembalian.ShowDialog()
    End Sub

    Private Sub ButtonItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem18.Click
        F_Backup_Database.ShowDialog()
    End Sub

    Private Sub ButtonItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem19.Click
        F_DatabaseRestore.ShowDialog()
    End Sub

    Private Sub ButtonItem22_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        L_Grafik_Buku.ShowDialog()
    End Sub

    Private Sub ButtonItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem23.Click
        L_Grafik_Anggota.ShowDialog()
    End Sub

    Private Sub ButtonItem14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItem14.Click
        L_Pengembalian.ShowDialog()
    End Sub


    Private Sub ButtonItem24_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItem24.Click
        L_Denda_.ShowDialog()
    End Sub

    Private Sub ButtonItem2_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
        L_Peminjaman_Anggota.ShowDialog()
    End Sub

    Private Sub ButtonItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem21.Click
        L_Grafik_Buku.ShowDialog()
    End Sub

    Private Sub ButtonItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem20.Click
        L_Grafik_Pinjam_Anggota.ShowDialog()
    End Sub

    Private Sub ButtonItem22_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem22.Click
        Tentang.ShowDialog()
    End Sub

    Private Sub ButtonItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem25.Click
        L_Buku_Rusak.ShowDialog()
    End Sub

    Private Sub ButtonItem3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem3.Click
        Help.ShowHelp(Me, "PERANGKAT LUNAK PENGOLAHAN DATA BUKU PADA BAGIAN PERPUSTAKAAN.chm")

    End Sub

    Private Sub ButtonItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem26.Click
        L_Periode.ShowDialog()
    End Sub
End Class