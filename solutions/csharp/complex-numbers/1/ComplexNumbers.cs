using System;

public class ComplexNumber
{
    private readonly double _real;
    private readonly double _imaginary;

    public ComplexNumber(double real, double imaginary)
    {
        _real = real;
        _imaginary = imaginary;
    }

    public double Real() => _real;
    public double Imaginary() => _imaginary;

    // z + (a + bi)
    public ComplexNumber Add(ComplexNumber other)
        => new ComplexNumber(_real + other._real, _imaginary + other._imaginary);

    // ✅ z + k  (k — звичайне число, додається до дійсної частини)
    public ComplexNumber Add(double value)
        => new ComplexNumber(_real + value, _imaginary);

    // z - (a + bi)
    public ComplexNumber Sub(ComplexNumber other)
        => new ComplexNumber(_real - other._real, _imaginary - other._imaginary);

    // ✅ z - k
    public ComplexNumber Sub(double value)
        => new ComplexNumber(_real - value, _imaginary);

    // z * (a + bi)
    public ComplexNumber Mul(ComplexNumber other)
        => new ComplexNumber(
            _real * other._real - _imaginary * other._imaginary,
            _imaginary * other._real + _real * other._imaginary
        );

    // ✅ z * k
    public ComplexNumber Mul(double factor)
        => new ComplexNumber(_real * factor, _imaginary * factor);

    // z / (a + bi)
    public ComplexNumber Div(ComplexNumber other)
    {
        double denom = other._real * other._real + other._imaginary * other._imaginary;

        return new ComplexNumber(
            (_real * other._real + _imaginary * other._imaginary) / denom,
            (_imaginary * other._real - _real * other._imaginary) / denom
        );
    }

    // ✅ z / k
    public ComplexNumber Div(double divisor)
        => new ComplexNumber(_real / divisor, _imaginary / divisor);

    public double Abs()
        => Math.Sqrt(_real * _real + _imaginary * _imaginary);

    public ComplexNumber Conjugate()
        => new ComplexNumber(_real, -_imaginary);

    public ComplexNumber Exp()
    {
        double expReal = Math.Exp(_real);
        return new ComplexNumber(
            expReal * Math.Cos(_imaginary),
            expReal * Math.Sin(_imaginary)
        );
    }
}
