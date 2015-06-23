using LandProperties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LandProperties.Services
{
    [ServiceContract]
    public interface IOwnerService
    {
        [OperationContract]
        List<Owner> GetAllOwners();

        [OperationContract]
        Owner Save(Owner owner);

        [OperationContract]
        Owner GetOwner(int id);

        [OperationContract]
        void Delete(int id);
    }
}
