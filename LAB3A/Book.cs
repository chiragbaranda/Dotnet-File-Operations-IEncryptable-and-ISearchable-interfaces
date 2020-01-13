/*# I, CHIRAG BARANDA, student number 000759867, 
 * certify that all code submitted is my own work; 
 * that I have not copied it from any other source.  
 * I also certify that I have not allowed my work to be copied by others.
 * 
 * Author: Chirag Baranda
 * Student Number: 000759867
 * 
 * Algorith Used From : https://www.dotnetperls.com/rot13
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3A
{
    /// <summary>
    /// This is a book class contains the Book Details
    /// Implements the IEncryptable and Inherit the Media Class
    /// </summary>
    class Book : Media, IEncryptable
    {

        public string Author { get; set; } //Autor of the Book object
        public string Summary { get; set; } //Summary of the Book object

        /// <summary>
        /// Two-argument constructor sets the two properties that all Media objects have
        /// call the base construcor for the title and year of the object
        /// </summary>
        /// <param name="title">Title of the Book Object</param>
        /// <param name="year">Year of the book object </param>
        /// <param name="author"> Name of the book object</param>
        /// <param name="summary">Summary of the book object</param>
        public Book(string title, int year, string author, string summary)
          : base(title, year)
        {
            Author = author;
            Summary = summary;
        }
        /// <summary>
        /// Tostring fucation of the Book class
        /// </summary>
        /// <returns>formatted string of the book data using the Book class Variables</returns>
        public override string ToString()
        {
            return $"Book Title: {Title,-30} ({Year,4}) \n Author: {Author,-15} \n --------------------";

        }
        /// <summary>
        /// IEncryptable is a interface of the for the encrption and Decryption 
        /// In this region Decrypt method is used for the decrption of the Summary
        /// </summary>
        /// <returns> Decrypted Message </returns>
        #region IEncryptable

         
        public string Decrypt() //method to decrypt the summary data from the data.txt
        {
            char[] array = Summary.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                int number = (int)array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                array[i] = (char)number;
            }
            return new string(array);
        }

        public string Encrypt()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
