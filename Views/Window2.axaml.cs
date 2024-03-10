using Avalonia.Controls;
using AvaloniaApp.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AvaloniaApp.Views
{
    public partial class Window2 : Window
    {
        public ObservableCollection<MapData> MapsLayers { get; private set; }

        private static ObservableCollection<string> _corSysList = new ObservableCollection<string>(new string[] { "WDS-84", "GOST 1121", "Pulkovo 1942" }.ToList());
        public static ObservableCollection<string> CorSysList { get => _corSysList; set => _corSysList = value; }

        public Window2()
        {
            InitializeComponent();

           

            var _mapsLayers = new List<MapData>
            {
                new MapData("Data 1", CorSysList[0], false),
                new MapData("Data 2", CorSysList[1] , true),
                new MapData("Data 3", CorSysList[2], true)
            };
            MapsLayers = new ObservableCollection<MapData>(_mapsLayers);
 DataContext = this;

        }
    }
}
