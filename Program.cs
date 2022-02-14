using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
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

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
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
                if (arrayLen == 1 && nums[min] >= target) //Array Length is 1 check
                {
                    return min;
                }

                else if (arrayLen == 1 && nums[min] < target)
                {
                    return 1;
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
                string modifiedParagraph = paragraph.ToLower(); //Converting to lower case
                modifiedParagraph = modifiedParagraph.Replace('!', ' '); //Removing special characters
                modifiedParagraph = modifiedParagraph.Replace('?', ' ');
                modifiedParagraph = modifiedParagraph.Replace('\'', ' ');
                modifiedParagraph = modifiedParagraph.Replace(',', ' ');
                modifiedParagraph = modifiedParagraph.Replace(';', ' ');
                modifiedParagraph = modifiedParagraph.Replace('.', ' ');
                                
                string[] paraSplit = modifiedParagraph.Split(" "); //splitting each word at space
                int[] paraSplitCount = new int[paraSplit.Length];
                int bannedLength = banned.Length;

                for(int i = 0; i < paraSplit.Length; i++) // Going through the whole input string
                {
                    if (paraSplit[i].Equals("")) //Ignoring string whose content is empty
                    {
                        paraSplitCount[i] = -1;
                        continue;
                    }
                    paraSplitCount[i] = 1;
                    for(int j=i+1; j<paraSplit.Length; j++) 
                    {
                        if (paraSplit[j].Equals("")) //Ignoring empty string
                        {
                            Debug.WriteLine("inside if of for loop: j = " + j);
                            continue;
                        }
                        else if (paraSplit[i].Equals(paraSplit[j])){ //Finding count for matches
                            Debug.WriteLine("inside Else-if of for loop: paraSplit[i] = " + paraSplit[i]);
                            paraSplit[j] = "";
                            paraSplitCount[j] = -1;
                            paraSplitCount[i] +=1;
                            Debug.WriteLine("paraSplit[i] = _" + paraSplit[i]+"_");
                            Debug.WriteLine("paraSplitCount[i] = " + paraSplitCount[i]);
                        }
                    }
                }

                for( int i = 0; i < paraSplit.Length; i++) //Just logger statement. Ignore
                {
                    Debug.WriteLine("paraSplit[i] = _" + paraSplit[i] + "_");
                    Debug.WriteLine("paraSplitCount[i] = " + paraSplitCount[i]);
                }
                int maxCount = 0;
                string maxSplit = "";
                bool flag = false;//If string is in banned list


                for (int i = 0; i < paraSplit.Length; i++) //Traversing through all the string words
                {
                    flag = false;
                    Debug.WriteLine("inside maxCount for loop: i = " + i);
                    if (paraSplitCount[i] > maxCount) // finding string with max count
                    {
                        Debug.WriteLine("inside maxCount if condition: paraSplitCount[i] = " + paraSplitCount[i]);
                        Debug.WriteLine("paraSplit[i] = " + paraSplit[i]);
                        Debug.WriteLine("inside maxCount if condition: maxCount = " + maxCount);
                        for (int z = 0; z < bannedLength; z++) // Finding if string is not in banned
                        {
                            Debug.WriteLine("inside for loop - z = " + z);
                            if (paraSplit[i].Equals(banned[z]))
                            {
                                Debug.WriteLine("inside for loop - if condition -  paraSplit[i] = " + paraSplit[i]);
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)// If string is not in banned, add new max value
                        {
                            Debug.WriteLine("MaxCount is being assigned: maxCount = " + paraSplitCount[i]);
                            Debug.WriteLine("MaxSplit = " + paraSplit[i]);
                            maxCount = paraSplitCount[i];
                            maxSplit = paraSplit[i];
                        }
                    }
                }
                
                return maxSplit; // Return maxSplit value
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
                //write your code here.
                IDictionary<int, int> count = new Dictionary<int, int>();
                int i;
                for (i = 0; i < arr.Length; i++) //Traversing through the input array
                {
                    if (count.ContainsKey(arr[i]))
                    {
                        count[arr[i]]++;
                    }
                    else//Adding value to dictionary
                    {
                        count.Add(arr[i], 1);
                    }
                }
                int high = 0; //int to store the highest Lucky number
                foreach (KeyValuePair<int, int> dict in count) //going through each element in dictionary
                {
                    // checking the condtion - number is repeated as the number itself
                    if (dict.Key == dict.Value)
                    {
                        // getting the max number
                        if (high < dict.Key)
                        {
                            high = dict.Key;
                        }
                    }
                }
                if (high != 0) //Lucky number is present
                {
                    return high;
                }
                else //NO Lucky number condition
                    return -1;
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
                string output = ""; //output string to return
                List<int> secretList = new List<int> { }; //List to store secrets
                List<int> guessList = new List<int> { }; //List to store guesses
                int countBull = 0, countCow = 0, i = 0, j = 0;
                for(i = 0; i<secret.Length; i++){
                    if (secret[i] == guess[i]) //If elemtent is present in correct position, increase bull count
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
                    if (secretList[i] == guessList[j]) // If elements are present in secret and guess List, increase cow count
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
                output = countBull + "A" + countCow + "B"; //Formulating the output representation
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
                int inputLen = s.Length, i, low, high;
                List<int> output = new List<int>(); //list to store output
                int[] array = new int[26]; //array of size 26 for all english characters
                for (i = inputLen - 1; i >= 0; i--) //converting ascii to number between 0-25
                {
                    if (array[s[i] - 97] == 0)
                    {
                        array[s[i] - 97] = i;
                    }
                }
                
                for (int index = 0; index < inputLen; index = high + 1) //Traversing through the input
                {
                    low = index;
                    high = array[s[index] - 97];
                    int asciiDifference = high - low + 1;
                    for (int j = low; j <= high; j++) //Traversing through the array contents
                    {
                        if (array[s[j] - 97] > high)
                        {
                            high = array[s[j] - 97];
                            asciiDifference = high - low + 1;
                        }

                    }
                    output.Add(asciiDifference); //Adding output to the list
                    index = high + 1;
                }
                //Returning the output list
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int noOfLines = 1;
                int lineLimit = 100;
                //int currentLineLimit = 0;
                int previousLineLimit = 0;

                for(int i = 0; i < s.Length; i++) //Traversing through the input
                {
                    if (previousLineLimit + widths[s[i] - 'a'] > lineLimit ) //Finding number of lines
                    {
                        noOfLines++;
                        previousLineLimit = widths[s[i] - 'a'];
                    }
                    else //If extra characters are present, set extra charcters in line Limit
                    {
                        previousLineLimit += widths[s[i] - 'a'];
                    }

                }
                //Passing the output
                    return new List<int>() { noOfLines, previousLineLimit };
                

                
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                //Using the principle of stack to run this program
                int index = 0;
                char[] string10 = new char[bulls_string10.Length];
                foreach(char c in bulls_string10) //Traversing through the input
                {
                    if (c == '(' || c == '[' || c == '{') //If the input is an open bracket, add to the char array
                    {
                        string10[index] = c;
                        index++;
                    }
                    else if (c == ')' || c == ']' || c == '}') //If the input is a closed bracket, remove elements from the char array
                    {
                        if(index == 0)
                        {
                            return false;
                        }
                        if(string10[index-1] == '(' && c==')') //Making sure brackets match
                        {
                            index--;
                        }
                        else if (string10[index - 1] == '{' && c == '}')
                        {
                            index--;
                        }
                        else if (string10[index - 1] == '[' && c == ']')
                        {
                            index--;
                        }
                    }
                    
                }
                if (index == 0) //Return appropriate value based on the match
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
          Question 8
         International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
         •	'a' maps to ".-",
         •	'b' maps to "-...",
         •	'c' maps to "-.-.", and so on.
         For convenience, the full table for the 26 letters of the English alphabet is given below:
         [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
         Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
             •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
         Return the number of different transformations among all words we have.

         Example 1:
         Input: words = ["gin","zen","gig","msg"]
         Output: 2
         Explanation: The transformation of each word is:
         "gin" -> "--...-."
         "zen" -> "--...-."
         "gig" -> "--...--."
         "msg" -> "--...--."
         There are 2 different transformations: "--...-." and "--...--.".
         */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {

                List<string> morseCode = new List<string> { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                List<string> outputCode = new List<string> { };
                int inputLen = words.Length;
                for(int i = 0; i< inputLen; i++) //Going through the entire input strings
                {
                    string s = words[i];
                    string morseCharString = "";// code for each word
                    foreach(char c in s) // formulating morese code for each word
                    {
                        morseCharString += morseCode[c - 97];
                    }
                    outputCode.Add(morseCharString);//adding code to string list
                }
                IEnumerable<string> outputUniqueCode = outputCode.Distinct(); //removing duplicates


                return outputUniqueCode.Count<string>(); //returning the count of the unique ones in list
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
