using System;
using System.Collections.Generic;
using System.Linq;
using AddPersonInputFields.Data;
using System.Threading.Tasks;

namespace AddPersonInputFields.Web.Models
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; }
        public string Message { get; set; }
    }
}
