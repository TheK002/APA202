using _09_UpcastingDowncastingExplicitImplicit.Models;
//-----------------Upcasting-Downcasting---------------

//Dog dog = new Dog
//{
//    AvgLifeTime = 23, Breed = "Husky", Gender = "Female", Name = "Yoshi"
//};
//Eagle eagle = new Eagle
//{
//    AvgLifeTime = 50, Gender = "Male", FlySpeed = 60
//};

//Animals animal = dog;
//Animals animal1 = eagle;

//Dog dog1 = (Dog)animal;
//Eagle eagle1 = (Eagle)animal;

//Animals[] animals = { dog, eagle };

//foreach(var animal in animals) 
//{
//Eagle eagle1 = (Eagle)animal;
//Eagle eagle1 = animal as Eagle;
//eagle.Fly();

//if (eagle1 != null)
//{
//    eagle1.Fly();
//}
//else
//{
//    Dog dog1 = animal as Dog;
//}
//} 

//-----------------Boxing---------------

//int a = 5;

//Object b = a as  Object;

//int c = (int)b;

//Test test = new Test();

//ITest test1 = test;

//ITest test2 = (Test)test1;


//public struct Test : ITest
//{
//    public int X { get; set; }
//    public int Y { get; set; }

//}

//public interface ITest
//{
//    int Y { get; set; }
//}


Dolar dolar = new(200);

Manat manat = new(170);

Dolar dolar1 = manat;
Console.WriteLine(dolar1.USD);

Manat manat1 = dolar;
Console.WriteLine(manat1.AZN);
