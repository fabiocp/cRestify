using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DevStore.Tdc.Api.Model;
using Ploeh.AutoFixture;


//http://localhost:9089/api/v1/public/products

namespace DevStore.Tdc.Api.Controllers {

  [EnableCors(origins: "http://localhost:9012", headers: "*", methods: "*")]
  [RoutePrefix("api/v1/public")]
  public class ProductController : ApiController {

    private readonly IList<Product> products;

    public ProductController() {
      var fixture = new Fixture();
      this.products = fixture.CreateMany<Product>().ToList();
    }

    #region Read
    [Route("products")]
    public HttpResponseMessage GetProducts( int skip = 0, int take = 25 ) {
      try {

        var result =  products.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        return Request.CreateResponse(HttpStatusCode.OK, result);
      } catch {
        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao recuperar produtos");
      }

    }

    [Route("products/{number}")]
    public HttpResponseMessage GetProductsByNumber( string number ) {
      try {
        var result =  products.FirstOrDefault(x => x.ProductNumber.ToUpper() == number.ToUpper());
        return Request.CreateResponse(HttpStatusCode.OK, result);
      } catch {
        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao recuperar produtos");
      }
    }
    #endregion

    #region Create
    [HttpPost]
    [Route("products")]
    public HttpResponseMessage PostProduct( Product product ) {
      if (product == null)
        return Request.CreateResponse(HttpStatusCode.BadRequest);

      try {
        products.Add(product);
        var result = product;
        return Request.CreateResponse(HttpStatusCode.Created, result);
      } catch {
        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir produto");
      }
    }
    #endregion

    #region Update
    [HttpPut]
    [Route("products")]
    public HttpResponseMessage PutProduct( Product product ) {
      if (product == null)
        return Request.CreateResponse(HttpStatusCode.BadRequest);

      try {

        var result = product;
        return Request.CreateResponse(HttpStatusCode.OK, result);
      } catch {
        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar produto");
      }
    }
    #endregion

    #region Delete
    [HttpDelete]
    [Route("products")]
    public HttpResponseMessage DeleteProduct( int productId ) {
      if (productId <= 0)
        return Request.CreateResponse(HttpStatusCode.BadRequest);

      try {
        products.Remove(products.Single(env => env.Id==productId));


        return Request.CreateResponse(HttpStatusCode.OK, "Produto excluido");
      } catch {
        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir produto");
      }
    }
    #endregion

  }
}
