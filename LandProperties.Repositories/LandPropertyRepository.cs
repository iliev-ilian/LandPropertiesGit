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
    public class LandPropertyRepository : ILandPropertyRepository
    {
        public List<LandProperty> GetAllLandProperties()
        {
            List<LandProperty> result = new List<LandProperty>();
            using (LandPropertiesDBEntities entities = new LandPropertiesDBEntities())
            {
                var landProperties = entities.LAND_PROPERTY.Include("MORTGAGEs").Include("OWNER").ToList();
                foreach (var dbLandProperty in landProperties)
                {
                    result.Add(ConvertToBusinessEntity(dbLandProperty));
                }
            }

            return result;
        }

        public LandProperty GetLandProperty(int id)
        {
            LandProperty result = null;

            using (LandPropertiesDBEntities entities = new LandPropertiesDBEntities())
            {
                var dbLandProperty = entities.LAND_PROPERTY.Include("MORTGAGEs").Include("OWNER").FirstOrDefault(lp => lp.ID == id);
                result = ConvertToBusinessEntity(dbLandProperty);
            }

            return result;
        }

        public void Edit(LandProperty landProperty)
        {
            using (LandPropertiesDBEntities entities = new LandPropertiesDBEntities())
            {
                var dbLandProperty = entities.LAND_PROPERTY.Include("OWNER").Include("MORTGAGEs").FirstOrDefault(lp => lp.ID == landProperty.ID);

                dbLandProperty.MORTGAGEs.ToList().ForEach(m => entities.MORTGAGEs.Remove(m));
                CopyDataFromBusinessToEFObject(dbLandProperty, landProperty);

                entities.SaveChanges();
            }
        }

        public void Add(LandProperty landProperty)
        {
            using (LandPropertiesDBEntities entities = new LandPropertiesDBEntities())
            {
                LAND_PROPERTY dbObjectToAdd = new LAND_PROPERTY();
                CopyDataFromBusinessToEFObject(dbObjectToAdd, landProperty);
                entities.LAND_PROPERTY.Add(dbObjectToAdd);
                entities.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (LandPropertiesDBEntities entities = new LandPropertiesDBEntities())
            {
                //Delete mortgages associates to this land property
                var mortgagesToThisProperty = entities.MORTGAGEs.Where(m => m.LAND_PROPERTY_ID == id).ToList();
                mortgagesToThisProperty.ForEach(m => entities.MORTGAGEs.Remove(m));

                //Delete the land property
                var landPropertyToDelete = entities.LAND_PROPERTY.FirstOrDefault(lp => lp.ID == id);
                entities.LAND_PROPERTY.Remove(landPropertyToDelete);

                entities.SaveChanges();
            }
        }

        private void CopyDataFromBusinessToEFObject(LAND_PROPERTY dbObject, LandProperty businessObject)
        {
            dbObject.AREA = businessObject.Area;
            dbObject.UPI = businessObject.UPI;
            dbObject.OWNER_ID = businessObject.Owner.ID;

            dbObject.MORTGAGEs.Clear();
            if (businessObject.Mortgages != null && businessObject.Mortgages.Any())
            {
                businessObject.Mortgages.ForEach(m => dbObject.MORTGAGEs.Add(new MORTGAGE
                                                                                {
                                                                                    MONEY_AMOUNT = m.MoneyAmount,
                                                                                    BEGIN_DATE = m.BeginDate
                                                                                }));
            }
            #region Needed, when only the deleted repositories are removed

            //var newlyAddedMortgages = businessObject.Mortgages.Where(lp => !dbObject.MORTGAGEs.Select(dbLp => dbLp.ID).Contains(lp.ID)).ToList();
            //foreach (var mortgage in newlyAddedMortgages)
            //{
            //    dbObject.MORTGAGEs.Add(new MORTGAGE
            //    {
            //        MONEY_AMOUNT = mortgage.MoneyAmount,
            //        BEGIN_DATE = mortgage.BeginDate
            //    });
            //}

            #endregion
        }

        private LandProperty ConvertToBusinessEntity(LAND_PROPERTY dbLandProperty)
        {
            LandProperty result = new LandProperty();
            result.ID = dbLandProperty.ID;
            result.Area = dbLandProperty.AREA;
            result.UPI = dbLandProperty.UPI;
            result.Mortgages = new List<Mortgage>();
            result.Owner = new Owner
                            {
                                ID = dbLandProperty.OWNER.ID,
                                FirstName = dbLandProperty.OWNER.FIRST_NAME,
                                LastName = dbLandProperty.OWNER.LAST_NAME,
                                Address = dbLandProperty.OWNER.ADDRESS
                            };
            foreach (var dbMorgage in dbLandProperty.MORTGAGEs)
            {
                result.Mortgages.Add(new Mortgage
                                        {
                                            ID = dbMorgage.ID,
                                            MoneyAmount = dbMorgage.MONEY_AMOUNT,
                                            BeginDate = dbMorgage.BEGIN_DATE
                                        });
            }

            return result;
        }
    }
}
