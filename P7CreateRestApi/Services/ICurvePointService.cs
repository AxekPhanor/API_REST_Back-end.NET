using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Models.OutputModel;

namespace P7CreateRestApi.Services
{
    public interface ICurvePointService
    {
        public List<CurvePointOutputModel> List();
        public void Create(CurvePointInputModel inputModel);
        public CurvePoint? Get(int id);
        public void Update(int id, CurvePointInputModel inputModel);
        public void Delete(int id);
    }
}
