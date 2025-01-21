using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class RecipeTests : IDisposable
    {
        private RestClient client;
        private string token;

        [SetUp]
        public void Setup()
        {
            client = new RestClient(GlobalConstants.BaseUrl);
            token = GlobalConstants.AuthenticateUser("john.doe@example.com", "password123");
            Assert.That(token, Is.Not.Null.Or.Empty, "Authentication token should not be null or empty");
        }

        [Test]
        public void Test_GetAllRecipes()
        {
            var request = new RestRequest("/recipe", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");

            var response = client.Execute(request);

            // Response Assertions
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code should be 200 OK");
            Assert.That(response.Content, Is.Not.Empty, "Response content should not be empty");

            var recipes = JArray.Parse(response.Content);

            // Data Structure Assertions
            Assert.That(recipes, Is.Not.Empty, "Should contain at least one recipe");

            // Recipe Fields Assertions
            foreach (var recipe in recipes)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(recipe["title"]?.ToString(), Is.Not.Null.Or.Empty, "Title should not be null or empty");
                    Assert.That(recipe["ingredients"], Is.Not.Null, "Ingredients should not be null");
                    Assert.That(recipe["ingredients"].Type, Is.EqualTo(JTokenType.Array), "Ingredients should be an array");
                    Assert.That(recipe["instructions"], Is.Not.Null, "Instructions should not be null");
                    Assert.That(recipe["instructions"].Type, Is.EqualTo(JTokenType.Array), "Instructions should be an array");
                    Assert.That(recipe["cookingTime"]?.ToString(), Is.Not.Null.Or.Empty, "CookingTime should not be null or empty");
                    Assert.That(recipe["servings"]?.ToString(), Is.Not.Null.Or.Empty, "Servings should not be null or empty");
                    Assert.That(recipe["category"], Is.Not.Null, "Category should not be null");
                });
            }
        }

        [Test]
        public void Test_GetRecipeByTitle()
        {
            var request = new RestRequest("/recipe", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");

            var response = client.Execute(request);

            // Response Assertions
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code should be 200 OK");
            Assert.That(response.Content, Is.Not.Empty, "Response content should not be empty");

            var recipes = JArray.Parse(response.Content);
            var chocolateChipCookies = recipes.FirstOrDefault(r => r["title"].ToString() == "Chocolate Chip Cookies");

            // Recipe Existence Assertion
            Assert.That(chocolateChipCookies, Is.Not.Null, "Chocolate Chip Cookies recipe should exist");

            // Recipe Fields Assertions
            Assert.Multiple(() =>
            {
                Assert.That(chocolateChipCookies["cookingTime"].Value<int>(), Is.EqualTo(25), "Cooking time should be 25 minutes");
                Assert.That(chocolateChipCookies["servings"].Value<int>(), Is.EqualTo(24), "Servings should be 24");
                Assert.That(chocolateChipCookies["ingredients"].Count(), Is.EqualTo(9), "Should have 9 ingredients");
                Assert.That(chocolateChipCookies["instructions"].Count(), Is.EqualTo(7), "Should have 7 instructions");
            });
        }

        [Test]
        public void Test_AddRecipe()
        {
            // Get all Categories first
            var categoryRequest = new RestRequest("/category", Method.Get);
            categoryRequest.AddHeader("Authorization", $"Bearer {token}");
            var categoryResponse = client.Execute(categoryRequest);
            var categories = JArray.Parse(categoryResponse.Content);
            var categoryId = categories[0]["_id"].ToString();

            // Create new recipe
            var newRecipe = new
            {
                title = "Test Recipe",
                ingredients = new[]
                {
                    new { name = "Ingredient 1", quantity = "100g" },
                    new { name = "Ingredient 2", quantity = "200ml" }
                },
                instructions = new[]
                {
                    new { step = "Step 1" },
                    new { step = "Step 2" }
                },
                cookingTime = 30,
                servings = 4,
                category = categoryId
            };

            var createRequest = new RestRequest("/recipe", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(newRecipe);

            var createResponse = client.Execute(createRequest);

            // Response Assertions
            Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code should be 200 OK");
            Assert.That(createResponse.Content, Is.Not.Empty, "Response content should not be empty");

            var createdRecipe = JObject.Parse(createResponse.Content);
            var recipeId = createdRecipe["_id"].ToString();

            // Get created recipe details
            var getRequest = new RestRequest($"/recipe/{recipeId}", Method.Get);
            getRequest.AddHeader("Authorization", $"Bearer {token}");
            var getResponse = client.Execute(getRequest);
            var recipe = JObject.Parse(getResponse.Content);

            // Recipe Fields Assertions
            Assert.Multiple(() =>
            {
                Assert.That(recipe["title"].ToString(), Is.EqualTo("Test Recipe"));
                Assert.That(recipe["cookingTime"].Value<int>(), Is.EqualTo(30));
                Assert.That(recipe["servings"].Value<int>(), Is.EqualTo(4));
                Assert.That(recipe["category"]["_id"].ToString(), Is.EqualTo(categoryId));
                Assert.That(recipe["ingredients"].Count(), Is.EqualTo(2));
                Assert.That(recipe["instructions"].Count(), Is.EqualTo(2));
            });
        }

        [Test]
        public void Test_UpdateRecipe()
        {
            // Get all recipes
            var getAllRequest = new RestRequest("/recipe", Method.Get);
            getAllRequest.AddHeader("Authorization", $"Bearer {token}");
            var getAllResponse = client.Execute(getAllRequest);

            // Get Request Assertions
            Assert.That(getAllResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Get all recipes should return 200 OK");
            Assert.That(getAllResponse.Content, Is.Not.Empty,
                "Response content should not be empty");

            var recipes = JArray.Parse(getAllResponse.Content);
            Assert.That(recipes.Count, Is.GreaterThan(0),
                "At least one recipe should exist");

            // Get the first available recipe
            var recipeToUpdate = recipes.First;
            var recipeId = recipeToUpdate["_id"].ToString();
            var originalTitle = recipeToUpdate["title"].ToString();

            Console.WriteLine($"Attempting to update recipe: {originalTitle}"); // Debug information

            // Create a new unique title by appending "Updated" and timestamp
            var newTitle = $"{originalTitle} Updated {DateTime.Now.Ticks}";
            var newServings = 4;

            // Update recipe
            var updateRequest = new RestRequest($"/recipe/{recipeId}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddJsonBody(new
            {
                title = newTitle,
                servings = newServings
            });

            var updateResponse = client.Execute(updateRequest);

            // Update Response Assertions
            Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Update should return 200 OK");
            Assert.That(updateResponse.Content, Is.Not.Empty,
                "Update response should not be empty");

            // Get updated recipe
            var getUpdatedRequest = new RestRequest($"/recipe/{recipeId}", Method.Get);
            getUpdatedRequest.AddHeader("Authorization", $"Bearer {token}");
            var getUpdatedResponse = client.Execute(getUpdatedRequest);
            var updatedRecipe = JObject.Parse(getUpdatedResponse.Content);

            // Update Recipe Fields Assertions
            Assert.Multiple(() =>
            {
                Assert.That(updatedRecipe["title"].ToString(), Is.EqualTo(newTitle),
                    "Recipe title should be updated");
                Assert.That(updatedRecipe["servings"].Value<int>(), Is.EqualTo(newServings),
                    "Recipe servings should be updated");
            });
        }

        [Test]
        public void Test_DeleteRecipe()
        {
            // Get all recipes
            var getAllRequest = new RestRequest("/recipe", Method.Get);
            getAllRequest.AddHeader("Authorization", $"Bearer {token}");
            var getAllResponse = client.Execute(getAllRequest);

            // Get Request Assertions
            Assert.That(getAllResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Status code should be 200 OK");
            Assert.That(getAllResponse.Content, Is.Not.Empty, "Response content should not be empty");

            var recipes = JArray.Parse(getAllResponse.Content);
            Assert.That(recipes.Count, Is.GreaterThan(0), "At least one recipe should exist");

            // Get the first available recipe instead of looking for a specific one
            var recipeToDelete = recipes.First;
            var recipeId = recipeToDelete["_id"].ToString();
            var recipeTitle = recipeToDelete["title"].ToString();

            Console.WriteLine($"Attempting to delete recipe: {recipeTitle}"); // Debug information

            // Delete recipe
            var deleteRequest = new RestRequest($"/recipe/{recipeId}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            var deleteResponse = client.Execute(deleteRequest);

            // Delete Response Assertions
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Delete request should return 200 OK");

            // Verify deletion
            var verifyRequest = new RestRequest($"/recipe/{recipeId}", Method.Get);
            verifyRequest.AddHeader("Authorization", $"Bearer {token}");
            var verifyResponse = client.Execute(verifyRequest);

            Assert.That(verifyResponse.Content, Is.EqualTo("null"),
                $"Recipe {recipeTitle} should be deleted and return null");
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}