namespace Library1;

public class GenericClass<T> {
    private T data;

    public GenericClass(T value){
        data = value;
    }

    public T GetData(){
        return data;
    }
}