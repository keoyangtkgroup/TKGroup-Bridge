Module ModMain

#Region "Messag Box"

    Public M_Message, M_Title, M_Icon As String
    Public M_Confirm As Boolean
    Public M_MessageFAS As String
    Public CheckConnect As Boolean
    Public strDatabase() As String

    Public Function ShowMessageAlert(ByVal Message As String, ByVal Title As String, ByVal Icon As String) As Boolean
        M_Message = Message
        M_Title = Title
        M_Icon = Application.StartupPath & "\Icon\" & Icon & ".png"
        Dim f As New FrmAlert
        f.ShowDialog()
        Return M_Confirm
    End Function
#End Region

#Region "User"
    Public M_UserID As String
    Public M_Username As String
    Public M_UserPassword As String
    Public M_UserFirstname As String
    Public M_UserLastName As String
    Public M_Permission As String


#Region "ผู้ใช้งานระบบ"
    'ผู้ใช้งานระบบ [User]
    Public M_UserLogin As String
    Public M_UserAccessRight As String
    Public M_UserPermission As String
    Public M_Maximized As Boolean
    Public StrPermission(3, 6) As Boolean

    'Public Sub CheckPermission()
    '    Dim DT As New DataTable
    '    Dim SqlSelect As String = ""
    '    SqlSelect = " SELECT FormStatus "
    '    SqlSelect &= " FROM   dbo.SysPermissionDetail "
    '    SqlSelect &= " WHERE PermissionID='" & M_Permission & "'"
    '    SqlSelect &= " AND Type='FrontOffice'"
    '    SqlSelect &= " ORDER BY ID ASC "
    '    CPSDatabase.SelectDatabaseSql(SqlSelect, DT)
    '    If DT.Rows.Count > 0 Then
    '        For i As Integer = 0 To 6
    '            If CBool(DT.Rows(i)(0)) Then
    '                StrPermission(0, i) = True
    '            Else
    '                StrPermission(0, i) = False
    '            End If
    '        Next
    '    End If

    '    'FrmCarIn
    '    If StrPermission(0, 0) = False Then
    '        FrmCarOut.btnCarIn.Enabled = False
    '    End If
    '    'FrmCarOut
    '    If StrPermission(0, 1) = False Then
    '        FrmCarIn.btnCarOut.Enabled = False
    '    End If

    '    'FrmLostCard
    '    If StrPermission(0, 2) = False Then
    '        FrmCarIn.btnLostCard.Enabled = False
    '        FrmCarOut.btnLostCard.Enabled = False
    '    End If
    '    'FrmForceOpen
    '    If StrPermission(0, 3) = False Then
    '        FrmCarIn.btnForceOpen.Enabled = False
    '        FrmCarOut.btnForceOpen.Enabled = False
    '    End If
    '    'FrmShift
    '    If StrPermission(0, 4) = False Then
    '        FrmCarOut.btnShift.Enabled = False
    '    End If
    '    'FrmConfigDevice
    '    If StrPermission(0, 5) = False Then
    '        FrmCarIn.btnSetting.Enabled = False
    '        FrmCarOut.btnSetting.Enabled = False
    '    End If
    '    'FrmConnetDatabase
    '    If StrPermission(0, 6) = False Then
    '        FrmCarIn.btnDatabase.Enabled = False
    '        FrmCarOut.btnDatabase.Enabled = False
    '    End If

    'End Sub

#End Region 'ผู้ใช้งานระบบ 
#End Region

#Region "Station"
    Public M_StationID As String
    Public M_StationName As String
    Public M_StationAddress As String
    Public M_SatationDirection As String
#End Region

#Region "Device"

    'Barrier In
    Public M_BarrierInStatus As String                    ' สถานะ Barrier ขาเข้า
    Public M_BarrierInPort As String                      ' ComPort Barrier ขาเข้า
    Public M_BarrierInBaudRate As String                  ' BaudRate Barrier ขาเข้า
    Public M_BarrierInDelay As String
    Public M_BarrierInOpenRelay As String
    Public M_BarrierInCloseRelay As String

    'BarrierOut
    Public M_BarrierOutStatus As String                   ' สถานะ Barrier ขาออก
    Public M_BarrierOutPort As String                     ' ComPort Barrier ขาออก
    Public M_BarrierOutBaudRate As String                 ' BaudRate Barrier ขาออก
    Public M_BarrierOutDelay As String
    Public M_BarrierOutOpenRelay As String
    Public M_BarrierOutCloseRelay As String


    'Printer
    Public M_PrinterInStatus As String                    ' สถานะ Printer ขาเข้า
    Public M_PrinterOutStatus As String                   ' สถานะ Printer ขาออก
    Public M_PrinterInName As String                      ' ชื่อ Printer ขาเข้า
    Public M_PrinterOutName As String                     ' ชื่อ Printer ขาออก

    'ReaderIn
    Public M_CardReaderInStatus As String                 ' สถานะ Card Reader ขาเข้า
    Public M_CardReaderInPort As String                   ' ComPort Card Reader ขาเข้า
    Public M_CardReaderInBaudRate As String               ' BaudRate Card Reader ขาเข้า

    'ReaderOut
    Public M_CardReaderOutStatus As String                ' สถานะ Card Reader ขาออก
    Public M_CardReaderOutPort As String                  ' ComPort Card Reader ขาออก
    Public M_CardReaderOutBaudRate As String
    Public M_VisitorCardProcess As String

    Public M_ReceiveLoop As String
    Public M_ReceiveButton As String

    'DisplayIn
    Public M_DisplayInStatus As String                    ' สถานะ Display ขาเข้า
    Public M_DisplayInPort As String                      ' ComPort Display ขาเข้า
    Public M_DisplayInBaudRate As String                  ' BaudRate Display ขาเข้า
    Public M_DisplayInDefault As String                   ' ข้อความ Default ขาเข้า

    'DisplayOut
    Public M_DisplayOutStatus As String                   ' สถานะ Display ขาเข้า
    Public M_DisplayOutPort As String                     ' ComPort Display ขาเข้า
    Public M_DisplayOutBaudRate As String                 ' BaudRate Display ขาเข้า
    Public M_DisplayOutDefault As String                  ' ข้อความ Default ขาเข้า

    'CameraIn
    Public M_CameraIn1Status As String                     ' สถานะกล้องขาเข้า ตัวที่1
    Public M_CameraIn1Name As String                       ' ชื่ออุปกรณ์ขาเข้า ตัวที่1
    Public M_CameraIn2Status As String                     ' สถานะกล้องขาเข้า ตัวที่2
    Public M_CameraIn2Name As String                       ' ชื่ออุปกรณ์ขาเข้า ตัวที่2

    'CameraOut
    Public M_CameraOut1Status As String                    ' สถานะกล้องขาออก ตัวที่1
    Public M_CameraOut1Name As String                      ' ชื่ออุปกรณ์ขาออก ตัวที่1
    Public M_CameraOut2Status As String                    ' สถานะกล้องขาออก ตัวที่2
    Public M_CameraOut2Name As String                      ' ชื่ออุปกรณ์ขาออก ตัวที่2

    'Sound
    Public M_Sound As String

    'CrashDownerIn
    Public M_CrashDownerInStatus As String                 ' สถานะ Card Reader ขาเข้า
    Public M_CrashDownerInPort As String                   ' ComPort Card Reader ขาเข้า
    Public M_CrashDownerInBaudRate As String               ' BaudRate Card Reader ขาเข้า

    'CrashDownerOut
    Public M_CrashDownerOutStatus As String                ' สถานะ Card Reader ขาออก
    Public M_CrashDownerOutPort As String                  ' ComPort Card Reader ขาออก
    Public M_CrashDownerOutBaudRate As String

    'Weight
    Public M_WeightStatus As String                        ' สถานะ ตาชั่ง
    Public M_WeightPort As String                          ' ComPort ตาชั่ง
    Public M_WeightBaudRate As String
    Public M_WeightBit As String  ' WeightBit 
    Public M_WeightParity As String
    Public M_WeighttStopBit As String

#End Region

#Region "TimeProfile"
    Public M_MonStatus As Boolean
    Public M_MonStart As String
    Public M_MonEnd As String

    Public M_TueStatus As Boolean
    Public M_TueStart As String
    Public M_TueEnd As String

    Public M_WedStatus As Boolean
    Public M_WedStart As String
    Public M_WedEnd As String

    Public M_ThuStatus As Boolean
    Public M_ThuStart As String
    Public M_ThuEnd As String

    Public M_FriStatus As Boolean
    Public M_FriStart As String
    Public M_FriEnd As String

    Public M_SatStatus As Boolean
    Public M_SatStart As String
    Public M_SatEnd As String

    Public M_SunStatus As Boolean
    Public M_SunStart As String
    Public M_SunEnd As String




#End Region

#Region "Get Date & Time"
    Public Function GetDateTimeServer() As Date
        Dim Result As Date
        Dim dt As New DataTable
        Dim sqlShow As String
        sqlShow = " SELECT GETDATE() AS DATE  "
        CPSDatabase.SelectDatabaseSql(sqlShow, dt)
        Result = CDate(dt.Rows(0)(0))
        Return Result
    End Function
#End Region

#Region "Permission"
    Public Sub CheckPermission()
        Dim sqlSelect As String
        Dim dt As New DataTable
        sqlSelect = " SELECT dbo.SysPermissionDetail.ID, dbo.SysPermissionDetail.FormNameEnglish, dbo.SysPermissionDetail.FormNameThai, "
        sqlSelect &= "        dbo.SysPermissionDetail.FormStatus, dbo.SysPermissionDetail.AddDataStatus, dbo.SysPermissionDetail.EditDataStatus, "
        sqlSelect &= "        dbo.SysPermissionDetail.DeleteDataStatus "
        sqlSelect &= " FROM   dbo.SysPermission RIGHT OUTER JOIN "
        sqlSelect &= "        dbo.SysPermissionDetail ON dbo.SysPermission.PermissionID = dbo.SysPermissionDetail.PermissionID "
        sqlSelect &= " WHERE   dbo.SysPermissionDetail.SoftWareType = 'FrontOffice' AND dbo.SysPermission.PermissionID='" & M_Permission & "'"
        sqlSelect &= " ORDER BY dbo.SysPermissionDetail.ID ASC "
        CPSDatabase.SelectDatabaseSql(sqlSelect, dt)
        If dt.Rows.Count > 0 Then

            If CBool(dt.Rows(0)(3)) = True Then
                '1:FrmCarIn
                'FrmCarOut.BtnCarIn.Enabled = True
            Else
                'FrmCarOut.BtnCarIn.Enabled = False
            End If


            If CBool(dt.Rows(1)("FormStatus")) = True Then
                '2:FrmCarOut()
                'FrmCarIn.BtnCarOut.Enabled = True
            Else
                'FrmCarIn.BtnCarOut.Enabled = False
            End If

            If CBool(dt.Rows(2)("FormStatus")) = True Then
                '3:FrmOpenShift()
                'FrmCarIn.BtnShift.Enabled = True
                'FrmCarIn.PicGreen.Enabled = True
                'FrmCarIn.PicRed.Enabled = True

                'FrmCarOut.BtnShift.Enabled = True
                'FrmCarOut.PicGreen.Enabled = True
                'FrmCarOut.PicRed.Enabled = True

            Else
                'FrmCarIn.BtnShift.Enabled = False
                'FrmCarIn.PicGreen.Enabled = False
                'FrmCarIn.PicRed.Enabled = False

                'FrmCarOut.BtnShift.Enabled = False
                'FrmCarOut.PicGreen.Enabled = False
                'FrmCarOut.PicRed.Enabled = False
            End If

            If CBool(dt.Rows(3)("FormStatus")) = True Then
                '4:FrmLostCard)
                'FrmCarOut.BtnLostCard.Enabled = True
            Else
                'FrmCarOut.BtnLostCard.Enabled = False
            End If

            If CBool(dt.Rows(4)("FormStatus")) = True Then
                '5:FrmForceOpen()
                'FrmCarIn.BtnForceOpen.Enabled = True
                'FrmCarOut.BtnForceOpen.Enabled = True
            Else
                'FrmCarIn.BtnForceOpen.Enabled = False
                'FrmCarOut.BtnForceOpen.Enabled = False
            End If

            If CBool(dt.Rows(5)("FormStatus")) = True Then
                '6:FrmConFigDevice()
                'FrmCarIn.btnConfigDevice.Enabled = True
                'FrmCarOut.btnConfigDevice.Enabled = True
            Else
                'FrmCarIn.btnConfigDevice.Enabled = False
                'FrmCarOut.btnConfigDevice.Enabled = False
            End If

            If CBool(dt.Rows(6)("FormStatus")) = True Then
                '7:FrmConnetDatabase()
                'FrmCarIn.btnConnectDatabase.Enabled = True
                'FrmCarOut.btnConnectDatabase.Enabled = True
            Else
                'FrmCarIn.btnConnectDatabase.Enabled = False
                'FrmCarOut.btnConnectDatabase.Enabled = False
            End If

        End If
    End Sub

#End Region

End Module
