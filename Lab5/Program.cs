//string [] name = {"ada Lovelace", "grace hopper", "margaret hamilton", "emily dickinson"};

/*User Input
Console.WriteLine("Please enter the names:? ");
int numNames = Convert.ToInt32(Console.ReadLine());
string[] name = new string[numNames];

for(int i = 0; i < numNames; i++)
{
    Console.WriteLine("Give me a name: ");
    name[i] = Console.ReadLine();
}

name = ClearNames(name);
string[] usernames = CreateUsernames(name);
int[] studentIds = CreateStudentIds(name.Length);
int[] studentLockers = CreateStudentLocker(name.Length);
*/

List<string> names = new List<string>();

string userInput;

do
{ 
    Console.WriteLine("Please enter a name 'FirstName LastName' (or 'DONE' to finish): ");
    userInput = Console.ReadLine().ToUpper();

    if(userInput != "DONE")
    {
        names.Add(userInput);
    }

} while(userInput != "DONE");

static string[] ClearNames(string[] names)
{
    string[] clearedNames = new string[names.Length];

    for(int i = 0; i < names.Length; i++)
    {
        clearedNames[i] = names[i].Trim();
    }

    return clearedNames;
}

static int[] CreateStudentIds(int count)
{
    int[] studentIds = new int[count];

    for(int i = 0; i < count; i++)
    {
        studentIds[i] = CreateStudentID();
    }
    return studentIds;
}


static int CreateStudentID()
{
    Random rng = new Random();

    return rng.Next(100000, 1000000);
}

static int[] CreateStudentLocker(int count)
{
    int[] studentLocker = new int[count];

    for(int i = 0; i < count; i++)
    {
        studentLocker[i] = CreateStudentID();
    }
    return studentLocker;
}

static int CreateStudentLockers()
{
    Random rng = new Random();

    return rng.Next(1, 501);
}

static string CreateUserName(string name)
{
    string[] nameParts = name.Split(' ');

    string firstName = nameParts[0].Trim().ToLower();
    string lastName = nameParts[1].Trim().ToLower();

    string userName = firstName[0] + lastName;

    return userName;
}

static string[] CreateUsernames(string[] names)

{
    string[] usernames = new string[names.Length];

    for(int i = 0; i < names.Length; i++)
    {
        usernames[i] = CreateUserName(names[i]);
    }

    return usernames;
}


