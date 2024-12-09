using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_RPG_Form;
using Xunit;
using Xunit.Sdk;

namespace P_Lista_3_formularz.Class.Tests
{
    public class Test
    {
        [Fact]
        public void Test1()
        {
            //Assert.Equal(3, 3);
            //Console.WriteLine("Test Completed");
            WPF_RPG_Form.App app = new WPF_RPG_Form.App();
            app.InitializeComponent();
            //app.Run();
            Assert.Equal("MainWindow.xaml", app.StartupUri.ToString());

        }

    }
    public class TestClass
    {
        [WpfFact]
        public void TestMethod()
        {
            var mainWindow = new MainWindow();
            var result = mainWindow.GetGreetingForTest();
            Assert.Equal("Welcome to WPF RPG!", result);
        }

        [Fact]
        public void Test_AddHeroe_Success()
        {
            var mainWindow = new MainWindow();
            string name = "TestHero";
            string type = HeroeType.Paladin.ToString();
            int hp = 100;
            int mana = 50;
            string skill = "Slash";
            string skill2 = "Block";
            string weapon = "Sword";
            int level = 1;
            //var result = mainWindow.AddHeroe(name, type, hp, mana, skill, skill2, weapon, level);
        }
    }
}
