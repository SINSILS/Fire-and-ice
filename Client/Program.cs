namespace Client
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //Application.Run(new Lobby());
            Application.Run(new Forma());
        }
    }
}