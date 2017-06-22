using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Lab4
{
    [Serializable]
    [DataContract(Name = "Brand")]
    [KnownType(typeof(Product))]
    [KnownType(typeof(CollectionProduct))]
    public class Brand : List<int>
    {
        [DataMember(Order = 0)]
        [XmlElement("product_name")]
        public string productName;
        [DataMember(Order = 1)]
        [XmlElement("name")]
        public string name;
        [DataMember(Order = 2)]
        [XmlElement("cost")]
        public int cost;
    }
}
