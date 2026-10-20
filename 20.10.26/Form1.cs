using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _20._10._26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Text = "LINQ: агрегаты и множества";
            Width = 1100;
            Height = 650;
            StartPosition = FormStartPosition.CenterScreen;

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 100,
                AutoScroll = true
            };

            AddButton(panel, "Статистика", CalcAggregates);
            AddButton(panel, "Только онлайн", ExceptOnline);
            AddButton(panel, "Общие товары", IntersectBoth);
            AddButton(panel, "Все уникальные", UnionAll);
            AddButton(panel, "Concat + Distinct", ConcatDistinct);

            var stats = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 100,
                AutoScroll = true
            };

            foreach (var label in new[]
            {
            lblCount, lblSum, lblAvg, lblMinMax, lblAggregate
        })
            {
                label.AutoSize = true;
                label.Margin = new Padding(8);
                stats.Controls.Add(label);
            }

            dgvResults.Dock = DockStyle.Fill;
            dgvResults.ReadOnly = true;
            dgvResults.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.AllowUserToAddRows = false;

            Controls.Add(dgvResults);
            Controls.Add(stats);
            Controls.Add(panel);

            try
            {
                dgvResults.DataSource =
                    Database.LoadOrders("OnlineOrders");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка загрузки базы: " + ex.Message);
            }
        }

        private void AddButton(
            FlowLayoutPanel panel,
            string text,
            EventHandler handler)
        {
            var button = new Button
            {
                Text = text,
                Width = 180,
                Height = 40,
                Margin = new Padding(5)
            };

            button.Click += handler;
            panel.Controls.Add(button);
        }

        private void ShowResults(
            System.Collections.Generic.List<OrderItem> items)
        {
            dgvResults.DataSource = null;
            dgvResults.DataSource = items;
        }

        private void CalcAggregates(object sender, EventArgs e)
        {
            var orders = Database.LoadOrders("OnlineOrders");

            if (!orders.Any())
            {
                MessageBox.Show("Нет онлайн-заказов.");
                return;
            }

            int count = orders.Count();
            int expensive = orders.Count(x => x.Total > 1000);
            decimal sum = orders.Sum(x => x.Total);
            decimal average = orders.Average(x => x.Price);
            decimal min = orders.Min(x => x.Price);
            decimal max = orders.Max(x => x.Price);

            string categories = orders
                .Select(x => x.Category)
                .Distinct()
                .Aggregate((a, b) => a + ", " + b);

            lblCount.Text =
                $"Всего: {count}; чек > 1000: {expensive}";
            lblSum.Text = $"Выручка: {sum:N2}";
            lblAvg.Text = $"Средняя цена: {average:N2}";
            lblMinMax.Text = $"Мин.: {min:N2}; макс.: {max:N2}";
            lblAggregate.Text = $"Категории: {categories}";

            ShowResults(orders);
        }

        private void ExceptOnline(object sender, EventArgs e)
        {
            var online = Database.LoadOrders("OnlineOrders");
            var store = Database.LoadOrders("StoreOrders");

            ShowResults(online.Except(store).ToList());
        }

        private void IntersectBoth(object sender, EventArgs e)
        {
            var online = Database.LoadOrders("OnlineOrders");
            var store = Database.LoadOrders("StoreOrders");

            ShowResults(online.Intersect(store).ToList());
        }

        private void UnionAll(object sender, EventArgs e)
        {
            var online = Database.LoadOrders("OnlineOrders");
            var store = Database.LoadOrders("StoreOrders");

            ShowResults(online.Union(store).ToList());
        }

        private void ConcatDistinct(object sender, EventArgs e)
        {
            var online = Database.LoadOrders("OnlineOrders");
            var store = Database.LoadOrders("StoreOrders");

            var result = online
                .Concat(store)
                .Distinct()
                .ToList();

            ShowResults(result);
        }
    }
}

