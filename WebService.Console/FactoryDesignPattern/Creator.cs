using WebService.ClassLibrary;

namespace WebService.Console
{
    public class Creator
    {
        public IType RaporFactory(CategoryType type)
        {
            IType itype = null;
            switch (type)
            {
                case CategoryType.BigPara:
                    itype = new JsonTypeBigPara();
                    break;
                case CategoryType.Emlak:
                    itype = new XmlTypeEmlak();
                    break;
                case CategoryType.Mahmure:
                    itype = new XmlTypeMahmure();
                    break;
                default:
                    break;
            }
            return itype;
        }
    }
}
