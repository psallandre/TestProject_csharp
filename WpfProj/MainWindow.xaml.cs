using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfProj
{
	using DataSet1TableAdapters;
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			//http://www.codeproject.com/KB/WPF/WPFDataGridExamples.aspx
			// construct the dataset
			DataSet1 dataset = new DataSet1();

			// use a table adapter to populate the Customers table
			Feuil1_TableAdapter adapter = new Feuil1_TableAdapter();
			adapter.Fill(dataset._Feuil1_);

			// use the Customer table as the DataContext for this Window
			this.DataContext = dataset._Feuil1_.DefaultView;

		}

		private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
