using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserModule.Model.RawModel
{
   public class Operation
    {
        [Key]
        public int ID_OPERATION { get; set; }
        public string TYPE { get; set; }
  


    }
}
