# cRestify
owin REST framework specifically meant for web service APIs 


# Usage

## Server
```javascript

var restify = new Restify();

server.get('/echo/:name',(req, res, next)=> {
  res.send(req.params);
  return next();
});

server.listen(8080, env=> {
  console.log('%s listening at %s', server.name, server.url);
});

#Todo


http://www.vinaysahni.com/best-practices-for-a-pragmatic-restful-api
