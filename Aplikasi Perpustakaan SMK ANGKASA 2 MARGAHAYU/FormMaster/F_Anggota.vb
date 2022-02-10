Imports System.Data.SqlClient
Imports System.IO
Public Class F_Anggota

    Private Sub F_Member_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim x As Integer
        x = MsgBox("Keluar Form Anggota?", vbQuestion + vbYesNo, "Pesan")
        If x = vbYes Then
            Me.Hide()
        Else
            e.Cancel = True
        End If
    End Sub
    Sub prodi()
        CbPilih.Items.Add("ADM")
        CbPilih.Items.Add("PEMASARAN ")
    End Sub
    Private Sub Tampil_Data()
        Call koneksi_database()
        sqlstr = "Select * from anggota"
        Try
            cmd = New SqlCommand(sqlstr, SQL_Kon)
            reader = cmd.ExecuteReader()
            DataGridViewX1.Rows.Clear()
            Do While reader.Read() = True
                x = DataGridViewX1.Rows.Add()
                DataGridViewX1.Rows(x).Cells(0).Value = reader(0)
                DataGridViewX1.Rows(x).Cells(1).Value = reader(1)
                DataGridViewX1.Rows(x).Cells(2).Value = reader(2)
                DataGridViewX1.Rows(x).Cells(3).Value = reader(3)
                DataGridViewX1.Rows(x).Cells(4).Value = reader(4)
            Loop
        Finally
            If reader IsNot Nothing Then reader.Close()
        End Try
        SQL_Kon.Close()
    End Sub
    Sub otomatis_()
        koneksi_database()
        Dim no As String
        sqlstr = "select no_ang from anggota where left (no_ang,4)='" & Now.ToString("yyMM") & "'order by no_ang desc"
        cmd = New SqlCommand(sqlstr, SQL_Kon)
        reader = cmd.ExecuteReader
        If reader.HasRows = False Then
            no = 1
        Else
            reader.Read()
            no = Val(reader.Item(0).ToString.Substring(4, 3)) + 1
        End If
        no = "000".Substring(0, 3 - Len(no)) + no
        TxtNo.Text = Now.ToString("yyMM") + no
        reader.Close()
        cmd.Dispose()
    End Sub
    Sub bersih()
        TxtNo.Clear()
        TxtNis.Clear()
        TxtNama.Clear()
        TxtAlama.Clear()
        CbPilih.Text = "Pilih"
    End Sub
    Sub bersih2()

        TxtNis.Clear()
        TxtNama.Clear()
        TxtAlama.Clear()
        CbPilih.Text = "Pilih"
    End Sub
    Private Sub F_Member_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Tampil_Data()
        mati(0)
        GroupPanel1.Enabled = 0
        tombol(0)
    End Sub
    Sub mati(ByVal ax As Boolean)
        BtnBaru.Enabled = Not ax
        BtnSimpan.Enabled = ax
        BtnUbah.Enabled = ax
        BtnHapus.Enabled = ax
        BtnBatal.Enabled = ax
        PictureBox1.Enabled = ax
    End Sub
    Sub tombol(ByVal b As Boolean)
        BtnBaru.Enabled = Not b
        BtnSimpan.Enabled = b
        BtnBatal.Enabled = b
    End Sub
    Private Sub BtnBaru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBaru.Click
        otomatis_()
        DataGridViewX1.Enabled = 0
        PictureBox1.Image = My.Resources.no_photo_female
        GroupPanel1.Enabled = 1
        PictureBox1.Enabled = 1
        bersih2()
        tombol(1)
        prodi()
    End Sub

    Private Sub BtnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBatal.Click
        Dim x As String
        x = MsgBox("Batal Input?", vbQuestion + vbYesNo, "Pesan")
        If x = vbYes Then
            mati(0)
            bersih()
            GroupPanel1.Enabled = 0
            tombol(0)
            DataGridViewX1.Enabled = True
            CbPilih.Items.Clear()
            PictureBox1.Image = My.Resources.no_photo_female
        End If
    End Sub


    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        If TxtNis.Text = "" Then
            MsgBox("Masukan NIS Siswa", vbExclamation, "Pesan")
        ElseIf TxtNama.Text = "" Then
            MsgBox("Masukan Nama Siswa", vbExclamation, "Pesan")
        ElseIf TxtAlama.Text = "" Then
            MsgBox("Masukan Alamat Siswa", vbExclamation, "Pesan")
        ElseIf CbPilih.Text = "Pilih" Then
            MsgBox("Pilih Prodi/Jurusan", vbExclamation, "Pesan")
        Else
            Try
                Call koneksi_database()
                Dim ms As New MemoryStream()
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                With cmd
                    .CommandText = "select * from anggota where nis='" + TxtNis.Text + "'"
                End With
                reader = cmd.ExecuteReader
                If reader.HasRows Then
                    MsgBox("NIS Tidak Boleh Ada Yang Sama", vbExclamation, "Pesan")
                Else
                    With cmd
                        .Connection = SQL_Kon
                        .CommandText = "insert into anggota values (@1,@2,@3,@4,@5,@6,@7)"
                        .Parameters.AddWithValue("@1", TxtNo.Text)
                        .Parameters.AddWithValue("@2", TxtNis.Text)
                        .Parameters.AddWithValue("@3", TxtNama.Text)
                        .Parameters.AddWithValue("@4", TxtAlama.Text)
                        .Parameters.AddWithValue("@5", CbPilih.Text)
                        .Parameters.AddWithValue("@7", tdk)
                        Dim data As Byte() = ms.GetBuffer()
                        Dim p As New SqlParameter("@6", SqlDbType.Image)
                        p.Value = data
                        cmd.Parameters.Add(p)
                    End With
                    cmd.ExecuteNonQuery()
                    MsgBox("Data Telah Di Simpan", vbInformation, "Pesan")
                    Tampil_Data()
                    DataGridViewX1.Enabled = True
                    cmd.Dispose()
                    cmd.Parameters.Clear()
                    mati(0)
                    GroupPanel1.Enabled = False
                    bersih()
                    CbPilih.Items.Clear()

                    PictureBox1.Image = My.Resources.no_photo_female
                    SQL_Kon.Close()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

                reader.Close()
       
    End Sub

    Private Sub DataGridViewX1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick
        x = DataGridViewX1.CurrentCell.RowIndex
        TxtNo.Text = DataGridViewX1.Rows(x).Cells(0).Value.ToString
        TxtNis.Text = DataGridViewX1.Rows(x).Cells(1).Value.ToString
        TxtNama.Text = DataGridViewX1.Rows(x).Cells(2).Value.ToString
        TxtAlama.Text = DataGridViewX1.Rows(x).Cells(3).Value.ToString
        CbPilih.Text = DataGridViewX1.Rows(x).Cells(4).Value.ToString
        Call koneksi_database()
        Dim xcz As String = ("select foto from anggota where no_ang='" & DataGridViewX1.Item(0, DataGridViewX1.CurrentRow.Index).Value & "'")
        cmd = New SqlCommand(xcz, SQL_Kon)
        Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
        PictureBox1.Image = Image.FromStream(ImgStream)
        ImgStream.Dispose()
        SQL_Kon.Close()
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

    Private Sub TxtAlama_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAlama.TextChanged
        Dim i As Integer = TxtAlama.SelectionStart
        TxtAlama.Text = StrConv(TxtAlama.Text, VbStrConv.ProperCase)
        TxtAlama.SelectionStart = i
    End Sub

    Private Sub CbPilih_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbPilih.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled() = True
        End If
        If ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled() = True
        End If
    End Sub

    Private Sub TxtNis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNis.KeyPress
        If Not (((e.KeyChar >= Chr(48)) And (e.KeyChar <= Chr(57))) Or (e.KeyChar = Chr(8))) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Try
            OpenFileDialog1.Filter = "Image Files|*.jpg;*.png;*.bmp"
            OpenFileDialog1.ShowDialog()
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DataGridViewX1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentDoubleClick
        BtnUbah.Enabled = 1
        BtnHapus.Enabled = 1
        BtnBatal.Enabled = 1
        BtnBaru.Enabled = 0
        GroupPanel1.Enabled = 1
        prodi()
        PictureBox1.Enabled = True
    End Sub

    Private Sub BtnUbah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbah.Click
        Dim x As String
        x = MsgBox("Ubah Data?", vbQuestion + vbYesNo, "Pesan")
        If x = vbYes Then
            If CbPilih.Text = "Pilih" Then
                MsgBox("Pilih Prodi", vbExclamation, "Pesan")
                CbPilih.Items.Clear()
                prodi()
            Else
                Try
                    Call koneksi_database()
                    Dim ms As New MemoryStream()
                    PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                    sqlstr = "update anggota set [nis]=@1,[nama]=@2,[alamat]=@3,[prodi]=@4,[foto]=@5 where [no_ang]=@6"
                    cmd = New SqlCommand(sqlstr, SQL_Kon)
                    cmd.Parameters.AddWithValue("@1", TxtNis.Text)
                    cmd.Parameters.AddWithValue("@2", TxtNama.Text)
                    cmd.Parameters.AddWithValue("@3", TxtAlama.Text)
                    cmd.Parameters.AddWithValue("@4", CbPilih.Text)
                    cmd.Parameters.AddWithValue("@6", TxtNo.Text)
                    Dim data As Byte() = ms.GetBuffer()
                    Dim p As New SqlParameter("@5", SqlDbType.Image)
                    p.Value = data
                    cmd.Parameters.Add(p)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    Call Tampil_Data()
                    Call bersih()
                    mati(0)
                    CbPilih.Items.Clear()
                    GroupPanel1.Enabled = False
                    MsgBox("Data Telah Di Ubah", vbInformation, "Pesan")
                    SQL_Kon.Close()
                Catch ex As Exception
                    MsgBox("Pilih Poto Kembali", vbExclamation, "Pesan")
                End Try

            End If
        End If
       
    End Sub

    Private Sub BtnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHapus.Click
        Dim x As String
        x = MsgBox("Hapus Data?", vbQuestion + vbYesNo, "Pesan")
        If x = vbYes Then
            Try
                koneksi_database()
                cmd = New SqlCommand("delete anggota where no_ang='" & DataGridViewX1.Item(0, DataGridViewX1.CurrentRow.Index).Value.ToString & "'", SQL_Kon)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                MsgBox("Data Telah Di Hapus", vbInformation, "Pesan")
                Call Tampil_Data()
                mati(0)
                GroupPanel1.Enabled = 0
                tombol(0)
                PictureBox1.Image = My.Resources.no_photo_female
                Call bersih()
                SQL_Kon.Close()
            Catch ex As Exception
                MsgBox("Maaf Data Tidak Bisa Di Hapus Karena Masih Meminjam Buku", vbInformation, "Pesan")
            End Try
        End If

    End Sub

End Class