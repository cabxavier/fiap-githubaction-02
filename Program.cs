using Bogus;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get;set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
}

public class Program
{
    public static void Main()
    {
        var faker = new Faker<Cliente>()
            .RuleFor(c => c.Id, f => f.IndexFaker + 1)
            .RuleFor(c => c.Nome, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.DataNascimento, f => f.Date.Past(30));

        List<Cliente> clientes = faker.Generate(10);

        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Id: {cliente.Id}, Nome: {cliente.Nome}, Email: {cliente.Email}, DataNascimento: {cliente.DataNascimento.ToString("dd/mm/yyyy")}");
        }

        Console.ReadKey();
    }
}