using System;
using Microsoft.AspNetCore.Mvc;
using TechTest.Repositories;
using TechTest.Repositories.Models;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;

namespace TechTest.Controllers
{
    [Route("api/people")]
    [ApiController]
    [Produces("application/json")]
    public class PeopleController : ControllerBase
    {
        public PeopleController(IPersonRepository personRepository)
        {
            this.PersonRepository = personRepository;
        }

        private IPersonRepository PersonRepository { get; }

        [HttpGet]
        public IActionResult GetAll()
        {
            // TODO: Step 1
            //
            // Implement a JSON endpoint that returns the full list
            // of people from the PeopleRepository. If there are zero
            // people returned from PeopleRepository then an empty
            // JSON array should be returned.
            var list = new List<Person>(); //list that will return the list of people. 

            //Add the results of the person into a list.
            foreach (Person p in PersonRepository.GetAll())
            {
                list.Add(p);
            }
            
            //If the list is empty, then return an empty json array.
            if (list.Count == 0)
            {
                var emptyArr = list.ToArray();
                JsonConvert.SerializeObject(emptyArr); //convert to a json object. 
                //return Json(new { status = "success", result = aJsonObject });
                return Ok(emptyArr);

            }
            else
            {
                //return the list of people. 
                return Ok(list);
            }
           
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // TODO: Step 2
            //
            // Implement a JSON endpoint that returns a single person
            // from the PeopleRepository based on the id parameter.
            // If null is returned from the PeopleRepository with
            // the supplied id then a NotFound should be returned.

            if (PersonRepository.Get(id) == null)
            {
                return NotFound();
            }
            else
            {
                var result = PersonRepository.Get(id);
                return Ok(result);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PersonUpdate personUpdate)
        {
            // TODO: Step 3
            //
            // Implement an endpoint that receives a JSON object to
            // update a person using the PeopleRepository based on
            // the id parameter. Once the person has been successfully
            // updated, the person should be returned from the endpoint.
            // If null is returned from the PeopleRepository then a
            // NotFound should be returned.

            if (PersonRepository.Get(id) != null)
            {
                var personResult = PersonRepository.Get(id);
                var personObj = new Person
                {
                    Id = personResult.Id,
                    FirstName = personResult.FirstName,
                    LastName = personResult.LastName,
                    Enabled = personUpdate.Enabled,
                    Authorised = personUpdate.Authorised,
                    Colours = personUpdate.Colours
                };
                //if update is successful, return the person variable. 
                return Ok(personObj);

            }   
            else 
            {
                return NotFound(); //return notfound if the variable is null.
            }
            
        }
    }

    
}