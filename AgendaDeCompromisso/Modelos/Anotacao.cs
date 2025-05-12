using System;

namespace AgendaDeCompromisso.Modelos;

public class Anotacao
{
    public string Texto { get; }
    public DateTime DataCriacao { get; }

    public Anotacao(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto)) {
            throw new ArgumentException("Texto da anotação é obrigatório.");
        }
        Texto = texto;
        DataCriacao = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{DataCriacao:dd/MM/yyyy HH:mm} - {Texto}";
    }
}

