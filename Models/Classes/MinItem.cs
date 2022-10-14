
namespace Pickerlib.Models.Classes
{
    internal class MinItem:ITimeItem
    {
        public int Clockvalue { get; private set; }

        public MinItem(int clockvalue)
        {
            Clockvalue = clockvalue;
        }
    }
}
