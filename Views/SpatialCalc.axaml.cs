using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AvaloniaApp.Views
{
    public partial class SpatialCalc : Window
    {

        private static ObservableCollection<string> _corSysList = new(new string[] { "WDS-84", "GOST 1121", "Pulkovo 1942" }.ToList());

        public static ObservableCollection<string> CorSysList { get => _corSysList; set => _corSysList = value; }

        public ObservableCollection<MapData> MapsLayers { get; private set; }



        public SpatialCalc()
        {
            InitializeComponent();


            var _tempData = new List<MapData>
            {
                new MapData("Data 1", CorSysList[0], false),
                new MapData("Data 2", CorSysList[1] , true),
                new MapData("Data 3", CorSysList[2], true)
            };
            MapsLayers = new ObservableCollection<MapData>(_tempData);
            DataContext = this;

        }



        public void BtnAddData()
        {

            MapsLayers.Add(new MapData($"Data {MapsLayers.Count}", CorSysList[2], true));

            Console.WriteLine("Data added clicked");

        }

        public void BtnAddLayer() { }

        public void BtnRemoveData() { }

    }

    public class MapData
    {
        public string MapFile { get; set; }
        public string BaseCor { get; set; }
        public bool IsChecked { get; set; }

        public MapData(string mapFile, string baseCor, bool isChecked)
        {
            MapFile = mapFile;
            BaseCor = baseCor;
            IsChecked = isChecked;
        }
    }
}
