using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CodingTest.Global.Models;
using AGLCodingTest.Data;
using AGLCodingTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AGLCodingTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _serviceRepository;

        public HomeController(IRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public IActionResult Index()
        {
            IEnumerable < OwnerViewModel > ownerWiseCats  = null;
            try
            {
                //GET List of Owner with all pet details from API Call
                IEnumerable<Owner> ownerPetList = _serviceRepository.GetOwnerList();

                //Sort Owner's gender wise cats 
                 ownerWiseCats = _serviceRepository.SortCatsInAscOrder(ownerPetList);

                return View(ownerWiseCats);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(exception.Message, "Something went wrong. Please inspect the exception error");
            }
            return View(ownerWiseCats);
        }

        
    }
}