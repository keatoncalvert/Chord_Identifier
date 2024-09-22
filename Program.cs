using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chord_Identifier.Chords;
using Chord_Identifier.Notes;

namespace Chord_Identifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Chord tchord = new(0, 4, 5, 7, 11);
            Console.WriteLine(tchord);

            ChordBuilder cb = new(-12);
            cb.AddMajorThird();
            cb.AddPerfectFifth();
            Chord bchord = new(cb.Build());
            Console.WriteLine(bchord);

            MajorTritone mt = new(0);
            Chord fchord = mt.MakeChord();
            Console.WriteLine(fchord);
        }
    }
}
