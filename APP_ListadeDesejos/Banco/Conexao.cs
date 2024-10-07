using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP_ListadeDesejos.Classes;

namespace APP_ListadeDesejos.Banco;

public class Conexao
{
    FirebaseClient firebase = new FirebaseClient("URL DO SEU BANCO");

    public async Task<List<Usuario>> ObterUsuarios()
    {

        return (await firebase
            .Child("Usuarios")
            .OnceAsync<Usuario>()).Select(item => new Usuario
        {
            nome = item.Object.nome,
            email = item.Object.email,
            senha=item.Object.senha,
            sexo=item.Object.sexo,
            estadocivil=item.Object.estadocivil,
            cidade=item.Object.cidade,
            estado=item.Object.estado
        }).ToList();
    }

    public async Task AdicionarUsuario(string nome, string email, string senha, string sexo, string estadocivil, string cidade, string estado)
    {

        await firebase
            .Child("Usuarios")
            .PostAsync(new Usuario() { Nome = nome,Email=email, Senha= senha, Sexo = sexo, EstadoCivil= estadocivil, Cidade = cidade, Estado= estado});
    }

    public async Task<Usuario> ObterUsuario(int idUsuario)
    {
        var allPersons = await ObterUsuarios();
        await firebase
            .Child("Usuarios")
            .OnceAsync<Usuario>();
        return allPersons.Where(a => a.IdUsuario == idUsuario).FirstOrDefault();
    }

    public async Task AtualizarUsuario(int IdUsuario, string nome, string email, string senha, string sexo, string estadocivil, string cidade, string estado)
    {
        var toUpdatePerson = (await firebase
            .Child("Usuarios")
            .OnceAsync<Usuario>()).Where(a => a.Object.Numero == numero).FirstOrDefault();

        await firebase
            .Child("Usuario")
            .Child(toUpdatePerson.Key)
            .PutAsync(new Usuario() { IDUsuario = IdUsuario, Nome = nome,Email=email, Senha= senha, Sexo = sexo, EstadoCivil= estadocivil, Cidade = cidade, Estado= estado});
    }

    public async Task ApagarUsuario(int idUsuario)
    {
        var toDeletePerson = (await firebase
            .Child("Usuarios")
            .OnceAsync<Usuario>()).Where(a => a.Object.IdUsuario == idUsuario).FirstOrDefault();
        await firebase.Child("Usuarios").Child(toDeletePerson.Key).DeleteAsync();

    }
}

