using System;

namespace AoC2015
{
    public class Day11 : IDay
    {
        private readonly string _start;

        public Day11(string start)
        {
            _start = start;
        }

        public Day11() : this("vzbxkghb")
        {
        }

        public void Do()
        {
            var pw1 = NextValidPassword(_start);
            Console.WriteLine($"Next valid password: {pw1}");
            var pw2 = NextValidPassword(pw1);
            Console.WriteLine($"Next valid password: {pw2}");
        }

        public string NextValidPassword(string password)
        {
            var len = password.Length;
            var curr = password.ToCharArray();

            InitialValidPassword(curr);
            while (true)
            {
                IncPassword(curr, len - 1);
                if (IsPasswordValid(curr))
                    return new string(curr);
            }
        }

        // Optimization.  This skips past all initial combinations with a bad letter
        private void InitialValidPassword(char[] password)
        {
            for (int i=0; i<password.Length-1; i++)
            {
                if (IsBadLetter(password[i]))
                {
                    password[i]++;
                    for (var j = i + 1; j < password.Length - 1; j++)
                        password[j] = 'a';
                    return;
                }
            }
        }

        private void IncPassword(char[] password, int index)
        {
            if (password[index] == 'z')
            {
                password[index] = 'a';
                IncPassword(password, index - 1);
            }
            else
            {
                password[index]++;
                // Check for bad letters.  Can skip all cases with a bad letter
                if (IsBadLetter(password[index]))
                {
                    password[index]++;
                    for (var i = index + 1; i < password.Length - 1; i++)
                        password[i] = 'a';
                }
            }
        }

        private bool IsPasswordValid(char[] word)
            => HasStraight(word) && !HasBadLetters(word) && HasTwoPairs(word);

        private bool HasStraight(char[] word)
        {
            for (int i = 0; i < word.Length - 2; i++)
                if (word[i] == word[i + 1] - 1 &&
                    word[i + 1] == word[i + 2] - 1)
                    return true;
            return false;
        }

        private bool HasBadLetters(char[] word)
        {
            foreach (var letter in word)
                if (IsBadLetter(letter))
                    return true;
            return false;
        }

        private bool IsBadLetter(char x)
            => x == 'i' || x == 'o' || x == 'l';

        private bool HasTwoPairs(char[] word)
        {
            for (int i = 0; i < word.Length - 1; i++)
                if (word[i] == word[i + 1])
                {
                    for (int j = i + 2; j < word.Length - 1; j++)
                        if (word[j] == word[j + 1] && word[j] != word[i])
                            return true;
                }
            return false;
        }
    }
}
