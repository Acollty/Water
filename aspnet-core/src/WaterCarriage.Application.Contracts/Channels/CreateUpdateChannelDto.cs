using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WaterCarriage.Channels
{
    public class CreateUpdateChannelDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public ChannelType Type { get; set; } = ChannelType.Undefined;

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; } = DateTime.Now;

        [Required]
        public Int64 Ports { get; set; }
    }
}
