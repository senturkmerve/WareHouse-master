using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WareHouse.Model.Enum;

namespace WareHouse.UI.Areas.Admin.Models.DTO
{
    public class AppUserDTO1:BaseDTO
    {
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public Role Role { get; set; }
        public Gender Gender { get; set; }

    }
}