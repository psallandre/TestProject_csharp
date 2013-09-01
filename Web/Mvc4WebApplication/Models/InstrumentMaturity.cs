using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Mvc4WebApplication.Models
{
  public class InstrumentMaturity
  {
      public int Id { get; set; }

    public string InstrumentName { get; set; }
    public DateTime Maturity { get; set; }
    public decimal Price { get; set; }

    public string MaturityToString { get; private set; }
    public string LastInterestToString { get; set; }

    public InstrumentMaturity Clone()
    {
      return new InstrumentMaturity
      {
        InstrumentName = InstrumentName,
        Maturity = Maturity,
        Price = Price,
        MaturityToString = String.Format(CultureInfo.InvariantCulture, "{0:MMM yyyy}", Maturity),
        LastInterestToString = LastInterestToString
      };
    }
  }
}