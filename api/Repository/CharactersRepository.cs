using api.Domain.Entity;
using api.Requests;
using api.Util;

namespace api.Repository
{
    public class CharactersRepository : IRepository
    {
        private readonly IRequests _requests;
        private static List<int> favCharacters = new List<int>();
        private static List<int> deletedCharacters = new List<int>();        

        public CharactersRepository(IRequests requests)
        {
            _requests = requests;
        }

        public async Task<IEnumerable<CharacterResumed>> GetAll(CharacterFilter filter)
        {


            return await Task.Run(() => 
            {
                List<CharacterResumed> listCharacter = _requests.GetCharacters(filter);

                // Usamos o lock para impedir que ocorra intersecção de tasks
                // tentando acessar a mesma lista
                lock (Const.FavTag)
                {
                    // Passamos por todos persongens, verificando se está incluso nos favoritos
                    listCharacter.ForEach(x =>  {
                        
                        x.Favorite = favCharacters.Contains(x.Id);
                        x.ThumbnailComics = new List<Thumbnail>();

                        // Obtendo as histórias do personagens
                        foreach (CharacterComics item in _requests.GetComics(x.Id))
                        {
                            // adicionamos as histórias que o personagem participa
                            x.ThumbnailComics!.Add(item.Thumbnail!);   
                        }

                    });
                }

                lock (Const.DeletedTag)
                {
                    // Retiramos os personagens que foram excluidos
                    listCharacter = listCharacter.Where(x => !deletedCharacters.Contains(x.Id)).ToList();
                }

                return listCharacter.OrderByDescending(x => x.Favorite);
            });
        }

        public async Task AddFav(int id)
        {
            await Task.Run(() => 
            {
                lock (Const.FavTag)
                {
                    if (favCharacters.Contains(id))
                        throw new ArgumentException("Personagem já adicionado!");

                    if (favCharacters.Count == Const.FavoriteLimit)
                        throw new ArgumentException("Não é possível adicionar mais que 5 personagens favoritos!");

                    favCharacters.Add(id);
                }
            });
        }

        public async Task DeleteFav(int id)
        {
            await Task.Run(() => 
            {
                lock (Const.FavTag)
                {
                    if (favCharacters.Contains(id))
                        favCharacters.Remove(id);
                }
            });
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => 
            {
                lock (Const.DeletedTag)
                {
                    if (!deletedCharacters.Contains(id))
                        deletedCharacters.Add(id);
                }
            });
        }
    }
}