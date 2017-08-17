using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingProject.Models
{
    public class PersonModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime Now { get; }
    }

    public class Student : PersonModel
    {
        public List<string> Textbooks = new List<string>();

        public Student() { }
    }

    public class Teacher : PersonModel
    {
        public List<string> TeachingMaterials = new List<string>();

        public Teacher() { }
    }

    public class ColorChoice
    {

        public string fav { get; set; }


    }
    public class CoinModel
    {
        public string OriginCountry { get; set; }
        public int YearMinted { get; set; }
        public string CoinMaterial { get; set; }
        public string CoinValue { get; set; }
    }
    public class UserModel
    {
        public string UserName
        {
            get; set;
        }
    }
    public class GameModel
    {
        public string GameName {get; set;}
        public int GamePrice { get; set; }
        
    }
}