using ZorkBuilder.Data;
using System.ComponentModel;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Zork.Builder.WinForms.ViewModels
{
    public class WorldViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Filename { get; set; }
        public BindingList<Player> Players { get; set; }
        public BindingList<Item> Items { get; set; }
        public BindingList<Room> Rooms { get; set; }
        public World World
        {
            set
            {
                if (mWorld != value)
                {
                    mWorld = value;
                    if(mWorld != null)
                    {
                        Players = new BindingList<Player>(mWorld.Player);
                        Items = new BindingList<Item>(mWorld.Items);
                        Rooms = new BindingList<Room>(mWorld.Rooms);
                    }
                    else
                    {
                        Players = new BindingList<Player>(Array.Empty<Player>());
                        Items = new BindingList<Item>(Array.Empty<Item>());
                        Rooms = new BindingList<Room>(Array.Empty<Room>());
                    }
                }
            }
        }

        public WorldViewModel(World world = null)
        {
            World = world;
        }
        public void SaveWorld()
        {
            if (string.IsNullOrEmpty(Filename))
            {
                throw new InvalidProgramException("Filename expected.");
            }

            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            using (StreamWriter streamWriter = new StreamWriter(Filename))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, mWorld);
            }
        }

        public WorldViewModel()
        {
        }

        private World mWorld;
    }
}
