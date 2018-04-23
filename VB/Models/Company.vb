Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Collections
Imports System.ComponentModel.DataAnnotations

Namespace DevExpress.Razor.Models
	Public Class Company
		Public Shared ReadOnly Property OfficeRooms() As IList(Of Room)
			Get
				If HttpContext.Current.Session("OfficeRooms") Is Nothing Then
					HttpContext.Current.Session("OfficeRooms") = GenerateOfficeRooms()
				End If
				Return CType(HttpContext.Current.Session("OfficeRooms"), IList(Of Room))
			End Get
		End Property
		Public Shared ReadOnly Property Persons() As IList(Of Person)
			Get
				If HttpContext.Current.Session("Persons") Is Nothing Then
					HttpContext.Current.Session("Persons") = GeneratePersons()
				End If
				Return CType(HttpContext.Current.Session("Persons"), IList(Of Person))
			End Get
		End Property
		Public Shared Function GetPersonsByRoom(ByVal roomID As Integer) As IEnumerable
			Return From person In Persons _
			       Where person.RoomID = roomID _
			       Select person
		End Function
        Public Shared Function GetPersonByID(ByVal id As Integer) As Person
            Return (From person In Persons
                    Where person.ID = id
                    Select person).SingleOrDefault()
        End Function
        Public Shared Function GetRoomByID(ByVal id As Integer) As Room
            Return (From room In OfficeRooms _
                    Where room.ID = id _
                    Select room).SingleOrDefault()
        End Function
		Public Shared Function GenerateRoomID() As Integer
			Return If(OfficeRooms.Count > 0, OfficeRooms.Last().ID + 1, 0)
		End Function
		Public Shared Function GeneratePersonID() As Integer
			Return If(Persons.Count > 0, Persons.Last().ID + 1, 0)
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
			If editablePerson IsNot Nothing Then
				Persons.Remove(editablePerson)
			End If
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
			If editableRoom IsNot Nothing Then
				OfficeRooms.Remove(editableRoom)
			End If
		End Sub

		Private Shared Function GeneratePersons() As IList(Of Person)
			Return New List(Of Person)(New Person() {New Person() With {.ID = 0, .RoomID = 0, .FirstName = "Nick", .SecondName = "F"}, New Person() With {.ID = 1, .RoomID = 0, .FirstName = "Jain", .SecondName = "K"}, New Person() With {.ID = 2, .RoomID = 1, .FirstName = "Loren", .SecondName = "F"}, New Person() With {.ID = 3, .RoomID = 2, .FirstName = "Mike", .SecondName = "N"}})
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
		Private privateID As Integer
		Public Property ID() As Integer
			Get
				Return privateID
			End Get
			Set(ByVal value As Integer)
				privateID = value
			End Set
		End Property
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
		Private privateFloor As Integer
		Public Property Floor() As Integer
			Get
				Return privateFloor
			End Get
			Set(ByVal value As Integer)
				privateFloor = value
			End Set
		End Property
		Private privateDescription As String
		Public Property Description() As String
			Get
				Return privateDescription
			End Get
			Set(ByVal value As String)
				privateDescription = value
			End Set
		End Property
	End Class
	Public Class Person
		Private privateID As Integer
		Public Property ID() As Integer
			Get
				Return privateID
			End Get
			Set(ByVal value As Integer)
				privateID = value
			End Set
		End Property
		Private privateRoomID As Integer
		Public Property RoomID() As Integer
			Get
				Return privateRoomID
			End Get
			Set(ByVal value As Integer)
				privateRoomID = value
			End Set
		End Property

		Private privateFirstName As String
		<Required(ErrorMessage := "First Name is required")> _
		Public Property FirstName() As String
			Get
				Return privateFirstName
			End Get
			Set(ByVal value As String)
				privateFirstName = value
			End Set
		End Property
		Private privateSecondName As String
		Public Property SecondName() As String
			Get
				Return privateSecondName
			End Get
			Set(ByVal value As String)
				privateSecondName = value
			End Set
		End Property
		Private privateDescription As String
		Public Property Description() As String
			Get
				Return privateDescription
			End Get
			Set(ByVal value As String)
				privateDescription = value
			End Set
		End Property
	End Class
End Namespace