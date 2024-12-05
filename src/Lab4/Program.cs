using Itmo.ObjectOrientedProgramming.Lab4.ChainCreators;
using Itmo.ObjectOrientedProgramming.Lab4.Filesystems;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        var creator = new ChainCreator();
        var runner = new Runner(creator.CreateChain());
        runner.AddSupportedFilesystemMode("local", new LocalFilesystem());
        while (true)
        {
            runner.Run(Console.ReadLine()?.Split());
            Console.WriteLine("Reading...");
        }
    }
}