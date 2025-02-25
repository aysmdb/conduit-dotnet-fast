using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealDotnetFast.Models.Entities;

public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Image { get; set; } = "https://api.realworld.io/images/smiley-cyrus.jpeg";
        public string Bio { get; set; } = "";
        public bool Demo { get; set; }

        public List<Article>? Articles { get; set; }
        public List<Article>? Favorites { get; set; }
        public List<User>? Follower { get; set; }
        public List<User>? Following { get; set; }
        public List<Comment>? Comments { get; set; }

    }