using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncDemo.Models
{
    public class ProgressReport
    {
        public int DownloadPercent { get; set; } = 0;
        public List<Website> DownloadedWebsites { get; set; } = new List<Website>();
    }
}
