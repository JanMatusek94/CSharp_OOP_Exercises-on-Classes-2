using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Exercises_on_Classes_2 {
	internal class Cylinder : Circle {
		private double height;
		public Cylinder() : base() {
			height = 1.0;
		}
		public Cylinder(double height) : base() {
			this.height = height;
		}

		public Cylinder(double radius, double height) : base(radius) {
			this.height = height;
		}
		public Cylinder(double radius, double height, string color) : base(radius, color) {
			this.height = height;
		}
		public double getHeight() { return height; }
		public void setHeight(double height) { this.height = height; }
		public double getVolume() {
			return base.getArea() * height;
		}
		public override double getArea() {
			return (2 * Math.PI * getRadius() * height) + (2 * base.getArea());
		}
		public override string ToString() {
			return $"Cylinder: subclass of {base.ToString()} height= {height}";
		}
		public static void Mainx() {
			Cylinder c1 = new Cylinder();
			Console.WriteLine("Cylinder:"
						+ " radius=" + c1.getRadius()
						+ " height=" + c1.getHeight()
						+ " base area=" + c1.getArea()
						+ " volume=" + c1.getVolume());
			Cylinder c2 = new Cylinder(10.0);
			Console.WriteLine("Cylinder:"
						+ " radius=" + c2.getRadius()
						+ " height=" + c2.getHeight()
						+ " base area=" + c2.getArea()
						+ " volume=" + c2.getVolume());
			Cylinder c3 = new Cylinder(2.0, 10.0, "blue");
			Console.WriteLine("Cylinder:"
						+ " radius=" + c3.getRadius()
						+ " height=" + c3.getHeight()
						+ " base area=" + c3.getArea()
						+ " volume=" + c3.getVolume());
			Console.WriteLine(c1);
			Console.WriteLine(c2);
			Console.WriteLine(c3);
		}
	}
}
