
Public Class ConsultaSeguimientoTaller

    Private Sub ConsultaSeguimientoTaller_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'ObtenerCantidadFallasFlotas()
        ObtenerCantidadFallasSistemas()
        'ObtenerCantidadFallasTipo()
        'ObtenerPromedioFallasMensual()

        CalcularTotales()

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

        Dim connection As New MySqlConnection(connectionString)

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

        Dim connection As New MySqlConnection(connectionString)

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

        Dim connection As New MySqlConnection(connectionString)

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

    End Sub

    Public Sub ObtenerPromedioFallasMensual()
        'Este metodo permite obtener los estados de los vehiculos para luego ser modificados
        'Se despliega el formulario MaestroVehiculo

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT ROUND((COUNT(idregistrotaller)/29),2) AS 'Promedio' " _
                                        & " From registrotaller " _
                                        & " WHERE MONTH(fechaingreso) = MONTH(CURDATE()) ", cnn)

        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            TextBox2.Text = row("Promedio").ToString

        Next

    End Sub

    Public Sub CalcularTotales()

        TextBox1.Text = 396

        TextBox2.Text = 6

        'Calculamos el promedio de unidades operativas por mes
        TextBox3.Text = (TextBox1.Text) - (TextBox2.Text)

        'Calculamos el peso porcentual %
        TextBox4.Text = (TextBox3.Text / TextBox1.Text).ToString("0%")

        'Calculamos el comlemento del peso porcentual %
        TextBox5.Text = ((100 - Val(TextBox4.Text)) / 100).ToString("0%")

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click

        Close()

    End Sub


End Class