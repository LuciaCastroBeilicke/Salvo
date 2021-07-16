using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salvo.Models
{
    public static class Dbinitializer
    {
        //metodo statico que ejecuta acciones dentro de el (void)
        public static void Initialize(SalvoContext context)
        {
            if (!context.Players.Any()) //si en mi lista de players hay algo
            {
                //aca deberia continuar
                var Players = new Player[]
                {
                new Player { Email = "j.bauer@ctu.gov", Name = "Jack Bauer", Password = "24" },
                new Player { Email = "c.obrian@ctu.gov", Name = "Chloe O'Brian", Password = "42" },
                new Player { Email = "kim_bauer@gmail.com", Name = "Kim Bauer", Password = "kb" },
                new Player { Email = "t.almeida@ctu.gov", Name = "Tony Almeida", Password = "mole" }
                };
                foreach (Player p in Players)
                {
                    context.Players.Add(p);
                }
                //gusrdar cambios en el contexto
                context.SaveChanges();
            }
            

            if (!context.Games.Any())
            {
                var Games = new Game[]
                {
                    new Game{CreationDate=DateTime.Now},
                    new Game{CreationDate=DateTime.Now.AddHours(1)},
                    new Game{CreationDate=DateTime.Now.AddHours(2)},
                    new Game{CreationDate=DateTime.Now.AddHours(3)},
                    new Game{CreationDate=DateTime.Now.AddHours(4)},
                    new Game{CreationDate=DateTime.Now.AddHours(5)},
                    new Game{CreationDate=DateTime.Now.AddHours(6)},
                    new Game{CreationDate=DateTime.Now.AddHours(7)}
                };
                foreach (Game g in Games)
                {
                    context.Games.Add(g);
                }
                context.SaveChanges();
            }
            if (!context.GamePlayers.Any())
            {
                Game game1 = context.Games.Find(1L);
                Game game2 = context.Games.Find(2L);
                Game game3 = context.Games.Find(3L);
                Game game4 = context.Games.Find(4L);

                Player jbauer = context.Players.Find(1L);
                Player obrian = context.Players.Find(2L);
                Player kbauer = context.Players.Find(3L);
                Player almeida = context.Players.Find(4L);

                var gamesPlayers = new GamePlayer[]
                {
                    new GamePlayer {JoinDate=DateTime.Now, Game = game1, Player = jbauer },
                    new GamePlayer {JoinDate=DateTime.Now, Game = game1, Player = obrian },
                    new GamePlayer {JoinDate=DateTime.Now, Game = game2, Player = jbauer },
                    new GamePlayer {JoinDate=DateTime.Now, Game = game2, Player = obrian },
                    new GamePlayer {JoinDate=DateTime.Now, Game = game3, Player = obrian },
                    new GamePlayer {JoinDate=DateTime.Now, Game = game3, Player = almeida },
                    new GamePlayer {JoinDate=DateTime.Now, Game = game4, Player = obrian },
                    new GamePlayer {JoinDate=DateTime.Now, Game = game4, Player = jbauer }

                };
                foreach(GamePlayer gp in gamesPlayers)
                {
                    context.GamePlayers.Add(gp);
                }
                context.SaveChanges();
            }
        }
    }
}
