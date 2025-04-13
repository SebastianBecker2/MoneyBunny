namespace MoneyBunny
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    public static class AppPaths
    {
        public static string GetLocalAppPath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (!Directory.Exists(path))
            {
                _ = Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, Application.CompanyName);
            if (!Directory.Exists(path))
            {
                _ = Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, Application.ProductName);
            if (!Directory.Exists(path))
            {
                _ = Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string GetLocalAppPath(string fileName)
        {
            var path = GetLocalAppPath();
            return Path.Combine(path, fileName);
        }

        public static string GetAppPath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(path))
            {
                _ = Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, Application.CompanyName);
            if (!Directory.Exists(path))
            {
                _ = Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, Application.ProductName);
            if (!Directory.Exists(path))
            {
                _ = Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string GetAppPath(string fileName)
        {
            var path = GetAppPath();
            return Path.Combine(path, fileName);
        }

        public static string GetCommonAppPath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            if (!Directory.Exists(path))
            {
                _ = Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, Application.CompanyName);
            if (!Directory.Exists(path))
            {
                _ = Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, Application.ProductName);
            if (!Directory.Exists(path))
            {
                _ = Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string GetCommonAppPath(string fileName)
        {
            var path = GetCommonAppPath();
            return Path.Combine(path, fileName);
        }
    }
}
