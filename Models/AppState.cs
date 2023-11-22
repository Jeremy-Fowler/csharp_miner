namespace moon_miner.Models;
class AppState
{
  public bool IsRunning { get; set; } = true;
  public int Cheese { get; set; } = 0;
  public List<Upgrade> Upgrades { get; } = new List<Upgrade>()
  {
    new Upgrade("Pickaxe", 1, 50, "click"),
    new Upgrade("Drill", 3, 100, "click"),
    new Upgrade("Rover", 1, 150, "Auto"),
    new Upgrade("Mousetronaut", 10, 500, "Auto")
  };
}
