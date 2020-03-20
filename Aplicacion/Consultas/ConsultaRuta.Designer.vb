<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaRuta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaRuta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BotonFiltrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BotonLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BotonExportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BotonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Contador = New System.Windows.Forms.ToolStripLabel()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.ColumnaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaVehiculo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaChofer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Columnasitiocarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaDestino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ColumnaVehiculo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaRutas2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BotonFiltrar, Me.ToolStripSeparator2, Me.BotonLimpiar, Me.ToolStripSeparator1, Me.BotonExportar, Me.ToolStripSeparator3, Me.BotonSalir, Me.ToolStripSeparator4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1084, 25)
        Me.ToolStrip1.TabIndex = 25
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.Contador})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 637)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1084, 25)
        Me.ToolStrip2.TabIndex = 76
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
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnaID, Me.ColumnaVehiculo, Me.ColumnaChofer, Me.ColumnaProducto, Me.Columnasitiocarga, Me.ColumnaDestino, Me.ColumnaEstado, Me.ColumnaFecha, Me.ColumnaHora})
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.GridColor = System.Drawing.SystemColors.Menu
        Me.DataGridView.Location = New System.Drawing.Point(3, 19)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridView.RowHeadersVisible = False
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(745, 584)
        Me.DataGridView.TabIndex = 77
        '
        'ColumnaID
        '
        Me.ColumnaID.DataPropertyName = "idruta"
        Me.ColumnaID.HeaderText = "ID RUTA"
        Me.ColumnaID.Name = "ColumnaID"
        Me.ColumnaID.ReadOnly = True
        Me.ColumnaID.Visible = False
        '
        'ColumnaVehiculo
        '
        Me.ColumnaVehiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaVehiculo.DataPropertyName = "idvehiculo"
        Me.ColumnaVehiculo.FillWeight = 139.6582!
        Me.ColumnaVehiculo.HeaderText = "VEHÍCULO"
        Me.ColumnaVehiculo.MinimumWidth = 60
        Me.ColumnaVehiculo.Name = "ColumnaVehiculo"
        Me.ColumnaVehiculo.ReadOnly = True
        Me.ColumnaVehiculo.Width = 70
        '
        'ColumnaChofer
        '
        Me.ColumnaChofer.DataPropertyName = "nombrechofer"
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnaChofer.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColumnaChofer.FillWeight = 31.74049!
        Me.ColumnaChofer.HeaderText = "CHOFER"
        Me.ColumnaChofer.MinimumWidth = 40
        Me.ColumnaChofer.Name = "ColumnaChofer"
        Me.ColumnaChofer.ReadOnly = True
        '
        'ColumnaProducto
        '
        Me.ColumnaProducto.DataPropertyName = "nombreproducto"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnaProducto.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColumnaProducto.FillWeight = 31.74049!
        Me.ColumnaProducto.HeaderText = "PRODUCTO"
        Me.ColumnaProducto.Name = "ColumnaProducto"
        Me.ColumnaProducto.ReadOnly = True
        '
        'Columnasitiocarga
        '
        Me.Columnasitiocarga.DataPropertyName = "nombresitiocarga"
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Columnasitiocarga.DefaultCellStyle = DataGridViewCellStyle4
        Me.Columnasitiocarga.FillWeight = 31.74049!
        Me.Columnasitiocarga.HeaderText = "SITIO DE CARGA"
        Me.Columnasitiocarga.Name = "Columnasitiocarga"
        Me.Columnasitiocarga.ReadOnly = True
        '
        'ColumnaDestino
        '
        Me.ColumnaDestino.DataPropertyName = "nombredestino"
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnaDestino.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColumnaDestino.FillWeight = 31.74049!
        Me.ColumnaDestino.HeaderText = "DESTINO"
        Me.ColumnaDestino.Name = "ColumnaDestino"
        Me.ColumnaDestino.ReadOnly = True
        '
        'ColumnaEstado
        '
        Me.ColumnaEstado.DataPropertyName = "nombreestado"
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnaEstado.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColumnaEstado.FillWeight = 31.74049!
        Me.ColumnaEstado.HeaderText = "ESTADO"
        Me.ColumnaEstado.Name = "ColumnaEstado"
        Me.ColumnaEstado.ReadOnly = True
        Me.ColumnaEstado.Visible = False
        '
        'ColumnaFecha
        '
        Me.ColumnaFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaFecha.DataPropertyName = "fecha"
        Me.ColumnaFecha.HeaderText = "FECHA"
        Me.ColumnaFecha.MinimumWidth = 50
        Me.ColumnaFecha.Name = "ColumnaFecha"
        Me.ColumnaFecha.ReadOnly = True
        Me.ColumnaFecha.Width = 70
        '
        'ColumnaHora
        '
        Me.ColumnaHora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaHora.DataPropertyName = "hora"
        Me.ColumnaHora.FillWeight = 401.6393!
        Me.ColumnaHora.HeaderText = "HORA REGISTRADA"
        Me.ColumnaHora.MinimumWidth = 50
        Me.ColumnaHora.Name = "ColumnaHora"
        Me.ColumnaHora.ReadOnly = True
        Me.ColumnaHora.Width = 75
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DataGridView)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(321, 28)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(751, 606)
        Me.GroupBox3.TabIndex = 87
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DETALLE DE CONSULTA"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 149)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(303, 236)
        Me.GroupBox2.TabIndex = 90
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "HISTORIAL DE RUTAS (EN LO QUE VA DE MES)"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnaVehiculo2, Me.ColumnaRutas2})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.Menu
        Me.DataGridView1.Location = New System.Drawing.Point(3, 19)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 45
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(297, 214)
        Me.DataGridView1.TabIndex = 49
        '
        'ColumnaVehiculo2
        '
        Me.ColumnaVehiculo2.DataPropertyName = "Vehiculo"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ColumnaVehiculo2.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColumnaVehiculo2.HeaderText = "VEHICULO"
        Me.ColumnaVehiculo2.Name = "ColumnaVehiculo2"
        Me.ColumnaVehiculo2.ReadOnly = True
        '
        'ColumnaRutas2
        '
        Me.ColumnaRutas2.DataPropertyName = "Conteo"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.ColumnaRutas2.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColumnaRutas2.HeaderText = "RUTAS GENERADAS"
        Me.ColumnaRutas2.Name = "ColumnaRutas2"
        Me.ColumnaRutas2.ReadOnly = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox4.Controls.Add(Me.Chart1)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 391)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(303, 243)
        Me.GroupBox4.TabIndex = 91
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "HISTORIAL DE RUTAS (EN LO QUE VA DE MES)"
        '
        'Chart1
        '
        ChartArea1.AxisX.LineColor = System.Drawing.Color.LightBlue
        ChartArea1.AxisX2.LineColor = System.Drawing.Color.LightBlue
        ChartArea1.AxisY.LineColor = System.Drawing.Color.LightBlue
        ChartArea1.AxisY2.LineColor = System.Drawing.Color.LightBlue
        ChartArea1.CursorX.SelectionColor = System.Drawing.Color.Red
        ChartArea1.CursorY.SelectionColor = System.Drawing.Color.Red
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Location = New System.Drawing.Point(6, 22)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.CustomProperties = "PointWidth=0.3"
        Series1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.IsValueShownAsLabel = True
        Series1.IsVisibleInLegend = False
        Series1.Name = "Rutas"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(291, 215)
        Me.Chart1.TabIndex = 3
        Title1.Name = "Title1"
        Me.Chart1.Titles.Add(Title1)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(303, 115)
        Me.GroupBox1.TabIndex = 92
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SELECCIONAR PERÍODO DE FECHAS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "DESDE"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DateTimePicker2.Location = New System.Drawing.Point(6, 81)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(257, 23)
        Me.DateTimePicker2.TabIndex = 66
        Me.DateTimePicker2.Value = New Date(2019, 4, 13, 0, 0, 0, 0)
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Checked = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 37)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(257, 23)
        Me.DateTimePicker1.TabIndex = 64
        Me.DateTimePicker1.Value = New Date(2019, 4, 13, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(6, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "HASTA"
        '
        'ConsultaRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1084, 662)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ConsultaRuta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Rutas por Fechas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Contador As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ColumnaID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaVehiculo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaChofer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaProducto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Columnasitiocarga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaDestino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaHora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaVehiculo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaRutas2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
