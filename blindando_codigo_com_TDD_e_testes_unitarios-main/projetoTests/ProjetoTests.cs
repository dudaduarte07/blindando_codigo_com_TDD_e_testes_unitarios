using projeto.Services;

namespace projetoTests;

public class ProjetoTests
{
    public Calculadora construirClasse(){
        string data = "07/10/23";
        Calculadora calc = new Calculadora("07/10/23");
        return calc;
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(4, 5, 9)]
    public void TesteSomar(int num1, int num2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculo = calc.Somar(num1, num2);
        Assert.Equal(resultado, resultadoCalculo);
    }

    [Theory]
    [InlineData(6, 2, 4)]
    [InlineData(5, 5, 0)]
    public void TesteSubtrair(int num1, int num2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculo = calc.Subtrair(num1, num2);
        Assert.Equal(resultado, resultadoCalculo);
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(4, 5, 20)]
    public void Multiplicar(int num1, int num2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculo = calc.Multiplicar(num1, num2);
        Assert.Equal(resultado, resultadoCalculo);
    }

    [Theory]
    [InlineData(6, 2, 3)]
    [InlineData(5, 5, 1)]
    public void TesteDividir(int num1, int num2, int resultado)
    {
        Calculadora calc = construirClasse();
        int resultadoCalculo = calc.Dividir(num1, num2);
        Assert.Equal(resultado, resultadoCalculo);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        Calculadora calc = construirClasse();

        Assert.Throws<DivideByZeroException>(() => calc.Dividir(3, 0));
    }

    [Fact]
    public void TestarHistorico()
    {
        Calculadora calc = construirClasse();

        calc.Somar(1,2);
        calc.Subtrair(2,8);
        calc.Multiplicar(3,7);
        calc.Dividir(4,1);

        var lista = calc.historico();
        
        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }
}