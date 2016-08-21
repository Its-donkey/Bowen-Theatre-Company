Public Module Utilities
    Public btnSeatAllocation As Control
    Public seatButtons() As TicketInfo
    Public senderArrayValue As String


    Public Structure TicketInfo
        Private m_FirstName As String
        Private m_Surname As String
        Private m_DateOfBirth As Date
        Private m_Type As String
        Private m_Status As Boolean

        Public Sub New(firstName As String, surname As String, dateofBirth As Date, type As String, status As Boolean)
            Me.m_FirstName = firstName
            Me.m_Surname = surname
            Me.m_DateOfBirth = dateofBirth
            Me.m_Type = type
            Me.m_Status = status
        End Sub

        Public Property FirstName As String
        Public Property Surname As String
        Public Property DateOfBirth As Date
        Public Property Type As String
        Public Property Status As Boolean

        Public Function ShowDetails() As String
            Return "Name - " & FirstName & " " & Surname & vbCrLf & "Date Of Birth - " & DateOfBirth & vbCrLf & "Ticket Type - " & Type
        End Function

        Public Function SaveDetails() As String
            Return FirstName & "|" & Surname & "|" & DateOfBirth.ToShortDateString & "|" & Type & "|" & Status
        End Function

    End Structure
End Module


