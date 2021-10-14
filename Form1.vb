Public Class Form1
	Dim fPath As String
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.Icon = My.Resources.ICON_159_0000
		Text = Application.ProductName & "  v" & Application.ProductVersion
		If Not My.Application.CommandLineArgs.Count = 0 Then
			If Not My.Application.CommandLineArgs(0).Trim.Length = 0 Then
				fPath = My.Application.CommandLineArgs(0).Trim
				Dim DT As DataTable

				If fPath.ToUpper.EndsWith("DTL") Then
					DT = ReadDTL(fPath)
				ElseIf fPath.ToUpper.EndsWith("EVT") Then
					DT = ReadEVT(fPath)
				End If

				With DGV1
					.DataSource = Nothing : .DataSource = DT
					.DataSource = Nothing : .DataSource = DT

					If fPath.ToUpper.EndsWith("DTL") Then
						.Columns(0).DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss.ffff"
					ElseIf fPath.ToUpper.EndsWith("EVT") Then
						.Columns(0).DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss"
					End If

				End With
			End If
		End If
		GC.Collect()
	End Sub

	Private Sub ОткрытьToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenFile.Click
		Using OFD = New OpenFileDialog With {.Title = "Open", .Filter = "DTL, EVT Files|*.dtl;*.evt", .Multiselect = False, .ShowReadOnly = False}
			If Not OFD.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
			fPath = OFD.FileName
		End Using
		'-------------------------------------------------------------------------------------
		Dim DT As DataTable

		If fPath.ToUpper.EndsWith("DTL") Then
			DT = ReadDTL(fPath)
		ElseIf fPath.ToUpper.EndsWith("EVT") Then
			DT = ReadEVT(fPath)
		End If

		With DGV1
			.DataSource = Nothing : .DataSource = DT
			.DataSource = Nothing : .DataSource = DT

			If fPath.ToUpper.EndsWith("DTL") Then
				.Columns(0).DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss.ffff"
			ElseIf fPath.ToUpper.EndsWith("EVT") Then
				.Columns(0).DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss"
			End If

		End With
		GC.Collect()
	End Sub

	Private Sub СправкаToolStripButton_Click(sender As Object, e As EventArgs) Handles abt.Click
		MsgBox(Application.ProductName & vbCrLf & "Version " & Application.ProductVersion & vbCrLf & vbCrLf & "Copyright (c) 2017 Yury Komar", 4096, "About...")
	End Sub
End Class
