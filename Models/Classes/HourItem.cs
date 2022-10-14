

namespace Pickerlib.Models.Classes
{
    internal class HourItem : ITimeItem
    {
        public int Clockvalue { get; private set; }

        public HourItem(int clockvalue)
        {
            Clockvalue = clockvalue;
        }
    }
}
