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
} catch (ArgumentException e) {
    Console.WriteLine($"\nErro ao criar usuário: {e.Message}");
    return;
}

Console.WriteLine("\nCadastrando Local do Compromisso");

Console.Write("Nome do Local: ");
string nomeLocal = Console.ReadLine();
Console.Write("Endereço: ");
string enderecoLocal = Console.ReadLine();
Console.Write("Capacidade: ");
string capacidadeLocal = Console.ReadLine();
if (!int.TryParse(capacidadeLocal, out int capacidade))
{
    Console.WriteLine("Capacidade inválida.");
    return;
}

Local local;
try{
    local = new(nomeLocal, enderecoLocal, capacidade);
    Console.WriteLine("\nLocal cadastrado com sucesso.");
    Console.WriteLine(local);
} catch (ArgumentException e) {
    Console.WriteLine("Erro ao cadastrar local: " + e.Message);
    return;
}

Console.WriteLine("\nCadastrando Novo Compromisso");

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

Compromisso compromisso;
try {
    compromisso = new((DateTime)dataCompromisso, (TimeSpan)horaCompromisso, descricaoCompromisso, usuario, local);
    Console.WriteLine("Compromisso criado com sucesso!\n");
    Console.WriteLine(compromisso);
} catch (ArgumentException e) {
    Console.WriteLine("Erro na reserva: \n" + e.Message);
    return;
}

while(true) {
    Console.WriteLine("\nAdicionar participante? (S/N)");
    var opcao = Console.ReadLine()?.ToUpper();
    if (opcao != "S") {
        break;
    }
    try {
        local.ValidarCapacidade(compromisso.Participantes.Count + 1);
    } catch(InvalidOperationException e) {
        Console.WriteLine("Erro: " + e.Message);
        break;
    }
    Console.Write("Nome: ");
    string nomeParticipante = Console.ReadLine();
    Console.Write("Email: ");
    string emailParticipante = Console.ReadLine();

    try {
        Participante participante = new(nomeParticipante, emailParticipante);
        compromisso.AdicionarParticipante(participante);
        Console.WriteLine("Participante adicionado com sucesso!");
    } catch(ArgumentException e) {
        Console.WriteLine("Erro ao adicionar participante: " + e.Message);
    }
}

while(true) {
    Console.Write("\nDeseja adicionar uma anotação ao compromisso? (S/N): ");
    var opcao = Console.ReadLine()?.ToUpper();
    if(opcao != "S") {
        break;
    }
    Console.Write("Digite a anotação: ");
    string textoAnotacao = Console.ReadLine();

    try {
        compromisso.AdicionarAnotacao(textoAnotacao);
        Console.WriteLine("Anotação adicionada com sucesso!");
    } catch(ArgumentException e) {
        Console.WriteLine("Erro ao adicionar anotação: " + e.Message);
    }
}

Console.WriteLine("\nResumo Final do Compromisso");

Console.WriteLine(compromisso);

if (compromisso.Participantes.Count > 0) {
    Console.WriteLine("\nParticipante(s): ");
    foreach (var p in compromisso.Participantes)
        Console.WriteLine($"- {p}");
} else {
    Console.WriteLine("\nNenhum participante adicionado.");
}

if (compromisso.Anotacoes.Count > 0) {
    Console.WriteLine("\nAnotações: ");
    foreach (var a in compromisso.Anotacoes)
        Console.WriteLine($"- {a}");
} else {
    Console.WriteLine("\nNenhuma anotação registrada.");
}
