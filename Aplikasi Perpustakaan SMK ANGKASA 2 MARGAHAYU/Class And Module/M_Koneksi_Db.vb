Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Module M_Koneksi_Db
    Public cmd As SqlCommand = Nothing
    Public reader As SqlDataReader = Nothing
    Public SQL_Kon As SqlConnection = Nothing
    Public sqlstr As String = Nothing
    Public x As Integer = Nothing
    Public cryRpt As New ReportDocument
    Public crtableLogoninfos As New TableLogOnInfos
    Public crtableLogoninfo As New TableLogOnInfo
    Public crConnectionInfo As New ConnectionInfo
    Public CrTables As Tables
    Public pin As String = "Pinjam"
    Public kem As String = "Kembali"
    Public tdk As String = "Tidak Meminjam"
    Public Sub koneksi_database()
        SQL_Kon = New SqlConnection(My.Settings.Setting)
        SQL_Kon.Open()
    End Sub
End Module


