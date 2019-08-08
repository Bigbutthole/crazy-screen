Imports System.Drawing
Imports System.Windows.Forms

Module Module1
    Public Declare Function GetWindowDC Lib "user32" (ByVal hwnd As Long) As Long '获得整个屏幕绘制
    Public Declare Function GetDesktopWindow Lib "user32" () As Long '获得整个桌面绘制
    Sub Main()
Main:
        Dim slp As Double = 1000 '决定休眠时间。
        Dim temp1 As Windows.Forms.Screen = Screen.PrimaryScreen
        Dim a As New Bitmap(temp1.WorkingArea.Size.Width, temp1.WorkingArea.Size.Height)
        Dim aaa As Graphics = Graphics.FromHdc(GetWindowDC(GetDesktopWindow()))
        Dim aaab As Graphics = Graphics.FromImage(a)
        Dim sa As New Point(0, 0)
        Do
            Try
                slp -= 10
                If slp <= 0 Then
                    slp = 1
                End If
                aaab.CopyFromScreen(New Point, New Point, temp1.WorkingArea.Size)
                Dim Hicon As IntPtr = a.GetHicon()
                aaa.DrawIcon(Icon.FromHandle(Hicon), New Rectangle With {
                    .Width = temp1.WorkingArea.Width * 0.9,
                    .Height = temp1.WorkingArea.Height * 0.9,
                    .X = temp1.WorkingArea.Width * 0.05,
                    .Y = temp1.WorkingArea.Height * 0.05
                             })
                Threading.Thread.Sleep(slp)
                aaab.Dispose()
                a.Dispose()
                a = New Bitmap(temp1.WorkingArea.Size.Width, temp1.WorkingArea.Size.Height)
                aaab = Graphics.FromImage(a)
            Catch
                aaa.Dispose()
                aaab.Dispose()
                a.Dispose()
                Threading.Thread.Sleep(10000)
                GoTo Main
            End Try
        Loop
    End Sub
End Module
