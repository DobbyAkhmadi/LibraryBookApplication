Public Class Splash

    Dim opacityRate As Double = 0.0
    Dim maximizeRate As Boolean = True
    Dim minimizeRate As Boolean = False
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If opacityRate >= 1.0 Then
            opacityRate = opacityRate + 1.0
            If opacityRate >= 20.0 Then

                opacityRate = 0.99
                Me.Opacity = opacityRate
            End If
        ElseIf maximizeRate Then
            opacityRate = opacityRate + 0.025
            Me.Opacity = opacityRate
            If opacityRate >= 1.0 Then
                maximizeRate = False
                minimizeRate = True
            End If
        ElseIf minimizeRate Then
            opacityRate = opacityRate - 0.025
            If opacityRate < 0 Then
                opacityRate = 0
            End If
            Me.Opacity = opacityRate
            If Opacity <= 0.0 Then
                minimizeRate = False
                maximizeRate = False
            End If
        Else
            Timer1.Stop()
            Timer1.Enabled = False
            Timer1.Dispose()

            Me.Visible = False
            'Dim Login As New F_Login
            F_Login.Show()
        End If

    End Sub

    Private Sub Splash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opacity = 0.0
        Timer1.Interval = 60
        Timer1.Enabled = True
        Timer1.Start()
    End Sub
End Class