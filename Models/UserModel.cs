using System.ComponentModel.DataAnnotations;

namespace project_renault.Models
{
    public class UserModel
    {
        [Key]
        public int id_usuario { get; set; }
        public string login { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public Boolean sessaoValida { get; set; }

    }
}
