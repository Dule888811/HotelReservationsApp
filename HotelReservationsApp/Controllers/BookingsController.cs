using HotelReservationsApp.Models;
using HotelReservationsApp.Repository;
using HotelReservationsApp.Repository.IRepository;
using Microsoft.Ajax.Utilities;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HotelReservationsApp.Controllers
{
    public class BookingsController : Controller
    {
        private Models.HotelReservationsApp db = new Models.HotelReservationsApp();
        private readonly IBookingsRepository _documentsRepository;

        public BookingsController(IBookingsRepository documentsRepository)
        {
            this._documentsRepository = documentsRepository;

        }

        // GET: Bookings
        public ActionResult Index(string id )
        {
            var bookings = this._documentsRepository.Get(id);
            return View(bookings);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTestSizeOne([Bind(Include = "Result,StartDate,EndDate,Room_id")] Booking Booking)
        {
            var room = db.Rooms.ToArray().First();


            if (Booking.StartDate < 0 || Booking.EndDate > 365)
            {
                Booking.Result = " Decline";
                Booking.StartDate = Booking.StartDate;
                Booking.EndDate = Booking.EndDate;
                this._documentsRepository.AddBooking(Booking);
                return Content("Your book in decided,out of range");
            }

          else  if (Booking.StartDate > Booking.EndDate)
            {
                Booking.Result = " Decline";
                Booking.StartDate = Booking.StartDate;
                Booking.EndDate = Booking.EndDate;
                this._documentsRepository.AddBooking(Booking);
                return Content("Your book in decided,out of range");
            } else
            {
                Booking.Result = " Accept";
                Booking.StartDate = Booking.StartDate;
                Booking.EndDate = Booking.EndDate;
                Booking.Room_id = room.id;
                this._documentsRepository.AddBooking(Booking);
            }


            return View();


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTestSizeThree([Bind(Include = "Result,StartDate,EndDate,Room_id")] Booking Booking)
        {
            var rooms = db.Rooms.ToList().Take(3);
            if (Booking.StartDate > Booking.EndDate)
            {
                Booking.Result = " Decline";
                Booking.StartDate = Booking.StartDate;
                Booking.EndDate = Booking.EndDate;
                this._documentsRepository.AddBooking(Booking);
                return Content("Your book in decided,out of range");
            }

            else if (Booking.StartDate < 0 || Booking.EndDate > 365)
            {
                Booking.Result = " Decline";
                Booking.StartDate = Booking.StartDate;
                Booking.EndDate = Booking.EndDate;
                this._documentsRepository.AddBooking(Booking);
                return Content("Your book in decided,out of range");
            }
            else
            {
                var result = false;
                foreach (var room in rooms)
                {

                    if (result)
                    {
                        break;
                    }
                    else
                    {
                        if (room.Booking.Count == 0)
                        {
                            Booking.Result = " Accept";
                            Booking.StartDate = Booking.StartDate;
                            Booking.EndDate = Booking.EndDate;
                            Booking.Room_id = room.id;
                            this._documentsRepository.AddBooking(Booking);
                            break;
                        }
                        else
                        {
                            foreach (var boking in room.Booking)
                            {
                                var startDay = Booking.StartDate - 1;
                                var endDay = Booking.EndDate - 1;
                                var BookinkArray = room.Booking.ToArray();
                                List<Booking> BadBokkingList = new List<Booking>();
                                List<Booking> BokkingList = new List<Booking>();
                                for (int i = 0; i < BookinkArray.Length; i++)
                                {
                                    if (!Enumerable.Range(Booking.StartDate, Booking.EndDate).Contains(BookinkArray[i].StartDate) && !Enumerable.Range(Booking.StartDate, Booking.EndDate).Contains(BookinkArray[i].EndDate) && BookinkArray[i].StartDate != Booking.EndDate)
                                    {

                                        BokkingList.Add(BookinkArray[i]);



                                    }
                                    else if (Booking.EndDate < BookinkArray[i].StartDate)
                                    {
                                        BokkingList.Add(BookinkArray[i]);
                                    }
                                    else
                                    {
                                        BadBokkingList.Add(BookinkArray[i]);
                                        continue;
                                    }
                                }
                                if (BadBokkingList.Any())
                                {
                                    break;
                                }
                                else
                                {
                                    Booking.Result = " Accept";
                                    Booking.StartDate = Booking.StartDate;
                                    Booking.EndDate = Booking.EndDate;
                                    Booking.Room_id = room.id;
                                    this._documentsRepository.AddBooking(Booking);
                                    result = true;
                                    break;
                                }



                            }
                        }


                    }


                }
                if (Booking.Room_id != null)
                {
                    return Content("Your booking in Accept");
                }
                else
                {
                    Booking.Result = " Decided";
                    Booking.StartDate = Booking.StartDate;
                    Booking.EndDate = Booking.EndDate;
                    Booking.Room_id = null;
                    this._documentsRepository.AddBooking(Booking);
                    return Content("Your booking in decided,no rooms avalible");
                }

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HotelReservations([Bind(Include = "Result,StartDate,EndDate,Room_id")] Booking Booking)
        {
            var rooms = db.Rooms.ToList();
            if (Booking.StartDate > Booking.EndDate)
            {
                Booking.Result = " Decline";
                Booking.StartDate = Booking.StartDate;
                Booking.EndDate = Booking.EndDate;
                this._documentsRepository.AddBooking(Booking);
                return Content("Your book in decided,out of range");
            }

           else if (Booking.StartDate < 0 || Booking.EndDate > 365)
            {
                Booking.Result = " Decline";
                Booking.StartDate = Booking.StartDate;
                Booking.EndDate = Booking.EndDate;
                this._documentsRepository.AddBooking(Booking);
                return Content("Your book in decided,out of range");
            }
            else
            {
                var result = false;
                foreach (var room in rooms)
                {

                    if (result)
                    {
                        break;
                    }
                    else
                    {
                        if (room.Booking.Count == 0)
                        {
                            Booking.Result = " Accept";
                            Booking.StartDate = Booking.StartDate;
                            Booking.EndDate = Booking.EndDate;
                            Booking.Room_id = room.id;
                            this._documentsRepository.AddBooking(Booking);
                            break;
                        }
                        else
                        {
                            foreach (var boking in room.Booking)
                            {
                                var startDay = Booking.StartDate - 1;
                                var endDay = Booking.EndDate - 1;
                                var BookinkArray = room.Booking.ToArray();
                                List<Booking> BadBokkingList = new List<Booking>();
                                List<Booking> BokkingList = new List<Booking>();
                                for (int i = 0; i < BookinkArray.Length; i++)
                                {
                                    if (!Enumerable.Range(Booking.StartDate, Booking.EndDate).Contains(BookinkArray[i].StartDate) && !Enumerable.Range(Booking.StartDate, Booking.EndDate).Contains(BookinkArray[i].EndDate) && BookinkArray[i].StartDate != Booking.EndDate)
                                    {

                                        BokkingList.Add(BookinkArray[i]);



                                    }
                                    else if (Booking.EndDate < BookinkArray[i].StartDate)
                                    {
                                        BokkingList.Add(BookinkArray[i]);
                                    }
                                    else
                                    {
                                        BadBokkingList.Add(BookinkArray[i]);
                                        continue;
                                    }
                                }
                                if (BadBokkingList.Any())
                                {
                                    break;
                                }
                                else
                                {
                                    Booking.Result = " Accept";
                                    Booking.StartDate = Booking.StartDate;
                                    Booking.EndDate = Booking.EndDate;
                                    Booking.Room_id = room.id;
                                    this._documentsRepository.AddBooking(Booking);
                                    result = true;
                                    break;
                                }



                            }
                        }


                    }


                }
                if (Booking.Room_id != null)
                {
                    return Content("Your booking in Accept");
                }
                else
                {
                    Booking.Result = " Decided";
                    Booking.StartDate = Booking.StartDate;
                    Booking.EndDate = Booking.EndDate;
                    Booking.Room_id = null;
                    this._documentsRepository.AddBooking(Booking);
                    return Content("Your booking in decided,no rooms avalible");
                }

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTestSizeTwo([Bind(Include = "Result,StartDate,EndDate,Room_id")] Booking Booking)
        {
            var rooms = db.Rooms.ToList().Skip(6).Take(2);
            if (Booking.StartDate > Booking.EndDate)
            {
                Booking.Result = " Decline";
                Booking.StartDate = Booking.StartDate;
                Booking.EndDate = Booking.EndDate;
                this._documentsRepository.AddBooking(Booking);
                return Content("Your book in decided,out of range");
            }

          else  if (Booking.StartDate < 0 || Booking.EndDate > 365)
            {
                Booking.Result = " Decline";
                Booking.StartDate = Booking.StartDate;
                Booking.EndDate = Booking.EndDate;
                this._documentsRepository.AddBooking(Booking);
                return Content("Your book in decided,out of range");
            }
            else
            {
                var result = false;
                foreach (var room in rooms)
                {

                    if (result)
                    {
                        break;
                    }
                    else
                    {
                        if (room.Booking.Count == 0)
                        {
                            Booking.Result = " Accept";
                            Booking.StartDate = Booking.StartDate;
                            Booking.EndDate = Booking.EndDate;
                            Booking.Room_id = room.id;
                            this._documentsRepository.AddBooking(Booking);
                            break;
                        }
                        else
                        {
                            foreach (var boking in room.Booking)
                            {
                                var startDay = Booking.StartDate - 1;
                                var endDay = Booking.EndDate - 1;
                                var BookinkArray = room.Booking.ToArray();
                                List<Booking> BadBokkingList = new List<Booking>();
                                List<Booking> BokkingList = new List<Booking>();
                                for (int i = 0; i < BookinkArray.Length; i++)
                                {
                                    if (!Enumerable.Range(Booking.StartDate, Booking.EndDate).Contains(BookinkArray[i].StartDate) && !Enumerable.Range(Booking.StartDate, Booking.EndDate).Contains(BookinkArray[i].EndDate - 1))
                                    {

                                        BokkingList.Add(BookinkArray[i]);



                                    }
                                    else if(Booking.EndDate < BookinkArray[i].StartDate)
                                    {
                                        BokkingList.Add(BookinkArray[i]);
                                    }
                                    else
                                    {
                                        BadBokkingList.Add(BookinkArray[i]);
                                        continue;
                                    }
                                }
                                if (BadBokkingList.Any())
                                {
                                    break;
                                }
                                else
                                {
                                    Booking.Result = " Accept";
                                    Booking.StartDate = Booking.StartDate;
                                    Booking.EndDate = Booking.EndDate;
                                    Booking.Room_id = room.id;
                                    this._documentsRepository.AddBooking(Booking);
                                    result = true;
                                    break;
                                }



                            }
                        }


                    }


                }
                if (Booking.Room_id != null)
                {
                    return Content("Your booking in Accept");
                }
                else
                {
                    Booking.Result = " Decided";
                    Booking.StartDate = Booking.StartDate;
                    Booking.EndDate = Booking.EndDate;
                    Booking.Room_id = null;
                    this._documentsRepository.AddBooking(Booking);
                    return Content("Your booking in decided,no rooms avalible");
                }

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTestSizeThreeDecline([Bind(Include = "Result,StartDate,EndDate,Room_id")] Booking Booking)
        {
            var rooms = db.Rooms.ToList().Skip(3).Take(3);
            if (Booking.StartDate > Booking.EndDate)
            {
                Booking.Result = " Decline";
                Booking.StartDate = Booking.StartDate;
                Booking.EndDate = Booking.EndDate;
                this._documentsRepository.AddBooking(Booking);
                return Content("Your book in decided,out of range");
            }

           else if (Booking.StartDate < 0 || Booking.EndDate > 365)
            {
                Booking.Result = " Decline";
                Booking.StartDate = Booking.StartDate;
                Booking.EndDate = Booking.EndDate;
                this._documentsRepository.AddBooking(Booking);
                return Content("Your book in decided,out of range");
            }
            else
            {
                var result = false;
                foreach (var room in rooms)
                {

                    if (result)
                    {
                        break;
                    }
                    else
                    {
                        if (room.Booking.Count == 0)
                        {
                            Booking.Result = " Accept";
                            Booking.StartDate = Booking.StartDate;
                            Booking.EndDate = Booking.EndDate;
                            Booking.Room_id = room.id;
                            this._documentsRepository.AddBooking(Booking);
                            break;
                        }
                        else
                        {
                            foreach (var boking in room.Booking)
                            {
                                var startDay = Booking.StartDate - 1;
                                var endDay = Booking.EndDate - 1;
                                var BookinkArray = room.Booking.ToArray();
                                List<Booking> BadBokkingList = new List<Booking>();
                                List<Booking> BokkingList = new List<Booking>();
                                for (int i = 0; i < BookinkArray.Length; i++)
                                {
                                    if (!Enumerable.Range(Booking.StartDate, Booking.EndDate).Contains(BookinkArray[i].StartDate) && !Enumerable.Range(Booking.StartDate, Booking.EndDate).Contains(BookinkArray[i].EndDate) && BookinkArray[i].StartDate != Booking.EndDate)
                                    {

                                        BokkingList.Add(BookinkArray[i]);



                                    }
                                    else if (Booking.EndDate < BookinkArray[i].StartDate)
                                    {
                                        BokkingList.Add(BookinkArray[i]);
                                    }
                                    else
                                    {
                                        BadBokkingList.Add(BookinkArray[i]);
                                        continue;
                                    }
                                }
                                if (BadBokkingList.Any())
                                {
                                    break;
                                }
                                else
                                {
                                    Booking.Result = " Accept";
                                    Booking.StartDate = Booking.StartDate;
                                    Booking.EndDate = Booking.EndDate;
                                    Booking.Room_id = room.id;
                                    this._documentsRepository.AddBooking(Booking);
                                    result = true;
                                    break;
                                }



                            }
                        }


                    }


                }
                if (Booking.Room_id != null)
                {
                    return Content("Your booking in Accept");
                }
                else
                {
                    Booking.Result = " Decided";
                    Booking.StartDate = Booking.StartDate;
                    Booking.EndDate = Booking.EndDate;
                    Booking.Room_id = null;
                    this._documentsRepository.AddBooking(Booking);
                    return Content("Your booking in decided,no rooms avalible");
                }
            }
        }
    }

}

