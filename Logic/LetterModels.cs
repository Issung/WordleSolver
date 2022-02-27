namespace WordleSolver.Logic
{
    public record LetterModels(ILetter[] Letters);

    public interface ILetter
    {
        char Letter { get; }
    }

    /// <summary>
    /// A grey letter.
    /// </summary>
    /// <param name="Letter"></param>
    public record AbsentLetter(char Letter) : ILetter;

    /// <summary>
    /// A yellow letter.
    /// We know the answer has this letter in it, and we also know it is NOT in <paramref name="Position"/>.
    /// </summary>
    public record KnownMissLetter(char Letter, int Position) : ILetter;

    /// <summary>
    /// A green letter.
    /// </summary>
    /// <param name="Position">Letter's position in the word, starting from 0 index (0 - 4).</param>
    public record KnownPositionLetter(char Letter, int Position) : ILetter;
}
