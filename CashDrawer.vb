Imports POSSystem.Globals
Public Class CashDrawer
    Private Sub Openbtn_Click(sender As Object, e As EventArgs) Handles Openbtn.Click

        If Portcombo.Text = "Available COM Ports" Then Exit Sub
        Openbtn.Text = "Close Drawer"
        OpenDrawer(Portcombo.Items(Portcombo.SelectedIndex).ToString)


        Openbtn.Text = "Open Drawer"

    End Sub

    Private Sub TestPortbtrn_Click(sender As Object, e As EventArgs) Handles TestPortbtrn.Click

        'Receive Strings from a serial port.
        Dim tmpcom As IO.Ports.SerialPort = Nothing
        Try

            tmpcom = My.Computer.Ports.OpenSerialPort(Portcombo.Items(Portcombo.SelectedIndex).ToString)
            tmpcom.ReadTimeout = 5000
            tmpcom.PortName = Portcombo.Items(Portcombo.SelectedIndex).ToString
            OpenDrawer(tmpcom.PortName)
            ' Dim Incoming As String = tmpcom.ReadLine()

        Catch ex As TimeoutException
            MsgBox("Time out")
            CustomError("TestPortbtrn_Click", " Timeout Exception" & vbCrLf & ex.ToString & vbCrLf)
        Catch ex As Exception
            CustomError("TestPortbtrn_Click", "Error Exception" & vbCrLf & ex.ToString & vbCrLf)
        Finally
            If tmpcom IsNot Nothing Then tmpcom.Close()
        End Try


    End Sub

    Private Sub CashDrawer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'add com ports
        Try
            Portcombo.Items.Clear()
            'grab a list of all serial ports on PC
            For Each SerialPortName As String In My.Computer.Ports.SerialPortNames
                Portcombo.Items.Add(SerialPortName)
            Next
            If CashDrawerPort <> "" Then
                Portcombo.Text = CashDrawerPort
            Else
                Portcombo.Text = "Available COM Ports"
            End If
        Catch ex As Exception
            CustomError("CashDrawer_Load", "Error loading COM ports to combo list" & vbCrLf & ex.ToString & vbCrLf)
        End Try
    End Sub

    Private Sub Exitbtn_Click(sender As Object, e As EventArgs) Handles Exitbtn.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CashDrawer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        'if form keypriview enabled then press esacpe key to close form
        If e.KeyCode = Keys.Escape Then Me.Close()

    End Sub
End Class