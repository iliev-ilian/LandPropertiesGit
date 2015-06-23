using LandProperties.MortgageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LandProperties.Controllers
{
    public class MortgagesController : ApiController
    {
        private IMortgageService _mortgageService;

        public MortgagesController()
        {
            this._mortgageService = new MortgageServiceClient();
        }

        public void Delete(int id)
        {
            this._mortgageService.Delete(id);
        }
    }
}