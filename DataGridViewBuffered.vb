Public Class DataGridViewBuffered
	Inherits DataGridView
	Private Sub DataGridViewBuffered_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
		DoubleBuffered = True
	End Sub
End Class
