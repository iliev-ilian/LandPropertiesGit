using LandProperties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandProperties.Repositories.Interfaces
{
    public interface ILandPropertyRepository : IRepository
    {
        List<LandProperty> GetAllLandProperties();

        LandProperty GetLandProperty(int id);

        void Edit(LandProperty landProperty);

        void Add(LandProperty landProperty);

        void Delete(int id);
    }
}
