using AgendaDeCompromisso.Modelos;

Console.Write("Digite o nome do usuário: ");
string nome = Console.ReadLine();

try {
    Usuario usuario = new(nome);

    Console.WriteLine("\nUsuário criado com sucesso");
    Console.WriteLine($"Nome: {usuario.NomeUsuario}");
} catch (Exception e) {
    Console.WriteLine($"\nErro ao criar usuário: {e.Message}");
}
