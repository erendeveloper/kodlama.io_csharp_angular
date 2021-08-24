using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Entities
{
    class Gamer
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Surname { get; set; }
       public long NationalityId { get; set; }
       public int BirthYear { get; set; }

    }
}
