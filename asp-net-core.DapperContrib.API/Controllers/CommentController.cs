using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper.Contrib.Extensions;
using asp_net_core.DapperContrib.API.Models;

namespace asp_net_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private IConfiguration _config;

        public CommentController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpGet("todos")]
        public IEnumerable<Comment> GetComment()
        {
            using (SqlConnection conection = new SqlConnection(
                _config.GetConnectionString("ConnectionString")))
            {
                return conection.GetAll<Comment>();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> Get(int id)
        {
            Comment comment ;
            using (SqlConnection conection = new SqlConnection(
                _config.GetConnectionString("ConnectionString")))
            {
                comment  = conection.Get<Comment>(id);
            }

            if (comment  != null)
                return comment ;
            else
                return NotFound(
                    new { message = "Comentário não encontrado" });
        }

        [HttpPost]
        public ActionResult Post(Comment comment)
        {
            using (SqlConnection conection = new SqlConnection(
                _config.GetConnectionString("ConnectionString")))
            {
                conection.Insert<Comment>(comment);
            }

            return Ok();
        }
    }
}