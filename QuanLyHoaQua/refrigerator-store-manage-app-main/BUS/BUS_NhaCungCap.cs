using DAL;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_NhaCungCap
    {

        DAL_NhaCungCap dal_daych = new DAL_NhaCungCap();
       
        public DataTable getData()
        {
            return dal_daych.getData();
        }
        public int kiemtramatrung(string ma)
        {
            return dal_daych.kiemtramatrung(ma);
        }
        public bool ThemNCC(NhaCungCap kh)
        {
            return dal_daych.ThemNCC(kh);
        }
        public bool SuaNCC(NhaCungCap kh)
        {
            return dal_daych.SuaNCC(kh);
        }
        public bool XoaNCC(string ma)
        {
            return dal_daych.XoaNCC(ma);
        }
        public string valuecbbNCC(string ma)
        {
            return dal_daych.valuecbbNCC(ma);
        }
    }
}
