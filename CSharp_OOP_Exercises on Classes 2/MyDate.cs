using System;
using System.Collections.Generic;
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
				if ((day <= daysInMonths[month - 1] + 1 && day > 0) || (month <= 12 && month > 0) || (year <= 999 && year > 0)){
					return true;
				} else {
					return false;
				}
			}
			else {
				if ((day <= daysInMonths[month - 1] && day > 0) || (month <= 12 && month > 0) || (year <= 999 && year > 0)){
					return true;
				}
				else {
					return false;
				}
			}
		}
		public static int getDayOfWeek(int year, int month, int day) {
			DateTime datum = new DateTime(year, month, day);
			int den = -1;
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
			return den;
		}

		public int getDayOfWeekInstancni() {
			DateTime datum = new DateTime(year, month, day);
			int den = -1;
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
			return den;
		}
		public MyDate(int day, int month, int year) {
			setDate(day, month, year);
		}
		public void setDate(int day, int month, int year) {
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
			catch (ArgumentException e) { Console.WriteLine(e + "Invalid day, month or year!");}
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
			catch (ArgumentException e) { Console.WriteLine(e + "Invalid year!"); }
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
			catch (ArgumentException e) { Console.WriteLine(e + "Invalid month!"); }
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
			catch (ArgumentException e) { Console.WriteLine(e + "Invalid day!"); }
		}

		public override string ToString() {
			return $"{strDays[getDayOfWeek(year, month, day)]} {day} {month} {year}";
		}
		//public MyDate nextDay() { }
		//public MyDate nextMonth() { }
		//public MyDate nextYear() { }
		//public MyDate previousDay() { }
		//public MyDate previousMonth() { }
		//public MyDate previousYear() { }

	}
}
