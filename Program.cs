using System;
using System.Diagnostics;

namespace Assignment2_Spring22
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

        }

        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int min = 0; // one end of for loop
                int arrayLen = nums.Length;
                int max = arrayLen; // other end of for loop
                if (arrayLen == 0) // Empty array check
                {
                    return 0;
                }
                for (int i = min; min < max ; i = (min+max)/ 2) // Binary search logic
                {
                    if (max == min + 1) // If the value is not in between min and max index value
                    {
                        Debug.WriteLine("Output : " + max + 1);
                        break;
                    }

                    Debug.WriteLine("i = " + i + " min = " + min + " max = " + max);
                    if (nums[i] == target) // if the target value is in the array's index
                    {
                        return i;
                        Debug.WriteLine("inside 1");
                    }
                    else if (nums[i] < target) // if the mid value of array is less than target value
                    {
                        min = i;
                        Debug.WriteLine("inside 2");
                        
                    }
                    else if(nums[i] > target) // if the mid value of array is greater than target value
                    {
                        max = i;
                        Debug.WriteLine("inside 3");
                    }
                }
                return max;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                //write your code here.

                return "";
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
