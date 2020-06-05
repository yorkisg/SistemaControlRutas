
Public Class ListadoGeneralRutas

    Private Sub ListadoGeneralRutas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView)
        AlternarFilasGeneral(DataGridView1)

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView)
        EnableDoubleBuffered(DataGridView1)

        'Carga del combobox de los grupos
        CargarComboGrupo()

    End Sub

    Private Sub ListadoGeneralVehiculo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        Dispose()

    End Sub

    Private Sub ListadoGeneralVehiculo_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        'Evento que permite cerrar el formulario presionando la tecla esc

        If (e.KeyCode = Keys.Escape) Then
            'Cierre del formulario

            Dispose()

        End If

    End Sub

    Private Sub BotonActualizar_Click(sender As Object, e As EventArgs) Handles BotonActualizar.Click
        'Boton Actualizar

        If Panel.SelectedIndex = 0 Then

            'Se cargan los elementos generales
            '    CargarGridGeneralVehiculo()
            '   CargarGridGeneralVehiculoGrupo()

        ElseIf Panel.SelectedIndex = 1 Then

            'Se cargan los elementos por grupo
            'CargarGridResumenVehiculo()
            'CargarGridResumenVehiculoGrupo()

        End If

    End Sub

    Private Sub BotonExportar_Click(sender As Object, e As EventArgs) Handles BotonExportar.Click
        'Boton Exportar a Excel

        Try

            If DataGridView.RowCount > 0 Or DataGridView1.RowCount > 0 Then

                Dim Mensaje As DialogResult

                Mensaje = MessageBox.Show("Desea expotar el listado?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                'Si la respuesta es "Si"
                If Mensaje = DialogResult.Yes Then

                    If Panel.SelectedIndex = 0 Then

                        Exportar(DataGridView)

                    ElseIf Panel.SelectedIndex = 1 Then

                        Exportar(DataGridView1)

                    End If

                End If

            Else

                MsgBox("No hay datos que exportar.", MsgBoxStyle.Exclamation, "Error.")

            End If

        Catch ex As Exception

            MsgBox("No se logró exportar nada, debe verificar con el administrador del sistema.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton salir

        Dispose()

    End Sub

    Private Sub DataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView.CellFormatting
        'CellFormatting: Propiedad del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Try

            Dim TipoEstado As String

            'Indicamos sobre cual columna trabajaremos.
            If DataGridView.Columns(e.ColumnIndex).Name.Equals("ColumnaEstado") Then

                TipoEstado = (DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                'Verificamos los valores del estado y asignamos los colores e iconos.
                If TipoEstado = "EN RUTA VACIO" Or TipoEstado = "EN RUTA CARGADO" Then

                    e.CellStyle.ForeColor = Color.Green
                    'Colocamos imagen a la celda de acuerdo al valor obtenido
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EnRutaVacio

                End If

                If TipoEstado = "DE REGRESO CARGADO" Or TipoEstado = "DE REGRESO VACIO" Then

                    e.CellStyle.ForeColor = Color.Red
                    'Colocamos imagen a la celda de acuerdo al valor obtenido
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = DeRegresoVacio

                End If

                If TipoEstado = "VEHICULO GUARDADO" Then

                    e.CellStyle.ForeColor = Color.Purple
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = OrganizacionElTunal

                End If

                If TipoEstado = "PERNOCTA AUTORIZADA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = PernoctaAutorizada

                End If

                If TipoEstado = "EN PROCESO DE CARGA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EnProcesoDeCarga

                End If

                If TipoEstado = "EN PROCESO DE DESCARGA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EnProcesoDeDescarga

                End If

                If TipoEstado = "CARGADO ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = CargadoEsperandoPorSalir

                End If

                If TipoEstado = "CARGADO ESPERANDO DOCUMENTOS" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = CargadoEsperandoDocumentos

                End If

                If TipoEstado = "ESPERANDO AUTORIZACIÓN PARA SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EsperandoAutorizacionParaSalir

                End If

                If TipoEstado = "DETENIDO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Detenido

                End If

                If TipoEstado = "ACCIDENTADO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Accidentado

                End If

                If TipoEstado = "PARADA IRREGULAR" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = ParadaIrregular

                End If

                If TipoEstado = "EN TALLER" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EnTaller

                End If

                If TipoEstado = "ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EsperandoPorSalir

                End If

                If TipoEstado = "EN EL CLIENTE" Or TipoEstado = "EN EL PROVEEDOR" Then

                    e.CellStyle.ForeColor = Color.Blue
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EnElClienteEnElProveedor

                End If

                If TipoEstado = "REALIZANDO MOVIMIENTOS Ó ACARREOS" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = RealizandoMovimientos

                End If

                If TipoEstado = "RUTA CANCELADA" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = RutaCancelada

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.2", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'CellFormatting: Propiedad del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Try

            Dim TipoEstado As String

            'Indicamos sobre cual columna trabajaremos.
            If DataGridView1.Columns(e.ColumnIndex).Name.Equals("ColumnaEstado2") Then

                TipoEstado = (DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                'Verificamos los valores del estado y asignamos los colores e iconos.
                If TipoEstado = "EN RUTA VACIO" Or TipoEstado = "EN RUTA CARGADO" Then

                    e.CellStyle.ForeColor = Color.Green
                    'Colocamos imagen a la celda de acuerdo al valor obtenido
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = EnRutaVacio

                End If

                If TipoEstado = "DE REGRESO CARGADO" Or TipoEstado = "DE REGRESO VACIO" Then

                    e.CellStyle.ForeColor = Color.Red
                    'Colocamos imagen a la celda de acuerdo al valor obtenido
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = DeRegresoVacio

                End If

                If TipoEstado = "VEHICULO GUARDADO" Then

                    e.CellStyle.ForeColor = Color.Purple
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = OrganizacionElTunal

                End If

                If TipoEstado = "PERNOCTA AUTORIZADA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = PernoctaAutorizada

                End If

                If TipoEstado = "EN PROCESO DE CARGA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = EnProcesoDeCarga

                End If

                If TipoEstado = "EN PROCESO DE DESCARGA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = EnProcesoDeDescarga

                End If

                If TipoEstado = "CARGADO ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = CargadoEsperandoPorSalir

                End If

                If TipoEstado = "CARGADO ESPERANDO DOCUMENTOS" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = CargadoEsperandoDocumentos

                End If

                If TipoEstado = "ESPERANDO AUTORIZACIÓN PARA SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = EsperandoAutorizacionParaSalir

                End If

                If TipoEstado = "DETENIDO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = Detenido

                End If

                If TipoEstado = "ACCIDENTADO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = Accidentado

                End If

                If TipoEstado = "PARADA IRREGULAR" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = ParadaIrregular

                End If

                If TipoEstado = "EN TALLER" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = EnTaller

                End If

                If TipoEstado = "ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = EsperandoPorSalir

                End If

                If TipoEstado = "EN EL CLIENTE" Or TipoEstado = "EN EL PROVEEDOR" Then

                    e.CellStyle.ForeColor = Color.Blue
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = EnElClienteEnElProveedor

                End If

                If TipoEstado = "REALIZANDO MOVIMIENTOS Ó ACARREOS" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = RealizandoMovimientos

                End If

                If TipoEstado = "RUTA CANCELADA" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = RutaCancelada

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.2", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub LimpiarComponentes()
        'Metodo que permite limpiar todos los controles del formulario.

        'Abrimos el ciclo que recorre todas las filas del datagridview
        For i As Integer = 0 To DataGridView.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView.Rows.Remove(DataGridView.CurrentRow)
        Next

        For i As Integer = 0 To DataGridView1.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        Next

    End Sub

    Private Sub CargarComboGrupo()
        'Metodo que permite cargar el Combobox desde la BD.

        Dim Tabla As New DataTable
        Dim Adaptador As New MySqlDataAdapter

        Adaptador = New MySqlDataAdapter("SELECT idgrupo, nombregrupo " _
                                    & " FROM subflota, grupo " _
                                    & " WHERE grupo.subflota = subflota.idsubflota " _
                                    & " AND tiposubflota = 'CARGA' ", Conexion)

        Adaptador.Fill(Tabla)

        'Este codigo inserta un valor no perteneciente al DATATABLE q trae la informacion de la BD
        Dim row As DataRow = Tabla.NewRow()
        row(0) = 0

        'Este es el valor que insertamos
        row(1) = "--- TODOS LOS GRUPOS ---"
        Tabla.Rows.InsertAt(row, 0)

        With ComboGrupo.ComboBox

            .DataSource = Tabla
            .DisplayMember = "nombregrupo"
            .ValueMember = "idgrupo"
            .SelectedIndex = 0

        End With

    End Sub

    Private Sub ComboGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboGrupo.SelectedIndexChanged

        'Enviamos el texto seleccionado del combobox al textbox
        TextBox1.Text = ComboGrupo.ComboBox.Text

        'si el item seleccionado es el primero
        If TextBox1.Text = "--- TODOS LOS GRUPOS ---" Then

            'Se cargan los elementos generales
            CargarGridGeneralVehiculo()
            CargarGridResumenVehiculo()

        ElseIf TextBox1.Text <> "--- TODOS LOS GRUPOS ---" Then

            'Se cargan los elementos por grupo
            CargarGridGeneralVehiculoGrupo()
            CargarGridResumenVehiculoGrupo()

        End If

    End Sub


End Class