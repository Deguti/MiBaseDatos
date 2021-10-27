Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Public stringConeccion As String = “Data Source = DESKTOP-2ROLQTO; Initial Catalog = Facturacion xx; Integrated Security = True”
    Dim stringSelect As String = "SELECT * FROM Clientes"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CargarGrid()

    End Sub

    Private Sub CargarGrid()

        Dim da As SqlDataAdapter
        Dim dt As New DataTable
        Try
            da = New SqlDataAdapter(stringSelect, stringConeccion)
            da.Fill(dt)
            Me.GridView1.DataSource = dt
            'LabelInfo.Text = String.Format("Total datos en la tabla: {0}", dt.Rows.Count)
            'String.Format("Total datos en la tabla: {0}", dt.Rows.Count)el 0 se sustituye por el valor de la par o que le asignes
        Catch ex As Exception

            LabelInfo.Text = "Error: " & ex.Message
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim NombreTabla As String = "clientes"
        Dim InsertSql As String
        InsertSql = "INSERT INTO " & NombreTabla & " (IdCliente, TerminosFactura, NombreCliente, NombreEmpresaCliente, "
        InsertSql = InsertSql & " CalleCliente, Ciudad, Provincia, CodigoPostal, TelefonoCliente, DireccionCorreoElectronico ) " & "VALUES "
        InsertSql = InsertSql & "(@IdCliente, @TerminosFactura, @NombreCliente, @NombreEmpresaCliente, "
        InsertSql = InsertSql & " @CalleCliente, @Ciudad, @Provincia, @CodigoPostal, @TelefonoCliente, @DireccionCorreoElectronico )"

        Using con As New SqlConnection(stringConeccion)

            Dim cmd As New SqlCommand(insertsql, con)
            cmd.Parameters.AddWithValue("@idCliente", Val(TextCliente.Text))
            cmd.Parameters.AddWithValue("@TerminosFactura", TextTerminos.Text)
            cmd.Parameters.AddWithValue("@NombreCliente", TextNombre.Text)
            cmd.Parameters.AddWithValue("@NombreEmpresaCliente", TextEmpresa.Text)
            cmd.Parameters.AddWithValue("@CalleCliente", TextCalle.Text)
            cmd.Parameters.AddWithValue("@Ciudad", TextCiudad.Text)
            cmd.Parameters.AddWithValue("@Provincia", TextProvincia.Text)
            cmd.Parameters.AddWithValue("@CodigoPostal", TextCodigo.Text)
            cmd.Parameters.AddWithValue("@TelefonoCliente", TextTelefono.Text)
            cmd.Parameters.AddWithValue("@DireccionCorreoElectronico", TextCorreo.Text)

            con.Open()
            Dim t As Integer = CInt(cmd.ExecuteScalar())

            con.Close()

        End Using

        Call CargarGrid()

    End Sub
End Class


