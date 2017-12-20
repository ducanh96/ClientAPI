using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClientAPI.Models.DetailPrize;

namespace ClientAPI.Models
{
    public class CreatePrizeModel
    {
        public FirstPrize GetFirstPrize { get; set; }
        public SecondPrize GetSecondPrize { get; set; }
        public ThirdPrize GetThirdPrize { get; set; }
        public FourthPrize GetFourthPrize { get; set; }
        public FifthPrize GetFifthPrize { get; set; }
        public SixthPrize GetSixthPrize { get; set; }
        public SeventhPrize GetSeventhPrize { get; set; }
        public SpecialPrize GetSpecialPrize { get; set; }
    }
}