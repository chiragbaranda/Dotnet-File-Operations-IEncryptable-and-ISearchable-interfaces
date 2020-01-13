/*# I, CHIRAG BARANDA, student number 000759867, 
 * certify that all code submitted is my own work; 
 * that I have not copied it from any other source.  
 * I also certify that I have not allowed my work to be copied by others.
 * 
 * Author: Chirag Baranda
 * Student Number: 000759867
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LAB3A
{
    /// <summary>
    /// This is a main program containing the main method.
    /// This class interact with user, user is asked to choose from given option, and respose accordingly
    /// Read data from the file, and give Output
    ///Serach and Display Data 
    ///
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ///lists for the books,songs and movies data storage
            List<Book> books = new List<Book>();
            List<Song> songs = new List<Song>();
            List<Movie> movies = new List<Movie>();
            List<Media> allmedia = new List<Media>();
            int count=0;
            StreamReader data = new StreamReader("Data.txt");


            //Read Data.txt
            string record;
            while ((record = data.ReadLine()) != null)
            {
                string[] exploded = record.Split('|'); //spliting the content of the same record

                string summary = "";
                do //splitting the records after the summary where there is a ----- occred
                {
                    record = data.ReadLine();
                    if (record != "-----")
                        summary += record;
                    else
                        summary += "\n";
                } while (record != "-----");

                if (exploded[0] == "BOOK")
                {
                    books.Add(new Book(exploded[1], Convert.ToInt32(exploded[2]), exploded[3], summary)); //creating the book object
                    //allmedia[count] = new Book(exploded[1], Convert.ToInt32(exploded[2]), exploded[3], summary); count++; //**under testing**

                }
                if (exploded[0] == "SONG")
                {
                    songs.Add(new Song(exploded[1], Convert.ToInt32(exploded[2]), exploded[3], summary)); //creating the song object
                    //allmedia[count] = new Song(exploded[1], Convert.ToInt32(exploded[2]), exploded[3], summary); count++; //**under testing**

                }
                if (exploded[0] == "MOVIE")
                {
                    movies.Add(new Movie(exploded[1], Convert.ToInt32(exploded[2]), exploded[3], summary)); //creating the movie object
                    //allmedia[count] = new Movie(exploded[1], Convert.ToInt32(exploded[2]), exploded[3], summary);  count++; //**under testing**
                }

            }

            data.Close(); //closing the file after reading the data
            
            //  user intercation, loop will run untill user insert 6
            Char userinput;
            do
            {
                Console.Clear();
                //intercation menu for user
                Console.WriteLine("*******++ Media Collection ++*******");
                Console.WriteLine("=======================");
                Console.WriteLine("1. List All Books");
                Console.WriteLine("2. List All Movies");
                Console.WriteLine("3. List All Songs");
                Console.WriteLine("4. List All Media");
                Console.WriteLine("5. Search All Media by Title");
                Console.WriteLine("6. Exit Program");
                Console.Write("Enter choice: ");

                userinput = Char.Parse(Console.ReadLine().Trim()); //user input

                switch(userinput)
                {
                    case '1':  //printing book data except the summary
                            foreach (Book b in books)
                                Console.WriteLine(b);
                        break;
                    case '2': //printing Movie data
                        foreach (Movie m in movies)
                            Console.WriteLine(m);
                        break;
                    case '3': //printing songs data
                        foreach (Song s in songs)
                            Console.WriteLine(s);
                        break;
                    case '4': //pringint all data
                        Console.WriteLine("Book");
                        foreach (Book b in books)
                            Console.WriteLine(b);
                        Console.WriteLine("Songs");
                        foreach (Song s in songs)
                            Console.WriteLine(s);
                        Console.WriteLine("Movies");
                        foreach (Movie m in movies)
                            Console.WriteLine(m);
                        break;
                    case '5': //printing data with search query and decrypted summary
                        Console.WriteLine("Enter a search term: ");
                        string query = Console.ReadLine();

                            foreach (Book b in books)
                                if (b.Search(query))
                                {
                                    Console.WriteLine(b);
                                Console.WriteLine("Book Summary" + b.Decrypt());
                            }
                        foreach (Song s in songs)
                            if (s.Search(query))
                            {
                                Console.WriteLine(s);
                            }
                        foreach (Movie m in movies)
                            if (m.Search(query))
                            {
                                Console.WriteLine(m);
                                Console.WriteLine(" Movie Summary" + m.Decrypt());
                            }

                        break;
                        default: Console.WriteLine("Invalid Input, Please Try Again!! ");
                        break;

                }

                Console.WriteLine(" \n Press any Key to Continue...");
                Console.ReadKey();
            } while (userinput != '6');


          
        }
    }
}
