using AspnetcoreWebapi.Services.Registration;

namespace AspnetcoreWebapi.Refactored.Startup;

public static partial class EndpointMapper
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        app.SendMessage();
        app.ReceiveMessage();

        return app;
    }

    //Send message to kafka producer
    public static WebApplication SendMessage(this WebApplication app)
    {
        app.MapGet("/send/{count?}", (int? count, IKafkaRegistration registration) => {
            //return registration.SearchChuckJokes(topic);
            return "registration.SearchChuckJokes(count)";
        });

        // app.MapPost("/jokebycategory/{category}", (string category, IKafkaRegistration registration) => {
        //     //return registration.GetJokeByCategory(category);
        //     return "registration.GetJokeByCategory(category)";
        // });

        return app;
    }
    
    //Receive message from kafka consumer
    public static WebApplication ReceiveMessage(this WebApplication app)
    {
        app.MapPut("/receive", (IKafkaRegistration registration) =>
        {
            //return registration.Joke();
            return "receive";
        });

        return app;
    }
}

