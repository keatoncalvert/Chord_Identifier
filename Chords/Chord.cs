using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chord_Identifier.Notes;

namespace Chord_Identifier.Chords
{
    internal class ChordValue
    {
        public Note Root { get; set; }
        public List<Note> Notes {  get; set; }
        
        private ChordValue(int root)
        {
            Root = new(root);
            Notes = new();
        }

        public ChordValue(int root, params int[] notes) : this(root)
        {
            Notes = Note.IntArrayToNotes(root, notes);
        }

        public bool AddNote(Note note)
        {
            bool available = !Notes.Contains(note);
            if (available)
            {
                Notes.Add(note);
            }
            return available;
        }
        public bool AddNote(int noteValue)
        {
            return AddNote(new Note(noteValue));
        }

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

        public Chord(Note root, List<Note> notes) : this(root.Value)
        {
            Notes = notes;
        }
        public Chord(Chord chord) : this(chord.Root, chord.Notes) { }
    }

    class ChordBuilder(int root) : ChordValue(root)
    {
        public ChordBuilder AddThird(Third third)
        {
            AddNote((int)third);
            return this;
        }
        public ChordBuilder AddFifth(Fifth fifth)
        {
            AddNote((int)fifth);
            return this;
        }
        public Chord Build()
        {
            Chord chord = new(Root, Notes);
            return chord;
        }
    }

    class ChordFactory
    {
    }
}
