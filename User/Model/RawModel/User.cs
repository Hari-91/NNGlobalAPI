
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace UserModule.Model.RawModel
{
  public  class User : IdentityUser
    {
        public int EmployeeId { get; protected set; }
        public string FirstName { get; protected set; }
        public string Surname { get; protected set; }

    }
}
