using System.ComponentModel.DataAnnotations;
using Todoonboard_api.InfoModels;

namespace Todoonboard_api.InfoModels;

    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
