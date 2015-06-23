using LandProperties.Repositories.DataModel;
using LandProperties.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandProperties.Repositories
{
    public class MortgageRepository : IMortgageRepository
    {
        public void Delete(int id)
        {
            using (LandPropertiesDBEntities entities = new LandPropertiesDBEntities())
            {
                var mortgage = entities.MORTGAGEs.FirstOrDefault(m => m.ID == id);
                entities.MORTGAGEs.Remove(mortgage);
                entities.SaveChanges();
            }
        }
    }
}
