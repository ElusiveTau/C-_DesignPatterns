using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class Client
    {
        public void RunCommand()
        {
            Invoker invoker = new Invoker();
            Receiver receiver = new Receiver();
            ConcreteCommand command = new ConcreteCommand(receiver);
            command.Parameter = "Hello, world!";
            invoker.Command = command;
            invoker.ExecuteCommand();
        }
    }

    /* The "receiver" is an object that receives a command to act/do/perform something concrete when a
     * a command is executed.
     */
    public class Receiver
    {
        public void Action(string message)
        {
            Console.WriteLine($"Action called with message, '{message}'.");
        }
    }

    public class Invoker
    {
        public CommandBase Command { get; set; }

        public void ExecuteCommand()
        {
            Command.Execute();
        }
    }

    /* CommandBase and ConcreteCommand encapsulates the actors involved in an action (or series of actions). It
     * is responsible for containing all of the information/data to successfully execute the encapsulated action(s) e.g,
     * `Receiver` and `Parameter`. It is NOT responsible for implementing the action that needs to be carried out
     * (that is encapsulated in the `Receiver` class). CommandBase.Execute() is a delegate for the action (a method)
     * encapsulated in the Receiver. 
     *
     * Commands can be executed immediately or stored in a collection (e.g., a queue, stack); the invoker or client
     * class determines when the command is executed. 
     */
    public abstract class CommandBase
    {
        protected Receiver _receiver;

        public CommandBase(Receiver receiver)
        {
            _receiver = receiver;
        }

        public abstract void Execute();
    }

    public class ConcreteCommand : CommandBase
    {
        public string Parameter { get; set; }

        public ConcreteCommand(Receiver receiver) : base(receiver) { }

        public override void Execute()
        {
            _receiver.Action(Parameter);
        }
    }
}


#region NOTES & REFERENCES
/*
 [1] Blackwasp: Command Design Pattern
     http://www.blackwasp.co.uk/command.aspx
 */
#endregion