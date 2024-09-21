using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chord_Identifier.Chords
{
    struct Chord
    {
        public int Root { get; }
        public List<int> Notes;
        public ChordValue Value;

        public Chord(int root, params int[] notes)
        {
            Root = root;
            Notes = new(notes);
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
        public int Root { get { return Value.Root; } }
        public List<int> Notes { get { return Value.Notes; } }
    }
}
