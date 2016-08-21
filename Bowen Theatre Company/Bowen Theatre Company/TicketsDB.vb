Imports System.IO

Public Class TicketsDB

    Private Const Dir As String = "C:\BTC\Files\"
    Private Const Path As String = Dir & "Tickets.Dat"

    Public Shared Function GetTicketDetails() As List(Of TicketInfo)

        If Not Directory.Exists(Dir) Then
            Directory.CreateDirectory(Dir)
        End If

        Dim fileReader As New StreamReader(New FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read))

        Dim tickets As New List(Of TicketInfo)

        Dim i As Integer = 0

        Do While fileReader.Peek <> -1

            Dim line As String = fileReader.ReadLine
            Dim field() As String = line.Split(CChar("|"))
            Dim ticket As New TicketInfo
            seatButtons(i).FirstName = field(0)
            seatButtons(i).Surname = field(1)
                seatButtons(i).DateOfBirth = CDate(field(2))
            seatButtons(i).Type = field(3)
            seatButtons(i).Status = Convert.ToBoolean(field(4))
            i += 1
        Loop

        fileReader.Close()

    End Function

    Public Shared Sub SaveTicketDetails()

        If Not Directory.Exists(Dir) Then
            Directory.CreateDirectory(Dir)
        End If

        Dim fileWriter As New StreamWriter(New FileStream(Path, FileMode.Create, FileAccess.Write))

        For Each ticket As TicketInfo In seatButtons
            fileWriter.Write(ticket.FirstName & "|")
            fileWriter.Write(ticket.Surname & "|")
            fileWriter.Write(ticket.DateOfBirth & "|")
            fileWriter.Write(ticket.Type & "|")
            fileWriter.WriteLine(ticket.Status)
        Next
        fileWriter.Close()

    End Sub

    Public Shared Sub DeleteTicketDate()
        If File.Exists(Path) Then
            File.Delete(Path)
        End If
    End Sub
End Class
