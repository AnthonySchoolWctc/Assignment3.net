
using NLog;

string path = Directory.GetCurrentDirectory() + "//nlog.config";



var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();






// Beginning to work on dk example as a start point


logger.Info("Program started");

string file = "mario.csv";
// This is changed to mario.csv on this project to make it work for the future
if (!File.Exists(file))
{
    logger.Error("File does not exist: {File}", file);
    //from my understanding this is just a type of error message for developers.
}
else
{
    // User menu: Same as from dk project as it I feel like something shouldn't try and be fixed if it aint broke
    //right here I created the lists 
    List<UInt64> ids = [];
    List<string> names = [];
    List<string> descriptions = [];
    List<string> species = [];
    List<string> firstAppear = [];
    List<UInt64> yearCreated = [];
    // now I populate them before the menu appears



    try
    {
         StreamReader sr = new(file);
        // first line is headers, so skip it with .readline()
        sr.ReadLine();
        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            Console.WriteLine(line);
            
        }
        sr.Close();
    }
    catch (Exception ex)
    {
        logger.Error(ex.Message);
    }
    //This try should catch exceptions and input them to the logger
    

















    string? choice;
    do
    {
        // adds if 1 selected, displays if 2 selected, logger keeps the choice in the log for debugging.
        Console.WriteLine("1) Add Character");
        Console.WriteLine("2) Display All Characters");
        Console.WriteLine("Enter to quit");

        // input selection
        choice = Console.ReadLine();
        logger.Info("User choice: {Choice}", choice);

        if (choice == "1")
        {
            // Add Character
        }
        else if (choice == "2")
        {
            // Display All Characters
        }
    } while (choice == "1" || choice == "2");
}
logger.Info("Program ended");