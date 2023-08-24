namespace dungeonsanddragons.Models
{
    public class CharacterClass
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public List<CharacterSkill> Skills { get; set; } = new List<CharacterSkill>();


        public CharacterClass(string name)
        {
            Id = _nextId++;
            Name = name;
        }
    }
}
