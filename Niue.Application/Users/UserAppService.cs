using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Niue.Abp.Abp.AutoMapper.AutoMapper;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Application.BaseDto;
using Niue.Application.Users.Dto;
using Niue.Common;
using Niue.Core.Enums;
using Niue.Core.Sessions;
using Niue.Core.Users;

namespace Niue.Application.Users
{
    /* THIS IS JUST A SAMPLE. */
    //[AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : NiueAppServiceBase, IUserAppService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly ISessionManager _sessionManager;

        public UserAppService(IRepository<User, long> userRepository, ISessionManager sessionManager)
        {
            _userRepository = userRepository;
            _sessionManager = sessionManager;
        }

        public async Task<PaginationDto<UserDto>> GetUsers(GetUsersInput input)
        {
            var users = await _userRepository.GetAllListAsync(o => o.UserName != "admin");
            if (!string.IsNullOrWhiteSpace(input.Key))
            {
                users = users.Where(o => o.UserName.Contains(input.Key) || o.Mobile.Contains(input.Key) || o.Name.Contains(input.Key)).ToList();
            }
            if (input.UserType > 0)
            {
                users = users.Where(o => o.UserType == (EnumUserType) input.UserType).ToList();
            }
            if (!string.IsNullOrWhiteSpace(input.EmailAddress))
            {
                users = users.Where(o => o.EmailAddress.Contains(input.EmailAddress)).ToList();
            }
            if (input.IsActive > 0)
            {
                users = users.Where(o => o.IsActive == (input.IsActive == 1)).ToList();
            }

            var userDtos = users.OrderByDescending(o => o.CreationTime).MapTo<List<UserDto>>();
            return userDtos.ToPagination(input);
        }

        public async Task<ResultDto> AddUser(UserDto input)
        {
            var currentUser = await _sessionManager.GetCurrentUser(AbpSession.UserId);
            if (currentUser == null)
            {
                return EnumResultCode.SessionInvalid.ToResultDto();
            }
            if (string.IsNullOrWhiteSpace(input.UserName))
            {
                return EnumResultCode.UserNameError.ToResultDto();
            }
            if (string.IsNullOrWhiteSpace(input.Pwd) || input.Pwd.Length < 6 || input.Pwd.Length > 18)
            {
                return EnumResultCode.PasswordError.ToResultDto();
            }
            if (string.IsNullOrWhiteSpace(input.Name))
            {
                return EnumResultCode.NameError.ToResultDto();
            }
            if (string.IsNullOrWhiteSpace(input.Mobile) || !RegVerifyHelper.IsMobile(input.Mobile))
            {
                return EnumResultCode.MobileError.ToResultDto();
            }
            if (!string.IsNullOrWhiteSpace(input.EmailAddress) && !RegVerifyHelper.IsEmailAddress(input.EmailAddress))
            {
                return EnumResultCode.EmailAddressError.ToResultDto();
            }
            var userNameCount = await _userRepository.CountAsync(o => o.UserName == input.UserName);
            if (userNameCount > 0)
            {
                return EnumResultCode.UserNameExists.ToResultDto();
            }
            var user = new User();
            user.UserName = input.UserName;
            user.Password = new PasswordHasher().HashPassword(input.Pwd);
            user.Name = input.Name;
            user.Mobile = input.Mobile;
            user.UserType = input.UserType;
            user.EmailAddress = input.EmailAddress;
            user.IsActive = input.IsActive;
            user.PhoneNumber = input.Mobile;
            user.IsEmailConfirmed = !string.IsNullOrWhiteSpace(input.EmailAddress);
            user.CreatorUser = currentUser;
            var addUser = await _userRepository.InsertAsync(user);
            return addUser.ResultTo<UserDto>();
        }

        public async Task<ResultDto> EditUser(UserDto input)
        {
            var currentUser = await _sessionManager.GetCurrentUser(AbpSession.UserId);
            if (currentUser == null)
            {
                return EnumResultCode.SessionInvalid.ToResultDto();
            }
            if (string.IsNullOrWhiteSpace(input.UserName))
            {
                return EnumResultCode.UserNameError.ToResultDto();
            }
            if (!string.IsNullOrWhiteSpace(input.Pwd) && (input.Pwd.Length < 6 || input.Pwd.Length > 18))
            {
                return EnumResultCode.PasswordError.ToResultDto();
            }
            if (string.IsNullOrWhiteSpace(input.Name))
            {
                return EnumResultCode.NameError.ToResultDto();
            }
            if (string.IsNullOrWhiteSpace(input.Mobile) || !RegVerifyHelper.IsMobile(input.Mobile))
            {
                return EnumResultCode.MobileError.ToResultDto();
            }
            if (!string.IsNullOrWhiteSpace(input.EmailAddress) && !RegVerifyHelper.IsEmailAddress(input.EmailAddress))
            {
                return EnumResultCode.EmailAddressError.ToResultDto();
            }
            var userNameCount = await _userRepository.CountAsync(o => o.Id != input.Id && o.UserName == input.UserName);
            if (userNameCount > 0)
            {
                return EnumResultCode.UserNameExists.ToResultDto();
            }
            var user = await _userRepository.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (user == null)
            {
                return EnumResultCode.UserNotExists.ToResultDto();
            }
            user.UserName = input.UserName;
            if (!string.IsNullOrWhiteSpace(input.Pwd))
            {
                user.Password = new PasswordHasher().HashPassword(input.Pwd);
            }
            user.Name = input.Name;
            user.Mobile = input.Mobile;
            user.UserType = input.UserType;
            user.EmailAddress = input.EmailAddress;
            user.PhoneNumber = input.Mobile;
            user.IsEmailConfirmed = !string.IsNullOrWhiteSpace(input.EmailAddress);
            user.LastModifierUser = currentUser;
            var editUser = await _userRepository.UpdateAsync(user);
            return editUser.ResultTo<UserDto>();
        }

        public async Task<ResultDto> ActiveUser(UserDto input)
        {
            var currentUser = await _sessionManager.GetCurrentUser(AbpSession.UserId);
            if (currentUser == null)
            {
                return EnumResultCode.SessionInvalid.ToResultDto();
            }
            var user = await _userRepository.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (user == null)
            {
                return EnumResultCode.UserNotExists.ToResultDto();
            }
            user.IsActive = input.IsActive;
            var editUser = await _userRepository.UpdateAsync(user);
            return editUser.ResultTo<UserDto>();
        }

        public async Task<ResultDto> DeleteUser(UserDto input)
        {
            var currentUser = await _sessionManager.GetCurrentUser(AbpSession.UserId);
            if (currentUser == null)
            {
                return EnumResultCode.SessionInvalid.ToResultDto();
            }
            var user = await _userRepository.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (user == null)
            {
                return EnumResultCode.UserNotExists.ToResultDto();
            }
            await _userRepository.DeleteAsync(user);
            return EnumResultCode.Success.ToResultDto();
        }
    }
}
