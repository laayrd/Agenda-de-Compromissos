using System;

namespace AgendaDeCompromisso.Modelos;

public class Local
{
    private string _nome;
    private string _endereco;
    private int _capacidadeMaxima;

    public string Nome { get {
        return _nome;
    } }
    public string Endereco { get {
        return _endereco;
    } }
    public int CapacidadeMaxima {get {
        return _capacidadeMaxima;
    } }
    public readonly List<string> ErrosDeValidacao = [];
    public Local(string nome, string endereco, int Capacidade) {
        _nome = nome;
        _endereco = endereco;
        _capacidadeMaxima = Capacidade;
        if(!ValidarLocal()) {
            throw new ArgumentException(string.Join("\n", ErrosDeValidacao));
        }
    }

    public void ValidarCapacidade(int quantidade) {
        if (quantidade > _capacidadeMaxima) {
            throw new InvalidOperationException("A quantidade de participantes excede a capacidade do local.");
        }
    }

    public bool ValidarLocal() {
        if (string.IsNullOrWhiteSpace(_nome)) {
            ErrosDeValidacao.Add("Nome do local é obrigatório");
        }       
        if (string.IsNullOrWhiteSpace(_endereco)) {
            ErrosDeValidacao.Add("Endereço do local é obrigatório");
        }
        if (_capacidadeMaxima <= 0) {
            ErrosDeValidacao.Add("Capacidade máxima deve ser maior que zero.");
        }
        return ErrosDeValidacao.Count == 0;
    }

    public override string ToString()
    {
        return $"{_nome}\nEndereço: {_endereco}\nCapacidade Máxima: {_capacidadeMaxima}";
    }
}