using Jalasoft.Devlevel1.Practice1;

int y = 0;
string x = string.Empty;
int order = 0;
int count = 0;
string payment = string.Empty;
string name = string.Empty;
Dictionary<int, List<Menu>> orderList = new Dictionary<int, List<Menu>>();
Queue<Dictionary<int, List<Menu>>> ordersQueue = new Queue<Dictionary<int, List<Menu>>>();


Console.WriteLine("Bienvenido a la aplicacion de pedidos de comida");
Console.WriteLine("Ingrese su nombre completo");
name = Console.ReadLine();

while (order <= 5)
{
    while (x != "0")
    {
        Console.WriteLine("Elija su plato: ");
        Console.WriteLine("1. Arroz");
        Console.WriteLine("2. Frijoles");
        Console.WriteLine("3. Carne");
        Console.WriteLine("4. Ensalada");
        Console.WriteLine("5. Pollo");
        Console.WriteLine("6. Pescado");
        Console.WriteLine("7. Verduras");
        Console.WriteLine("8. Frutas");
        Console.WriteLine("9. Sopa");
        Console.WriteLine("10. Postre");
        Console.WriteLine(" ");
        Console.WriteLine("Elija su bebida: ");
        Console.WriteLine("11.Agua");
        Console.WriteLine("12.Jugo");
        Console.WriteLine("13.Cerveza");
        Console.WriteLine("14.Vino");
        Console.WriteLine("15.Refresco");
        Console.WriteLine("16.Cafe");
        Console.WriteLine("17.Tequila");
        Console.WriteLine("18.Whisky");
        Console.WriteLine("19.Vodka");
        Console.WriteLine("20.Licores");
        Console.WriteLine("0.Salir");

        x = Console.ReadLine();
        y = Convert.ToInt32(x);

        if (y != 0)
        {
            if (orderList.ContainsKey(order))
            {
                orderList[order].Add((Menu)y);
            }
            else
            {
                orderList.Add(order, new List<Menu> { (Menu)y });
            }
        }
        
        ordersQueue.Enqueue(orderList);

    }

    Console.WriteLine("Desea hacer otro pedido? (S/N)");
    string answer = Console.ReadLine();
    
    while (answer != "S" && answer != "N")
    {
        Console.WriteLine("Desea hacer otro pedido? (S/N)");
        answer = Console.ReadLine();
    }


    if (answer == "N")
    {
        break;
    }
    else
    {
        x = string.Empty;
    }

    
    order++;

}

Console.WriteLine("Ingrese metodo de pago: ");
Console.WriteLine("1. Efectivo");
Console.WriteLine("2. Tarjeta de credito");
payment = Console.ReadLine();

while (payment != "1" && payment != "2")
{
    Console.WriteLine("Ingrese metodo de pago: ");
    Console.WriteLine("1. Efectivo");
    Console.WriteLine("2. Tarjeta de credito");
    payment = Console.ReadLine();
}


foreach (var dicc in ordersQueue)
{

    foreach (var item in dicc)
    {
        Console.WriteLine("Delivering Order: " + item.Key + " Customer " + name);

        List<string> menuList = new List<string>();

        foreach (var menu in item.Value)
        {
            count = item.Value.Count(x => x == menu);


            menuList.Add( "Cantidad: " +  count + " Pedido: " + menu + " TOTAL: $" + count * 500);

        }
        
        var menuListDistinct = menuList.Distinct().ToList();

        foreach (var menu in menuListDistinct)
        {
            Console.WriteLine(menu);
        }


    }

    break;

}


if (payment == "1")
{
    Console.WriteLine($"payment method: {Payment.Cash}");
}
else if (payment == "2")
{
    Console.WriteLine($"payment method: {Payment.CreditCard}");
}



