using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using WpfArraylist_BusinessObject;

namespace WpfArraylist_DAO
{
    public class SinhVienDAO
    {
        private ArrayList danhSachSinhVien = new ArrayList();

        public void Add(SinhVien sv)
        {
            danhSachSinhVien.Add(sv);
        }

        public ArrayList GetAll()
        {
            return danhSachSinhVien;
        }

        public void Update(SinhVien sv)
        {
            for (int i = 0; i < danhSachSinhVien.Count; i++)
            {
                SinhVien currentSv = (SinhVien)danhSachSinhVien[i];
                if (currentSv.Id == sv.Id)
                {
                    danhSachSinhVien[i] = sv;
                    break;
                }
            }
        }

        public void Delete(int id)
        {
            for (int i = 0; i < danhSachSinhVien.Count; i++)
            {
                SinhVien currentSv = (SinhVien)danhSachSinhVien[i];
                if (currentSv.Id == id)
                {
                    danhSachSinhVien.RemoveAt(i);
                    break;
                }
            }
        }
    }

}
