'// This code helps programmer to retrive a data from *EVT files.
'// The author of this code is Yury, Komar.
'// Public Function ReadEVT retirns a DataTable.
Module EVTreader
	Structure EVTHeader
		Public Sign, Undef1, Date2, Count As Integer
	End Structure
	Structure EVTRow
		Public Date_ As DateTime, Evnt As Byte, Catgry As Byte, Msg As String
	End Structure

	Public Function ReadEVT(FileName As String) As DataTable
		Dim newDT As New DataTable
		Using BinReader = New IO.BinaryReader(New IO.FileStream(FileName, IO.FileMode.Open, IO.FileAccess.Read), System.Text.Encoding.Default)
			Dim Header As EVTHeader
			Dim Rows As New EVTRow()

			'Read Header------------------------------------------------------------------------------------------------
			Header.Sign = BinReader.ReadInt32 'Not using in this code
			Header.Undef1 = BinReader.ReadInt32	'Not using in this code
			Header.Date2 = BinReader.ReadInt32 'Not using in this code
			Header.Count = BinReader.ReadInt32 '* 2	'Not using in this code

			'Create DataTable Columns-------------------------------------------------------------------------------------
			newDT.Columns.Add("DateTime", GetType(System.DateTime))
			newDT.Columns.Add("Event") ', GetType(System.DateTime))
			newDT.Columns.Add("Category") ', GetType(System.DateTime))
			newDT.Columns.Add("Message", GetType(System.String))

			'ReadRowData ------------------------------------------------------------------------------------------------
			Do Until BinReader.BaseStream.Position = BinReader.BaseStream.Length
				Rows.Date_ = New DateTime(1970, 1, 1).AddSeconds(BinReader.ReadInt32)
				Rows.Evnt = BinReader.ReadByte
				Rows.Catgry = BinReader.ReadByte
				Rows.Msg = System.Text.Encoding.UTF8.GetString(BinReader.ReadBytes(BinReader.ReadByte))

				'Construct a new row and add it to the table-----------------------------------------------------------
				Dim Params As New List(Of Object)
				Params.Add(Rows.Date_)
				Params.Add(Rows.Evnt)
				Params.Add(Rows.Catgry)
				Params.Add(Rows.Msg)
				newDT.Rows.Add(Params.ToArray)
			Loop
		End Using
		Return newDT
		newDT.Dispose()
		GC.Collect()
	End Function
End Module
