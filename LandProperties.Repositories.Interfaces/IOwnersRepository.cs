using LandProperties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandProperties.Repositories.Interfaces
{
    public interface IOwnersRepository : IRepository
    {
        List<Owner> GetAllOwners();

        Owner AddOwner(Owner owner);

        Owner GetOwner(int id);

        Owner EditOwner(Owner owner);

        void Delete(int id);
    }
}
