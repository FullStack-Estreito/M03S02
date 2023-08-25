namespace FichaCadastroApi.Partner.Command
{
    // The Command interface declares a method for executing a command.
    public interface IMessage
    {
        string Message { get; }
    }

    public interface ICommand : IMessage
    {
        void Execute();
    }

    // Some commands can implement simple operations on their own.
    public class SimpleCommand : ICommand
    {
        private string _payload = string.Empty;

        public SimpleCommand(string payload)
        {
            this._payload = payload;
        }

        public string Message { get; private set; }

        public void Execute()
        {
            Message = $"SimpleCommand: See, I can do simple things like printing ({this._payload})";
        }
    }

    // However, some commands can delegate more complex operations to other
    // objects, called "receivers."
    public class ComplexCommand : ICommand
    {
        private Receiver _receiver;

        public string Message { get; private set; }


        // Context data, required for launching the receiver's methods.
        private string _mensageA;

        private string _mensageB;

        // Complex commands can accept one or several receiver objects along
        // with any context data via the constructor.
        public ComplexCommand(Receiver receiver, string mensageA, string mensageB)
        {
            this._receiver = receiver;
            this._mensageA = mensageA;
            this._mensageB = mensageB;
        }

        // Commands can delegate to any methods of a receiver.
        public void Execute()
        {
            Message = "ComplexCommand: Complex stuff should be done by a receiver object.";
            this._receiver.DoSomething(this._mensageA);
            this._receiver.DoSomethingElse(this._mensageB);
        }
    }

    // The Receiver classes contain some important business logic. They know how
    // to perform all kinds of operations, associated with carrying out a
    // request. In fact, any class may serve as a Receiver.
    public class Receiver : IMessage
    {
        public string Message { get; private set; }

        public void DoSomething(string menageA)
        {
            Message += $"Receiver: Working on ({menageA}.) ";
        }

        public void DoSomethingElse(string messageB)
        {
            Message += $"Receiver: Also working on ({messageB}.) ";
        }
    }

    // The Invoker is associated with one or several commands. It sends a
    // request to the command.
    public class ConcepacaoCommand
    {
        private ICommand _onStart;

        private ICommand _onFinish;

        // Initialize commands.
        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }

        public void SetOnFinish(ICommand command)
        {
            this._onFinish = command;
        }

        // The Invoker does not depend on concrete command or receiver classes.
        // The Invoker passes a request to a receiver indirectly, by executing a
        // command.
        public void DoSomethingImportant()
        {
            //Console.WriteLine("Invoker: Does anybody want something done before I begin?");
            if (this._onStart is ICommand)
            {
                this._onStart.Execute();
            }

            //Console.WriteLine("Invoker: ...doing something really important...");

            //Console.WriteLine("Invoker: Does anybody want something done after I finish?");
            if (this._onFinish is ICommand)
            {
                this._onFinish.Execute();
            }
        }
    }
}
