Option Explicit On
Option Strict On


Public Class FrmAlert
    Private Sub FrmAlert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim IconName() As String = M_Icon.Split(CChar("\"))
        IconName(0) = IconName(IconName.Length - 1)
        Dim Icon As String = IconName(IconName.Length - 1).Substring(0, IconName(0).Length - 4)
        Me.Text = M_Title
        lblMessage.Text = M_Message
        PictureBox1.Image = Image.FromFile(M_Icon)
        Select Case Icon.ToUpper
            Case "QUESTION"
                btnYES.Visible = True
                btnOK.Visible = False
                BtnNO.Visible = True
            Case "INFORMATION"
                btnYES.Visible = False
                btnOK.Visible = True
                BtnNO.Visible = False
            Case "ERROR"
                btnYES.Visible = False
                btnOK.Visible = True
                BtnNO.Visible = False
        End Select
    End Sub

    Private Sub btnYES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYES.Click
        M_Confirm = True
        Me.Hide()
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        M_Confirm = True
        Me.Close()
    End Sub

    Private Sub BtnNO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNO.Click
        M_Confirm = False
        Me.Close()
    End Sub

    Private Sub btnYES_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnYES.MouseDown
        btnYES.ForeColor = Color.Lime
    End Sub

    Private Sub btnYES_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnYES.MouseUp
        btnYES.ForeColor = Color.White
    End Sub

    Private Sub btnOK_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnOK.MouseDown
        btnOK.ForeColor = Color.Lime
    End Sub

    Private Sub btnOK_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnOK.MouseUp
        btnOK.ForeColor = Color.White
    End Sub

    Private Sub BtnNO_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnNO.MouseDown
        BtnNO.ForeColor = Color.Red
    End Sub

    Private Sub BtnNO_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnNO.MouseUp
        BtnNO.ForeColor = Color.White
    End Sub
End Class