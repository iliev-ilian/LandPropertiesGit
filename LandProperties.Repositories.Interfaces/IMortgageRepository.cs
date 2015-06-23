using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandProperties.Repositories.Interfaces
{
    public interface IMortgageRepository: IRepository
    {
        void Delete(int id);
    }
}
