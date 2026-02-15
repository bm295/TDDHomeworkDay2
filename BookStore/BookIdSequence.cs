using System.Collections;

namespace BookStore;

public class BookIdSequence : IEnumerable<int>
{
    private readonly int _startId;
    private readonly int _count;

    public BookIdSequence(int startId, int count)
    {
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be zero or greater.");
        }

        _startId = startId;
        _count = count;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (var i = 0; i < _count; i++)
        {
            yield return _startId + i;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
