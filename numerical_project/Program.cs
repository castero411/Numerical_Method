using System;
using System.Runtime.Serialization.Formatters;

// using the formula ax3 + bx2 + cx + d
float a, b, c, d;
float x, y;
int method;
int no_Of_Itteration;
float tollerance;


Console.WriteLine("Welcome to the numerical Project" +"\n"+
    "please consider that the format of the formula is considered as the following" +
    "\n" +
    "ax3 + bx2 + cx + d" +
    " \nplese enter teh following variable a,b,c,d respectively");

a = int.Parse(Console.ReadLine());
b = int.Parse(Console.ReadLine());
c = int.Parse(Console.ReadLine());
d = int.Parse(Console.ReadLine());

Console.WriteLine("please enter the interval value [x,y] respectively");
x = int.Parse(Console.ReadLine());
y = int.Parse(Console.ReadLine());


Console.WriteLine("please enter the tollerance value");
tollerance = float.Parse(Console.ReadLine());

Console.WriteLine("please choose your your method" +
    "\n Bisection -> 1" +
    "\n Secant -> 2" +
    "\n Modified Secant -> 3" +
    "\n Newton Raphton -> 4" +
    "\n Fixed Point -> 5" +
    "\n All Methods -> 6");

method = int.Parse(Console.ReadLine());

no_Of_Itteration = (int)Math.Ceiling(Math.Log((y - x) / tollerance)/Math.Log(2));

int noomba = 0;

while (true)
{
    noomba++;

    if (method == 1)// bisection
    {
        Bisection();
        break;
    }
    else if (method == 2) // secant
    {
        secant();
        break;
    }else if (method == 3)// modified secant
    {
        Modified_secant();
        break;
    }else if(method == 4)// newton raphton
    {
        Newton_Raphton();
        break;
    }
    else if (method == 5)//fixed point
    {
        Fixed_point();
        break;
    }else if(method == 6)
    {
        Bisection();
        secant();
        Modified_secant();
        Newton_Raphton();
        Fixed_point();
        break;
    }
    else
    {
        Console.WriteLine("please enter a number within the list");
    }
    if (noomba ==2)
    {
        Console.WriteLine("get lost");
        Environment.Exit(0);
    }
    
}

float function(float x)//the function given by the user
{
    return a * x * x * x + b * x * x + c * x + d;
}

float integrated_function(float x) 
{

    return 3 * a * x * x + 2 * b * x + 1 * c ;
}

bool isPositive(float x)
{
    return x > 0;
}



void Bisection()
{
    float n1 = x, n2 = y, n3 = 0;// a, b, c
    float fun1, fun2, fun3;// f(a), f(b), f(c) 

    Console.Write("Bisection Method : \n");
    Console.WriteLine(" iteration    a        b        c       F(a)       F(b)       F(c)       |F(c)|<tol");

    for (int i = 1; i <= no_Of_Itteration;i++)
    {
        n3 = (n1 + n2) / 2;
        fun1= function(n1);
        fun2 = function(n2);
        fun3 = function(n3);

        Console.WriteLine("\n " + i + "       " +  n1.ToString("F5") +
            "  "+ n2.ToString("F5") + "  "+ n3.ToString("F5") + "  " + 
            fun1.ToString("F5")+ "  "+ fun2.ToString("F5")+ "   "+ fun3.ToString("F5") +"         "+ (Math.Abs(fun3)<tollerance)
            );
        
        if (Math.Abs(function(n3))<tollerance)
        {
            break;
        }

        if (isPositive(fun1) == isPositive(fun3))//check for the root value
        {
            n1 = n3;
        }
        else
        {
            n2 = n3;
        }


    }
    Console.WriteLine("\nthe root is " + n3);
    return;
}

void secant()
{

    float n1 = x, n2 = y, n3 = 0;// a, b, c
    float fun1, fun2, fun3;// f(a), f(b), f(c) 

    Console.Write("Secant Method : \n");
    Console.WriteLine(" iteration    a        b        c       F(a)       F(b)       F(c)       |F(c)|<tol    I=N");

    for (int i = 1; i <= no_Of_Itteration; i++)
    {

        fun1 = function(n1);
        fun2 = function(n2);

        n3 = n2 - fun2 * ((n2-n1) / (fun2-fun1));

        fun3 = function(n3);

        Console.WriteLine("\n " + i + "       " + n1.ToString("F5") +
            "  " + n2.ToString("F5") + "  " + n3.ToString("F5") + "  " +
            fun1.ToString("F5") + "  " + fun2.ToString("F5") + "   " + fun3.ToString("F5") + "         " + (Math.Abs(fun3) < tollerance)
            + "      " + (i == no_Of_Itteration)
            );

        if (Math.Abs(function(n3)) < tollerance)//cheking if F(c) < tollerance
        {
            break;
        }

        n1 = n2;//moving b to a
        n2 = n3;//moving c to b

    }
    Console.WriteLine("\nthe root is " + n3);
}


void Modified_secant()
{

    float n1 = x, n2 = y, n3 = 0;// a, b, c
    float fun1, fun2, fun3;// f(a), f(b), f(c) 

    Console.Write("MOdified Secant Method : \n");
    Console.WriteLine(" iteration    a        b        c       F(a)       F(b)       F(c)       |F(c)|<tol    I=N");

    for (int i = 1; i <= no_Of_Itteration; i++)
    {

        fun1 = function(n1);
        fun2 = function(n2);

        n3 = n2 - fun2 * ((n2 - n1) / (fun2 - fun1));

        fun3 = function(n3);

        Console.WriteLine("\n " + i + "       " + n1.ToString("F5") +
            "  " + n2.ToString("F5") + "  " + n3.ToString("F5") + "  " +
            fun1.ToString("F5") + "  " + fun2.ToString("F5") + "   " + fun3.ToString("F5") + "         " + (Math.Abs(fun3) < tollerance)
            + "      " + (i == no_Of_Itteration)
            );

        if (Math.Abs(function(n3)) < tollerance)//cheking if F(c) < tollerance
        {
            break;
        }

        if (isPositive(fun1) == isPositive(fun3))//check for the root value
        {
            n1 = n3;
        }
        else
        {
            n2 = n3;
        }
    }
    Console.WriteLine("\nthe root is " + n3);
}



void Newton_Raphton()
{
    float x1 = x;
    float funX,funX_dash;

    Console.Write("Newton Raphton Method : \n");
    Console.WriteLine(" iteration    x        F(x)      F'(x)      |F(x)|<tol    I=N");

    for (int i = 1; i <= no_Of_Itteration; i++)
    {
        funX = function(x1);
        funX_dash = integrated_function(x1);

        Console.WriteLine("\n " + i + "           " + x1.ToString("F5") + "    "
            + funX.ToString("F5") + "  " +
            funX_dash.ToString("F5") + "    " + (Math.Abs(funX) < tollerance) + "      " + (i == no_Of_Itteration)
            );

        if (Math.Abs(funX) < tollerance)
        {
            break;
        }

        x1 = x1 - (funX / funX_dash);
    }

    Console.WriteLine("\nthe root is " + x1);
}


void Fixed_point()
{
    float x1 = x;
    float funX, gfunX;
    Console.WriteLine("enter max number of itteration");

    no_Of_Itteration = Convert.ToInt32(Console.Read);

    Console.Write("Newton Raphton Method : \n");
    Console.WriteLine(" iteration    x        F(x)       G(x)      |F(x)|<tol    I=N");

    for (int i = 1; i <= no_Of_Itteration; i++)
    {
        funX = function(x1);
        gfunX = funX + x1;

        Console.WriteLine("\n " + i + "       " + x1.ToString("F5")+ "     "
            + funX.ToString("F5") + "  " + 
            gfunX.ToString("F5") + "    " + (Math.Abs(funX) < tollerance) + "      " + (i  == no_Of_Itteration)
            );

        if (Math.Abs(funX) < tollerance)
        {
            break;
        }

        x1 = gfunX;
    }

    Console.WriteLine("\nthe root is " + x1);
}