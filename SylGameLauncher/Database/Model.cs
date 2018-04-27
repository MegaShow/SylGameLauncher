using System.Collections.Generic;

namespace SylGameLauncher.Database {
    public class Model {
        public User User { get; set; }
        public List<Game> GameList { get; set; }
        public List<Record> RecordList { get; set; }

        public Model() {
            User = new User();
            GameList = new List<Game>();
            RecordList = new List<Record>();
        }
    }
}