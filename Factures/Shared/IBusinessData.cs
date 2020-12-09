using System;
using System.Collections.Generic;
using System.Text;

namespace Factures.Shared
{
    public interface IBusinessData
    {
        List<Facture> Facture { get; }
    }
}