using System.Collections.Generic;
using System.Linq;
using user_crud.Server.Entities;

namespace user_crud.Server.Services
{
    public class NationalityService : INationalityService
    {
        public IEnumerable<string> GetAll()
        {
            return System.Enum.GetNames(typeof(Nationality));
        }
    }
}
