using FileSystemVisitor;
using System;
using System.Collections.Generic;
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

namespace TestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Finder finder = new Finder();        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                finder.GetFiles(tbPath.Text, tbExtension.Text);
                finder.Started += () => Onstarted();
                finder.OnStarted();
                lbItems.ItemsSource = finder.Files;
                finder.Finishied += () => OnFinished();
                finder.OnFinished();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnFinished()
        {
            MessageBox.Show("Finished");
        }

        private void Onstarted()
        {
            MessageBox.Show("Started");
        }
    }
}
