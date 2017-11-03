using System;
namespace XamarinAdal.Domain
{
    public class Profile
    {
        public string UniqueId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string DisplayableId { get; set; }
    }
}