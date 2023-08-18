namespace dungeonsanddragons.Models
{
    public class CharacterSkill
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Value { get; set; } = 0;
        public string Description { get; set; }


        public CharacterSkill(string name, string description, int value)
        {
            Id = _nextId++;
            Name = name;
            Description = description;
            Value = value;
        }
    }
}
