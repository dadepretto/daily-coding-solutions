namespace Day021;

public interface IStrategy
{
    int Execute(IEnumerable<Lecture> lectures);
}