Option Strict Off
Imports System.Text.RegularExpressions

Public Class frmSeatAllocations

    Private validationPatterns As New Dictionary(Of String, Regex)

    Private Sub frmSeatAllocations_Load(sender As Object, e As EventArgs) Handles Me.Load
        validationPatterns.Add("FirstName", New Regex("^[a-z]+[\-'\s]?[a-z]+$", RegexOptions.IgnoreCase))
        validationPatterns.Add("Surname", New Regex("^[a-z]+[\-'\s]?[a-z]+$", RegexOptions.IgnoreCase))

        dtpDateOfBirth.MaxDate = Today 'Stop people being born in the future

        Dim font As New System.Drawing.Font("Arial", 10)

        For rowNumber As Integer = 0 To pnlSeatNumbers.RowCount - 1
            For columnNumber As Integer = 0 To pnlSeatNumbers.ColumnCount - 1

                btnSeatAllocation = New Button
                Dim buttonName As String = Convert.ToChar(rowNumber + 65) & (columnNumber + 1)

                With btnSeatAllocation
                    .Size = New Size(100%, 100%)
                    .Tag = rowNumber & "," & columnNumber
                    .Name = buttonName
                    .Text = buttonName
                    .ForeColor = Color.Green
                    .Font = font
                    .BackgroundImage = My.Resources.chair
                    .BackgroundImageLayout = ImageLayout.Stretch
                End With

                AddHandler btnSeatAllocation.MouseDown, AddressOf btnSeatAllocation_MouseDown
                AddHandler btnSeatAllocation.MouseHover, AddressOf btnSeatAllocation_MouseHover

                pnlSeatNumbers.Controls.Add(btnSeatAllocation, columnNumber, rowNumber)
                seatButtons(rowNumber, columnNumber) = "Available"


            Next
        Next
    End Sub

    Private Sub btnSeatAllocation_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim arrayNumbers() As String = Split(sender.tag, ",")
        senderArrayValue = seatButtons(arrayNumbers(0), arrayNumbers(1))
        If e.Button = MouseButtons.Left Then


            If validateForm() Then
                If senderArrayValue = "Available" Then
                    Dim ticket As TicketInfo

                    With ticket
                        .firstName = txtFirstName.Text
                        .surname = txtSurname.Text
                        .dateOfBirth = dtpDateOfBirth.Value
                        .type = cmbTicketType.SelectedItem
                    End With

                    seatButtons(arrayNumbers(0), arrayNumbers(1)) = saveTicketInfo(ticket)
                    With sender
                        .forecolor = Color.Black
                        .Backcolor = Color.MistyRose

                    End With

                    clearForm(sender, e)

                Else
                    MsgBox("Unfortunately the seat you have selected is not available." & vbCrLf & "Please select another seat")

                End If
            End If
        ElseIf e.Button = MouseButtons.Right Then
            frmShowDetails.ShowDialog()
        End If
    End Sub

    Private Sub btnSeatAllocation_MouseHover(ByVal sender As Object, ByVal e As EventArgs)
        Dim arrayNumbers() As String = Split(sender.tag, ",")
        Dim tooltip As String = seatButtons(arrayNumbers(0), arrayNumbers(1))
        If tooltip <> "Available" Then
            tipShowTip.SetToolTip(sender, tooltip)
            tipShowTip.ToolTipTitle = "Booking Information"
        Else
            tipShowTip.ToolTipTitle = ""
            tipShowTip.SetToolTip(sender, tooltip)
        End If
    End Sub

    Private Sub dtpDateOfBirth_ValueChanged(sender As Object, e As EventArgs)
        'Check if the right ticket type is selected
        'A child ticket must be less than 14 years old
        If DateDiff(DateInterval.Day, Now, dtpDateOfBirth.Value) < -5114 Then
            cmbTicketType.Items.Remove("Child")

        ElseIf cmbTicketType.Items.Contains("Child") Then

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
    End Sub
End Class