using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ZorkBuilder.Data
{
    public class World : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Player> Player { get; set; }
        public List<Item> Items { get; set; }
        public List<Room> Rooms { get; set; }
        public World()
        {
            Player = new List<Player>();
            Items = new List<Item>();
            Rooms = new List<Room>();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            foreach(Player player in Player)
            {
                player.BuildInventoryFromName(Items); 
            }
        }
    }
}
