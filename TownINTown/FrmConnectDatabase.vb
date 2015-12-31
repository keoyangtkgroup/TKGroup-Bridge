Option Strict On
Option Explicit On
Imports System.IO


Public Class FrmConnectDatabase
    Dim strPathServer As String()

    Private Sub FrmConnectDatabase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Clear()
        RdoWindows.Checked = True
        LoadDatabase()
        If File.Exists(Application.StartupPath & "\PathServer") = True Then
            Try
                TestDatabase()
                AddNameDatabase()
            Catch ex As Exception
            End Try

        End If
    End Sub

    Private Sub Clear()
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtServername.Text = ""
        CboDatabase.Text = "กรุณาเลือก Database"
    End Sub

    Private Sub LoadDatabase()
        Try
            If File.Exists(Application.StartupPath & "\PathServer") = True Then
                strPathServer = (System.IO.File.ReadAllText(Application.StartupPath & "\PathServer")).Split(CChar("|"))
                txtServername.Text = strPathServer(0)
                CboDatabase.Text = strPathServer(1)
                If strPathServer.Length > 2 Then
                    RdoSql.Checked = True
                    txtUsername.Text = strPathServer(2)
                    txtPassword.Text = strPathServer(3)
                End If
                lblDisplay.Text = "การเชื่อมต่อสำเร็จ"
                lblDisplay.ForeColor = Color.Lime
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub AddNameDatabase()
        Dim dt As New DataTable
        Dim sqlshow As String = (" SELECT Name FROM Sys.Databases ")
        CPSDatabase.SelectDatabaseSql(sqlshow, dt)
        If dt.Rows.Count > 0 Then
            If CboDatabase.Items.Count > 0 Then
                CboDatabase.Items.Clear()
            End If
            Dim ab As Integer = CboDatabase.Items.Count
            For i As Integer = 0 To dt.Rows.Count - 1
                CboDatabase.Items.Add(dt.Rows(i)(0))
            Next
        End If
    End Sub

    Private Sub TestDatabase()
        If RdoWindows.Checked = True Then
            If CPSDatabase.TestConnectDatabase(txtServername.Text, CboDatabase.Text, False) = True Then
                System.IO.File.WriteAllText(Application.StartupPath & "\PathServer", txtServername.Text & "|" & CboDatabase.Text)
                CheckConnDB = True
                lblDisplay.Text = "การเชื่อมต่อสำเร็จ"
                lblDisplay.ForeColor = Color.Lime
                AddNameDatabase()
            Else
                lblDisplay.Text = "การเชื่อมต่อล้มเหลว"
                lblDisplay.ForeColor = Color.Red
            End If
        Else
            If CPSDatabase.TestConnectDatabase(txtServername.Text, CboDatabase.Text, True, txtUsername.Text, txtPassword.Text) = True Then
                System.IO.File.WriteAllText(Application.StartupPath & "\PathServer", txtServername.Text & "|" & CboDatabase.Text & "|" & txtUsername.Text & "|" & txtPassword.Text)
                CheckConnDB = True
                lblDisplay.Text = "การเชื่อมต่อสำเร็จ"
                lblDisplay.ForeColor = Color.Lime
                AddNameDatabase()
            Else
                lblDisplay.Text = "การเชื่อมต่อล้มเหลว"
                lblDisplay.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub PicCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub PicConnect_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        TestDatabase()
    End Sub

    Private Sub RdoSql_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdoSql.CheckedChanged
        If RdoSql.Checked = True Then
            txtUsername.Enabled = True
            txtPassword.Enabled = True
            txtUsername.Focus()
        End If
    End Sub

    Private Sub RdoWindows_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdoWindows.CheckedChanged
        If RdoWindows.Checked = True Then
            txtUsername.Enabled = False
            txtPassword.Enabled = False
        End If
    End Sub

    Private Sub btnCONNECT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCONNECT.Click
        TestDatabase()
    End Sub

    Private Sub btnCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLOSE.Click
        Me.Close()
    End Sub

    Private Sub btnCLOSE_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCLOSE.MouseDown
        btnCLOSE.ForeColor = Color.Red
    End Sub

    Private Sub btnCLOSE_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCLOSE.MouseUp
        btnCLOSE.ForeColor = Color.White
    End Sub

    Private Sub btnCONNECT_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCONNECT.MouseDown
        btnCONNECT.ForeColor = Color.Lime
    End Sub

    Private Sub btnCONNECT_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCONNECT.MouseUp
        btnCONNECT.ForeColor = Color.White
    End Sub
End Class