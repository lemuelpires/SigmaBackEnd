;

namespace sigmaBack.DTOs.DTOs
{
    public class UsuarioDto
    {
        public string? Email { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Senha { get; set; }
        public string? Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Telefone { get; set; }
        public string? CPF { get; set; }
        public DateTime Data { get; set; }
        public bool Ativo { get; set; }
        public UserRole Role { get; set; }
    }
}


