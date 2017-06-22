exports.index = function (req, res) {
    //req.session.login = 'san4es@mymail.com';
    if (req.session.login !== undefined) {
        res.redirect('/inbox');
    } else {
        res.redirect('/login');
    }
};

exports.register = function (req, res) {
    res.render('Register', { title: 'Register', login: req.session.login });
};

exports.login = function (req, res) {
    res.render('Login', { title: 'Login', login: req.session.login });
};

exports.newMessage = function (req, res) {
    res.render('NewMessage', { title: 'New message', login: req.session.login });
};

exports.inbox = function (req, res) {
    if (req.session.login !== undefined) {
        var webSocket = require('ws');
        var socket = new webSocket("ws://localhost:1338");

        socket.on('open', function open() {
            var mails = {
                login: req.session.login,
                queryType: 'inbox'
            }

            socket.send(JSON.stringify(mails));
        });

        socket.on('message', function(data, flags) {
            if (data !== "") {
                data = JSON.parse(data);
            }
            res.render('Inbox', { title: 'Inbox', login: req.session.login, mails: data });
        });
    } else {
        es.redirect('/');
    }
};

exports.sent = function (req, res) {
    var webSocket = require('ws');
    var socket = new webSocket("ws://localhost:1338");
    
    socket.on('open', function open() {
        var mails = {
            login: req.session.login,
            queryType: 'sent'
        }
        
        socket.send(JSON.stringify(mails));
    });
    
    socket.on('message', function (data, flags) {
        if (data !== "") {
            data = JSON.parse(data);
        }
        res.render('Sent', { title: 'Sent', login: req.session.login, mails: data });
    });
};

exports.signout = function (req, res) {
    req.session.login = undefined;
    res.redirect('/');
};
