using CalgaryHacks.Apis;
using CalgaryHacks.DatabaseModel;
using CalgaryHacks.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CalgaryHacks.Controllers
{
    public class HomeController : Controller
    {
        DataModel db = new DataModel();

        public ActionResult Index()
        {
            ViewModels.EventViewModel eventViewModel = new ViewModels.EventViewModel();
            eventViewModel.Events = EventCache.GetEventBag();
            return View(eventViewModel);
        }
        public ActionResult About()
        {
            return View();
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
                return RedirectToAction("ChooseChat", "Home");
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
                    if (user.Events.Count != 0)
                    {
                        return RedirectToAction("ChooseChat", "Home");
                    }
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Message = "Incorrect Email/Password";
            }
            return View();
        }

        public ActionResult Chat(int roomId)
        {

            User user = (User)HttpContext.Session["user"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.roomId = roomId;
            Event currentEvent = EventCache.GetEventBag().FirstOrDefault(x => x.Id == roomId);
            ViewModels.ChatModel chatModel = new ViewModels.ChatModel();
            chatModel.User = user;
            chatModel.CurrentEvent = currentEvent;
            return View(chatModel);
        }

        public ActionResult ChooseChat()
        {
            User user = (User)HttpContext.Session["user"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewModels.ChooseChatModel chooseChatModel = new ViewModels.ChooseChatModel();
            User userModel = db.Users.Find(user.Id);

            if (userModel?.Events == null || userModel.Events.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            chooseChatModel.EventChats = userModel.Events;
            return View(chooseChatModel);
        }

        [HttpPost]
        public ActionResult ChooseChat(int roomId)
        {
            User user = (User)HttpContext.Session["user"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            HttpContext.Session["user"] = user;

            User dbUser = db.Users.Find(user.Id);
            Event eventObject = db.Events.Find(roomId);
            if (dbUser != null && eventObject != null)
            {
                dbUser.Events.Add(eventObject);
                db.Entry(dbUser).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Chat", "Home", new {roomId});
        }

        public ActionResult Analytics()
        {
            var pointsOfInterests = PointsOfInterestCache.GetPointsOfInterestBag().ToList();

            return View(pointsOfInterests);
        }

        public ActionResult Quadrants(string quadrant)
        {
            ViewModels.QuadrantModel quadrantModel = new ViewModels.QuadrantModel();

            quadrantModel.Events = EventCache.GetEventBag().Where(x => x.Quadrant == quadrant).ToList();
            quadrantModel.PointsOfInterests = PointsOfInterestCache.GetPointsOfInterestBag().Where(x => x.Location == quadrant).ToList();
            
            switch (quadrant)
            {
                case "NW":
                    quadrantModel.Lat = "51.0750527";
                    quadrantModel.Lng = "-114.1194289";
                    quadrantModel.Quadrant = "NW";
                    quadrantModel.Population = 330000L;
                    ;
                    break;
                case "NE":

                    quadrantModel.Lat = "51.0865101";
                    quadrantModel.Lng = "-113.967823";
                    quadrantModel.Quadrant = "NE";
                    quadrantModel.Population = 265000L;
                    break;
                case "SW":
                    quadrantModel.Lat = "51.0213185";
                    quadrantModel.Lng = "-114.1023589";
                    quadrantModel.Quadrant = "SW";
                    quadrantModel.Population = 280000L;

                    break;
                case "SE":
                    quadrantModel.Lat = "51.011528";
                    quadrantModel.Lng = "-113.9891212";
                    quadrantModel.Quadrant = "SE";
                    quadrantModel.Population = 355000L;
                    break;
                default:
                    break;

            }
            return View(quadrantModel);
        }
    }
}