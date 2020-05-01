using System;
using System.Collections.Generic;
using System.Text;

namespace MovieList
{
    class Movie
    {
        string category;
        string title;


        public string Title { get { return title; } set { title = value; } }
        public string Category { get { return category; } set { category = value; } }

        public Movie()
        {

        }

        public Movie(string title, string category)
        {
            this.title = title;
            this.category = category;
        }
    }
}
