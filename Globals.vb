Imports System.IO
Imports System.Text.RegularExpressions
Imports System.IO.Ports

Module Globals

    Public InputData As String = ""
    Public BlowUpYes, BlowUpNo, BlowUpCancel, BlowUpOk As Integer

    Public PortScale, PortCashDrawer, PortTest As System.IO.Ports.SerialPort
    Public rdthread, threadtest, statusthread As System.Threading.Thread
    

    Public Sub OpenDrawer(PortToOpen As String)
        SQLcon()
        Dim port As New System.IO.Ports.SerialPort
        'this Is code for the cash register to open
        Try

            port = New System.IO.Ports.SerialPort(PortToOpen)
            port.PortName = PortToOpen
            port.BaudRate = 9600
            port.Parity = IO.Ports.Parity.None
            port.DataBits = 8
            port.StopBits = IO.Ports.StopBits.One
            port.Handshake = IO.Ports.Handshake.RequestToSend
            port.RtsEnable = True
            port.DtrEnable = True
            port.WriteTimeout = 400
            Try
                port.Open()
            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try
            'port.Open()

            If port.IsOpen = True Then
                
                Try
                    port.Write(Chr(1))
                Catch ex As Exception
                    If port.IsOpen = True Then port.Close()
                    port = Nothing
                    CustomError("OpenDrawer()", "SQL Insert" & vbCrLf & ex.ToString & vbCrLf)
                    Exit Sub
                End Try
            Else
                port.Close()
                port = Nothing
                Exit Sub
            End If

        Catch ex As TimeoutException
            If port.IsOpen = True Then port.Close()
            port = Nothing
            'CustomError("OpenDrawer", "TimeOut" & vbCrLf & ex.ToString & vbCrLf)
            MsgBox("Drawer not connected! Check your connection and equipment setting.")
            Exit Sub
        Catch ex As Exception
            If port.IsOpen = True Then port.Close()
            port = Nothing
            'CustomError("OpenDrawer", "Error opening port: " & CashDrawerPort.ToString)
            'make security record
            SQLcon()
            cmd = New SqlCommand("INSERT INTO Security(TimeOfDay, EmpID, Location, Type, Reference) VALUES('" & Now & "','" & EmployeeID & "','System: " & System.Net.Dns.GetHostName & " User: " & Environment.UserName & "', 'DrawerFailure','" & ReceiptID.ToString & "') ", SQLconnect)
            'Dim cmd2 = New SqlCommand("SELECT EmpID, FirstName, LastName, Admin FROM dbo.Employees WHERE EmpID='" & UserName & "' AND Password='" & Password & "'", SQLconnect)
            reader = cmd.ExecuteReader()

            Exit Sub
        End Try
        'make security record
        SQLcon()
        cmd = New SqlCommand("INSERT INTO Security(TimeOfDay, EmpID, Location, Type, Reference) VALUES('" & Now & "','" & EmployeeID & "','System: " & System.Net.Dns.GetHostName & " User: " & Environment.UserName & "', 'Open Drawer','Change Till') ", SQLconnect)
        'Dim cmd2 = New SqlCommand("SELECT EmpID, FirstName, LastName, Admin FROM dbo.Employees WHERE EmpID='" & UserName & "' AND Password='" & Password & "'", SQLconnect)
        reader = cmd.ExecuteReader()
        If port.IsOpen = True Then port.Close()
        port = Nothing
        'MsgBox("Cash drawer test complete.")

    End Sub
 
    Public Function CustomError(ByVal CurrentProcedureName As String, Optional ByVal ExtraMessage As String = "")
        Try


            Dim message As String

            message = "An error occured:  " & vbObjectError & vbCrLf
            If Len(ExtraMessage) <> 0 Then
                message = message & ExtraMessage & vbCrLf
            End If
            message = message & "Procedure " & CurrentProcedureName & vbCrLf & vbCrLf & Err.Description
            MsgBox(message, vbCritical + vbOKOnly, "ERROR!")

            Dim FileString As String = ErrorLogString & "\MHMPOSErrorLog.txt"
            'Dim FileString As String = "c:\MHMPOSErrorLog.txt"
            If My.Computer.FileSystem.FileExists(FileString) = False Then
                'if the file doesn't exist then create it
                File.Create(FileString).Dispose()
            End If

            Using sw As StreamWriter = File.AppendText(FileString)
                'Write the error to the log
                sw.WriteLine("Time: " & Date.Now & vbCrLf & "Routine: " & CurrentProcedureName & vbCrLf & ExtraMessage)
            End Using


        Catch ex As Exception
            'MsgBox("Custom error function failed", vbOKOnly)
            Exit Function
        End Try
        SQLcon()
        Return 0
    End Function

End Module