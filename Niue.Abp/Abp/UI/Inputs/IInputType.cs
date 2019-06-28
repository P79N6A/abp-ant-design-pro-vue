using System.Collections.Generic;
using Niue.Abp.Abp.Runtime.Validation;

namespace Niue.Abp.Abp.UI.Inputs
{
    public interface IInputType
    {
        string Name { get; }

        object this[string key] { get; set; }

        IDictionary<string, object> Attributes { get; }

        IValueValidator Validator { get; set; }
    }
}