
Public Class ListadoGeneralRutas

    Private Sub ListadoGeneralRutas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView)
        AlternarFilasGeneral(DataGridView1)
        AlternarFilasGeneral(DataGridView2)
        AlternarFilasGeneral(DataGridView3)

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView)
        EnableDoubleBuffered(DataGridView1)
        EnableDoubleBuffered(DataGridView2)
        EnableDoubleBuffered(DataGridView3)

        'Llamada a los metodos de carga de datos
        CargarGridGeneralVehiculo()
        CargarGridResumenVehiculo()

        CargarGridEstatusProducto()
        CargarGridEstatusGrupo()

        'Mandamos a agrupar los datos
        AgruparListaExtendida()
        AgruparListaAgrupada()
        AgruparListaEstatusActual()

        'Mandamos a generar el grafico
        GenerarGraficoReporte()

        DataGridView2.AutoGenerateColumns = False

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

        For i As Integer = 0 To DataGridView2.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView2.Rows.Remove(DataGridView2.CurrentRow)
        Next

        For i As Integer = 0 To DataGridView3.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView3.Rows.Remove(DataGridView3.CurrentRow)
        Next

    End Sub

    Private Sub Panel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Panel.SelectedIndexChanged
        'Evento donde se seleccionan los tabs del tabcontrol (paginas) y luego se cargan metodos dependiendo del index del tab

        If Panel.SelectedIndex = 0 Then

            DataGridView.ClearSelection()

        ElseIf Panel.SelectedIndex = 1 Then

            DataGridView1.ClearSelection()

        ElseIf Panel.SelectedIndex = 2 Then

            DataGridView2.ClearSelection()
            DataGridView3.ClearSelection()

        End If

    End Sub

    Private Sub DataGridView2_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView2.CellPainting

        If DataGridView2.Columns(e.ColumnIndex).Name.Equals("ColumnaProducto3") Then

            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None

            If e.RowIndex < 1 OrElse e.ColumnIndex < 0 Then Return

            If (IsTheSameCellValue(e.ColumnIndex, e.RowIndex)) = True Then

                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None

            Else

                e.AdvancedBorderStyle.Top = DataGridView2.AdvancedCellBorderStyle.Top

            End If

            'Generamos la division de grupos
            If e.ColumnIndex = 0 AndAlso e.RowIndex <> -1 Then

                Using gridBrush As Brush = New SolidBrush(DataGridView2.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                    Using gridLinePen As Pen = New Pen(gridBrush)

                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                        If e.RowIndex < DataGridView2.Rows.Count - 1 AndAlso DataGridView2.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                        End If

                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                        If Not e.Value Is Nothing Then

                            Dim previos As Integer = 0
                            Dim siguientes As Integer = 0
                            For i As Integer = e.RowIndex - 1 To 0 Step -1
                                If DataGridView2.Item(e.ColumnIndex, i).Value <> e.Value Or i = 0 Then
                                    previos = e.RowIndex - i - 1
                                    Exit For
                                End If
                            Next

                            For i As Integer = e.RowIndex + 1 To DataGridView2.Rows.Count - 1
                                If DataGridView2.Item(e.ColumnIndex, i).Value <> e.Value Or DataGridView2.Rows.Count - 1 = i Then
                                    siguientes = i - e.RowIndex - 1
                                    Exit For
                                End If
                            Next

                            If siguientes = previos Or siguientes - 1 = previos Then
                                e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 3, StringFormat.GenericDefault)
                            End If

                        End If

                        e.Handled = True

                    End Using

                End Using

            End If

        End If

    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting

        Try

            'damos formato a las celdas, bien sea por color de texto, fondo, etc.
            Dim TipoEstado As String

            'Indicamos sobre cual columna trabajaremos.
            If DataGridView2.Columns(e.ColumnIndex).Name.Equals("ColumnaEstado3") Then

                TipoEstado = (DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                'Verificamos los valores del estado y asignamos los colores e iconos.
                If TipoEstado = "EN RUTA VACIO" Or TipoEstado = "EN RUTA CARGADO" Then

                    e.CellStyle.ForeColor = Color.Green
                    'Colocamos imagen a la celda de acuerdo al valor obtenido
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = EnRutaVacio

                End If

                If TipoEstado = "DE REGRESO CARGADO" Or TipoEstado = "DE REGRESO VACIO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = DeRegresoVacio

                End If

                If TipoEstado = "VEHICULO GUARDADO" Then

                    e.CellStyle.ForeColor = Color.Purple
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = OrganizacionElTunal

                End If

                If TipoEstado = "PERNOCTA AUTORIZADA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = PernoctaAutorizada

                End If

                If TipoEstado = "EN PROCESO DE CARGA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = EnProcesoDeCarga

                End If

                If TipoEstado = "EN PROCESO DE DESCARGA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = EnProcesoDeDescarga

                End If

                If TipoEstado = "CARGADO ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = CargadoEsperandoPorSalir

                End If

                If TipoEstado = "CARGADO ESPERANDO DOCUMENTOS" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = CargadoEsperandoDocumentos

                End If

                If TipoEstado = "ESPERANDO AUTORIZACIÓN PARA SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = EsperandoAutorizacionParaSalir

                End If

                If TipoEstado = "DETENIDO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = Detenido

                End If

                If TipoEstado = "ACCIDENTADO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = Accidentado

                End If

                If TipoEstado = "PARADA IRREGULAR" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = ParadaIrregular

                End If

                If TipoEstado = "EN TALLER" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = EnTaller

                End If

                If TipoEstado = "ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = EsperandoPorSalir

                End If

                If TipoEstado = "EN EL CLIENTE" Or TipoEstado = "EN EL PROVEEDOR" Then

                    e.CellStyle.ForeColor = Color.Blue
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = EnElClienteEnElProveedor

                End If

                If TipoEstado = "REALIZANDO MOVIMIENTOS Ó ACARREOS" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = RealizandoMovimientos

                End If

                If TipoEstado = "RUTA CANCELADA" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = RutaCancelada

                End If

            End If

            If (e.RowIndex = 0) Then
                Return
            End If

            If DataGridView2.Columns(e.ColumnIndex).Name.Equals("ColumnaProducto3") Then

                If (IsTheSameCellValue(e.ColumnIndex, e.RowIndex)) = True Then

                    e.Value = ""
                    e.FormattingApplied = True
                    e.CellStyle.BackColor = Color.LightBlue

                End If

            End If

        Catch ex As Exception

            MsgBox("Error 2", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Function IsTheSameCellValue(ByVal column As Integer, ByVal row As Integer) As Boolean

        Dim cell1 As DataGridViewCell = DataGridView2(column, row)
        Dim cell2 As DataGridViewCell = DataGridView2(column, row - 1)

        If (IsDBNull(cell1.Value) Or IsDBNull(cell2.Value)) Then
            Return False
        End If

        If (cell1.Value = cell2.Value) Then
            Return True
        Else
            Return False
        End If

    End Function


End Class