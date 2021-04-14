using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain;
using WebAPI.Domain.Responses;
using WebAPI.Domain.Services;
using WebAPI.Extensions;
using WebAPI.Resource;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseService<User> service;
        private readonly IMapper mapper;

        public UserController(IBaseService<User> service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            BaseResponse<IEnumerable<User>> response = await service.GetWhere(x => x.Id >= 0);
            if (response.Success)
            {
                return Ok(response.context);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserResource userResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                User user = mapper.Map<UserResource, User>(userResource);
                BaseResponse<User> response = await service.Add(user);
                if (response.Success)
                {
                    return Ok(response.context);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            BaseResponse<User> response = await service.GetById(id);
            if (response.Success)
            {
                return Ok(response.context);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromForm] UserResource userResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                //BaseResponse<User> result = await service.GetById(userResource.Id);
                //User user = result.context;
                User user = mapper.Map<UserResource, User>(userResource);
                if (user != null)
                {
                    
                    BaseResponse<User> response = await service.Update(user);
                    if (response.Success)
                    {
                        return Ok(response.context);
                    }
                    else
                    {
                        return BadRequest(response.Message);
                    }
                }
                else
                {
                    return BadRequest("Belirtilen Kullanıcı Bulunamamıştır.");
                }
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            BaseResponse<User> response = await service.Delete(id);
            if (response.Success)
            {
                return Ok(response.context);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}