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
            Chord tchord = new(7, 4, 7);
            Console.WriteLine(tchord);
        }
    }
}
