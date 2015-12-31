<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConnectDatabase
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConnectDatabase))
        Me.GrbConnectDatabase = New System.Windows.Forms.GroupBox
        Me.btnCLOSE = New System.Windows.Forms.Button
        Me.btnCONNECT = New System.Windows.Forms.Button
        Me.lblDisplay = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.CboDatabase = New System.Windows.Forms.ComboBox
        Me.txtServername = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.RdoSql = New System.Windows.Forms.RadioButton
        Me.RdoWindows = New System.Windows.Forms.RadioButton
        Me.GbUser = New System.Windows.Forms.GroupBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.lblUsername = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblHeader = New System.Windows.Forms.Label
        Me.lblDatabasename = New System.Windows.Forms.Label
        Me.lblServerName = New System.Windows.Forms.Label
        Me.GrbConnectDatabase.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrbConnectDatabase
        '
        Me.GrbConnectDatabase.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.GrbConnectDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GrbConnectDatabase.Controls.Add(Me.btnCLOSE)
        Me.GrbConnectDatabase.Controls.Add(Me.btnCONNECT)
        Me.GrbConnectDatabase.Controls.Add(Me.lblDisplay)
        Me.GrbConnectDatabase.Controls.Add(Me.PictureBox3)
        Me.GrbConnectDatabase.Controls.Add(Me.CboDatabase)
        Me.GrbConnectDatabase.Controls.Add(Me.txtServername)
        Me.GrbConnectDatabase.Controls.Add(Me.Label7)
        Me.GrbConnectDatabase.Controls.Add(Me.RdoSql)
        Me.GrbConnectDatabase.Controls.Add(Me.RdoWindows)
        Me.GrbConnectDatabase.Controls.Add(Me.GbUser)
        Me.GrbConnectDatabase.Controls.Add(Me.lblHeader)
        Me.GrbConnectDatabase.Controls.Add(Me.lblDatabasename)
        Me.GrbConnectDatabase.Controls.Add(Me.lblServerName)
        Me.GrbConnectDatabase.Location = New System.Drawing.Point(1, -6)
        Me.GrbConnectDatabase.Name = "GrbConnectDatabase"
        Me.GrbConnectDatabase.Size = New System.Drawing.Size(433, 608)
        Me.GrbConnectDatabase.TabIndex = 54
        Me.GrbConnectDatabase.TabStop = False
        '
        'btnCLOSE
        '
        Me.btnCLOSE.BackgroundImage = CType(resources.GetObject("btnCLOSE.BackgroundImage"), System.Drawing.Image)
        Me.btnCLOSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCLOSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCLOSE.ForeColor = System.Drawing.Color.White
        Me.btnCLOSE.Location = New System.Drawing.Point(237, 493)
        Me.btnCLOSE.Name = "btnCLOSE"
        Me.btnCLOSE.Size = New System.Drawing.Size(122, 51)
        Me.btnCLOSE.TabIndex = 68
        Me.btnCLOSE.Text = "CLOSE"
        Me.btnCLOSE.UseVisualStyleBackColor = True
        '
        'btnCONNECT
        '
        Me.btnCONNECT.BackgroundImage = CType(resources.GetObject("btnCONNECT.BackgroundImage"), System.Drawing.Image)
        Me.btnCONNECT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCONNECT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCONNECT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCONNECT.ForeColor = System.Drawing.Color.White
        Me.btnCONNECT.Location = New System.Drawing.Point(88, 492)
        Me.btnCONNECT.Name = "btnCONNECT"
        Me.btnCONNECT.Size = New System.Drawing.Size(122, 51)
        Me.btnCONNECT.TabIndex = 67
        Me.btnCONNECT.Text = "CONNECT"
        Me.btnCONNECT.UseVisualStyleBackColor = True
        '
        'lblDisplay
        '
        Me.lblDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblDisplay.ForeColor = System.Drawing.Color.Red
        Me.lblDisplay.Location = New System.Drawing.Point(24, 412)
        Me.lblDisplay.Name = "lblDisplay"
        Me.lblDisplay.Size = New System.Drawing.Size(380, 67)
        Me.lblDisplay.TabIndex = 66
        Me.lblDisplay.Text = "     "
        Me.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(95, 65)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(65, 63)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 65
        Me.PictureBox3.TabStop = False
        '
        'CboDatabase
        '
        Me.CboDatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.CboDatabase.FormattingEnabled = True
        Me.CboDatabase.Location = New System.Drawing.Point(171, 199)
        Me.CboDatabase.Name = "CboDatabase"
        Me.CboDatabase.Size = New System.Drawing.Size(216, 28)
        Me.CboDatabase.TabIndex = 64
        '
        'txtServername
        '
        Me.txtServername.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtServername.Location = New System.Drawing.Point(171, 161)
        Me.txtServername.MaxLength = 30
        Me.txtServername.Name = "txtServername"
        Me.txtServername.Size = New System.Drawing.Size(216, 26)
        Me.txtServername.TabIndex = 63
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gold
        Me.Label7.Location = New System.Drawing.Point(34, 244)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 18)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Authentication   :"
        '
        'RdoSql
        '
        Me.RdoSql.AutoSize = True
        Me.RdoSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RdoSql.ForeColor = System.Drawing.Color.White
        Me.RdoSql.Location = New System.Drawing.Point(171, 277)
        Me.RdoSql.Name = "RdoSql"
        Me.RdoSql.Size = New System.Drawing.Size(216, 24)
        Me.RdoSql.TabIndex = 61
        Me.RdoSql.TabStop = True
        Me.RdoSql.Text = "SQL Server Authentication"
        Me.RdoSql.UseVisualStyleBackColor = True
        '
        'RdoWindows
        '
        Me.RdoWindows.AutoSize = True
        Me.RdoWindows.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RdoWindows.ForeColor = System.Drawing.Color.White
        Me.RdoWindows.Location = New System.Drawing.Point(171, 243)
        Me.RdoWindows.Name = "RdoWindows"
        Me.RdoWindows.Size = New System.Drawing.Size(198, 24)
        Me.RdoWindows.TabIndex = 60
        Me.RdoWindows.TabStop = True
        Me.RdoWindows.Text = "Windows Authentication"
        Me.RdoWindows.UseVisualStyleBackColor = True
        '
        'GbUser
        '
        Me.GbUser.Controls.Add(Me.txtPassword)
        Me.GbUser.Controls.Add(Me.txtUsername)
        Me.GbUser.Controls.Add(Me.lblUsername)
        Me.GbUser.Controls.Add(Me.lblPassword)
        Me.GbUser.ForeColor = System.Drawing.Color.White
        Me.GbUser.Location = New System.Drawing.Point(66, 307)
        Me.GbUser.Name = "GbUser"
        Me.GbUser.Size = New System.Drawing.Size(338, 98)
        Me.GbUser.TabIndex = 59
        Me.GbUser.TabStop = False
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(108, 53)
        Me.txtPassword.MaxLength = 30
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(219, 26)
        Me.txtPassword.TabIndex = 52
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(108, 18)
        Me.txtUsername.MaxLength = 30
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(219, 26)
        Me.txtUsername.TabIndex = 51
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblUsername.ForeColor = System.Drawing.Color.Gold
        Me.lblUsername.Location = New System.Drawing.Point(7, 21)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(95, 18)
        Me.lblUsername.TabIndex = 10
        Me.lblUsername.Text = "Username :"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.Gold
        Me.lblPassword.Location = New System.Drawing.Point(9, 56)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(93, 18)
        Me.lblPassword.TabIndex = 11
        Me.lblPassword.Text = "Password :"
        '
        'lblHeader
        '
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Gold
        Me.lblHeader.Location = New System.Drawing.Point(156, 74)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(242, 45)
        Me.lblHeader.TabIndex = 54
        Me.lblHeader.Text = "เชื่อมต่อฐานข้อมูล"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblDatabasename
        '
        Me.lblDatabasename.AutoSize = True
        Me.lblDatabasename.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblDatabasename.ForeColor = System.Drawing.Color.Gold
        Me.lblDatabasename.Location = New System.Drawing.Point(35, 203)
        Me.lblDatabasename.Name = "lblDatabasename"
        Me.lblDatabasename.Size = New System.Drawing.Size(133, 18)
        Me.lblDatabasename.TabIndex = 56
        Me.lblDatabasename.Text = "DatabaseName :"
        '
        'lblServerName
        '
        Me.lblServerName.AutoSize = True
        Me.lblServerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblServerName.ForeColor = System.Drawing.Color.Gold
        Me.lblServerName.Location = New System.Drawing.Point(35, 164)
        Me.lblServerName.Name = "lblServerName"
        Me.lblServerName.Size = New System.Drawing.Size(131, 18)
        Me.lblServerName.TabIndex = 55
        Me.lblServerName.Text = "Server Name    :"
        '
        'FrmConnectDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(436, 603)
        Me.Controls.Add(Me.GrbConnectDatabase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmConnectDatabase"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "เชื่อมต่อฐานข้อมูล"
        Me.GrbConnectDatabase.ResumeLayout(False)
        Me.GrbConnectDatabase.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbUser.ResumeLayout(False)
        Me.GbUser.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrbConnectDatabase As System.Windows.Forms.GroupBox
    Friend WithEvents lblDisplay As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CboDatabase As System.Windows.Forms.ComboBox
    Friend WithEvents txtServername As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RdoSql As System.Windows.Forms.RadioButton
    Friend WithEvents RdoWindows As System.Windows.Forms.RadioButton
    Friend WithEvents GbUser As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblDatabasename As System.Windows.Forms.Label
    Friend WithEvents lblServerName As System.Windows.Forms.Label
    Friend WithEvents btnCLOSE As System.Windows.Forms.Button
    Friend WithEvents btnCONNECT As System.Windows.Forms.Button
End Class
