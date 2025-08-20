using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HePTBac2_73_Loc_65_Dai
{
    public class HePTBac2_Functions_73_Loc_65_Dai
    {
        private double a1, b1, c1, d1, a2, b2, c2, d2;
        // 73_Loc_65_Dai: Operator --> phương thức khởi tạo
        public HePTBac2_Functions_73_Loc_65_Dai(double a1, double b1, double c1, double d1, double a2, double b2, double c2, double d2)
        {
            this.a1 = a1;
            this.b1 = b1;
            this.c1 = c1;
            this.d1 = d1;
            this.a2 = a2;
            this.b2 = b2;
            this.c2 = c2;
            this.d2 = d2;
        }

        // 73_Loc_65_Dai: Operator --> phương thức khởi tạo
        public HePTBac2_Functions_73_Loc_65_Dai()
        {

        }

        // 73_Loc_65_Dai: CHỨC NĂNG 2 --> KIỂM TRA DỮ LIỆU ĐẦU VÀO
        public string  ValidateInput_73_Loc_65_Dai(string a1, string b1, string c1, string d1, string a2, string b2, string c2, string d2)
        {
            double numA1, numB1, numC1, numD1, numA2, numB2, numC2, numD2;

            // Kiểm tra nếu có bất kỳ giá trị nào không thể chuyển đổi sang số
            if (!double.TryParse(a1, out numA1) || !double.TryParse(b1, out numB1) ||
                !double.TryParse(c1, out numC1) || !double.TryParse(d1, out numD1) ||
                !double.TryParse(a2, out numA2) || !double.TryParse(b2, out numB2) ||
                !double.TryParse(c2, out numC2) || !double.TryParse(d2, out numD2))
            {
                return "Lỗi: Vui lòng nhập số hợp lệ!";
            }

            // Kiểm tra hệ số có phải là số hợp lệ không (không phải NaN hoặc Infinity)
            double[] coefficients = { numA1, numB1, numC1, numD1, numA2, numB2, numC2, numD2 };
            foreach (var coef in coefficients)
            {
                if (double.IsNaN(coef) || double.IsInfinity(coef))
                {
                    return "Hệ phương trình KHÔNG hợp lệ!! (Có hệ số không hợp lệ)";
                }
            }

            // Kiểm tra nếu cả hai hệ số c1 và c2 đều bằng 0 (không có biến y)
            if (numC1 == 0 && numC2 == 0)
            {
                return "Hệ phương trình KHÔNG hợp lệ!! (Cả hai phương trình không chứa biến y)";
            }

            return "Hệ phương trình hợp lệ!!";
        }

        // 73_Loc_65_Dai: CHỨC NĂNG 1 --> TÍNH HỆ PHƯƠNG TRÌNH BẬC 2
        // 73_Loc_65_Dai: ĐỊNH NGHĨA CÁC LOẠI NGHIỆM
        public enum SolutionType
        {
            Unique,    // Nghiệm duy nhất
            Infinite, // Vô số nghiệm
            NoSolution,        // Vô nghiệm
            Multiple,      // Hai nghiệm
            DegenerateUnique,         // Thoái hóa khớp 1 nghiệm
            DegenerateMultiple      // still thoái hóa khớp nhưng 2 nghiệm
        }

        private const double EPSILON = 1e-10; // Ngưỡng sai số cho số thực

        // 73_Loc_65_Dai: Định nghĩa struct chứa kết quả
        public struct SolutionResult
        {
            public SolutionType Type { get; set; }
            public List<(double x, double y)> Solutions { get; set; }

            public SolutionResult(SolutionType type, List<(double x, double y)> solutions = null)
            {
                Type = type;
                Solutions = solutions ?? new List<(double x, double y)>();
            }
        }

        public SolutionResult Solve_73_Loc_65_Dai(double a1, double b1, double c1, double d1,
                                                double a2, double b2, double c2, double d2)
        {
            var solutions = new List<(double x, double y)>();

            // 73_Loc_65_Dai: Kiểm tra thoái hóa
            if (Math.Abs(a1) < EPSILON && Math.Abs(a2) < EPSILON) // 73_Loc_65_Dai: Cả hai phương trình thoái hóa
            {
                return GiaiPhuongTrinhTuyenTinh_73_Loc_65_Dai(b1, c1, d1, b2, c2, d2);
            }
            else if (Math.Abs(a2) == 0) // 73_Loc_65_Dai: Phương trình 2 thoái hóa
            {
                return GiaiPhuongTrinhThoaiHoa_73_Loc_65_Dai(a1, b1, c1, d1, b2, c2, d2);

            }
            else if (Math.Abs(a1) == 0) // 73_Loc_65_Dai: Phương trình 1 thoái hóa
            {
                return GiaiPhuongTrinhThoaiHoa_73_Loc_65_Dai(a2, b2, c2, d2, b1, c1, d1);
            }

            double A = a1 * c2 - a2 * c1;
            double B = b1 * c2 - b2 * c1;
            double C = d1 * c2 - d2 * c1;

            // 73_Loc_65_Dai: Giải phương trình bậc 2: A*x^2 + B*x + C = 0
            double delta = B * B - 4 * A * C;
            if (Math.Abs(A) < EPSILON)
            {
                if (Math.Abs(B) < EPSILON)
                {
                    if (Math.Abs(C) < EPSILON)
                    {
                        solutions.Add((0, -d1 / c1));
                        solutions.Add((1, -(a1 + b1 + d1) / c1));
                        return new SolutionResult(SolutionType.Infinite, solutions);  // 65_Dai: Vô số nghiệm
                    }
                    return new SolutionResult(SolutionType.NoSolution, solutions); // 73_Loc: Vô nghiệm
                }
                double x = -C / B;
                double y = -(a1 * x * x + b1 * x + d1) / c1;
                solutions.Add((x, y));
                return new SolutionResult(SolutionType.Unique, solutions); // 73_Loc: Nghiệm duy nhất
            }

            if (delta < -EPSILON)
            {
                return new SolutionResult(SolutionType.NoSolution, solutions); // 73_Loc: Vô nghiệm
            }
            else if (Math.Abs(delta) < EPSILON)
            {
                double x = -B / (2 * A);
                double y = -(a1 * x * x + b1 * x + d1) / c1;
                solutions.Add((x, y));
                return new SolutionResult(SolutionType.Unique, solutions); //73_Loc: Nghiệm duy nhất
            }
            else
            {
                double x1 = (-B + Math.Sqrt(delta)) / (2 * A);
                double y1 = -(a1 * x1 * x1 + b1 * x1 + d1) / c1;
                solutions.Add((x1, y1));

                double x2 = (-B - Math.Sqrt(delta)) / (2 * A);
                double y2 = -(a1 * x2 * x2 + b1 * x2 + d1) / c1;
                solutions.Add((x2, y2));
                return new SolutionResult(SolutionType.Multiple, solutions); // 65_Dai: Hai nghiệm
            }
        }

        // 73_Loc_65_Dai: Hệ 2 phương trình thoái hóa
        private SolutionResult GiaiPhuongTrinhTuyenTinh_73_Loc_65_Dai(double b1, double c1, double d1,
                                                            double b2, double c2, double d2)
        {
            var solutions = new List<(double x, double y)>();
            double det = b1 * c2 - b2 * c1;

            if (Math.Abs(det) < EPSILON)
            {
                if (Math.Abs(b1 * d2 - b2 * d1) < EPSILON && Math.Abs(c1 * d2 - c2 * d1) < EPSILON)
                {
                    // 65_Dai: Vô số nghiệm
                    solutions.Add((0, -d1 / c1));
                    solutions.Add((1, -(b1 + d1) / c1));
                    return new SolutionResult(SolutionType.Infinite, solutions);
                }
                return new SolutionResult(SolutionType.NoSolution); // 73_Loc: Vô nghiệm
            }

            // 73_Loc: Nghiệm duy nhất
            double x = (c1 * d2 - c2 * d1) / det;
            double y = (b2 * d1 - b1 * d2) / det;
            solutions.Add((x, y));
            if (Math.Abs(a2) == 0 && Math.Abs(a1) ==0)
            {
                return new SolutionResult(SolutionType.DegenerateUnique, solutions); // 65_Dai: Thoái hóa + Nghiệm duy nhất
            }
            return new SolutionResult(SolutionType.Unique, solutions);
        }

        // 73_Loc_65_Dai: 1 phương trình thoái hóa (a1 == 0 hoặc a2 == 0)
        private SolutionResult GiaiPhuongTrinhThoaiHoa_73_Loc_65_Dai(double a1, double b1, double c1, double d1,
                                                                double b2, double c2, double d2)
        {
            var solutions = new List<(double x, double y)>();

            // 73_Loc_65_Dai: Phương trình 2: b2*x + c2*y + d2 = 0
            if (Math.Abs(c2) < EPSILON)
            {
                if (Math.Abs(b2) < EPSILON)
                {
                    if (Math.Abs(d2) < EPSILON)
                    {
                        // 73_Loc_65_Dai: Giải phương trình 1: a1*x^2 + b1*x + c1*y + d1 = 0
                        solutions.Add((0, -d1 / c1));
                        solutions.Add((1, -(a1 + b1 + d1) / c1));
                        return new SolutionResult(SolutionType.Infinite, solutions); // 65_Dai: Vô số nghiệm
                    }
                    return new SolutionResult(SolutionType.NoSolution); // 73_Loc: Vô nghiệm
                }
                double x = -d2 / b2;
                double y = -(a1 * x * x + b1 * x + d1) / c1;
                solutions.Add((x, y));
                return new SolutionResult(SolutionType.DegenerateUnique, solutions); // 65_Dai: Thoái hóa khớp + Nghiệm duy nhất
            }

            //  73_Loc_65_Dai
            // Giải y từ phương trình 2: y = -(b2*x + d2)/c2
            // Thay vào phương trình 1: a1*x^2 + b1*x + c1*(-(b2*x + d2)/c2) + d1 = 0
            double A = a1;
            double B = b1 - c1 * b2 / c2;
            double C = d1 - c1 * d2 / c2;

            double delta = B * B - 4 * A * C;
            if (delta < -EPSILON) return new SolutionResult(SolutionType.NoSolution); // 73_Loc: Vô nghiệm
            if (Math.Abs(delta) < EPSILON) // 65_Dai: Thoái hóa khớp + Nghiệm duy nhất
            {
                double x = -B / (2 * A);
                double y = -(b2 * x + d2) / c2;
                solutions.Add((x, y));
                return new SolutionResult(SolutionType.DegenerateUnique, solutions);
            }
            else // 73_Loc: Thoái hóa + Hai nghiệm
            {
                double x1 = (-B + Math.Sqrt(delta)) / (2 * A);
                double y1 = -(b2 * x1 + d2) / c2;
                solutions.Add((x1, y1));

                double x2 = (-B - Math.Sqrt(delta)) / (2 * A);
                double y2 = -(b2 * x2 + d2) / c2;
                solutions.Add((x2, y2));
                return new SolutionResult(SolutionType.DegenerateMultiple, solutions);
            }
        }
    }
}
