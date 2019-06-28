using System;

namespace Niue.Abp.Abp.Runtime.Validation
{
    [Validator("NULL")]
    [Serializable]
    public class AlwaysValidValueValidator : ValueValidatorBase
    {
        public override bool IsValid(object value)
        {
            return true;
        }
    }
}