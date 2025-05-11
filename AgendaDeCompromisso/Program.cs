using System.Globalization;
using AgendaDeCompromisso.Modelos;

CultureInfo culturaBrasileira = new("pt-BR");

Console.WriteLine("\nCadastrando novo Usuário");

Usuario usuario;

Console.Write("\nDigite o nome do usuário: ");
string nome = Console.ReadLine();

try {
    usuario = new(nome);
    Console.WriteLine("\nUsuário criado com sucesso");
    Console.WriteLine($"Nome: {usuario.NomeUsuario}");
} catch (Exception e) {
    Console.WriteLine($"\nErro ao criar usuário: {e.Message}");
    return;
}

// Novo trecho para cadastrar Local (mantendo seu estilo)
Console.WriteLine("\nCadastrando Local do Compromisso");
Console.Write("Nome do Local: ");
string nomeLocal = Console.ReadLine();
Console.Write("Endereço: ");
string enderecoLocal = Console.ReadLine();

Local local = new Local(nomeLocal, enderecoLocal);

Console.WriteLine("\nCadastrando novo Compromisso");

DateTime? dataCompromisso = null;
TimeSpan? horaCompromisso = null;
string? descricaoCompromisso = null;

while (dataCompromisso == null) {
    Console.Write("Informe data para reserva (dd/MM/yyyy): ");
    var dataDigitada = Console.ReadLine();
    try {
        var data = DateTime.ParseExact(dataDigitada, "dd/MM/yyyy", culturaBrasileira);
        dataCompromisso = data;
    } catch (FormatException) {
        Console.WriteLine($"{dataDigitada} não é uma data válida");
    }
}

while (horaCompromisso == null) {
    Console.Write("Informe hora para a reserva (HH:mm): ");
    var horaDigitada = Console.ReadLine();
    try {
        var hora = TimeSpan.ParseExact(horaDigitada, "hh\\:mm", culturaBrasileira);
        horaCompromisso = hora;
    } catch {
        Console.WriteLine($"{horaDigitada} não é uma hora válida");
    }
}

while (descricaoCompromisso == null) {
    Console.Write("Informe a descrição da sala para reserva: ");
    descricaoCompromisso = Console.ReadLine();
}

try {
    Compromisso compromisso = new(
        (DateTime)dataCompromisso, 
        (TimeSpan)horaCompromisso, 
        descricaoCompromisso, 
        usuario,
        local // Novo parâmetro
    );
    
    Console.WriteLine("Compromisso criado com sucesso!\n");
    Console.WriteLine(compromisso);
    
    // Trecho opcional para participantes (pode ser comentado)
    Console.WriteLine("\nAdicionar participante? (S/N)");
    if (Console.ReadLine()?.ToUpper() == "S") {
        Console.Write("Nome: ");
        string nomePart = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        
        compromisso.AdicionarParticipante(new Participante(nomePart, email));
    }
} catch (ArgumentException e) {
    Console.WriteLine("Erro na reserva: \n" + e.Message);
    return;
}