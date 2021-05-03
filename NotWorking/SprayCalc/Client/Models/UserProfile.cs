using System;
using System.Collections.Generic;

namespace SprayCalc.Client.Models
{
    public class UserProfile
    {
        public UserProfile()
        {
        }

        public DateTimeOffset CreatedOn { get; set; }
        public bool IsNavMinified { get; set; } = false;
        public bool IsNavOpen { get; set; } = true;
        public string LastPageVisited { get; set; } = "/";
        public List<MetricReadyToUse> MetricReadyToUses { get; set; } = new List<MetricReadyToUse>();
        public DateTimeOffset ModifiedOn { get; set; }
        public Guid UserId { get; set; }
    }
}