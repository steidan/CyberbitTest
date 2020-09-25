using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {
            Console.WriteLine("Hello World");
        }


        [HttpGet("a")]
        public async Task<ActionResult<long>> CreateBalance()
        {
            // var balanceID = await this.payoneerDBDAL.CreateBalance().ConfigureAwait(false);
            Console.WriteLine("Hello World");
            return Ok();
        }

        // [HttpGet("GetBalanceInfo/{id}")]
        // public async Task<ActionResult<BalanceInfo>> GetBalanceInfo(long id)
        // {
        //     var (balance, doesBalanceExist) = await this.payoneerDBDAL.GetBalance(id).ConfigureAwait(false);
        //     if (!doesBalanceExist)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(balance);
        // }

        // [HttpGet("Charge/{balanceID}/{amount}")]
        // public async Task<ActionResult> Charge(long balanceID, float amount)
        // {
        //     var (doesBalanceExist, isBalanceAmountEnough) = await this.payoneerDBDAL.Charge(balanceID, amount).ConfigureAwait(false);
        //     if (!doesBalanceExist)
        //     {
        //         return BadRequest(new Exception("Balance doesn't exist"));
        //     }
        //     if (!isBalanceAmountEnough)
        //     {
        //         return BadRequest(new Exception("Balance doesn't have sufficient amount"));
        //     }
        //     return Ok();
        // }

        // [HttpGet("Load/{balanceID}/{amount}")]
        // public async Task<ActionResult> Load(long balanceID, float amount)
        // {
        //     var doesBalanceExist = await this.payoneerDBDAL.Load(balanceID, amount).ConfigureAwait(false);
        //     if (!doesBalanceExist)
        //     {
        //         return BadRequest(new Exception("Balance doesn't exist"));
        //     }
        //     return Ok();
        // }

        // [HttpGet("Transfer/{senderBalanceID}/{recipientBalanceID}/{amount}")]
        // public async Task<ActionResult> Transfer(long senderBalanceID, long recipientBalanceID, float amount)
        // {
        //     var (doBalancesExist, isSenderBalanceAmountEnough) = await this.payoneerDBDAL.Transfer(senderBalanceID, recipientBalanceID, amount).ConfigureAwait(false);
        //     if (!doBalancesExist)
        //     {
        //         return BadRequest(new Exception("One of the balances or both don't exist"));
        //     }
        //     if (!isSenderBalanceAmountEnough)
        //     {
        //         return BadRequest(new Exception("The sender's balance doesn't have sufficient amount for the transaction"));
        //     }
        //     return Ok();
        // }
    }
}
