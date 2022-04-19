using System;
using System.Collections.Generic;
using System.Text;

namespace API_data_retreival
{
    class User
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string FavouriteColour { get; set; }
        public User(string user)
        {
            var listProperties = user.Split(',');
            foreach(var p in listProperties)
            {
                var property = p.Split(':');
                switch (property[0].Trim('"'))
                {
                    case "id":
                        this.ID = property[1].Trim('"');
                        break;
                    case "firstName":
                        this.FirstName = property[1].Trim('"');
                        break;
                    case "lastName":
                        this.LastName = property[1].Trim('"');
                        break;
                    case "email":
                        this.Email = property[1].Trim('"');
                        break;
                    case "dob":
                        var p1 =p.Replace("\"dob\":","");
                        this.DOB = DateTime.Parse(p1.Trim('"').Replace('T',' '));
                        break;
                    case "favouriteColour":
                        this.FavouriteColour = property[1].Trim('"');
                        break;
                }
            }
        }
    }
}
