using System.Json;

namespace SylGameLauncher.Database {
  class Model {
    private User user;
    private Game[] game;
    private Record[] record;

    public Model(string _username) {
      user.SetName(_username);
    }
  }
}