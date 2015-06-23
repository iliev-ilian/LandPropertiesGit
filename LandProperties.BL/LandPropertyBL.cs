using LandProperties.BL.Factories;
using LandProperties.Entities;
using LandProperties.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandProperties.BL
{
    public class LandPropertyBL
    {
        private ILandPropertyRepository landPropertyRepository;
        public LandPropertyBL()
        {
            this.landPropertyRepository =
                new RepositoryFactory().GetUserRepository<ILandPropertyRepository>("LandPropertyRepository");
        }

        public List<LandProperty> GetAllLandProperties()
        {
            List<LandProperty> result = this.landPropertyRepository.GetAllLandProperties();
            return result;
        }

        public LandProperty GetLandProperty(int id)
        {
            return this.landPropertyRepository.GetLandProperty(id);
        }

        public void SaveLandProperty(LandProperty landPropertyToSave)
        {
            if (landPropertyToSave.ID != 0)
            {
                //Edit
                this.landPropertyRepository.Edit(landPropertyToSave);
            }
            else
            {
                //Add
                this.landPropertyRepository.Add(landPropertyToSave);
            }
        }

        public void Delete(int id)
        {
            this.landPropertyRepository.Delete(id);
        }
    }
}
