using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface ICurvePointRepository
    {
        public List<CurvePoint> List();
        public void Create(CurvePoint curvePoint);
        public CurvePoint? Get(int id);
        public void Update(CurvePoint curvePoint);
        public void Delete(int id);
    }
}
