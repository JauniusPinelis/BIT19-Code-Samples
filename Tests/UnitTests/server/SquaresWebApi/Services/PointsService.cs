using AutoMapper;
using SquaresWebApi.Dtos.PointDtos;
using SquaresWebApi.Models;
using SquaresWebApi.Repositories;
using SquaresWebApi.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWebApi.Services
{
    public class PointsService
    {
        private readonly PointsRepository _pointsRepository;

        public PointsService(PointsRepository pointsRepository)
        {
            _pointsRepository = pointsRepository;
        }

        public void PrepareCreateRange(List<Point> points)
        {
            _pointsRepository.PrepareCreateRange(points);
        }

        public void PrepareRemoveRange(List<Point> points)
        {
            _pointsRepository.PrepareRemoveRange(points);
        }
    }
}
