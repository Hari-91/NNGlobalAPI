using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserModule.Model.RawModel
{
    public class JoinUserModule
    {
        [Key]
        [Column(Order = 1)]
        public int ID_USER { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ID_MODULE { get; set; }

        //[ForeignKey("ID_USER")]
        //public User User { get; set; }
        [ForeignKey("ID_MODULE")]
        public Module Module { get; set; }

    }
}
