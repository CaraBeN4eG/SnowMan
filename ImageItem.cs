using System;
using System.Drawing;
using System.Windows.Forms;

namespace SnowMan
{
    public class ImageItem : PictureBox // ми розширяємо функціонал існуюючого класу PictureBox під свої потреби (ООПшне наслідування)
    {
        public string ItemName { get; set; }        // назва предмету
        public Point TargetLocation { get; set; }   // де цей предмет повинен знаходитись
        public int MagneticSize { get; set; }       // як далеко діє притягнення предмету до його позиції (залежить від розміру)
        public bool isFixed { get; set; }           // чи об'єкт вже поставлений на своє місце?

        private Point mouseClickedLocation;         // де саме миша доторкнулась до картинки відносно верхнього лівого кута цього PictureBox

        public ImageItem(string ItemName, Image image, Point target, Size size)
        {
            this.ItemName = ItemName;
            this.Image = image;
            this.TargetLocation = target;
            this.isFixed = false;                               // спочатку предмет можна рухати

            this.Size = size;                                   // розмір такий самий, як у зображення
            this.MagneticSize = (Size.Width + Size.Height) / 4; // примагнічується на радіус предмета (половина середнього значнення)
            this.SizeMode = PictureBoxSizeMode.Zoom;            // масштабування зображення з збереженням пропорцій
            this.Cursor = Cursors.Hand;                         // змінюж вигляд курсора на руку при наведенні

            // підписуємо події, щоб викликались мої функції, разом з стандартними для PictureBox
            this.MouseDown += ImageItem_MouseDown;
            this.MouseMove += ImageItem_MouseMove;
            this.MouseUp += ImageItem_MouseUp;
        }
        public void ImageItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (isFixed) return; // не дозволяємо переміщувати, якщо цей об'єкт вже на своєму місці
            if (e.Button == MouseButtons.Left)
                mouseClickedLocation = e.Location; // прив'язуємо кординати кліку до змінної    
                    
        }
        public void ImageItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (isFixed) return; // не дозволяємо переміщувати, якщо цей об'єкт вже на своєму місці
            if (e.Button == MouseButtons.Left)
            {
                // зберігаємо різницю між позицією миші та місцес кліку
                this.Left += e.X - mouseClickedLocation.X;  // відстань у пікселях від лівого краю форми до лівого краю цього елемента
                this.Top += e.Y - mouseClickedLocation.Y;   // відстань від верхнього краю форми до верхнього краю елемента
            }

        }
        public void ImageItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (isFixed) return; // не дозволяємо переміщувати, якщо цей об'єкт вже на своєму місці

            // рахуємо як далеко ми є від місця предмета
            double x = this.Left - TargetLocation.X;
            double y = this.Top - TargetLocation.Y;
            // Беремо модуль
            x *= (x < 0) ? -1 : 1; 
            y *= (y < 0) ? -1 : 1; 

            if(x < MagneticSize && y < MagneticSize)
            {
                this.Location = TargetLocation;
                isFixed = true;
                this.Cursor = Cursors.Default;
            }
        }
    }
}
