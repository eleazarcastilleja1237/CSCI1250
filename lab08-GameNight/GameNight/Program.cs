/*
Name: Eleazar Castilleja
Course: CSCI 1250, Section 001
Assignment: Lab 08, Game Night
Date: November 20, 2026
Description: Keeps a game night leaderboard in three text files. Shows the
season so far, records tonight's points, saves the new totals,
and adds tonight's result to a history that grows every week.
*/

const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;


// Look for the data files next to Program.cs, however the program is started.
string projectFolder = Path.GetFullPath(
Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);


// ---------- Part 3 (top): read the history ----------

Console.WriteLine("=== GAME NIGHT LEADERBOARD ===");
string[] history = File.ReadAllLines(HISTORY_FILE);

if (history.Length == 0)
{
Console.WriteLine("No nights played yet.");
}
else
{

Console.WriteLine("Nights played: " + history.Length);

// foreach: I only need each line once, in order, and no index.
foreach (string night in history)
{
Console.WriteLine(" " + night);
}
}

int tonightNumber = history.Length + 1;
Console.WriteLine("Tonight's Night " + tonightNumber + ".");
Console.WriteLine();


// ---------- Part 1: the standings ----------

string[] players = File.ReadAllLines(PLAYERS_FILE);
string[] points = File.ReadAllLines(POINTS_FILE);
Console.WriteLine("PLAYER".PadRight(11) + "POINTS");


// for: the name and the points live in two arrays,
// and only a shared index keeps them together.
for (int i = 0; i < players.Length; i++)
{
Console.WriteLine(players[i].PadRight(11) + points[i]);
}


int leader = LeaderIndex(points);
Console.WriteLine("Leader: " + players[leader] + " with " + points[leader]);
Console.WriteLine("Season total: " + TotalPoints(points));
Console.WriteLine();


// ---------- Part 2: game night ----------

int bestTonight = -1;
string winnerTonight = "";

// for: I need the index to update points[i] and to know whose turn it is.
for (int i = 0; i < players.Length; i++)
{
Console.Write("Points tonight for " + players[i] + ": ");
int tonight = Convert.ToInt32(Console.ReadLine());

// while: I can't know how many bad entries the user will type,
// so it repeats until the score is valid.
while (tonight < 0 || tonight > MAX_POINTS)
{
Console.WriteLine("Points must be from 0 to " + MAX_POINTS + ".");
Console.Write("Points tonight for " + players[i] + ": ");
tonight = Convert.ToInt32(Console.ReadLine());
}

int season = Convert.ToInt32(points[i]) + tonight;
points[i] = season.ToString();
if (tonight > bestTonight)
{
bestTonight = tonight;
winnerTonight = players[i];
}
}

Console.WriteLine("Tonight's winner: " + winnerTonight + " with " + bestTonight);
Console.WriteLine();
File.WriteAllLines(POINTS_FILE, points);
Console.WriteLine("Saved points.txt.");


// ---------- Part 3 (bottom): add tonight to the history ----------

string[] entry = { HistoryEntry(tonightNumber, winnerTonight, bestTonight) };
File.AppendAllLines(HISTORY_FILE, entry);
Console.WriteLine("Added to history.txt: " + entry[0]);

// Hands back the POSITION of the highest score, not the name or the number.
static int LeaderIndex(string[] points)
{
int best = 0;

// for: I need the position of the best score, so I need the index.
for (int i = 1; i < points.Length; i++)
{
if (Convert.ToInt32(points[i]) > Convert.ToInt32(points[best]))
{
best = i;
}
}
return best;
}

// Hands back the sum of every score as an int.
static int TotalPoints(string[] points)
{
int total = 0;

// foreach: every value is added once and the position doesn't matter.
foreach (string p in points)
{
total += Convert.ToInt32(p);
}
return total;
}

// Hands back one history line, like "Night 1: Alan won with 15 points".
static string HistoryEntry(int night, string winner, int points)
{
return "Night " + night + ": " + winner + " won with " + points + " points";
}
