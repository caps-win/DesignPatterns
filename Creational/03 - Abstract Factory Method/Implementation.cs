using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractFactory
{
  /// <summary>
  /// AbstractFactory
  /// </summary>
  public interface IShoppingCartPurchaseFactory
  {
    IDiscountService CreateDiscountService();
    IShippingCostService CreateShippingCostsService();
  }

  /// <summary>
  /// AbstractProduct
  /// </summary>
  public interface IDiscountService
  {
    int DiscountPercentage { get; }
  }

  /// <summary>
  /// AbstractProduct
  /// </summary>
  public interface IShippingCostService
  {
    decimal ShippingCost { get; }
  }

  /// <summary>
  /// ConcreteProduct
  /// </summary>
  public class BelgiumDiscountService : IDiscountService
  {
    public int DiscountPercentage => 20;
  }

  /// <summary>
  /// ConcreteProduct
  /// </summary>
  public class FranceDiscountService : IDiscountService
  {
    public int DiscountPercentage => 10;
  }

  /// <summary>
  /// ConcreteProduct
  /// </summary>
  public class BelgiumShippingCostService : IShippingCostService
  {
    public decimal ShippingCost => 20;
  }

  public class FranceShippingCostsService : IShippingCostService
  {
    public decimal ShippingCost => 25;
  }

  /// <summary>
  /// concreteFactory
  /// /// </summary>
  public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
  {
    public IDiscountService CreateDiscountService()
    {
      return new BelgiumDiscountService();
    }

    public IShippingCostService CreateShippingCostsService()
    {
      return new BelgiumShippingCostService();
    }
  }

  public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
  {
    public IDiscountService CreateDiscountService()
    {
      return new FranceDiscountService();
    }

    public IShippingCostService CreateShippingCostsService()
    {
      return new FranceShippingCostsService();
    }
  }

  public class ShoppingCart
  {
    private readonly IDiscountService _discountService;
    private readonly IShippingCostService _shippingCostService;
    private readonly int _orderCost;

    public ShoppingCart(IShoppingCartPurchaseFactory shoppingCartPurchaseFactory)
    {
      _discountService = shoppingCartPurchaseFactory.CreateDiscountService();
      _shippingCostService = shoppingCartPurchaseFactory.CreateShippingCostsService();
      _orderCost = 200;
    }

    public void CalculateCosts()
    {
      System.Console.WriteLine($"Total costs = {(_orderCost / 100 * _discountService.DiscountPercentage) + _shippingCostService.ShippingCost}");
    }
  }
}
