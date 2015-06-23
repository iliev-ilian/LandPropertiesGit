using LandProperties.BL.Factories;
using LandProperties.Entities;
using LandProperties.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandProperties.BL
{
    public class OwnerBL
    {
        private IOwnersRepository _ownersRepository;

        public OwnerBL()
        {
            this._ownersRepository = new RepositoryFactory().GetUserRepository<IOwnersRepository>("OwnersRepository");
        }

        public List<Owner> GetAllOwners()
        {
            return this._ownersRepository.GetAllOwners();
        }

        public Owner Save(Owner owner)
        {
            if (owner.ID != 0)
                return this._ownersRepository.EditOwner(owner);
            else
                return this._ownersRepository.AddOwner(owner);
        }

        public Owner GetOwner(int id)
        {
            return this._ownersRepository.GetOwner(id);
        }

        public void Delete(int id)
        {
            this._ownersRepository.Delete(id);
        }
    }
}
