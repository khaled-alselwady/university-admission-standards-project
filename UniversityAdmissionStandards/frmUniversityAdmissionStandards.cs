using Guna.UI2.WinForms;
using System;
using System.Linq;
using System.Windows.Forms;
using UniversityAdmissionStandards_Business;

namespace UniversityAdmissionStandards
{
    public partial class frmUniversityAdmissionStandards : Form
    {
        public enum enCollege
        {
            All = -1,
            Engineering = 1,
            Pharmacy = 2,
            Business = 4,
            IT = 8,
            Law = 16,
            Sharia = 32,
            Sciences = 64,
            Psychological = 128,
            Aviation = 256
        };

        public enum enMajor
        {
            All = -1,
            Architecture = 524288,                    // هندسة العمارة
            CivilEngineering = 262144,                // الهندسة المدنية
            RenewableEnergyEngineering = 131072,      // هندسة الطاقة المتجددة
            Pharmacy = 65536,                         // صيدلة
            BusinessAdministration = 32768,           // إدارة الأعمال
            FinanceAndBanking = 16384,                // التمويل والمصارف
            Accounting = 8192,                        // المحاسبة
            ManagementInformationSystems = 4096,      // نظم المعلومات الإدارية
            DigitalMarketing = 2048,                  // التسويق الرقمي
            AccountingAndBusinessLaw = 1024,          // المحاسبة وقانون الأعمال
            HumanResourceManagement = 512,            // إدارة الموارد البشرية
            SoftwareEngineering = 256,                // هندسة البرمجيات
            CyberSecurity = 128,                      // الأمن السيبراني
            Law = 64,                                 // القانون
            Sharia = 32,                              // الشريعة
            EnglishLanguageAndTranslation = 16,       // اللغة الإنجليزية والترجمة
            Mathematics = 8,                          // الرياضيات
            SpecialEducation = 4,                     // التربية الخاصة
            AircraftMaintenance = 2,                  // صيانة الطائرات
            AviationElectronicsSciences = 1          // علوم إلكترونيات الطيران
        }

        public enum enBranchForMajor
        {
            Scientific = -1,
            PureScience = 65535,
            LiteraryAndSharia = 65535,
            HealthEducation = 65535,
            Informatics = 65535,
            Industrial_Old = 921999,
            CommercialHotelEconomics_Old = 65143,
            Agricultural_Old = 4495,
            Nursing = 4495,
            Industrial_New = 917899,
            HotelAndTourism_New = 65027,
            Economics_New = 7,
            Agricultural_New = 395
        };

        public enum enBranchForCollege
        {
            Scientific = -1,
            PureScience = 508,
            LiteraryAndSharia = 508,
            HealthEducation = 508,
            Informatics = 508,
            Industrial_Old = 461,
            CommercialHotelEconomics_Old = 500,
            Agricultural_Old = 460,
            Nursing = 460,
            Industrial_New = 329,
            HotelAndTourism_New = 260,
            Economics_New = 384,
            Agricultural_New = 328
        };

        public frmUniversityAdmissionStandards()
        {
            InitializeComponent();
        }

        private string _GetDiscountName()
        {
            float Rate = float.Parse(txtRate.Text.Trim());

            if (Rate >= 90)
                return "Discount 90 Plus";

            if (Rate >= 80 && Rate < 90)
                return "Discount >= 80 And < 90";

            if (Rate < 80)
                return "Discount Less than 80";

            return "Discount";
        }

        private void _RefreshListByRateAndBranch()
        {
            dgvCollegeMajorByBranchAndRateList.DataSource =
                clsCollegeMajor.GetCollegesAndMajorsByRateAndBranch
                (_GetCollegeBinary(), _GetMajorBinary(), float.Parse(txtRate.Text.Trim()));

            lblNumberOfRecordsByBranchAndRate.Text = dgvCollegeMajorByBranchAndRateList.Rows.Count.ToString();

            if (dgvCollegeMajorByBranchAndRateList.Rows.Count > 0)
            {
                dgvCollegeMajorByBranchAndRateList.Columns[0].HeaderText = "Major Name";
                dgvCollegeMajorByBranchAndRateList.Columns[0].Width = 200;

                dgvCollegeMajorByBranchAndRateList.Columns[1].HeaderText = "College Name";
                dgvCollegeMajorByBranchAndRateList.Columns[1].Width = 230;

                dgvCollegeMajorByBranchAndRateList.Columns[2].HeaderText = "Rate";
                dgvCollegeMajorByBranchAndRateList.Columns[2].Width = 100;

                dgvCollegeMajorByBranchAndRateList.Columns[3].HeaderText = "Total Grades";
                dgvCollegeMajorByBranchAndRateList.Columns[3].Width = 140;

                dgvCollegeMajorByBranchAndRateList.Columns[4].HeaderText = "Hour Fees";
                dgvCollegeMajorByBranchAndRateList.Columns[4].Width = 120;

                dgvCollegeMajorByBranchAndRateList.Columns[5].HeaderText = _GetDiscountName();
                dgvCollegeMajorByBranchAndRateList.Columns[5].Width = 220;

                dgvCollegeMajorByBranchAndRateList.Columns[6].HeaderText = "Hour Fees After Discount";
                dgvCollegeMajorByBranchAndRateList.Columns[6].Width = 232;
            }
        }

        private void _RefreshListByAllCollegeAndMajor()
        {
            dgvAllCollegeAndMajor.DataSource = clsCollegeMajor.GetAllBranches();

            lblNumberOfRecordOfAllMajorCollege.Text = dgvAllCollegeAndMajor.Rows.Count.ToString();

            if (dgvAllCollegeAndMajor.Rows.Count > 0)
            {
                dgvAllCollegeAndMajor.Columns[0].HeaderText = "Major Name";
                dgvAllCollegeAndMajor.Columns[0].Width = 200;

                dgvAllCollegeAndMajor.Columns[1].HeaderText = "College Name";
                dgvAllCollegeAndMajor.Columns[1].Width = 250;

                dgvAllCollegeAndMajor.Columns[2].HeaderText = "Rate";
                dgvAllCollegeAndMajor.Columns[2].Width = 100;

                dgvAllCollegeAndMajor.Columns[3].HeaderText = "Total Grades";
                dgvAllCollegeAndMajor.Columns[3].Width = 150;

                dgvAllCollegeAndMajor.Columns[4].HeaderText = "Hour Fees";
                dgvAllCollegeAndMajor.Columns[4].Width = 150;

                dgvAllCollegeAndMajor.Columns[5].HeaderText = "Discount 90 Plus Rate";
                dgvAllCollegeAndMajor.Columns[5].Width = 220;

                dgvAllCollegeAndMajor.Columns[6].HeaderText = "Discount 80 To 90 Rate";
                dgvAllCollegeAndMajor.Columns[6].Width = 250;

                dgvAllCollegeAndMajor.Columns[7].HeaderText = "Discount Less Than 80 Rate";
                dgvAllCollegeAndMajor.Columns[7].Width = 250;
            }
        }

        private short _GetCollegeBinary()
        {
            switch (cbBranch.Text)
            {
                case "الفرع العلمي":
                case "الفرع العلمي القديم":
                case "الحقل الطبي":
                case "الحقل الهندسي":
                    return (short)enBranchForCollege.Scientific;

                case "العلوم البحتة":
                case "الأدبي/الشرعي":
                case "التعليم الصحي الشامل":
                case "الأدارة المعلوماتية":
                case "الأدارة المعلوماتية المسار الأول":
                case "الأدارة المعلوماتية المسار الثاني":
                    return (short)enBranchForCollege.PureScience;

                case "(الصناعي(القديم":
                    return (short)enBranchForCollege.Industrial_Old;

                case "(التجاري/الفندقي/الاقتصاد المنزلي(القديم":
                    return (short)enBranchForCollege.CommercialHotelEconomics_Old;

                case "(الزراعي(القديم":
                case "(التمريضي(القديم":
                    return (short)enBranchForCollege.Agricultural_Old;

                case "(الصناعي(الجديد":
                    return (short)enBranchForCollege.Industrial_New;

                case "(الفندقي والسياحي(الجديد":
                    return (short)enBranchForCollege.HotelAndTourism_New;

                case "(الاقتصاد المنزلي(الجديد":
                    return (short)enBranchForCollege.Economics_New;

                case "(الزراعي(الجديد":
                    return (short)enBranchForCollege.Agricultural_New;

                default:
                    return (short)enBranchForCollege.Scientific;
            }
        }

        private int _GetMajorBinary()
        {
            switch (cbBranch.Text)
            {
                case "الفرع العلمي":
                case "الفرع العلمي القديم":
                case "الحقل الطبي":
                case "الحقل الهندسي":
                    return (int)enBranchForMajor.Scientific;

                case "العلوم البحتة":
                case "الأدبي/الشرعي":
                case "التعليم الصحي الشامل":
                case "الأدارة المعلوماتية":
                case "الأدارة المعلوماتية المسار الأول":
                case "الأدارة المعلوماتية المسار الثاني":
                    return (int)enBranchForMajor.PureScience;

                case "(الصناعي(القديم":
                    return (int)enBranchForMajor.Industrial_Old;

                case "(التجاري/الفندقي/الاقتصاد المنزلي(القديم":
                    return (int)enBranchForMajor.CommercialHotelEconomics_Old;

                case "(الزراعي(القديم":
                case "(التمريضي(القديم":
                    return (int)enBranchForMajor.Agricultural_Old;

                case "(الصناعي(الجديد":
                    return (int)enBranchForMajor.Industrial_New;

                case "(الفندقي والسياحي(الجديد":
                    return (int)enBranchForMajor.HotelAndTourism_New;

                case "(الاقتصاد المنزلي(الجديد":
                    return (int)enBranchForMajor.Economics_New;

                case "(الزراعي(الجديد":
                    return (int)enBranchForMajor.Agricultural_New;

                default:
                    return (int)enBranchForMajor.Scientific;
            }
        }

        private void btnGetResult_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRate.Text.Trim()))
            {
                MessageBox.Show("You have to enter a rate first!", "Missing Rate",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _RefreshListByRateAndBranch();
        }

        private void frmUniversityAdmissionStandards_Load(object sender, EventArgs e)
        {
            _RefreshListByAllCollegeAndMajor();
        }

        private void frmUniversityAdmissionStandards_Activated(object sender, EventArgs e)
        {
            txtRate.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvCollegeMajorByBranchAndRateList.DataSource = null;
            txtRate.Clear();
            lblNumberOfRecordsByBranchAndRate.Text = "??";
            cbBranch.SelectedIndex = 0;
            txtRate.Focus();
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;
            string textBoxText = (sender as Guna2TextBox).Text;

            // Allow digits, the decimal point, and the backspace.
            bool isDigit = Char.IsDigit(inputChar);
            bool isDecimalPoint = (inputChar == '.');
            bool isBackspace = (inputChar == '\b');

            // If the input character is not a digit, decimal point, or backspace, suppress it.
            if (!isDigit && !isDecimalPoint && !isBackspace)
            {
                e.Handled = true;
            }

            // Concatenate the current text with the new character.
            string newText = textBoxText;
            if (isBackspace)
            {
                if (textBoxText.Length > 0 && (sender as Guna2TextBox).SelectionStart > 0)
                {
                    newText = textBoxText.Substring(0, (sender as Guna2TextBox).SelectionStart - 1) +
                              textBoxText.Substring((sender as Guna2TextBox).SelectionStart + (sender as Guna2TextBox).SelectionLength);
                }
            }
            else
            {
                newText = textBoxText.Substring(0, (sender as Guna2TextBox).SelectionStart) + inputChar +
                          textBoxText.Substring((sender as Guna2TextBox).SelectionStart + (sender as Guna2TextBox).SelectionLength);
            }

            // Check if the resulting value is a valid floating-point number within the range of 0 to 100.
            float result = 0f;
            if (!string.IsNullOrEmpty(newText) && !float.TryParse(newText, out result) || result < 0 || result > 100)
            {
                e.Handled = true; // Suppress input if not a valid number or out of range.
            }

            // Make sure there is only one decimal point in the input.
            if (isDecimalPoint && textBoxText.Contains(".") && !newText.Substring(newText.IndexOf('.')).Contains('.'))
            {
                e.Handled = true;
            }
        }
    }
}
