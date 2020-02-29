using WebService.ClassLibrary;

namespace WebService.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Creator TypeCreator = new Creator();
            SqlHelper sqlHelper = new SqlHelper();

            sqlHelper.TruncateEntity();

            IType itype = TypeCreator.RaporFactory(CategoryType.BigPara);
            itype.Olustur();

            itype = TypeCreator.RaporFactory(CategoryType.Emlak);
            itype.Olustur();

            /*itype = TypeCreator.RaporFactory(CategoryType.Mahmure);
            itype.Olustur();*/
        }
    }
}
