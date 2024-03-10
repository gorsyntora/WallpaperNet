using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static AvaloniaApp.ViewModels.MainViewModel;
using System.Windows.Input;
using AvaloniaApp.Views;

namespace AvaloniaApp.ViewModels
{
    public partial class GeoCalcViewModel : ViewModelBase
    {

       
        private static ObservableCollection<string> _corSysList =  new ObservableCollection<string>(new string[] { "WDS-84", "GOST 1121", "Pulkovo 1942" }.ToList());
               public static ObservableCollection<string> CorSysList { get => _corSysList; set => _corSysList = value; }
        public ObservableCollection<Layer> TransformationList { get; set; } = new();
        public ObservableCollection<MapData> MapsLayers { get; private set; }

 

        public GeoCalcViewModel()
        {
            TransformationList.Add(new Layer("Tranfomation 1"));
            TransformationList.Add(new Layer("Tranformation 2"));
            TransformationList.Add(new Layer("Transformation 3"));
            TransformationList.Add(new Layer("Tranformation 4"));
          

            var _mapsLayers = new List<MapData>
            {
                new MapData("Data 1", CorSysList[0], false),
                new MapData("Data 2", CorSysList[1] , true),
                new MapData("Data 3", CorSysList[2], true)
            };
            MapsLayers = new ObservableCollection<MapData>(_mapsLayers);


        }




        public void BtnAddData()
        {
            //   LayerList.Add(new Layer("Dynamically added layer"));

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
            MapFile =  mapFile;
            BaseCor = baseCor;
            IsChecked = isChecked;
        }
    }

}
