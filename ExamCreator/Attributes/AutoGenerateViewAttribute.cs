using ExamCreator.Models;

namespace ExamCreator.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class AutoGenerateActionViewAttribute : Attribute
    {
        public MethodType ViewType { get; private set; }
        public Type ListDTOType { get; private set; }
        public Type CreateDTOType { get; private set; }
        public Type EditDTOType { get; private set; }

        public AutoGenerateActionViewAttribute()
        {
            ViewType = MethodType.Empty;
        }

        public AutoGenerateActionViewAttribute(MethodType viewType)
        {
            ViewType = viewType;
        }

        public AutoGenerateActionViewAttribute(Type listDTOType, Type createDTOType, Type editDTOType)
        {
            ListDTOType = listDTOType;
            CreateDTOType = createDTOType;
            EditDTOType = editDTOType;
        }
    }
}
