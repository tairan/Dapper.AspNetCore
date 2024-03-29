﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;

namespace Dapper.AspNetCore.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ValuesController(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var list = new List<object>
            {
                _unitOfWork.Connection.QuerySingle<int>("select 1")
            };

            _unitOfWork.ExecuteTransaction((trans) =>
            {
                list.Add(trans.Connection.QuerySingle<int>("select 2", transaction: trans));
                list.Add(trans.Connection.QuerySingle<int>("select 3", transaction: trans));
                list.Add(trans.Connection.QuerySingle<int>("select 4", transaction: trans));
            });

            return list.Select(i => i.ToString()).ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
