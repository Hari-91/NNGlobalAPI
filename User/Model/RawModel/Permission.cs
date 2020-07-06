using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserModule.Model.RawModel
{
   public class Permission
    {

        [Key]
        [Column(Order = 1)]
        public int? ID_PERMISSION { get; set; }


        [Key]
        [Column(Order = 2)]
        public int? ID_USER { get; set; }
        [Key]
        [Column(Order = 3)]
        public int? ID_OPERATION { get; set; }
        [Key]
        [Column(Order = 4)]
        public int? ID_MODULE { get; set; }
        [Key]
        [Column(Order = 5)]
        public int? ID_FUNCIONALITY { get; set; }




        [ForeignKey("ID_MODULE")]
        public Module? Module { get; set; }

        [ForeignKey("ID_FUNCIONALITY")]
        public Funcionality? Funcionality { get; set; }

        [ForeignKey("ID_OPERATION")]
        public Operation? Operation { get; set; }
    }
}
