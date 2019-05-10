using System;
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

        [Fact]
        public void deveValidarValorMinimoAplicacao()
        {
            var operacao = new Operacao();

            operacao.valor = 6000;

            var cliente = new Cliente();
            cliente.segmento = "A";

            Validacao.validaValor(cliente.segmento, operacao.valor);
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
        public static boolean validaValor(string segmento, double valor){
            return segmento.Equal("A") && valor < 5000;
        }
    }
}
