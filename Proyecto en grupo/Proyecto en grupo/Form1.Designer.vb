<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnParaAñadirAlumno = New System.Windows.Forms.Button()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtApellido1 = New System.Windows.Forms.TextBox()
        Me.txtApellido2 = New System.Windows.Forms.TextBox()
        Me.txtDni = New System.Windows.Forms.TextBox()
        Me.txtHorasTotales = New System.Windows.Forms.TextBox()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.txtAlias = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnParaAñadirAlumno
        '
        Me.btnParaAñadirAlumno.Location = New System.Drawing.Point(368, 54)
        Me.btnParaAñadirAlumno.Name = "btnParaAñadirAlumno"
        Me.btnParaAñadirAlumno.Size = New System.Drawing.Size(75, 23)
        Me.btnParaAñadirAlumno.TabIndex = 0
        Me.btnParaAñadirAlumno.Text = "Button1"
        Me.btnParaAñadirAlumno.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(34, 128)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(100, 22)
        Me.txtNombre.TabIndex = 1
        Me.txtNombre.Text = "Nombre"
        '
        'txtApellido1
        '
        Me.txtApellido1.Location = New System.Drawing.Point(191, 128)
        Me.txtApellido1.Name = "txtApellido1"
        Me.txtApellido1.Size = New System.Drawing.Size(100, 22)
        Me.txtApellido1.TabIndex = 2
        Me.txtApellido1.Text = "Apellido1"
        '
        'txtApellido2
        '
        Me.txtApellido2.Location = New System.Drawing.Point(343, 128)
        Me.txtApellido2.Name = "txtApellido2"
        Me.txtApellido2.Size = New System.Drawing.Size(100, 22)
        Me.txtApellido2.TabIndex = 3
        Me.txtApellido2.Text = "Apellido2"
        '
        'txtDni
        '
        Me.txtDni.Location = New System.Drawing.Point(486, 128)
        Me.txtDni.Name = "txtDni"
        Me.txtDni.Size = New System.Drawing.Size(100, 22)
        Me.txtDni.TabIndex = 4
        Me.txtDni.Text = "Dni"
        '
        'txtHorasTotales
        '
        Me.txtHorasTotales.Location = New System.Drawing.Point(623, 128)
        Me.txtHorasTotales.Name = "txtHorasTotales"
        Me.txtHorasTotales.Size = New System.Drawing.Size(100, 22)
        Me.txtHorasTotales.TabIndex = 5
        Me.txtHorasTotales.Text = "HorasTotales"
        '
        'txtCiclo
        '
        Me.txtCiclo.Location = New System.Drawing.Point(123, 188)
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(100, 22)
        Me.txtCiclo.TabIndex = 6
        Me.txtCiclo.Text = "Ciclo"
        '
        'txtAlias
        '
        Me.txtAlias.Location = New System.Drawing.Point(486, 188)
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(100, 22)
        Me.txtAlias.TabIndex = 7
        Me.txtAlias.Text = "Alias"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtAlias)
        Me.Controls.Add(Me.txtCiclo)
        Me.Controls.Add(Me.txtHorasTotales)
        Me.Controls.Add(Me.txtDni)
        Me.Controls.Add(Me.txtApellido2)
        Me.Controls.Add(Me.txtApellido1)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.btnParaAñadirAlumno)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnParaAñadirAlumno As Button
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtApellido1 As TextBox
    Friend WithEvents txtApellido2 As TextBox
    Friend WithEvents txtDni As TextBox
    Friend WithEvents txtHorasTotales As TextBox
    Friend WithEvents txtCiclo As TextBox
    Friend WithEvents txtAlias As TextBox
End Class
