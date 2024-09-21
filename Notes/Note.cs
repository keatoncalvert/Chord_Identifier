
namespace Chord_Identifier.Notes
{
    class Note(int value = 0, int offset = 0)
    {
        private readonly String[] NoteNames = { "C", "C#\\Db", "D", "D#\\Eb", "E", "F", "F#\\Gb", "G", "G#\\Ab", "A", "A#\\Bb", "B" };
        public int Value { get; set; } = value + offset;
        static public List<Note> IntArrayToNotes(int root, int[] notes)
        {
            List<Note> result = new List<Note>();
            foreach (var note in notes)
            {
                result.Add(new Note(root, note));
            }
            return result;
        }

        public override string ToString()
        {
            return NoteNames[Value % 12];
        }
    }
}