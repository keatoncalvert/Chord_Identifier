using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chord_Identifier.Notes;

namespace Chord_Identifier.Chords
{
    struct Chord
    {
        public Note Root { get; }
        public List<Note> Notes;
        public ChordValue Value;

        public Chord(int root, params int[] notes)
        {
            Root = new(root);
            Notes = Note.IntArrayToNotes(root, notes);
            Value = new(this);
        }

        public override string ToString()
        {
            return $"{Root}, {String.Join(", ", Notes)}";
        }
    }

    class ChordValue(Chord chord)
    {
        private Chord Value { get; } = chord;
        public Note Root { get { return Value.Root; } }
        public List<Note> Notes { get { return Value.Notes; } }
    }
}
