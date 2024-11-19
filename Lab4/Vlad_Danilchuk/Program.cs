using ClassLib;
using McMaster.Extensions.CommandLineUtils;

const string DefaultInputFileName = "INPUT.TXT";
const string DefaultOutputFileName = "OUTPUT.TXT";
const string LabPathVariable = "LAB_PATH";

var app = new CommandLineApplication
{
    Name = "Vlad_Danilchuk",
    Description = "Crossplatform .NET Core console application lab 4",
};

app.HelpOption("-?|-h|--help");

app.Command("version", command =>
{
    command.Description = "Show version information";
    command.OnExecute(() =>
    {
        Console.WriteLine("Author Vlad_Danilchuk");
        Console.WriteLine("Version 1.0.0");
    });
});


app.Command("set-path", setPath =>
{
    setPath.Description = "Set path to folder with input and output files";

    var path = setPath.Option("-p|--path", "Path to folder", CommandOptionType.SingleValue).IsRequired();

    setPath.OnExecute(() =>
    {
        var labPath = path.Value();

        if (OperatingSystem.IsWindows())
        {
            Environment.SetEnvironmentVariable(LabPathVariable, labPath, EnvironmentVariableTarget.User);
            Console.WriteLine($"LAB_PATH set to {labPath} and saved for user on Windows.");
        }
        else if (OperatingSystem.IsMacOS() || OperatingSystem.IsLinux())
        {
            var userHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string shellConfigPath;

            if (OperatingSystem.IsMacOS())
            {
                shellConfigPath = Path.Combine(userHome, ".bash_profile");
            }
            else
            {
                shellConfigPath = Path.Combine(userHome, ".bashrc");
            }

            Environment.SetEnvironmentVariable(LabPathVariable, labPath);
            Console.WriteLine($"LAB_PATH set to {labPath} for the current session.");

            var exportCommand = $"\nexport LAB_PATH=\"{labPath}\"\n";
            File.AppendAllText(shellConfigPath, exportCommand);
            Console.WriteLine($"LAB_PATH saved to {shellConfigPath} for future sessions.");

            var lines = File.ReadAllLines(shellConfigPath);
            foreach (var line in lines.Where(line => line.StartsWith("export LAB_PATH=")))
            {
                var value = line.Split('=')[1].Trim('"');
                Environment.SetEnvironmentVariable(LabPathVariable, value);
                Console.WriteLine($"LAB_PATH loaded into current session as: {value}");
            }
        }
        else
        {
            Console.WriteLine("Unsupported operating system. This tool works on Windows, macOS, and Linux.");
        }

        return 0;
    });
});

app.Command("run", run =>
{
    run.Description = "Run the application";
    run.OnExecute(() =>
    {
        Console.WriteLine("Specify a subcommand");
        run.ShowHelp();
        return 1;
    });

    var input = run.Option("-i|--input", "Input file name", CommandOptionType.SingleValue, true);
    var output = run.Option("-o|--output", "Output file name", CommandOptionType.SingleValue, true);
    run.Command("lab1", lab1 =>
    {
        lab1.Description = "Run lab 1";

        lab1.OnExecute(() =>
        {
            var folderPath = Environment.GetEnvironmentVariable(LabPathVariable);
            if (string.IsNullOrEmpty(folderPath))
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, DefaultInputFileName);
            var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, DefaultOutputFileName);

            FirstLab.Execute(inputFilePath ?? "", outputFilePath ?? "");
        });
    });

    run.Command("lab2", lab2 =>
    {
        lab2.Description = "Run lab 2";

        lab2.OnExecute(() =>
        {
            var folderPath = Environment.GetEnvironmentVariable(LabPathVariable);
            if (string.IsNullOrEmpty(folderPath))
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, DefaultInputFileName);
            var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, DefaultOutputFileName);

            SecondLab.Execute(inputFilePath ?? "", outputFilePath ?? "");
        });
    });

    run.Command("lab3", lab3 =>
    {
        lab3.Description = "Run lab 3";

        lab3.OnExecute(() =>
        {
            var folderPath = Environment.GetEnvironmentVariable(LabPathVariable, EnvironmentVariableTarget.User);
            if (string.IsNullOrEmpty(folderPath))
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, DefaultInputFileName);
            var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, DefaultOutputFileName);

            ThirdLab.Execute(inputFilePath ?? "", outputFilePath ?? "");
        });
    });
});

app.OnExecute(() =>
{
    Console.WriteLine("Specify a subcommand");
    app.ShowHelp();
    return 1;
});

try
{
    return await app.ExecuteAsync(args);
}
catch (Exception e)
{
    Console.WriteLine($"An error occurred: {e.Message}");
    return 1;
}
