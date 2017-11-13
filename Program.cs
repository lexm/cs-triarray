using System;
using System.Collections.Generic;

namespace tricon
{
    class Program
    {
        public class OurNode
        {
            public OurNode(int[] arr)
            {
                idx = 0;
                Arr = arr;
            }
            public int idx { get; set; }
            public int[] Arr { get; set; }
            public int Val() => Arr[idx];
            public int inc()
            {
                idx++;
                return idx;
            }
            public bool OutOfRange()
            {
                return idx >= Arr.Length;
            }
        }

        public class TriHeap
        {
            public TriHeap(int[] arr1, int[] arr2, int[] arr3)
            {
                min = null;
                max = null;
                node1 = new OurNode(arr1);
                node2 = new OurNode(arr2);
                node3 = new OurNode(arr3);
            }
            public OurNode min { get; set; }
            public OurNode max { get; set; }
            public OurNode node1 { get; set; }
            public OurNode node2 { get; set; }
            public OurNode node3 { get; set; }
            public bool eval()
            {
                if(node1.OutOfRange() || node2.OutOfRange() || node3.OutOfRange())
                {
                    return false;
                }
                int? val1 = node1.Val();
                int? val2 = node2.Val();
                int? val3 = node3.Val();
                if (val1 > val2 && val1 > val3)
                {
                    max = node1;
                    if (val2 < val3)
                    {
                        min = node2;
                    }
                    else
                    {
                        min = node3;
                    }
                }
                else if (val1 < val2 && val1 < val3)
                {
                    min = node1;
                    if (val2 > val3)
                    {
                        max = node2;
                    }
                    else
                    {
                        max = node3;
                    }
                }
                else
                {
                    if (node2.Val() < node3.Val())
                    {
                        min = node2;
                        max = node3;
                    }
                    else
                    {
                        min = node3;
                        max = node2;
                    }
                }
                return true;
            }
        }

        public class Pre
        {
            public int Min { get; set; }
            public int Max { get; set; }
            public int Range { get; set; }
            public Pre(int initmin, int initmax, int initrange)
            {
                Min = initmin;
                Max = initmax;
                Range = initrange;
            }
        }

        public static int[] TriArray(int[] arr1, int[] arr2, int[] arr3)
        {
            TriHeap Thing = new TriHeap(arr1, arr2, arr3);
            Thing.eval();
            Pre pre = new Pre(Thing.min.Val(), Thing.max.Val(), Thing.max.Val() - Thing.min.Val());
            do
            {
                if (pre.Range > Thing.max.Val() - Thing.min.Val())
                {
                    pre.Min = Thing.min.Val();
                    pre.Max = Thing.max.Val();
                    pre.Range = Thing.max.Val() - Thing.min.Val();
                }
                Thing.min.inc();
            }
            while (Thing.eval());
            int[] result = new int[2];
            result[0] = pre.Min;
            result[1] = pre.Max;
            return result;
        }

        static void Main(string[] args)
        {
        int[] arr1 = { 1, 2, 4, 15 };
        int[] arr2 = { 3, 10, 12 };
        int[] arr3 = { 5, 10, 13, 17, 23 };
        int[] result = TriArray(arr1, arr2, arr3);
        Console.WriteLine("result: [{0}, {1}]", result[0], result[1]);
        }
    }
}
