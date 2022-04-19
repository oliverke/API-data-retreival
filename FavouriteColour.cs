using System;
using System.Collections.Generic;
using System.Text;

namespace API_data_retreival
{
    class FavouriteColour
    {
        public string Colour { get; set; }
        public int Frequency { get; set; }
        public FavouriteColour(string colour, int freq)
        {
            this.Colour = colour;
            this.Frequency = freq;
        }
    }
}
