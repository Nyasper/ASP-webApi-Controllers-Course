using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Backend_Csharp.Services;

namespace Proyecto_Backend_Csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }


        [HttpGet("all")] //api/Peopple/all
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")] //api/:id
        public ActionResult<People> Get(int id) //Los ActionResult son manejardores de codigo http
        {
            var people = Repository.People.FirstOrDefault(p => p.Id == id); //el metodo FristOrDefault no arroja una exepcion si no encuentra al elemento, en su lugar devuelve null.

            if (people == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(people);
            }

        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search) =>
            Repository.People.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList();


        [HttpPost]
        public IActionResult Add(People people) //IActionResult se utiliza cuando no se retorna nada, por ejemplo cuando agregamos,actualizamos, o eliminamos algo.
        {
            if (!this._peopleService.Validate(people))
            {
                return BadRequest(); //retorna una respuesta 400
            }

            Repository.People.Add(people);

            return NoContent(); //devuelve que todo fue ok pero no se envia nada en el body.
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var people = Repository.People.FirstOrDefault(p => p.Id == id);

            if(people == null)
            {
                return BadRequest();
            }

            Repository.People.Remove(people);

            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdatePerson([FromBody] People people)
        {
            var ExistPeople = Repository.People.FirstOrDefault(p => p.Id == people.Id);

            if (ExistPeople == null)
            {
                return BadRequest();
            }

            foreach (var p in Repository.People)
            {
                if (p.Id == ExistPeople.Id)
                {
                    p.Name = ExistPeople.Name;
                    p.Birthday = ExistPeople.Birthday;
                }
            }
            return NoContent();
        }



    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime  Birthday { get; set; } 
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                Id=1, Name="Pedro", Birthday = new DateTime(1990,12,3)
            },
            new People()
            {
                Id=2, Name="Juan", Birthday = new DateTime(2000,12,3)
            },
            new People()
            {
                Id=3, Name="MarcosS", Birthday = new DateTime(1995,12,3)
            },
            new People()
            {
                Id=4, Name="Lucy", Birthday = new DateTime(2000,12,3)
            },

        };
    }

}
