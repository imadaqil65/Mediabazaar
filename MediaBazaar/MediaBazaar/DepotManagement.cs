using Domain;
using Domain.EmployeeServices;
using Domain.WorkShiftServices;
using Infrastructure;

namespace MediaBazaar
{
    public partial class DepotManagement : Form
    {
        private readonly Home homepage;
        private readonly RequestService requestService;
        private readonly ProductService productServices;
        public DepotManagement(Home homepage)
        {
            InitializeComponent();
            this.homepage = homepage;
            productServices = new ProductService(new ProductRepository());
            requestService = new RequestService(new RequestRepository());
            FillDatagrid();
            AddButonInDataGrid();
            FillComboBox();
        }

        private void FillDatagrid()
        {
            FillDatagrid(productServices.ViewActiveProduct());
            FillRequests();
        }
        private void FillEditProduct(Product product)
        {
            lbl_productId.Text = product.productId.ToString();
            tbxEditName.Text = product.name;
            tbxEditBrand.Text = product.brand;
            rTbxEditDesc.Text = product.description;
            cmbxEditCategory.Text = product.category;
            nudEditPrice.Value = product.price;
            nudEditWidth.Value = product.width;
            nudEditHeight.Value = product.height;
            nudEditLength.Value = product.length;
            nudEditWeight.Value = product.weight;
            nudEditStock.Value = product.stock;
        }
        private void ClearEditProduct()
        {
            lbl_productId.Text = "null";
            lblRequestEdit.Text = "null";
            tbxEditName.Clear();
            tbxEditBrand.Clear();
            rTbxEditDesc.Clear();
            cmbxEditCategory.SelectedIndex = 0;
            nudEditPrice.Value = 0;
            nudEditWidth.Value = 0;
            nudEditHeight.Value = 0;
            nudEditLength.Value = 0;
            nudEditWeight.Value = 0;
            nudEditStock.Value = 0;
        }

        private void FillRequests()
        {
            dgv_Requests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv_Requests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Requests.MultiSelect = false;
            var source = new BindingSource();
            source.DataSource = requestService.GetRestockRequests();
            dgv_Requests.DataSource = source;
            dgv_Requests.ScrollBars = ScrollBars.Both;
        }

        private void AddButonInDataGrid()
        {
            //Add Restock Button
            var RestockButton = new DataGridViewButtonColumn();
            RestockButton.Name = "dataGridViewRestockButton";
            RestockButton.HeaderText = "Restock";
            RestockButton.Text = "Restock";
            RestockButton.UseColumnTextForButtonValue = true;
            this.dgv_Requests.Columns.Add(RestockButton);
            //Add Delete Request Button
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "dataGridViewDeleteButton";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            this.dgv_Requests.Columns.Add(deleteButton);
        }

        private void FillDatagrid(IEnumerable<Product> list)
        {
            dgv_Product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv_Product.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Product.MultiSelect = false;
            var source = new BindingSource();
            source.DataSource = list;
            dgv_Product.DataSource = source;
            dgv_Product.ScrollBars = ScrollBars.Both;

        }

        private void FillComboBox()
        {
            List<string> categories = productServices.GetCategories();
            cmbxCategory.DataSource = categories;
            cmbxEditCategory.DataSource = categories;
            categories.Insert(0, "-");
            cmbxCategoryFilter.DataSource = categories;
        }

        private void BtnBackToHome_Click(object sender, EventArgs e)
        {
            this.Close();
            homepage.Show();
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbxName.Text;
                string brand = tbxBrand.Text;
                string desc = rTbxDesc.Text;
                string category = cmbxCategory.Text;
                decimal price = (decimal)nudPrice.Value;
                int width = (int)nudWidth.Value;
                int height = (int)nudHeight.Value;
                int length = (int)nudLength.Value;
                int weight = (int)nudWeight.Value;
                int stock = (int)nudstock.Value;
                Product product = new Product(0, name, brand, price, desc, category, height, width, length, weight, stock, true);
                if (lbl_productId.Text == "null")
                {
                    productServices.CreateProduct(product);
                    MessageBox.Show("Product Added");
                    ClearEditProduct();
                    FillDatagrid();
                    tabcontrol.SelectedTab = tabPage1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private void BtDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                switch (MessageBox.Show("Are you sure you want to delete? \rDeletion is permanent", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        DataGridViewRow selectedRow = dgv_Product.SelectedRows[0];
                        int id = (int)selectedRow.Cells["productId"].Value;
                        productServices.DeleteProduct(id);
                        FillDatagrid();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private void BtnSendToEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Product product;
                DataGridViewRow selectedRow = dgv_Product.SelectedRows[0];
                int id = (int)selectedRow.Cells["productIdDataGridViewTextBoxColumn"].Value;
                product = productServices.GetProduct(id);
                FillEditProduct(product);
                tabcontrol.SelectedTab = tabPage3;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private void DepotManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            //homepage.Show();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbxEditName.Text;
                string brand = tbxEditBrand.Text;
                string desc = rTbxEditDesc.Text;
                string category = cmbxEditCategory.Text;
                decimal price = (decimal)nudEditPrice.Value;
                int width = (int)nudEditWidth.Value;
                int height = (int)nudEditHeight.Value;
                int length = (int)nudEditLength.Value;
                int weight = (int)nudEditWeight.Value;
                int stock = (int)nudEditStock.Value;
                Product product = new Product(int.Parse(lbl_productId.Text), name, brand, price, desc, category, height, width, length, weight, stock, true);
                productServices.UpdateProduct(product);
                if (lblRequestEdit.Text != "null")
                {
                    requestService.DeleteRequest(int.Parse(lblRequestEdit.Text));
                }
                MessageBox.Show("Product Edited");
                FillDatagrid();
                tabcontrol.SelectedTab = tabPage1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured\r{ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string NameSearch = tbxSearchFilter.Text;
            List<Product> filteredproducts = new List<Product>();
            foreach (var product in productServices.ViewActiveProduct())
            {
                if (string.IsNullOrEmpty(NameSearch) || product.name.Contains(NameSearch, (StringComparison)5))
                {
                    if (cmbxCategoryFilter.Text == product.category)
                    {
                        filteredproducts.Add(product);
                    }
                    else if (cmbxCategoryFilter.Text == "-")
                    {
                        filteredproducts.Add(product);
                    }
                }
            }
            FillDatagrid(filteredproducts);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            cmbxCategoryFilter.SelectedIndex = 0;
            FillDatagrid();
        }

        private void BtnEmployee_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeeForm emp = new EmployeeForm(homepage);
            emp.Show();
        }

        private void BtnWorkShift_Click(object sender, EventArgs e)
        {
            this.Close();
            WorkSchedule emp = new WorkSchedule(homepage);
            emp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            DepartmentManagement emp = new DepartmentManagement(homepage);
            emp.Show();
        }

        private void DepotManagement_Load(object sender, EventArgs e)
        {
            BtnDepotManagement.Visible = false;
            BtnEmployee.Visible = false;
            BtnWorkShift.Visible = false;
            button4.Visible = false;
        }

        private void dgv_Requests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgv_Requests.SelectedRows[0];
            //if click is on new row or header row
            if (e.RowIndex == dgv_Requests.NewRowIndex || e.RowIndex < 0)
                return;
            try
            {
                //Check if click is on specific column 
                if (e.ColumnIndex == dgv_Requests.Columns["dataGridViewRestockButton"].Index)
                {
                    int requestId = (int)selectedRow.Cells["RequestId"].Value;
                    int productId = (int)selectedRow.Cells["ProductId"].Value;
                    int restock = (int)selectedRow.Cells["RestockNumber"].Value;
                    string productName = productServices.GetProduct(productId).name;

                    tbxProductName.Text = productName;
                    nudProductId.Value = productId;
                    nudAddStock.Value = restock;
                    lblRequestID.Text = requestId.ToString();
                }
                else if (e.ColumnIndex == dgv_Requests.Columns["dataGridViewDeleteButton"].Index)
                {
                    int id = (int)selectedRow.Cells["RequestId"].Value;
                    requestService.DeleteRequest(id);
                    FillDatagrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured\r" + ex.Message);
            }
        }

        private void btnRestockItem_Click(object sender, EventArgs e)
        {
            Product product = productServices.GetProduct((int)nudProductId.Value);
            product.stock += (int)nudAddStock.Value;
            productServices.UpdateProduct(product);
            MessageBox.Show("Product restocked");
            requestService.DeleteRequest(int.Parse(lblRequestID.Text));
            ClearQuickRestock();
            FillDatagrid();
        }

        private void ClearQuickRestock()
        {
            lblRequestID.Text = string.Empty;
            tbxProductName.Clear();
            nudProductId.Value = 0;
            nudAddStock.Value = 0;
        }

        private void nudProductId_ValueChanged(object sender, EventArgs e)
        {
            if (nudProductId.Value == 0)
            {
                btnRestockItem.Enabled = false;
            }
            else
            {
                btnRestockItem.Enabled = true;
            }
        }

        private void btnSendToEdit_Click(object sender, EventArgs e)
        {
            Product product;
            DataGridViewRow selectedRow = dgv_Requests.SelectedRows[0];
            int id = (int)selectedRow.Cells["ProductId"].Value;
            product = productServices.GetProduct(id);
            FillEditProduct(product);
            tabcontrol.SelectedTab = tabPage3;
            lblRequestEdit.Text = selectedRow.Cells["ProductId"].Value.ToString();
        }
    }
}
