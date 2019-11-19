using System;
using System.Collections.Generic;

namespace bb_api.Models
{
    public partial class Adusers
    {
        public string Username { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Deletiondate { get; set; }
        public string Displayname { get; set; }
        public string Email { get; set; }
        public bool? Enabled { get; set; }
        public bool Expirable { get; set; }
        public string Extension { get; set; }
        public string Firstname { get; set; }
        public string Groups { get; set; }
        public DateTime? Lastlogin { get; set; }
        public string Lastname { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Notes { get; set; }
        public string Office { get; set; }
        public string Ou { get; set; }
        public DateTime? Passwordlastset { get; set; }
        public string Program { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public Guid Id { get; set; }
        public int? TermOfEmploymentId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Supervisor { get; set; }
    }
}
