namespace Quiz.Models
{
    public class Answer
    {
        public string Name { get; private set; }
        public bool IsValid { get; private set; }

        public Answer(string name, bool isValid)
        {
            Name = name;
            IsValid = isValid;
        }
    }
}