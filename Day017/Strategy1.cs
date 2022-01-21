namespace Day017;

public class Strategy1 : IStrategy
{
    public int Execute(string fileSystemRepresentation)
    {
        var pathFragments = fileSystemRepresentation
            .Split('\n')
            .Select(line => new PathFragment(line));

        var stack = new PathFragmentStack();
        var max = 0;

        foreach (var pathFragment in pathFragments)
        {
            if (pathFragment.Depth > stack.Depth)
            {
                stack.Push(pathFragment);
            }
            else
            {
                stack.Pop(stack.Depth - pathFragment.Depth + 1);
                stack.Push(pathFragment);
            }

            if (pathFragment.IsFile && stack.TotalLength > max)
                max = stack.TotalLength;
        }

        return max;
    }
}