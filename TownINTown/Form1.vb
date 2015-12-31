Imports System.Net
Imports System.Drawing.Printing
Imports System.Text
Imports System.Data.SqlClient
Imports System.IO

Public Class Form1

    Dim valid_car As Boolean = False
    Dim uie As New System.Globalization.CultureInfo("en-Us")
    Dim TransactionID As String
    Public strDatabase() As String
    Dim Database() As String


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '  Label1.Text = Now
        'Dim Xcount As Integer = 0
        'Xcount = +1
        valid_car = False
        'SerialPort1.WriteLine(":7" + vbCrLf)
        Dim BarrierReceiveDataIn As String = ""
        '  Dim BarrierReceiveDataOut As String

        BarrierReceiveDataIn = SerialPort1.ReadExisting
        'BarrierReceiveDataOut = SerialPort2.ReadChar
        System.Threading.Thread.Sleep(100)
        If InStr(BarrierReceiveDataIn, "IN") Then
            'timer1.Stop()
            valid_car = True
            CreateTransactionID()
            ' Timer1.Start()
        End If
        If InStr(BarrierReceiveDataIn.Trim, "OUT") Then
            ' Timer1.Stop()
            valid_car = False
            CreateTransactionID()
            ' Timer1.Start()
        End If


        'If BarrierReceiveDataIn.Trim = "IN" Then
        '    ' Timer1.Stop()
        '    valid_car = True
        '    CreateTransactionID()
        'End If
        'If BarrierReceiveDataIn.Trim = "OUT" Then
        '    'Timer1.Stop()
        '    valid_car = True
        '    CreateTransactionID()
        'End If


        ' Timer1.Start()
        'End If
        'If BarrierReceiveData.Trim = "IN" Then
        '    ' Timer1.Stop()
        '    valid_car = False
        '    CreateTransactionID()
        '    ' Timer1.Start()
        'End If

        'If valid_car = True Then
        '    Timer1.Stop()
        '    CreateTransactionID()
        '    valid_car = False
        '    Timer1.Start()
        'End If

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' conDatabase()
        'ConnectGateBarrier()
        ConnectCamera()
        Timer1.Enabled = True
        Timer1.Start()
        OpenComport()
    End Sub

    Private Sub OpenComport()
        Try
            If SerialPort1.IsOpen = True Then SerialPort1.Close()
            SerialPort1.PortName = "COM3"
            SerialPort1.BaudRate = "9600"
            SerialPort1.Open()


            If SerialPort2.IsOpen = True Then SerialPort2.Close()
            SerialPort2.PortName = "COM4"
            SerialPort2.BaudRate = "9600"
            SerialPort2.Open()
        Catch ex As Exception
            MsgBox("")
        End Try
    End Sub

    'Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
    '    Dim BarrierReceiveData As String
    '    BarrierReceiveData = SerialPort1.ReadExisting
    '    If BarrierReceiveData.Trim = "10000000" Then
    '        valid_car = True
    '    ElseIf BarrierReceiveData.Trim = "00000000" Then
    '        valid_car = False
    '    End If
    'End Sub

    Private Function CreateTransactionID() As String
        Dim uth As New System.Globalization.CultureInfo("th-th")
        CreateTransactionID = "" 'แก้ไขเมื่อ 10
        Dim dt As New DataTable
        Dim sqlShow As String = ""

        If valid_car = True Then
            sqlShow = " SELECT MAX(TransactionID) AS TransactionID "
            sqlShow &= " FROM TransactionCarIn "
            sqlShow &= " WHERE DateTimeCarIn BETWEEN '" & Date.Now.ToString("yyyy/MM/dd 00:00:00", uie) & "'"
            sqlShow &= " AND '" & Date.Now.ToString("yyyy/MM/dd 23:59:59", uie) & "' AND StationAddressIn = '" & M_StationID & "'"
            sqlShow &= " UNION"
            sqlShow &= " SELECT MAX(TransactionID) AS TransactionID "
            sqlShow &= " FROM TransactionCarOut "
            sqlShow &= " WHERE DateTimeCarIn BETWEEN '" & Date.Now.ToString("yyyy/MM/dd 00:00:00", uie) & "'"
            sqlShow &= " AND '" & Date.Now.ToString("yyyy/MM/dd 23:59:59", uie) & "' AND StationAddressIn = '" & M_StationID & "'"
            sqlShow &= " ORDER BY TransactionID DESC "
        Else
            sqlShow = " SELECT MAX(TransactionID) AS TransactionID "
            sqlShow &= " FROM TransactionCarOut "
            sqlShow &= " WHERE DateTimeCarOut BETWEEN '" & Date.Now.ToString("yyyy/MM/dd 00:00:00", uie) & "'"
            sqlShow &= " AND '" & Date.Now.ToString("yyyy/MM/dd 23:59:59", uie) & "' AND StationAddressOut = '" & M_StationID & "'"
            sqlShow &= " UNION"
            sqlShow &= " SELECT MAX(TransactionID) AS TransactionID "
            sqlShow &= " FROM TransactionCarOut "
            sqlShow &= " WHERE DateTimeCarOut BETWEEN '" & Date.Now.ToString("yyyy/MM/dd 00:00:00", uie) & "'"
            sqlShow &= " AND '" & Date.Now.ToString("yyyy/MM/dd 23:59:59", uie) & "' AND StationAddressOut = '" & M_StationID & "'"
            sqlShow &= " ORDER BY TransactionID DESC "
        End If

        CPSDatabase.SelectDatabaseSql(sqlShow, dt)

        ' Dim Xda As New SqlClient.SqlDataAdapter(sqlShow, Conn)
        '  Xda.Fill(dt)

        If dt.Rows.Count > 0 Then
            Try
                Dim TransactionCut As String = dt.Rows(0)("TransactionID").ToString.Substring(9)
                TransactionID = M_StationID & Date.Now.ToString("yyMMdd", uie) & (TransactionCut + 1).ToString("0000")
            Catch ex As Exception
                TransactionID = M_StationID & Date.Now.ToString("yyMMdd", uie) & "0001"
            End Try
        Else
            TransactionID = M_StationID & Date.Now.ToString("yyMMdd", uie) & "0001"
        End If

        If valid_car = True Then
            InsertTransactionCarIn("", "IN", "", "", "", "IN", "", "", "", "", "")
        Else
            InsertTransactionCarOut("", "OUT", "", "", "", "OUT", "", "", "", "", "")
        End If
        ' InsertTransactionCarIn("", "IN", "", "", "", "IN", "", "", "", "", "")
        ' print()
        'OpenGateIn()

        'lblCardID.Text = TransactionID
        'LblDate.Text = Format(Now, "dd/MM/yyyy")
        'lblTime.Text = Format(Now, "HH:mm:ss")

        System.Threading.Thread.Sleep(100)
        Return TransactionID

    End Function

    Public Sub OpenGateIn()
        If M_BarrierInStatus.Trim.ToUpper = "TRUE" Then
            Try
                'BarrierInPort.WriteLine(":20001" + vbCrLf)
                'BarrierInPort.WriteLine(":21000" + vbCrLf)
                If M_BarrierInDelay = 1 Then
                    BarrierInPort.WriteLine(":21000" + vbCrLf)
                ElseIf M_BarrierInDelay = 2 Then
                    BarrierInPort.WriteLine(":20100" + vbCrLf)
                ElseIf M_BarrierInDelay = 3 Then
                    BarrierInPort.WriteLine(":20010" + vbCrLf)
                ElseIf M_BarrierInDelay = 4 Then
                    BarrierInPort.WriteLine(":20001" + vbCrLf)
                End If
                System.Threading.Thread.Sleep(600)
                BarrierInPort.WriteLine(":20001" + vbCrLf)
                ' FrmCard.Label1.Text = "รถเข้าจอด"
                ' FrmCard.Label2.Text = "ไม้กั้นเปิด"
                ' ShowSystemMessage("ไม้กั้นเปิด", Color.Green)
                'FrmCarOut.ShowSystemMessage("รถเข้าจอด", Color.Green)
            Catch ex As Exception
                ShowMessageAlert("กรุณาตรวจสอบพอร์ตเชื่อมต่อไม้แขนกั้น", "คำแนะนำ", "ERROR")
            End Try
        Else
            ' ShowSystemMessage("ไม้กั้นเปิด", Color.Green)
            ' FrmCarOut.ShowSystemMessage("รถเข้าจอด", Color.Green)
            ' FrmCard.Label1.Text = "รถเข้าจอด"
            ' FrmCard.Label2.Text = "ไม้กั้นเปิด"
        End If
        ' CountCarIn()
    End Sub

    Private Sub print()
        Dim PrintTicketIn As New CryTicketIn
        PrintTicketIn.SetParameterValue("PBarcode", "*" & TransactionID & "*")
        PrintTicketIn.SetParameterValue("PNo", ": " & TransactionID)
        PrintTicketIn.SetParameterValue("PVNo", ": " & "")
        'PCPC
        ' DateCarIN = String.Format(CDate(DateCarIN), "dd/MM/yyyy ")
        'PCPC
        PrintTicketIn.SetParameterValue("PDate", ": " & Format(Now, "dd/MM/yyyy"))
        PrintTicketIn.SetParameterValue("PTime", ": " & Format(Now, "HH:mm:ss"))
        'PCPC----------
        PrintTicketIn.SetParameterValue("PCarType", ": " & "")
        PrintTicketIn.SetParameterValue("Puser", ": " & "")
        'PCPC-------
        PrintTicketIn.PrintOptions.PrinterName = M_PrinterInName
        PrintTicketIn.PrintToPrinter(0, False, 0, 0)
        PrintTicketIn.Dispose()
    End Sub

    'Private Sub conDatabase()
    '    If File.Exists(Application.StartupPath & "\PathServer") = True Then
    '        Database = IO.File.ReadAllText(System.Windows.Forms.Application.StartupPath & "\PathServer").ToString.Split("|")
    '        If Database.Length > 2 Then
    '            ' Conn.ConnectionString = "Data Source= " & Database(0) & ";Initial Catalog=" & Database(1) & ";uid=" & Database(2) & ";pwd=" & Database(3)
    '            ' Conn.Open()
    '        End If
    '    End If
    'End Sub


    Public Sub InsertTransactionCarIn(ByVal CardID As String _
                                  , ByVal Direction As String _
                                  , ByVal StationAddressIn As String _
                                  , ByVal CarID As String _
                                   , ByVal CarTypeID As String _
                                  , ByVal AccessMessageIn As String _
                                  , ByVal WorkIDIn As String _
                                  , ByVal MemberID As String _
                                  , ByVal StampID As String _
                                   , ByVal SeatID As String _
                                  , ByVal BoxDocument As String)
Insert:
        'TransactionID = CreateTransactionID()
        Dim sqlstr As String
        Try

            CardID = "VISITOR"

            sqlstr = "INSERT INTO TransactionCarIn "
            sqlstr &= " ( TransactionID, "
            sqlstr &= " CardID, "
            sqlstr &= " DatetimeCarIn, "
            sqlstr &= " Direction, "
            sqlstr &= " StationAddressIn, "
            sqlstr &= " CarID, "
            sqlstr &= " CarType, "
            sqlstr &= " AccessMessageIN, "
            sqlstr &= " WorkIDIn , "
            sqlstr &= " MemberID , "
            sqlstr &= " StampIn ) "
            sqlstr &= " VALUES  "
            sqlstr &= "  ( '" & TransactionID & "', "
            sqlstr &= "  '" & CardID & "', "
            sqlstr &= "  '" & Date.Now.ToString(uie) & "', "
            sqlstr &= "  'IN', "
            sqlstr &= "  '" & M_StationID & "', "
            sqlstr &= "  '000', "
            sqlstr &= "  '001',"
            sqlstr &= "  'เข้าปกติ', "
            sqlstr &= "  'ST', "
            sqlstr &= "  '', "
            sqlstr &= "  '') "

            CPSDatabase.ExecuteDatabaseSql(sqlstr)
        Catch ex As Exception
            '  TransactionID = (CInt(TransactionID) + 1).ToString("0000000000")
            GoTo Insert

        End Try


        SavePictureCarIn("TransactionCarIn")
        ' UpdateParkingStatus("True", CardID)

    End Sub

    Public Sub InsertTransactionCarOut(ByVal CardID As String _
                                 , ByVal Direction As String _
                                 , ByVal StationAddressIn As String _
                                 , ByVal CarID As String _
                                  , ByVal CarTypeID As String _
                                 , ByVal AccessMessageIn As String _
                                 , ByVal WorkIDIn As String _
                                 , ByVal MemberID As String _
                                 , ByVal StampID As String _
                                  , ByVal SeatID As String _
                                 , ByVal BoxDocument As String)
Insert:
        'TransactionID = CreateTransactionID()
        Dim sqlstr As String
        Try

            CardID = "VISITOR"

            sqlstr = "INSERT INTO TransactionCarOut "
            sqlstr &= " ( TransactionID, "
            sqlstr &= " CardID, "
            sqlstr &= " DatetimeCarOut, "
            sqlstr &= " Direction, "
            sqlstr &= " StationAddressOut, "
            sqlstr &= " CarID, "
            sqlstr &= " CarType, "
            sqlstr &= " AccessMessageOut, "
            sqlstr &= " WorkIDOut , "
            sqlstr &= " MemberID , "
            sqlstr &= " StampOut ) "
            sqlstr &= " VALUES  "
            sqlstr &= "  ( '" & TransactionID & "', "
            sqlstr &= "  '" & CardID & "', "
            sqlstr &= "  '" & Date.Now.ToString(uie) & "', "
            sqlstr &= "  'OUT', "
            sqlstr &= "  '" & M_StationID & "', "
            sqlstr &= "  '000', "
            sqlstr &= "  '001',"
            sqlstr &= "  'ออกปกติ', "
            sqlstr &= "  'ST', "
            sqlstr &= "  '', "
            sqlstr &= "  '') "

            CPSDatabase.ExecuteDatabaseSql(sqlstr)
        Catch ex As Exception
            '  TransactionID = (CInt(TransactionID) + 1).ToString("0000000000")
            GoTo Insert

        End Try


        SavePictureCarOut("TransactionCarOut")
        ' UpdateParkingStatus("True", CardID)

    End Sub

    Private Sub SavePictureCarIn(ByVal TableName As String)
        If CBool(M_CameraIn1Status) = True Then
            AxVideoCapX1.SaveFrameJPG(Application.StartupPath & "\CarIn.jpg", 50)
            CPSDatabase.SavePicture(Application.StartupPath & "\CarIn.jpg", "PictureCarIn", TableName, "TransactionID", TransactionID)
        End If
        'If CBool(M_CameraIn2Status) = True Then
        '    AxVideoCapX1.SaveFrameJPG(Application.StartupPath & "\DriverIn.jpg", 50)
        '    CPSDatabase.SavePicture(Application.StartupPath & "\DriverIn.jpg", "PictureDriverIn", TableName, "TransactionID", TransactionID)
        'End If
    End Sub

    Private Sub SavePictureCarOut(ByVal TableName As String)
        'If CBool(M_CameraIn1Status) = True Then
        '    AxVideoCapX1.SaveFrameJPG(Application.StartupPath & "\CarIn.jpg", 50)
        '    CPSDatabase.SavePicture(Application.StartupPath & "\CarIn.jpg", "PictureCarIn", TableName, "TransactionID", TransactionID)
        'End If
        If CBool(M_CameraIn2Status) = True Then
            AxVideoCapX1.SaveFrameJPG(Application.StartupPath & "\DriverIn.jpg", 50)
            CPSDatabase.SavePicture(Application.StartupPath & "\DriverIn.jpg", "PictureDriverIn", TableName, "TransactionID", TransactionID)
        End If
    End Sub

    Private Sub ConnectCamera()
        If CBool(M_CameraIn1Status) = True Then
            Try
                With AxVideoCapX1
                    AxVideoCapX1.BringToFront()
                    AxVideoCapX1.Visible = True
                    PictureBox1.Visible = False
                    .ServerMode = True
                    .ServerPort = 43521
                    .VideoDeviceIndex = M_CameraIn1Name
                    .Connected = True
                    .Preview = True
                    .PreviewAudio = False
                    .SetTextOverlay(0, "TIME", 50, 400, "MS SAN SERIF", 14, RGB(247, 0, 0), -1)
                End With
            Catch ex As Exception
                AxVideoCapX1.Visible = False
                PictureBox1.Visible = True
            End Try

            Try
                With AxVideoCapX2
                    AxVideoCapX2.BringToFront()
                    AxVideoCapX2.Visible = True
                    PictureBox3.Visible = False
                    .ServerMode = True
                    .ServerPort = 43521
                    .VideoDeviceIndex = M_CameraIn2Name
                    .Connected = True
                    .Preview = True
                    .PreviewAudio = False
                    .SetTextOverlay(0, "TIME", 50, 400, "MS SAN SERIF", 14, RGB(247, 0, 0), -1)
                End With
            Catch ex As Exception
                AxVideoCapX2.Visible = False
                PictureBox3.Visible = True
            End Try
        Else
            'AxVideoCapX1.Size = New Size(442, 312)
            ' AxVideoCapX1.Location = New Point(28, 35)
            AxVideoCapX1.Visible = False
            PictureBox1.Visible = True
        End If

    End Sub

    Private Sub ConnectGateBarrier()
        If M_BarrierInStatus.Trim.ToUpper = "TRUE" Then
            Try
                If BarrierInPort.IsOpen = True Then BarrierInPort.Close()
                BarrierInPort.PortName = M_BarrierInPort
                BarrierInPort.BaudRate = M_BarrierInBaudRate
                BarrierInPort.Open()
            Catch ex As Exception
                ShowMessageAlert("กรุณาตรวจสอบพอร์ตเชื่อมต่อไม้แขนกั้น", "คำแนะนำ", "ERROR")
            End Try
        End If
    End Sub

    Private Sub MenuConnectDatabase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConnectDatabase.Click
        Dim f As New FrmConnectDatabase
        f.StartPosition = FormStartPosition.Manual
        ' f.Location = New Point(566, 72)
        f.ShowDialog()
    End Sub

    Private Sub MenuConfigDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConfigDevice.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New FrmConfigDevice
        f.StartPosition = FormStartPosition.Manual
        'f.Location = New Point(566, 70)
        f.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MenuExitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuExitProgram.Click

        ShowMessageAlert("คุณต้องการออกจากโปรแกรม ใช่หรือไม่?", "คำยืนยัน", "Question")
        If M_Confirm = True Then
            'Me.Close()
            'FrmLogin.txtPassword.Text = ""
            'FrmLogin.txtPassword.TabIndex = 0
            'FrmLogin.txtPassword.Focus()
            'FrmLogin.Show()
            Application.Exit()
        End If
    End Sub

   
End Class
