using System;
using System.Collections.Generic;


namespace ISM6225_Assignment_2_Spring_2022
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

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
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
                //Write your Code here.
                //Here i am doing a binary search to first search if the element is present, if not found i am returning the 
                // position using min or max by comparision as the actual number will be 1 less than min number position or
                // 1 more than max number position when not found depending on which partition it belongs to
                int min = 0, max = nums.Length - 1;
                while (min < max)
                {
                    int mid = (min + max) / 2;
                    if (target == nums[mid])
                    {
                        return mid;
                    }
                    else if (target < nums[mid])
                    {
                        max = mid - 1;
                    }
                    else if (target > nums[mid])
                    {
                        min = mid + 1;
                    }

                }
                if (target < min)
                {
                    return min - 1;
                }
                else
                    return max + 1;

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
                // Here i am first forming a dictionary of number and its frequency and then removing the banned words and finally
                //returning word that has max freq
                string[] para = paragraph.ToLower().Split(new Char[] { '!', '?', '\'', ',', ';', '.', ' ' },
                                 StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> s = new Dictionary<string, int>();
                string[] n = new string[para.Length];

                List<String> l = new List<string>();
                foreach (String word in banned)
                {
                    l.Add(word);
                }

                // add paragraph words to dictionary

                foreach (String word in para)
                {
                    if (!l.Contains(word))
                    {
                        if (s.ContainsKey(word))
                        {
                            s[word] = s[word] + 1;
                        }
                        else s.Add(word, 1);
                    }
                }

                int max = 0;
                var maxk = "";
                foreach (var kvp in s)
                {
                    if (kvp.Value > max)
                    {
                        max = kvp.Value;
                        maxk = kvp.Key;
                    }
                }

                return maxk;
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
                // Here i am forming a dictionary of number and its frequency, then checking if the freq is equal to the number itself
                // and finding maximum of all such values by filtering again within and returning.
                Dictionary<int, int> d = new Dictionary<int, int>();
                int[] keys = new int[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!d.ContainsKey(arr[i])) d.Add(arr[i], 1);
                    else d[arr[i]] = d[arr[i]] + 1;
                }
                int max = -1;
                var maxk = -1;
                foreach (var kvp in d)
                {
                    if (kvp.Key == kvp.Value)
                    {
                        if (kvp.Value > max | kvp.Value == max & kvp.Key > maxk)
                        {
                            max = kvp.Value;
                            maxk = kvp.Key;
                        }
                        else continue;
                    }
                }
                return maxk;
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
                //write your code here.
                // Here i am using two dictionaries to store the index and flag indicating whether that number is counted towards bulls
                //  or not for both secret and guess words respectively. Then i am using this flag to eliminate bulls numbers and 
                // then checking for matching numbers in remaining indices and updating flag again to keep track of parsed integers and 
                // updating cows
                char[] s = secret.ToCharArray();
                char[] g = guess.ToCharArray();
                int bulls = 0, cows = 0;

                Dictionary<int, bool> d = new Dictionary<int, bool>();
                Dictionary<int, bool> e = new Dictionary<int, bool>();
                for (int i = 0; i < secret.Length; i++)
                {
                    if (s[i] == g[i])
                    {

                        bulls = bulls + 1;

                        d.Add(i, true);
                        e.Add(i, true);

                    }
                    else
                    {
                        d.Add(i, false);
                        e.Add(i, false);
                    }



                }
                for (int i = 0; i < secret.Length; i++)
                {
                    if (d[i] == false)
                    {
                        for (int j = 0; j < guess.Length; j++)
                        {
                            if (e[j] == false)
                            {
                                if (s[i] == g[j])
                                {
                                    cows = cows + 1;
                                    d[i] = true;
                                    e[j] = true;
                                    break;
                                }
                            }


                        }
                    }
                }
                return (bulls + "A" + cows + "B").ToString();
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
                //write your code here.
                // Here i am using letter - 'a' to get the index of a list of 26 alphabets positions and updating that particular 
                // index location with the last occurance index. Then i am checking the last occurance of each letter starting from index 0
                // while moving ahead by keeping track of the number by start and its next occurances by end and when end reaches last
                // ocuurance whihc is stored in the list earlier, i am partitioning it there and now updating start with end+1 to start next
                // partition and so on till end of list.
                int l = s.Length;

                List<int> a = new List<int>();
                int[] li = new int[26];

                for (int i = 0; i < l; i++)
                {
                    li[s[i] - 'a'] = i;
                }
                int j = 0;
                int start = 0, end = 0;
                for (int i = 0; i < l; i++)
                {
                    end = Math.Max(end, li[s[i] - 'a']);
                    if (i == end)
                    {
                        a.Add(end - start + 1);
                        start = end + 1;
                    }
                }
                return a;
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
                //write your code here.
                // Here i am getting the width of each character of the string in the widths array and adding it up and whenever it reaches 
                // sum total greater than 100 i am updating the line count and resetting the total to the excess width that was added in 
                // the current step which made it greater than 100 to be carried forward to next line. Continuing this process until
                // all widths are parsed. Last value of total will hold last width over 100 from previous line and hence the last line pixels
                char[] ss = s.ToCharArray();
                List<int> l = new List<int>();
                int tot = 0, count = 1;


                foreach (char c in ss)
                {
                    int w = widths[c - 'a'];
                    tot = tot + w;
                    if (tot > 100)
                    {
                        count = count + 1;
                        tot = w;
                    }

                }

                l.Add(count);
                l.Add(tot);
                return l;
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
                //write your code here.
                // Here i am simply checking if there is any open paranthesis and pushing it over a stack to keep track of the order
                // as stack is LIFO. Using this property of stack to remove the open braces as and when its corresponding end braces occur
                // while parsing the string in order. If finally stack is empty, then string is valid.
                Stack<char> open = new Stack<char>();
                foreach (char c in bulls_string10.ToCharArray())
                {
                    if (c == '(' || c == '[' || c == '{')
                    {
                        open.Push(c);
                    }
                    else if (c == ')' && open.Count != 0 && open.Peek() == '(')
                    {
                        open.Pop();
                    }
                    else if (c == ']' && open.Count != 0 && open.Peek() == '[')
                    {
                        open.Pop();
                    }
                    else if (c == '}' && open.Count != 0 && open.Peek() == '{')
                    {
                        open.Pop();
                    }
                    else
                        return false;
                }

                return open.Count == 0;
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
                //write your code here.
                // Here i am taking all morse codes in a string to use for comparision. Then iterating each word and updating the output
                // msg by looping over each letter in each word and finding corresponding code in code array by index location.
                // Then i am checking if there are any duplicates and retaining only unique strings and returning its count.
                List<string> final = new List<string>();
                string[] code = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                for (int i = 0; i < words.Length; i++)
                {
                    string op = "";
                    for (int j = 0; j < words[i].Length; j++)
                    {
                        op = op + code[words[i][j] - 'a'];
                    }
                    final.Add(op);
                }
                List<string> check = new List<string>();
                foreach (var n in final)
                {

                    if (!check.Contains(n))
                    {
                        check.Add(n);

                    }
                    else continue;
                }

                return check.Count;
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                //write your code here.
                return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

//Self reflection:
// Q1 :The hint given was quite helpful to solve this problem . I was able to solve this in 10 minutes. But while handling corner cases it failed
// So i took some time to handle corner cases.
// Q2: This took me about 30 minutes to solve as the corner cases of empty string in banned words needed to be handled as well as ignoring
// the punctuations took me some time to figure out. 
// Q3: This was pretty easy as i needed to find frequency and compare with number which is a simple logic. Thanks for one easy question.
// Q4: This was the most difficult question of entire assignment (apart from extra qns) . I spent a lot of time on this because there
// are some corner cases that i was missing. I left solving this at a point of time and revisited at the end of assignment after finishing
// all questions. This took me like 3 hours or even more to solve. 
// Q5: This question was also a tricky one and getting the idea to partition took a while. I took an hour for this one.
// Q6: The logic behind this question did not take much time to arrive at but implementing it brought up some issues of wrong answer for
// length in last line. It took me an hour.
// Q7: This was another question which was good to solve . I got the idea of stack as i solved similar problem in btech while learning stacks.
// So it took me about 15 to 20 min to solve.
// Q8: This was also an easy one in terms of solution but i took some time to understand how the transformation output should be.
// Initially i read the question wrong and output combined string length but later corrected it to find unique values.
// Q9 and Q10: These were too complex for me to solve. I tried to understand the question but they were very difficult to interpret. I will
// try solving them over the next week or if you could please provide an explanation to these it would be very helpful.