using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Models.OutputModel;
using P7CreateRestApi.Repositories;

namespace P7CreateRestApi.Services
{
    public class CurvePointService : ICurvePointService
    {
        private readonly ICurvePointRepository _curvePointRepository;
        public CurvePointService(ICurvePointRepository curvePointRepository)
        {
            _curvePointRepository = curvePointRepository;
        }

        public List<CurvePointOutputModel> List()
        {
            var list = new List<CurvePointOutputModel>();
            var curvePoints = _curvePointRepository.List();
            foreach (var curvePoint in curvePoints)
            {
                list.Add(ToOutputModel(curvePoint));
            }
            return list;
        }

        public void Create(CurvePointInputModel inputModel)
        {
            _curvePointRepository.Create(new CurvePoint {
                CurveId = inputModel.CurveId,
                AsOfDate = inputModel.AsOfDate,
                CurvePointValue = inputModel.CurvePointValue,
                CreationDate = DateTime.Now
            });
        }

        public CurvePoint? Get(int id) => _curvePointRepository.Get(id);

        public void Update(int id, CurvePointInputModel inputModel)
        {
            var curvePoint = _curvePointRepository.Get(id);
            if(curvePoint is not null)
            {
                _curvePointRepository.Update(new CurvePoint
                {
                    Id = curvePoint.Id,
                    CurveId = inputModel.CurveId,
                    AsOfDate = inputModel.AsOfDate,
                    CurvePointValue = inputModel.CurvePointValue,
                    CreationDate = DateTime.Now
                });
            }
        }

        public void Delete(int id) => _curvePointRepository.Delete(id);

        private CurvePointOutputModel ToOutputModel(CurvePoint curvePoint) => 
            new CurvePointOutputModel { 
                Id = curvePoint.Id, 
                CurveId = curvePoint.CurveId, 
                AsOfDate = curvePoint.AsOfDate, 
                CurvePointValue = curvePoint.CurvePointValue 
            };
    }
}
