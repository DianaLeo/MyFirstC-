namespace Library1;

public interface IRepository<T> {
    void Add (T item);
    T GetById(int id);
}
