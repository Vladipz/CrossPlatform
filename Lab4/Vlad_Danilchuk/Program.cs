using ClassLib;
using McMaster.Extensions.CommandLineUtils;

const string DefaultInputFileName = "INPUT.TXT";
const string DefaultOutputFileName = "OUTPUT.TXT";

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
        if (OperatingSystem.IsWindows())
        {
            Environment.SetEnvironmentVariable("LAB_PATH", path.Value(), EnvironmentVariableTarget.User);
        }
        else
        {
            var labPath = path.Value();

            // Set the environment variable for the current session
            Environment.SetEnvironmentVariable("LAB_PATH", labPath);

            // Save the environment variable in .zshrc to make it permanent
            var zshrcPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".bashrc");

            Console.WriteLine(zshrcPath);
            // Append the export command to .zshrc
            File.AppendAllText(zshrcPath, $"\nexport LAB_PATH=\"{labPath}\"\n");

            Console.WriteLine($"LAB_PATH set to {labPath} and saved to .zshrc");

            // Manually load the variable into the current C# environment
            // Parsing .zshrc to update the current environment variable
            var lines = File.ReadAllLines(zshrcPath);
            foreach (var line in lines)
            {
                if (line.StartsWith("export LAB_PATH="))
                {
                    var value = line.Split('=')[1].Trim('"');
                    Environment.SetEnvironmentVariable("LAB_PATH", value);
                    Console.WriteLine($"LAB_PATH loaded into current session as: {value}");
                }
            }
        }
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
            var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
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
            var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
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
            var folderPath = Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User);
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
    return app.Execute(args);
}
catch (Exception e)
{
    Console.WriteLine($"An error occurred: {e.Message}");
    return 1;
}
