<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.BackgroundPanel = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LoopInterval = New System.Windows.Forms.Timer(Me.components)
        Me.CopyTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ClosePictureBox = New System.Windows.Forms.PictureBox()
        Me.MinimizePictureBox = New System.Windows.Forms.PictureBox()
        Me.InfoColorBox = New System.Windows.Forms.PictureBox()
        Me.BackgroundPanel.SuspendLayout()
        CType(Me.ClosePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinimizePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InfoColorBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackgroundPanel
        '
        Me.BackgroundPanel.BackColor = System.Drawing.Color.White
        Me.BackgroundPanel.Controls.Add(Me.Label8)
        Me.BackgroundPanel.Controls.Add(Me.Label7)
        Me.BackgroundPanel.Controls.Add(Me.Label6)
        Me.BackgroundPanel.Controls.Add(Me.Label5)
        Me.BackgroundPanel.Controls.Add(Me.Label4)
        Me.BackgroundPanel.Controls.Add(Me.Label3)
        Me.BackgroundPanel.Controls.Add(Me.Label2)
        Me.BackgroundPanel.Controls.Add(Me.Label1)
        Me.BackgroundPanel.Controls.Add(Me.ClosePictureBox)
        Me.BackgroundPanel.Controls.Add(Me.MinimizePictureBox)
        Me.BackgroundPanel.Controls.Add(Me.InfoColorBox)
        Me.BackgroundPanel.Location = New System.Drawing.Point(1, 1)
        Me.BackgroundPanel.Name = "BackgroundPanel"
        Me.BackgroundPanel.Size = New System.Drawing.Size(160, 80)
        Me.BackgroundPanel.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(7, 12)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = " "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(44, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 12)
        Me.Label7.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(44, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "UNLOCKED"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "HEX: #123456"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "HSL: 100, 100, 100"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "CMYK: 100, 100, 100, 100"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "RGB: 255, 255, 255"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "X, Y: 0, 0"
        '
        'LoopInterval
        '
        Me.LoopInterval.Enabled = True
        '
        'CopyTimer
        '
        Me.CopyTimer.Interval = 1000
        '
        'ClosePictureBox
        '
        Me.ClosePictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ClosePictureBox.Image = Global.Mouse_Spy_Tool.My.Resources.Resources.close
        Me.ClosePictureBox.Location = New System.Drawing.Point(28, 45)
        Me.ClosePictureBox.Margin = New System.Windows.Forms.Padding(0)
        Me.ClosePictureBox.Name = "ClosePictureBox"
        Me.ClosePictureBox.Size = New System.Drawing.Size(15, 15)
        Me.ClosePictureBox.TabIndex = 2
        Me.ClosePictureBox.TabStop = False
        '
        'MinimizePictureBox
        '
        Me.MinimizePictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MinimizePictureBox.Image = Global.Mouse_Spy_Tool.My.Resources.Resources.minimize
        Me.MinimizePictureBox.Location = New System.Drawing.Point(3, 45)
        Me.MinimizePictureBox.Margin = New System.Windows.Forms.Padding(0)
        Me.MinimizePictureBox.Name = "MinimizePictureBox"
        Me.MinimizePictureBox.Size = New System.Drawing.Size(15, 15)
        Me.MinimizePictureBox.TabIndex = 1
        Me.MinimizePictureBox.TabStop = False
        '
        'InfoColorBox
        '
        Me.InfoColorBox.BackColor = System.Drawing.Color.White
        Me.InfoColorBox.BackgroundImage = Global.Mouse_Spy_Tool.My.Resources.Resources.colorbox
        Me.InfoColorBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.InfoColorBox.Image = Global.Mouse_Spy_Tool.My.Resources.Resources.colorbox
        Me.InfoColorBox.Location = New System.Drawing.Point(3, 3)
        Me.InfoColorBox.Margin = New System.Windows.Forms.Padding(0)
        Me.InfoColorBox.Name = "InfoColorBox"
        Me.InfoColorBox.Size = New System.Drawing.Size(40, 40)
        Me.InfoColorBox.TabIndex = 0
        Me.InfoColorBox.TabStop = False
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(162, 82)
        Me.Controls.Add(Me.BackgroundPanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainWindow"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mouse Spy Tool"
        Me.TopMost = True
        Me.BackgroundPanel.ResumeLayout(False)
        Me.BackgroundPanel.PerformLayout()
        CType(Me.ClosePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinimizePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InfoColorBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BackgroundPanel As Panel
    Friend WithEvents InfoColorBox As PictureBox
    Friend WithEvents LoopInterval As Timer
    Friend WithEvents MinimizePictureBox As PictureBox
    Friend WithEvents ClosePictureBox As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents CopyTimer As Timer
End Class
