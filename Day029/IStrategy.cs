namespace Day029;

public interface IStrategy
{
    string Encode(string input);
    string Decode(string input);
}