using moon_miner.Models;

namespace csharp_miner.Models;

public class Game
{
  public Game()
  {
    StartGame();
  }
  private readonly AppState _appState = new AppState();
  private void StartGame()
  {
    do
    {
      DrawMoon();
    }
    while (_appState.IsRunning);
  }

  private void DrawMoon()
  {
    Console.Clear();
    Console.WriteLine("MOON MINER");
    Console.WriteLine($"Cheese: {_appState.Cheese}");
    Console.WriteLine("[SPACEBAR] Mine");
    Console.WriteLine("[S] Shop");
    Console.WriteLine("[ESC] Quit");
    ConsoleKeyInfo userInput = GetUserInput();
    switch (userInput.Key)
    {
      case ConsoleKey.Spacebar:
        _appState.Cheese += GetUpgradeTotalByType("click");
        break;
      case ConsoleKey.S:
        DrawShop();
        break;
      case ConsoleKey.Escape:
        _appState.IsRunning = false;
        break;
    }

  }

  private void DrawShop()
  {
    Console.Clear();
    Console.WriteLine("SHOP");
    Console.WriteLine("");
    List<Upgrade> affordableUpgrades = _appState.Upgrades.FindAll(upgrade => upgrade.Price <= _appState.Cheese);
    for (int i = 0; i < affordableUpgrades.Count; i++)
    {
      Upgrade upgrade = affordableUpgrades[i];
      Console.WriteLine(upgrade.Name.ToUpper());
      Console.WriteLine($"Type: {upgrade.Type} Price: {upgrade.Price} Multiplier: {upgrade.Multiplier}");
      Console.WriteLine($"[{i}] Buy {upgrade.Name}");
      Console.WriteLine("");
    }
    Console.WriteLine("[ESC] Exit Shop");
    ConsoleKeyInfo userInput = GetUserInput();

    if (userInput.Key == ConsoleKey.Escape)
    {
      DrawMoon();
    }


  }

  private ConsoleKeyInfo GetUserInput()
  {
    ConsoleKeyInfo userInput = Console.ReadKey();
    return userInput;
  }

  private int GetUpgradeTotalByType(string type)
  {
    List<Upgrade> upgrades = _appState.Upgrades.FindAll(upgrade => upgrade.Type == type);
    int total = 0;
    upgrades.ForEach(upgrade => total += upgrade.QuantityTimesMultiplier);
    return type == "click" ? total + 1 : total;
  }


}
