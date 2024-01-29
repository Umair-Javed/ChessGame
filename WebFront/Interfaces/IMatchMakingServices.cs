using WebFront.MongoDbEntities;

namespace WebFront.Interfaces
{
    public interface IMatchMakingServices
    {
        UserDetail GetOpponent(string MainPlayerName);
    }
}
