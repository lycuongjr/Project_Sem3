using HTM.Mgs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTM.Mgs.Service
{
    public class ChucVuService : BaseService<ChucVu, HTMDb>
    {
        public IEnumerable<ChucVu> DSChucVu()
        {
            var list = dbContext.ChucVus.Where(x => x.TrangThai == true).AsQueryable();

            return list.OrderBy(x => x.ChucVuId);
        }

    }
       
}
