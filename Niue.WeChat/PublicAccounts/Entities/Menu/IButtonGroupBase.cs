using System.Collections.Generic;
using Niue.WeChat.PublicAccounts.Entities.Menu.Buttons;

namespace Niue.WeChat.PublicAccounts.Entities.Menu
{
    public interface IButtonGroupBase
    {
        List<BaseButton> button { get; set; }
    }
}
