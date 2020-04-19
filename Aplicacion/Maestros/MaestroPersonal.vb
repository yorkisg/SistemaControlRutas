
Public Class MaestroPersonal

    Private Sub MaestroPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Si la llamada no proviene del formulario GuiaTelefonica, entonces incrementamos la serie del chofer
        If GuiaTelefonica.Visible = False Then

            Serie()

            'Inicializamos los combobox
            ComboEstadoPersona.SelectedItem = "ACTIVO"
            ComboTipoPersona.SelectedItem = "CARGA"

        End If

        'Validamos que en cada Textbox del formulario solo se agregue texto en mayusculas.
        TextBox1.CharacterCasing = CharacterCasing.Upper
        TextBox2.CharacterCasing = CharacterCasing.Upper

    End Sub

    Private Sub MaestroPersonal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        LimpiarComponentes()
        BotonBuscar.Enabled = True
        Dispose()

    End Sub

    Private Sub BotonGuardar_Click(sender As Object, e As EventArgs) Handles BotonGuardar.Click
        'Boton registrar

        'Se valida que no haya algun campo vacio
        If ValidarComponentes() = True Then

            Dim db As New MySqlCommand("INSERT INTO personal (idpersonal, nombrepersonal, tipopersonal, telefono1, telefono2, estadopersonal) VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & ComboTipoPersona.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & ComboEstadoPersona.Text & "')", Conexion)
            db.ExecuteNonQuery()
            MsgBox("Personal registrado con Exito.", MsgBoxStyle.Information, "Exito.")

            'Se limpian todos los componentes del formulario para un nuevo uso.
            LimpiarComponentes()
            'Se habilita el metodo para incrementar el siguiente ID.
            Serie()

            TextBox3.Text = "N/A"
            TextBox4.Text = "N/A"

        End If

        'Si la llamada proviene del formulario RegistroRuta, entonces se cierra al modificar el registro seleccionado
        If SeguimientoCarga.Visible = True Then

            Dispose()

        End If

    End Sub

    Private Sub BotonModificar_Click(sender As Object, e As EventArgs) Handles BotonModificar.Click
        'Boton modificar

        'Se valida que no haya algun campo vacio
        If ValidarComponentes() = True Then

            Dim db As New MySqlCommand("UPDATE personal SET nombrepersonal = '" & TextBox2.Text & "', telefono1 = '" & TextBox3.Text & "', telefono2 = '" & TextBox4.Text & "', estadopersonal = '" & ComboEstadoPersona.Text & "', tipopersonal = '" & ComboTipoPersona.Text & "' WHERE idpersonal = '" & TextBox1.Text & "' ", Conexion)
            db.ExecuteNonQuery()
            MsgBox("Personal modificado con Exito.", MsgBoxStyle.Information, "Exito.")

            'Se desactiva el uso del boton modificar.
            BotonModificar.Enabled = False
            'Se activa el uso del boton guardar.
            BotonGuardar.Enabled = True
            'Se desactiva el uso del boton buscar.
            BotonBuscar.Enabled = True
            'Se limpian todos los componentes del formulario para un nuevo uso.
            LimpiarComponentes()
            'Se habilita el metodo para incrementar el siguiente ID.
            Serie()

            TextBox3.Text = "N/A"
            TextBox4.Text = "N/A"

            'Si la llamada proviene del formulario GuiaTelefonica, entonces se cierra al modificar el registro seleccionado
            If GuiaTelefonica.Visible = True Then

                If GuiaTelefonica.Panel8.SelectedIndex = 0 Then

                    CargarGridGuiaPersonalCarga()

                ElseIf GuiaTelefonica.Panel8.SelectedIndex = 1 Then

                    CargarGridGuiaPersonalLiviano()

                ElseIf GuiaTelefonica.Panel8.SelectedIndex = 2 Then

                    CargarGridGuiaPersonal()

                End If

                Dispose()

            End If

        End If

    End Sub

    Private Sub BotonBuscar_Click(sender As Object, e As EventArgs) Handles BotonBuscar.Click
        'Boton buscar

        ListadoPersonal.ShowDialog()

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton salir

        LimpiarComponentes()
        BotonBuscar.Enabled = True
        Dispose()

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        'Evento KeyPress: permite agregar solo numeros en el textbox.

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        'Evento KeyPress: permite agregar solo numeros en el textbox.

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub LimpiarComponentes()
        'Metodo que permite limpiar todos los controles del formulario.

        'TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboEstadoPersona.Text = ""

    End Sub

    Private Sub Serie()
        'Metodo que permite generar una serie correlativa de numeros enteros. 
        'Usado para generar automaticamente el ID.

        'Se obtiene el ultimo ID.
        Dim Command As New MySqlCommand("SELECT MAX(idpersonal) FROM personal", Conexion)
        Dim numero As Integer

        'El ID obtenido de la BD se incrementa.
        numero = Command.ExecuteScalar
        numero = numero + 1

        'Se da formato al ID obtenido de la BD.
        TextBox1.Text = Format(numero, ("000000000"))

    End Sub

    Function ValidarComponentes() As Boolean

        Dim Validar As Boolean = True

        'Limpia todos los mensajes de error mostrados en la interfaz de usuario
        ErrorProvider1.Clear()

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(TextBox2.Text) Then
            ErrorProvider1.SetError(TextBox2, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(TextBox3.Text) Then
            ErrorProvider1.SetError(TextBox3, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(TextBox4.Text) Then
            ErrorProvider1.SetError(TextBox4, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el combobox no este nulo o vacio
        If String.IsNullOrEmpty(ComboEstadoPersona.Text) Then
            ErrorProvider1.SetError(ComboEstadoPersona, "No puede dejar campos en blanco.")
            Validar = False
        End If

        Return Validar

    End Function

    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        'Metodo para colocar el texto al borrar el numero

        If TextBox3.Text = "" Then

            TextBox3.Text = "N/A"

        End If

    End Sub

    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        'Metodo para colocar el texto al borrar el numero

        If TextBox4.Text = "" Then

            TextBox4.Text = "N/A"

        End If

    End Sub


End Class