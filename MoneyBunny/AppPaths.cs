using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace MoneyBunny
{
    public static class AppPaths
    {
		public static string GetLocalAppPath()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			path = Path.Combine(path, Application.CompanyName);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			path = Path.Combine(path, Application.ProductName);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			return path;
		}

		public static string GetLocalAppPath(string file_name)
		{
			string path = GetLocalAppPath();
			return Path.Combine(path, file_name);
		}

		public static string GetAppPath()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			path = Path.Combine(path, Application.CompanyName);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			path = Path.Combine(path, Application.ProductName);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			return path;
		}

		public static string GetAppPath(string file_name)
		{
			string path = GetAppPath();
			return Path.Combine(path, file_name);
		}

		public static string GetCommonAppPath()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			path = Path.Combine(path, Application.CompanyName);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			path = Path.Combine(path, Application.ProductName);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			return path;
		}

		public static string GetCommonAppPath(string file_name)
		{
			string path = GetCommonAppPath();
			return Path.Combine(path, file_name);
		}
	}
}
