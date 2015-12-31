Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports System.Net
Imports System.Security.Cryptography

Public Class FrmLogin
    Dim CheckFocus As String = "USERNAME"
    Dim BoolCheckIP As Boolean
    Dim countOpacity As Integer = 0


    Public Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUserName.Clear()
        txtPassword.Clear()
        Me.Opacity = 0
        Dim strPathServer() As String
        'If File.Exists(Application.StartupPath & "\PathServer") = True Then
        If CheckConnect = True Then
            strPathServer = (System.IO.File.ReadAllText(Application.StartupPath & "\PathServer")).Split(CChar("|"))
            If strPathServer.Length > 2 Then
                Try
                    CPSDatabase.ConnectDatabaseSql(Application.StartupPath & "\PathServer", True)
                Catch ex As Exception
                    If ShowMessageAlert("ไม่สามารถเชื่อมต่อฐานข้อมูลได้ คุณต้องการตั้งค่าใหม่ ใช่หรือไม่?", "คำยืนยัน", "QUESTION") = True Then
                        Dim f As New FrmConnectDatabase
                        f.ShowDialog()
                        strPathServer = (System.IO.File.ReadAllText(Application.StartupPath & "\PathServer")).Split(CChar("|"))
                        If strPathServer.Length > 2 Then

                            CPSDatabase.ConnectDatabaseSql(Application.StartupPath & "\PathServer", True)
                        Else
                            CPSDatabase.ConnectDatabaseSql(Application.StartupPath & "\PathServer", False)
                        End If
                    End If
                End Try
            Else
                Try
                    CPSDatabase.ConnectDatabaseSql(Application.StartupPath & "\PathServer", False)
                Catch ex As Exception
                    If ShowMessageAlert("ไม่สามารถเชื่อมต่อฐานข้อมูลได้ คุณต้องการตั้งค่าใหม่ ใช่หรือไม่?", "คำยืนยัน", "QUESTION") = True Then
                        Dim f As New FrmConnectDatabase
                        f.ShowDialog()
                        strPathServer = (System.IO.File.ReadAllText(Application.StartupPath & "\PathServer")).Split(CChar("|"))
                        If strPathServer.Length > 2 Then
                            CPSDatabase.ConnectDatabaseSql(Application.StartupPath & "\PathServer", True)
                        Else
                            CPSDatabase.ConnectDatabaseSql(Application.StartupPath & "\PathServer", False)
                        End If
                    End If
                End Try
            End If
        Else
            If ShowMessageAlert("คุณยังไม่ได้ตั้งค่าฐานข้อมูลคุณต้องการตั้งค่า ใช่หรือไม่?", "คำยืนยัน", "QUESTION") = True Then
                Dim f As New FrmConnectDatabase
                f.ShowDialog()
                strPathServer = (System.IO.File.ReadAllText(Application.StartupPath & "\PathServer")).Split(CChar("|"))
                If strPathServer.Length > 2 Then
                    CPSDatabase.ConnectDatabaseSql(Application.StartupPath & "\PathServer", True)
                Else
                    CPSDatabase.ConnectDatabaseSql(Application.StartupPath & "\PathServer", False)
                End If
            Else
                Exit Sub
            End If
        End If
        If File.Exists(Application.StartupPath & "\Login") = True Then
            txtUserName.Text = File.ReadAllText(Application.StartupPath & "\Login")
            txtPassword.TabIndex = 0
            txtPassword.Focus()
        End If
        If File.Exists(Application.StartupPath & "\UserLogin") = True Then
            txtUserName.Text = System.IO.File.ReadAllText(Application.StartupPath & "\UserLogin")
            txtPassword.Focus()
            ShowPicUser()
        End If
        timeOpacity.Start()
        ToolTip1.SetToolTip(picExit, "Exit")
    End Sub

   

    'ถอดรหัส "[JSTFCB]"
    Public Function decryptText(ByVal key As String, ByVal text As String) As String
        Dim IV As Byte() = {18, 52, 86, 120, 144, 171, 205, 239}
        Dim inputByteArray As Byte() = New Byte(text.Length) {}
        Try
            Dim byKey As Byte() = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8))
            Dim des As New DESCryptoServiceProvider()
            inputByteArray = Convert.FromBase64String(text)

            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub CheckLogin()
        Dim SqlcheckLoin As String
        Dim dt As New DataTable

        SqlcheckLoin = " SELECT * FROM SysUser "
        SqlcheckLoin &= " WHERE LoginName ='" & txtUserName.Text.Trim & "' AND LoginPassword='" & txtPassword.Text.Trim & "' "
        Dim Xda As New SqlClient.SqlDataAdapter(SqlcheckLoin, Conn)
        Xda.Fill(dt)
        ' CPSDatabase.SelectDatabaseSql(SqlcheckLoin, dt)
        If dt.Rows.Count > 0 Then
            CheckStationAddtess()
            If BoolCheckIP = True Then
                If LoadDeviceConfig() = False Then
                    Exit Sub
                End If
                If CStr(dt.Rows(0)(8)).ToUpper.Trim = "TRUE" Then
                    M_Username = txtUserName.Text
                    M_UserFirstname = CStr(dt.Rows(0)(1))
                    M_UserLastName = CStr(dt.Rows(0)(2))
                    M_Permission = CStr(dt.Rows(0)(9))
                    SaveUserLogin()
                    File.WriteAllText(Application.StartupPath & "\Login", txtUserName.Text)
                    TimeOpen.Start()
                    Form1.Show()
                    Me.Hide()
                Else
                    ShowMessageAlert("UserName นี้ไม่มีสิทธิ์เข้าระบบ", "คำยืนยัน", "INFORMATION")
                End If
            Else
                ShowMessageAlert("UserName หรือ Password", "ผิดพลาด", "ERROR")
            End If
        Else
            Application.Exit()
        End If
    End Sub

    Public Sub CheckStationAddtess()
        Dim sqlShow As String = "'"
        Dim sb As New StringBuilder
        Dim IPMe As String
        If Dns.GetHostAddresses(My.Computer.Name)(0).ToString().Length > 15 Then
Skip:       IPMe = Dns.GetHostAddresses(My.Computer.Name)(1).ToString()
        Else
            IPMe = Dns.GetHostAddresses(My.Computer.Name)(0).ToString()
            If IPMe.Length < 8 Then
                GoTo Skip
            End If
        End If
        sb = New StringBuilder
        sb.Append(" SELECT * FROM SysStationAddress ")
        sb.Append(" WHERE StationIPAddress='" & IPMe & "' ")
        sqlShow = sb.ToString
        Dim dtAddress As New DataTable
        CPSDatabase.SelectDatabaseSql(sqlShow, dtAddress)
        If dtAddress.Rows.Count > 0 Then
            M_StationID = CStr(dtAddress.Rows(0)("StationID"))
            M_StationName = CStr(dtAddress.Rows(0)("StationName"))
            M_StationAddress = IPMe
            M_SatationDirection = CStr(dtAddress.Rows(0)("StationDirection"))
            BoolCheckIP = True
        Else
            ShowMessageAlert("ไม่มีหมายเลข IP Address นี้ในระบบ กรุณาตรวจสอบ", "ข้อผิดพลาด", "ERROR")
            BoolCheckIP = False
            Me.Close()
        End If
        dtAddress.Dispose()
    End Sub

    Private Sub ShowPicUser()
        Dim SqlShowPic As String
        Dim Dt As New DataTable
        SqlShowPic = " SELECT Picture FROM SysUser "
        SqlShowPic &= " WHERE LoginName ='" & txtUserName.Text.Trim & "'"
        ModDatabase.CPSDatabase.SelectDatabaseSql(SqlShowPic, Dt)
        If Dt.Rows.Count > 0 Then
            If IsDBNull(Dt.Rows(0)(0)) = True Then
                Exit Sub
            End If
            Dim Pic() As Byte
            Pic = CType(Dt.Rows(0)(0), Byte())
            Dim Mystream As New System.IO.MemoryStream(Pic)
            PgbLogin.Image = Image.FromStream(Mystream)
        End If
    End Sub

    Private Sub SaveUserLogin()
        'Dim SqlSave As String
        'SqlSave = " INSERT INTO TransactionLogin(DateTimeLogIn, SoftwareType, UserLogin ) "
        'SqlSave &= " VALUES (GETDATE(), 'FONT OFFICE', '" & txtUserName.Text.Trim & "') "
        'ModDatabase.CPSDatabase.ExecuteDatabaseSql(SqlSave)
    End Sub


#Region "Button Click"

    Private Sub stringConcat(ByVal str As String)
        If CheckFocus = "USERNAME" Then
            txtUserName.Text = txtUserName.Text & str
            txtUserName.SelectionStart = txtUserName.Text.Length
        ElseIf CheckFocus = "PASSWORD" Then
            txtPassword.Text = txtPassword.Text & str
            txtPassword.SelectionStart = txtPassword.Text.Length
        End If
    End Sub

    Private Sub txtUsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowPicUser()
    End Sub

    Private Sub txtUserName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.GotFocus
        CheckFocus = "USERNAME"
    End Sub

    Private Sub txtPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.Click
        CheckFocus = "PASSWORD"
    End Sub

    Private Sub txtPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        CheckFocus = "PASSWORD"
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckLogin()
        End If
    End Sub

    Private Sub txtUserName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        stringConcat("1")
    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        stringConcat("2")
    End Sub

    Private Sub btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3.Click
        stringConcat("3")
    End Sub

    Private Sub btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4.Click
        stringConcat("4")
    End Sub

    Private Sub btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5.Click
        stringConcat("5")
    End Sub

    Private Sub btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6.Click
        stringConcat("6")
    End Sub

    Private Sub btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn7.Click
        stringConcat("7")
    End Sub

    Private Sub btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn8.Click
        stringConcat("8")
    End Sub

    Private Sub btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn9.Click
        stringConcat("9")
    End Sub

    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click
        stringConcat("0")
    End Sub

    Private Sub btn0_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn0.MouseDown
        btn0.ForeColor = Color.Lime
    End Sub

    Private Sub btn0_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn0.MouseUp
        btn0.ForeColor = Color.White
    End Sub

    Private Sub Btn1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn1.MouseDown
        btn1.ForeColor = Color.Lime
    End Sub

    Private Sub Btn1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn1.MouseUp
        btn1.ForeColor = Color.White
    End Sub

    Private Sub Btn2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn2.MouseDown
        btn2.ForeColor = Color.Lime
    End Sub

    Private Sub Btn2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn2.MouseUp
        btn2.ForeColor = Color.White
    End Sub

    Private Sub btn3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn3.MouseDown
        btn3.ForeColor = Color.Lime
    End Sub

    Private Sub btn3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn3.MouseUp
        btn3.ForeColor = Color.White
    End Sub

    Private Sub btn4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn4.MouseDown
        btn4.ForeColor = Color.Lime
    End Sub

    Private Sub btn4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn4.MouseUp
        btn4.ForeColor = Color.White
    End Sub

    Private Sub btn5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn5.MouseDown
        btn5.ForeColor = Color.Lime
    End Sub

    Private Sub btn5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn5.MouseUp
        btn5.ForeColor = Color.White
    End Sub

    Private Sub btn6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn6.MouseDown
        btn6.ForeColor = Color.Lime
    End Sub

    Private Sub btn6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn6.MouseUp
        btn6.ForeColor = Color.White
    End Sub

    Private Sub btn7_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn7.MouseDown
        btn7.ForeColor = Color.Lime
    End Sub

    Private Sub btn7_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn7.MouseUp
        btn7.ForeColor = Color.White
    End Sub

    Private Sub btn8_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn8.MouseDown
        btn8.ForeColor = Color.Lime
    End Sub

    Private Sub btn8_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn8.MouseUp
        btn8.ForeColor = Color.White
    End Sub

    Private Sub btn9_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn9.MouseDown
        btn9.ForeColor = Color.Lime
    End Sub

    Private Sub btn9_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn9.MouseUp
        btn9.ForeColor = Color.White
    End Sub

    Private Sub btnCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLEAR.Click
        If CheckFocus = "USERNAME" Then
            txtUserName.Text = ""
        ElseIf CheckFocus = "PASSWORD" Then
            txtPassword.Text = ""
        End If
    End Sub

    Public Sub btnENTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnENTER.Click
        If txtUserName.Text = "" Then
            ShowMessageAlert("กรุณากรอกชื่อผู้ใช้ก่อนค่ะ", "ข้อผิดพลาด", "ERROR")
            txtUserName.Focus()
            Exit Sub
        ElseIf txtPassword.Text = "" Then
            ShowMessageAlert("กรุณากรอกรหัสผู้ใช้ก่อนค่ะ", "ข้อผิดพลาด", "ERROR")
            txtPassword.Focus()
            Exit Sub
        End If
        M_UserPassword = txtPassword.Text
        CheckLogin()
    End Sub

    Private Sub btnA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnA.Click
        stringConcat("A")
    End Sub

    Private Sub btnB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnB.Click
        stringConcat("B")
    End Sub

    Private Sub btnC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC.Click
        stringConcat("C")
    End Sub

    Private Sub btnD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnD.Click
        stringConcat("D")
    End Sub

    Private Sub btnE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnE.Click
        stringConcat("E")
    End Sub

    Private Sub btnF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF.Click
        stringConcat("F")
    End Sub

    Private Sub btnG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnG.Click
        stringConcat("G")
    End Sub

    Private Sub btnH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnH.Click
        stringConcat("H")
    End Sub

    Private Sub btnI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnI.Click
        stringConcat("I")
    End Sub

    Private Sub btnJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJ.Click
        stringConcat("J")
    End Sub

    Private Sub btnK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnK.Click
        stringConcat("K")
    End Sub

    Private Sub btnL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnL.Click
        stringConcat("L")
    End Sub

    Private Sub btnM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnM.Click
        stringConcat("M")
    End Sub

    Private Sub btnN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnN.Click
        stringConcat("N")
    End Sub

    Private Sub btnO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnO.Click
        stringConcat("O")
    End Sub

    Private Sub btnP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP.Click
        stringConcat("P")
    End Sub

    Private Sub btnQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQ.Click
        stringConcat("Q")
    End Sub

    Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnR.Click
        stringConcat("R")
    End Sub

    Private Sub btnS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnS.Click
        stringConcat("S")
    End Sub

    Private Sub btnT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnT.Click
        stringConcat("T")
    End Sub

    Private Sub btnU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnU.Click
        stringConcat("U")
    End Sub

    Private Sub btnV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnV.Click
        stringConcat("V")
    End Sub

    Private Sub btnW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnW.Click
        stringConcat("W")
    End Sub

    Private Sub btnX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnX.Click
        stringConcat("X")
    End Sub

    Private Sub btnY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnY.Click
        stringConcat("Y")
    End Sub

    Private Sub btnZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZ.Click
        stringConcat("Z")
    End Sub

    Private Sub btnA_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnA.MouseDown
        btnA.ForeColor = Color.Lime
    End Sub

    Private Sub btnA_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnA.MouseUp
        btnA.ForeColor = Color.White
    End Sub

    Private Sub BtnB_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnB.MouseDown
        btnB.ForeColor = Color.Lime
    End Sub

    Private Sub BtnB_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnB.MouseUp
        btnB.ForeColor = Color.White
    End Sub

    Private Sub BtnC_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnC.MouseDown
        btnC.ForeColor = Color.Lime
    End Sub

    Private Sub BtnC_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnC.MouseUp
        btnC.ForeColor = Color.White
    End Sub

    Private Sub btnD_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnD.MouseDown
        btnD.ForeColor = Color.Lime
    End Sub

    Private Sub btnD_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnD.MouseUp
        btnD.ForeColor = Color.White
    End Sub

    Private Sub btnE_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnE.MouseDown
        btnE.ForeColor = Color.Lime
    End Sub

    Private Sub btnE_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnE.MouseUp
        btnE.ForeColor = Color.White
    End Sub

    Private Sub btnF_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnF.MouseDown
        btnF.ForeColor = Color.Lime
    End Sub

    Private Sub btnF_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnF.MouseUp
        btnF.ForeColor = Color.White
    End Sub

    Private Sub btnG_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnG.MouseDown
        btnG.ForeColor = Color.Lime
    End Sub

    Private Sub btnG_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnG.MouseUp
        btnG.ForeColor = Color.White
    End Sub

    Private Sub btnH_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnH.MouseDown
        btnH.ForeColor = Color.Lime
    End Sub

    Private Sub btnH_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnH.MouseUp
        btnH.ForeColor = Color.White
    End Sub

    Private Sub btnI_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnI.MouseDown
        btnI.ForeColor = Color.Lime
    End Sub

    Private Sub btnI_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnI.MouseUp
        btnI.ForeColor = Color.White
    End Sub

    Private Sub btnJ_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJ.MouseDown
        btnJ.ForeColor = Color.Lime
    End Sub

    Private Sub btnJ_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnJ.MouseUp
        btnJ.ForeColor = Color.White
    End Sub

    Private Sub btnK_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnK.MouseDown
        btnK.ForeColor = Color.Lime
    End Sub

    Private Sub btnK_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnK.MouseUp
        btnK.ForeColor = Color.White
    End Sub

    Private Sub BtnL_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnL.MouseDown
        btnL.ForeColor = Color.Lime
    End Sub

    Private Sub BtnL_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnL.MouseUp
        btnL.ForeColor = Color.White
    End Sub

    Private Sub BtnM_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnM.MouseDown
        btnM.ForeColor = Color.Lime
    End Sub

    Private Sub BtnM_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnM.MouseUp
        btnM.ForeColor = Color.White
    End Sub

    Private Sub btnN_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnN.MouseDown
        btnN.ForeColor = Color.Lime
    End Sub

    Private Sub btnN_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnN.MouseUp
        btnN.ForeColor = Color.White
    End Sub

    Private Sub btnO_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnO.MouseDown
        btnO.ForeColor = Color.Lime
    End Sub

    Private Sub btnO_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnO.MouseUp
        btnO.ForeColor = Color.White
    End Sub

    Private Sub btnP_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnP.MouseDown
        btnP.ForeColor = Color.Lime
    End Sub

    Private Sub btnP_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnP.MouseUp
        btnP.ForeColor = Color.White
    End Sub

    Private Sub btnQ_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnQ.MouseDown
        btnQ.ForeColor = Color.Lime
    End Sub

    Private Sub btnQ_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnQ.MouseUp
        btnQ.ForeColor = Color.White
    End Sub

    Private Sub btnR_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnR.MouseDown
        btnR.ForeColor = Color.Lime
    End Sub

    Private Sub btnR_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnR.MouseUp
        btnR.ForeColor = Color.White
    End Sub

    Private Sub btnS_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnS.MouseDown
        btnS.ForeColor = Color.Lime
    End Sub

    Private Sub btnS_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnS.MouseUp
        btnS.ForeColor = Color.White
    End Sub

    Private Sub btnT_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnT.MouseDown
        btnT.ForeColor = Color.Lime
    End Sub

    Private Sub btnT_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnT.MouseUp
        btnT.ForeColor = Color.White
    End Sub

    Private Sub btnU_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnU.MouseDown
        btnU.ForeColor = Color.Lime
    End Sub

    Private Sub btnU_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnU.MouseUp
        btnU.ForeColor = Color.White
    End Sub

    Private Sub btnV_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnV.MouseDown
        btnV.ForeColor = Color.Lime
    End Sub

    Private Sub btnV_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnV.MouseUp
        btnV.ForeColor = Color.White
    End Sub

    Private Sub BtnW_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnW.MouseDown
        btnW.ForeColor = Color.Lime
    End Sub

    Private Sub BtnW_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnW.MouseUp
        btnW.ForeColor = Color.White
    End Sub

    Private Sub BtnX_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnX.MouseDown
        btnX.ForeColor = Color.Lime
    End Sub

    Private Sub BtnX_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnX.MouseUp
        btnX.ForeColor = Color.White
    End Sub

    Private Sub btnY_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnY.MouseDown
        btnY.ForeColor = Color.Lime
    End Sub

    Private Sub btnY_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnY.MouseUp
        btnY.ForeColor = Color.White
    End Sub

    Private Sub btnZ_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZ.MouseDown
        btnZ.ForeColor = Color.Lime
    End Sub

    Private Sub btnZ_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZ.MouseUp
        btnZ.ForeColor = Color.White
    End Sub

    Private Sub btnKeypad_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnKeypad.MouseDown
        BtnKeypadGreen.BringToFront()
        picExit.BringToFront()
    End Sub

    Private Sub btnKeypad_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnKeypad.MouseUp
        btnKeypad.BringToFront()
        picExit.BringToFront()
        If Me.Width = 410 Then
            For i As Integer = 410 To 1010 Step 20
                Me.Width = i
                Application.DoEvents()
                Me.CenterToScreen()
            Next
        ElseIf Me.Width = 1010 Then
            For i As Integer = 1010 To 410 Step -20
                Me.Width = i
                Application.DoEvents()
                Me.CenterToScreen()
            Next
            Me.Width = 410
        End If
    End Sub

    Private Sub picExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picExit.Click
        Application.Exit()
    End Sub

    Private Sub txtUserName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.Click
        CheckFocus = "USERNAME"
    End Sub

#End Region

#Region "LoadDeviceConfig"
    Public Function LoadDeviceConfig()
        Dim chackConfig As Boolean = False
        Dim sqlShow As String = ""
        Dim sb As New StringBuilder
        sb = New StringBuilder
        sb.Append(" SELECT * FROM SysConfigDevice ")
        sb.Append(" WHERE StationID='" & M_StationID & "'")
        sqlShow = sb.ToString
        Dim dt As New DataTable
        CPSDatabase.SelectDatabaseSql(sqlShow, dt)
        If dt.Rows.Count > 0 Then
            chackConfig = True
            M_BarrierInStatus = IIf(dt.Rows(0)("BarrierIn") Is DBNull.Value, "False", dt.Rows(0)("BarrierIn"))                ' สถานะ Barrier ขาเข้า
            M_BarrierInPort = IIf(dt.Rows(0)("BarrierInPort") Is DBNull.Value, "False", dt.Rows(0)("BarrierInPort").ToString)         ' ComPort Barrier ขาเข้า
            M_BarrierInBaudRate = IIf(dt.Rows(0)("BarrierInBuard") Is DBNull.Value, "False", dt.Rows(0)("BarrierInBuard").ToString)     ' BaudRate Barrier ขาเข้า
            M_BarrierInDelay = IIf(dt.Rows(0)("BarrierInDelay") Is DBNull.Value, "False", dt.Rows(0)("BarrierInDelay").ToString)        ' เวลาหน่องของ Barrier ขาเข้า
           
            M_BarrierOutStatus = IIf(dt.Rows(0)("BarrierOut") Is DBNull.Value, "False", dt.Rows(0)("BarrierOut").ToString)      ' สถานะ Barrier ขาออก
            M_BarrierOutPort = IIf(dt.Rows(0)("BarrierOutPort") Is DBNull.Value, "False", dt.Rows(0)("BarrierOutPort").ToString)        ' ComPort Barrier ขาออก
            M_BarrierOutBaudRate = IIf(dt.Rows(0)("BarrierOutBuard") Is DBNull.Value, "False", dt.Rows(0)("BarrierOutBuard").ToString)    ' BaudRate Barrier ขาออก
            M_BarrierOutDelay = IIf(dt.Rows(0)("BarrierOutDelay") Is DBNull.Value, "False", dt.Rows(0)("BarrierOutDelay").ToString)              ' เวลาหน่วงของ Barrier ขาออก
           
            M_PrinterInStatus = IIf(dt.Rows(0)("PrinterIn") Is DBNull.Value, "False", dt.Rows(0)("PrinterIn").ToString)               ' สถานะ Printer ขาเข้า
            M_PrinterInName = IIf(dt.Rows(0)("PrinterInName") Is DBNull.Value, "False", dt.Rows(0)("PrinterInName").ToString)                 ' ชื่อ Printer ขาเข้า

            M_PrinterOutStatus = IIf(dt.Rows(0)("PrinterOut") Is DBNull.Value, "False", dt.Rows(0)("PrinterOut").ToString)              ' สถานะ Printer ขาออก
            M_PrinterOutName = IIf(dt.Rows(0)("PrinterOutName") Is DBNull.Value, "False", dt.Rows(0)("PrinterOutName").ToString)                ' ชื่อ Printer ขาออก

            M_CardReaderInStatus = IIf(dt.Rows(0)("CardReaderIn") Is DBNull.Value, "False", dt.Rows(0)("CardReaderIn").ToString)            ' สถานะ Card Reader ขาเข้า
            M_CardReaderInPort = IIf(dt.Rows(0)("CardReaderInPort") Is DBNull.Value, "False", dt.Rows(0)("CardReaderInPort").ToString)              ' ComPort Card Reader ขาเข้า
            M_CardReaderInBaudRate = IIf(dt.Rows(0)("CardReaderInBuard") Is DBNull.Value, "False", dt.Rows(0)("CardReaderInBuard").ToString)         ' BaudRate Card Reader ขาเข้า

            M_CardReaderOutStatus = IIf(dt.Rows(0)("CardReaderOut") Is DBNull.Value, "False", dt.Rows(0)("CardReaderOut").ToString)           ' สถานะ Card Reader ขาออก
            M_CardReaderOutPort = IIf(dt.Rows(0)("CardReaderOutPort") Is DBNull.Value, "False", dt.Rows(0)("CardReaderOutPort").ToString)             ' ComPort Card Reader ขาออก
            M_CardReaderOutBaudRate = IIf(dt.Rows(0)("CardReaderOutBuard") Is DBNull.Value, "False", dt.Rows(0)("CardReaderOutBuard").ToString)         ' BaudRate Card Reader ขาออก

            ' ข้อความ Default ขาเข้า

            M_CameraIn1Status = IIf(dt.Rows(0)("CameraIn1") Is DBNull.Value, "False", dt.Rows(0)("CameraIn1").ToString)               ' สถานะกล้องตัวที่1 ขาเข้า
            M_CameraIn1Name = IIf(dt.Rows(0)("CameraInName1") Is DBNull.Value, "False", dt.Rows(0)("CameraInName1").ToString)                  ' ชื่ออุปกรณ์ตัวที่1 ขาเข้า
            M_CameraIn2Status = IIf(dt.Rows(0)("CameraIn2") Is DBNull.Value, "False", dt.Rows(0)("CameraIn2").ToString)                ' สถานะกล้องตัวที่2 ขาเข้า
            M_CameraIn2Name = IIf(dt.Rows(0)("CameraInName2") Is DBNull.Value, "False", dt.Rows(0)("CameraInName2").ToString)                  ' ชื่ออุปกรณ์ตัวที่2 ขาเข้า

            M_CameraOut1Status = IIf(dt.Rows(0)("CameraOut1") Is DBNull.Value, "False", dt.Rows(0)("CameraIn1").ToString)               ' สถานะกล้องตัวที่1 ขาออก
            M_CameraOut1Name = IIf(dt.Rows(0)("CameraOut1") Is DBNull.Value, "False", dt.Rows(0)("CameraIn1").ToString)                ' ชื่ออุปกรณ์ตัวที่1 ขาออก
            M_CameraOut2Status = IIf(dt.Rows(0)("CameraOut2") Is DBNull.Value, "False", dt.Rows(0)("CameraOut2").ToString)                ' สถานะกล้องตัวที่2 ขาออก
            M_CameraOut2Name = IIf(dt.Rows(0)("CameraOutName2") Is DBNull.Value, "False", dt.Rows(0)("CameraOutName2").ToString)                ' ชื่ออุปกรณ์ตัวที่2 ขาออก

            M_Sound = IIf(dt.Rows(0)("Sound") Is DBNull.Value, "False", dt.Rows(0)("Sound").ToString)

        Else
            ShowMessageAlert("คุณยังไม่ได้ตั้งค่าระบบ !!!", "คำยืนยัน", "INFORMATION")
            FrmConfigDevice.Show()
            chackConfig = False
            Me.Hide()
            ' Exit Sub
        End If

        dt.Dispose()
        Return chackConfig
    End Function
#End Region

    Private Sub timeOpacity_tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timeOpacity.Tick
        countOpacity += 1

        Me.Opacity = countOpacity / 10
        If countOpacity > 10 Then
            timeOpacity.Stop()

        End If

    End Sub

    Private Sub timeOut_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timeOut.Tick
        countOpacity -= 1
        Me.Opacity = countOpacity / 10
        If countOpacity < 0 Then
            timeOut.Stop()
            Application.Exit()
        End If

    End Sub

    Private Sub TimeOpen_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeOpen.Tick
        countOpacity -= 1
        Me.Opacity = countOpacity / 10
        If countOpacity < 0 Then
            TimeOpen.Stop()
        End If
    End Sub

End Class
