using System;
using System.Collections.Generic;

namespace HeapSortRecursive
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private List<T> list = new List<T>();

        public void Add(T item)
        {
            list.Add(item);
            HeapifyUp();
        }

        public T ExtractMax()
        {
            if (list.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            T root = list[0];
            list[0] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);

            HeapifyDown();

            return root;
        }

        private void HeapifyUp()
        {
            int index = list.Count - 1;
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (list[index].CompareTo(list[parentIndex]) > 0)
                {
                    T temp = list[index];
                    list[index] = list[parentIndex];
                    list[parentIndex] = temp;
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void HeapifyDown()
        {
            int index = 0;
            int maxChildIndex;

            while (true)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;

                if (leftChildIndex < list.Count)
                {
                    if (rightChildIndex < list.Count && list[rightChildIndex].CompareTo(list[leftChildIndex]) > 0)
                    {
                        maxChildIndex = rightChildIndex;
                    }
                    else
                    {
                        maxChildIndex = leftChildIndex;
                    }

                    if (list[maxChildIndex].CompareTo(list[index]) > 0)
                    {
                        T temp = list[index];
                        list[index] = list[maxChildIndex];
                        list[maxChildIndex] = temp;

                        index = maxChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }

    public class HeapSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            BinaryHeap<T> maxHeap = new BinaryHeap<T>();

            foreach (T item in arr)
            {
                maxHeap.Add(item);
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                arr[i] = maxHeap.ExtractMax();
            }
        }

        public static void PrintArray<T>(T[] arr)
        {
            foreach (T item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            Console.WriteLine("Original: ");
            PrintArray(arr);

            Sort(arr);

            Console.WriteLine("Sorted: ");
            PrintArray(arr);
        }
    }
}
