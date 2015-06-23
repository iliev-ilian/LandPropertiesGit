using LandProperties.LandPropertyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LandProperties.Controllers
{
    public class LandPropertiesController : ApiController
    {
        ILandPropertyService _landPropertyService;

        public LandPropertiesController()
        {
            this._landPropertyService = new LandPropertyServiceClient();
        }

        public IEnumerable<LandProperty> Get()
        {
            var landProperties = _landPropertyService.GetAllLandProperties();
            return landProperties;
        }

        public LandProperty Get(int id)
        {
            var landProperty = this._landPropertyService.GetLandProperty(id);
            return landProperty;
        }

        public void Post(LandProperty landProperty)
        {
            this._landPropertyService.SaveLandProperty(landProperty);
        }

        public void Delete(int id)
        {
            this._landPropertyService.Delete(id);
        }
    }
}