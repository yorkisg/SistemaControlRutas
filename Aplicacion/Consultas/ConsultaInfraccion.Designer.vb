﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaInfraccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaInfraccion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BotonFiltrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BotonLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BotonExportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BotonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BotonBuscar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.ColumnaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaVehiculo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaChofer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaVelocidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Contador = New System.Windows.Forms.ToolStripLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BotonFiltrar, Me.ToolStripSeparator2, Me.BotonLimpiar, Me.ToolStripSeparator1, Me.BotonExportar, Me.ToolStripSeparator3, Me.BotonSalir, Me.ToolStripSeparator5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(984, 25)
        Me.ToolStrip1.TabIndex = 75
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BotonFiltrar
        '
        Me.BotonFiltrar.Image = CType(resources.GetObject("BotonFiltrar.Image"), System.Drawing.Image)
        Me.BotonFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BotonFiltrar.Name = "BotonFiltrar"
        Me.BotonFiltrar.Size = New System.Drawing.Size(78, 22)
        Me.BotonFiltrar.Text = "Consultar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BotonLimpiar
        '
        Me.BotonLimpiar.Image = CType(resources.GetObject("BotonLimpiar.Image"), System.Drawing.Image)
        Me.BotonLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BotonLimpiar.Name = "BotonLimpiar"
        Me.BotonLimpiar.Size = New System.Drawing.Size(67, 22)
        Me.BotonLimpiar.Text = "Limpiar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BotonExportar
        '
        Me.BotonExportar.Image = CType(resources.GetObject("BotonExportar.Image"), System.Drawing.Image)
        Me.BotonExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BotonExportar.Name = "BotonExportar"
        Me.BotonExportar.Size = New System.Drawing.Size(108, 22)
        Me.BotonExportar.Text = "Exportar a Excel"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BotonSalir
        '
        Me.BotonSalir.Image = CType(resources.GetObject("BotonSalir.Image"), System.Drawing.Image)
        Me.BotonSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BotonSalir.Name = "BotonSalir"
        Me.BotonSalir.Size = New System.Drawing.Size(49, 22)
        Me.BotonSalir.Text = "Salir"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.BotonBuscar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(303, 556)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SELECCIONAR PERÍODO DE FECHAS"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 37)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(240, 23)
        Me.DateTimePicker1.TabIndex = 76
        Me.DateTimePicker1.Value = New Date(2019, 3, 12, 18, 55, 59, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "VEHÍCULO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "DESDE"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DateTimePicker2.Location = New System.Drawing.Point(6, 81)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(240, 23)
        Me.DateTimePicker2.TabIndex = 78
        Me.DateTimePicker2.Value = New Date(2019, 3, 12, 18, 56, 3, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(6, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "HASTA"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButton2.Location = New System.Drawing.Point(6, 196)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(70, 19)
        Me.RadioButton2.TabIndex = 74
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "LIVIANO"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButton1.Location = New System.Drawing.Point(6, 171)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(64, 19)
        Me.RadioButton1.TabIndex = 73
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "CARGA"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(6, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 15)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "TIPO DE VEHÍCULO"
        '
        'BotonBuscar
        '
        Me.BotonBuscar.Image = CType(resources.GetObject("BotonBuscar.Image"), System.Drawing.Image)
        Me.BotonBuscar.Location = New System.Drawing.Point(269, 121)
        Me.BotonBuscar.Name = "BotonBuscar"
        Me.BotonBuscar.Size = New System.Drawing.Size(28, 28)
        Me.BotonBuscar.TabIndex = 71
        Me.BotonBuscar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Vehiculo"
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.TextBox1.Location = New System.Drawing.Point(6, 125)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(240, 22)
        Me.TextBox1.TabIndex = 55
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(132, 192)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(114, 23)
        Me.TextBox2.TabIndex = 80
        Me.TextBox2.Visible = False
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.AllowUserToResizeRows = False
        Me.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnaID, Me.ColumnaVehiculo, Me.ColumnaChofer, Me.ColumnaVelocidad, Me.ColumnaEstado, Me.ColumnaFecha, Me.ColumnaHora})
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.GridColor = System.Drawing.SystemColors.Menu
        Me.DataGridView.Location = New System.Drawing.Point(3, 19)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridView.RowHeadersVisible = False
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(645, 534)
        Me.DataGridView.TabIndex = 80
        '
        'ColumnaID
        '
        Me.ColumnaID.DataPropertyName = "idregistroinfraccion"
        Me.ColumnaID.HeaderText = "ID HISTORIAL"
        Me.ColumnaID.Name = "ColumnaID"
        Me.ColumnaID.ReadOnly = True
        Me.ColumnaID.Visible = False
        '
        'ColumnaVehiculo
        '
        Me.ColumnaVehiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaVehiculo.DataPropertyName = "vehiculo"
        Me.ColumnaVehiculo.FillWeight = 139.6582!
        Me.ColumnaVehiculo.HeaderText = "VEHÍCULO"
        Me.ColumnaVehiculo.MinimumWidth = 80
        Me.ColumnaVehiculo.Name = "ColumnaVehiculo"
        Me.ColumnaVehiculo.ReadOnly = True
        '
        'ColumnaChofer
        '
        Me.ColumnaChofer.DataPropertyName = "nombrechofer"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnaChofer.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColumnaChofer.HeaderText = "CHOFER"
        Me.ColumnaChofer.MinimumWidth = 100
        Me.ColumnaChofer.Name = "ColumnaChofer"
        Me.ColumnaChofer.ReadOnly = True
        '
        'ColumnaVelocidad
        '
        Me.ColumnaVelocidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaVelocidad.DataPropertyName = "velocidad"
        Me.ColumnaVelocidad.FillWeight = 31.74049!
        Me.ColumnaVelocidad.HeaderText = "VELOCIDAD KM/H"
        Me.ColumnaVelocidad.MinimumWidth = 80
        Me.ColumnaVelocidad.Name = "ColumnaVelocidad"
        Me.ColumnaVelocidad.ReadOnly = True
        Me.ColumnaVelocidad.Width = 105
        '
        'ColumnaEstado
        '
        Me.ColumnaEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaEstado.DataPropertyName = "estadovehiculo"
        Me.ColumnaEstado.HeaderText = "ESTADO"
        Me.ColumnaEstado.MinimumWidth = 60
        Me.ColumnaEstado.Name = "ColumnaEstado"
        Me.ColumnaEstado.ReadOnly = True
        '
        'ColumnaFecha
        '
        Me.ColumnaFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaFecha.DataPropertyName = "fecha"
        Me.ColumnaFecha.HeaderText = "FECHA"
        Me.ColumnaFecha.MinimumWidth = 80
        Me.ColumnaFecha.Name = "ColumnaFecha"
        Me.ColumnaFecha.ReadOnly = True
        Me.ColumnaFecha.Width = 95
        '
        'ColumnaHora
        '
        Me.ColumnaHora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaHora.DataPropertyName = "hora"
        Me.ColumnaHora.FillWeight = 31.74049!
        Me.ColumnaHora.HeaderText = "HORA REGISTRADA"
        Me.ColumnaHora.MinimumWidth = 80
        Me.ColumnaHora.Name = "ColumnaHora"
        Me.ColumnaHora.ReadOnly = True
        Me.ColumnaHora.Width = 92
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.Contador})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 587)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(984, 25)
        Me.ToolStrip2.TabIndex = 81
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripLabel1.Text = "REGISTROS ENCONTRADOS:"
        '
        'Contador
        '
        Me.Contador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Contador.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Contador.Image = CType(resources.GetObject("Contador.Image"), System.Drawing.Image)
        Me.Contador.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Contador.Name = "Contador"
        Me.Contador.Size = New System.Drawing.Size(0, 22)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(321, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(651, 556)
        Me.GroupBox2.TabIndex = 82
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "HISTORIAL DE INFRACCIONES"
        '
        'ConsultaInfraccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 612)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ConsultaInfraccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Infracciones de Velocidad por Vehiculos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BotonFiltrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BotonLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BotonExportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BotonSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BotonBuscar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Contador As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ColumnaID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaVehiculo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaChofer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaVelocidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaHora As System.Windows.Forms.DataGridViewTextBoxColumn
End Class