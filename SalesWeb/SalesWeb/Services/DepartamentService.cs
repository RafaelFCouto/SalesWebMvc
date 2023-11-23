using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWeb.Models;
using SalesWeb.Data;

namespace SalesWeb.Services
{
    public class DepartamentService
    {


        private readonly SalesWebContext _context;

        public DepartamentService(SalesWebContext context)
        {
            _context = context;

        }

        public List<Departament> FindAll()
        {

            return _context.Departament.OrderBy(d=> d.Name).ToList();

        }






    }
}
