using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;

using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        private static Leetcode _leetcode;

        static void Main(string[] args)
        {
            _leetcode = new Leetcode();

            _leetcode.HammingDistance(1,4);

            _leetcode.FindCompliment(5);

            _leetcode.ReverseString("abc");

            _leetcode.BestProfit(new List<int>() { 10, 7, 5, 8, 11, 9 });

            _leetcode.GetProductOfAllIntsExceptAtIndex(new int[]{5,1,2,4,3 });

            _leetcode.GetHighestProduct(new List<int>() { 1, 2, 3, 3, 2, 1 });

            _leetcode.GetLargestNonRepeatingSubstring("wzrjugcptmrserlhhoaudcboimpdrpaqqrzmxddtqvluoweymgspitfshwwynwqfnqrnv");

            _leetcode.LongestPalindromicSubstring("xyzlolololabccba");

            _leetcode.IslandInOcean(new[,] {{0, 1, 0, 0}, {1, 1, 1, 1}, {0, 1, 0, 0}, {1, 1, 0, 0}});

            //_leetcode.StringRepresentationOfNumbers(15);

            //_leetcode.NimGame(5);

            //_leetcode.SingleNumber(new int[] {17,12,5,-6,12,4,17,-5,2,-3,2,4,5,16,-3,-4,15,15,-4,-5,-6});

            //_leetcode.GetSum(5, 6);

            //_leetcode.AssignCookies(new int[]{1,2,2,2}, new int[]{1,2,1});

            //_leetcode.FindTheDifference("ab", "aba");

            //_leetcode.AddDigits(12345)

            //_leetcode.MaxDepthOfBinaryTree(new TreeNode(10){left = new TreeNode(2){left = new TreeNode(1){left = new TreeNode(0){right = new TreeNode(-1)}},right = new TreeNode(4){left = new TreeNode(3)}},right = new TreeNode(6){left = new TreeNode(5)}});

            //_leetcode.MoveZeroes(new[] { 1, 0, 2, 3, 0, 1 });

            //_leetcode.ClosestToZero(new int[]{});

            //_leetcode.MinMoves(new int[] { });

            //_leetcode.RansomNote("aa", "aba");

            //_leetcode.IntersectionOfTwoArrays(new[] { 1, 2, 2, 1 }, new int[] { 2, 2 });

            //_leetcode.FirstUniqChar("coddoce");

            //_leetcode.IsSameTree(new TreeNode(0) { left = new TreeNode(2)}, new TreeNode(0) { left = new TreeNode(2) });

            //_leetcode.FindDisappearedNumbers(new int[] {3, 1, 1, 1});

            //_leetcode.ConvertToTitle("ZZZ");

            //_leetcode.IsAnagram("a","b");

            //_leetcode.ContainsDuplicate(new int[]{0,4,5,0,3,6});

            //_leetcode.LongestPalindrome("civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth");

            //_leetcode.Intersect(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 });

            //_leetcode.FindComplement(5);

            //_leetcode.FindMaxConsecutiveOnes(new int[] {1, 0, 1, 1, 0, 1});

            //_leetcode.RomanToInt("DCCCXC");

            //_leetcode.MissingNumber(new [] { 0 });

            //_leetcode.ReverseList(new ListNode(1){next = new ListNode(2){next = new ListNode(3){next =new ListNode(4)}}});

            //_leetcode.DeleteNode(new ListNode(3){next = new ListNode(4)});

            //_leetcode.TwoSum(new []{2, 7, 11, 15}, 9 );

            //_leetcode.AddStrings("3876620623801494171","6529364523802684779");

            //_leetcode.FindRelativeRanks(new [] {3,10,8,9,4});

            //_leetcode.InvertTree(new TreeNode(4) { left = new TreeNode(2) { left = new TreeNode(1), right = new TreeNode(3) }, right = new TreeNode(7) { left = new TreeNode(6), right = new TreeNode(9) } });

            //_leetcode.NumberOfBoomerangs(new [,] { { 0,0 }, { 1, 0 }, { -1, 0 }, {0 ,1} , {0, -1}});

            //_leetcode.ConvertToBase7(-7);

            //_leetcode.FindLuslength("aba", "daba");

            //_leetcode.GetMinimumDifference(new TreeNode(1){left = null,right = new TreeNode(3) { left = new TreeNode(2), right = null }});

            //_leetcode.ReverseWords("Let's take LeetCode contest");

            //_leetcode.NextGreaterElement(new[] { 2, 4 }, new[] { 1, 2, 3, 4 });

            //_leetcode.MaxProfit(new[] { 3, 3, 5, 0, 0, 3, 1, 4 });

            //_leetcode.DistributeCandies(new[] {1,1});

            //_leetcode.FindWords(new []{"Hello", "Alaska", "Dad", "Peace"});

            //_leetcode.MatrixReshape(new int[2,2] {{1, 2}, {3, 4}}, 2, 4);

            //_leetcode.FibbonaciNumber(8181);

            //_leetcode.NodesAtSameLevel(new TreeNode(4) { left = new TreeNode(2) { left = new TreeNode(1), right = new TreeNode(3) },right = new TreeNode(7){ left = new TreeNode(6),right = new TreeNode(9) }}, new List<TreeNode>(), 3, 1);

            //_leetcode.MergeTrees(new TreeNode(4){left = new TreeNode(2) { left = new TreeNode(1), right = new TreeNode(3) },right = new TreeNode(7) {left = new TreeNode(6), right = new TreeNode(9)}},new TreeNode(4){left = new TreeNode(2) {left = new TreeNode(1), right = new TreeNode(3)},right = new TreeNode(7) {left = new TreeNode(6), right = new TreeNode(9)}});

            //_leetcode.AverageOfLevels(new TreeNode(3){left = new TreeNode(9),right = new TreeNode(20){left = new TreeNode(15),right = new TreeNode(7)}});

            //_leetcode.FindRestaurant(new[] { "Shogun", "KFC", "Burger King", "Tapioca Express" },new[] {"KFC", "Shogun", "Burger King"});
           
            //_leetcode.FindLuslength("aba", "daba");

            //_leetcode.ReverseStr("abcdefghi", 5);

            //_leetcode.DetectCapitalUse("FlaG");

            //_leetcode.ConstructRectangle(24);

            //_leetcode.ArrayPairSum(new [] { 7, 3, 1, 0, 0, 6 });
            
            //_leetcode.MaxProfit(new[] { 1, 4, 2 });

            //_leetcode.FindWords(new [] {"Hello", "Alaska", "Dad", "Peace"});

            //_leetcode.ReadBinaryWatch(7);

            //_leetcode.CheckRecord("PPALLL");

            //_leetcode.IsHappy(19);

            //_leetcode.IsPowerOfThree(243);

            //_leetcode.DeleteDuplicates(new ListNode(1){next=new ListNode(1){next = new ListNode(1){next = new ListNode(2){next = new ListNode(2){next = new ListNode(3){next = new ListNode(3)}}}}}});
        }
    }

   

}
