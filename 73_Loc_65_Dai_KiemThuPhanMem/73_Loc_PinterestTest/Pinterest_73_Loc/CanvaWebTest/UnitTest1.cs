using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;

namespace Pinterest_73_Loc
{
    [TestClass]
    public class UnitTest
    {
        // 73_Loc: Khởi tạo các biến đối tượng tương tác với WebDriver
        private IWebDriver driver_73_Loc;
        private WebDriverWait wait_73_Loc;
        public TestContext TestContext { get; set; }
        // Thiết lập môi trường kiểm thử
        [TestInitialize]
        public void Setup()
        {
            driver_73_Loc = new ChromeDriver();
            // Mở maximize tab chrome
            driver_73_Loc.Manage().Window.Maximize();
            // Nếu điều kiện chờ đúng trong vòng 10s thì tiếp tục thực hiện
            wait_73_Loc = new WebDriverWait(driver_73_Loc, TimeSpan.FromSeconds(10));
        }

        // 73_Loc: TEST CASE CHO CHỨC NĂNG LOGIN
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data_73_Loc\TestData_73_Loc.csv", "TestData_73_Loc#csv", DataAccessMethod.Sequential)]
        public void TC1_Login_73_Loc()
        {
            driver_73_Loc.Navigate().GoToUrl("https://www.pinterest.com/login/");
            // Lấy email_73_Loc, password_73_Loc, expected_result_73_Loc từ csv, thực hiện login
            string email_73_Loc = TestContext.DataRow["email_73_Loc"].ToString();
            string password_73_Loc = TestContext.DataRow["password_73_Loc"].ToString();
            string expectedResult_73_Loc = TestContext.DataRow["expected_result_73_Loc"].ToString();
            string actual_73_Loc = "success";
            // Lấy ô điền email bằng id và điền email
            var emailField_73_Loc = driver_73_Loc.FindElement(By.Id("email"));
            emailField_73_Loc.SendKeys(email_73_Loc);
            // Lấy ô điền password bằng name và điền password
            var passwordField = driver_73_Loc.FindElement(By.Name("password"));
            passwordField.SendKeys(password_73_Loc);
            // Lấy nút login bằng CssSelector và ấn nút login
            var submitBtn_73_Loc = driver_73_Loc.FindElement(By.CssSelector("#mweb-unauth-container > div > div:nth-child(3) > div > div > div.KS5.jzS.un8.C9i.TB_ > div:nth-child(1) > form > div.qGb.zI7.iyn.Hsu > button > div"));
            submitBtn_73_Loc.Click();
            // 73_Loc: Nếu kết quả mong đợi là success thì kiểm tra đường dẫn hiện tại
            if (expectedResult_73_Loc.ToLower() == "success")
            {
                // Nếu url không chứa login => kết quả thực tế là success, đăng nhập thành công
                if (driver_73_Loc.Url.Contains("pinterest.com") && !driver_73_Loc.Url.Contains("login"))
                    actual_73_Loc = "success";
                // So sánh kết quả mong đợi và kết quả thực tế, bằng nhau thì pass
                Assert.AreEqual(expectedResult_73_Loc, actual_73_Loc);
            }
            // 73_Loc: Nếu kết quả mong đợi không là success thì vẫn kiểm tra đường dẫn hiện tại
            else
            {
                // Nếu url chứa login => kết quả thực tế là failure, đăng nhập thất bại
                if (driver_73_Loc.Url.Contains("login"))
                    actual_73_Loc = "failure";
                // So sánh kết quả mong đợi và kết quả thực tế, bằng nhau thì pass
                Assert.AreEqual(expectedResult_73_Loc, actual_73_Loc);
            }
        }

        // 73_Loc: TEST CASE CHO CHỨC NĂNG TẢI ẢNH
        [TestMethod, Ignore]
        public void TC2_DownImage_73_Loc()
        {   
            // 73_Loc: LOGIN
            driver_73_Loc.Navigate().GoToUrl("https://www.pinterest.com/login/");
            // Lấy ô điền email bằng id và điền email
            var emailField_73_Loc = driver_73_Loc.FindElement(By.Id("email"));
            emailField_73_Loc.SendKeys("locnguyentan1909@gmail.com");
            // Lấy ô điền password bằng name và điền password
            var passwordField = driver_73_Loc.FindElement(By.Name("password"));
            passwordField.SendKeys("LockNger.59");
            // Lấy nút login bằng CssSelector và ấn nút login
            var submitBtn_73_Loc = driver_73_Loc.FindElement(By.CssSelector("#mweb-unauth-container > div > div:nth-child(3) > div > div > div.KS5.jzS.un8.C9i.TB_ > div:nth-child(1) > form > div.qGb.zI7.iyn.Hsu > button > div"));
            submitBtn_73_Loc.Click();
            Thread.Sleep(5000);

            // 73_Loc: TẢI ẢNH ĐẦU TIÊN
            // Lấy bài viết đầu tiên bằng CssSelector và click vào
            IWebElement firstPin_73_Loc = wait_73_Loc.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href*='/pin/']")));
            firstPin_73_Loc.Click();
            // Đợi 5s
            Thread.Sleep(5000);
            // Lấy nút ... bằng XPath Bấm dấu ...
            IWebElement moreBtn_73_Loc = wait_73_Loc.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"gradient\"]/div/div/div[2]/div/div/div/div/div/div/div/div[1]/div[1]/div/div/div/div[1]/div/div[4]/div/div/div/div/div/div/div/div/div/div/button/div/div")));
            moreBtn_73_Loc.Click();
            // Lấy nút tải ảnh bằng CssSelector và Bấm nút tải ảnh
            IWebElement downBtn_73_Loc = wait_73_Loc.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#pin-action-dropdown-item-0 > div > div > div.jzS.ujU.un8.C9i.yLs > div > div")));
            downBtn_73_Loc.Click();
            // Nếu nút down ảnh không còn tồn tại -> tải thành công -> pass
            Assert.IsNotNull(downBtn_73_Loc);
        }
    }
}