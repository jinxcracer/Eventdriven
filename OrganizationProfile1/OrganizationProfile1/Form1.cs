using System;
using System.Windows.Forms;
using static OrganizationProfile1.StudentInformation;

namespace OrganizationProfile1
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age; 
        private long _ContactNo; 
        private int _StudentNo; 

        public frmRegistration()
        {
            InitializeComponent();
        }
        private void OrganizationProfile_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            cbPrograms.Items.AddRange(ListOfProgram);
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value; 

                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Format error: " + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Null error: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Overflow error: " + ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Index error: " + ex.Message);
            }
        }

        private string FullName(string lastName, string firstName, string middleInitial)
        {
            if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException("Names cannot be empty.");

            return $"{firstName} {middleInitial}. {lastName}".Trim();
        }

        private int StudentNumber(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("Student number cannot be null or empty.");

            if (!int.TryParse(text, out int studentNo))
                throw new FormatException("Invalid student number format.");

            return studentNo;
        }

        private long ContactNo(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("Contact number cannot be null or empty.");

            if (!long.TryParse(text, out long contactNo))
                throw new FormatException("Invalid contact number format.");

            return contactNo;
        }

        private int Age(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("Age cannot be null or empty.");

            if (!int.TryParse(text, out int age))
                throw new FormatException("Invalid age format.");

            return age;
        }
    }
}
