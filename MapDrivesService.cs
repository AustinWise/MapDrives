using System.Diagnostics;
using System.ServiceProcess;

namespace MapDrive
{
    public partial class MapDrivesService : ServiceBase
    {
        public MapDrivesService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            foreach (var line in Properties.Settings.Default.DrivesToMap)
            {
                var splitLine = line.Split('|');
                var driveLetter = splitLine[0];
                var destPath = splitLine[1]; //the path should not end in a slash
                unmapDrive(driveLetter);
                mapDrive(driveLetter, destPath);
            }
        }

        protected override void OnStop()
        {
            foreach (var line in Properties.Settings.Default.DrivesToMap)
            {
                var splitLine = line.Split('|');
                var driveLetter = splitLine[0];
                var destPath = splitLine[1];
                unmapDrive(driveLetter);
            }
        }

        private void unmapDrive(string letter)
        {
            Process.Start("net.exe", string.Format("use {0}: /delete", letter)).WaitForExit();
        }

        private void mapDrive(string letter, string path)
        {
            Process.Start("net.exe", string.Format("use {0}: \"{1}\"", letter, path)).WaitForExit();
        }
    }
}
