using System.ComponentModel;
using ZorkBuilder.Data;

namespace ZorkBuilder.Data
{
    public class Room : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public string Location { get; set; }
        public string Neighbor { get; set; }
        public string Rooms { get; set; }
    }
}
