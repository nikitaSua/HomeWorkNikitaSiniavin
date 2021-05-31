using System.Runtime.Serialization;

namespace Core.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;

        [DataMember] 
        public string Age;

        [DataMember]
        public int TotalPoints;
    }
}