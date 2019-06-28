using Niue.Application.BaseDto;

namespace Niue.Application.Users.Dto
{
    public class GetUsersInput : PaginationDto<UserDto>
    {
        public string Key { get; set; }
        public int UserType { get; set; }
        public string EmailAddress { get; set; }
        public int IsActive { get; set; }
    }
}
