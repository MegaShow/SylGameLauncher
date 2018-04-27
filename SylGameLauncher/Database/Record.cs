using System;

namespace SylGameLauncher.Database {
    public class Record {
        public int GameId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        public Record(int id, DateTime start, DateTime end) {
            GameId = id;
            TimeStart = start;
            TimeEnd = end;
        }
    }
}
