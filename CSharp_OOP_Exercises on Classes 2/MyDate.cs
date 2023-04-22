using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_OOP_Exercises_on_Classes_2 {
	internal class MyDate {
		private int year;
		private int month;
		private int day;
		private static string[] strMonths = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul",
													"Aug", "Sep", "Oct", "Nov", "Dec"};
		private static string[] strDays = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday",
												"Saturday", "Sunday"};
		private static int[] daysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		public static bool isLeapYear(int year) {
			if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) {
				return true;
			} else {
				return false;
			}
		}
		public static bool isValidDate(int year, int month, int day) {
			if (isLeapYear(year) && month == 2) {
				if ((day <= daysInMonths[month - 1] + 1 && day > 0) && (month <= 12 && month > 0) && (year <= 9999 && year > 0)) {
					return true;
				} else {
					return false;
				}
			}
			else {
				if ((day <= daysInMonths[month - 1] && day > 0) && (month <= 12 && month > 0) && (year <= 9999 && year > 0)) {
					return true;
				}
				else {
					return false;
				}
			}
		}
		public static int getDayOfWeek(int year, int month, int day) {
			int den = 0;
			try {
				DateOnly datum = new DateOnly(year, month, day);
				switch (datum.DayOfWeek) {
					case DayOfWeek.Sunday:
						den = 6;
						break;
					case DayOfWeek.Monday:
						den = 0;
						break;
					case DayOfWeek.Tuesday:
						den = 1;
						break;
					case DayOfWeek.Wednesday:
						den = 2;
						break;
					case DayOfWeek.Thursday:
						den = 3;
						break;
					case DayOfWeek.Friday:
						den = 4;
						break;
					case DayOfWeek.Saturday:
						den = 5;
						break;
				}
			}
			catch (ArgumentException e) { Console.WriteLine(e + "TOTO NELZE" ); }
			return den;
		}

		//public int getDayOfWeekInstancni() {
		//	DateTime datum = new DateTime(year, month, day);
		//	int den = -1;
		//	switch (datum.DayOfWeek) {
		//		case DayOfWeek.Sunday:
		//			den = 6;
		//			break;
		//		case DayOfWeek.Monday:
		//			den = 0;
		//			break;
		//		case DayOfWeek.Tuesday:
		//			den = 1;
		//			break;
		//		case DayOfWeek.Wednesday:
		//			den = 2;
		//			break;
		//		case DayOfWeek.Thursday:
		//			den = 3;
		//			break;
		//		case DayOfWeek.Friday:
		//			den = 4;
		//			break;
		//		case DayOfWeek.Saturday:
		//			den = 5;
		//			break;
		//	}
		//	return den;
		//}
		public MyDate(int year, int month, int day) {
			setDate(year, month, day);
		}
		public void setDate(int year, int month, int day) {
			try {
				if (isValidDate(year, month, day)) {
					this.day = day;
					this.month = month;
					this.year = year;
				}
				else {
					throw new ArgumentException();
				}
			}
			catch (ArgumentException e) { Console.WriteLine(e.Message + " Invalid day, month or year!"); }
		}
		public int getYear() { return year; }
		public int getMonth() { return month; }
		public int getDay() { return day; }
		public void setYear(int year) {
			try {
				if (year >= 1 && year <= 9999) {
					this.year = year;
				} else {
					throw new ArgumentException();
				}
			}
			catch (ArgumentException e) { Console.WriteLine(e.Message + " Invalid year!"); }
		}
		public void setMonth(int month) {
			try {
				if (month >= 1 && month <= 12) {
					this.month = month;
				}
				else {
					throw new ArgumentException();
				}
			}
			catch (ArgumentException e) { Console.WriteLine(e.Message + " Invalid month!"); }
		}
		public void setDay(int day) {
			int dayMax = daysInMonths[month - 1];
			try {
				if (isLeapYear(year) && month == 2) {
					if ((day <= dayMax + 1) && day > 0) {
						this.day = day;
					}
					else {
						throw new ArgumentException();
					}
				}
				else {
					if ((day <= dayMax) && day > 0) {
						this.day = day;
					}
					else {
						throw new ArgumentException();
					}
				}
			}
			catch (ArgumentException e) { Console.WriteLine(e.Message + " Invalid day!"); }
		}
		public MyDate nextDay() {
			int maxDay = daysInMonths[month - 1];
			if (isLeapYear(year) && month == 2 && day == 28) {
				day = 29;
			}
			else {
				if (day >= maxDay) {
					day = 1;
					month++;
					if (month > 12) {
						year++;
						month = 1;
					}
				}
				else {
					day++;
				}
			}
			return this;
		}
		public MyDate nextMonth() {

			if (month == 12) {
				month++;
				year++;
			} else {
				int maxDay = daysInMonths[month];
				month++;
				if (day > maxDay) {
					day = maxDay;
				}
			}
			return this;
		}
		public MyDate nextYear() {
			year++;
			if (isLeapYear(year-1) && month == 2 && day == 29) {
				day--;
			}
			return this;
		}
		public override string ToString() {
			return $"{strDays[getDayOfWeek(year, month, day)]} {day} {strMonths[month-1]} {year}";
		}

		public MyDate previousDay() {
			if (isLeapYear(year) && month == 2 && day == 1) {
				day = 29;
				month--;
			}
			else if (month == 2 && day == 1) {
				day = 28;
				month--;
			} 
			else {
				if (day == 1) {
					if (month == 1) {
						year--;
						month = 12;
						day = daysInMonths[month - 1];
					}
					else {
						month--;
						day = daysInMonths[month - 1];

					}
				} else {
					day--;
				}
			}
			return this;
		}
		public MyDate previousMonth() {
			if (month == 1) {
				month = 12;
				year--;
			}
			else {
				int maxDay = daysInMonths[month-2];
				month--;
				if (day > maxDay) {
					day = maxDay;
				}
			}
			return this;
		}
		public MyDate previousYear() {
		year--;
			if (isLeapYear(year+1) && month == 2 && day == 29) {
				day--;
			}
			return this; 
		}
		public static void Mainx() {

			MyDate d1 = new MyDate(2012, 2, 28);
			Console.WriteLine(d1);
			Console.WriteLine(d1.nextDay());
			Console.WriteLine(d1.nextDay());
			Console.WriteLine(d1.nextMonth());
			Console.WriteLine(d1.nextYear());
			MyDate d2 = new MyDate(2012, 1, 2);
			Console.WriteLine(d2);
			Console.WriteLine(d2.previousDay());
			Console.WriteLine(d2.previousDay());
			Console.WriteLine(d2.previousMonth());
			Console.WriteLine(d2.previousYear());

			MyDate d3 = new MyDate(2012, 2, 29);
			Console.WriteLine(d3.previousYear());
			MyDate d5 = new MyDate(2011, 2, 29);
		}
	}

}
