using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HePTBac2_73_Loc_65_Dai;
using static HePTBac2_73_Loc_65_Dai.HePTBac2_Functions_73_Loc_65_Dai;

namespace HePTBac2_Test_73_Loc_65_Dai
{
    [TestClass]
    public class UnitTest1
    {
        private HePTBac2_Functions_73_Loc_65_Dai res_73_Loc_65_Dai;
        [TestInitialize]
        public void SetUp()
        {
            res_73_Loc_65_Dai = new HePTBac2_Functions_73_Loc_65_Dai();
        }

        // TestContext_73_Loc_65_Dai
        public TestContext TestContext { get; set; }

        // 73_Loc_65_Dai
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
           @".\TestData_73_Loc_65_Dai\DataChucNang1_73_Loc_65_Dai.csv", "DataChucNang1_73_Loc_65_Dai#csv", DataAccessMethod.Sequential)]
        public void TestChucNang1_Solve_73_Loc_65_Dai()
        {
            double a1_73_Loc_65_Dai = Double.Parse(TestContext.DataRow[0].ToString());
            double b1_73_Loc_65_Dai = Double.Parse(TestContext.DataRow[1].ToString());
            double c1_73_Loc_65_Dai = Double.Parse(TestContext.DataRow[2].ToString());
            double d1_73_Loc_65_Dai = Double.Parse(TestContext.DataRow[3].ToString());
            double a2_73_Loc_65_Dai = Double.Parse(TestContext.DataRow[4].ToString());
            double b2_73_Loc_65_Dai = Double.Parse(TestContext.DataRow[5].ToString());
            double c2_73_Loc_65_Dai = Double.Parse(TestContext.DataRow[6].ToString());
            double d2_73_Loc_65_Dai = Double.Parse(TestContext.DataRow[7].ToString());
            string expected_result_73_Loc_65_Dai = TestContext.DataRow[8].ToString();
            string expected_resultType_73_Loc_65_Dai = TestContext.DataRow[9].ToString();
            
            HePTBac2_Functions_73_Loc_65_Dai res_73_Loc_65_Dai = new HePTBac2_Functions_73_Loc_65_Dai();
            var actual_result_73_Loc_65_Dai = res_73_Loc_65_Dai.Solve_73_Loc_65_Dai(a1_73_Loc_65_Dai, b1_73_Loc_65_Dai, c1_73_Loc_65_Dai,
                                                                    d1_73_Loc_65_Dai, a2_73_Loc_65_Dai, b2_73_Loc_65_Dai,
                                                                    c2_73_Loc_65_Dai, d2_73_Loc_65_Dai);

            // 73_Loc_65_Dai: Chuyển Solutions thành chuỗi để so sánh
            string actualSolutionsString;
            switch (actual_result_73_Loc_65_Dai.Type)
            {
                case SolutionType.Unique:
                    actualSolutionsString = $"[({actual_result_73_Loc_65_Dai.Solutions[0].x:F2},{actual_result_73_Loc_65_Dai.Solutions[0].y:F2})]";
                    break;
                case SolutionType.Infinite:
                    actualSolutionsString = "[]";
                    break;
                case SolutionType.NoSolution:
                    actualSolutionsString = "[]";
                    break;
                case SolutionType.Multiple:
                    actualSolutionsString = $"[({actual_result_73_Loc_65_Dai.Solutions[0].x:F2},{actual_result_73_Loc_65_Dai.Solutions[0].y:F2})," +
                                            $"({actual_result_73_Loc_65_Dai.Solutions[1].x:F2},{actual_result_73_Loc_65_Dai.Solutions[1].y:F2})]";
                    break;
                case SolutionType.DegenerateUnique:
                    actualSolutionsString = $"[({actual_result_73_Loc_65_Dai.Solutions[0].x:F2},{actual_result_73_Loc_65_Dai.Solutions[0].y:F2})]";
                    break;
                case SolutionType.DegenerateMultiple:
                    actualSolutionsString = $"[({actual_result_73_Loc_65_Dai.Solutions[0].x:F2},{actual_result_73_Loc_65_Dai.Solutions[0].y:F2})," +
                                            $"({actual_result_73_Loc_65_Dai.Solutions[1].x:F2},{actual_result_73_Loc_65_Dai.Solutions[1].y:F2})]";
                    break;
                default:
                    actualSolutionsString = "";
                    break;
            }
            // 73_Loc_65_Dai: So sánh loại nghiệm
            Assert.AreEqual(expected_resultType_73_Loc_65_Dai, actual_result_73_Loc_65_Dai.Type.ToString(), "=== Loại nghiệm khớp ===");

            // 73_Loc_65_Dai: So sánh kết quả nghiệm
            Assert.AreEqual(expected_result_73_Loc_65_Dai, actualSolutionsString);
        }

        // 73_Loc_65_Dai: Unit Test Chức năng 2: Validate dữ liệu đầu vào
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
           @".\TestData_73_Loc_65_Dai\DataChucNang2_73_Loc_65_Dai.csv", "DataChucNang2_73_Loc_65_Dai#csv", DataAccessMethod.Sequential)]
        public void TestChucNang2_Solve_73_Loc_65_Dai()
        {
            string a1_73_Loc_65_Dai = (TestContext.DataRow[0].ToString());
            string b1_73_Loc_65_Dai = (TestContext.DataRow[1].ToString());
            string c1_73_Loc_65_Dai = (TestContext.DataRow[2].ToString());
            string d1_73_Loc_65_Dai = (TestContext.DataRow[3].ToString());
            string a2_73_Loc_65_Dai = (TestContext.DataRow[4].ToString());
            string b2_73_Loc_65_Dai = (TestContext.DataRow[5].ToString());
            string c2_73_Loc_65_Dai = (TestContext.DataRow[6].ToString());
            string d2_73_Loc_65_Dai = (TestContext.DataRow[7].ToString());
            string expected_result_73_Loc_65_Dai = (TestContext.DataRow[8].ToString());
            string actual_result_73_Loc_65_Dai = res_73_Loc_65_Dai.ValidateInput_73_Loc_65_Dai(a1_73_Loc_65_Dai, b1_73_Loc_65_Dai, c1_73_Loc_65_Dai,
                                                                    d1_73_Loc_65_Dai, a2_73_Loc_65_Dai, b2_73_Loc_65_Dai,
                                                                    c2_73_Loc_65_Dai, d2_73_Loc_65_Dai);
            // 73_Loc_65_Dai: Chuyển Solutions thành chuỗi để so sánh
            string actualSolutionsString;
            switch (actual_result_73_Loc_65_Dai)
            {
                case "Lỗi: Vui lòng nhập số hợp lệ!":
                    actualSolutionsString = "F";
                    break;
                case "Hệ phương trình KHÔNG hợp lệ!! (Có hệ số không hợp lệ)":
                    actualSolutionsString = "F";
                    break;
                case "Hệ phương trình KHÔNG hợp lệ!! (Cả hai phương trình không chứa biến y)":
                    actualSolutionsString = "F";
                    break; ;
                case "Hệ phương trình hợp lệ!!":
                    actualSolutionsString = "T";
                    break;
                default:
                    actualSolutionsString = "";
                    break;
            }
            Assert.AreEqual(expected_result_73_Loc_65_Dai, actualSolutionsString);
        }
    }
}
