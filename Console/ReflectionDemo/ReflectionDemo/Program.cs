using ReflectionDemo.Model;

Console.WriteLine("Hello, World!");

var todos = new List<Todo>();

todos.Add(new Todo { Id = 1, Name = "Todo1", Location = "Vilnius" });
todos.Add(new Todo { Id = 2, Name = "Todo2" });

foreach (var todo in todos)
{
    var properties = todo.GetType().GetProperties();

    var todoPrintInfo = "";

    foreach (var property in properties.Where(p => p.PropertyType == typeof(string)))
    {
        todoPrintInfo += $"{property.Name}: {GetPropValue(todo, property.Name)} ";
    }


    Console.WriteLine(todoPrintInfo);
}

static object GetPropValue(object src, string propName)
{
    return src.GetType().GetProperty(propName).GetValue(src, null);
}
