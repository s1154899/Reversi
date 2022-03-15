const {src, dest} = require('gulp');

const order = require('gulp-order');
const concat = require('gulp-concat');
//const babel = require('gulp-babel');
const {files} = require("../config");


const fn = function (projectPath,filesJs,filesJsOrder) {
    return function(){


        return src(projectPath + filesJs)
            .pipe(order(filesJsOrder, { base: './' }))
            .pipe(concat('app.js'))
            //.pipe(babel({
            //    presets: ['@babel/preset-env']
            //}))
            .pipe(dest('.'))
            .pipe(dest("C:/xampp/htdocs/Reversi/Reversi/" + './dist/js'));

    }
};

exports.js = fn;