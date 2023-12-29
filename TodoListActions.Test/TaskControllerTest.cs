namespace TodoListActions.Test
{
    public class TaskControllerTest
    {
        [Fact]
        public async Task GetById_InputIs1_ReturnsOk()
        {
            var factory = new TodoListActionsWebApplicationFactory();
            var client = factory.CreateClient();

            var response = await client.GetAsync("/api/Task/id=1");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        // failing test
        [Fact]
        public async Task GetById_InputIs1_ReturnsBadRequest()
        {
            var factory = new TodoListActionsWebApplicationFactory();
            var client = factory.CreateClient();

            var response = await client.GetAsync("/api/Task/id=1");
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
