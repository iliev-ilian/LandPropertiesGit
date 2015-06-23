using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LandProperties.Entities
{
    [DataContract]
    public class LandProperty
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public double Area { get; set; }

        [DataMember]
        public String UPI { get; set; }

        [DataMember]
        public List<Mortgage> Mortgages { get; set; }

        [DataMember]
        public Owner Owner { get; set; }
    }
}
