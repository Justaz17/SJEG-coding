using System;
namespace BusinessEntities
{
    public interface IUser
    {
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string UserType { get; set; }

    }
}
