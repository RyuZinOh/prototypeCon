<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class userlogin
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
        Me.usernames = New System.Windows.Forms.TextBox()
        Me.passwords = New System.Windows.Forms.TextBox()
        Me.loginas = New System.Windows.Forms.Button()
        Me.LOGIN = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'usernames
        '
        Me.usernames.Location = New System.Drawing.Point(238, 128)
        Me.usernames.Name = "usernames"
        Me.usernames.Size = New System.Drawing.Size(100, 20)
        Me.usernames.TabIndex = 0
        '
        'passwords
        '
        Me.passwords.Location = New System.Drawing.Point(238, 169)
        Me.passwords.Name = "passwords"
        Me.passwords.Size = New System.Drawing.Size(100, 20)
        Me.passwords.TabIndex = 1
        '
        'loginas
        '
        Me.loginas.Location = New System.Drawing.Point(263, 219)
        Me.loginas.Name = "loginas"
        Me.loginas.Size = New System.Drawing.Size(75, 23)
        Me.loginas.TabIndex = 2
        Me.loginas.Text = "LOGIN"
        Me.loginas.UseVisualStyleBackColor = True
        '
        'LOGIN
        '
        Me.LOGIN.AutoSize = True
        Me.LOGIN.Location = New System.Drawing.Point(247, 71)
        Me.LOGIN.Name = "LOGIN"
        Me.LOGIN.Size = New System.Drawing.Size(73, 13)
        Me.LOGIN.TabIndex = 3
        Me.LOGIN.Text = "USER LOGIN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(159, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Username"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(159, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "password"
        '
        'userlogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LOGIN)
        Me.Controls.Add(Me.loginas)
        Me.Controls.Add(Me.passwords)
        Me.Controls.Add(Me.usernames)
        Me.Name = "userlogin"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents usernames As TextBox
    Friend WithEvents passwords As TextBox
    Friend WithEvents loginas As Button
    Friend WithEvents LOGIN As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
