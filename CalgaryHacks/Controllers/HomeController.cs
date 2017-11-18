
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CalgaryHacks.Apis;
using CalgaryHacks.DatabaseModel;
using CalgaryHacks.Models;

namespace CalgaryHacks.Controllers
{
    public class HomeController : Controller
    {
        DataModel db = new DataModel();

        public ActionResult Index()
        {
            //            var events = EventsApi.GetEventfulEvents();
            //            var trumba = EventsApi.GetTrumbaEvents();
            //            var ticketMaster = EventsApi.GetTicketMasterEvents();

//                        EventsApi.UpdateEvents();
            ViewModels.EventViewModel eventViewModel = new ViewModels.EventViewModel();
            eventViewModel.Events = EventCache.GetEventBag().ToList();
            return View(eventViewModel);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(ViewModels.RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(a => a.Email == register.Email);
                if (user != null)
                {
                    ViewBag.Message = "Email already exists!";
                    return View();
                }

                user = new User
                {
                    Name = register.Name,
                    Phone = register.Phone,
                    Password = register.Password,
                    Email = register.Email
                };

                if (register.Latitude != null && register.Longitude != null)
                {
                    user.Location = new Location
                    {
                        Latitude = register.Latitude,
                        Longitude = register.Longitude
                    };
                }

                db.Users.Add(user);
                db.SaveChanges();

                user = db.Users.FirstOrDefault(a => a.Email == register.Email && a.Password == register.Password);
                HttpContext.Session["user"] = user;
                EmailSender.SendEmail(register.Email,
                    "Welcome to Calgary chat",
                    $"Hi {register.Name},\n" +
                    "Welcome to Calgary chat,\n " +
                    "We hope you have a good time with all the different events, feel free to hop into any of the chatrooms to begin the conversion with your peers.\n\n" +
                    "Regards,\n" + "Calgary Events Team");
                return RedirectToAction("Chat", "Home");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session["user"] = null;
            return RedirectToAction("Index", "Home");
            ;
        }

        [HttpPost]
        public ActionResult Login(ViewModels.LoginModel login)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(a => a.Email == login.Email && a.Password == login.Password);
                if (user != null)
                {
                    HttpContext.Session["user"] = user;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Message = "Incorrect Email/Password";
            }
            return View();
        }

        public ActionResult Chat()
        {
            User user = (User)HttpContext.Session["user"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (user.CurrentRoomId == null)
            {
                return RedirectToAction("ChooseChat", "Home");
            }
            return View(user);
        }

        public ActionResult ChooseChat()
        {
            User user = (User)HttpContext.Session["user"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewModels.ChooseChatModel chooseChatModel = new ViewModels.ChooseChatModel();
            chooseChatModel.EventChats = EventCache.GetEventBag().ToList();

            return View(chooseChatModel);
        }

        [HttpPost]
        public ActionResult ChooseChat(String roomId)
        {
            User user = (User)HttpContext.Session["user"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            user.CurrentRoomId = roomId;
            HttpContext.Session["user"] = user;

            User dbUser = db.Users.Find(user.Id);
            Event eventObject = db.Events.Find(Int32.Parse(roomId));
            if (dbUser != null && eventObject != null)
            {
                dbUser.Events.Add(eventObject);
                db.Entry(dbUser).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Chat", "Home");
        }

        public ActionResult Analytics()
        {
           // PointsOfInterestsMapper.UpdateCommunityCenterLocations(PointsOfInterestsApi.GetCommunities());
            //PointsOfInterestsMapper.UpdateFireStationLocations(PointsOfInterestsApi.GetFireStationLocations());
           // PointsOfInterestsMapper.UpdatePublicLibraryLocations(PointsOfInterestsApi.GetPublicLibraryLocations());
            PointsOfInterestsMapper.UpdateRecreationalLocations(PointsOfInterestsApi.GetRecreationalFacilities());

            return View();
        }
    }
}