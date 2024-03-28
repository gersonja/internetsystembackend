using System.ComponentModel.DataAnnotations;

namespace InternetSystem.Models
{
    public class AttentionModelReq
    {
        public int? Attentionid { get; set; }

        [Required(ErrorMessage = "Turn is required")]
        public int Turnid { get; set; }

        [Required(ErrorMessage = "Client is required")]
        public int Clientid { get; set; }

        [Required(ErrorMessage = "AttentionTypeid is required")]
        public string AttentionTypeid { get; set; }

        [Required(ErrorMessage = "AttentionStatusid is required")]
        public int AttentionStatusid { get; set; }

    }
}