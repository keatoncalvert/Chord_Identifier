using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chord_Identifier.Notes;

namespace Chord_Identifier.Chords
{
    internal class ChordValue(int root, params int[] notes)
    {
        public Note Root { get; } = new(root);
        public List<Note> Notes = Note.IntArrayToNotes(root, notes);

        public override string ToString()
        {
            return $"{Root}, {String.Join(", ", Notes)}";
        }
    }

    internal class ChordStringInterpreter
    {
        private readonly ChordValue Chord;
        public ChordStringInterpreter(ChordValue chord) { Chord = chord; }
    }

    class Chord : ChordValue
    {
        private ChordStringInterpreter CSI;

        public Chord(int root, params int[] notes) : base(root, notes)
        {
            CSI = new(this);
        }
    }

}
