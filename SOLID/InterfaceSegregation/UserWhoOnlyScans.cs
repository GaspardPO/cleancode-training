namespace SOLID.InterfaceSegregation
{
    public class UserWhoOnlyScans {

        IScanner scanner;

        public void Scan()
        {
            scanner.Scan();
        }
    }
}
