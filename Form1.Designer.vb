<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.OpenFile = New System.Windows.Forms.ToolStripButton()
		Me.SaveFile = New System.Windows.Forms.ToolStripButton()
		Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
		Me.abt = New System.Windows.Forms.ToolStripButton()
		Me.DGV1 = New DTLReader_.DataGridViewBuffered()
		Me.ToolStrip1.SuspendLayout()
		CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFile, Me.SaveFile, Me.toolStripSeparator, Me.abt})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
		Me.ToolStrip1.Size = New System.Drawing.Size(584, 25)
		Me.ToolStrip1.TabIndex = 4
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'OpenFile
		'
		Me.OpenFile.Image = CType(resources.GetObject("OpenFile.Image"), System.Drawing.Image)
		Me.OpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.OpenFile.Name = "OpenFile"
		Me.OpenFile.Size = New System.Drawing.Size(56, 22)
		Me.OpenFile.Text = "&Open"
		'
		'SaveFile
		'
		Me.SaveFile.Enabled = False
		Me.SaveFile.Image = CType(resources.GetObject("SaveFile.Image"), System.Drawing.Image)
		Me.SaveFile.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.SaveFile.Name = "SaveFile"
		Me.SaveFile.Size = New System.Drawing.Size(51, 22)
		Me.SaveFile.Text = "&Save"
		'
		'toolStripSeparator
		'
		Me.toolStripSeparator.Name = "toolStripSeparator"
		Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
		'
		'abt
		'
		Me.abt.Image = CType(resources.GetObject("abt.Image"), System.Drawing.Image)
		Me.abt.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.abt.Name = "abt"
		Me.abt.Size = New System.Drawing.Size(69, 22)
		Me.abt.Text = "About..."
		'
		'DGV1
		'
		Me.DGV1.AllowUserToAddRows = False
		Me.DGV1.AllowUserToDeleteRows = False
		Me.DGV1.AllowUserToResizeRows = False
		Me.DGV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
		Me.DGV1.BackgroundColor = System.Drawing.Color.White
		Me.DGV1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DGV1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DGV1.Location = New System.Drawing.Point(0, 25)
		Me.DGV1.Name = "DGV1"
		Me.DGV1.ReadOnly = True
		Me.DGV1.Size = New System.Drawing.Size(584, 536)
		Me.DGV1.TabIndex = 5
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(584, 561)
		Me.Controls.Add(Me.DGV1)
		Me.Controls.Add(Me.ToolStrip1)
		Me.DoubleBuffered = True
		Me.Name = "Form1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "DTL Reader"
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
	Friend WithEvents OpenFile As System.Windows.Forms.ToolStripButton
	Friend WithEvents SaveFile As System.Windows.Forms.ToolStripButton
	Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents abt As System.Windows.Forms.ToolStripButton
	Friend WithEvents DGV1 As DTLReader_.DataGridViewBuffered

End Class
