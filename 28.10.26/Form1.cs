using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _28._10._26
{
    public class FormMain : Form
    {
        private DatabaseInitializer _database;
        private ReportService _reportService;

        private List<Category> _categories;
        private List<Product> _products;
        private List<Sale> _sales;

        private DataGridView _productsGrid;
        private DataGridView _reportGrid;
        private TextBox _searchBox;
        private ComboBox _categoryBox;
        private NumericUpDown _stockLimit;

        public FormMain()
        {
            Text = "Магазин — учет товаров и продаж";
            Width = 1100;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;

            BuildInterface();
            LoadDatabase();
        }

        private void BuildInterface()
        {
            TabControl tabs = new TabControl();
            tabs.Dock = DockStyle.Fill;
            Controls.Add(tabs);

            // Вкладка товаров
            TabPage productsPage = new TabPage("Товары");
            tabs.TabPages.Add(productsPage);

            Panel topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 100;
            productsPage.Controls.Add(topPanel);

            Label searchLabel = new Label();
            searchLabel.Text = "Поиск:";
            searchLabel.Left = 10;
            searchLabel.Top = 15;
            searchLabel.AutoSize = true;
            topPanel.Controls.Add(searchLabel);

            _searchBox = new TextBox();
            _searchBox.Left = 75;
            _searchBox.Top = 10;
            _searchBox.Width = 220;
            _searchBox.TextChanged += SearchBox_TextChanged;
            topPanel.Controls.Add(_searchBox);

            Label categoryLabel = new Label();
            categoryLabel.Text = "Категория:";
            categoryLabel.Left = 320;
            categoryLabel.Top = 15;
            categoryLabel.AutoSize = true;
            topPanel.Controls.Add(categoryLabel);

            _categoryBox = new ComboBox();
            _categoryBox.Left = 400;
            _categoryBox.Top = 10;
            _categoryBox.Width = 220;
            _categoryBox.DropDownStyle =
                ComboBoxStyle.DropDownList;
            _categoryBox.SelectedIndexChanged +=
                CategoryBox_SelectedIndexChanged;
            topPanel.Controls.Add(_categoryBox);

            Label stockLabel = new Label();
            stockLabel.Text = "Остаток не более:";
            stockLabel.Left = 10;
            stockLabel.Top = 55;
            stockLabel.AutoSize = true;
            topPanel.Controls.Add(stockLabel);

            _stockLimit = new NumericUpDown();
            _stockLimit.Left = 130;
            _stockLimit.Top = 50;
            _stockLimit.Width = 70;
            _stockLimit.Maximum = 10000;
            _stockLimit.Value = 5;
            topPanel.Controls.Add(_stockLimit);

            Button stockButton = new Button();
            stockButton.Text = "Мало на складе";
            stockButton.Left = 215;
            stockButton.Top = 48;
            stockButton.Width = 140;
            stockButton.Click += StockButton_Click;
            topPanel.Controls.Add(stockButton);

            Button allProductsButton = new Button();
            allProductsButton.Text = "Все товары";
            allProductsButton.Left = 365;
            allProductsButton.Top = 48;
            allProductsButton.Width = 110;
            allProductsButton.Click += AllProductsButton_Click;
            topPanel.Controls.Add(allProductsButton);

            _productsGrid = new DataGridView();
            _productsGrid.Dock = DockStyle.Fill;
            _productsGrid.ReadOnly = true;
            _productsGrid.AllowUserToAddRows = false;
            _productsGrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            _productsGrid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            productsPage.Controls.Add(_productsGrid);

            // Вкладка отчетов
            TabPage reportsPage = new TabPage("Отчеты");
            tabs.TabPages.Add(reportsPage);

            FlowLayoutPanel reportButtons = new FlowLayoutPanel();
            reportButtons.Dock = DockStyle.Top;
            reportButtons.Height = 80;
            reportsPage.Controls.Add(reportButtons);

            AddReportButton(
                reportButtons,
                "Продажи",
                ShowSalesReport);

            AddReportButton(
                reportButtons,
                "Скидки",
                ShowDiscountReport);

            AddReportButton(
                reportButtons,
                "Сводка категорий",
                ShowCategorySummary);

            AddReportButton(
                reportButtons,
                "Выручка по каналам",
                ShowChannelReport);

            _reportGrid = new DataGridView();
            _reportGrid.Dock = DockStyle.Fill;
            _reportGrid.ReadOnly = true;
            _reportGrid.AllowUserToAddRows = false;
            _reportGrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            reportsPage.Controls.Add(_reportGrid);
        }

        private void AddReportButton(
            FlowLayoutPanel panel,
            string caption,
            EventHandler handler)
        {
            Button button = new Button();
            button.Text = caption;
            button.Width = 160;
            button.Height = 35;
            button.Margin = new Padding(5);
            button.Click += handler;
            panel.Controls.Add(button);
        }

        private void LoadDatabase()
        {
            try
            {
                _database = new DatabaseInitializer();
                _database.Initialize();

                _categories = _database.LoadCategories();
                _products = _database.LoadProducts();
                _sales = _database.LoadSales();

                _reportService = new ReportService(
                    _categories,
                    _products,
                    _sales);

                _categoryBox.Items.Clear();
                _categoryBox.Items.Add("Все категории");

                foreach (Category category in _categories)
                {
                    _categoryBox.Items.Add(category.Name);
                }

                _categoryBox.SelectedIndex = 0;

                ShowProducts(_products);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Не удалось загрузить базу данных:\n" +
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ShowProducts(List<Product> products)
        {
            _productsGrid.DataSource = null;
            _productsGrid.DataSource = products;
        }

        private void SearchBox_TextChanged(
            object sender,
            EventArgs e)
        {
            if (_reportService == null)
                return;

            List<Product> result =
                _reportService.SearchProducts(_searchBox.Text);

            ShowProducts(result);
        }

        private void CategoryBox_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (_categories == null ||
                _categoryBox.SelectedIndex < 0)
                return;

            if (_categoryBox.SelectedIndex == 0)
            {
                ShowProducts(_products);
                return;
            }

            Category selectedCategory =
                _categories[_categoryBox.SelectedIndex - 1];

            ShowProducts(
                _reportService.GetProductsByCategory(
                    selectedCategory.Id));
        }

        private void StockButton_Click(
            object sender,
            EventArgs e)
        {
            int limit = (int)_stockLimit.Value;

            ShowProducts(
                _reportService.GetLowStockProducts(limit));
        }

        private void AllProductsButton_Click(
            object sender,
            EventArgs e)
        {
            _searchBox.Text = "";

            if (_categoryBox.Items.Count > 0)
                _categoryBox.SelectedIndex = 0;

            ShowProducts(_products);
        }

        private void ShowSalesReport(
            object sender,
            EventArgs e)
        {
            _reportGrid.DataSource = null;
            _reportGrid.DataSource =
                _reportService.GetSalesReport();
        }

        private void ShowDiscountReport(
            object sender,
            EventArgs e)
        {
            _reportGrid.DataSource = null;
            _reportGrid.DataSource =
                _reportService.GetProductsWithDiscount();
        }

        private void ShowCategorySummary(
            object sender,
            EventArgs e)
        {
            _reportGrid.DataSource = null;
            _reportGrid.DataSource =
                _reportService.GetCategorySummary();
        }

        private void ShowChannelReport(
            object sender,
            EventArgs e)
        {
            _reportGrid.DataSource = null;
            _reportGrid.DataSource =
                _reportService.GetRevenueByChannel();
        }
    }
}
