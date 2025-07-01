using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;


namespace TSAGroup_Tec.Tests;

public class TaskEndpointTest(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task GetTasks_ReturnOk()
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync("/api/tasks");
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetTaskById_ReturnOk()
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync("/api/tasks/1");
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

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

    [Fact]
    public async Task DeleteTask_ReturnNoContent()
    {
        var client = factory.CreateClient();
        var response = await client.DeleteAsync("/api/tasks/1");
        Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
    }
}