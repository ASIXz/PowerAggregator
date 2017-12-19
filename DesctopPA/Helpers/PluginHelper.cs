using PowerAgregator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesctopPA
{
    public static class PluginHelper
    {
        public static List<Type> Plugins;

        static PluginHelper()
        {
            Plugins = new List<Type>();
            foreach (var path in Directory.GetFiles("Plugins"))
            {
                if (path.EndsWith(".dll") && !path.EndsWith("PowerAgregator.dll"))
                {
                    LoadPlugin(path);
                }
            }
           // Plugins.Add(typeof(TelegramPlugin.TelegramPlugin));

        }

        public static string LoadPlugin(string path)
        {
            try
            {//File.ReadAllBytes
                //if (!Path.IsPathRooted(path)) path = Path.GetFullPath(path);
                Assembly module = Assembly.Load(File.ReadAllBytes(path));
                Type chatterClass = module.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IChatPlugin)));
                if (chatterClass != null)
                {
                    Plugins.Add(chatterClass);
                    return null;
                }
                else
                {
                    return "Dll is not plugin file";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string AddPlugin(string path)
        {
            if (Path.GetDirectoryName(Path.GetFullPath(path)) != Path.GetFullPath("Plugins"))
            {
                var newPath = "Plugins\\" + Path.GetFileName(path);
                if (File.Exists(newPath)) return "File already exist";
                File.Copy(path, newPath);
                var PluginLoadResult = LoadPlugin(newPath);
                if (PluginLoadResult != null)
                {
                    File.Delete(newPath);
                    return PluginLoadResult;
                }
                return null;
            }
            else
            {
                return "Plugin with same name already added";
            }
        }

        public static string RemovePlugin(Type Plugin)
        {
            try
            {
                var PluginPath = "Plugins\\" + Plugin.Assembly.ManifestModule.FullyQualifiedName;

                File.Delete(PluginPath);

                Plugins.Remove(Plugin);

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
