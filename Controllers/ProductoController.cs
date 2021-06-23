using API_Restful_CRUD.Context;
using API_Restful_CRUD.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Restful_CRUD.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductoController : ControllerBase

	{ 
		private readonly AppDbContext context;
		public ProductoController(AppDbContext context1)
		{
			this.context = context1; 
		}
		// GET: api/<ProductoController>
		[HttpGet]
		public IEnumerable<Producto> Get()
		{
		//	List<Producto> ProList = new List<Producto>;
			IEnumerable<Entities.Producto> ProList = context.Producto.ToList();
			return ProList;

			//ProList = context.Producto.ToList();
			//return ProList;
		}

		// GET api/<ProductoController>/5
		[HttpGet("{id}")]
		public Producto  Get(string id)
		{
			Producto pro = context.Producto.FirstOrDefault(p => p.pro_codigo == id);
			return pro;
		}

		// POST api/<ProductoController>
		[HttpPost]
		public ActionResult Post([FromBody] Producto producto)
		{
			try
			{
				context.Producto.Add(producto);
				context.SaveChanges();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest();
			}
		}

		// POST api/<ProductoController>
		//[HttpPost]
		////post es para insertar
		// public async Task<bool> Post(Producto producto) {
		//	try
		//	{
		//		context.Producto.Add(producto);
		//		await context.SaveChangesAsync ();
		//		//return Ok();
		//		return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		return false;
		//		//return BadRequest();
		//	}
		// }


		// PUT api/<ProductoController>/5
		[HttpPut("{id}")]
		//put es para modificacion
		public ActionResult Put(string id, [FromBody] Producto producto)
		{
			if (producto.pro_codigo == id)
			{
				context.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				context.SaveChanges();
				return Ok();
			}
			else {
				return BadRequest();
			}

		}

		// DELETE api/<ProductoController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(string id)
		{
			var producto = context.Producto.FirstOrDefault(p => p.pro_codigo == id);
			if (producto != null)
			{
				context.Producto.Remove(producto);
				context.SaveChangesAsync();
				return Ok();
			}
			else {
				return BadRequest();
			}
		}
	}
}
