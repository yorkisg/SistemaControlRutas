
Imports System.Windows.Forms.DataVisualization.Charting

Public Class ConsultaSeguimientoTaller

    Private Sub ConsultaSeguimientoTaller_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ObtenerCantidadFallasFlotas()
        ObtenerCantidadFallasSistemas()
        ObtenerCantidadFallasTipo()
        ObtenerPromedioFallasMensual()

        CalcularTotales()

        ObtenerReportesMensual()

        GenerarChartReportesMensual()
        GenerarChartReportesDiarios()

    End Sub

    Public Sub ObtenerCantidadFallasFlotas()
        'Metodo para cargar el datagridview de la Guia Telefonica

        'Conexion a la BD.
        Dim sql As String = " SELECT COUNT(idregistrotaller) As 'Cantidad', nombresubflota As 'Flota' " _
                             & " FROM registrotaller, vehiculo, subflota " _
                             & " WHERE registrotaller.vehiculo = vehiculo.idvehiculo " _
                             & " AND vehiculo.subflota = subflota.idsubflota " _
                             & " AND MONTH(fechaingreso) = MONTH(CURDATE()) " _
                             & " GROUP BY nombresubflota " _
                             & " ORDER BY nombresubflota ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "22")
        Tabla = DataSet.Tables("22")
        DataGridView2.DataSource = DataSet.Tables("22")


        'Parametros para editar apariencia del datagridview.
        With DataGridView2
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        CalcularTotalFallasFlotas()
        DataGridView2.ClearSelection()

    End Sub

    Public Sub CalcularTotalFallasFlotas()

        Dim Total As New Double

        For i As Integer = 0 To DataGridView2.RowCount - 1

            Total = Total + CDbl(DataGridView2.Item("ColumnaCantidad", i).Value)

        Next

        TextBox1.Text = Total

    End Sub

    Public Sub ObtenerCantidadFallasSistemas()
        'Metodo para cargar el datagridview de la Guia Telefonica

        'Conexion a la BD.
        Dim sql As String = " SELECT area AS 'Area', COUNT(idregistrotaller) AS 'Cantidad', " _
              & " CONCAT(ROUND((COUNT(area) * 100 / (SELECT COUNT(*) FROM registrotaller WHERE MONTH(fechaingreso) = MONTH(CURDATE()))),1),' %') AS 'Porcentaje' " _
              & " FROM registrotaller " _
              & " WHERE MONTH(fechaingreso) = MONTH(CURDATE()) " _
              & " GROUP BY area " _
              & " ORDER BY area ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "33")
        Tabla = DataSet.Tables("33")
        DataGridView3.DataSource = DataSet.Tables("33")

        'Parametros para editar apariencia del datagridview.
        With DataGridView3
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        CalcularTotalFallasSistemas()
        DataGridView3.ClearSelection()

    End Sub

    Public Sub CalcularTotalFallasSistemas()

        Dim Total As New Double

        For i As Integer = 0 To DataGridView3.RowCount - 1

            Total = Total + CDbl(DataGridView3.Item("ColumnaCantidad2", i).Value)

        Next

        LabelTotal2.Text = Total

    End Sub

    Public Sub ObtenerCantidadFallasTipo()
        'Metodo para cargar el datagridview de la Guia Telefonica

        'Conexion a la BD.
        Dim sql As String = " SELECT COUNT(idregistrotaller) AS 'Cantidad', nombretipo AS 'Tipo' " _
                            & " FROM registrotaller, vehiculo, tipovehiculo " _
                            & " WHERE registrotaller.vehiculo = vehiculo.idvehiculo " _
                            & " AND vehiculo.tipovehiculo = tipovehiculo.idtipo " _
                            & " AND MONTH(fechaingreso) = MONTH(CURDATE()) " _
                            & " GROUP BY nombretipo " _
                            & " ORDER BY nombretipo ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "44")
        Tabla = DataSet.Tables("44")
        DataGridView1.DataSource = DataSet.Tables("44")

        'Parametros para editar apariencia del datagridview.
        With DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        DataGridView1.ClearSelection()

    End Sub

    Public Sub ObtenerPromedioFallasMensual()
        'Este metodo permite obtener los estados de los vehiculos para luego ser modificados
        'Se despliega el formulario MaestroVehiculo

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT ROUND((COUNT(idregistrotaller)/29),2) AS 'Promedio' " _
                                        & " From registrotaller " _
                                        & " WHERE MONTH(fechaingreso) = MONTH(CURDATE()) ", Conexion)

        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            TextBox2.Text = row("Promedio").ToString

        Next

    End Sub

    Public Sub CalcularTotales()

        'TextBox1.Text = 396
        'TextBox2.Text = 6

        'Calculamos el promedio de unidades operativas por mes: TOTAL FLOTA - PROMEDIO DE UNIDADES REPORTADAS / DIA
        TextBox3.Text = (TextBox1.Text) - (TextBox2.Text)

        'Calculamos el peso porcentual %: PROMEDIO DE UNIDADES OPERATIVAS POR MES / TOTAL FLOTA
        TextBox4.Text = (TextBox3.Text / TextBox1.Text).ToString("0%")

        'Calculamos el complemento del peso porcentual %: 100% - PROMEDIO DE UNIDADES OPERATIVAS POR MES / TOTAL FLOTA
        TextBox5.Text = ((100 - Val(TextBox4.Text)) / 100).ToString("0%")

    End Sub

    Public Sub ObtenerReportesMensual()
        'Metodo para cargar el datagridview de la Guia Telefonica

        'Conexion a la BD.
        Dim sql As String = " SELECT estado As 'Estado', COUNT(estado) As 'Cantidad' " _
                            & " FROM registrotaller " _
                            & " WHERE Month(fechaingreso) = Month(CURDATE())  " _
                            & " GROUP BY estado "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "tabla")
        Tabla = DataSet.Tables("tabla")
        DataGridView4.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With DataGridView4
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        CalcularTotales2()
        DataGridView4.ClearSelection()

    End Sub

    Public Sub CalcularTotales2()

        'TextBox6.Text = DataGridView5.Item(1, 0).Value.ToString()
        TextBox6.Text = TextBox1.Text
        TextBox7.Text = DataGridView4.Item(1, 1).Value.ToString()

        'Calculo de unidades reportadas y entregadas diario
        TextBox8.Text = Math.Round((TextBox6.Text / 29), 2)
        TextBox9.Text = Math.Round((TextBox7.Text / 29), 2)

    End Sub

    Public Sub GenerarChartReportesMensual()
        'Grafico que muestra el total de unidades reportadas y entregadas por mes

        'Obtenemos los valores desde los textbox 
        Dim y As Double() = {TextBox6.Text, TextBox7.Text}

        'Titulos de las leyendas
        Dim x As String() = {"Reportadas", "Entregadas"}

        Chart2.Series.Clear()
        Chart2.Titles.Clear()
        Chart2.Series.Add("Serie")

        'Llenamos los valores provenientes de los textbox en las coordenades x, y
        Chart2.Series("Serie").Points.DataBindXY(x, y)

        'Indicamos el tipo de grafico y sus colores
        Chart2.Series("Serie").ChartType = SeriesChartType.Pie
        Chart2.Series("Serie").Points(0).Color = Color.ForestGreen
        Chart2.Series("Serie").Points(1).Color = Color.OrangeRed

        'Definimos en que parte apareceran los numeros del label
        Chart2.Series("Serie")("PieLabelStyle") = "Inside"
        Chart2.Series("Serie").IsValueShownAsLabel = True

        'Expresamos con %porcentaje el valor
        Chart2.Series(0).LegendText = "#VALX (#PERCENT)"

        'Cambiams el tipo de fuente del label
        Chart2.Legends(0).Font = New Font("Segoe UI", 8)
        Chart2.Series(0).Font = New Font("Segoe UI", 9, FontStyle.Bold)

        'Personalizacion del Area
        Chart2.ChartAreas(0).Area3DStyle.Inclination = 45
        Chart2.ChartAreas("Area").Area3DStyle.Enable3D = True


    End Sub

    Public Sub GenerarChartReportesDiarios()
        'Grafico que muestra el total de unidades reportadas y entregadas diario

        'Obtenemos los valores desde los textbox 
        Dim y As Double() = {TextBox8.Text, TextBox9.Text}

        'Titulos de las leyendas
        Dim x As String() = {"Reportadas", "Entregadas"}

        Chart3.Series.Clear()
        Chart3.Titles.Clear()
        Chart3.Series.Add("Serie")

        'Llenamos los valores provenientes de los textbox en las coordenades x, y
        Chart3.Series("Serie").Points.DataBindXY(x, y)

        'Indicamos el tipo de grafico y sus colores
        Chart3.Series("Serie").ChartType = SeriesChartType.Pie
        Chart3.Series("Serie").Points(0).Color = Color.MediumBlue
        Chart3.Series("Serie").Points(1).Color = Color.PaleVioletRed

        'Definimos en que parte apareceran los numeros del label
        Chart3.Series("Serie")("PieLabelStyle") = "Inside"
        Chart3.Series("Serie").IsValueShownAsLabel = True

        'Expresamos con %porcentaje el valor
        Chart3.Series(0).LegendText = "#VALX (#PERCENT)"

        'Cambiams el tipo de fuente del label
        Chart3.Legends(0).Font = New Font("Segoe UI", 8)
        Chart3.Series(0).Font = New Font("Segoe UI", 9, FontStyle.Bold)

        'Personalizacion del Area
        Chart3.ChartAreas(0).Area3DStyle.Inclination = 45
        Chart3.ChartAreas("Area").Area3DStyle.Enable3D = True


    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click

        Close()

    End Sub


End Class