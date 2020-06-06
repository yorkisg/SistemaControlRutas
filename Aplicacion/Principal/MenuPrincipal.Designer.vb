<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MenuPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuPrincipal))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuPrincipal2 = New System.Windows.Forms.MenuStrip()
        Me.MenuMaestros = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPersonal = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuProductos = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menusitiocargaes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuVehiculos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuGestionRutas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSeguimientoCarga = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSeguimientoLiviano = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuSeguimientoTaller = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSeguimientoTransporte = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuConsultas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuConsultarChofer = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuConsultarInfracciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuConsultarIncidencias = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuConsultaConsumos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuListadoDeInfractores = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuListadoCompelto = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuConsultaGrupoProducto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuGuiaTelefonica = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEstadisticas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuHistorialDeRutas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuConfiguracion = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuFlotas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEstados = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuSalir2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.usuariorol = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuPrincipal2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuPrincipal2
        '
        Me.MenuPrincipal2.BackColor = System.Drawing.Color.AliceBlue
        Me.MenuPrincipal2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuPrincipal2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuMaestros, Me.MenuGestionRutas, Me.MenuConsultas, Me.MenuEstadisticas, Me.MenuConfiguracion, Me.MenuSalir})
        Me.MenuPrincipal2.Location = New System.Drawing.Point(0, 0)
        Me.MenuPrincipal2.Name = "MenuPrincipal2"
        Me.MenuPrincipal2.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuPrincipal2.Size = New System.Drawing.Size(984, 25)
        Me.MenuPrincipal2.TabIndex = 9
        Me.MenuPrincipal2.Text = "MenuPrincipal"
        '
        'MenuMaestros
        '
        Me.MenuMaestros.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MenuMaestros.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuPersonal, Me.MenuProductos, Me.Menusitiocargaes, Me.MenuVehiculos})
        Me.MenuMaestros.Image = CType(resources.GetObject("MenuMaestros.Image"), System.Drawing.Image)
        Me.MenuMaestros.Name = "MenuMaestros"
        Me.MenuMaestros.Size = New System.Drawing.Size(129, 21)
        Me.MenuMaestros.Text = "Datos Maestros"
        '
        'MenuPersonal
        '
        Me.MenuPersonal.Image = CType(resources.GetObject("MenuPersonal.Image"), System.Drawing.Image)
        Me.MenuPersonal.Name = "MenuPersonal"
        Me.MenuPersonal.Size = New System.Drawing.Size(165, 22)
        Me.MenuPersonal.Text = "Personal"
        '
        'MenuProductos
        '
        Me.MenuProductos.Image = CType(resources.GetObject("MenuProductos.Image"), System.Drawing.Image)
        Me.MenuProductos.Name = "MenuProductos"
        Me.MenuProductos.Size = New System.Drawing.Size(165, 22)
        Me.MenuProductos.Text = "Productos"
        '
        'Menusitiocargaes
        '
        Me.Menusitiocargaes.Image = CType(resources.GetObject("Menusitiocargaes.Image"), System.Drawing.Image)
        Me.Menusitiocargaes.Name = "Menusitiocargaes"
        Me.Menusitiocargaes.Size = New System.Drawing.Size(165, 22)
        Me.Menusitiocargaes.Text = "Sitios de Carga"
        '
        'MenuVehiculos
        '
        Me.MenuVehiculos.Image = CType(resources.GetObject("MenuVehiculos.Image"), System.Drawing.Image)
        Me.MenuVehiculos.Name = "MenuVehiculos"
        Me.MenuVehiculos.Size = New System.Drawing.Size(165, 22)
        Me.MenuVehiculos.Text = "Vehiculos"
        '
        'MenuGestionRutas
        '
        Me.MenuGestionRutas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuSeguimientoCarga, Me.MenuSeguimientoLiviano, Me.ToolStripSeparator3, Me.MenuSeguimientoTaller, Me.MenuSeguimientoTransporte, Me.ToolStripSeparator7})
        Me.MenuGestionRutas.Image = CType(resources.GetObject("MenuGestionRutas.Image"), System.Drawing.Image)
        Me.MenuGestionRutas.Name = "MenuGestionRutas"
        Me.MenuGestionRutas.Size = New System.Drawing.Size(134, 21)
        Me.MenuGestionRutas.Text = "Control de Rutas"
        '
        'MenuSeguimientoCarga
        '
        Me.MenuSeguimientoCarga.Image = CType(resources.GetObject("MenuSeguimientoCarga.Image"), System.Drawing.Image)
        Me.MenuSeguimientoCarga.Name = "MenuSeguimientoCarga"
        Me.MenuSeguimientoCarga.Size = New System.Drawing.Size(289, 22)
        Me.MenuSeguimientoCarga.Text = "Seguimiento a Vehiculos de Carga"
        '
        'MenuSeguimientoLiviano
        '
        Me.MenuSeguimientoLiviano.Image = CType(resources.GetObject("MenuSeguimientoLiviano.Image"), System.Drawing.Image)
        Me.MenuSeguimientoLiviano.Name = "MenuSeguimientoLiviano"
        Me.MenuSeguimientoLiviano.Size = New System.Drawing.Size(289, 22)
        Me.MenuSeguimientoLiviano.Text = "Seguimiento a Vehiculos Livianos"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(286, 6)
        '
        'MenuSeguimientoTaller
        '
        Me.MenuSeguimientoTaller.Image = CType(resources.GetObject("MenuSeguimientoTaller.Image"), System.Drawing.Image)
        Me.MenuSeguimientoTaller.Name = "MenuSeguimientoTaller"
        Me.MenuSeguimientoTaller.Size = New System.Drawing.Size(289, 22)
        Me.MenuSeguimientoTaller.Text = "Gestión de Taller (80%)"
        '
        'MenuSeguimientoTransporte
        '
        Me.MenuSeguimientoTransporte.Image = CType(resources.GetObject("MenuSeguimientoTransporte.Image"), System.Drawing.Image)
        Me.MenuSeguimientoTransporte.Name = "MenuSeguimientoTransporte"
        Me.MenuSeguimientoTransporte.Size = New System.Drawing.Size(289, 22)
        Me.MenuSeguimientoTransporte.Text = "Gestión de Cámaras (Proximamente)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(286, 6)
        '
        'MenuConsultas
        '
        Me.MenuConsultas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MenuConsultas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuConsultarChofer, Me.MenuConsultarInfracciones, Me.MenuConsultarIncidencias, Me.MenuConsultaConsumos, Me.ToolStripSeparator5, Me.MenuListadoDeInfractores, Me.ToolStripSeparator4, Me.MenuListadoCompelto, Me.MenuConsultaGrupoProducto, Me.ToolStripSeparator8, Me.MenuGuiaTelefonica})
        Me.MenuConsultas.Image = CType(resources.GetObject("MenuConsultas.Image"), System.Drawing.Image)
        Me.MenuConsultas.Name = "MenuConsultas"
        Me.MenuConsultas.Size = New System.Drawing.Size(92, 21)
        Me.MenuConsultas.Text = "Consultas"
        '
        'MenuConsultarChofer
        '
        Me.MenuConsultarChofer.Image = CType(resources.GetObject("MenuConsultarChofer.Image"), System.Drawing.Image)
        Me.MenuConsultarChofer.Name = "MenuConsultarChofer"
        Me.MenuConsultarChofer.Size = New System.Drawing.Size(285, 22)
        Me.MenuConsultarChofer.Text = "Consulta General"
        '
        'MenuConsultarInfracciones
        '
        Me.MenuConsultarInfracciones.Image = CType(resources.GetObject("MenuConsultarInfracciones.Image"), System.Drawing.Image)
        Me.MenuConsultarInfracciones.Name = "MenuConsultarInfracciones"
        Me.MenuConsultarInfracciones.Size = New System.Drawing.Size(285, 22)
        Me.MenuConsultarInfracciones.Text = "Consultar Infracciones de Velocidad"
        '
        'MenuConsultarIncidencias
        '
        Me.MenuConsultarIncidencias.Image = CType(resources.GetObject("MenuConsultarIncidencias.Image"), System.Drawing.Image)
        Me.MenuConsultarIncidencias.Name = "MenuConsultarIncidencias"
        Me.MenuConsultarIncidencias.Size = New System.Drawing.Size(285, 22)
        Me.MenuConsultarIncidencias.Text = "Consultar Incidencias"
        '
        'MenuConsultaConsumos
        '
        Me.MenuConsultaConsumos.Image = CType(resources.GetObject("MenuConsultaConsumos.Image"), System.Drawing.Image)
        Me.MenuConsultaConsumos.Name = "MenuConsultaConsumos"
        Me.MenuConsultaConsumos.Size = New System.Drawing.Size(285, 22)
        Me.MenuConsultaConsumos.Text = "Consultar Consumibles"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(282, 6)
        '
        'MenuListadoDeInfractores
        '
        Me.MenuListadoDeInfractores.Image = CType(resources.GetObject("MenuListadoDeInfractores.Image"), System.Drawing.Image)
        Me.MenuListadoDeInfractores.Name = "MenuListadoDeInfractores"
        Me.MenuListadoDeInfractores.Size = New System.Drawing.Size(285, 22)
        Me.MenuListadoDeInfractores.Text = "Reporte General"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(282, 6)
        '
        'MenuListadoCompelto
        '
        Me.MenuListadoCompelto.Image = CType(resources.GetObject("MenuListadoCompelto.Image"), System.Drawing.Image)
        Me.MenuListadoCompelto.Name = "MenuListadoCompelto"
        Me.MenuListadoCompelto.Size = New System.Drawing.Size(285, 22)
        Me.MenuListadoCompelto.Text = "Listado Actual de Rutas"
        '
        'MenuConsultaGrupoProducto
        '
        Me.MenuConsultaGrupoProducto.Image = CType(resources.GetObject("MenuConsultaGrupoProducto.Image"), System.Drawing.Image)
        Me.MenuConsultaGrupoProducto.Name = "MenuConsultaGrupoProducto"
        Me.MenuConsultaGrupoProducto.Size = New System.Drawing.Size(285, 22)
        Me.MenuConsultaGrupoProducto.Text = "Cuadro Resumen de Materia Prima"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(282, 6)
        '
        'MenuGuiaTelefonica
        '
        Me.MenuGuiaTelefonica.Image = CType(resources.GetObject("MenuGuiaTelefonica.Image"), System.Drawing.Image)
        Me.MenuGuiaTelefonica.Name = "MenuGuiaTelefonica"
        Me.MenuGuiaTelefonica.Size = New System.Drawing.Size(285, 22)
        Me.MenuGuiaTelefonica.Text = "Guía Teléfonica"
        '
        'MenuEstadisticas
        '
        Me.MenuEstadisticas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuHistorialDeRutas})
        Me.MenuEstadisticas.Image = CType(resources.GetObject("MenuEstadisticas.Image"), System.Drawing.Image)
        Me.MenuEstadisticas.Name = "MenuEstadisticas"
        Me.MenuEstadisticas.Size = New System.Drawing.Size(103, 21)
        Me.MenuEstadisticas.Text = "Estadisticas"
        '
        'MenuHistorialDeRutas
        '
        Me.MenuHistorialDeRutas.Image = CType(resources.GetObject("MenuHistorialDeRutas.Image"), System.Drawing.Image)
        Me.MenuHistorialDeRutas.Name = "MenuHistorialDeRutas"
        Me.MenuHistorialDeRutas.Size = New System.Drawing.Size(173, 22)
        Me.MenuHistorialDeRutas.Text = "Historial General"
        '
        'MenuConfiguracion
        '
        Me.MenuConfiguracion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFlotas, Me.MenuEstados})
        Me.MenuConfiguracion.Enabled = False
        Me.MenuConfiguracion.Image = CType(resources.GetObject("MenuConfiguracion.Image"), System.Drawing.Image)
        Me.MenuConfiguracion.Name = "MenuConfiguracion"
        Me.MenuConfiguracion.Size = New System.Drawing.Size(117, 21)
        Me.MenuConfiguracion.Text = "Configuración"
        '
        'MenuFlotas
        '
        Me.MenuFlotas.Enabled = False
        Me.MenuFlotas.Image = CType(resources.GetObject("MenuFlotas.Image"), System.Drawing.Image)
        Me.MenuFlotas.Name = "MenuFlotas"
        Me.MenuFlotas.Size = New System.Drawing.Size(183, 22)
        Me.MenuFlotas.Text = "Flotas"
        '
        'MenuEstados
        '
        Me.MenuEstados.Enabled = False
        Me.MenuEstados.Image = CType(resources.GetObject("MenuEstados.Image"), System.Drawing.Image)
        Me.MenuEstados.Name = "MenuEstados"
        Me.MenuEstados.Size = New System.Drawing.Size(183, 22)
        Me.MenuEstados.Text = "Estados por Rutas"
        '
        'MenuSalir
        '
        Me.MenuSalir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuSalir2})
        Me.MenuSalir.Image = CType(resources.GetObject("MenuSalir.Image"), System.Drawing.Image)
        Me.MenuSalir.Name = "MenuSalir"
        Me.MenuSalir.Size = New System.Drawing.Size(61, 21)
        Me.MenuSalir.Text = "Salir"
        '
        'MenuSalir2
        '
        Me.MenuSalir2.Image = CType(resources.GetObject("MenuSalir2.Image"), System.Drawing.Image)
        Me.MenuSalir2.Name = "MenuSalir2"
        Me.MenuSalir2.Size = New System.Drawing.Size(101, 22)
        Me.MenuSalir2.Text = "Salir"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 537)
        Me.Panel1.TabIndex = 11
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.usuariorol, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripLabel2, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 512)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(984, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Image = CType(resources.GetObject("ToolStripLabel1.Image"), System.Drawing.Image)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripLabel1.Text = "Usuario:"
        '
        'usuariorol
        '
        Me.usuariorol.Name = "usuariorol"
        Me.usuariorol.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(61, 22)
        Me.ToolStripButton1.Text = "01.06.2020"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(65, 22)
        Me.ToolStripLabel2.Text = "Versión:"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuPrincipal2)
        Me.Font = New System.Drawing.Font("Microsoft JhengHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "MenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistema de Gestión de Rutas - Cecon Hacienda El Tunal"
        Me.MenuPrincipal2.ResumeLayout(False)
        Me.MenuPrincipal2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuPrincipal2 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuMaestros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuConsultas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSalir2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuProductos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menusitiocargaes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuVehiculos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuGestionRutas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSeguimientoCarga As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuConsultarChofer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuConfiguracion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuFlotas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEstados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents usuariorol As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuPersonal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuConsultarInfracciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEstadisticas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuHistorialDeRutas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuGuiaTelefonica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuListadoCompelto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuConsultaGrupoProducto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSeguimientoLiviano As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuListadoDeInfractores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSeguimientoTaller As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuSeguimientoTransporte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuConsultarIncidencias As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents MenuConsultaConsumos As ToolStripMenuItem
End Class
