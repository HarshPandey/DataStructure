using System;
using System.Text;
using System.Collections.Generic;

namespace DataStructure
{
    public class DynamicProgramming
    {
        #region ReformatPhoneNumber

        public static void ReformatPhoneNumber(string[] phoneNumbers)
        {
            if (phoneNumbers != null)
            {

                for (int i = 0; i < phoneNumbers.Length; i++)
                {

                    string phoneNumber = phoneNumbers[i];
                    if (phoneNumber.Contains("-"))
                    {
                        phoneNumber = phoneNumber.Replace("-", "");
                    }
                    char[] number = phoneNumber.ToCharArray();
                    char[] updatedNumber = SwapAreaCode(number);

                    phoneNumbers[i] = new string(updatedNumber);
                }
            }
        }

        static char[] SwapAreaCode(char[] number)
        {

            char temp1 = number[0];
            char temp2 = number[1];
            char temp3 = number[2];

            number[0] = number[3];
            number[1] = number[4];
            number[2] = number[5];

            number[3] = temp1;
            number[4] = temp2;
            number[5] = temp3;
            return number;
        }

        #endregion

        public static void TestTowerOfHanoi(int numberofDisc, char fromRod, char toRod, char auxRod)
        {
            if (numberofDisc == 1)
            {
                Console.WriteLine("Move disk 1 from " + fromRod + " to " + toRod);
                return;
            }
            TestTowerOfHanoi(numberofDisc - 1, fromRod, auxRod, toRod);
            Console.WriteLine("Move disk " + numberofDisc + " from " + fromRod + " to " + toRod);
            TestTowerOfHanoi(numberofDisc - 1, auxRod, toRod, fromRod);
        }

        public static void MakeTheNumbersMatch(int a, int b, int x, int y)
        {
            while (a != x || b != y)
            {
                if (a != x && a > x)
                {
                    a--;
                }
                else if (a != x && a < x)
                {
                    a++;
                }
                if (b != y && b > y)
                {
                    b--;
                }
                else if (b != y && b < y)
                {
                    b++;
                }
            }
            Console.WriteLine("Values : A B X Y " + a + b + x + y);
        }

        public static void FindSubstringsWithKDistinctCharacters(String s, int k)
        {
            char[] letters = s.ToCharArray(0, s.Length);
            //IList<string> list = new List<string>();
            for (int i = 0, n = letters.Length - k; i <= n; i++)
            {
                HashSet<char> uniques = new HashSet<char>();

                for (int j = i, m = i + k; j < m; j++)
                {
                    uniques.Add(letters[j]);
                }

                if (uniques.Count == k)
                {
                    Console.WriteLine("substring : " + StringBuilderStrings(uniques));
                }

            }
        }

        static string StringBuilderStrings(IEnumerable<char> charSequence)
        {
            var sb = new StringBuilder();
            foreach (char c in charSequence)
            {
                sb.Append(c.ToString());
            }
            return sb.ToString();
        }

        public static void TestCoinDistribution(){
            
            List<int> coins = new List<int>() { 50, 25, 10, 5, 1 };

            IDictionary<int, int> noOfCoins = FindChange(coins, 64);
            PrintData(noOfCoins);

            noOfCoins = FindChange(coins, 79);
            PrintData(noOfCoins);

            noOfCoins = FindChange(coins, 70);
            PrintData(noOfCoins);

            noOfCoins = FindChange(coins, 100);
            PrintData(noOfCoins);
        }

        static void PrintData(IDictionary<int, int> noOfCoins)
        {
            Console.WriteLine("Coin Distribution : ");
            int total = 0;
            foreach (var item in noOfCoins)
            {
                total = total + (item.Key * item.Value);
                Console.WriteLine(string.Format("Coin {0} * {1} = {2}", item.Key, item.Value, item.Key * item.Value));
            }
            Console.WriteLine("Total : " + total);
            Console.WriteLine(Environment.NewLine);
        }

        public static IDictionary<int, int> FindChange(List<int> coins, int amount)
        {
            IDictionary<int, int> change = new Dictionary<int, int>();
            coins.Sort(); coins.Reverse();

            // For exact matches.
            if (coins.Contains(amount))
            {
                foreach (int coin in coins)
                {
                    if (coin == amount)
                    {
                        change.Add(coin, 1);
                    }
                }
            }
            else
            {
                int money = amount;
                int coinCount = 0;

                for (int i = 0; i < coins.Count; i++)
                {

                    if (money == 0)
                    {
                        break;
                    }
                    int div = money / coins[i];
                    int rem = money % coins[i];

                    if (div == 0)
                    {
                        // means that amount is less than current coin.
                        money = rem;
                        continue;
                    }
                    if (div > 0)
                    {
                        coinCount = div;
                        change.Add(coins[i], coinCount);
                        money = rem;
                    }
                }

            }
            return change;
        }
    }
}
