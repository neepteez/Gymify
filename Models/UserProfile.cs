using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    using System;

    namespace DataVerseManager.Models
    {
        // This class represents the users profile data
        public class UserProfile
        {
            public int Age { get; set; }
            public int Length { get; set; }  // in cm
            public int Weight { get; set; }  // in kg
            public string Measurements { get; set; }
            public string Description { get; set; }

            // A short summary for printing
            public string Summary =>
                $"Age: {Age}, Length: {Length} cm, Weight: {Weight} kg, Measurements: {Measurements}";
        }
    }




