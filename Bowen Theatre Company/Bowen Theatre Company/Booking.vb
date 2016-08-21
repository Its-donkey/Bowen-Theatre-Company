Option Strict On
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class frmSeatAllocations
    Private senderTag As Integer
    Private senderControl As Control
    Private validationPatterns As New Dictionary(Of String, Regex)

    Private Sub frmSeatAllocations_Load(sender As Object, e As EventArgs) Handles Me.Load
        validationPatterns.Add("FirstName", New Regex("^[a-z]+[\-'\s]?[a-z]+$", RegexOptions.IgnoreCase))
        validationPatterns.Add("Surname", New Regex("^[a-z]+[\-'\s]?[a-z]+$", RegexOptions.IgnoreCase))

        dtpDateOfBirth.MaxDate = Today 'Stop people being born in the future

        Dim font As New System.Drawing.Font("Arial", 10, FontStyle.Bold)


        ReDim Preserve seatButtons(pnlSeatNumbers.ColumnCount * pnlSeatNumbers.RowCount)

        TicketsDB.GetTicketDetails()

        seatButtonsGeneration()

    End Sub
    Private Sub seatButtonsGeneration()
        Dim n As Integer = 0
        For rowNumber As Integer = 0 To pnlSeatNumbers.RowCount - 1
            For columnNumber As Integer = 0 To pnlSeatNumbers.ColumnCount - 1

                btnSeatAllocation = New Button
                Dim buttonName As String = Convert.ToChar(rowNumber + 65) & (columnNumber + 1)

                If seatButtons(n).Status = False And seatButtons(n).FirstName <> "" Then
                    With btnSeatAllocation
                        .Size = New Size(100%, 100%)
                        .Tag = n
                        .Name = buttonName
                        .Text += buttonName & vbCrLf & "N/A" & vbCrLf & "" & vbCrLf & ""
                        .ForeColor = Color.White
                        .BackColor = Color.Red
                        .Font = New System.Drawing.Font("Arial", 8, FontStyle.Bold)
                        .BackgroundImage = My.Resources.chair
                        .BackgroundImageLayout = ImageLayout.Stretch
                    End With
                Else
                    With btnSeatAllocation
                        .Size = New Size(100%, 100%)
                        .Tag = n
                        .Name = buttonName
                        .Text = buttonName
                        .ForeColor = Color.Black
                        .BackColor = Color.LightGreen
                        .Font = Font
                        .BackgroundImage = My.Resources.chair
                        .BackgroundImageLayout = ImageLayout.Stretch
                    End With

                    seatButtons(n).Status = True
                End If

                AddHandler btnSeatAllocation.MouseDown, AddressOf btnSeatAllocation_MouseDown
                AddHandler btnSeatAllocation.MouseHover, AddressOf btnSeatAllocation_MouseHover

                pnlSeatNumbers.Controls.Add(btnSeatAllocation, columnNumber, rowNumber)

                n += 1
            Next
        Next
    End Sub
    Function validateForm() As Boolean
        Dim errorMessage As String = "The following fields are invalid"
        Dim invalid As Boolean = False
        For Each validationPattern As KeyValuePair(Of String, Regex) In validationPatterns
            Dim field As Control = Controls("txt" & validationPattern.Key)
            Dim match As Match = validationPattern.Value.Match(field.Text)

            If Not match.Success Then
                Dim fieldText As String = CType(field.Tag, String)

                errorMessage += Environment.NewLine & "-" & fieldText
                invalid = True
            End If
        Next

        If dtpDateOfBirth.Value = Today Then
            Dim dateOfBirthText As String = CType(dtpDateOfBirth.Tag, String)

            errorMessage += Environment.NewLine & "-" & dateOfBirthText
            invalid = True
        End If

        If cmbTicketType.SelectedItem Is "" Then
            Dim ticketTypeText As String = CType(cmbTicketType.Tag, String)

            errorMessage += Environment.NewLine & "-" & ticketTypeText
            invalid = True
        End If

        If invalid Then
            MsgBox(errorMessage)
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub btnDeleteData_Click(sender As Object, e As EventArgs) Handles btnDeleteData.Click
        TicketsDB.DeleteTicketDate()
        Array.Clear(seatButtons, 0, seatButtons.Length)
        validationPatterns.Clear()
        Me.Controls.Clear()
        InitializeComponent()
        seatButtonsGeneration()
    End Sub
    Private Sub btnSeatAllocation_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        senderTag = CInt(DirectCast(sender, Button).Tag)
        senderControl = DirectCast(sender, Button)

        If e.Button = MouseButtons.Left Then
            If seatButtons(CInt(DirectCast(sender, Button).Tag)).Status = True Then
                If validateForm() Then
                    seatButtons(senderTag).FirstName = txtFirstName.Text
                    seatButtons(senderTag).Surname = txtSurname.Text
                    seatButtons(senderTag).DateOfBirth = CDate(dtpDateOfBirth.Value.ToShortDateString)
                    seatButtons(senderTag).Type = CType(cmbTicketType.SelectedItem, String)
                    seatButtons(senderTag).Status = False

                    With senderControl
                        .ForeColor = Color.White
                        .BackColor = Color.Red
                        .Text += vbCrLf & "N/A" & vbCrLf & "" & vbCrLf & ""
                        .Font = New System.Drawing.Font("Arial", 8, FontStyle.Bold)
                    End With

                    clearForm(sender, e)
                    lblSeatNotAvailable.Visible = False
                End If
            Else
                displaySeatTaken(5)

            End If

        ElseIf e.Button = MouseButtons.Right Then
            'If the button is right clicked Fill in the field on frmShowDetails to reflect the booking details
            'If booked will show all the details else will show Available
            If seatButtons(senderTag).Status = True Then
                frmShowDetails.txtTicketDetails.Text = "Available"
            ElseIf seatButtons(senderTag).Status = False Then
                frmShowDetails.txtTicketDetails.Text = seatButtons(senderTag).ShowDetails
            End If
            frmShowDetails.txtTicketDetails.ReadOnly = True

            frmShowDetails.ShowDialog()
        End If
    End Sub
    Private Sub btnSeatAllocation_MouseHover(ByVal sender As Object, ByVal e As EventArgs)
        senderTag = CInt(DirectCast(sender, Button).Tag)
        senderControl = DirectCast(sender, Button)

        Dim arrayNumbers() As String = Split(CType(senderControl.Tag, String), ",")
        Dim tooltip As String = seatButtons(senderTag).ShowDetails
        If seatButtons(senderTag).Status = False Then
            tipShowTip.SetToolTip(senderControl, tooltip)
            tipShowTip.ToolTipTitle = "Booking Information"
        Else
            tipShowTip.SetToolTip(senderControl, "Available")
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
    Private Sub frmSeatAllocations_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        TicketsDB.SaveTicketDetails()
    End Sub

End Class