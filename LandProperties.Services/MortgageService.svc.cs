using LandProperties.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LandProperties.Services
{
    public class MortgageService : IMortgageService
    {
        public void Delete(int id)
        {
            new MortgageBL().Delete(id);
        }
    }
}
