using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

using System.IO;
using INVENTORYManagment.Reports;

namespace INVENTORYManagment.Forms
{
    public partial class Home : Form
    {
        string imageLocation = "";
        string cs = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
        SqlCommand cmd = new SqlCommand();
        public Home()
        {
            InitializeComponent();
            btnHome.Visible = true;
            btnUserManagment.Visible = true;
            btnCustomer.Visible = true;
            btnPurchase.Visible = true;
            btnSupplier.Visible = true;
            btnProduct.Visible = true;
            btnStock.Visible = true;
            btnReports.Visible = true;
            panelHome.Visible = true;
            panelwelcome.Visible = true;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelwelcome.Visible = false;
            panelUser.Visible = false;
            panelCustomer.Visible = false;
            panelPurchase.Visible = false;
            panelSupplier.Visible = false;
            panelProduct.Visible = false;
            panelStock.Visible = false;
            panelReport.Visible = false;
          
        }

        

        private void btnUserManagment_Click(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelUser.Visible = true;
            panelCustomer.Visible = false;
            panelPurchase.Visible = false;
            panelSupplier.Visible = false;
            panelProduct.Visible = false;
            panelStock.Visible = false;
            panelReport.Visible = false;
            panelwelcome.Visible = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (txtEmail.Text != "" && txtContact.Text != "")
                {
                    con.Open();
                    string qry = "INSERT INTO Users(FirstName,LastName,Contact,Email,UserName,Password,RoleName,IsActive) values (@firstname,@lastname,@contact,@email,@user,@password,@role,@isactve)";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@lastname", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@user", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassord.Text);
                    cmd.Parameters.AddWithValue("@role", comboBoxRole.GetItemText(comboBoxRole.SelectedItem));
                    int IsActive;
                    if (checkBoxUser.Checked == true)
                    {
                        IsActive = 1;
                    }
                    else
                    {
                        IsActive = 0;
                    }
                    cmd.Parameters.Add(new SqlParameter("@isactve", IsActive));
                   



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record saved Successfully");

                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtContact.Text = "";
                    txtEmail.Text = "";
                    txtUserName.Text = "";
                    txtPassord.Text = "";
                    con.Close();
                          
                }
                else
                {
                    MessageBox.Show("Please trainee & round number");
                }

            }


        }

        private void Home_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myInventorySystemDataSet13.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter2.Fill(this.myInventorySystemDataSet13.Products);
            // TODO: This line of code loads data into the 'myInventorySystemDataSet9.SubCategory' table. You can move, or remove it, as needed.
            this.subCategoryTableAdapter1.Fill(this.myInventorySystemDataSet9.SubCategory);
            // TODO: This line of code loads data into the 'myInventorySystemDataSet8.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter1.Fill(this.myInventorySystemDataSet8.Products);
            // TODO: This line of code loads data into the 'myInventorySystemDataSet5.SubCategory' table. You can move, or remove it, as needed.
            this.subCategoryTableAdapter.Fill(this.myInventorySystemDataSet5.SubCategory);
            // TODO: This line of code loads data into the 'myInventorySystemDataSet4.Unit' table. You can move, or remove it, as needed.
            this.unitTableAdapter.Fill(this.myInventorySystemDataSet4.Unit);
            // TODO: This line of code loads data into the 'myInventorySystemDataSet3.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.myInventorySystemDataSet3.Category);
            // TODO: This line of code loads data into the 'myInventorySystemDataSet2.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.myInventorySystemDataSet2.Customers);
            // TODO: This line of code loads data into the 'myInventorySystemDataSet1.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.myInventorySystemDataSet1.Products);
            // TODO: This line of code loads data into the 'myInventorySystemDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.myInventorySystemDataSet.Users);

            CrystalReportTransection rTrn = new CrystalReportTransection();
            crystalReportViewerTransection.ReportSource = rTrn;

            CrystalReportCustomer rCus = new CrystalReportCustomer();
            crystalReportViewerCustomer.ReportSource = rCus;

            CrystalReportProduct rPRo = new CrystalReportProduct();
            crystalReportViewerProduct.ReportSource = rPRo;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelUser.Visible = true;
            panelCustomer.Visible = true;
            panelPurchase.Visible = false;
            panelSupplier.Visible = false;
            panelProduct.Visible = false;
            panelStock.Visible = false;
            panelReport.Visible = false;
            panelwelcome.Visible = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (txtCustomerName.Text != "" && txtContactNo.Text != "")
                {
                    con.Open();
                    string qry = "INSERT INTO Customers(CustomerName,Email,Contact,City,State,Country,IsActive) values (@CustomerName,@Email,@Contact,@City,@State,@Country,@isactve)";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@State", txtState.Text);
                    cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                   
                    int IsActive;
                    if (checkBoxCustomer.Checked == true)
                    {
                        IsActive = 1;
                    }
                    else
                    {
                        IsActive = 0;
                    }
                    cmd.Parameters.Add(new SqlParameter("@isactve", IsActive));




                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Add Successfully");

                    txtCustomerName.Text = "";
                    textBoxEmail.Text = "";
                    txtContactNo.Text = "";
                    txtCity.Text = "";
                    txtState.Text = "";
                    txtCountry.Text = "";
                    con.Close();

                }
                else
                {
                    MessageBox.Show("Please Customer Name & Countact number !!!!");
                }

            }


        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelUser.Visible = true;
            panelCustomer.Visible = true;
            panelPurchase.Visible = true;
            panelSupplier.Visible = false;
            panelProduct.Visible = false;
            panelStock.Visible = false;
            panelReport.Visible = false;
            panelwelcome.Visible = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
                if (txtRate.Text != "" && txtVat.Text != "")
                {
                    con.Open();
                    string qryInsert = "INSERT INTO [Transaction](TransactionType,Date,Rate,Quantity,Discount,Vat) VALUES (@TransactionType,@Date,@Rate,@Quantity,@Discount,@Vat)";

                    SqlCommand cmd = new SqlCommand(qryInsert, con);

                    cmd.Parameters.AddWithValue("@TransactionType", textBoxTP.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.ToString());
                    cmd.Parameters.AddWithValue("@Rate", txtRate.Text);
                    cmd.Parameters.AddWithValue("@Quantity", textBoxQuantity.Text);

                    cmd.Parameters.AddWithValue("@Discount", textBoxDiscount.Text);
                    cmd.Parameters.AddWithValue("@Vat", txtVat.Text);



                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Transaction successfully!!!");



                    textBoxTP.Text = "";
                    txtRate.Text = "";
                    textBoxQuantity.Text = "";

                    textBoxDiscount.Text = "";
                    txtState.Text = "";



                    con.Close();

                }


        }

        private void button2Reset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelUser.Visible = true;
            panelCustomer.Visible = true;
            panelPurchase.Visible = true;
            panelSupplier.Visible = true;
            panelProduct.Visible = false;
            panelStock.Visible = false;
            panelReport.Visible = false;
            panelwelcome.Visible = false;
        }

        private void btnSupplierSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (textSuppName.Text != "" && textBoxSuppContNo.Text != "")
                {
                    con.Open();
                    string qry = "INSERT INTO Supplier(BusinessName,ContactPersonName,Email,Contact,City,State,Country,IsActive) values (@BusinessName,@ContactPersonName,@Email,@Contact,@City,@State,@Country,@isactve)";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@BusinessName", textBoxBName.Text);
                    cmd.Parameters.AddWithValue("ContactPersonName",textSuppName.Text);
                    cmd.Parameters.AddWithValue("@Email", textBoxsupplierEmail.Text);
                    cmd.Parameters.AddWithValue("@Contact", textBoxSuppContNo.Text);
                    cmd.Parameters.AddWithValue("@City", textBoxSuppCity.Text);
                    cmd.Parameters.AddWithValue("@State", textBoxSuppState.Text);
                    cmd.Parameters.AddWithValue("@Country", textBoxSuppCounty.Text);

                    int IsActive;
                    if (checkBoxSupplier.Checked == true)
                    {
                        IsActive = 1;
                    }
                    else
                    {
                        IsActive = 0;
                    }
                    cmd.Parameters.Add(new SqlParameter("@isactve", IsActive));




                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplier Add Successfully");

                    textBoxBName.Text = "";
                    textSuppName.Text = "";
                    textBoxsupplierEmail.Text = "";
                    textBoxSuppContNo.Text = "";
                    textBoxSuppCity.Text = "";
                    textBoxSuppState.Text = "";
                    textBoxSuppCounty.Text = "";
                    con.Close();

                }
                else
                {
                    MessageBox.Show("Please Customer Name & Countact number !!!!");
                }

            }


        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelUser.Visible = true;
            panelCustomer.Visible = true;
            panelPurchase.Visible = true;
            panelSupplier.Visible = true;
            panelProduct.Visible = true;
            panelStock.Visible = false;
            panelReport.Visible = false;
            panelwelcome.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
               

          
           if (textBoxProductName.Text != "" && textBoxUnitRate.Text != "")
                {
                    con.Open();
                var imagePath = "";
                    if (imageLocation == "")
                    {
                        imagePath = lblImagePath.Text;
                    }
                    else
                    {
                        File.Copy(imageLocation, Path.Combine(@"C:\Uploads", Uri.EscapeDataString(DateTime.Now.ToLocalTime().ToLongDateString() + Path.GetFileName(imageLocation).ToString())), true);
                        imagePath = Uri.EscapeDataString(DateTime.Now.ToLocalTime().ToLongDateString() + Path.GetFileName(imageLocation).ToString());

                    }
                    string qryInsert = "INSERT INTO Products (ProductName,UnitRate,ProductImage,IsActive) VALUES (@ProductName,@UnitRate,@ProductImage,@IsActive)";

                    SqlCommand cmd = new SqlCommand(qryInsert, con);

                    cmd.Parameters.AddWithValue("@ProductName", textBoxProductName.Text);
                    cmd.Parameters.AddWithValue("@UnitRate", textBoxUnitRate.Text);
                    cmd.Parameters.AddWithValue("@ProductImage", imagePath);



                    int IsActive;
                    if (checkBoxProduct.Checked == true)
                    {
                        IsActive = 1;
                    }
                    else
                    {
                        IsActive = 0;
                    }
                    cmd.Parameters.Add(new SqlParameter("@IsActive", IsActive));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record saved successfully!!!");


                    textBoxProductID.Text = "";
                    textBoxProductName.Text = "";
                    textBoxUnitRate.Text = "";

                    con.Close();
                    con.Open();
                    string qryInsert1 = "INSERT INTO Category (CategoryName) VALUES (@categoryName)";
                    SqlCommand cmd1 = new SqlCommand(qryInsert1, con);

                    cmd1.Parameters.AddWithValue("@categoryName", comboBoxCategory.GetItemText(comboBoxCategory.SelectedItem));
                    con.Close();

                    con.Open();
                    string qryInsert2 = "INSERT INTO SubCategory (SubCategoryName) VALUES (@subCategoryName)";
                    SqlCommand cmd2 = new SqlCommand(qryInsert2, con);

                    cmd2.Parameters.AddWithValue("@subCategoryName", comboBoxSubcategory.GetItemText(comboBoxSubcategory.SelectedItem));
                    con.Close();
                    con.Open();
                    string qryInsert3 = "INSERT INTO Unit (UnitName) VALUES (@unitName)";
                    SqlCommand cmd3 = new SqlCommand(qryInsert3, con);

                    cmd2.Parameters.AddWithValue("@unitName", comboBoxUnit.GetItemText(comboBoxUnit.SelectedItem));
                    con.Close();
                }



        }

        private void btnProductReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string qry = "DELETE FROM Products WHERE ProductID='" + textBoxProductID.Text + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@ID", textBoxProductID.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Delate  Successfully");

               

                con.Close();
            }

        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = dialog.FileName;
                pictureBoxImages.ImageLocation = imageLocation;
            }

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelUser.Visible = true;
            panelCustomer.Visible = true;
            panelPurchase.Visible = true;
            panelSupplier.Visible = true;
            panelProduct.Visible = true;
            panelStock.Visible = true;
            panelReport.Visible = false;
            panelwelcome.Visible = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
           

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string showQry = "SELECT ProductName,UnitRate,IsActive FROM Products";
                cmd = new SqlCommand(showQry, con);
                DataTable dataTable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
                dataGridViewStock.DataSource = dataTable.DefaultView;
                con.Close();
              

            }

             

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelUser.Visible = true;
            panelCustomer.Visible = true;
            panelPurchase.Visible = true;
            panelSupplier.Visible = true;
            panelProduct.Visible = true;
            panelStock.Visible = true;
            panelReport.Visible = true;
            panelwelcome.Visible = false;
        }
    }
}
