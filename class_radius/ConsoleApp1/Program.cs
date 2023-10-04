using System;
using System.Reflection;

public sealed class Circle
{
	private double radius;

	public double Calculate(Func<double, double> op)
	{
		return op(radius);
	}
}

class Program
{
	static void Main()
	{
		double radius = 10.0;
		Circle circle = new Circle();

		Type circleType = circle.GetType();
		FieldInfo radiusField = circleType.GetField("radius", BindingFlags.NonPublic | BindingFlags.Instance);
		radiusField.SetValue(circle, radius);

		double circleForms = circle.Calculate(r => 2 * Math.PI * r);
		Console.WriteLine("Окружность круга: " + circleForms);

		Console.ReadLine();
	}
}
