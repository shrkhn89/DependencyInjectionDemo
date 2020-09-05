using System;
using System.Collections.Generic;

namespace CodingTest.Global.Models
{
    public class OwnerViewModel
    {
        /// <summary>
        /// OwnerGender
        /// </summary>
        public string OwnerGender { get; set; }

        /// <summary>
        /// CatNames
        /// </summary>
        public IEnumerable<string> CatNames { get; set; }
    }
}
