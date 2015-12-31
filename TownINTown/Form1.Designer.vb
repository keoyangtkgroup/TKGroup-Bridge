<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ตงคาระบบToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuConnectDatabase = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuConfigDevice = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuExitProgram = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnSnap = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.lblMemberType = New System.Windows.Forms.Label
        Me.lblCar = New System.Windows.Forms.Label
        Me.lblAccessRight = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.AxVideoCapX1 = New AxVIDEOCAPXLib.AxVideoCapX
        Me.BarrierInPort = New System.IO.Ports.SerialPort(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.AxVideoCapX2 = New AxVIDEOCAPXLib.AxVideoCapX
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.SerialPort2 = New System.IO.Ports.SerialPort(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.btnSnap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxVideoCapX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxVideoCapX2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(47, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ตงคาระบบToolStripMenuItem, Me.MenuExitProgram})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(859, 24)
        Me.MenuStrip1.TabIndex = 91
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ตงคาระบบToolStripMenuItem
        '
        Me.ตงคาระบบToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuConnectDatabase, Me.MenuConfigDevice})
        Me.ตงคาระบบToolStripMenuItem.Image = CType(resources.GetObject("ตงคาระบบToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ตงคาระบบToolStripMenuItem.Name = "ตงคาระบบToolStripMenuItem"
        Me.ตงคาระบบToolStripMenuItem.Size = New System.Drawing.Size(83, 20)
        Me.ตงคาระบบToolStripMenuItem.Text = "ตั้งค่าระบบ"
        '
        'MenuConnectDatabase
        '
        Me.MenuConnectDatabase.Image = CType(resources.GetObject("MenuConnectDatabase.Image"), System.Drawing.Image)
        Me.MenuConnectDatabase.Name = "MenuConnectDatabase"
        Me.MenuConnectDatabase.Size = New System.Drawing.Size(177, 22)
        Me.MenuConnectDatabase.Text = "ตั้งค่าฐานข้อมูล"
        '
        'MenuConfigDevice
        '
        Me.MenuConfigDevice.Image = CType(resources.GetObject("MenuConfigDevice.Image"), System.Drawing.Image)
        Me.MenuConfigDevice.Name = "MenuConfigDevice"
        Me.MenuConfigDevice.Size = New System.Drawing.Size(177, 22)
        Me.MenuConfigDevice.Text = "ตั้งการเชื่อมต่ออุปกรณ์"
        '
        'MenuExitProgram
        '
        Me.MenuExitProgram.Image = CType(resources.GetObject("MenuExitProgram.Image"), System.Drawing.Image)
        Me.MenuExitProgram.Name = "MenuExitProgram"
        Me.MenuExitProgram.Size = New System.Drawing.Size(99, 20)
        Me.MenuExitProgram.Text = "ออกโปรแกรม"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.btnSnap)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Panel9)
        Me.Panel2.Controls.Add(Me.lblMemberType)
        Me.Panel2.Controls.Add(Me.lblCar)
        Me.Panel2.Controls.Add(Me.lblAccessRight)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.AxVideoCapX1)
        Me.Panel2.Location = New System.Drawing.Point(12, 64)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(396, 317)
        Me.Panel2.TabIndex = 92
        '
        'btnSnap
        '
        Me.btnSnap.BackColor = System.Drawing.Color.Transparent
        Me.btnSnap.BackgroundImage = CType(resources.GetObject("btnSnap.BackgroundImage"), System.Drawing.Image)
        Me.btnSnap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSnap.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSnap.Location = New System.Drawing.Point(457, 23)
        Me.btnSnap.Name = "btnSnap"
        Me.btnSnap.Size = New System.Drawing.Size(29, 34)
        Me.btnSnap.TabIndex = 77
        Me.btnSnap.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(21, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(356, 281)
        Me.PictureBox1.TabIndex = 85
        Me.PictureBox1.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Transparent
        Me.Panel9.BackgroundImage = CType(resources.GetObject("Panel9.BackgroundImage"), System.Drawing.Image)
        Me.Panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel9.Location = New System.Drawing.Point(21, 1)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(70, 18)
        Me.Panel9.TabIndex = 76
        '
        'lblMemberType
        '
        Me.lblMemberType.AutoSize = True
        Me.lblMemberType.BackColor = System.Drawing.Color.Transparent
        Me.lblMemberType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberType.ForeColor = System.Drawing.Color.Gold
        Me.lblMemberType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMemberType.Location = New System.Drawing.Point(254, 392)
        Me.lblMemberType.Name = "lblMemberType"
        Me.lblMemberType.Size = New System.Drawing.Size(20, 18)
        Me.lblMemberType.TabIndex = 72
        Me.lblMemberType.Text = "   "
        '
        'lblCar
        '
        Me.lblCar.AutoSize = True
        Me.lblCar.BackColor = System.Drawing.Color.Transparent
        Me.lblCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCar.ForeColor = System.Drawing.Color.Gold
        Me.lblCar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCar.Location = New System.Drawing.Point(255, 416)
        Me.lblCar.Name = "lblCar"
        Me.lblCar.Size = New System.Drawing.Size(20, 18)
        Me.lblCar.TabIndex = 73
        Me.lblCar.Text = "   "
        '
        'lblAccessRight
        '
        Me.lblAccessRight.AutoSize = True
        Me.lblAccessRight.BackColor = System.Drawing.Color.Transparent
        Me.lblAccessRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccessRight.ForeColor = System.Drawing.Color.Gold
        Me.lblAccessRight.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAccessRight.Location = New System.Drawing.Point(255, 513)
        Me.lblAccessRight.Name = "lblAccessRight"
        Me.lblAccessRight.Size = New System.Drawing.Size(20, 18)
        Me.lblAccessRight.TabIndex = 73
        Me.lblAccessRight.Text = "   "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(164, 489)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 18)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "ทะเบียนรถ  :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(164, 464)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 18)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "ทะเบียนรถ  :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(165, 513)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 18)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "สิทธิ์ใช้งาน  :"
        '
        'AxVideoCapX1
        '
        Me.AxVideoCapX1.Enabled = True
        Me.AxVideoCapX1.Location = New System.Drawing.Point(21, 17)
        Me.AxVideoCapX1.Name = "AxVideoCapX1"
        Me.AxVideoCapX1.OcxState = CType(resources.GetObject("AxVideoCapX1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxVideoCapX1.Size = New System.Drawing.Size(356, 281)
        Me.AxVideoCapX1.TabIndex = 88
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.AxVideoCapX2)
        Me.Panel1.Location = New System.Drawing.Point(425, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(396, 317)
        Me.Panel1.TabIndex = 93
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Location = New System.Drawing.Point(457, 23)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 34)
        Me.PictureBox2.TabIndex = 77
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(21, 17)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(356, 281)
        Me.PictureBox3.TabIndex = 85
        Me.PictureBox3.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Location = New System.Drawing.Point(21, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(70, 18)
        Me.Panel3.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gold
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(254, 392)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 18)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "   "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gold
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(255, 416)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 18)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "   "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gold
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(255, 513)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 18)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "   "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(164, 489)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 18)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "ทะเบียนรถ  :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(164, 464)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 18)
        Me.Label9.TabIndex = 70
        Me.Label9.Text = "ทะเบียนรถ  :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(165, 513)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 18)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "สิทธิ์ใช้งาน  :"
        '
        'AxVideoCapX2
        '
        Me.AxVideoCapX2.Enabled = True
        Me.AxVideoCapX2.Location = New System.Drawing.Point(21, 17)
        Me.AxVideoCapX2.Name = "AxVideoCapX2"
        Me.AxVideoCapX2.OcxState = CType(resources.GetObject("AxVideoCapX2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxVideoCapX2.Size = New System.Drawing.Size(356, 281)
        Me.AxVideoCapX2.TabIndex = 88
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Yellow
        Me.Label11.Location = New System.Drawing.Point(183, 403)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 31)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "IN"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(596, 403)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 31)
        Me.Label12.TabIndex = 95
        Me.Label12.Text = "OUT"
        '
        'SerialPort2
        '
        Me.SerialPort2.PortName = "COM4"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(859, 472)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cap_PowerPlant"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.btnSnap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxVideoCapX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxVideoCapX2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ตงคาระบบToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuConnectDatabase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuConfigDevice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuExitProgram As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSnap As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents lblMemberType As System.Windows.Forms.Label
    Friend WithEvents lblCar As System.Windows.Forms.Label
    Friend WithEvents lblAccessRight As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents AxVideoCapX1 As AxVIDEOCAPXLib.AxVideoCapX
    Friend WithEvents BarrierInPort As System.IO.Ports.SerialPort
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents AxVideoCapX2 As AxVIDEOCAPXLib.AxVideoCapX
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SerialPort2 As System.IO.Ports.SerialPort
End Class
