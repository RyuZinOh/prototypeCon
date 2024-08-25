<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.placestuff = New System.Windows.Forms.Button()
        Me.stuff = New System.Windows.Forms.TextBox()
        Me.nrs = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(314, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADMIN CONTROL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(191, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(191, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "stuff"
        '
        'placestuff
        '
        Me.placestuff.Location = New System.Drawing.Point(194, 220)
        Me.placestuff.Name = "placestuff"
        Me.placestuff.Size = New System.Drawing.Size(75, 23)
        Me.placestuff.TabIndex = 3
        Me.placestuff.Text = "dropitem"
        Me.placestuff.UseVisualStyleBackColor = True
        '
        'stuff
        '
        Me.stuff.Location = New System.Drawing.Point(235, 130)
        Me.stuff.Name = "stuff"
        Me.stuff.Size = New System.Drawing.Size(100, 20)
        Me.stuff.TabIndex = 4
        '
        'nrs
        '
        Me.nrs.Location = New System.Drawing.Point(235, 170)
        Me.nrs.Name = "nrs"
        Me.nrs.Size = New System.Drawing.Size(100, 20)
        Me.nrs.TabIndex = 5
        '
        'AdminForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.nrs)
        Me.Controls.Add(Me.stuff)
        Me.Controls.Add(Me.placestuff)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AdminForm"
        Me.Text = "AdminForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents placestuff As Button
    Friend WithEvents stuff As TextBox
    Friend WithEvents nrs As TextBox
End Class
