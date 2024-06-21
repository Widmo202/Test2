using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesCharacterExist(int characterId)
    {
        return await _context.Characters.AnyAsync(e => e.Id == characterId);
    }

    public async Task<Character?> GetCharacterById(int characterId)
    {
        return await _context.Characters.FirstOrDefaultAsync(e => e.Id == characterId);

    }

    public async Task<ICollection<Backpack>> GetBackpacksOfCharacter(int characterId)
    {
        return await _context.Backpacks.Include(e => e.Character)
            .Where(e => e.CharacterId == characterId)
            .ToListAsync();
    }
    
    public async Task<ICollection<CharacterTitle>> GetCharacterTitles(int characterId)
    {
        return await _context.CharacterTitles.Include(e => e.Character)
            .Where(e => e.CharacterId == characterId)
            .ToListAsync();
    }

    public async Task<Title?> GetTitleById(int titleId)
    {
        return await _context.Titles.FirstOrDefaultAsync(e => e.Id == titleId);
    }

    public async Task<Item?> GetItemById(int itemId)
    {
        return await _context.Items.FirstOrDefaultAsync(e => e.Id == itemId);
    }
}