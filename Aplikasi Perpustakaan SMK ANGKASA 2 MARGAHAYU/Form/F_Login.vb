Imports System.Data.SqlClient
Public Class F_Login

    Private Sub F_Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtUser.ShortcutsEnabled = 0
        TxtPass.ShortcutsEnabled = 0
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub Btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnok.Click
        If TxtUser.Text = "" Then
            MsgBox("Isikan Data Pengguna", vbExclamation, "Pesan")
        ElseIf TxtPass.Text = "" Then
            MsgBox("Isikan Sandi Pengguna", vbExclamation, "Pesan")
        Else
            koneksi_database()
            sqlstr = "select * from login where username='" & TxtUser.Text & "'and password='" & TxtPass.Text & "'"
            cmd = New SqlCommand(sqlstr, SQL_Kon)
            reader = cmd.ExecuteReader
            While reader.Read
                If reader.Item(2) = "Administrator" Then
                    MsgBox("Selamat Datang Di Aplikasi Perpustakaan", vbInformation, "Pesan")
                    F_MainMenu.RibbonPanel4.Enabled = 0
                    F_MainMenu.Lbuser.Text = reader(0)
                    F_MainMenu.Lbakses.Text = reader(2)
                    Me.Hide()
                    F_MainMenu.Show()
                ElseIf reader.Item(2) = "SuperAdmin" Then
                    MsgBox("Selamat Datang Di Aplikasi Perpustakaan", vbInformation, "Pesan")
                    F_MainMenu.RibbonPanel4.Enabled = 1
                    F_MainMenu.Lbuser.Text = reader(0)
                    F_MainMenu.Lbakses.Text = reader(2)
                    Me.Hide()
                    F_MainMenu.Show()
                End If
                    TxtPass.Clear()
                    TxtUser.Clear()
            End While
        End If

    End Sub

    Private Sub TxtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUser.KeyDown
        If e.KeyCode = Keys.Return Then
            TxtPass.Focus()
        End If
    End Sub

    Private Sub TxtPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPass.KeyDown
        If e.KeyCode = Keys.Return Then
            e.Handled = 1
            Btnok.Focus()
            Btnok_Click(sender, e)
        End If
    End Sub

    Private Sub BtnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As String
        a = MsgBox("Konfigurasi?", vbQuestion + vbYesNo, "Pesan")
        If a = vbYes Then
            If InputBox("Masukan Kode yang diberikan oleh Admin ", vbInformation) = "a" Then
                MsgBox("Sukses", vbInformation, "Pesan ")
                F_Create_Database.ShowDialog()
            Else
                MsgBox("Kode Salah", vbExclamation, "Pesan")
            End If
        End If
    End Sub

    Private Sub OriginalIconHolder1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OriginalIconHolder1.Load

    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        F_Password.Show()
    End Sub

    Private Sub TxtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        If Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private Sub TxtUser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtUser.TextChanged
        Dim i As Integer = TxtUser.SelectionStart
        TxtUser.Text = StrConv(TxtUser.Text, VbStrConv.ProperCase)
        TxtUser.SelectionStart = i
    End Sub

    Private Sub TxtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPass.KeyPress
        If Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
End Class