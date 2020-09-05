using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CodingTest.Global.Models;
using AGLCodingTest.Models.Constant;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using HttpClient = System.Net.Http.HttpClient;
using Microsoft.IdentityModel.Tokens;

namespace AGLCodingTest.Data
{
    public class OwnerRepository : IRepository
    {
        private readonly ILogger<OwnerRepository> logger;
        public OwnerRepository( ILogger<OwnerRepository> logger )
        {
            this.logger = logger;
        }
       


        public IEnumerable<Owner> GetOwnerList()
        {
            IEnumerable<Owner> owner = null;
            string endPoint = String.Empty;
            try { 
            
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constant.APIUrl);

                    // Asynchronous API GET call using HttpClient 
                    var responseTask = client.GetAsync(Constant.GetOwnerPetListEndpoint);

                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Owner>>();
                        readTask.Wait();

                        owner = readTask.Result;
                    }
                    else
                    {
                        //API call didnt respond with success message. Log the response code
                        this.logger.LogInformation(Constant.NoSucessAPIResponse , result.StatusCode);
                        owner = Enumerable.Empty<Owner>();
                    }
                }
                this.logger.LogInformation(Constant.ResultFoundString);
                return owner;
            }
            catch (Exception exception)
            {
                this.logger.LogError("An error has occured during API call. '{RequestUri}' with error message ", Constant.APIUrl + endPoint, exception.InnerException?.Message);
                
            }

            return owner;
        }

        public IEnumerable<OwnerViewModel> SortCatsInAscOrder(IEnumerable<Owner> ownerList)
        {
            List<OwnerViewModel> ownerViewModel = null;
            try
            {
                if (ownerList == null || ownerList.Count() == 0)
                {
                    this.logger.LogInformation(Constant.NoResultFoundString);

                    return ownerViewModel;
                }
                else
                {
                    this.logger.LogInformation(Constant.ResultFoundString);

                    var personListGroupedPerGenderCatNames = ownerList
                    .Where(p => p.Pets != null && p.Pets.Any())
                    .GroupBy(g => g.Gender)
                    .Select(
                        group => new OwnerViewModel
                        {
                            OwnerGender = group.Key,
                            CatNames = group
                                .SelectMany(p => p.Pets)
                                .Where(p => p.Type.Equals("Cat", StringComparison.OrdinalIgnoreCase))
                                .Select(pet => pet.Name)
                                .OrderBy(name => name)
                        }).ToList();

                    return personListGroupedPerGenderCatNames;
                }
            }
            
            catch (Exception ex)
            {
                this.logger.LogError(ex, Constant.UnexpectedErrorString);
            }
            return ownerViewModel;
        }
    }
}