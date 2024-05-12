using Microsoft.Maps.MapControl.WPF;
using VoronovoStreets.StreetModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Media;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VoronovoStreets.Windows
{
    /// <summary>
    /// Логика взаимодействия для PreviewStreatWindow.xaml
    /// </summary>
    public partial class PreviewStreatWindow : Window
    {
        public ObservableCollection<StreetModel> StreetsList { get; set; } = new ObservableCollection<StreetModel>();
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        private StreetModel _selectedStreet;
        public StreetModel SelectedStreet
        { 
            get { return _selectedStreet; }
            set 
            { 
                _selectedStreet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedStreet)));
            }
        }

        public PreviewStreatWindow()
        {
            InitializeComponent();
            DataContext = this;
            FillStreatList();
            ICollectionView view = CollectionViewSource.GetDefaultView(StreetsList);
            view.Filter = (item) => (item as StreetModel).Name.ToLower().StartsWith(textBoxFilter.Text.ToLower());
        }

        private void FillStreatList() 
        {
            StreetsList.Add(new StreetModel { Name = "агр. Бенякони", Coordinates = new Location(54.250420, 25.356511), Images = GetImageItemsByName("Benyakoni"), Information = GetPathToInfoByName("Benyakoni") });
            StreetsList.Add(new StreetModel { Name = "д. Гайтюнишки", Coordinates = new Location(54.263883, 25.454886), Images = GetImageItemsByName("Gayty"), Information = GetPathToInfoByName("Gayty") });
            StreetsList.Add(new StreetModel { Name = "агр. Больтеники", Coordinates = new Location(54.239912, 25.302188), Images = GetImageItemsByName("Bolteniki"), Information = GetPathToInfoByName("Bolteniki") });
            StreetsList.Add(new StreetModel { Name = "д. Трокели", Coordinates = new Location(54.038253, 25.410358), Images = GetImageItemsByName("Trokeli"), Information = GetPathToInfoByName("Trokeli") });
            StreetsList.Add(new StreetModel { Name = "д. Нача", Coordinates = new Location(54.072042, 24.839191), Images = GetImageItemsByName("Nacha"), Information = GetPathToInfoByName("Nacha") });
            StreetsList.Add(new StreetModel { Name = "г.п. Радунь", Coordinates = new Location(54.052911, 24.997634), Images = GetImageItemsByName("Radun"), Information = GetPathToInfoByName("Radun") });
            StreetsList.Add(new StreetModel { Name = "д. Оссова", Coordinates = new Location(54.078722, 25.216448), Images = GetImageItemsByName("Ossova"), Information = GetPathToInfoByName("Ossova") });
            StreetsList.Add(new StreetModel { Name = "агр. Заболоть", Coordinates = new Location(53.927853, 24.794991), Images = GetImageItemsByName("Zabolot"), Information = GetPathToInfoByName("Zabolot") });
            StreetsList.Add(new StreetModel { Name = "д. Шауры", Coordinates = new Location(55.652074, 27.123189), Images = GetImageItemsByName("Shauri"), Information = GetPathToInfoByName("Shauri") });
            StreetsList.Add(new StreetModel { Name = "г.п. Вороново", Coordinates = new Location(54.149923, 25.316446), Images = GetImageItemsByName("Voronovo"), Information = GetPathToInfoByName("Voronovo") });
            StreetsList.Add(new StreetModel { Name = "ул. Советская", Coordinates = new Location(54.150982, 25.318160), Images = GetImageItemsByName("Sovetskaya"), Information = GetPathToInfoByName("Sovetskaya") });
            StreetsList.Add(new StreetModel { Name = "ул. Октябрьская", Coordinates = new Location(54.152782, 25.318570), Images = GetImageItemsByName("Oktybrskaya"), Information = GetPathToInfoByName("Oktybrskaya") });
            StreetsList.Add(new StreetModel { Name = "ул. Семашко", Coordinates = new Location(54.153343, 25.318876), Images = GetImageItemsByName("Semashko"), Information = GetPathToInfoByName("Semashko") });
            StreetsList.Add(new StreetModel { Name = "ул. Литовчика", Coordinates = new Location(54.151214, 25.314159), Images = GetImageItemsByName("Litovchika"), Information = GetPathToInfoByName("Litovchika") });
            StreetsList.Add(new StreetModel { Name = "ул. Юбилейная", Coordinates = new Location(54.150084, 25.316486), Images = GetImageItemsByName("Ubileynaya"), Information = GetPathToInfoByName("Ubileynaya") });
            StreetsList.Add(new StreetModel { Name = "ул. Канарчика", Coordinates = new Location(54.150392, 25.321403), Images = GetImageItemsByName("Kanarchika"), Information = GetPathToInfoByName("Kanarchika") });
            StreetsList.Add(new StreetModel { Name = "ул. Калинина", Coordinates = new Location(54.151897, 25.321991), Images = GetImageItemsByName("Kalinina"), Information = GetPathToInfoByName("Kalinina") });
            StreetsList.Add(new StreetModel { Name = "ул. 1 Мая", Coordinates = new Location(54.152942, 25.321121), Images = GetImageItemsByName("PervogoMay"), Information = GetPathToInfoByName("PervogoMay") });
            StreetsList.Add(new StreetModel { Name = "пер. Калинина", Coordinates = new Location(54.152009, 25.322483), Images = GetImageItemsByName("perKalinina"), Information = GetPathToInfoByName("perKalinina") });
        }

        private string GetPathToInfoByName(string fileName) 
        {
            return @"InfoAbautStreats/TextInfo/" + fileName + ".rtf";
        }

        private string GetPathToSoundInfoByName(string fileName)
        {
            return @"InfoAbautStreats/SoundInfo/" + fileName + ".wav";
        }

        private ObservableCollection<string> GetImageItemsByName(string name)
        {
            ObservableCollection<string> images = new ObservableCollection<string>();
            string folder = @"InfoAbautStreats/Images/" + name;
            foreach (var pathToPhoto in Directory.GetFiles(folder))
            {
                images.Add(@"/bin/Debug/net8.0-windows/" + pathToPhoto);
            }
            return images;
        }
        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SendStretToPreviewByName(SelectedStreet.Name);
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(StreetsList).Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendStretToPreviewByName((sender as Button).Tag.ToString());
        }

        private void SendStretToPreviewByName(string name) 
        {
            StreetModel foundByName = StreetsList.First(item => item.Name == name);
            new PreviewStreatInformationWindow(foundByName).ShowDialog();
        }
    }
}
