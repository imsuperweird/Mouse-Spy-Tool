Imports System.Runtime.InteropServices
Public Class MainWindow

    Public LOCK As Boolean = False, COPY As Boolean = False, COMBO As Boolean = False, WAIT_TIMER As Boolean = False
    Public COPYTEXT As String = Nothing

    ' Register Hotkey
    <DllImport("User32.dll")>
    Public Shared Function RegisterHotKey(ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    End Function
    <DllImport("User32.dll")>
    Public Shared Function UnregisterHotKey(ByVal hwnd As IntPtr, ByVal id As Integer) As Integer
    End Function
    Public Const WM_HOTKEY = &H312
    Public Const MOD_CTRL = &H2
    Public Const MOD_ALT = &H1
    Public Const MOD_SHIFT = &H4
    Public CXY As Boolean = False, CRGB As Boolean = False, CCMYK As Boolean = False, CHSL As Boolean = False
    Protected Overrides Sub WndProc(ByRef m As Message)
        If (m.Msg = WM_HOTKEY) Then
            Dim id As IntPtr = m.WParam
            Select Case (id.ToString)
                Case "99988"
                    If Not WAIT_TIMER Then
                        If COMBO Then
                            COPYTEXT = Nothing
                            COMBO = False
                            CXY = False
                            CRGB = False
                            CCMYK = False
                            CHSL = False
                        Else
                            COMBO = True
                        End If
                    End If
                Case "99989"
                    If LOCK Then
                        LOCK = False
                    Else
                        LOCK = True
                    End If
                Case "99990"
                    Dim ssbmp As New Bitmap(32, 32, Imaging.PixelFormat.Format32bppPArgb)
                    ssbmp.SetResolution(32, 32)
                    Using g = Graphics.FromImage(ssbmp)
                        g.InterpolationMode = Drawing2D.InterpolationMode.Bilinear
                        g.CopyFromScreen(New Drawing.Point(MousePosition.X - (16), MousePosition.Y - (16)), New Drawing.Point(0, 0), ssbmp.Size)
                    End Using
                    Dim newbmp As New Bitmap(198, 198, Imaging.PixelFormat.Format32bppPArgb)
                    Using quack = Graphics.FromImage(newbmp)
                        quack.InterpolationMode = Drawing.Drawing2D.InterpolationMode.NearestNeighbor
                        quack.DrawImage(ssbmp, 0, 0, 198, 198)
                    End Using
                    Zoom.BackgroundImage = newbmp
                    Zoom.Show()
                Case "99991"
                    If Not WAIT_TIMER Then
                        If COMBO Then
                            If CXY Then
                                Clipboard.SetText(MOUSEXClipboard)
                                COPYTEXT = "MOUSE X"
                                CopyStart()
                            ElseIf CRGB Then
                                Clipboard.SetText(REDClipboard)
                                COPYTEXT = "RED"
                                CopyStart()
                            ElseIf CCMYK Then
                                Clipboard.SetText(CYANClipboard)
                                COPYTEXT = "CYAN"
                                CopyStart()
                            ElseIf CHSL Then
                                Clipboard.SetText(HUEClipboard)
                                COPYTEXT = "HUE"
                                CopyStart()
                            Else
                                CXY = True
                                COPYTEXT = "X, Y"
                            End If
                        Else
                            Clipboard.SetText(POSITIONXYClipboard)
                            COPYTEXT = "X, Y"
                            CopyStart()
                        End If
                    End If
                Case "99992"
                    If Not WAIT_TIMER Then
                        If COMBO Then
                            If CXY Then
                                Clipboard.SetText(MOUSEYClipboard)
                                COPYTEXT = "MOUSE Y"
                                CopyStart()
                            ElseIf CRGB Then
                                Clipboard.SetText(GREENClipboard)
                                COPYTEXT = "GREEN"
                                CopyStart()
                            ElseIf CCMYK Then
                                Clipboard.SetText(MAGENTAClipboard)
                                COPYTEXT = "MAGENTA"
                                CopyStart()
                            ElseIf CHSL Then
                                Clipboard.SetText(SATURATIONClipboard)
                                COPYTEXT = "SATURATION"
                                CopyStart()
                            Else
                                CRGB = True
                                COPYTEXT = "RGB"
                            End If
                        Else
                            Clipboard.SetText(RGBClipboard)
                            COPYTEXT = "RGB"
                            CopyStart()
                        End If
                    End If
                Case "99993"
                    If Not WAIT_TIMER Then
                        If COMBO Then
                            If CRGB Then
                                Clipboard.SetText(BLUEClipboard)
                                COPYTEXT = "BLUE"
                                CopyStart()
                            ElseIf CCMYK Then
                                Clipboard.SetText(YELLOWClipboard)
                                COPYTEXT = "YELLOW"
                                CopyStart()
                            ElseIf CHSL Then
                                Clipboard.SetText(LIGHTNESSClipboard)
                                COPYTEXT = "LIGHTNESS"
                                CopyStart()
                            Else
                                CCMYK = True
                                COPYTEXT = "CMYK"
                            End If
                        Else
                            Clipboard.SetText(CMYKClipboard)
                            COPYTEXT = "CMYK"
                            CopyStart()
                        End If
                    End If
                Case "99994"
                    If Not WAIT_TIMER Then
                        If COMBO Then
                            If CCMYK Then
                                Clipboard.SetText(KEYClipboard)
                                COPYTEXT = "KEY"
                                CopyStart()
                            Else
                                CHSL = True
                                COPYTEXT = "HSL"
                            End If
                        Else
                            Clipboard.SetText(HSLClipboard)
                            COPYTEXT = "HSL"
                            CopyStart()
                        End If
                    End If
                Case "99995"
                    If Not WAIT_TIMER Then
                        If Not COMBO Then
                            Clipboard.SetText(HEXCODEClipboard)
                            COPYTEXT = "HEXCODE"
                            CopyStart()
                        End If
                    End If
            End Select
        End If
        MyBase.WndProc(m)
    End Sub
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RegisterHotKey(Me.Handle, 99988, MOD_CTRL Xor MOD_ALT Xor MOD_SHIFT, Keys.K)
        RegisterHotKey(Me.Handle, 99989, MOD_CTRL Xor MOD_ALT Xor MOD_SHIFT, Keys.L)
        RegisterHotKey(Me.Handle, 99990, MOD_CTRL Xor MOD_ALT Xor MOD_SHIFT, Keys.Z)
        RegisterHotKey(Me.Handle, 99991, MOD_CTRL Xor MOD_ALT Xor MOD_SHIFT, Keys.D1)
        RegisterHotKey(Me.Handle, 99992, MOD_CTRL Xor MOD_ALT Xor MOD_SHIFT, Keys.D2)
        RegisterHotKey(Me.Handle, 99993, MOD_CTRL Xor MOD_ALT Xor MOD_SHIFT, Keys.D3)
        RegisterHotKey(Me.Handle, 99994, MOD_CTRL Xor MOD_ALT Xor MOD_SHIFT, Keys.D4)
        RegisterHotKey(Me.Handle, 99995, MOD_CTRL Xor MOD_ALT Xor MOD_SHIFT, Keys.D5)
    End Sub
    Private Sub MainWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        UnregisterHotKey(Me.Handle, 99988)
        UnregisterHotKey(Me.Handle, 99989)
        UnregisterHotKey(Me.Handle, 99990)
        UnregisterHotKey(Me.Handle, 99991)
        UnregisterHotKey(Me.Handle, 99992)
        UnregisterHotKey(Me.Handle, 99993)
        UnregisterHotKey(Me.Handle, 99994)
        UnregisterHotKey(Me.Handle, 99995)
    End Sub

    ' Copy
    Public Sub CopyStart()
        COMBO = False
        CXY = False
        CRGB = False
        CCMYK = False
        CHSL = False
        COPY = True
        WAIT_TIMER = True
        CopyTimer.Start()
    End Sub
    Private Sub CopyTimer_Tick(sender As Object, e As EventArgs) Handles CopyTimer.Tick
        COPYTEXT = Nothing
        COPY = False
        WAIT_TIMER = False
        CopyTimer.Stop()
    End Sub

    ' Loop
    Public Property MouseEnterWindow As Boolean
    Public Property MouseEnterIcon As Boolean
    Public POSITIONX As Integer, POSITIONY As Integer, RED As Integer, GREEN As Integer, BLUE As Integer, CYAN As Integer, MAGENTA As Integer, YELLOW As Integer, KEY As Integer, HUE As Integer, SATURATION As Integer, LIGHTNESS As Integer, HEXCODE As String
    Public POSITIONXYClipboard As String, RGBClipboard As String, CMYKClipboard As String, HSLClipboard As String, HEXCODEClipboard As String, MOUSEXClipboard As String, MOUSEYClipboard As String, REDClipboard As String, GREENClipboard As String, BLUEClipboard As String, CYANClipboard As String, MAGENTAClipboard As String, YELLOWClipboard As String, KEYClipboard As String, HUEClipboard As String, SATURATIONClipboard As String, LIGHTNESSClipboard As String
    Private Sub LoopInterval_Tick(sender As Object, e As EventArgs) Handles LoopInterval.Tick
        If Not MouseEnterWindow Then

            Me.InfoColorBox.Image = Global.Mouse_Spy_Tool.My.Resources.Resources.colorbox

            If Not LOCK Then
                ' Mouse Position
                POSITIONX = Windows.Forms.Cursor.Position.X
                POSITIONY = Windows.Forms.Cursor.Position.Y

                ' RGB
                Dim bmp As New Bitmap(1, 1)
                Using screenshot As Graphics = Graphics.FromImage(bmp)
                    screenshot.CopyFromScreen(Windows.Forms.Cursor.Position, New Point(0, 0), New Size(1, 1))
                End Using
                RED = Integer.Parse(bmp.GetPixel(0, 0).R)
                GREEN = Integer.Parse(bmp.GetPixel(0, 0).G)
                BLUE = Integer.Parse(bmp.GetPixel(0, 0).B)

                ' CMYK
                Dim R As Decimal, G As Decimal, B As Decimal, C As Decimal, M As Decimal, Y As Decimal, K As Decimal, max As Decimal
                If RED = 0 And GREEN = 0 And BLUE = 0 Then
                    C = 0
                    M = 0
                    Y = 0
                    K = 0
                Else
                    R = Decimal.Parse(RED) / 255
                    G = Decimal.Parse(GREEN) / 255
                    B = Decimal.Parse(BLUE) / 255
                    max = R
                    If max < G Then
                        max = G
                    End If
                    If max < B Then
                        max = B
                    End If
                    C = (max - R) / max
                    M = (max - G) / max
                    Y = (max - B) / max
                    K = 1 - max
                End If
                C = Decimal.Parse(C * 100)
                M = Decimal.Parse(M * 100)
                Y = Decimal.Parse(Y * 100)
                K = Decimal.Parse(K * 100)
                CYAN = Math.Round(C)
                MAGENTA = Math.Round(M)
                YELLOW = Math.Round(Y)
                KEY = Math.Round(K)

                ' HSL
                HUE = Math.Round(Color.FromArgb(RED, GREEN, BLUE).GetHue())
                SATURATION = Math.Round(Color.FromArgb(RED, GREEN, BLUE).GetSaturation() * 100)
                LIGHTNESS = Math.Round(Color.FromArgb(RED, GREEN, BLUE).GetBrightness() * 100)

                ' HexCode
                HEXCODE = String.Format("{0}{1}{2}", RED.ToString("X").PadLeft(2, "0"), GREEN.ToString("X").PadLeft(2, "0"), BLUE.ToString("X").PadLeft(2, "0"))
            End If

            ' BackColor
            Me.InfoColorBox.BackColor = System.Drawing.Color.FromArgb(RED, GREEN, BLUE)
            Me.Invalidate()

            ' Clipboards
            ' Mouse
            POSITIONXYClipboard = POSITIONX.ToString + ", " + POSITIONY.ToString
            MOUSEXClipboard = POSITIONX.ToString
            MOUSEYClipboard = POSITIONY.ToString
            ' RGB
            RGBClipboard = RED.ToString + ", " + GREEN.ToString + ", " + BLUE.ToString
            REDClipboard = RED.ToString
            GREENClipboard = GREEN.ToString
            BLUEClipboard = BLUE.ToString
            ' CMYK
            CMYKClipboard = CYAN.ToString + ", " + MAGENTA.ToString + ", " + YELLOW.ToString + ", " + KEY.ToString
            CYANClipboard = CYAN.ToString
            MAGENTAClipboard = MAGENTA.ToString
            YELLOWClipboard = YELLOW.ToString
            KEYClipboard = KEY.ToString
            ' HSL
            HSLClipboard = HUE.ToString + ", " + SATURATION.ToString + ", " + LIGHTNESS.ToString
            HUEClipboard = HUE.ToString
            SATURATIONClipboard = SATURATION.ToString
            LIGHTNESSClipboard = LIGHTNESS.ToString
            ' HEXCODE
            HEXCODEClipboard = String.Format("{0}{1}{2}", RED.ToString("X").PadLeft(2, "0"), GREEN.ToString("X").PadLeft(2, "0"), BLUE.ToString("X").PadLeft(2, "0"))

            ' Labels
            Label1.Text = "X, Y: " + POSITIONX.ToString + ", " + POSITIONY.ToString
            Label2.Text = "RGB: " + RED.ToString + ", " + GREEN.ToString + ", " + BLUE.ToString
            Label3.Text = "CMYK: " + CYAN.ToString + ", " + MAGENTA.ToString + ", " + YELLOW.ToString + ", " + KEY.ToString
            Label4.Text = "HSL: " + HUE.ToString + ", " + SATURATION.ToString + ", " + LIGHTNESS.ToString
            Label5.Text = "HEX: #" + HEXCODE
            If LOCK Then
                Label6.Text = "LOCKED"
            Else
                Label6.Text = "UNLOCKED"
            End If
            Label7.Text = COPYTEXT
            If COMBO Then
                Label8.Text = "COMBO:"
            ElseIf COPY Then
                Label8.Text = "COPIED:"
            Else
                Label8.Text = Nothing
            End If

        Else
            If MouseEnterIcon Then
                Me.InfoColorBox.BackColor = System.Drawing.Color.LightGray
            Else
                Me.InfoColorBox.BackColor = System.Drawing.Color.White
            End If
            Me.InfoColorBox.Image = Global.Mouse_Spy_Tool.My.Resources.Resources.icon
            Label1.Text = "X, Y: Ctrl+Alt+Shift+1"
            Label2.Text = "RGB: Ctrl+Alt+Shift+2"
            Label3.Text = "CMYK: Ctrl+Alt+Shift+3"
            Label4.Text = "HSL: Ctrl+Alt+Shift+4"
            Label5.Text = "HEX: Ctrl+Alt+Shift+5"
            If LOCK Then
                Label6.Text = "UNLOCK: Ctrl+Alt+Shift+L"
            Else
                Label6.Text = "LOCK: Ctrl+Alt+Shift+L"
            End If
            Label7.Text = "ZOOM: Ctrl+Alt+Shift+Z"
            Label8.Text = Nothing
        End If
    End Sub

    ' Mouse Enter Window
    Private Sub MainWindow_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        MouseEnterWindow = True
        MouseEnterIcon = False
    End Sub
    Private Sub MainWindow_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        MouseEnterWindow = False
        MouseEnterIcon = False
    End Sub
    Private Sub InfoColorBox_MouseEnter(sender As Object, e As EventArgs) Handles InfoColorBox.MouseEnter
        MouseEnterWindow = True
        MouseEnterIcon = True
    End Sub
    Private Sub InfoColorBox_MouseLeave(sender As Object, e As EventArgs) Handles InfoColorBox.MouseLeave
        MouseEnterWindow = False
        MouseEnterIcon = False
        Me.InfoColorBox.BackColor = System.Drawing.Color.White
    End Sub

    ' Move Window
    Public Property MoveWindow As Boolean
    Public Property MoveWindow_MousePosition As Point
    Private Sub MainWindow_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveWindow = True
            Me.Cursor = Cursors.Default
            MoveWindow_MousePosition = e.Location
        End If
    End Sub
    Private Sub MainWindow_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then
            MoveWindow = False
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub MainWindow_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If MoveWindow Then
            Me.Location = Me.Location + (e.Location - MoveWindow_MousePosition)
        End If
    End Sub

    ' Buttons
    Private Sub MinimizePictureBox_Click(sender As Object, e As EventArgs) Handles MinimizePictureBox.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub MinimizePictureBox_MouseEnter(sender As Object, e As EventArgs) Handles MinimizePictureBox.MouseEnter
        MainWindow_MouseEnter(sender, e)
        Me.MinimizePictureBox.BackColor = System.Drawing.Color.LightCyan
    End Sub
    Private Sub MinimizePictureBox_MouseLeave(sender As Object, e As EventArgs) Handles MinimizePictureBox.MouseLeave
        MainWindow_MouseLeave(sender, e)
        Me.MinimizePictureBox.BackColor = System.Drawing.Color.White
    End Sub
    Private Sub ClosePictureBox_Click(sender As Object, e As EventArgs) Handles ClosePictureBox.Click
        Application.Exit()
    End Sub
    Private Sub ClosePictureBox_MouseEnter(sender As Object, e As EventArgs) Handles ClosePictureBox.MouseEnter
        MainWindow_MouseEnter(sender, e)
        Me.ClosePictureBox.BackColor = System.Drawing.Color.LightCoral
    End Sub
    Private Sub ClosePictureBox_MouseLeave(sender As Object, e As EventArgs) Handles ClosePictureBox.MouseLeave
        MainWindow_MouseLeave(sender, e)
        Me.ClosePictureBox.BackColor = System.Drawing.Color.White
    End Sub
    ' Other Stuff
    Private Sub BackgroundPanel_MouseDown(sender As Object, e As MouseEventArgs) Handles BackgroundPanel.MouseDown
        MainWindow_MouseDown(sender, e)
    End Sub
    Private Sub BackgroundPanel_MouseUp(sender As Object, e As MouseEventArgs) Handles BackgroundPanel.MouseUp
        MainWindow_MouseUp(sender, e)
    End Sub
    Private Sub BackgroundPanel_MouseMove(sender As Object, e As MouseEventArgs) Handles BackgroundPanel.MouseMove
        MainWindow_MouseMove(sender, e)
    End Sub
    Private Sub BackgroundPanel_MouseEnter(sender As Object, e As EventArgs) Handles BackgroundPanel.MouseEnter
        MainWindow_MouseEnter(sender, e)
    End Sub
    Private Sub BackgroundPanel_MouseLeave(sender As Object, e As EventArgs) Handles BackgroundPanel.MouseLeave
        MainWindow_MouseLeave(sender, e)
    End Sub
    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        MainWindow_MouseDown(sender, e)
    End Sub
    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        MainWindow_MouseUp(sender, e)
    End Sub
    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        MainWindow_MouseMove(sender, e)
    End Sub
    Private Sub Label1_MouseEnter(sender As Object, e As EventArgs) Handles Label1.MouseEnter
        MainWindow_MouseEnter(sender, e)
    End Sub
    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        MainWindow_MouseLeave(sender, e)
    End Sub
    Private Sub Label2_MouseDown(sender As Object, e As MouseEventArgs) Handles Label2.MouseDown
        MainWindow_MouseDown(sender, e)
    End Sub
    Private Sub InfoColorBox_Click(sender As Object, e As EventArgs) Handles InfoColorBox.Click
        ShortcutInfo.Show()
    End Sub
    Private Sub Label2_MouseEnter(sender As Object, e As EventArgs) Handles Label2.MouseEnter
        MainWindow_MouseEnter(sender, e)
    End Sub
    Private Sub Label2_MouseLeave(sender As Object, e As EventArgs) Handles Label2.MouseLeave
        MainWindow_MouseLeave(sender, e)
    End Sub
    Private Sub Label2_MouseMove(sender As Object, e As MouseEventArgs) Handles Label2.MouseMove
        MainWindow_MouseMove(sender, e)
    End Sub
    Private Sub Label2_MouseUp(sender As Object, e As MouseEventArgs) Handles Label2.MouseUp
        MainWindow_MouseUp(sender, e)
    End Sub
    Private Sub Label3_MouseDown(sender As Object, e As MouseEventArgs) Handles Label3.MouseDown
        MainWindow_MouseDown(sender, e)
    End Sub
    Private Sub Label3_MouseEnter(sender As Object, e As EventArgs) Handles Label3.MouseEnter
        MainWindow_MouseEnter(sender, e)
    End Sub
    Private Sub Label3_MouseLeave(sender As Object, e As EventArgs) Handles Label3.MouseLeave
        MainWindow_MouseLeave(sender, e)
    End Sub
    Private Sub Label3_MouseMove(sender As Object, e As MouseEventArgs) Handles Label3.MouseMove
        MainWindow_MouseMove(sender, e)
    End Sub
    Private Sub Label3_MouseUp(sender As Object, e As MouseEventArgs) Handles Label3.MouseUp
        MainWindow_MouseUp(sender, e)
    End Sub
    Private Sub Label4_MouseDown(sender As Object, e As MouseEventArgs) Handles Label4.MouseDown
        MainWindow_MouseDown(sender, e)
    End Sub
    Private Sub Label4_MouseEnter(sender As Object, e As EventArgs) Handles Label4.MouseEnter
        MainWindow_MouseEnter(sender, e)
    End Sub
    Private Sub Label4_MouseLeave(sender As Object, e As EventArgs) Handles Label4.MouseLeave
        MainWindow_MouseLeave(sender, e)
    End Sub
    Private Sub Label4_MouseMove(sender As Object, e As MouseEventArgs) Handles Label4.MouseMove
        MainWindow_MouseMove(sender, e)
    End Sub
    Private Sub Label4_MouseUp(sender As Object, e As MouseEventArgs) Handles Label4.MouseUp
        MainWindow_MouseUp(sender, e)
    End Sub
    Private Sub Label5_MouseDown(sender As Object, e As MouseEventArgs) Handles Label5.MouseDown
        MainWindow_MouseDown(sender, e)
    End Sub
    Private Sub Label5_MouseEnter(sender As Object, e As EventArgs) Handles Label5.MouseEnter
        MainWindow_MouseEnter(sender, e)
    End Sub
    Private Sub Label5_MouseLeave(sender As Object, e As EventArgs) Handles Label5.MouseLeave
        MainWindow_MouseLeave(sender, e)
    End Sub
    Private Sub Label5_MouseMove(sender As Object, e As MouseEventArgs) Handles Label5.MouseMove
        MainWindow_MouseMove(sender, e)
    End Sub
    Private Sub Label5_MouseUp(sender As Object, e As MouseEventArgs) Handles Label5.MouseUp
        MainWindow_MouseUp(sender, e)
    End Sub
    Private Sub Label6_MouseDown(sender As Object, e As MouseEventArgs) Handles Label6.MouseDown
        MainWindow_MouseDown(sender, e)
    End Sub
    Private Sub Label6_MouseEnter(sender As Object, e As EventArgs) Handles Label6.MouseEnter
        MainWindow_MouseEnter(sender, e)
    End Sub
    Private Sub Label6_MouseLeave(sender As Object, e As EventArgs) Handles Label6.MouseLeave
        MainWindow_MouseLeave(sender, e)
    End Sub
    Private Sub Label6_MouseMove(sender As Object, e As MouseEventArgs) Handles Label6.MouseMove
        MainWindow_MouseMove(sender, e)
    End Sub
    Private Sub Label6_MouseUp(sender As Object, e As MouseEventArgs) Handles Label6.MouseUp
        MainWindow_MouseUp(sender, e)
    End Sub
    Private Sub Label7_MouseDown(sender As Object, e As MouseEventArgs) Handles Label7.MouseDown
        MainWindow_MouseDown(sender, e)
    End Sub
    Private Sub Label7_MouseEnter(sender As Object, e As EventArgs) Handles Label7.MouseEnter
        MainWindow_MouseEnter(sender, e)
    End Sub
    Private Sub Label7_MouseLeave(sender As Object, e As EventArgs) Handles Label7.MouseLeave
        MainWindow_MouseLeave(sender, e)
    End Sub
    Private Sub Label7_MouseMove(sender As Object, e As MouseEventArgs) Handles Label7.MouseMove
        MainWindow_MouseMove(sender, e)
    End Sub
    Private Sub Label7_MouseUp(sender As Object, e As MouseEventArgs) Handles Label7.MouseUp
        MainWindow_MouseUp(sender, e)
    End Sub
    Private Sub Label8_MouseDown(sender As Object, e As MouseEventArgs) Handles Label8.MouseDown
        MainWindow_MouseDown(sender, e)
    End Sub
    Private Sub Label8_MouseEnter(sender As Object, e As EventArgs) Handles Label8.MouseEnter
        MainWindow_MouseEnter(sender, e)
    End Sub
    Private Sub Label8_MouseLeave(sender As Object, e As EventArgs) Handles Label8.MouseLeave
        MainWindow_MouseLeave(sender, e)
    End Sub
    Private Sub Label8_MouseMove(sender As Object, e As MouseEventArgs) Handles Label8.MouseMove
        MainWindow_MouseMove(sender, e)
    End Sub
    Private Sub Label8_MouseUp(sender As Object, e As MouseEventArgs) Handles Label8.MouseUp
        MainWindow_MouseUp(sender, e)
    End Sub
End Class