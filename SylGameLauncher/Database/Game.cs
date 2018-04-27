using System;

namespace SylGameLauncher.Database {
    public class Game {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameCN { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishTime { get; set; }

        public Game(int id, string name, string nameCN, string developer, string publisher, DateTime publishTime) {
            Id = id;
            Name = name;
            NameCN = nameCN;
            Developer = developer;
            Publisher = publisher;
            PublishTime = publishTime;
        }
    }
}
