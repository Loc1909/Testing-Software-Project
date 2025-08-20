using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HePTBac2_73_Loc_65_Dai.HePTBac2_Functions_73_Loc_65_Dai;

namespace HePTBac2_73_Loc_65_Dai
{
    public partial class HePhuongTrinh_73_Loc_65_Dai : Form
    {
        public HePhuongTrinh_73_Loc_65_Dai()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // 73_Loc_65_Dai: CHỨC NĂNG 2 - GỌI THỰC THI CÁC HÀM VALIDATE CÁC SỐ ĐẦU VÀO
        private void btnValidate_73_Loc_65_Dai_Click(object sender, EventArgs e)
        {
            HePTBac2_Functions_73_Loc_65_Dai coefficients = new HePTBac2_Functions_73_Loc_65_Dai();
            txtBox_KQValidate_73_Loc_65_Dai.Text = coefficients.ValidateInput_73_Loc_65_Dai(
                txtBox_a1_73_Loc_65_Dai.Text, txtBox_b1_73_Loc_65_Dai.Text,
                txtBox_c1_73_Loc_65_Dai.Text, txtBox_d1_73_Loc_65_Dai.Text,
                txtBox_a2_73_Loc_65_Dai.Text, txtBox_b2_73_Loc_65_Dai.Text,
                txtBox_c2_73_Loc_65_Dai.Text, txtBox_d2_73_Loc_65_Dai.Text);
        }

        // 73_Loc_65_Dai: CHỨC NĂNG 1 - GỌI THỰC THI HÀM SOLVE CÁC SỐ ĐẦU VÀO
        private void btn_Solve_73_Loc_65_Dai_Click(object sender, EventArgs e)
        {
            if (txtBox_KQValidate_73_Loc_65_Dai.Text.Equals("Hệ phương trình hợp lệ!!"))
            {

                double a1 = double.Parse(txtBox_a1_73_Loc_65_Dai.Text);
                double b1 = double.Parse(txtBox_b1_73_Loc_65_Dai.Text);
                double c1 = double.Parse(txtBox_c1_73_Loc_65_Dai.Text);
                double d1 = double.Parse(txtBox_d1_73_Loc_65_Dai.Text);
                double a2 = double.Parse(txtBox_a2_73_Loc_65_Dai.Text);
                double b2 = double.Parse(txtBox_b2_73_Loc_65_Dai.Text);
                double c2 = double.Parse(txtBox_c2_73_Loc_65_Dai.Text);
                double d2 = double.Parse(txtBox_d2_73_Loc_65_Dai.Text);

                // 73_Loc_65_Dai: Tính toán kết quả hệ phương trình
                HePTBac2_Functions_73_Loc_65_Dai coefficients = new HePTBac2_Functions_73_Loc_65_Dai();
                var result = coefficients.Solve_73_Loc_65_Dai(a1, b1, c1, d1, a2, b2, c2, d2);

                // 73_Loc_65_Dai: Hiển thị loại nghiệm và nghiệm
                string loaiNghiem_73_Loc_65_Dai = "";
                string nghiemText_73_Loc_65_Dai = "";
                switch (result.Type)
                {
                    case SolutionType.Unique:
                        loaiNghiem_73_Loc_65_Dai = "Nghiệm duy nhất";
                        nghiemText_73_Loc_65_Dai = $"({result.Solutions[0].x:F2}, {result.Solutions[0].y:F2})";
                        break;
                    case SolutionType.Infinite:
                        loaiNghiem_73_Loc_65_Dai = "Vô số nghiệm";
                        nghiemText_73_Loc_65_Dai = $"Ví dụ: ({result.Solutions[0].x:F2}, {result.Solutions[0].y:F2}) và " +
                                     $"({result.Solutions[1].x:F2}, {result.Solutions[1].y:F2})";
                        break;
                    case SolutionType.NoSolution:
                        loaiNghiem_73_Loc_65_Dai = "Vô nghiệm";
                        nghiemText_73_Loc_65_Dai = "Không có nghiệm";
                        break;
                    case SolutionType.Multiple:
                        loaiNghiem_73_Loc_65_Dai = "Hai nghiệm";
                        nghiemText_73_Loc_65_Dai = $"({result.Solutions[0].x:F2}, {result.Solutions[0].y:F2}) và " +
                                                    $"({result.Solutions[1].x:F2}, {result.Solutions[1].y:F2})";
                        break;
                    case SolutionType.DegenerateUnique:
                        loaiNghiem_73_Loc_65_Dai = "Hệ thoái hóa nghiệm duy nhất";
                        nghiemText_73_Loc_65_Dai = $"({result.Solutions[0].x:F2}, {result.Solutions[0].y:F2})";
                        break;
                    case SolutionType.DegenerateMultiple:
                        loaiNghiem_73_Loc_65_Dai = "Hệ thoái hóa hai nghiệm";
                        nghiemText_73_Loc_65_Dai = $"({result.Solutions[0].x:F2}, {result.Solutions[0].y:F2}) và " +
                                                    $"({result.Solutions[1].x:F2}, {result.Solutions[1].y:F2})";
                        break;
                }

                txtBox_Nghiem_73_Loc_65_Dai.Text = nghiemText_73_Loc_65_Dai;
                txtBox_LoaiNghiem_73_Loc_65_Dai.Text = loaiNghiem_73_Loc_65_Dai;
            }
            else
            {
                txtBox_Nghiem_73_Loc_65_Dai.Text = "Hệ phương trình chưa hợp lệ!!";
            }
        }
    }
}
