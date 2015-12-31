<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegister
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegister))
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnRegister = New System.Windows.Forms.Button
        Me.BtnTry = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.TxtMachine = New System.Windows.Forms.TextBox
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.TxtSerial = New System.Windows.Forms.TextBox
        Me.lblExpire = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(79, 342)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Expire ::"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(24, 313)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Serial Number ::"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(82, 283)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Name ::"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(46, 251)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Machine ID ::"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(179, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(185, 150)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("LilyUPC", 33.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(62, 190)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(426, 49)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "ST. Future Control Co.Ltd,"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnRegister
        '
        Me.BtnRegister.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRegister.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BtnRegister.Image = CType(resources.GetObject("BtnRegister.Image"), System.Drawing.Image)
        Me.BtnRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRegister.Location = New System.Drawing.Point(101, 370)
        Me.BtnRegister.Name = "BtnRegister"
        Me.BtnRegister.Size = New System.Drawing.Size(124, 40)
        Me.BtnRegister.TabIndex = 22
        Me.BtnRegister.Text = "Register"
        Me.BtnRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRegister.UseVisualStyleBackColor = True
        '
        'BtnTry
        '
        Me.BtnTry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTry.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BtnTry.Image = CType(resources.GetObject("BtnTry.Image"), System.Drawing.Image)
        Me.BtnTry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTry.Location = New System.Drawing.Point(248, 370)
        Me.BtnTry.Name = "BtnTry"
        Me.BtnTry.Size = New System.Drawing.Size(86, 40)
        Me.BtnTry.TabIndex = 22
        Me.BtnTry.Text = "Try"
        Me.BtnTry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnTry.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
        Me.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClose.Location = New System.Drawing.Point(357, 370)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(107, 40)
        Me.BtnClose.TabIndex = 22
        Me.BtnClose.Text = "Close"
        Me.BtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'TxtMachine
        '
        Me.TxtMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtMachine.Location = New System.Drawing.Point(148, 251)
        Me.TxtMachine.Name = "TxtMachine"
        Me.TxtMachine.Size = New System.Drawing.Size(316, 21)
        Me.TxtMachine.TabIndex = 23
        '
        'TxtName
        '
        Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtName.Location = New System.Drawing.Point(148, 283)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(316, 21)
        Me.TxtName.TabIndex = 23
        '
        'TxtSerial
        '
        Me.TxtSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TxtSerial.Location = New System.Drawing.Point(148, 313)
        Me.TxtSerial.Name = "TxtSerial"
        Me.TxtSerial.Size = New System.Drawing.Size(316, 21)
        Me.TxtSerial.TabIndex = 23
        '
        'lblExpire
        '
        Me.lblExpire.BackColor = System.Drawing.Color.Transparent
        Me.lblExpire.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblExpire.ForeColor = System.Drawing.Color.Red
        Me.lblExpire.Location = New System.Drawing.Point(148, 340)
        Me.lblExpire.Name = "lblExpire"
        Me.lblExpire.Size = New System.Drawing.Size(295, 24)
        Me.lblExpire.TabIndex = 24
        Me.lblExpire.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(520, 422)
        Me.Controls.Add(Me.lblExpire)
        Me.Controls.Add(Me.TxtSerial)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.TxtMachine)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnTry)
        Me.Controls.Add(Me.BtnRegister)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRegister"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Register"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnRegister As System.Windows.Forms.Button
    Friend WithEvents BtnTry As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents TxtMachine As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtSerial As System.Windows.Forms.TextBox
    Friend WithEvents lblExpire As System.Windows.Forms.Label
End Class
