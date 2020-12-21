using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public class WeatherResponse
    {
        public TempInfo Main{ get; set; }
        public string Name { get; set; }
        public WindInfo Wind { get; set; }
        public List<Item> Weather { get; set; }
        
    }
}
