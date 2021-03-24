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

namespace Aufgabe7_Kittinger_20210310
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        SpielerSammlung Sammlung = new SpielerSammlung();
        private void spielerAnlegen_Click(object sender, RoutedEventArgs e)
        {
            string name;
            int alter;
            char geschlecht = ' ';

            try
            {
                if (Name_TB.Text != "" && Alter_TB.Text != "")
                {
                    name = Name_TB.Text;
                    alter = Convert.ToInt32(Alter_TB.Text);

                    if (Weiblich_RB.IsChecked == true)
                    {
                        geschlecht = 'w';
                    }
                    if (Maennlich_RB.IsChecked == true)
                    {
                        geschlecht = 'm';
                    }
                    Sammlung.Add(new Spieler(name, alter, geschlecht));
                }
                Name_TB.Text = "";
                Alter_TB.Text = "";
                Maennlich_RB.IsChecked = false;
                Weiblich_RB.IsChecked = false;
            }
            catch (Exception x)
            {
                MessageBox.Show("Ungültige Eingabe!\nKorrigiere den Wert für Alter", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Spielerauswahl_DropDownOpened(object sender, EventArgs e)
        {
            Spielerauswahl.Items.Clear();

            for(int i = 0; i < Sammlung.Count; i++)
            {
                Spielerauswahl.Items.Add(Sammlung[i].getName + ";" + Sammlung[i].getAlter + ";" + Sammlung[i].getGeschlecht);
            }
        }
    }
}
