using System.Windows;
using System.Windows.Documents;

namespace VoronovoStreets.Windows
{
    /// <summary>
    /// Логика взаимодействия для VoronovoHistoryWindow.xaml
    /// </summary>
    public partial class VoronovoHistoryWindow : Window
    {
        public VoronovoHistoryWindow()
        {
            InitializeComponent();
            LoadDockx("InfoAbautStreats/VoronovoHistory/VoronovoHistory.rtf");
        }

        private void LoadDockx(string path)
        {
            if (System.IO.File.Exists(path))
            {
                TextRange range;
                System.IO.FileStream fStream;
                range = new TextRange(RichTextBoxForInfo.Document.ContentStart, RichTextBoxForInfo.Document.ContentEnd);
                fStream = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.Rtf);
                fStream.Close();
            }
        }
        private void RickTextBoxForInfo_TextChanged()
        {

        }
    }
}
