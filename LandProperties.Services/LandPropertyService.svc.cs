using LandProperties.BL;
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
    public class LandPropertyService : ILandPropertyService
    {
        public List<LandProperty> GetAllLandProperties()
        {
            return new LandPropertyBL().GetAllLandProperties();
        }

        public LandProperty GetLandProperty(int id)
        {
            return new LandPropertyBL().GetLandProperty(id);
        }

        public void SaveLandProperty(LandProperty landPropertyToSave)
        {
            new LandPropertyBL().SaveLandProperty(landPropertyToSave);
        }

        public void Delete(int id)
        {
            new LandPropertyBL().Delete(id);
        }
    }
}
