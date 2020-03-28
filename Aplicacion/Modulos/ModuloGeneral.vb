
Imports System.Reflection

Module ModuloGeneral

    'Variables globales de conexion de datos.
    Public Command As MySqlCommand
    Public Adaptador As MySqlDataAdapter
    Public DataSet As DataSet
    Public Tabla As DataTable
    Public Builder As MySqlCommandBuilder
    Public connectionString As String = "server=172.16.8.88;user=cecon01;password=1234;database=bdsaladecontrolgps;port=3306"
    Public cnn As New MySqlConnection
    Public Reader As MySqlDataReader

    'Usado para cargar las imagenes en un arreglo y desplegarlas en el combobox mediante los eventos drawitem y measureitem
    Public Arreglo As New ArrayList
    Public Arreglo2 As New ArrayList

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''CONEXION A LA BD''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub ConectarBaseDeDatos()
        'Metodo que permite conectar la BD.

        Try

            If cnn.State = ConnectionState.Closed Then

                cnn.ConnectionString = "server=172.16.8.88;user=cecon01;password=1234;database=bdsaladecontrolgps;port=3306"
                cnn.Open()

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

            cnn.Close()

        Catch myerror As System.Data.SqlClient.SqlException

            MsgBox("Base de Datos Cerrada.")

        End Try

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''METODOS DE APOYO'''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub ExportarAExcell(ByVal DataGridView As DataGridView)
        'Metodo que permite exportar contenido de DataGridView a Excel.

        Dim obj_Excel As Object
        Dim obj_hoja As Object
        Dim obj_libro As Object
        Dim LETEXCEL() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N"}

        Dim i As Integer
        Dim j As Integer

        obj_Excel = CreateObject("Excel.Application")
        obj_libro = obj_Excel.Workbooks.Add()
        obj_hoja = obj_libro.Worksheets(1)

        For i = 0 To DataGridView.Columns.Count - 1
            obj_hoja.Range(LETEXCEL(i) & "1").Value = DataGridView.Columns(i).HeaderText
        Next

        'Ponemos en negrita los encabezados
        obj_hoja.Range("A1:N1").Font.Bold = True
        'obj_hoja.HorizontalAlignment = 3

        'Recorremos el datagridview y exportamos celda a celda
        For i = 0 To DataGridView.Columns.Count - 1

            For j = 0 To DataGridView.RowCount - 1
                obj_hoja.range(LETEXCEL(i) & j + 2).value = DataGridView(i, j).Value
            Next

        Next

        obj_Excel.Visible = True

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

        Dim info As UpdateCheckInfo = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException
                MessageBox.Show("La nueva versión de la aplicación no puede ser descargada aun. " + ControlChars.Lf & ControlChars.Lf & "Por favor verifique su conexión, o intente mas tarde. Error: " + dde.Message)
                Return
            Catch ioe As InvalidOperationException
                MessageBox.Show("Esta aplicación no puede ser actualizada en este momento. Error: " & ioe.Message)
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
                    ' Display a message that the app MUST reboot. Display the minimum required version.
                    MessageBox.Show("This application has detected a mandatory update from your current " &
                        "version to version " & info.MinimumRequiredVersion.ToString() &
                        ". The application will now install the update and restart.",
                        "Actualización disponible", MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                End If

                If (doUpdate) Then
                    Try
                        AD.Update()
                        MessageBox.Show("La aplicación a sido actualizada.")
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
