using System.Text;

namespace StringAndArrays
{
    class Program
    {
        public static void Main(string[] args)
        {
            //var input11 = "loveleetcode";
            //var output11 = FirstUniqueCharIndex(input11);
            //System.Diagnostics.Debug.WriteLine($"1.1 Index: {output11}");

            //var input12 = "hello";
            //var output12 = ReverseString(input12);
            //System.Diagnostics.Debug.WriteLine($"1.2 Reverse: {output12}");

            //var input13 = new char[] {'t', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e', ' ', 'n', 'o', 'w'};
            //ReverseWords(input13);
            //foreach (var item in input13)
            //{
            //    System.Diagnostics.Debug.Write($"{item}");
            //}

            //var input14 = new int[]{2, 7, 11, 15};
            //var output14 = TwoSum(input14, 30);
            //foreach (var item in output14)
            //{
            //    System.Diagnostics.Debug.Write($"{item} ");
            //}

            //var input15 = new int[] { 1, -1, 5, -2, 3 };
            //var output15 = MaxSubArrayLen(input15, 3);
            //System.Diagnostics.Debug.WriteLine($"Result: {output15}");

            //var input15b = new int[] { -1 };
            //var output15b = MaxSubArrayLen(input15b, -1);
            //System.Diagnostics.Debug.WriteLine($"Result: {output15b}");

            //var input15c = new int[] { -2, -1, 2, 1 };
            //var output15c = MaxSubArrayLen(input15c, 1);
            //System.Diagnostics.Debug.WriteLine($"Result: {output15c}");

            //var output16 = CompareVersion("0.1", "1.1");
            //System.Diagnostics.Debug.WriteLine($"Result: {output16}");

            //var output16b = CompareVersion("1.0.1", "1");
            //System.Diagnostics.Debug.WriteLine($"Result: {output16b}");

            //var output16c = CompareVersion("7.5.2.4", "7.5.3");
            //System.Diagnostics.Debug.WriteLine($"Result: {output16c}");

            //var output16d = CompareVersion("1", "1.1");
            //System.Diagnostics.Debug.WriteLine($"Result: {output16d}");

            // 1.7
            //var input17 = "";// "ccc";
            //System.Diagnostics.Debug.WriteLine($"Result: {LongestPalindrome(input17)}");

            // 1.8
            //var input18 = new int[] { 1, 2, 3, 4 };
            //foreach (var item in ProductExceptSelf(input18))
            //{
            //    System.Diagnostics.Debug.Write($"{item} ");
            //}

            // 1.9
            //var input19 = new int[] { 2, 12, 52, 123, 12345, 1234567, 1234567891 };
            //foreach (var item in input19)
            //{
            //    System.Diagnostics.Debug.WriteLine($"> {item.ToString()} : {NumberToWords(item)}\n");
            //}

            // 1.10
            var input110 = new[] {
                new int[] { 2, 12, 3, 43, 2, 9 },
                new int[] { 1, 3, 4, 2, 2 },
                new int[] { 3, 1, 3, 4, 2 }
            };
            foreach (var item in input110)
            {
                System.Diagnostics.Debug.Write("[");
                for (int i = 0; i < item.Length; i++)
                {
                    System.Diagnostics.Debug.Write($"{item[i].ToString()},");
                }
                System.Diagnostics.Debug.Write("] ");
                System.Diagnostics.Debug.Write($"Found: {FindDuplicate(item)}\n\r");
            }
        }

        #region 1.1
        static int FirstUniqueCharIndex(string s)
        {
            var result = -1;

            var countArray = new char[256];

            for (int i = 0; i < s.Length; i++)
            {
                countArray[s[i]]++;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (countArray[s[i]] == 1)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
        #endregion

        #region 1.2
        static string ReverseString(string s)
        {
            var orgArray = s.ToCharArray();
            System.Array.Reverse(orgArray);
            return new string(orgArray);
        }

        #endregion

        #region 1.3
        static void ReverseWords(char[] str)
        {
            var s = new string(str);
            var sArray = s.Split(' ');

            for (int i = 0, j = sArray.Length - 1; i <= j; i++, j--)
            {
                var temp = sArray[i];
                sArray[i] = sArray[j];
                sArray[j] = temp;
            }

            s = string.Join(" ", sArray);
            var r = s.ToCharArray();

            for (int i = 0; i <= r.Length - 1; i++)
            {
                str[i] = r[i];
            }
        }

        #endregion

        #region 1.4
        static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                for (int j = 1; j <= nums.Length - 1; j++)
                {
                    if (i != j && nums[i] + nums[j] == target)
                        return new int[] { i, j };
                }
            }
            return new int[0];
        }
        #endregion

        #region 1.5
        static public int MaxSubArrayLen(int[] nums, int k)
        {
            var count = 0;
            var sum = 0;

            for (int i = 0; i <= nums.Length - 1; i++)
            {
                sum = nums[i];
                //count = 0;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    sum += nums[j];
                    //count++;

                    if (sum == k)
                    {
                        count = i + 1;
                    }
                }
            }
            return count;
        }

        static public int MaxSubArrayLen2(int[] nums, int k)
        {
            var max = 0;
            var sum = 0;

            var dict = new System.Collections.Generic.Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (sum == k)
                    max = System.Math.Max(max, i + 1);

                int diff = sum - k;

                if (!dict.ContainsKey(diff))
                    dict.Add(diff, i);
                else
                    max = System.Math.Max(max, i - dict[diff]);

            }

            return max;
        }
        #endregion

        #region 1.6
        static int CompareVersion(string v1, string v2)
        {

            var version1 = v1.Split('.');
            var version2 = v2.Split('.');
            var length = System.Math.Min(version1.Length, version2.Length);

            for (int i = 0; i < length; i++)
            {
                var ve1 = int.Parse(version1[i]);
                var ve2 = int.Parse(version2[i]);

                if (ve1 > ve2)
                {
                    return 1;
                }

                if (ve1 < ve2)
                {
                    return -1;
                }
            }

            if (version1.Length > version2.Length)
            {
                for (int i = length; i < version1.Length; i++)
                {
                    if (int.Parse(version1[i]) > 0)
                        return 1;
                }
            }

            if (version2.Length > version1.Length)
            {
                for (int i = length; i < version2.Length; i++)
                {
                    if (int.Parse(version2[i]) > 0)
                        return -1;
                }
            }

            return 0;
        }
        #endregion

        #region 1.7
        static string LongestPalindrome(string s)
        {
            var n = s.Length;
            var startIndex = 0;
            var length = 0;
            var MAX = n < 1000 ? n : 1000;

            if (n == 1)
                length = 1;

            var matrix = new bool[n, n];

            // Set the flags first
            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = true;
                length = 1;
            }

            // Check 2 characters
            for (int i = 0; i < n - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    matrix[i, i + 1] = true;
                    startIndex = i;
                    length = 2;
                }
            }

            // Check 3+ characters
            for (int ln = 3; ln <= n; ln++)
            {
                for (int i = 0; i < n - ln + 1; i++)
                {
                    int j = i + ln - 1;

                    if (s[i] == s[j] && matrix[i + 1, j - 1])
                    {
                        matrix[i, j] = true;
                        startIndex = i;
                        length = ln;
                    }
                }
            }

            return s.Substring(startIndex, length);
        }
        #endregion

        #region 1.8
        static int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            res[0] = 1;
            for (int i = 1; i < n; i++)
            {
                res[i] = res[i - 1] * nums[i - 1];
            }
            int right = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                res[i] *= right;
                right *= nums[i];
            }
            return res;
        }
        #endregion

        #region 1.9
        static string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            return GetEnglishWord(num);
        }

        static string GetEnglishWord(int num)
        {
            var TEENS = new string[20] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var TENS = new string[10] { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            
            var sb = new StringBuilder();

            if (num < 20)
            {
                sb.Append($"{TEENS[num]}");
            }
            else if (num < 100)
            {
                sb.Append($"{TENS[num / 10]} {TEENS[num % 10]}");
            }
            else if (num < 1000)
            {
                sb.Append($"{GetEnglishWord(num/100)} Hundred {GetEnglishWord(num % 100)}");
            }
            else if (num < 1000000)
            {
                sb.Append($"{GetEnglishWord(num / 1000)} Thousand {GetEnglishWord(num % 1000)}");
            }
            else if (num < 1000000000)
            {
                sb.Append($"{GetEnglishWord(num / 1000000)} Million {GetEnglishWord(num % 1000000)}");
            }
            else
            {
                sb.Append($"{GetEnglishWord(num / 1000000000)} Billion {GetEnglishWord(num % 1000000000)}");
            }

            return sb.ToString().Trim();
        }
        #endregion

        #region 1.10
        static int FindDuplicate(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j < nums.Length; j++)
                {
                    if (i != j && nums[i] == nums[j])
                        return nums[i];
                }
            }
            return -1;
        }
        #endregion
    }
}


