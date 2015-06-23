using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LandProperties.Entities
{
    [DataContract]
    public class Owner
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public String FirstName { get; set; }

        [DataMember]
        public String LastName { get; set; }

        [DataMember]
        public String Address { get; set; }

        [DataMember]
        public List<LandProperty> LandProperties { get; set; }
    }
}
