using Library1;

namespace Project1;

internal class Program{
    static void Main(string[] args){
        Class1 lib1 = new Class1();
        string message = lib1.GetMessage("Diana");
        Console.WriteLine(message);

        // type transform explicit
        string str1 = "123";
        int result;
        bool success = int.TryParse(str1, out result);
        Console.WriteLine(success);

        string str2 = "abx";
        int result2;
        bool success2 = int.TryParse(str2, out result2);
        Console.WriteLine(success2);
    }

}

