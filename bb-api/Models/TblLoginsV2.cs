using System;
using System.Collections.Generic;

namespace bb_api.Models
{
    public partial class TblLoginsV2
    {
        public int Id { get; set; }
        public string Logintype { get; set; }
        public string Username { get; set; }
        public string Machine { get; set; }
        public DateTime Date { get; set; }
        public string Dc { get; set; }
        public string Gw { get; set; }
    }
}
