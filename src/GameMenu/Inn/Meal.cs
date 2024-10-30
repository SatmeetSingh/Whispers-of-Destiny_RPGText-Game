using RpgTextGame.Models;
using System.IO;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgTextGame.Utilities;

namespace RpgTextGame.src.GameMenu.Inn
{
    public class Effect
    {
        public int? HealthRestoration { get; set; }
        public int? StaminaRestoration { get; set; }  // Nullable for optional fields
        public bool? MoraleBoost { get; set; }
        public bool? TemporaryAttackBoost { get; set; }
    }

    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Effect Effect { get; set; }
        public Currency Cost { get; set; }

    }
    public class MealData
    {
        public List<Meal> Meals { get; set; }
    }
    public class MealPage
    {
        public void OrderMeal(ICharacter character)
        {
            MealData mealData = null;
            string jsonFilePath = @"C:\Users\Satmeetsingh\Desktop\C# Practice Questions\RpgTextGame\Data\Inn\OrderMeal.json";
            try
            {
                // Read the JSON data from the file
                var jsonData = File.ReadAllText(jsonFilePath);
                Console.Clear();
                Console.WriteLine("\n =================================================");
                Console.WriteLine("                   Order a meal                   ");
                Console.WriteLine(" =================================================\n");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Make property name matching case-insensitive
                };

                // Deserialize the JSON data into MealData
                mealData = JsonSerializer.Deserialize<MealData>(jsonData, options);

                // Check if Meals is null
                if (mealData?.Meals == null)
                {
                    Console.WriteLine(" Meals is null after deserialization.");
                }
                else
                {
                    // Loop through meals to print details
                    foreach (Meal meal in mealData.Meals)
                    {
                        if (meal == null)
                        {
                            continue; 
                        }
                        Currency currency = new Currency(meal.Cost.Gold, meal.Cost.Silver, meal.Cost.Bronze);

                        Console.WriteLine($"{meal.Id}. Meal: {meal.Name}");
                        Console.WriteLine($"   Description: {meal.Description}");
                        
                        Console.WriteLine($"   Cost: {currency.PrintCurrency()}");
                        // Check effects
                        if (meal.Effect != null)
                        {
                            if (meal.Effect.HealthRestoration.HasValue)
                                Console.WriteLine($"   Health Restoration: {meal.Effect.HealthRestoration}");
                            if (meal.Effect.StaminaRestoration.HasValue)
                                Console.WriteLine($"   Stamina Restoration: {meal.Effect.StaminaRestoration}");
                            if (meal.Effect.MoraleBoost.HasValue && meal.Effect.MoraleBoost.Value)
                                Console.WriteLine("   Morale Boost: Yes");
                            if (meal.Effect.TemporaryAttackBoost.HasValue && meal.Effect.TemporaryAttackBoost.Value)
                                Console.WriteLine("   Temporary Attack Boost: Yes");
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($" JSON Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Exception: {ex.Message}");
            }

            Console.Write(" Pick your Order: ");
            string Order = Console.ReadLine();
            do
            {
                if (mealData != null)
                {
                    switch (Order)
                    {
                        case "1":
                            var cost = mealData.Meals[0].Cost;
                            NavigationPage.InsuffecientMoneyForFood(character, cost);
                            character.Money.SubtractCurrency(cost.Gold, cost.Silver, cost.Bronze);
                            if (character.HealthPoints + mealData.Meals[0].Effect.HealthRestoration < character.MaxHealthPoints)
                            {
                                character.HealthPoints += mealData.Meals[0].Effect.HealthRestoration ?? 0;
                            }
                            else
                            {
                                character.HealthPoints = character.MaxHealthPoints;
                            }
                            MealData(character, mealData.Meals[0]);
                            break;
                        case "2":
                            cost = mealData.Meals[1].Cost;
                            NavigationPage.InsuffecientMoneyForFood(character, cost);
                            character.Money.SubtractCurrency(cost.Gold, cost.Silver, cost.Bronze);
                            if (character.HealthPoints + mealData.Meals[1].Effect.HealthRestoration < character.MaxHealthPoints)
                            {
                                character.HealthPoints += mealData.Meals[1].Effect.HealthRestoration ?? 0;
                            }
                            else
                            {
                                character.HealthPoints = character.MaxHealthPoints;
                            }
                            MealData(character, mealData.Meals[1]);
                            break;
                        case "3":
                            cost = mealData.Meals[2].Cost;
                            NavigationPage.InsuffecientMoneyForFood(character, cost);
                            character.Money.SubtractCurrency(cost.Gold, cost.Silver, cost.Bronze);
                            if (character.Mana + mealData.Meals[2].Effect.StaminaRestoration < character.MaxMana)
                            {
                                character.Mana += mealData.Meals[2].Effect.StaminaRestoration ?? 0;
                            }
                            else
                            {
                                character.Mana = character.MaxMana;
                            }
                            MealData(character, mealData.Meals[2]);
                            break;
                        case "4":
                            cost = mealData.Meals[3].Cost;
                            NavigationPage.InsuffecientMoneyForFood(character, cost);
                            character.Money.SubtractCurrency(cost.Gold, cost.Silver, cost.Bronze);
                            if (character.HealthPoints + mealData.Meals[3].Effect.HealthRestoration < character.MaxHealthPoints)
                            {
                                character.HealthPoints += mealData.Meals[3].Effect.HealthRestoration ?? 0;
                            }
                            else
                            {
                                character.HealthPoints = character.MaxHealthPoints;
                            }
                            MealData(character, mealData.Meals[3]);
                            break;
                        case "5":
                            cost = mealData.Meals[4].Cost;
                            NavigationPage.InsuffecientMoneyForFood(character, cost);
                            character.Money.SubtractCurrency(cost.Gold, cost.Silver, cost.Bronze);
                            if (character.HealthPoints + mealData.Meals[4].Effect.HealthRestoration < character.MaxHealthPoints)
                            {
                                character.HealthPoints += mealData.Meals[4].Effect.HealthRestoration ?? 0;
                            }
                            else
                            {
                                character.HealthPoints = character.MaxHealthPoints;
                            }
                            MealData(character, mealData.Meals[4]);
                            break;
                        case "6":
                            Console.WriteLine(" Skip the Meal");
                            NavigationPage.NavigateToInnPage(character);
                            break;
                        default:
                            Console.WriteLine(" Invalid Option, Press any key to try again");
                            OrderMeal(character);
                            break;
                    };
                }
            } while (Order != "6");
            Console.ReadKey();
        }

        public void MealData(ICharacter character, Meal meal)
        {
            // Assuming meal has already been selected, and currency deduction is done
            Console.Clear();
            Console.WriteLine("\n Meal Ordered Successfully!");

            // Print the meal details
            Console.WriteLine($" You ordered: {meal.Name}");
            Console.WriteLine($" Description: {meal.Description}");

            // Print the cost of the meal
            Console.WriteLine(" Cost: ");
            Console.Write(meal.Cost.PrintCurrency());  // Assuming your PrintCurrency method shows the cost

            // Print the effects of the meal
            Console.WriteLine("\n Effects:");
            if (meal.Effect.HealthRestoration.HasValue)
            {
                Console.WriteLine($" - Health Restored: {meal.Effect.HealthRestoration} HP");
            }
            if (meal.Effect.StaminaRestoration.HasValue)
            {
                Console.WriteLine($" - Stamina Restored: {meal.Effect.StaminaRestoration} Stamina");
            }
            if (meal.Effect.MoraleBoost.HasValue && meal.Effect.MoraleBoost.Value)
            {
                Console.WriteLine(" - Morale Boost: Yes");
            }
            if (meal.Effect.TemporaryAttackBoost.HasValue && meal.Effect.TemporaryAttackBoost.Value)
            {
                Console.WriteLine(" - Temporary Attack Boost: Yes");
            }

            // Show remaining character's currency (assuming you've updated it after the purchase)
            Console.WriteLine("\n Your remaining currency:");
            Console.WriteLine(character.Money.PrintCurrency());  // Assuming PrintCurrency also works for the character's balance

            // Show any other details you want to include
            Console.WriteLine("\n Enjoy your meal!");

            Console.Write(" Press any key to go back");
            Console.ReadKey();
            OrderMeal(character);
        }

    }
}
