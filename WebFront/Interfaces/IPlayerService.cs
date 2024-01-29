using WebFront.Enums;
using WebFront.Models;
using WebFront.MongoDbEntities;

namespace WebFront.Interfaces
{
    public interface IPlayerService
    {
        PlayerModel? InitializePlayer(string name, PlayerType type);
        PlayerModel? InitializePlayerWithExistingSession(GameSession session, PlayerType type);
        List<CoinsModel> GenerateShuffledList();
    }
}
