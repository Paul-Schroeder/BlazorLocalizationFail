using System;
using System.ComponentModel.DataAnnotations;

namespace SprayCalc.Client.Consts
{
    public class ComponentEnums
    {
        [Flags]
        public enum SwathSize
        {
            [Display(Name = "50 Meter Swath")]
            Swath50Meter = 1,

            [Display(Name = "100 Meter Swath")]
            Swath100Meter = 2
        }
    }
}