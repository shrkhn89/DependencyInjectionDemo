using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGLCodingTest.Models.Constant
{
    public static class Constant
    {
        //Base API URL
        public const string APIUrl = "https://agl-developer-test.azurewebsites.net";

        //API Methods
        public const string GetOwnerPetListEndpoint = "/people.json";

        public const string NoSucessAPIResponse = "API does not respond with success(200) code";
        public const string UnexpectedErrorString = "An expected error occured while the AGL API is being called";
        public const string NoResultFoundString = "There is no data";
        public const string ResultFoundString = "Data found";
    }
}
