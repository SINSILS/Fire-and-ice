namespace Client._Classes
{
    public class Part
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Part(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
