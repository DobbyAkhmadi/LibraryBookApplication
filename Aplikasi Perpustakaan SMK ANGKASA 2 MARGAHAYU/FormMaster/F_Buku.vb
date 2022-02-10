Imports System.Data.SqlClient
Public Class F_Buku
    Public aas As String
    Private Sub F_Buku_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim x As Integer
        x = MsgBox("Keluar Form Buku?", vbQuestion + vbYesNo, "Pesan")
        If x = vbYes Then
            DataGridViewX1.Rows.Clear()
            Me.Hide()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub F_Buku_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BtnRefresh.Focus()
        mati_Grup(0)
        mati_buton(0)
        GroupPanel2.Enabled = 0
    End Sub
    Sub mati_Grup(ByVal x As Boolean)
        GroupPanel1.Enabled = x
    End Sub
    Sub mati_buton(ByVal a As Boolean)
        BtnBaru.Enabled = Not a
        BtnSimpan.Enabled = a
        BtnUbah.Enabled = a
        BtnHapus.Enabled = a
        BtnBatal.Enabled = a

    End Sub
    Sub simpan(ByVal q As Boolean)
        BtnBaru.Enabled = Not q
        BtnSimpan.Enabled = q
        BtnBatal.Enabled = q
    End Sub
  
    Sub cb_cari()
        CbCari.Items.Clear()
        CbCari.Items.Add("Nama Pengarang")
        CbCari.Items.Add("Judul")
    End Sub
    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Tampil_Data()
        GroupPanel2.Enabled = 1
        cb_cari()
    End Sub

    Private Sub BtnBaru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBaru.Click
        Auto()
        bersih2()
        GroupPanel1.Enabled = 1
        simpan(True)
        TxtNmaPeng.Focus()
        DataGridViewX1.Enabled = 0
    End Sub

    Private Sub BtnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBatal.Click
        Dim x As String
        x = MsgBox("Batal Input?", vbQuestion + vbYesNo, "Pesan")
        If x = vbYes Then
            mati_Grup(0)
            mati_buton(0)
            GroupPanel2.Enabled = 0
            bersih()
            DataGridViewX1.Enabled = 1

        End If
    End Sub

    Private Sub BtnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCari.Click
        If CbCari.Text = "Pilih" Then
            MsgBox("Pilih Berdasarkan", vbInformation, "Pesan")
        Else
            tampil()
        End If
    End Sub


#Region "Validasi"

    Private Sub TxtNmaPeng_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNmaPeng.KeyPress
        If ((e.KeyChar >= "0" And e.KeyChar <= "9") Or (e.KeyChar >= "!" And e.KeyChar <= "+")) Then
            e.Handled() = True
        End If
    End Sub
    Private Sub TxtNmaPeng_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNmaPeng.TextChanged
        Dim i As Integer = TxtNmaPeng.SelectionStart
        TxtNmaPeng.Text = StrConv(TxtNmaPeng.Text, VbStrConv.ProperCase)
        TxtNmaPeng.SelectionStart = i
    End Sub

    Private Sub Txtjudul_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtjudul.KeyPress
        If ((e.KeyChar >= "0" And e.KeyChar <= "9") Or (e.KeyChar >= "!" And e.KeyChar <= "+")) Then
            e.Handled() = True
        End If
    End Sub
    Private Sub Txtjudul_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtjudul.TextChanged
        Dim i As Integer = Txtjudul.SelectionStart
        Txtjudul.Text = StrConv(Txtjudul.Text, VbStrConv.ProperCase)
        Txtjudul.SelectionStart = i
    End Sub

    Private Sub TxtKota_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtKota.KeyPress
        If ((e.KeyChar >= "0" And e.KeyChar <= "9") Or (e.KeyChar >= "!" And e.KeyChar <= "+")) Then
            e.Handled() = True
        End If
    End Sub
    Private Sub TxtKota_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKota.TextChanged
        Dim i As Integer = TxtKota.SelectionStart
        TxtKota.Text = StrConv(TxtKota.Text, VbStrConv.ProperCase)
        TxtKota.SelectionStart = i
    End Sub

    Private Sub TxtNama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNama.KeyPress
        If ((e.KeyChar >= "0" And e.KeyChar <= "9") Or (e.KeyChar >= "!" And e.KeyChar <= "+")) Then
            e.Handled() = True
        End If
    End Sub
    Private Sub TxtNama_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNama.TextChanged
        Dim i As Integer = TxtNama.SelectionStart
        TxtNama.Text = StrConv(TxtNama.Text, VbStrConv.ProperCase)
        TxtNama.SelectionStart = i
    End Sub

    Private Sub TxtKunci_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtKunci.KeyDown
        If e.KeyCode = Keys.Return Then
            If CbCari.Text = "Pilih" Then
                MsgBox("Cari Berdasarkan Kategori")
                TxtKunci.Clear()
            Else
                tampil()
            End If
        End If
    End Sub
    Private Sub TxtKunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKunci.TextChanged
        Dim i As Integer = TxtKunci.SelectionStart
        TxtKunci.Text = StrConv(TxtKunci.Text, VbStrConv.ProperCase)
        TxtKunci.SelectionStart = i
    End Sub
    Private Sub CbCari_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbCari.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled() = True
        End If
        If ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled() = True
        End If
    End Sub
#End Region

#Region "DML"
    Private Sub Tampil_Data()
        Call koneksi_database()
        sqlstr = "Select * from buku"
        Try
            cmd = New SqlCommand(sqlstr, SQL_Kon)
            reader = cmd.ExecuteReader()
            DataGridViewX1.Rows.Clear()
            Do While reader.Read()
                x = DataGridViewX1.Rows.Add()
                DataGridViewX1.Rows(x).Cells(0).Value = reader(0)
                DataGridViewX1.Rows(x).Cells(1).Value = reader(1)
                DataGridViewX1.Rows(x).Cells(2).Value = reader(2)
                DataGridViewX1.Rows(x).Cells(3).Value = reader(3)
                DataGridViewX1.Rows(x).Cells(4).Value = reader(4)
                DataGridViewX1.Rows(x).Cells(5).Value = reader(5)
                DataGridViewX1.Rows(x).Cells(6).Value = reader(6)
                DataGridViewX1.Rows(x).Cells(7).Value = reader(7)
            Loop
        Finally
            If reader IsNot Nothing Then reader.Close()
        End Try
        SQL_Kon.Close()
    End Sub
    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        If TxtNmaPeng.Text = "" Then
            MsgBox("Isikan Nama Pengarang", vbExclamation, "Pesan")
        ElseIf Txtjudul.Text = "" Then
            MsgBox("Isikan Judul", vbExclamation, "Pesan")
        ElseIf TxtKota.Text = "" Then
            MsgBox("Isikan Nama Kota", vbExclamation, "Pesan")
        ElseIf TxtNama.Text = "" Then
            MsgBox("Isikan Nama Penerbit", vbExclamation, "Pesan")
        ElseIf TxtTahun.Text = "" Then
            MsgBox("Isikan Tahun", vbExclamation, "Pesan")
        ElseIf TxtStok.Text = "" Then
            MsgBox("Isikan Stok Awal", vbExclamation, "Pesan")
        Else
            Dim a As String
            a = MsgBox("Simpan Data?", vbQuestion + vbYesNo, "Pesan")
            If a = vbYes Then
                Try
                    Call koneksi_database()
                    With cmd
                        .Connection = SQL_Kon
                        .CommandText = "insert into buku values (@1,@2,@3,@4,@5,@6,@7,@8)"
                        .Parameters.AddWithValue("@1", TxtNo.Text)
                        .Parameters.AddWithValue("@2", TxtNmaPeng.Text)
                        .Parameters.AddWithValue("@3", Txtjudul.Text)
                        .Parameters.AddWithValue("@4", TxtKota.Text)
                        .Parameters.AddWithValue("@5", TxtNama.Text)
                        .Parameters.AddWithValue("@6", TxtTahun.Text)
                        .Parameters.AddWithValue("@7", Txtper.Text)
                        .Parameters.AddWithValue("@8", TxtStok.Text)
                    End With
                    cmd.ExecuteNonQuery()
                    MsgBox("Data Telah Di Simpan", vbInformation, "Pesan")
                    Tampil_Data()
                    DataGridViewX1.Enabled = True
                    mati_buton(0)
                    mati_Grup(0)
                    Call bersih()
                    cmd.Dispose()
                    cmd.Parameters.Clear()
                    SQL_Kon.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
        
    End Sub

    Private Sub BtnUbah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbah.Click
        Dim x As String
        x = MsgBox("Ubah Data?", vbQuestion + MsgBoxStyle.YesNo, "Pesan")
        If x = vbYes Then
            Try
                Call koneksi_database()
                sqlstr = "update buku set [nama]=@1,[judul]=@2,[kota]=@3,[penerbit]=@4,[tahun]=@5,[perolehan]=@6,[stok]=@8 where [no_induk]=@7"
                cmd = New SqlCommand(sqlstr, SQL_Kon)
                cmd.Parameters.AddWithValue("@7", TxtNo.Text)
                cmd.Parameters.AddWithValue("@1", TxtNmaPeng.Text)
                cmd.Parameters.AddWithValue("@2", Txtjudul.Text)
                cmd.Parameters.AddWithValue("@3", TxtKota.Text)
                cmd.Parameters.AddWithValue("@4", TxtNama.Text)
                cmd.Parameters.AddWithValue("@5", TxtTahun.Text)
                cmd.Parameters.AddWithValue("@6", Txtper.Text)
                cmd.Parameters.AddWithValue("@8", TxtStok.Text)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                Call Tampil_Data()
                mati_buton(0)
                mati_Grup(0)
                Call bersih()
                MsgBox("Data Berhasil Di Ubah", vbInformation, "Pesan")
                SQL_Kon.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHapus.Click
        Dim x As String
        x = MsgBox("Hapus Data?", vbQuestion + MsgBoxStyle.YesNo, "Pesan")
        If x = vbYes Then
            Try
                koneksi_database()
                cmd = New SqlCommand("delete buku where no_induk='" & DataGridViewX1.Item(0, DataGridViewX1.CurrentRow.Index).Value.ToString & "'", SQL_Kon)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                MsgBox("Data Telah Di Hapus", vbInformation, "Pesan")
                Call Tampil_Data()
                mati_buton(0)
                mati_Grup(0)
                Call bersih()
                SQL_Kon.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
#End Region

    Sub Auto()
        Call koneksi_database()
        Dim strku As String
        Call koneksi_database()
        cmd = New SqlCommand("select count(*) from buku", SQL_Kon)
        strku = cmd.ExecuteScalar + 1
        strku = "0000".Substring(1, 4 - Len(strku)) + strku
        'substring sama kek middle
        TxtNo.Text = "BKU" + Now.ToString("ddMMyy") + strku
        cmd.Dispose()
        SQL_Kon.Close()
    End Sub

    Private Sub DataGridViewX1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick

        Try
            x = DataGridViewX1.CurrentCell.RowIndex
            TxtNo.Text = DataGridViewX1.Rows(x).Cells(0).Value.ToString
            TxtNmaPeng.Text = DataGridViewX1.Rows(x).Cells(1).Value.ToString
            Txtjudul.Text = DataGridViewX1.Rows(x).Cells(2).Value.ToString
            TxtKota.Text = DataGridViewX1.Rows(x).Cells(3).Value.ToString
            TxtNama.Text = DataGridViewX1.Rows(x).Cells(4).Value.ToString
            TxtTahun.Text = DataGridViewX1.Rows(x).Cells(5).Value.ToString
            Txtper.Text = DataGridViewX1.Rows(x).Cells(6).Value.ToString
            TxtStok.Text = DataGridViewX1.Rows(x).Cells(7).Value.ToString
        Catch ex As Exception

        End Try
      
    End Sub

    Private Sub DataGridViewX1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentDoubleClick
        BtnUbah.Enabled = 1
        BtnHapus.Enabled = 1
        BtnBatal.Enabled = 1
        BtnBaru.Enabled = 0
        GroupPanel1.Enabled = 1
    End Sub
    Sub bersih2()
        Txtjudul.Clear()
        TxtKota.Clear()
        TxtKunci.Clear()
        TxtNama.Clear()
        TxtNmaPeng.Clear()
        TxtStok.Clear()
        Txtper.Clear()
        TxtTahun.Clear()
    End Sub
    Sub bersih()
        Txtjudul.Clear()
        TxtKota.Clear()
        TxtKunci.Clear()
        TxtNama.Clear()
        TxtNmaPeng.Clear()
        TxtNo.Clear()
        Txtper.Clear()
        TxtTahun.Clear()
        TxtStok.Clear()
    End Sub



  
    Private Sub CbCari_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbCari.SelectedIndexChanged

        If CbCari.SelectedIndex = 0 Then
            aas = "nama"
        ElseIf CbCari.SelectedIndex = 1 Then
            aas = "judul"
        ElseIf CbCari.SelectedIndex = 2 Then
            aas = "kota"
        ElseIf CbCari.SelectedIndex = 3 Then
            aas = "tahun"
        End If
    End Sub

    Sub tampil()
        SQL_Kon.Open()
        Dim x As String
        sqlstr = "select * from buku where " & aas & " like'%" & TxtKunci.Text & "%'"
        Try
            cmd = New SqlCommand(sqlstr, SQL_Kon)
            reader = cmd.ExecuteReader()
            DataGridViewX1.Rows.Clear()
            Do While reader.Read()
                x = DataGridViewX1.Rows.Add()
                DataGridViewX1.Rows(x).Cells(0).Value = reader(0)
                DataGridViewX1.Rows(x).Cells(1).Value = reader(1)
                DataGridViewX1.Rows(x).Cells(2).Value = reader(2)
                DataGridViewX1.Rows(x).Cells(3).Value = reader(3)
                DataGridViewX1.Rows(x).Cells(4).Value = reader(4)
                DataGridViewX1.Rows(x).Cells(5).Value = reader(5)
                DataGridViewX1.Rows(x).Cells(6).Value = reader(6)
            Loop
            cmd.Dispose()
        Finally
            If reader IsNot Nothing Then reader.Close()
        End Try
        SQL_Kon.Close()
    End Sub

    Private Sub TxtTahun_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTahun.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8))) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub Txtper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtper.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8))) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtStok_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtStok.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8))) Then
            e.KeyChar = ""
        End If
    End Sub
End Class