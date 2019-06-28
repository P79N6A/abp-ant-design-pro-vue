using System;

namespace Niue.Application.AppServices.AppWeChatPays.Dto
{
    public class GetPayInfoInput
    {
        public Guid BusinessPartyId { get; set; }
        public string SpbillCreateIp { get; set; }
    }
}
