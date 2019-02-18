using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
    public class ProTest
    {
        #region HackerRank Problems

        #region Problem

        #endregion

        #region Problem

        #endregion

        #region Problem

        #endregion

        #region Problem

        #endregion

        #region Problem

        #endregion

        #region Problem Stair Case with 1 2, 3 steps

        static readonly int[] results = new int[37];

        private static int Fibonacci(int n)
        {
            if (results[n] != -1)
            {
                return results[n];
            }
            results[n] = Fibonacci(n - 1) + Fibonacci(n - 2) + Fibonacci(n - 3);
            return results[n];
        }

        public static void TestStairCaseProblem()
        {
            for (int i = 0; i < 37; i++)
            {
                results[i] = -1;
            }
            results[0] = 1;
            results[1] = 1;
            results[2] = 2;

            int s = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < s; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Fibonacci(n));
            }
        }

        #endregion

        #region Problem LonelyInteger

        public static void GetUniqueElement()
        {
            int[] a = { 1, 2, 1, 7, 2, 3, 3 };

            int unique = LonelyInteger1(a);
            Console.WriteLine(unique);

            unique = LonelyInteger2(a);
            Console.WriteLine(unique);

            unique = LonelyInteger3(a);
            Console.WriteLine(unique);
        }

        private static int LonelyInteger1(int[] a)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int t in a)
            {
                if (!set.Add(t))
                {
                    set.Remove(t);
                }
            }
            int[] arr = set.ToArray();
            if (arr.Length > 0)
            {
                return arr[0];
            }
            return -1;
        }

        private static int LonelyInteger2(int[] a)
        {
            IDictionary<int, int> result = new Dictionary<int, int>();
            foreach (var item in a)
            {
                if (result.ContainsKey(item))
                {
                    result[item] = result[item] + 1;
                }
                else
                {
                    result.Add(item, 1);
                }
            }
            int value = -1;
            foreach (var item in result)
            {
                if (item.Value == 1)
                {
                    value = item.Key;
                    break;
                }
            }
            return value;
        }

        private static int LonelyInteger3(int[] a)
        {
            int n = a.Length;
            int res = 0;
            for (int i = 0; i < n; i++)
                res ^= a[i];
            return res;
        }

        #endregion

        #region FindRunningMedian

        static float GetMedianValue(int[] array)
        {
            Array.Sort(array);

            float medianValue;
            int length = array.Length;
            int half = length / 2;

            if (length % 2 == 0)
            {
                medianValue = (float)(array[half - 1] + array[half]) / 2;
            }
            else
            {
                medianValue = array[half];
            }
            return Convert.ToSingle(medianValue);
        }

        public static void TestRunningMedian()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
                int[] temp = new int[i + 1];
                Array.Copy(a, 0, temp, 0, i + 1);
                float value = GetMedianValue(temp);
                Console.WriteLine("{0:0.0}", value);
            }
        }

        #endregion

        #region Contacts

        static readonly IDictionary<string, int> v_NamesWithCounter = new Dictionary<string, int>();

        static private int FindPartial(string partialName)
        {
            if (!v_NamesWithCounter.ContainsKey(partialName))
            {
                return 0;
            }
            int counter = v_NamesWithCounter[partialName];
            return counter;
        }

        static private void AddContact(string contact)
        {
            if (!string.IsNullOrEmpty(contact))
            {
                for (int i = 0; i < contact.Length; i++)
                {
                    string newToken = contact.Substring(0, i + 1);
                    if (v_NamesWithCounter.ContainsKey(newToken))
                    {
                        v_NamesWithCounter.Add(newToken, v_NamesWithCounter[newToken] + 1);
                    }
                    else
                    {
                        v_NamesWithCounter.Add(newToken, 1);
                    }
                }
            }
        }

        public static void SolveContactProblem()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < n; a0++)
            {
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    string[] tokens = readLine.Split(' ');
                    string op = tokens[0];
                    string contact = tokens[1];
                    if (op.Equals("add"))
                    {
                        AddContact(contact);
                    }
                    else if (op.Equals("find"))
                    {
                        int count = FindPartial(contact);
                        Console.WriteLine(count);
                    }
                }
            }
        }

        #endregion

        #region RotateArrayLeft

        static void RotateArrayLeft2(ref int[] array, int kRotation)
        {
            int length = array.Length;
            if (length < 2)
            {
                return;
            }

            int[] updateList = new int[length];
            for (int i = 0; i < length; i++)
            {
                int newIndex = (i + kRotation) % length;
                updateList[i] = array[newIndex];
            }
            array = updateList;
        }

        static void RotateArrayLeft(ref int[] array)
        {
            int length = array.Length;
            if (length < 2)
            {
                return;
            }
            int first = array[0];

            IList<int> updateList = new List<int>();
            for (int i = 1; i < length; i++)
            {
                updateList.Add(array[i]);
            }
            updateList.Add(-1); // Toda make a place holder.
            array = updateList.ToArray();
            array[array.Length - 1] = first;
        }

        public static void TestArrayLeftRotation()
        {
            int n = 5;
            int k = 3;
            int[] a = { 1, 2, 3, 4, 5 };

            //for (int i = 0; i < k; i++) {
            //    RotateArrayLeft(ref a);
            //}

            RotateArrayLeft2(ref a, k);

            // Display the array.
            Console.WriteLine(string.Join(",", a));
        }

        #endregion

        #region Alphabets

        const string c_Alphabet = "abcdefghijklmnopqrstuvwxyz";

        private static int GetCharPosition(char c)
        {
            char[] array = c_Alphabet.ToCharArray();

            int position = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(c))
                {
                    if (array[i].Equals('a') || array[i].Equals('e') || array[i].Equals('i') || array[i].Equals('o') ||
                        array[i].Equals('u'))
                    {
                        position = 2 * (i + 1);
                    }
                    else
                    {
                        position = i + 1;
                    }
                }
            }
            return position;
        }

        private static int GetWordsScore(string word)
        {
            int score = 0;

            char[] charsInWord = word.ToCharArray();
            foreach (char t
                in
                charsInWord)
            {
                score += GetCharPosition(t);
            }
            return score;
        }

        static int Compare(KeyValuePair<int, string> a, KeyValuePair<int, string> b)
        {
            return a.Key.CompareTo(b.Key);
        }

        static string[] SortWordsByScore(string[] words)
        {
            var wordsWithScore = new List<KeyValuePair<int, string>>();
            foreach (string word in words)
            {
                wordsWithScore.Add(new KeyValuePair<int, string>(GetWordsScore(word), word));
            }
            wordsWithScore.Sort(Compare);

            IList<string> sortedList = new List<string>();
            foreach (var temp in wordsWithScore)
            {
                sortedList.Add(temp.Value);
            }

            return sortedList.ToArray();
        }

        public static void SolveHackerRankProblem()
        {
            Console.WriteLine("SolveHackerRankProblem");
            string s1 = "this";
            string s2 = "that";
            string s3 = "this";
            string s4 = "the";
            string s5 = "there";
            int score = GetWordsScore(s1.ToLower());

            string[] words = { s1, s2, s3, s4, s5 };
            string[] sortedWords = SortWordsByScore(words);
        }

        #endregion

        #endregion

        #region TestBalancedBrackets

        public static void TestBalancedBrackets()
        {
            string eq1 = "{()[ ([]) ] }";
            string eq2 = "{{ [() {} () [] {} ]" + "}}";
            string eq3 = "{[}]";
            string eq4 = "[]{}()";
            string eq5 = "{";
            bool status = CheckBalancedBrackets(eq1);
            Console.WriteLine("FindBalancedBrackets Balanced : " + status);

            status = CheckBalancedBrackets(eq2);
            Console.WriteLine("FindBalancedBrackets Balanced : " + status);

            status = CheckBalancedBrackets(eq3);
            Console.WriteLine("FindBalancedBrackets Balanced : " + status);

            status = CheckBalancedBrackets(eq4);
            Console.WriteLine("FindBalancedBrackets Balanced : " + status);

            status = CheckBalancedBrackets(eq5);
            Console.WriteLine("FindBalancedBrackets Balanced : " + status);
        }

        static bool MatchBracket(char open, char close)
        {
            if (open.Equals('(') && close.Equals(')'))
            {
                return true;
            }
            if (open.Equals('{') && close.Equals('}'))
            {
                return true;
            }
            if (open.Equals('[') && close.Equals(']'))
            {
                return true;
            }
            return false;
        }

        static bool CheckBalancedBrackets(string equation)
        {
            char[] symbols = equation.ToCharArray();
            Stack<char> list = new Stack<char>();

            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i].Equals('(') || symbols[i].Equals('{') || symbols[i].Equals('['))
                {
                    list.Push(symbols[i]);
                }
                else if (symbols[i].Equals(')') || symbols[i].Equals('}') || symbols[i].Equals(']'))
                {
                    if (list.Count == 0 || !MatchBracket(list.Peek(), symbols[i]))
                    {
                        return false;
                    }
                    list.Pop();
                }
            }
            return list.Count == 0;
        }

        #endregion

        #region TestMinimumMeetingRoomsRequired TODO

        public static void TestMinimumMeetingRoomsRequired()
        {
            IList<Meeting> listOfMeetings = new List<Meeting>();
            listOfMeetings.Add(new Meeting(8, 10));
            listOfMeetings.Add(new Meeting(10, 12));
            listOfMeetings.Add(new Meeting(9, 10));
            listOfMeetings.Add(new Meeting(8, 9));
            listOfMeetings.Add(new Meeting(14, 16));
            listOfMeetings.Add(new Meeting(11, 15));

            int answer = FindMettingRooms(listOfMeetings);
            Console.WriteLine("FindMettingRooms NumberOfRooms : " + answer);
        }

        class Meeting
        {
            public int StartTime;
            public int EndTime;

            public Meeting(int start, int end)
            {
                StartTime = start;
                EndTime = end;
            }
        }

        /*
         public int minMeetingRooms(Interval[] intervals) {
            if(intervals==null||intervals.length==0)
                return 0;
 
            Arrays.sort(intervals, new Comparator<Interval>(){
                public int compare(Interval i1, Interval i2){
                    return i1.start-i2.start;
                }
            });
     
            PriorityQueue<Integer> queue = new PriorityQueue<Integer>();
            int count=1;
            queue.offer(intervals[0].end);
 
            for(int i=1; i<intervals.length; i++){
                if(intervals[i].start<queue.peek()){
                    count++;
             
                }else{
                    queue.poll();
                } 
                queue.offer(intervals[i].end);
            }
 
            return count;
        }
         */

        static int FindMettingRooms(IList<Meeting> meetings)
        {
            foreach (Meeting meet in meetings)
            {
            }

            return 0;
        }

        #endregion

        #region TestLastLines

        public static void TestLastLines()
        {
            string str1 = "str1\nstr2\nstr3\nstr4\nstr5\nstr6\nstr7\nstr8\nstr9" +
                          "\nstr10\nstr11\nstr12\nstr13\nstr14\nstr15\nstr16\nstr17" +
                          "\nstr18\nstr19\nstr20\nstr21\nstr22\nstr23\nstr24\nstr25";
            string str2 = "str1\nstr2\nstr3\nstr4\nstr5\nstr6\nstr7";
            string str3 = "\n";
            string str4 = "";

            PrintLastLines(str1, 10);
            PrintLastLines(str2, 10);
            PrintLastLines(str3, 10);
            PrintLastLines(str4, 10);
        }

        static void PrintLastLines(string data, int lines)
        {
            string[] listOfLines = data.Split('\n');

            if (listOfLines.Length > lines)
            {
                for (int i = listOfLines.Length - 1; i > (listOfLines.Length - 1) - lines; i--)
                {
                    Console.WriteLine(listOfLines[i]);
                }
            }
            else
            {
                foreach (string line in listOfLines)
                {
                    Console.WriteLine(line);
                }
            }
        }

        #endregion

        static int GetMissingNo(int[] a, int n)
        {
            int x1 = a[0];
            int x2 = 1;

            /* For xor of all the elements  
            in array */
            for (int i = 1; i < n; i++)
                x1 = x1 ^ a[i];

            /* For xor of all the elements  
            from 1 to n+1 */
            for (int i = 2; i <= n + 1; i++)
                x2 = x2 ^ i;

            return (x1 ^ x2);
        }

        //Swap(){
        // Code to swap 'x' and 'y'  using Multiply and Divide
        //x = x* y;  // x now becomes 50 
        //y = x / y;  // y becomes 10 
        //x = x / y;  // x becomes 5 

        // Code to swap 'x' (1010) and 'y' (0101)  using XOR
        //x = x ^ y;  // x now becomes 15 (1111) 
        //y = x ^ y;  // y becomes 10 (1010) 
        //x = x ^ y;  // x becomes 5 (0101)
 
        //}

        // This utility calculates the number of digits in multiplication of two numbers
        public static int CountDigits(int a, int b)
        {
            // if either of the number is 0, 
            // then product will be 0 
            if (a == 0 || b == 0)
                return 1;

            // required count of digits          
            return (int)Math.Floor(Math.Log10(Math.Abs(a)) + Math.Log10(Math.Abs(b))) + 1;


            // Theoratically it will be always n1 + n2 -1 or n1 + n2;
        }

        private static string Multiply(string num1, string num2)
        {
            int length1 = num1.Length;
            int length2 = num2.Length;

            if (length1 == 0 || length2 == 0) {
                return "0";
            }
            int i_n1 = 0; // to shift the indexes on each numbers
            int i_n2 = 0;

            //int[] result = Enumerable.Repeat(-1, length1 + length2).ToArray(); // Initialize the array with given value;
            int[] result = new int[length1 + length2];

            for (int i = length1 - 1; i >= 0; i--) {
                int carry = 0;
                int n1 = Int32.Parse(num1[i].ToString());
                i_n2 = 0;

                for (int j = length2 - 1; j >= 0; j--) {
                    int n2 = Int32.Parse(num2[j].ToString());

                    int sum = n1 * n2 + result[i_n1 + i_n2] + carry;
                    carry = sum / 10; // 1

                    result[i_n1 + i_n2] = sum % 10;
                    i_n2++;
                }

                if (carry > 0) {
                    result[i_n1 + i_n2] = result[i_n1 + i_n2] + carry;
                }
                i_n1++;
            }

            string s = "";
            int resultLength = result.Length -1;
            while (resultLength >= 0) {
                s += result[resultLength--];
            }
            return s.TrimStart('0');
        }

        public static void TesttwoLargeNumberMultiplication()
        {
            string str1 = "1235421415454545454545454544"; //Console.ReadLine(); //
            string str2 = "1714546546546545454544548544544545"; //Console.ReadLine();//
            // Consider addressing the sign of each number at frist index before passing the numbers into Multiply
            string result = Multiply(str1, str2);
            // Answer : 2118187521397235888154583183918321221520083884298838480662480
            Console.WriteLine("TesttwoLargeNumberMultiplication : "+ result);
        }

        #region Test Random

        public static void TestRandom()
        {
            TesttwoLargeNumberMultiplication();
            #if false

            //#1 Reverse the string
            string test = "I Love programming very much";
            string reversed = ReversedString(test);
            Console.WriteLine(reversed);

            //#2 Find the majority element
            int[] arrayValues = {1, 2, 2, 2, 4, 2, 1, 2, 7, 2};
            int answer = FindTheMajorityElement(arrayValues);
            Console.WriteLine("MajorityElement is : " + answer);

            //#3 Find Digital Root 
            int num = 12345;
            //Also called seed (1+2+3+4+5 = 6) = > 1+2 > 3+ 3 > 6 + 4 > 10 +5> 15 = > 1+5 > 6
            // Do this cumulative addition until reach to single digit.
            answer = FindDigitalRoot(num);
            Console.WriteLine("DigitalRoot is : " + answer);


            //#4 Find Unique number
            int[] arrayValues2 = {1, 2, 2, 2, 4, 2, 1, 4, 7, 2};
            answer = FindUniqueNumber(arrayValues2);
            Console.WriteLine("UniqueNumber is : " + answer);

            //#5 Merge and Sort
            int[] array1 = {3, 5, 6, 9, 12, 14, 18, 20, 25, 28};
            int[] array2 = {30, 32, 34, 36, 38, 40, 42, 44, 46, 48};

            int[] arrayAnswer = MergeAndSortArray(array1, array2); // TODO complete the method and test

            //#6 Get the GCD of array
            answer = GeneralizedGcd(9, array1); // Means finding GCD of an array with n values.
            Console.WriteLine("GeneralizedGCD is : " + answer);

            answer = IterativeGcd(12, 9);
            Console.WriteLine("IterativeGcd is : " + answer);

            answer = RecursiveGcd(12, 9);
            Console.WriteLine("RecursiveGCD is : " + answer);

            //#7  Get Nth number in Fibonacci Series
            answer = GetNthNumberInFibonacciSeries(5);
            Console.WriteLine("GetNthNumberInFibonacciSeries is : " + answer);

            //#8 Get the Higher version of given string formatted 
            string version1 = "1.0.0.1";
            string version2 = "1.1.0.1";
            string version3 = "1.1.1.1";
            string version4 = "1.1.1.1";
            answer = GetHigherVersion(version3, version4); // Use any of above to test
            Console.WriteLine("GetHigherVersion is : " + answer);


            int[] primeArray = {104711, 89387, 2467, 691, 97, 7, 3, 2};

            foreach (int primeNumber in primeArray) {
                //bool status1 = IsPrime1(primeNumber);
                //Console.WriteLine("Check if " + primeNumber + " IsPrime1 : " + status1);
                bool status2 = IsPrime2(primeNumber);
                Console.WriteLine("Check if " + primeNumber + " IsPrime2 : " + status2);
                bool status3 = IsPrimeOptimal(primeNumber);
                Console.WriteLine("Check if " + primeNumber + " IsPrimeOptimal : " + status3);
            }

            //6 , 28 , 496
            for (int i = 1; i < 30; i++) {
                bool isPerfectNumber = IsPerfectNumber(i);
                if (isPerfectNumber) {
                    Console.WriteLine("IsPerfectNumber " + i + " : " + isPerfectNumber);
                }

                isPerfectNumber = IsPerfectNumberOptimal(i);
                if (isPerfectNumber) {
                    Console.WriteLine("IsPerfectNumberOptimal " + i + " : " + isPerfectNumber);
                }
            }

            //#endif

            Console.WriteLine("*****************************************");
            Console.WriteLine(
                "Now to test almost matching strings enter two string which are just different by one char at end,front or mid");
            string text1 = Console.ReadLine();
            string text2 = Console.ReadLine();
            Console.WriteLine("String 1 : " + text1);
            Console.WriteLine("String 2 : " + text2);
            bool status = CheckIfTheseTwoWordsAreOneEditAway(text1, text2);
            Console.WriteLine("CheckIfTheseTwoWordsAreOneEditAway  : " + status);

            text1 = Console.ReadLine();
            text2 = Console.ReadLine();
            Console.WriteLine("String 1 : " + text1);
            Console.WriteLine("String 2 : " + text2);
            status = CheckIfTheseTwoWordsAreOneEditAway(text1, text2);
            Console.WriteLine("CheckIfTheseTwoWordsAreOneEditAway  : " + status);

#endif

        }

        private static bool CheckIfTheseTwoWordsAreOneEditAway(string text1, string text2)
        {
            // When invalid input
            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2)) {
                return false;
            }

            // When the strings are diff to each other more than a char its definitely not what we are looking for.
            int diff = text1.Length - text2.Length;
            if (Math.Abs(diff) > 1) {
                return false;
            }
            bool status = false;
            char[] text1Array = text1.ToCharArray();
            char[] text2Array = text2.ToCharArray();

            if (diff == 0) {
                //case 1 where string are of equal length.
                IDictionary<char, char> charIndex = new Dictionary<char, char>();
                for (int i = 0; i < text1.Length; i++) {
                    if (!text1Array[i].Equals(text2Array[i])) {
                        charIndex.Add(text1Array[i], text2Array[i]);
                    }
                }
                if (charIndex.Count == 1) {
                    // When the difference is exactly one then only it matches the case.
                    status = true;
                }
            }
            else {
                // Identify the bigger string
                string biggerString;
                if (diff == 1) {
                    //bigger
                }



                //// Case 1 : where removal of a char is required at end e.g. The & Then
                //IDictionary<char, int> charIndex = new Dictionary<char, int>();
                //for (int i = 0; i < text2.Length; i++) {
                //    if (!text2Array[i].Equals(text1Array[i])) {
                //        charIndex.Add(text1Array[i], i);
                //    }
                //}
                //status = charIndex.Count == 0 | false;
            }

            return status;
        }

        static string ReversedString(string inputString)
        {
            string[] words = inputString.Split(' ');
            Array.Reverse(words);
            return ConvertStringArrayToString(words);
        }

        static int FindTheMajorityElement(int[] arrayValues)
        {
            Dictionary<int, int> tracker = new Dictionary<int, int>();

            for (int i = 0; i < arrayValues.Length; i++) {
                if (!tracker.ContainsKey(arrayValues[i])) {
                    tracker.Add(arrayValues[i], 1); // setting the counter by 1 
                }
                else {
                    int value;
                    tracker.TryGetValue(arrayValues[i], out value);
                    tracker[arrayValues[i]] = value + 1;
                }
            }
            int major = 0;
            int highest = 0;
            foreach (var item in tracker) {
                if (item.Value > highest) {
                    highest = item.Value;
                    major = item.Key;
                }
            }
            return major;
        }

        static int FindDigitalRoot(int num)
        {
            return (1 + (num - 1) % 9);
        }

        static int FindUniqueNumber(int[] array)
        {
            Dictionary<int, int> tracker = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++) {
                if (!tracker.ContainsKey(array[i])) {
                    tracker.Add(array[i], 1);
                }
                else {
                    int value;
                    tracker.TryGetValue(array[i], out value);
                    tracker[array[i]] = value + 1;
                }
            }
            foreach (var item in tracker) {
                if (item.Value == 1) {
                    return item.Key;
                }
            }
            return 0;
        }

        static int[] MergeAndSortArray(int[] array1, int[] array2)
        {
            int count1 = array1.Length;
            int count2 = array2.Length;
            int[] arrayResult = new int[count1 + count2];

            int a = 0, b = 0; // indexes in origin arrays
            int i = 0; // index in result array

            // join
            while (a < count1 && b < count2) {
                if (array1[a] <= array2[b]) {
                    // element in first array at current index 'a'
                    // is less or equals to element in second array at index 'b'
                    arrayResult[i++] = array1[a++];
                }
                else {
                    arrayResult[i++] = array2[b++];
                }
            }

            // tail
            if (a < count1) {
                // fill tail from first array
                for (int j = a; j < count1; j++) {
                    arrayResult[i++] = array1[j];
                }
            }
            else {
                // fill tail from second array
                for (int j = b; j < count2; j++) {
                    arrayResult[i++] = array2[j];
                }
            }
            return arrayResult;
        }

        static int GeneralizedGcd(int num, int[] arr)
        {
            int gcd = 0;
            if (num > 0 && arr != null) {
                gcd = arr[0]; // if there is only one value result will be the same.

                for (int i = 1; i < num; i++) {
                    gcd = IterativeGcd(arr[i], gcd);
                }
            }
            return gcd;
        }

        static int IterativeGcd(int n1, int n2)
        {
            // Check for corner cases like 0 and negative numbers
            while (n2 != 0) {
                int rem = n1 % n2;
                n1 = n2;
                n2 = rem;
            }
            return n1;
        }

        static int RecursiveGcd(int a, int b)
        {
            if (a == 0)
                return b;
            return RecursiveGcd(b % a, a);
        }

        static int GetNthNumberInFibonacciSeries(int n)
        {
            int firstnumber = 0, secondnumber = 1, result = 0;

            if (n == 0)
                return 0; //To return the first Fibonacci number   
            if (n == 1)
                return 1; //To return the second Fibonacci number   

            for (int i = 2; i <= n; i++) {
                result = firstnumber + secondnumber;
                firstnumber = secondnumber;
                secondnumber = result;
            }

            return result;
        }

        static int GetHigherVersion(string v1, string v2)
        {
            string[] ver1 = v1.Split('.');
            string[] ver2 = v2.Split('.');

            int status = 0;

            for (int i = 0; i < ver1.Length; i++) {
                if (Convert.ToInt32(ver1[i]) < Convert.ToInt32(ver2[i])) {
                    status = -1;
                    break;
                }
                if (Convert.ToInt32(ver1[i]) > Convert.ToInt32(ver2[i])) {
                    status = 1;
                    break;
                }
            }
            return status;
        }

        // O(n)
        static bool IsPrime1(int n)
        {
            if (n <= 1) {
                return false;
            }
            for (int i = 2; i < n; i++) {
                if (n % i == 0) {
                    return false;
                }
            }
            return true;
        }

        //O(n)
        static bool IsPrime2(int n)
        {
            if (n <= 1) {
                return false;
            }
            if (n <= 3) {
                return true;
            }
            if (n % 2 == 0 || n % 3 == 0) {
                return false;
            }
            for (int i = 5; i < n; i++) {
                if ((n - 1) % 6 == 0 || (n + 1) % 6 == 0) {
                    return true;
                }
            }
            return false;
        }

        //O(n^1/2)
        static bool IsPrimeOptimal(int n)
        {
            if (n <= 1) {
                return false;
            }
            if (n <= 3) {
                return true;
            }
            if (n % 2 == 0 || n % 3 == 0) {
                return false;
            }
            for (int i = 5; i * i < n; i = i + 6) {
                if (n % i == 0 || n % (i + 2) == 0) {
                    return false;
                }
            }
            return true;
        }

        static bool IsPerfectNumber(int n)
        {
            if (n <= 1) {
                return false;
            }

            int sum = 1;

            for (int i = 2; i < n; i++) {
                if (n % i == 0) {
                    sum = sum + i;
                }
            }

            if (sum == n && n != 1) {
                return true;
            }
            return false;
        }

        static bool IsPerfectNumberOptimal(int n)
        {
            int sum = 1;
            for (int i = 2; i * i < n; i++) {
                if (n % i == 0) {
                    sum = sum + i + n / i;
                }
            }
            if (sum == n && n != 1) {
                return true;
            }
            return false;
        }

#endregion

#region Tools

        static string ConvertStringArrayToString(string[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder();
            foreach (string value in array) {
                builder.Append(value);
                builder.Append(' ');
            }
            return builder.ToString();
        }

#endregion

        public static void SolveAmazonProblemA()
        {
            string word =
                "Jack and Jill went to the market to buy bread and cheese. Cheese is Jack's and Jill's favorite food";
            IList<string> excluded = new List<string> {"and", "he", "the", "to", "is", "Jack", "Jill"};
            IList<string> excludedTemp = new List<string>();
            foreach (var item in excluded) {
                excludedTemp.Add(item.ToLower());
            }

            word = word.ToLower();
            char[] delimiters = {' ', '.', '\'', '\r', '\n'};
            string[] Value = word.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> repeatedWordCount = new Dictionary<string, int>();
            for (int i = 0; i < Value.Length; i++) {
                if (excludedTemp.Contains(Value[i])) {
                    continue;
                }
                if (repeatedWordCount.ContainsKey(Value[i])) {
                    int value = repeatedWordCount[Value[i]];
                    repeatedWordCount[Value[i]] = value + 1;
                }
                else {
                    repeatedWordCount.Add(Value[i], 1);
                }
            }
            int max = 0;
            foreach (var item in repeatedWordCount) {
                if (item.Value > max) {
                    max = item.Value;
                }
            }
            IList<string> answer = new List<string>();
            foreach (var item in repeatedWordCount) {
                if (item.Value == max) {
                    answer.Add(item.Key);
                }
            }

            foreach (var item in answer) {
                Console.WriteLine("Most found : " + item);
            }
        }

#region Matrix

        public static void SolveMatrixProblems()
        {
            TestMatrixAddition();
        }

        static void TestMatrixAddition()
        {
            int[,] matrix1 = new int[3, 3];
        }

#endregion
    }

    public class AdjacentCellStatusProblem
    {
        public int[] CellCompete(int[] states, int days)
        {
            while (days > 0) {
                int currentCellOldValue = -1;
                for (int i = 0; i < states.Length; i++) {
                    int left;
                    int right;
                    if (i == 0) {
                        left = 0;
                    }
                    else if (currentCellOldValue != -1) {
                        left = currentCellOldValue;
                    }
                    else {
                        left = states[i - 1];
                    }
                    if (i == states.Length - 1) {
                        right = 0;
                    }
                    else {
                        right = states[i + 1];
                    }
                    currentCellOldValue = states[i];
                    states[i] = GetCellStatus(left, right);
                }
                --days;
            }
            return states;
        }

        // METHOD SIGNATURE ENDS

        int GetCellStatus(int left, int right)
        {
            if ((left == 1 && right == 1) || (left == 0 && right == 0)) {
                return 0; // Inactive
            }
            return 1; // Else cell should be active.
        }
    }

    class Merge3Arrays
    {
        static void Merge2(int[] arr1, int len1, int[] arr2)
        {
            int i = len1 - 1;
            int j = arr2.Length - 1;
            int k = len1 + arr2.Length - 1;

            while (i >= 0 && j >= 0) {
                if (arr1[i] >= arr2[j]) {
                    arr1[k--] = arr1[i--];
                }
                else {
                    arr1[k--] = arr2[j--];
                }
            }

            while (j >= 0) {
                arr1[k--] = arr2[j--];
            }
        }

        static void Merge3(int[] arr1, int[] arr2, int[] arr3, int[] output)
        {
            arr1.CopyTo(output, 0);
            Merge2(output, arr1.Length, arr2);
            Merge2(output, arr1.Length + arr2.Length, arr3);
        }

        static void PrintArray(int[] arr, string msg)
        {
            Console.WriteLine(msg);
            foreach (var i in arr) {
                Console.Write("{0, 4}", i);
            }
            Console.WriteLine();
        }

        static void DoTest(int[] arr1, int[] arr2, int[] arr3, int[] output)
        {
            PrintArray(arr1, "A");
            PrintArray(arr2, "B");
            PrintArray(arr3, "C");
            Merge3(arr1, arr2, arr3, output);
            PrintArray(output, "D after merging");
        }

        //static void Main(string[] args)
        //{
        //    int[] A = { 2, 4, 6, 8 };
        //    int[] B = { 1, 3, 5, 7 };
        //    int[] C = { 10, 12, 14, 16 };
        //    int[] D = new int[A.Length + B.Length + C.Length];
        //    DoTest(A, B, C, D);
        //}
    }

    class Knapsack
    {
        // A utility function that returns maximum of two integers
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // Returns the maximum value that can be put in a knapsack of capacity W
        static int knapSack(int W, int[] wt, int[] val, int n)
        {
            // Base Case
            if (n == 0 || W == 0)
                return 0;

            // If weight of the nth item is more than Knapsack capacity W, then
            // this item cannot be included in the optimal solution
            if (wt[n - 1] > W)
                return knapSack(W, wt, val, n - 1);

            // Return the maximum of two cases: 
            // (1) nth item included 
            // (2) not included
            return max(val[n - 1] + knapSack(W - wt[n - 1], wt, val, n - 1), knapSack(W, wt, val, n - 1));
        }

        //// Driver program to test above function
        //public static void Test(String args [])
        //{
        //    int val [] =
        //    new int[] {60, 100, 120};
        //    int wt [] =
        //    new int[] {10, 20, 30};
        //    int W = 50;
        //    int n = val.length;
        //    System.out.println(knapSack(W, wt, val, n));
        //}
    }
}