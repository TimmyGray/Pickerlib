using Pickerlib.Models.Classes;
using Pickerlib.Models;
using System.Collections.ObjectModel;

namespace Pickerlib.Contexts
{
    public class ClockContext<T> where T : ITimeItem
    {
            public ObservableCollection<ITimeItem> Houritems;
            public ObservableCollection<ITimeItem> Minitems;
            public ObservableCollection<ITimeItem> Secitems;

            public ClockContext()
            {
                Houritems = new ObservableCollection<ITimeItem>();
                Minitems = new ObservableCollection<ITimeItem>();
                Secitems = new ObservableCollection<ITimeItem>();
                for (int i = 0; i < 60; i++)
                {
                    while (i < 24)
                    {
                        HourItem houritem = new HourItem(i);
                        Houritems.Add(houritem);
                        break;
                    }
                    MinItem minitem = new MinItem(i);
                    SecItem secitem = new SecItem(i);

                    Minitems.Add(minitem);
                    Secitems.Add(secitem);

                }

            }


    }


    
}
