using AutoMapper;
using HomeworkDeliveryAPI.Dtos;
using HomeworkDeliveryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HomeworkDeliveryAPI.Controllers
{
    [Route("api/HomeWorks")]
    [ApiController]
    [Authorize]
    public class HomeWorkController : ControllerBase
    {
        private readonly AppDbContext _context;
        ResultDto result = new ResultDto();
        public HomeWorkController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Assignment>> List()
        {
            var homeWorks = await _context.Assignments.ToListAsync();
            return homeWorks;
        }
        [HttpPost]
        public async Task<ResultDto> Add(HomeWorkDto dto)
        {
            if (_context.Assignments.Count(c => c.Title == dto.Title) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Başlık Kayıtlıdır!";
                return result;
            }
            Assignment assignment = new Assignment()
            {
                Title = dto.Title,
                Description = dto.Description,
                StartDate = dto.StartDate,
                Deadline = dto.Deadline,
                Status = dto.Status,
                LessonId = dto.LessonId

           };
            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();

            result.Status = true;
            result.Message = "Kayıt Eklendi";
            return result;
        }

        [HttpPut]
        public async Task<ResultDto> Update(HomeWorkDto dto)
        {
            var homeWorks = await _context.Assignments.Where(s => s.Id == dto.Id).SingleOrDefaultAsync();
            if (homeWorks == null)
            {
                result.Status = false;
                result.Message = "Kayıt Bulunamadı!";
                return result;

            }
            homeWorks.Title = dto.Title;
            homeWorks.Description = dto.Description;          

            _context.Assignments.UpdateRange(homeWorks);
            await _context.SaveChangesAsync();
            result.Status = true;
            result.Message = "Kayıt Güncellendi";
            return result;
        }

        [HttpDelete]
        [Route("id")]
        public async Task<ResultDto> Delete(int id)
        {

            var homeWorks = await _context.Assignments.Where(s => s.Id == id).SingleOrDefaultAsync();
            if (homeWorks == null)
            {
                result.Status = false;
                result.Message = "Kayıt Bulunamadı!";
                return result;

            }
          

            _context.Assignments.Remove(homeWorks);
            await _context.SaveChangesAsync();
            result.Status = true;
            result.Message = "Kayıt Silindi";
            return result;
        }

    }
}
