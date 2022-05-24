
Public Class CuadroResumenMateriaPrima

    Private Sub ResumenMateriaPrima_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView)

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView)

    End Sub

    Private Sub CuadroResumenMateriaPrima_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        If DataGridView.RowCount > 0 Then
            'Si el datagridview contiene datos, obtenemos recursos 
            'liberando los datatable y dataset implementados.

            Tabla.Clear()
            DataSet.Clear()
            Dispose()

        Else

            Dispose()

        End If

    End Sub

    Private Sub CuadroResumenMateriaPrima_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        'Evento que permite cerrar el formulario presionando la tecla esc

        If (e.KeyCode = Keys.Escape) Then

            'Cierre del formulario

            If DataGridView.RowCount > 0 Then
                'Si el datagridview contiene datos, obtenemos recursos 
                'liberando los datatable y dataset implementados.

                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            Else

                Dispose()

            End If

        End If

    End Sub

    Private Sub DataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView.CellFormatting
        'CellFormatting: Evento del control DataGridview el cual permite cambiar 
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
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = EnRutaVacio

                End If

                If TipoEstado = "DE REGRESO CARGADO" Or TipoEstado = "DE REGRESO VACIO" Then

                    e.CellStyle.ForeColor = Color.Red
                    'Colocamos imagen a la celda de acuerdo al valor obtenido
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = DeRegresoVacio

                End If

                If TipoEstado = "VEHICULO GUARDADO" Then

                    e.CellStyle.ForeColor = Color.Purple
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = OrganizacionElTunal

                End If

                If TipoEstado = "PERNOCTA AUTORIZADA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = PernoctaAutorizada

                End If

                If TipoEstado = "EN PROCESO DE CARGA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = EnProcesoDeCarga

                End If

                If TipoEstado = "EN PROCESO DE DESCARGA" Then

                    e.CellStyle.ForeColor = Color.Purple
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = EnProcesoDeDescarga

                End If

                If TipoEstado = "CARGADO ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Purple
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = CargadoEsperandoPorSalir

                End If

                If TipoEstado = "CARGADO ESPERANDO DOCUMENTOS" Then

                    e.CellStyle.ForeColor = Color.Purple
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = CargadoEsperandoDocumentos

                End If

                If TipoEstado = "ESPERANDO AUTORIZACIÓN PARA SALIR" Then

                    e.CellStyle.ForeColor = Color.Purple
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = EsperandoAutorizacionParaSalir

                End If

                If TipoEstado = "DETENIDO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = Detenido

                End If

                If TipoEstado = "ACCIDENTADO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = Accidentado

                End If

                If TipoEstado = "PARADA IRREGULAR" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = ParadaIrregular

                End If

                If TipoEstado = "EN TALLER" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = EnTaller

                End If

                If TipoEstado = "ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Purple
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = EsperandoPorSalir

                End If

                If TipoEstado = "EN EL CLIENTE" Or TipoEstado = "EN EL PROVEEDOR" Then

                    e.CellStyle.ForeColor = Color.Blue
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = EnElClienteEnElProveedor

                End If

                If TipoEstado = "REALIZANDO MOVIMIENTOS Ó ACARREOS" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = RealizandoMovimientos

                End If

                If TipoEstado = "RUTA CANCELADA" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView.Rows(e.RowIndex).Cells(0).Value = RutaCancelada

                End If

            End If

        Catch ex As Exception


        End Try

    End Sub

    Private Sub BotonBuscar1_Click(sender As Object, e As EventArgs) Handles BotonBuscar1.Click
        'Boton buscar sitio de carga

        ListadoSitioCarga.ShowDialog()

    End Sub

    Private Sub BotonBuscar2_Click(sender As Object, e As EventArgs) Handles BotonBuscar2.Click
        'Boton buscar producto 

        ListadoProducto.ShowDialog()

    End Sub

    Private Sub BotonFiltrar_Click(sender As Object, e As EventArgs) Handles BotonFiltrar.Click
        'Boton filtrar

        If TextBox2.Text = "" Or TextBox3.Text = "" Then

            MsgBox("No puede dejar campos en blanco.", MsgBoxStyle.Exclamation, "Error.")

        ElseIf TextBox2.Text <> "" And TextBox3.Text <> "" Then

            'Cargamos los datos
            CargarResumenMateriaPrima()

            'Sumamos el total de unidades por la columna
            total.Text = Sumar("ColumnaUnidades", DataGridView)

            'Cargamos las imagenes de la columna de los estados
            CargarImagenesHistorialCarga()

        End If

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton salir

        If DataGridView.RowCount > 0 Then
            'Si el datagridview contiene datos, obtenemos recursos 
            'liberando los datatable y dataset implementados.

            Dispose()

        Else

            Close()

        End If

    End Sub


End Class