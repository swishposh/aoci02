using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace aoci2
{
    public partial class Form1 : Form
    {
        private Image<Bgr, byte> sourceImage; //глобальная переменная

        private universal universal = new universal();

        public Form1()
        {
            InitializeComponent();
        }

        public Emgu.CV.Image<Bgr, byte> openImg()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\Users\\click\\Documents\\2020-2021\\AOCI\\01\\";
            openFileDialog.Filter = "jpg files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; | All files (*.*)|*.*";
            var result = openFileDialog.ShowDialog(); // открытие диалога выбора файла

            if (result == DialogResult.OK) // открытие выбранного файла
            {
                string fileName = openFileDialog.FileName;
                return new Image<Bgr, byte>(fileName).Resize(640, 480, Inter.Linear);
            }
            return null;
        }

        private void load_Click(object sender, EventArgs e)
        {
            sourceImage = openImg();
            imageBox1.Image = sourceImage;
        }


        public Emgu.CV.Image<Gray, byte> fbw(Image<Bgr, byte> sourceImage)
        {
            var grayImage = new Image<Gray, byte>(sourceImage.Size);
            //var grayImage = sourceImage.Copy(); //new Image<Gray, byte>(sourceImage.Size);

            for (int y = 0; y < grayImage.Height; y++)
                for (int x = 0; x < grayImage.Width; x++)
                {
                    // заполнение значений "серого" изображения должно осуществляться в цикле
                    grayImage.Data[y, x, 0] = Convert.ToByte(0.299 * sourceImage.Data[y, x, 2] + 0.587 *
                    sourceImage.Data[y, x, 1] + 0.114 * sourceImage.Data[y, x, 0]);
                    //for (int c = 0; c <= 2; c++)
                    //{
                    //    grayImage.Data[y, x, c] = Convert.ToByte(0.1 * grayImage.Data[y, x, 0] + 0.6 * 
                    //        grayImage.Data[y, x, 1] + 0.3 * grayImage.Data[y, x, 2]);
                    //}
                        
                }
            return grayImage;
        }

        private void bw_Click(object sender, EventArgs e)
        {
            //var channel = sourceImage.Split()[0];

            //Image<Bgr, byte> destImage = sourceImage.CopyBlank();

            //VectorOfMat vm = new VectorOfMat();
            //vm.Push(channel);
            //vm.Push(channel.CopyBlank());
            //vm.Push(channel.CopyBlank());
            //CvInvoke.Merge(vm, destImage);

            //imageBox2.Image = destImage;

            // создание "серого" изображения
            
                    

            imageBox2.Image = fbw(sourceImage);
        }

        public Emgu.CV.Image<Bgr, byte> fcontrast(Image<Bgr, byte> sourceImage, double value)
        {
            var contrastImage = sourceImage.Copy();
            //int c = 2;
            //double c = 0.5;

            for (int ch = 0; ch < 3; ch++)
                for (int y = 0; y < contrastImage.Height; y++)
                    for (int x = 0; x < contrastImage.Width; x++)
                    {
                        if ((contrastImage.Data[y, x, ch] * value) > 255)
                            contrastImage.Data[y, x, ch] = 255;
                        else
                            contrastImage.Data[y, x, ch] = Convert.ToByte(contrastImage.Data[y, x, ch] * value);

                        //contrastImage.Data[y, x, 1] = Convert.ToByte(contrastImage.Data[y, x, 1] * c);
                        //contrastImage.Data[y, x, 2] = Convert.ToByte(contrastImage.Data[y, x, 2] * c);
                    }
            return contrastImage;
        }

        private void contrast_Click(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(textBox1.Text);
            imageBox2.Image = fcontrast(sourceImage, value);
        }

        private void hsv_Click(object sender, EventArgs e)
        {
            Image<Hsv, byte> hsvImage = sourceImage.Convert<Hsv, byte>();

            for (int y = 0; y < hsvImage.Height; y++)
                for (int x = 0; x < hsvImage.Width; x++)
                {
                    hsvImage.Data[y, x, 0] = 100;
                }

            imageBox2.Image = hsvImage;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Image<Hsv, byte> hsvImage = sourceImage.Convert<Hsv, byte>();

            for (int y = 0; y < hsvImage.Height; y++)
                for (int x = 0; x < hsvImage.Width; x++)
                {
                    hsvImage.Data[y, x, 0] = (byte)(trackBar1.Value); //cvetovoq ton
                    //hsvImage.Data[y, x, 1] = (byte)(trackBar1.Value); //nassuchennost
                }

            imageBox2.Image = hsvImage;
        }


        public Image<Gray, byte> fblur(Image<Bgr, byte> sourceImage)
        {
            Image<Gray, byte> gary = sourceImage.Convert<Gray, byte>();
            Image<Gray, byte> result = gary.CopyBlank();

            List<byte> l = new List<byte>();

            int sh = 4;
            int N = 9;

            for (int y = sh; y < gary.Height - sh; y++)
                for (int x = sh; x < gary.Width - sh; x++)
                {
                    l.Clear();

                    for (int i = -1; i < 2; i++)
                        for (int j = -1; j < 2; j++)
                        {
                            l.Add(gary.Data[i + y, j + x, 0]);
                        }

                    l.Sort();

                    result.Data[y, x, 0] = l[N / 2];

                    //gary.Data[y, x, 0] = (byte)(trackBar1.Value);
                }
            return result.Resize(640, 480, Inter.Linear);
        }

        private void blur_Click(object sender, EventArgs e)
        {
            //imageBox1.Image = gary;
            imageBox2.Image = fblur(sourceImage);
        }


        public Image<Gray, byte> fsharp(Image<Bgr, byte> sourceImage, int[,] wnd)
        {


            var bl = fbw(sourceImage);

            var resultImage = new Image<Gray, byte>(bl.Size);
            for (int x = 1; x < bl.Width - 1; x++)
                for (int y = 1; y < bl.Height - 1; y++)
                {
                    double cB = 0;
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            cB += sourceImage.Data[y + i, x + j, 0] * wnd[i + 1, j + 1];
                        }
                    if (cB > 254)
                        cB = 255;
                    if (cB < 0)
                        cB = 0;
                    resultImage.Data[y, x, 0] = Convert.ToByte(cB);

                }
            return resultImage;
        }

        private void sharp_Click(object sender, EventArgs e)
        {
            int[,] wnd = new int[,]
            {
                { Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text)},
                { Convert.ToInt32(textBox5.Text),  Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text)},
                { Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox10.Text)}
            };
            imageBox2.Image = fsharp(sourceImage, wnd);

            //Image<Gray, byte> gary = sourceImage.Convert<Gray, byte>();
            //Image<Gray, byte> result = gary.CopyBlank();

            //int[,] w = new int[3, 3]
            //   {
            //       {-1, -1, -1},
            //       {-1, 9, -1},
            //       {-1, -1, -1}
            //   };

            ////List<byte> l = new List<byte>();

            //int sh = 1;
            ////int N = 3;

            //for (int y = sh; y < gary.Height - sh; y++)
            //    for (int x = sh; x < gary.Width - sh; x++)
            //    {
            //        //l.Clear();
            //        int r = 0;

            //        for (int i = -1; i < 2; i++)
            //            for (int j = -1; j < 2; j++)
            //            {
            //                r += gary.Data[i + y, j + x, 0] * w[i+1, j+1];
            //            }

            //        //l.Sort();

            //        if (r > 255) r = 255;
            //        if (r < 0) r = 0;

            //        result.Data[y, x, 0] = (byte)r;

            //        //gary.Data[y, x, 0] = (byte)(trackBar1.Value);
            //    }
            //imageBox1.Image = gary;
            //imageBox2.Image = result;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                var channel = sourceImage.Split()[2];

                Image<Bgr, byte> destImage = sourceImage.CopyBlank();

                VectorOfMat vm = new VectorOfMat();
                
                vm.Push(channel.CopyBlank());
                vm.Push(channel.CopyBlank());
                vm.Push(channel);

                CvInvoke.Merge(vm, destImage);

                imageBox2.Image = destImage;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                var channel = sourceImage.Split()[1];

                Image<Bgr, byte> destImage = sourceImage.CopyBlank();

                VectorOfMat vm = new VectorOfMat();

                vm.Push(channel.CopyBlank());
                vm.Push(channel);
                vm.Push(channel.CopyBlank());

                CvInvoke.Merge(vm, destImage);

                imageBox2.Image = destImage;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                var channel = sourceImage.Split()[0];

                Image<Bgr, byte> destImage = sourceImage.CopyBlank();

                VectorOfMat vm = new VectorOfMat();

                vm.Push(channel);
                vm.Push(channel.CopyBlank());
                vm.Push(channel.CopyBlank());

                CvInvoke.Merge(vm, destImage);

                imageBox2.Image = destImage;
            }
        }

        private void sepia_Click(object sender, EventArgs e)
        {
            var sepiaImage = sourceImage.Copy();

            for (int x = 0; x < sourceImage.Width; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    var red = sourceImage[y, x].Red;
                    var green = sourceImage[y, x].Green;
                    var blue = sourceImage[y, x].Blue;

                    var color = red * 0.393 + green * 0.769 + blue * 0.189;
                    if (color > 255) color = 255;
                    sepiaImage.Data[y, x, 2] = Convert.ToByte(color);

                    color = red * 0.349 + green * 0.686 + blue * 0.168;
                    if (color > 255) color = 255;
                    sepiaImage.Data[y, x, 1] = Convert.ToByte(color);

                    color = red * 0.272 + green * 0.534 + blue * 0.131;
                    if (color > 255) color = 255;
                    sepiaImage.Data[y, x, 0] = Convert.ToByte(color);
                }

            imageBox2.Image = sepiaImage;
        }



        public Image<Bgr, byte> Plus(Image<Bgr, byte> image, Image<Bgr, byte> secimage, int sum, double cf1, double cf2)
        {
            var brightimage = image.Copy();
            for (int x = 0; x < brightimage.Width; x++)
            {
                for (int y = 0; y < brightimage.Height; y++)
                {
                    for (int c = 0; c <= 2; c++)
                    {
                        if (secimage != null)
                        {
                            if ((image.Data[y, x, c] * cf1 + secimage.Data[y, x, c] * cf2) > 255)
                            {
                                brightimage.Data[y, x, c] = 255;
                            }
                            else
                            {
                                brightimage.Data[y, x, c] = Convert.ToByte(image.Data[y, x, c] * cf1 + secimage.Data[y, x, c] * cf2);
                            }
                        }
                        else
                        {
                            if ((brightimage.Data[y, x, c] + sum) > 255)
                            {
                                brightimage.Data[y, x, c] = 255;
                            }
                            else
                            {
                                brightimage.Data[y, x, c] += Convert.ToByte(sum);
                            }
                        }
                    }
                }
            }
            return brightimage;
        }



        public Image<Bgr, byte> Minus(Image<Bgr, byte> image, Image<Bgr, byte> secimage, int sum, double cf1, double cf2)
        {
            var brightimage = image.Copy();
            for (int x = 0; x < brightimage.Width; x++)
            {
                for (int y = 0; y < brightimage.Height; y++)
                {
                    for (int c = 0; c <= 2; c++)
                    {
                        if (secimage != null)
                        {
                            if (Convert.ToInt16(image.Data[y, x, c] * cf1 - secimage.Data[y, x, c] * cf2) < 0)
                            {
                                brightimage.Data[y, x, c] = 0;
                            }
                            else
                            {
                                brightimage.Data[y, x, c] = Convert.ToByte(image.Data[y, x, c] * cf1 - secimage.Data[y, x, c] * cf2);
                            }
                        }
                        else
                        {
                            if ((Convert.ToInt32(brightimage.Data[y, x, c]) + sum) < 0)
                            {
                                brightimage.Data[y, x, c] = 0;
                            }
                            else
                            {
                                brightimage.Data[y, x, c] = Convert.ToByte(Convert.ToInt16(brightimage.Data[y, x, c]) + sum);
                            }
                        }
                    }
                }
            }
            return brightimage;
        }

        public Image<Bgr, byte> Peresech(Image<Bgr, byte> image, Image<Bgr, byte> secimage, double sum, double cf1, double cf2)
        {
            var contrastimage = image.Copy();
            for (int x = 0; x < contrastimage.Width; x++)
            {
                for (int y = 0; y < contrastimage.Height; y++)
                {
                    for (int c = 0; c <= 2; c++)
                    {
                        if (secimage != null)
                        {
                            if (Convert.ToDouble((image.Data[y, x, c] * cf1 / 10) * (secimage.Data[y, x, c] * cf2 / 10)) > 255)
                            {
                                contrastimage.Data[y, x, c] = 255;
                            }
                            else
                            {
                                contrastimage.Data[y, x, c] = Convert.ToByte((image.Data[y, x, c] * cf1 / 10) * (secimage.Data[y, x, c] * cf2 / 10));
                            }
                        }
                        else
                        {
                            if ((contrastimage.Data[y, x, c] * Convert.ToDouble(sum / 10)) > 255)
                            {
                                contrastimage.Data[y, x, c] = 255;
                            }
                            else
                            {
                                contrastimage.Data[y, x, c] = Convert.ToByte(contrastimage.Data[y, x, c] * Convert.ToDouble(sum / 10));
                            }
                        }
                    }
                }
            }
            return contrastimage;
        }

        public Image<Bgr, byte> makeOperate(Image<Bgr, byte> sourceImage, int type)
        {
            var resultImage = new Image<Bgr, byte>(sourceImage.Size);
            switch (type)
            {
                case 0:
                    {
                        return Plus(sourceImage, openImg(), 1, 0.5, 0.5);

                    }
                case 1:
                    {
                        return Minus(sourceImage, openImg(), 1, 0.5, 0.5);

                    }
                case 2:
                    {
                        return Peresech(sourceImage, openImg(), 1, 0.5, 0.5);

                    }
            }
            return null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            imageBox2.Image = makeOperate(sourceImage, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imageBox2.Image = makeOperate(sourceImage, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imageBox2.Image = makeOperate(sourceImage, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (trackBar2.Value > 255)
            {
                imageBox2.Image = Plus(sourceImage, null, trackBar2.Value - 255, 1, 1);
            }
            else
            {
                imageBox2.Image = Minus(sourceImage, null, trackBar2.Value - 255, 1, 1);
            }
        }

        public Image<Bgr, byte> facva(Image<Bgr, byte> sourceImage)
        {
            var temp = makeOperate(sourceImage, 0);
            return temp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            imageBox2.Image = facva(sourceImage);
        }

        public Image<Gray, byte> makeGrayde(Image<Gray, byte> sourceImage)
        {
            Image<Bgr, byte> gary = sourceImage.Convert<Bgr, byte>();
            
             var edges = fbw(gary);
             Image<Gray, byte> grayedges = edges.Convert<Gray, byte>();
             grayedges = grayedges.ThresholdAdaptive(new Gray(255), AdaptiveThresholdType.MeanC, ThresholdType.Binary, 3, new Gray(0.03));
            return grayedges;
        }
        public Image<Gray, byte> fcartoon(Image<Bgr, byte> sourceImage)
        {
            var cartoonimg = fblur(sourceImage).Resize(640,480,Inter.Linear);
            Image<Gray, byte> grayedge = makeGrayde((cartoonimg));
            for (int i = 0; i < cartoonimg.Width; i++)
            {
                for (int j = 0; j < cartoonimg.Height; j++)
                {
                    if (grayedge.Data[j, i, 0] > 0)
                    {
                        
                    }
                    else
                    {
                        cartoonimg.Data[j, i, 0] = 1;
                        //cartoonimg.Data[j, i, 1] = 0;
                        //cartoonimg.Data[j, i, 2] = 0;
                    }
                }
            }
            return cartoonimg;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            imageBox2.Image = fcartoon(sourceImage);
        }
    }
}
