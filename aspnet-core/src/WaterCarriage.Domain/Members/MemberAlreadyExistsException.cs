using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace WaterCarriage.Members
{
    [Serializable]
    public class MemberAlreadyExistsException : BusinessException
    {
        public MemberAlreadyExistsException(string name) : base(WaterCarriageDomainErrorCodes.MemberAlreadyExists)
        {
            WithData("name", name);
        }
    }
}