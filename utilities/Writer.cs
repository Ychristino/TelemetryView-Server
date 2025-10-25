using System;
using System.IO;

namespace TelemetryServer.Utilities
{
    public class Writer
    {
        private readonly string _gameName;
        private readonly string _trackName;
        private readonly string _lap;
        private readonly string _gameDirectory;
        private readonly string _rootDirectory;

        private string _lastLapFilePath;

        public Writer(string gameName, string trackName)
        {
            if (string.IsNullOrWhiteSpace(gameName))
                throw new ArgumentException("O nome do jogo não pode ser nulo ou vazio.", nameof(gameName));
            if (string.IsNullOrWhiteSpace(trackName))
                throw new ArgumentException("O nome da pista não pode ser nulo ou vazio.", nameof(trackName));

            _gameName = SanitizeFileName(gameName);
            _trackName = SanitizeFileName(trackName);

            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string documentsPath = Path.Combine(userProfile, "Documents");
            _gameDirectory = Path.Combine(documentsPath, "TelemetryData", _gameName);
            _rootDirectory = Path.Combine(documentsPath, "TelemetryData", _gameName, _trackName);

            EnsureDirectoryExists();
        }

        private void EnsureDirectoryExists()
        {
            if (!Directory.Exists(_rootDirectory))
            {
                Directory.CreateDirectory(_rootDirectory);
            }
        }

        private static string SanitizeFileName(string name)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            foreach (var c in invalidChars)
            {
                name = name.Replace(c, '_');
            }
            return name;
        }

        public void writeConfigurationLine(string line)
        {
            if (!Directory.Exists(_gameDirectory))
            {
                Directory.CreateDirectory(_gameDirectory);
            }
            var fileName = $".structure";
            var filePath = Path.Combine(_gameDirectory, fileName);

            File.WriteAllText(filePath, line + Environment.NewLine);
        }
        
        public void WriteLine(string identifier, string driverName, int lapNumber, string line)
        {
            if (string.IsNullOrWhiteSpace(driverName))
                throw new ArgumentException("O nome do piloto não pode ser nulo ou vazio.", nameof(driverName));
            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentException("O nome do piloto não pode ser nulo ou vazio.", nameof(identifier));

            var sanitizedDriverName = SanitizeFileName(driverName);
            var sanitizedIdentifier = SanitizeFileName(identifier);
            var driverDirectory = Path.Combine(_rootDirectory, sanitizedIdentifier, sanitizedDriverName);

            if (!Directory.Exists(driverDirectory))
            {
                Directory.CreateDirectory(driverDirectory);
            }

            var fileName = $"{DateTime.Now:yyyyMMdd}_lap{lapNumber}.csv";
            var filePath = Path.Combine(driverDirectory, fileName);
            
            File.AppendAllText(filePath, line + Environment.NewLine);
        }
    }
}
