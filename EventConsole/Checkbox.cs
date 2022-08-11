using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDay1
{
     public class Checkbox
    {
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private bool _checked;

        public bool Checked
        {
            get { return _checked; }
            set {
                if (value != _checked && checkChange!=null)
                {
                    checkChange(text, value);
                }
                _checked = value; }
        }

        public delegate void handle(string text, bool check);
        public event handle checkChange;
        


    }
}
