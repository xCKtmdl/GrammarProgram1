using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Collections.Specialized;

using Aaron.net.PSGClass;
using Aaron.net.SpecialObjects;

namespace GrammarProgram1
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] myArr = new String[] { "NounPhrase","TransitiveVerbPhrase",
                "TransitiveVerb","IntransitiveVerb",
            "IntransitiveVerbPhrase","ARTICLE","ADJECTIVE",
            "NOUN","VERB","ADVERB",
            "the","sleepy","happy","tortoise",
            "hare","passes","quickly","runs","slowly",
            "SENTENCE"};

            StringCollection Vocabulary = new StringCollection();
            Vocabulary.AddRange(myArr);

            myArr = new String[] { "the","sleepy","happy","tortoise",
            "hare","passes","quickly","runs","slowly"};
            StringCollection TerminalSymbols = new StringCollection();
            TerminalSymbols.AddRange(myArr);

            KeyValueList<string, string> Productions = new KeyValueList<string, string>
            {
                {"SENTENCE","NounPhrase TransitiveVerbPhrase NounPhrase"},
                {"ADJECTIVE","sleepy"},{"ADJECTIVE","happy"},
                {"NOUN","tortoise"},{"NOUN","hare"},
                {"TransitiveVerb","passes"},
                {"IntransitiveVerb","runs"},
                {"ADVERB","quickly"},
                {"ADVERB","slowly"},
            {"SENTENCE","NounPhrase IntransitiveVerbPhrase"},
            {"NounPhrase","ARTICLE ADJECTIVE NOUN"},
            {"NounPhrase","ARTICLE NOUN"},
            {"TransitiveVerbPhrase","TransitiveVerb"},
            {"IntransitiveVerbPhrase","IntransitiveVerb ADVERB"},
            {"IntransitiveVerbPhrase","IntransitiveVerb"},
            {"ARTICLE","the"}
            };


            Grammar grammar = new Grammar(Vocabulary, TerminalSymbols, "S", Productions);

       //     StringCollection getVocabulary = grammar.getVocabulary();
       //     StringCollection getTerminalSymbols = grammar.getTerminalSymbols();
            

/*
            string s = grammar.getCurrentString();
            grammar.applyProduction(0);
            s = grammar.getCurrentString();
 */

            grammar.setCurrentString("the hare runs the sleepy tortoise");
            string strProductionHistory= "";
            while (true)
            {
                Console.WriteLine("Current String Is: ");
                Console.WriteLine(grammar.getCurrentString());
                grammar.printProductions();
                Console.WriteLine("productions: " + strProductionHistory);
                Console.WriteLine("reverse production: ");
                string commandLine = Console.ReadLine();
                strProductionHistory = strProductionHistory + " " + commandLine;
                int i = Convert.ToInt32(commandLine);
                grammar.reverseProduction(i);
            }

        }
    }
}
