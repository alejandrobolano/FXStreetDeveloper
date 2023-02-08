using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Football.API.Common.Contracts;
using Football.API.Common.Models;
using Football.API.DataAccess.Contracts;
using AutoMapper;
using Football.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        public ManagerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        //TODO All Get's methods can be changed by GetAll(), this way will indicate that it result are lists
        public async Task<ActionResult<IEnumerable<ManagerResponse>>> Get()
        {
            var managers = await _repository.ManagerRepository.GetAllAsync();
            return Ok(managers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var response = await _repository.ManagerRepository.GetByIdAsync(id);
            if (response == default)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        //TODO Change Post by Add
        public async Task<ActionResult> Add(ManagerRequest managerRequest)
        {
            var manager = _mapper.Map<ManagerResponse>(managerRequest);
            var response = _repository.ManagerRepository.Add(manager);
            try
            {
                await _repository.SaveAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                var className = GetType().Name;
                var errorLine = new System.Diagnostics.StackFrame(0, true).GetFileLineNumber();
                _logger.LogError($"Something went wrong inside the Update action. {dbUpdateException.Message}", className, errorLine);
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                var className = GetType().Name;
                var errorLine = new System.Diagnostics.StackFrame(0, true).GetFileLineNumber();
                _logger.LogError($"Something went wrong inside the Update action. {exception.Message}", className, errorLine);
                return StatusCode(500, "Internal server error");
            }
            
            return CreatedAtRoute(response.Id, response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody]ManagerRequest managerRequest)
        {
            var managerMapped = _mapper.Map<ManagerResponse>(managerRequest);
            var manager = await _repository.ManagerRepository.GetByIdAsync(id);
            if (manager == default)
                return NotFound();
            try
            {
                managerMapped.Id = manager.Id;
                _repository.ManagerRepository.Update(managerMapped);
                await _repository.SaveAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                var className = GetType().Name;
                var errorLine = new System.Diagnostics.StackFrame(0, true).GetFileLineNumber();
                _logger.LogError($"Something went wrong inside the Update action. {dbUpdateException.Message}", className, errorLine);
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                var className = GetType().Name;
                var errorLine = new System.Diagnostics.StackFrame(0, true).GetFileLineNumber();
                _logger.LogError($"Something went wrong inside the Update action. {exception.Message}", className, errorLine);
                return StatusCode(500, "Internal server error");
            }


            return Ok(managerMapped);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var manager = await _repository.ManagerRepository.GetByIdAsync(id);
            if (manager == default)
                return NotFound();
            try
            {
                _repository.ManagerRepository.Delete(manager);
                await _repository.SaveAsync();
            }

            catch (DbUpdateException dbUpdateException)
            {
                var className = GetType().Name;
                var errorLine = new System.Diagnostics.StackFrame(0, true).GetFileLineNumber();
                _logger.LogError($"Something went wrong inside the Delete action. {dbUpdateException.Message}", className, errorLine);
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                var className = GetType().Name;
                var errorLine = new System.Diagnostics.StackFrame(0, true).GetFileLineNumber();
                _logger.LogError($"Something went wrong inside the Delete action. {exception.Message}", className, errorLine);
                return StatusCode(500, "Internal server error");
            }
            return Ok("Delete successful");
        }
    }
}
