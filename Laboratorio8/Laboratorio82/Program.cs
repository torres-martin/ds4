public class Cuenta
{
    private string idCuenta;

    public Cuenta(string prmtIdCuenta)
    {
        this.idCuenta = prmtIdCuenta;
        System.Console.WriteLine(
        "Contructor Clase Base para cuenta {0}", prmtIdCuenta);
    }
    public virtual void CalcularInteres()
    {
        System.Console.WriteLine(
        "Cuenta.CalcularIntereses() efectuado para la cuenta {0}", 
        this.idCuenta);
    }
    public string getidCuenta()
    {
        return this.idCuenta;
    }
}
public class CuentaCorriente : Cuenta
{
    public CuentaCorriente(string prmtIdCuenta) : base(prmtIdCuenta)
    {
    }
    public override void CalcularInteres()
    {
        System.Console.WriteLine(
        "CuentaCorriente.CalcularIntereses() efectuado para " + 
        "la cuenta {0}", getidCuenta());
    }
}
public class CuentaAhorro : Cuenta
{
    public CuentaAhorro(string prmtIdCuenta) : base(prmtIdCuenta)
    {
    }
    public override void CalcularInteres()
    {
        System.Console.WriteLine(
        "CuentaAhorro.CalcularIntereses() efectuado para " + 
        "la cuenta {0}", getidCuenta());
    }
}
internal class  Program
{
    private static void Main(string[]args)
    {
        const string CUENTA = "100";

        Cuenta cuenta = new Cuenta(CUENTA);
        CuentaCorriente cuentaCorriente =
        new CuentaCorriente(CUENTA);
        CuentaAhorro cuentaAhorro = 
        new CuentaAhorro(CUENTA);
        cuenta.CalcularInteres();
        cuentaCorriente.CalcularInteres();
        cuentaAhorro.CalcularInteres();
    }
}