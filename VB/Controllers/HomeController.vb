Imports Microsoft.VisualBasic
Imports System.Web.Mvc
Imports DevExpress.Razor.Models
Imports DevExpress.Web.Mvc

Namespace DevExpress.Razor.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult
			Return View(Company.OfficeRooms)
		End Function
		Public Function GridViewMasterPartial() As ActionResult
			Return PartialView("GridViewMasterPartial", Company.OfficeRooms)
		End Function
		Public Function GridViewMasterAddNewPartial(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal room As Room) As ActionResult
			If ModelState.IsValid Then
				Company.InsertRoom(room)
			End If
			Return PartialView("GridViewMasterPartial", Company.OfficeRooms)
		End Function
		Public Function GridViewMasterUpdatePartial(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal room As Room) As ActionResult
			If ModelState.IsValid Then
				Company.UpdateRoom(room)
			End If
			Return PartialView("GridViewMasterPartial", Company.OfficeRooms)
		End Function
		Public Function GridViewMasterDeletePartial(ByVal ID As Integer) As ActionResult
			Company.RemoveRoomByID(ID)
			Return PartialView("GridViewMasterPartial", Company.OfficeRooms)
		End Function

		Public Function GridViewDetailPartial(ByVal roomID As Integer) As ActionResult
			ViewData("RoomID") = roomID
			Return PartialView("GridViewDetailPartial", Company.GetPersonsByRoom(roomID))
		End Function
		Public Function GridViewDetailAddNewPartial(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal person As Person, ByVal roomID As Integer) As ActionResult
			ViewData("RoomID") = roomID
			person.RoomID = roomID
			If ModelState.IsValid Then
				Company.InsertPerson(person)
			End If
			Return PartialView("GridViewDetailPartial", Company.GetPersonsByRoom(roomID))
		End Function
		Public Function GridViewDetailUpdatePartial(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal person As Person, ByVal roomID As Integer) As ActionResult
			ViewData("RoomID") = roomID
			If ModelState.IsValid Then
				Company.UpdatePerson(person)
			End If
			Return PartialView("GridViewDetailPartial", Company.GetPersonsByRoom(roomID))
		End Function
		Public Function GridViewDetailDeletePartial(ByVal ID As Integer, ByVal roomID As Integer) As ActionResult
			ViewData("RoomID") = roomID
			Company.RemovePersonByID(ID)
			Return PartialView("GridViewDetailPartial", Company.GetPersonsByRoom(roomID))
		End Function
	End Class
End Namespace