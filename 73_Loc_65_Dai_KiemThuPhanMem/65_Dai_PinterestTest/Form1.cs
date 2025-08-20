using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace _65_Dai_PinterestTest
{
    public partial class PinterestTest_65_Dai : Form
    {
        public PinterestTest_65_Dai()
        {
            InitializeComponent();
        }

        // 65_Dai: CHỨC NĂNG TÌM KIẾM VÀ TRUY CẬP VÀO ẢNH
        private void Dai_65_btnNavigate_Click(object sender, EventArgs e)
        {
            // 65_Dai: Điều hướng trình duyệt
            IWebDriver driver_65_Dai = new ChromeDriver();
            driver_65_Dai.Navigate().GoToUrl("https://www.pinterest.com/login/");

            // 65_Dai: Đăng nhập vào trang web:
            string email = "hunghuongminhdai@gmail.com";
            string password = "1234khanhhung";
            // Điền email
            var emailField = driver_65_Dai.FindElement(By.Id("email"));
            emailField.SendKeys(email);
            // Điền password
            var passwordField = driver_65_Dai.FindElement(By.Name("password"));
            passwordField.SendKeys(password);
            // Ấn nút login
            var submitBtn = driver_65_Dai.FindElement(By.CssSelector("#mweb-unauth-container > div > div:nth-child(3) > div > div > div.KS5.jzS.un8.C9i.TB_ > div:nth-child(1) > form > div.qGb.zI7.iyn.Hsu > button > div"));
            submitBtn.Click();


            // 65_Dai: Nhập liệu Tìm kiếm
            Thread.Sleep(7000); //Đợi 10 giây trước khi tìm kiếm
            IWebElement searchBox_65_Dai = driver_65_Dai.FindElement(By.XPath("//*[@id=\"searchBoxContainer\"]/div/div/div[2]/input"));
            searchBox_65_Dai.SendKeys("Fujii Kaze");
            searchBox_65_Dai.SendKeys(OpenQA.Selenium.Keys.Enter);

            // 65_Dai: Sau khi tìm kiếm, truy cập vào 1 ảnh đầu tiên xuất hiện
            Thread.Sleep(5000); //Đợi 5 giây trước khi truy cập
            IWebElement access_65_Dai = driver_65_Dai.FindElement(By.XPath("//*[@id=\"__PWS_ROOT__\"]/div/div/div[1]/div/div[2]/div/div/div[4]/div/div/div/div/div[2]/div/div/div/div[1]/div[1]/div/div/div/div/div/div/div/div[1]/a/div/div[1]/div/div/div/div/div/div/div/img"));
            access_65_Dai.Click();

            // 65_Dai: Sau khi truy cập vào ảnh, thực hiện post bình luận trên ảnh:
            Thread.Sleep(3000);
            IWebElement comment_65_Dai = driver_65_Dai.FindElement(By.XPath("//*[@id=\"dweb-comment-editor-container\"]/div/div[2]/div/div/div/div"));
            comment_65_Dai.SendKeys("Love you Fujii Kaze !!!");
            Thread.Sleep(3000);
            IWebElement post_comment_65_Dai = driver_65_Dai.FindElement(By.XPath("//*[@id=\"gradient\"]/div/div/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div[2]/div/button"));
            post_comment_65_Dai.Click();

        }

        private void Dai_65_btnNavigate2_Click(object sender, EventArgs e)
        {
            // 65_Dai: Điều hướng trình duyệt
            IWebDriver driver_65_Dai = new ChromeDriver();
            driver_65_Dai.Navigate().GoToUrl("https://www.pinterest.com/login/");

            // 65_Dai: Đăng nhập vào trang web:
            string email = "hunghuongminhdai@gmail.com";
            string password = "1234khanhhung";
            // Điền email
            var emailField = driver_65_Dai.FindElement(By.Id("email"));
            emailField.SendKeys(email);
            // Điền password
            var passwordField = driver_65_Dai.FindElement(By.Name("password"));
            passwordField.SendKeys(password);
            // Ấn nút login
            var submitBtn = driver_65_Dai.FindElement(By.CssSelector("#mweb-unauth-container > div > div:nth-child(3) > div > div > div.KS5.jzS.un8.C9i.TB_ > div:nth-child(1) > form > div.qGb.zI7.iyn.Hsu > button > div"));
            submitBtn.Click();

            // 65_Dai: CHỨC NĂNG UPLOAD ẢNH LÊN PINTEREST
            Thread.Sleep(3000);
            driver_65_Dai.Navigate().GoToUrl("https://www.pinterest.com/pin-creation-tool/");
            Thread.Sleep(3000);
            IWebElement upload_65_Dai = driver_65_Dai.FindElement(By.XPath("//*[@id=\"storyboard-upload-input\"]"));
            upload_65_Dai.SendKeys(@"C:\\Users\\ASUS\\Downloads\\fujiikaze.jpg");

            // 65_Dai: Sau khi đã upload ảnh, tiến hành fill các ô mô tả, tiêu đề cần thiết và đăng
            Thread.Sleep(5000); // đợi 5 giây trước khi fill
            IWebElement title_65_Dai = driver_65_Dai.FindElement(By.XPath("//*[@id=\"storyboard-selector-title\"]"));
            title_65_Dai.SendKeys("Fujii Kaze");
            Thread.Sleep(2000);
            IWebElement upload_btn_65_Dai = driver_65_Dai.FindElement(By.XPath("//*[@id=\"__PWS_ROOT__\"]/div/div/div[1]/div/div[2]/div/div/div/div[2]/div[2]/div/div/div[1]/div[2]/div[2]/div/button"));
            upload_btn_65_Dai.Click();
        }
    }
}
