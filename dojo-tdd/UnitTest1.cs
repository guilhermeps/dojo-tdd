using System;
using System.Collections.Generic;
using Xunit;

namespace dojo_tdd
{
    public class UnitTest1
    {
        // A data de aplicação deve ser hoje

        [Fact]
        public void dataAplicacaoDeveSerHoje()
        {
            var operacao = new Operacao();

            var dataHj = DateTime.Now;
            Assert.Equal(operacao.data.Date, dataHj.Date);
        }

        [Theory]
        [InlineData(6000, "A")]
        [InlineData(5000, "B")]
        [InlineData(7000, "C")]
        [InlineData(8000, "G")]
        public void deveValidarValorMinimoDe5000AplicacaoSegmentoAG(double valor, string segmento)
        {
            var operacao = new Operacao();
            operacao.valor = valor;
            var cliente = new Cliente();
            cliente.segmento = segmento;
            Assert.True(Validacao.validaValorAaG(cliente.segmento, operacao.valor));
        }

        [Theory]
        [ClassData(typeof(MassaDeDadoDeErroParaAplicacaoEmSegmentosAaG))]
        public void DeveRetornarErroQuandoOValorDaAplicacaoForMenorDoQue5000ParaSegmentosDeAaG(double valor, string segmento, string msgErro)
        {
            var operacao = new Operacao();
            operacao.valor = valor;
            var cliente = new Cliente();
            cliente.segmento = segmento;

            try
            {
                Validacao.validaValorAaG(cliente.segmento, operacao.valor);
            }
            catch (System.Exception ex)
            {
                Assert.Equal(msgErro, ex.Message);
            }
        }

        [Theory]
        [ClassData(typeof(MassaDeSucessoSegmento0ouZ))]
        public void DeveRetornarSucessoQuandoOValorDaAplicacaoForMaiorDoQue50000ParaSegmento0ou(double valor, string segmento)
        {
            var operacao = new Operacao();
            operacao.valor = valor;
            var cliente = new Cliente();
            cliente.segmento = segmento;
            Assert.True(Validacao.validaValor0ouZ(cliente.segmento, operacao.valor));
        }

    }


    public class Cliente
    {
        public string nome { get; set; }
        public string cpfCnpj { get; set; }
        public string segmento { get; set; }
        public string agencia { get; set; }
        public string conta { get; set; }
        public string DAC { get; set; }
    }

    public class Operacao
    {
        public double valor { get; set; }
        public DateTime data { get { return DateTime.Now; } }
        public string tipo { get; set; }
    }

    public class Liquidacao
    {
        public string tipo { get; set; }
        public string banco { get; set; }
        public string agencia { get; set; }
        public string conta { get; set; }
        public string DAC { get; set; }
    }

    public class Movimentacao
    {
        public Cliente cliente { get; set; }
        public Operacao operacao { get; set; }
        public Liquidacao liquidacao { get; set; }
    }

    public static class Validacao
    {
        public static bool validaValorAaG(string segmento, double valor)
        {
            List<string> valores = new List<string>() { "A", "B", "C", "D", "E", "F", "G" };
            bool estaValido = valores.Contains(segmento) && valor >= 5000;

            if (!estaValido) throw new Exception("O valor mínimo da aplicação para este segmento é de 5 Mil BRL");

            return estaValido;
        }

        public static bool validaValor0ouZ(string segmento, double valor)
        {
            List<string> valores = new List<string>() { "0", "Z" };
            bool estaValido = valores.Contains(segmento) && valor >= 50000;

            if (!estaValido) throw new Exception("O valor mínimo da aplicação para este segmento é de 50 Mil BRL");

            return estaValido;
        }
    }
}
