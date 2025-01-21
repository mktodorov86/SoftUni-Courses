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
        public void Test_CategoryLifecycle()
        {
            // Step 1: Create a new category
            var createRequest = new RestRequest("/category", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(new { name = "Test Category" });

            var createResponse = client.Execute(createRequest);
            Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Create category should return 200 OK");

            var categoryId = JObject.Parse(createResponse.Content)["_id"].ToString();
            Assert.That(categoryId, Is.Not.Null.Or.Empty, "Category ID should not be null or empty");

            // Step 2: Get all categories
            var getAllRequest = new RestRequest("/category", Method.Get);
            getAllRequest.AddHeader("Authorization", $"Bearer {token}");

            var getAllResponse = client.Execute(getAllRequest);
            Assert.That(getAllResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Get all categories should return 200 OK");

            var categories = JArray.Parse(getAllResponse.Content);
            Assert.That(categories, Is.Not.Empty, "Categories list should not be empty");
            Assert.That(categories.Count, Is.GreaterThan(0), "Should contain at least one category");

            // Step 3: Get category by ID
            var getByIdRequest = new RestRequest($"/category/{categoryId}", Method.Get);
            getByIdRequest.AddHeader("Authorization", $"Bearer {token}");

            var getByIdResponse = client.Execute(getByIdRequest);
            Assert.That(getByIdResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Get category by ID should return 200 OK");

            var category = JObject.Parse(getByIdResponse.Content);
            Assert.That(category["_id"].ToString(), Is.EqualTo(categoryId), "Retrieved category ID should match created ID");
            Assert.That(category["name"].ToString(), Is.EqualTo("Test Category"), "Retrieved category name should match created name");

            // Step 4: Edit the category
            var editRequest = new RestRequest($"/category/{categoryId}", Method.Put);
            editRequest.AddHeader("Authorization", $"Bearer {token}");
            editRequest.AddJsonBody(new { name = "Updated Test Category" });

            var editResponse = client.Execute(editRequest);
            Assert.That(editResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Edit category should return 200 OK");

            // Step 5: Verify Edit
            var verifyEditRequest = new RestRequest($"/category/{categoryId}", Method.Get);
            verifyEditRequest.AddHeader("Authorization", $"Bearer {token}");

            var verifyEditResponse = client.Execute(verifyEditRequest);
            Assert.That(verifyEditResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Verify edit should return 200 OK");

            var updatedCategory = JObject.Parse(verifyEditResponse.Content);
            Assert.That(updatedCategory["name"].ToString(), Is.EqualTo("Updated Test Category"), "Category name should be updated");

            // Step 6: Delete the category
            var deleteRequest = new RestRequest($"/category/{categoryId}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");

            var deleteResponse = client.Execute(deleteRequest);
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Delete category should return 200 OK");

            // Step 7: Verify that the deleted category cannot be found
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