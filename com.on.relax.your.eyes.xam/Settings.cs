namespace com.on.relax.your.eyes.xam
{

    internal sealed class Settings
    {
        //singleton impl
        static Settings() { }
        private Settings() { }
        public static Settings Instance { get; } = new Settings();

        //all settings here:

        public bool SkipHello = false;
    }
}
