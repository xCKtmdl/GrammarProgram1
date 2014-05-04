using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Collections.Specialized;
using Aaron.net.SpecialObjects;

namespace Aaron.net.PSGClass
{
    public class Grammar
    {
        private StringCollection Vocabulary = new StringCollection();
        private StringCollection TerminalSymbols = new StringCollection();
        private string StartSymbol = "";
        private KeyValueList<string, string> Productions = new KeyValueList<string, string>();
        private string CurrentString = "";

        public Grammar(StringCollection Vocabulary, StringCollection TerminalSymbols,
            String StartSymbol, KeyValueList<string, string> Productions)
        {
            this.Vocabulary = Vocabulary;
            this.TerminalSymbols = TerminalSymbols;
            this.StartSymbol = StartSymbol;
            this.Productions = Productions;
        }

        public void applyProduction(int i)
        {
            KeyValuePair<string, string> keyValuePair = Productions.ElementAt(i);
            string strCurrent= getCurrentString();
            
            int j =strCurrent.IndexOf(keyValuePair.Key);
            
            if (j != -1)
            {
               string strBeg = strCurrent.Substring(0, j);
               string strMiddle= keyValuePair.Value;
               int numChar = strCurrent.Length - strBeg.Length - keyValuePair.Key.Length;
               setCurrentString(strBeg + strMiddle + strCurrent.Substring(j + keyValuePair.Key.Length, numChar));
            }
            else
            {
            }
            
        }

        public void reverseProduction(int i)
        {
            KeyValuePair<string, string> keyValuePair = Productions.ElementAt(i);
            string strCurrent = getCurrentString();

            int j = strCurrent.IndexOf(keyValuePair.Value);

            if (j != -1)
            {
                string strBeg = strCurrent.Substring(0, j);
                string strMiddle = keyValuePair.Key;
                int numChar = strCurrent.Length - strBeg.Length - keyValuePair.Value.Length;
                setCurrentString(strBeg + strMiddle + strCurrent.Substring(j + keyValuePair.Value.Length, numChar));
            }
            else
            {
            }

        }

        public void setCurrentString(string CurrentString)
        {
            this.CurrentString = CurrentString;
        }
        public string getCurrentString()
        {
            return CurrentString;
        }

        public String getStartSymbol()
        {
            return StartSymbol;
        }

        public KeyValueList<string, string> getProductions()
        {
            return Productions;
        }

        public void printProductions()
        {
            System.Console.WriteLine("The current productions are: ");
            int i=0;
           foreach (KeyValuePair<string,string> keyValuePair in Productions)
           {
               System.Console.WriteLine(i.ToString() + ": " + keyValuePair.ToString());
                   i=i+1;
           }
        }

        public StringCollection getVocabulary()
        {
            return Vocabulary;
        }

        public StringCollection getTerminalSymbols()
        {
            return TerminalSymbols;
        }
    }
}
