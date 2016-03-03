using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockBitmap
{
    class Program
    {
        static void Main(string[] args)
        {
            var bmp = (Bitmap)Image.FromFile("H:\\source.jpg");
            var watch = new Stopwatch();
            watch.Start();

            Grayscale(bmp);

            watch.Stop();
            
            Console.WriteLine(watch.Elapsed.TotalSeconds);
            bmp.Save("H:\\result.jpg");
        }

        private static void Grayscale(Bitmap source)
        {
            using (var bmp = new LockBitmap(source))
            {
                for (var y = 0; y < bmp.Height; y++)
                {
                    for (var x = 0; x < bmp.Width; x++)
                    {
                        var color = bmp.GetPixel(x, y);
                        var minComponent = (color.R + color.G + color.B) / 3;

                        if (minComponent > 255)
                        {
                            minComponent = 255;
                        }

                        var newColor = Color.FromArgb(color.A, minComponent, minComponent, minComponent);
                        bmp.SetPixel(x, y, newColor);
                    }
                }
            }
        }
    }
}
