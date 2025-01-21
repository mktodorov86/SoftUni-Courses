using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class CategoryTests : IDisposable
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
        public void Test_CategoryLifecycle_RecipeBook()
        {
            // Step 1: Create a new category
            var createRequest = new RestRequest("/category", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(new { name = "Vegan Recipes" });

            var createResponse = client.Execute(createRequest);

            Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Create category should return 200 OK");

            var createdCategory = JObject.Parse(createResponse.Content);
            var categoryId = createdCategory["_id"].ToString();
            Assert.That(categoryId, Is.Not.Null.Or.Empty, "Category ID should not be null or empty");

            // Step 2: Get all categories
            var getAllRequest = new RestRequest("/category", Method.Get);
            getAllRequest.AddHeader("Authorization", $"Bearer {token}");

            var getAllResponse = client.Execute(getAllRequest);

            Assert.That(getAllResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Get all categories should return 200 OK");
            Assert.That(getAllResponse.Content, Is.Not.Empty, "Categories response should not be empty");

            var categories = JArray.Parse(getAllResponse.Content);
            Assert.That(categories.Type, Is.EqualTo(JTokenType.Array), "Response should be a JSON array");
            Assert.That(categories.Count, Is.GreaterThan(0), "Should contain at least one category");

            // Step 3: Get category by ID
            var getByIdRequest = new RestRequest($"/category/{categoryId}", Method.Get);
            getByIdRequest.AddHeader("Authorization", $"Bearer {token}");

            var getByIdResponse = client.Execute(getByIdRequest);

            Assert.That(getByIdResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Get category by ID should return 200 OK");
            Assert.That(getByIdResponse.Content, Is.Not.Empty, "Category response should not be empty");

            var retrievedCategory = JObject.Parse(getByIdResponse.Content);
            Assert.That(retrievedCategory["_id"].ToString(), Is.EqualTo(categoryId), "Retrieved category ID should match created ID");
            Assert.That(retrievedCategory["name"].ToString(), Is.EqualTo("Vegan Recipes"), "Retrieved category name should match");

            // Step 4: Edit the category
            var updateRequest = new RestRequest($"/category/{categoryId}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddJsonBody(new { name = "Healthy Vegan Recipes" });

            var updateResponse = client.Execute(updateRequest);

            Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Update category should return 200 OK");

            // Step 5: Verify the update
            var verifyUpdateRequest = new RestRequest($"/category/{categoryId}", Method.Get);
            verifyUpdateRequest.AddHeader("Authorization", $"Bearer {token}");

            var verifyUpdateResponse = client.Execute(verifyUpdateRequest);

            Assert.That(verifyUpdateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Verify update should return 200 OK");
            Assert.That(verifyUpdateResponse.Content, Is.Not.Empty, "Updated category response should not be empty");

            var updatedCategory = JObject.Parse(verifyUpdateResponse.Content);
            Assert.That(updatedCategory["name"].ToString(), Is.EqualTo("Healthy Vegan Recipes"), "Category name should be updated");

            // Step 6: Delete the category
            var deleteRequest = new RestRequest($"/category/{categoryId}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");

            var deleteResponse = client.Execute(deleteRequest);

            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Delete category should return 200 OK");

            // Step 7: Verify the deletion
            var verifyDeleteRequest = new RestRequest($"/category/{categoryId}", Method.Get);
            verifyDeleteRequest.AddHeader("Authorization", $"Bearer {token}");

            var verifyDeleteResponse = client.Execute(verifyDeleteRequest);
            Assert.That(verifyDeleteResponse.Content, Is.EqualTo("null"), "Deleted category should return null");
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}