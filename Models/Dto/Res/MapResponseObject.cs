using AutoWrapper;
namespace TechnoAcademyApi.Models.Dto.Res
{
    public class MapResponseObject
    {
        [AutoWrapperPropertyMap(Prop.Result)]
        public object? Result { get; set; }
    }
}
