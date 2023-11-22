namespace moon_miner.Models;


public class Upgrade
{
  public string Name { get; }
  public int Quantity { get; set; } = 0;
  public int Multiplier { get; }
  public int Price { get; set; }
  public string Type { get; }
  public int QuantityTimesMultiplier => Multiplier * Quantity;

  public Upgrade(string name, int multiplier, int price, string type)
  {
    Name = name;
    Multiplier = multiplier;
    Price = price;
    Type = type;
  }
}