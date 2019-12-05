using System;
using prob5.Interfaces;

namespace prob5.Core
{
    class Clock : IClock
    {
        public DateTime Now { get; }

        public DateTime UtcNow { get; }

        public BusinessDate Today { get; }

        public Clock()
        {
            this.Now = DateTime.Now;
            this.UtcNow = DateTime.UtcNow;
            this.Today = new BusinessDate(DateTime.Today);
        }
    }
}
