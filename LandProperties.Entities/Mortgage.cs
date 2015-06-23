using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LandProperties.Entities
{
    [DataContract]
    public class Mortgage
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public decimal MoneyAmount { get; set; }

        [DataMember]
        public DateTime BeginDate { get; set; }
    }
}
