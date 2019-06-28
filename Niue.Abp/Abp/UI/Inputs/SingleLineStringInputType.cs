using System;
using Niue.Abp.Abp.Runtime.Validation;

namespace Niue.Abp.Abp.UI.Inputs
{
    [Serializable]
    [InputType("SINGLE_LINE_STRING")]
    public class SingleLineStringInputType : InputTypeBase
    {
        public SingleLineStringInputType()
        {

        }

        public SingleLineStringInputType(IValueValidator validator)
            : base(validator)
        {
        }
    }
}