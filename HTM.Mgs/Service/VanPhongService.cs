using HTM.Mgs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTM.Mgs.Service
{
   public class VanPhongService : BaseService<VanPhong, HTMDb>
    {
   
        public IEnumerable<VanPhong> DSVanPhong()
        {
            var list = dbContext.VanPhongs.Where(x => x.TrangThai == true).AsQueryable();           
            return list.OrderBy(x => x.VanPhongId);
        }
     
    }
}
