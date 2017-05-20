using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Leetcode
    {

        public int HammingDistance(int a, int b)
        {
            /*
             * The Hamming distance between two integers is the number of positions at which the corresponding bits are different.
                Given two integers x and y, calculate the Hamming distance.
             */
            int z = a ^ b;
            string s = Convert.ToString(z, 2);
            int[] bits = s.PadLeft(8, '0')
             .Select(c => int.Parse(c.ToString())) 
             .ToArray();
            int count = 0;
            foreach (int i in bits)
            {
                if (i == 1) count += 1;
            }
            return count;
        }

       /* public int FindCompliment(int x)
        {
            
             * Given a positive integer, output its complement number. The complement strategy is to flip the bits of its binary representation.
            Note:
            The given integer is guaranteed to fit within the range of a 32-bit signed integer.
            You could assume no leading zero bit in the integer’s binary representation.
             
           
            //string s = Convert.ToString(x, 2);
            //int[] bits = s.PadLeft(8, '0')
            // .Select(c => int.Parse(c.ToString()))
            // .ToArray();
            //for (var i = 0; i < bits.Length;i++)
            //{
            //    bits[i] = bits[i]==1?0 : 1;
            //}
            //var bitArray = new BitArray();
            //int[] array = new int[1];
            //bitArray.CopyTo(array, 0);
            //return array[0];
        }*/

        public string ReverseString(string s)
        {
            var arr = s.ToCharArray().Reverse().ToArray();
            return String.Join("", arr);
        }

        public  int BestProfit(List<int> stockPricesYesterday){

            /*
             * Write an efficient function that takes stock_prices_yesterday 
             * and returns the best profit I could have made from 1 purchase and 1 sale of 1 Apple stock yesterday
             */

            stockPricesYesterday.Sort();
            return stockPricesYesterday[stockPricesYesterday.Count-1] - stockPricesYesterday[0];
        }

        public int[] GetProductOfAllIntsExceptAtIndex(int[] input)
        {
            /*
             * You have a list of integers, and for each index you want to find the product of every integer except the integer at that index.
             */
            
           /*
            var productList = new List<int>();
            for (var i=0; i<originalList.Length; i++)
            {
                int product = 1;
                for (var j = 0; j < originalList.Length; j++)
                {
                    if(i==j) continue;
                    product *= originalList[j];
                }
                productList.Add(product);
            }
            return productList.ToArray();
            */
            var output = new int[input.Length];
            for (var i=1; i< input.Length; i++)
            {
                var current = 1;
                for (var j=0; j<i; j++){
                    if (i == 1)
                    {
                        output[j] = input[i];
                    }else
                    {
                        output[j] = output[j] * input[i];    
                    }
                    current = current*input[j];
                }
                output[i] = current;
            }
            return output;

        }

        public int GetHighestProduct(List<int> originalList)
        {
            /*
             * Given a list_of_ints, find the highest_product you can get from three of the integers.
                The input list_of_ints will always have at least three integers.
             */
            originalList.Sort();
            return originalList[originalList.Count - 3]*originalList[originalList.Count - 2]*
                   originalList[originalList.Count - 1];
        }

        public int GetLargestNonRepeatingSubstring(String originalString)
        {
            /*
             * Given a string, find the length of the longest substring without repeating characters.
             * Given "abcabcbb", the answer is "abc", which the length is 3.
             */
            if (originalString.Length == 1) return 1;

            var returnString = string.Empty;
            for (var i = 0; i < originalString.Length-1; i++)
            {
                for (var j = 1; j <= originalString.Length-i; j++)
                {
                    var mySubstring = originalString.Substring(i, j);
                    var charArray = mySubstring.ToCharArray();
                    var charSet = new HashSet<char>(charArray);
                    if(charSet.Count == charArray.Count() && returnString.Length < charArray.Count())
                    {
                        returnString = mySubstring;
                    }
                }

            }
            return returnString.Length;
        }

        public string LongestPalindromicSubstring(String s)
        {
            /*
             * Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
             */

            if (s.Length == 1) return s;
            var returnString = string.Empty;
            for (var i = 0; i < s.Length - 1; i++)
            {
                for (var j = 1; j <= s.Length-i; j++)
                {
                    var mySubstring = s.Substring(i, j);
                    var reverseSubstring = String.Join("", mySubstring.Reverse().ToArray());
                    if (mySubstring == reverseSubstring && returnString.Length < mySubstring.Count())
                    {
                        returnString = mySubstring;
                    }
                }

            }
            return returnString;
        }

        public int IslandInOcean(int[,] grid)
        {
            /*
             * You are given a map in form of a two-dimensional integer grid where 1 represents land and 0 represents water. 
             * Grid cells are connected horizontally/vertically (not diagonally). 
             * The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells). 
             * The island doesn't have "lakes" (water inside that isn't connected to the water around the island). 
             * One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100.
             * Determine the perimeter of the island.
             * Example:
             * [[0,1,0,0],
                [1,1,1,0],
                [0,1,0,0],
                [1,1,0,0]]

                Answer: 16
             * 1)Find # of 1's * 4
               2)Find # of contiguous pairs of 1's * 2 (They share a border twice over)
               3)Subtract 2 from 1
             */

            var numberOfFullBlocks = 0;

            for(int i=0;i < grid.GetLength(0);i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 1)
                    {
                        numberOfFullBlocks += 1;
                    }
                } 
            }

            var numberOfContiguousPairsOfBlocks = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 1; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == grid[i, j-1] && grid[i, j] == 1)
                    {
                        numberOfContiguousPairsOfBlocks += 1;
                    }
                } 
            }

            for (int i = 0; i < grid.GetLength(1); i++)
            {
                for (int j = 1; j < grid.GetLength(0); j++)
                {
                    if (grid[j, i] == grid[j-1, i] && grid[j, i] == 1)
                    {
                        numberOfContiguousPairsOfBlocks += 1;
                    }
                }
            }

            return numberOfFullBlocks*4 - numberOfContiguousPairsOfBlocks*2;

        }

        public IList<string> StringRepresentationOfNumbers(int n)
        {
            /*
             Write a program that outputs the string representation of numbers from 1 to n.
             But for multiples of three it should output “Fizz” instead of the number and for the multiples of five output “Buzz”.
             For numbers which are multiples of both three and five output “FizzBuzz”.
             * Example:
             * n = 15,
            Return:["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]
             */

            var temp = new List<string>();
            for (var i=1; i<=n; i++)
            {
                if(i % 3 ==0 && i % 5==0 )
                {
                    temp.Add("FizzBuzz");     
                }else if (i % 3==0)
                {
                    temp.Add("Fizz");     
                }else if (i % 5 == 0)
                {
                    temp.Add("Buzz");     
                }else
                {
                    temp.Add(i.ToString());
                }
            }
            return temp;
        }

        public bool NimGame(int n)
        {
            /*
             * You are playing the following Nim Game with your friend: 
             * There is a heap of stones on the table, each time one of you take turns to remove 1 to 3 stones. 
             * The one who removes the last stone will be the winner. You will take the first turn to remove the stones.
                Both of you are very clever and have optimal strategies for the game. 
             * Write a function to determine whether you can win the game given the number of stones in the heap.
                For example, if there are 4 stones in the heap, then you will never win the game: no matter 1, 2, or 3 stones you remove,
             * the last stone will always be removed by your friend.
             */
            throw new NotImplementedException();
        }

        public int SingleNumber(int[] nums)
        {
            //Given an array of integers, every element appears twice except for one. Find that single one.
            if(nums.Length==1) return nums[0];
            Array.Sort(nums);
            for(var i=0; i<nums.Length; )
            {
                if (i < nums.Length -1 && nums[i] == nums[i + 1])
                {
                    i = Math.Min(i + 2, nums.Length);
                }else
                {
                    return nums[i];    
                }
                
            }
            return -1;
        }

        public int GetSum(int a, int b)
        {
            /*
             * Calculate the sum of two integers a and b, but you are not allowed to use the operator + and -.
             */
            throw new NotImplementedException();

        }

        public int AssignCookies(int[] greedFactor, int[] cookies)
        {
            /*
             * Assume you are an awesome parent and want to give your children some cookies. 
             * But, you should give each child at most one cookie. 
             * Each child i has a greed factor gi, which is the minimum size of a cookie that the child will be content with; 
             * and each cookie j has a size sj. 
             * If sj >= gi, we can assign the cookie j to the child i, and the child i will be content. 
             * Your goal is to maximize the number of your content children and output the maximum number.

                Note:
                You may assume the greed factor is always positive. 
                You cannot assign more than one cookie to one child.
             * 
             * Input: [1,2], [1,2,3]

               Output: 2

               Explanation: You have 2 children and 3 cookies. The greed factors of 2 children are 1, 2. 
               You have 3 cookies and their sizes are big enough to gratify all of the children, 
               You need to output 2.
             */

            int countOfServedChildren = 0;
            Array.Sort(cookies);
            Array.Reverse(cookies);
            var cookiesList = new List<int>(cookies);
            foreach (var childGreed in greedFactor)
            {
                for (int j=cookiesList.Count-1; j>=0; j--)
                {
                    if (childGreed <= cookiesList[j])
                    {
                        countOfServedChildren += 1;
                        cookiesList.RemoveAt(j);
                        break;
                    }
                }
            }
            return countOfServedChildren;
        }

        public char FindTheDifference(string s, string t)
        {
            /*
             * Given two strings s and t which consist of only lowercase letters.
               String t is generated by random shuffling string s and then add one more letter at a random position.
               Find the letter that was added in t.
             */
            var myList1 = s.ToCharArray().ToList();
            var myList2 = t.ToCharArray().ToList();

            myList1.Sort();
            myList2.Sort();

            for (var i = 0; i < myList2.Count;i++)
            {
                if (i == myList2.Count - 1) return myList2[i];
                if (myList1[i] != myList2[i]) return myList2[i];
            }
            return new char();
        }

        public int AddDigits(int num)
        {
            /*
            Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.
            For example:
            Given num = 38, the process is like: 3 + 8 = 11, 1 + 1 = 2. Since 2 has only one digit, return it.
             */
            if (num <= 9) return num;
            if (num % 9 == 0) return 9;
            return num % 9;
        }

        public int MaxDepthOfBinaryTree(TreeNode root)
        {
            /*
             Given a binary tree, find its maximum depth.
             The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
             */
            if (root == null) return 0;
            var count = 0;
            CalculateDepth(root, 0, ref count);
            return count;
        }

        private void CalculateDepth(TreeNode node, int previousLevel, ref int count)
        {
            /*
             Given a binary tree, find its maximum depth.
             The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
             */
            int level = previousLevel + 1;
            if (node.left != null)
            {
                CalculateDepth(node.left, level, ref count);
            }
            if (node.right != null)
            {
                CalculateDepth(node.right, level, ref count);
            }
            if (count < level) count = level;
        }

        public int[] MoveZeroes(int[] nums)
        {
            /*
             * Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
               For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0]
             * You must do this in-place without making a copy of the array.
               Minimize the total number of operations.
             */
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    bool isAllZeroes = true;
                    while(true)
                    {
                        for (var j = i ; j <=nums.Length-1; j++)
                        {
                            if (isAllZeroes) isAllZeroes = nums[j] == 0;
                            nums[j] = j != nums.Length - 1 ? nums[j + 1] : 0;
                        }
                        if (nums[i] != 0 || isAllZeroes) break;
                    }
                }
            }
            return nums;
        }

        public int ClosestToZero(int[] nums)
        {
            /*
             From an array of integers(positive and negative) return the number closest to 0.
             * If the array is empty or has only one element which is 0 return 0
             */
            if(nums.Length==0 || nums.Length==1 && nums[0]==0){
                return 0;
            }
            int? ans = null;
            for (int i=0;i<nums.Length;i++)
            {
                if(nums[i]==0) continue;
                ans = ans == null ? nums[i] : Math.Abs(nums[i]) < ans ? nums[i] : ans;
            }
            return ans ?? 0;
        }

        public int MinMoves(int[] nums)
        {
            /*
             Given a non-empty integer array of size n, find the minimum number of moves required to make all array elements equal, where a move is incrementing n - 1 elements by 1.
             * Input:[1,2,3]
               Output:3

                Explanation:
                Only three moves are needed (remember each move increments two elements):

                [1,2,3]  =>  [2,3,3]  =>  [3,4,3]  =>  [4,4,4]
             */
            int count = 0;
            if (nums.Length == 1) return 0;
            if (nums.Length == 2) return nums[1] - nums[0];
            Array.Sort(nums);
            while (nums[nums.Length - 1] - nums[0] >= 1)
            {
                var diff = nums[nums.Length - 1] - nums[0];
                count += diff;
                for (var i = 0; i < nums.Length - 1;i++)
                {
                    nums[i] = nums[i] + diff;
                }
                Array.Sort(nums);
            }
            return count;
        }

        public bool RansomNote(string ransomNote, string magazine)
        {
            /*
             Given an arbitrary ransom note string and another string containing letters from all the magazines,
             write a function that will return true if the ransom note can be constructed from the magazines ; otherwise, it will return false.
            Each letter in the magazine string can only be used once in your ransom note.
             */
            char[] ransomChars = ransomNote.ToCharArray();
            char[] magazineChars = magazine.ToCharArray();
            foreach (var mychar in ransomChars)
            {
                int index = Array.IndexOf(magazineChars,mychar);
                if(index != -1){
                    magazineChars[index] = new char();
                }else
                {
                    return false;
                }
            }
            return true;
        }

        public int[] IntersectionOfTwoArrays(int[] nums1, int[] nums2)
        {
            /*
             Given two arrays, write a function to compute their intersection.
             */
            var less = nums1.Length > nums2.Length ? nums2 : nums1;
            var more = less == nums1 ? nums2 : nums1;
            var intersection = new List<int>();
            foreach (var i in less)
            {
                var index = Array.IndexOf(more, i);
                if(index!=-1 && intersection.IndexOf(i) == -1)
                {
                   intersection.Add(i);
                }
            }
            
            return intersection.ToArray();
            
        }

        public int FirstUniqChar(string s)
        {
            /*
             * Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.
             * Eg.
             * s = "loveleetcode",
               return 2.
             */
            var charArray = s.ToCharArray();
            for (int i=0; i<charArray.Length;i++)
            {
                if(i==0)
                {
                    if (Array.IndexOf(charArray, charArray[i], i + 1) == -1) 
                        return i;
                }else if (i==charArray.Length-1)
                {
                    if (Array.IndexOf(charArray, charArray[i], 0, charArray.Length-1) == -1)
                        return i;
                }
                else if (Array.IndexOf(charArray, charArray[i], i + 1) == -1 &&
                     Array.IndexOf(charArray, charArray[i], 0, i) == -1)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            /*
             Given two binary trees, write a function to check if they are equal or not.
            Two binary trees are considered equal if they are structurally identical and the nodes have the same value.
             */
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val != q.val) return false;
           
            if (!IsSameTree(p.left, q.left)) return false;
            return IsSameTree(p.right, q.right);
            
        }

        public IList<int>  FindDisappearedNumbers(int[] nums)
        {
            /*
             * Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.
               Find all the elements of [1, n] inclusive that do not appear in this array.
               Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.
             * Input:
                [4,3,2,7,8,2,3,1]

                Output:
                [5,6]
             */
            var ret = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int val = Math.Abs(nums[i]) - 1;
                if (nums[val] > 0)
                {
                    nums[val] = -nums[val];
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    ret.Add(i + 1);
                }
            }
            return ret;
        }

        public int ConvertToTitle(string s)
        {
            /*
             * Given a positive integer, return its corresponding column title as appear in an Excel sheet.
             */
            var charArray = s.ToUpperInvariant().ToCharArray();
            int number = 0;
            for (var i = 0; i < charArray.Length;i++)
            {
                number += (Convert.ToInt32(charArray[i]) - 64) * (int)Math.Pow(26.0, (charArray.Length - 1 - i));
                
            }
            return number;
        }

        public bool IsAnagram(string s, string t)
        {
            /*
             Given two strings s and t, write a function to determine if t is an anagram of s.

             For example,
             s = "anagram", t = "nagaram", return true.
             s = "rat", t = "car", return false.

             Note:
             You may assume the string contains only lowercase alphabets.
             */

            var sArray = s.ToUpperInvariant().ToCharArray();
            var tArray = t.ToUpperInvariant().ToCharArray();
            if (sArray.Length != tArray.Length) return false;
            var num = new int[26];
            for (var i = 0; i < sArray.Length; i++)
            {
                num[Convert.ToInt32(sArray[i]) - 65]++;
            }
            for (var i = 0; i < tArray.Length; i++)
            {
                num[Convert.ToInt32(tArray[i]) - 65]--;
            }

            for (var i = 0; i < num.Length; i++)
            {
                if (num[i] != 0) return false;
            }
            return true;
        }

        public bool ContainsDuplicate(int[] nums)
        {
            /*
             * Given an array of integers, find if the array contains any duplicates. Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct.
             */
            int max = 0;
            for (int i = 0; i < nums.Length; i++){
                if (nums[i] > max) max = nums[i];
            }
            var test = new int[max+1];
            for(int i=0;i<nums.Length;i++)
            {
                if(test[Math.Abs(nums[i])]==0)
                {
                    test[Math.Abs(nums[i])] = nums[i] >= 0 ? 1 : -1;
                }
                else if ((test[Math.Abs(nums[i])] < 0 && nums[i] < 0) || (test[Math.Abs(nums[i])] >= 0 && nums[i] >= 0))
                {
                    return true;
                }
            }
            return false;
        }
        
        public int LongestPalindrome(string s)
        {
            /*
            Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters.

            This is case sensitive, for example "Aa" is not considered a palindrome here.

            Note:
            Assume the length of given string will not exceed 1,010.
             */

            bool hasOddValue = false;
            int sumEvenValue = 0;
            var dictionary = new Dictionary<char, int>();
            foreach (var character in s.ToCharArray())
            {
                dictionary[character] = dictionary.ContainsKey(character) ? dictionary[character] + 1 : 1;
            }
            foreach (var key in dictionary.Keys)
            {
                if (dictionary[key] % 2 == 0)
                {
                    sumEvenValue += dictionary[key];
                }
                else
                {
                    sumEvenValue += dictionary[key] - 1;
                    hasOddValue = true;
                }
            }
            return sumEvenValue + (hasOddValue ? 1 : 0); 
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            /*
             * Given two arrays, write a function to compute their intersection.

                 Example:
                 Given nums1 = [1, 2, 2, 1], nums2 = [2, 2], return [2].

                 Note:
                 Each element in the result must be unique.
                 The result can be in any order.
             */

            var d1 = new Dictionary<int,int>();
            var nums = new List<int>();
            foreach (var i in nums1)
            {
                d1[i] = d1.ContainsKey(i) ? d1[i] + 1 : 1;
            }
            foreach (var i in nums2)
            {
               if(d1.ContainsKey(i))
               {
                   nums.Add(i);
                   d1[i] = d1[i] - 1;
                   if (d1[i] == 0) d1.Remove(i);
               }
            }
            return nums.ToArray();
        }

        public int FindComplement(int num)
        {
            /*
            Given a positive integer, output its complement number. The complement strategy is to flip the bits of its binary representation.
            Note:
            The given integer is guaranteed to fit within the range of a 32-bit signed integer.
            You could assume no leading zero bit in the integer’s binary representation.
            Example 1:
            Input: 5
            Output: 2
            Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.
             */
            var bits = new List<char>();
            int i = 0;
            while (num != 0)
            {
                bits.Add((num & 1) == 1 ? '0' : '1');
                num >>= 1;
            }
            bits.Reverse();
            return Convert.ToInt32(new string(bits.ToArray()), 2);
        }

        public int FindMaxConsecutiveOnes(int[] nums)
        {
            /*
             Given a binary array, find the maximum number of consecutive 1s in this array.
            Example 1:
            Input: [1,1,0,1,1,1]
            Output: 3
            Explanation: The first two digits or the last three digits are consecutive 1s.
                The maximum number of consecutive 1s is 3.
            Note:

            The input array will only contain 0 and 1.
            The length of input array is a positive integer and will not exceed 10,000
             */

            int count = 0;
            int maxCount = 0;
            foreach (int i in nums)
            {
                if (i == 1)
                {
                    count += 1;
                }
                else
                {
                    maxCount = count> maxCount?count:maxCount;
                    count = 0;
                }
            }
            return count > maxCount ? count : maxCount;
        }

        public int RomanToInt(string s)
        {
            /*
            Given a roman numeral, convert it to an integer.
            Input is guaranteed to be within the range from 1 to 3999.
             */
            var total = 0;
            var dict1 = new Dictionary<string, int> { { "IV", 4 }, { "IX", 9 }, { "XL", 40 }, { "XC", 90 }, { "CD", 400 }, { "CM", 900 }};
            var dict2 = new Dictionary<char, int> {{'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}};
            foreach (var key in dict1.Keys)
            {
                if(s.IndexOf(key, StringComparison.Ordinal) != -1)
                {
                    total += dict1[key];
                    s = s.Replace(key, string.Empty);
                }
            }
            foreach (var key in s.ToCharArray())
            {
                if (dict2.ContainsKey(key))
                {
                    total += dict2[key];
                }
            }

            return total;
        }

        public int MissingNumber(int[] nums)
        {
            /*
            Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.
            For example, Given nums = [0, 1, 3] return 2
            Your algorithm should run in linear runtime complexity. Could you implement it using only constant extra space complexity?
            */
            var tempArray = new int[nums.Length+1];
            foreach (var num in nums)
            {
                tempArray[num] = 1;
            }
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i] == 0)
                    return i;
            }
            return 0;
        }

        public ListNode ReverseList(ListNode head)
        {
            /*
              Reverse a singly linked list.
             */
            if (head == null) return head;
            var arr = new List<ListNode>();
            while(head != null)
            {
                arr.Add(head);
                head = head.next;
            }
            int i = arr.Count;
            while(--i>0)
            {
                arr[i].next = arr[i - 1];
            }
            arr[0].next = null;
            return arr[arr.Count - 1];
        }

        public void DeleteNode(ListNode node)
        {
            /*
            Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.
            Supposed the linked list is 1 -> 2 -> 3 -> 4 and you are given the third node with value 3, the linked list should become 1 -> 2 -> 4 after calling your function.
            */
            node.val = node.next.val;
            node.next = node.next.next;
        }

        public int[] TwoSum(int[] numbers, int target)
        {
            /*
             Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
             The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.
             Please note that your returned answers (both index1 and index2) are not zero-based.
             You may assume that each input would have exactly one solution and you may not use the same element twice.

            Input: numbers={2, 7, 11, 15}, target=9
            Output: index1=1, index2=2
             */
            int i;int j;
            for (i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] == 0) continue;
                for (j = i+1; j < numbers.Length; j++)
                {
                    if(numbers[i] + numbers[j]==target)
                    {
                        return new [] { i+1, j+1 };
                    }
                }   
            }
            return new [] {1,2};
        }

        public string AddStrings(string num1, string num2)
        {
            /*
            Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.
            Note:
            The length of both num1 and num2 is < 5100.
            Both num1 and num2 contains only digits 0-9.
            Both num1 and num2 does not contain any leading zero.
            You must not use any built-in BigInteger library or convert the inputs to integer directly.
             */
            num1 = num1.PadLeft(num2.Length, '0');
            num2 = num2.PadLeft(num1.Length, '0');
         
            char[] arr1 = num1.ToCharArray();
            char[] arr2 = num2.ToCharArray();

            var sum = new char[(arr1.Length)];
            int carryOver = 0;

            for (int i = arr1.Length - 1; i >= 0; i--)
            {
                int digit = arr1[i] + arr2[i] + carryOver - 48*2;
                carryOver = digit > 9 ? 1 : 0;
                digit = digit > 9 ? digit - 10 : digit;
                sum[i] = (char)(48 + digit);
            }
            return carryOver == 1 ? carryOver + string.Join("", sum) : string.Join("", sum);
        }

        public string[] FindRelativeRanks(int[] nums) {
            /*
             * Given scores of N athletes, find their relative ranks and the people with the top three highest scores,
             * who will be awarded medals: "Gold Medal", "Silver Medal" and "Bronze Medal".
             * Input: [3,10,8,9,4]
            Output: [ "Bronze Medal", "Gold Medal", "Silver Medal", "4", "5"]
            Explanation: The first three athletes got the top three highest scores, so they got "Gold Medal", "Bronze Medal" and "Silver Medal" respectively. 
            For the left two athletes, you just need to output their relative ranks according to their scores.
             */
            var nums1 = new string[nums.Length];
            var dict = new Dictionary<int, int>();
            for (int i=0;i<nums.Length;i++){
                dict[nums[i]] = i;
            }
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                var mystring = (nums.Length - i) == 1
                                   ? "Gold Medal"
                                   : (nums.Length - i) == 2
                                         ? "Silver Medal"
                                         : (nums.Length - i) == 3 ? "Bronze Medal" : (nums.Length - i).ToString();
                nums1[dict[nums[i]]] = mystring;
            }
           
            return nums1;
        }

        public TreeNode InvertTree(TreeNode root)
        {
            /*
             Invert a binary tree.

                 4
               /   \
              2     7
             / \   / \
            1   3 6   9
             
            To
            
                 4
               /   \
              7     2
             / \   / \
            9   6 3   1
             */

            if (root == null) return null;
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;
            if (root.left != null)
            {
                InvertTree(root.left);
            }
            if (root.right != null)
            {
                InvertTree(root.right);    
            }
            
            return root;
        }

        public int NumberOfBoomerangs(int[,] points)
        {
            /*
             Given n points in the plane that are all pairwise distinct, a "boomerang" is a tuple of points (i, j, k) 
             * such that the distance between i and j equals the distance between i and k (the order of the tuple matters).

            Find the number of boomerangs. You may assume that n will be at most 500 and coordinates of points are all in the range [-10000, 10000] (inclusive).
             */
            int count = 0;
            for(int i=0; i < points.GetLength(0)-2; i++)
            {
                for (int j = i+1; j < points.GetLength(0)-1; j++)
                {

                    for (int k = j + 1; k < points.GetLength(0); k++)
                    {
                        Console.WriteLine((i + 1) + "," + (j + 1) + "," + (k + 1));
                        var dist1 = Math.Sqrt(Math.Pow(points[j, 0] - points[i, 0], 2) + Math.Pow(points[j, 1] - points[i, 1], 2));
                        var dist2 = Math.Sqrt(Math.Pow(points[k, 0] - points[i, 0], 2) + Math.Pow(points[k, 1] - points[i, 1], 2));
                        if ((int)dist1 == (int)dist2)
                            count += 1;
                    }
                }
            }
            return count;
        }

        public string ConvertToBase7(int num)
        {
            /*
          Given an integer, return its base 7 string representation.
        Example 1:
        Input: 100
        Output: "202"
          */
            var characters = new List<string>();
            int quotient = Math.Abs(num);
            while (quotient >= 7)
            {
                int remainder = quotient % 7;
                quotient = quotient / 7;
                characters.Insert(0, remainder.ToString());
            }
            characters.Insert(0, (quotient).ToString());
            return num >= 0 ? String.Join("", characters) : '-'+String.Join("", characters);
        }

        public int FindLuslength(string a, string b)
        {
            /*
             * Given a group of two strings, you need to find the longest uncommon subsequence of this group of two strings.
               The longest uncommon subsequence is defined as the longest subsequence of one of these strings and this subsequence should not be any subsequence of the other strings.
               A subsequence is a sequence that can be derived from one sequence by deleting some characters without changing the order of the remaining elements.
               Trivially, any string is a subsequence of itself and an empty string is a subsequence of any string.
               The input will be two strings, and the output needs to be the length of the longest uncommon subsequence. If the longest uncommon subsequence doesn't exist, return -1.
             */
            var maxLength1=-1; var maxLength2 = -1;
            int i = a.Length;
            
            while(i > 0){
                var str1 = a.Substring(0, i);
                if(!b.Contains(str1)){
                    maxLength1 = str1.Length;
                    break;
                }
                i = i - 1;
            }

            i = b.Length;
            while (i > 0)
            {
                var str1 = b.Substring(0, i);
                if (!a.Contains(str1)){
                    maxLength2 = str1.Length;
                    break;
                }
                i = i - 1;
            }
            return maxLength2> maxLength1?maxLength2:maxLength1;
        }

        public int GetMinimumDifference(TreeNode root)
        {
            /*
            Given a binary search tree with non-negative values, find the minimum absolute difference between values of any two nodes.
            Example:
            Input:               1
                                   \
                                    3
                                  /
                                 2
            Output:
            1
            Explanation:
            The minimum absolute difference is 1, which is the difference between 2 and 1 (or between 2 and 3).*/
            var values = new List<int> { root.val };
            GetValues(root, ref values);
            int minValue = 0;

            for (int i = 0; i <= values.Count - 2; i++)
            {
                for (int j = i + 1; j <= values.Count - 1; j++)
                {
                    if (minValue == 0)
                    {
                        minValue = Math.Abs(values[j] - values[i]);
                    }
                    else if (Math.Abs(values[j] - values[i]) < minValue)
                    {
                        minValue = Math.Abs(values[j] - values[i]);
                    }
                }
            }

            return minValue;
        }

        private void GetValues(TreeNode node, ref List<int> values)
        {
            if (node == null) return;

            if (node.left != null)
            {
                values.Add(node.left.val);
                GetValues(node.left, ref values);
            }

            if (node.right != null)
            {
                values.Add(node.right.val);
                GetValues(node.right, ref values);
            }
        }

        public string ReverseStr(string s, int k)
        {
            /*
             Given a string and an integer k, you need to reverse the first k characters for every 2k characters
             * counting from the start of the string. If there are less than k characters left,
             * reverse all of them. If there are less than 2k but greater than or equal to k characters,
             * then reverse the first k characters and left the other as original.
             * The string consists of lower English letters only.
               Length of the given string and k will in the range [1, 10000]
             * 
             * Example:
                Input: s = "abcdefg", k = 2
            Output: "bacdfeg"
             */
           
            var chrArr = s.ToCharArray();
            for (var i = 0; i < chrArr.Length; i = i +2*k)
            {
                var length = Math.Min(k, chrArr.Length - i);
                var tempArr = new char[length];
                Array.Copy(chrArr, i, tempArr, 0, length);
                Array.Reverse(tempArr);
                for(var j=0; j< tempArr.Length;j++)
                {
                    chrArr[i + j] = tempArr[j];
                }
            }
            return new string(chrArr);
        }

        public bool DetectCapitalUse(string word)
        {
            /*
             Given a word, you need to judge whether the usage of capitals in it is right or not.
            We define the usage of capitals in a word to be right when one of the following cases holds:

            All letters in this word are capitals, like "USA".
            All letters in this word are not capitals, like "leetcode".
            Only the first letter in this word is capital if it has more than one letter, like "Google".
            Otherwise, we define that this word doesn't use capitals in a right way.
             * 
             * Example 1:
            Input: "USA"
            Output: True
            Example 2:
            Input: "FlaG"
            Output: False
             */

            if(word.ToLowerInvariant() == word) return true;
            if(word.ToUpperInvariant() == word) return true;
            
            var chrArr = word.ToCharArray();
            if(Char.IsLower(chrArr[0])) return false;

            for (var i = 1; i < chrArr.Length; i++)
            {
                if (!Char.IsLower(chrArr[i])) return false;
            }
            return true;
        }

        public int[] ConstructRectangle(int area)
        {
            /*
             Design a rectangular web page, whose length L and width W satisfy the following requirements:
            1. The area of the rectangular web page you designed must equal to the given target area.
            2. The width W should not be larger than the length L, which means L >= W.
            3. The difference between length L and width W should be as small as possible.
            You need to output the length L and the width W of the web page you designed in sequence.
             * Example:
                Input: 4
                Output: [2, 2]
             * 
             */
            var sides = new []{area,1};
            for(var i = 1; i <= area/2; i++)
            {
                if(area % i==0)
                {
                    if ( i>= area/i && (i - area / i) < (sides[0] - sides[1]))
                    {
                        sides = new[] { i, area / i };    
                    }
                    
                }
            }

            return sides;

        }

        public int ArrayPairSum(int[] nums)
        {
            /*
             Given an array of 2n integers, your task is to group these integers into n pairs of integer,
             say (a1, b1), (a2, b2), ..., (an, bn) which makes sum of min(ai, bi) for all i from 1 to n as large as possible.
            Example 1:
            Input: [1,4,3,2]

            Output: 4
            Explanation: n is 2, and the maximum sum of pairs is 4.
             */

            Array.Sort(nums);
            int sum = 0;
            for(var i=0;i<nums.Length-1;i+=2)
            {
                sum += nums[i];
            }

            return sum;
        }

        public int MaxProfit(int[] prices)
        {
            /*
             Say you have an array for which the ith element is the price of a given stock on day i.
             Design an algorithm to find the maximum profit.
             You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times).
             However, you may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
             */
            if (prices.Length == 0 || prices.Length == 1) return 0;
            int sellPrice = 0; int buyPrice = prices[0];

            for (var i = 1; i < prices.Length; i++)
            {
                if (prices[i] > buyPrice)
                {
                    if(prices[i] > sellPrice)
                        sellPrice = prices[i];
                }
                else
                {
                    buyPrice = prices[i];
                }
            }
            return sellPrice > 0 ? sellPrice - buyPrice : 0;
        }

        public string[] FindWords(string[] words)
        {
            /*
             * Given a List of words, return the words that can be typed using letters of
             * alphabet on only one row's of American keyboard like the image below.
             */
            var firstRow = new List<char>(){'q','w','e','r','t','y','u','i','o','p'};
            var secondRow = new List<char>() { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            var thirdRow = new List<char>() { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
            var found = new List<string>();
            foreach (var word in words)
            {
                var characters = word.ToCharArray();
                bool isInRow = true;
                foreach (var character in characters){
                    if (firstRow.IndexOf(character) == -1){
                        isInRow = false; break;
                    }
                }
                if (isInRow) found.Add(word);
                if(!isInRow)
                {
                    foreach (var character in characters)
                    {
                        if (secondRow.IndexOf(character) == -1){
                            break;
                        }
                    }   
                }
                if (isInRow) found.Add(word);
                if (!isInRow)
                {
                    foreach (var character in characters)
                    {
                        if (thirdRow.IndexOf(character) == -1){
                            break;
                        }
                    }
                }
                if (isInRow) found.Add(word);
            }
            return found.ToArray();
        }

    }


    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }

    public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int x) { val = x; }
  }

}
