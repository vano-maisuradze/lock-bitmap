using NUnit.Framework;
using System.Drawing;

namespace LockBitmap.Tests
{
    [TestFixture]
    public class BitmapLockerTests
    {
        [Test]
        public void ShouldChangeColor()
        {
            var bitmap = new Bitmap(1, 1);
            var newColor = Color.FromArgb(100, 150, 200);
            using (var bl = new BitmapLocker(bitmap))
            {
                bl.SetPixel(0, 0, newColor);
            }
            Assert.AreEqual(newColor, bitmap.GetPixel(0, 0));
        }
    }
}
