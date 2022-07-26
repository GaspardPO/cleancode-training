namespace SOLID.InterfaceSegregation
{
    public interface IMachine:IPrinter,IFax,IScanner,IPhotocopier {     
    }

    public interface IPrinter 
    {
        void Print();
    }

    public interface IFax
    {
        void Fax();
    }

    public interface IScanner
    {
        void Scan();
    }

    public interface IPhotocopier
    {
        void Photocopy();
    }


}
