using prob5.Core;
using System;

namespace prob5.Interfaces
{
    interface IClock
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }

        BusinessDate Today { get; }
    }
}
