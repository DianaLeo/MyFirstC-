using Library1;

public class Project2{
    public static void Main(string[] args) {
        // If Generic is not used, Class1 must implement different constructors to use different types
        // Class1 class1withInt = new Class1(123);
        // Class1 class1withString = new Class1("123");

        // Constructor with object can solve the problem, but involves BOXING and UNBOXING issue
        // Input 123 is an Int, but constructor transform it to a Object when INSTANTIATION.
        // Value types are stored in STACK, reference types are stored in HEAP.
        // BOXING: Transforming an int to an object needs moving it from STACK to HEAP, which causes performance issues.
        Class1 class1withObject = new Class1(123);
        object obj = class1withObject.GetData();
        // UNBOXING: Transforming a reference type to a value type
        int num = (int)obj;
        int another = num++;

        // Using Generic
        // Compared with the above Object method, generic is TYPE-SAFE, cause the type is explicitly declared when instantiation.
        GenericClass<int> genericClass = new GenericClass<int>(123);
        int numObject = genericClass.GetData();

        // Generic Interface
        IRepository<int> repo = new Repository<int>();
        repo.Add(100);
        int item = repo.GetById(0);
    }

}
