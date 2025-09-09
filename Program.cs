
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
    // TODO: create user menu
}
logger.Info("Program ended");