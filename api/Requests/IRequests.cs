using System.Reflection;
using api.Domain.Entity;

namespace api.Requests
{
    public interface IRequests
    {
        List<CharacterResumed> GetCharacters(CharacterFilter filter);
    }
}