
[Author("Ventsi")]
public class Program
{
    [Author("Gosho")]
    static void Main(string[] args)
    {
        var tracker = new Tracker();

        tracker.PrintMethodsByAuthor();
    }
}
