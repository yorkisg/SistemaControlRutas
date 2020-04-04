
Public Class MaestroVehiculo

    Private Sub MaestroVehiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Carga de los combobox por valores de BD.
        CargarComboFlota()
        CargarComboTipo()
        CargarComboCondicion()
        CargarComboEstadoVehiculo()

        'Validamos que en cada Textbox del formulario solo se agregue texto en mayusculas.
        TextBox1.CharacterCasing = CharacterCasing.Upper

        'Decimos que el primer elemento activo del combo es "Activo"
        ' ComboEstado.SelectedItem = "OPERATIVO"

        'Metodo que viene del modulo ModuloRuta, que permite obtener los datos 
        'para modificar los estados de los vehiculos
        ObtenerVehiculoCarga()
        ObtenerVehiculoLiviano()

    End Sub

    Private Sub MaestroVehiculo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        LimpiarComponentes()
        Dispose()

    End Sub

    Private Sub BotonGuardar_Click(sender As Object, e As EventArgs) Handles BotonGuardar.Click
        'Boton registrar

        'Se valida que no haya algun campo vacio
        If VerificarExistencia(TextBox1.Text) = True Then

            MsgBox("Ya este Vehiculo esta registrado.", MsgBoxStyle.Exclamation, "Aviso.")
            TextBox1.Text = ""

        ElseIf ValidarComponentes() = True Then

            Dim db As New MySqlCommand("INSERT INTO vehiculo (idvehiculo, subflota, tipovehiculo, clasificacionvehiculo ,condicionvehiculo, estadoactual, estadorevision) VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox6.Text & "', '" & ComboCondicion.Text & "', '" & ComboEstado.Text & "', 'OPERATIVO')", cnn)
            db.ExecuteNonQuery()

            'Se limpian todos los componentes del formulario para un nuevo uso.
            LimpiarComponentes()

            MsgBox("Vehiculo registrado con Exito.", MsgBoxStyle.Information, "Exito.")

        End If

    End Sub

    Private Sub BotonModificar_Click(sender As Object, e As EventArgs) Handles BotonModificar.Click
        'Boton modificar

        Dim fecha = DateTimePicker1.Value.ToString("yyyy-MM-dd")

        'Se valida que no haya algun campo vacio.
        If ValidarComponentes() = True Then

            Dim db As New MySqlCommand("UPDATE vehiculo SET subflota = '" & TextBox2.Text & "', tipovehiculo = '" & TextBox3.Text & "', clasificacionvehiculo = '" & ComboClasificacion.Text & "', condicionvehiculo = '" & ComboCondicion.Text & "', estadoactual = '" & ComboEstado.Text & "' WHERE idvehiculo = '" & TextBox1.Text & "' ", cnn)
            db.ExecuteNonQuery()

            'Se desactiva el uso del boton modificar.
            BotonModificar.Enabled = False
            'Se activa el uso del boton guardar.
            BotonGuardar.Enabled = True
            'Se activa el uso del textbox1.
            TextBox1.Enabled = True

            CargarGridRutaCarga()
            CargarGridRutaLiviano()

            'Se limpian todos los componentes del formulario para un nuevo uso.
            LimpiarComponentes()

            MsgBox("Vehiculo modificado con Exito.", MsgBoxStyle.Information, "Exito.")

        End If

        'Si la llamada proviene del formulario RegistroRuta, entonces se cierra al modificar el registro seleccionado
        If SeguimientoCarga.Visible = True Or SeguimientoLiviano.Visible = True Then

            CargarGridRutaLiviano()
            Dispose()

        End If

    End Sub

    Private Sub BotonBuscar_Click(sender As Object, e As EventArgs) Handles BotonBuscar.Click
        'Boton buscar

        ListadoVehiculo.ShowDialog()

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton salir

        LimpiarComponentes()
        Dispose()

    End Sub

    Private Sub CargarComboFlota()
        'Metodo que permite cargar el Combobox desde la BD.

        Dim Tabla As New DataTable
        Dim Adaptador As New MySqlDataAdapter

        Adaptador = New MySqlDataAdapter("SELECT * FROM subflota ORDER BY nombresubflota ASC", cnn)
        Adaptador.Fill(Tabla)

        ComboFlota.DataSource = Tabla
        ComboFlota.DisplayMember = "nombresubflota"
        ComboFlota.ValueMember = "idsubflota"

    End Sub

    Private Sub CargarComboTipo()
        'Metodo que permite cargar el Combobox desde la BD.

        Dim Tabla As New DataTable
        Dim Adaptador As New MySqlDataAdapter

        Adaptador = New MySqlDataAdapter("SELECT * FROM tipovehiculo ORDER BY nombretipo ASC", cnn)
        Adaptador.Fill(Tabla)

        ComboTipo.DataSource = Tabla
        ComboTipo.DisplayMember = "nombretipo"
        ComboTipo.ValueMember = "idtipo"

    End Sub

    Private Sub CargarComboCondicion()
        'Metodo que permite cargar el Combobox desde la BD.

        Dim Tabla2 As New DataTable
        Dim Adaptador2 As New MySqlDataAdapter

        Adaptador2 = New MySqlDataAdapter("SELECT idcondicionvehiculo, nombrecondicion FROM condicionvehiculo ORDER BY idcondicionvehiculo ASC", cnn)
        Adaptador2.Fill(Tabla2)

        ComboCondicion.DataSource = Tabla2
        ComboCondicion.DisplayMember = "nombrecondicion"
        ComboCondicion.ValueMember = "idcondicionvehiculo"

        ComboCondicion.DrawMode = DrawMode.OwnerDrawVariable 'PARA PODER PONER NUESTRAS IMAGENES
        ComboCondicion.DropDownHeight = 480 'PARA QUE MUESTRE TODOS LOS ELEMENTOS. DEPENDE DEL NUMERO DE ELEMENTOS Y SU ALTURA

        'Generamos un ciclo para obtener cada nombre de la consulta guardada en el Tabla2
        'cada valor obtenido es agregado al ArrayList declarado al inicio de la clase
        For Each dr As DataRow In Tabla2.Rows

            'guardamos cada registro en el arreglo
            Arreglo2.Add(dr("nombrecondicion"))

        Next

    End Sub

    Private Sub CargarComboEstadoVehiculo()
        'Metodo que permite cargar el Combobox desde la BD.

        Dim Tabla As New DataTable
        Dim Adaptador As New MySqlDataAdapter

        Adaptador = New MySqlDataAdapter("SELECT idestado, nombreestado FROM estadoruta ORDER BY nombreestado ASC", cnn)
        Adaptador.Fill(Tabla)

        ComboEstado.DataSource = Tabla
        ComboEstado.DisplayMember = "nombreestado"
        ComboEstado.ValueMember = "idestado"

        ComboEstado.DrawMode = DrawMode.OwnerDrawVariable 'PARA PODER PONER NUESTRAS IMAGENES
        ComboEstado.DropDownHeight = 480 'PARA QUE MUESTRE TODOS LOS ELEMENTOS. DEPENDE DEL NUMERO DE ELEMENTOS Y SU ALTURA

        'Generamos un ciclo para obtener cada nombre de la consulta guardada en el Tabla2
        'cada valor obtenido es agregado al ArrayList declarado al inicio de la clase
        For Each dr As DataRow In Tabla.Rows

            'guardamos cada registro en el arreglo
            Arreglo.Add(dr("nombreestado"))

        Next

    End Sub

    Private Sub ComboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboTipo.SelectedIndexChanged
        'Este metodo permite obtener el ID de cada item seleccionado. 

        Dim Adaptador2 As New MySqlDataAdapter
        Dim Tabla2 As New DataTable

        Adaptador2 = New MySqlDataAdapter("SELECT idtipo FROM tipovehiculo WHERE nombretipo = ('" & ComboTipo.Text & "') ", cnn)
        Adaptador2.Fill(Tabla2)

        For Each row As DataRow In Tabla2.Rows
            TextBox3.Text = row("idtipo").ToString
        Next

    End Sub

    Private Sub ComboFlota_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboFlota.SelectedIndexChanged
        'Este metodo permite obtener el ID de cada item seleccionado. 

        Dim Adaptador2 As New MySqlDataAdapter
        Dim Tabla2 As New DataTable

        Adaptador2 = New MySqlDataAdapter("SELECT idsubflota FROM subflota WHERE nombresubflota = ('" & ComboFlota.Text & "') ", cnn)
        Adaptador2.Fill(Tabla2)

        For Each row As DataRow In Tabla2.Rows
            TextBox2.Text = row("idsubflota").ToString
        Next

    End Sub

    Private Sub ComboEstado_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles ComboEstado.DrawItem
        'Evento que dibuja el texto y las imagenes cargadas en el combobox

        Try

            e.DrawBackground()

            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                'Si hay un elemento seleccionado se dibuja la seleccion, el texto y la imagen

                'Dibuja la seleccion
                e.Graphics.FillRectangle(Brushes.DeepSkyBlue, e.Bounds)

                'Dibuja el texto
                e.Graphics.DrawString(Arreglo(e.Index), e.Font, Brushes.Black, e.Bounds.Left + ImageList2.ImageSize.Width + 16, e.Bounds.Top)

                'Dibuja la imagen
                e.Graphics.DrawImage(ImageList2.Images(e.Index), e.Bounds.Left, e.Bounds.Top)

                'e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

            Else
                'Si no se selecciona nada, se dibuja el texto y la imagen

                'Dibuja la imagen
                e.Graphics.DrawImage(ImageList2.Images(e.Index), e.Bounds.Left, e.Bounds.Top)
                'Dibuja el texto
                e.Graphics.DrawString(Arreglo(e.Index), e.Font, Brushes.Black, e.Bounds.Left + ImageList2.ImageSize.Width + 16, e.Bounds.Top)

                'e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

            End If

            e.DrawFocusRectangle()

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub ComboEstado_MeasureItem(sender As Object, e As System.Windows.Forms.MeasureItemEventArgs) Handles ComboEstado.MeasureItem

        Try

            'Esto es para darle espacio a los elementos mostrados en el ComboBox
            e.ItemHeight = ImageList2.ImageSize.Height + 3

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub ComboCondicion_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles ComboCondicion.DrawItem
        'Evento que dibuja el texto y las imagenes cargadas en el combobox

        Try

            e.DrawBackground()

            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                'Si hay un elemento seleccionado se dibuja la seleccion, el texto y la imagen

                'Dibuja la seleccion
                e.Graphics.FillRectangle(Brushes.DeepSkyBlue, e.Bounds)

                'Dibuja el texto
                e.Graphics.DrawString(Arreglo2(e.Index), e.Font, Brushes.Black, e.Bounds.Left + ImageList1.ImageSize.Width + 16, e.Bounds.Top)

                'Dibuja la imagen
                e.Graphics.DrawImage(ImageList1.Images(e.Index), e.Bounds.Left, e.Bounds.Top)

                'e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

            Else
                'Si no se selecciona nada, se dibuja el texto y la imagen

                'Dibuja la imagen
                e.Graphics.DrawImage(ImageList1.Images(e.Index), e.Bounds.Left, e.Bounds.Top)
                'Dibuja el texto
                e.Graphics.DrawString(Arreglo2(e.Index), e.Font, Brushes.Black, e.Bounds.Left + ImageList1.ImageSize.Width + 16, e.Bounds.Top)

                'e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

            End If

            e.DrawFocusRectangle()

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub ComboCondicion_MeasureItem(sender As Object, e As System.Windows.Forms.MeasureItemEventArgs) Handles ComboCondicion.MeasureItem
        'Esto es para darle espacio a los elementos mostrados en el ComboBox

        Try

            e.ItemHeight = ImageList1.ImageSize.Height + 3

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub ComboClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboClasificacion.SelectedIndexChanged
        'Esto es para enviar texto del combobox a un textbox

        TextBox6.Text = ComboClasificacion.SelectedItem

    End Sub

    Private Sub LimpiarComponentes()
        'Metodo que permite limpiar todos los controles del formulario.

        TextBox1.Text = ""
        'TextBox2.Text = ""
        'TextBox3.Text = ""
        ComboClasificacion.Text = ""

    End Sub

    Function ValidarComponentes() As Boolean

        Dim Validar As Boolean = True

        'Limpia todos los mensajes de error mostrados en la interfaz de usuario
        ErrorProvider1.Clear()

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(TextBox1.Text) Then
            ErrorProvider1.SetError(TextBox1, "No puede dejar campos en blanco.")
            Validar = False
        End If

        If String.IsNullOrEmpty(ComboFlota.Text) Then
            ErrorProvider1.SetError(ComboFlota, "No puede dejar campos en blanco.")
            Validar = False
        End If

        If String.IsNullOrEmpty(ComboTipo.Text) Then
            ErrorProvider1.SetError(ComboTipo, "No puede dejar campos en blanco.")
            Validar = False
        End If

        If String.IsNullOrEmpty(ComboEstado.Text) Then
            ErrorProvider1.SetError(ComboEstado, "No puede dejar campos en blanco.")
            Validar = False
        End If

        If String.IsNullOrEmpty(ComboClasificacion.Text) Then
            ErrorProvider1.SetError(ComboClasificacion, "No puede dejar campos en blanco.")
            Validar = False
        End If

        Return Validar

    End Function

    Function VerificarExistencia(ByVal id As String) As Boolean
        'Funcion booleana que permite validar si existe algun ID en la base de datos
        'para evitar registrar duplicados.

        Dim sql As String = "SELECT COUNT(idvehiculo) > 0 FROM vehiculo WHERE idvehiculo = '" & id & "' "
        Dim con As New MySqlCommand(sql, cnn)
        Return Convert.ToBoolean(con.ExecuteScalar())

    End Function


End Class