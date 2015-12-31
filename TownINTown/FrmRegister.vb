Public Class FrmRegister
    Dim NumberCountDown As Integer = 5
    Dim NumberComplete As Integer = 3
    Private WithEvents CountDown As New Timer
    Private WithEvents Complete As New Timer

    Private Sub FrmRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then Application.Exit()
        Dim Machine As String = GetMachineID
        TxtMachine.Text = Machine
        Dim ApplicationName As String
        Dim ApplicationKey As String
        ApplicationName = "CarParking (Front Office)"
        ApplicationKey = "Demo"
        Antidebugging()
        Call SS_R("Nakin W", "MTDObY+HNeo5g91hLtflnXUmwuU+djKRGQAlNbeuQQXsdkbpno8dg+WMZrXty7cq3uKxdo95IXu4ObiKz3jIPQ==")
        Call SS_R("Nakin W", "MTDObY+HNeo5g91hLtflnXUmwuU+djKRGQAlNbeuQQXsdkbpno8dg+WMZrXty7cq3uKxdo95IXu4ObiKz3jIPQ==")
        Call SS_R("Nakin W", "MTDObY+HNeo5g91hLtflnXUmwuU+djKRGQAlNbeuQQXsdkbpno8dg+WMZrXty7cq3uKxdo95IXu4ObiKz3jIPQ==")
        Call SS_R("Nakin W", "MTDObY+HNeo5g91hLtflnXUmwuU+djKRGQAlNbeuQQXsdkbpno8dg+WMZrXty7cq3uKxdo95IXu4ObiKz3jIPQ==")
        Call SetApplicationInfo(ApplicationName, ApplicationKey)

        Call SS_DefaultKey("Demo", "TL-572248E0L5LcuTsI+mB4vAntbKen3uTY9ij0mAZ3", "")
        Call SS_Initialize()
        If SS_IsUnlocked = False Then
            If SS_TrialExpired() = False Then
                'Trial Mode = Days Expiration = 1
                If SS_TrialMode = 1 Then
                    TxtName.Text = SplitName(SS_GetUserName)
                    TxtSerial.text = SS_GetUserKey
                    lblExpire.Text = SS_LicenseInfo() & " day(s) left"
                End If

                'Trial Mode = DateExpiration = 2, return day remain before date expiration
                If SS_TrialMode = 2 Then
                    TxtName.Text = SplitName(SS_GetUserName)
                    TxtSerial.Text = SS_GetUserKey
                    lblExpire.Text = SS_LicenseInfo() & " day(s) left before expiration"
                End If

                'Trial Mode = Run Count = 3
                If SS_TrialMode = 3 Then
                    TxtName.Text = SplitName(SS_GetUserName)
                    TxtSerial.Text = SS_GetUserKey
                    lblExpire.Text = SS_LicenseInfo() & " run(s) left"
                End If

                'Trial Mode = FreeMode  = 4
                If SS_TrialMode = 4 Then
                    TxtName.Text = SplitName(SS_GetUserName)
                    TxtSerial.Text = SS_GetUserKey
                    lblExpire.Text = "Free Mode"
                End If
            End If
            If SS_LicenseInfo > 0 Then
                BtnTry.Text = NumberCountDown
                CountDown.Interval = 1000
                CountDown.Start()
            End If
        Else
            TxtName.Text = "Full Version" 'SplitName(SS_GetUserName)
            lblExpire.Text = "Full Version"
            TxtSerial.Text = SS_GetUserKey
            BtnTry.Visible = False
            BtnRegister.Size = New Size(200, 46)
            BtnRegister.Text = "Full Version"
            FrmLogin.Show()
            Me.Opacity = 0
            Me.ShowInTaskbar = False
        End If
    End Sub

    Private Sub CountDown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CountDown.Tick
        NumberCountDown -= 1
        If NumberCountDown = 0 Then
            CountDown.Stop()
            BtnTry.Enabled = True
            BtnTry.Text = "Try"
            Exit Sub
        End If
        BtnTry.Text = NumberCountDown
    End Sub

    Private Sub Complete_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Complete.Tick
        NumberComplete -= 1
        If NumberComplete = 0 Then
            BtnTry.Enabled = True
            Complete.Stop()
            Me.Hide()
            FrmLogin.Show()
        End If
    End Sub

    Private Function SplitName(ByVal Name As String) As String
        Dim Result() As String
        Result = Name.Split("-")
        If Result.Length > 1 Then
            Name = Result(0).Remove(Result(0).Length - 4, 4)
        Else
            Name = Result(0)
        End If
        Return Name
    End Function

    Private Sub C1BtnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegister.Click
        If SS_IsUnlocked = False Then
            Antidebugging() 'Antidebugging or AntiTracing Protection
            Dim MachineName As String = TxtName.Text & TxtMachine.Text
            Dim ResultID As Integer
            lblExpire.Text = ""
            ResultID = SSUser(MachineName, TxtSerial.Text, "")

            If ResultID = 1 Then
                ' SS_TrialMode is function to check which Trial Mode is used (Days = 1, Date = 2, Run = 3 Expiration)
                ' You can add your personal text with your language

                'Trial Mode = Days Expiration = 1
                If SS_TrialMode = 1 Then
                    lblExpire.Text = (SS_LicenseInfo() & " day(s) left")
                    FrmRegister_Load(Nothing, New EventArgs)
                End If

                'Trial Mode = DateExpiration = 2, return day remain before date expiration
                If SS_TrialMode = 2 Then
                    lblExpire.Text = (SS_LicenseInfo() & " day(s) left before expiration")
                End If

                'Trial Mode = Run Count = 3
                If SS_TrialMode = 3 Then
                    lblExpire.Text = (SS_LicenseInfo() & " run(s) left")
                End If

                'Trial Mode = FreeMode  = 4
                If SS_TrialMode = 4 Then
                    lblExpire.Text = ("Free Mode")
                End If
            End If

            If ResultID = 3 Then
                lblExpire.Text = "Key incorrect!"
                lblExpire.ForeColor = Color.Red
            End If


            If ResultID = 4 Then
                lblExpire.Text = "Software Full Version Mode"
                lblExpire.ForeColor = Color.Lime
                Complete.Interval = 1000
                Complete.Start()
                BtnRegister.Enabled = False
            End If
        Else
            M_Maximized = False
            FrmLogin.Show()
            Me.Hide()
        End If
    End Sub


    Private Sub C1BtnTry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTry.Click
        If NumberCountDown = 0 Then
            M_Maximized = False
            Me.Hide()
            FrmLogin.Show()
        End If
    End Sub

    Private Sub C1BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Application.Exit()
    End Sub
End Class