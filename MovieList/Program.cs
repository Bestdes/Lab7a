using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace MovieList
{
    class Program
    {
        static void Main(string[] args)
        {
            string NameOfProgram = "Movie in Category Searcher";

            List<Movie> listOfMovies = new List<Movie>();
            listOfMovies.Add(new Movie("Matrix", "Scifi"));
            listOfMovies.Add(new Movie("Godfather", "Crime"));
            listOfMovies.Add(new Movie("Casablanca", "Classic"));
            listOfMovies.Add(new Movie("Pulp Fiction", "Crime"));
            listOfMovies.Add(new Movie("Star Wars", "Scifi"));
            listOfMovies.Add(new Movie("Baby Driver", "Thriller"));
            listOfMovies.Add(new Movie("Inception", "Thriller"));
            listOfMovies.Add(new Movie("Edge of Tomorrow", "Scifi"));
            listOfMovies.Add(new Movie("Mad Max", "Scifi"));
            listOfMovies.Add(new Movie("Terminator", "Scifi"));

            List<string> listOfCategories = new List<string>();
            listOfCategories.Add("Scifi");
            listOfCategories.Add("Thriller");
            listOfCategories.Add("Crime");
            listOfCategories.Add("Classic");

            Console.WriteLine("Hello World!");

            //-------------------------------------------------------------------
            // Program Logic Starts Here

            bool runProgram = true;

            while (runProgram)
            {
                GreetingPrompt();
                PrintListOfCategories(listOfCategories);
                Console.WriteLine("------------------"); // This is just for readability of output
                string userInput = ReadAndReturnInput();

                if (ValidateCategory(userInput, listOfCategories))
                {
                    List<string> matchingMovies = SearchMovieForCategory(SearchCategory(userInput, listOfCategories), listOfMovies);
                    Console.WriteLine("------------------"); // This is just for readability of output
                    Console.WriteLine("This is the list of Movies in the requested category: ");
                    PrintMovieList(matchingMovies);
                }
                else if(userInput == "")
                {
                    Console.WriteLine("Sorry , something went wrong. It seems you didn't input any text, try again.");
                    Console.WriteLine("-----------------------------------------------------------------------------"); // This is just for readability of output
                }
                else
                {
                    Console.WriteLine("Invalid Input! Try again please.");
                    Console.WriteLine("--------------------------------"); // This is just for readability of output
                }

                runProgram = CheckIfProgramShouldReRun(NameOfProgram);
            }


        }

        public static void GreetingPrompt()
        {
            Console.WriteLine("Welcome to the Movie Genre Searcher!\nEnter a genre of movies that you would like to search from our collection:");
        }

        public static void PrintListOfCategories(List<string> categoryList)
        {
            Console.WriteLine("The following list represents the categories of movies we have: ");
            foreach (string category in categoryList)
            {
                Console.WriteLine(category);
            }
        }

        public static string ReadAndReturnInput()
        {
            return Console.ReadLine();
        }

        public static bool ValidateCategory(string testingCategory, List<string> categoryList)
        {
            bool isInList = false;

            foreach(string category in categoryList)
            {
                if(testingCategory.ToLower() == category.ToLower())
                {
                    isInList = true;
                    return isInList;
                }
            }
            return isInList;
        }

        public static string SearchCategory(string movieCategory, List<string> categoryList)
        {
            string foundCategory = "";

            foreach(string category in categoryList)
            {
                if (movieCategory.ToLower() == category.ToLower())
                {
                    foundCategory = category;
                    return foundCategory;
                }
            }
            return foundCategory;
        }

        // I am having trouble with the below method. I am trying to call the object's property: Category in the from the movie list
        // Solved!!!
        public static List<string> SearchMovieForCategory(string category, List<Movie> movieList)
        {
            List<string> specificGenreMovies = new List<string>();
            string movieCategory = "";


            foreach (Movie movie in movieList)
            {
                movieCategory = movie.Category;

                if (movieCategory == category)
                {
                    specificGenreMovies.Add(movie.Title);
                }
            }
            return specificGenreMovies;
        }
        public static void PrintMovieList(List<string> movieList)
        {
            foreach(string movie in movieList)
            {
                Console.WriteLine(movie);
            }
        }

        public static Boolean CheckIfProgramShouldReRun(string programName)
        {
            Boolean askRerun = true;

            while (askRerun)
            {
                Console.WriteLine($"Do you want to run the {programName} Again? (y/n)");
                string reRunInput = Console.ReadLine();

                if (reRunInput == "y")
                {
                    askRerun = false;
                }
                else if (reRunInput == "n")
                {
                    Console.WriteLine($"Thank you for using the {programName}. Have nice day!");
                    askRerun = false;
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please input y for yes or n for no.");
                }
            }
            return true;
        }
    }
}
