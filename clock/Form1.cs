namespace clock
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DateTime dt = DateTime.Now;
            Pen clockPen = new Pen(Color.Black, 2);
            Pen minutesArrowPen = new Pen(Color.DarkBlue, 3);
            Pen secondArrowPen = new Pen(Color.DarkRed, 2);
            Pen hourArrowPen = new Pen(Color.DarkGreen, 5);
            Brush brush = new SolidBrush(Color.Black);
            Graphics g = e.Graphics;
            GraphicsState gs;
            int w = 400;
            int h = 400;
            g.TranslateTransform(w / 2, h / 2);
            for (int i=0; i < 60; i++)
            {
                
                gs = g.Save();
                g.RotateTransform(i*6);
                if (i % 5 == 0)
                {
                    g.DrawLine(clockPen, 0, 80, 0, 100);
                } else
                {
                    g.DrawLine(clockPen, 0, 90, 0, 100);
                }
                
                g.Restore(gs);
            }
            Font f = new Font("Sans", 12);
            g.DrawString("12", f, brush, -10, -80);
            g.DrawString("3", f, brush, 65, -10);
            g.DrawString("6", f, brush, -10, 60);
            g.DrawString("9", f, brush, -80, -10);

            gs = g.Save();
            g.RotateTransform(30 * (dt.Hour + (float)dt.Minute / 60));
            g.DrawLine(hourArrowPen, 0, 0, 0, -40);
            g.Restore(gs);

            gs = g.Save();
            g.RotateTransform(6 * (dt.Minute + (float)dt.Second / 60));
            g.DrawLine(minutesArrowPen, 0, 0, 0, -60);
            g.Restore(gs);
           

            gs = g.Save();
            g.RotateTransform(6 * dt.Second );
            g.DrawLine(secondArrowPen, 0, 0, 0, -80);
            g.Restore(gs);


            g.DrawEllipse(clockPen, -w / 4, -h / 4, w / 2, h / 2);
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}