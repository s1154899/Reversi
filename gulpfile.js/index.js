const config = require('./config');
const js = require('./tasks/js').js(config.localServerProjectPath,config.files.jspath,config.order);
//const js = require('./tasks/js').js(config.localServerProjectPath);
js.displayName = 'js';
const hello = function (done) {
    console.log(`Groeten van ${config.voornaam}!`);
    done();
}


exports.default = hello;
exports.js = js;