Imports System.Data.SqlClient
Public Class F_Buku_Rusak

    Sub cekbuku()
        Cb_Buku.Items.Clear()
        koneksi_database()
        sqlstr = "select * from d_pinjam where no_pinjam='" & F_Pengembalian.CBPinjam.Text & "' "
        Try
            cmd = New SqlCommand(sqlstr, SQL_Kon)
            reader = cmd.ExecuteReader
            While reader.Read
                Cb_Buku.Items.Add(reader.Item(1))
            End While
            cmd.Dispose()
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
  

    Private Sub Btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsimpan.Click
        If Cb_Buku.Text = "Pilih" Then
            MsgBox("Pilih Buku", vbExclamation, "Pesan")
        ElseIf TxtKondisi.Text = "" Then
            MsgBox("Isikan Data Kondisi Buku Max 100%", vbExclamation, "Pesan")
        ElseIf Txtjml.Text = "" Then
            MsgBox("Jumlah Tidak Boleh Kosong", vbExclamation, "Pesan")
        Else
            If CInt(TxtKondisi.Text) > 30 Then
                MsgBox("Kondisi Buku Tidak boleh lebih dari 30%", vbExclamation, "Pesan")
            ElseIf Txtjml.Text > Lbjumlah.Text Then
                MsgBox("Jumlah Buku Tidak Boleh Melebihi " & Lbjumlah.Text, vbExclamation, "Pesan")
            Else
                koneksi_database()
                With cmd
                    .Connection = SQL_Kon
                    .CommandText = "insert into buku_rusak values(@1,@2,@3,@4,@5)"
                    .Parameters.AddWithValue("@1", Cb_Buku.Text)
                    .Parameters.AddWithValue("@2", lbjudul.Text)
                    .Parameters.AddWithValue("@3", lbnama.Text)
                    .Parameters.AddWithValue("@4", TxtKondisi.Text)
                    .Parameters.AddWithValue("@5", Txtjml.Text)
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cmd.Parameters.Clear()

                With cmd
                    .Connection = SQL_Kon
                    .CommandText = "update buku set stok=stok-@6 where no_induk='" & Cb_Buku.Text & "'"
                    .Parameters.AddWithValue("@6", Txtjml.Text)
                End With
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cmd.Parameters.Clear()

                MsgBox("Data Telah Di Simpan", vbInformation, "Pesan")
                bersih()
                Me.Hide()
            End If
        End If

    End Sub
    Sub bersih()
        Cb_Buku.Items.Clear()
        Cb_Buku.Text = "Pilih"
        lbjudul.Text = "-"
        lbnama.Text = "-"
        Lbjumlah.Text = "-"
        Txtjml.Clear()
        Txtjml.Clear()
    End Sub
   
    Private Sub F_Buku_Rusak_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        bersih()
    End Sub

    Private Sub F_Buku_Rusak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Txtjml.Enabled = 0
        TxtKondisi.Enabled = 0
        cekbuku()
    End Sub

    Private Sub Cb_Buku_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb_Buku.SelectedIndexChanged
        koneksi_database()
        sqlstr = "select * from d_pinjam where no_induk = '" & Cb_Buku.Text & "'and no_pinjam='" & F_Pengembalian.CBPinjam.Text & "'"
        cmd = New SqlCommand(sqlstr, SQL_Kon)
        reader = cmd.ExecuteReader
        If reader.Read Then
            lbnama.Text = reader.Item(2)
            lbjudul.Text = reader.Item(3)
            Lbjumlah.Text = reader.Item(4)
        End If
        cmd.Dispose()
        reader.Close()
        SQL_Kon.Close()
    End Sub

    Private Sub lbjudul_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbjudul.TextChanged
        Txtjml.Enabled = 1
        TxtKondisi.Enabled = 1
    End Sub


End Class