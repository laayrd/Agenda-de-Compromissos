using System;
using System.Collections.Generic;

namespace AgendaDeCompromisso.Modelos;

public class Usuario
{
    public string NomeUsuario { get; }
    private readonly List<Compromisso> _compromissos = new();
    public IReadOnlyCollection<Compromisso> Compromissos => _compromissos;

    public Usuario (string nomeUsuario) {
        if (string.IsNullOrWhiteSpace(nomeUsuario))
            throw new ArgumentException("Nome de usuário é obrigatório");
        NomeUsuario = nomeUsuario;
    }

    public void AdicionarCompromisso (Compromisso compromisso) {
        if(compromisso == null) {
            throw new ArgumentNullException(nameof(compromisso));
        }
        _compromissos.Add(compromisso);
    }
    public override string ToString() {
        return $"{NomeUsuario}";
    }
}