using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingProject.Models;

using System.Web.Script.Serialization;

namespace TrainingProject.Controllers
{
    public class TrainingController : Controller
    {
        // GET: Training
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Unit1()
        {
            PersonModel myPerson = new PersonModel();

            myPerson.FirstName = "Andrew";
            myPerson.LastName = "Potenza";
            myPerson.PhoneNumber = "561-676-4489";
            myPerson.Email = "andrewpotenza02@gmail.com";
            return View(myPerson);

        }

        public ActionResult Register(FormCollection form)
        {
            PersonModel myPerson = new PersonModel();

            myPerson.FirstName = form["firstName"].ToUpper();
            myPerson.LastName = form["lastName"].ToUpper();
            myPerson.PhoneNumber = form["phoneNumber"];
            myPerson.Email = form["email"];
            // Get birthdate
            string birthdate = form["birthDate"];
            DateTime dateBirth = DateTime.Parse(birthdate);
            // Calculate the age
            DateTime today = DateTime.Now;
            int age = today.Year - dateBirth.Year;
            if (dateBirth > today.AddYears(-age)) age--;
            ViewBag.Age = age;

            // Save person into database
            TrainingEntities db = new TrainingEntities();

            // First check to see if person exists
            var person = db.People.Where(x => x.FirstName == myPerson.FirstName && x.LastName == myPerson.LastName).FirstOrDefault();
            if (person == null)
            {
                // person doesn't exist
                db.People.Add(new Models.Person()
                {
                    FirstName = myPerson.FirstName,
                    LastName = myPerson.LastName,
                    PhoneNumber = myPerson.PhoneNumber,
                    Email = myPerson.Email,
                });
                db.SaveChanges();
            }
            else
            {
                // person exists
            }


            return View("Unit1", myPerson);
        }

        public ActionResult Unit2()
        {
            ColorChoice Choice = new ColorChoice();

            Choice.fav = "rgb(255, 0, 0)";
            return View(Choice);
        }
        public ActionResult FavoriteColor(FormCollection form)
        {
            ColorChoice Choice = new ColorChoice();

            Choice.fav = form["color"];

            return View("Unit2", Choice);
        }
        /*
         * 
         *  Ask user for favorite color
         *  Display input
         *  BONUS: Make the page the favorite color
         *  Either use drop down or free form
         */

        public ActionResult Unit3()
        {
            Student andrew = new Student();
            Teacher eddie = new Teacher();

            andrew.FirstName = "Andrew";
            eddie.FirstName = "Eddie";

            andrew.Textbooks.Add("Math - Algebra");
            andrew.Textbooks.Add("Reading - English 1");
            eddie.TeachingMaterials.Add("Exam Answer Key");
            eddie.TeachingMaterials.Add("Grading Sheet");

            List<PersonModel> classroom = new List<PersonModel>();
            classroom.Add(andrew);
            classroom.Add(eddie);

            ViewBag.Classroom = classroom;

            return View();
        }

        public ActionResult Unit4()
        {
            CoinModel newCoin = new CoinModel();

            newCoin.OriginCountry = "UNITED STATES OF AMERICA";
            newCoin.YearMinted = 1943;
            newCoin.CoinMaterial = "SILVER";
            newCoin.CoinValue = "$0.01";

            return View(newCoin);
        }
        public ActionResult coinForm(FormCollection form)
        {
            CoinModel newCoin = new CoinModel();

            newCoin.OriginCountry = form["originCountry"].ToUpper();
            newCoin.YearMinted = Int32.Parse(form["yearMinted"]);
            newCoin.CoinMaterial = form["coinMaterial"].ToUpper();
            newCoin.CoinValue = form["coinValue"];

            TrainingEntities db = new TrainingEntities();

            // First check to see if person exists
            var coin = db.Coins.Where(x => x.OriginCountry == newCoin.OriginCountry && x.YearMinted == newCoin.YearMinted && x.CoinMaterial == newCoin.CoinMaterial && x.CoinValue == newCoin
            .CoinValue).FirstOrDefault();
            if (coin == null)
            {
                // person doesn't exist
                db.Coins.Add(new Coin()
                {
                    OriginCountry = newCoin.OriginCountry,
                    YearMinted = newCoin.YearMinted,
                    CoinMaterial = newCoin.CoinMaterial,
                    CoinValue = newCoin.CoinValue
                });
                db.SaveChanges();
            }
            else
            {
                // person exists
            }

            return View("Unit4", newCoin);
        }

        public ActionResult Unit5()
        {
            TrainingEntities db = new TrainingEntities();
            List<Person> people = db.People.ToList();
            ViewBag.People = people;

            return View();
        }

        public ActionResult Unit6()
        {
            TrainingEntities db = new TrainingEntities();
            List<SpecialCoin> coins = db.SpecialCoins.ToList();
            ViewBag.Coins = coins;

            return View();
        }
        public ActionResult Unit7()
        {
            TrainingEntities db = new TrainingEntities();
            List<Friend> friends = db.Friends.ToList();
            ViewBag.Friends = friends;

            return View();
        }

        public JsonResult GetPerson(int personID)
        {
            TrainingEntities db = new TrainingEntities();

            var person = from p in db.People where p.PersonID == personID select new { Person = p };

            var jsonPerson = new JavaScriptSerializer().Serialize(person);

            return Json(jsonPerson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPersonCoins(int personID)
        {
            TrainingEntities db = new TrainingEntities();

            var coins =
               from c in db.SpecialCoins
               join pc in db.PersonCoins on c.SpecialCoinID equals pc.CoinID
               where pc.PersonID == personID
               select new { Coin = c };

            var jsonCoin = new JavaScriptSerializer().Serialize(coins);

            return Json(jsonCoin, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCoin(int CoinID)
        {
            TrainingEntities db = new TrainingEntities();

            var coin = from c in db.Coins where c.CoinID == CoinID select new { Coin = c };

            var jsonCoin = new JavaScriptSerializer().Serialize(coin);

            return Json(jsonCoin, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCoinsPerson(int CoinID)
        {
            TrainingEntities db = new TrainingEntities();

            var people =
               from c in db.SpecialCoins
               join pc in db.PersonCoins on c.SpecialCoinID equals pc.CoinID
               join p in db.People on pc.PersonID equals p.PersonID
               where c.SpecialCoinID == CoinID
               select new { Person = p };

            var jsonPeople = new JavaScriptSerializer().Serialize(people);

            return Json(jsonPeople, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetFriend(int FriendID)
        {
            TrainingEntities db = new TrainingEntities();

            var friend = from f in db.Friends where f.UserID == FriendID select new { Friend = f };

            var jsonFriend = new JavaScriptSerializer().Serialize(friend);

            return Json(jsonFriend, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFriendGames(int FriendID)
        {
            TrainingEntities db = new TrainingEntities();

            var games =
                from fg in db.FriendGames
                join g in db.Games on fg.GameID equals g.GameID
                where fg.UserID == FriendID
                select new { Game = g };


            var jsonGames = new JavaScriptSerializer().Serialize(games);

            return Json(jsonGames, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Unit8()
        {
            return View();
        }
        public ActionResult Unit9()
        {

            GameModel newGame = new GameModel();

            return View(newGame);
        }
        public ActionResult gameForm(FormCollection form)
        {
            GameModel newGame = new GameModel();

            newGame.GameName = form["gameName"];
            newGame.GamePrice = Int32.Parse(form["gamePrice"]);
            TrainingEntities db = new TrainingEntities();

            // First check to see if person exists
            var game = db.Games.Where(x => x.GameName == newGame.GameName && x.GamePrice == newGame.GamePrice).FirstOrDefault();
            if (game == null)
            {
                // person doesn't exist
                db.Games.Add(new Game()
                {
                    GameName = newGame.GameName,
                    GamePrice = newGame.GamePrice
                });
                db.SaveChanges();
            }
            else
            {
                // person exists
            }
            return View("Unit9", newGame);
        }
        public JsonResult GetGames()
        {
            TrainingEntities db = new TrainingEntities();

            var game = from g in db.Games select new { Game= g };

            var jsonGame = new JavaScriptSerializer().Serialize(game);

            return Json(jsonGame, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Unit10()
        {
            return View();
        }

        public ActionResult Unit11()
        {

          

            return View();
        }
        public ActionResult genderForm(FormCollection form)
        {
            PersonModel newPerson = new PersonModel();
            newPerson.FirstName = form["firstName"].ToUpper();
            newPerson.LastName = form["lastName"].ToUpper();
            newPerson.PhoneNumber = form["phoneNumber"];
            newPerson.Email = form["email"];
            newPerson.Gender = form["gender"].ToUpper();
            TrainingEntities db = new TrainingEntities();

            var person = db.People.Where(x => x.FirstName == newPerson.FirstName && x.LastName == newPerson.LastName && x.Email == newPerson.Email).FirstOrDefault();
            if (person == null)
            {
                // person doesn't exist
                db.People.Add(new Models.Person()
                {
                    FirstName = newPerson.FirstName,
                    LastName = newPerson.LastName,
                    PhoneNumber = newPerson.PhoneNumber,
                    Email = newPerson.Email,
                    Gender = newPerson.Gender,
                });
                db.SaveChanges();
            }
            else
            {
                // person exists
            }
      
            return View("Unit11", newPerson);
        }
        public ActionResult Bootstrap()
        {



            return View();
        }
        public ActionResult genderForm2(FormCollection form)
        {
            PersonModel newPerson = new PersonModel();
            newPerson.FirstName = form["firstName"].ToUpper();
            newPerson.LastName = form["lastName"].ToUpper();
            newPerson.PhoneNumber = form["phoneNumber"];
            newPerson.Email = form["email"];
            newPerson.Gender = form["gender"];
            TrainingEntities db = new TrainingEntities();

            var person = db.People.Where(x => x.FirstName == newPerson.FirstName && x.LastName == newPerson.LastName && x.Email == newPerson.Email && x.Gender == newPerson.Gender).FirstOrDefault();
            if (person == null)
            {
                // person doesn't exist
                db.People.Add(new Models.Person()
                {
                    FirstName = newPerson.FirstName,
                    LastName = newPerson.LastName,
                    PhoneNumber = newPerson.PhoneNumber,
                    Email = newPerson.Email,
                    Gender = newPerson.Gender,
                });
                db.SaveChanges();
            }
            else
            {
                // person exists
            }

            return View("Bootstrap", newPerson);
        }

        public JsonResult UpdatePerson(string FirstName, string LastName, string PhoneNumber, string Email, string Gender)
        {
            TrainingEntities db = new TrainingEntities();
            // save to database
            var person = db.People.Where(x => x.FirstName == FirstName && x.LastName == LastName && x.Email == Email && x.Gender == Gender).FirstOrDefault();
            if (person == null)
            {
                // person doesn't exist
                db.People.Add(new Models.Person()
                {
                    FirstName = FirstName.ToUpper(),
                    LastName = LastName.ToUpper(),
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    Gender = Gender


                });
                db.SaveChanges();
                return Json("success", JsonRequestBehavior.AllowGet);
             
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
      
    }
}