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
            if (available) { Notes.Add(note); }
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

        public Chord(int root, params int[] notes) : base(root, notes) { CSI = new(this); }

        public Chord(Note root, List<Note> notes) : this(root.Value) {  Notes = notes; }

        public Chord(Chord chord) : this(chord.Root, chord.Notes) { }
    }

    class ChordBuilder(int root) : ChordValue(root)
    {
        public ChordBuilder AddMajorThird() { AddNote(4); return this; }
        public ChordBuilder AddMinorThird() { AddNote(3); return this; }
        public ChordBuilder AddAugThird() { AddNote(5); return this; }
        public ChordBuilder AddDimThird() { AddNote(2); return this; }
        public ChordBuilder AddSus4() { AddNote(5); return this; }
        public ChordBuilder AddSus2() { AddNote(2); return this; }
        public ChordBuilder AddPerfectFifth() { AddNote(7); return this; }
        public ChordBuilder AddTritone() { AddNote(6); return this; }
        public ChordBuilder AddAugmentedFifth() { AddNote(8); return this; }
        public Chord Build()
        {
            Chord chord = new(Root, Notes);
            return chord;
        }
    }

    abstract class ChordFactory(int root)
    {
        public Chord Chord { get { return MakeChord(); } }

        protected ChordBuilder Cb { get; set; } = new(root);

        public abstract Chord MakeChord();
    }

    class MajorTriad(int root) : ChordFactory(root)
    {
        public override Chord MakeChord()
        {
            Cb.AddMajorThird();
            Cb.AddPerfectFifth();
            return Cb.Build();
        }
    }

    class MinorTriad(int root) : ChordFactory(root)
    {
        public override Chord MakeChord()
        {
            Cb.AddMinorThird();
            Cb.AddPerfectFifth();
            return Cb.Build();
        }
    }
}
