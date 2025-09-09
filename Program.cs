//This should be working, I just wanted to figure out how to get nlog working before staring on going forward.
using NLog;

string path = Directory.GetCurrentDirectory() + "//nlog.config";



var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();
logger.Trace("Sample trace message");
logger.Debug("Sample debug message");
logger.Info("Sample informational message");
logger.Warn("Sample warning message");
logger.Error("Sample error message");
logger.Fatal("Sample fatal error message");


