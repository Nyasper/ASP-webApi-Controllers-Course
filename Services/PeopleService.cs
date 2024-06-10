using Proyecto_Backend_Csharp.Controllers;

namespace Proyecto_Backend_Csharp.Services
{
    public class PeopleService : IPeopleService
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name)) 
            { 
                return false;
            }
            return true;
        }
    }
}
