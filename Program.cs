
using NLog;
using NLog.Targets;

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

            if (line is not null)
            { //ensures the line has data


                //details still seperated by commas so I split them 
                string[] fileDetails = line.Split(',');

                //id first
                ids.Add(UInt64.Parse(fileDetails[0]));
                //then name
                names.Add(fileDetails[1]);
                //then description
                descriptions.Add(fileDetails[2]);
                //then species
                species.Add(fileDetails[3]);
                //then first appearance
                firstAppear.Add(fileDetails[4]);
                //finally, the year created
                yearCreated.Add(UInt64.Parse(fileDetails[5]));

            }
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
            Console.WriteLine("Enter new character's name: ");
            string? Name = Console.ReadLine();
            if (!string.IsNullOrEmpty(Name))
            {
                //adding in duplication check first
                List<string> lowerCaseNames = names.ConvertAll(n => n.ToLower());
                if (lowerCaseNames.Contains(Name.ToLower()))
                {
                    logger.Info($"Dupelicated name {Name}");
                }
                else
                {
                    //I am allowing these details to be null, as them being empty is ok in my book
                    Console.WriteLine("Enter description of the character: ");
                    string? desc = Console.ReadLine();

                    Console.WriteLine("Enter character species: ");
                    string? spec = Console.ReadLine();

                    Console.WriteLine("Enter the media they first appeared in: ");
                    string? fappear = Console.ReadLine();

                    Console.WriteLine("Enter what year they got created: ");
                    UInt64 createdyear = Convert.ToUInt64(Console.ReadLine());




                    //generate id as it isn't needed to be inputted
                    UInt64 id = ids.Max() + 1;
                    
                    StreamWriter sw = new(file, true);
                    sw.WriteLine($"{id},{Name},{desc},{spec},{fappear},{createdyear}");
                    sw.Close();
                    // add new character details to Lists
                    ids.Add(id);
                    names.Add(Name);
                    descriptions.Add(desc);
                    species.Add(spec);
                    firstAppear.Add(fappear);
                    yearCreated.Add(createdyear);

                    // log transaction
                    logger.Info($"Character id {id} added");


                }
            }
            else
            {
                logger.Error($"Cannont add a character with an empty name {Name}");
            }
        }
        else if (choice == "2")
        {
            // functionality should work, will see if i can create error exeptions later
            for (int i = 0; i < ids.Count; i++)
            {
                // display character details
                Console.WriteLine($"Id: {ids[i]}");
                Console.WriteLine($"Name: {names[i]}");
                Console.WriteLine($"Description: {descriptions[i]}");
                Console.WriteLine($"Species: {species[i]}");
                Console.WriteLine($"First Appearance: {firstAppear[i]}");
                Console.WriteLine($"Year Created: {yearCreated[i]}");
                Console.WriteLine();
            }
        }
    } while (choice == "1" || choice == "2");
}
logger.Info("Program ended");