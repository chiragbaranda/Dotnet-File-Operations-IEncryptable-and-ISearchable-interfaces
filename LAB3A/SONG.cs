/*# I, CHIRAG BARANDA, student number 000759867, 
 * certify that all code submitted is my own work; 
 * that I have not copied it from any other source.  
 * I also certify that I have not allowed my work to be copied by others.
 * 
 * Author: Chirag Baranda
 * Student Number: 000759867
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3A
{   /// <summary>
    /// This is a SONG class contains the song Details
    /// Implements the IEncryptable and Inherit the Media Class
    /// </summary>
    class Song : Media
    {
        public string Artist { get; set; } //Artist of the Song object
        public string Album { get; set; } //Album of the Song object
        /// <summary>
        /// Two-argument constructor sets the two properties that all Song objects have
        /// call the base construcor for the title and year of the object
        /// </summary>
        /// <param name="title">Title of the song object</param>
        /// <param name="year">Name of the Song</param>
        /// <param name="album">Album of the song</param>
        /// <param name="artist">Artist fof the song</param>
        public Song(string title, int year, string album, string artist)
          : base(title, year)
        {
            Album = album;
            Artist = artist;
        }
        /// <summary>
        ///  Tostring fucation of the Song class
        /// </summary>
        /// <returns>formatted string of the Song data using the Song class Variables</returns>
        public override string ToString()
        {
            return $"Song Title: {Title,-30} ({Year,5}) \n Album: {Album,-15} Artist: {Artist} \n --------------------";

        }

    }
}
