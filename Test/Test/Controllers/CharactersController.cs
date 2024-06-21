using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services;

namespace Test.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;
    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetCharacters(int characterId)
    {
        if (!await _dbService.DoesCharacterExist(characterId))
        {
            return BadRequest("No character with this ID");
        }

        Character character = await _dbService.GetCharacterById(characterId);

        var charBackpack = await _dbService.GetBackpacksOfCharacter(characterId);

        var characterTitle = await _dbService.GetCharacterTitles(characterId);

        var items = new List<Item>();
        
        foreach (var backpack in charBackpack)
        {
            var item = await _dbService.GetItemById(backpack.ItemId);
            items.Add(new Item()
              {
                  Id = item.Id,
                  Weight = item.Weight
              });
        }

        var titles = new List<Title>();
        
        foreach (var charTitle in characterTitle)
        {
            var title = await _dbService.GetTitleById(charTitle.TitleId);
            titles.Add(new Title()
            {
                Id = title.Id,
                Name = title.Name
            });
        }

        return Ok(new
        {
            firstName = character.FirstName,
            lastName = character.LastName,
            currentWeight = character.CurrentWeight,
            maxWeight = character.MaxWeight,
            backpacks = items.ToList(),
            Titles = titles.ToList()
        });
    }
}