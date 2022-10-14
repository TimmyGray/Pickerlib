

namespace Pickerlib.Models.Classes
{
    internal class SecItem:ITimeItem
    {
        public int Clockvalue { get; private set; }

        public SecItem(int clockvalue)
        {
            Clockvalue = clockvalue;
        }
    }
}
