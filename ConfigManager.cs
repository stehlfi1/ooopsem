// ConfigurationManager.cs

namespace ooopsem
{
    public class Config
    {
        private static Config ?_instance;

        public int Width { get; private set; }
        public int Height { get; private set; }

        private Config()
        {
            Width = 200;
            Height = 100;
        }

        public static Config Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Config();
                }
                return _instance;
            }
        }
    }
}
