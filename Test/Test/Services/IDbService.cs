using Test.Models;

namespace Test.Services;

public interface IDbService
{
    Task<bool> DoesCharacterExist(int characterId);
    Task<Character?> GetCharacterById(int characterId);
    Task<ICollection<Backpack>> GetBackpacksOfCharacter(int characterId);
    Task<ICollection<CharacterTitle>> GetCharacterTitles(int characterId);
    Task<Title?> GetTitleById(int titleId);
    Task<Item?> GetItemById(int itemId);
}