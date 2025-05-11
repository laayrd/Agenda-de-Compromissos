using System;

namespace AgendaDeCompromisso.Modelos;

public class Local
{
    public string Nome { get; }
    public string Endereco { get; }

    public Local(string nome, string endereco)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do local é obrigatório");
        if (string.IsNullOrWhiteSpace(endereco))
            throw new ArgumentException("Endereço do local é obrigatório");

        Nome = nome;
        Endereco = endereco;
    }

    public override string ToString()
    {
        return $"{Nome} ({Endereco})";
    }
}