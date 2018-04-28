using System;
using System.Collections.Generic;
using System.Text;

namespace SylGameLauncher.Convert.Database.v0._1 {
    public class Record {
        public int id { get; set; }
        public int gameId { get; set; }
        public string gameName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int time { get; set; }
    }
}
