using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TurtleChallenge.GameRunner;
using TurtleChallenge.Settings.GameSettingsFiles;
using TurtleChallenge.Settings.MovesFiles;

namespace TurtleChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            Init(args);
        }

        private static void Init(string[] args)
        {
            var builder = Host.CreateApplicationBuilder();
            builder.Services.AddScoped<ISettingsParser, JsonSettingsParser>();
            builder.Services.AddScoped<IMovesParser, JsonMovesParser>();
            builder.Services.AddHostedService(provider =>
            {
                var settings = ReadSettings(args[0], provider.GetRequiredService<ISettingsParser>());
                var moves = ReadMoves(args[1], provider.GetRequiredService<IMovesParser>());
                var isVisual = false;
                if (args.Length > 2)
                {
                    isVisual = bool.Parse(args[2]);
                }
                return new TurtleGameRunner(settings, moves, isVisual);
            });

            var gameRunner = builder.Build();
            gameRunner.Run();
        }


        private static GameSettings ReadSettings(string settingsFile, ISettingsParser parser)
        {
            using var file = new StreamReader(settingsFile);
            try
            {
                return parser.Parse(file.ReadToEnd());
            }
            catch
            {
                Console.WriteLine("INVALID SETTINGS FILE!");
                Environment.Exit(0);
            }
            return null;
        }

        private static MovesSettings ReadMoves(string settingsFile, IMovesParser parser)
        {
            using var file = new StreamReader(settingsFile);
            try
            {
                return parser.Parse(file.ReadToEnd());
            }
            catch
            {
                Console.WriteLine("INVALID SETTINGS FILE!");
                Environment.Exit(0);
            }
            return null;
        }
    }
}