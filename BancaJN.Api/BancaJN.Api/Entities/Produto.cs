﻿namespace BancaJN.Api.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public string ImagemUrl { get; set; }
}

