using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenda.Core.Data
{
    public abstract class ProjectVendaDbContext : DbContext
    {
        public ProjectVendaDbContext()
        {

        }
    }
}
