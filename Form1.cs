using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyCppCompiler
{
    public partial class Form1 : Form
    {
        LexicalAnalyzer LA;
        public Form1()
        {
            InitializeComponent();
        }


        private void ParseButton_Click(object sender, EventArgs e)
        {
           
            DummyCppParser Parser = new DummyCppParser(LA);
            if (Parser.ERROR.Length != 0)
            {
                MessageBox.Show(Parser.ERROR);
            }
            Parser.Parse();
            for (int i = 0; i != Parser.ParserFinalOutput.Count(); i++ )
                ParserOutput.Items.Add(Parser.ParserFinalOutput[i]);
        }

        private void LexerButton_Click_1(object sender, EventArgs e)
        {
            string input = InputScreen.Text;
            string RealInput = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\r' || input[i] == '\n' || input[i]==' ')
                    continue;
                RealInput += input[i];

            }
             LA = new LexicalAnalyzer(RealInput);
            while (!LA.IsFinished())
            {
                try
                {
                    LA.NextToken();
                }
                catch (LexerException LE)
                {
                    MessageBox.Show(LE.message);
                }
            }
            List<Token> temp = LA.TokensList;
              LexerOutput.Items.Clear();
            foreach (Token s in temp)
            {
                string Temper;
                Temper = s.Lexeme.ToString() + ">>" + s.Type.ToString();
               LexerOutput.Items.Add(Temper);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            InputScreen.Clear();
            LexerOutput.Items.Clear();
            ParserOutput.Items.Clear();
        }
    }
}
