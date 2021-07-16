using Microsoft.EntityFrameworkCore;
using Salvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salvo.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(SalvoContext repositoryContext):base(repositoryContext)
        {

        }
        public IEnumerable<Game> GetAllGames()
        {
            return FindAll().OrderByDescending(game => game.CreationDate);
        }
        public IEnumerable<Game> GetAllGamesWithPlayers()
        {
            return FindAll(source =>
                source.Include(game => game.GamePlayers)
                    .ThenInclude(GamePlayer => GamePlayer.Player)).OrderBy(game => game.CreationDate).ToList();
        }
    }
}
