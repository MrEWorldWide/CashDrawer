<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashDrawer
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
        Me.Openbtn = New System.Windows.Forms.Button()
        Me.Exitbtn = New System.Windows.Forms.Button()
        Me.TestPortbtrn = New System.Windows.Forms.Button()
        Me.Portcombo = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Openbtn
        '
        Me.Openbtn.Location = New System.Drawing.Point(34, 97)
        Me.Openbtn.Margin = New System.Windows.Forms.Padding(6)
        Me.Openbtn.Name = "Openbtn"
        Me.Openbtn.Size = New System.Drawing.Size(150, 44)
        Me.Openbtn.TabIndex = 0
        Me.Openbtn.Text = "Open Drawer"
        Me.Openbtn.UseVisualStyleBackColor = True
        '
        'Exitbtn
        '
        Me.Exitbtn.Location = New System.Drawing.Point(153, 153)
        Me.Exitbtn.Margin = New System.Windows.Forms.Padding(6)
        Me.Exitbtn.Name = "Exitbtn"
        Me.Exitbtn.Size = New System.Drawing.Size(150, 44)
        Me.Exitbtn.TabIndex = 3
        Me.Exitbtn.Text = "Exit"
        Me.Exitbtn.UseVisualStyleBackColor = True
        '
        'TestPortbtrn
        '
        Me.TestPortbtrn.Location = New System.Drawing.Point(34, 41)
        Me.TestPortbtrn.Margin = New System.Windows.Forms.Padding(6)
        Me.TestPortbtrn.Name = "TestPortbtrn"
        Me.TestPortbtrn.Size = New System.Drawing.Size(150, 44)
        Me.TestPortbtrn.TabIndex = 4
        Me.TestPortbtrn.Text = "Test Port"
        Me.TestPortbtrn.UseVisualStyleBackColor = True
        '
        'Portcombo
        '
        Me.Portcombo.FormattingEnabled = True
        Me.Portcombo.Location = New System.Drawing.Point(193, 48)
        Me.Portcombo.Name = "Portcombo"
        Me.Portcombo.Size = New System.Drawing.Size(222, 33)
        Me.Portcombo.TabIndex = 5
        Me.Portcombo.Text = "Available Com Ports"
        '
        'CashDrawer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 214)
        Me.Controls.Add(Me.Portcombo)
        Me.Controls.Add(Me.TestPortbtrn)
        Me.Controls.Add(Me.Exitbtn)
        Me.Controls.Add(Me.Openbtn)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "CashDrawer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CashDrawer"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Openbtn As Button
    Friend WithEvents Exitbtn As Button
    Friend WithEvents TestPortbtrn As Button
    Friend WithEvents Portcombo As ComboBox
End Class
