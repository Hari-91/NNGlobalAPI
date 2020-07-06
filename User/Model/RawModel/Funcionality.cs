using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace UserModule.Model.RawModel
{
   public class Funcionality
    {
        [Key]
        public int ID_FUNCIONALITY { get; set; }
        public string NAME { get; set; }

        public int ID_MODULE { get; set; }

        public Module? Module { get; set; }

        public ICollection<Permission>? Permissions { get; set; }


    }
}
