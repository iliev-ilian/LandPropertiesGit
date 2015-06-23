using LandProperties.BL;
using LandProperties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LandProperties.Services
{
    public class OwnerService : IOwnerService
    {
        public List<Owner> GetAllOwners()
        {
            return new OwnerBL().GetAllOwners();
        }

        public Owner Save(Owner owner)
        {
            return new OwnerBL().Save(owner);
        }

        public Owner GetOwner(int id)
        {
            return new OwnerBL().GetOwner(id);
        }

        public void Delete(int id)
        {
            new OwnerBL().Delete(id);
        }
    }
}
