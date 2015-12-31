Imports System.Data.SqlClient
Imports System.text
Public Class FrmConfigDevice
    Private Sub FrmConfigDevice_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub FrmConfigDevice_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If FrmCarIn.ReaderInPort.IsOpen = True Then FrmCarIn.ReaderInPort.Close()
        ' If FrmCarOut.ReaderOutPort.IsOpen = True Then FrmCarOut.ReaderOutPort.Close()
        ' If FrmInsertCardVisitor.Reader.IsOpen = True Then FrmInsertCardVisitor.Reader.Close()
    End Sub

    Private Sub FrmConfigDevice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowComportList()
        GetCameraDeviceName()
        ShowPrinterName()
        ShowStationdirection()
        lblStationID.Text = M_StationID
        lblStationAddress.Text = M_StationAddress
        ShowConfiguration()
    End Sub

    Private Sub ShowStationdirection()
        Dim SqlSelect As String
        Dim dt As New DataTable
        SqlSelect = "SELECT StationDirection  "
        SqlSelect &= " FROM SysStationAddress "
        SqlSelect &= "   WHERE (StationIPAddress='" & M_StationAddress & "')"
        CPSDatabase.SelectDatabaseSql(SqlSelect, dt)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(0) = "IN" Then
                CboStationDirection.SelectedIndex = 0
            ElseIf dt.Rows(0)(0) = "OUT" Then
                CboStationDirection.SelectedIndex = 1
            ElseIf dt.Rows(0)(0) = "INOUT" Then
                CboStationDirection.SelectedIndex = 2
            End If
        End If
    End Sub

    Private Sub ShowBaudRate()
        For i As Integer = 0 To 10
            CmbCardReaderBitIn.Text = ""
            CmbCardReaderBitOut.Text = ""
            CmbDisplayBitIn.Text = ""
            CmbDisplayBitOut.Text = ""
            CmbGateBarrierbitIn.Text = ""
            CmbGateBarrierbitOut.Text = ""
        Next
    End Sub

    Private Sub chbCardReader_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCardReader.CheckedChanged
        If chbCardReader.Checked = True Then
            chbCardReaderIn.Enabled = True
            chbCardReaderOut.Enabled = True
        Else
            chbCardReaderIn.Checked = False
            chbCardReaderOut.Checked = False
            chbCardReaderIn.Enabled = False
            chbCardReaderOut.Enabled = False
        End If
    End Sub

    Private Sub ChbCrashDrowner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChbCrashDrowner.CheckedChanged
        If ChbCrashDrowner.Checked = True Then
            ChbCrashDownerIn.Enabled = True
            ChbCrashDownerOut.Enabled = True
        Else
            ChbCrashDownerIn.Checked = False
            ChbCrashDownerOut.Checked = False
            ChbCrashDownerIn.Enabled = False
            ChbCrashDownerOut.Enabled = False
        End If
    End Sub

    Private Sub chbCamera_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChbCamera.CheckedChanged
        If ChbCamera.Checked = True Then
            ChbCameraCarIn.Enabled = True
            chbCameraDriverIn.Enabled = True
            ChbCameraCarOut.Enabled = True
            ChbCameraDriverOut.Enabled = True

        Else
            ChbCameraCarIn.Checked = False
            chbCameraDriverIn.Checked = False
            ChbCameraCarOut.Checked = False
            ChbCameraDriverOut.Checked = False
            ChbCameraCarIn.Enabled = False
            chbCameraDriverIn.Enabled = False
            ChbCameraCarOut.Enabled = False
            ChbCameraDriverOut.Enabled = False
        End If
    End Sub

    Private Sub chbSound_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChbSound.CheckedChanged
        If ChbSound.Checked = True Then
            ChbSoundOn.Enabled = True
            ChbSoundOff.Enabled = True
        Else
            ChbSoundOn.Checked = False
            ChbSoundOff.Checked = False
            ChbSoundOn.Enabled = False
            ChbSoundOff.Enabled = False
        End If
    End Sub

    Private Sub ChbCameraCarIn_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbCameraCarIn.CheckedChanged
        If ChbCameraCarIn.Checked = True Then
            CmbCameraCarIn.Enabled = True
        Else
            CmbCameraCarIn.Enabled = False
        End If
    End Sub

    Private Sub chbCameraDriverIn_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbCameraDriverIn.CheckedChanged
        If chbCameraDriverIn.Checked = True Then
            CmbCameraDriverIn.Enabled = True
        Else
            CmbCameraDriverIn.Enabled = False
        End If
    End Sub

    Private Sub ChbCameraCarOut_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbCameraCarOut.CheckedChanged
        If ChbCameraCarOut.Checked = True Then
            CmbCameraCarOut.Enabled = True
        Else
            CmbCameraCarOut.Enabled = False
        End If
    End Sub

    Private Sub ChbCameraDriverOut_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbCameraDriverOut.CheckedChanged
        If ChbCameraDriverOut.Checked = True Then
            CmbCameraDriverOut.Enabled = True
        Else
            CmbCameraDriverOut.Enabled = False
        End If
    End Sub

    Private Sub chbPrinter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPrinter.CheckedChanged
        If chbPrinter.Checked = True Then
            chbPrinterIn.Enabled = True
            chbPrinterOut.Enabled = True
        Else
            chbPrinterIn.Enabled = False
            chbPrinterOut.Enabled = False
        End If
    End Sub

    Private Sub chbPrinterIn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPrinterIn.CheckedChanged
        If chbPrinterIn.Checked = True Then
            CmbPrinterIn.Enabled = True
        Else
            CmbPrinterIn.Enabled = False
        End If
    End Sub

    Private Sub chbPrinterOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPrinterOut.CheckedChanged
        If chbPrinterOut.Checked = True Then
            CmbPrinterOut.Enabled = True
        Else
            CmbPrinterOut.Enabled = False
        End If
    End Sub

    Private Sub chbCardReaderIn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCardReaderIn.CheckedChanged
        If chbCardReaderIn.Checked = True Then
            cmbCardReaderPortIn.Enabled = True
            CmbCardReaderBitIn.Enabled = True
        Else
            cmbCardReaderPortIn.Enabled = False
            CmbCardReaderBitIn.Enabled = False
        End If
    End Sub

    Private Sub chbCardReaderOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCardReaderOut.CheckedChanged
        If chbCardReaderOut.Checked = True Then
            cmbCardReaderPortOut.Enabled = True
            CmbCardReaderBitOut.Enabled = True
        Else
            cmbCardReaderPortOut.Enabled = False
            CmbCardReaderBitOut.Enabled = False
        End If
    End Sub

    Private Sub chbDisPlay_IN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDisPlayIn.CheckedChanged
        If chbDisPlayIn.Checked = True Then
            cmbDisplayPortIn.Enabled = True
            CmbDisplayBitIn.Enabled = True
            TxtDisplayShowIn.Enabled = True
        Else
            cmbDisplayPortIn.Enabled = False
            CmbDisplayBitIn.Enabled = False
            TxtDisplayShowIn.Enabled = False
        End If
    End Sub

    Private Sub chbDisPlay_Out_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDisPlayOut.CheckedChanged
        If chbDisPlayOut.Checked = True Then
            cmbDisplayPortOut.Enabled = True
            CmbDisplayBitOut.Enabled = True
            TxtDisplayShowOut.Enabled = True
        Else
            CmbDisplayBitOut.Enabled = False
            cmbDisplayPortOut.Enabled = False
            TxtDisplayShowOut.Enabled = False
        End If
    End Sub

    Private Sub chbGateBarrierPortIn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbGateBarrierPortIn.CheckedChanged
        If chbGateBarrierPortIn.Checked = True Then
            cmbGateBarrierPortIn.Enabled = True
            CmbGateBarrierbitIn.Enabled = True
            CboGateBarrierDelayIn.Enabled = True
        Else
            cmbGateBarrierPortIn.Enabled = False
            CmbGateBarrierbitIn.Enabled = False
            CboGateBarrierDelayIn.Enabled = False
        End If
    End Sub

    Private Sub chbGateBarrierPortOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbGateBarrierPortOut.CheckedChanged
        If chbGateBarrierPortOut.Checked = True Then
            cmbGateBarrierPortOut.Enabled = True
            CmbGateBarrierbitOut.Enabled = True
            CboGateBarrierDelayOut.Enabled = True
        Else
            cmbGateBarrierPortOut.Enabled = False
            CmbGateBarrierbitOut.Enabled = False
            CboGateBarrierDelayOut.Enabled = False
        End If
    End Sub

    Private Sub ChbSoundOn_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbSoundOn.CheckedChanged
        If ChbSoundOn.Checked = True Then
            ChbSoundOn.Checked = True
            ChbSoundOff.Checked = False
        End If
    End Sub

    Private Sub ChbSoundOff_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbSoundOff.CheckedChanged
        If ChbSoundOff.Checked = True Then
            ChbSoundOn.Checked = False
            ChbSoundOff.Checked = True
        End If
    End Sub

    Private Sub GetCameraDeviceName()
        For i As Integer = 0 To Camera.GetVideoDeviceCount - 1
            CmbCameraCarIn.Items.Add(Camera.GetVideoDeviceName(i))
            CmbCameraDriverIn.Items.Add(Camera.GetVideoDeviceName(i))
            CmbCameraCarOut.Items.Add(Camera.GetVideoDeviceName(i))
            CmbCameraDriverOut.Items.Add(Camera.GetVideoDeviceName(i))
        Next
    End Sub
    Private Sub ShowPrinterName()

        Dim oSYS As New System.Management.ManagementObjectSearcher("Select * from Win32_Printer")
        For Each infoPrinter As System.Management.ManagementObject In oSYS.Get
            CmbPrinterIn.Items.Add(infoPrinter("Name"))
            CmbPrinterOut.Items.Add(infoPrinter("Name"))
        Next
    End Sub

    Private Sub ShowComportList()
        Dim Port() As String = System.IO.Ports.SerialPort.GetPortNames
        cmbGateBarrierPortIn.Items.Clear()
        cmbGateBarrierPortOut.Items.Clear()
        cmbDisplayPortIn.Items.Clear()
        cmbDisplayPortOut.Items.Clear()
        cmbCardReaderPortIn.Items.Clear()
        cmbCardReaderPortOut.Items.Clear()
        CmbCrashDownerPortIn.Items.Clear()
        CmbCrashDownerPortOut.Items.Clear()
        For Each Ports As String In Port
            cmbGateBarrierPortIn.Items.Add(Ports)
            cmbGateBarrierPortOut.Items.Add(Ports)
            cmbDisplayPortIn.Items.Add(Ports)
            cmbDisplayPortOut.Items.Add(Ports)
            cmbCardReaderPortIn.Items.Add(Ports)
            cmbCardReaderPortOut.Items.Add(Ports)
            CmbCrashDownerPortIn.Items.Add(Ports)
            CmbCrashDownerPortOut.Items.Add(Ports)

            cmbGateBarrierPortIn.Text = Ports
            cmbGateBarrierPortOut.Text = Ports
            cmbDisplayPortIn.Text = Ports
            cmbDisplayPortOut.Text = Ports
            cmbCardReaderPortIn.Text = Ports
            cmbCardReaderPortOut.Text = Ports
            CmbCrashDownerPortIn.Text = Ports
            CmbCrashDownerPortOut.Text = Ports
        Next

        cmbGateBarrierPortIn.Sorted = True
        cmbGateBarrierPortOut.Sorted = True
        cmbDisplayPortIn.Sorted = True
        cmbDisplayPortOut.Sorted = True
        cmbCardReaderPortIn.Sorted = True
        cmbCardReaderPortOut.Sorted = True
        CmbCrashDownerPortIn.Sorted = True
        CmbCrashDownerPortOut.Sorted = True
    End Sub

    Private Sub ShowConfiguration()
        Dim sb As New StringBuilder
        Dim SqlStr As String
        sb.Append("SELECT *  ")
        sb.Append(" FROM SysConfigDevice ")
        sb.Append("   WHERE (StationID='" & M_StationID & "')")
        SqlStr = sb.ToString
        Dim dt As New DataTable
        CPSDatabase.SelectDatabaseSql(SqlStr, dt)
        lblStationID.Text = CStr(dt.Rows(0)(0)).Trim
        lblStationAddress.Text = M_StationName


        If (CStr(dt.Rows(0)("BarrierIn")).Trim.ToUpper = "TRUE") Or (CStr(dt.Rows(0)("BarrierOut")).Trim.ToUpper = "TRUE") Then
            chbGateBarrier.Checked = True
            If CStr(dt.Rows(0)("BarrierIn")).Trim.ToUpper = "TRUE" Then
                chbGateBarrierPortIn.Checked = True
                cmbGateBarrierPortIn.Text = dt.Rows(0)("BarrierInPort")
                CmbGateBarrierbitIn.Text = dt.Rows(0)("BarrierInBuard")
                CboGateBarrierDelayIn.Text = dt.Rows(0)("BarrierInDelay")
            Else
                chbGateBarrierPortIn.Checked = False
            End If
            If CStr(dt.Rows(0)("BarrierOut")).Trim.ToUpper = "TRUE" Then
                chbGateBarrierPortOut.Checked = True
                cmbGateBarrierPortOut.Text = dt.Rows(0)("BarrierOutPort")
                CmbGateBarrierbitOut.Text = dt.Rows(0)("BarrierOutBuard")
                CboGateBarrierDelayOut.Text = dt.Rows(0)("BarrierOutDelay")
            Else
                chbGateBarrierPortOut.Checked = False
            End If
        Else
            chbGateBarrier.Checked = True
            chbGateBarrier.Checked = False
        End If


        If (CStr(dt.Rows(0)("PrinterIn")).Trim.ToUpper = "TRUE") Or (CStr(dt.Rows(0)("PrinterOut")).Trim.ToUpper = "TRUE") Then
            chbPrinter.Checked = True
            If (CStr(dt.Rows(0)("PrinterIn")).Trim.ToUpper = "TRUE") Then
                chbPrinterIn.Checked = True
                CmbPrinterIn.Text = dt.Rows(0)("PrinterInName")
            Else
                chbPrinterIn.Checked = False
            End If
            If (CStr(dt.Rows(0)("PrinterOut")).Trim.ToUpper = "TRUE") Then
                chbPrinterOut.Checked = True
                CmbPrinterOut.Text = dt.Rows(0)("PrinterOutName")
            Else
                chbPrinterOut.Checked = False
            End If
        Else
            chbPrinter.Checked = True
            chbPrinter.Checked = False
        End If


        If (CStr(dt.Rows(0)("CardReaderIn")).Trim.ToUpper = "TRUE") Or (CStr(dt.Rows(0)("CardReaderOut")).Trim.ToUpper = "TRUE") Then
            chbCardReader.Checked = True
            If (CStr(dt.Rows(0)("CardReaderIn")).Trim.ToUpper = "TRUE") Then
                chbCardReaderIn.Checked = True
                cmbCardReaderPortIn.Text = CStr(dt.Rows(0)("CardReaderInPort")).Trim
                CmbCardReaderBitIn.Text = CStr(dt.Rows(0)("CardReaderInBuard")).Trim
            Else
                chbCardReaderIn.Checked = False
            End If
            If (CStr(dt.Rows(0)("CardReaderOut")).Trim.ToUpper = "TRUE") Then
                chbCardReaderOut.Checked = True
                cmbCardReaderPortOut.Text = CStr(dt.Rows(0)("CardReaderOutPort")).Trim
                CmbCardReaderBitOut.Text = CStr(dt.Rows(0)("CardReaderOutBuard")).Trim
            Else
                chbCardReaderOut.Checked = False
            End If
        Else
            chbCardReader.Checked = True
            chbCardReader.Checked = False
        End If


        If (CStr(dt.Rows(0)("DisplayIn")).Trim.ToUpper = "TRUE") Or (CStr(dt.Rows(0)("DisplayOut")).Trim.ToUpper = "TRUE") Then
            chbDisPlay.Checked = True
            If (CStr(dt.Rows(0)("DisplayIn")).Trim.ToUpper = "TRUE") Then
                chbDisPlayIn.Checked = True
                cmbDisplayPortIn.Text = CStr(dt.Rows(0)("DisplayInPort")).Trim
                CmbDisplayBitIn.Text = CStr(dt.Rows(0)("DisplayInBuard")).Trim
                TxtDisplayShowIn.Text = CStr(dt.Rows(0)("DisplayInDefault")).Trim
            Else
                chbDisPlayIn.Checked = False
            End If
            If (CStr(dt.Rows(0)("DisplayOut")).Trim.ToUpper = "TRUE") Then
                chbDisPlayOut.Checked = True
                cmbDisplayPortOut.Text = CStr(dt.Rows(0)("DisplayOutPort")).Trim
                CmbDisplayBitOut.Text = CStr(dt.Rows(0)("DisplayOutBuard")).Trim
                TxtDisplayShowOut.Text = CStr(dt.Rows(0)("DisplayOutDefault")).Trim
            Else
                chbDisPlayOut.Checked = False
            End If
        Else
            chbDisPlay.Checked = True
            chbDisPlay.Checked = False
        End If


        If (CStr(dt.Rows(0)("CameraIn1")).Trim.ToUpper = "TRUE") Or (CStr(dt.Rows(0)("CameraIn2")).Trim.ToUpper = "TRUE") Then
            ChbCamera.Checked = True
            If (CStr(dt.Rows(0)("CameraIn1")).Trim.ToUpper = "TRUE") Then
                ChbCameraCarIn.Checked = True
                Dim CameraCarInName As String = dt.Rows(0)("CameraInName1")
                'CmbCameraCarIn.Text = Camera.GetVideoDeviceName(CameraCarInName)
                Try
                    CmbCameraCarIn.SelectedIndex = CInt(CameraCarInName)
                Catch ex As Exception
                    ChbCameraCarIn.Checked = False
                End Try
            Else
                ChbCameraCarIn.Checked = False
            End If
            If (CStr(dt.Rows(0)("CameraIn2")).Trim.ToUpper = "TRUE") Then
                chbCameraDriverIn.Checked = True
                Dim CameraDriverInName As String = dt.Rows(0)("CameraInName2")
                'CmbCameraDriverIn.Text = Camera.GetVideoDeviceName(CameraDriverInName)
                Try
                    CmbCameraDriverIn.SelectedIndex = CInt(CameraDriverInName)
                Catch ex As Exception
                    chbCameraDriverIn.Checked = False
                End Try
            Else
                chbCameraDriverIn.Checked = False
            End If
        End If



        If (dt.Rows(0)("CameraOut1").ToString.Trim.ToUpper = "TRUE") Or (dt.Rows(0)("CameraOut2").ToString.Trim.ToUpper = "TRUE") Then
            ChbCamera.Checked = True
            If (CStr(dt.Rows(0)("CameraOut1")).Trim.ToUpper = "TRUE") Then
                ChbCameraCarOut.Checked = True
                Dim CameraCarOutName As String = dt.Rows(0)("CameraOutName1")
                'CmbCameraCarOut.Text = Camera.GetVideoDeviceName(CameraCarOutName)
                Try
                    CmbCameraCarOut.SelectedIndex = CInt(CameraCarOutName)
                Catch ex As Exception
                    ChbCameraCarOut.Checked = False
                End Try
            Else
                ChbCameraCarOut.Checked = False
            End If
            If (dt.Rows(0)("CameraOut2").ToString.Trim.ToUpper = "TRUE") Then
                ChbCameraDriverOut.Checked = True
                Dim CameraDriverOutName As String = dt.Rows(0)("CameraOutName2")
                'CmbCameraDriverOut.Text = Camera.GetVideoDeviceName(CameraDriverOutName)
                Try
                    CmbCameraDriverOut.SelectedIndex = CInt(CameraDriverOutName)
                Catch ex As Exception
                    ChbCameraDriverOut.Checked = False
                End Try
            Else
                ChbCameraDriverOut.Checked = False
            End If
        End If


        If (dt.Rows(0)("Sound").ToString.Trim.ToUpper = "TRUE") Then
            ChbSound.Checked = True
            ChbSoundOn.Checked = True
            ChbSoundOff.Checked = False
        Else
            ChbSound.Checked = False
            ChbSoundOn.Checked = False
            ChbSoundOff.Checked = True
        End If


        If (dt.Rows(0)("CrashDownerIn").ToString.Trim.ToUpper = "TRUE") Or (dt.Rows(0)("CrashDownerOut").ToString.Trim.ToUpper = "TRUE") Then
            ChbCrashDrowner.Checked = True
            If (CStr(dt.Rows(0)("CrashDownerIn")).Trim.ToUpper = "TRUE") Then
                ChbCrashDownerIn.Checked = True
                CmbCrashDownerPortIn.Text = dt.Rows(0)("CrashDownerInPort").ToString.Trim
                CmbCrashDownerBaudrateIn.Text = dt.Rows(0)("CrashDownerInBuard").ToString.Trim
            Else
                ChbCrashDownerIn.Checked = False
            End If
            If (CStr(dt.Rows(0)("CrashDownerOut")).Trim.ToUpper = "TRUE") Then
                ChbCrashDownerOut.Checked = True
                CmbCrashDownerPortOut.Text = dt.Rows(0)("CrashDownerOutPort").ToString.Trim
                CmbCrashDownerBaudrateOut.Text = dt.Rows(0)("CrashDownerOutBuard").ToString.Trim
            Else
                ChbCrashDownerOut.Checked = False
            End If
        Else
            ChbCrashDrowner.Checked = True
            ChbCrashDrowner.Checked = False
        End If

        If (dt.Rows(0)("VisitorCardProcess").ToString.Trim.ToUpper = "TRUE") Then
            ChbVisitorCardOn.Checked = True
        Else
            ChbVisitorCardOff.Checked = True
        End If

        dt.Dispose()
    End Sub

    Private Sub cbGate_Barrier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbGateBarrier.CheckedChanged
        If chbGateBarrier.Checked = True Then
            chbGateBarrierPortIn.Enabled = True
            chbGateBarrierPortOut.Enabled = True
        Else
            chbGateBarrierPortIn.Checked = False
            chbGateBarrierPortOut.Checked = False
            chbGateBarrierPortIn.Enabled = False
            chbGateBarrierPortOut.Enabled = False
        End If
    End Sub

    Private Sub PicCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub picExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Hide()
    End Sub
    Private Sub PicSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chbDisPlay_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbDisPlay.CheckedChanged
        If chbDisPlay.Checked = True Then
            chbDisPlayIn.Enabled = True
            chbDisPlayOut.Enabled = True
        Else
            chbDisPlayIn.Checked = False
            chbDisPlayOut.Checked = False
            chbDisPlayIn.Enabled = False
            chbDisPlayOut.Enabled = False
        End If
    End Sub

    Private Sub btnSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSAVE.Click
        Dim SqlStr As String

        SqlStr = " Update SysConfigDevice "


        If chbGateBarrier.Checked = True Then
            If chbGateBarrierPortIn.Checked = True Then
                SqlStr &= " SET BarrierIn='True' "
                If cmbGateBarrierPortIn.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , BarrierInPort='" & cmbGateBarrierPortIn.Text & "'"
                If CmbGateBarrierbitIn.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , BarrierInBuard='" & CmbGateBarrierbitIn.Text & "' "
                If CboGateBarrierDelayIn.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , BarrierInDelay='" & CboGateBarrierDelayIn.Text & "' "
            Else

                SqlStr &= " SET BarrierIn ='False' "
                SqlStr &= " , BarrierInPort ='-' "
                SqlStr &= " , BarrierInBuard ='-' "
                SqlStr &= " , BarrierInDelay ='0' "
            End If

            If chbGateBarrierPortOut.Checked = True Then
                SqlStr &= " , BarrierOut ='True' "
                If cmbGateBarrierPortOut.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , BarrierOutPort='" & cmbGateBarrierPortOut.Text & "' "
                If CmbGateBarrierbitOut.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , BarrierOutBuard='" & CmbGateBarrierbitOut.Text & "' "
                If CboGateBarrierDelayOut.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , BarrierOutDelay ='" & CboGateBarrierDelayOut.Text & "' "
            Else
                SqlStr &= " , BarrierOut ='False' "
                SqlStr &= " , BarrierOutPort ='-' "
                SqlStr &= " , BarrierOutBuard ='-' "
                SqlStr &= " , BarrierOutDelay ='0' "
            End If
        Else
            SqlStr &= " SET BarrierIn ='False'"
            SqlStr &= " , BarrierInPort ='-' "
            SqlStr &= " , BarrierInBuard ='-' "
            SqlStr &= " , BarrierInDelay ='0' "
            SqlStr &= " , BarrierOut ='False' "
            SqlStr &= " , BarrierOutPort ='-' "
            SqlStr &= " , BarrierOutBuard ='-' "
            SqlStr &= " , BarrierOutDelay ='0' "
        End If


        If chbPrinter.Checked = True Then
            If chbPrinterIn.Checked = True Then
                SqlStr &= " , PrinterIn='True' "
                SqlStr &= " , PrinterInName ='" & CmbPrinterIn.Text & "'"
            Else
                SqlStr &= " , PrinterIn ='False' "
                SqlStr &= " , PrinterInName ='-' "
            End If
            If chbPrinterOut.Checked = True Then
                SqlStr &= " , PrinterOut ='True' "
                SqlStr &= " , PrinterOutName ='" & CmbPrinterOut.Text & "'"
            Else
                SqlStr &= " , PrinterOut ='False' "
                SqlStr &= " , PrinterOutName ='-' "
            End If
        Else
            SqlStr &= " , PrinterIn ='False' "
            SqlStr &= " , PrinterInName ='-' "
            SqlStr &= " , PrinterOut ='False' "
            SqlStr &= " , PrinterOutName ='-' "
        End If



        If chbCardReader.Checked = True Then
            If chbCardReaderIn.Checked = True Then
                SqlStr &= " , CardReaderIn ='True' "
                If cmbCardReaderPortIn.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , CardReaderInPort='" & cmbCardReaderPortIn.Text & "' "
                If CmbCardReaderBitIn.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , CardReaderInBuard='" & CmbCardReaderBitIn.Text & "' "
            Else
                SqlStr &= " , CardReaderIn ='False' "
                SqlStr &= " , CardReaderInPort ='-' "
                SqlStr &= " , CardReaderInBuard ='-' "
            End If
            If chbCardReaderOut.Checked = True Then
                SqlStr &= " , CardReaderOut ='True'"
                If cmbCardReaderPortOut.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , CardReaderOutPort ='" & cmbCardReaderPortOut.Text & "'"
                If CmbCardReaderBitOut.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , CardReaderOutBuard ='" & CmbCardReaderBitOut.Text & "'"
            Else
                SqlStr &= " , CardReaderOut ='False'"
                SqlStr &= " , CardReaderOutPort ='-'"
                SqlStr &= " , CardReaderOutBuard ='-'"
            End If
        Else
            SqlStr &= " , CardReaderIn ='False'"
            SqlStr &= " , CardReaderInPort ='-'"
            SqlStr &= " , CardReaderInBuard ='-'"
            SqlStr &= " , CardReaderOut ='False'"
            SqlStr &= " , CardReaderOutPort ='-'"
            SqlStr &= " , CardReaderOutBuard ='-'"
        End If



        If chbDisPlay.Checked = True Then
            If chbDisPlayIn.Checked = True Then
                SqlStr &= " , DisplayIn ='True'"
                If cmbDisplayPortIn.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , DisplayInPort ='" & cmbDisplayPortIn.Text & "'"
                If CmbDisplayBitIn.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , DisplayInBuard ='" & CmbDisplayBitIn.Text & "'"
                If TxtDisplayShowIn.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , DisplayInDefault ='" & TxtDisplayShowIn.Text & "'"
            Else
                SqlStr &= " , DisplayIn ='False'"
                SqlStr &= " , DisplayInPort ='-'"
                SqlStr &= " , DisplayInBuard ='-'"
                SqlStr &= " , DisplayInDefault ='-'"
            End If

            If chbDisPlayOut.Checked = True Then
                SqlStr &= " , DisplayOut ='True'"
                If cmbDisplayPortOut.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , DisplayOutPort ='" & cmbDisplayPortOut.Text & "'"
                If CmbDisplayBitOut.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , DisplayOutBuard ='" & CmbDisplayBitOut.Text & "'"
                If TxtDisplayShowOut.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , DisplayOutDefault ='" & TxtDisplayShowOut.Text & "'"
            Else
                SqlStr &= " , DisplayOut ='False'"
                SqlStr &= " , DisplayOutPort ='-'"
                SqlStr &= " , DisplayOutBuard ='-'"
                SqlStr &= " , DisplayOutDefault ='-'"
            End If

        Else
            SqlStr &= " , DisplayIn ='False'"
            SqlStr &= " , DisplayInPort ='-'"
            SqlStr &= " , DisplayInBuard ='-'"
            SqlStr &= " , DisplayInDefault ='-'"

            SqlStr &= " , DisplayOut ='False'"
            SqlStr &= " , DisplayOutPort ='-'"
            SqlStr &= " , DisplayOutBuard ='-'"
            SqlStr &= ", DisplayOutDefault ='-'"
        End If



        If ChbCamera.Checked = True Then
            If ChbCameraCarIn.Checked = True Then
                SqlStr &= " , CameraIn1 ='True'"
                If CmbCameraCarIn.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , CameraInName1 ='" & CmbCameraCarIn.SelectedIndex & "'"
            Else
                SqlStr &= " , CameraIn1 ='False'"
                SqlStr &= " , CameraInName1 ='-'"
            End If
            If chbCameraDriverIn.Checked = True Then
                SqlStr &= " , CameraIn2 ='True'"
                If CmbCameraDriverIn.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , CameraInName2 ='" & CmbCameraDriverIn.SelectedIndex & "'"
            Else
                SqlStr &= " , CameraIn2 ='False'"
                SqlStr &= " , CameraInName2 ='-'"
            End If
        Else
            SqlStr &= " , CameraIn1 ='False'"
            SqlStr &= " , CameraInName1 ='-'"
            SqlStr &= " , CameraIn2 ='False'"
            SqlStr &= " , CameraInName2 ='-'"
        End If



        If ChbCamera.Checked = True Then
            If ChbCameraCarOut.Checked = True Then
                SqlStr &= " , CameraOut1 ='True'"
                If CmbCameraCarOut.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , CameraOutName1 ='" & CmbCameraCarOut.SelectedIndex & "'"
            Else
                SqlStr &= " , CameraOut1 ='False'"
                SqlStr &= " , CameraOutName1 ='0'"
            End If
            If ChbCameraDriverOut.Checked = True Then
                SqlStr &= " , CameraOut2 ='True'"
                If CmbCameraDriverOut.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , CameraOutName2 ='" & CmbCameraDriverOut.SelectedIndex & "'"
            Else
                SqlStr &= " , CameraOut2 ='False'"
                SqlStr &= " , CameraOutName2 ='0'"
            End If
        Else
            SqlStr &= " , CameraOut1 ='False'"
            SqlStr &= " , CameraOutName1 ='0'"
            SqlStr &= " , CameraOut2 ='False'"
            SqlStr &= " , CameraOutName2 ='0'"
        End If



        If ChbSound.Checked = True Then
            If ChbSoundOn.Checked = True Then
                SqlStr &= " , Sound ='True'"
            ElseIf ChbSoundOff.Checked = True Then
                SqlStr &= " , Sound ='False'"
            Else
                SqlStr &= " , Sound ='False'"
            End If
        Else
            SqlStr &= " , Sound ='False'"
        End If



        If ChbCrashDrowner.Checked = True Then
            If ChbCrashDownerIn.Checked = True Then
                SqlStr &= " , CrashDownerIn ='True' "
                If CmbCrashDownerPortIn.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , CrashDownerInPort='" & CmbCrashDownerPortIn.Text & "' "
                If CmbCrashDownerBaudrateIn.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , CrashDownerInBuard='" & CmbCrashDownerBaudrateIn.Text & "' "
            Else
                SqlStr &= " , CrashDownerIn ='False' "
                SqlStr &= " , CrashDownerInPort ='-' "
                SqlStr &= " , CrashDownerInBuard ='-' "
            End If
            If ChbCrashDownerOut.Checked = True Then
                SqlStr &= " , CrashDownerOut ='True'"
                If CmbCrashDownerPortOut.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , CrashDownerOutPort ='" & CmbCrashDownerPortOut.Text & "'"
                If CmbCrashDownerBaudrateOut.Text = "" Then
                    MessageBox.Show("กรุณาตรวจสอบการเลือกอุปกรณ์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                SqlStr &= " , CrashDownerOutBuard ='" & CmbCrashDownerBaudrateOut.Text & "'"
            Else
                SqlStr &= " , CrashDownerOut ='False'"
                SqlStr &= " , CrashDownerOutPort ='-'"
                SqlStr &= " , CrashDownerOutBuard ='-'"
            End If
        Else
            SqlStr &= " , CrashDownerIn ='False'"
            SqlStr &= " , CrashDownerInPort ='-'"
            SqlStr &= " , CrashDownerInBuard ='-'"
            SqlStr &= " , CrashDownerOut ='False'"
            SqlStr &= " , CrashDownerOutPort ='-'"
            SqlStr &= " , CrashDownerOutBuard ='-'"
        End If

        If ChbVisitorCardOn.Checked = True Then
            SqlStr &= " , VisitorCardProcess ='True'"
        End If

        If ChbVisitorCardOff.Checked = True Then
            SqlStr &= " , VisitorCardProcess ='False'"
        End If

        SqlStr &= " WHERE StationID='" & M_StationID & "'"
        CPSDatabase.ExecuteDatabaseSql(SqlStr)
        Me.Close()

        SqlStr = " UPDATE SysStationAddress "
        If CboStationDirection.SelectedIndex = 0 Then
            SqlStr &= " SET StationDirection='IN'"
        ElseIf CboStationDirection.SelectedIndex = 1 Then
            SqlStr &= " SET StationDirection='OUT'"
        ElseIf CboStationDirection.SelectedIndex = 2 Then
            SqlStr &= " SET StationDirection='INOUT'"
        End If

        SqlStr &= " WHERE StationID='" & M_StationID & "'"
        CPSDatabase.ExecuteDatabaseSql(SqlStr)

        ShowMessageAlert("ตั้งค่าอุปกรณ์ เรียบร้อยแล้ว", "ผลการทำงาน", "Information")
        Form1.Close()
        Form1.Show()
        FrmLogin.btnENTER_Click(New Object, Nothing)
    End Sub

    Private Sub btnSAVE_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSAVE.MouseDown
        btnSAVE.ForeColor = Color.Lime
    End Sub

    Private Sub btnSAVE_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSAVE.MouseUp
        btnSAVE.ForeColor = Color.White
    End Sub

    Private Sub ChbCrashDownerIn_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbCrashDownerIn.CheckedChanged
        If ChbCrashDownerIn.Checked = True Then
            CmbCrashDownerPortIn.Enabled = True
            CmbCrashDownerBaudrateIn.Enabled = True
        Else
            CmbCrashDownerPortIn.Enabled = False
            CmbCrashDownerBaudrateIn.Enabled = False
        End If
    End Sub

    Private Sub ChbCrashDownerOut_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbCrashDownerOut.CheckedChanged
        If ChbCrashDownerOut.Checked = True Then
            CmbCrashDownerPortOut.Enabled = True
            CmbCrashDownerBaudrateOut.Enabled = True
        Else
            CmbCrashDownerPortOut.Enabled = False
            CmbCrashDownerBaudrateOut.Enabled = False
        End If
    End Sub

    Private Sub ChbVisitorCardOff_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbVisitorCardOff.CheckedChanged
        If ChbVisitorCardOff.Checked = True Then
            ChbVisitorCardOff.Checked = True
            ChbVisitorCardOn.Checked = False
        Else
            ChbVisitorCardOff.Checked = False
            ChbVisitorCardOn.Checked = True
        End If
    End Sub

    Private Sub ChbVisitorCardOn_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChbVisitorCardOn.CheckedChanged
        If ChbVisitorCardOn.Checked = True Then
            ChbVisitorCardOn.Checked = True
            ChbVisitorCardOff.Checked = False
        Else
            ChbVisitorCardOn.Checked = False
            ChbVisitorCardOff.Checked = True
        End If
    End Sub

    Private Sub btnAddCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCard.Click
        '  Dim F As New FrmInsertCardVisitor
        '  F.Show()
        btnSAVE.Enabled = False
        btnAddCard.Enabled = False
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class