namespace Day005;

public static class ConsCarCdr
{
    public static Func<Func<dynamic, dynamic, dynamic>, dynamic> Cons(dynamic a,
        dynamic b)
    {
        return f => f(a, b);
    }

    public static dynamic Car(
        Func<Func<dynamic, dynamic, dynamic>, dynamic> pair)
    {
        return pair((a, _) => a);
    }

    public static dynamic Cdr(
        Func<Func<dynamic, dynamic, dynamic>, dynamic> pair)
    {
        return pair((_, b) => b);
    }
}