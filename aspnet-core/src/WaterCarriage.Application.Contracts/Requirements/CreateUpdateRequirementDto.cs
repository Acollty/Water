using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WaterCarriage.Requirements
{
    public class CreateUpdateRequirementDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
    }
}
