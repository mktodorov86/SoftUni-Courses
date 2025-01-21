using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;


namespace ApiTests
{
    [TestFixture]
    public class BookTests : IDisposable
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
        public void Test_GetAllBooks()
        {
            // Arrange
            var request = new RestRequest("book", Method.Get);
            request.AddHeader("Authorization", $"Bearer {token}");

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.Multiple(() =>
            {
                // Response Assertions
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                    "HTTP response status code should be 200 OK");
                Assert.That(response.Content, Is.Not.Empty,
                    "Response content should not be empty");

                // Data Structure Assertions
                Assert.That(response.Content.TrimStart().StartsWith("["),
                    "Response should be a JSON array (should start with '[')");
                Assert.That(response.Content.TrimEnd().EndsWith("]"),
                    "Response should be a JSON array (should end with ']')");

                var books = JArray.Parse(response.Content);
                Assert.That(books, Is.Not.Null,
                    "Books should parse as JSON array");
                Assert.That(books.Type, Is.EqualTo(JTokenType.Array),
                    "Response should be a JSON array");
                Assert.That(books.Count, Is.GreaterThan(0),
                    "JSON array should contain at least one book");

                // Book Fields Assertions
                foreach (var book in books)
                {
                    Assert.That(book["title"]?.ToString(), Is.Not.Null.Or.Empty,
                        "Book title should not be null or empty");
                    Assert.That(book["author"]?.ToString(), Is.Not.Null.Or.Empty,
                        "Book author should not be null or empty");
                    Assert.That(book["description"]?.ToString(), Is.Not.Null.Or.Empty,
                        "Book description should not be null or empty");
                    Assert.That(book["price"]?.ToString(), Is.Not.Null.Or.Empty,
                        "Book price should not be null or empty");
                    Assert.That(book["pages"]?.ToString(), Is.Not.Null.Or.Empty,
                        "Book pages should not be null or empty");
                    Assert.That(book["category"]?["title"]?.ToString(), Is.Not.Null.Or.Empty,
                        "Book category should not be null or empty");
                }
            });
        }


        [Test]
        public void Test_GetBookByTitle()
        {
            // First, ensure The Great Gatsby exists
            var categoryRequest = new RestRequest("category", Method.Get);
            categoryRequest.AddHeader("Authorization", $"Bearer {token}");
            var categoryResponse = client.Execute(categoryRequest);
            var categories = JArray.Parse(categoryResponse.Content);
            var categoryId = categories[0]["_id"].ToString();

            // Create The Great Gatsby book
            var newBook = new
            {
                title = "The Great Gatsby",
                author = "F. Scott Fitzgerald",
                description = "A novel set in the Roaring Twenties, exploring themes of wealth, love, and the American Dream.",
                price = 9.99,
                pages = 180,
                category = categoryId
            };

            var createRequest = new RestRequest("book", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(newBook);
            var createResponse = client.Execute(createRequest);

            // Now test getting the book by title
            var getRequest = new RestRequest("book", Method.Get);
            getRequest.AddHeader("Authorization", $"Bearer {token}");

            var response = client.Execute(getRequest);

            // Response Assertions
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "HTTP response status code should be 200 OK");
            Assert.That(response.Content, Is.Not.Empty,
                "Response content should not be empty");

            // Parse content and find The Great Gatsby
            var books = JArray.Parse(response.Content);
            var greatGatsbyBook = books.FirstOrDefault(b =>
                b["title"]?.ToString() == "The Great Gatsby");

            // Data Assertions
            Assert.That(greatGatsbyBook, Is.Not.Null,
                "Book with title 'The Great Gatsby' should be found in the response");

            // Book Fields Assertions
            Assert.That(greatGatsbyBook["author"]?.ToString(), Is.EqualTo("F. Scott Fitzgerald"),
                "The author of 'The Great Gatsby' should be 'F. Scott Fitzgerald'");
        }

        [Test]
        public void Test_AddBook()
        {
            // Step 1: Get all categories
            var categoryRequest = new RestRequest("category", Method.Get);
            categoryRequest.AddHeader("Authorization", $"Bearer {token}");
            var categoryResponse = client.Execute(categoryRequest);

            Assert.That(categoryResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Failed to get categories");
            Assert.That(categoryResponse.Content, Is.Not.Empty,
                "Categories response should not be empty");

            var categories = JArray.Parse(categoryResponse.Content);
            var categoryId = categories[0]["_id"].ToString();

            // Step 2: Create a new book
            var newBook = new
            {
                title = "Test Book Title",
                author = "Test Author Name",
                description = "Test book description",
                price = 19.99,
                pages = 200,
                category = categoryId
            };

            var addRequest = new RestRequest("book", Method.Post);
            addRequest.AddHeader("Authorization", $"Bearer {token}");
            addRequest.AddJsonBody(newBook);

            // Step 3: Add the book and verify response
            var addResponse = client.Execute(addRequest);

            Assert.That(addResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Book creation should return 200 OK");
            Assert.That(addResponse.Content, Is.Not.Empty,
                "Book creation response should not be empty");

            // Step 4: Get the created book's ID
            var addedBook = JObject.Parse(addResponse.Content);
            Assert.That(addedBook["_id"]?.ToString(), Is.Not.Null.Or.Empty,
                "Created book should have an ID");
            var bookId = addedBook["_id"].ToString();

            // Step 5: Get book details
            var getRequest = new RestRequest($"book/{bookId}", Method.Get);
            getRequest.AddHeader("Authorization", $"Bearer {token}");
            var getResponse = client.Execute(getRequest);

            // Step 6: Verify get response
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Get book details should return 200 OK");
            Assert.That(getResponse.Content, Is.Not.Empty,
                "Get book details response should not be empty");

            // Step 7: Verify book fields
            var retrievedBook = JObject.Parse(getResponse.Content);
            Assert.Multiple(() =>
            {
                // Title verification
                Assert.That(retrievedBook["title"]?.ToString(), Is.EqualTo(newBook.title),
                    "Book title should match input");

                // Author verification
                Assert.That(retrievedBook["author"]?.ToString(), Is.EqualTo(newBook.author),
                    "Book author should match input");

                // Price verification
                Assert.That(double.Parse(retrievedBook["price"]?.ToString()), Is.EqualTo(newBook.price),
                    "Book price should match input");

                // Pages verification
                Assert.That(int.Parse(retrievedBook["pages"]?.ToString()), Is.EqualTo(newBook.pages),
                    "Book pages should match input");

                // Category verification
                Assert.That(retrievedBook["category"], Is.Not.Null,
                    "Book category should not be null");
                Assert.That(retrievedBook["category"]["_id"]?.ToString(), Is.EqualTo(categoryId),
                    "Category ID should match input");
            });
        }
        [Test]
        public void Test_UpdateBook()
        {
            // First create "The Catcher in the Rye" if it doesn't exist
            var categoryRequest = new RestRequest("category", Method.Get);
            categoryRequest.AddHeader("Authorization", $"Bearer {token}");
            var categoryResponse = client.Execute(categoryRequest);
            var categories = JArray.Parse(categoryResponse.Content);
            var categoryId = categories[0]["_id"].ToString();

            // Create the book
            var newBook = new
            {
                title = "The Catcher in the Rye",
                author = "J.D. Salinger",
                description = "A novel about teenage alienation and angst.",
                price = 9.99,
                pages = 234,
                category = categoryId
            };

            var createRequest = new RestRequest("book", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(newBook);
            var createResponse = client.Execute(createRequest);
            var createdBook = JObject.Parse(createResponse.Content);
            var bookId = createdBook["_id"].ToString();

            // Step 1: Get all books
            var getRequest = new RestRequest("book", Method.Get);
            getRequest.AddHeader("Authorization", $"Bearer {token}");
            var getResponse = client.Execute(getRequest);

            // Step 2: Get Request Assertions
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Get request should return 200 OK");
            Assert.That(getResponse.Content, Is.Not.Empty,
                "Get response content should not be empty");

            var books = JArray.Parse(getResponse.Content);
            var bookToUpdate = books.FirstOrDefault(b => b["title"]?.ToString() == "The Catcher in the Rye");
            Assert.That(bookToUpdate, Is.Not.Null,
                "Book 'The Catcher in the Rye' should exist in the response");

            // Step 3: Update the book
            var updateData = new
            {
                title = "Updated Book Title",
                author = "Updated Author"
            };

            var updateRequest = new RestRequest($"book/{bookId}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddJsonBody(updateData);
            var updateResponse = client.Execute(updateRequest);

            // Step 4: Update Request Assertions
            Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Update request should return 200 OK");
            Assert.That(updateResponse.Content, Is.Not.Empty,
                "Update response content should not be empty");

            // Step 5: Updated Fields Assertions
            var updatedBook = JObject.Parse(updateResponse.Content);
            Assert.Multiple(() =>
            {
                Assert.That(updatedBook["title"]?.ToString(), Is.EqualTo("Updated Book Title"),
                    "Book title should be updated to 'Updated Book Title'");
                Assert.That(updatedBook["author"]?.ToString(), Is.EqualTo("Updated Author"),
                    "Book author should be updated to 'Updated Author'");
            });
        }
        [Test]
        public void Test_DeleteBook()
        {
            // First create "To Kill a Mockingbird" if it doesn't exist
            var categoryRequest = new RestRequest("category", Method.Get);
            categoryRequest.AddHeader("Authorization", $"Bearer {token}");
            var categoryResponse = client.Execute(categoryRequest);
            var categories = JArray.Parse(categoryResponse.Content);
            var categoryId = categories[0]["_id"].ToString();

            // Create the book
            var newBook = new
            {
                title = "To Kill a Mockingbird",
                author = "Harper Lee",
                description = "A story of racial injustice and the loss of innocence in the American South.",
                price = 12.99,
                pages = 281,
                category = categoryId
            };

            var createRequest = new RestRequest("book", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(newBook);
            var createResponse = client.Execute(createRequest);
            var createdBook = JObject.Parse(createResponse.Content);
            var bookId = createdBook["_id"].ToString();

            // Step 1: Get all books
            var getRequest = new RestRequest("book", Method.Get);
            getRequest.AddHeader("Authorization", $"Bearer {token}");
            var getResponse = client.Execute(getRequest);

            // Step 2: Get Request Assertions
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Get request should return 200 OK");
            Assert.That(getResponse.Content, Is.Not.Empty,
                "Get response content should not be empty");

            var books = JArray.Parse(getResponse.Content);
            var bookToDelete = books.FirstOrDefault(b => b["title"]?.ToString() == "To Kill a Mockingbird");
            Assert.That(bookToDelete, Is.Not.Null,
                "Book 'To Kill a Mockingbird' should exist in the response");

            // Step 3: Delete the book
            var deleteRequest = new RestRequest($"book/{bookId}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            var deleteResponse = client.Execute(deleteRequest);

            // Step 4: Delete Response Assertion
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                "Delete request should return 200 OK");

            // Step 5: Verify deletion by getting book details
            var verifyRequest = new RestRequest($"book/{bookId}", Method.Get);
            verifyRequest.AddHeader("Authorization", $"Bearer {token}");
            var verifyResponse = client.Execute(verifyRequest);

            // Step 6: Verify response content
            Assert.That(verifyResponse.Content, Is.EqualTo("null"),
                "Get request for deleted book should return 'null'");
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}