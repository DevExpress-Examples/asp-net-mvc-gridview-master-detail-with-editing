using System.Web.Mvc;
using DevExpress.Razor.Models;
using DevExpress.Web.Mvc;

namespace DevExpress.Razor.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View(Company.OfficeRooms);
        }
        public ActionResult GridViewMasterPartial() {
            return PartialView("GridViewMasterPartial", Company.OfficeRooms);
        }
        public ActionResult GridViewMasterAddNewPartial([ModelBinder(typeof(DevExpressEditorsBinder))] Room room) {
            if (ModelState.IsValid)
                Company.InsertRoom(room);
            return PartialView("GridViewMasterPartial", Company.OfficeRooms);
        }
        public ActionResult GridViewMasterUpdatePartial([ModelBinder(typeof(DevExpressEditorsBinder))] Room room) {
            if (ModelState.IsValid)
                Company.UpdateRoom(room);
            return PartialView("GridViewMasterPartial", Company.OfficeRooms);
        }
        public ActionResult GridViewMasterDeletePartial(int ID){
            Company.RemoveRoomByID(ID);
            return PartialView("GridViewMasterPartial", Company.OfficeRooms);
        }

        public ActionResult GridViewDetailPartial(int roomID) {
            ViewData["RoomID"] = roomID;
            return PartialView("GridViewDetailPartial", Company.GetPersonsByRoom(roomID));
        }
        public ActionResult GridViewDetailAddNewPartial([ModelBinder(typeof(DevExpressEditorsBinder))] Person person, int roomID) {
            ViewData["RoomID"] = roomID;
            person.RoomID = roomID;
            if(ModelState.IsValid)
                Company.InsertPerson(person);
            return PartialView("GridViewDetailPartial", Company.GetPersonsByRoom(roomID));
        }
        public ActionResult GridViewDetailUpdatePartial([ModelBinder(typeof(DevExpressEditorsBinder))] Person person, int roomID) {
            ViewData["RoomID"] = roomID;
            if(ModelState.IsValid)
                Company.UpdatePerson(person);
            return PartialView("GridViewDetailPartial", Company.GetPersonsByRoom(roomID));
        }
        public ActionResult GridViewDetailDeletePartial(int ID, int roomID){
            ViewData["RoomID"] = roomID;
            Company.RemovePersonByID(ID);
            return PartialView("GridViewDetailPartial", Company.GetPersonsByRoom(roomID));
        }
    }
}