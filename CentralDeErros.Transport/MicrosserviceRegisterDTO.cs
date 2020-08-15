using System;
using System.ComponentModel.DataAnnotations;

namespace CentralDeErros.Transport
{
    public class MicrosserviceRegisterDTO
    {
        public Guid ClientId { get; set; }
        public string ClientSecret { get; set; }
        private string Name { get; set; }
        
    }
}
