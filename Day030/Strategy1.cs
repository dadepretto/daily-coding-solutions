namespace Day030;

public class Strategy1 : IStrategy
{
    public int Execute(int[] map)
    {
        var sum = 0;
        var left = new Cursor(0, int.MinValue);
        var right = new Cursor(map.Length - 1, int.MinValue);

        while (left.Index < right.Index)
            if (map[left.Index] < map[right.Index])
            {
                if (map[left.Index] >= left.Max) left.Max = map[left.Index];
                else sum += left.Max - map[left.Index];
                left.Index++;
            }
            else
            {
                if (map[right.Index] >= right.Max) right.Max = map[right.Index];
                else sum += right.Max - map[right.Index];
                right.Index--;
            }

        return sum;
    }

    private class Cursor
    {
        public Cursor(int index, int max)
        {
            Index = index;
            Max = max;
        }

        public int Index { get; set; }

        public int Max { get; set; }
    }
}