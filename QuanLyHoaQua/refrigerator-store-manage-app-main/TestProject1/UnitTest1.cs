using NUnit.Framework;
using DAL;
using Entities;
using System.Data;

namespace TestProject
{
    [TestFixture]
    public class DAL_LoaiSanPhamTests
    {
        private DAL_LoaiSanPham dalLoaiSanPham;

        [SetUp]
        public void Setup()
        {
            dalLoaiSanPham = new DAL_LoaiSanPham();
        }

        [Test]
        public void GetData_ReturnsDataTable()
        {
            DataTable result = dalLoaiSanPham.getData();

            Assert.IsNotNull(result);
            // Add additional assertions based on the expected data in the DataTable
        }

        //[Test]
        //public void KiemTraMaTrung_ValidMa_ReturnsCount()
        //{
        //    string maLoaiSanPham = "LSP001";

        //    int result = dalLoaiSanPham.kiemtramatrung(maLoaiSanPham);

        //    Assert.AreEqual(1, result);
        //}
    

        [Test]
        public void LoadCbbDCH_ValidMa_ReturnsTenLoaiSanPham()
        {
            string maLoaiSanPham = "LSP001";

            string result = dalLoaiSanPham.loadcbbDCH(maLoaiSanPham);

            Assert.IsNotNull(result);
            // Add additional assertions based on the expected value of TenLoaiSanPham
        }
    }
    public class LoginTests
    {
        [Test]
        public void DangNhap_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            string username = "admin";
            string password = "password";
            bool expected = true;

            // Act
            bool actual = MVVA(username, password);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DangNhap_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            string username = "invalid";
            string password = "wrongpassword";
            bool expected = false;

            // Act
            bool actual = MVVA(username, password);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // Thay thế điều này bằng chức năng đăng nhập thực tế của bạn
        private bool MVVA(string username, string password)
        {
            // Triển khai logic đăng nhập của bạn tại đây
            // Trả về true nếu thông tin xác thực hợp lệ, ngược lại là false

            if (username == "admin" && password == "password")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
//ThanhLan oi toi lam 5 cai nhe co mot cai bi lỗi là xược rồi đấy để cai đấy cho có 1 cái sai chạy ở cái test bên cạnh cái debug ý xong bấm cái dòng đầu tiên run nhe nếu muốn thêm test thì bảo ánh với ly nt cho t nheee

