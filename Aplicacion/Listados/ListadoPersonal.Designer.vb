﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoPersonal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListadoPersonal))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BotonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ComboTipoPersona = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripLabel()
        Me.ComboEstadoPersona = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.TextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BotonExportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BotonSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.Contador = New System.Windows.Forms.ToolStripLabel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.ColumnaChofer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaClasificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaTelefono1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaTelefono2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BotonGuardar, Me.ToolStripSeparator5, Me.ToolStripLabel3, Me.ComboTipoPersona, Me.ToolStripSeparator7, Me.ToolStripButton1, Me.ComboEstadoPersona, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.TextBox, Me.ToolStripSeparator2, Me.BotonExportar, Me.ToolStripSeparator1, Me.BotonSalir, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(984, 25)
        Me.ToolStrip1.TabIndex = 28
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BotonGuardar
        '
        Me.BotonGuardar.Image = CType(resources.GetObject("BotonGuardar.Image"), System.Drawing.Image)
        Me.BotonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BotonGuardar.Name = "BotonGuardar"
        Me.BotonGuardar.Size = New System.Drawing.Size(68, 22)
        Me.BotonGuardar.Text = "Aceptar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(77, 22)
        Me.ToolStripLabel3.Text = "Clasificación:"
        '
        'ComboTipoPersona
        '
        Me.ComboTipoPersona.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoPersona.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.ComboTipoPersona.Items.AddRange(New Object() {"CARGA", "LIVIANO", "PERSONAL"})
        Me.ComboTipoPersona.Name = "ComboTipoPersona"
        Me.ComboTipoPersona.Size = New System.Drawing.Size(170, 25)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripButton1.Text = "Estado:"
        '
        'ComboEstadoPersona
        '
        Me.ComboEstadoPersona.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboEstadoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEstadoPersona.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.ComboEstadoPersona.Items.AddRange(New Object() {"ACTIVO", "DE REPOSO", "DE PERMISO", "DE VACACIONES", "INACTIVO"})
        Me.ComboEstadoPersona.Name = "ComboEstadoPersona"
        Me.ComboEstadoPersona.Size = New System.Drawing.Size(170, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripLabel1.Text = "Buscar:"
        '
        'TextBox
        '
        Me.TextBox.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TextBox.Name = "TextBox"
        Me.TextBox.Size = New System.Drawing.Size(180, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BotonExportar
        '
        Me.BotonExportar.Image = CType(resources.GetObject("BotonExportar.Image"), System.Drawing.Image)
        Me.BotonExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BotonExportar.Name = "BotonExportar"
        Me.BotonExportar.Size = New System.Drawing.Size(108, 22)
        Me.BotonExportar.Text = "Exportar a Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BotonSalir
        '
        Me.BotonSalir.Image = CType(resources.GetObject("BotonSalir.Image"), System.Drawing.Image)
        Me.BotonSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BotonSalir.Name = "BotonSalir"
        Me.BotonSalir.Size = New System.Drawing.Size(49, 22)
        Me.BotonSalir.Text = "Salir"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripSeparator4, Me.ToolStripMenuItem3})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(116, 76)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(115, 22)
        Me.ToolStripMenuItem1.Text = "Resaltar"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(115, 22)
        Me.ToolStripMenuItem2.Text = "Copiar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(112, 6)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(115, 22)
        Me.ToolStripMenuItem3.Text = "Prueba"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(149, 76)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 30
        Me.TextBox1.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.Contador})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 567)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(984, 25)
        Me.ToolStrip2.TabIndex = 72
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripLabel2.Text = "REGISTROS ENCONTRADOS:"
        '
        'Contador
        '
        Me.Contador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Contador.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contador.Image = CType(resources.GetObject("Contador.Image"), System.Drawing.Image)
        Me.Contador.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Contador.Name = "Contador"
        Me.Contador.Size = New System.Drawing.Size(0, 22)
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(149, 102)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 73
        Me.TextBox2.Visible = False
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.AllowUserToResizeRows = False
        Me.DataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnaChofer, Me.ColumnaNombre, Me.ColumnaClasificacion, Me.ColumnaTelefono1, Me.ColumnaTelefono2, Me.ColumnaEstado})
        Me.DataGridView.GridColor = System.Drawing.SystemColors.Menu
        Me.DataGridView.Location = New System.Drawing.Point(12, 28)
        Me.DataGridView.MultiSelect = False
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.RowHeadersVisible = False
        Me.DataGridView.RowHeadersWidth = 45
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(960, 536)
        Me.DataGridView.TabIndex = 74
        '
        'ColumnaChofer
        '
        Me.ColumnaChofer.DataPropertyName = "idpersonal"
        Me.ColumnaChofer.HeaderText = "ID CHOFER"
        Me.ColumnaChofer.Name = "ColumnaChofer"
        Me.ColumnaChofer.ReadOnly = True
        Me.ColumnaChofer.Visible = False
        '
        'ColumnaNombre
        '
        Me.ColumnaNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaNombre.DataPropertyName = "nombrepersonal"
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnaNombre.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColumnaNombre.HeaderText = "NOMBRE"
        Me.ColumnaNombre.Name = "ColumnaNombre"
        Me.ColumnaNombre.ReadOnly = True
        Me.ColumnaNombre.Width = 240
        '
        'ColumnaClasificacion
        '
        Me.ColumnaClasificacion.DataPropertyName = "tipopersonal"
        Me.ColumnaClasificacion.HeaderText = "CLASIFICACIÓN"
        Me.ColumnaClasificacion.Name = "ColumnaClasificacion"
        Me.ColumnaClasificacion.ReadOnly = True
        '
        'ColumnaTelefono1
        '
        Me.ColumnaTelefono1.DataPropertyName = "Telefono1"
        Me.ColumnaTelefono1.HeaderText = "TELÉFONO 1"
        Me.ColumnaTelefono1.Name = "ColumnaTelefono1"
        Me.ColumnaTelefono1.ReadOnly = True
        '
        'ColumnaTelefono2
        '
        Me.ColumnaTelefono2.DataPropertyName = "Telefono2"
        Me.ColumnaTelefono2.HeaderText = "TELÉFONO 2"
        Me.ColumnaTelefono2.Name = "ColumnaTelefono2"
        Me.ColumnaTelefono2.ReadOnly = True
        '
        'ColumnaEstado
        '
        Me.ColumnaEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaEstado.DataPropertyName = "estadopersonal"
        Me.ColumnaEstado.HeaderText = "ESTADO"
        Me.ColumnaEstado.Name = "ColumnaEstado"
        Me.ColumnaEstado.ReadOnly = True
        Me.ColumnaEstado.Width = 150
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(149, 128)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 75
        '
        'ListadoPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(984, 592)
        Me.Controls.Add(Me.DataGridView)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ListadoPersonal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Personal"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BotonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BotonExportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BotonSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ComboEstadoPersona As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Contador As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ComboTipoPersona As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents ColumnaEstado As DataGridViewTextBoxColumn
    Friend WithEvents ColumnaTelefono2 As DataGridViewTextBoxColumn
    Friend WithEvents ColumnaTelefono1 As DataGridViewTextBoxColumn
    Friend WithEvents ColumnaClasificacion As DataGridViewTextBoxColumn
    Friend WithEvents ColumnaNombre As DataGridViewTextBoxColumn
    Friend WithEvents ColumnaChofer As DataGridViewTextBoxColumn
End Class
