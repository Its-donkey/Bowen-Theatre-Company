Option Strict Off
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class frmSeatAllocations

    Private validationPatterns As New Dictionary(Of String, Regex)

    Private Sub frmSeatAllocations_Load(sender As Object, e As EventArgs) Handles Me.Load
        validationPatterns.Add("FirstName", New Regex("^[a-z]+[\-'\s]?[a-z]+$", RegexOptions.IgnoreCase))
        validationPatterns.Add("Surname", New Regex("^[a-z]+[\-'\s]?[a-z]+$", RegexOptions.IgnoreCase))

        dtpDateOfBirth.MaxDate = Today 'Stop people being born in the future

        Dim font As New System.Drawing.Font("Arial", 10, FontStyle.Bold)
        Dim i As Integer = 0

        For rowNumber As Integer = 0 To pnlSeatNumbers.RowCount - 1
            For columnNumber As Integer = 0 To pnlSeatNumbers.ColumnCount - 1

                btnSeatAllocation = New Button
                Dim buttonName As String = Convert.ToChar(rowNumber + 65) & (columnNumber + 1)

                With btnSeatAllocation
                    .Size = New Size(100%, 100%)
                    .Tag = i
                    .Name = buttonName
                    .Text = buttonName
                    .ForeColor = Color.Black
                    .BackColor = Color.LightGreen
                    .Font = font
                    .BackgroundImage = My.Resources.chair
                    .BackgroundImageLayout = ImageLayout.Stretch
                End With

                AddHandler btnSeatAllocation.MouseDown, AddressOf btnSeatAllocation_MouseDown
                AddHandler btnSeatAllocation.MouseHover, AddressOf btnSeatAllocation_MouseHover

                pnlSeatNumbers.Controls.Add(btnSeatAllocation, columnNumber, rowNumber)

                ReDim Preserve seatButtons(i)
                seatButtons(i).status = True

                i += 1
            Next
        Next
    End Sub

    Private Sub btnSeatAllocation_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)

        If e.Button = MouseButtons.Left Then
            If validateForm() Then
                If seatButtons(sender.Tag).status = True Then
                    Dim ticket As TicketInfo

                    With ticket
                        .firstName = txtFirstName.Text
                        .surname = txtSurname.Text
                        .dateOfBirth = dtpDateOfBirth.Value
                        .type = CType(cmbTicketType.SelectedItem, String)
                    End With

                    seatButtons(sender.Tag).ticketBookingDetails = saveTicketInfo(ticket)
                    seatButtons(sender.Tag).status = False

                    With sender
                        .Forecolor = Color.White
                        .Backcolor = Color.Red
                        .Text += vbCrLf & "N/A" & vbCrLf & "" & vbCrLf & ""
                        .Font = New System.Drawing.Font("Arial", 8, FontStyle.Bold)
                    End With

                    clearForm(sender, e)
                    lblSeatNotAvailable.Visible = False
                Else
                    displaySeatTaken(5)
                End If
            End If

        ElseIf e.Button = MouseButtons.Right Then
            'If the button is right clicked Fill in the field on frmShowDetails to reflect the booking details
            'If booked will show all the details else will show Available
            If seatButtons(sender.Tag).status = True Then
                frmShowDetails.txtTicketDetails.Text = "Available"
            ElseIf seatButtons(sender.Tag).status = False Then
                frmShowDetails.txtTicketDetails.Text = seatButtons(sender.Tag).ticketBookingDetails
            End If
            frmShowDetails.txtTicketDetails.ReadOnly = True

            frmShowDetails.ShowDialog()
        End If
    End Sub

    Private Sub btnSeatAllocation_MouseHover(ByVal sender As Object, ByVal e As EventArgs)
        Dim arrayNumbers() As String = Split(sender.tag, ",")
        Dim tooltip As String = seatButtons(sender.Tag).ticketBookingDetails
        If seatButtons(sender.Tag).status = False Then
            tipShowTip.SetToolTip(sender, tooltip)
            tipShowTip.ToolTipTitle = "Booking Information"
        Else
            tipShowTip.SetToolTip(sender, "Available")
            tipShowTip.ToolTipTitle = ""
        End If
    End Sub

    Private Sub dtpDateOfBirth_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateOfBirth.ValueChanged
        'A child must be under 14.
        If DateDiff(DateInterval.Day, Now, dtpDateOfBirth.Value) < -5114 Then 'If the patron is over 14 years
            cmbTicketType.Items.Remove("Child") 'Remove child ticket type

        ElseIf cmbTicketType.Items.Contains("Child") Then
            'Do nothing if patron is under 14 and the item already exists
        Else
            cmbTicketType.Items.Add("Child")
        End If
    End Sub


    Function validateForm() As Boolean
        Dim errorMessage As String = "The following fields are invalid"
        Dim invalid As Boolean = False
        For Each validationPattern As KeyValuePair(Of String, Regex) In validationPatterns
            Dim field As Control = Controls("txt" & validationPattern.Key)
            Dim match As Match = validationPattern.Value.Match(field.Text)

            If Not match.Success Then
                errorMessage += Environment.NewLine & "-" & field.Tag

                invalid = True
            End If
        Next

        If dtpDateOfBirth.Value = Today Then
            errorMessage += Environment.NewLine & "-" & dtpDateOfBirth.Tag
            invalid = True
        End If

        If cmbTicketType.SelectedItem = "" Then
            errorMessage += Environment.NewLine & "-" & cmbTicketType.Tag
            invalid = True
        End If

        If invalid Then
            MsgBox(errorMessage)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub clearForm(sender As Object, e As EventArgs) Handles btnClear.Click
        txtFirstName.Clear()
        txtSurname.Clear()
        dtpDateOfBirth.Value = Today
        cmbTicketType.SelectedIndex = -1
        lblSeatNotAvailable.Visible = False
    End Sub


    Private Async Sub displaySeatTaken(ByVal seconds As Integer)
        lblSeatNotAvailable.Visible = True
        Await Task.Delay(seconds * 1000)
        lblSeatNotAvailable.Visible = False
    End Sub
End Class