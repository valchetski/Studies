var nano = require("nano")("http://localhost:5984");
var webSocket= new require('ws');
var webSocketServer = new webSocket.Server({
    port: 1338
});

var usersDbName = "myusers";
var mailDbName = "mymail";

var clients = {};


function SendToClients(data) {
    for (var key in clients) {
        if (data === null) {
            data = "";
        }
        clients[key].send(String(data));
    }
}

function Register(jsonData) {
    nano.use(usersDbName).insert(jsonData, jsonData.Login, function (err, body) {
        if (err) {
            console.log("Inserting user failed. " + err + "\n");
        } else {
            console.log("User inserted. Response: " + JSON.stringify(body) + "\n");
        }
        SendToClients(err);
    });
}



function Inbox(jsonData) {
    var mails = [];
    var i = 0;

    nano.use(mailDbName).list({ include_docs: true }, function (err, body) {
        for (var j in body.rows) {
            if (body.rows[j].doc.To === jsonData.login) {
                mails[i] = body.rows[j].doc;
                i++;
            }
        }
        SendToClients(JSON.stringify(mails));
    });
}

function Sent(jsonData) {
    var mails = [];
    var i = 0;
    
    nano.use(mailDbName).list({ include_docs: true }, function (err, body) {
        for (var j in body.rows) {
            if (body.rows[j].doc.From === jsonData.login) {
                mails[i] = body.rows[j].doc;
                mails[i].From = body.rows[j].doc.To;
                i++;
            }
        }
        SendToClients(JSON.stringify(mails));
    });
}

function Details(jsonData) {
    nano.use(mailDbName).get(jsonData.id, { revs_info: true }, function (err, body) {
        SendToClients(JSON.stringify(body));
    });
}

webSocketServer.on('connection', function (ws) {
    var id = Math.random();
    clients[id] = ws;
    console.log("New connection" + id);

    ws.on('message', function(rModel) {
        var jsonData = JSON.parse(rModel);
        var queryType = jsonData.queryType;
        delete jsonData.queryType;
        switch (queryType) {
        case 'register':
            Register(jsonData);
            break;
        case 'inbox':
            Inbox(jsonData);
            break;
        case 'sent':
            Sent(jsonData);
            break;
        case 'details':
            Details(jsonData);
            break;
        }
    });

    ws.on('close', function () {
        console.log('Connection closed' + id);
        delete clients[id];
    });
});