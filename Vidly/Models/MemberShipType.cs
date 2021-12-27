using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MemberShipType
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public short DurationInMonths { get; set; }
        public short DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte Free = 1;
    }
}