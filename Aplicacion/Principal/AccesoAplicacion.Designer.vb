<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AccesoAplicacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccesoAplicacion))
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BotonEntrar = New System.Windows.Forms.Button()
        Me.BotonSalir = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.rolusuario = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBox2.Location = New System.Drawing.Point(12, 71)
        Me.TextBox2.MaxLength = 50
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(200, 23)
        Me.TextBox2.TabIndex = 19
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBox1.Location = New System.Drawing.Point(12, 27)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(200, 23)
        Me.TextBox1.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "USUARIO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "CONTRASEÑA"
        '
        'BotonEntrar
        '
        Me.BotonEntrar.BackColor = System.Drawing.SystemColors.Control
        Me.BotonEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BotonEntrar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BotonEntrar.Image = CType(resources.GetObject("BotonEntrar.Image"), System.Drawing.Image)
        Me.BotonEntrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BotonEntrar.Location = New System.Drawing.Point(12, 100)
        Me.BotonEntrar.Name = "BotonEntrar"
        Me.BotonEntrar.Size = New System.Drawing.Size(97, 23)
        Me.BotonEntrar.TabIndex = 20
        Me.BotonEntrar.Text = "ENTRAR"
        Me.BotonEntrar.UseVisualStyleBackColor = False
        '
        'BotonSalir
        '
        Me.BotonSalir.BackColor = System.Drawing.SystemColors.Control
        Me.BotonSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BotonSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BotonSalir.Image = CType(resources.GetObject("BotonSalir.Image"), System.Drawing.Image)
        Me.BotonSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BotonSalir.Location = New System.Drawing.Point(115, 100)
        Me.BotonSalir.Name = "BotonSalir"
        Me.BotonSalir.Size = New System.Drawing.Size(97, 23)
        Me.BotonSalir.TabIndex = 21
        Me.BotonSalir.Text = "SALIR"
        Me.BotonSalir.UseVisualStyleBackColor = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'rolusuario
        '
        Me.rolusuario.AutoSize = True
        Me.rolusuario.Location = New System.Drawing.Point(122, 9)
        Me.rolusuario.Name = "rolusuario"
        Me.rolusuario.Size = New System.Drawing.Size(52, 13)
        Me.rolusuario.TabIndex = 22
        Me.rolusuario.Text = "rolusuario"
        Me.rolusuario.Visible = False
        '
        'AccesoAplicacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(224, 136)
        Me.Controls.Add(Me.rolusuario)
        Me.Controls.Add(Me.BotonSalir)
        Me.Controls.Add(Me.BotonEntrar)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "AccesoAplicacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acceso"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BotonEntrar As System.Windows.Forms.Button
    Friend WithEvents BotonSalir As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents rolusuario As System.Windows.Forms.Label
End Class
