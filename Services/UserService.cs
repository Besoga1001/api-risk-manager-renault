using Microsoft.EntityFrameworkCore;
using project_renault.Models;
using project_renault.NovaPasta;

namespace project_renault.Services
{
    public class UserService
    {
        DBSettings _context;
        public UserService(DBSettings context) 
        {
            _context = context;
        }

        public async Task<UserModel> doLogin(UserDTO userDTO)
        {
            if (userDTO.login == null)
            {
                throw new ArgumentNullException(nameof(userDTO.login));
            }

            if (userDTO.password == null) 
            { 
                throw new ArgumentNullException(nameof(userDTO.password));
            }

            var user = await _context.User.Where(u => u.login == userDTO.login).FirstOrDefaultAsync();

            if (user.senha == userDTO.password)
            {
                user.senha = "";
                user.sessaoValida = true;
                return user;
            }
            else
            {
                user.senha = "";
                user.sessaoValida = false;
                return user;
            }

        }
    }
}
