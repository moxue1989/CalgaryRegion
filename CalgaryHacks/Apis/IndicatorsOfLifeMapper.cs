using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CalgaryHacks.DatabaseModel;
using CalgaryHacks.EventDtos.IndicatorDTOs;

namespace CalgaryHacks.Apis
{
    public class IndicatorsOfLifeMapper
    {
        public static Task UpdateOtherIndicatorsOfLife(List<OtherQOLIndicatorsDTO> otherQOLDTOs)
        {
            DataModel db = new DataModel();
            List<OtherIndicatorsOfLife> otherIndicatorsOfLife = db.OtherIndicatorsofLife.ToList();

            foreach (var indicatorQOLByYear in otherQOLDTOs)
            {
                OtherIndicatorsOfLife indicatorByYear = otherIndicatorsOfLife.FirstOrDefault(x => x.Year == indicatorQOLByYear.Year);

                if (indicatorByYear == null)
                {
                    OtherIndicatorsOfLife newIndicatorByYear = new OtherIndicatorsOfLife();
                    newIndicatorByYear.Year = indicatorQOLByYear.Year;
                    newIndicatorByYear.PercentageOfActiveAdults = indicatorQOLByYear.ActiveAdults;
                    newIndicatorByYear.PercentageOfDrivingAloneToWork = indicatorQOLByYear.DriveAloneToWork;
                    newIndicatorByYear.PercentageToDailyNeedsAndServices =
                        indicatorQOLByYear.AccessToDailyNeedsAndServices;
                    newIndicatorByYear.PercentageAccessibilityTransit = indicatorQOLByYear.AccessibilityToTransit;
                    newIndicatorByYear.PercentageCommunityBelonging = indicatorQOLByYear.CommunityBelonging;

                    db.OtherIndicatorsofLife.Add(newIndicatorByYear);
                }
            }
            db.SaveChanges();
            return Task.FromResult(0);
        }

    }
}