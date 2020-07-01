using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserModule.Model
{
    public class Role : IdentityRole
    {
        //public static implicit operator Role(RoleEnum re) => new Role(re);
        //public static implicit operator RoleEnum(Role r) => (RoleEnum)r.Id;

        [Required]
        [MaxLength(32)]
        public string ViewText { get; protected set; }

        //protected Role() { }
        //protected Role(RoleEnum roleEnum)
        //{
        //    Id = (int)roleEnum;
        //    Name = roleEnum.ToString();
        //    NormalizedName = Name.Normalize();
        //    ViewText = roleEnum.GetEnumDescription();
        //}
        //protected Role(RoleEnum roleEnum, string viewText)
        //{
        //    Id = (int)roleEnum;
        //    Name = roleEnum.ToString();
        //    ViewText = viewText;
        //}

        //public RoleDto GetDto()
        //{
        //    return new RoleDto
        //    {
        //        Id = Id,
        //        Name = Name,
        //        ViewText = ViewText
        //    };
        //}
    }
}
