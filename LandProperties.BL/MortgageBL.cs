using LandProperties.BL.Factories;
using LandProperties.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandProperties.BL
{
    public class MortgageBL
    {
        IMortgageRepository mortgageRepository;

        public MortgageBL()
        {
            this.mortgageRepository = new RepositoryFactory().GetUserRepository<IMortgageRepository>("MortgageRepository");
        }

        public void Delete(int id)
        {
            this.mortgageRepository.Delete(id);
        }
    }
}
