var express = require('express');
var routes = require('./routes');
var http = require('http');
var path = require('path');
var engine = require('ejs-locals');
var otherFile = require('./WebSocketServer.js');
var session = require('client-sessions');


var app = express();
app.use(express.cookieParser());
app.use(express.session({ secret: "This is a secret" }));

// all environments
app.set('port', process.env.PORT || 3000);
app.set('views', path.join(__dirname, 'views'));
app.engine('ejs', engine);
app.set('view engine', 'ejs');
app.use(express.favicon());
app.use(express.logger('dev'));
app.use(express.json());
app.use(express.urlencoded());
app.use(express.methodOverride());
app.use(app.router);
app.use(require('stylus').middleware(path.join(__dirname, 'public')));
app.use(express.static(path.join(__dirname, 'public')));

app.use(session({
    cookieName: 'session',
    secret: 'random_string_goes_here',
    duration: 30 * 60 * 1000,
    activeDuration: 5 * 60 * 1000
}));


// development only
if ('development' == app.get('env')) {
    app.use(express.errorHandler());
}

var nano = require("nano")("http://localhost:5984");
var usersDbName = "myusers";
var mailDbName = "mymail";
nano.db.create(usersDbName, function (err, body) {
    if (err) {
        console.log("Database creation failed. " + err + "\n");
    } else {
        console.log("Database created. Response: " + JSON.stringify(body) + "\n");
    }
});

nano.db.create(mailDbName, function (err, body) {
    if (err) {
        console.log("Database creation failed. " + err + "\n");
    } else {
        console.log("Database created. Response: " + JSON.stringify(body) + "\n");
    }
});

app.get('/', routes.index);
app.get('/register', routes.register);
app.get('/login', routes.login);
app.get('/signout', routes.signout);
app.get('/newmessage', routes.newMessage);
app.get('/inbox', routes.inbox);
app.get('/sent', routes.sent);



app.post('/register', function (req, res) {
    var webSocket = require('ws');
    var socket = new webSocket("ws://localhost:1338");

    socket.on('open', function open() {
        delete req.body.__proto__;
        req.body.queryType = 'register';
        req.body.Login += '@mymail.com';
        socket.send(JSON.stringify(req.body));
    });
    
    socket.on('message', function (err, flags) {
        if (err) {
            res.redirect('/register');
        } else {
            res.redirect('/');
        }
    });
});


app.post('/login', function(req, res) {
    delete req.body.__proto__;
    if (req.body.Login.toLowerCase().indexOf('@mymail.com') === -1) {
        req.body.Login += '@mymail.com';
    }
    nano.use(usersDbName).get(req.body.Login, { revs_info: true }, function (err, body) {
        if (!err) {
            if (body.password !== req.body.password) {
                res.redirect('/login');
            } else {
                req.session.login = req.body.Login;
                res.redirect('/');
            }
        } else {
            res.redirect('/login');
        }
    });
});


app.post('/newmessage', function (req, res) {
    delete req.body.__proto__;
    
    var currentdate = new Date();
    req.body.Date = currentdate.getDate() + "/" 
                + (currentdate.getMonth() + 1) + "/" 
                + currentdate.getFullYear() + " " 
                + currentdate.getHours() + ":" 
                + currentdate.getMinutes() + ":" 
                + currentdate.getSeconds();
    
    nano.use(mailDbName).insert(req.body, function (err, body) {
        if (err) {
            res.redirect('/newmessage');
        } else {
            res.redirect('/');
        }
    });
});

app.get('/remove', function (req, res) {
    req.body.id = req.url.split("=").pop();
    
    nano.use(mailDbName).get(req.body.id, { revs_info: true }, function (err, body) {
        if (!err) {
            nano.use(mailDbName).destroy(req.body.id, body._rev, function (err, body, header) {
            });
        }
        res.redirect('/');
    });
});

app.get('/details', function(req, res) {
    var webSocket = require('ws');
    var socket = new webSocket("ws://localhost:1338");

    socket.on('open', function open() {

        req.body.queryType = 'details';
        req.body.id = req.url.split("=").pop();
        socket.send(JSON.stringify(req.body));
    });

    socket.on('message', function(data, flags) {
        if (data !== "") {
            data = JSON.parse(data);
        }
        res.render('details', { title: 'Details', login: req.session.login, mail: data });
    });
});


http.createServer(app).listen(app.get('port'), function() {
    console.log('Express server listening on port ' + app.get('port'));
});