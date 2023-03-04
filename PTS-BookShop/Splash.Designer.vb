<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Splash
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Myprogress = New Guna.UI2.WinForms.Guna2CircleProgressBar()
        Me.PercentLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Myprogress.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Phetsarath OT", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(252, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(309, 67)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ຮ້ານຂາຍປື້ມ PTS"
        '
        'Myprogress
        '
        Me.Myprogress.Controls.Add(Me.PercentLabel)
        Me.Myprogress.FillColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.Myprogress.FillThickness = 10
        Me.Myprogress.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Myprogress.ForeColor = System.Drawing.Color.White
        Me.Myprogress.Location = New System.Drawing.Point(272, 89)
        Me.Myprogress.Minimum = 0
        Me.Myprogress.Name = "Myprogress"
        Me.Myprogress.ProgressThickness = 10
        Me.Myprogress.ShadowDecoration.CustomizableEdges = CustomizableEdges1
        Me.Myprogress.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Myprogress.Size = New System.Drawing.Size(225, 225)
        Me.Myprogress.TabIndex = 3
        Me.Myprogress.Text = "Guna2CircleProgressBar1"
        '
        'PercentLabel
        '
        Me.PercentLabel.AutoSize = True
        Me.PercentLabel.Font = New System.Drawing.Font("Phetsarath OT", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PercentLabel.ForeColor = System.Drawing.Color.Black
        Me.PercentLabel.Location = New System.Drawing.Point(54, 75)
        Me.PercentLabel.Name = "PercentLabel"
        Me.PercentLabel.Size = New System.Drawing.Size(74, 73)
        Me.PercentLabel.TabIndex = 4
        Me.PercentLabel.Text = "%"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Phetsarath OT", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(263, 327)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(286, 44)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "PoweredByPTSCode"
        '
        'Timer1
        '
        '
        'Splash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BlueViolet
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Myprogress)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Splash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Myprogress.ResumeLayout(False)
        Me.Myprogress.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Myprogress As Guna.UI2.WinForms.Guna2CircleProgressBar
    Friend WithEvents PercentLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer1 As Timer
End Class
