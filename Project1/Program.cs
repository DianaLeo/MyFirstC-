using Library1;

namespace Project1;

internal class Program{
    static void Main(string[] args){
        Class1 lib1 = new Class1();
        string message = lib1.GetMessage("Diana");

        Console.WriteLine(message);
    }

}

