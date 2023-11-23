using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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
using WpfApp2.Models;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataContext data;
        public MainWindow()
        {
            InitializeComponent();

            TestContext testContext = new TestContext();
            Models.Process process = new Models.Process();
            process.Fauf = 3;
            process.Boat = 3;
            process.Stand = "Stand";
            process.DateFin = DateTime.Now;
            process.Version = "V1";
            process.Status = 1;
            for (int i = 1; i < 11; i++)
            {
                int ok = Convert.ToInt32(i % 2 == 0);
                var result = new Result() { Position = i, Data1 = ok, Data2 = 2, Data3 = 3 };
                result.ChargeMachines.Add(new ChargeMachine() { Type = "Piece 1", Charge = "Charge pièce 1" });
                result.ChargeMachines.Add(new ChargeMachine() { Type = "Piece 2", Charge = "Charge pièce 1" });
                result.ChargeMachines.Add(new ChargeMachine() { Type = "Piece 3", Charge = "Charge pièce 1" });
                result.ChargeMachines.Add(new ChargeMachine() { Type = "Piece 4", Charge = "Charge pièce 1" });
                result.ChargeMachines.Add(new ChargeMachine() { Type = "Piece 5", Charge = "Charge pièce 1" });
                result.ChargeMachines.Add(new ChargeMachine() { Type = "Piece 6", Charge = "Charge pièce 1" });
                process.Results.Add(result);
            }
            
            testContext.Processes.Add(process);
            foreach(var r in process.Results.Where(r => r.Data1 == 1))
            {
                if(!testContext.Infos.Any(i=> i.Position == r.Position && i.Boat == r.Process.Boat && i.Fauf == r.Process.Fauf))
                {
                    Debug.WriteLine("Premier passage bon : sauvegarde dans la table info et charge.");
                    var info = new Models.Info() { Boat = process.Boat, Fauf = process.Fauf, Position = r.Position };
                    foreach (var chargeMahine in r.ChargeMachines) info.Charges.Add(new Charge(chargeMahine));
                    testContext.Infos.Add(info);
                }
                else
                {
                    Debug.WriteLine("Pièce déjà passée bonne et sauvegardée dans la table info.");
                }
            }
            testContext.SaveChanges();
        }

        public void test(params int ?[]? args)
        {
            foreach(var arg in args)
            {

            }
        }
    }

    public class CustomAttribute : Attribute
    {
        public CustomAttribute(int arg, params int[] args)
        {
                
        }
    }
}

