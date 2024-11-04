using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfArraylist_BusinessObject;
using WpfArraylist_Service;

namespace WpfArrayList
{
    public partial class MainWindow : Window
    {
        private SinhVienService sinhVienService = new SinhVienService();
        private ArrayList sinhVienList = new ArrayList();

        public MainWindow()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            sinhVienList = sinhVienService.GetAllStudents();
            listBoxSinhVien.Items.Clear();
            foreach (SinhVien sv in sinhVienList)
            {
                listBoxSinhVien.Items.Add(sv);
            }
        }
       
        private void Read_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxSinhVien.SelectedItem != null)
            {
                SinhVien selectedStudent = (SinhVien)listBoxSinhVien.SelectedItem;
                txtId.Text = selectedStudent.Id.ToString();
                txtName.Text = selectedStudent.Name;
                txtAge.Text = selectedStudent.Age.ToString();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAge.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các thông tin");
                return;
            }
            if (!int.TryParse(txtId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("ID phải là số nguyên.");
                return;
            }
            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Tuổi phải là số nguyên.");
                return;
            }
            string name = txtName.Text;
            foreach (SinhVien sv in sinhVienList)
            {
                if (sv.Id == id)
                {
                    MessageBox.Show("ID đã tồn tại. Vui lòng nhập ID khác.");
                    return;
                }
            }
            SinhVien newStudent = new SinhVien { Id = id, Name = name, Age = age };
            sinhVienService.AddStudent(newStudent);
            LoadStudents();
            ClearFields();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxSinhVien.SelectedItem != null)
            {
                if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAge.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ các thông tin");
                    return;
                }

                if (!int.TryParse(txtId.Text, out int id) || id <= 0)
                {
                    MessageBox.Show("ID phải là số nguyên.");
                    return;
                }
                if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
                {
                    MessageBox.Show("Tuổi phải là số nguyên.");
                    return;
                }
                string name = txtName.Text;
                SinhVien selectedStudent = (SinhVien)listBoxSinhVien.SelectedItem;
                foreach (SinhVien sv in sinhVienList)
                {
                    if (sv.Id == id && sv.Id != selectedStudent.Id)
                    {
                        MessageBox.Show("ID đã tồn tại. Vui lòng nhập ID khác.");
                        return;
                    }
                }
                SinhVien updatedStudent = new SinhVien { Id = id, Name = name, Age = age };
                sinhVienService.UpdateStudent(updatedStudent);
                LoadStudents();
                ClearFields();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxSinhVien.SelectedItem != null)
            {
                SinhVien selectedStudent = (SinhVien)listBoxSinhVien.SelectedItem;
                sinhVienService.DeleteStudent(selectedStudent.Id);
                LoadStudents();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtId.Text = "ID";
            txtName.Text = "Name";
            txtAge.Text = "Age";
        }
    }
}
