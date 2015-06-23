using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LandProperties.Services
{
    [ServiceContract]
    public interface IMortgageService
    {
        [OperationContract]
        void Delete(int id);
    }
}
