using System;
using System.Collections.Generic;
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
            Console.WriteLine("Most frequent word is : {0}", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "0451";
            string guess = "0113";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
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
                string modifedParagraph = paragraph.ToLower();
                if (paragraph.Contains('!'))
                {
                    modifedParagraph = modifedParagraph.Replace('!', ' ');
                }
                if (paragraph.Contains('?'))
                {
                    modifedParagraph = paragraph.Replace('?', ' ');
                }
                if (paragraph.Contains('\''))
                {
                    modifedParagraph = modifedParagraph.Replace('\'', ' ');
                }
                if (paragraph.Contains(','))
                {
                    modifedParagraph = modifedParagraph.Replace(',', ' ');
                }
                if (paragraph.Contains(';'))
                {
                    modifedParagraph = modifedParagraph.Replace(';', ' ');
                }
                if (paragraph.Contains('.'))
                {
                    modifedParagraph = modifedParagraph.Replace('.', ' ');
                }
                
                string[] paraSplit = modifedParagraph.Split(" ");
                int[] paraSplitCount = new int[paraSplit.Length];
                int bannedLength = banned.Length;

                for(int i = 0; i < paraSplit.Length; i++)
                {
                    if (paraSplit[i].Equals(""))
                    {
                        paraSplitCount[i] = -1;
                        continue;
                    }
                    paraSplitCount[i] = 1;
                    for(int j=i+1; j<paraSplit.Length; j++)
                    {
                        if (paraSplit[j].Equals(""))
                        {
                            Debug.WriteLine("inside if of for loop: j = " + j);
                            continue;
                        }
                        else if (paraSplit[i].Equals(paraSplit[j])){
                            Debug.WriteLine("inside Else-if of for loop: paraSplit[i] = " + paraSplit[i]);
                            paraSplit[j] = "";
                            paraSplitCount[j] = -1;
                            paraSplitCount[i] +=1;
                            Debug.WriteLine("paraSplit[i] = _" + paraSplit[i]+"_");
                            Debug.WriteLine("paraSplitCount[i] = " + paraSplitCount[i]);
                        }
                    }
                }

                for( int i = 0; i < paraSplit.Length; i++)
                {
                    Debug.WriteLine("paraSplit[i] = _" + paraSplit[i] + "_");
                    Debug.WriteLine("paraSplitCount[i] = " + paraSplitCount[i]);
                }
                int maxCount = 0;
                string maxSplit = "";
                bool flag = false;//If string is in banned list


                for (int i = 0; i < paraSplit.Length; i++)
                {
                    flag = false;
                    Debug.WriteLine("inside maxCount for loop: i = " + i);
                    if (paraSplitCount[i] > maxCount)
                    {
                        Debug.WriteLine("inside maxCount if condition: paraSplitCount[i] = " + paraSplitCount[i]);
                        Debug.WriteLine("paraSplit[i] = " + paraSplit[i]);
                        Debug.WriteLine("inside maxCount if condition: maxCount = " + maxCount);
                        for (int z = 0; z < bannedLength; z++)
                        {
                            Debug.WriteLine("inside for loop - z = " + z);
                            if (paraSplit[i].Equals(banned[z]))
                            {
                                Debug.WriteLine("inside for loop - if condition -  paraSplit[i] = " + paraSplit[i]);
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            Debug.WriteLine("MaxCount is being assigned: maxCount = " + paraSplitCount[i]);
                            Debug.WriteLine("MaxSplit = " + paraSplit[i]);
                            maxCount = paraSplitCount[i];
                            maxSplit = paraSplit[i];
                        }
                    }
                }
                
                return maxSplit;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                int current = 0;
                int previous = 0;
                int currentCount = 0;
                int largestLuckyNum = -1;
                int i = 0;

                current = arr[0];
                currentCount++;
                if (arr.Length == 1)
                {
                    if (current == currentCount)
                    {
                        largestLuckyNum = 1;
                        return largestLuckyNum;
                    }
                    else
                    {
                        return largestLuckyNum;
                    }
                }
                
                for (i = 1; i < arr.Length; i++)
                {
                    previous = current;
                    current = arr[i];
                    if(current == previous)
                    {
                        currentCount++;
                    }
                    else if (current != previous)
                    {
                        if(currentCount == previous)
                        {
                            if(largestLuckyNum < previous)
                            {
                                largestLuckyNum = previous;
                            }
                            
                        }
                        currentCount = 1;
                        
                    }
                 }
                if (i == arr.Length)
                {
                    previous = current;
                    if (currentCount == previous)
                    {
                        if (largestLuckyNum < previous)
                        {
                            largestLuckyNum = previous;
                        }
                    }
                 }
                
                return largestLuckyNum;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                string output = "";
                List<int> secretList = new List<int> { };
                List<int> guessList = new List<int> { };
                int countBull = 0, countCow = 0, i = 0, j = 0;
                for(i = 0; i<secret.Length; i++){
                    if (secret[i] == guess[i])
                    {
                        countBull++;
                        continue;
                    }
                    //converting characters with integers to Integers by subtracting ASCII value
                    secretList.Add(secret[i]-48);
                    guessList.Add(guess[i]-48);
                }
                secretList.Sort();
                guessList.Sort();

                for(i = 0, j = 0; i < secretList.Count && j < secretList.Count; )
                {
                    if (secretList[i] == guessList[j])
                    {
                        countCow++;
                        i++;
                        j++;
                    }
                    else if (secretList[i] < guessList[j])
                    {
                        i++;
                    }
                    else if (secretList[i] > guessList[j])
                    {
                        j++;
                    }
                }
                output = countBull + "A" + countCow + "B";
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */
        public static List<int> PartitionLabels(string s)
        {
            try
            {
                char[] input = s.ToCharArray();
                int inputLen = input.Length;
                int min, max;
                char[] uniqueElement = new char[inputLen];
                int[,] uniqueRange = new int[inputLen, 2];
                char c;
                List<int> resultCountList = new List<int> { };

                for(int i = 0; i < inputLen; i++)
                {
                    c = input[i];
                    if (i == 0)
                    {
                        uniqueElement[i] = input[i];
                        uniqueElement[i + 1] = '*';
                        uniqueRange[i, 0] = 0;
                        uniqueRange[i, 1] = 0;
                        continue;
                    }
                    for(int j = 0; j < inputLen; j++)
                    {
                        if (uniqueElement[j] == '*') // Element not in uniqueElement array & we're at end
                                                     // So, Add the new elemtent to array
                        {
                            uniqueElement[j] = input[i];
                            uniqueElement[j + 1] = '*';
                            uniqueRange[j, 0] = i;
                            uniqueRange[j, 1] = i;
                            break;
                        }
                        else if (uniqueElement[j] == input[i])
                        {
                            uniqueRange[j, 1] = i;
                            break;
                        }
                    }
                }
                min = uniqueRange[0, 0];
                max = uniqueRange[0, 1];
                for (int z = 0; z < inputLen; z++)
                {
                    Debug.WriteLine($"unique element = {uniqueElement[z]} uniqueRange[z, 0] = {uniqueRange[z, 0]} uniqueRange[z, 1] = {uniqueRange[z, 1]}");
                    if (uniqueElement[z] == '*')
                    {
                        break;
                    }
                }
                for (int i = 0; i<inputLen; i++)
                {
                    if (uniqueElement[i] == '*')
                    {
                        resultCountList.Add(max - min + 1);
                        Debug.WriteLine("Last character reveived");
                        break;
                    }
                    if (max == min) // character with single occuarnce after string is found
                    {
                        Debug.WriteLine("Inside MIN = MAX = "+max);
                        resultCountList.Add(max - min + 1);
                        
                    }
                    else if(max > uniqueRange[i, 0] && max > uniqueRange[i,1])
                    {
                        continue;
                    }
                    else if (max > uniqueRange[i, 0] && max < uniqueRange[i, 1])
                    {
                        max = uniqueRange[i, 1];
                    }
                    else if (max < uniqueRange[i,0])//string is found
                    {
                        Debug.WriteLine("min = "+ min + " max = " + max);
                        resultCountList.Add(max - min + 1);
                        min = uniqueRange[i, 0];
                        max = uniqueRange[i, 1];
                        Debug.WriteLine("After adding string min = " + min + " max = " + max);    
                    }
                    Debug.WriteLine(uniqueElement[i] + " " + uniqueRange[i, 0] + " " + uniqueRange[i, 1]);
                }
                return resultCountList;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
