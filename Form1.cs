/****************************************************************************
**SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** PROGRAMLAMAYA GİRİŞİ DERSİ
**
** ÖDEV NUMARASI: 1
**ÖĞRENCİ ADI: Selva Maramaei
**ÖĞRENCİ NUMARASI: G221210583
**DERS GRUBU: 2A
YOUTUBE LİNKİ - 1: https://youtu.be/LLNDWOVkIA0
****************************************************************************/
using System.Drawing;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ndp_proje_forms_çizdirme
{
    public partial class Form1 : Form
    {
        private List<Shape> shapes = new List<Shape>();
        public abstract class Shape
        {
            protected Graphics graphics;
            protected Random location;

            public int x { get; protected set; }
            public int y { get; protected set; }
            public int z { get; protected set; }
            public Shape(Graphics graphics)
            {
                this.graphics = graphics;
                this.location = new Random();
            }

            public abstract void Draw();
        }
      
        public Form1()
        {
            InitializeComponent();
        }
        
        private class Nokta : Shape 
        {
            public Nokta(Graphics graphics) : base(graphics)
            {
                x = location.Next(30, 851);                   
                y = location.Next(30, 701);
            }

            public void RandomDraw()
            {
                graphics.FillEllipse(Brushes.Red, x, y, 10, 10);

            }
            public override void Draw()
            {
                graphics.FillEllipse(Brushes.Red, 600, 300, 10, 10);
            }

        }

        private class Dörtgen : Shape
        {
            public int genislik { get; set; } = 200;
            public int yukseklik { get; set; } = 100;
            // çerçeve boyutları
            private int çerçeveGenislik = 820;
            private int çerçeveYukseklik = 670;

            public Dörtgen(Graphics graphics) : base(graphics)
            {
                x = location.Next(çerçeveGenislik - genislik);
                y = location.Next(çerçeveYukseklik - yukseklik);
            }
            public void RandomDraw()
            {
                graphics.DrawRectangle(Pens.Black, x, y, genislik, yukseklik);
            }

            public override void Draw()
            {
                graphics.DrawRectangle(Pens.Black, 500 , 100 , 200 , 100);
            }
           
            public bool InterSectsWith(Dörtgen rectangle)
            {

                if (x + genislik >= rectangle.x && x <= rectangle.x + rectangle.genislik && y + yukseklik >= rectangle.y && y <= rectangle.y + rectangle.yukseklik)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        private class Çember : Shape 
        {
            public Çember(Graphics graphics) : base(graphics)
            {
                x = location.Next(30, 651);
                y = location.Next(30, 501);
            }

            public void RandomDraw()
            {
                graphics.DrawEllipse(Pens.Black, x, y, 200, 200);

            }
            public override void Draw()
            {
                graphics.DrawEllipse(Pens.Black, 500, 400, 200, 200);
            }

        }

        private class Küre : Shape
        {
            public Küre(Graphics graphics) : base(graphics)
            {
                x = location.Next(30, 651);
                y = location.Next(30, 501);
            }
            public void RandomDraw()
            {
                graphics.DrawEllipse(Pens.Black, x, y, 200, 200);
                graphics.DrawEllipse(Pens.Black, x, y + 60, 200, 80);

            }
            public override void Draw()
            {
                graphics.DrawEllipse(Pens.Black, 200, 200, 200, 200);
                graphics.DrawEllipse(Pens.Black, 200, 260, 200, 80);
            }

        }

        private class DörtgenPrizma : Shape 
        {
            public int genislik { get; set; } = 200;
            public int yukseklik { get; set; } = 100;
            public int derinlik { get; set; } = 50;

            private int çerçeveGenislik = 820;
            private int çerçeveYukseklik = 670;

            public DörtgenPrizma(Graphics graphics) : base(graphics)
            {
                x = location.Next(çerçeveGenislik - genislik);
                y = location.Next(çerçeveYukseklik - yukseklik);
                z = location.Next(0 , 50);
            }

            public void RandomDraw()
            {
                int dörtgenX1 = x;
                int dörtgenY1 = y;
                int dörtgenX2 = x + genislik;
                int dörtgenY2 = y + yukseklik;
               
                graphics.DrawRectangle(Pens.Black, x + derinlik , y - derinlik , genislik, yukseklik );
                graphics.DrawRectangle(Pens.Black, x, y, genislik, yukseklik);
                
                // ikisini bağlayan çizgiler 
                graphics.DrawLine(Pens.Black, dörtgenX1, dörtgenY1, dörtgenX1 + derinlik, dörtgenY1 - derinlik);
                graphics.DrawLine(Pens.Black, dörtgenX2, dörtgenY1, dörtgenX2 + derinlik, dörtgenY1 - derinlik);
                graphics.DrawLine(Pens.Black, dörtgenX2, dörtgenY2, dörtgenX2 + derinlik, dörtgenY2 - derinlik);
                graphics.DrawLine(Pens.Black, dörtgenX1, dörtgenY2, dörtgenX1 + derinlik, dörtgenY2 - derinlik);


            }

            public override void Draw()
            {
                graphics.DrawRectangle(Pens.Black, 300, 200, 200, 100);
                graphics.DrawRectangle(Pens.Black, 380, 130, 200, 100);
                graphics.DrawLine(Pens.Black, 380, 130, 300, 200);
                graphics.DrawLine(Pens.Black, 380, 230, 300, 300);
                graphics.DrawLine(Pens.Black, 580, 130, 500, 200);
                graphics.DrawLine(Pens.Black, 580, 230, 500, 300);
            }
           
        } 

        private class Silindir: Shape
        {
            public Silindir(Graphics graphics) : base(graphics)
            {
                x = location.Next(30, 651);
                y = location.Next(30, 621);
            }

            public void RandomDraw()
            {
                graphics.DrawEllipse(Pens.Black, x, y, 200, 80);
                graphics.DrawEllipse(Pens.Black, x, y + 120, 200, 80);
                graphics.DrawLine(Pens.Green, x, y + 40, x, y + 40 + 120);
                graphics.DrawLine(Pens.Red, x + 200, y + 40, x + 200, y + 40 + 120);

            }
            public override void  Draw()
            {
                graphics.DrawEllipse(Pens.Black, 50, 50, 200, 80);
                graphics.DrawLine(Pens.Black, 50, 90, 50, 210);
                graphics.DrawEllipse(Pens.Black, 50, 170, 200, 80);
                graphics.DrawLine(Pens.Black, 250, 90, 250, 210);
            }

        }

        private class Yüzey:Shape
        {
            protected int genislik { get; set; }
            protected int yukseklik { get; set; }
            public Yüzey(Graphics graphics) : base(graphics)
            {
                x = 100;
                y = 500;
                genislik = 700;
                yukseklik = 100;
            }
            public override void Draw()
            {
                graphics.DrawLine(Pens.Black, x , y , x + genislik, y);
                graphics.DrawLine(Pens.Red, x , y, x - 50 , y + yukseklik);
                graphics.DrawLine(Pens.Black, x-50 , y+yukseklik, x-50+genislik, y + yukseklik);
                graphics.DrawLine(Pens.Red, x+genislik, y , x - 50 + genislik, y + yukseklik);
            }

        }


        // şekil çizdirme 
        public void frame()   
        {
            Graphics graphics = this.CreateGraphics();
            graphics.DrawLine(Pens.Black, 10, 10, 850, 10);
            graphics.DrawLine(Pens.Black, 10, 700, 850, 700);
            graphics.DrawLine(Pens.Black, 10, 10, 10, 700);
            graphics.DrawLine(Pens.Black, 850, 10, 850, 700);

        }
       
        private void dikdörtgen_Click(object sender, EventArgs e)   
        {
            Graphics graphics = this.CreateGraphics();
            Dörtgen dörtgen = new Dörtgen(graphics);
            shapes.Add(dörtgen);
            dörtgen.Draw();
        }

        private void çember_Click(object sender, EventArgs e)    
        {
            Graphics graphics = this.CreateGraphics();
            Çember  çember = new Çember(graphics);
            shapes.Add(çember);
            çember.Draw();
           
        }

        private void nokta_Click(object sender, EventArgs e)    
        {
            Graphics graphics = this.CreateGraphics();
            Nokta nokta = new Nokta(graphics);
            shapes.Add(nokta);
            nokta.Draw();
        }

        private void küre_Click(object sender, EventArgs e)   
        {
            Graphics graphics = this.CreateGraphics();
            Küre küre = new Küre(graphics);
            shapes.Add(küre);
            küre.Draw();
        }

        private void dörtgen_priazma_Click(object sender, EventArgs e)  
        {
            Graphics graphics = this.CreateGraphics();
            DörtgenPrizma dörtgenprizma = new DörtgenPrizma(graphics);
            shapes.Add(dörtgenprizma);
            dörtgenprizma.Draw();

        }

        private void silindir_Click(object sender, EventArgs e) 
        {
            Graphics graphics = this.CreateGraphics();
            Silindir silindir = new Silindir(graphics);
            shapes.Add(silindir);
            silindir.Draw();
        }

        private void yüzey_Click(object sender, EventArgs e)   
        {
            Graphics graphics = this.CreateGraphics();
            Yüzey yüzey = new Yüzey(graphics);
            shapes.Add(yüzey);
            yüzey.Draw();
        }

        private void temizle_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }



        // çarpışma denetimi 
       
        
        private void çarpışma1_Click(object sender, EventArgs e)  // nokta - dörtgen çarpışma denetimi
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            Nokta nokta = new Nokta(graphics);
            Dörtgen dörtgen = new Dörtgen(graphics);
            nokta.RandomDraw();
            dörtgen.RandomDraw();

            if (nokta.x > dörtgen.x && nokta.x < dörtgen.x + dörtgen.genislik && nokta.y > dörtgen.y && nokta.y < dörtgen.y + dörtgen.yukseklik)
            {
                durum_textbox.Text = "çarpıştı";
            }
            else
            {
              durum_textbox.Text = "çarpışmadı";
            }

        }

        private void çarpışma2_Click(object sender, EventArgs e)    // nokta - çember çarpışma denetimi
        {
            this.Refresh();
            frame();

            Graphics graphics = this.CreateGraphics();
            Nokta nokta = new Nokta(graphics);
            Çember çember = new Çember(graphics);

            nokta.RandomDraw();
            çember.RandomDraw();

            double distance = Math.Sqrt(Math.Pow(nokta.x - (çember.x + 100), 2) + Math.Pow(nokta.y - (çember.y + 100), 2));

            if (distance <= 100 + 5)   // +5 noktatnın yarı çapı için
            {
                durum_textbox.Text = "çarpıştı";
            }
            else
            {
                durum_textbox.Text = "çarpışmadı";
            }
        }

        private void çarpışma3_Click(object sender, EventArgs e)    // dikdörtgen - dikdörtgen çarıpşması 
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            Dörtgen dörtgen1 = new Dörtgen(graphics);
            Dörtgen  dörtgen2 = new Dörtgen(graphics);

            dörtgen1.RandomDraw();
            dörtgen2.RandomDraw();

          if(dörtgen1.InterSectsWith(dörtgen2))
            {
                durum_textbox.Text = "çarpıştı";
            }
            else
            {
                durum_textbox.Text = "çarpışmadı";
            }
        }

        private void çarpışma4_Click(object sender, EventArgs e)   // çember - çember çarpışması 
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();

            Çember çember1 = new Çember(graphics);
            Çember çember2 = new Çember(graphics);

            çember1.RandomDraw();
            çember2.RandomDraw();
           
            double distance = Math.Sqrt(Math.Pow((çember1.x + 100) - (çember2.x + 100), 2) + Math.Pow((çember1.y + 100) - (çember2.y + 100), 2));

            if (distance <= 100 + 100)
            {
                durum_textbox.Text = "çarpıştı";
            }
            else
            {
                durum_textbox.Text = "çarpışmadı";
            }
        }

        private void çarpışma5_Click(object sender, EventArgs e)    // nokta - küre 
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            Nokta nokta = new Nokta(graphics);
            Küre küre = new Küre(graphics);

            nokta.RandomDraw();
            küre.RandomDraw();

            double distance = Math.Sqrt(Math.Pow(nokta.x - (küre.x + 100), 2) + Math.Pow(nokta.y - (küre.y + 100), 2));

            if (distance <= 100 + 5)   // +5 noktatnın yarı çapı için
            {
                durum_textbox.Text = "çarpıştı";
            }
            else
            {
                durum_textbox.Text = "çarpışmadı";
            }
        }

        private void çarpışma6_Click(object sender, EventArgs e)   // nokta - dikdörtgen prizma 
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            Nokta nokta = new Nokta(graphics);
            DörtgenPrizma dörtgenPrizma = new DörtgenPrizma(graphics);

            nokta.RandomDraw();
            dörtgenPrizma.RandomDraw();


            if ((nokta.x >= dörtgenPrizma.x ) && ( nokta.x <= dörtgenPrizma.x + dörtgenPrizma.genislik) && ( nokta.y >= dörtgenPrizma.y ) && ( nokta.y <= dörtgenPrizma.y + dörtgenPrizma.yukseklik))
            { 
                durum_textbox.Text = "çarpıştı";
            }
            else if ((nokta.x >= dörtgenPrizma.x + 49 ) && (nokta.x <= dörtgenPrizma.x + dörtgenPrizma.genislik + 49) && (nokta.y >= dörtgenPrizma.y - 49) && (nokta.y <= dörtgenPrizma.y + dörtgenPrizma.yukseklik - 49))
            {
                durum_textbox.Text = "çarpıştı";
            }
            else
            {
                durum_textbox.Text = "çarpışmadı";
            }
        }

        // bunu yapmadın
        private void çarpışma7_Click(object sender, EventArgs e)   // nokta - silindir
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            Nokta nokta = new Nokta(graphics);
            Silindir silindir = new Silindir(graphics);

            nokta.RandomDraw();
            silindir.RandomDraw();

             double distance = Math.Sqrt(Math.Pow(nokta.x - (silindir.x + 100), 2) + Math.Pow(nokta.y - (silindir.y +40), 2));

             if (distance <= 105) // 100 +5 
             {
                 durum_textbox.Text = "çarpıştı";
             }
             else if ( (silindir.x <= nokta.x ) && ( nokta.x <= (silindir.x + 200) && ( silindir.y +40 <= nokta.y ) && (nokta.y <= silindir.y +170))) 
             {
                 durum_textbox.Text = "çarpıştı";
             }
            else
             {
                 durum_textbox.Text = "çarpışmadı";
             }

        }
        // bunu yapmadın
        private void çarpışma8_Click(object sender, EventArgs e)   // silindir - silindir çarpışması
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            Silindir silindir1 = new Silindir(graphics);
            Silindir silindir2 = new Silindir(graphics);

            silindir1.RandomDraw();
            silindir2.RandomDraw();

            double distance = Math.Sqrt(Math.Pow(silindir1.x - silindir2.x, 2) + Math.Pow(silindir1.y - silindir2.y, 2));

            if ((Math.Abs(silindir1.x -silindir2.x)<200) && (Math.Abs(silindir1.y - silindir2.y) < 150) )
            {
                durum_textbox.Text = "çarpıştı";
            }
            else 
            {
                durum_textbox.Text = "çarpışmadı";

            }

        }

        private void çarpışma9_Click(object sender, EventArgs e)   // küre - küre çarpışma
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            Küre küre1 = new Küre(graphics);
            Küre küre2 = new Küre(graphics);

            küre1.RandomDraw();
            küre2.RandomDraw();

            double distance = Math.Sqrt(Math.Pow((küre1.x + 100) - (küre2.x + 100), 2) + Math.Pow((küre1.y + 100) - (küre2.y + 100), 2));

            if (distance <= 100 + 100)
            {
                durum_textbox.Text = "çarpıştı";
            }
            else
            {
                durum_textbox.Text = "çarpışmadı";
            }
        }

        // bunu yapmadın
        private void çarpışma10_Click(object sender, EventArgs e)  // küre - silindir
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            Küre küre = new Küre(graphics);
            Silindir silindir = new Silindir(graphics);

            silindir.RandomDraw();
            küre.RandomDraw();

            int Silindir_CenterX = (silindir.x + 200 / 2);
            int Silindir_CenterY = (((silindir.y + 120 + 80) - (silindir.y)) / 2);  // 120 = iki çemberin konumları arasındakı uzaklık . 80 = çeberin uzunluğu   
            int Küre_CenterX = küre.x + 100;
            int Küre_CenterY = küre.y + 100;

            double distance = Math.Sqrt(Math.Pow( Math.Abs( Silindir_CenterX - Küre_CenterX), 2) + Math.Pow(Math.Abs( Silindir_CenterY - Küre_CenterY), 2));

            if ((distance > 200))         // 100 : çemberin yarıçapı  . 100 : silindirin yarıçapı
            {
                durum_textbox.Text = "çarpışmadı";
            }
 
            else
            {
                durum_textbox.Text = "çarpıştı";
            }

        }
       
        private void çarpışma11_Click(object sender, EventArgs e)   // yüzey - küre
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            Küre küre = new Küre(graphics);
            Yüzey yüzey = new Yüzey(graphics);

            yüzey.Draw();
            küre.RandomDraw();

            // ilk çizgi için 
            //çizginin eğimi sıfır olduğu iiçin çemberin yatay çizgi ile arasındaki en kısa mesafe şu şekilde hesaplanır: 
            double d1 = Math.Abs(küre.y + 100 - yüzey.y);   

            if (d1 < 100)
            {
                durum_textbox.Text = "çarpıştı";
            }
            else
            {
                 durum_textbox.Text = "çarpışmadı";
            }

        }

        private void çarpışma12_Click(object sender, EventArgs e)   // yüzey - dikdörtgen prizma
        {

            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            Yüzey yüzey = new Yüzey(graphics);
            DörtgenPrizma dörtgenprizma = new DörtgenPrizma(graphics);  

            dörtgenprizma.RandomDraw(); 
            yüzey.Draw();

            if (dörtgenprizma.y + dörtgenprizma.yukseklik > yüzey.y)
            {
                durum_textbox.Text = "çarpıştı";
            }
            else
            {
                durum_textbox.Text = "çarpışmadı";
            }

        }

        private void çarpışma13_Click(object sender, EventArgs e)   // yüzey - silindir 
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            Yüzey yüzey = new Yüzey(graphics);
            Silindir silindir = new Silindir(graphics);

            silindir.RandomDraw();
            yüzey.Draw();

            if (silindir.y+210 > yüzey.y)
            {
                durum_textbox.Text = "çarpıştı";
            }
            else
            {
                durum_textbox.Text = "çarpışmadı";
            }
}

        // bunu yapmadın
        private void çarpışma14_Click(object sender, EventArgs e)  // küre - dikdörtgen prizma
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            Küre küre = new Küre(graphics);
            DörtgenPrizma dörtgenprizma = new DörtgenPrizma(graphics);

            küre.RandomDraw();
            dörtgenprizma.RandomDraw();


            int küreMerkezX = küre.x + 100;
            int küreMerkezY = küre.y + 100;
            int küreYarıçap = 100;

            // Dikdörtgen Prizma
            int prizmaX1 = dörtgenprizma.x;
            int prizmaY1 = dörtgenprizma.y;
            int prizmaX2 = dörtgenprizma.x + dörtgenprizma.genislik;
            int prizmaY2 = dörtgenprizma.y + dörtgenprizma.yukseklik;

            if (küreMerkezX + küreYarıçap < prizmaX1 || küreMerkezX - küreYarıçap > prizmaX2 || küreMerkezY + küreYarıçap < prizmaY1 || küreMerkezY - küreYarıçap > prizmaY2)
            {
                durum_textbox.Text = "çarpışmadı";
            }
            else
            {
                durum_textbox.Text = "çarpıştı";
            }
        }
       
        private void çarpışma16_Click(object sender, EventArgs e)   // dikdörtgen prizma - dikdörtgen prizma
        {
            this.Refresh();

            frame();

            Graphics graphics = this.CreateGraphics();
            DörtgenPrizma dörtgenprizma1 = new DörtgenPrizma(graphics);
            DörtgenPrizma dörtgenprizma2 = new DörtgenPrizma(graphics);

            dörtgenprizma1.RandomDraw();
            dörtgenprizma2.RandomDraw();
            
            Rectangle rectangle1_1 = new Rectangle(dörtgenprizma1.x, dörtgenprizma1.y, dörtgenprizma1.genislik, dörtgenprizma1.yukseklik);
            Rectangle rectangle1_2 = new Rectangle(dörtgenprizma1.x+ dörtgenprizma1.derinlik, dörtgenprizma1.y + dörtgenprizma1.derinlik, dörtgenprizma1.genislik, dörtgenprizma1.yukseklik);
            
            Rectangle rectangle2_1 = new Rectangle(dörtgenprizma2.x, dörtgenprizma2.y, dörtgenprizma2.genislik, dörtgenprizma2.yukseklik);
            Rectangle rectangle2_2 = new Rectangle(dörtgenprizma2.x+ dörtgenprizma2.derinlik, dörtgenprizma2.y + dörtgenprizma2.derinlik, dörtgenprizma2.genislik, dörtgenprizma2.yukseklik);

            if(rectangle1_1.IntersectsWith(rectangle2_1))
            {
                durum_textbox.Text = "çarpıştı";
            }
            else if (rectangle1_1.IntersectsWith(rectangle2_2))
            {
                durum_textbox.Text = "çarpıştı";
            }
            else if (rectangle1_2.IntersectsWith(rectangle2_2))
            {
                durum_textbox.Text = "çarpıştı";
            }
            else if (rectangle1_2.IntersectsWith(rectangle2_1))
            {
                durum_textbox.Text = "çarpıştı";
            }
            else
            {
                durum_textbox.Text = "çarpışmadı";
            }
            
          
        }
        

    }


} 