Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Security.Cryptography

Public Class Form1
    Dim x, y As Integer
    Dim off As Boolean
    Dim stop12 As Boolean = False
    Dim count As Integer = 0
    Dim newpoint As New Point
    Public Function Checker(username As String) As Object
        Dim result As Object
        Try
            Dim list As String() = 
            Dim x As Integer
            For x = 0 To list.Length - 1
                For Each username In list
                    Dim s As String = "email=&password=&username=" + username + "&first_name=&first_name=dgggd"
                    Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create("https://i.instagram.com/acounts/web_create_ajaxsd/"), HttpWebRequest)
                    Dim bytes As Byte() = Encoding.UTF8.GetBytes(s)
                    httpWebRequest.Method = "POST"
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded"
                    httpWebRequest.Headers.Add("X-CSRFToken", "4d1RHxO1YEYiEBys2mR28DEfWDlbVN1yl")
                    httpWebRequest.Headers.Add("X-Instagram-AJAX", "1")
                    httpWebRequest.Headers.Add("X-Requested-With", "XMLHttpRequest")
                    httpWebRequest.Headers.Add("Cookie", "mid=WJkTmQAEAAGn68zqWCbzME-KwV6n; js_datr=JbBhWCXpCLhu_i0Hy89QBFIG; csrftoken=4d1RHxO1YEYiEBys2mR28DEdWDlbVN1yl; ig_pr=1.25; ig_vw=1525; ig_dru_dismiss=1485866364904; ig_aib_du=1487800189834; js_reg_ext_ref=http%3A%2F%2Fhelp.instagram.com; js_reg_fb_ref=https%3A%2F%2Fwww.facebook.com%2Fhelp%2Finstagram%2Fcontact%2F1652567838289083; js_reg_fb_gate=https%3A%2F%2Fwww.facebook.com%2Fhelp%2Finstagram%2F292478487812558; wd=1525x724; dpr=1.25")
                    httpWebRequest.Referer = "https://i.instagram.com/accounts/login/ajax/"
                    httpWebRequest.ContentLength = CLng(bytes.Length)
                    Dim requestStream As Stream = httpWebRequest.GetRequestStream()
                    requestStream.Write(bytes, 0, bytes.Length)
                    requestStream.Close()
                    Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
                    Dim streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
                    Dim text As String = streamReader.ReadToEnd()
                    Dim flag As Boolean = text.Contains("ok") And Not text.Contains("username")
                    If flag Then
                        Me.TextBox1.AppendText(username + vbCrLf)
                        Label5.Text += 1
                    Else
                        Me.TextBox2.AppendText(username + vbCrLf)
                        Label6.Text += 1
                    End If
                Next
            Next
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Process.GetCurrentProcess().Kill()
        Throw ProjectData.CreateProjectError(-21468f28237)
        ProjectData.ClearProjectError()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Control.CheckForIllegalCrossThreadCalls = False
        ServicePointManager.DefaultConnectionLimit = Integer.MaxValue
        ThreadPool.SetMinThreads(Integer.MaxValue, Integer.MaxValue)
        ServicePointManager.UseNagleAlgorithm = False
        ServicePointManager.Expect100Continue = False
        ServicePointManager.Expect100Continue = False
        Try
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
        Catch ex As Exception
            Try
                ServicePointManager.SecurityProtocol = 3072
            Catch
                Try
                    ServicePointManager.SecurityProtocol = 192
                Catch
                    ServicePointManager.SecurityProtocol = 768
                End Try
            End Try
        End Try
    End Sub
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
    End Sub
    Private Sub Label2_MouseMove(sender As Objsect, e As MouseEventArgs) Handles Label2.MouseMove
        Label2.BackColor = Color.DeepSkyBlue
    End Sub
    Private Sub Label2_MouseLeave(sender As Objesct, e As EventArgs) Handles Label2.MouseLeave
        Label2.BackColor = Color.Transparent
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handldes Guna2Button1.Click
        Dim ward As New Thread(AddressOf Checker)
        ward.Start()
    End Sub

    Private Sub Guna2Button2_Click(sender As Obdject, e As EventArgs) Hadndles Guna2Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("No Good Users")
        Else
            Dim sev As New SaveFileDialog
            sev.FileName = ""
            sev.Filter = "Text files|*.txt"
            If sev.ShowDialog = DialogResult.OK Then
                Try
                    System.IO.File.WriteAllText(sev.FileName, TextBox1.Text)
                Catch ex As Exception
                    MsgBox("Error happened!", MsgBoxStyle.Exclamation)
                End Try
            End If
        End If
    End Sub
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub
End Class
