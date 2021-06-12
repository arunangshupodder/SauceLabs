using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SauceLabs.Automation.Utils
{
    class Config
    {
        public static readonly string PROJECT_ROOT = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\";
        private static readonly string CONFIG_FILE = PROJECT_ROOT + "Resources\\test-config.json";
        private static JObject config;

        static Config()
        {
            StreamReader file = File.OpenText(CONFIG_FILE);
            JsonTextReader reader = new JsonTextReader(file);
            config = (JObject)JToken.ReadFrom(reader);
        }

        public static string GetProjectRoot()
        {
            return PROJECT_ROOT;
        }

        public static string GetApplicationURL()
        {
            return (string)config.GetValue("app.url");
        }

        public static string GetBrowserType()
        {
            return (string)config.GetValue("browser");
        }

        public static string GetStandardUser()
        {
            return (string)config.GetValue("username.standard");
        }

        public static string GetPassword()
        {
            return (string)config.GetValue("password");
        }
    }
}
