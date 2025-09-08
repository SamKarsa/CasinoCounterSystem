using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoCounterSystem.Model
{
    public class CoinType
    {
        public int CoinTypeId { get; set; }

        [Required(ErrorMessage = "Coin number is required")]
        public int NumCoin { get; set; }

        // Constructor
        public CoinType() { }

        public CoinType(int coinTypeId, int numCoin)
        {
            CoinTypeId = coinTypeId;
            NumCoin = numCoin;
        }

        public override string ToString()
        {
            return $"Coin {NumCoin}";
        }
    }
}
