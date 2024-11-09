namespace Library1;

public class GenericConstraint<T>  where T : class, new(){
    
}

public class GenericConstraint1<T>  where T : user, new(){

}

public class user {

}

public class user2: user {

}

public class user1: user {
    public user1(int a){
        
    }
}