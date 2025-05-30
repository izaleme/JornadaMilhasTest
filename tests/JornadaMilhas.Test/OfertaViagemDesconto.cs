﻿using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test;

public class OfertaViagemDesconto
{
    [Fact]
    public void RetornaPrecoAttQuandoAplicadoDesconto()
    {
        // Arrange
        Rota rota = new Rota("OrigemA", "DestinoB");
        Periodo periodo = new Periodo(new DateTime(2024, 05, 01), new DateTime(2024, 05, 10));
        double precoOriginal = 100.00;
        double desconto = 20.00;
        double precoComDesconto = precoOriginal - desconto;
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

        // Act
        oferta.Desconto = desconto;

        // Assert
        Assert.Equal(precoComDesconto, oferta.Preco);
    }

    [Theory]
    [InlineData(120, 30)]
    [InlineData(100, 30)]
    public void RetornaDescontoMaxQuandoValorDescontoMaiorOuIgualAoPreco(double desconto, double precoComDesconto)
    {
        // Arrange
        Rota rota = new Rota("OrigemA", "DestinoB");
        Periodo periodo = new Periodo(new DateTime(2024, 05, 01), new DateTime(2024, 05, 10));
        double precoOriginal = 100.00;
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

        // Act
        oferta.Desconto = desconto;

        // Assert
        Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
    }
}
