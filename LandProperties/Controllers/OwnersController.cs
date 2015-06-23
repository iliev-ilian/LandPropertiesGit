using LandProperties.OwnerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LandProperties.Controllers
{
    public class OwnersController : ApiController
    {
        private IOwnerService _ownerService;

        public OwnersController()
        {
            this._ownerService = new OwnerServiceClient();
        }

        public IEnumerable<Owner> Get()
        {
            List<Owner> allOwners = this._ownerService.GetAllOwners();
            return allOwners;
        }

        public Owner Get(int id)
        {
            Owner owner = this._ownerService.GetOwner(id);
            return owner;
        }

        public Owner Post(Owner owner)
        {
            var newlyCreatedOwner = this._ownerService.Save(owner);
            return newlyCreatedOwner;
        }

        public void Delete(int id)
        {
            this._ownerService.Delete(id);
        }
    }
}