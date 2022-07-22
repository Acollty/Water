using System;
using System.Collections.Generic;
using System.Text;
using WaterCarriage.Localization;
using Volo.Abp.Application.Services;

namespace WaterCarriage;

/* Inherit your application services from this class.
 */
public abstract class WaterCarriageAppService : ApplicationService
{
    protected WaterCarriageAppService()
    {
        LocalizationResource = typeof(WaterCarriageResource);
    }
}
