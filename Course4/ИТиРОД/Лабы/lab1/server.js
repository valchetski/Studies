var http = require('http'),
	url = require('url'),
	fs = require('fs'),
	tree = require("./tree.json");

const PORT=8080; 

function handleRequest(request, response){
	var url_parts = url.parse(request.url);
	console.log(url_parts);
	if(url_parts.pathname == '/') {
		fs.readFile('./index.html', function(err, data) {
			response.end(data);
		});
	} 
	else if(url_parts.pathname == '/jquery-1.11.3.js') {
		fs.readFile('./jquery-1.11.3.js', function(err, data) {
			response.end(data);
		});
	}
	else if(url_parts.pathname == '/scripts.js') {
		fs.readFile('./scripts.js', function(err, data) {
			response.end(data);
		});
	}
	else if (url_parts.pathname == '/mystyles.css'){
		fs.readFile('./mystyles.css', function(err, data) {
			response.end(data);
		});
	}
	else if (url_parts.pathname == '/NATIVE_REQUEST'){
		response.end("It was HTTP request");
	}
	else if (url_parts.pathname == '/JQUERY_REQUEST'){
		response.end("It was jQuery request");
	}
	else{
		console.log(tree[url_parts.pathname.replace('/', '')])
		response.setHeader('Content-Type', 'application/json');
		response.end(JSON.stringify(tree[url_parts.pathname.replace('/', '')]));
	}
}

var server = http.createServer(handleRequest);

server.listen(PORT, function(){
    console.log("Server listening on: http://localhost:%s", PORT);
});