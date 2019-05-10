using Xunit;

namespace dojo_tdd
{
    public class MassaDeSucessoSegmento0ouZ : TheoryData<double, string>
    {
        public MassaDeSucessoSegmento0ouZ()
        {
            Add(50000, "0");
            Add(1000000, "Z");
        }
    }
}