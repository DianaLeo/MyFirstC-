using System.Formats.Asn1;

namespace Library1;

public class Class1
{
    // private int num;
    // public Class1(int value){
    //     num = value;
    // }

    // private string str;
    // public Class1(string value){
    //     str = value;
    // }

    private object obj;
    public Class1(object value){
        obj = value;
    }

    public object GetData(){
        return obj;
    }

    public string GetMessage(string name){
        return "hello" +name;
    }
}
