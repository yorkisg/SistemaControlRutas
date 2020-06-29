
Imports System.Reflection

Module ModuloGeneral

    'Variables globales de conexion de datos.
    Public Command As MySqlCommand
    Public Adaptador As MySqlDataAdapter
    Public DataSet As DataSet
    Public Tabla As DataTable
    Public DataView As DataView
    Public ConnectionString As String = "server=172.16.8.88;user=cecon01;password=1234;database=bdsaladecontrolgps;port=3306"
    Public Conexion As New MySqlConnection
    Public Reader As MySqlDataReader

    'Usado para cargar las imagenes en un arreglo y desplegarlas en el combobox mediante los eventos drawitem y measureitem
    Public Arreglo As New ArrayList
    Public Arreglo2 As New ArrayList

    'Lista para agrupar datos
    Public ListaAgrupadaEstatusActual As New Subro.Controls.DataGridViewGrouper
    Public ListaAgrupadaListadoExtendido As New Subro.Controls.DataGridViewGrouper
    Public ListaAgrupadaListadoAgrupado As New Subro.Controls.DataGridViewGrouper

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''CONEXION A LA BD''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub ConectarBaseDeDatos()
        'Metodo que permite conectar la BD.

        Try

            If Conexion.State = ConnectionState.Closed Then

                Conexion.ConnectionString = " server=172.16.8.88; " _
                                     & " user=cecon01; " _
                                     & " password=1234; " _
                                     & " database=bdsaladecontrolgps; " _
                                     & " port=3306"
                Conexion.Open()

                'Comprobamos si existen actualizaciones disponibles e iniciamos la aplicacion
                ComprobarActualizacion()

                MsgBox("Conexión Exitosa.", MsgBoxStyle.Information, "Exito.")

            End If

        Catch myerror As Exception

            MsgBox("Error en Conexión", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Public Sub DesconectarBaseDeDatos()
        'Metodo que permite desconectar la BD.

        Try

            Conexion.Close()

        Catch myerror As System.Data.SqlClient.SqlException

            MsgBox("Base de Datos Cerrada.")

        End Try

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''METODOS DE APOYO'''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub Exportar(ByVal DataGridView As DataGridView)

        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        exLibro = exApp.Workbooks.Add
        exHoja = exLibro.Worksheets.Add()

        Dim NCol As Integer = DataGridView.ColumnCount
        Dim NRow As Integer = DataGridView.RowCount

        For i As Integer = 1 To NCol

            exHoja.Cells.Item(1, i) = DataGridView.Columns(i - 1).Name.ToString

        Next

        For Fila As Integer = 0 To NRow - 1

            For Col As Integer = 0 To NCol - 1

                exHoja.Cells.Item(Fila + 2, Col + 1) = DataGridView.Rows(Fila).Cells(Col).Value

            Next

        Next

        exHoja.Rows.Item(1).Font.Bold = 1
        exHoja.Rows.Item(1).HorizontalAlignment = 3
        exHoja.Columns.AutoFit()

        exApp.Application.Visible = True

        exHoja = Nothing
        exLibro = Nothing
        exApp = Nothing

    End Sub

    Public Sub AlternarFilasGeneral(ByVal DataGridView As DataGridView)
        'En este metodo especificamos cuales son los colores de las filas y los alternamos
        'con el color blanco y el color de seleccion de filas

        DataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
        DataGridView.RowsDefaultCellStyle.BackColor = Color.White

    End Sub

    Public Sub EnableDoubleBuffered(ByVal control As Control)
        'Metodo que permite la rapida ejecucion del listview al cargar los datos

        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''PREVENIR ABRIR LA APLICACION DOS VECES''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Function InstanciaPrevia() As Boolean
        'Metodo que evita que el ejecutable se abra 2 veces

        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then

            Return True

        Else

            Return False

        End If

    End Function

    Public Sub Instancia()
        'Con este metodo se evita la doble instancia del ejecutable

        Dim Instanciado As Integer
        Instanciado = InstanciaPrevia()

        If Instanciado <> 0 Then

            MsgBox("Ya la aplicación se esta ejecutando", MsgBoxStyle.Exclamation, "Error.")

            End

        End If

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''COMPROBAR ACTUALIZACION (EN PRUEBA Y DESARROLLO)''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub ComprobarActualizacion()
        'Metodo empleado para actualizar la aplicacion, evalua si existe una version nueva y la actualiza

        Dim info As UpdateCheckInfo = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then

            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try

                info = AD.CheckForDetailedUpdate()

            Catch dde As DeploymentDownloadException

                MessageBox.Show("La nueva versión de la aplicación no puede ser descargada aun. " + ControlChars.Lf & ControlChars.Lf & "Por favor verifique su conexión, o intente mas tarde. Error: " + dde.Message)
                Return

            Catch ioe As InvalidOperationException

                MsgBox("Esta aplicación no puede ser actualizada en este momento.", MsgBoxStyle.Exclamation, "Error.")
                Return

            End Try

            If (info.UpdateAvailable) Then

                Dim doUpdate As Boolean = True

                If (Not info.IsUpdateRequired) Then

                    Dim dr As DialogResult = MessageBox.Show("Una nueva actualización esta disponible. Le gustaria descargarla en este momento?", "Actualización disponible", MessageBoxButtons.OKCancel)

                    If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                        doUpdate = False
                    End If

                Else

                    'Muestra un mensaje que la aplicación DEBE reiniciar. Mostrar la versión mínima requerida.
                    MessageBox.Show("Esta aplicación ha detectado una actualización obligatoria de su versión actual a la versión " & info.MinimumRequiredVersion.ToString() & ". La aplicación ahora instalará la actualización y reiniciará.", "Actualización disponible", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

                If (doUpdate) Then

                    Try

                        AD.Update()
                        MsgBox("La aplicación a sido actualizada.", MsgBoxStyle.Information, "Exito.")
                        Application.Restart()

                    Catch dde As DeploymentDownloadException

                        MessageBox.Show("La aplicación no a sido actualizada. " & ControlChars.Lf & ControlChars.Lf & "Por favor verifique su conexión, o intente mas tarde.")
                        Return

                    End Try

                End If

            End If

        End If

    End Sub


End Module
