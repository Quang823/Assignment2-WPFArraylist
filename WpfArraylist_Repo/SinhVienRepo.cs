using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using WpfArraylist_BusinessObject;
using WpfArraylist_DAO;

namespace WpfArraylist_Repo
{
    public class SinhVienRepo
    {
        private SinhVienDAO dao = new SinhVienDAO();

        public void Add(SinhVien sv)
        {
            dao.Add(sv);
        }

        public ArrayList GetAll()
        {
            return dao.GetAll();
        }

        public void Update(SinhVien sv)
        {
            dao.Update(sv);
        }

        public void Delete(int id)
        {
            dao.Delete(id);
        }
    }
}
