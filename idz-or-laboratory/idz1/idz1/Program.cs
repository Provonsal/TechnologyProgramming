using System;
using System.Collections.Generic;
using idz1.Collections;
using idz1.Controllers;
using idz1.FactoryIntefraces;
using idz1.FactoryObjects;

namespace idz1
{

    class Program
    {

        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        static string Input()
        {

            string? input = Console.ReadLine();

            while (input is null)
            {
                input = Console.ReadLine();
            }

            return input;
        }

        static void ConsoleCleaner(){
            Console.Clear();
        }

        static void ComeBack(Engine eng){
            eng.Menu.Back();
        }

        static void FabricControl(Engine eng)
        {
            eng.Menu.ChangeMenu("Factory control");
        }

        static void UnitsControl(Engine eng)
        {
            eng.Menu.ChangeMenu("Units control");
        }

        static void TanksControl(Engine eng)
        {
            eng.Menu.ChangeMenu("Tanks control");
        }

        static void FindFactory(Engine eng){
            eng.Output.ClearHandler();
            eng.Output.PrintHandler("Write id of a factory you looking for. Write /back to come back to menu.");

            string? input;
            
            while ((input = eng.Input.Handler?.Invoke()) is not null)
            {
                eng.Output.ClearHandler();
                eng.Output.PrintHandler("Write id of a factory you looking for. Write /back to come back to menu.");

                if (int.TryParse(input, out int FactoryId))
                {
                    Factory fact = (Factory) eng.Company.FindFactory(FactoryId);
                    
                    eng.Output.PrintHandler(fact.ToString());
                } else if (input == "/back") {
                    break;
                } else {
                    eng.Output.PrintHandler("ad");
                }
            }
        }

        static void Terminate(Engine eng)
        {
            eng.Dispose();
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            FactoryList FactList = new();
            UnitList UnitList = new();
            TankList TankList = new();

            FactList.LoadFromJson("factories.json");
            UnitList.LoadFromJson("units.json");
            TankList.LoadFromJson("tanks.json");

            Dictionary<string, IDictionary<string, string>> menus = new(){
                {
                    "mainmenu",
                    new Dictionary<string, string>(){
                        {"Factory control", "fabricControl"},
                        {"Units control", "unitsControl"},
                        {"Tanks control", "tanksControl"},
                        {"Exit", "exit"}
                    }
                },
                {
                    "Factory control",
                    new Dictionary<string, string>(){
                        {"Find factory", "findFactory"},
                        {"Show factories", "showFactories"},
                        {"Back", "back"}
                    }
                },
                {
                    "Units control",
                    new Dictionary<string, string>(){
                        {"Find unit", "findUnit"},
                        {"Show units", "showUnits"},
                        {"Back", "back"}
                    }
                },
                {
                    "Tanks control",
                    new Dictionary<string, string>(){
                        {"All tank campacity", "TanksCampacity"},
                        {"Show tanks", "showTanks"},
                        {"Back", "back"}
                    }
                }
            };

            Dictionary<string, Act> HandlerFuncs = new(){
                {"fabricControl", FabricControl},
                {"unitsControl", UnitsControl},
                {"tanksControl", TanksControl},
                {"findFactory", FindFactory},
                {"back", ComeBack},
                {"exit", Terminate}
            };

            In INhandler = Input;
            Out OUThandler = Print;
            Clear Cleaner = ConsoleCleaner;

            InputListener listener = new(INhandler);
            PrintController output = new(OUThandler, Cleaner);

            HandlersController handlers = new();

            foreach (var item in HandlerFuncs)
            {
                handlers.AttachHandler(new Handler(item.Key, item.Value));
            }

            MenuController menuContr = new(menus, output, handlers, "mainmenu");

            CompanyController companyController = new(FactList, UnitList, TankList);

            Engine eng = new(listener, output, menuContr, companyController);

            eng.StartEngine();          
        }
    }
}