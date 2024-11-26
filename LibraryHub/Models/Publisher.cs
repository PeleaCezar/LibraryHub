namespace LibraryHub.Models;

public class Publisher
{
    public string FullName { get; private set; }

    public Publisher(string fullName)
    {
         FullName = fullName;
    }
}
