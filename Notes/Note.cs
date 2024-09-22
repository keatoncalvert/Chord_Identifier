
namespace Chord_Identifier.Notes
{
    class Note(int value = 0, int offset = 0)
    {
        private readonly string[] NoteNames = { "C", "C#\\Db", "D", "D#\\Eb", "E", "F", "F#\\Gb", "G", "G#\\Ab", "A", "A#\\Bb", "B" };
        public int Value = value + offset;
        static public List<Note> IntArrayToNotes(int root, int[] notes)
        {
            List<Note> result = new List<Note>();
            foreach (var note in notes)
            {
                result.Add(new Note(root, note));
            }
            return result;
        }

        static public int NoteIndexFromValue(int value)
        {
            int string_val = value;
            while (string_val < 0)
            {
                string_val += 12;
            }
            string_val %= 12;
            return string_val;
        }

        public override string ToString()
        {
            int note_index = NoteIndexFromValue(Value);
            return NoteNames[note_index];
        }
    }

    public enum Third
    {
        Major = 4,
        Minor = 3,
    }

    public enum Fifth
    {
        Perfect = 7,
        Diminished = 6,
        Augmented = 8,
    }
}