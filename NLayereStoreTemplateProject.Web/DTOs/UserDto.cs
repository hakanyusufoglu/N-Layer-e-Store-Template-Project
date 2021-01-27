using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.DTOs
{
    public class UserDto
    {//yorum satırı deneme amaçlı eklendi
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
    }
}
