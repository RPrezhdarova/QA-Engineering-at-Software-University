string architecturesName = Console.ReadLine();
int projects = int.Parse(Console.ReadLine());
int hoursPerProject = 3;
int totalProjectsHours = projects * hoursPerProject;

Console.WriteLine($"The architect {architecturesName} will need {totalProjectsHours} hours to complete {projects} project/s.");
