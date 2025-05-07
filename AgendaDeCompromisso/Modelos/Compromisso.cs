using System;

namespace AgendaDeCompromisso.Modelos;

public class Compromisso
{
    private DateTime _data;
    private TimeSpan _hora;
    
    public DateTime Data { get {
        return _data;
    } }
    public TimeSpan Hora { get {
        return _hora;
    } }
    public string? DescricaoCompromisso { get; }

    private readonly Usuario _usuario;
    //private readonly Local _local;

    //private readonly List<Participante> _participantes = new();
    //public IReadOnlyCollection<Participante> Participantes => _participantes;
    //private readonly List<Anotacao> _anotacoes = new();
    //public IReadOnlyCollection<Anotacao> Anotacoes => _anotacoes;
    public readonly List<string> ErrosDeValidacao = [];

    public Compromisso(DateTime data, TimeSpan hora, string descricao, Usuario usuario/*, Local local*/) {
        _data = data;
        _hora = hora;
        DescricaoCompromisso = descricao;
        _usuario = usuario;
        //_local = local;

        if(!ValidarCompromisso()) {
            throw new ArgumentException(string.Join("\n", ErrosDeValidacao));
        }
    }
    // public void AdicionarParticipante(Participante participante) {
    //     if(participante == null) throw new ArgumentNullException();
    //     _participantes.Add(participante);
    //     participante.AdicionarCompromisso(this);
    // }
    // public void AdicionarAnotacao(string texto) {
    //     if(texto == null) throw new ArgumentNullException();
    //     _anotacoes.Add(new Anotacao(texto));
    // }
    public bool ValidarCompromisso() {
        if (_data < DateTime.Today) {
            ErrosDeValidacao.Add("A data mínima não pode ser anterior à data de hoje");
        }
        if (_data == DateTime.Today && _hora <= DateTime.Now.TimeOfDay) {
            ErrosDeValidacao.Add("A hora do Compromisso não pode ser menor que a hora atual");
        }
        if (string.IsNullOrWhiteSpace(DescricaoCompromisso)) {
            ErrosDeValidacao.Add("Descrição do Compromisso é obrigatório");
        }
        return ErrosDeValidacao.Count == 0;
    }

    public override string ToString()
    {
        return $"\nDescrição Compromisso: {DescricaoCompromisso}\nUsuário: {_usuario}\nData: {_data:dd/MM/yyyy}\nHora: {_hora:hh\\:mm}"; //Local: {_local}
    }
}

