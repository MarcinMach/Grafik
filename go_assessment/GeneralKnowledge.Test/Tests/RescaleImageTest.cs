using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public void Run()
        {
            var image = ResizerImage(200, 300);
            // TODO:
            // Grab an image from a public URL and write a function thats rescale the image to a desired format
            // The use of 3rd party plugins is permitted
            // For example: 100x80 (thumbnail) and 1200x1600 (preview)
        }


        public Image GetImage()
        {
            using (WebClient client = new WebClient())
            {
                var data = client.DownloadData("https://www.google.co.uk/images/srpr/logo11w.png");
                using (MemoryStream ms = new MemoryStream(data))
                {
                    Image img = Image.FromStream(ms);
                    return img;
                }
            }
        }

        public Image ResizerImage(int width, int height)
        {
            var image = GetImage();
            var newImage = new Bitmap(image, width, height);
            Image resizeImage = (Image)newImage;
            return resizeImage;
        }
    }
}
