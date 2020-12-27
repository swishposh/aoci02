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
    class universal
    {
        public double a = 100;
        //public double a2 = 63;

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


        public Emgu.CV.Image<Bgr, byte> effect(Image<Bgr, byte> sourceImage, double cannyThreshold, double cannyThresholdLinking)
        {
            Image<Gray, byte> grayImage = sourceImage.Convert<Gray, byte>();

            var tempImage = grayImage.PyrDown();
            var destImage = tempImage.PyrUp();

            //double cannyThreshold = 80.0;
            //double cannyThresholdLinking = 40.0;
            Image<Gray, byte> cannyEdges = destImage.Canny(cannyThreshold, cannyThresholdLinking);

            // cannyEdges._Dilate(1);

            Image<Bgr, byte> cannyEdgesBgr = cannyEdges.Convert<Bgr, byte>();
            Image<Bgr, byte> resultImage = sourceImage.Sub(cannyEdgesBgr); // попиксельное вычитание

            //обход по каналам
            for (int channel = 0; channel < resultImage.NumberOfChannels; channel++)
                for (int x = 0; x < resultImage.Width; x++)
                    for (int y = 0; y < resultImage.Height; y++) // обход по пискелям
                    {
                        // получение цвета пикселя
                        byte color = resultImage.Data[y, x, channel];
                        if (color <= 50)
                            color = 0;
                        //else if (color <= 100)
                        //    color = 25;
                        else if (a <= 150)
                            a = 100;
                        else if (color <= 200)
                            color = 200;
                        else
                            color = 255;
                        resultImage.Data[y, x, channel] = color; // изменение цвета пикселя

                        ////byte color = 0;

                        ////byte r = resultImage.Data[y, x, 2];
                        ////byte g = resultImage.Data[y, x, 1];
                        ////byte b = resultImage.Data[y, x, 0];

                        ////color = Math.Max(r, g);
                        ////color = Math.Max(color, b);

                        ////byte th = (byte)(color / a); 32
                        ////th = (byte)((th + 1) * 63); 32

                        ////color = (byte)(th - color);

                        ////r = (byte)(r + color);
                        ////g = (byte)(g + color);
                        ////b = (byte)(b + color);

                        ////resultImage.Data[y, x, 2] = r;
                        ////resultImage.Data[y, x, 1] = g;
                        ////resultImage.Data[y, x, 0] = b;
                    }

            return resultImage; //.Resize(640, 480, Inter.Linear)
        }
    }
}
