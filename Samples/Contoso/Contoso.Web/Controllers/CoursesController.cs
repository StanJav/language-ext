﻿using System.Threading.Tasks;
using Contoso.Application.Courses.Commands;
using Contoso.Application.Students.Queries;
using Contoso.Web.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CoursesController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{courseId}")]
        public Task<IActionResult> Get(int courseId) =>
            _mediator.Send(new GetStudentById(courseId))
                .ToActionResult();

        [HttpPost]
        public Task<IActionResult> Create(CreateCourse createCourse) =>
            _mediator.Send(createCourse).ToActionResult();
        
        [HttpPut]
        public Task<IActionResult> Update(UpdateCourse updateCourse) =>
            _mediator.Send(updateCourse).ToActionResult();

        [HttpDelete]
        public Task<IActionResult> Delete(DeleteCourse deleteCourse) =>
            _mediator.Send(deleteCourse).ToActionResult();
    }
}
