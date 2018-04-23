using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace DevExpress.Razor.Models {
    public class Company {
        public static IList<Room> OfficeRooms {
            get {
                if (HttpContext.Current.Session["OfficeRooms"] == null)
                    HttpContext.Current.Session["OfficeRooms"] = GenerateOfficeRooms();
                return (IList<Room>)HttpContext.Current.Session["OfficeRooms"];
            }
        }
        public static IList<Person> Persons {
            get {
                if (HttpContext.Current.Session["Persons"] == null)
                    HttpContext.Current.Session["Persons"] = GeneratePersons();
                return (IList<Person>)HttpContext.Current.Session["Persons"];
            }
        }
        public static IEnumerable GetPersonsByRoom(int roomID) {
            return from person in Persons where person.RoomID == roomID select person;
        }
        public static Person GetPersonByID(int id) {
            return (from person in Persons where person.ID == id select person).SingleOrDefault<Person>();
        }
        public static Room GetRoomByID(int id) {
            return (from room in OfficeRooms where room.ID == id select room).SingleOrDefault<Room>();
        }
        public static int GenerateRoomID() {
            return OfficeRooms.Count > 0 ? OfficeRooms.Last().ID + 1 : 0;
        }
        public static int GeneratePersonID() {
            return Persons.Count > 0 ? Persons.Last().ID + 1 : 0;
        }

        public static void InsertPerson(Person person){
            if (person != null) {
                person.ID = GeneratePersonID();
                Persons.Add(person);
            }
        }
        public static void UpdatePerson(Person person) {
            Person editablePerson = GetPersonByID(person.ID);
            if (editablePerson != null) {
                editablePerson.ID = person.ID;
                editablePerson.RoomID = person.RoomID;
                editablePerson.FirstName = person.FirstName;
                editablePerson.SecondName = person.SecondName;
                editablePerson.Description = person.Description;
            }
        }
        public static void RemovePersonByID(int id) {
            Person editablePerson = GetPersonByID(id);
            if (editablePerson != null)
                Persons.Remove(editablePerson);
        }

        public static void InsertRoom(Room room) {
            if (room != null) {
                room.ID = GenerateRoomID();
                OfficeRooms.Add(room);
            }
        }
        public static void UpdateRoom(Room room) {
            Room editableRoom = GetRoomByID(room.ID);
            if (editableRoom != null) {
                editableRoom.ID = room.ID;
                editableRoom.Number = room.Number;
                editableRoom.Floor = room.Floor;
                editableRoom.Description = room.Description;
            }
        }
        public static void RemoveRoomByID(int id) {
            Room editableRoom = GetRoomByID(id);
            if (editableRoom != null)
                OfficeRooms.Remove(editableRoom);
        }

        static IList<Person> GeneratePersons() {
            return new List<Person>{
                        new Person(){
                            ID = 0,
                            RoomID = 0,
                            FirstName = "Nick",
                            SecondName = "F"
                        },
                        new Person(){
                            ID = 1,
                            RoomID = 0,
                            FirstName = "Jain",
                            SecondName = "K"
                        },
                        new Person(){
                            ID = 2,
                            RoomID = 1,
                            FirstName = "Loren",
                            SecondName = "F"
                        },
                        new Person(){
                            ID = 3,
                            RoomID = 2,
                            FirstName = "Mike",
                            SecondName = "N"
                        }
                    };
        }
        static IList<Room> GenerateOfficeRooms() {
            List<Room> rooms = new List<Room>();
            rooms.Add(
                new Room() {
                    ID = 0,
                    Number = 101,
                    Floor = 5
                }
            );
            rooms.Add(
                new Room() {
                    ID = 1,
                    Number = 206,
                    Floor = 2
                }
            );
            rooms.Add(
                new Room() {
                    ID = 2,
                    Number = 159,
                    Floor = 5
                }
            );
            return rooms;
        }
    }
    public class Room {
        public int ID { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public string Description { get; set; }
    }
    public class Person {
        public int ID { get; set; }
        public int RoomID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Description { get; set; }
    }
}