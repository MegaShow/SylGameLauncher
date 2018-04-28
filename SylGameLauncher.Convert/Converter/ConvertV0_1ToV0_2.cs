using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using SylGameLauncher.Database;

namespace SylGameLauncher.Convert.Converter {
    public class ConvertV0_1ToV0_2 {
        private Database.v0._1.Model oldModel;
        private SylGameLauncher lanucher;

        public ConvertV0_1ToV0_2(string gamePath, string playPath) {
            oldModel = new Database.v0._1.Model();
            using (var sr = new StreamReader(gamePath)) {
                string json = sr.ReadToEnd();
                oldModel.GameList = JsonConvert.DeserializeObject<List<Database.v0._1.Game>>(json);
            }
            using (var sr = new StreamReader(playPath)) {
                string json = sr.ReadToEnd();
                oldModel.RecordList = JsonConvert.DeserializeObject<List<Database.v0._1.Record>>(json);
            }
        }

        public void StartConvert(string username) {
            lanucher = new SylGameLauncher();
            lanucher.Data.User.Name = username;
            foreach (Database.v0._1.Game item in oldModel.GameList) {
                lanucher.Data.GameList.Add(new Game(item.id, item.name, item.name, String.Empty, String.Empty, DateTime.Now));
            }
            foreach (Database.v0._1.Record item in oldModel.RecordList) {
                lanucher.AddRecord(item.gameId, item.startDate, item.endDate);
            }
        }

        public void EndConvert(string savePath) {
            using (var sw = new StreamWriter(savePath)) {
                string json = JsonConvert.SerializeObject(lanucher.Data);
                sw.Write(json);
            }
        }
    }
}
