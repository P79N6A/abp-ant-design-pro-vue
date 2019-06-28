using Niue.Abp.Abp.Application.Services.Dto;
using Niue.Abp.Abp.AutoMapper.AutoMapper;
using Niue.Application.Roles.Dto;
using Niue.Core.Enums;
using Niue.Core.Users;

namespace Niue.Application.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserDto : EntityDto<long>
    {
        /// <summary>
        /// ����
        /// </summary>
        public string Name { get; set; }

        public string Surname { get; set; }

        /// <summary>
        /// �û���
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public virtual string Pwd { get; set; }

        public string FullName { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string EmailAddress { get; set; }

        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// �绰����
        /// </summary>
        public string PhoneNumber { get; set; }

        public bool IsPhoneNumberConfirmed { get; set; }

        /// <summary>
        /// ����¼ʱ��
        /// </summary>
        public string LastLoginTime { get; set; }

        /// <summary>
        /// ״̬��0-���ã�1-����
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string CreationTime { get; set; }

        /// <summary>
        /// ��ɫ
        /// </summary>
        public RoleDto Role { get; set; }

        /// <summary>
        /// �ֻ�����
        /// </summary>
        public virtual string Mobile { get; set; }

        /// <summary>
        /// �û�����
        /// </summary>
        public virtual EnumUserType UserType { get; set; }

        /// <summary>
        /// ΢��OpenId
        /// </summary>
        public virtual string WxOpenId { get; set; }

        /// <summary>
        /// ���֤��
        /// </summary>
        public virtual string IdentificationNumber { get; set; }

        /// <summary>
        /// ���֤��Ƭ
        /// </summary>
        public virtual string IdentificationPhoto { get; set; }
    }
}