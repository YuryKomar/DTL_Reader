'// This code helps programmer to retrive a data from *DTL files.
'// The author of this code is Yury, Komar.
'// Public Function ReadDTL retirns a DataTable.
Module DtlReader
	Enum ValueType
		Int16_BCD_Unsigned = 0
		Int16_BCD_Signed = 1
		Int16_Unsigned = 2
		Int16_Signed = 3
		Int32_Unsigned = 4
		Int32_Signed = 5
		Float32 = 6
		String_ = 7
	End Enum
	Structure DTLColumn
		Public Type As ValueType, Size As Integer, Name As String
	End Structure
	Structure DTLHeader
		Public Sign As Integer, Undef1 As Integer, Date2 As Integer, FieldsCount As Integer, Count2 As Integer
		Public Columns() As DTLColumn
	End Structure
	Structure DTLRow
		Public Date_ As DateTime, Cells() As Object
	End Structure

	Public Function ReadDTL(FileName As String) As DataTable
		Dim newDT As New DataTable
		Using BinReader = New IO.BinaryReader(New IO.FileStream(FileName, IO.FileMode.Open, IO.FileAccess.Read), System.Text.Encoding.Default)
			Dim Header As DTLHeader
			Dim Rows As New DTLRow()

			'Read Header------------------------------------------------------------------------------------------------
			Header.Sign = BinReader.ReadInt32 'Not using in this code
			Header.Undef1 = BinReader.ReadInt32	'Not using in this code
			Header.Date2 = BinReader.ReadInt32 'Not using in this code
			Header.FieldsCount = BinReader.ReadInt32 'Read Columns number (+4 bytes)
			Header.Count2 = BinReader.ReadInt32 * 2	'Not using in this code
			Header.Columns = New DTLColumn(Header.FieldsCount - 1) {} 'Create empty array of Columns
			For i = 0 To Header.Columns.Count - 1 'Read each column's Type and Size
				Header.Columns(i).Type = BinReader.ReadInt32
				Header.Columns(i).Size = BinReader.ReadInt32
			Next
			BinReader.BaseStream.Position += 4 'skip 4 bytes
			For i = 0 To Header.Columns.Count - 1
				Header.Columns(i).Name = System.Text.Encoding.UTF8.GetString(BinReader.ReadBytes(BinReader.ReadInt16))
				'MsgBox(Header.Columns(i).Name & vbCrLf & Header.Columns(i).Type) 'Check ColumnHeader Name and Type
			Next

			'Create DataTable Columns-------------------------------------------------------------------------------------
			newDT.Columns.Add("DateTime", GetType(System.DateTime))
			For Each f In Header.Columns
				If f.Type.ToString.Length > 0 Then newDT.Columns.Add(f.Name & StrDup(newDT.Columns.Count, vbNullChar))
			Next

			'ReadRowData ------------------------------------------------------------------------------------------------
			Do Until BinReader.BaseStream.Position = BinReader.BaseStream.Length
				Rows.Date_ = New DateTime(1970, 1, 1).AddSeconds(BinReader.ReadInt32).AddMilliseconds(BinReader.ReadByte)
				Rows.Cells = New Object(Header.Columns.Count - 1) {}
				For i = 0 To Header.Columns.Count - 1
					Select Case Header.Columns(i).Type
						Case ValueType.Int16_BCD_Unsigned
							Rows.Cells(i) = BinReader.ReadInt16
						Case ValueType.Int16_BCD_Signed
							Rows.Cells(i) = BinReader.ReadInt16
						Case ValueType.Int16_Signed
							Rows.Cells(i) = BinReader.ReadInt16
						Case ValueType.Int16_Unsigned
							Rows.Cells(i) = BinReader.ReadInt16
						Case ValueType.Int32_Signed
							Rows.Cells(i) = BinReader.ReadInt32
						Case ValueType.Int32_Unsigned
							Rows.Cells(i) = BinReader.ReadInt32
						Case ValueType.Float32
							Rows.Cells(i) = BinReader.ReadSingle
						Case ValueType.String_
							Rows.Cells(i) = System.Text.Encoding.UTF8.GetString(BinReader.ReadBytes(Header.Columns(i).Size * 2))	'Read String with length * 2
					End Select
				Next

				'Construct a new row and add it to the table-----------------------------------------------------------
				Dim Params As New List(Of Object)
				Params.Add(Rows.Date_)
				Params.AddRange((From r In Rows.Cells Where Not r Is Nothing).ToList)
				newDT.Rows.Add(Params.ToArray)
			Loop
		End Using
		Return newDT
		newDT.Dispose()
		GC.Collect()
	End Function
End Module