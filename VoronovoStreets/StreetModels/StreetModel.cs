using Microsoft.Maps.MapControl.WPF;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Media;
using System.IO;
using System.Windows.Media;

namespace VoronovoStreets.StreetModels
{
    public class StreetModel
    {
        public string Name { get; set; }
        public Location Coordinates { get; set; }
        public string Information { get; set; }
        public ObservableCollection<string> Images { get; set; }

    }
}
