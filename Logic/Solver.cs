namespace WordleSolver.Logic
{
    public static class Solver
    {
        private static IReadOnlyList<string> words = File.ReadAllLines("5letterwords.txt");

        public static string[] Discern(IEnumerable<ILetter> knownLetters)
        {
            return words.Where(word => WordFits(word, knownLetters)).ToArray();
        }

        public static bool WordFits(string word, IEnumerable<ILetter> knownLetters)
        {
            foreach (var letter in knownLetters)
            {
                if (letter is KnownMissLetter unknownPositionLetter)
                {
                    if (!word.Contains(unknownPositionLetter.Letter))
                    {
                        return false;
                    }

                    if (word[unknownPositionLetter.Position] == unknownPositionLetter.Letter)
                    {
                        return false;
                    }
                }
                else if (letter is KnownPositionLetter knownPositionLetter)
                {
                    if (word[knownPositionLetter.Position] != knownPositionLetter.Letter)
                    {
                        return false;
                    }
                }
                else if (letter is AbsentLetter absentLetter)
                {
                    if (word.Contains(absentLetter.Letter))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
