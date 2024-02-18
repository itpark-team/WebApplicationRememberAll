using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApplicationRememberAll.Dtos;
using WebApplicationRememberAll.Services;
using WebApplicationRememberAll.Validators;

namespace WebApplicationRememberAll.Controllers;

[ApiController]
[Route("slaves/")]
public class SlavesController : ControllerBase
{
    private SlavesService _slavesService;
    private SlavesAddNewRequestDtoValidator _slavesAddNewRequestDtoValidator;

    public SlavesController(SlavesService slavesService,
        SlavesAddNewRequestDtoValidator slavesAddNewRequestDtoValidator)
    {
        _slavesService = slavesService;
        _slavesAddNewRequestDtoValidator = slavesAddNewRequestDtoValidator;
    }

    [HttpGet("get-all")]
    public List<SlavesGetAllResponseDto> GetAll()
    {
        return _slavesService.GetAll();
    }

    [HttpGet("get-by-id/{id}")]
    public String GetById(int id)
    {
        if (id % 2 == 0)
        {
            throw new Exception("OMG id is even");
        }

        return $"hello {id}";
    }

    [HttpPost("add-new")]
    public String AddNew(SlavesAddNewRequestDto addNewRequestDto)
    {
        ValidationResult validationResult = _slavesAddNewRequestDtoValidator.Validate(addNewRequestDto);

        if (validationResult.IsValid == false)
        {
            throw new Exception("Проблема валидации");
        }

        return "added successful";
    }
}