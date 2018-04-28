using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SylGameLauncher.Database;

namespace SylGameLauncher {
    public class SylGameLauncher {
        public Model Data { get; set; }

        public SylGameLauncher() {
            Data = new Model();
        }

        public SylGameLauncher(string json) {
            Data = JsonConvert.DeserializeObject<Model>(json);
        }

        public string ToJson() {
            return JsonConvert.SerializeObject(Data);
        }

        public static string Version() {
            return "SylGameLauncher Core version 0.2";
        }

        public Dictionary<int, string> GetGameList() {
            var map = new Dictionary<int, string>();
            foreach (Game item in Data.GameList) {
                map.Add(item.Id, item.NameCN);
            }
            return map;
        }

        public void AddRecord(int gameId, DateTime start, DateTime end) {
            Data.RecordList.Add(new Record(gameId, start.ToUniversalTime(), end.ToUniversalTime()));
            Data.User.Play(gameId, start, end);
        }

        public void AddGame(string name, string nameCN, string developer, string publisher, DateTime publishTime) {
            int id = Data.GameList.Count + 1;
            Data.GameList.Add(new Game(id, name, nameCN, developer, publisher, publishTime));
        }
    }
}
