using System.Reflection.Metadata;

namespace APP_ListadeDesejos.Classes;

public class ItemLista
{
    int idItemLista;
    Usuario usuario;
    string nome;
    string descricao;
    Blob imagem;
    string link;
    string visualizacao; //public or private
    bool comentario; //sim ou não
    //lista de usuários que curtiram o item
}