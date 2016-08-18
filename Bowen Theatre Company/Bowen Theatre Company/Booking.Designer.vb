<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSeatAllocations
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlSeatNumbers = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSelectSeat = New System.Windows.Forms.Label()
        Me.cmbTicketType = New System.Windows.Forms.ComboBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblTicketType = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblDateOfBirth = New System.Windows.Forms.Label()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.dtpDateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.lblSurname = New System.Windows.Forms.Label()
        Me.tipShowTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pnlSeatNumbers
        '
        Me.pnlSeatNumbers.ColumnCount = 6
        Me.pnlSeatNumbers.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.pnlSeatNumbers.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.pnlSeatNumbers.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.pnlSeatNumbers.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.pnlSeatNumbers.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.pnlSeatNumbers.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.pnlSeatNumbers.Location = New System.Drawing.Point(12, 157)
        Me.pnlSeatNumbers.Name = "pnlSeatNumbers"
        Me.pnlSeatNumbers.RowCount = 4
        Me.pnlSeatNumbers.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.pnlSeatNumbers.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.pnlSeatNumbers.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.pnlSeatNumbers.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.pnlSeatNumbers.Size = New System.Drawing.Size(400, 250)
        Me.pnlSeatNumbers.TabIndex = 0
        '
        'lblSelectSeat
        '
        Me.lblSelectSeat.AutoSize = True
        Me.lblSelectSeat.Location = New System.Drawing.Point(9, 141)
        Me.lblSelectSeat.Name = "lblSelectSeat"
        Me.lblSelectSeat.Size = New System.Drawing.Size(86, 13)
        Me.lblSelectSeat.TabIndex = 5
        Me.lblSelectSeat.Text = "Select your seat."
        '
        'cmbTicketType
        '
        Me.cmbTicketType.FormattingEnabled = True
        Me.cmbTicketType.Items.AddRange(New Object() {"Adult", "Concession"})
        Me.cmbTicketType.Location = New System.Drawing.Point(212, 90)
        Me.cmbTicketType.Name = "cmbTicketType"
        Me.cmbTicketType.Size = New System.Drawing.Size(200, 21)
        Me.cmbTicketType.TabIndex = 29
        Me.cmbTicketType.Tag = "Ticket Type"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(212, 12)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(200, 20)
        Me.txtFirstName.TabIndex = 23
        Me.txtFirstName.Tag = "First Name"
        '
        'lblTicketType
        '
        Me.lblTicketType.AutoSize = True
        Me.lblTicketType.Location = New System.Drawing.Point(142, 93)
        Me.lblTicketType.Name = "lblTicketType"
        Me.lblTicketType.Size = New System.Drawing.Size(64, 13)
        Me.lblTicketType.TabIndex = 28
        Me.lblTicketType.Text = "Ticket Type"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(149, 15)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(57, 13)
        Me.lblFirstName.TabIndex = 22
        Me.lblFirstName.Text = "First Name"
        '
        'lblDateOfBirth
        '
        Me.lblDateOfBirth.AutoSize = True
        Me.lblDateOfBirth.Location = New System.Drawing.Point(138, 67)
        Me.lblDateOfBirth.Name = "lblDateOfBirth"
        Me.lblDateOfBirth.Size = New System.Drawing.Size(68, 13)
        Me.lblDateOfBirth.TabIndex = 27
        Me.lblDateOfBirth.Text = "Date Of Birth"
        '
        'txtSurname
        '
        Me.txtSurname.Location = New System.Drawing.Point(212, 38)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(200, 20)
        Me.txtSurname.TabIndex = 24
        Me.txtSurname.Tag = "Surname"
        '
        'dtpDateOfBirth
        '
        Me.dtpDateOfBirth.Location = New System.Drawing.Point(212, 64)
        Me.dtpDateOfBirth.Name = "dtpDateOfBirth"
        Me.dtpDateOfBirth.Size = New System.Drawing.Size(200, 20)
        Me.dtpDateOfBirth.TabIndex = 26
        Me.dtpDateOfBirth.Tag = "Date of Birth"
        '
        'lblSurname
        '
        Me.lblSurname.AutoSize = True
        Me.lblSurname.Location = New System.Drawing.Point(157, 41)
        Me.lblSurname.Name = "lblSurname"
        Me.lblSurname.Size = New System.Drawing.Size(49, 13)
        Me.lblSurname.TabIndex = 25
        Me.lblSurname.Text = "Surname"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(336, 118)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 30
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'frmSeatAllocations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(424, 419)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.cmbTicketType)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.lblTicketType)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.lblDateOfBirth)
        Me.Controls.Add(Me.txtSurname)
        Me.Controls.Add(Me.dtpDateOfBirth)
        Me.Controls.Add(Me.lblSurname)
        Me.Controls.Add(Me.lblSelectSeat)
        Me.Controls.Add(Me.pnlSeatNumbers)
        Me.Name = "frmSeatAllocations"
        Me.Text = "Booking"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlSeatNumbers As TableLayoutPanel
    Friend WithEvents lblSelectSeat As Label
    Friend WithEvents cmbTicketType As ComboBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents lblTicketType As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents lblDateOfBirth As Label
    Friend WithEvents txtSurname As TextBox
    Friend WithEvents dtpDateOfBirth As DateTimePicker
    Friend WithEvents lblSurname As Label
    Friend WithEvents tipShowTip As ToolTip
    Friend WithEvents btnClear As Button
End Class
