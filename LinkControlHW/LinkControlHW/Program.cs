
namespace LinkControlHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var item = Factory.GetRepository();
            //var meetings = item.GetAllMeetings();

            Console.WriteLine("Choose access level:\n1.ReadOnly\n2.RW Mode (Full Access)");
            if (!Enum.TryParse(typeof(AccessMode), Console.ReadLine(), out var accessLevel))
            {
                throw new Exception("Wrong access level! It must be in range [1,2].");
            }

            IController controller = 
                (AccessMode)accessLevel == AccessMode.RWMode ? new MenuItemController() : new ReadOnlyMenuItemController();

            try
            {
                while (controller != null)
                {
                    controller = controller.ExecuteAction();
                }
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine($"Something expected went wrong! {ex.Message}\n Stack Trace is:\n{ex.StackTrace}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something unexpected went wrong! {ex.Message}\n Stack Trace is:\n{ex.StackTrace}");
            }

            Console.WriteLine("\nExecution has ended.");
            Console.ReadKey();
        }
    }
    internal enum AccessMode
    {
        readonlyMode = 1,
        RWMode
    }
}