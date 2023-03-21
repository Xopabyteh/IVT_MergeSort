var a = new[] {1, 2, 8, 94 ,0, -5, 12, 3, 24, 25, 3, 4};

var c = MergeSort(a, 0, a.Length - 1);
foreach (var i in c)
{
    Console.WriteLine(i);
}

T[] MergeSort<T>(T[] arr, int left, int right)
    where T : IComparable
{
    if (left == right)
    {
        return new T[] { arr[left] };
    }
    int mid = (left + right) / 2;
    var leftArr = MergeSort(arr, left, mid);
    var rightArr = MergeSort(arr, mid + 1, right);
    return Merge(leftArr, rightArr).ToArray();
}


IEnumerable<T> Merge<T>(T[] a, T[] b) 
    where T : IComparable
{
    var aI = 0;
    var bI = 0;
    var result = new List<T>();

    while (true)
    {
        if (a[aI].CompareTo(b[bI]) < 0)
        {
            result.Add(a[aI]);
            aI++;
        }
        else
        {
            result.Add(b[bI]);
            bI++;
        }

        if (aI >= a.Length)
        {
            for (; bI < b.Length; bI++)
            {
                result.Add(b[bI]);
            }
            break;
        }
        if (bI >= b.Length)
        {
            for (; aI < a.Length; aI++)
            {
                result.Add(a[aI]);
            }
            break;
        }
    }

    return result;
}