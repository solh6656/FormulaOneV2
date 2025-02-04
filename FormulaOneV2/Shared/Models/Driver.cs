using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneV2.Shared.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RacingNb { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
    }
}
