using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApp.Models;
using SimpleWebApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagesController : ControllerBase
    {
        // GET: api/<PassagesController>
        [HttpGet]
        public Passage Get(int passageId)
        {
            //validate passageId
            IPassageService passageService = new PassageService();
            return passageService.GetPassage(passageId);
        }        
    }
}
