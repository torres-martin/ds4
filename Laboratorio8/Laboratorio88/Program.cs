abstract class ClaseAbtrata
{
    abstract protected string tomarValor();
    abstract public string prefixValor(string prefix);

    public void printOut()
    {
        Console.WriteLine(tomarValor());
    }
}
class ClaseConcreta1 : ClaseAbtrata
{
    protected override string tomarValor()
    {
        return "ClaseConcreta1";
    }
    public override string prefixValor(string prefix)
    {
        return $"{prefix}ClaseConcreta1";
    }
}

class ClaseConcreta2 : ClaseAbtrata
{
    protected override string tomarValor()
    {
        return "ClaseConcreta2";
    }
    public override string prefixValor(string prefix)
    {
        return $"{prefix}ClaseConcreta2";
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        ClaseAbtrata concreta1 = new ClaseConcreta1();
        concreta1.printOut();
        Console.WriteLine(concreta1.prefixValor("ES_"));
        ClaseAbtrata concreta2 = new ClaseConcreta2();
        concreta2.printOut();
        Console.WriteLine(concreta2.prefixValor("ES_"));
    }
}