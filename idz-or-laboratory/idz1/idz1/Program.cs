using System;
using idz1.Collections;
using idz1.Controllers;
using idz1.FactoryObjects;

namespace idz1
{

    class Program
    {

        static void Print(string message){
            Console.WriteLine(message);
        }

        static string Input(){
            
            string? input = Console.ReadLine();

            while (input is null){
                input = Console.ReadLine();
            }

            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            FactoryList FactList = new();
            UnitList UnitList = new();
            TankList TankList = new();

            FactList.LoadFromJson("factories.json");
            UnitList.LoadFromJson("units.json");
            TankList.LoadFromJson("tanks.json");
            Console.WriteLine(FactList.DumpToJson());
            Console.WriteLine(UnitList.DumpToJson());
            Console.WriteLine(TankList.DumpToJson());

            In INhandler;
            INhandler = Input;
            Out OUThandler;
            OUThandler = Print;

            InputListener listener = new(INhandler);
            PrintController output = new(OUThandler);
            MenuController menuContr = new();

            Engine eng = new()

            // Factory fact1 = new("factory1", "Первый нефтеперерабатывающий завод");
            // Factory fact2 = new("factory2", "Второй нефтеперерабатывающий завод");

            // Unit unit1 = new("unit1", "Газофракционная установка", 0);
            // Unit unit2 = new("unit2", "Атмосферно-вакуумная трубчатка", 0);
            // Unit unit3 = new("unit3", "Атмосферно-вакуумная трубчатка", 1);

            // Tank tank1 = new("tank1", "blabla1", 1500, 2000, 0);
            // Tank tank2 = new("tank2", "blabla1", 2500, 3000, 0);
            // Tank tank3 = new("tank3", "blabla1", 3000, 3000, 1);
            // Tank tank4 = new("tank4", "blabla1", 3000, 3000, 1);
            // Tank tank5 = new("tank5", "blabla1", 4000, 5000, 1);
            // Tank tank6 = new("tank6", "blabla1", 500, 500, 2);

            // FactList.Add(fact1);
            // FactList.Add(fact2);

            // UnitList.Add(unit1);
            // UnitList.Add(unit2);
            // UnitList.Add(unit3);

            // TankList.Add(tank1);
            // TankList.Add(tank2);
            // TankList.Add(tank3);
            // TankList.Add(tank4);
            // TankList.Add(tank5);
            // TankList.Add(tank6);

            // CompanyController Contr = new(FactList, UnitList, TankList);
            // Console.WriteLine(Contr.FindUnit("tank2").ToString());            
        }
    }
}