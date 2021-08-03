using System;
using System.ComponentModel.DataAnnotations;

namespace PasswordGeneratorApp.Models
{
    public class Password
    {
        public long PasswordId { get; set; }
        [Display(Name = "Link to Site")]
        public string SiteURL { get; set; }
        [Display(Name = "Password")]
        public string SitePassword { get; set; }
        [Display(Name = "Create Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreateDate { get; set; }
        private DateTime expireDate { get; set; }
        [Display(Name = "Expires")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExpireDate 
        {
            get => expireDate;
            set
            {
                DateTime date = CreateDate.AddDays(90);
                expireDate = date;
            }
        }
        [Display(Name = "For")]
        public Person Person { get; set; }
        [Display(Name = "Associated Person")]
        public long PersonId { get; set; }
    }
}