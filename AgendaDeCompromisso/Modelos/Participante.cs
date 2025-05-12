using System;
using System.Collections.Generic;

namespace AgendaDeCompromisso.Modelos;

public class Participante
{
    private string _nome;
    private string _email;
    public string Nome { get {
        return _nome;
    } }
    public string Email { get {
        return _email;
    } }
    private readonly List<Compromisso> _compromissos = new();
    public readonly List<string> ErrosDeValidacao = [];

    public Participante(string nome, string email)
    {
        _nome = nome;
        _email = email;
        if(!ValidarParticipante()) {
            throw new ArgumentException(string.Join("\n", ErrosDeValidacao));
        }
    }

    public void AdicionarCompromisso(Compromisso compromisso)
    {
        if (compromisso == null)
            throw new ArgumentNullException(nameof(compromisso));
        _compromissos.Add(compromisso);
    }

    public bool ValidarParticipante(){
        if (string.IsNullOrWhiteSpace(_nome))
            ErrosDeValidacao.Add("Nome do participante é obrigatório");
        if (string.IsNullOrWhiteSpace(_email))
            ErrosDeValidacao.Add("Email do participante é obrigatório");
        return ErrosDeValidacao.Count == 0;
    }

    public override string ToString()
    {
        return $"Nome: {Nome} <{Email}>";
    }
}