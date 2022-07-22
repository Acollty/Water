using System;
using System.ComponentModel.DataAnnotations;

namespace WaterCarriage.Members
{
    public class CreateMemberDto
    {
        [Required]
        [StringLength(MemberConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(MemberConsts.MaxMobileLength)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(MemberConsts.MaxEmailLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(MemberConsts.MaxPasswordLength)]
        public string Password { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [StringLength(MemberConsts.MaxGenderLength)]
        public Int32 Gender { get; set; }

        [StringLength(MemberConsts.MaxShortBioLength)]
        public string ShortBio { get; set; }
    }
}