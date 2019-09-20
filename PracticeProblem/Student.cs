using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeProblem
{
    public partial class Student : Form
    {
        List<string> ids = new List<string> { };
        List<string> names = new List<string> { };
        List<string> mobiles = new List<string> { };
        List<int> ages = new List<int> { };
        List<string> addresses = new List<string> { };
        List<double> gpas = new List<double> { };

        int age;
        string id,name, mobile, address;
        double gpa;

        double MaxGrade;
        string MaxMan = "";



        public Student()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(idTextBox.Text) && !String.IsNullOrEmpty(nameTextBox.Text) && !String.IsNullOrEmpty(mobileTextBox.Text))
            {
                if(idTextBox.Text.Length == 4)
                {
                    id = idTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Invalid ID!!!");
                }

                if (nameTextBox.Text.Length <= 30)
                {
                    name = nameTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Name!!!");
                }

                if (mobileTextBox.Text.Length == 11)
                {
                    mobile = mobileTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Mobile number.!!!");
                }

                age = int.Parse(ageTextBox.Text);
                address = addressRichTextBox.Text;
                

                if(Convert.ToDouble(gpaTextBox.Text) >= 0.00 && Convert.ToDouble(gpaTextBox.Text) <= 4.00)
                {
                    gpa = Convert.ToDouble(gpaTextBox.Text);
                }
                else
                {
                    MessageBox.Show("GPA must be between 0 - 4 !!!!");
                    return;
                }

                
                AddIntoList();
            }
            else
            {
                MessageBox.Show("You have to enter id, name and mobile!!!");
                return;
            }
            ShowOneStudentDetails();
            ClearData();
        }

        private void ShowOneStudentDetails()
        {
            displayRichTextBox.AppendText("\n------------\nID: " + id + "\nName: " + name + "\nMobie: " + mobile + "\nAge: " + age + "\nAdress: " + address +
                "\nGPA Point: " + gpa + "\n\n------------------");
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            if (idRadioButton.Checked == true)
            {
                displayRichTextBox.Clear();

                string searchId = " ";
                for(int i = 0; i < ids.Count(); i++)
                {

                    searchId += ids[i] + "    ";
                }
                displayRichTextBox.AppendText("Inserted IDs: " + searchId + ",");
            }

            else if (nameRadioButton.Checked == true)
            {
                displayRichTextBox.Clear();
                string searchName = " ";

                for (int i = 0; i < name.Count(); i++)
                {

                    searchName += names[i] + "   ";
                }
            displayRichTextBox.AppendText("Inserted Names: " + searchName + ",");
            }

            else if (mobileRadioButton.Checked == true)
            {
                displayRichTextBox.Clear();

                string searchMobile = " ";

                for (int i = 0; i < mobiles.Count(); i++)
                {

                    searchMobile += mobiles[i]+ "    " ;
                }
                displayRichTextBox.AppendText("Inserted Mobile Number : "  + searchMobile + ",");
            }

        }

       

        private void AddIntoList()
        {
            ids.Add(id);
            names.Add(name);
            mobiles.Add(mobile);
            ages.Add(age);
            addresses.Add(address);
            gpas.Add(gpa);
        }

        private void ClearData()
        {
            idTextBox.Clear();
            nameTextBox.Clear();
            mobileTextBox.Clear();
            ageTextBox.Clear();
            addressRichTextBox.Clear();
            gpaTextBox.Clear();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            displayRichTextBox.Clear();
            string AllStudent = "";
            for (int i = 0; i < names.Count(); i++)
            {
                AllStudent += "\n------------\nID: " + ids[i] + "\nName: " + names[i] + "\nMobie: " + mobiles[i] + "\nAge: " + ages[i] + "\nAdress: " + addresses[i] +
                "\nGPA Point: " + gpas[i] + "\n\n------------------";

            }
            displayRichTextBox.AppendText(AllStudent);
            
            //find Max() and Min();
            maxTextBox.Text = gpas.Max().ToString();
            maxNameTextBox.Text = names[gpas.IndexOf(gpas.Max())];

            minTextBox.Text = gpas.Min().ToString();
            minNameTextBox.Text = names[gpas.IndexOf(gpas.Min())];

            avgTextBox.Text = gpas.Average().ToString();
            totalTextBox.Text = gpas.Sum().ToString(); 

            //totalGpaTextBox =gpas.Sum();

            
        }
    }
}
