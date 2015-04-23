using Core.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class LoaiGiayChungNhanModel : Model
    {
        private readonly LoaiGiayChungNhan loaiGCN;

        public LoaiGiayChungNhanModel(LoaiGiayChungNhan loaiGCN)
        {
            if (loaiGCN == null)
            {
                throw new ArgumentNullException("Loai GCN");
            }

            this.loaiGCN = loaiGCN;
        }

        public LoaiGiayChungNhan LoaiGiayChungNhan { get { return loaiGCN; } }
    }
}
