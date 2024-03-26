using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public interface ISorter
    {
        void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>;

        public class BubbleSort : ISorter
        {
            public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
            {
                if (comparer == null) comparer = Comparer<K>.Default;

                int n = sequence.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (comparer.Compare(sequence[j], sequence[j + 1]) > 0)
                        {
                            K temp = sequence[j];
                            sequence[j] = sequence[j + 1];
                            sequence[j + 1] = temp;
                        }
                    }
                }
            }
        }

        public class InsertionSort : ISorter
        {
            public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
            {
                if (comparer == null) comparer = Comparer<K>.Default;

                int n = sequence.Length;
                for (int i = 1; i < n; ++i)
                {
                    K key = sequence[i];
                    int j = i - 1;

                    while (j >= 0 && comparer.Compare(sequence[j], key) > 0)
                    {
                        sequence[j + 1] = sequence[j];
                        j = j - 1;
                    }
                    sequence[j + 1] = key;
                }
            }
        }

        public class SelectionSort : ISorter
        {
            public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
            {
                if (comparer == null) comparer = Comparer<K>.Default;

                int n = sequence.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (comparer.Compare(sequence[j], sequence[minIndex]) < 0)
                        {
                            minIndex = j;
                        }
                    }
                    K temp = sequence[minIndex];
                    sequence[minIndex] = sequence[i];
                    sequence[i] = temp;
                }
            }
        }
    }
}
