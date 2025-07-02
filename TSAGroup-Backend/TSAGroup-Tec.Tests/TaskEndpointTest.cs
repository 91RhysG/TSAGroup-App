using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;


namespace TSAGroup_Tec.Tests;

/// <summary>
/// The TaskEndpointTest class is used to test the Task API endpoints.
/// </summary>
/// <param name="factory"></param>
public class TaskEndpointTest(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    /// <summary>
    /// A test to verify that the Task API is reachable and returns a 200 OK status code.
    /// </summary>
    [Fact]
    public async Task GetTasks_ReturnOk()
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync("/api/tasks");
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    /// <summary>
    /// A test to verify that a specific task can be retrieved by its ID and returns a 200 OK status code.
    /// </summary>
    [Fact]
    public async Task GetTaskById_ReturnOk()
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync("/api/tasks/1");
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    /// <summary>
    /// A test to verify that creating a new task returns a 201 Created status code.
    /// </summary>
    [Fact]
    public async Task CreateTask_ReturnCreated()
    {
        var client = factory.CreateClient();
        var task = new
        {
            Id = 100,
            Name = "Test Task",
            Description = "This is a test task.",
            Status = Enums.TaskStatus.InProgress,
            CreatedAt = DateTime.UtcNow
        };
        var response = await client.PostAsJsonAsync("/api/tasks", task);
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
    }

    /// <summary>
    /// A test to verify that updating an existing task returns a 200 OK status code.
    /// </summary>
    [Fact]
    public async Task UpdateTask_ReturnOk()
    {
        var client = factory.CreateClient();
        var task = new
        {
            Id = 100,
            Name = "Updated Task",
            Description = "This is an updated test task.",
            Status = Enums.TaskStatus.Completed,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CompletedAt = DateTime.UtcNow
        };
        var response = await client.PutAsJsonAsync("/api/tasks/100", task);
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    /// <summary>
    /// A test to verify that deleting a task returns a 204 No Content status code, indicating successful deletion.
    /// </summary>
    [Fact]
    public async Task DeleteTask_ReturnNoContent()
    {
        var client = factory.CreateClient();
        var response = await client.DeleteAsync("/api/tasks/1");
        Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
    }
}