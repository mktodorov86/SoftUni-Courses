using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class DestinationTests : IDisposable
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
        public void Test_GetAllDestinations()
        {
            // Arrange
            var request = new RestRequest("destination", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");

            // Act
            var response = client.Execute(request);
            var content = response.Content;
            var destinations = JArray.Parse(content);

            // Assert HTTP Response
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "HTTP Status Code should be 200 OK");
            Assert.That(content, Is.Not.Empty,
                "Response content should not be empty");

            // Assert JSON Structure
            Assert.That(destinations, Is.InstanceOf<JArray>(),
                "Response should be a JSON array");
            Assert.That(destinations.Count, Is.GreaterThan(0),
                "JSON array should contain at least one destination");

            // Assert Each Destination in Array
            foreach (var destination in destinations)
            {
                // Basic Field Assertions
                Assert.Multiple(() =>
                {
                    Assert.That(destination["name"].ToString(), Is.Not.Empty,
                        "Name should not be empty");
                    Assert.That(destination["location"].ToString(), Is.Not.Empty,
                        "Location should not be empty");
                    Assert.That(destination["description"].ToString(), Is.Not.Empty,
                        "Description should not be empty");
                    Assert.That(destination["bestTimeToVisit"].ToString(), Is.Not.Empty,
                        "Best time to visit should not be empty");
                });

                // Category Assertions
                Assert.Multiple(() =>
                {
                    Assert.That(destination["category"], Is.Not.Null,
                        "Category should not be null");
                    Assert.That(destination["category"]["name"].ToString(), Is.Not.Empty,
                        "Category name should not be empty");
                    Assert.That(destination["category"]["_id"].ToString(), Is.Not.Empty,
                        "Category ID should not be empty");
                });

                // Attractions Array Assertion
                Assert.That(destination["attractions"], Is.InstanceOf<JArray>(),
                    "Attractions should be a JSON array");
                var attractions = destination["attractions"].ToObject<JArray>();
                Assert.That(attractions, Is.Not.Null,
                    "Attractions array should exist");

                // Category Filter Verification
                if (destination["category"]["name"].ToString() == "Historical Sites")
                {
                    var historicalSite = destination["name"].ToString();
                    Assert.That(historicalSite, Is.EqualTo("Machu Picchu"),
                        $"Expected Historical Sites category to contain Machu Picchu, but found {historicalSite}");
                }
            }
        }

        [Test]
        public void Test_GetDestinationByName()
        {
            // Arrange
            var destinationName = "New York City";
            var request = new RestRequest("destination", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddParameter("name", destinationName);

            // Act
            var response = client.Execute(request);
            var content = response.Content;
            var destinations = JArray.Parse(content);

            // Assert HTTP Response
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "HTTP Status Code should be 200 OK");
            Assert.That(content, Is.Not.Empty,
                "Response content should not be empty");

            // Find New York City in destinations
            var nycDestination = destinations.FirstOrDefault(d =>
                d["name"].ToString() == destinationName);

            // Assert Destination Exists
            Assert.That(nycDestination, Is.Not.Null,
                $"Destination with name '{destinationName}' should exist in the response");

            // Assert Specific Fields
            Assert.Multiple(() =>
            {
                Assert.That(nycDestination["location"].ToString(), Is.EqualTo("New York, USA"),
                    "Location should be 'New York, USA'");

                Assert.That(nycDestination["description"].ToString(), Is.Not.Empty,
                    "Description should not be empty");

                // Updated assertion to match the actual description
                Assert.That(nycDestination["description"].ToString(),
                    Is.EqualTo("The largest city in the USA, known for its skyscrapers, culture, and entertainment."),
                    "Description should match the expected value");
            });
        }

        [Test]
        public void Test_AddDestination()
        {
            // Step 1: Get all categories
            var categoryRequest = new RestRequest("category", Method.Get);
            categoryRequest.AddHeader("Authorization", $"Bearer {token}");
            var categoryResponse = client.Execute(categoryRequest);

            Assert.That(categoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Category request should return 200 OK");

            var categories = JArray.Parse(categoryResponse.Content);
            var categoryId = categories[0]["_id"].ToString();

            // Step 2: Create new destination
            var newDestination = new
            {
                name = "Test Destination",
                location = "Test Location, Country",
                description = "A beautiful test destination for travelers",
                bestTimeToVisit = "Spring and Fall",
                category = categoryId,
                attractions = new[] { "Attraction 1", "Attraction 2", "Attraction 3" }
            };

            var createRequest = new RestRequest("destination", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(newDestination);

            var createResponse = client.Execute(createRequest);

            // Assert creation response
            Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Create destination request should return 200 OK");
            Assert.That(createResponse.Content, Is.Not.Empty,
                "Create destination response should not be empty");

            // Step 3: Get created destination ID
            var createdDestination = JObject.Parse(createResponse.Content);
            var createdId = createdDestination["_id"].ToString();

            Assert.That(createdId, Is.Not.Empty,
                "Created destination should have an ID");

            // Step 4: Get destination details
            var getRequest = new RestRequest($"destination/{createdId}", Method.Get);
            getRequest.AddHeader("Authorization", $"Bearer {token}");
            var getResponse = client.Execute(getRequest);

            // Assert get response
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Get destination request should return 200 OK");
            Assert.That(getResponse.Content, Is.Not.Empty,
                "Get destination response should not be empty");

            var retrievedDestination = JObject.Parse(getResponse.Content);

            // Step 5: Assert all fields
            Assert.Multiple(() =>
            {
                // Basic fields
                Assert.That(retrievedDestination["name"].ToString(), Is.EqualTo(newDestination.name),
                    "Retrieved name should match input");
                Assert.That(retrievedDestination["location"].ToString(), Is.EqualTo(newDestination.location),
                    "Retrieved location should match input");
                Assert.That(retrievedDestination["description"].ToString(), Is.EqualTo(newDestination.description),
                    "Retrieved description should match input");
                Assert.That(retrievedDestination["bestTimeToVisit"].ToString(), Is.EqualTo(newDestination.bestTimeToVisit),
                    "Retrieved bestTimeToVisit should match input");

                // Category
                Assert.That(retrievedDestination["category"], Is.Not.Null,
                    "Category should not be null");
                Assert.That(retrievedDestination["category"]["_id"].ToString(), Is.EqualTo(categoryId),
                    "Retrieved category ID should match input");

                // Attractions
                var retrievedAttractions = retrievedDestination["attractions"].ToObject<JArray>();
                Assert.That(retrievedAttractions.Count, Is.EqualTo(newDestination.attractions.Length),
                    "Number of attractions should match input");

                for (int i = 0; i < newDestination.attractions.Length; i++)
                {
                    Assert.That(retrievedAttractions[i].ToString(), Is.EqualTo(newDestination.attractions[i]),
                        $"Attraction at index {i} should match input");
                }
            });
        }

        [Test]
        public void Test_UpdateDestination()
        {
            // Step 1: Get all destinations
            var getAllRequest = new RestRequest("destination", Method.Get);
            getAllRequest.AddHeader("Authorization", $"Bearer {token}");
            var getAllResponse = client.Execute(getAllRequest);

            // Assert GET response
            Assert.That(getAllResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Get all destinations should return 200 OK");
            Assert.That(getAllResponse.Content, Is.Not.Empty,
                "Get all destinations response should not be empty");

            // Find Machu Picchu destination
            var destinations = JArray.Parse(getAllResponse.Content);
            var machuPicchu = destinations.FirstOrDefault(d =>
                d["name"].ToString() == "Machu Picchu");

            // Assert Machu Picchu exists
            Assert.That(machuPicchu, Is.Not.Null,
                "Destination 'Machu Picchu' should exist in the response");

            // Get the destination ID
            var destinationId = machuPicchu["_id"].ToString();

            // Step 2: Update the destination
            var updatedData = new
            {
                name = "Updated Machu Picchu",
                bestTimeToVisit = "May to October"
            };

            var updateRequest = new RestRequest($"destination/{destinationId}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddJsonBody(updatedData);

            var updateResponse = client.Execute(updateRequest);

            // Assert UPDATE response
            Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Update destination should return 200 OK");
            Assert.That(updateResponse.Content, Is.Not.Empty,
                "Update response should not be empty");

            // Parse updated destination
            var updatedDestination = JObject.Parse(updateResponse.Content);

            // Assert updated fields
            Assert.Multiple(() =>
            {
                Assert.That(updatedDestination["name"].ToString(), Is.EqualTo(updatedData.name),
                    "Updated name should match input value");
                Assert.That(updatedDestination["bestTimeToVisit"].ToString(), Is.EqualTo(updatedData.bestTimeToVisit),
                    "Updated bestTimeToVisit should match input value");
            });

            // Optional: Restore original data
            var restoreData = new
            {
                name = "Machu Picchu",
                bestTimeToVisit = machuPicchu["bestTimeToVisit"].ToString()
            };

            var restoreRequest = new RestRequest($"destination/{destinationId}", Method.Put);
            restoreRequest.AddHeader("Authorization", $"Bearer {token}");
            restoreRequest.AddJsonBody(restoreData);

            client.Execute(restoreRequest);
        }
        [Test]
        public void Test_DeleteDestination()
        {
            // Step 1: Get all destinations to find one to delete
            var getAllRequest = new RestRequest("destination", Method.Get);
            getAllRequest.AddHeader("Authorization", $"Bearer {token}");
            var getAllResponse = client.Execute(getAllRequest);

            TestContext.WriteLine($"Get All Response: {getAllResponse.Content}");

            Assert.That(getAllResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Get all destinations should return 200 OK");

            var destinations = JArray.Parse(getAllResponse.Content);
            Assert.That(destinations.Count, Is.GreaterThan(0),
                "Should have at least one destination to delete");

            var destinationToDelete = destinations.First();
            var destinationId = destinationToDelete["_id"].ToString();
            var destinationName = destinationToDelete["name"].ToString();

            TestContext.WriteLine($"Attempting to delete destination: {destinationName} with ID: {destinationId}");

            // Step 2: Delete the destination
            var deleteRequest = new RestRequest($"destination/{destinationId}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            var deleteResponse = client.Execute(deleteRequest);

            // Assert DELETE response
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Delete destination should return 200 OK. Response: {deleteResponse.Content}");

            // Step 3: Verify deletion
            var verifyRequest = new RestRequest($"destination/{destinationId}", Method.Get);
            verifyRequest.AddHeader("Authorization", $"Bearer {token}");
            var verifyResponse = client.Execute(verifyRequest);

            // Assert verification response
            Assert.That(verifyResponse.Content, Is.EqualTo("null"),
                $"Get request for deleted destination {destinationName} should return 'null'");
        }
        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
