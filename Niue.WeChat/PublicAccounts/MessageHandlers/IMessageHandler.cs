/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：IMessageHandler.cs
    文件功能描述：MessageHandler接口
    
    
    创建标识：Senparc - 20150924
    
----------------------------------------------------------------*/

using Niue.WeChat.Core.MessageHandlers;
using Niue.WeChat.PublicAccounts.Entities.Request;
using Niue.WeChat.PublicAccounts.Entities.Response;

namespace Niue.WeChat.PublicAccounts.MessageHandlers
{

    public interface IMessageHandler : IMessageHandler<IRequestMessageBase, IResponseMessageBase>
    {
        new IRequestMessageBase RequestMessage { get; set; }
        new IResponseMessageBase ResponseMessage { get; set; }
    }
}
