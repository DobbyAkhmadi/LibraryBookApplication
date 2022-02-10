Imports System.Data.SqlClient
Public Class F_Pengembalian

  

    Private Sub F_Pengembalian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ButtonX2.Enabled = 0
        BtnBaru.Enabled = 1
        TxtKem.Enabled = 0
        BtnCariA.Enabled = 0
        BtnSimpan.Enabled = 0
        ButtonX2.Enabled = 0
        BtnBatal.Enabled = 0
        GroupPanel2.Enabled = 0
        Txtkembali.Enabled = 0
        CBPinjam.Items.Clear()
        CBAng.Items.Clear()
        CBPinjam.Text = "Otomatis"
        LBDenda.Text = "-"
        LbTelat.Text = "-"
        LblTanggal.Text = "-"
        LbBuku.Text = "-"
        TxtKem.Text = ""
        CBAng.Text = "Otomatis"
        LBNIS.Text = "-"
        LBNAMA.Text = "-"
        LBKELAS.Text = "-"
        LbBuku.Text = "-"
        TxtKem.Text = ""
        LbHarus.Text = "-"
        LabelX13.Text = "-"
        DateTimePicker1.Value = Now
        '  DateTimePicker2.Enabled = 0
        '  DateTimePicker2.Value = Now
    End Sub
    Sub tampil()
        Call koneksi_database()
        sqlstr = "Select * from d_pinjam where no_pinjam='" & CBPinjam.Text & "'"
        Try
            cmd = New SqlCommand(sqlstr, SQL_Kon)
            reader = cmd.ExecuteReader()
            DataGridViewX1.Rows.Clear()
            Do While reader.Read() = True
                x = DataGridViewX1.Rows.Add()
                DataGridViewX1.Rows(x).Cells(0).Value = reader(1)
                DataGridViewX1.Rows(x).Cells(1).Value = reader(2)
                DataGridViewX1.Rows(x).Cells(2).Value = reader(3)
                DataGridViewX1.Rows(x).Cells(3).Value = reader(4)
                DataGridViewX1.Rows(x).Cells(4).Value = reader(5)
                DataGridViewX1.Rows(x).Cells(5).Value = reader(4)

            Loop
        Finally
            If reader IsNot Nothing Then reader.Close()
        End Try
        SQL_Kon.Close()
    End Sub


    Private Sub BtnCariA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCariA.Click
        F_Kembali.ShowDialog()
    End Sub
    Sub cekanggota()
        koneksi_database()
        sqlstr = "select no_ang from anggota"
        Try
            cmd = New SqlCommand(sqlstr, SQL_Kon)
            reader = cmd.ExecuteReader

            While reader.Read
                CBAng.Items.Add(reader.Item(0))
            End While

            cmd.Dispose()
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Sub cekpinjam()
        koneksi_database()
        sqlstr = "select no_pinjam from h_pinjam"
        Try
            cmd = New SqlCommand(sqlstr, SQL_Kon)
            reader = cmd.ExecuteReader

            While reader.Read
                CBPinjam.Items.Add(reader.Item(0))
            End While

            cmd.Dispose()
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub


    Private Sub BtnBaru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBaru.Click

        BtnCariA.Enabled = 1
        cekanggota()
        cekpinjam()
        BtnBaru.Enabled = 0
        Txtkembali.Enabled = 1
        BtnBatal.Enabled = 1
        LbHarus.Text = "-"
    End Sub

    Private Sub BtnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBatal.Click
        Dim s As String
        s = MsgBox("Batal?", vbQuestion + vbYesNo, "Pesan")
        If s = vbYes Then
            BtnSimpan.Enabled = 0
            BtnBatal.Enabled = 0
            BtnBaru.Enabled = 1
            Txtkembali.Enabled = 0
            BtnCariA.Enabled = 0
            DataGridViewX1.Rows.Clear()
            CBPinjam.Text = "Otomatis"
            LBDenda.Text = "-"
            LbTelat.Text = "-"
            LbBuku.Text = "-"
            TxtKem.Text = ""
            LblTanggal.Text = "-"
            LbHarus.Text = "-"
            CBAng.Text = "Otomatis"
            LBNIS.Text = "-"
            LabelX13.Text = "-"
            LBNAMA.Text = "-"
            LBKELAS.Text = "-"
            ButtonX2.Enabled = 0
            ' DateTimePicker2.Enabled = 0
        End If
    End Sub

    Private Sub DataGridViewX1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick
        Txtkembali.Enabled = 0
        x = DataGridViewX1.CurrentCell.RowIndex
        LbBuku.Text = DataGridViewX1.Rows(x).Cells(0).Value.ToString
        TxtKem.Text = DataGridViewX1.Rows(x).Cells(3).Value.ToString
        LbKembalii.Text = DataGridViewX1.Rows(x).Cells(4).Value.ToString
    End Sub

    Private Sub DataGridViewX1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentDoubleClick
        If DataGridViewX1.Rows(x).Cells(4).Value = "Kembali" Then
            GroupPanel2.Enabled = 0
            TxtKem.Enabled = 0
            Txtkembali.Enabled = 0
            MsgBox("Buku Sudah Kembali", vbExclamation, "Pesan")
        Else
            GroupPanel2.Enabled = 1
            TxtKem.Enabled = 1
            Txtkembali.Enabled = 1
        End If

    End Sub

    Private Sub TxtKem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKem.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8))) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub Txtkembali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtkembali.Click
        Dim s As String
        s = MsgBox("Kembalikan " & TxtKem.Text & " Buku?", vbQuestion + vbYesNo, "Pesan")
        If s = vbYes Then
            If TxtKem.Text = "" Then
                MsgBox("Isikan Jumlah Buku", vbInformation, "Pesan")
            ElseIf TxtKem.Text > 3 Then
                MsgBox("Tidak Boleh Lebih Dari 3 Buku", vbInformation, "Pesan")
            ElseIf DataGridViewX1.Rows(x).Cells(3).Value < 0 Then
                MsgBox("Buku Sudah Dikembalikan", vbInformation, "Pesan")
            Else
                koneksi_database()
                With cmd
                    .Connection = SQL_Kon
                    .CommandText = "update d_pinjam set jumlah=jumlah - @2 where no_induk=@1 and no_pinjam=@3"
                    .Parameters.AddWithValue("@1", LbBuku.Text)
                    .Parameters.AddWithValue("@2", DataGridViewX1.Rows(x).Cells(3).Value)
                    .Parameters.AddWithValue("@3", CBPinjam.Text)
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cmd.Parameters.Clear()

                With cmd
                    .Connection = SQL_Kon
                    .CommandText = "update d_pinjam set status='Kembali'  where no_induk=@1 and no_pinjam=@2"
                    .Parameters.AddWithValue("@1", LbBuku.Text)
                    .Parameters.AddWithValue("@2", CBPinjam.Text)
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cmd.Parameters.Clear()

                MsgBox("" & TxtKem.Text & " Buku Telah Dikembalikan !", vbInformation, "Pesan")
                DataGridViewX1.Rows(x).Cells(3).Value = DataGridViewX1.Rows(x).Cells(3).Value - Val(TxtKem.Text)
                If DataGridViewX1.Rows(x).Cells(3).Value = 0 Then
                    DataGridViewX1.Rows(x).Cells(4).Value = "Kembali"
                    LbKembalii.Text = "-"
                    LbBuku.Text = "-"
                    TxtKem.Enabled = 0
                    TxtKem.Text = ""
                    Txtkembali.Enabled = 0
                End If
            End If
        End If


    End Sub

    Private Sub CBPinjam_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBPinjam.TextChanged
        koneksi_database()
        Dim tgl As Date
        sqlstr = "SELECT * from H_Pinjam where no_pinjam = '" & CBPinjam.Text & "'"
        cmd = New SqlCommand(sqlstr, SQL_Kon)
        reader = cmd.ExecuteReader
        If reader.Read Then
            LblTanggal.Text = reader(1)
            LbHarus.Text = reader(2)
            LabelX13.Text = Now.ToString("dd/MMM/yyyy")
            tgl = reader(1)
        End If
        LbHarus.Text = Format(DateAdd(DateInterval.Day, 3, tgl), "dd/MMM/yyyy")
        DateTimePicker1.Focus()
        LbTelat.Text = DateDiff(DateInterval.Day, tgl, DateTimePicker1.Value)
        If LbTelat.Text <= 3 Then
            LbTelat.Text = 0
        Else
            LbTelat.Text = LbTelat.Text - 3
        End If
        LBDenda.Text = CDbl(LbTelat.Text) * 500
        tampil()
        cmd.Dispose()
        reader.Close()
        SQL_Kon.Close()

    End Sub


    Private Sub CBAng_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBAng.TextChanged
        koneksi_database()
        sqlstr = "select * from anggota where no_ang = '" & CBAng.Text & "'"
        cmd = New SqlCommand(sqlstr, SQL_Kon)
        reader = cmd.ExecuteReader
        If reader.Read Then
            LBNIS.Text = reader(1)
            LBNAMA.Text = reader(2)
            LBKELAS.Text = reader(4)
        End If

        cmd.Dispose()
        reader.Close()
        SQL_Kon.Close()
    End Sub

    Private Sub TxtKem_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKem.KeyUp
        If Val(TxtKem.Text) < 0 Then
            MsgBox("Tidak Boleh Kurang Dari 1 Buku", vbInformation, "Pesan")
            TxtKem.Clear()
        ElseIf Val(TxtKem.Text) > 3 Then
            MsgBox("Tidak Boleh Lebih Dari 3 Buku", vbInformation, "Pesan")
            TxtKem.Clear()
        End If
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        Dim a As String
        a = MsgBox("Simpan Data?", vbQuestion + vbYesNo, "Pesan")
        If a = vbYes Then
            koneksi_database()
            'If DateTimePicker2.Value < Now Then
            '    MsgBox("Waktu Perpanjangan Tidak Boleh Kurang Dari Tanggal Sekarang", vbExclamation, "Pesan")
            'Else
            For i As Integer = 0 To DataGridViewX1.RowCount - 1
                With cmd
                    .Connection = SQL_Kon
                    .CommandText = "select * from d_pinjam where status='Pinjam' and no_pinjam=@1"
                    .Parameters.AddWithValue("@1", CBPinjam.Text)
                    ' .Parameters.AddWithValue("@2", CBAng.Text)
                End With
                reader = cmd.ExecuteReader
                If reader.HasRows = 0 Then
                    With cmd
                        .Connection = SQL_Kon
                        .CommandText = "update h_pinjam set status=@11 where no_pinjam=@22 and no_ang=@33 "
                        .Parameters.AddWithValue("@22", CBPinjam.Text)
                        .Parameters.AddWithValue("@33", CBAng.Text)
                        .Parameters.AddWithValue("@11", "Kembali")
                    End With
                    reader.Close()
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    cmd.Parameters.Clear()
                End If
                reader.Close()

                With cmd
                    .Connection = SQL_Kon
                    .CommandText = "update buku set [stok]=[stok] + @71 where no_induk=@61"
                    .Parameters.AddWithValue("@61", DataGridViewX1.Rows(i).Cells(0).Value)
                    .Parameters.AddWithValue("@71 ", DataGridViewX1.Rows(i).Cells(5).Value)
                    .Parameters.AddWithValue("@70 ", CBPinjam.Text)
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cmd.Parameters.Clear()

                sqlstr = "update h_pinjam set tgl_kmbali=@5, telat=@2,denda=@3 where no_pinjam=@4"
                cmd = New SqlCommand(sqlstr, SQL_Kon)
                cmd.Parameters.AddWithValue("@4", CBPinjam.Text)
                cmd.Parameters.AddWithValue("@2", LbTelat.Text)
                cmd.Parameters.AddWithValue("@3", LBDenda.Text)
                cmd.Parameters.AddWithValue("@5", LabelX13.Text)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cmd.Parameters.Clear()

                sqlstr = "update anggota set status_pin='Tidak Meminjam' where no_ang=@1"
                cmd = New SqlCommand(sqlstr, SQL_Kon)
                cmd.Parameters.AddWithValue("@1", CBAng.Text)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cmd.Parameters.Clear()

            Next
            SQL_Kon.Close()
            MsgBox("Data Telah Tersimpan", vbInformation, "Pesan")
            BtnSimpan.Enabled = 0
            BtnBatal.Enabled = 0
            BtnBaru.Enabled = 1
            Txtkembali.Enabled = 0
            BtnCariA.Enabled = 0
            ' DateTimePicker2.Enabled = 0
            DataGridViewX1.Rows.Clear()
            CBPinjam.Text = "Otomatis"
            LBDenda.Text = "-"
            LbTelat.Text = "-"
            LbBuku.Text = "-"
            TxtKem.Text = ""
            LblTanggal.Text = "-"
            LbHarus.Text = "-"
            CBAng.Text = "Otomatis"
            LBNIS.Text = "-"
            LBNAMA.Text = "-"
            LBKELAS.Text = "-"
            ButtonX2.Enabled = 0
            LabelX13.Enabled = 0
        End If
        reader.Close()
        '  End If

    End Sub


    Private Sub ButtonX2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX2.Click
        F_Buku_Rusak.ShowDialog()
    End Sub

    Private Sub LblTanggal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LblTanggal.TextChanged
        ButtonX2.Enabled = 1
    End Sub





End Class