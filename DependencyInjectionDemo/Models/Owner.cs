using AGLCodingTest.Models;
using System;
using System.Collections.Generic;

namespace CodingTest.Global.Models
{
    public class Owner
    {
        /// <summary>
        ///  Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        ///  Age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        ///  Pets
        /// </summary>
        public List<Pet> Pets { get; set; }
    }
}
