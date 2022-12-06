using OrderService.Domain.SharedKernel;

namespace OrderService.Domain.Models
{
    public class User : IEntity<UserId>
    {
        private User(UserId id, UserStatus status)
        {
            Id = id;
            Status = status;
        }

        public UserId Id { get; }
        public UserStatus Status { get; set; }

        public static User Create(UserId id, UserStatus status)
            => new(id, status);

        internal bool IsVip()
        {
            return Status == UserStatus.Vip;
        }
    }
}