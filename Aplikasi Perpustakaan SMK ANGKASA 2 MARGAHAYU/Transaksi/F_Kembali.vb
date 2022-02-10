Imports System.Data.SqlClient
Public Class F_Kembali

    Private Sub F_Kembali_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi_database()
        Dim x As String
        sqlstr = "select * from h_pinjam where status='Pinjam'"
        Try
            cmd = New SqlCommand(sqlstr, SQL_Kon)
            reader = cmd.ExecuteReader()
            DataGridViewX1.Rows.Clear()
            Do While reader.Read()
                x = DataGridViewX1.Rows.Add()
                DataGridViewX1.Rows(x).Cells(0).Value = reader(0)
                DataGridViewX1.Rows(x).Cells(1).Value = reader(1)
                DataGridViewX1.Rows(x).Cells(2).Value = reader(2)
                DataGridViewX1.Rows(x).Cells(3).Value = reader(4)
                DataGridViewX1.Rows(x).Cells(4).Value = reader(5)
            Loop
            cmd.Dispose()
        Finally
            If reader IsNot Nothing Then reader.Close()
        End Try

    End Sub

    Private Sub DataGridViewX1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentClick
        Try
            Call koneksi_database()
            Dim xcz As String = ("select foto from anggota where no_ang='" & DataGridViewX1.Item(3, DataGridViewX1.CurrentRow.Index).Value & "'")
            cmd = New SqlCommand(xcz, SQL_Kon)
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            PictureBox1.Image = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            SQL_Kon.Close()
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub DataGridViewX1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentDoubleClick
        Dim a As String
        Dim b As String
        a = DataGridViewX1.Item(0, DataGridViewX1.CurrentRow.Index).Value.ToString
        F_Pengembalian.CBPinjam.Text = a
        b = DataGridViewX1.Item(3, DataGridViewX1.CurrentRow.Index).Value.ToString
        F_Pengembalian.CBAng.Text = b
        F_Pengembalian.BtnSimpan.Enabled = 1
        Me.Hide()
    End Sub
End Class