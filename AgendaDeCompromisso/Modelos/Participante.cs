using System;
using System.Collections.Generic;

namespace AgendaDeCompromisso.Modelos;

public class Participante
{
    public string Nome { get; }
    public string Email { get; }
    private readonly List<Compromisso> _compromissos = new();

    public Participante(string nome, string email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do participante é obrigatório");
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email do participante é obrigatório");

        Nome = nome;
        Email = email;
    }

    public void AdicionarCompromisso(Compromisso compromisso)
    {
        if (compromisso == null)
            throw new ArgumentNullException();
        _compromissos.Add(compromisso);
    }

    public override string ToString()
    {
        return $"{Nome} <{Email}>";
    }
}