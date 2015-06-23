using LandProperties.Repositories.Interfaces;
using LandProperties.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandProperties.BL.Factories
{
    public class RepositoryFactory
    {
        public T GetUserRepository<T>(String repositoryKey) where T : class, IRepository
        {
            String repositoryTypeKeys = ConfigurationHelper.ReadFromConfig(repositoryKey);
            String typeName = repositoryTypeKeys.Split(new char[] { ',' })[0];
            String assemblyName = repositoryTypeKeys.Split(new char[] { ',' })[1];
            var instance = Activator.CreateInstance(assemblyName, typeName);
            T userRepository = instance.Unwrap() as T;
            return userRepository;
        }
    }
}
