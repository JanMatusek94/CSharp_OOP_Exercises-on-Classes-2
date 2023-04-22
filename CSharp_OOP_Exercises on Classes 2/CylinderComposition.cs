using CSharp_OOP_Exercises_on_Classes_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Exercises_on_Classes_2a {
	internal class Cylinder {
		private double height;
		private Circle based;
		public Cylinder() {
			height = 1.0;
			based = new Circle();
		}
		public Cylinder(double height) {
			this.height = height;
			based = new Circle();
		}

		public Cylinder(double radius, double height) {
			this.height = height;
			based = new Circle(radius);
		}
		public Cylinder(double radius, double height, string color) {
			this.height = height;
			based = new Circle(radius, color);
		}
		public double getHeight() { return height; }
		public void setHeight(double height) { this.height = height; }
		public double getVolume() {
			return based.getArea() * height;
		}
		public double getArea() {
			return (2 * Math.PI * based.getRadius() * height) + (2 * based.getArea());
		}
		public override string ToString() {
			return $"Cylinder: subclass of {based} height= {height}";
		}
		public static void Mainx() {
			Cylinder c1 = new Cylinder();
			Console.WriteLine("Cylinder:"
						+ " radius=" + c1.based.getRadius()
						+ " height=" + c1.getHeight()
						+ " base area=" + c1.getArea()
						+ " volume=" + c1.getVolume());
			Cylinder c2 = new Cylinder(10.0);
			Console.WriteLine("Cylinder:"
						+ " radius=" + c2.based.getRadius()
						+ " height=" + c2.getHeight()
						+ " base area=" + c2.getArea()
						+ " volume=" + c2.getVolume());
			Cylinder c3 = new Cylinder(2.0, 10.0, "blue");
			Console.WriteLine("Cylinder:"
						+ " radius=" + c3.based.getRadius()
						+ " height=" + c3.getHeight()
						+ " base area=" + c3.getArea()
						+ " volume=" + c3.getVolume());
			Console.WriteLine(c1);
			Console.WriteLine(c2);
			Console.WriteLine(c3);
		}
	}
}
