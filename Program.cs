using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var app = WebApplication.CreateBuilder().Build();

app.Run(async (HttpContext context) => {
    string path = context.Request.Path;
    string method = context.Request.Method;
    context.Response.StatusCode = 200;
    if(path == "/" || path == "/Home")
    {
        await context.Response.WriteAsync("You are in the Home Page");
    }
    else if(path == "/Contact")
    {
        await context.Response.WriteAsync("You are in the Contact Page");
    }
    else if(method == "POST" && path == "/Product")
    {
        Stream body = context.Request.Body;
        StreamReader reader = new StreamReader(body);
        string data = await reader.ReadToEndAsync();
        string id = string.Empty, name = string.Empty;
        /* StringValues are used as the values for query parameters because a single key can have multiple values
        E.g. `Name=Yemi&Age=19&Name=Abdulazeez` */
        Dictionary<string, StringValues> dataDict = QueryHelpers.ParseQuery(data);
        if(dataDict.ContainsKey("id")) id = dataDict["id"]!;
        if(dataDict.ContainsKey("name")) name = dataDict["name"]!;
        await context.Response.WriteAsync($"ID: {id}; Name: {name}");
    }
    else if(path == "/Product")
    {
        var query = context.Request.Query;
        if(query.ContainsKey("id") && query.ContainsKey("name"))
        {
            string id = query["id"].ToString();
            string name = $"{query["name"]}" ?? "";
            await context.Response.WriteAsync($"You selected the prodcut with ID: {id} and name: {name}");
            return;
        }
        await context.Response.WriteAsync("You are in the products Page");
    }
    else{
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("The page you are looking for cannot be found");
    }
});
app.Run();
