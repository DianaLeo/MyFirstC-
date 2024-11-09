namespace Library1;

public class Repository<T> : IRepository<T> {
    private List<T> items = new List<T>();
    public void Add(T item){
        items.Add(item);
    }
    public T GetById(int id){
        return items[id];
    }
}