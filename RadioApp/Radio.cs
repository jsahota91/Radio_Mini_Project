using System;


namespace RadioApp
{
    public class Radio
    {
        //fields
        private int _channel = 1;
        private bool _on;

        //property
        public int Channel
        {
            get { return _channel; }
            set
            {
                if (_on == true & value > 0 & value < 5)
                { _channel = value; }          
            }
        }

        public bool On
        {
            get { return _on; }
        }
        //constructor
        public Radio() { }

        //methods
        public string Play()
        {
            
            if (_on == true) { return $"Playing channel {Channel}"; }
            else { return $"Radio is off"; }
        }

        public void TurnOn()
        {
            _on = true;
            _channel = 1;
             
        }

        public void TurnOff()
        {
            _on = false;
            
        }
    }
    // implement a class Radio that corresponds to the Class diagram 
    //   and specification in the Radio_Mini_Project document
}