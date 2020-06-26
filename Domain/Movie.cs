﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Movie
    {
        public string Name { get; set; }
        public List<string> Genres { get; set; }
        public DateTime Date { get; set; }
        public string Director { get; set; }
        public List<string> Files { get; set; }

        public override string ToString()
        {
            string ret = "Movie: " + Name + " Premiere: " + Date.Day +"/"+ Date.Month + "/" +  Date.Year  + " Directed by: " + Director + " Genres asociated: ";
            foreach (var gen in Genres)
            {
                ret += gen + ", ";
            }
            return ret;
        }

    }
}