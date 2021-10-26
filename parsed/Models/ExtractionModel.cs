namespace parsed.Models
{
    public class ExtractionModel
    {
        public string ErrorMessage;
        public string ParsedText;
        public int NumberOfPages;
        public int NumberOfWords;

        public ExtractionModel(string errorMessage, string parsedText, int numberOfPages, int numberOfWords)
        {
            ErrorMessage = errorMessage;
            ParsedText = parsedText;
            NumberOfPages = numberOfPages;
            NumberOfWords = numberOfWords;
        }
    }
}