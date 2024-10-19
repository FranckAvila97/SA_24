using SA_W4.Models;

namespace SA_W4.Helpers
{
    public class SettingsBuilder
    {
        private static Settings _settings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Settings").Get<Settings>();
        public static Settings Builder
        {
            get { return _settings; }
            set { _settings = value; }
        }
    }
}
