﻿using Dot.Net.WebApi.Domain;
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

        public CurvePointOutputModel? Create(CurvePointInputModel inputModel)
        {
            var curvePoint = new CurvePoint
            {
                CurveId = inputModel.CurveId,
                AsOfDate = inputModel.AsOfDate,
                CurvePointValue = inputModel.CurvePointValue,
                CreationDate = DateTime.Now
            };
            _curvePointRepository.Create(curvePoint);
            return ToOutputModel(curvePoint);
        }

        public CurvePointOutputModel? Get(int id)
        {
            var curvePoint = _curvePointRepository.Get(id);
            if (curvePoint is not null)
            {
                return ToOutputModel(curvePoint);
            }
            return null;
        }

        public CurvePointOutputModel? Update(int id, CurvePointInputModel inputModel)
        {
            var curvePoint = _curvePointRepository.Update(new CurvePoint
            {
                Id = id,
                CurveId = inputModel.CurveId,
                AsOfDate = inputModel.AsOfDate,
                CurvePointValue = inputModel.CurvePointValue,
                CreationDate = DateTime.Now
            });
            if(curvePoint is not null) 
            { 
                return ToOutputModel(curvePoint);
            }
            return null;
        }

        public CurvePointOutputModel? Delete(int id) 
        {
            var curvePoint = _curvePointRepository.Delete(id);
            if (curvePoint is not null)
            {
                return ToOutputModel(curvePoint);
            }
            return null;
        } 

        private CurvePointOutputModel ToOutputModel(CurvePoint curvePoint) =>
            new CurvePointOutputModel
            {
                Id = curvePoint.Id,
                CurveId = curvePoint.CurveId,
                AsOfDate = curvePoint.AsOfDate,
                CurvePointValue = curvePoint.CurvePointValue
            };
    }
}