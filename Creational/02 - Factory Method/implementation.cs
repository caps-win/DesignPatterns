using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryMethod
{
  /// <summary>
  /// Product
  /// </summary>
  public abstract class DiscountService
  {
    public abstract int DiscountPercentage { get; }
    public override string ToString()
    {
      return GetType().Name;
    }
  }

  /// <summary>
  /// ConcreteProduct
  /// </summary>
  public class CountryDiscountService : DiscountService
  {
    private readonly string _countryIdentifier;

    public CountryDiscountService(string countryIdentifier)
    {
      this._countryIdentifier = countryIdentifier;
    }

    public override int DiscountPercentage
    {
      get
      {
        switch (this._countryIdentifier)
        {
          case "BE":
            return 20;
          default:
            return 10;
        }
      }
    }
  }

  /// <summary>
  /// ConcreteProduct
  /// </summary>
  public class CodeDiscountService : DiscountService
  {
    private readonly Guid _code;

    public CodeDiscountService(Guid code)
    {
      this._code = code;
    }

    public override int DiscountPercentage
    {
      get => 15;
    }
  }

  /// <summary>
  /// Creator
  /// </summary>
  public abstract class DiscountFactory
  {
    public abstract DiscountService CreateDiscountService();
  }


  /// <summary>
  /// ConcreteCreator
  /// </summary>
  public class CountryDiscountFactory : DiscountFactory
  {
    private readonly string _countryIdentifier;

    public CountryDiscountFactory(string countryIdentifier)
    {
      this._countryIdentifier = countryIdentifier;
    }

    public override DiscountService CreateDiscountService()
    {
      return new CountryDiscountService(_countryIdentifier);
    }
  }

  /// <summary>
  /// ConcreteCreator
  /// </summary>
  public class CodeDiscountFactory : DiscountFactory
  {
    private readonly Guid _code;

    public CodeDiscountFactory(Guid code)
    {
      _code = code;
    }

    public override DiscountService CreateDiscountService()
    {
      return new CodeDiscountService(_code);
    }
  }
}
