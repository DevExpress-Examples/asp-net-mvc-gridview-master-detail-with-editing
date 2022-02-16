Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Collections
Imports System.ComponentModel.DataAnnotations

Namespace DevExpress.Razor.Models

    Public Class Company

        Public Shared ReadOnly Property OfficeRooms As IList(Of Room)
            Get
                If HttpContext.Current.Session("OfficeRooms") Is Nothing Then HttpContext.Current.Session("OfficeRooms") = GenerateOfficeRooms()
                Return CType(HttpContext.Current.Session("OfficeRooms"), IList(Of Room))
            End Get
        End Property

        Public Shared ReadOnly Property Persons As IList(Of Person)
            Get
                If HttpContext.Current.Session("Persons") Is Nothing Then HttpContext.Current.Session("Persons") = GeneratePersons()
                Return CType(HttpContext.Current.Session("Persons"), IList(Of Person))
            End Get
        End Property

        Public Shared Function GetPersonsByRoom(ByVal roomID As Integer) As IEnumerable
            Return From person In Persons Where person.RoomID = roomID Select person
        End Function

        Public Shared Function GetPersonByID(ByVal id As Integer) As Person
            Return(From person In Persons Where person.ID = id Select person).SingleOrDefault(Of Person)()
        End Function

        Public Shared Function GetRoomByID(ByVal id As Integer) As Room
            Return(From room In OfficeRooms Where room.ID = id Select room).SingleOrDefault(Of Room)()
        End Function

        Public Shared Function GenerateRoomID() As Integer
            Return If(OfficeRooms.Count > 0, Enumerable.Last(OfficeRooms).ID + 1, 0)
        End Function

        Public Shared Function GeneratePersonID() As Integer
            Return If(Persons.Count > 0, Enumerable.Last(Persons).ID + 1, 0)
        End Function

        Public Shared Sub InsertPerson(ByVal person As Person)
            If person IsNot Nothing Then
                person.ID = GeneratePersonID()
                Persons.Add(person)
            End If
        End Sub

        Public Shared Sub UpdatePerson(ByVal person As Person)
            Dim editablePerson As Person = GetPersonByID(person.ID)
            If editablePerson IsNot Nothing Then
                editablePerson.ID = person.ID
                editablePerson.RoomID = person.RoomID
                editablePerson.FirstName = person.FirstName
                editablePerson.SecondName = person.SecondName
                editablePerson.Description = person.Description
            End If
        End Sub

        Public Shared Sub RemovePersonByID(ByVal id As Integer)
            Dim editablePerson As Person = GetPersonByID(id)
            If editablePerson IsNot Nothing Then Persons.Remove(editablePerson)
        End Sub

        Public Shared Sub InsertRoom(ByVal room As Room)
            If room IsNot Nothing Then
                room.ID = GenerateRoomID()
                OfficeRooms.Add(room)
            End If
        End Sub

        Public Shared Sub UpdateRoom(ByVal room As Room)
            Dim editableRoom As Room = GetRoomByID(room.ID)
            If editableRoom IsNot Nothing Then
                editableRoom.ID = room.ID
                editableRoom.Number = room.Number
                editableRoom.Floor = room.Floor
                editableRoom.Description = room.Description
            End If
        End Sub

        Public Shared Sub RemoveRoomByID(ByVal id As Integer)
            Dim editableRoom As Room = GetRoomByID(id)
            If editableRoom IsNot Nothing Then OfficeRooms.Remove(editableRoom)
        End Sub

        Private Shared Function GeneratePersons() As IList(Of Person)
            Return New List(Of Person) From {New Person() With {.ID = 0, .RoomID = 0, .FirstName = "Nick", .SecondName = "F"}, New Person() With {.ID = 1, .RoomID = 0, .FirstName = "Jain", .SecondName = "K"}, New Person() With {.ID = 2, .RoomID = 1, .FirstName = "Loren", .SecondName = "F"}, New Person() With {.ID = 3, .RoomID = 2, .FirstName = "Mike", .SecondName = "N"}}
        End Function

        Private Shared Function GenerateOfficeRooms() As IList(Of Room)
            Dim rooms As List(Of Room) = New List(Of Room)()
            rooms.Add(New Room() With {.ID = 0, .Number = 101, .Floor = 5})
            rooms.Add(New Room() With {.ID = 1, .Number = 206, .Floor = 2})
            rooms.Add(New Room() With {.ID = 2, .Number = 159, .Floor = 5})
            Return rooms
        End Function
    End Class

    Public Class Room

        Public Property ID As Integer

        Public Property Number As Integer

        Public Property Floor As Integer

        Public Property Description As String
    End Class

    Public Class Person

        Public Property ID As Integer

        Public Property RoomID As Integer

        <Required(ErrorMessage:="First Name is required")>
        Public Property FirstName As String

        Public Property SecondName As String

        Public Property Description As String
    End Class
End Namespace
