using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesctopPA
{
    public static class ImageHelper
    {
        public static ImageList List = new ImageList();
        static ImageHelper()
        {
            List.ImageSize = new Size(44, 44);
            var dir = Directory.GetFiles(Path.GetFullPath("img"));
            foreach (var item in dir)
            {
                Image img;
                using (var bmpTemp = new Bitmap(item))
                {
                    img = new Bitmap(bmpTemp);
                }
                List.Images.Add(Path.GetFileNameWithoutExtension(item), img);
            }
        }

        public static string GetImageKey(string name)
        {
            string ImageKey = string.Concat(name.Where(x => !Path.GetInvalidPathChars().Contains(x)));
            return List.Images.Keys.Contains(ImageKey) ? ImageKey : "default";
        }

        public static Image GetImage(string name)
        {
            return List.Images[GetImageKey(name)];
        }

        public static string AddImage(string path, string name)
        {
            string ImageKey = string.Concat(name.Where(x => !Path.GetInvalidPathChars().Contains(x)));
            string newPath = Path.GetFullPath($"img\\{ImageKey}.jpg");
            
            if(List.Images.ContainsKey(ImageKey))
            {
                File.Delete(newPath);
                List.Images.RemoveByKey(ImageKey);
            }
            Image img;
            using (var bmpTemp = new Bitmap(path))
            {
                img = new Bitmap(bmpTemp);
            }
            List.Images.Add(ImageKey, img);
            img.Save(newPath, System.Drawing.Imaging.ImageFormat.Jpeg);

            return ImageKey;
        }

        public static string GetImagePath(string ImageKey)
        {
            string dir = Directory.GetFiles(Path.GetFullPath("img")).First(x => Path.GetFileNameWithoutExtension(x) == ImageKey);
            return dir;
        }

        public static string RenameImage(string oldName, string newName)
        {
            string ImageKey = GetImageKey(oldName);
            if (ImageKey != "default")
            {
                string NewImageKey = string.Concat(newName.Where(x => !Path.GetInvalidPathChars().Contains(x)));

                List.Images.SetKeyName(List.Images.IndexOfKey(ImageKey), newName);

                var CurrentPath = GetImagePath(ImageKey);
                File.Move(CurrentPath, Path.GetDirectoryName(CurrentPath) + "\\" + NewImageKey + ".jpg");

                return NewImageKey;
            }
            return "default";
        }

        public static bool RemoveImage(string name)
        {
            string ImageKey = GetImageKey(name);
            if (ImageKey != "default")
            {
                var CurrentPath = GetImagePath(ImageKey);
                File.Delete(CurrentPath);
                List.Images.RemoveByKey(ImageKey);
                return true;
            }
            return false;
        }
    }
}
