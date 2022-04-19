using System;
using System.Collections.Generic;
using System.Text;

namespace API_data_retreival
{
    class AgePlus20
    {
        public string ID { get; set; }
        public int Age { get; set; }
        public int AgePlusTwenty { get; set; }
        public AgePlus20(string id, DateTime DOB)
        {
            var today = DateTime.Today;
            this.Age = today.Year - DOB.Year;
            if (today.Month < DOB.Month || (today.Month == DOB.Month && today.Day < DOB.Day))
            {
                this.Age--;
            }
            this.AgePlusTwenty = Age + 20;
            this.ID = id;
        }
    }
}
