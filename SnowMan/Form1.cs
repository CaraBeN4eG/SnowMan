using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowMan
{
    public partial class Form1 : Form
    {
        private List<Circle> snowMan;
        private Graphics graphics;
        private Circle selectedCircle = null;
        public class Circle
        {
            public int x { get; set; }
            public int y { get; set; }
            public int diameter { get; set; }
            public Color fillColor { get; set; }
            public Color borderColor { get; set; }
            public bool IsSelected { get; set; }
            public void Draw(Graphics g)
            {
                Brush fill = new SolidBrush(fillColor);
                Pen border = new Pen(borderColor, IsSelected ? 4 : 2);

                g.FillEllipse(fill, x, y, diameter, diameter);
                g.DrawEllipse(border, x, y, diameter, diameter);
            }
            public bool CheckClick(int mx, int my)
            {
                int center_x = x + diameter / 2;
                int center_y = y + diameter / 2;

                int distance_x = mx - center_x;
                int distance_y = my - center_y;

                // (x − a)² + (y − b)² ≤ r²
                int our_click = distance_x * distance_x + distance_y * distance_y;
                int our_radius = (diameter / 2) * (diameter / 2);

                return (our_click <= our_radius);
            }
        }
        public Form1()
        {
            InitializeComponent();
            int X = Winter.Width / 2;
            int Y = Winter.Height / 2;
            int radius = 150;
            Color border = Color.Black;
            Color fill = Color.White;

            DrawSnowMan(X, Y, radius, border, fill, 3);
        }

        private void DrawSnowMan(int start_X, int start_Y, int radius_medium, Color border, Color fill, int n_circles)
        {
            snowMan = new List<Circle>();       // створюємо шаблон для заповнення нового сніговика

            Bitmap bmp = new Bitmap(Winter.Width, Winter.Height);
            graphics = Graphics.FromImage(bmp);

            int current_y = start_Y;
            int current_diametr = radius_medium * 2;
            for (int i = 0; i < (n_circles - 1) / 2; i++)
                current_diametr /= 3;

            for (int i = 0; i < n_circles; i++)
            {
                snowMan.Add(new Circle { x = start_X - current_diametr / 2, y = current_y, diameter = current_diametr, borderColor = border, fillColor = fill, IsSelected = false });

                current_y += current_diametr;
                current_diametr += current_diametr / 3;
            }

            foreach (Circle circle in snowMan)
                circle.Draw(graphics);
            Winter.Image = bmp;

            Winter.Invalidate(); // просимо перемалювати
        }
        private void RedrawSnowMan()
        {
            Bitmap bmp = new Bitmap(Winter.Width, Winter.Height);

            graphics = Graphics.FromImage(bmp);

            foreach (Circle circle in snowMan)
            {
                circle.IsSelected = (selectedCircle == circle) ? true : false;
                circle.Draw(graphics);
            }
            Winter.Image = bmp;

            Winter.Invalidate(); // просимо перемалювати
        }
        private void LoadListBox()
        {
            listComb.Items.Clear(); // очищуємо форму
            DBDataContext db = new DBDataContext();

            foreach (var el in db.SaveGoodCombinations)
                listComb.Items.Add(el);
        }

        private void changeBorder_button_Click(object sender, EventArgs e)
        {

            if (snowMan.Count == 0) return;

            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                if (selectedCircle == null)
                    snowMan[(snowMan.Count) / 2].borderColor = cd.Color;
                else
                    selectedCircle.borderColor = cd.Color;
                RedrawSnowMan();
            }
        }
        private void changeFill_button_Click(object sender, EventArgs e)
        {
            if (snowMan.Count == 0) return;

            ColorDialog cd = new ColorDialog(); // створюємо вікно вибору кольору

            if (cd.ShowDialog() == DialogResult.OK) // отримавши результат
            {
                if (selectedCircle == null) // автоматично обираємо среедній елемент, для котрого змінюємо колір заповнення, якщо він не обраний користувачем
                    snowMan[(snowMan.Count) / 2].fillColor = cd.Color;
                else
                    selectedCircle.fillColor = cd.Color;

                RedrawSnowMan();
            }
        }

        private void Winter_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Circle circle in snowMan)
            {
                if (circle.CheckClick(e.X, e.Y))
                {
                    selectedCircle = circle;
                    RedrawSnowMan();
                    return;
                }
            }
            selectedCircle = null;
        }

        private void AddToDB_button_Click(object sender, EventArgs e)
        {
            DBDataContext db = new DBDataContext(); // Завдяки цьому класу ми відкриваємо доступ до бази даних за допомогою LINQ to SQL
            SaveGoodCombination scg = new SaveGoodCombination   // Створюємо один об'єкт нашої таблиці
            {
                FillColor = selectedCircle.fillColor.ToArgb(),
                BorderColor = selectedCircle.borderColor.ToArgb()
            }; // у фігурних дужках ми заповнюємо поля цього класу
            db.SaveGoodCombinations.InsertOnSubmit(scg); // і складаємо їх до бази
            db.SubmitChanges(); // зберігаємо ці зміни
            LoadListBox(); // просимо завантажити (бо вже оновлені дані) список елементів в базі
        }

        private void listComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listComb.SelectedItem is SaveGoodCombination comb)  // повертає обраний об'єкт
            {
                Color fill = Color.FromArgb(comb.FillColor);
                Color border = Color.FromArgb(comb.BorderColor);

                selectedCircle.fillColor = fill;
                selectedCircle.borderColor = border;
            }
            RedrawSnowMan();
        }
    }
}
