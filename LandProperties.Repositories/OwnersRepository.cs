using LandProperties.Entities;
using LandProperties.Repositories.DataModel;
using LandProperties.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandProperties.Repositories
{
    public class OwnersRepository : IOwnersRepository
    {
        public List<Owner> GetAllOwners()
        {
            List<Owner> result = new List<Owner>();
            using (LandPropertiesDBEntities entities = new LandPropertiesDBEntities())
            {
                var dbEntities = entities.OWNERs.ToList();
                dbEntities.ForEach(dbEntity => result.Add(ConvertDbToBusinessEntity(dbEntity)));
            }

            return result;
        }

        public Owner GetOwner(int id)
        {
            using (LandPropertiesDBEntities entities = new LandPropertiesDBEntities())
            {
                var dbOwner = entities.OWNERs.Include("LAND_PROPERTY").FirstOrDefault(o => o.ID == id);
                return ConvertDbToBusinessEntity(dbOwner);
            }
        }

        public Owner AddOwner(Owner owner)
        {
            Owner addedOwner = null;
            using (LandPropertiesDBEntities entities = new LandPropertiesDBEntities())
            {
                OWNER ownerToAdd = new OWNER
                                    {
                                        FIRST_NAME = owner.FirstName,
                                        LAST_NAME = owner.LastName,
                                        ADDRESS = owner.Address
                                    };

                entities.OWNERs.Add(ownerToAdd);
                entities.SaveChanges();
                addedOwner = ConvertDbToBusinessEntity(ownerToAdd);
            }

            return addedOwner;
        }

        public Owner EditOwner(Owner owner)
        {
            using (LandPropertiesDBEntities entities = new LandPropertiesDBEntities())
            {
                var dbOwner = entities.OWNERs.FirstOrDefault(o => o.ID == owner.ID);
                dbOwner.FIRST_NAME = owner.FirstName;
                dbOwner.LAST_NAME = owner.LastName;
                dbOwner.ADDRESS = owner.Address;

                entities.SaveChanges();
                return ConvertDbToBusinessEntity(dbOwner);
            }
        }

        public void Delete(int id)
        {
            using (LandPropertiesDBEntities entities = new LandPropertiesDBEntities())
            {
                var ownerToDelete = entities.OWNERs.FirstOrDefault(o => o.ID == id);
                entities.OWNERs.Remove(ownerToDelete);
                entities.SaveChanges();
            }
        }

        private Owner ConvertDbToBusinessEntity(OWNER dbEntity)
        {
            Owner businessEntity = new Owner();
            businessEntity.ID = dbEntity.ID;
            businessEntity.FirstName = dbEntity.FIRST_NAME;
            businessEntity.LastName = dbEntity.LAST_NAME;
            businessEntity.Address = dbEntity.ADDRESS;

            if (dbEntity.LAND_PROPERTY != null && dbEntity.LAND_PROPERTY.Any())
            {
                businessEntity.LandProperties = new List<LandProperty>();
                dbEntity.LAND_PROPERTY.ToList().ForEach(lp => businessEntity.LandProperties.Add(new LandProperty
                                                                        {
                                                                            ID = lp.ID,
                                                                            Area = lp.AREA,
                                                                            UPI = lp.UPI
                                                                        }));
                                                                                                    
            }

            return businessEntity;
        }
    }
}
