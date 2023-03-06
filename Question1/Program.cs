using System;
using System.Linq;
using System.Collections.Generic;
namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            //You have two arrays/lists as follows
            int[] list1 = new int[] { 1, 2, 3, 4, 5 };
            int[] list2 = new int[] { 3, 4, 5, 6, 7 };
            //a. Show the common elements in both lists. E.g the common elements are "3 4 5", because they
            //are contained in both lists.
            var commonList = list1.Intersect(list2);
            Console.WriteLine(string.Join(" ", commonList));            //I renamed the lists to more defining descriptions


            //b. Show the elements from list 1, but is not found in list2. E.g 1 2"
            //int[] nonCommonList = new int[] { };
            var    nonCommonList = list1.Except(list2);
            Console.WriteLine(string.Join(" ", nonCommonList)); //list4


            //c. Complete here
            //Show the elements from list 2, but is not found in list1. E.g 6 7"
            var nonCommonList2 = list2.Except(list1);
            Console.WriteLine(string.Join(" ", nonCommonList2)); //list5


            Console.WriteLine("Press <ENTER> to continue");
            Console.ReadLine();
        }
    }
}