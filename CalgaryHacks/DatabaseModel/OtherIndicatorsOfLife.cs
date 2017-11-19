using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalgaryHacks.DatabaseModel
{
    public class OtherIndicatorsOfLife
    {
        public int ID { get; set; }

        public string Year { get; set; }

        public string PercentageOfDrivingAloneToWork { get; set; }

        public string PercentageOfActiveAdults { get; set; }

        public string PercentageToDailyNeedsAndServices { get; set; }

        public string PercentageCommunityBelonging { get; set; }

        public string PercentageAccessibilityTransit { get; set; }

    }
}