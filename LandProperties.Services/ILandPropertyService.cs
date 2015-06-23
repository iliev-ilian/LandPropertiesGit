using LandProperties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LandProperties.Services
{
    [ServiceContract]
    public interface ILandPropertyService
    {
        [OperationContract]
        List<LandProperty> GetAllLandProperties();

        [OperationContract]
        LandProperty GetLandProperty(int id);

        [OperationContract]
        void SaveLandProperty(LandProperty landPropertyToSave);

        [OperationContract]
        void Delete(int id);
    }
}
