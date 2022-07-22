using WaterCarriage.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace WaterCarriage.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class WaterCarriageController : AbpControllerBase
{
    protected WaterCarriageController()
    {
        LocalizationResource = typeof(WaterCarriageResource);
    }
}
