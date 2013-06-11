using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using Microsoft.CSharp;
using Microsoft.Office.Interop.Excel;
using System.Reflection;							//pour Missing
using System.IO;

namespace WindowsFormsApplication3Excel
{
	public partial class Form1 : Form
	{
    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

		string filename = @"\file.txt";

		public Form1()
		{
			InitializeComponent();
			filename = Environment.CurrentDirectory + filename;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//Microsoft.Office.Interop.Excel.ApplicationClass excelApp = new ApplicationClass();

			Workbook book = null;
			Worksheet sheet = null;
			Range range = null;

			try {
				excelApp.Visible = true;
				excelApp.ScreenUpdating = true;
				excelApp.DisplayAlerts = true;
				//excelApp.Calculation = XlCalculation.xlCalculationManual;

				book = excelApp.Workbooks.Open(filename,
					   Missing.Value, Missing.Value, Missing.Value,
					   Missing.Value, Missing.Value, Missing.Value, Missing.Value,
					   Missing.Value, Missing.Value, Missing.Value, Missing.Value,
					   Missing.Value, Missing.Value, Missing.Value);
				sheet = (Worksheet)book.Worksheets[1];

				range = sheet.get_Range("A1", Missing.Value);
				range = range.get_End(XlDirection.xlToRight);			// get the end of values to the right (will stop at the first empty cell)
				range = range.get_End(XlDirection.xlDown);				// get the end of values toward the bottom, looking in the last column (will stop at first empty cell)

				string downAddress = range.get_Address(false, false, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);	// get the address of the bottom, right cell

				// Get the range, then values from a1
				range = sheet.get_Range("A1", downAddress);
				object[,] values = (object[,])range.Value2;

				excelApp.Visible = true;
				excelApp.ScreenUpdating = true;
				excelApp.DisplayAlerts = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			//finally
			//{
			//    range = null;
			//    sheet = null;
			//    if (book != null)
			//        book.Close(false, Missing.Value, Missing.Value);
			//    book = null;
			//    if (excelApp != null)
			//        excelApp.Quit();
			//    excelApp = null;
			//}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Workbook book = null;
			Worksheet sheet = null;
			Range range = null;

			try
			{
				excelApp.Visible = true;
				excelApp.ScreenUpdating = true;
				excelApp.DisplayAlerts = true;
				//excelApp.Calculation = XlCalculation.xlCalculationManual;

				book = excelApp.Workbooks.Open(filename,
					   Missing.Value, Missing.Value, Missing.Value,
					   Missing.Value, Missing.Value, Missing.Value, Missing.Value,
					   Missing.Value, Missing.Value, Missing.Value, Missing.Value,
					   Missing.Value, Missing.Value, Missing.Value);
				sheet = (Worksheet)book.Worksheets[1];

				Chart chart = (Chart)excelApp.Charts.Add(Missing.Value,Missing.Value,Missing.Value,Missing.Value);

				range = sheet.get_Range("A1", Missing.Value);
				range = range.get_End(XlDirection.xlToRight);			// get the end of values to the right (will stop at the first empty cell)
				range = range.get_End(XlDirection.xlDown);				// get the end of values toward the bottom, looking in the last column (will stop at first empty cell)
				chart.ChartWizard(range, XlChartType.xlLine,
					Missing.Value,
					Microsoft.Office.Interop.Excel.XlRowCol.xlRows,
					Missing.Value,Missing.Value,Missing.Value,
					"Sales","Employee","Export in percent",Missing.Value);
				chart.Location(XlChartLocation.xlLocationAsObject, sheet.Name);
				sheet.Shapes.Item("Chart 1").Left = 2.10f;
				sheet.Shapes.Item("Chart 1").Top = 150.0f;
				sheet.Shapes.Item("Chart 1").Width = 500.0f;
				sheet.Shapes.Item("Chart 1").Height = 300.0f;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}
	}
}
