using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDay1
{
    public class Textbox
    {
        private string text;

        public string Text
        {
            get { return text; }
            set {
                if (value != text && changeText!= null)
                {
                    changeText(text,value);
                }
                text = value; }
        }

        public delegate void handle(string Oldtext, string Newtext);
        public event handle changeText;
    }
}
