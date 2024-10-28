using RpgTextGame.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace RpgTextGame.Utilities
{
   
    internal class MonsterList
    {
        public void JsonConnection(ref List<Enemy> monsters)
        {
            string filePath = @"C:\Users\Satmeetsingh\Desktop\C# Practice Questions\RpgTextGame\Data\Enemy\VillgeOutskirt.json";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return; // Exit if file not found
            }
            try
            {

                string jsonData = File.ReadAllText(filePath);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                monsters = JsonSerializer.Deserialize<List<Enemy>>(jsonData, options);
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON Deserialization Error: {jsonEx.Message}");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return; // Exit for any other exception
            }
        }
        public List<Enemy> GetMonster() {
            List<Enemy> monsters = null;

            JsonConnection(ref monsters);

            if (monsters == null && monsters?.Count == 0) {
                Console.WriteLine(" monsters is null after deserialization.");
            } else
            {
                foreach(Enemy monster in monsters)
                {
                    Console.WriteLine($"\t{monster.Id}. {monster.Name}(level:{monster.Level})");
                    Console.WriteLine($"\t   HP: {monster.Health} / {monster.MaxHealth}  Damage:{monster.Damage}\n");
                }
            }
            return monsters;
        }
    }
}
