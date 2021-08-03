using System;

namespace PasswordGeneratorApp.Models
{
    public class Password
    {
        public long PasswordId { get; set; }
        public string SiteURL { get; set; }
        public string SitePassword { get; set; }
        public DateTime CreateDate { get; set; }
        private DateTime expireDate { get; set; }
        public DateTime ExpireDate 
        {
            get => expireDate;
            set
            {
                DateTime date = CreateDate.AddDays(90);
                expireDate = date;
            }
        }
        public Person Person { get; set; }
        public long PersonId { get; set; }
    }
}