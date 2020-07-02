using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service.IService
{
   public interface ITokenService
    {
        public string generateToken(string Id);
    }
}
