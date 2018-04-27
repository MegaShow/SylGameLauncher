using System;
using System.Collections.Generic;

namespace SylGameLauncher.Database {
    public class User {
        public string Name { get; set; }
        public int PlayGameTimeSum { get; set; }
        public Dictionary<int, int> PlayGameState { get; set; }

        public User() {
            PlayGameState = new Dictionary<int, int>();
        }

        public void Play(int gameId, DateTime start, DateTime end) {
            int time = (int)(end - start).TotalSeconds;
            PlayGameTimeSum += time;
            if (PlayGameState.ContainsKey(gameId)) {
                PlayGameState[gameId] += time;
            } else {
                PlayGameState.Add(gameId, time);
            }
        }
    }
}
