using System;
using System.Collections.Generic;
using System.Net;

namespace API_data_retreival
{
    class Program
    {
        public List<User> UserObjects { get; set; }
        static void Main(string[] args)
        {
            var dFA = new DataFromAPI();
            dFA.GetData();
            dFA.CalcFavouriteColourFreq();
            dFA.CalcAgePlusTwenty();

        }
        
    }
    class DataFromAPI
    {
        public List<User> UserObjects { get; set; }
        public List<FavouriteColour> FavouriteColours { get; set; }
        public List<string> Colours { get; set; }
        public List<AgePlus20> AgePlus20s { get; set; }
        public void GetData()
        {
            using (WebClient client = new WebClient())
            {
                UserObjects = new List<User> { };
                // Download the data
                var rawData = client.DownloadString("https://recruitment.highfieldqualifications.com/api/test").TrimStart(new char[] {'[', '{'}).TrimEnd(new char[] { ']', '}' });
                var userList = rawData.Split("},{");
                foreach (string user in userList)
                {
                    UserObjects.Add(new User(user));
                }
            }
        }
        public void CalcFavouriteColourFreq()
        {
            Colours = new List<string> { };
            FavouriteColours = new List<FavouriteColour> { };
            foreach (var user in UserObjects)
            {
                Colours.Add(user.FavouriteColour);
            }
            List<string> all=new List<string> { };
            foreach (var colour in Colours)
            {
                var d = all.FindAll(x => x == colour);
                if (all.FindAll(x => x == colour).Count == 0)
                {
                    all.Add(colour);
                    FavouriteColours.Add(new FavouriteColour(colour, all.Count));
                }
            }
        }
        public void CalcAgePlusTwenty()
        {
            AgePlus20s = new List<AgePlus20> { };
            foreach (var u in UserObjects)
            {
                AgePlus20s.Add(new AgePlus20(u.ID, u.DOB));
            }
        }
    }
}
