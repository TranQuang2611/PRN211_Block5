using System;

namespace EventConsole
{
    public class Button
    {
        public Button()
        {
        }

        //tao event cho button

        public delegate void handle();
        public event handle ButtonClick;

        internal void Click()
        {
            //kich hoat su kien click
            if(ButtonClick != null)
            {
                ButtonClick();
            }
        }
    }
}