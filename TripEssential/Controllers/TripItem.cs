using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripEssential.BLL;
using TripEssential.BLL.DataContract;

namespace TripEssential.Controllers
{
    [Route("api/TripItem")]
    [ApiController]
    public class TripItem : ControllerBase
    {
        [Route("V1/GetTripItems")]
        [HttpGet]
        public async Task<ActionResult> GetTripItems()
        {
            try
            {
                #region RequestValidation

                #endregion

                return Ok(await TripEssentialBLL.TripItemHelper.GetTripItems());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("V1/GetKnapsacktems")]
        [HttpGet]
        public async Task<ActionResult> GetKnapsacktems()
        {
            try
            {
                #region RequestValidation

                #endregion

                return Ok(await TripEssentialBLL.TripItemHelper.GetKnapsacktems());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("V1/GetKnapsackCapacity")]
        [HttpGet]
        public async Task<ActionResult> GetKnapsackCapacity()
        {
            try
            {
                #region RequestValidation

                #endregion

                return Ok(await TripEssentialBLL.TripItemHelper.GetKnapsackCapacity());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("V1/AddOrRemoveKnapsackItem")]
        [HttpPost]
        public async Task<ActionResult> AddOrRemoveKnapsackItem([FromBody] AddOrRemoveKnapsackItemReq addOrRemoveKnapsackItemReq)
        {
            try
            {
                #region RequestValidation

                ModelState.Clear();

                if (addOrRemoveKnapsackItemReq is null)
                {
                    ModelState.AddModelError("AddOrRemoveKnapsackItemReq", "addOrRemoveKnapsackItemReq can not be null");
                }
                else
                {
                    if (addOrRemoveKnapsackItemReq.TripItemId == Guid.Empty)
                    {
                        ModelState.AddModelError("TripItemId", "TripItemId must be a globally unique identifier and not empty");
                    }
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiErrorResp(ModelState));
                }

                #endregion

                await TripEssentialBLL.TripItemHelper.AddOrRemoveKnapsackItem(addOrRemoveKnapsackItemReq);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
