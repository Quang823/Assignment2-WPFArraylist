using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using WpfArraylist_BusinessObject;
using WpfArraylist_Repo;

namespace WpfArraylist_Service
{
    public class SinhVienService
    {
        private SinhVienRepo repository = new SinhVienRepo();

        public void AddStudent(SinhVien sv)
        {
            repository.Add(sv);
        }

        public ArrayList GetAllStudents()
        {
            return repository.GetAll();
        }

        public void UpdateStudent(SinhVien sv)
        {
            repository.Update(sv);
        }

        public void DeleteStudent(int id)
        {
            repository.Delete(id);
        }
    }

}
