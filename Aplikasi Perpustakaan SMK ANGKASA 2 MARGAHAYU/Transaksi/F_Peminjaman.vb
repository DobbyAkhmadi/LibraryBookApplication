Imports System.Data.SqlClient
Public Class F_Peminjaman
    '  Private Property tot As Double = 0
    Public tot As Double = 0
    Private Sub F_Peminjaman_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CBBUku.Items.Clear()
        CBNO.Items.Clear()
        LbNomer.Text = "-"
        LblTanggal.Text = "-"
        Lblkem.Text = "-"
        CBNO.Text = "Otomatis"
        LBNIS.Text = "-"
        LBNAMA.Text = "-"
        LBKELAS.Text = "-"
        LBALAMAT.Text = "-"
        CBBUku.Text = "Otomatis"
        Lbnamabuk.Text = "-"
        LBjudul.Text = "-"
        Txtjum.Text = ""
    End Sub

    Private Sub F_Peminjaman_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Txtjum.Enabled = 0
        mati(0)
        BtnTambah.Enabled = 0
        CBNO.Text = "Otomatis"
        CBBUku.Text = "Otomatis"
    End Sub
    Sub cekanggota()

        koneksi_database()
        sqlstr = "select no_ang from anggota"
        Try
            cmd = New SqlCommand(sqlstr, SQL_Kon)
            reader = cmd.ExecuteReader

            While reader.Read
                CBNO.Items.Add(reader.Item(0))
            End While

            cmd.Dispose()
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Sub cekbuku()
        koneksi_database()
        sqlstr = "select no_induk from buku"
        Try
            cmd = New SqlCommand(sqlstr, SQL_Kon)
            reader = cmd.ExecuteReader

            While reader.Read
                CBBUku.Items.Add(reader.Item(0))
            End While

            cmd.Dispose()
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Sub mati(ByVal x As Boolean)
        BtnBaru.Enabled = Not x
        BtnSimpan.Enabled = x
        BtnBatal.Enabled = x
        ' BtnCetak.Enabled = Not x
        GroupPanel1.Enabled = x
        GroupPanel2.Enabled = x
        GroupPanel4.Enabled = x
        ' BtnTambah.Enabled = x
    End Sub
    Sub otomatis_()
        koneksi_database()
        Dim no As String
        sqlstr = "select no_pinjam from h_pinjam where left (no_pinjam,4)='" & Now.ToString("yyMM") & "'order by no_pinjam desc"
        cmd = New SqlCommand(sqlstr, SQL_Kon)
        reader = cmd.ExecuteReader
        If reader.HasRows = False Then
            no = 1
        Else
            reader.Read()
            no = Val(reader.Item(0).ToString.Substring(4, 3)) + 1
        End If
        no = "000".Substring(0, 3 - Len(no)) + no
        LbNomer.Text = Now.ToString("yyMM") + no
        reader.Close()
        cmd.Dispose()
    End Sub
    Private Sub BtnBaru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBaru.Click
        otomatis_()
        CBNO.Text = "Otomatis"
        CBBUku.Text = "Otomatis"
        LblTanggal.Text = Now.ToString("dd/MMMM/yyyy")
        Dim t As Date
        t = DateAdd("d", 3, Now)
        Lblkem.Text = t.ToString("dd/MMMM/yyyy")
        hidup(1)
        mati(1)
        cekanggota()
        cekbuku()
    End Sub

    Sub hidup(ByVal a As Boolean)
        BtnBaru.Enabled = Not a
        BtnSimpan.Enabled = a
        BtnBatal.Enabled = a
        ' BtnCetak.Enabled = Not a
    End Sub
    Sub bersihbku()
        CBBUku.Text = "Cari Buku"
        Lbnamabuk.Text = "-"
        LBjudul.Text = "-"
        Txtjum.Clear()
    End Sub
    Private Sub BtnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBatal.Click
        Dim x As String
        x = MsgBox("Batal Input?", vbQuestion + vbYesNo, "Pesan")
        If x = vbYes Then
            mati(0)
            BtnTambah.Enabled = 0
            DataGridViewX1.Rows.Clear()
            CBNO.Text = "Cari Anggota"
            LBNIS.Text = "-"
            LBNAMA.Text = "-"
            LBKELAS.Text = "-"
            LBALAMAT.Text = "-"
            CBBUku.Text = "Cari Buku"
            Lbnamabuk.Text = "-"
            LBjudul.Text = "-"
            Txtjum.Clear()
            LbNomer.Text = "-"
            LblTanggal.Text = "-"
            Lblkem.Text = "-"
            '    LbJumlahey.Text = "-"
        End If
    End Sub

    Private Sub BtnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCari.Click
        'Me.Hide()
        F_CariBuku.ShowDialog()
    End Sub

    Private Sub BtnCariA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCariA.Click
        F_CariAnggota.ShowDialog()
    End Sub
 

    Private Sub CBNO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBNO.SelectedIndexChanged
        koneksi_database()
        sqlstr = "select * from anggota where no_ang = '" & CBNO.Text & "'"
        cmd = New SqlCommand(sqlstr, SQL_Kon)
        reader = cmd.ExecuteReader

        If reader.Read Then
            LBNIS.Text = reader.Item(1)
            LBNAMA.Text = reader.Item(2)
            LBKELAS.Text = reader.Item(4)
            LBALAMAT.Text = reader.Item(3)
        End If
        cmd.Dispose()
        reader.Close()
        SQL_Kon.Close()
    End Sub
    Private Sub BtnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTambah.Click
        Dim i As Integer

        If CBNO.Text = "Cari Anggota" Then
            MsgBox("Pilih Anggota Yang Akan Meminjam Buku", vbExclamation, "Pesan")
        ElseIf CBBUku.Text = "Cari Buku" Then
            MsgBox("Pilih Buku Yang Akan Dipinjam", vbExclamation, "Pesan")
        ElseIf Txtjum.Text = "" Then
            MsgBox("Isikan Jumlah Buku", vbExclamation, "Pesan")
        ElseIf Txtjum.Text > 3 Then
            MsgBox("Peminjaman Buku Maksimal 3 Buku", vbExclamation, "Pesan")
        Else
            DataGridViewX1.Rows.Add(CBBUku.Text, Lbnamabuk.Text, LBjudul.Text, Txtjum.Text)
            'For x As Integer = 0 To DataGridViewX1.RowCount - 1
            '    tot = tot + DataGridViewX1.Rows(x).Cells(3).Value
            'Next
            'LbJumlahey.Text = tot
            CBBUku.Text = "Cari Buku"
            Lbnamabuk.Text = "-"
            LBjudul.Text = "-"
            Txtjum.Clear()
            Txtjum.Enabled = 0
        End If
    End Sub



    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        Dim z As String
        z = MsgBox("Simpan Data Peminjaman?", vbQuestion + vbYesNo, "Pesan")
        If z = vbYes Then
            If CBNO.Text = "Cari Anggota" Then
                MsgBox("Pilih Anggota Yang Akan Meminjam Buku", vbExclamation, "Pesan")
            ElseIf CBBUku.Text <> "Cari Buku" Then
                MsgBox("Pilih Buku yang akan di pinjam", vbExclamation, "Pesan")
            Else
                koneksi_database()
                With cmd
                    .Connection = SQL_Kon
                    .CommandText = "insert into h_pinjam(no_pinjam,tgl_pinjam,tgl_harus_kem,no_ang,status,telat,denda) values (@1,@2,@3,@4,@5,@6,@7)"
                    .Parameters.AddWithValue("@1", LbNomer.Text)
                    .Parameters.AddWithValue("@2", LblTanggal.Text)
                    .Parameters.AddWithValue("@3", Lblkem.Text)
                    .Parameters.AddWithValue("@4", CBNO.Text)
                    .Parameters.AddWithValue("@5", pin)
                    .Parameters.AddWithValue("@6", 0)
                    .Parameters.AddWithValue("@7", 0)
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cmd.Parameters.Clear()

                With cmd
                    .Connection = SQL_Kon
                    .CommandText = "update anggota set status_pin='Pinjam' where no_ang=@1"
                    .Parameters.AddWithValue("@1", CBNO.Text)
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cmd.Parameters.Clear()

                For i As Integer = 0 To DataGridViewX1.RowCount - 1
                    With cmd
                        .Connection = SQL_Kon
                        .CommandText = "insert into d_pinjam values(@1,@2,@3,@4,@5,@6,@7)"
                        .Parameters.AddWithValue("@1", LbNomer.Text)
                        .Parameters.AddWithValue("@2", DataGridViewX1.Rows(i).Cells(0).Value)
                        .Parameters.AddWithValue("@3", DataGridViewX1.Rows(i).Cells(1).Value)
                        .Parameters.AddWithValue("@4", DataGridViewX1.Rows(i).Cells(2).Value)
                        .Parameters.AddWithValue("@5", DataGridViewX1.Rows(i).Cells(3).Value)
                        .Parameters.AddWithValue("@6", pin)
                        .Parameters.AddWithValue("@7", DataGridViewX1.Rows(i).Cells(3).Value)
                    End With
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    cmd.Parameters.Clear()

                    With cmd
                        .Connection = SQL_Kon
                        .CommandText = "update buku set stok=stok-@6 where no_induk=@7"
                        .Parameters.AddWithValue("@7", DataGridViewX1.Rows(i).Cells(0).Value)
                        .Parameters.AddWithValue("@6 ", DataGridViewX1.Rows(i).Cells(3).Value)
                    End With
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    cmd.Parameters.Clear()
                Next
                SQL_Kon.Close()
                MsgBox("Data Sudah Dimasukan", vbInformation, "Pesan")
                bersihuy()
            End If
        End If

    End Sub
    Sub bersihuy()
        mati(0)
        BtnTambah.Enabled = 0
        DataGridViewX1.Rows.Clear()
        CBNO.Text = "Cari Anggota"
        LBNIS.Text = "-"
        LBNAMA.Text = "-"
        LBKELAS.Text = "-"
        LBALAMAT.Text = "-"
        CBBUku.Text = "Cari Buku"
        Lbnamabuk.Text = "-"
        LBjudul.Text = "-"
        Txtjum.Clear()
        LbNomer.Text = "-"
        LblTanggal.Text = "-"
        Lblkem.Text = "-"
        '     LbJumlahey.Text = "-"
    End Sub


    'Private Sub DataGridViewX1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridViewX1.UserDeletedRow
    '    For x As Integer = 0 To DataGridViewX1.RowCount - 1
    '        tot = tot + DataGridViewX1.Rows(x).Cells(3).Value
    '    Next
    '    LbJumlahey.Text = tot
    'End Sub
    Private Sub DataGridViewX1_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridViewX1.UserDeletingRow
        Dim z As String
        z = MsgBox("Data Akan Di Hapus?", vbQuestion + vbYesNo, "Pesan")
        If z = vbNo Then
            e.Cancel = True
        End If
    End Sub
    Private Sub CBBUku_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBBUku.TextChanged
        koneksi_database()
        sqlstr = "select * from buku where no_induk = '" & CBBUku.Text & "'"
        cmd = New SqlCommand(sqlstr, SQL_Kon)
        reader = cmd.ExecuteReader
        If reader.Read Then
            Lbnamabuk.Text = reader(1)
            LBjudul.Text = reader(2)
            BtnTambah.Enabled = 1
        End If
        cmd.Dispose()
        reader.Close()
        SQL_Kon.Close()
    End Sub

   
    Private Sub Txtjum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtjum.KeyPress
        If Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

End Class