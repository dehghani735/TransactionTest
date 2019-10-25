using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://www.tutorialsteacher.com/csharp/csharp-event

namespace TransactionTest.Event
{
  // PrintHelper is a publisher class that publishes the beforePrint event. Notice that in each print method, it first checks to see if beforePrintEvent is not null
  // and then it calls beforePrintEvent(). beforePrintEvent is an object of type BeforPrint delegate, so it would be null if no class is subscribed to the event and
  // that is why it is necessary to check for null before calling a delegate. (The delegate can also be invoked using the Invoke() method, e.g., beforePrintEvent.Invoke().)

  public class PrintHelper
  {
    // declare delegate 
    public delegate void BeforePrint();

    //declare event of type delegate
    public event BeforePrint beforePrintEvent;

    public PrintHelper()
    {

    }

    public void PrintNumber(int num)
    {
      //call delegate method before going to print
      if (beforePrintEvent != null)
        beforePrintEvent();

      Console.WriteLine("Number: {0,-12:N0}", num);
    }

    public void PrintDecimal(int dec)
    {
      if (beforePrintEvent != null)
        beforePrintEvent();

      Console.WriteLine("Decimal: {0:G}", dec);
    }

    public void PrintMoney(int money)
    {
      if (beforePrintEvent != null)
        beforePrintEvent();

      Console.WriteLine("Money: {0:C}", money);
    }

    public void PrintTemperature(int num)
    {
      if (beforePrintEvent != null)
        beforePrintEvent();

      Console.WriteLine("Temperature: {0,4:N1} F", num);
    }
    public void PrintHexadecimal(int dec)
    {
      if (beforePrintEvent != null)
        beforePrintEvent();

      Console.WriteLine("Hexadecimal: {0:X}", dec);
    }
  }

  // let's create a subscriber

  // All the subscribers must provided a handler function, which is going to be called when a publisher raises an event. In the above example, the Number class
  // creates an instance of PrintHelper and subscribes to the beforePrintEvent with the "+=" operator and gives the name of the function which will handle the event
  // (it will be get called when publish fires an event). printHelper_beforePrintEvent is the event handler that has the same signature as the BeforePrint delegate
  // in the PrintHelper class.
  class Number
  {
    private PrintHelper _printHelper;

    public Number(int val)
    {
      _value = val;

      _printHelper = new PrintHelper();
      //subscribe to beforePrintEvent event
      _printHelper.beforePrintEvent += printHelper_beforePrintEvent;
    }
    //beforePrintevent handler
    void printHelper_beforePrintEvent()
    {
      Console.WriteLine("BeforPrintEventHandler: PrintHelper is going to print a value");
    }

    private int _value;

    public int Value
    {
      get { return _value; }
      set { _value = value; }
    }

    public void PrintMoney()
    {
      _printHelper.PrintMoney(_value);
    }

    public void PrintNumber()
    {
      _printHelper.PrintNumber(_value);
    }

    static void Main()
    {
      Number myNumber = new Number(100000);
      myNumber.PrintMoney();
      myNumber.PrintNumber();
    }
  }
}


/* Points to Remember :
Use event keyword with delegate type to declare an event.
Check event is null or not before raising an event.
Subscribe to events using "+=" operator. Unsubscribe it using "-=" operator.
Function that handles the event is called event handler.Event handler must have same signature as declared by event delegate.
Events can have arguments which will be passed to handler function.
Events can also be declared static, virtual, sealed and abstract.
An Interface can include event as a member.
Events will not be raised if there is no subscriber
Event handlers are invoked synchronously if there are multiple subscribers
The .NET framework uses an EventHandler delegate and an EventArgs base class.*/
