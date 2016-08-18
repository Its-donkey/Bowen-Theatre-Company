Public Module Utilities
    Public btnSeatAllocation As Control
    Public seatButtons(3, 5) As String
    Public senderArrayValue As String


    Public Structure TicketInfo
        Dim firstName, surname As String
        Dim dateOfBirth As Date
        Dim type As String
    End Structure

    Public Function saveTicketInfo(ticket As TicketInfo) As String
        Try
            Return "Name - " & ticket.firstName & " " & ticket.surname & vbCrLf & "Date Of Birth - " & ticket.dateOfBirth & vbCrLf & "Ticket Type - " & ticket.type
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Module


