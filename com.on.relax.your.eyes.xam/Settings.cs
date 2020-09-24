namespace com.on.relax.your.eyes.xam
{

    internal sealed class Settings
    {
        //singleton impl
        static Settings() { }
        private Settings() { }
        public static Settings Instance { get; } = new Settings();

        //all settings here:
        //main settings shoud not be renamed
        public readonly string SkipHello = nameof(SkipHello);

        public readonly string StateKey = nameof(StateKey);
    }
}
