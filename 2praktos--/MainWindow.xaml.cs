using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2praktos__
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<node> nodes = new List<node>();
        List<string> tags = new List<string>();

        public MainWindow()
        {
            if (!File.Exists("D:\\nodesdata.json"))
                File.Create("D:\\nodesdata.json").Close();

            InitializeComponent();

            nodes = json.getInfo<List<node>>("D:\\nodesdata.json");
            
            if (nodes == null)
                nodes = new List<node>();

            date.SelectedDate = DateTime.Now;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            json.saveInfo("D:\\nodesdata.json", nodes);
        }

        private void data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(data.SelectedItem != null)
            {
                foreach (var node in nodes)
                {
                    if (data.SelectedItem.ToString() == node.name && date.SelectedDate.Value == node.date)
                    {
                        name.Text = node.name;
                        desc.Text = node.desc;
                        return;
                    }
                }
            }
        }

        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            tags.Clear();
            data.ItemsSource = null;
            foreach (node _node in nodes)
            {
                if (_node.date == date.SelectedDate.Value)
                {
                    tags.Add(_node.name);
                }
            }
            data.ItemsSource = tags;
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(name.Text) && !String.IsNullOrEmpty(desc.Text) && date.SelectedDate != null)
            {
                nodes.Add(new node(name.Text, desc.Text, date.SelectedDate.Value));
                tags.Clear();
                data.ItemsSource = null;
                foreach (node _node in nodes)
                {
                    if (_node.date == date.SelectedDate.Value)
                    {
                        tags.Add(_node.name);
                    }
                }
                data.ItemsSource = tags;
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if(data.SelectedItem != null)
            {
                foreach (var node in nodes)
                {
                    if (data.SelectedItem.ToString() == node.name && date.SelectedDate.Value == node.date)
                    {
                        nodes.Remove(node);
                        break;
                    }
                }
            }
            tags.Clear();
            data.ItemsSource = null;
            foreach (node _node in nodes)
            {
                if (_node.date == date.SelectedDate.Value)
                {
                    tags.Add(_node.name);
                }
            }
            data.ItemsSource = tags;
        }
    }
}
