using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserModule.Model.RawModel
{
   public class Module
    {
        [Key]
        public int ID_MODULE { get; set; }
        public string NAME { get; set; }
        public virtual ICollection<Funcionality> Funcionalities { get; set; }

    }
}
