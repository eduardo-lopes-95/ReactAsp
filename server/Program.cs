using Microsoft.OpenApi.Models;
using server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP.NET with ReactJS", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ASP.NET with ReactJS";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API serving a very simple Post model.");
    swaggerUIOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.MapGet("/get-all-posts", async () => await PostsRepository.GetPostsAsync())
    .WithTags("Posts Endpoints");

app.MapGet("/get-post-by-id/{postId}", async (int postId) =>
{
    var postToReturn = await PostsRepository.GetPostByIdAsync(postId);

    if (postToReturn != null)
    {
        return Results.Ok(postToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
    
}).WithTags("Posts Endpoints");

app.MapPost("/create-post", async (Post postToCreate) =>
{
    var createSucessful = await PostsRepository.CreatePostAsync(postToCreate);

    if (createSucessful)
    {
        return Results.Ok("Create Sucessful");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Posts Endpoints");

app.MapPut("/update-post", async (Post postToUpdate) =>
{
    var updateSucessful = await PostsRepository.UpdatePostAsync(postToUpdate);

    if (updateSucessful)
    {
        return Results.Ok(updateSucessful);
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Posts Endpoints");

app.MapDelete("/delete-post-by-id/{postId}", async (int postId) =>
{
    var deleteSucessful = await PostsRepository.DeletePostAsync(postId);

    if (deleteSucessful)
    {
        return Results.Ok("Delete Sucessful");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Posts Endpoints");

app.Run();