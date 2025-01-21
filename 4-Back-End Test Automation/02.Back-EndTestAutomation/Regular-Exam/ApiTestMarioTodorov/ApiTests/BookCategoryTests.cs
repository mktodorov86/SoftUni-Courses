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
            string categoryId;

            // Step 1: Create a new category
            {
                var createRequest = new RestRequest("category", Method.Post);
                createRequest.AddHeader("Authorization", $"Bearer {token}");
                createRequest.AddJsonBody(new { title = "Fictional Literature" });

                var createResponse = client.Execute(createRequest);
                var createContent = JObject.Parse(createResponse.Content);

                // Assert creation
                Assert.Multiple(() =>
                {
                    Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                        "Category creation should return 200 OK");
                    Assert.That(createContent["_id"]?.ToString(), Is.Not.Null.Or.Empty,
                        "Category ID should not be null or empty");
                    Assert.That(createContent["title"]?.ToString(), Is.EqualTo("Fictional Literature"),
                        "Category title should match input");
                });

                categoryId = createContent["_id"].ToString();
            }

            // Step 2: Get all categories
            {
                var getAllRequest = new RestRequest("category", Method.Get);
                getAllRequest.AddHeader("Authorization", $"Bearer {token}");

                var getAllResponse = client.Execute(getAllRequest);

                // Assert get all
                Assert.Multiple(() =>
                {
                    // Verify response code
                    Assert.That(getAllResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                        "Get all categories should return 200 OK");

                    // Verify content is not empty
                    Assert.That(getAllResponse.Content, Is.Not.Empty,
                        "Categories list should not be empty");

                    // Verify response is a JSON array
                    Assert.That(getAllResponse.Content.TrimStart().StartsWith("["),
                        "Response should be a JSON array (should start with '[')");
                    Assert.That(getAllResponse.Content.TrimEnd().EndsWith("]"),
                        "Response should be a JSON array (should end with ']')");

                    // Parse and verify array
                    var categories = JArray.Parse(getAllResponse.Content);
                    Assert.That(categories, Is.Not.Null, "Categories should parse as JSON array");
                    Assert.That(categories.Type, Is.EqualTo(JTokenType.Array),
                        "Response should be a JSON array");

                    // Verify array has at least one category
                    Assert.That(categories.Count, Is.GreaterThan(0),
                        "Should have at least one category");

                    // Find and verify the new category
                    var newCategory = categories.FirstOrDefault(c => c["_id"]?.ToString() == categoryId);
                    Assert.That(newCategory, Is.Not.Null,
                        "Newly created category should be in the list");
                    Assert.That(newCategory["title"]?.ToString(), Is.EqualTo("Fictional Literature"),
                        "Category title should match in list");
                });
            }

            // Step 3: Edit the category
            {
                var updateRequest = new RestRequest($"category/{categoryId}", Method.Put);
                updateRequest.AddHeader("Authorization", $"Bearer {token}");
                updateRequest.AddJsonBody(new { title = "Updated Fictional Literature" });

                var updateResponse = client.Execute(updateRequest);

                // Assert update
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Category update should return 200 OK");
            }

            // Step 4: Verify the update
            {
                var verifyRequest = new RestRequest($"category/{categoryId}", Method.Get);
                verifyRequest.AddHeader("Authorization", $"Bearer {token}");

                var verifyResponse = client.Execute(verifyRequest);
                var updatedCategory = JObject.Parse(verifyResponse.Content);

                // Assert verification
                Assert.Multiple(() =>
                {
                    Assert.That(verifyResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                        "Get updated category should return 200 OK");
                    Assert.That(verifyResponse.Content, Is.Not.Empty,
                        "Updated category content should not be empty");
                    Assert.That(updatedCategory["title"]?.ToString(), Is.EqualTo("Updated Fictional Literature"),
                        "Category title should be updated");
                });
            }

            // Step 5: Delete the category
            {
                var deleteRequest = new RestRequest($"category/{categoryId}", Method.Delete);
                deleteRequest.AddHeader("Authorization", $"Bearer {token}");

                var deleteResponse = client.Execute(deleteRequest);

                // Assert deletion
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "Category deletion should return 200 OK");
            }

            // Step 6: Verify the deletion
            {
                var finalVerifyRequest = new RestRequest($"category/{categoryId}", Method.Get);
                finalVerifyRequest.AddHeader("Authorization", $"Bearer {token}");

                var finalVerifyResponse = client.Execute(finalVerifyRequest);

                // Assert final verification
                Assert.That(finalVerifyResponse.Content, Is.EqualTo("null"),
                    "Deleted category should return null");
            }
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}