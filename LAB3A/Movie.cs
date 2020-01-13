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
{   /// <summary>
    /// This is a Movie class contains the Movie Details
    /// Implements the IEncryptable and Inherit the Media Class
    /// </summary>
    class Movie : Media, IEncryptable
    {
        public string Director { get; set; } //Director of the MOvie
        public string Summary { get; set; } //Summary of the movie
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">Title of the movie</param>
        /// <param name="year">Year OF the Movie</param>
        /// <param name="director">Director of the Movie</param>
        /// <param name="summary">SUmmary of the movie</param>
        public Movie(string title, int year, string director, string summary)
          : base(title, year)
        {
            Director = director;
            Summary = summary;
        }
        /// <summary>
        /// Tostring fucation of the Song class
        /// </summary>
        /// <returns>formatted string of the Movie data using the Movie class Variables</returns>
        public override string ToString()
        {
            return $"Song Title: {Title,-30} ({Year,5}) \n Album: {Director,-15} \n --------------------";

        }
        /// <summary>
        /// IEncryptable is a interface of the for the encrption and Decryption 
        /// In this region Decrypt method is used for the decrption of the Summary
        /// </summary>
        /// <returns> Decrypted Message </returns>
        #region IEncryptable

        public string Decrypt()
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
