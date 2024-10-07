namespace APP_ListadeDesejos.Classes;

public class Usuario
{
    public int IdUsuario { get; set; }
    //public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    string nome;
    string email;
    string senha;
    string sexo;
    string estadocivil;
    string cidade;
    string estado;
    //lista de amigos
    List<Amigo> listaDeAmigos;
    //lista de familiares
    List<Familiar> listaDeFamiliares;
    
}