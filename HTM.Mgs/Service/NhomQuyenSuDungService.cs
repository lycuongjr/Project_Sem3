using HTM.Mgs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTM.Mgs.Service
{
    public class NhomQuyenSuDungService : BaseService<NhomQuyenSuDung, HTMDb>
    {
        public IEnumerable<NhomQuyenSuDung> DSQuyen()
        {
            var list = dbContext.NhomQuyenSuDungs.AsQueryable();
            return list.OrderBy(x => x.NhomQuyenSuDungID);
        }
    }
}
