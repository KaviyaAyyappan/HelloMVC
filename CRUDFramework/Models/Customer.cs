using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDFramework.Models
{
    public class Customer
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="This field is requied")]
        
        public string Name { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="This field is requied")]
        public int Telephone { get; set; }
                
    }
}