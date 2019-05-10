using System;
using Xunit;

namespace dojo_tdd 
{
    internal class MassaDeDadoDeErroParaAplicacaoEmSegmentosAaG : TheoryData<double, string, string>
    {
        public MassaDeDadoDeErroParaAplicacaoEmSegmentosAaG()
        {
            Add(0, "A", "O valor mínimo da aplicação para este segmento é de 5 Mil BRL");
            Add(100, "B", "O valor mínimo da aplicação para este segmento é de 5 Mil BRL");
            Add(1000, "C", "O valor mínimo da aplicação para este segmento é de 5 Mil BRL");
        }
    }
}