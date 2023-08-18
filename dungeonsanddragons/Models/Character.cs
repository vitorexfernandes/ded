namespace dungeonsanddragons.Models
{
    public class Character
    {
        private static int _nextId = 1;
        public int Id { get;  private set; }
        public string Name { get; set; }
        public CharacterClass CharacterClass { get; set; }  // Referência à classe CharacterClass

        public Character(string name, CharacterClass characterClass)
        {
            Id = _nextId++;
            Name = name;
            CharacterClass = characterClass;
        }

    }
}
